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

