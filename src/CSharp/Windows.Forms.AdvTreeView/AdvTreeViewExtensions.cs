using System.Windows.Forms;

namespace Windows.Forms
{
    public static class AdvTreeViewExtensions
    {
        /// <devdoc>
        ///     Adds a new child node to this node.  Child node is positioned after siblings.
        /// </devdoc>
        public static AdvTreeNode Add(this TreeNodeCollection nodeCollection, AdvTreeNode node)
        {
            nodeCollection.Add(node);
            return node;
        }

        /// <devdoc>
        ///     Inserts a new child node on this node.  Child node is positioned as specified by index.
        /// </devdoc>
        public static AdvTreeNode Insert(this TreeNodeCollection nodeCollection, int index, AdvTreeNode node)
        {
            nodeCollection.Insert(index, node);
            return node;
        }
        
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public static void AddRange(this TreeNodeCollection nodeCollection, AdvTreeNode[] nodes)
        {
            nodeCollection.AddRange(nodes);
        }
    }
}
