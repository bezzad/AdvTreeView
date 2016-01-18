using System;
using System.Windows.Forms;
using Windows.Forms;

namespace CSharpWinFormSample
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            advTree.CheckedChanged += advTree_CheckedChanged;
            chkSiblingCheckLimitation.CheckedChanged += chkSiblingCheckLimitation_CheckedChanged;
            numErrorDuration.ValueChanged += numErrorDuration_ValueChanged;
            txtSiblingSelectError.TextChanged += txtSiblingSelectError_TextChanged;
            txtParentSelectError.TextChanged += txtParentSelectError_TextChanged;

            txtParentSelectError.Text = advTree.ParentNodeSelectError;
            txtSiblingSelectError.Text = advTree.SiblingNodeSelectError;
            numErrorDuration.Value = 3000;
            advTree.CheckNodeValidation = NodeValidation;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var treeNode1 = new TreeNode("Node0");
            var treeNode2 = new TreeNode("Node5");
            var treeNode3 = new TreeNode("Node8");
            var treeNode4 = new TreeNode("Node9");
            var treeNode5 = new TreeNode("Node10");
            var treeNode6 = new TreeNode("Node6");
            treeNode6.AddRangeNodes(new TreeNode[]
            {
                treeNode3,
                treeNode4,
                treeNode5
            });
            var treeNode7 = new TreeNode("Node7");
            var treeNode8 = new TreeNode("Node1");
            treeNode8.AddRangeNodes(new TreeNode[]
            {
                treeNode2,
                treeNode6,
                treeNode7
            });
            var treeNode9 = new TreeNode("Node2");
            var treeNode10 = new TreeNode("Node11");
            var treeNode11 = new TreeNode("Node12");
            var treeNode12 = new TreeNode("Node14");
            var treeNode13 = new TreeNode("Node19");
            var treeNode14 = new TreeNode("Node20");
            var treeNode15 = new TreeNode("Node17");
            treeNode15.AddRangeNodes(new TreeNode[]
            {
                treeNode13,
                treeNode14
            });
            var treeNode16 = new TreeNode("Node18");
            var treeNode17 = new TreeNode("Node15");
            treeNode17.AddRangeNodes(new TreeNode[]
            {
                treeNode15,
                treeNode16
            });
            var treeNode18 = new TreeNode("Node16");
            var treeNode19 = new TreeNode("Node13");
            treeNode19.AddRangeNodes(new TreeNode[]
            {
                treeNode12,
                treeNode17,
                treeNode18
            });
            var treeNode20 = new TreeNode("Node3");
            treeNode20.AddRangeNodes(new TreeNode[]
            {
                treeNode10,
                treeNode11,
                treeNode19
            });
            var treeNode21 = new TreeNode("Node4");

            treeNode1.Name = "Node0";
            treeNode1.Text = "Node0";
            treeNode2.Name = "Node5";
            treeNode2.Text = "Node5";
            treeNode3.Name = "Node8";
            treeNode3.Text = "Node8";
            treeNode4.Name = "Node9";
            treeNode4.Text = "Node9";
            treeNode5.Name = "Node10";
            treeNode5.Text = "Node10";
            treeNode6.Name = "Node6";
            treeNode6.Text = "Node6";
            treeNode7.Name = "Node7";
            treeNode7.Text = "Node7";
            treeNode8.Name = "Node1";
            treeNode8.Text = "Node1";
            treeNode9.Name = "Node2";
            treeNode9.Text = "Node2";
            treeNode10.Name = "Node11";
            treeNode10.Text = "Node11";
            treeNode11.Name = "Node12";
            treeNode11.Text = "Node12";
            treeNode12.Name = "Node14";
            treeNode12.Text = "Node14";
            treeNode13.Name = "Node19";
            treeNode13.Text = "Node19";
            treeNode14.Name = "Node20";
            treeNode14.Text = "Node20";
            treeNode15.Name = "Node17";
            treeNode15.Text = "Node17";
            treeNode16.Name = "Node18";
            treeNode16.Text = "Node18";
            treeNode17.Name = "Node15";
            treeNode17.Text = "Node15";
            treeNode18.Name = "Node16";
            treeNode18.Text = "Node16";
            treeNode19.Name = "Node13";
            treeNode19.Text = "Node13";
            treeNode20.Name = "Node3";
            treeNode20.Text = "Node3";
            treeNode21.Name = "Node4";
            treeNode21.Text = "Node4";


            advTree.AddRange(new TreeNode[]
            {
                treeNode1,
                treeNode8,
                treeNode9,
                treeNode20,
                treeNode21
            });
        }


        private void advTree_CheckedChanged(TreeViewEventArgs e)
        {
            e.Node.Text = e.Node.Index + e.Node.CheckState().ToString();
        }

        private void chkSiblingCheckLimitation_CheckedChanged(object sender, EventArgs e)
        {
            advTree.SiblingLimitSelection = ((CheckBox)sender).Checked;
        }

        private void txtSiblingSelectError_TextChanged(object sender, EventArgs e)
        {
            advTree.SiblingNodeSelectError = txtSiblingSelectError.Text;
        }

        private void txtParentSelectError_TextChanged(object sender, EventArgs e)
        {
            advTree.ParentNodeSelectError = txtParentSelectError.Text;
        }

        private void numErrorDuration_ValueChanged(object sender, EventArgs e)
        {
            advTree.NodeErrorDuration = (int)numErrorDuration.Value;
        }

        private string NodeValidation(TreeNode e)
        {
            return e.Text.Contains("0UnChecked") ? "This is not valid" : null;
        }
    }
}