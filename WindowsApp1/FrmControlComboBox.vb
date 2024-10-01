Public Class FrmControlComboBox
    Private Sub DGTabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTabla.CellContentClick

    End Sub

    Private Sub FrmControlComboBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelDetalle.Dock = System.Windows.Forms.DockStyle.Fill

        For J = 1 To 28
            DGTabla.Rows.Add()
            DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = J
            DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "ACEITE LA BOTIJA EXTRA VIRGEN LTA X 150ML  " & J & "CODI"

        Next J
    End Sub

    Private Sub DGTabla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTabla.CellDoubleClick
        MsgBox("OK")
        Me.Close()
    End Sub
End Class