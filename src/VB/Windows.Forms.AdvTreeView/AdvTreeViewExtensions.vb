
Public Module AdvTreeViewExtensions

    <System.Runtime.CompilerServices.Extension> _
    Public Function CheckedState(ByRef node As System.Windows.Forms.TreeNode) As CheckedState
        Return DirectCast(node.StateImageIndex, CheckedState)
    End Function

End Module
