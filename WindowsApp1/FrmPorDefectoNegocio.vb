Imports System.Data.SqlClient
Imports System.Net
Imports System.Runtime.InteropServices
Imports FontAwesome.Sharp
Imports Newtonsoft.Json
Imports WindowsApp1.Almacenes.ListaAlmacenes
Imports WindowsApp1.Locales.ListaLocales
Imports WindowsApp1.Negocio.ListaAccesoNegocios
Imports WindowsApp1.Negocio.ListaNegocioAcceso

Public Class FrmPorDefectoNegocio
    Private Sub PanelSup_Paint(sender As Object, e As PaintEventArgs) Handles PanelSup.Paint

    End Sub

    Private Sub PanelSup_Resize(sender As Object, e As EventArgs) Handles PanelSup.Resize
        Me.Text = ""
        Me.ControlBox = False
    End Sub
    'Drag Form'
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub PanelSup_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelSup.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub CmdMin_Click(sender As Object, e As EventArgs)
        WindowState = FormWindowState.Minimized
        Me.Text = ""
        Me.ControlBox = True

    End Sub

    Private Sub CmdRestaurar_Click(sender As Object, e As EventArgs)
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmPorDefectoNegocio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim wflagneg As Integer = 0
        Me.Icon = My.Resources.icologo
        Dim result As String
        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        Me.Centrar()

        LblNegocio.Text = ""
        LblLocal.Text = ""
        LblAlmacen.Text = ""


        ' If lk_api_ListaNegocios Is Nothing Then
        ' RECARGARNEGOCIOS()
        ' End If
        'If lk_api_AccesoNegocios Is Nothing Then

        ' End If
        If lk_sql_Usuario_negocio.Rows.Count > 0 Then
            wflagneg = 1
            MisNegocios()
        End If


        'MsgBox(lk_api_ListaNegocios.estado)

        ' RECARGAR_ACCESONEGOCIOS()
        'If lk_api_ValidaUsuario.AccessNegocio.Count > 0 Then
        ' wflagneg = 1
        'End If
        Me.Opacity = 1
        If wflagneg = 0 Then
            result = MensajesBox.Show("No cuenta con Negocio Propio ni de Tercero, para usar el sistema." & Chr(13) & "Debe dar su Usuario y le otrogen el acceso o puede crear su propio cuenta de negocio con la plataforma ORI.",
                                          "Asignar Negocio por defecto.")
            Me.Close()
        End If

    End Sub
    Private Sub RECARGAR_ACCESONEGOCIOS()



        'Dim parametroneg = New List(Of Parametro) From {
        '            New Parametro("idUsuario", lk_id_usuario)
        '            }
        'Dim responseneg = MuestraDataApi(lk_api_cadena_base + "access/control/usuario", parametroneg) ' respuesta : vps_Usaurios
        Try
            '  lk_api_ListaNegocioAcceso = JsonConvert.DeserializeObject(Of JsonListaNegocioAcceso)(responseneg) 'Cái truyền tên Class vào

            If lk_api_ValidaUsuario.estado = True Then



                For I = 0 To lk_api_ValidaUsuario.AccessNegocio.Count - 1
                    DGNegocios.Rows.Add()
                    DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(0).Value = Trim(lk_api_ValidaUsuario.AccessNegocio(I).nombrecomercial) & vbCrLf & "RUC : " & Trim(lk_api_ValidaUsuario.AccessNegocio(I).numeroreg) & vbCrLf & Strings.Left(lk_api_ValidaUsuario.AccessNegocio(I).nombre, 20) & "..."

                    If lk_api_ValidaUsuario.AccessNegocio(I).fotonegociolocal = "-" Then
                        DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(1).Value = My.Resources.negocio ' Image.FromFile(My.Resources.negocio)
                    Else
                        DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(1).Value = Image.FromFile(lk_api_ValidaUsuario.AccessNegocio(I).fotonegociolocal)
                    End If

                    DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(2).Value = Trim(lk_api_ValidaUsuario.AccessNegocio(I).id_negocio)
                    DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(3).Value = ""
                    DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(4).Value = Strings.Trim(lk_api_ValidaUsuario.AccessNegocio(I).nombre)
                    DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(5).Value = Strings.Trim(lk_api_ValidaUsuario.AccessNegocio(I).descripcion)
                    DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(6).Value = Strings.Trim(lk_api_ValidaUsuario.AccessNegocio(I).numeroreg)
                    DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(7).Value = Strings.Trim(lk_api_ValidaUsuario.AccessNegocio(I).fotonegociolocal)
                    DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(8).Value = Strings.Trim(lk_api_ValidaUsuario.AccessNegocio(I).nombrecomercial)
                    DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(9).Value = Strings.Trim(lk_api_ValidaUsuario.AccessNegocio(I).direccion)
                    DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(10).Value = Strings.Trim(lk_api_ValidaUsuario.AccessNegocio(I).estado_acceso)

                    DGNegocios.Columns(0).Width = 180
                    DGNegocios.Columns(1).Width = 180
                    DGNegocios.Columns(2).Width = 0
                    DGNegocios.Columns(2).Visible = False
                    DGNegocios.Columns(3).Width = 60
                    DGNegocios.Rows(DGNegocios.Rows.Count - 1).Height = 60

                Next


            End If
        Catch ex As Exception
            MsgBox("ERRO RECARGARNEGOCIOS ")
            Exit Sub
        End Try
    End Sub
    Private Sub MisNegocios()
        DGNegocios.Rows.Clear()
        For I = 0 To lk_sql_Usuario_negocio.Rows.Count - 1

            If lk_sql_Usuario_negocio.Rows(I).Item("estado").ToString = "1" Then
                ' pasas
            Else
                GoTo NoTieneAcceso
            End If
            DGNegocios.Rows.Add()
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(0).Value = Trim(lk_sql_Usuario_negocio.Rows(I).Item("neg_abreviado").ToString) & vbCrLf & "RUC : " & Trim(lk_sql_Usuario_negocio.Rows(I).Item("neg_numerodoc").ToString) & vbCrLf & Strings.Left(lk_sql_Usuario_negocio.Rows(I).Item("neg_nombre").ToString, 20) & "..."
            If lk_sql_Usuario_negocio.Rows(I).Item("fotonegociolocal").ToString = "-" Then
                DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(1).Value = My.Resources.negocio ' Image.FromFile(My.Resources.negocio)
            Else
                DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(1).Value = Image.FromFile(lk_sql_Usuario_negocio.Rows(I).Item("fotonegociolocal").ToString)
            End If
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(2).Value = Trim(lk_sql_Usuario_negocio.Rows(I).Item("id_negocio").ToString)
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(3).Value = Trim(lk_sql_Usuario_negocio.Rows(I).Item("tipo").ToString)
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(4).Value = Strings.Trim(lk_sql_Usuario_negocio.Rows(I).Item("neg_nombre").ToString)
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(5).Value = Strings.Trim(lk_sql_Usuario_negocio.Rows(I).Item("des_tipdoc").ToString)
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(6).Value = Strings.Trim(lk_sql_Usuario_negocio.Rows(I).Item("neg_numerodoc").ToString)
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(7).Value = Strings.Trim(lk_sql_Usuario_negocio.Rows(I).Item("fotonegociolocal").ToString)
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(8).Value = Strings.Trim(lk_sql_Usuario_negocio.Rows(I).Item("neg_abreviado").ToString)
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(9).Value = Strings.Trim(lk_sql_Usuario_negocio.Rows(I).Item("direccion").ToString)
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(10).Value = Strings.Trim(lk_sql_Usuario_negocio.Rows(I).Item("estado").ToString)

            DGNegocios.Columns(0).Width = 180
            DGNegocios.Columns(1).Width = 180
            DGNegocios.Columns(2).Width = 0
            DGNegocios.Columns(2).Visible = False
            DGNegocios.Columns(3).Width = 60
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Height = 60
NoTieneAcceso:
        Next


        'lk_NegocioActivo.id_Negocio = 2
        'lk_NegocioActivo.nombre =4
        'lk_NegocioActivo.tipodoc = "RUC" 5 
        'lk_NegocioActivo.numdoc = 6 lk_api_ListaNegocios.data(I).numeroreg
        'lk_NegocioActivo.fotonegocio = 7 lk_api_ListaNegocios.data(I).fotonegociolocal
        'lk_NegocioActivo.nombrecomercial = 8
        'lk_NegocioActivo.direccion = 9
        'lk_NegocioActivo.estado = 10


    End Sub
    Public Sub Centrar()
        Dim xl, yl As Integer
        xl = (Screen.PrimaryScreen.WorkingArea.Width - Me.Size.Width) / 2
        yl = (Screen.PrimaryScreen.WorkingArea.Height - Me.Size.Height) / 2
        Me.Location = New Point(xl, yl)



    End Sub

    Private Sub DGNegocios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGNegocios.CellContentClick

    End Sub

    Private Sub DGNegocios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGNegocios.CellClick
        Dim ws_IdNegocio As Integer

        ws_IdNegocio = DGNegocios.Rows(e.RowIndex).Cells(2).Value
        Dim ws_espropio As String = DGNegocios.Rows(e.RowIndex).Cells(3).Value

        'Dim frCargainfo As New FrmCarga
        'Me.Opacity = 0.9
        'frCargainfo.LogoSolicdo.Visible = True
        'frCargainfo.Show()
        'Application.DoEvents()


        DGLocales.Rows.Clear()
        DGAlmacenes.Rows.Clear()
        ' If ws_espropio = "PROPIO" Then
        'llena_Lista_Locales_propios(ws_IdNegocio)
        'Else
        llena_Lista_Locales(ws_IdNegocio)
        'End If


        LblNegocio.Text = Trim(DGNegocios.Rows(e.RowIndex).Cells(4).Value)

fin:
        '   frCargainfo.Close()
        '    Me.Opacity = 1
        'Me.Show()
    End Sub

    Dim WithEvents CLIENTE As New WebClient 'LO DECLARAMOS CON EVENTS PARA PODER UTILIZAR LOS PROCEDIMIENTOS PROGRESSCHANGED Y COMPLETED

    Private Sub llena_Lista_Locales(ws_idnegocio As String)



        Try
            ' lk_api_ListaLocales = JsonConvert.DeserializeObject(Of JsonListaLocales)(responseneg) 'Cái truyền tên Class vào

            For I = 0 To lk_sql_Usuario_local.Rows.Count - 1
                ' Trim(lk_sql_Usuario_negocio.Rows(I).Item("id_negocio").ToString)
                If lk_sql_Usuario_local.Rows(I).Item("local_fotolocal") = "-" Then
                    lk_sql_Usuario_local.Rows(I).Item("fotolocal_local") = "-"
                    If lk_sql_Usuario_local.Rows(I).Item("id_tb_tipolocal").ToString = 1 Then
                        lk_sql_Usuario_local.Rows(I).Item("fotolocallocal_Defecto") = My.Resources.botica
                    ElseIf lk_sql_Usuario_local.Rows(I).Item("id_tb_tipolocal").ToString = 2 Then
                        lk_sql_Usuario_local.Rows(I).Item("fotolocallocal_Defecto") = My.Resources.farmacia
                    ElseIf lk_sql_Usuario_local.Rows(I).Item("id_tb_tipolocal").ToString = 3 Then
                        lk_sql_Usuario_local.Rows(I).Item("fotolocallocal_Defecto") = My.Resources.deli
                    ElseIf lk_sql_Usuario_local.Rows(I).Item("id_tb_tipolocal").ToString = 4 Then
                        lk_sql_Usuario_local.Rows(I).Item("fotolocallocal_Defecto") = My.Resources.distrib
                    Else
                        lk_sql_Usuario_local.Rows(I).Item("fotolocallocal_Defecto") = My.Resources.negocio
                    End If
                Else
                    Dim wRutaLocalfile As String = lk_Carpeta_Temp & System.IO.Path.GetFileName(lk_sql_Usuario_local.Rows(I).Item("local_fotolocal").ToString)
                    If System.IO.File.Exists(wRutaLocalfile) Then

                    Else
                        CLIENTE.DownloadFile(New Uri(lk_sql_Usuario_local.Rows(I).Item("local_fotolocal").ToString), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                    End If
                    'Dim wRutaLocalfile As String = My.Computer.FileSystem.CurrentDirectory & lk_api_ListaLocales.data(I).id_local & System.IO.Path.GetFileName(lk_api_ListaLocales.data(I).fotolocal)
                    'CLIENTE.DownloadFile(New Uri(lk_api_ListaLocales.data(I).fotolocal), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                    lk_sql_Usuario_local.Rows(I).Item("fotolocal_local") = wRutaLocalfile

                End If
            Next

        Catch ex As Exception
            Exit Sub
        End Try




        For I = 0 To lk_sql_Usuario_local.Rows.Count - 1
            If ws_idnegocio = lk_sql_Usuario_local.Rows(I).Item("id_negocio").ToString Then
                If lk_sql_Usuario_local.Rows(I).Item("estado").ToString = 0 Then Continue For
                DGLocales.Rows.Add()
                DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(0).Value = Trim(lk_sql_Usuario_local.Rows(I).Item("local_nombre").ToString) & vbCrLf & "CODIGO : " & Trim(lk_sql_Usuario_local.Rows(I).Item("local_codigo").ToString) & vbCrLf & Trim(lk_sql_Usuario_local.Rows(I).Item("local_abreviado").ToString)
                If lk_sql_Usuario_local.Rows(I).Item("fotolocal_local").ToString = "-" Then
                    DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(1).Value = lk_sql_Usuario_local.Rows(I).Item("fotolocallocal_Defecto")
                Else
                    DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(1).Value = Image.FromFile(lk_sql_Usuario_local.Rows(I).Item("fotolocal_local").ToString)
                End If
                DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(2).Value = Trim(lk_sql_Usuario_local.Rows(I).Item("id_local").ToString)
                DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(3).Value = I
                DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(4).Value = Trim(lk_sql_Usuario_local.Rows(I).Item("local_nombre").ToString)
                DGLocales.Columns(0).Width = 200
                DGLocales.Columns(1).Width = 100
                DGLocales.Columns(2).Width = 0
                DGLocales.Columns(2).Visible = False
                DGLocales.Columns(3).Width = 60
                DGLocales.Rows(DGLocales.Rows.Count - 1).Height = 60
            End If

        Next




        Exit Sub
NoIngresa:
    End Sub


    Private Sub llena_Lista_Locales_propios(ws_idnegocio As String)
        Dim result

        Dim parametroneg = New List(Of Parametro) From {
             New Parametro("id_negocio", ws_idnegocio)
             }

        Dim responseneg = MuestraDataApi(lk_api_cadena_base + "negocio/local/listar", parametroneg) ' respuesta : vps_Usaurios
        Try
            lk_api_ListaLocales = JsonConvert.DeserializeObject(Of JsonListaLocales)(responseneg) 'Cái truyền tên Class vào
            If lk_api_ListaLocales.estado = True Then
                For I = 0 To lk_api_ListaLocales.data.Count - 1
                    If lk_api_ListaLocales.data(I).fotolocal = "-" Then
                        lk_api_ListaLocales.data(I).fotolocal_local = "-"
                        If lk_api_ListaLocales.data(I).id_tb_tipolocal = 1 Then
                            lk_api_ListaLocales.data(I).fotolocal_local_Defecto = My.Resources.botica
                        ElseIf lk_api_ListaLocales.data(I).id_tb_tipolocal = 2 Then
                            lk_api_ListaLocales.data(I).fotolocal_local_Defecto = My.Resources.farmacia
                        ElseIf lk_api_ListaLocales.data(I).id_tb_tipolocal = 3 Then
                            lk_api_ListaLocales.data(I).fotolocal_local_Defecto = My.Resources.deli
                        ElseIf lk_api_ListaLocales.data(I).id_tb_tipolocal = 4 Then
                            lk_api_ListaLocales.data(I).fotolocal_local_Defecto = My.Resources.distrib
                        Else
                            lk_api_ListaLocales.data(I).fotolocal_local_Defecto = My.Resources.negocio
                        End If
                    Else
                        Dim wRutaLocalfile As String = lk_Carpeta_Temp & System.IO.Path.GetFileName(lk_api_ListaLocales.data(I).fotolocal)
                        If System.IO.File.Exists(wRutaLocalfile) Then

                        Else
                            CLIENTE.DownloadFile(New Uri(lk_api_ListaLocales.data(I).fotolocal), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                        End If
                        'Dim wRutaLocalfile As String = My.Computer.FileSystem.CurrentDirectory & lk_api_ListaLocales.data(I).id_local & System.IO.Path.GetFileName(lk_api_ListaLocales.data(I).fotolocal)
                        'CLIENTE.DownloadFile(New Uri(lk_api_ListaLocales.data(I).fotolocal), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                        lk_api_ListaLocales.data(I).fotolocal_local = wRutaLocalfile

                    End If
                Next

            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If lk_api_ListaLocales.estado = False Then
            result = MensajesBox.Show("Todavia no a creado sus Locales." & Chr(13) & "Ingrese la Informacion de su local. ",
                                           "Crear Locales")
            GoTo NoIngresa
        End If


        For I = 0 To lk_api_ListaLocales.data.Count - 1
            If ws_idnegocio = lk_api_ValidaUsuario.AccessLocal(I).id_negocio And lk_api_ValidaUsuario.AccessLocal(I).estado_acceso = "1" Then ' Solo al Almacen y con el Estado 1 con acceso 
                DGLocales.Rows.Add()
                DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(0).Value = Trim(lk_api_ListaLocales.data(I).nombreabreviado) & vbCrLf & "CODIGO : " & Trim(lk_api_ListaLocales.data(I).codigo) & vbCrLf & Trim(lk_api_ListaLocales.data(I).nombre)
                If lk_api_ListaLocales.data(I).fotolocal_local = "-" Then
                    DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(1).Value = lk_api_ListaLocales.data(I).fotolocal_local_Defecto
                Else
                    DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(1).Value = Image.FromFile(lk_api_ListaLocales.data(I).fotolocal_local)
                End If

                DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(2).Value = Trim(lk_api_ListaLocales.data(I).id_local)
                DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(3).Value = I
                DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(4).Value = Trim(lk_api_ListaLocales.data(I).nombre)
                DGLocales.Columns(0).Width = 200
                DGLocales.Columns(1).Width = 100
                DGLocales.Columns(2).Width = 0
                DGLocales.Columns(2).Visible = False
                DGLocales.Columns(3).Width = 60
                DGLocales.Rows(DGLocales.Rows.Count - 1).Height = 60
            End If
        Next




        Exit Sub
NoIngresa:
    End Sub

    Private Sub DGLocales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGLocales.CellContentClick

    End Sub

    Private Sub DGLocales_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGLocales.CellClick
        Dim ws_IdLocal As Integer
        ws_IdLocal = DGLocales.Rows(e.RowIndex).Cells(2).Value

        Dim frCargainfo As New FrmCarga
        Me.Opacity = 0.9

        frCargainfo.LogoSolicdo.Visible = True
        frCargainfo.Show()
        Application.DoEvents()



        llena_lista_Almacenes(ws_IdLocal)

        DGAlmacenes.Rows.Clear()


        'If lk_api_ListaAlmacenes.estado = False Then
        'GoTo fin
        ' End If


        Dim FOTODEFECTO = My.Resources.alma
        ' 1 paso ver q almacenes tien apra marcar

        'For I = 0 To lk_sql_Usuario_almacen.Rows.Count - 1
        ' If lk_sql_Usuario_almacen.Rows(I).Item("alm_fotoalmacen") = "-" Then

        For I = 0 To lk_sql_Usuario_almacen.Rows.Count - 1
            If ws_IdLocal = lk_sql_Usuario_almacen.Rows(I).Item("id_local") And lk_sql_Usuario_almacen.Rows(I).Item("estado") = "1" Then ' Solo al Almacen y con el Estado 1 con acceso 
                DGAlmacenes.Rows.Add()
                DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(0).Value = Trim(lk_sql_Usuario_almacen.Rows(I).Item("alm_nombre")) & vbCrLf & "CODIGO : " & Trim(lk_sql_Usuario_almacen.Rows(I).Item("alm_codigo")) & vbCrLf & Trim(lk_sql_Usuario_almacen.Rows(I).Item("alm_abreviado"))
                If lk_sql_Usuario_almacen.Rows(I).Item("alm_fotoalmacen") = "-" Then
                    DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(1).Value = lk_sql_Usuario_almacen.Rows(I).Item("fotoalmacenlocal_Defecto")
                Else
                    DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(1).Value = Image.FromFile(lk_sql_Usuario_almacen.Rows(I).Item("fotoalmacen_local"))
                End If
                DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(2).Value = Trim(lk_sql_Usuario_almacen.Rows(I).Item("id_almacen"))
                DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(3).Value = Trim(lk_sql_Usuario_almacen.Rows(I).Item("alm_nombre"))
                DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(4).Value = I
                DGAlmacenes.Columns(0).Width = 200
                DGAlmacenes.Columns(1).Width = 100
                DGAlmacenes.Columns(2).Width = 0
                ' DGAlmacenes.Columns(3).Visible = False
                DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Height = 60
            End If

        Next

        LblLocal.Text = DGLocales.Rows(e.RowIndex).Cells(4).Value



        frCargainfo.Close()
        Me.Opacity = 1
        Exit Sub
fin:
        frCargainfo.Close()
        Me.Opacity = 1
    End Sub
    Private Sub llena_lista_Almacenes(ws_idlocal As String)

        'Dim result

        ''  If lk_api_ListaNegocios Is Nothing Then
        'Dim parametroneg = New List(Of Parametro) From {
        '     New Parametro("id_local", ws_idlocal)
        '     }
        'For I = 0 To lk_sql_Usuario_local.Rows.Count - 1
        '    ' Trim(lk_sql_Usuario_negocio.Rows(I).Item("id_negocio").ToString)
        '    If lk_sql_Usuario_local.Rows(I).Item("local_fotolocal") = "-" Then
        '        lk_sql_Usuario_local.Rows(I).Item("fotolocal_local") = "-"





        'Dim responseneg = MuestraDataApi(lk_api_cadena_base + "negocio/almacen/listar", parametroneg) ' respuesta : vps_Usaurios
        Try
            '   lk_api_ListaAlmacenes = JsonConvert.DeserializeObject(Of JsonListaAlmacenes)(responseneg) 'Cái truyền tên Class vào

            For I = 0 To lk_sql_Usuario_almacen.Rows.Count - 1
                If lk_sql_Usuario_almacen.Rows(I).Item("alm_fotoalmacen") = "-" Then
                    lk_sql_Usuario_almacen.Rows(I).Item("fotoalmacenlocal_Defecto") = My.Resources.alma
                    lk_sql_Usuario_almacen.Rows(I).Item("fotoalmacen_local") = "-"
                Else
                    Dim wRutaLocalfile As String = lk_Carpeta_Temp & System.IO.Path.GetFileName(lk_sql_Usuario_almacen.Rows(I).Item("alm_fotoalmacen").ToString)
                    If System.IO.File.Exists(wRutaLocalfile) Then

                    Else
                        CLIENTE.DownloadFile(New Uri(lk_sql_Usuario_almacen.Rows(I).Item("alm_fotoalmacen").ToString), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                    End If
                    'Dim wRutaLocalfile As String = My.Computer.FileSystem.CurrentDirectory & lk_api_ListaLocales.data(I).id_local & System.IO.Path.GetFileName(lk_api_ListaLocales.data(I).fotolocal)
                    'CLIENTE.DownloadFile(New Uri(lk_api_ListaLocales.data(I).fotolocal), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                    lk_sql_Usuario_almacen.Rows(I).Item("fotoalmacen_local") = wRutaLocalfile

                End If
            Next

        Catch ex As Exception
            Exit Sub
        End Try

        'If lk_api_ListaAlmacenes.estado = False Then
        ' result = MensajesBox.Show("Todavia no a creado sus Almacenes para el Local." & Chr(13) & "Ingrese la Informacion de su Almacen. ",
        '                                    "Crear Almacen")
        ' GoTo NoIngresa
        ' End If


        Exit Sub
NoIngresa:

    End Sub

    Private Sub DGAlmacenes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGAlmacenes.CellContentClick

    End Sub

    Private Sub DGAlmacenes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGAlmacenes.CellClick


        LblAlmacen.Text = DGAlmacenes.Rows(e.RowIndex).Cells(3).Value
    End Sub

    Private Sub CmdAddLocal_Click(sender As Object, e As EventArgs) Handles CmdAddLocal.Click
        Dim Result As String
        If DGAlmacenes.CurrentRow Is Nothing Then
            Result = MensajesBox.Show("Definir un almacen por defecto.",
                                                "Definir Negocio Local y alamcen por defecto")

            Exit Sub
        End If
        If DGNegocios.Rows(DGNegocios.CurrentRow.Index).Cells(10).Value <> "1" Then
            MsgBox("Sin ACCESO")
            Exit Sub
        Else

        End If



        lk_NegocioActivo.id_Negocio = DGNegocios.Rows(DGNegocios.CurrentRow.Index).Cells(2).Value
        lk_NegocioActivo.nombre = DGNegocios.Rows(DGNegocios.CurrentRow.Index).Cells(4).Value
        lk_NegocioActivo.tipodoc = DGNegocios.Rows(DGNegocios.CurrentRow.Index).Cells(5).Value
        lk_NegocioActivo.numdoc = DGNegocios.Rows(DGNegocios.CurrentRow.Index).Cells(6).Value
        lk_NegocioActivo.fotonegocio = DGNegocios.Rows(DGNegocios.CurrentRow.Index).Cells(7).Value
        lk_NegocioActivo.nombrecomercial = DGNegocios.Rows(DGNegocios.CurrentRow.Index).Cells(8).Value
        lk_NegocioActivo.direccion = DGNegocios.Rows(DGNegocios.CurrentRow.Index).Cells(9).Value
        lk_NegocioActivo.estado = DGNegocios.Rows(DGNegocios.CurrentRow.Index).Cells(10).Value


        Dim ws_pos As Integer = DGLocales.Rows(DGLocales.CurrentRow.Index).Cells(3).Value

        Dim ws_pos_alm As Integer = DGAlmacenes.Rows(DGAlmacenes.CurrentRow.Index).Cells(4).Value


        lk_LocalActivo.id_local = lk_sql_Usuario_local.Rows(ws_pos).Item("id_local").ToString()
        lk_LocalActivo.id_Negocio = lk_sql_Usuario_local.Rows(ws_pos).Item("id_negocio").ToString()
        lk_LocalActivo.nombre = lk_sql_Usuario_local.Rows(ws_pos).Item("id_negocio").ToString()
        lk_LocalActivo.abreviado = lk_sql_Usuario_local.Rows(ws_pos).Item("local_abreviado").ToString()
        lk_LocalActivo.codigo = lk_sql_Usuario_local.Rows(ws_pos).Item("local_codigo").ToString()
        lk_LocalActivo.fotolocal = lk_sql_Usuario_local.Rows(ws_pos).Item("fotolocal_local").ToString()
        lk_LocalActivo.direccion = ""
        lk_LocalActivo.estado = lk_sql_Usuario_local.Rows(ws_pos).Item("estado").ToString()

        lk_AlmacenActivo.id_local = lk_sql_Usuario_local.Rows(ws_pos).Item("id_local").ToString()
        lk_AlmacenActivo.id_Negocio = lk_sql_Usuario_local.Rows(ws_pos).Item("id_negocio").ToString()
        lk_AlmacenActivo.id_almacen = lk_sql_Usuario_almacen.Rows(ws_pos_alm).Item("id_almacen").ToString()
        lk_AlmacenActivo.nombre = lk_sql_Usuario_almacen.Rows(ws_pos_alm).Item("alm_nombre").ToString()
        lk_AlmacenActivo.abreviado = lk_sql_Usuario_almacen.Rows(ws_pos_alm).Item("alm_abreviado").ToString()
        lk_AlmacenActivo.codigo = lk_sql_Usuario_almacen.Rows(ws_pos_alm).Item("alm_codigo").ToString()
        lk_AlmacenActivo.fotoalmacen = lk_sql_Usuario_almacen.Rows(ws_pos_alm).Item("fotoalmacen_local").ToString()
        lk_AlmacenActivo.direccion = ""
        lk_AlmacenActivo.estado = lk_sql_Usuario_almacen.Rows(ws_pos_alm).Item("estado").ToString()



        If lk_NegocioActivo.id_Negocio = "" Then ' NO TIENE NEGOCIO ASIGNADO
            FrmLogin.CmdCreaTuNegocio.Text = "MI PRIMER NEGOCIO"
            FrmLogin.CmdCreaTuNegocio.IconChar = FontAwesome.Sharp.IconChar.Store

        Else
            FrmLogin.CmdIdNegocio.Text = lk_NegocioActivo.nombre
            FrmLogin.CmdIdNegocio.Tag = lk_NegocioActivo.id_Negocio
            If lk_NegocioActivo.fotonegocio = "-" Then
                FrmLogin.FotoNegocio.Image = My.Resources.negocio
            Else
                FrmLogin.FotoNegocio.Image = Image.FromFile(lk_NegocioActivo.fotonegocio)
            End If
            FrmLogin.CmdCreaTuNegocio.Text = "MI NEGOCIO"
            FrmLogin.CmdCreaTuNegocio.IconColor = System.Drawing.ColorTranslator.FromHtml("#2A476D")
            FrmLogin.CmdCreaTuNegocio.IconChar = FontAwesome.Sharp.IconChar.Stream
        End If
        Dim command As SqlCommand = New SqlCommand("update m_usuarios set id_neg_def = " & lk_NegocioActivo.id_Negocio & " , id_loc_def = " & lk_LocalActivo.id_local & " , id_alm_def  = " & lk_AlmacenActivo.id_almacen & " where  id_usuario= " & lk_id_usuario & "", lk_connection_master)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        Dim Sql_ActualizaUser As New DataTable
        adapter.Fill(Sql_ActualizaUser)
        Dim filasActualizadas As Integer = command.ExecuteNonQuery()
        If filasActualizadas = 0 Then
        Else
        End If

        Carga_Paramtros_Negocio(lk_NegocioActivo.id_Negocio)
        Me.Close()
    End Sub
End Class