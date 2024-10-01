Imports Newtonsoft.Json
Public Class Locales
    Public Class ListaLocales
        Public Class JsonListaLocales

            <JsonProperty("estado")>
            Public Property estado As String

            <JsonProperty("code")>
            Public Property code As String

            <JsonProperty("message")>
            Public Property message As String

            <JsonProperty("data")>
            Public Property data As Data()

        End Class

        Public Class Data
            <JsonProperty("id_negocio")>
            Public Property id_negocio As String

            <JsonProperty("id_tb_tipolocal")>
            Public Property id_tb_tipolocal As String

            <JsonProperty("id_tb_propiedad")>
            Public Property id_tb_propiedad As String

            <JsonProperty("codigo")>
            Public Property codigo As String

            <JsonProperty("nombre")>
            Public Property nombre As String

            <JsonProperty("nombreabreviado")>
            Public Property nombreabreviado As String

            <JsonProperty("direccion")>
            Public Property direccion As String

            <JsonProperty("referencia")>
            Public Property referencia As String

            <JsonProperty("id_ubigeo_n1")>
            Public Property id_ubigeo_n1 As String

            <JsonProperty("id_ubigeo_n2")>
            Public Property id_ubigeo_n2 As String

            <JsonProperty("id_ubigeo_n3")>
            Public Property id_ubigeo_n3 As String

            <JsonProperty("fotolocal")>
            Public Property fotolocal As String

            <JsonProperty("lat")>
            Public Property lat As String

            <JsonProperty("lon")>
            Public Property lon As String

            <JsonProperty("fec_registro")>
            Public Property fec_registro As String

            <JsonProperty("id_suscripcion")>
            Public Property id_suscripcion As String

            <JsonProperty("fec_iniciosuscripcion")>
            Public Property fec_iniciosuscripcion As String

            <JsonProperty("dias")>
            Public Property dias As String

            <JsonProperty("estado")>
            Public Property estado As String

            <JsonProperty("id_local")>
            Public Property id_local As String

            <JsonProperty("fotolocal_local")>
            Public Property fotolocal_local As String

            <JsonProperty("fotolocal_local_Defecto")>
            Public Property fotolocal_local_Defecto As Bitmap

        End Class




    End Class
End Class
