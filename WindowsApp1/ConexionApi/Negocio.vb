Imports Newtonsoft.Json

Public Class Negocio


    Public Class ListaAccesoNegocios
        Public Class JsonAccesoNegocios

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

            <JsonProperty("nombre")>
            Public Property nombre As String


        End Class

    End Class
    Public Class ListaNegocioAcceso
        Public Class JsonListaNegocioAcceso

            <JsonProperty("estado")>
            Public Property estado As String

            <JsonProperty("code")>
            Public Property code As String

            <JsonProperty("message")>
            Public Property message As String

            <JsonProperty("data")>
            Public Property data As Data()

        End Class
        '[{"id_negocio":"24","nombre":"CIENPHARMA S.A.","nombrecomercial":"CIENPHARMA","direccion":"VICTORLARCO","descripcion":"RUC","numeroreg":"20548754101","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotonegocio":"-","estado_acceso":"1"},

        Public Class Data
            <JsonProperty("id_negocio")>
            Public Property id_negocio As String

            <JsonProperty("nombre")>
            Public Property nombre As String

            <JsonProperty("nombrecomercial")>
            Public Property nombrecomercial As String

            <JsonProperty("direccion")>
            Public Property direccion As String


            <JsonProperty("descripcion")>
            Public Property descripcion As String

            <JsonProperty("numeroreg")>
            Public Property numeroreg As String

            <JsonProperty("des_n1")>
            Public Property des_n1 As String

            <JsonProperty("des_n2")>
            Public Property des_n2 As String

            <JsonProperty("des_n3")>
            Public Property des_n3 As String

            <JsonProperty("fotonegocio")>
            Public Property fotonegocio As String

            <JsonProperty("estado_acceso")>
            Public Property estado_acceso As String

            <JsonProperty("fotonegociolocal")>
            Public Property fotonegociolocal As String



        End Class

    End Class

    Public Class ListaHorarioLocal
        Public Class JsonListaHorarioLocal

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
            <JsonProperty("id_horario")>
            Public Property id_horario As String

            <JsonProperty("id_acceso_loc")>
            Public Property id_acceso_loc As String

            <JsonProperty("diasemana")>
            Public Property diasemana As String

            <JsonProperty("tipo_acceso")>
            Public Property tipo_acceso As String

            <JsonProperty("hora_de")>
            Public Property hora_de As String

            <JsonProperty("hora_hasta")>
            Public Property hora_hasta As String


        End Class

    End Class
    Public Class ListaAlmacenAcceso
        Public Class JsonListaAlmacenAcceso

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

            <JsonProperty("estado")>
            Public Property estado As String
        End Class

    End Class
    Public Class ListaLocalAcceso
        Public Class JsonListaLocalAcceso

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
            <JsonProperty("id_local")>
            Public Property id_local As String

            <JsonProperty("nombre")>
            Public Property nombre As String

            <JsonProperty("id_tipo_acc_loc")>
            Public Property id_tipo_acc_loc As String

            <JsonProperty("id_acceso_loc")>
            Public Property id_acceso_loc As String


            <JsonProperty("estado")>
            Public Property estado As String

        End Class

    End Class


    Public Class AgregaLocal

        Public Class JsonAgregarLocal

            <JsonProperty("estado")>
            Public Property estado As String

            <JsonProperty("code")>
            Public Property code As String

            <JsonProperty("message")>
            Public Property message As String


        End Class
    End Class
    Public Class AgregaNegocio

        Public Class JsonAgregaNegocio

            <JsonProperty("estado")>
            Public Property estado As String

            <JsonProperty("code")>
            Public Property code As String

            <JsonProperty("message")>
            Public Property message As String
            <JsonProperty("data")>
            Public Property data As Data


        End Class
        Public Class Data
            <JsonProperty("id_cuenta_user")>
            Public Property id_cuenta_user As String


        End Class


    End Class
    Public Class ListaNegocio
        Public Class JsonListaNegocios

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
            <JsonProperty("id_negousaurio")>
            Public Property id_negousaurio As String

            <JsonProperty("id_usuario")>
            Public Property id_usuario As String

            <JsonProperty("id_negocio")>
            Public Property id_negocio As String

            <JsonProperty("fec_registro")>
            Public Property fec_registro As String

            <JsonProperty("estado")>
            Public Property estado As String

            <JsonProperty("id_tipdoc")>
            Public Property id_tipdoc As String

            <JsonProperty("numeroreg")>
            Public Property numeroreg As String

            <JsonProperty("nombre")>
            Public Property nombre As String

            <JsonProperty("nombrecomercial")>
            Public Property nombrecomercial As String

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

            <JsonProperty("fotonegocio")>
            Public Property fotonegocio As String

            <JsonProperty("fotonegociolocal")>
            Public Property fotonegociolocal As String
        End Class




    End Class
    Public Class NegocioActivo

        Public Class TempNegocioActivo

            Public Property estado As String = ""


            Public Property id_Negocio As String


            Public Property nombre As String

            Public Property id_pais As String


            Public Property nombrecomercial As String


            Public Property direccion As String


            Public Property fotonegocio As String


            Public Property tipodoc As String


            Public Property numdoc As String


        End Class
        Public Class TempLocalActivo

            Public Property id_local As String
            Public Property codigo As String
            Public Property estado As String

            Public Property id_Negocio As String

            Public Property nombre As String

            Public Property abreviado As String

            Public Property direccion As String

            Public Property fotolocal As String

        End Class
        Public Class TempAlmacenActivo

            Public Property id_almacen As String

            Public Property id_local As String
            Public Property estado As String


            Public Property id_Negocio As String


            Public Property nombre As String

            Public Property abreviado As String

            Public Property codigo As String

            Public Property mombrecomercial As String


            Public Property direccion As String


            Public Property fotoalmacen As String


        End Class
    End Class


    Public Class AgregarAlmacen

        Public Class JsonAgregarAlmacen

            <JsonProperty("estado")>
            Public Property estado As String

            <JsonProperty("code")>
            Public Property code As String

            <JsonProperty("message")>
            Public Property message As String


        End Class
    End Class
    Public Class TempFormato


        Public Property id_negocio As Integer = 0


        Public Property id_tb_oper As Integer = 0


        Public Property id_usuario As Integer = 0

        Public Property equipo As String


        Public Property id_destino As Integer


        Public Property id_formato As Integer


        Public Property id_copias As Integer


        Public Property impresora1 As String

        Public Property impresora2 As String
        Public Property impresora3 As String


    End Class


End Class
