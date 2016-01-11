using System;
using System.Windows.Forms;
using Windows.Forms;

namespace CSharpWinFormSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            threeStateCheckBoxTreeView1.CheckedChanged += threeStateCheckBoxTreeView1_CheckedChanged;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var treeNode1 = new TTreeNode("Node0");
            var treeNode2 = new TTreeNode("Node5");
            var treeNode3 = new TTreeNode("Node8");
            var treeNode4 = new TTreeNode("Node9");
            var treeNode5 = new TTreeNode("Node10");
            var treeNode6 = new TTreeNode("Node6", new[]
            {
                treeNode3,
                treeNode4,
                treeNode5
            });
            var treeNode7 = new TTreeNode("Node7");
            var treeNode8 = new TTreeNode("Node1", new[]
            {
                treeNode2,
                treeNode6,
                treeNode7
            });
            var treeNode9 = new TTreeNode("Node2");
            var treeNode10 = new TTreeNode("Node11");
            var treeNode11 = new TTreeNode("Node12");
            var treeNode12 = new TTreeNode("Node14");
            var treeNode13 = new TTreeNode("Node19");
            var treeNode14 = new TTreeNode("Node20");
            var treeNode15 = new TTreeNode("Node17", new[]
            {
                treeNode13,
                treeNode14
            });
            var treeNode16 = new TTreeNode("Node18");
            var treeNode17 = new TTreeNode("Node15", new[]
            {
                treeNode15,
                treeNode16
            });
            var treeNode18 = new TTreeNode("Node16");
            var treeNode19 = new TTreeNode("Node13", new[]
            {
                treeNode12,
                treeNode17,
                treeNode18
            });
            var treeNode20 = new TTreeNode("Node3", new[]
            {
                treeNode10,
                treeNode11,
                treeNode19
            });
            var treeNode21 = new TTreeNode("Node4");

            treeNode1.Name = "Node0";
            treeNode1.Checked = CheckedState.UnChecked;
            treeNode1.Text = "Node0";
            treeNode2.Name = "Node5";
            treeNode2.Checked = CheckedState.UnChecked;
            treeNode2.Text = "Node5";
            treeNode3.Name = "Node8";
            treeNode3.Checked = CheckedState.UnChecked;
            treeNode3.Text = "Node8";
            treeNode4.Name = "Node9";
            treeNode4.Checked = CheckedState.UnChecked;
            treeNode4.Text = "Node9";
            treeNode5.Name = "Node10";
            treeNode5.Checked = CheckedState.UnChecked;
            treeNode5.Text = "Node10";
            treeNode6.Name = "Node6";
            treeNode6.Checked = CheckedState.UnChecked;
            treeNode6.Text = "Node6";
            treeNode7.Name = "Node7";
            treeNode7.Checked = CheckedState.UnChecked;
            treeNode7.Text = "Node7";
            treeNode8.Name = "Node1";
            treeNode8.Checked = CheckedState.UnChecked;
            treeNode8.Text = "Node1";
            treeNode9.Name = "Node2";
            treeNode9.Checked = CheckedState.UnChecked;
            treeNode9.Text = "Node2";
            treeNode10.Name = "Node11";
            treeNode10.Checked = CheckedState.UnChecked;
            treeNode10.Text = "Node11";
            treeNode11.Name = "Node12";
            treeNode11.Checked = CheckedState.UnChecked;
            treeNode11.Text = "Node12";
            treeNode12.Name = "Node14";
            treeNode12.Checked = CheckedState.UnChecked;
            treeNode12.Text = "Node14";
            treeNode13.Name = "Node19";
            treeNode13.Checked = CheckedState.UnChecked;
            treeNode13.Text = "Node19";
            treeNode14.Name = "Node20";
            treeNode14.Checked = CheckedState.UnChecked;
            treeNode14.Text = "Node20";
            treeNode15.Name = "Node17";
            treeNode15.Checked = CheckedState.UnChecked;
            treeNode15.Text = "Node17";
            treeNode16.Name = "Node18";
            treeNode16.Checked = CheckedState.UnChecked;
            treeNode16.Text = "Node18";
            treeNode17.Name = "Node15";
            treeNode17.Checked = CheckedState.UnChecked;
            treeNode17.Text = "Node15";
            treeNode18.Name = "Node16";
            treeNode18.Checked = CheckedState.UnChecked;
            treeNode18.Text = "Node16";
            treeNode19.Name = "Node13";
            treeNode19.Checked = CheckedState.UnChecked;
            treeNode19.Text = "Node13";
            treeNode20.Name = "Node3";
            treeNode20.Checked = CheckedState.UnChecked;
            treeNode20.Text = "Node3";
            treeNode21.Name = "Node4";
            treeNode21.Checked = CheckedState.UnChecked;
            treeNode21.Text = "Node4";


            threeStateCheckBoxTreeView1.Nodes.AddRange(new TreeNode[]
            {
                treeNode1,
                treeNode8,
                treeNode9,
                treeNode20,
                treeNode21
            });
        }

        
        private void threeStateCheckBoxTreeView1_CheckedChanged(TTreeViewEventArgs e)
        {
            e.Node.Text = e.Node.Checked.ToString();
        }
    }
}