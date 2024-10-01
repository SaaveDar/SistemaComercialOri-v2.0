Imports System.Data.SqlClient
Imports Newtonsoft.Json
Imports WindowsApp1.ListaTablas
Imports WindowsApp1.ListaUbigeoN1
Imports WindowsApp1.ListaUbigeoN2
Imports WindowsApp1.ListaUbigeoN3

Module Cargas
    Public Sub CargaUBIGEOS()
        'Dim command As SqlCommand = New SqlCommand("u_obtenerTipoDoc", lk_connection_master)
        'command.CommandType = CommandType.StoredProcedure
        'command.Parameters.AddWithValue("@usuario", TxtUsuario.Text)
        'Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        'adapter.Fill(lk_sql_ListaTipoDocPersona)


        '        If lk_sql_ListaUbigeoN1 Is Nothing Then
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        command = New SqlCommand("u_listar_ubigeo_n1", lk_connection_master)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Clear()
        command.Parameters.AddWithValue("@id", "1")
        adapter = New SqlDataAdapter(command)
        lk_sql_ListaUbigeoN1 = New DataTable
        adapter.Fill(lk_sql_ListaUbigeoN1)
        '    End If

        '       If lk_sql_ListaUbigeoN2 Is Nothing Then
        command = New SqlCommand("u_listar_ubigeo_n2", lk_connection_master)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Clear()
        command.Parameters.AddWithValue("@id", "1")
        adapter = New SqlDataAdapter(command)
        lk_sql_ListaUbigeoN2 = New DataTable
        adapter.Fill(lk_sql_ListaUbigeoN2)
        '      End If

        'If lk_sql_ListaUbigeoN3 Is Nothing Then
        command = New SqlCommand("u_listar_ubigeo_n3", lk_connection_master)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Clear()
        command.Parameters.AddWithValue("@id", "1")
        adapter = New SqlDataAdapter(command)
        lk_sql_ListaUbigeoN3 = New DataTable
        adapter.Fill(lk_sql_ListaUbigeoN3)
        'End If



        'If lk_sql_ListaTablas Is Nothing Then
        command = New SqlCommand("n_listar_tablasBasicas", lk_connection_master)
        adapter = New SqlDataAdapter(command)
        command.Parameters.Clear()
        lk_sql_ListaTablas = New DataTable
        adapter.Fill(lk_sql_ListaTablas)


        ' Dim parametro = New List(Of Parametro) From {
        'New Parametro("", "")}
        ' Dim response = MuestraDataApi(lk_api_cadena_base + "negocio/tablas/listar", parametro) ' respuesta : vps_Usaurios
        ' If Mid(response, 1, 1) = "*" Then
        '     Exit Sub
        ' End If
        ' lk_api_ListaTablas = JsonConvert.DeserializeObject(Of JsonListaTablas)(response) 'Cái truyền tên Class vào
        'End If
    End Sub
End Module
