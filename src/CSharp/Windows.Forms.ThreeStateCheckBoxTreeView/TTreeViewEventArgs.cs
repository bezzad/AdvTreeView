using System;

namespace Windows.Forms
{
    /// <devdoc>
    ///    <para>
    ///       Provides data for the <see cref='Windows.Forms.ThreeStateCheckBoxTreeView.OnCheckedChanged'/> event. 
    ///    </para>
    /// </devdoc> 
    public class TTreeViewEventArgs : EventArgs
    {
        TTreeNode node;

        /// <devdoc>
        ///    <para>[To be supplied.]</para> 
        /// </devdoc>
        public TTreeViewEventArgs(TTreeNode node)
        {
            this.node = node;
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc> 
        public TTreeNode Node
        {
            get
            {
                return node;
            }
        }
    }
}