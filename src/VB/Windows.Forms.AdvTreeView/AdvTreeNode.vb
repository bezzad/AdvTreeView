Imports System.ComponentModel
Imports System.Windows.Forms

Namespace Windows.Forms
    Public Class AdvTreeNode
        Inherits TreeNode
#Region "Properties"

        ''' <summary>
        ''' Gets or sets three state checkbox tree node value.
        ''' </summary>
        <Category("Appearance"), Description("Sets tree view node three state checkboxes checked value."), DefaultValue(CheckedState.UnChecked)> _
        Public Shadows Property Checked() As CheckedState
            Get
                Return DirectCast(StateImageIndex, CheckedState)
            End Get
            Set(value As CheckedState)
                StateImageIndex = CInt(value)
            End Set
        End Property

#End Region

#Region "Constructors"

        ''' <devdoc> 
        '''     Creates a TreeNode object. 
        ''' </devdoc>
        Public Sub New()
        End Sub

        ''' <devdoc> 
        '''     Creates a TreeNode object. 
        ''' </devdoc>
        Public Sub New(text As String)
            MyBase.New(text)
        End Sub

        ''' <devdoc>
        '''     Creates a TreeNode object. 
        ''' </devdoc>
        Public Sub New(text As String, children As AdvTreeNode())
            MyBase.New(text, children)
        End Sub

        ''' <devdoc>
        '''     Creates a TreeNode object. 
        ''' </devdoc>
        Public Sub New(text As String, imageIndex As Integer, selectedImageIndex As Integer)
            MyBase.New(text, imageIndex, selectedImageIndex)
        End Sub

        ''' <devdoc> 
        '''     Creates a TreeNode object.
        ''' </devdoc>
        Public Sub New(text As String, imageIndex As Integer, selectedImageIndex As Integer, children As AdvTreeNode())
            MyBase.New(text, imageIndex, selectedImageIndex, children)
        End Sub

#End Region
    End Class

End Namespace