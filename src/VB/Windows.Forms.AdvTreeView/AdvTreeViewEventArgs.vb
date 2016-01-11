Namespace Windows.Forms
    ''' <devdoc>
    '''    <para>
    '''       Provides data for the <see cref='Windows.Forms.AdvTreeView.OnCheckedChanged'/> event. 
    '''    </para>
    ''' </devdoc> 
    Public Class AdvTreeViewEventArgs
        Inherits EventArgs
        Private m_node As AdvTreeNode

        ''' <devdoc>
        '''    <para>[To be supplied.]</para> 
        ''' </devdoc>
        Public Sub New(node As AdvTreeNode)
            Me.m_node = node
        End Sub

        ''' <devdoc>
        '''    <para>[To be supplied.]</para>
        ''' </devdoc> 
        Public ReadOnly Property Node() As AdvTreeNode
            Get
                Return m_node
            End Get
        End Property
    End Class
End Namespace