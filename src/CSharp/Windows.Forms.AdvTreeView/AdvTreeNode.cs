using System.ComponentModel;
using System.Windows.Forms;

namespace Windows.Forms
{
    public class AdvTreeNode : TreeNode
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets three state checkbox tree node value.
        /// </summary>
        [Category("Appearance"), Description("Sets tree view node three state checkboxes checked value."), DefaultValue(CheckedState.UnChecked)]
        public new CheckedState Checked
        {
            get { return (CheckedState)StateImageIndex; }
            set { StateImageIndex = (int)value; }
        }
        
        #endregion

        #region Constructors
        
        /// <devdoc> 
        ///     Creates a TreeNode object. 
        /// </devdoc>
        public AdvTreeNode() { }

        /// <devdoc> 
        ///     Creates a TreeNode object. 
        /// </devdoc>
        public AdvTreeNode(string text) : base(text) { }

        /// <devdoc>
        ///     Creates a TreeNode object. 
        /// </devdoc>
        public AdvTreeNode(string text, AdvTreeNode[] children) : base(text, children) { }

        /// <devdoc>
        ///     Creates a TreeNode object. 
        /// </devdoc>
        public AdvTreeNode(string text, int imageIndex, int selectedImageIndex) : base(text, imageIndex, selectedImageIndex) { }

        /// <devdoc> 
        ///     Creates a TreeNode object.
        /// </devdoc>
        public AdvTreeNode(string text, int imageIndex, int selectedImageIndex, AdvTreeNode[] children) : base(text, imageIndex, selectedImageIndex, children) { }

        #endregion
    }
}