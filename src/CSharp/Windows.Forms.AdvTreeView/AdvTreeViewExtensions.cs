using System.Windows.Forms;

namespace Windows.Forms
{
    public static class AdvTreeViewExtensions
    {
        public static CheckedState CheckState(this TreeNode node)
        {
            return (CheckedState)node.StateImageIndex;
        }
    }
}
