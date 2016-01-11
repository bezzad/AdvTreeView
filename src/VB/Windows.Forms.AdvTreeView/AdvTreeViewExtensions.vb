Imports System.Windows.Forms

Namespace Windows.Forms
    Module AdvTreeViewExtensions
        ''' <devdoc>
        '''     Adds a new child node to this node.  Child node is positioned after siblings.
        ''' </devdoc>
        <System.Runtime.CompilerServices.Extension> _
        Public Function Add(nodeCollection As TreeNodeCollection, node As AdvTreeNode) As AdvTreeNode
            nodeCollection.Add(node)
            Return node
        End Function

        ''' <devdoc>
        '''     Inserts a new child node on this node.  Child node is positioned as specified by index.
        ''' </devdoc>
        <System.Runtime.CompilerServices.Extension> _
        Public Function Insert(nodeCollection As TreeNodeCollection, index As Integer, node As AdvTreeNode) As AdvTreeNode
            nodeCollection.Insert(index, node)
            Return node
        End Function

        ''' <devdoc>
        '''    <para>[To be supplied.]</para>
        ''' </devdoc>
        <System.Runtime.CompilerServices.Extension> _
        Public Sub AddRange(nodeCollection As TreeNodeCollection, nodes As AdvTreeNode())
            nodeCollection.AddRange(nodes)
        End Sub
    End Module
End Namespace