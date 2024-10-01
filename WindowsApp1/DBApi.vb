Imports System.Net
Imports RestSharp
Imports Newtonsoft.Json
Public Class DBApi
    Public Function Post(url As String, headers As List(Of Parametro), parametros As List(Of Parametro), objeto As Object) As String
        'Por siacaso este codigo, sirve cuando la api tiene problemas con su certificado
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12


        lk_client.BaseUrl = New Uri(url)

        Dim request = New RestRequest()
        request.Method = Method.POST

        For Each item As Parametro In headers
            request.AddHeader(item.Clave, item.Valor)
        Next

        For Each parametro As Parametro In parametros
            request.AddParameter(parametro.Clave, parametro.Valor)
        Next


        If (parametros.Count = 0) Then
            request.AddJsonBody(objeto)
        End If

        Dim response = lk_client.Execute(request).Content.ToString()

        Return response
    End Function


End Class
Public Class clsJson
    Public Class DataOP
        <JsonProperty("dni")>
        Public Property dni As String

        <JsonProperty("nombre")>
        Public Property nombre As String

        <JsonProperty("apellido")>
        Public Property apellido As String
    End Class
    Public Class JsonRespuestaOP

        <JsonProperty("estado")>
        Public Property estado As String

        <JsonProperty("code")>
        Public Property code As String

        <JsonProperty("message")>
        Public Property message As String

        <JsonProperty("data")>
        Public Property data As DataOP()

    End Class
End Class
Public Class Usuarios

    Public Class Data2
        <JsonProperty("dni")>
        Public Property dni2 As String

        <JsonProperty("nombre")>
        Public Property nombre2 As String

        <JsonProperty("apellido")>
        Public Property apellido2 As String
    End Class
    Public Class JsonRespuesta2

        <JsonProperty("estado")>
        Public Property estado2 As String

        <JsonProperty("code")>
        Public Property code2 As String

        <JsonProperty("message")>
        Public Property message2 As String

        <JsonProperty("data")>
        Public Property data2 As Data2()

    End Class
End Class