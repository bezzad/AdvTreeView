Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

''' <summary>
''' Provides a tree view control supporting three state checkboxes.
''' </summary>
Public Class AdvTreeView
    Inherits TreeView

#Region "Events"

    Public Delegate Sub CheckedChangedHandler(e As TreeViewEventArgs)
    Public Event CheckedChanged As CheckedChangedHandler
    Protected Overridable Sub OnCheckedChanged(e As TreeViewEventArgs)
        RaiseEvent CheckedChanged(e)
    End Sub

#End Region

#Region "Fields"

    ReadOnly _ilStateImages As ImageList
    Private _checkBoxesVisible As Boolean
    Private _preventCheckEvent As Boolean

#End Region

#Region "Constructors"

    ''' <summary>
    ''' Creates a new instance
    ''' of this control.
    ''' </summary>
    Public Sub New()
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
        Get
            Return MyBase.StateImageList
        End Get
        Set(value As ImageList)
            MyBase.StateImageList = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets to support three state in the checkboxes or not.
    ''' </summary>
    <Category("Appearance"), Description("Sets tree view to use three state checkboxes or not."), DefaultValue(True)> _
    Public Property CheckBoxesThreeState() As Boolean
        Get
            Return m_CheckBoxesThreeState
        End Get
        Set(value As Boolean)
            m_CheckBoxesThreeState = value
        End Set
    End Property
    Private m_CheckBoxesThreeState As Boolean

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

        _preventCheckEvent = True

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
            OnCheckedChanged(New TreeViewEventArgs(DirectCast(tnBuffer, TreeNode)))

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
            OnCheckedChanged(New TreeViewEventArgs(DirectCast(tnBuffer, TreeNode)))
        End While
        ' loop here.
        _preventCheckEvent = False

        ' set this node StateImageIndex to 0 if not checked
        If Not e.Node.Checked Then
            e.Node.StateImageIndex = 0
        End If
        ' raise checked changed event
        OnCheckedChanged(New TreeViewEventArgs(DirectCast(e.Node, TreeNode)))
    End Sub

#End Region

End Class