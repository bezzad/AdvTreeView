Imports Windows.Forms
Imports Windows.Forms.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.ThreeStateCheckBoxTreeView1 = New AdvTreeView()
        Me.SuspendLayout()
        '
        'ThreeStateCheckBoxTreeView1
        '
        Me.ThreeStateCheckBoxTreeView1.CheckBoxes = True
        Me.ThreeStateCheckBoxTreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ThreeStateCheckBoxTreeView1.FullRowSelect = True
        Me.ThreeStateCheckBoxTreeView1.HotTracking = True
        Me.ThreeStateCheckBoxTreeView1.Location = New System.Drawing.Point(0, 0)
        Me.ThreeStateCheckBoxTreeView1.Name = "ThreeStateCheckBoxTreeView1"
        Me.ThreeStateCheckBoxTreeView1.Size = New System.Drawing.Size(702, 449)
        Me.ThreeStateCheckBoxTreeView1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 449)
        Me.Controls.Add(Me.ThreeStateCheckBoxTreeView1)
        Me.Name = "Form1"
        Me.Text = "Three State CheckBox TreeView"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ThreeStateCheckBoxTreeView1 As AdvTreeView

End Class
