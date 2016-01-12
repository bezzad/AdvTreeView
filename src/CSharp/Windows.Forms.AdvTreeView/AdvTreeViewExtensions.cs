using System.Collections.Generic;
using System.Windows.Forms;

namespace Windows.Forms
{
    public static class AdvTreeViewExtensions
    {
        public static CheckedState CheckState(this TreeNode node)
        {
            return (CheckedState)node.StateImageIndex;
        }

        public static TreeNode GetFirstCheckedSiblingNode(this TreeNode node)
        {
            while (node.Parent != null && node.Parent.GetNodeCount(false) > 1) // have sibling node except self?
            {
                foreach (TreeNode sibling in node.Parent.Nodes)
                {
                    if (sibling.Index != node.Index && sibling.CheckState() != CheckedState.UnChecked)
                    // is sibling node not me and checked or mixed?
                    {
                        return sibling;
                    }
                }

                node = node.Parent; // check next time, this node parent sibling nodes
            }

            return null;
        }

        public static List<TreeNode> GetCheckedSiblingsNode(this TreeNode node)
        {
            var siblings = new List<TreeNode>();

            while (node.Parent != null && node.Parent.GetNodeCount(false) > 1) // have sibling node except self?
            {
                foreach (TreeNode sibling in node.Parent.Nodes)
                {
                    if (sibling.Index != node.Index && sibling.CheckState() != CheckedState.UnChecked)
                    // is sibling node not me and checked or mixed?
                    {
                        siblings.Add(sibling);
                    }
                }

                node = node.Parent; // check next time, this node parent sibling nodes
            }

            return siblings;
        }

        internal static string GetUniqueValue(this TreeNode node)
        {
            string key = "";
            
            while (node != null)
            {
                key += string.Format(@"\{0}", node.Index);
                node = node.Parent;
            }

            return key;
        }
    }
}