namespace CSharpWinFormSample
{
    partial class TestForm
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
            this.chkSiblingCheckLimitation = new System.Windows.Forms.CheckBox();
            this.txtParentSelectError = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSiblingSelectError = new System.Windows.Forms.TextBox();
            this.numErrorDuration = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.advTree = new Windows.Forms.AdvTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.numErrorDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSiblingCheckLimitation
            // 
            this.chkSiblingCheckLimitation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSiblingCheckLimitation.AutoSize = true;
            this.chkSiblingCheckLimitation.Location = new System.Drawing.Point(12, 302);
            this.chkSiblingCheckLimitation.Name = "chkSiblingCheckLimitation";
            this.chkSiblingCheckLimitation.Size = new System.Drawing.Size(138, 17);
            this.chkSiblingCheckLimitation.TabIndex = 1;
            this.chkSiblingCheckLimitation.Text = "Sibling Check Limitation";
            this.chkSiblingCheckLimitation.UseVisualStyleBackColor = true;
            // 
            // txtParentSelectError
            // 
            this.txtParentSelectError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtParentSelectError.Location = new System.Drawing.Point(114, 325);
            this.txtParentSelectError.Name = "txtParentSelectError";
            this.txtParentSelectError.Size = new System.Drawing.Size(427, 20);
            this.txtParentSelectError.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ParentSelectError: ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "SiblingSelectError: ";
            // 
            // txtSiblingSelectError
            // 
            this.txtSiblingSelectError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSiblingSelectError.Location = new System.Drawing.Point(114, 351);
            this.txtSiblingSelectError.Name = "txtSiblingSelectError";
            this.txtSiblingSelectError.Size = new System.Drawing.Size(427, 20);
            this.txtSiblingSelectError.TabIndex = 4;
            // 
            // numErrorDuration
            // 
            this.numErrorDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numErrorDuration.Location = new System.Drawing.Point(421, 301);
            this.numErrorDuration.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numErrorDuration.Name = "numErrorDuration";
            this.numErrorDuration.Size = new System.Drawing.Size(120, 20);
            this.numErrorDuration.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Error Duration:";
            // 
            // advTree
            // 
            this.advTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advTree.CheckBoxes = true;
            this.advTree.CheckNodeValidation = null;
            this.advTree.ErrorForeColor = System.Drawing.Color.Crimson;
            this.advTree.FullRowSelect = true;
            this.advTree.Indent = 30;
            this.advTree.Location = new System.Drawing.Point(-2, 1);
            this.advTree.Name = "advTree";
            this.advTree.NodeErrorDuration = 0;
            this.advTree.ParentNodeSelectError = "Parent not selectable class!";
            this.advTree.ShowNodeToolTips = true;
            this.advTree.SiblingNodeSelectError = "The ({0}) is a selected sibling node was found!";
            this.advTree.Size = new System.Drawing.Size(553, 295);
            this.advTree.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 379);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numErrorDuration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSiblingSelectError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtParentSelectError);
            this.Controls.Add(this.chkSiblingCheckLimitation);
            this.Controls.Add(this.advTree);
            this.Name = "TestForm";
            this.Text = "C# Three State CheckBox TreeView";
            ((System.ComponentModel.ISupportInitialize)(this.numErrorDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.Forms.AdvTreeView advTree;
        private System.Windows.Forms.CheckBox chkSiblingCheckLimitation;
        private System.Windows.Forms.TextBox txtParentSelectError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSiblingSelectError;
        private System.Windows.Forms.NumericUpDown numErrorDuration;
        private System.Windows.Forms.Label label3;
    }
}

