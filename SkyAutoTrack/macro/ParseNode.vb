Public Class ParseNode
    Dim children As LinkedList(Of ParseNode)

    Public Sub New()
        Me.children = New LinkedList(Of ParseNode)
    End Sub

    Public Sub AddChild(child As ParseNode)
        children.AddLast(child)
    End Sub

    Public Function GetChildren() As LinkedList(Of ParseNode)
        Return children
    End Function
End Class
