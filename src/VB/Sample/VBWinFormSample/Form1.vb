
Imports Windows.Forms
Imports Windows.Forms.Windows.Forms

Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()

        AddHandler ThreeStateCheckBoxTreeView1.CheckedChanged, AddressOf threeStateCheckBoxTreeView1_CheckedChanged
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Dim treeNode1 = New AdvTreeNode("Node0")
        Dim treeNode2 = New AdvTreeNode("Node5")
        Dim treeNode3 = New AdvTreeNode("Node8")
        Dim treeNode4 = New AdvTreeNode("Node9")
        Dim treeNode5 = New AdvTreeNode("Node10")
        Dim treeNode6 = New AdvTreeNode("Node6", New AdvTreeNode() {treeNode3, treeNode4, treeNode5})
        Dim treeNode7 = New AdvTreeNode("Node7")
        Dim treeNode8 = New AdvTreeNode("Node1", New AdvTreeNode() {treeNode2, treeNode6, treeNode7})
        Dim treeNode9 = New AdvTreeNode("Node2")
        Dim treeNode10 = New AdvTreeNode("Node11")
        Dim treeNode11 = New AdvTreeNode("Node12")
        Dim treeNode12 = New AdvTreeNode("Node14")
        Dim treeNode13 = New AdvTreeNode("Node19")
        Dim treeNode14 = New AdvTreeNode("Node20")
        Dim treeNode15 = New AdvTreeNode("Node17", New AdvTreeNode() {treeNode13, treeNode14})
        Dim treeNode16 = New AdvTreeNode("Node18")
        Dim treeNode17 = New AdvTreeNode("Node15", New AdvTreeNode() {treeNode15, treeNode16})
        Dim treeNode18 = New AdvTreeNode("Node16")
        Dim treeNode19 = New AdvTreeNode("Node13", New AdvTreeNode() {treeNode12, treeNode17, treeNode18})
        Dim treeNode20 = New AdvTreeNode("Node3", New AdvTreeNode() {treeNode10, treeNode11, treeNode19})
        Dim treeNode21 = New AdvTreeNode("Node4")

        treeNode1.Name = "Node0"
        treeNode1.Checked = CheckedState.Unchecked
        treeNode1.Text = "Node0"
        treeNode2.Name = "Node5"
        treeNode2.Checked = CheckedState.UnChecked
        treeNode2.Text = "Node5"
        treeNode3.Name = "Node8"
        treeNode3.Checked = CheckedState.UnChecked
        treeNode3.Text = "Node8"
        treeNode4.Name = "Node9"
        treeNode4.Checked = CheckedState.UnChecked
        treeNode4.Text = "Node9"
        treeNode5.Name = "Node10"
        treeNode5.Checked = CheckedState.UnChecked
        treeNode5.Text = "Node10"
        treeNode6.Name = "Node6"
        treeNode6.Checked = CheckedState.UnChecked
        treeNode6.Text = "Node6"
        treeNode7.Name = "Node7"
        treeNode7.Checked = CheckedState.UnChecked
        treeNode7.Text = "Node7"
        treeNode8.Name = "Node1"
        treeNode8.Checked = CheckedState.UnChecked
        treeNode8.Text = "Node1"
        treeNode9.Name = "Node2"
        treeNode9.Checked = CheckedState.UnChecked
        treeNode9.Text = "Node2"
        treeNode10.Name = "Node11"
        treeNode10.Checked = CheckedState.UnChecked
        treeNode10.Text = "Node11"
        treeNode11.Name = "Node12"
        treeNode11.Checked = CheckedState.UnChecked
        treeNode11.Text = "Node12"
        treeNode12.Name = "Node14"
        treeNode12.Checked = CheckedState.UnChecked
        treeNode12.Text = "Node14"
        treeNode13.Name = "Node19"
        treeNode13.Checked = CheckedState.UnChecked
        treeNode13.Text = "Node19"
        treeNode14.Name = "Node20"
        treeNode14.Checked = CheckedState.UnChecked
        treeNode14.Text = "Node20"
        treeNode15.Name = "Node17"
        treeNode15.Checked = CheckedState.UnChecked
        treeNode15.Text = "Node17"
        treeNode16.Name = "Node18"
        treeNode16.Checked = CheckedState.UnChecked
        treeNode16.Text = "Node18"
        treeNode17.Name = "Node15"
        treeNode17.Checked = CheckedState.UnChecked
        treeNode17.Text = "Node15"
        treeNode18.Name = "Node16"
        treeNode18.Checked = CheckedState.UnChecked
        treeNode18.Text = "Node16"
        treeNode19.Name = "Node13"
        treeNode19.Checked = CheckedState.UnChecked
        treeNode19.Text = "Node13"
        treeNode20.Name = "Node3"
        treeNode20.Checked = CheckedState.UnChecked
        treeNode20.Text = "Node3"
        treeNode21.Name = "Node4"
        treeNode21.Checked = CheckedState.UnChecked
        treeNode21.Text = "Node4"


        ThreeStateCheckBoxTreeView1.Nodes.AddRange(New AdvTreeNode() {treeNode1, treeNode8, treeNode9, treeNode20, treeNode21})
    End Sub


    Private Sub threeStateCheckBoxTreeView1_CheckedChanged(e As AdvTreeViewEventArgs)
        e.Node.Text = e.Node.Checked.ToString()
    End Sub
End Class
