Public Class FrmEsperar
    Private Sub FrmEsperar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = 1





    End Sub

    Private Sub cargagif_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles cargagif.DoWork
        ' MuestraGif.Visible = True
        '  MuestraGif.Refresh()

    End Sub

    Private Sub FrmEsperar_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'If cargagif.IsBusy = False Then
        cargagif.RunWorkerAsync()
        ' End If
    End Sub
End Class