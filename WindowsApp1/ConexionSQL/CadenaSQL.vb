Imports System.Data.SqlClient

Module CadenaSQL
    Public lk_sql_ValidaUsuario As DataTable = New DataTable()
    Public lk_sql_Usuario_negocio As DataTable = New DataTable()
    Public lk_sql_Usuario_local As DataTable = New DataTable()
    Public lk_sql_Usuario_almacen As DataTable = New DataTable()
    Public lk_sql_ListaTipoDocPersona As DataTable = New DataTable()

    Public lk_sql_ListaUbigeoN1 As DataTable = New DataTable()
    Public lk_sql_ListaUbigeoN2 As DataTable = New DataTable()
    Public lk_sql_ListaUbigeoN3 As DataTable = New DataTable()
    Public lk_sql_ListaTablas As DataTable = New DataTable()

    Public lk_sql_ListaLocales As New DataTable()
    Public lk_sql_ListaAlmacenes As New DataTable()
    Public lk_sql_estructura_prod As New DataTable()

    Public lk_sql_ListaCuentaUser As New DataTable()

    Public lk_sql_ListaNegocioAcceso As New DataTable()
    Public lk_sql_ListalocalAcceso As New DataTable()
    Public lk_sql_ListaHorarioLocal As New DataTable()
    Public lk_sql_ListAlmacenAcceso As New DataTable()
    Public lk_sql_BuscaUsuarios As New DataTable()

    Public lk_sql_ListaControlCajas As New DataTable()




    Public lk_sql_finanzas_local As DataTable

    Public datos_sql_resul As New DataTable()



    Public lk_Token_tigo As String
    Public lk_connection_master
    Public lk_connection_cuenta
    Public lk_connection_imagenes

    ''**********
    Public PCSERVER As String = ""
    Public PASSSEVER As String = ""
    Public SASEVER As String = ""
    Public LK_ES_FORMATO_ESPANOL As Boolean = True

    '**********

    'Public PCSERVER As String = "34.134.43.163"
    'Public PASSSEVER As String = "yp257sjtfBpqnNK8F%5s"
    'Public SASEVER As String = "sa"
    'Public LK_ES_FORMATO_ESPANOL As Boolean = False

    '**********

    Public Sub ConexionSQL_Maester()



        Dim connectionString As String = "Data Source=" & PCSERVER & ";Initial Catalog=r23_master;User ID=" & SASEVER & ";Password=" & PASSSEVER & ";"
        lk_connection_master = New SqlConnection(connectionString)
        lk_connection_master.Open()
    End Sub
    Public Sub ConexionSQL_Cuentas()
        'Dim connectionString As String = "Data Source=34.134.43.163;Initial Catalog=r23_negocio_cuenta;User ID=sa;Password=yp257sjtfBpqnNK8F%5s;"
        Dim connectionString As String = "Data Source=" & PCSERVER & ";Initial Catalog=r23_negocio_cuenta;User ID=" & SASEVER & ";Password=" & PASSSEVER & ";"
        lk_connection_cuenta = New SqlConnection(connectionString)
        lk_connection_cuenta.Open()
    End Sub
    Public Sub ConexionSQL_Imagenes()
        ' Dim connectionString As String = "Data Source=34.134.43.163;Initial Catalog=r23_images;User ID=sa;Password=yp257sjtfBpqnNK8F%5s;"
        Dim connectionString As String = "Data Source=" & PCSERVER & ";Initial Catalog=r23_images;User ID=" & SASEVER & ";Password=" & PASSSEVER & ";"
        lk_connection_imagenes = New SqlConnection(connectionString)
        lk_connection_imagenes.Open()
    End Sub
    Function Obtener_bd_Negocio(wid_negocio As Integer) As String
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim wnomb As String = ""

        sql_cade = "select  nombre_bd from [dbo].[neg_keys] negkey inner join basedatos_mae bd on  negkey.id_bd = bd.id_bd and negkey.id_negocio = " & wid_negocio & " "
        lk_sql_nombre_bd = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_nombre_bd)

        If lk_sql_nombre_bd.Rows.Count <> 0 Then
            wnomb = "*"
        Else

            wnomb = lk_sql_nombre_bd.Rows(0).Item("nombre_bd")
        End If

        Return wnomb
    End Function

End Module
