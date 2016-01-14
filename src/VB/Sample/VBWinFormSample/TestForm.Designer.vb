<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.label3 = New System.Windows.Forms.Label()
        Me.numErrorDuration = New System.Windows.Forms.NumericUpDown()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtSiblingSelectError = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtParentSelectError = New System.Windows.Forms.TextBox()
        Me.chkSiblingCheckLimitation = New System.Windows.Forms.CheckBox()
        Me.advTree = New Windows.Forms.AdvTreeView()
        CType(Me.numErrorDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label3
        '
        Me.label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(342, 306)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(75, 13)
        Me.label3.TabIndex = 23
        Me.label3.Text = "Error Duration:"
        '
        'numErrorDuration
        '
        Me.numErrorDuration.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numErrorDuration.Location = New System.Drawing.Point(423, 304)
        Me.numErrorDuration.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numErrorDuration.Name = "numErrorDuration"
        Me.numErrorDuration.Size = New System.Drawing.Size(120, 20)
        Me.numErrorDuration.TabIndex = 22
        '
        'label2
        '
        Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(11, 357)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(96, 13)
        Me.label2.TabIndex = 21
        Me.label2.Text = "SiblingSelectError: "
        '
        'txtSiblingSelectError
        '
        Me.txtSiblingSelectError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSiblingSelectError.Location = New System.Drawing.Point(116, 354)
        Me.txtSiblingSelectError.Name = "txtSiblingSelectError"
        Me.txtSiblingSelectError.Size = New System.Drawing.Size(427, 20)
        Me.txtSiblingSelectError.TabIndex = 20
        '
        'label1
        '
        Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(11, 331)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(96, 13)
        Me.label1.TabIndex = 19
        Me.label1.Text = "ParentSelectError: "
        '
        'txtParentSelectError
        '
        Me.txtParentSelectError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtParentSelectError.Location = New System.Drawing.Point(116, 328)
        Me.txtParentSelectError.Name = "txtParentSelectError"
        Me.txtParentSelectError.Size = New System.Drawing.Size(427, 20)
        Me.txtParentSelectError.TabIndex = 18
        '
        'chkSiblingCheckLimitation
        '
        Me.chkSiblingCheckLimitation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkSiblingCheckLimitation.AutoSize = True
        Me.chkSiblingCheckLimitation.Location = New System.Drawing.Point(14, 305)
        Me.chkSiblingCheckLimitation.Name = "chkSiblingCheckLimitation"
        Me.chkSiblingCheckLimitation.Size = New System.Drawing.Size(138, 17)
        Me.chkSiblingCheckLimitation.TabIndex = 17
        Me.chkSiblingCheckLimitation.Text = "Sibling Check Limitation"
        Me.chkSiblingCheckLimitation.UseVisualStyleBackColor = True
        '
        'advTree
        '
        Me.advTree.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.advTree.CheckBoxes = True
        Me.advTree.CheckNodeValidation = Nothing
        Me.advTree.ErrorForeColor = System.Drawing.Color.Crimson
        Me.advTree.FullRowSelect = True
        Me.advTree.Indent = 30
        Me.advTree.Location = New System.Drawing.Point(0, 4)
        Me.advTree.Name = "advTree"
        Me.advTree.NodeErrorDuration = 0
        Me.advTree.ParentNodeSelectError = "Parent not selectable class!"
        Me.advTree.ShowNodeToolTips = True
        Me.advTree.SiblingNodeSelectError = "The ({0}) is a selected sibling node was found!"
        Me.advTree.Size = New System.Drawing.Size(553, 295)
        Me.advTree.TabIndex = 16
        '
        'TestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 379)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.numErrorDuration)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.txtSiblingSelectError)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.txtParentSelectError)
        Me.Controls.Add(Me.chkSiblingCheckLimitation)
        Me.Controls.Add(Me.advTree)
        Me.Name = "TestForm"
        Me.Text = "VB Three State CheckBox TreeView"
        CType(Me.numErrorDuration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents numErrorDuration As System.Windows.Forms.NumericUpDown
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents txtSiblingSelectError As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents txtParentSelectError As System.Windows.Forms.TextBox
    Private WithEvents chkSiblingCheckLimitation As System.Windows.Forms.CheckBox
    Private WithEvents advTree As Windows.Forms.AdvTreeView
End Class
