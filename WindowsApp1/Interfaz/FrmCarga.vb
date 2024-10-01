Public Class FrmCarga
    Dim FONDO As New FrmFondo
    Private Sub FrmCarga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Location = New Point(FrmCarga.Location.X + 8, FrmCarga.Location.Y + 30)

        Me.TransparencyKey = Me.BackColor
        Me.MaximizeBox = False
        FONDO.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        If Val(LogoSolicdo.Tag) <> 0 Then
            FONDO.Opacity = Val(LogoSolicdo.Tag)
        Else
            FONDO.Opacity = 0
        End If

        FONDO.Width = Me.Width - 16
        FONDO.Height = Me.Height - 30
        FONDO.Location = New Point(Me.Location.X + 8, Me.Location.Y + 30)
        FONDO.Show()
        Application.DoEvents()

        'Gifcarga.SizeMode = PictureBoxSizeMode.CenterImage
        'Gifcarga.Image = Image.FromFile("ruta/a/tu/imagen.gif")
        ' Gifcarga.Visible = True

        ' Ejecuta el proceso en segundo plano





    End Sub

    Private Sub FrmCarga_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        FONDO.Location = New Point(Me.Location.X + 8, Me.Location.Y + 30)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles LogoMuestra.Click

    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Gifcarga_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FrmCarga_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FONDO.Close()
    End Sub

End Class