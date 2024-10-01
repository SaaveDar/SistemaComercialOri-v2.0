Imports Newtonsoft.Json

Public Class Almacenes
    Public Class ListaAlmacenes
        Public Class JsonListaAlmacenes

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
            <JsonProperty("id_almacen")>
            Public Property id_almacen As String

            <JsonProperty("id_local")>
            Public Property id_local As String

            <JsonProperty("id_tb_tipoalm")>
            Public Property id_tb_tipoalm As String

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

            <JsonProperty("fotoalmacen")>
            Public Property fotoalmacen As String

            <JsonProperty("fec_registro")>
            Public Property fec_registro As String

            <JsonProperty("estado")>
            Public Property estado As String

            <JsonProperty("fotoalmacen_local")>
            Public Property fotoalmacen_local As String

            <JsonProperty("fotoalmacen_local_Defecto")>
            Public Property fotoalmacen_local_Defecto As Bitmap

        End Class




    End Class
End Class
