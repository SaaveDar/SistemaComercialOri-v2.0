Public Class FrmFilaGrid
    Private Sub FrmFilaGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler ModeloBase3.NuevoMensaje, AddressOf ManejarNuevoMensaje
    End Sub
    Private Sub ManejarNuevoMensaje(sender As Object, e As MensajeEventArgs)
        ' Obtener los datos del mensaje
        Dim remitente As String = e.Remitente
        Dim destinatario As String = e.Destinatario
        Dim contenido As String = e.Contenido

        ' Mostrar la notificación emergente o actualizar la lista de mensajes no leídos
        ' Aquí puedes implementar la lógica específica para tu aplicación
        MessageBox.Show($"Has recibido un nuevo mensaje de {remitente}: {contenido}")
    End Sub
End Class