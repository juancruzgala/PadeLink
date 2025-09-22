Public Module ShellHost
    Public Current As FrmShell

    Public Sub ShowInShell(f As Form)
        If Current Is Nothing OrElse Current.IsDisposed Then
            Current = New FrmShell()
            Current.Show()              ' se muestra una sola vez
        End If
        Current.ShowForm(f)             ' cambia la vista
    End Sub
End Module
