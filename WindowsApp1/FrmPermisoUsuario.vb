Imports System.Runtime.InteropServices
Imports FontAwesome.Sharp
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports WindowsApp1.ModificaDatos
Imports System.Net
Imports RestSharp
Imports WindowsApp1.Locales.ListaLocales
Imports WindowsApp1.Almacenes.ListaAlmacenes
Imports WindowsApp1.ListaCuentaUser
Imports WindowsApp1.Negocio.ListaNegocioAcceso
Imports WindowsApp1.Negocio.ListaLocalAcceso
Imports WindowsApp1.Negocio.ListaHorarioLocal
Imports WindowsApp1.Negocio.ListaAlmacenAcceso
Imports System.Data.SqlClient

Public Class FrmPermisoUsuario
    Dim AccesoNegocio(20) As Boolean
    Dim AccesoTienda(20, 20) As Boolean
    Dim AccesoAlmacen(20, 20, 20) As Boolean

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



    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub



    Private Sub CmdAddUsuario_Click(sender As Object, e As EventArgs) Handles CmdAddUsuario.Click
        Dim frsegundoplano As New FrmEsperar
        Dim wposi As Integer
        frsegundoplano.Left = Me.Left
        frsegundoplano.Top = Me.Top
        frsegundoplano.Width = Me.Width
        frsegundoplano.Height = Me.Height
        frsegundoplano.Opacity = 0.4
        frsegundoplano.Show()

        Dim frBuscaUsuario As New FrmBuscaUsuarios
        PlaySonidoMouse(lk_CodigoSonido)
        frBuscaUsuario.ShowDialog()
        If Trim(frBuscaUsuario.DGUser.Tag) = "" Then
            frsegundoplano.Close()
            frBuscaUsuario.Close()
            DGUsuarios.Select()
            Exit Sub
        End If
        frsegundoplano.Close()
        wposi = frBuscaUsuario.DGUser.Tag

        DGUsuarios.Columns(0).Width = 80
        DGUsuarios.Columns(1).Width = 130
        DGUsuarios.Columns(2).Width = 0
        DGUsuarios.Rows.Add()
        DGUsuarios.Rows(DGUsuarios.Rows.Count - 1).Cells(0).Value = lk_sql_BuscaUsuarios.Rows(wposi).Item("usuario").ToString.ToUpper
        DGUsuarios.Rows(DGUsuarios.Rows.Count - 1).Cells(1).Value = lk_sql_BuscaUsuarios.Rows(wposi).Item("nombres") & " " & lk_sql_BuscaUsuarios.Rows(wposi).Item("apellidos")
        DGUsuarios.Rows(DGUsuarios.Rows.Count - 1).Cells(2).Value = lk_sql_BuscaUsuarios.Rows(wposi).Item("id_usuario")

        DGUsuarios.Rows(DGUsuarios.Rows.Count - 1).Cells(4).Value = lk_sql_BuscaUsuarios.Rows(wposi).Item("celular")
        TxtUsuario.Tag = lk_sql_BuscaUsuarios.Rows(wposi).Item("usuario").ToString.ToUpper
        TxtUsuario.Text = lk_sql_BuscaUsuarios.Rows(wposi).Item("usuario").ToString.ToUpper
        TxtNombres.Text = lk_sql_BuscaUsuarios.Rows(wposi).Item("nombres") & " " & lk_sql_BuscaUsuarios.Rows(wposi).Item("apellidos")
        TxtCelular.Text = lk_sql_BuscaUsuarios.Rows(wposi).Item("celular")
        'If  lk_sql_BuscaUsuarios.Rows(wposi).Item("celular") erfil = "-" Then
        FotoUsuario.Image = My.Resources.userd ' Image.FromFile(My.Resources.negocio)
        DGUsuarios.Rows(DGUsuarios.Rows.Count - 1).Cells(3).Value = "-"
        'Else
        ' Dim wRutaLocalfile As String = lk_Carpeta_Temp & System.IO.Path.GetFileName(lk_api_BuscaUsuarios.data(wposi).fotoperfil)
        ' If System.IO.File.Exists(wRutaLocalfile) Then
        '
        '        Else
        '        CLIENTE.DownloadFile(New Uri(lk_api_BuscaUsuarios.data(wposi).fotoperfil), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
        '        End If
        '        FotoUsuario.Image = Image.FromFile(wRutaLocalfile)
        '        DGUsuarios.Rows(DGUsuarios.Rows.Count - 1).Cells(3).Value = wRutaLocalfile
        '        End If

        frBuscaUsuario.Close()
        DGUsuarios.Select()

    End Sub
    Private Sub ListaMisUsuarios()
        DGUsuarios.Rows.Clear()
        DGUsuarios.Columns(0).Width = 80
        DGUsuarios.Columns(1).Width = 130
        DGUsuarios.Columns(2).Width = 0
        RECARGA_LISTAUSUARIOS()
        If lk_sql_ListaCuentaUser.Rows.Count = 0 Then Exit Sub
        For I = 0 To lk_sql_ListaCuentaUser.Rows.Count - 1
            DGUsuarios.Rows.Add()
            DGUsuarios.Rows(DGUsuarios.Rows.Count - 1).Cells(0).Value = lk_sql_ListaCuentaUser.Rows(I).Item("usuario")
            DGUsuarios.Rows(DGUsuarios.Rows.Count - 1).Cells(1).Value = lk_sql_ListaCuentaUser.Rows(I).Item("nombres") & " " & lk_sql_ListaCuentaUser.Rows(I).Item("apellidos")
            DGUsuarios.Rows(DGUsuarios.Rows.Count - 1).Cells(2).Value = lk_sql_ListaCuentaUser.Rows(I).Item("id_usuario")
            DGUsuarios.Rows(DGUsuarios.Rows.Count - 1).Cells(3).Value = lk_sql_ListaCuentaUser.Rows(I).Item("fotoperfil_local")
            DGUsuarios.Rows(DGUsuarios.Rows.Count - 1).Cells(4).Value = lk_sql_ListaCuentaUser.Rows(I).Item("celular")

            'If lk_api_ListaCuentaUser.data(I).fotoperfil = "-" Then
            ' DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(1).Value = My.Resources.negocio ' Image.FromFile(My.Resources.negocio)
            ' Else
            ' DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(1).Value = Image.FromFile(lk_api_ListaNegocios.data(I).fotonegociolocal)
            ' End If

        Next
        DGUsuarios.ClearSelection()

    End Sub

    Public Sub RECARGA_LISTAUSUARIOS()

        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter

        command = New SqlCommand("acceso_listar_user", lk_connection_master)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@id_cuenta_user", lk_id_cuemta_user)
        adapter = New SqlDataAdapter(command)
        lk_sql_ListaCuentaUser = New DataTable
        adapter.Fill(lk_sql_ListaCuentaUser)
        Dim tempColumn = New DataColumn("fotoperfil_local", GetType(String))
        lk_sql_ListaCuentaUser.Columns.Add(tempColumn)




        Try


            For I = 0 To lk_sql_ListaCuentaUser.Rows.Count - 1
                lk_sql_ListaCuentaUser.Rows(I).Item("fotoperfil_local") = "-"
                'If lk_sql_ListaCuentaUser.Rows(I).Item("fotoperfil_local") = "-" Then
                '    lk_sql_ListaCuentaUser.data(I).fotoperfil_local = "-"
                'Else
                '    Dim wRutaLocalfile As String = lk_Carpeta_Temp & System.IO.Path.GetFileName(lk_sql_ListaCuentaUser.data(I).fotoperfil)
                '    If System.IO.File.Exists(wRutaLocalfile) Then

                '    Else
                '        CLIENTE.DownloadFile(New Uri(lk_sql_ListaCuentaUser.data(I).fotoperfil), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                '    End If
                '    'Dim wRutaLocalfile As String = My.Computer.FileSystem.CurrentDirectory & "\" & Format(Now, "mmss") & lk_api_ListaNegocios.data(I).id_negocio & System.IO.Path.GetFileName(lk_api_ListaNegocios.data(I).fotonegocio)
                '    'CLIENTE.DownloadFile(New Uri(lk_api_ListaNegocios.data(I).fotonegocio), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                '    lk_sql_ListaCuentaUser.data(I).fotoperfil_local = wRutaLocalfile

                'End If
            Next


        Catch ex As Exception
            MsgBox("ERRO RECARGAR USER ")
            Exit Sub
        End Try
    End Sub



    Private Sub IconButton3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FrmPermisoUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Se Definir lcas catnidades de cada array para cada negocio







        'PCSERVER = "acosme"
        'PASSSEVER = "159357852456"
        'SASEVER = "sa"
        'LK_ES_FORMATO_ESPANOL = True
        'LK_RUTA_RPT = "D:\Proyectos VisualStudio\Ori\SistemaComercialOri\WindowsApp1\FormatosCrystal\"

        'CERRAR_SESIONES()
        'ConexionSQL_Maester()
        'ConexionSQL_Cuentas()
        'Carga_Paramtros_Generales()
        'Dim command As SqlCommand = New SqlCommand("u_login", lk_connection_master)
        'command.CommandType = CommandType.StoredProcedure
        'command.Parameters.AddWithValue("@usuario", "admin")
        'command.Parameters.AddWithValue("@clave", "1234")
        'Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        'adapter.Fill(lk_sql_ValidaUsuario)
        'lk_fecha_dia = Now
        'lk_id_usuario = lk_sql_ValidaUsuario.Rows(0)("id_usuario").ToString()
        'lk_usuario = lk_sql_ValidaUsuario.Rows(0)("Usuario").ToString()
        'lk_id_cuemta_user = lk_sql_ValidaUsuario.Rows(0)("id_cuenta_user").ToString()
        'lk_Carpeta_Temp = My.Computer.FileSystem.CurrentDirectory & "\user" & lk_id_usuario & "\"
        'My.Computer.FileSystem.CreateDirectory(lk_Carpeta_Temp)
        'lk_foto_perfil_id = 0
        'lk_id_cuemta_user = 1
        'Negocio_Local_Almacen_Usuario()

        '*************************

        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)

        PanelAccesos.Left = 16
        PanelAccesos.Top = 230




        FotoUsuario.Image = My.Resources.userd
        DGAccesos.Rows.Clear()
        DGAccesos.Rows.Add()
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(0).Value = 0
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(1).Value = "MANTENEDOR DE PRODUCTOS"
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(2).Value = False
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(2).ReadOnly = True
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(3).Value = False
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(3).ReadOnly = True
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(4).Value = False
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(4).ReadOnly = True
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(5).Value = False
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(5).ReadOnly = True

        For I = 1 To 10
            DGAccesos.Rows.Add()
            DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(0).Value = I
            DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(1).Value = "Descripcion detalla el acceso q tendria de acuerdo a las check q que lusuario coloque." & I
            'DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(2).Value = I
            'DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(3).Value = I
            'DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(4).Value = I
            'DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(5).Value = I
            DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(6).Value = I

            'DGAccesos.Columns(0).Width = 20
            'DGAccesos.Columns(1).Width = 150
            'DGAccesos.Columns(2).Width = 50
            'DGAccesos.Columns(3).Width = 0
            'DGAccesos.Columns(3).Visible = False
            'DGAccesos.Rows(DGAccesos.Rows.Count - 1).Height = 40
        Next

        'DGAccesos.Rows.Clear()
        'DGAccesos.Rows.Add()
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(0).Value = 0
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(1).Value = "MANTENEDOR DE SOCIO DE NEGOCIO"
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(2).Value = False
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(2).ReadOnly = True
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(3).Value = False
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(3).ReadOnly = True
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(4).Value = False
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(4).ReadOnly = True
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(5).Value = False
        DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(5).ReadOnly = True

        For I = 1 To 10
            DGAccesos.Rows.Add()
            DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(0).Value = I
            DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(1).Value = "Descripcion detalla el acceso q tendria de acuerdo a las check q que lusuario coloque." & I
            'DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(2).Value = I
            'DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(3).Value = I
            'DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(4).Value = I
            'DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(5).Value = I
            DGAccesos.Rows(DGAccesos.Rows.Count - 1).Cells(6).Value = I

            'DGAccesos.Columns(0).Width = 20
            'DGAccesos.Columns(1).Width = 150
            'DGAccesos.Columns(2).Width = 50
            'DGAccesos.Columns(3).Width = 0
            'DGAccesos.Columns(3).Visible = False
            'DGAccesos.Rows(DGAccesos.Rows.Count - 1).Height = 40
        Next






        CmdPerfilUsuario.Items.Clear()
        CmdPerfilUsuario.Items.Add("Administrador de Tienda")
        CmdPerfilUsuario.Items.Add("Quimico Farmaceutico")
        CmdPerfilUsuario.Items.Add("Asistente Quimico Farmaceutico")
        CmdPerfilUsuario.Items.Add("Auxiliar Farmaceutico")
        CmdPerfilUsuario.Items.Add("Asistente Quimico Farmaceutico")
        CmdPerfilUsuario.Items.Add("Tecnico Farmaceutico")
        CmdPerfilUsuario.Items.Add("Tecnico Almacen")
        CmdPerfilUsuario.Items.Add("Usuario Invitado")
        CmdPerfilUsuario.Items.Add("Perzonalizado...")


        AccesoTienda(1, 1) = 0
        AccesoTienda(1, 1) = 1
        AccesoTienda(1, 1) = 3

        'CmbLu1.SelectedIndex = 0
        'CmbLu2.SelectedIndex = 0
        Inicializa_datos()
        ListaMisUsuarios()

    End Sub
    Private Sub llena_hasta(Cmbde As ComboBox, CmbHasta As ComboBox)
        Dim iInicio As Integer
        iInicio = Cmbde.SelectedIndex

        CmbHasta.Items.Clear()
        If iInicio = Cmbde.Items.Count - 1 Then
            CmbHasta.Items.Add("00:00")
        Else
            For i = iInicio + 1 To Cmbde.Items.Count - 1
                CmbHasta.Items.Add(Cmbde.Items(i).ToString)
            Next
            CmbHasta.Items.Add("23:59")
        End If
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles PanelTodo.Paint

    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        Dim hora As String

        Exit Sub


        hora = Now.ToString("HH:mm") 'formato 24 horas

        If Valida_Hora_Acceso(CmbLu1.Text, CmbLu2.Text, Now.ToString("HH:mm")) Then
            'TextBox1.Text = hora & " FULL ACCESO"
        Else
            ' TextBox1.Text = hora & "Sin acceso"
        End If

        '        horaI = Strings.Left(CmbLu1.Text, 2)
        '        horaF = Strings.Left(CmbLu2.Text, 2)
        '        minI = Strings.Right(CmbLu1.Text, 2)
        '        minF = Strings.Right(CmbLu2.Text, 2)


        '        hora_compara = Val(Strings.Left(Now.ToString("HH:mm"), 2))
        '        min_compara = Val(Strings.Right(Now.ToString("HH:mm"), 2))
        '        Dim wAcceso As String

        '        hora = Now.ToString("HH:mm") 'formato 24 horas
        '        TextBox1.Text = hora
        '        wAcceso = "  Sin Acceso"
        '        If hora_compara >= horaI And hora_compara <= horaF Then
        '            If hora_compara = horaI And hora_compara = horaF Then
        '                If min_compara >= minI And min_compara <= minF Then ' And min_compara <= minF
        '                    wAcceso = "  Acceso sistema"
        '                End If
        '                GoTo resul
        '            End If
        '            If hora_compara = horaI Then
        '                If min_compara >= minI Then ' And min_compara <= minF
        '                    wAcceso = "  Acceso sistema"
        '                End If
        '                GoTo resul
        '            End If
        '            If hora_compara = horaF Then
        '                If min_compara >= minF Then ' And min_compara <= minF
        '                    wAcceso = "  Acceso sistema"
        '                End If
        '                GoTo resul
        '            End If


        '        End If
        'resul:
        '        TextBox1.Text = hora & wAcceso

    End Sub

    Private Sub CmdAddLunes_Click(sender As Object, e As EventArgs) Handles CmdAddLunes.Click
        AddRango(CmbLu1, CmbLu2, DGLunes)

    End Sub
    Private Sub AddRango(ComboIni As ComboBox, ComboFin As ComboBox, GridDatos As DataGridView)
        Dim horaI As Integer
        Dim horaF As Integer
        Dim minI As Integer
        Dim minF As Integer

        horaI = Strings.Left(ComboIni.Text, 2)
        minI = Strings.Right(ComboIni.Text, 2)
        horaF = Strings.Left(ComboFin.Text, 2)
        minF = Strings.Right(ComboFin.Text, 2)

        If horaF < horaI Then
            MsgBox("error rango")
            Exit Sub
        End If
        If horaI = horaF Then
            If minF < minI Then
                MsgBox("error rango")
                Exit Sub
            End If
        End If

        FaltaDatos.SetError(GridDatos, "")
        For i = 0 To GridDatos.Rows.Count - 1
            If GridDatos.Rows(i).Cells(0).Value = ComboIni.Text And GridDatos.Rows(i).Cells(1).Value = ComboFin.Text Then
                FaltaDatos.SetError(GridDatos, "Ya Existe el Rango.")
                Exit Sub
            End If
        Next

        GridDatos.Rows.Add()
        GridDatos.Rows(GridDatos.Rows.Count - 1).Cells(0).Value = ComboIni.Text
        GridDatos.Rows(GridDatos.Rows.Count - 1).Cells(1).Value = ComboFin.Text
        GridDatos.Rows(GridDatos.Rows.Count - 1).Cells(2).Value = My.Resources.eliminar
        GridDatos.Rows(GridDatos.Rows.Count - 1).Cells(3).Value = GridDatos.Rows.Count - 1
        GridDatos.Columns(0).Width = 50
        GridDatos.Columns(1).Width = 50
        GridDatos.Columns(2).Width = 50
        GridDatos.Columns(3).Width = 0
        GridDatos.Columns(3).Visible = False
        GridDatos.Rows(GridDatos.Rows.Count - 1).Height = 25
    End Sub

    Private Sub ActivaDia(ComboInicio As ComboBox, ComboFin As ComboBox, griddatos As DataGridView, ActivaDEsActiva As Boolean, tipoAcceso As Integer, ComboAddDia As IconButton)

        If tipoAcceso = 2 Then
            griddatos.Rows.Clear()
            griddatos.Rows.Add()
            griddatos.Rows(griddatos.Rows.Count - 1).Cells(0).Value = "00:00"
            griddatos.Rows(griddatos.Rows.Count - 1).Cells(1).Value = "00:00"
            griddatos.Rows(griddatos.Rows.Count - 1).Cells(2).Value = My.Resources.ver
            griddatos.Rows(griddatos.Rows.Count - 1).Cells(3).Value = 0
            griddatos.Columns(0).Width = 50
            griddatos.Columns(1).Width = 50
            griddatos.Columns(2).Width = 50
            griddatos.Columns(3).Width = 0
            griddatos.Columns(3).Visible = False
            griddatos.Rows(griddatos.Rows.Count - 1).Height = 25
            griddatos.Enabled = False
            ComboInicio.SelectedIndex = 0
            ComboFin.SelectedIndex = 0
        End If
        If tipoAcceso = 1 Then
            griddatos.Rows.Clear()
            griddatos.Enabled = False
            ' ComboInicio.SelectedIndex = 0
            'ComboFin.SelectedIndex = 0
        End If
        If tipoAcceso = 3 Then
            griddatos.Rows.Clear()
            ComboInicio.SelectedIndex = 0
            ComboFin.SelectedIndex = 0
            griddatos.Enabled = True
        End If
        ComboInicio.Enabled = ActivaDEsActiva
        ComboFin.Enabled = ActivaDEsActiva
        ComboAddDia.Enabled = ActivaDEsActiva

    End Sub




    Private Sub DGLunes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGLunes.CellContentClick

    End Sub

    Private Sub DGLunes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGLunes.CellClick
        If e.ColumnIndex = 2 Then
            If e.RowIndex = DGLunes.RowCount - 1 Then
                DGLunes.Rows.Remove(DGLunes.CurrentRow)
                FaltaDatos.SetError(DGLunes, "")
            Else
                FaltaDatos.SetError(DGLunes, "Debe Quitar el Ultimo.")
            End If
        End If
    End Sub

    Private Sub CmbLu1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbLu1.SelectedIndexChanged
        llena_hasta(CmbLu1, CmbLu2)
    End Sub

    Private Sub OpTodoDia_CheckedChanged(sender As Object, e As EventArgs) Handles OpTodoDia.CheckedChanged
        If OpTodoDia.Checked Then
            PanelDias.Visible = False
            OpLunesSin.Checked = True
            OpMartesSin.Checked = True
            OpMiercolesSin.Checked = True
            OpJuevesSin.Checked = True
            OpViernesSin.Checked = True
            OpSabadoSin.Checked = True
            OpViernesSin.Checked = True
            OpDomingoSin.Checked = True
        Else
            PanelDias.Visible = True
        End If
    End Sub

    Private Sub OpPorSemana_CheckedChanged(sender As Object, e As EventArgs) Handles OpPorSemana.CheckedChanged
        If OpPorSemana.Checked Then
            PanelDias.Visible = True
        Else
            PanelDias.Visible = False
        End If
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CmdCancelarCrear_Click(sender As Object, e As EventArgs) Handles CmdCancelarCrear.Click

    End Sub

    Private Sub ChekDeshabilitar_CheckedChanged(sender As Object, e As EventArgs) Handles ChekDeshabilitar.CheckedChanged
        If ChekDeshabilitar.Checked Then
            ChekDeshabilitar.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorRojo)
        Else
            ChekDeshabilitar.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorAzul)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim foo_id As New List(Of String)
        Dim foo_nombre As New List(Of String)

        Dim myAL As New ArrayList()
        myAL.Add("the")
        myAL.Add("")
        myAL.Add("brown")
        myAL.Add(Format(Now, "yyyy-MM-dd hh:mm:ss"))
        myAL.Add("jumps")
        myAL.Add("over")
        myAL.Add("the")
        myAL.Add("lazy")
        myAL.Add("dog")
        myAL.Add("in")
        myAL.Add("the")
        myAL.Add("barn")

        ' request.AddParameter("id", weekDays)

        Dim parametro = New List(Of ParametroArray) From {
            New ParametroArray("id", myAL),
            New ParametroArray("nombre", myAL),
            New ParametroArray("celular", myAL)
                    }

        'Dim response = MuestraDataApi_Arreglos(lk_api_cadena_base + "prueba", parametro) ' respuesta : vps_Usaurios




        Dim api = New DBApi()
        Dim headers = New List(Of Parametro) From {
                New Parametro("Authorization", ""), New Parametro("Content-Type", "application/json")}
        Dim respuesta1 As New Object
        ' Dim objeto As Object

        lk_client.BaseUrl = New Uri(lk_api_cadena_base + "prueba")

        Dim request = New RestRequest()
        request.Method = Method.POST
        request.AddHeader("Content-Type", "application/json")


        Dim Str As String

        For Each parametro1 As ParametroArray In parametro

            Str = "'" & String.Join("','", parametro1.Array.ToArray()) & "'"
            request.AddParameter(parametro1.Clave, Str)
        Next

        If (parametro.Count = 0) Then
            request.AddJsonBody(request)
        End If

        Dim response = lk_client.Execute(request).Content.ToString


        ' Dim response = Post_Array(lk_api_cadena_base + "prueba", headers, parametro, respuesta1)



        Stop
        'lk_api_ModificaDatos = JsonConvert.DeserializeObject(Of JsonModificaDatos)(response) ' 
        'If lk_api_ModificaDatos.estado = False Then
        '    MsgBox("no")
        'Else
        '    MsgBox("si")

        'End If






        Stop
    End Sub
    Public Class ParametroArray
        Public Property Clave As String

        Public Property Array As ArrayList

        'Public Sub New(_clave As String, _array As String())
        '    Clave = _clave
        '    Array = _array
        'End Sub
        Public Sub New(_clave As String, _array As ArrayList)
            Clave = _clave
            Array = _array
        End Sub

    End Class
    Public Function MuestraDataApi_Arreglos(url As String, parametro As List(Of ParametroArray)) As String
        Dim repite As Integer



        repite = repite - 1
        Dim api = New DBApi()
        Dim headers = New List(Of Parametro) From {
            New Parametro("Authorization", ""), New Parametro("Cookie", "")}
        Dim respuesta1 As New Object
        Dim response = Post_Array(url, headers, parametro, respuesta1)
        ' MuestraDataApi_Arreglos = "*600" ' Data Vacio
        MuestraDataApi_Arreglos = response


    End Function
    Public Function Post_Array(url As String, headers As List(Of Parametro), parametros As List(Of ParametroArray), objeto As Object) As String
        'Por siacaso este codigo, sirve cuando la api tiene problemas con su certificado
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        lk_client.BaseUrl = New Uri(url)

        Dim request = New RestRequest()
        request.Method = Method.POST

        For Each parametro As ParametroArray In parametros
            request.AddParameter(parametro.Clave, parametro.Array)
        Next

        If (parametros.Count = 0) Then
            request.AddJsonBody(objeto)
        End If

        Dim response = lk_client.Execute(request).Content.ToString

        Return response
    End Function

    Private Sub DGNegocios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGNegocios.CellContentClick

    End Sub

    Private Sub DGNegocios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGNegocios.CellClick
        Dim ws_IdNegocio As Integer


        ws_IdNegocio = DGNegocios.Rows(e.RowIndex).Cells(2).Value

        Dim frCargainfo As New FrmCarga
        Me.Opacity = 0.9
        frCargainfo.LogoSolicdo.Visible = True
        frCargainfo.Show()
        Application.DoEvents()



        'llena_Lista_Locales(ws_IdNegocio)
        DGLocales.Rows.Clear()
        DGAlmacenes.Rows.Clear()
        ChekDeshabilitar.Checked = False
        PanelAccesos.Visible = False
        LblTituloLocal.Text = ""
        If lk_sql_Usuario_local.Rows.Count = 0 Then
            GoTo fin
        End If



        DGLocales.Rows.Clear()
        For I = 0 To lk_sql_Usuario_local.Rows.Count - 1
            If ws_IdNegocio <> lk_sql_Usuario_local.Rows(I).Item("id_negocio") Then Continue For
            DGLocales.Rows.Add()
            DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(0).Value = Trim(lk_sql_Usuario_local.Rows(I).Item("local_abreviado")) & vbCrLf & "CODIGO : " & Trim(lk_sql_Usuario_local.Rows(I).Item("local_codigo")) & vbCrLf & Trim(lk_sql_Usuario_local.Rows(I).Item("local_nombre"))
            If lk_sql_Usuario_local.Rows(I).Item("fotolocal_local") = "-" Then
                DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(1).Value = lk_sql_Usuario_local.Rows(I).Item("fotolocallocal_Defecto")
            Else
                DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(1).Value = Image.FromFile(lk_sql_Usuario_local.Rows(I).Item("fotolocal_local"))
            End If

            DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(2).Value = Trim(lk_sql_Usuario_local.Rows(I).Item("id_local"))
            DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(3).Value = I
            DGLocales.Columns(0).Width = 130
            DGLocales.Columns(1).Width = 130
            DGLocales.Columns(2).Width = 0
            DGLocales.Columns(2).Visible = False
            DGLocales.Rows(DGLocales.Rows.Count - 1).Height = 40

        Next

fin:
        frCargainfo.Close()
        Me.Opacity = 1
        'Me.Show()



    End Sub
    Dim WithEvents CLIENTE As New WebClient 'LO DECLARAMOS CON EVENTS PARA PODER UTILIZAR LOS PROCEDIMIENTOS PROGRESSCHANGED Y COMPLETED
    Private Sub llena_Lista_Locales(ws_idnegocio As String)

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


        Exit Sub
NoIngresa:
    End Sub

    Private Sub DGLocales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGLocales.CellContentClick
        Dim ws_IdLocal As Integer
        ws_IdLocal = DGLocales.Rows(e.RowIndex).Cells(2).Value


        Dim frCargainfo As New FrmCarga
        Me.Opacity = 0.9
        PanelAccesos.Visible = False
        frCargainfo.LogoSolicdo.Visible = True
        frCargainfo.Show()
        Application.DoEvents()



        'llena_lista_Almacenes(ws_IdLocal)

        DGAlmacenes.Rows.Clear()
        ChekDeshabilitar.Checked = False
        PanelAccesos.Visible = False
        If lk_sql_Usuario_almacen.Rows.Count = 0 Then
            GoTo fin
        End If


        Dim FOTODEFECTO = My.Resources.alma
        ' 1 paso ver q almacenes tien apra marcar







        For I = 0 To lk_sql_Usuario_almacen.Rows.Count - 1

            If lk_sql_Usuario_almacen.Rows(I).Item("estado") = 1 And lk_sql_Usuario_almacen.Rows(I).Item("id_local") = ws_IdLocal Then ' AQUI MIRA SI TIENE ACESO AL AALMCEN 
            Else
                Continue For
                'For J = 0 To lk_api_ListAlmacenAcceso.data.Count - 1
                '    If Trim(lk_api_ListaAlmacenes.data(I).id_almacen) = Trim(lk_api_ListAlmacenAcceso.data(J).id_almacen) And lk_api_ListAlmacenAcceso.data(J).estado = "1" Then
                '        DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(0).Value = True
                '        Exit For
                '    End If
                'Next
            End If
            DGAlmacenes.Rows.Add()

            DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(1).Value = Trim(lk_sql_Usuario_almacen.Rows(I).Item("alm_abreviado")) & vbCrLf & "CODIGO : " & Trim(lk_sql_Usuario_almacen.Rows(I).Item("alm_codigo")) & vbCrLf & Trim(lk_sql_Usuario_almacen.Rows(I).Item("alm_nombre"))
            If lk_sql_Usuario_almacen.Rows(I).Item("fotoalmacen_local") = "-" Then
                DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(2).Value = lk_sql_Usuario_almacen.Rows(I).Item("fotoalmacenlocal_Defecto")
            Else
                DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(2).Value = Image.FromFile(lk_sql_Usuario_almacen.Rows(I).Item("fotoalmacen_local"))
            End If

            DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(3).Value = Trim(lk_sql_Usuario_almacen.Rows(I).Item("id_almacen"))

            DGAlmacenes.Columns(0).Width = 30
            DGAlmacenes.Columns(1).Width = 130
            DGAlmacenes.Columns(2).Width = 130
            DGAlmacenes.Columns(3).Width = 0
            DGAlmacenes.Columns(3).Visible = False
            DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Height = 40








        Next
        ' Aqui pasar o llmar los acceso del usuario



        Dim ws_IdUsuario As Integer = Val(TxtUsuario.Tag)
        Dim ws_IdNegocio As String = DGNegocios.Rows(DGNegocios.CurrentRow.Index).Cells(2).Value
        Muestra_almacenes_accesos(ws_IdLocal, TxtUsuario.Tag)

        'jala api q negocio tiene acceso

        Dim idlocalAcceso_POSIndex As String = Muestra_AccesoLocal(ws_IdUsuario, ws_IdNegocio, ws_IdLocal)
        '        Dim windexneg As Integer
        Cheaccesolocal.Checked = False
        PanelAccesos.Visible = True
        PanelOpciones.Enabled = True
        IniciarHorario()

        If idlocalAcceso_POSIndex = "" Then ' nombre tiene  acceso y sale primer usuario nuevo 
            Dim wposi As Integer = DGLocales.Rows(e.RowIndex).Cells(3).Value
            'LblTituloLocal.Text = lk_api_ListaLocales.data(wposi).nombre
            'LblTituloLocal.Tag = lk_api_ListaLocales.data(wposi).id_local
            Cheaccesolocal.Text = "Dar Acceso al Local."
            Cheaccesolocal.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorAzul)
            GoTo fin

        End If
        Dim wIndexLocal As Integer = Val(idlocalAcceso_POSIndex)
        ' de aqui abajo es cuando tiene acceso al local 
        If lk_sql_ListalocalAcceso.Rows.Count = 0 Then
            Cheaccesolocal.Checked = False ' No  tiene acceso al local
        Else
            If lk_sql_ListalocalAcceso.Rows(0).Item("estado") = "1" Then
                Cheaccesolocal.Checked = True  ' tiene acceso al local
            Else
                Cheaccesolocal.Checked = False ' No  tiene acceso al local
            End If
            Muestra_horario_usuario(lk_sql_ListalocalAcceso.Rows(wIndexLocal).Item("id_acceso_loc"))
        End If



        frCargainfo.Close()
        Me.Opacity = 1
        Exit Sub
fin:
        frCargainfo.Close()
        Me.Opacity = 1
    End Sub

    Private Sub DGLocales_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGLocales.CellClick

    End Sub
    Private Sub Muestra_almacenes_accesos(ws_id_local As Integer, ws_id_usuario As String)


        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter

        Try
            command = New SqlCommand("acceso_listar_almacen", lk_connection_master)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@id", lk_id_cuemta_user)
            command.Parameters.AddWithValue("@idUsu", ws_id_usuario)
            command.Parameters.AddWithValue("@idLocal", ws_id_local)
            adapter = New SqlDataAdapter(command)
            lk_sql_ListAlmacenAcceso = New DataTable
            adapter.Fill(lk_sql_ListAlmacenAcceso)



            If lk_sql_ListAlmacenAcceso.Rows.Count <> 0 Then
                '    Muestra_AccesoNegocio = lk_sql_ListaNegocioAcceso.Rows(0).Item("id_negocio")

            End If
            For iacc = 0 To lk_sql_ListAlmacenAcceso.Rows.Count - 1
                For i = 0 To DGAlmacenes.Rows.Count - 1
                    If DGAlmacenes.Rows(i).Cells(3).Value = lk_sql_ListAlmacenAcceso.Rows(iacc).Item("id_almacen").ToString Then
                        DGAlmacenes.Rows(i).Cells(0).Value = 1
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox("ERRO RECARGAR ACCESO NEGOCIO ")
        End Try


    End Sub
    Private Sub Muestra_horario_usuario(ws_idAccesoLocal_horario As String)
        Exit Sub
        'http://207.180.246.8/backend-farmacia/public/api/access/listar/horario
        '{"id_horario":"7","id_acceso_loc":"1","diasemana":"7","tipo_acceso":"1","hora_de":"00:00","hora_hasta":"00:00"}]}
        '        {
        '            "idAccesoLocal": 1
        '            Muestra_AccesoLocal = ""
        '0= No tiene Acceso
        '            1 = Acceso Total 
        '            2 = Rango Horario

        Dim parametroneg = New List(Of Parametro) From {
            New Parametro("idAccesoLocal", ws_idAccesoLocal_horario)
            }
        Dim responseneg = MuestraDataApi(lk_api_cadena_base + "access/listar/horario", parametroneg) ' respuesta : vps_Usaurios
        ' Try
        lk_api_ListaHorarioLocal = JsonConvert.DeserializeObject(Of JsonListaHorarioLocal)(responseneg) 'Cái truyền tên Class vào
        If lk_api_ListaHorarioLocal.estado = True Then
            OpPorSemana.Checked = True
            DGLunes.Rows.Clear()
            For I = 0 To lk_api_ListaHorarioLocal.data.Count - 1
                If lk_api_ListaHorarioLocal.data(I).diasemana = "1" Then
                    If lk_api_ListaHorarioLocal.data(I).tipo_acceso = "0" Then
                        OpLunesSin.Checked = True
                    ElseIf lk_api_ListaHorarioLocal.data(I).tipo_acceso = "1" Then
                        OpLunesTodo.Checked = True
                    ElseIf lk_api_ListaHorarioLocal.data(I).tipo_acceso = "2" Then
                        OpLunesRango.Checked = True
                        Asignahorario(DGLunes, lk_api_ListaHorarioLocal.data(I).hora_de, lk_api_ListaHorarioLocal.data(I).hora_hasta)
                    End If
                End If
                If lk_api_ListaHorarioLocal.data(I).diasemana = "2" Then
                    If lk_api_ListaHorarioLocal.data(I).tipo_acceso = "0" Then
                        OpMartesSin.Checked = True
                    ElseIf lk_api_ListaHorarioLocal.data(I).tipo_acceso = "1" Then
                        OpMartesTodo.Checked = True
                    ElseIf lk_api_ListaHorarioLocal.data(I).tipo_acceso = "2" Then
                        OpMartesRango.Checked = True
                        Asignahorario(DGMartes, lk_api_ListaHorarioLocal.data(I).hora_de, lk_api_ListaHorarioLocal.data(I).hora_hasta)
                    End If
                End If
                If lk_api_ListaHorarioLocal.data(I).diasemana = "3" Then
                    If lk_api_ListaHorarioLocal.data(I).tipo_acceso = "0" Then
                        OpMiercolesSin.Checked = True
                    ElseIf lk_api_ListaHorarioLocal.data(I).tipo_acceso = "1" Then
                        OpMiercolesTodo.Checked = True
                    ElseIf lk_api_ListaHorarioLocal.data(I).tipo_acceso = "2" Then
                        OpMiercolesRango.Checked = True
                        Asignahorario(DGMiercoles, lk_api_ListaHorarioLocal.data(I).hora_de, lk_api_ListaHorarioLocal.data(I).hora_hasta)
                    End If
                End If
                If lk_api_ListaHorarioLocal.data(I).diasemana = "4" Then
                    If lk_api_ListaHorarioLocal.data(I).tipo_acceso = "0" Then
                        OpJuevesSin.Checked = True
                    ElseIf lk_api_ListaHorarioLocal.data(I).tipo_acceso = "1" Then
                        OpJuevesTodo.Checked = True
                    ElseIf lk_api_ListaHorarioLocal.data(I).tipo_acceso = "2" Then
                        OpJuevesRango.Checked = True
                        Asignahorario(DGJueves, lk_api_ListaHorarioLocal.data(I).hora_de, lk_api_ListaHorarioLocal.data(I).hora_hasta)
                    End If
                End If

                If lk_api_ListaHorarioLocal.data(I).diasemana = "5" Then
                    If lk_api_ListaHorarioLocal.data(I).tipo_acceso = "0" Then
                        OpViernesSin.Checked = True
                    ElseIf lk_api_ListaHorarioLocal.data(I).tipo_acceso = "1" Then
                        OpViernesTodo.Checked = True
                    ElseIf lk_api_ListaHorarioLocal.data(I).tipo_acceso = "2" Then
                        OpViernesRango.Checked = True
                        Asignahorario(DGViernes, lk_api_ListaHorarioLocal.data(I).hora_de, lk_api_ListaHorarioLocal.data(I).hora_hasta)
                    End If

                End If
                If lk_api_ListaHorarioLocal.data(I).diasemana = "6" Then
                    If lk_api_ListaHorarioLocal.data(I).tipo_acceso = "0" Then
                        OpSabadoSin.Checked = True
                    ElseIf lk_api_ListaHorarioLocal.data(I).tipo_acceso = "1" Then
                        OpSabadoTodo.Checked = True
                    ElseIf lk_api_ListaHorarioLocal.data(I).tipo_acceso = "2" Then
                        OpSabadoRango.Checked = True
                        Asignahorario(DGSabado, lk_api_ListaHorarioLocal.data(I).hora_de, lk_api_ListaHorarioLocal.data(I).hora_hasta)
                    End If

                End If
                If lk_api_ListaHorarioLocal.data(I).diasemana = "7" Then
                    If lk_api_ListaHorarioLocal.data(I).tipo_acceso = "0" Then
                        OpDomingoSin.Checked = True
                    ElseIf lk_api_ListaHorarioLocal.data(I).tipo_acceso = "1" Then
                        OpDomingoTodo.Checked = True
                    ElseIf lk_api_ListaHorarioLocal.data(I).tipo_acceso = "2" Then
                        OpDomingoRango.Checked = True
                        Asignahorario(DGDomingo, lk_api_ListaHorarioLocal.data(I).hora_de, lk_api_ListaHorarioLocal.data(I).hora_hasta)
                    End If

                End If

            Next
        End If
        'Catch ex As Exception
        '    MsgBox("ERRO RECARGAR local x Horario")
        '    Exit Sub
        'End Try

    End Sub
    Private Sub Asignahorario(gridsema As DataGridView, horade As String, horaghasta As String)
        gridsema.Rows.Add()
        gridsema.Rows(gridsema.Rows.Count - 1).Cells(0).Value = horade
        gridsema.Rows(gridsema.Rows.Count - 1).Cells(1).Value = horaghasta
        gridsema.Rows(gridsema.Rows.Count - 1).Cells(2).Value = My.Resources.eliminar
        gridsema.Rows(gridsema.Rows.Count - 1).Cells(3).Value = gridsema.Rows.Count - 1
        gridsema.Columns(0).Width = 50
        gridsema.Columns(1).Width = 50
        gridsema.Columns(2).Width = 50
        gridsema.Columns(3).Width = 0
        gridsema.Columns(3).Visible = False
        gridsema.Rows(gridsema.Rows.Count - 1).Height = 25

    End Sub
    Private Sub llena_lista_Almacenes(ws_idlocal As String)

        Dim result

        '  If lk_api_ListaNegocios Is Nothing Then
        Dim parametroneg = New List(Of Parametro) From {
             New Parametro("id_local", ws_idlocal)
             }

        Dim responseneg = MuestraDataApi(lk_api_cadena_base + "negocio/almacen/listar", parametroneg) ' respuesta : vps_Usaurios
        Try
            lk_api_ListaAlmacenes = JsonConvert.DeserializeObject(Of JsonListaAlmacenes)(responseneg) 'Cái truyền tên Class vào
            If lk_api_ListaAlmacenes.estado = True Then
                For I = 0 To lk_api_ListaAlmacenes.data.Count - 1
                    If lk_api_ListaAlmacenes.data(I).fotoalmacen = "-" Then
                        lk_api_ListaAlmacenes.data(I).fotoalmacen_local_Defecto = My.Resources.alma
                        lk_api_ListaAlmacenes.data(I).fotoalmacen_local = "-"
                    Else
                        Dim wRutaLocalfile As String = lk_Carpeta_Temp & System.IO.Path.GetFileName(lk_api_ListaAlmacenes.data(I).fotoalmacen)
                        If System.IO.File.Exists(wRutaLocalfile) Then

                        Else
                            CLIENTE.DownloadFile(New Uri(lk_api_ListaAlmacenes.data(I).fotoalmacen), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                        End If
                        'Dim wRutaLocalfile As String = My.Computer.FileSystem.CurrentDirectory & lk_api_ListaLocales.data(I).id_local & System.IO.Path.GetFileName(lk_api_ListaLocales.data(I).fotolocal)
                        'CLIENTE.DownloadFile(New Uri(lk_api_ListaLocales.data(I).fotolocal), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                        lk_api_ListaAlmacenes.data(I).fotoalmacen_local = wRutaLocalfile

                    End If
                Next

            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If lk_api_ListaAlmacenes.estado = False Then
            result = MensajesBox.Show("Todavia no a creado sus Almacenes para el Local." & Chr(13) & "Ingrese la Informacion de su Almacen. ",
                                           "Crear Almacen")
            GoTo NoIngresa
        End If


        Exit Sub
NoIngresa:

    End Sub

    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click
        Dim result As String
        If OpLunesRango.Checked And DGLunes.Rows.Count = 0 Then
            result = MensajesBox.Show("Debe Indicar las Horas para el Rango del dia Lunes.",
                                          "Accesos a Usuarios")
            GoTo NoGrabar
        End If
        If OpMartesRango.Checked And DGMartes.Rows.Count = 0 Then
            result = MensajesBox.Show("Debe Indicar las Horas para el Rango del dia Martes.",
                                          "Accesos a Usuarios")
            GoTo NoGrabar
        End If
        If OpMiercolesRango.Checked And DGMiercoles.Rows.Count = 0 Then
            result = MensajesBox.Show("Debe Indicar las Horas para el Rango del dia Miercoles.",
                                          "Accesos a Usuarios")
            GoTo NoGrabar
        End If
        If OpJuevesRango.Checked And DGJueves.Rows.Count = 0 Then
            result = MensajesBox.Show("Debe Indicar las Horas para el Rango del dia Jueves.",
                                          "Accesos a Usuarios")
            GoTo NoGrabar
        End If
        If OpViernesRango.Checked And DGViernes.Rows.Count = 0 Then
            result = MensajesBox.Show("Debe Indicar las Horas para el Rango del dia Viernes.",
                                          "Accesos a Usuarios")
            GoTo NoGrabar
        End If
        If OpSabadoRango.Checked And DGSabado.Rows.Count = 0 Then
            result = MensajesBox.Show("Debe Indicar las Horas para el Rango del dia Sabado.",
                                          "Accesos a Usuarios")
            GoTo NoGrabar
        End If
        If OpDomingoRango.Checked And DGDomingo.Rows.Count = 0 Then
            result = MensajesBox.Show("Debe Indicar las Horas para el Rango del dia Domingo.",
                                          "Accesos a Usuarios")
            GoTo NoGrabar
        End If

        Dim array_idAlmacen As New ArrayList()
        Dim array_fechaAlmacen As New ArrayList()
        Dim array_estadoAlmacen As New ArrayList()

        Dim array_dia As New ArrayList()
        Dim array_tipoAcesson As New ArrayList()
        Dim array_horade As New ArrayList()
        Dim array_horahasta As New ArrayList()



        Dim ws_idAlmacen As String
        Dim ws_fechaAlmacen As String
        Dim ws_estadoAlmacen As String

        For I = 0 To DGAlmacenes.Rows.Count - 1
            array_idAlmacen.Add(DGAlmacenes.Rows(I).Cells(3).Value)
            array_fechaAlmacen.Add(Format(Now, "yyyy-MM-dd hh:mm:ss"))
            If DGAlmacenes.Rows(I).Cells(0).Value Then
                array_estadoAlmacen.Add(1)
            Else
                array_estadoAlmacen.Add(0)
            End If
        Next
        'ws_idAlmacen = "'" & String.Join("','", array_idAlmacen.Array.ToArray()) & "'"
        ws_idAlmacen = "" & String.Join(",", array_idAlmacen.ToArray()) & ""
        ws_fechaAlmacen = "" & String.Join(",", array_fechaAlmacen.ToArray()) & ""
        ws_estadoAlmacen = "" & String.Join(",", array_estadoAlmacen.ToArray()) & ""

        Dim ws_dia As String
        Dim ws_tipoAcesson As String
        Dim ws_horade As String
        Dim ws_horahasta As String

        'Autor:
        '0= No tiene Acceso
        '            1 = Acceso Total 
        '            2 = Rango Horario
#Region "jala datos para almacenes dia de la semana con horario"
        If OpTodoDia.Checked Then
            For I = 0 To 6
                array_dia.Add(I + 1)
                array_tipoAcesson.Add(1)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            Next
        Else
            If OpLunesSin.Checked Then
                array_dia.Add(1)
                array_tipoAcesson.Add(0)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            ElseIf OpLunesTodo.Checked Then
                array_dia.Add(1)
                array_tipoAcesson.Add(1)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            ElseIf OpLunesRango.Checked Then
                For i = 0 To DGLunes.Rows.Count - 1
                    array_dia.Add(1)
                    array_tipoAcesson.Add(2)
                    array_horade.Add(DGLunes.Rows(i).Cells(0).Value)
                    array_horahasta.Add(DGLunes.Rows(i).Cells(1).Value)
                Next
            End If

            If OpMartesSin.Checked Then
                array_dia.Add(2)
                array_tipoAcesson.Add(0)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            ElseIf OpMartesTodo.Checked Then
                array_dia.Add(2)
                array_tipoAcesson.Add(1)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            ElseIf OpMartesRango.Checked Then
                For i = 0 To DGMartes.Rows.Count - 1
                    array_dia.Add(2)
                    array_tipoAcesson.Add(2)
                    array_horade.Add(DGMartes.Rows(i).Cells(0).Value)
                    array_horahasta.Add(DGMartes.Rows(i).Cells(1).Value)
                Next
            End If

            If OpMiercolesSin.Checked Then
                array_dia.Add(3)
                array_tipoAcesson.Add(0)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            ElseIf OpMiercolesTodo.Checked Then
                array_dia.Add(3)
                array_tipoAcesson.Add(1)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            ElseIf OpMiercolesRango.Checked Then
                For i = 0 To DGMiercoles.Rows.Count - 1
                    array_dia.Add(3)
                    array_tipoAcesson.Add(2)
                    array_horade.Add(DGMiercoles.Rows(i).Cells(0).Value)
                    array_horahasta.Add(DGMiercoles.Rows(i).Cells(1).Value)
                Next
            End If

            If OpJuevesSin.Checked Then
                array_dia.Add(4)
                array_tipoAcesson.Add(0)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            ElseIf OpJuevesTodo.Checked Then
                array_dia.Add(4)
                array_tipoAcesson.Add(1)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            ElseIf OpJuevesRango.Checked Then
                For i = 0 To DGJueves.Rows.Count - 1
                    array_dia.Add(4)
                    array_tipoAcesson.Add(2)
                    array_horade.Add(DGJueves.Rows(i).Cells(0).Value)
                    array_horahasta.Add(DGJueves.Rows(i).Cells(1).Value)
                Next
            End If

            If OpViernesSin.Checked Then
                array_dia.Add(5)
                array_tipoAcesson.Add(0)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            ElseIf OpViernesTodo.Checked Then
                array_dia.Add(5)
                array_tipoAcesson.Add(1)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            ElseIf OpViernesRango.Checked Then
                For i = 0 To DGViernes.Rows.Count - 1
                    array_dia.Add(5)
                    array_tipoAcesson.Add(2)
                    array_horade.Add(DGViernes.Rows(i).Cells(0).Value)
                    array_horahasta.Add(DGViernes.Rows(i).Cells(1).Value)
                Next
            End If

            If OpSabadoSin.Checked Then
                array_dia.Add(6)
                array_tipoAcesson.Add(0)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            ElseIf OpSabadoTodo.Checked Then
                array_dia.Add(6)
                array_tipoAcesson.Add(1)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            ElseIf OpSabadoRango.Checked Then
                For i = 0 To DGSabado.Rows.Count - 1
                    array_dia.Add(6)
                    array_tipoAcesson.Add(2)
                    array_horade.Add(DGSabado.Rows(i).Cells(0).Value)
                    array_horahasta.Add(DGSabado.Rows(i).Cells(1).Value)
                Next
            End If

            If OpDomingoSin.Checked Then
                array_dia.Add(7)
                array_tipoAcesson.Add(0)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            ElseIf OpDomingoTodo.Checked Then
                array_dia.Add(7)
                array_tipoAcesson.Add(1)
                array_horade.Add("00:00")
                array_horahasta.Add("00:00")
            ElseIf OpDomingoRango.Checked Then
                For i = 0 To DGDomingo.Rows.Count - 1
                    array_dia.Add(7)
                    array_tipoAcesson.Add(2)
                    array_horade.Add(DGDomingo.Rows(i).Cells(0).Value)
                    array_horahasta.Add(DGDomingo.Rows(i).Cells(1).Value)
                Next
            End If

        End If
#End Region





        ws_dia = "" & String.Join(",", array_dia.ToArray()) & ""
        ws_tipoAcesson = "" & String.Join(",", array_tipoAcesson.ToArray()) & ""
        ws_horade = "" & String.Join(",", array_horade.ToArray()) & ""
        ws_horahasta = "" & String.Join(",", array_horahasta.ToArray()) & ""


        Dim ws_idUsuario As String = TxtUsuario.Tag
        Dim ws_idCuentaUsuario As String = lk_id_cuemta_user

        Dim ws_idNegocio As String = DGNegocios.Rows(DGNegocios.CurrentRow.Index).Cells(2).Value
        Dim ws_fecha As String = Format(Now, "dd-MM-yyyy hh:mm:ss")
        Dim ws_estado As String = "1"

        Dim ws_idLocal As String = DGLocales.Rows(DGLocales.CurrentRow.Index).Cells(2).Value
        Dim ws_idtipoLocal As String = 1  ' Tipo de acceso
        Dim ws_fechaLocal As String = Format(Now, "dd-MM-yyyy hh:mm:ss")

        Dim ws_estadoLocal As String = 1

        If Cheaccesolocal.Checked Then
            ws_estadoLocal = 1
        Else
            ws_estadoLocal = 0
        End If


        Dim wdt_id_usuario As Integer = 0
        Dim wdt_id_acceso_alm As Integer = 0
        Dim wdt_id_almacen As Integer = 0
        Dim wdt_fec_acceso As DateTime = lk_fecha_dia
        Dim wdt_estado As Integer = 0
        Dim wdt_id_cuenta_user As Integer = 0

        Dim acc_almacenes As New DataTable()
        acc_almacenes.Columns.Add("id_usuario", GetType(Integer))
        acc_almacenes.Columns.Add("id_acceso_alm", GetType(Integer))
        acc_almacenes.Columns.Add("id_almacen", GetType(Integer))
        acc_almacenes.Columns.Add("fec_acceso", GetType(DateTime))
        acc_almacenes.Columns.Add("estado", GetType(Integer))
        acc_almacenes.Columns.Add("id_cuenta_user", GetType(Integer))

        For i = 0 To DGAlmacenes.Rows.Count - 1
            If DGAlmacenes.Rows(i).Cells(0).Value = 1 Or DGAlmacenes.Rows(i).Cells(0).Value = True Then
                wdt_id_usuario = ws_idUsuario
                wdt_id_acceso_alm = i
                wdt_id_almacen = Val(DGAlmacenes.Rows(i).Cells(3).Value)
                wdt_fec_acceso = Format(Now, "yyyy-MM-dd hh:mm:ss")
                wdt_estado = 1
                wdt_id_cuenta_user = ws_idCuentaUsuario
                acc_almacenes.Rows.Add(wdt_id_usuario, wdt_id_acceso_alm, wdt_id_almacen, wdt_fec_acceso, wdt_estado, wdt_id_cuenta_user)
            End If
        Next
        result = ""


        Using cmd As New SqlCommand("acceso_registrar_negocio", lk_connection_master)
            cmd.CommandType = CommandType.StoredProcedure
            ' Parámetros de entrada
            cmd.Parameters.AddWithValue("@idUser", ws_idUsuario)
            cmd.Parameters.AddWithValue("@idNegocio", ws_idNegocio)
            cmd.Parameters.AddWithValue("@fecha", ws_fecha)
            cmd.Parameters.AddWithValue("@estado", 1)
            cmd.Parameters.AddWithValue("@idCuentaUser", lk_id_cuemta_user)

            ' Parámetro de salida para el resultado de la eliminación
            Dim resultadoEliminarParam As New SqlParameter("@ResultadoEliminar", SqlDbType.Int)
            resultadoEliminarParam.Direction = ParameterDirection.Output
            cmd.Parameters.Add(resultadoEliminarParam)

            ' Ejecuta el procedimiento almacenado
            cmd.ExecuteNonQuery()

            ' Recupera el valor de la variable de salida
            Dim resultadoEliminar As Integer = Convert.ToInt32(resultadoEliminarParam.Value)

            ' Verifica el resultado de la eliminación
            If resultadoEliminar = 1 Then
                ' Eliminación exitosa


            Else
                ' Fallo en la eliminación
                result = MensajesBox.Show("no se pudo realizar la Operacion , intentar nuevamente.",
                                          "Accesos a Usuarios")
                result = "X"
            End If
        End Using
        If result = "X" Then
            Exit Sub
        End If


        Using cmd As New SqlCommand("acceso_registrar_local", lk_connection_master)
            cmd.CommandType = CommandType.StoredProcedure
            ' Parámetros de entrada
            cmd.Parameters.AddWithValue("@idNegocio", ws_idNegocio)
            cmd.Parameters.AddWithValue("@idUsuario", ws_idUsuario)
            cmd.Parameters.AddWithValue("@idLocal", ws_idLocal)
            cmd.Parameters.AddWithValue("@idTipoLocal", ws_idtipoLocal)
            cmd.Parameters.AddWithValue("@estado", ws_estadoLocal)
            cmd.Parameters.AddWithValue("@idCuentaUser", lk_id_cuemta_user)

            Dim detalleParam As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalAcceso_Alm", acc_almacenes)

            ' Parámetro de salida para el resultado de la eliminación
            Dim resultadoEliminarParam As New SqlParameter("@ResultadoEliminar", SqlDbType.Int)
            resultadoEliminarParam.Direction = ParameterDirection.Output
            cmd.Parameters.Add(resultadoEliminarParam)

            ' Ejecuta el procedimiento almacenado
            cmd.ExecuteNonQuery()

            ' Recupera el valor de la variable de salida
            Dim resultadoEliminar As Integer = Convert.ToInt32(resultadoEliminarParam.Value)

            ' Verifica el resultado de la eliminación
            If resultadoEliminar = 1 Then
                ' Eliminación exitosa
                result = MensajesBox.Show("Acceso Registrado con Exito.",
                                          "Accesos a Usuarios")

            Else
                ' Fallo en la eliminación
                result = MensajesBox.Show("no se pudo realizar la Operacion , intentar nuevamente.",
                                          "Accesos a Usuarios")
            End If
        End Using


        Inicia_User()
        Inicializa_datos()
        ListaMisUsuarios()




        'Dim parametro = New List(Of Parametro) From {
        '    New Parametro("idUsuario", ws_idUsuario),
        '    New Parametro("idCuentaUsuario", ws_idCuentaUsuario),
        '    New Parametro("idNegocio", ws_idNegocio),
        '    New Parametro("fecha", ws_fecha),
        '    New Parametro("estado", ws_estado),
        '    New Parametro("idLocal", ws_idLocal),
        '    New Parametro("idtipoLocal", ws_idtipoLocal),
        '    New Parametro("fechaLocal", ws_fechaLocal),
        '    New Parametro("estadoLocal", ws_estadoLocal),
        '    New Parametro("estadoLocal", ws_estadoLocal),
        '    New Parametro("idAlmacen", ws_idAlmacen),
        '    New Parametro("fechaAlmacen", ws_fechaAlmacen),
        '    New Parametro("estadoAlmacen", ws_estadoAlmacen),
        '    New Parametro("dia", ws_dia),
        '    New Parametro("tipoAcesso", ws_tipoAcesson),
        '    New Parametro("horade", ws_horade),
        '    New Parametro("horahasta", ws_horahasta)
        '}

        'Dim response = MuestraDataApi(lk_api_cadena_base + "access/registrar", parametro) ' respuesta : vps_Usaurios
        ''Stop
        'lk_api_ModificaDatos = JsonConvert.DeserializeObject(Of JsonModificaDatos)(response) ' 
        'If lk_api_ModificaDatos.estado = False Then
        '    result = MensajesBox.Show("Verificar!!!, Intente nuevamente Actuazliar Accesos.",
        '                                  "Verificar Informacion!!!!")

        'Else
        '    result = MensajesBox.Show("Acceso Actualizado para el usaurio.",
        '                                  "Accesos a Usuarios")
        '    '
        'End If



        Exit Sub
NoGrabar:

    End Sub

    Private Sub CmdMisUsuarios_Click(sender As Object, e As EventArgs) Handles CmdMisUsuarios.Click
        Inicializa_datos()
        ListaMisUsuarios()



    End Sub
    Private Sub Inicializa_datos()
        DGUsuarios.Rows.Clear()
        DGNegocios.Rows.Clear()
        DGLocales.Rows.Clear()
        DGAlmacenes.Rows.Clear()

        TxtUsuario.Tag = ""
        TxtUsuario.Text = ""
        TxtNombres.Text = ""
        TxtCelular.Text = ""
        FotoUsuario.Image = My.Resources.userd ' Image.FromFile(My.Resources.negocio)

        ChekDeshabilitar.Checked = False
        PanelAccesos.Visible = False
        PanelUser.Visible = False
        PanelOpciones.Enabled = False
        LblTituloLocal.Text = ""



    End Sub
    Private Sub DGUsuarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGUsuarios.CellContentClick

    End Sub

    Private Sub DGUsuarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGUsuarios.CellClick
        Dim ws_IdUsuario As Integer


        Dim frCargainfo As New FrmCarga
        PanelTodo.Visible = False
        Me.Opacity = 1

        frCargainfo.LogoSolicdo.Visible = True
        frCargainfo.Show()
        Application.DoEvents()
        If e.RowIndex < 0 Then Exit Sub

        ws_IdUsuario = DGUsuarios.Rows(e.RowIndex).Cells(2).Value

        Inicia_User()

        TxtUsuario.Tag = ws_IdUsuario
        TxtUsuario.Text = DGUsuarios.Rows(e.RowIndex).Cells(0).Value
        TxtNombres.Text = DGUsuarios.Rows(e.RowIndex).Cells(1).Value
        TxtCelular.Text = DGUsuarios.Rows(e.RowIndex).Cells(4).Value
        If DGUsuarios.Rows(e.RowIndex).Cells(3).Value = "-" Then
            FotoUsuario.Image = My.Resources.userd ' Image.FromFile(My.Resources.negocio)
        Else
            'FotoUsuario.Image = Image.FromFile(DGUsuarios.Rows(e.RowIndex).Cells(3).Value)
        End If
        PanelUser.Visible = True
        'jala api q negocio tiene acceso
        Dim idnegocioAcceso As String = Muestra_AccesoNegocio(ws_IdUsuario)
        Dim windexneg As Integer


        windexneg = -1
        DGNegocios.Rows.Clear()
        For I = 0 To lk_sql_Usuario_negocio.Rows.Count - 1
            If lk_sql_Usuario_negocio.Rows(I).Item("tipo") = "EXTERNO" Then Continue For
            DGNegocios.Rows.Add()
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(0).Value = Trim(lk_sql_Usuario_negocio.Rows(I).Item("neg_abreviado")) & vbCrLf & "RUC : " & Trim(lk_sql_Usuario_negocio.Rows(I).Item("neg_numerodoc")) & vbCrLf & Strings.Left(lk_sql_Usuario_negocio.Rows(I).Item("neg_nombre"), 20) & "..."

            If lk_sql_Usuario_negocio.Rows(I).Item("fotonegociolocal") = "-" Then
                DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(1).Value = My.Resources.negocio ' Image.FromFile(My.Resources.negocio)
            Else
                DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(1).Value = Image.FromFile(lk_sql_Usuario_negocio.Rows(I).Item("fotonegociolocal"))
            End If

            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(2).Value = Trim(lk_sql_Usuario_negocio.Rows(I).Item("id_negocio"))
            DGNegocios.Columns(0).Width = 160
            DGNegocios.Columns(1).Width = 150
            DGNegocios.Columns(2).Width = 0
            DGNegocios.Columns(2).Visible = False
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Height = 40
            If idnegocioAcceso = lk_sql_Usuario_negocio.Rows(I).Item("id_negocio") Then
                windexneg = I
            End If
        Next

        If windexneg = -1 Then
            DGNegocios.ClearSelection()
            ' no tiene acceso a nada es usuario nuevo desde 0
            GoTo Fin
        End If
        DGNegocios.Rows(windexneg).Selected = True
        DGNegocios.CurrentCell = DGNegocios.Rows(windexneg).Cells(0)



Fin:
        Me.Opacity = 1
        PanelTodo.Visible = True
        frCargainfo.Close()

    End Sub
    Private Sub Inicia_User()
        DGNegocios.Rows.Clear()
        DGLocales.Rows.Clear()
        DGAlmacenes.Rows.Clear()
        TxtUsuario.Tag = ""
        TxtUsuario.Text = ""
        TxtNombres.Text = ""
        TxtCelular.Text = ""
        FotoUsuario.Image = My.Resources.userd ' Image.FromFile(My.Resources.negocio)
        ChekDeshabilitar.Checked = False
        PanelAccesos.Visible = False
        PanelUser.Visible = False
        LblTituloLocal.Text = ""

    End Sub
    Private Function Muestra_AccesoNegocio(wid_usuario As Integer) As String

        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Muestra_AccesoNegocio = "0"

        command = New SqlCommand("acceso_lisatr_negocios", lk_connection_master)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@id_cuenta_user", lk_id_cuemta_user)
        command.Parameters.AddWithValue("@id_usuario", wid_usuario)
        adapter = New SqlDataAdapter(command)
        lk_sql_ListaNegocioAcceso = New DataTable
        adapter.Fill(lk_sql_ListaNegocioAcceso)



        Try

            If lk_sql_ListaNegocioAcceso.Rows.Count <> 0 Then
                Muestra_AccesoNegocio = lk_sql_ListaNegocioAcceso.Rows(0).Item("id_negocio")

            End If
        Catch ex As Exception
            MsgBox("ERRO RECARGAR ACCESO NEGOCIO ")
            Exit Function
        End Try


    End Function
    Private Function Muestra_AccesoLocal(wid_usuario As Integer, wid_negocio As Integer, wid_local As String) As String


        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Muestra_AccesoLocal = "0"

        Try
            command = New SqlCommand("acceso_listar_local", lk_connection_master)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@id", lk_id_cuemta_user)
            command.Parameters.AddWithValue("@idUsu", wid_usuario)
            command.Parameters.AddWithValue("@idNego", wid_negocio)
            command.Parameters.AddWithValue("@idlocal", wid_local)
            adapter = New SqlDataAdapter(command)
            lk_sql_ListalocalAcceso = New DataTable
            adapter.Fill(lk_sql_ListalocalAcceso)

            If lk_sql_ListalocalAcceso.Rows.Count <> 0 Then
                For I = 0 To lk_sql_ListalocalAcceso.Rows.Count - 1
                    If lk_sql_ListalocalAcceso.Rows(I).Item("id_local") = wid_local Then
                        Muestra_AccesoLocal = I
                    End If
                Next I
                '    Muestra_AccesoNegocio = lk_sql_ListaNegocioAcceso.Rows(0).Item("id_negocio")

            End If
        Catch ex As Exception
            MsgBox("ERRO RECARGAR ACCESO NEGOCIO ")
        End Try






    End Function
    Private Sub TxtCelular_TextChanged(sender As Object, e As EventArgs) Handles TxtCelular.TextChanged

    End Sub

    Private Sub TxtUsuario_TextChanged(sender As Object, e As EventArgs) Handles TxtUsuario.TextChanged

    End Sub

    Private Sub TxtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUsuario.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtCelular_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCelular.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtNombres_TextChanged(sender As Object, e As EventArgs) Handles TxtNombres.TextChanged

    End Sub

    Private Sub TxtNombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNombres.KeyPress
        e.Handled = True
    End Sub

    Private Sub Cheaccesolocal_CheckedChanged(sender As Object, e As EventArgs) Handles Cheaccesolocal.CheckedChanged
        If Cheaccesolocal.Checked Then
            Cheaccesolocal.Text = "Quitar el acceso al Negocio del Local"
            Cheaccesolocal.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorRojo)
            PanelAccesoTienda.Visible = True
        Else
            Cheaccesolocal.Text = "Dar Acceso al Local."
            Cheaccesolocal.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorAzul)
            PanelAccesoTienda.Visible = False
        End If

    End Sub
    Private Sub IniciarHorario()

        OpLunesSin.Checked = True
        Dim wva As Double
        CmbLu1.Items.Clear()
        wva = 0
        For i = 1 To 24
            CmbLu1.Items.Add(Format(wva, "00") & ":00")
            CmbLu1.Items.Add(Format(wva, "00") & ":15")
            CmbLu1.Items.Add(Format(wva, "00") & ":30")
            CmbLu1.Items.Add(Format(wva, "00") & ":45")
            wva = wva + 1
        Next
        CmbMar1.Items.Clear()
        wva = 0
        For i = 1 To 24
            CmbMar1.Items.Add(Format(wva, "00") & ":00")
            CmbMar1.Items.Add(Format(wva, "00") & ":15")
            CmbMar1.Items.Add(Format(wva, "00") & ":30")
            CmbMar1.Items.Add(Format(wva, "00") & ":45")
            wva = wva + 1
        Next
        CmbMie1.Items.Clear()
        wva = 0
        For i = 1 To 24
            CmbMie1.Items.Add(Format(wva, "00") & ":00")
            CmbMie1.Items.Add(Format(wva, "00") & ":15")
            CmbMie1.Items.Add(Format(wva, "00") & ":30")
            CmbMie1.Items.Add(Format(wva, "00") & ":45")
            wva = wva + 1
        Next
        CmbJue1.Items.Clear()
        wva = 0
        For i = 1 To 24
            CmbJue1.Items.Add(Format(wva, "00") & ":00")
            CmbJue1.Items.Add(Format(wva, "00") & ":15")
            CmbJue1.Items.Add(Format(wva, "00") & ":30")
            CmbJue1.Items.Add(Format(wva, "00") & ":45")
            wva = wva + 1
        Next
        CmbVie1.Items.Clear()
        wva = 0
        For i = 1 To 24
            CmbVie1.Items.Add(Format(wva, "00") & ":00")
            CmbVie1.Items.Add(Format(wva, "00") & ":15")
            CmbVie1.Items.Add(Format(wva, "00") & ":30")
            CmbVie1.Items.Add(Format(wva, "00") & ":45")
            wva = wva + 1
        Next
        CmbSab1.Items.Clear()
        wva = 0
        For i = 1 To 24
            CmbSab1.Items.Add(Format(wva, "00") & ":00")
            CmbSab1.Items.Add(Format(wva, "00") & ":15")
            CmbSab1.Items.Add(Format(wva, "00") & ":30")
            CmbSab1.Items.Add(Format(wva, "00") & ":45")
            wva = wva + 1
        Next
        CmbDom1.Items.Clear()
        wva = 0
        For i = 1 To 24
            CmbDom1.Items.Add(Format(wva, "00") & ":00")
            CmbDom1.Items.Add(Format(wva, "00") & ":15")
            CmbDom1.Items.Add(Format(wva, "00") & ":30")
            CmbDom1.Items.Add(Format(wva, "00") & ":45")
            wva = wva + 1
        Next

        DGLunes.Rows.Clear()
        DGMartes.Rows.Clear()
        DGMiercoles.Rows.Clear()
        DGJueves.Rows.Clear()
        DGViernes.Rows.Clear()
        DGSabado.Rows.Clear()
        DGDomingo.Rows.Clear()


    End Sub
#Region "Eventos de cada dia de la semanas "

    Private Sub OpLunesSin_CheckedChanged(sender As Object, e As EventArgs) Handles OpLunesSin.CheckedChanged
        If OpLunesSin.Checked Then
            ActivaDia(CmbLu1, CmbLu2, DGLunes, False, 1, CmdAddLunes)
        End If
    End Sub
    Private Sub OpLunesTodo_CheckedChanged(sender As Object, e As EventArgs) Handles OpLunesTodo.CheckedChanged
        If OpLunesTodo.Checked And OpLunesTodo.Visible Then
            ActivaDia(CmbLu1, CmbLu2, DGLunes, False, 2, CmdAddLunes)
        End If
    End Sub
    Private Sub OpLunesRango_CheckedChanged(sender As Object, e As EventArgs) Handles OpLunesRango.CheckedChanged
        If OpLunesRango.Checked Then

            ActivaDia(CmbLu1, CmbLu2, DGLunes, True, 3, CmdAddLunes)
        End If
    End Sub

    Private Sub OpMartesSin_CheckedChanged(sender As Object, e As EventArgs) Handles OpMartesSin.CheckedChanged
        If OpMartesSin.Checked Then
            ActivaDia(CmbMar1, CmbMar2, DGMartes, False, 1, CmdAddMartes)
        End If
    End Sub

    Private Sub OpMartesTodo_CheckedChanged(sender As Object, e As EventArgs) Handles OpMartesTodo.CheckedChanged
        If OpMartesTodo.Checked And OpMartesTodo.Visible Then
            ActivaDia(CmbMar1, CmbMar2, DGMartes, False, 2, CmdAddMartes)
        End If
    End Sub

    Private Sub OpMartesRango_CheckedChanged(sender As Object, e As EventArgs) Handles OpMartesRango.CheckedChanged
        If OpMartesRango.Checked Then
            ActivaDia(CmbMar1, CmbMar2, DGMartes, True, 3, CmdAddMartes)
        End If
    End Sub

    Private Sub OpMiercolesSin_CheckedChanged(sender As Object, e As EventArgs) Handles OpMiercolesSin.CheckedChanged
        If OpMiercolesSin.Checked Then
            ActivaDia(CmbMie1, CmbMie2, DGMiercoles, False, 1, CmdAddMiercoles)
        End If
    End Sub

    Private Sub OpMiercolesTodo_CheckedChanged(sender As Object, e As EventArgs) Handles OpMiercolesTodo.CheckedChanged
        If OpMiercolesTodo.Checked And OpMiercolesTodo.Visible Then
            ActivaDia(CmbMie1, CmbMie2, DGMiercoles, False, 2, CmdAddMiercoles)
        End If
    End Sub

    Private Sub OpMiercolesRango_CheckedChanged(sender As Object, e As EventArgs) Handles OpMiercolesRango.CheckedChanged
        If OpMiercolesRango.Checked Then
            ActivaDia(CmbMie1, CmbMie2, DGMiercoles, True, 3, CmdAddMiercoles)
        End If
    End Sub

    Private Sub OpJuevesSin_CheckedChanged(sender As Object, e As EventArgs) Handles OpJuevesSin.CheckedChanged
        If OpJuevesSin.Checked Then
            ActivaDia(CmbJue1, CmbJue2, DGJueves, False, 1, CmdAddJueves)
        End If
    End Sub

    Private Sub OpJuevesTodo_CheckedChanged(sender As Object, e As EventArgs) Handles OpJuevesTodo.CheckedChanged
        If OpJuevesTodo.Checked And OpJuevesTodo.Visible Then
            ActivaDia(CmbJue1, CmbJue2, DGJueves, False, 2, CmdAddJueves)
        End If
    End Sub

    Private Sub OpJuevesRango_CheckedChanged(sender As Object, e As EventArgs) Handles OpJuevesRango.CheckedChanged
        If OpJuevesRango.Checked Then
            ActivaDia(CmbJue1, CmbJue2, DGJueves, True, 3, CmdAddJueves)
        End If
    End Sub

    Private Sub OpViernesSin_CheckedChanged(sender As Object, e As EventArgs) Handles OpViernesSin.CheckedChanged
        If OpViernesSin.Checked Then
            ActivaDia(CmbVie1, CmbVie2, DGViernes, False, 1, CmdAddViernes)
        End If
    End Sub

    Private Sub OpViernesTodo_CheckedChanged(sender As Object, e As EventArgs) Handles OpViernesTodo.CheckedChanged
        If OpViernesTodo.Checked And OpViernesTodo.Visible Then
            ActivaDia(CmbVie1, CmbVie2, DGViernes, False, 2, CmdAddViernes)
        End If
    End Sub

    Private Sub OpViernesRango_CheckedChanged(sender As Object, e As EventArgs) Handles OpViernesRango.CheckedChanged
        If OpViernesRango.Checked Then
            ActivaDia(CmbVie1, CmbVie2, DGViernes, True, 3, CmdAddViernes)
        End If
    End Sub

    Private Sub OpSabadoSin_CheckedChanged(sender As Object, e As EventArgs) Handles OpSabadoSin.CheckedChanged
        If OpSabadoSin.Checked Then
            ActivaDia(CmbSab1, CmbSab2, DGSabado, False, 1, CmdAddSabado)
        End If
    End Sub

    Private Sub OpSabadoTodo_CheckedChanged(sender As Object, e As EventArgs) Handles OpSabadoTodo.CheckedChanged
        If OpSabadoTodo.Checked And OpSabadoTodo.Visible Then
            ActivaDia(CmbSab1, CmbSab2, DGSabado, False, 2, CmdAddSabado)
        End If
    End Sub

    Private Sub OpSabadoRango_CheckedChanged(sender As Object, e As EventArgs) Handles OpSabadoRango.CheckedChanged
        If OpSabadoRango.Checked Then
            ActivaDia(CmbSab1, CmbSab2, DGSabado, True, 3, CmdAddSabado)
        End If
    End Sub

    Private Sub OpDomingoSin_CheckedChanged(sender As Object, e As EventArgs) Handles OpDomingoSin.CheckedChanged
        If OpDomingoSin.Checked Then
            ActivaDia(CmbDom1, CmbDom2, DGDomingo, False, 1, CmdAddDomingo)
        End If
    End Sub

    Private Sub OpDomingoTodo_CheckedChanged(sender As Object, e As EventArgs) Handles OpDomingoTodo.CheckedChanged
        If OpDomingoTodo.Checked And OpDomingoTodo.Visible Then
            ActivaDia(CmbDom1, CmbDom2, DGDomingo, False, 2, CmdAddDomingo)
        End If
    End Sub

    Private Sub OpDomingoRango_CheckedChanged(sender As Object, e As EventArgs) Handles OpDomingoRango.CheckedChanged
        If OpDomingoRango.Checked Then
            ActivaDia(CmbDom1, CmbDom2, DGDomingo, True, 3, CmdAddDomingo)
        End If
    End Sub


    Private Sub CmbMar1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbMar1.SelectedIndexChanged
        llena_hasta(CmbMar1, CmbMar2)
    End Sub

    Private Sub CmbMie1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbMie1.SelectedIndexChanged
        llena_hasta(CmbMie1, CmbMie2)
    End Sub

    Private Sub CmbJue1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbJue1.SelectedIndexChanged
        llena_hasta(CmbJue1, CmbJue2)
    End Sub

    Private Sub CmbVie1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbVie1.SelectedIndexChanged
        llena_hasta(CmbVie1, CmbVie2)
    End Sub

    Private Sub CmbSab1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSab1.SelectedIndexChanged
        llena_hasta(CmbSab1, CmbSab2)
    End Sub

    Private Sub CmbDom1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDom1.SelectedIndexChanged
        llena_hasta(CmbDom1, CmbDom2)
    End Sub

    Private Sub CmdAddMartes_Click(sender As Object, e As EventArgs) Handles CmdAddMartes.Click
        AddRango(CmbMar1, CmbMar2, DGMartes)
    End Sub

    Private Sub CmdAddMiercoles_Click(sender As Object, e As EventArgs) Handles CmdAddMiercoles.Click
        AddRango(CmbMie1, CmbMie2, DGMiercoles)
    End Sub

    Private Sub CmdAddJueves_Click(sender As Object, e As EventArgs) Handles CmdAddJueves.Click
        AddRango(CmbJue1, CmbJue2, DGJueves)
    End Sub

    Private Sub CmdAddViernes_Click(sender As Object, e As EventArgs) Handles CmdAddViernes.Click
        AddRango(CmbVie1, CmbVie2, DGViernes)
    End Sub

    Private Sub CmdAddSabado_Click(sender As Object, e As EventArgs) Handles CmdAddSabado.Click
        AddRango(CmbSab1, CmbSab2, DGSabado)
    End Sub

    Private Sub CmdAddDomingo_Click(sender As Object, e As EventArgs) Handles CmdAddDomingo.Click
        AddRango(CmbDom1, CmbDom2, DGDomingo)
    End Sub

    Private Sub DGAlmacenes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGAlmacenes.CellContentClick

    End Sub

    Private Sub CmdQuitarUser_Click(sender As Object, e As EventArgs) Handles CmdQuitarUser.Click
        ' Establece la conexión a tu base de datos
        Dim Result As String
        Result = MensajesBox.Show("Desea Quitar al Usuario de forma permanente de su cuenta de Negocio..?", "Acceso a  Negocio", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        'MessageBoxButtons.YesNoCancel,
        '                       MessageBoxIcon.Warning,
        '                       MessageBoxDefaultButton.Button1)

        If Result = "7" Or Result = "2" Then ' es NO
            Exit Sub
        End If


        Dim ws_idUsuario As String = TxtUsuario.Tag
        Dim ws_idCuentaUsuario As String = lk_id_cuemta_user



        ' Crea un comando para el procedimiento almacenado
        Using cmd As New SqlCommand("sp_quitar_usuario", lk_connection_master)
            cmd.CommandType = CommandType.StoredProcedure

            ' Parámetros de entrada
            cmd.Parameters.AddWithValue("@id_cuenta_user", ws_idCuentaUsuario)
            cmd.Parameters.AddWithValue("@id_usuario", ws_idUsuario)

            ' Parámetro de salida para el resultado de la eliminación
            Dim resultadoEliminarParam As New SqlParameter("@ResultadoEliminar", SqlDbType.Int)
            resultadoEliminarParam.Direction = ParameterDirection.Output
            cmd.Parameters.Add(resultadoEliminarParam)

            ' Ejecuta el procedimiento almacenado
            cmd.ExecuteNonQuery()

            ' Recupera el valor de la variable de salida
            Dim resultadoEliminar As Integer = Convert.ToInt32(resultadoEliminarParam.Value)

            ' Verifica el resultado de la eliminación
            If resultadoEliminar = 1 Then
                ' Eliminación exitosa
                Result = MensajesBox.Show("Usuario Quitado con Exito.",
                                          "Accesos a Usuarios")

            Else
                ' Fallo en la eliminación
                Result = MensajesBox.Show("no se pudo realizar la Operacion , intentar nuevamente.",
                                          "Accesos a Usuarios")
            End If
        End Using
        Inicia_User()
        Inicializa_datos()
        ListaMisUsuarios()
    End Sub


#End Region
End Class