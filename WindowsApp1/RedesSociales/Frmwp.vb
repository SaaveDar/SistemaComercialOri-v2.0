Imports System.Diagnostics
Imports System.Net.Http
Public Class Frmwp
    Private Async Sub btnEnviarMensaje_Click(sender As Object, e As EventArgs) Handles btnEnviarMensaje.Click
        Dim numeroTelefono As String = "51948100300"
        Dim mensaje As String = "Hola, este es un mensaje desde mi programa VB.NET."

        Dim url As String = String.Format("https://api.whatsapp.com/send?phone={0}&text={1}", numeroTelefono, Uri.EscapeDataString(mensaje))

        Using client As New HttpClient()
            Await client.GetAsync(url)
        End Using
    End Sub



    'Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1_Click.Click
    '    Dim numeroTelefono As String = "51948100300"
    '    Dim mensaje As String = "Hola, este es un mensaje desde mi programa VB.NET."

    '    Dim url As String = String.Format("https://api.whatsapp.com/send?phone={0}&text={1}", numeroTelefono, Uri.EscapeDataString(mensaje))

    '    Using client As New HttpClient()
    '        Await client.GetAsync(url)
    '    End Using
    'End Sub


    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click




    '    'Dim numeroTelefono As String = "51948100300"
    '    'Dim mensaje As String = "Hola, este es un mensaje desde mi programa VB.NET."

    '    'Dim url As String = String.Format("https://api.whatsapp.com/send?phone={0}&text={1}", numeroTelefono, Uri.EscapeDataString(mensaje))

    '    'Process.Start(url)
    'End Sub
End Class