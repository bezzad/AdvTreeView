Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles


''' <summary>
''' Provides a tree view control supporting three state checkboxes.
''' </summary>
Public Class AdvTreeView
    Inherits TreeView

#Region "Events"

    ''' <summary>
    ''' Validate node must checked or not ? and get not check cause message
    ''' </summary>
    ''' <param name="e">Current checked Node</param>
    ''' <returns>Why must not check error message. if must checked and not any error then return null</returns>
    Public Delegate Function NodeValidator(e As TreeNode) As String

    Public Delegate Sub CheckedChangedHandler(e As TreeViewEventArgs)
    Public Event CheckedChanged As CheckedChangedHandler
    Protected Overridable Sub OnCheckedChanged(e As TreeViewEventArgs)
        RaiseEvent CheckedChanged(e)
    End Sub

    Public Delegate Sub NodeAddedHandler(e As TreeViewEventArgs)
    Public Event NodeAdded As NodeAddedHandler
    Protected Overridable Sub OnNodeAdded(e As TreeViewEventArgs)
        e.Node.Checked = e.Node.Checked
        RaiseEvent NodeAdded(e)
    End Sub

    Friend Sub PerformNodeAdded(node As TreeNode)
        OnNodeAdded(New TreeViewEventArgs(node))
    End Sub

#End Region

#Region "Fields"

    Private ReadOnly _ilStateImages As ImageList
    Private ReadOnly _errorNodes As List(Of String)
    Private _checkBoxesVisible As Boolean
    Private _preventCheckEvent As Boolean

#End Region

#Region "Constructors"

    ''' <summary>
    ''' Creates a new instance of this control.
    ''' </summary>
    Public Sub New()
        _errorNodes = New List(Of String)()
        NodeErrorDuration = 3000
        ErrorForeColor = Color.Crimson
        ParentNodeSelectError = "Parent not selectable class!"
        SiblingNodeSelectError = "The ({0}) is a selected sibling node was found!"

        _ilStateImages = New ImageList()
        ' first we create our state image
        Dim cbsState = CheckBoxState.UncheckedNormal

        For i As Integer = 0 To 2
            ' let's iterate each three state
            Dim bmpCheckBox = New Bitmap(16, 16)
            Dim gfxCheckBox = Graphics.FromImage(bmpCheckBox)
            Select Case i
                ' it...
                Case 0
                    cbsState = CheckBoxState.UncheckedNormal
                    Exit Select
                Case 1
                    cbsState = CheckBoxState.CheckedNormal
                    Exit Select
                Case 2
                    cbsState = CheckBoxState.MixedNormal
                    Exit Select
            End Select
            CheckBoxRenderer.DrawCheckBox(gfxCheckBox, New Point(2, 2), cbsState)
            ' ...rendering the checkbox and...
            gfxCheckBox.Save()
            _ilStateImages.Images.Add(bmpCheckBox)
            ' ...adding to sate image list.
            CheckBoxesThreeState = True
        Next
    End Sub

#End Region

#Region "Properties"

    ''' <summary>
    ''' Gets or sets to display
    ''' checkboxes in the tree
    ''' view.
    ''' </summary>
    <Category("Appearance")> _
    <Description("Sets tree view to display checkboxes or not.")> _
    <DefaultValue(False)> _
    Public Shadows Property CheckBoxes() As Boolean
        Get
            Return _checkBoxesVisible
        End Get
        Set(value As Boolean)
            _checkBoxesVisible = value
            MyBase.CheckBoxes = _checkBoxesVisible
            Me.StateImageList = If(_checkBoxesVisible, _ilStateImages, Nothing)
        End Set
    End Property

    <Browsable(False)> _
    Public Shadows Property StateImageList() As ImageList

    ''' <summary>
    ''' Gets or sets to support three state in the checkboxes or not.
    ''' </summary>
    <Category("Appearance"), Description("Sets tree view to use three state checkboxes or not."), DefaultValue(True)> _
    Public Property CheckBoxesThreeState() As Boolean

    ''' <summary>
    ''' Gets or sets to no support multi sibling checks.
    ''' </summary>
    <Category("Appearance"), Description("Gets or sets to no support multi sibling checks."), DefaultValue(False)> _
    Public Property SiblingLimitSelection() As Boolean

    ''' <summary>
    ''' Gets or sets Parent select error message.
    ''' </summary>
    <Category("Appearance"), Description("Gets or sets Parent select error message.")> _
    Public Property ParentNodeSelectError() As String

    ''' <summary>
    ''' Gets or sets Sibling select error message.
    ''' </summary>
    <Category("Appearance"), Description("Gets or sets Sibling select error message.")> _
    Public Property SiblingNodeSelectError() As String

    ''' <summary>
    ''' Gets or sets select error duration per millisecond.
    ''' </summary>
    <Category("Appearance"), Description("Gets or sets select error duration per millisecond.")> _
    Public Property NodeErrorDuration() As Integer

    ''' <summary>
    ''' Gets or sets select error ForeColor.
    ''' </summary>
    <Category("Appearance"), Description("Gets or sets select error ForeColor.")> _
    Public Property ErrorForeColor() As Color

    ''' <summary>
    ''' TreeNode validator for define selected node must checked or not ? and get not check cause message
    ''' </summary>
    ''' <value>
    ''' The check node validation.
    ''' </value>
    <Browsable(False)> _
    Public Property CheckNodeValidation() As NodeValidator

#End Region

#Region "Methods"

    ''' <summary>
    ''' Refreshes this control.
    ''' </summary>
    Public Overrides Sub Refresh()
        MyBase.Refresh()

        If Not CheckBoxes Then
            ' nothing to do here if
            Return
        End If
        ' checkboxes are hidden.
        MyBase.CheckBoxes = False
        ' hide normal checkboxes...
        Dim stNodes = New Stack(Of TreeNode)(Me.Nodes.Count)
        For Each tnCurrent As TreeNode In Me.Nodes
            ' push each root node.
            stNodes.Push(tnCurrent)
        Next

        While stNodes.Count > 0
            ' let's pop node from stack,
            Dim tnStacked = stNodes.Pop()
            If tnStacked.StateImageIndex = -1 Then
                ' index if not already done
                tnStacked.StateImageIndex = If(tnStacked.Checked, 1, 0)
            End If
            ' and push each child to stack
            For i As Integer = 0 To tnStacked.Nodes.Count - 1
                ' too until there are no
                stNodes.Push(tnStacked.Nodes(i))
                ' nodes left on stack.
            Next
        End While
    End Sub

    Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
        MyBase.OnLayout(levent)

        Refresh()
    End Sub

    Protected Overrides Sub OnAfterExpand(e As TreeViewEventArgs)
        MyBase.OnAfterExpand(e)

        For Each tnCurrent As TreeNode In e.Node.Nodes
            ' set tree state image
            If tnCurrent.StateImageIndex = -1 Then
                ' to each child node...
                tnCurrent.StateImageIndex = If(tnCurrent.Checked, 1, 0)
            End If
        Next
    End Sub

    Protected Overrides Sub OnAfterCheck(e As TreeViewEventArgs)
        MyBase.OnAfterCheck(e)

        If _preventCheckEvent Then
            Return
        End If

        OnNodeMouseClick(New TreeNodeMouseClickEventArgs(e.Node, MouseButtons.None, 0, 0, 0))
    End Sub

    Protected Overrides Sub OnNodeMouseClick(e As TreeNodeMouseClickEventArgs)
        MyBase.OnNodeMouseClick(e)

        Try
            _preventCheckEvent = True

            If Not e.Node.Checked AndAlso SiblingLimitSelection Then
                ' not checked show before clicking mode and is not current state
                If e.Node.GetNodeCount(False) > 0 Then
                    ' is nested node ?
                    e.Node.Checked = False
                    SetError(e.Node, ParentNodeSelectError)
                    Return
                End If

                Dim sibling As TreeNode
                If (InlineAssignHelper(sibling, e.Node.GetFirstCheckedSiblingNode())) IsNot Nothing Then
                    ' check sibling selections
                    e.Node.Checked = False
                    SetError(e.Node, SiblingNodeSelectError, sibling.Text)
                    Return
                End If

                If CheckNodeValidation IsNot Nothing Then
                    Dim errorMsg As String = CheckNodeValidation(e.Node)
                    If errorMsg IsNot Nothing Then
                        e.Node.Checked = False
                        SetError(e.Node, errorMsg)
                        Return
                    End If
                End If
            End If

            Dim iSpacing As Integer = If(ImageList Is Nothing, 0, 18)
            ' *not* used by the state
            ' image we can leave here.
            If (e.X > e.Node.Bounds.Left - iSpacing OrElse e.X < e.Node.Bounds.Left - (iSpacing + 16)) AndAlso e.Button <> MouseButtons.None Then
                Return
            End If

            Dim tnBuffer = e.Node
            If e.Button = MouseButtons.Left Then
                ' flip its check state.
                tnBuffer.Checked = Not tnBuffer.Checked
            End If

            ' set state image index
            tnBuffer.StateImageIndex = If(tnBuffer.Checked, 1, tnBuffer.StateImageIndex)
            ' correctly.
            OnAfterCheck(New TreeViewEventArgs(tnBuffer, TreeViewAction.ByMouse))

            Dim stNodes = New Stack(Of TreeNode)(tnBuffer.Nodes.Count)
            stNodes.Push(tnBuffer)
            ' push buffered node first.
            Do
                ' let's pop node from stack,
                tnBuffer = stNodes.Pop()
                ' inherit buffered node's
                tnBuffer.Checked = e.Node.Checked
                ' check state and push
                tnBuffer.StateImageIndex = If(e.Node.Checked, 1, 0)
                OnCheckedChanged(New TreeViewEventArgs(tnBuffer))

                For i As Integer = 0 To tnBuffer.Nodes.Count - 1
                    ' each child on the stack
                    stNodes.Push(tnBuffer.Nodes(i))
                    ' until there is no node
                Next
            Loop While stNodes.Count > 0
            ' left.
            Dim bMixedState = False
            tnBuffer = e.Node
            ' re-buffer clicked node.
            While tnBuffer.Parent IsNot Nothing
                ' while we get a parent we
                For Each tnChild As TreeNode In tnBuffer.Parent.Nodes
                    ' determine mixed check states
                    ' and convert current check
                    bMixedState = bMixedState Or (tnChild.Checked <> tnBuffer.Checked Or tnChild.StateImageIndex = 2)
                Next
                ' state to state image index.
                Dim iIndex = CInt(Convert.ToUInt32(tnBuffer.Checked))
                tnBuffer.Parent.Checked = bMixedState OrElse (iIndex > 0)
                ' state image in dependency
                If bMixedState Then
                    ' of mixed state.
                    tnBuffer.Parent.StateImageIndex = If(CheckBoxesThreeState, 2, 1)
                Else
                    tnBuffer.Parent.StateImageIndex = iIndex
                End If
                tnBuffer = tnBuffer.Parent
                ' finally buffer parent and
                OnCheckedChanged(New TreeViewEventArgs(tnBuffer))
            End While
            ' loop here.
            ' set this node StateImageIndex to 0 if not checked
            If Not e.Node.Checked Then
                e.Node.StateImageIndex = 0
            End If
            ' raise checked changed event
            OnCheckedChanged(New TreeViewEventArgs(e.Node))
        Finally
            _preventCheckEvent = False
        End Try
    End Sub

    Protected Async Sub SetError(node As TreeNode, errorText As String, ParamArray errorParams As Object())
        SyncLock node
            If _errorNodes.Contains(node.GetUniqueValue()) Then
                Return
            End If
            _errorNodes.Add(node.GetUniqueValue())
        End SyncLock

        Try
            Dim tBuffer = node.Text
            Dim cBuffer = node.ForeColor

            node.ForeColor = ErrorForeColor
            node.Text += String.Format(" ({0})", String.Format(errorText, errorParams))

            Await Task.Delay(NodeErrorDuration)

            If Not Me.IsHandleCreated Then
                Return
            End If

            node.ForeColor = cBuffer
            node.Text = tBuffer
        Finally
            _errorNodes.Remove(node.GetUniqueValue())
        End Try
    End Sub

    Public Function Add(node As TreeNode) As TreeNode
        Me.Nodes.Add(node)
        OnNodeAdded(New TreeViewEventArgs(node))
        Return node
    End Function

    Public Sub AddRange(nodeArray As TreeNode())
        For Each node In nodeArray
            Me.Nodes.Add(node)
            OnNodeAdded(New TreeViewEventArgs(node))
        Next
    End Sub
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

#End Region

End Class


Public Module AdvTreeViewExtensions

    <System.Runtime.CompilerServices.Extension> _
    Public Function CheckState(node As TreeNode) As CheckBoxState
        Select Case node.StateImageIndex
            Case 0
                Return CheckBoxState.UncheckedNormal
            Case 1
                Return CheckBoxState.CheckedNormal
            Case 2
                Return CheckBoxState.MixedNormal
            Case Else
                Return CheckBoxState.UncheckedNormal
        End Select
    End Function

    <System.Runtime.CompilerServices.Extension> _
    Public Function GetFirstCheckedSiblingNode(node As TreeNode) As TreeNode
        While node.Parent IsNot Nothing AndAlso node.Parent.GetNodeCount(False) > 1
            ' have sibling node except self?
            For Each sibling As TreeNode In node.Parent.Nodes
                If sibling.Index <> node.Index AndAlso sibling.CheckState() <> CheckBoxState.UncheckedNormal Then
                    ' is sibling node not me and checked or mixed?
                    Return sibling
                End If
            Next

            ' check next time, this node parent sibling nodes
            node = node.Parent
        End While

        Return Nothing
    End Function

    <System.Runtime.CompilerServices.Extension> _
    Public Function GetCheckedSiblingsNode(node As TreeNode) As List(Of TreeNode)
        Dim siblings = New List(Of TreeNode)()

        While node.Parent IsNot Nothing AndAlso node.Parent.GetNodeCount(False) > 1
            ' have sibling node except self?
            For Each sibling As TreeNode In node.Parent.Nodes
                If sibling.Index <> node.Index AndAlso sibling.CheckState() <> CheckBoxState.UncheckedNormal Then
                    ' is sibling node not me and checked or mixed?
                    siblings.Add(sibling)
                End If
            Next

            ' check next time, this node parent sibling nodes
            node = node.Parent
        End While

        Return siblings
    End Function

    <System.Runtime.CompilerServices.Extension> _
    Friend Function GetUniqueValue(node As TreeNode) As String
        Dim key As String = ""

        While node IsNot Nothing
            key += String.Format("\{0}", node.Index)
            node = node.Parent
        End While

        Return key
    End Function

    <System.Runtime.CompilerServices.Extension> _
    Public Function AddNode(node As TreeNode, newNode As TreeNode) As TreeNode
        Dim tree = DirectCast(node.TreeView, AdvTreeView)
        node.Nodes.Add(newNode)
        If (tree IsNot Nothing) Then tree.PerformNodeAdded(newNode)
        Return newNode
    End Function

    <System.Runtime.CompilerServices.Extension> _
    Public Sub AddRangeNodes(node As TreeNode, newNodes As TreeNode())
        Dim tree = DirectCast(node.TreeView, AdvTreeView)

        For Each newNode In newNodes
            node.Nodes.Add(newNode)
            If (tree IsNot Nothing) Then tree.PerformNodeAdded(newNode)
        Next
    End Sub

End Module
