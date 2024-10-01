Imports Newtonsoft.Json

Public Class ValidaUsuarios

    Public Class Data
        <JsonProperty("id_usuario")>
        Public Property id_usuario As String

        <JsonProperty("usuario")>
        Public Property Usuario As String

        <JsonProperty("clave")>
        Public Property Clave As String

        <JsonProperty("id_tipodoc")>
        Public Property id_tipodoc As String

        <JsonProperty("FotoPerfil")>
        Public Property FotoPerfil As String

        <JsonProperty("numero_doc")>
        Public Property numero_doc As String

        <JsonProperty("nombres")>
        Public Property nombres As String

        <JsonProperty("apellidos")>
        Public Property apellidos As String

        <JsonProperty("id_pais")>
        Public Property id_pais As String

        <JsonProperty("celular")>
        Public Property celular As String

        <JsonProperty("email")>
        Public Property email As String

        <JsonProperty("id_ciudad")>
        Public Property id_ciudad As String

        <JsonProperty("fec_nac")>
        Public Property fec_nac As String

        <JsonProperty("genero")>
        Public Property genero As String

        <JsonProperty("estado")>
        Public Property estado As String

        <JsonProperty("fec_registro")>
        Public Property fec_registro As String

        <JsonProperty("fec_conexion")>
        Public Property fec_conexion As String

        <JsonProperty("id_cuenta_user")>
        Public Property id_cuenta_user As String



    End Class
    '  "AccessNegocio":[{"tipo":"externo","id_negocio":"1068","nombre":"GRUPO LIVES S.A.","nombrecomercial":"LIVES","direccion":"LIMA","descripcion":"RUC","numeroreg":"20559856521","des_n1":"AMAZONAS","des_n2":"BAGUA","des_n3":"BAGUA GRANDE","fotonegocio":"http:\/\/www.innovatechapp.com\/perfilesinnova\/neg10060353221006.png","estado_acceso":"1"},{"tipo":"propio","id_negocio":"22","nombre":"AHORRO FARMA DISTRIBUCIONES LIBERTAD SAC","nombrecomercial":"AHORRO FARMA","direccion":"DIRECION DEL NEGCOCIO","descripcion":"RUC","numeroreg":"20502154214","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotonegocio":"http:\/\/www.innovatechapp.com\/perfilesinnova\/loc103030522.jpg","estado_acceso":"1"},{"tipo":"propio","id_negocio":"23","nombre":"GRUPO LIVES S.A","nombrecomercial":"LIVES","direccion":"TRUJIILLOJOAQUINOLMERO","descripcion":"RUC","numeroreg":"20559713156","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotonegocio":"-","estado_acceso":"1"},{"tipo":"propio","id_negocio":"24","nombre":"CIENPHARMA S.A.","nombrecomercial":"CIENPHARMA","direccion":"VICTORLARCO","descripcion":"RUC","numeroreg":"20548754101","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotonegocio":"-","estado_acceso":"1"},{"tipo":"propio","id_negocio":"25","nombre":"BVC FARMA S.A.C","nombrecomercial":"BVC FARMA","direccion":"TRUJILLO","descripcion":"RUC","numeroreg":"20559743156","des_n1":"AMAZONAS","des_n2":"BAGUA","des_n3":"BAGUA GRANDE","fotonegocio":"http:\/\/www.innovatechapp.com\/perfilesinnova\/neg1103161.jpg","estado_acceso":"1"},{"tipo":"propio","id_negocio":"26","nombre":"GRUPO CCCCC","nombrecomercial":"ASDFASD","direccion":"ASDF","descripcion":"RUC","numeroreg":"50225478797","des_n1":"LA LIBERTAD","des_n2":"TRUJILLO","des_n3":"TRUJILLO","fotonegocio":"http:\/\/www.innovatechapp.com\/perfilesinnova\/neg1105451.jpg","estado_acceso":"1"},{"tipo":"propio","id_negocio":"27","nombre":"ASDJKL","nombrecomercial":"AS{KDJF A{SDJ","direccion":"ASJK","descripcion":"RUC","numeroreg":"20542154215","des_n1":"AMAZONAS","des_n2":"BAGUA","des_n3":"BAGUA","fotonegocio":"http:\/\/www.innovatechapp.com\/perfilesinnova\/neg1107211.jpg","estado_acceso":"1"},{"tipo":"propio","id_negocio":"28","nombre":"A\u00d1SDLJ","nombrecomercial":"\u00d1ASD","direccion":"\u00d1ASDLF","descripcion":"DNI","numeroreg":"18181818","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotonegocio":"http:\/\/www.innovatechapp.com\/perfilesinnova\/neg1109361.jpg","estado_acceso":"1"},{"tipo":"propio","id_negocio":"29","nombre":"GH SDFG SDFG SDFGSDFGSDF","nombrecomercial":"SDFGSDFGSDF","direccion":"GSDFGSDF","descripcion":"RUC","numeroreg":"20559713152","des_n1":"LA LIBERTAD","des_n2":"TRUJILLO","des_n3":"TRUJILLO","fotonegocio":"http:\/\/www.innovatechapp.com\/perfilesinnova\/neg1119391.jpg","estado_acceso":"1"},{"tipo":"propio","id_negocio":"34","nombre":"ASDAGASGASDFG","nombrecomercial":"ASDFASDFASDFA","direccion":"FASDFASDF","descripcion":"RUC","numeroreg":"20502065541","des_n1":"LA LIBERTAD","des_n2":"TRUJILLO","des_n3":"TRUJILLO","fotonegocio":"-","estado_acceso":"1"}],
    Public Class AccessNegocio
        <JsonProperty("tipo")>
        Public Property tipo As String

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

        <JsonProperty("fotonegociolocal")>
        Public Property fotonegociolocal As String

        <JsonProperty("estado_acceso")>
        Public Property estado_acceso As String





    End Class


    '  "AccessAlmacen":[{"tipo":"externo","id_almacen":"1005","nombre":"ALMCEN CENTRAL","codigo":"01","direccion":"LIMA","des_n1":"AMAZONAS"
    '  ,"des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotoalmacen":"-","id_local":"1019","estado_acceso":"1"},{"tipo":"propio","id_almacen":"4","nombre":"ALMCEN PRIMER PISO","codigo":"10","direccion":"AF ASDFASDFA SDF","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotoalmacen":"http:\/\/www.innovatechapp.com\/perfilesinnova\/alm10253394.jpg","id_local":"22","estado_acceso":"1"},{"tipo":"propio","id_almacen":"5","nombre":"ALMCEN SEGUNDO PISO","codigo":"11","direccion":"DIREC SEGUNDO PIESO","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotoalmacen":"http:\/\/www.innovatechapp.com\/perfilesinnova\/alm10300115.png","id_local":"22","estado_acceso":"1"},{"tipo":"propio","id_almacen":"6","nombre":"ASFGASDFASDFASDFASDF","codigo":"44","direccion":"SDFASDFASDFASDF","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotoalmacen":"-","id_local":"22","estado_acceso":"1"},{"tipo":"propio","id_almacen":"7","nombre":"ALMCEN PRIMER PISO","codigo":"12","direccion":"AF ASDFASDFA SDF","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotoalmacen":"-","id_local":"22","estado_acceso":"1"},{"tipo":"propio","id_almacen":"8","nombre":"ALM FARMA LIVES","codigo":"01","direccion":"MISMA TIENDA","des_n1":"LA LIBERTAD","des_n2":"TRUJILLO","des_n3":"TRUJILLO","fotoalmacen":"-","id_local":"23","estado_acceso":"1"},{"tipo":"propio","id_almacen":"9","nombre":"ALMCEN PRIMER PISO","codigo":"13","direccion":"AF ASDFASDFA SDF","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotoalmacen":"-","id_local":"22","estado_acceso":"1"},{"tipo":"propio","id_almacen":"10","nombre":"ALMCEN PRIMER PISO","codigo":"14","direccion":"AF ASDFASDFA SDF","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotoalmacen":"-","id_local":"22","estado_acceso":"1"},{"tipo":"propio","id_almacen":"12","nombre":"ALMC01","codigo":"10","direccion":"ASDFL\u00d1 AN\u00d1SDF","des_n1":"LA LIBERTAD","des_n2":"TRUJILLO","des_n3":"TRUJILLO","fotoalmacen":"-","id_local":"22","estado_acceso":"1"},{"tipo":"propio","id_almacen":"1006","nombre":"ALMCEN CIEN I","codigo":"50","direccion":"LIMA","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotoalmacen":"-","id_local":"24","estado_acceso":"1"}],


    Public Class AccessAlmacen

        <JsonProperty("tipo")>
        Public Property tipo As String

        <JsonProperty("id_almacen")>
        Public Property id_almacen As String

        <JsonProperty("nombre")>
        Public Property nombre As String

        <JsonProperty("codigo")>
        Public Property codigo As String

        <JsonProperty("direccion")>
        Public Property direccion As String

        <JsonProperty("des_n1")>
        Public Property des_n1 As String

        <JsonProperty("des_n2")>
        Public Property des_n2 As String

        <JsonProperty("des_n3")>
        Public Property des_n3 As String

        <JsonProperty("fotoalmacen")>
        Public Property fotoalmacen As String

        <JsonProperty("fotoalmacenlocal")>
        Public Property fotoalmacenlocal As String

        <JsonProperty("fotoalmacenlocal_Defecto")>
        Public Property fotoalmacenlocal_Defecto As Bitmap


        <JsonProperty("id_local")>
        Public Property id_local As String

        <JsonProperty("estado_acceso")>
        Public Property estado_acceso As String

    End Class




    '  "AccessLocal":[{"tipo":"externo","id_local":"1019","id_acceso_loc":"6","nombre":"SANTA CRUS","codigo":"001","direccion":"LIMA",
    '  "id_tb_tipolocal":"2","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotolocal":"-","id_negocio":"1068","estado_acceso":"1",
    '  "lat":"-7.88242666121779","lon":"-79.222412109375",

    Public Class AccessLocal
        <JsonProperty("tipo")>
        Public Property tipo As String

        <JsonProperty("id_local")>
        Public Property id_local As String

        <JsonProperty("id_acceso_loc")>
        Public Property id_acceso_loc As String

        <JsonProperty("nombre")>
        Public Property nombre As String

        <JsonProperty("codigo")>
        Public Property codigo As String

        <JsonProperty("direccion")>
        Public Property direccion As String

        <JsonProperty("id_tb_tipolocal")>
        Public Property id_tb_tipolocal As String

        <JsonProperty("des_n1")>
        Public Property des_n1 As String

        <JsonProperty("des_n2")>
        Public Property des_n2 As String

        <JsonProperty("des_n3")>
        Public Property des_n3 As String

        <JsonProperty("fotolocal")>
        Public Property fotolocal As String

        <JsonProperty("fotolocallocal")>
        Public Property fotolocallocal As String

        <JsonProperty("fotolocallocal_Defecto")>
        Public Property fotolocallocal_Defecto As Bitmap

        <JsonProperty("id_negocio")>
        Public Property id_negocio As String

        <JsonProperty("estado_acceso")>
        Public Property estado_acceso As String

        <JsonProperty("lat")>
        Public Property lat As String
        <JsonProperty("lon")>
        Public Property lon As String

        <JsonProperty("horario")>
        Public Property horario As horario()


    End Class
    '  "horario":[{"id_acceso_loc":"6","diasemana":"1","tipo_acceso":"1","hora_de":"00:00","hora_hasta":"00:00"},{"id_acceso_loc":"6","diasemana":"2","tipo_acceso":"1","hora_de":"00:00","hora_hasta":"00:00"},{"id_acceso_loc":"6","diasemana":"3","tipo_acceso":"1","hora_de":"00:00","hora_hasta":"00:00"},{"id_acceso_loc":"6","diasemana":"4","tipo_acceso":"1","hora_de":"00:00","hora_hasta":"00:00"},{"id_acceso_loc":"6","diasemana":"5","tipo_acceso":"1","hora_de":"00:00","hora_hasta":"00:00"},{"id_acceso_loc":"6","diasemana":"6","tipo_acceso":"1","hora_de":"00:00","hora_hasta":"00:00"},{"id_acceso_loc":"6","diasemana":"7","tipo_acceso":"1","hora_de":"00:00","hora_hasta":"00:00"}]},{"tipo":"propio","id_local":"3","id_acceso_loc":"1","nombre":"SAN MARTIN 1 - PRIMER PISO","codigo":"015","direccion":"DIRECCION LOCAL AV SAN AMRTIN 547","id_tb_tipolocal":"1","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotolocal":"-","id_negocio":"22","estado_acceso":"1","lat":"-8.11230013621251","lon":"-79.0317915002419"},{"tipo":"propio","id_local":"6","id_acceso_loc":"1","nombre":"SAN MARTIN 2","codigo":"009","direccion":"AV. SAN MARTIN PASAJER 15441","id_tb_tipolocal":"1","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotolocal":"http:\/\/www.innovatechapp.com\/perfilesinnova\/2548koala.jpg","id_negocio":"22","estado_acceso":"1","lat":"-8.11230013621251","lon":"-79.0317915002419"},{"tipo":"propio","id_local":"7","id_acceso_loc":"1","nombre":"CENTRO DE DELIVERY","codigo":"010","direccion":"AV. SAN MARTIN 547","id_tb_tipolocal":"3","des_n1":"LA LIBERTAD","des_n2":"TRUJILLO","des_n3":"TRUJILLO","fotolocal":"http:\/\/www.innovatechapp.com\/perfilesinnova\/2337klipartz.com (5).png","id_negocio":"22","estado_acceso":"1","lat":"-8.11230013621251","lon":"-79.0317915002419"},{"tipo":"propio","id_local":"8","id_acceso_loc":"1","nombre":"FARMA SOFT","codigo":"050","direccion":"ASDFAD FASD","id_tb_tipolocal":"2","des_n1":"LA LIBERTAD","des_n2":"TRUJILLO","des_n3":"TRUJILLO","fotolocal":"http:\/\/www.innovatechapp.com\/perfilesinnova\/loc11303922.jpg","id_negocio":"22","estado_acceso":"1","lat":"-8.11230013621251","lon":"-79.0317915002419"},{"tipo":"propio","id_local":"9","id_acceso_loc":"1","nombre":"FARMA LIVES","codigo":"001","direccion":"JR. OLMEDO 4514 - TRUJILLO","id_tb_tipolocal":"2","des_n1":"LA LIBERTAD","des_n2":"TRUJILLO","des_n3":"TRUJILLO","fotolocal":"http:\/\/www.innovatechapp.com\/perfilesinnova\/1349pos9.jpg","id_negocio":"23","estado_acceso":"1","lat":"-8.11230013621251","lon":"-79.0317915002419"},{"tipo":"propio","id_local":"10","id_acceso_loc":"1","nombre":"GJFHD","codigo":"444","direccion":"SGDFGSDFGSDF","id_tb_tipolocal":"2","des_n1":"LA LIBERTAD","des_n2":"TRUJILLO","des_n3":"TRUJILLO","fotolocal":"http:\/\/www.innovatechapp.com\/perfilesinnova\/loc11311122.jpg","id_negocio":"22","estado_acceso":"1","lat":"-8.11230013621251","lon":"-79.0317915002419"},{"tipo":"propio","id_local":"11","id_acceso_loc":"1","nombre":"FARMA JUAN III","codigo":"121","direccion":"AF ASDF ASDF","id_tb_tipolocal":"1","des_n1":"AMAZONAS","des_n2":"CHACHAPOYAS","des_n3":"CHCHAP-N3","fotolocal":"-","id_negocio":"24","estado_acceso":"1","lat":"-8.09594061366425","lon":"-79.0589904785156"}]}
    Public Class horario
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
    Public Class JsonValidaUsaurio

        <JsonProperty("estado")>
        Public Property estado As String

        <JsonProperty("code")>
        Public Property code As String

        <JsonProperty("message")>
        Public Property message As String

        <JsonProperty("data")>
        Public Property data As Data()

        <JsonProperty("AccessNegocio")>
        Public Property AccessNegocio As AccessNegocio()

        <JsonProperty("AccessAlmacen")>
        Public Property AccessAlmacen As AccessAlmacen()

        <JsonProperty("AccessLocal")>
        Public Property AccessLocal As AccessLocal()
    End Class

End Class
Public Class RepiteUsuario

    Public Class JsonRepiteUsuario

        <JsonProperty("estado")>
        Public Property estado As String

        <JsonProperty("code")>
        Public Property code As String

        <JsonProperty("message")>
        Public Property message As String


    End Class
End Class
Public Class EnviaSMS
    Public Class JsonEnvioSMS

        <JsonProperty("estado")>
        Public Property estado As String

        <JsonProperty("code")>
        Public Property code As String

        <JsonProperty("message")>
        Public Property message As String

        <JsonProperty("data")>
        Public Property data As String
    End Class
End Class
Public Class ListaUsuarios
    Public Class JsonListaUsuarios

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
        <JsonProperty("id")>
        Public Property id As String

        <JsonProperty("usuario")>
        Public Property usuario As String


    End Class

End Class
Public Class ListaCuentaUser
    Public Class JsonListaCuentaUser

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
        <JsonProperty("id_usuario")>
        Public Property id_usuario As String

        <JsonProperty("usuario")>
        Public Property usuario As String

        <JsonProperty("nombres")>
        Public Property nombres As String

        <JsonProperty("apellidos")>
        Public Property apellidos As String

        <JsonProperty("celular")>
        Public Property celular As String

        <JsonProperty("fotoperfil")>
        Public Property fotoperfil As String

        <JsonProperty("fotoperfil_local")>
        Public Property fotoperfil_local As String




    End Class

End Class
Public Class BuscaUsuarios
    Public Class JsonBuscaUsuarios

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
        <JsonProperty("id_usuario")>
        Public Property id_usuario As String

        <JsonProperty("usuario")>
        Public Property usuario As String

        <JsonProperty("descripcion")>
        Public Property descripcion As String

        <JsonProperty("numero_doc")>
        Public Property numero_doc As String

        <JsonProperty("fotoperfil")>
        Public Property fotoperfil As String

        <JsonProperty("nombres")>
        Public Property nombres As String

        <JsonProperty("celular")>
        Public Property celular As String

        <JsonProperty("apellidos")>
        Public Property apellidos As String

        <JsonProperty("ya_asignado")>
        Public Property ya_asignado As String



    End Class

End Class
Public Class AgregarUsuario

    Public Class JsonAgregarUsuario

        <JsonProperty("estado")>
        Public Property estado As String

        <JsonProperty("code")>
        Public Property code As String

        <JsonProperty("message")>
        Public Property message As String


    End Class
End Class
Public Class ModificaUsuario

    Public Class JsonModificaUsuario

        <JsonProperty("estado")>
        Public Property estado As String

        <JsonProperty("code")>
        Public Property code As String

        <JsonProperty("message")>
        Public Property message As String


    End Class
End Class