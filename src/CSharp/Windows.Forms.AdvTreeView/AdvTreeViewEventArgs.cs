using System;

namespace Windows.Forms
{
    /// <devdoc>
    ///    <para>
    ///       Provides data for the <see cref='Windows.Forms.AdvTreeView.OnCheckedChanged'/> event. 
    ///    </para>
    /// </devdoc> 
    public class AdvTreeViewEventArgs : EventArgs
    {
        AdvTreeNode node;

        /// <devdoc>
        ///    <para>[To be supplied.]</para> 
        /// </devdoc>
        public AdvTreeViewEventArgs(AdvTreeNode node)
        {
            this.node = node;
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc> 
        public AdvTreeNode Node
        {
            get
            {
                return node;
            }
        }
    }
}