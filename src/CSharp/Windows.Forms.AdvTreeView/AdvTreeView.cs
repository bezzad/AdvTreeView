using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Windows.Forms
{
    /// <summary>
    /// Provides a tree view control supporting three state checkboxes.
    /// </summary>
    public class AdvTreeView : TreeView
    {
        #region Events
        
        public delegate void CheckedChangedHandler(TreeViewEventArgs e);
        public event CheckedChangedHandler CheckedChanged;
        protected virtual void OnCheckedChanged(TreeViewEventArgs e)
        {
            CheckedChangedHandler handler = CheckedChanged;
            if (handler != null) handler(e);
        }

        #endregion

        #region Fields

        readonly ImageList _ilStateImages;
        bool _checkBoxesVisible;
        bool _preventCheckEvent;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance
        /// of this control.
        /// </summary>
        public AdvTreeView()
        {
            _ilStateImages = new ImageList();											// first we create our state image
            var cbsState = CheckBoxState.UncheckedNormal;

            for (int i = 0; i <= 2; i++)
            {												// let's iterate each three state
                var bmpCheckBox = new Bitmap(16, 16);
                var gfxCheckBox = Graphics.FromImage(bmpCheckBox);
                switch (i)
                {															// it...
                    case 0: cbsState = CheckBoxState.UncheckedNormal; break;
                    case 1: cbsState = CheckBoxState.CheckedNormal; break;
                    case 2: cbsState = CheckBoxState.MixedNormal; break;
                }
                CheckBoxRenderer.DrawCheckBox(gfxCheckBox, new Point(2, 2), cbsState);	// ...rendering the checkbox and...
                gfxCheckBox.Save();
                _ilStateImages.Images.Add(bmpCheckBox);									// ...adding to sate image list.

                CheckBoxesThreeState = true;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets to display
        /// checkboxes in the tree
        /// view.
        /// </summary>
        [Category("Appearance")]
        [Description("Sets tree view to display checkboxes or not.")]
        [DefaultValue(false)]
        public new bool CheckBoxes
        {
            get { return _checkBoxesVisible; }
            set
            {
                _checkBoxesVisible = value;
                base.CheckBoxes = _checkBoxesVisible;
                this.StateImageList = _checkBoxesVisible ? _ilStateImages : null;
            }
        }

        [Browsable(false)]
        public new ImageList StateImageList
        {
            get { return base.StateImageList; }
            set { base.StateImageList = value; }
        }

        /// <summary>
        /// Gets or sets to support three state in the checkboxes or not.
        /// </summary>
        [Category("Appearance"), Description("Sets tree view to use three state checkboxes or not."), DefaultValue(true)]
        public bool CheckBoxesThreeState { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Refreshes this
        /// control.
        /// </summary>
        public override void Refresh()
        {
            base.Refresh();

            if (!CheckBoxes)												// nothing to do here if
                return;														// checkboxes are hidden.

            base.CheckBoxes = false;										// hide normal checkboxes...

            var stNodes = new Stack<TreeNode>(this.Nodes.Count);
            foreach (TreeNode tnCurrent in this.Nodes)						// push each root node.
                stNodes.Push(tnCurrent);

            while (stNodes.Count > 0)
            {										                        // let's pop node from stack,
                var tnStacked = stNodes.Pop();
                if (tnStacked.StateImageIndex == -1)						// index if not already done
                    tnStacked.StateImageIndex = tnStacked.Checked ? 1 : 0;	// and push each child to stack
                for (int i = 0; i < tnStacked.Nodes.Count; i++)				// too until there are no
                    stNodes.Push(tnStacked.Nodes[i]);						// nodes left on stack.
            }
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            Refresh();
        }

        protected override void OnAfterExpand(TreeViewEventArgs e)
        {
            base.OnAfterExpand(e);

            foreach (TreeNode tnCurrent in e.Node.Nodes)					// set tree state image
                if (tnCurrent.StateImageIndex == -1)						// to each child node...
                    tnCurrent.StateImageIndex = tnCurrent.Checked ? 1 : 0;
        }

        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            base.OnAfterCheck(e);

            if (_preventCheckEvent)
                return;

            OnNodeMouseClick(new TreeNodeMouseClickEventArgs(e.Node, MouseButtons.None, 0, 0, 0));
        }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            base.OnNodeMouseClick(e);
            
            _preventCheckEvent = true;

            int iSpacing = ImageList == null ? 0 : 18;
            if ((e.X > e.Node.Bounds.Left - iSpacing ||						// *not* used by the state
                 e.X < e.Node.Bounds.Left - (iSpacing + 16)) &&				// image we can leave here.
                 e.Button != MouseButtons.None)
            { return; }

            var tnBuffer = e.Node;
            if (e.Button == MouseButtons.Left)								// flip its check state.
                tnBuffer.Checked = !tnBuffer.Checked;

            tnBuffer.StateImageIndex = tnBuffer.Checked ?					// set state image index
                                        1 : tnBuffer.StateImageIndex;		// correctly.

            OnAfterCheck(new TreeViewEventArgs(tnBuffer, TreeViewAction.ByMouse));

            var stNodes = new Stack<TreeNode>(tnBuffer.Nodes.Count);
            stNodes.Push(tnBuffer);											// push buffered node first.
            do
            {															// let's pop node from stack,
                tnBuffer = stNodes.Pop();									// inherit buffered node's
                tnBuffer.Checked = e.Node.Checked;                          // check state and push
                tnBuffer.StateImageIndex = e.Node.Checked ? 1 : 0;
                OnCheckedChanged(new TreeViewEventArgs(tnBuffer));

                for (int i = 0; i < tnBuffer.Nodes.Count; i++)				// each child on the stack
                    stNodes.Push(tnBuffer.Nodes[i]);						// until there is no node
            } while (stNodes.Count > 0);									// left.
            
            var bMixedState = false;
            tnBuffer = e.Node;												// re-buffer clicked node.
            while (tnBuffer.Parent != null)
            {								// while we get a parent we
                foreach (TreeNode tnChild in tnBuffer.Parent.Nodes)			// determine mixed check states
                    bMixedState |= (tnChild.Checked != tnBuffer.Checked |	// and convert current check
                                    tnChild.StateImageIndex == 2);			// state to state image index.
                var iIndex = (int)Convert.ToUInt32(tnBuffer.Checked);
                tnBuffer.Parent.Checked = bMixedState || (iIndex > 0);		// state image in dependency
                if (bMixedState)											// of mixed state.
                    tnBuffer.Parent.StateImageIndex = CheckBoxesThreeState ? 2 : 1;
                else
                    tnBuffer.Parent.StateImageIndex = iIndex;
                tnBuffer = tnBuffer.Parent;									// finally buffer parent and

                OnCheckedChanged(new TreeViewEventArgs(tnBuffer));
            }																// loop here.

            _preventCheckEvent = false;

            // set this node StateImageIndex to 0 if not checked
            if (!e.Node.Checked) e.Node.StateImageIndex = 0;
            // raise checked changed event
            OnCheckedChanged(new TreeViewEventArgs(e.Node));
        }


        #endregion
    }
}
