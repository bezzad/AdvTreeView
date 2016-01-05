namespace CSharpWinFormSample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node5");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node8");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node9");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node10");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node6", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node7");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node11");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node12");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Node14");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Node19");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Node20");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Node17", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Node18");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Node15", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Node16");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Node13", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Node3", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Node4");
            this.threeStateCheckBoxTreeView1 = new Windows.Forms.ThreeStateCheckBoxTreeView();
            this.SuspendLayout();
            // 
            // threeStateCheckBoxTreeView1
            // 
            this.threeStateCheckBoxTreeView1.CheckBoxes = true;
            this.threeStateCheckBoxTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threeStateCheckBoxTreeView1.HotTracking = true;
            this.threeStateCheckBoxTreeView1.Location = new System.Drawing.Point(0, 0);
            this.threeStateCheckBoxTreeView1.Name = "threeStateCheckBoxTreeView1";
            treeNode1.Name = "Node0";
            treeNode1.StateImageIndex = 0;
            treeNode1.Text = "Node0";
            treeNode2.Name = "Node5";
            treeNode2.StateImageIndex = 0;
            treeNode2.Text = "Node5";
            treeNode3.Name = "Node8";
            treeNode3.StateImageIndex = 0;
            treeNode3.Text = "Node8";
            treeNode4.Name = "Node9";
            treeNode4.StateImageIndex = 0;
            treeNode4.Text = "Node9";
            treeNode5.Name = "Node10";
            treeNode5.StateImageIndex = 0;
            treeNode5.Text = "Node10";
            treeNode6.Name = "Node6";
            treeNode6.StateImageIndex = 0;
            treeNode6.Text = "Node6";
            treeNode7.Name = "Node7";
            treeNode7.StateImageIndex = 0;
            treeNode7.Text = "Node7";
            treeNode8.Name = "Node1";
            treeNode8.StateImageIndex = 0;
            treeNode8.Text = "Node1";
            treeNode9.Name = "Node2";
            treeNode9.StateImageIndex = 0;
            treeNode9.Text = "Node2";
            treeNode10.Name = "Node11";
            treeNode10.StateImageIndex = 0;
            treeNode10.Text = "Node11";
            treeNode11.Name = "Node12";
            treeNode11.StateImageIndex = 0;
            treeNode11.Text = "Node12";
            treeNode12.Name = "Node14";
            treeNode12.StateImageIndex = 0;
            treeNode12.Text = "Node14";
            treeNode13.Name = "Node19";
            treeNode13.StateImageIndex = 0;
            treeNode13.Text = "Node19";
            treeNode14.Name = "Node20";
            treeNode14.StateImageIndex = 0;
            treeNode14.Text = "Node20";
            treeNode15.Name = "Node17";
            treeNode15.StateImageIndex = 0;
            treeNode15.Text = "Node17";
            treeNode16.Name = "Node18";
            treeNode16.StateImageIndex = 0;
            treeNode16.Text = "Node18";
            treeNode17.Name = "Node15";
            treeNode17.StateImageIndex = 0;
            treeNode17.Text = "Node15";
            treeNode18.Name = "Node16";
            treeNode18.StateImageIndex = 0;
            treeNode18.Text = "Node16";
            treeNode19.Name = "Node13";
            treeNode19.StateImageIndex = 0;
            treeNode19.Text = "Node13";
            treeNode20.Name = "Node3";
            treeNode20.StateImageIndex = 0;
            treeNode20.Text = "Node3";
            treeNode21.Name = "Node4";
            treeNode21.StateImageIndex = 0;
            treeNode21.Text = "Node4";
            this.threeStateCheckBoxTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode8,
            treeNode9,
            treeNode20,
            treeNode21});
            this.threeStateCheckBoxTreeView1.Size = new System.Drawing.Size(414, 345);
            this.threeStateCheckBoxTreeView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 345);
            this.Controls.Add(this.threeStateCheckBoxTreeView1);
            this.Name = "Form1";
            this.Text = "Three State CheckBox TreeView";
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.Forms.ThreeStateCheckBoxTreeView threeStateCheckBoxTreeView1;
    }
}

