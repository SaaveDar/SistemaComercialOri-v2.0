Imports Newtonsoft.Json

Public Class ListaTipoDocPersona

    Public Class Data
        <JsonProperty("id_tipodoc")>
        Public Property id As String

        <JsonProperty("descripcion")>
        Public Property descripcion As String

        <JsonProperty("digitos")>
        Public Property digitos As String

        <JsonProperty("estado")>
        Public Property estado As String


    End Class
    Public Class JsonListaTipoDocPersona

        <JsonProperty("estado")>
        Public Property estado As String

        <JsonProperty("code")>
        Public Property code As String

        <JsonProperty("message")>
        Public Property message As String

        <JsonProperty("data")>
        Public Property data As Data()

    End Class

End Class
Public Class ListaUbigeoN1

    Public Class Data
        <JsonProperty("id_pais")>
        Public Property id_pais As String

        <JsonProperty("id_ubigeo_n1")>
        Public Property id_ubigeo_n1 As String

        <JsonProperty("descripcion")>
        Public Property descripcion As String

        <JsonProperty("estado")>
        Public Property estado As String


    End Class
    Public Class JsonListaUbigeoN1

        <JsonProperty("estado")>
        Public Property estado As String

        <JsonProperty("code")>
        Public Property code As String

        <JsonProperty("message")>
        Public Property message As String

        <JsonProperty("data")>
        Public Property data As Data()

    End Class
End Class


Public Class ListaUbigeoN2

    Public Class Data
        <JsonProperty("id_pais")>
        Public Property id_pais As String

        <JsonProperty("id_ubigeo_n2")>
        Public Property id_ubigeo_n2 As String

        <JsonProperty("descripcion")>
        Public Property descripcion As String

        <JsonProperty("id_ubigeo_n1")>
        Public Property id_ubigeo_n1 As String

        <JsonProperty("estado")>
        Public Property estado As String


    End Class
    Public Class JsonListaUbigeoN2

        <JsonProperty("estado")>
        Public Property estado As String

        <JsonProperty("code")>
        Public Property code As String

        <JsonProperty("message")>
        Public Property message As String

        <JsonProperty("data")>
        Public Property data As Data()

    End Class
End Class
Public Class ListaUbigeoN3

    Public Class Data
        <JsonProperty("id_pais")>
        Public Property id_pais As String

        <JsonProperty("id_ubigeo_n3")>
        Public Property id_ubigeo_n3 As String

        <JsonProperty("descripcion")>
        Public Property descripcion As String

        <JsonProperty("id_ubigeo_n2")>
        Public Property id_ubigeo_n2 As String

        <JsonProperty("estado")>
        Public Property estado As String


    End Class
    Public Class JsonListaUbigeoN3

        <JsonProperty("estado")>
        Public Property estado As String

        <JsonProperty("code")>
        Public Property code As String

        <JsonProperty("message")>
        Public Property message As String

        <JsonProperty("data")>
        Public Property data As Data()

    End Class
End Class
Public Class ModificaDatos

    Public Class JsonModificaDatos

        <JsonProperty("estado")>
        Public Property estado As String

        <JsonProperty("code")>
        Public Property code As String

        <JsonProperty("message")>
        Public Property message As String


    End Class
End Class
Public Class ListaTablas

    Public Class Data
        <JsonProperty("id_tb")>
        Public Property id_tb As String

        <JsonProperty("id_tipotabla")>
        Public Property id_tipotabla As String

        <JsonProperty("descripcion")>
        Public Property descripcion As String

        <JsonProperty("abreviado")>
        Public Property abreviado As String

        <JsonProperty("estado")>
        Public Property estado As String


    End Class
    Public Class JsonListaTablas

        <JsonProperty("estado")>
        Public Property estado As String

        <JsonProperty("code")>
        Public Property code As String

        <JsonProperty("message")>
        Public Property message As String

        <JsonProperty("data")>
        Public Property data As Data()

    End Class
End Class
