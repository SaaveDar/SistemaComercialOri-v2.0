Imports GMap.NET
Imports System.Windows.Forms.VisualStyles
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports Newtonsoft.Json
Imports System.ComponentModel
Imports System.Net
Imports System.Runtime.InteropServices
Imports WindowsApp1.ListaTipoDocPersona
Imports WindowsApp1.ModificaDatos
Imports WindowsApp1.Negocio.AgregaNegocio
Imports WindowsApp1.Negocio.ListaNegocio
Imports WindowsApp1.Locales.ListaLocales
Imports WindowsApp1.Negocio.AgregaLocal
Imports WindowsApp1.Negocio.AgregarAlmacen
Imports WindowsApp1.Almacenes.ListaAlmacenes
Imports System.Data.SqlClient

Public Class FrmCreaNegocio
    Dim punto_lat, punto_lon As String
    Dim markerOverlay
    Dim marker
    Dim wVarListaPais() As String
    Dim file As New OpenFileDialog()
    Dim westadoFotoSubir As String
    Dim wsfor_numerodigitos As Integer
    Dim Flag_ModifoMapa As Integer = 0
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

    Private Sub CmdCrearNegocio_Click(sender As Object, e As EventArgs) Handles CmdCrearNegocio.Click
        PanelCentral.Visible = False
        PanelCentral.Dock = DockStyle.None
        PanelCreaNegocio.Visible = True
        PanelCreaNegocio.Top = 50
        PanelCreaNegocio.Left = 310
        westadoFotoSubir = "0"
        wsfor_numerodigitos = lk_sql_ListaTipoDocPersona.Rows(CmbTipoDoc.SelectedIndex).Item("digitos").ToString
        LimpiaNegocio()
        'PanelNegocios.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        'DGLocales.BackgroundColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        ' DGAlmacenes.BackgroundColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        ' DGNegocios.BackgroundColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)

        CmdAddNegocio.Text = "&Crear"
        PanelNegocios.Enabled = False
        FotoNegocio.Image = My.Resources.negocio
        file.FileName = "-"
        CheckAutorizaEtiqueta.Visible = True
        CheckAutoriza.Visible = True

    End Sub

    Private Sub CmdCancelar_Click(sender As Object, e As EventArgs) Handles CmdCancelar.Click

        If DGNegocios.Rows.Count = 0 Then
            Me.Close()
            Exit Sub
        End If

        LimpiaNegocio()
        PanelAlmacen.Visible = False
        PanelLocales.Visible = False
        PanelCreaNegocio.Visible = False
        PanelAlmacen.Visible = False
        PanelCentral.Dock = DockStyle.Fill
        PanelCentral.Visible = True
        PanelNegocios.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorVerde)
        PanelNegocios.Enabled = True


    End Sub

    Private Sub CmdAddNegocio_Click(sender As Object, e As EventArgs) Handles CmdAddNegocio.Click
        If Strings.Left(CmdAddNegocio.Text, 2) = "&C" Then
            CreaNegocioNuevo()
        ElseIf Strings.Left(CmdAddNegocio.Text, 2) = "&A" Then
            ModificaNegocio()
        End If

    End Sub
    Private Sub LimpiaNegocio()
        TxtNroRegistro.Text = ""
        txtNombreNeg.Text = ""
        TxtNombreComercial.Text = ""
        TxtDirecNego.Text = ""
        TxtRefNego.Text = ""
        CmbubigeoN1Neg.SelectedIndex = -1
        'CmbTipoDoc.SelectedIndex = -1
        CmbubigeoN2Neg.Items.Clear()
        CmbubigeoN3Neg.Items.Clear()
        CheckAutoriza.Checked = False
        FotoNegocio.Image = My.Resources.negocio
        FaltaDatos.Clear()
        CheckAutorizaEtiqueta.Visible = False
        CheckAutoriza.Visible = False

    End Sub
    Private Sub LimpiaLocales()
        TxtNombreComercialLocal.Text = ""

        TxtAbreviadoLocal.Text = ""
        txtkey_local.Enabled = True
        txtkey_local.Text = ""
        TxtCodigoLocal.Text = ""
        TxtDireccionLocal.Text = ""
        TxtTelefonosLocal.Text = ""
        TxtCorreoLocal.Text = ""
        TxtRefLocal.Text = ""

        CmbTipoLocal.SelectedIndex = -1

        PuntoInicialMAPA()
        CmbubigeoN1Local.SelectedIndex = -1
        CmbubigeoN2Local.Items.Clear()
        CmbubigeoN3Local.Items.Clear()

        CheckAutoriza.Checked = False
        FotoNegocio.Image = My.Resources.local
        FaltaDatos.Clear()

        FotoLocal.Image = My.Resources.local
        file.FileName = "-"
        westadoFotoSubir = "0"

    End Sub

    Private Sub ModificaNegocio()
        Dim result
        Dim wConfirmasubida As String
        If ValidaAntesdeGrabar() = False Then
            Exit Sub
        End If

        FotoNegocio.Tag = "-"
        If westadoFotoSubir = "2" Then ' Solo Subir si cambia la foto
            'Dim nombre As String = System.IO.Path.GetFileName(file.FileName)
            'Dim extension As String = System.IO.Path.GetExtension(file.FileName)

            Dim nombre As String  ' = System.IO.Path.GetFileName(file.FileName)
            Dim extension As String = System.IO.Path.GetExtension(file.FileName)
            nombre = "loc" & lk_id_usuario & Format(Now, "hhmmss") & Id_NegocioLocal.Text & extension

            Application.DoEvents()
            wConfirmasubida = SubirImagen(file.FileName, lk_RutaSubir & nombre, lk_RutaSubir_User, lk_RutaSubir_clave)
            If Mid(wConfirmasubida, 1, 1) = "*" Then
                result = MensajesBox.Show("Sin acceso a guadar Imagenes, codigo error " & wConfirmasubida, lk_cabeza_msgbox)
                GoTo NO_Actualiza
            End If
            ''   'My.Computer.Network.UploadFile(file.FileName, RutaSubir & nombre, RutaSubir_User, RutaSubir_clave)
            My.Computer.FileSystem.CopyFile(
                   file.FileName,
                    lk_Carpeta_Temp & nombre,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            FotoNegocio.Tag = lk_RutaBD & nombre

        End If
        If ActualizaNegocio() = False Then
            result = MensajesBox.Show("No se pude Actualizar Negocio, Intentar nuevamente ",
                                      "Envio de SMS")
            Exit Sub
        End If





        Negocio_Local_Almacen_Usuario()
        'RECARGARNEGOCIOS()
        MUESTRANEGOCIOS()
        'ActualizaNegocioporDefcto()

        PanelCreaNegocio.Visible = False
        PanelCentral.Visible = True
        PanelCentral.Dock = DockStyle.Fill



        result = MensajesBox.Show("Datos Actualizados.", lk_cabeza_msgbox)

        Exit Sub
NO_Actualiza:
    End Sub

    Private Sub CreaNegocioNuevo()
        Dim result
        Dim wConfirmasubida As String

        If ValidaAntesdeGrabar() = False Then
            'result = MensajesBox.Show("No se pudo Crear el Negocio, Intentar nuevamente ",
            '                          "Envio de SMS")
            Exit Sub
        End If
        If CheckAutoriza.Checked = False Then
            FaltaDatos.SetError(CheckAutorizaEtiqueta, "Debe Aceptar con el Check de Terminos y condiciones.")
            Exit Sub
        End If
        FotoNegocio.Tag = "-"
        If westadoFotoSubir = "2" Then ' Solo Subir si cambia la foto
            Dim nombre As String '  = System.IO.Path.GetFileName(file.FileName)
            ' Dim extension As String = System.IO.Path.GetExtension(file.FileName)

            Application.DoEvents()

            'Dim nombre As String = "" ' System.IO.Path.GetFileName(file.FileName)
            Dim extension As String = System.IO.Path.GetExtension(file.FileName)

            nombre = "neg" & lk_id_usuario & Format(Now, "hhmmss") & lk_id_usuario & extension


            wConfirmasubida = SubirImagen(file.FileName, lk_RutaSubir & nombre, lk_RutaSubir_User, lk_RutaSubir_clave)
            If Mid(wConfirmasubida, 1, 1) = "*" Then
                result = MensajesBox.Show("Sin acceso a guadar Imagenes, codigo error " & wConfirmasubida, lk_cabeza_msgbox)
                GoTo NO_Actualiza
            End If
            My.Computer.FileSystem.CopyFile(
                   file.FileName,
                    lk_Carpeta_Temp & nombre,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)

            FotoNegocio.Tag = lk_RutaBD & nombre

        End If

        If AddNegocio() = False Then
            result = MensajesBox.Show("No se pudo Crear el Negocio, Intentar nuevamente ",
                                      "Envio de SMS")
            Exit Sub
        End If

        LimpiaNegocio()

        'RECARGARNEGOCIOS()
        Negocio_Local_Almacen_Usuario()
        MUESTRANEGOCIOS()

        PanelCreaNegocio.Visible = False
        PanelCentral.Visible = True
        PanelCentral.Dock = DockStyle.Fill

        ' ActualizaNegocioporDefcto()





        CmdCancelar_Click(Nothing, Nothing)



        Exit Sub
NO_Actualiza:
        MsgBox("ERROR")

    End Sub
    Private Sub ActualizaNegocioporDefcto()

        lk_NegocioActivo.id_Negocio = ""
        If lk_sql_Usuario_negocio.Rows.Count > 0 Then
            For I = 0 To lk_sql_Usuario_negocio.Rows.Count - 1
                lk_NegocioActivo.id_Negocio = lk_sql_Usuario_negocio.Rows(I).Item("id_negocio").ToString
                lk_NegocioActivo.nombre = lk_sql_Usuario_negocio.Rows(I).Item("nombre").ToString
                lk_NegocioActivo.tipodoc = lk_sql_Usuario_negocio.Rows(I).Item("des_tipdoc").ToString

                'lk_NegocioActivo.id_Negocio = lk_api_ListaNegocios.data(I).id_tipdoc
                lk_NegocioActivo.numdoc = lk_sql_Usuario_negocio.Rows(I).Item("numeroreg").ToString
                lk_NegocioActivo.fotonegocio = lk_sql_Usuario_negocio.Rows(I).Item("fotonegociolocal").ToString
                lk_id_cuemta_user = lk_sql_Usuario_negocio.Rows(I).Item("fotonegociolocal").ToString
                Exit For
            Next
        End If
        If lk_NegocioActivo.fotonegocio = "" Then ' NO TIENE NEGOCIO ASIGNADO
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
    End Sub
    Private Function ValidaAntesdeGrabar() As Boolean
        ValidaAntesdeGrabar = True
        If Len(TxtNroRegistro.Text) <> Val(wsfor_numerodigitos) Then
            FaltaDatos.SetError(TxtNroRegistro, "Debe indicar " & wsfor_numerodigitos & " Digitos para el Numero")
            GoTo NO_Actualiza
        End If
        If txtNombreNeg.Text = "" Then
            FaltaDatos.SetError(txtNombreNeg, "Debe indicar Nombre Negocio")
            GoTo NO_Actualiza
        End If
        If TxtNombreComercial.Text = "" Then
            FaltaDatos.SetError(TxtNombreComercial, "Debe indicar Nombre Comercial")
            GoTo NO_Actualiza
        End If

        If TxtDirecNego.Text = "" Then
            FaltaDatos.SetError(TxtDirecNego, "Debe indicar Direccion")
            GoTo NO_Actualiza
        End If

        If TxtRefNego.Text = "" Then
            FaltaDatos.SetError(TxtRefNego, "Debe indicar Referencia")
            GoTo NO_Actualiza
        End If
        If Trim(CmbubigeoN1Neg.Text) = "" Then
            FaltaDatos.SetError(CmbubigeoN1Neg, "Debe indicar: Departamento")
            GoTo NO_Actualiza
        End If

        If Trim(CmbubigeoN2Neg.Text) = "" Then
            FaltaDatos.SetError(CmbubigeoN2Neg, "Debe indicar: Departamento")
            GoTo NO_Actualiza
        End If
        If Trim(CmbubigeoN3Neg.Text) = "" Then
            FaltaDatos.SetError(CmbubigeoN3Neg, "Debe indicar: Departamento")
            GoTo NO_Actualiza
        End If


        Exit Function
NO_Actualiza:
        ValidaAntesdeGrabar = False

    End Function

    Private Function ActualizaNegocio() As Boolean


        Dim ws_id_negocio As String = Id_Negocio.Text

        Dim ws_tipoDocNeg As String = lk_sql_ListaTipoDocPersona.Rows(CmbTipoDoc.SelectedIndex).Item("id_tipodoc").ToString
        Dim ws_nunRegi As String = TxtNroRegistro.Text
        Dim ws_nombreNeg As String = txtNombreNeg.Text
        Dim ws_nombreCome As String = TxtNombreComercial.Text
        Dim ws_direccionNeg As String = TxtDirecNego.Text
        Dim ws_referenciaNeg As String = TxtRefNego.Text
        Dim ws_ubigeoN1 As String = lk_sql_ListaUbigeoN1.Rows(CmbubigeoN1Neg.SelectedIndex).Item("id_ubigeo_n1").ToString
        Dim ws_ubigeoN2 As String = Trim(Strings.Right(CmbubigeoN2Neg.Text, 10))
        Dim ws_ubigeoN3 As String = Trim(Strings.Right(CmbubigeoN3Neg.Text, 10))
        Dim ws_fotoNeg As String
        If file.FileName = "X" Then  '  QUITA LA FOTO 
            ws_fotoNeg = "-"
        Else
            If FotoNegocio.Tag = "-" Then
                ws_fotoNeg = Nothing
            Else
                ws_fotoNeg = FotoNegocio.Tag
            End If
        End If

        Dim command As New SqlCommand()
        command.Connection = lk_connection_master
        command.CommandType = CommandType.StoredProcedure
        command.CommandText = "n_update_negocio"
        command.Parameters.Clear()
        command.Parameters.AddWithValue("@id", ws_id_negocio)
        command.Parameters.AddWithValue("@tipoDocNeg", ws_tipoDocNeg)
        command.Parameters.AddWithValue("@nunRegi", ws_nunRegi)
        command.Parameters.AddWithValue("@nombreNeg", ws_nombreNeg)
        command.Parameters.AddWithValue("@nombreCome", ws_nombreCome)
        command.Parameters.AddWithValue("@direccionNeg", ws_direccionNeg)
        command.Parameters.AddWithValue("@referenciaNeg", ws_referenciaNeg)
        command.Parameters.AddWithValue("@ubigeoN1", ws_ubigeoN1)
        command.Parameters.AddWithValue("@ubigeoN2", ws_ubigeoN2)
        command.Parameters.AddWithValue("@ubigeoN3", ws_ubigeoN3)
        command.Parameters.AddWithValue("@fotoNeg", ws_fotoNeg)
        Dim filasActualizadas As Integer = command.ExecuteNonQuery()
        If filasActualizadas > 0 Then
            ' La actualización fue exitosa '
            ActualizaNegocio = True
        Else
            ActualizaNegocio = False
            Exit Function
        End If



    End Function

    Private Function AddNegocio() As Boolean

        Dim ws_idUsuario As String = lk_id_usuario
        Dim ws_tipoDocNego As String = lk_sql_ListaTipoDocPersona.Rows(CmbTipoDoc.SelectedIndex).Item("id_tipodoc").ToString
        Dim ws_nunRegi As String = TxtNroRegistro.Text
        Dim ws_nombreNeg As String = txtNombreNeg.Text
        Dim ws_nombreCome As String = TxtNombreComercial.Text
        Dim ws_direccionNeg As String = TxtDirecNego.Text
        Dim ws_referenciaNeg As String = TxtRefNego.Text
        Dim ws_ubigeoN1 As String = lk_sql_ListaUbigeoN1.Rows(CmbubigeoN1Neg.SelectedIndex).Item("id_ubigeo_n1").ToString
        Dim ws_ubigeoN2 As String = Trim(Strings.Right(CmbubigeoN2Neg.Text, 10))
        Dim ws_ubigeoN3 As String = Trim(Strings.Right(CmbubigeoN3Neg.Text, 10))
        Dim ws_fotoNeg As String = FotoNegocio.Tag


        Dim command As New SqlCommand()
        command.Connection = lk_connection_master
        command.CommandType = CommandType.StoredProcedure
        command.CommandText = "n_registrar_negocio_usuario"
        command.Parameters.Clear()
        command.Parameters.AddWithValue("@idUsu", ws_idUsuario)
        command.Parameters.AddWithValue("@tipoDocNeg", ws_tipoDocNego)
        command.Parameters.AddWithValue("@nunRegi", ws_nunRegi)
        command.Parameters.AddWithValue("@nombreNeg", ws_nombreNeg)
        command.Parameters.AddWithValue("@nombreCome", ws_nombreCome)
        command.Parameters.AddWithValue("@direccionNeg", ws_direccionNeg)
        command.Parameters.AddWithValue("@referenciaNeg", ws_referenciaNeg)
        command.Parameters.AddWithValue("@ubigeoN1", ws_ubigeoN1)
        command.Parameters.AddWithValue("@ubigeoN2", ws_ubigeoN2)
        command.Parameters.AddWithValue("@ubigeoN3", ws_ubigeoN3)
        command.Parameters.AddWithValue("@fotoNeg", ws_fotoNeg)
        Dim filasActualizadas As Integer = command.ExecuteNonQuery()
        If filasActualizadas > 0 Then
            ' La actualización fue exitosa '
            AddNegocio = True
        Else
            AddNegocio = False
            Exit Function
        End If



        'Dim parametro = New List(Of Parametro) From {
        '    New Parametro("idUsuario", ws_idUsuario),
        '    New Parametro("tipoDocNeg", ws_tipoDocNego),
        '    New Parametro("nunRegi", ws_nunRegi),
        '    New Parametro("nombreNeg", ws_nombreNeg),
        '    New Parametro("nombreCome", ws_nombreCome),
        '    New Parametro("direccionNeg", ws_direccionNeg),
        '    New Parametro("referenciaNeg", ws_referenciaNeg),
        '    New Parametro("ubigeoN1", ws_ubigeoN1),
        '    New Parametro("ubigeoN2", ws_ubigeoN2),
        '    New Parametro("ubigeoN3", ws_ubigeoN3),
        '    New Parametro("fotoNeg", ws_fotoNeg)
        '}

        'Dim response = MuestraDataApi(lk_api_cadena_base + "negocio/usuario/agregar", parametro) ' respuesta : vps_Usaurios

        'lk_api_AgregaNegocio = JsonConvert.DeserializeObject(Of JsonAgregaNegocio)(response) 'Cái truyền tên Class vào
        'If lk_api_AgregaNegocio.estado = False Then
        '    AddNegocio = False
        'Else
        '    AddNegocio = True
        '    'VERIFICAMOS SI YA TIENE CUENTA SINO LE ASIGNAMOS 
        '    lk_id_cuemta_user = lk_api_AgregaNegocio.data.id_cuenta_user

        'End If

    End Function
    Private Sub CmdCreaLocales_Click(sender As Object, e As EventArgs) Handles CmdCreaLocales.Click
        Dim result
        If DGNegocios.Rows.Count = 0 Then
            result = MensajesBox.Show("Para Ingresar un Local" & Chr(13) & "primero debe ingresar informacion de su negocio...",
                                               "Crear tu cuenta de Negocio.")
            CmdCrearNegocio_Click(Nothing, Nothing)
            Exit Sub
        End If
        Flag_ModifoMapa = 0
        punto_lat = ""
        punto_lon = ""
        PanelCentral.Visible = False
        PanelCreaNegocio.Visible = False
        PanelCentral.Dock = DockStyle.None


        PanelLocales.Visible = True
        PanelLocales.Top = 50
        PanelLocales.Left = 310

        westadoFotoSubir = "0"
        wsfor_numerodigitos = lk_sql_ListaTipoDocPersona.Rows(CmbTipoDoc.SelectedIndex).Item("digitos").ToString
        LimpiaLocales()
        CmdAddLocal.Text = "&Crear"

        PanelNegocios.Enabled = False
        CmbActivaCambioGPS.Text = "&Retorna Ubicación"
        CmbActivaCambioGPS.IconChar = FontAwesome.Sharp.IconChar.MapMarked
        marker.ToolTipText = String.Format("Usa el Mouse " & vbCrLf & "para ubicar el nuevo GPS.")
        marker.Position = New PointLatLng(temp_lat.Text, temp_lon.Text)
        CmbActivaCambioGPS.Enabled = False

        Flag_ModifoMapa = 0
    End Sub

    Private Sub CmdCancelaLocales_Click(sender As Object, e As EventArgs) Handles CmdCancelaLocales.Click
        PanelLocales.Visible = False
        PanelCreaNegocio.Visible = False
        PanelAlmacen.Visible = False
        PanelCentral.Dock = DockStyle.Fill
        PanelCentral.Visible = True
        PanelNegocios.Enabled = True
        PanelAlmacen.Visible = False
        LimpiaLocales()
    End Sub

    Private Sub GMapControl1_Load(sender As Object, e As EventArgs) Handles GMapControl1.Load

    End Sub

    Private Sub FrmCreaNegocio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim result
        Me.Opacity = 0.7
        Me.Top = Me.Top + 40

        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        FotoNegocio.Image = My.Resources.negocio
        Me.Icon = My.Resources.icologo
        Me.FormBorderStyle = 1 ' Impedir que cambie el tamaño el formulario


        CmbListaPais.Items.Clear()
        wVarListaPais = {"Peru (+51)"} 'ARRAY ELEMENTOS EN EL MISMO ORDEN QUE EL IMAGELIST
        CmbListaPais.Items.AddRange(wVarListaPais)
        CmbListaPais.DrawMode = DrawMode.OwnerDrawVariable 'PARA PODER PONER NUESTRAS IMAGENES
        CmbListaPais.DropDownStyle = ComboBoxStyle.DropDownList 'PARA QUE EN EL TEXTO APAREZCA LA IMAGEN Y EL TEXTO
        CmbListaPais.DropDownHeight = 200 'PARA QUE MUESTRE TODOS LOS ELEMENTOS. DEPENDE DEL NUMERO DE ELEMENTOS Y SU ALTURA
        CmbListaPais.SelectedIndex = 0

        If lk_sql_ListaTipoDocPersona.Rows.Count = 0 Then

        End If

        If lk_sql_ListaTipoDocPersona.Rows.Count = 0 Then
            Dim command As SqlCommand = New SqlCommand("u_obtenerTipoDoc", lk_connection_master)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            lk_sql_ListaTipoDocPersona = New DataTable
            adapter.Fill(lk_sql_ListaTipoDocPersona)

        End If
        CmbTipoDoc.Items.Clear()
        For i = 0 To lk_sql_ListaTipoDocPersona.Rows.Count - 1
            CmbTipoDoc.Items.Add(lk_sql_ListaTipoDocPersona.Rows(i).Item("descripcion").ToString) ' & Space(80) & lk_api_TipoDocPersona.data(i).id
        Next
        CmbTipoDoc.SelectedIndex = 0


        If lk_sql_ListaTablas.Rows.Count = 0 Then

        Else
            CmbTipoLocal.Items.Clear()
            CmbTipoPropiedad.Items.Clear()

            For i = 0 To lk_sql_ListaTablas.Rows.Count - 1
                If lk_sql_ListaTablas.Rows(i).Item("id_tipotabla").ToString = "10" Then ' solo Tipo de locales
                    CmbTipoLocal.Items.Add(lk_sql_ListaTablas.Rows(i).Item("descripcion").ToString & Space(80) & lk_sql_ListaTablas.Rows(i).Item("id_tb").ToString)
                End If
                If lk_sql_ListaTablas.Rows(i).Item("id_tipotabla").ToString = "20" Then ' solo Tipo de locales
                    CmbTipoPropiedad.Items.Add(lk_sql_ListaTablas.Rows(i).Item("descripcion").ToString & Space(80) & lk_sql_ListaTablas.Rows(i).Item("id_tb").ToString)
                End If
                If lk_sql_ListaTablas.Rows(i).Item("id_tipotabla").ToString = "30" Then ' solo Tipo de locales
                    CmbTipoAlmacen.Items.Add(lk_sql_ListaTablas.Rows(i).Item("descripcion").ToString & Space(80) & lk_sql_ListaTablas.Rows(i).Item("id_tb").ToString)
                End If

            Next
        End If


        CmbubigeoN1Neg.Items.Clear()
        For i = 0 To lk_sql_ListaUbigeoN1.Rows.Count - 1
            CmbubigeoN1Neg.Items.Add(lk_sql_ListaUbigeoN1.Rows(i).Item("descripcion").ToString) ' & Space(80) & lk_api_TipoDocPersona.data(i).id
            CmbubigeoN1Local.Items.Add(lk_sql_ListaUbigeoN1.Rows(i).Item("descripcion").ToString) ' & Space(80) & lk_api_TipoDocPersona.data(i).id
            CmbUbigeoN1Almacen.Items.Add(lk_sql_ListaUbigeoN1.Rows(i).Item("descripcion").ToString) ' & Space(80) & lk_api_TipoDocPersona.data(i).id

        Next
        CmbubigeoN2Neg.Items.Clear()
        CmbubigeoN3Neg.Items.Clear()

        CmbubigeoN2Local.Items.Clear()
        CmbubigeoN3Local.Items.Clear()

        CmbUbigeoN2Almacen.Items.Clear()
        CmbUbigeoN3Almacen.Items.Clear()




        markerOverlay = New GMapOverlay("Marcador")
        marker = New GMarkerGoogle(New PointLatLng(punto_lat, punto_lon), My.Resources.gps1)
        markerOverlay.Markers.add(marker)
        marker.ToolTipMode = MarkerTooltipMode.Always
        marker.ToolTipText = String.Format("Ubicacion :" & vbCrLf & "Lat : {0} " & vbCrLf & " Lon : {1}", punto_lat, punto_lon)
        GMapControl1.Overlays.Add(markerOverlay)


        If lk_sql_Usuario_negocio.Rows.Count = 0 Then
            'RECARGARNEGOCIOS()
        End If

        If lk_sql_Usuario_negocio.Rows.Count = 0 Then
            Me.Opacity = 1
            result = MensajesBox.Show("Ingrese la informacion de su Negocio." & Chr(13) & "",
                                               "Crear tu cuenta de Negocio.")
            CmdCrearNegocio_Click(Nothing, Nothing)
            Exit Sub
        End If


        MUESTRANEGOCIOS()

        PanelNegocios.Width = 300
        PanelCentral.Visible = True
        PanelCentral.Dock = DockStyle.Fill
        Me.Opacity = 1
        PuntoInicialMAPA()




        Exit Sub
NoIngresa:
        MsgBox("algo hay ")
    End Sub
    Private Sub PuntoInicialMAPA()

        punto_lat = -8.1123001362125109
        punto_lon = -79.031791500241923
        temp_lat.Text = -8.1123001362125109
        temp_lon.Text = -79.031791500241923
        GMapControl1.DragButton = MouseButtons.Left
        GMapControl1.CanDragMap = True
        GMapControl1.MapProvider = GMapProviders.GoogleMap
        GMapControl1.Position = New PointLatLng(punto_lat, punto_lon)
        GMapControl1.MinZoom = 0
        GMapControl1.MaxZoom = 25
        GMapControl1.Zoom = 10
        GMapControl1.AutoScroll = True

    End Sub
    Private Sub MUESTRANEGOCIOS()

        DGNegocios.Rows.Clear()
        For I = 0 To lk_sql_Usuario_negocio.Rows.Count - 1
            If lk_sql_Usuario_negocio.Rows(I).Item("tipo").ToString = "EXTERNO" Then Continue For
            DGNegocios.Rows.Add()
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(0).Value = Trim(lk_sql_Usuario_negocio.Rows(I).Item("neg_abreviado").ToString) & vbCrLf & "RUC : " & Trim(lk_sql_Usuario_negocio.Rows(I).Item("neg_numerodoc").ToString) & vbCrLf & Strings.Left(lk_sql_Usuario_negocio.Rows(I).Item("neg_nombre").ToString, 20) & "..."

            If lk_sql_Usuario_negocio.Rows(I).Item("fotonegociolocal").ToString = "-" Then
                DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(1).Value = My.Resources.negocio ' Image.FromFile(My.Resources.negocio)
            Else
                DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(1).Value = Image.FromFile(lk_sql_Usuario_negocio.Rows(I).Item("fotonegociolocal").ToString)
            End If

            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Cells(2).Value = Trim(lk_sql_Usuario_negocio.Rows(I).Item("id_negocio").ToString)
            DGNegocios.Columns(0).Width = 210
            DGNegocios.Columns(1).Width = 210
            DGNegocios.Columns(2).Width = 0
            DGNegocios.Columns(2).Visible = False
            DGNegocios.Rows(DGNegocios.Rows.Count - 1).Height = 60
        Next
    End Sub

    Private Sub CmdAddLocal_Click(sender As Object, e As EventArgs) Handles CmdAddLocal.Click
        If Strings.Left(CmdAddLocal.Text, 2) = "&C" Then
            CreaLocalNuevo()
        ElseIf Strings.Left(CmdAddLocal.Text, 2) = "&A" Then
            ModificaLocal()
        End If

    End Sub
    Private Sub ModificaLocal()
        Dim result
        Dim wConfirmasubida As String
        If ValidaAntesdeGrabar_local() = False Then
            Exit Sub
        End If

        FotoLocal.Tag = "-"
        If westadoFotoSubir = "2" Then ' Solo Subir si cambia la foto
            Dim nombre As String = System.IO.Path.GetFileName(file.FileName)
            Dim extension As String = System.IO.Path.GetExtension(file.FileName)
            nombre = "loc" & lk_id_usuario & Format(Now, "hhmmss") & Id_NegocioLocal.Text & extension
            Application.DoEvents()
            wConfirmasubida = SubirImagen(file.FileName, lk_RutaSubir & nombre, lk_RutaSubir_User, lk_RutaSubir_clave)
            If Mid(wConfirmasubida, 1, 1) = "*" Then
                result = MensajesBox.Show("Sin acceso a guadar Imagenes, codigo error " & wConfirmasubida, lk_cabeza_msgbox)
                GoTo NO_Actualiza
            End If
            ''   'My.Computer.Network.UploadFile(file.FileName, RutaSubir & nombre, RutaSubir_User, RutaSubir_clave)
            My.Computer.FileSystem.CopyFile(
                   file.FileName,
                    lk_Carpeta_Temp & nombre,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            FotoLocal.Tag = lk_RutaBD & nombre

        End If


        If ActualizaLocal() = False Then
            result = MensajesBox.Show("No se pude Actualizar Negocio, Intentar nuevamente ",
                                      "Envio de SMS")
            Exit Sub
        End If


        'RECARGARNEGOCIOS()
        ' MUESTRANEGOCIOS()
        Negocio_Local_Almacen_Usuario()

        PanelCreaNegocio.Visible = False
        PanelCentral.Visible = True
        PanelCentral.Dock = DockStyle.Fill

        result = MensajesBox.Show("Datos Actualizados.", lk_cabeza_msgbox)
        PanelNegocios.Enabled = True

        llena_Lista_Locales(Id_Negocio.Text)
        CmdCancelaLocales_Click(Nothing, Nothing)
        Exit Sub
NO_Actualiza:
    End Sub
    Private Function ActualizaLocal() As Boolean

        Dim ws_idLocal As String = id_Local.Text
        Dim ws_idTbLocal As String = Trim(Strings.Right(CmbTipoLocal.Text, 20))
        Dim ws_idTbPropiedad As String = Trim(Strings.Right(CmbTipoPropiedad.Text, 20))
        Dim ws_codigo As String = TxtCodigoLocal.Text
        Dim ws_nombre As String = TxtNombreComercialLocal.Text
        Dim ws_nombreAbre As String = TxtAbreviadoLocal.Text
        Dim ws_direccion As String = TxtDireccionLocal.Text
        Dim ws_telefonos As String = TxtTelefonosLocal.Text
        Dim ws_correo As String = TxtCorreoLocal.Text




        Dim ws_referencia As String = TxtRefLocal.Text
        Dim ws_ubigeoN1 As String = lk_sql_ListaUbigeoN1.Rows(CmbubigeoN1Local.SelectedIndex).Item("id_ubigeo_n1").ToString
        Dim ws_ubigeoN2 As String = Trim(Strings.Right(CmbubigeoN2Local.Text, 10))
        Dim ws_ubigeoN3 As String = Trim(Strings.Right(CmbubigeoN3Local.Text, 10))
        Dim ws_fotoLocal As String

        If file.FileName = "X" Then  '  QUITA LA FOTO 
            ws_fotoLocal = "-"
        Else
            If FotoLocal.Tag = "-" Then
                ws_fotoLocal = Nothing
            Else
                ws_fotoLocal = FotoLocal.Tag
            End If
        End If
        Dim ws_lat As String = punto_lat
        Dim ws_lon As String = punto_lon
        Dim ws_idsus As String = "1"
        Dim ws_fechaInicio As String = Nothing
        Dim ws_dias As String = Nothing


        Dim command As New SqlCommand()
        command.Connection = lk_connection_master
        command.CommandType = CommandType.StoredProcedure
        command.CommandText = "n_update_negocio_local"
        command.Parameters.Clear()
        command.Parameters.AddWithValue("@idLocal", ws_idLocal)
        command.Parameters.AddWithValue("@idTbLocal", ws_idTbLocal)
        command.Parameters.AddWithValue("@idTbPropiedad", ws_idTbPropiedad)
        command.Parameters.AddWithValue("@codigo", ws_codigo)
        command.Parameters.AddWithValue("@nombre", ws_nombre)
        command.Parameters.AddWithValue("@nombreAbre", ws_nombreAbre)
        command.Parameters.AddWithValue("@direccion", ws_direccion)
        command.Parameters.AddWithValue("@referencia", ws_referencia)
        command.Parameters.AddWithValue("@idUbi1", ws_ubigeoN1)
        command.Parameters.AddWithValue("@idUbi2", ws_ubigeoN2)
        command.Parameters.AddWithValue("@idUbi3", ws_ubigeoN3)
        command.Parameters.AddWithValue("@fotoLocal", ws_fotoLocal)
        command.Parameters.AddWithValue("@lat", ws_lat)
        command.Parameters.AddWithValue("@lon", ws_lon)
        command.Parameters.AddWithValue("@idsus", ws_idsus)
        command.Parameters.AddWithValue("@fechaInicio", ws_fechaInicio)
        command.Parameters.AddWithValue("@dias", ws_dias)
        command.Parameters.AddWithValue("@telefonos", ws_telefonos)
        command.Parameters.AddWithValue("@correo", ws_correo)


        Dim filasActualizadas As Integer = command.ExecuteNonQuery()
        If filasActualizadas > 0 Then
            ' La actualización fue exitosa '
            ActualizaLocal = True
        Else
            ActualizaLocal = False
            Exit Function
        End If



        'Dim parametro = New List(Of Parametro) From {
        '    New Parametro("idLocal", ws_idLocal),
        '    New Parametro("idTbLocal", ws_idTbLocal),
        '    New Parametro("idTbPropiedad", ws_idTbPropiedad),
        '    New Parametro("codigo", ws_codigo),
        '    New Parametro("nombre", ws_nombre),
        '    New Parametro("nombreAbre", ws_nombreAbre),
        '    New Parametro("direccion", ws_direccion),
        '    New Parametro("referencia", ws_referencia),
        '    New Parametro("ubigeoN1", ws_ubigeoN1),
        '    New Parametro("ubigeoN2", ws_ubigeoN2),
        '    New Parametro("ubigeoN3", ws_ubigeoN3),
        '    New Parametro("fotoLocal", ws_fotoLocal),
        '    New Parametro("lat", ws_lat),
        '    New Parametro("lon", ws_lon),
        '    New Parametro("idsus", ws_idsus),
        '    New Parametro("fechaInicio", ws_fechaInicio),
        '    New Parametro("dias", ws_dias)
        '}

        'Dim response = MuestraDataApi(lk_api_cadena_base + "negocio/local/modificar", parametro) ' respuesta : vps_Usaurios

        'lk_api_ModificaDatos = JsonConvert.DeserializeObject(Of JsonModificaDatos)(response) ' 
        'If lk_api_ModificaDatos.estado = False Then
        '    ActualizaLocal = False
        'Else
        '    ActualizaLocal = True

        'End If





    End Function
    Private Sub CreaLocalNuevo()
        Dim result
        Dim wConfirmasubida As String
        Dim ws_key As String = txtkey_local.Text
        Dim ws_idNego As Integer = Val(Id_NegocioLocal.Text)
        Validado.SetError(txtkey_local, "")
        FaltaDatos.SetError(txtkey_local, "")
        If Validakey_local(ws_key, ws_idNego) = False Then
            result = MensajesBox.Show("Key de Suscripción no valido, comuníquese con su Partner local", lk_cabeza_msgbox)
            FaltaDatos.SetError(txtkey_local, "Key Incorrecto")
            txtkey_local.Focus()
            GoTo NO_Actualiza
        End If
        Validado.SetError(txtkey_local, "Key Aceptado")

        If ValidaAntesdeGrabar_local() = False Then
            GoTo NO_Actualiza
        End If

        FotoLocal.Tag = "-"
        If westadoFotoSubir = "2" Then ' Solo Subir si cambia la foto
            Dim nombre As String = System.IO.Path.GetFileName(file.FileName)
            Dim extension As String = System.IO.Path.GetExtension(file.FileName)



            nombre = "loc" & lk_id_usuario & Format(Now, "hhmmss") & Id_NegocioLocal.Text & extension

            Application.DoEvents()
            wConfirmasubida = SubirImagen(file.FileName, lk_RutaSubir & nombre, lk_RutaSubir_User, lk_RutaSubir_clave)
            If Mid(wConfirmasubida, 1, 1) = "*" Then
                result = MensajesBox.Show("Sin acceso a guadar Imagenes, codigo error " & wConfirmasubida, lk_cabeza_msgbox)
                GoTo NO_Actualiza
            End If
            ''   'My.Computer.Network.UploadFile(file.FileName, RutaSubir & nombre, RutaSubir_User, RutaSubir_clave)
            My.Computer.FileSystem.CopyFile(
                   file.FileName,
                    lk_Carpeta_Temp & nombre,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            FotoLocal.Tag = lk_RutaBD & nombre

        End If

        If AddLocal() = False Then
            result = MensajesBox.Show("No se pudo Crear Local, Intentar nuevamente ",
                                      "Envio de SMS")
            Exit Sub
        End If


        PanelLocales.Visible = False
        PanelCentral.Dock = DockStyle.Fill


        '        MsgBox("creado local")

        result = MensajesBox.Show("Muy Bien su Local ha sido creado con exito..",
                                      "Creación de Local")

        LimpiaLocales()
        'RECARGARNEGOCIOS()
        ' MUESTRANEGOCIOS()
        llena_Lista_Locales(Id_NegocioLocal.Text)
        PanelCreaNegocio.Visible = False
        PanelCentral.Visible = True
        PanelCentral.Dock = DockStyle.Fill
        CmdCancelaLocales_Click(Nothing, Nothing)
        Exit Sub
NO_Actualiza:
        '  MsgBox("ERR")
    End Sub
    Private Function AddLocal() As Boolean




        Dim ws_idNego As String = Id_NegocioLocal.Text
        Dim ws_idTbLocal As String = Trim(Strings.Right(CmbTipoLocal.Text, 20))
        Dim ws_idTbPropiedad As String = Trim(Strings.Right(CmbTipoPropiedad.Text, 20))
        Dim ws_codigo As String = TxtCodigoLocal.Text
        Dim ws_nombre As String = TxtNombreComercialLocal.Text
        Dim ws_nombreAbre As String = TxtAbreviadoLocal.Text
        Dim ws_direccion As String = TxtDireccionLocal.Text

        Dim ws_telefonos As String = TxtTelefonosLocal.Text
        Dim ws_correo As String = TxtCorreoLocal.Text




        Dim ws_referencia As String = TxtRefLocal.Text
        Dim ws_ubigeoN1 As String = lk_sql_ListaUbigeoN1.Rows(CmbubigeoN1Local.SelectedIndex).Item("id_ubigeo_n1").ToString
        Dim ws_ubigeoN2 As String = Trim(Strings.Right(CmbubigeoN2Local.Text, 10))
        Dim ws_ubigeoN3 As String = Trim(Strings.Right(CmbubigeoN3Local.Text, 10))
        Dim ws_fotoLocal As String = FotoLocal.Tag
        Dim ws_lat As String = punto_lat
        Dim ws_lon As String = punto_lon
        Dim ws_idsus As String = "1"
        Dim ws_fechaInicio As String = Format(Now, "yyyy-MM-dd hh:mm:ss")

        Dim ws_fechaInicioREG As Date = Now
        Dim ws_dias As String = "1"


        Dim command As New SqlCommand()
        command.Connection = lk_connection_master
        command.CommandType = CommandType.StoredProcedure
        command.CommandText = "n_registrar_negocio_local"
        command.Parameters.Clear()
        command.Parameters.AddWithValue("@idNego", ws_idNego)
        command.Parameters.AddWithValue("@idTbLocal", ws_idTbLocal)
        command.Parameters.AddWithValue("@idTbPropiedad", ws_idTbPropiedad)
        command.Parameters.AddWithValue("@codigo", ws_codigo)
        command.Parameters.AddWithValue("@nombre", ws_nombre)
        command.Parameters.AddWithValue("@nombreAbre", ws_nombreAbre)
        command.Parameters.AddWithValue("@direccion", ws_direccion)
        command.Parameters.AddWithValue("@referencia", ws_referencia)
        command.Parameters.AddWithValue("@idUbi1", ws_ubigeoN1)
        command.Parameters.AddWithValue("@idUbi2", ws_ubigeoN2)
        command.Parameters.AddWithValue("@idUbi3", ws_ubigeoN3)
        command.Parameters.AddWithValue("@fotoLocal", ws_fotoLocal)
        command.Parameters.AddWithValue("@lat", ws_lat)
        command.Parameters.AddWithValue("@lon", ws_lon)
        command.Parameters.AddWithValue("@idsus", ws_idsus)
        ' command.Parameters.AddWithValue("@fechaInicio", ws_fechaInicio)
        command.Parameters.AddWithValue("@dias", ws_dias)
        command.Parameters.AddWithValue("@telefonos", ws_telefonos)
        command.Parameters.AddWithValue("@correo", ws_correo)




        Dim filasActualizadas As Integer = command.ExecuteNonQuery()
        If filasActualizadas > 0 Then
            ' La actualización fue exitosa '
            AddLocal = True
        Else
            AddLocal = False
            Exit Function
        End If

        'Dim parametro = New List(Of Parametro) From {
        '    New Parametro("idNego", ws_idNego),
        '    New Parametro("idTbLocal", ws_idTbLocal),
        '    New Parametro("idTbPropiedad", ws_idTbPropiedad),
        '    New Parametro("codigo", ws_codigo),
        '    New Parametro("nombre", ws_nombre),
        '    New Parametro("nombreAbre", ws_nombreAbre),
        '    New Parametro("direccion", ws_direccion),
        '    New Parametro("referencia", ws_referencia),
        '    New Parametro("ubigeoN1", ws_ubigeoN1),
        '    New Parametro("ubigeoN2", ws_ubigeoN2),
        '    New Parametro("ubigeoN3", ws_ubigeoN3),
        '    New Parametro("fotoLocal", ws_fotoLocal),
        '    New Parametro("lat", ws_lat),
        '    New Parametro("lon", ws_lon),
        '    New Parametro("idsus", ws_idsus),
        '    New Parametro("fechaInicio", ws_fechaInicio),
        '    New Parametro("dias", ws_dias)
        '}

        'Dim response = MuestraDataApi(lk_api_cadena_base + "negocio/local/agregar", parametro) ' respuesta : vps_Usaurios

        'lk_api_AgregaLocal = JsonConvert.DeserializeObject(Of JsonAgregarLocal)(response) 'Cái truyền tên Class vào
        'If lk_api_AgregaLocal.estado = False Then
        '    AddLocal = False
        'Else
        '    AddLocal = True

        'End If

    End Function

    Private Function Validakey_local(ws_key As String, ws_id_negocio As Integer) As Boolean
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim wvar_resultado As DataTable
        Validakey_local = True

        sql_cade = "select  key_acceso from neg_keys where id_negocio = " & ws_id_negocio & " and id_local = 0 " ' filtro para buscar por el id : id_oper_maestro
        wvar_resultado = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(wvar_resultado)
        If wvar_resultado.Rows.Count = 0 Then
            Validakey_local = False
            Exit Function
        End If
        If wvar_resultado.Rows(0).Item("key_acceso").ToString <> ws_key Then
            Validakey_local = False
            Exit Function
        End If
    End Function
    Private Function ValidaAntesdeGrabar_local() As Boolean
        ValidaAntesdeGrabar_local = True

        If CmbTipoLocal.Text = "" Then
            FaltaDatos.SetError(CmbTipoLocal, "Debe indicar Tipo de Local")
            GoTo NO_Actualiza
        End If
        If CmbTipoPropiedad.Text = "" Then
            FaltaDatos.SetError(CmbTipoPropiedad, "Debe indicar Tipo de Propiedad")
            GoTo NO_Actualiza
        End If
        If TxtNombreComercialLocal.Text = "" Then
            FaltaDatos.SetError(TxtNombreComercialLocal, "Debe indicar Nombre Local")
            GoTo NO_Actualiza
        End If
        If TxtAbreviadoLocal.Text = "" Then
            FaltaDatos.SetError(TxtAbreviadoLocal, "Debe indicar Nombre abreviado")
            GoTo NO_Actualiza
        End If
        If TxtCodigoLocal.Text = "" Then
            FaltaDatos.SetError(TxtCodigoLocal, "Debe indicar Codigo")
            GoTo NO_Actualiza
        End If
        If TxtDireccionLocal.Text = "" Then
            FaltaDatos.SetError(TxtDireccionLocal, "Debe indicar Dirección")
            GoTo NO_Actualiza
        End If

        If TxtRefLocal.Text = "" Then
            FaltaDatos.SetError(TxtRefLocal, "Debe indicar Referencia")
            GoTo NO_Actualiza
        End If

        If Trim(CmbubigeoN1Local.Text) = "" Then
            FaltaDatos.SetError(CmbubigeoN1Local, "Debe indicar: Departamento")
            GoTo NO_Actualiza
        End If

        If Trim(CmbubigeoN2Local.Text) = "" Then
            FaltaDatos.SetError(CmbubigeoN2Local, "Debe indicar: Provincia")
            GoTo NO_Actualiza
        End If
        If Trim(CmbubigeoN3Local.Text) = "" Then
            FaltaDatos.SetError(CmbubigeoN3Local, "Debe indicar: Distrito")
            GoTo NO_Actualiza
        End If
        If Flag_ModifoMapa = 0 Then ' no activo la moficiacion en el mapa
            FaltaDatos.SetError(GMapControl1, "Debe indicar Punto en el MAPA, Use el Mouse para ubicar")
            GoTo NO_Actualiza
        End If
        Dim wcontar As Integer
        wcontar = 0

        For i = 0 To lk_sql_ListaLocales.Rows.Count - 1
            If id_Local.Text <> lk_sql_ListaLocales.Rows(i).Item("id_local").ToString Then
                If lk_sql_ListaLocales.Rows(i).Item("codigo").ToString = TxtCodigoLocal.Text Then
                    wcontar = wcontar + 1
                End If
            End If
        Next
        If wcontar >= 1 Then
                FaltaDatos.SetError(TxtCodigoLocal, "Codigo Duplicado,  ya Existe en otro Local.")
                GoTo NO_Actualiza
            End If




        Exit Function
NO_Actualiza:
        ValidaAntesdeGrabar_local = False

    End Function

    Private Sub CmdCreaAlmacen_Click(sender As Object, e As EventArgs) Handles CmdCreaAlmacen.Click
        'Exit Sub
        Dim result
        If DGLocales.Rows.Count = 0 Then
            result = MensajesBox.Show("Para Ingresar un Almacen" & Chr(13) & "primero debe ingresar informacion del Local...",
                                               "Crear tu cuenta de Local.")
            CmdCreaLocales_Click(Nothing, Nothing)
            Exit Sub
        End If

        PanelCentral.Visible = False
        PanelCreaNegocio.Visible = False

        PanelCentral.Dock = DockStyle.None
        PanelLocales.Visible = False
        PanelAlmacen.Top = 50
        PanelAlmacen.Left = 310
        westadoFotoSubir = "0"
        LimpiaAlmacen()
        CmdAddAlmacen.Text = "&Crear"

        PanelNegocios.Enabled = False
        Flag_ModifoMapa = 0
        PanelAlmacen.Visible = True

    End Sub
    Private Sub LimpiaAlmacen()
        TxtNombreAlmacen.Text = ""

        TtxtAbreviadoAlmacen.Text = ""
        TxtCodigoAlmacen.Text = ""
        TxtDireccionAlmacen.Text = ""
        TxtCodigoAlmacen.Text = ""
        TxtRefAlmacen.Text = ""

        CmbTipoLocal.SelectedIndex = -1


        CmbUbigeoN1Almacen.SelectedIndex = -1
        CmbUbigeoN2Almacen.Items.Clear()
        CmbUbigeoN3Almacen.Items.Clear()

        FaltaDatos.Clear()
        FotoAlmacen.Image = My.Resources.alma
        file.FileName = "-"
        westadoFotoSubir = "0"


    End Sub
    Private Sub CmdAddAlmacen_Click(sender As Object, e As EventArgs) Handles CmdAddAlmacen.Click
        If Strings.Left(CmdAddAlmacen.Text, 2) = "&C" Then
            CreaAlmacenlNuevo()
        ElseIf Strings.Left(CmdAddAlmacen.Text, 2) = "&A" Then
            Modifica_Almacen()
        End If

    End Sub
    Private Sub Modifica_Almacen()
        Dim result
        Dim wConfirmasubida As String
        If ValidaAntesdeGrabar_Almacen() = False Then
            Exit Sub
        End If

        FotoAlmacen.Tag = "-"
        If westadoFotoSubir = "2" Then ' Solo Subir si cambia la foto
            Dim nombre As String = System.IO.Path.GetFileName(file.FileName)
            Dim extension As String = System.IO.Path.GetExtension(file.FileName)
            nombre = "alm" & lk_id_usuario & Format(Now, "hhmmss") & Id_Almacen.Text & extension
            Application.DoEvents()
            wConfirmasubida = SubirImagen(file.FileName, lk_RutaSubir & nombre, lk_RutaSubir_User, lk_RutaSubir_clave)
            If Mid(wConfirmasubida, 1, 1) = "*" Then
                result = MensajesBox.Show("Sin acceso a guadar Imagenes, codigo error " & wConfirmasubida, lk_cabeza_msgbox)
                GoTo NO_Actualiza
            End If
            ''   'My.Computer.Network.UploadFile(file.FileName, RutaSubir & nombre, RutaSubir_User, RutaSubir_clave)
            My.Computer.FileSystem.CopyFile(
                   file.FileName,
                    lk_Carpeta_Temp & nombre,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            FotoAlmacen.Tag = lk_RutaBD & nombre

        End If


        If Actualiza_Almacen() = False Then
            result = MensajesBox.Show("No se pude Actualizar Almacen, Intentar nuevamente ",
                                      "Actualiza Almacen")
            Exit Sub
        End If

        Negocio_Local_Almacen_Usuario()
        'RECARGARNEGOCIOS()
        ' MUESTRANEGOCIOS()

        PanelCreaNegocio.Visible = False
        PanelCentral.Visible = True
        PanelCentral.Dock = DockStyle.Fill

        result = MensajesBox.Show("Datos Actualizados.", lk_cabeza_msgbox)
        PanelNegocios.Enabled = True

        llena_lista_Almacenes(Id_Local_alm.Text)
        CmdCancelAlmacen_Click(Nothing, Nothing)
        Exit Sub
NO_Actualiza:
    End Sub
    Private Function Actualiza_Almacen() As Boolean






        Dim ws_idAlmacen As String = Id_Almacen.Text
        Dim ws_idTbAlmacen As String = Trim(Strings.Right(CmbTipoAlmacen.Text, 20))
        Dim ws_codigo As String = TxtCodigoAlmacen.Text
        Dim ws_nombre As String = TxtNombreAlmacen.Text
        Dim ws_nombreAbre As String = TtxtAbreviadoAlmacen.Text
        Dim ws_direccion As String = TxtDireccionAlmacen.Text
        Dim ws_referencia As String = TxtRefAlmacen.Text
        Dim ws_ubigeoN1 As String = lk_sql_ListaUbigeoN1.Rows(CmbUbigeoN1Almacen.SelectedIndex).Item("id_ubigeo_n1").ToString
        Dim ws_ubigeoN2 As String = Trim(Strings.Right(CmbUbigeoN2Almacen.Text, 10))
        Dim ws_ubigeoN3 As String = Trim(Strings.Right(CmbUbigeoN3Almacen.Text, 10))
        Dim ws_fotoAlma As String

        If file.FileName = "X" Then  '  QUITA LA FOTO 
            ws_fotoAlma = "-"
        Else
            If FotoAlmacen.Tag = "-" Then
                ws_fotoAlma = Nothing
            Else
                ws_fotoAlma = FotoAlmacen.Tag
            End If
        End If

        Dim command As New SqlCommand()
        command.Connection = lk_connection_master
        command.CommandType = CommandType.StoredProcedure
        command.CommandText = "n_update_negocio_almacen"
        command.Parameters.Clear()
        command.Parameters.AddWithValue("@idAlmacen", ws_idAlmacen)
        command.Parameters.AddWithValue("@idTbAlmacen", ws_idTbAlmacen)
        command.Parameters.AddWithValue("@codigo", ws_codigo)
        command.Parameters.AddWithValue("@nombre", ws_nombre)
        command.Parameters.AddWithValue("@nombreAbre", ws_nombreAbre)
        command.Parameters.AddWithValue("@direcion", ws_direccion)
        command.Parameters.AddWithValue("@referencia", ws_referencia)
        command.Parameters.AddWithValue("@idUbi1", ws_ubigeoN1)
        command.Parameters.AddWithValue("@idUbi2", ws_ubigeoN2)
        command.Parameters.AddWithValue("@idUbi3", ws_ubigeoN3)
        command.Parameters.AddWithValue("@fotoAlma", ws_fotoAlma)
        Dim filasActualizadas As Integer = command.ExecuteNonQuery()
        If filasActualizadas > 0 Then
            ' La actualización fue exitosa '
            Actualiza_Almacen = True
        Else
            Actualiza_Almacen = False
            Exit Function
        End If

        'Dim parametro = New List(Of Parametro) From {
        '    New Parametro("idAlmacen", ws_idAlmacen),
        '    New Parametro("idTbAlmacen", ws_idTbAlmacen),
        '    New Parametro("codigo", ws_codigo),
        '    New Parametro("nombre", ws_nombre),
        '    New Parametro("nombreAbre", ws_nombreAbre),
        '    New Parametro("direccion", ws_direccion),
        '    New Parametro("referencia", ws_referencia),
        '    New Parametro("ubigeoN1", ws_ubigeoN1),
        '    New Parametro("ubigeoN2", ws_ubigeoN2),
        '    New Parametro("ubigeoN3", ws_ubigeoN3),
        '    New Parametro("fotoAlma", ws_fotoAlma)
        '}

        'Dim response = MuestraDataApi(lk_api_cadena_base + "negocio/almacen/modificar", parametro) ' respuesta : vps_Usaurios

        'lk_api_ModificaDatos = JsonConvert.DeserializeObject(Of JsonModificaDatos)(response) ' 
        'If lk_api_ModificaDatos.estado = False Then
        '    Actualiza_Almacen = False
        'Else
        '    Actualiza_Almacen = True

        'End If
    End Function
    Private Sub CreaAlmacenlNuevo()
        Dim result
        Dim wConfirmasubida As String
        If ValidaAntesdeGrabar_Almacen() = False Then
            GoTo NO_Actualiza
        End If

        FotoAlmacen.Tag = "-"
        If westadoFotoSubir = "2" Then ' Solo Subir si cambia la foto
            Dim nombre As String = System.IO.Path.GetFileName(file.FileName)
            Dim extension As String = System.IO.Path.GetExtension(file.FileName)



            nombre = "alm" & lk_id_usuario & Format(Now, "hhmmss") & Id_Local_alm.Text & extension

            Application.DoEvents()
            wConfirmasubida = SubirImagen(file.FileName, lk_RutaSubir & nombre, lk_RutaSubir_User, lk_RutaSubir_clave)
            If Mid(wConfirmasubida, 1, 1) = "*" Then
                result = MensajesBox.Show("Sin acceso a guadar Imagenes, codigo error " & wConfirmasubida, lk_cabeza_msgbox)
                GoTo NO_Actualiza
            End If
            ''   'My.Computer.Network.UploadFile(file.FileName, RutaSubir & nombre, RutaSubir_User, RutaSubir_clave)
            My.Computer.FileSystem.CopyFile(
                   file.FileName,
                    lk_Carpeta_Temp & nombre,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            FotoAlmacen.Tag = lk_RutaBD & nombre

        End If
        Dim wId_Negocio As Integer = Id_Negocio.Text
        If AddAlmacen() = False Then
            result = MensajesBox.Show("No se pudo Crear Almacen, Intentar nuevamente ",
                                      "Creación de Almacen.")
            Exit Sub
        End If


        PanelAlmacen.Visible = False
        PanelCentral.Dock = DockStyle.Fill


        '        MsgBox("creado local")

        result = MensajesBox.Show("Muy Bien su Almacen ha sido creado con exito..",
                                      "Creación de Almacen")

        LimpiaAlmacen()

        llena_lista_Almacenes(Id_Local_alm.Text)

        PanelCreaNegocio.Visible = False
        PanelLocales.Visible = False
        PanelAlmacen.Visible = False
        PanelCentral.Visible = True
        PanelCentral.Dock = DockStyle.Fill
        CmdCancelAlmacen_Click(Nothing, Nothing)






        Exit Sub
NO_Actualiza:
        '   MsgBox("ERR")
    End Sub
    Private Function AddAlmacen() As Boolean

        Dim wId_Negocio As Integer = Id_Negocio.Text
        Dim ws_idLocal As String = Id_Local_alm.Text
        Dim ws_idTbAlmacen As String = Trim(Strings.Right(CmbTipoAlmacen.Text, 20))
        Dim ws_codigo As String = TxtCodigoAlmacen.Text
        Dim ws_nombre As String = TxtNombreAlmacen.Text
        Dim ws_nombreAbre As String = TtxtAbreviadoAlmacen.Text
        Dim ws_direccion As String = TxtDireccionAlmacen.Text
        Dim ws_referencia As String = TxtRefAlmacen.Text
        Dim ws_ubigeoN1 As String = lk_sql_ListaUbigeoN1.Rows(CmbUbigeoN1Almacen.SelectedIndex).Item("id_ubigeo_n1").ToString
        Dim ws_ubigeoN2 As String = Trim(Strings.Right(CmbUbigeoN2Almacen.Text, 10))
        Dim ws_ubigeoN3 As String = Trim(Strings.Right(CmbUbigeoN3Almacen.Text, 10))
        Dim ws_fotoAlma As String = FotoAlmacen.Tag


        Dim command As New SqlCommand()
        command.Connection = lk_connection_master
        command.CommandType = CommandType.StoredProcedure
        command.CommandText = "[n_registrar_negocio_almacen]"
        command.Parameters.Clear()
        command.Parameters.AddWithValue("@id_negocio", wId_Negocio)
        command.Parameters.AddWithValue("@local", ws_idLocal)
        command.Parameters.AddWithValue("@idTbAlmacen", ws_idTbAlmacen)
        command.Parameters.AddWithValue("@codigo", ws_codigo)
        command.Parameters.AddWithValue("@nombre", ws_nombre)
        command.Parameters.AddWithValue("@nombreAbre", ws_nombreAbre)
        command.Parameters.AddWithValue("@direcion", ws_direccion)
        command.Parameters.AddWithValue("@referencia", ws_referencia)
        command.Parameters.AddWithValue("@idUbi1", ws_ubigeoN1)
        command.Parameters.AddWithValue("@idUbi2", ws_ubigeoN2)
        command.Parameters.AddWithValue("@idUbi3", ws_ubigeoN3)
        command.Parameters.AddWithValue("@fotoAlma", ws_fotoAlma)
        Dim filasActualizadas As Integer = command.ExecuteNonQuery()
        If filasActualizadas > 0 Then
            ' La actualización fue exitosa '
            AddAlmacen = True
        Else
            AddAlmacen = False
            Exit Function
        End If


        'Dim parametro = New List(Of Parametro) From {
        '    New Parametro("idLocal", ws_idLocal),
        '    New Parametro("idTbAlmacen", ws_idTbAlmacen),
        '    New Parametro("codigo", ws_codigo),
        '    New Parametro("nombre", ws_nombre),
        '    New Parametro("nombreAbre", ws_nombreAbre),
        '    New Parametro("direccion", ws_direccion),
        '    New Parametro("referencia", ws_referencia),
        '    New Parametro("ubigeoN1", ws_ubigeoN1),
        '    New Parametro("ubigeoN2", ws_ubigeoN2),
        '    New Parametro("ubigeoN3", ws_ubigeoN3),
        '    New Parametro("fotoAlma", ws_fotoAlma)
        '}

        'Dim response = MuestraDataApi(lk_api_cadena_base + "negocio/almacen/agregar", parametro) ' respuesta : vps_Usaurios

        'lk_api_AgregarAlmacen = JsonConvert.DeserializeObject(Of JsonAgregarAlmacen)(response) 'Cái truyền tên Class vào
        'If lk_api_AgregarAlmacen.estado = False Then
        '    AddAlmacen = False
        'Else
        '    AddAlmacen = True

        'End If

    End Function
    Private Function ValidaAntesdeGrabar_Almacen() As Boolean
        ValidaAntesdeGrabar_Almacen = True

        If CmbTipoAlmacen.Text = "" Then
            FaltaDatos.SetError(CmbTipoAlmacen, "Debe indicar Tipo de Local")
            GoTo NO_Actualiza
        End If
        If TxtNombreAlmacen.Text = "" Then
            FaltaDatos.SetError(TxtNombreAlmacen, "Debe indicar Nombre Local")
            GoTo NO_Actualiza
        End If
        If TtxtAbreviadoAlmacen.Text = "" Then
            FaltaDatos.SetError(TtxtAbreviadoAlmacen, "Debe indicar Nombre abreviado")
            GoTo NO_Actualiza
        End If
        If TxtCodigoAlmacen.Text = "" Then
            FaltaDatos.SetError(TxtCodigoAlmacen, "Debe indicar Codigo")
            GoTo NO_Actualiza
        End If
        If TxtDireccionAlmacen.Text = "" Then
            FaltaDatos.SetError(TxtDireccionAlmacen, "Debe indicar Dirección")
            GoTo NO_Actualiza
        End If

        If TxtRefAlmacen.Text = "" Then
            FaltaDatos.SetError(TxtRefAlmacen, "Debe indicar Referencia")
            GoTo NO_Actualiza
        End If

        If Trim(CmbUbigeoN1Almacen.Text) = "" Then
            FaltaDatos.SetError(CmbUbigeoN1Almacen, "Debe indicar: Departamento")
            GoTo NO_Actualiza
        End If

        If Trim(CmbUbigeoN2Almacen.Text) = "" Then
            FaltaDatos.SetError(CmbUbigeoN2Almacen, "Debe indicar: Provincia")
            GoTo NO_Actualiza
        End If
        If Trim(CmbUbigeoN3Almacen.Text) = "" Then
            FaltaDatos.SetError(CmbUbigeoN3Almacen, "Debe indicar: Distrito")
            GoTo NO_Actualiza
        End If

        Dim wcontar As Integer
        wcontar = 0
        If lk_sql_ListaAlmacenes.Rows.Count > 0 Then
            For i = 0 To lk_sql_ListaAlmacenes.Rows.Count - 1
                If Id_Almacen.Text <> lk_sql_ListaAlmacenes.Rows(i).Item("id_almacen").ToString Then
                    If lk_sql_ListaAlmacenes.Rows(i).Item("codigo").ToString = TxtCodigoAlmacen.Text Then
                        wcontar = wcontar + 1
                    End If
                End If
            Next
            If wcontar >= 1 Then
                FaltaDatos.SetError(TxtCodigoAlmacen, "Codigo Duplicado,  ya Existe en otro Almacen.")
                GoTo NO_Actualiza
            End If
        End If




        Exit Function
NO_Actualiza:
        ValidaAntesdeGrabar_Almacen = False

    End Function
    Private Sub CmdCancelAlmacen_Click(sender As Object, e As EventArgs) Handles CmdCancelAlmacen.Click
        PanelAlmacen.Visible = False
        PanelLocales.Visible = False
        PanelCreaNegocio.Visible = False
        PanelCentral.Dock = DockStyle.Fill
        PanelCentral.Visible = True
        PanelNegocios.Enabled = True
        PanelAlmacen.Visible = False
        LimpiaAlmacen()





    End Sub

    Private Sub IconButton9_Click(sender As Object, e As EventArgs) Handles IconButton9.Click

    End Sub

    Private Sub CmbListaPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbListaPais.SelectedIndexChanged

    End Sub
    Private Sub CmbListaPais_DrawItem(sender As Object, e As DrawItemEventArgs) Handles CmbListaPais.DrawItem
        Try
            e.Graphics.DrawImage(ImagenesPaises.Images(e.Index), e.Bounds.Left, e.Bounds.Top) 'DIBUJA LA IMAGEN
            e.Graphics.DrawString(wVarListaPais(e.Index), CmbListaPais.Font, Brushes.Black, e.Bounds.Left + ImagenesPaises.ImageSize.Width + 10, e.Bounds.Top) 'DIBUJA EL TEXTO
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CmbListaPais_MeasureItem(sender As Object, e As MeasureItemEventArgs) Handles CmbListaPais.MeasureItem
        e.ItemHeight = ImagenesPaises.ImageSize.Height + 5 'PARA SEPARAR LOS ELEMENTOS
    End Sub

    Private Sub PanelAlmacen_Paint(sender As Object, e As PaintEventArgs) Handles PanelAlmacen.Paint

    End Sub

    Private Sub CmbubigeoN1Neg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbubigeoN1Neg.SelectedIndexChanged
        CmbubigeoN2Neg.Items.Clear()
        If CmbubigeoN1Neg.SelectedIndex = -1 Then Exit Sub
        For i = 0 To lk_sql_ListaUbigeoN2.Rows.Count - 1
            If lk_sql_ListaUbigeoN2.Rows(i).Item("id_ubigeo_n1").ToString = lk_sql_ListaUbigeoN1.Rows(CmbubigeoN1Neg.SelectedIndex).Item("id_ubigeo_n1").ToString Then
                CmbubigeoN2Neg.Items.Add(lk_sql_ListaUbigeoN2.Rows(i).Item("descripcion").ToString & Space(80) & lk_sql_ListaUbigeoN2.Rows(i).Item("id_ubigeo_n2").ToString) ' & Space(80) & lk_api_TipoDocPersona.data(i).id
            End If
        Next
        CmbubigeoN3Neg.Items.Clear()

    End Sub

    Private Sub CmbubigeoN2Neg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbubigeoN2Neg.SelectedIndexChanged
        CmbubigeoN3Neg.Items.Clear()

        For i = 0 To lk_sql_ListaUbigeoN3.Rows.Count - 1
            If lk_sql_ListaUbigeoN3.Rows(i).Item("id_ubigeo_n2").ToString = Trim(Strings.Right(CmbubigeoN2Neg.Text, 10)) Then
                CmbubigeoN3Neg.Items.Add(lk_sql_ListaUbigeoN3.Rows(i).Item("descripcion").ToString & Space(80) & lk_sql_ListaUbigeoN3.Rows(i).Item("id_ubigeo_n3").ToString)
            End If
        Next


    End Sub

    Private Sub CmbFotoNegocio_Click(sender As Object, e As EventArgs) Handles CmbFotoNegocio.Click
        Dim ws_fotolocal As String
        westadoFotoSubir = "0"
        file.Filter = "Archivo JPG|*.bmp;*.jpg;*.png"
        If file.ShowDialog() = DialogResult.OK Then
            file.FileName = StrConv(file.FileName, vbLowerCase)
            ws_fotolocal = AjustarImagen(file.FileName)

            file.FileName = ws_fotolocal
            FotoNegocio.Image = Image.FromFile(file.FileName)
            Redondeaimagen(FotoNegocio)
            westadoFotoSubir = "2"
        End If
    End Sub

    Private Sub CmdQuitaFotoNegocio_Click(sender As Object, e As EventArgs) Handles CmdQuitaFotoNegocio.Click
        FotoNegocio.Image = My.Resources.negocio
        file.FileName = "X"
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles CheckAutorizaEtiqueta.LinkClicked

        Try
            System.Diagnostics.Process.Start("https://innovatechapp.com/")


        Catch
            MsgBox("NO SE PUDO CARGAR LA PAGINA..")
        End Try
    End Sub

    Dim WithEvents CLIENTE As New WebClient 'LO DECLARAMOS CON EVENTS PARA PODER UTILIZAR LOS PROCEDIMIENTOS PROGRESSCHANGED Y COMPLETED
    Private Sub llena_Lista_Locales(ws_idnegocio As String)



        Dim command As SqlCommand = New SqlCommand("n_lista_neg_local", lk_connection_master)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@id", ws_idnegocio)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        lk_sql_ListaLocales = New DataTable
        lk_sql_ListaLocales.Columns.Clear()
        adapter.Fill(lk_sql_ListaLocales)
        Dim tempColumn As DataColumn = New DataColumn("fotolocal_local", GetType(String))
        Dim tempColumn2 As DataColumn = New DataColumn("fotolocal_local_Defecto", GetType(Bitmap))
        lk_sql_ListaLocales.Columns.Add(tempColumn)
        lk_sql_ListaLocales.Columns.Add(tempColumn2)




        Dim result
        Id_NegocioLocal.Text = ws_idnegocio
        '  If lk_api_ListaNegocios Is Nothing Then
        'Dim parametroneg = New List(Of Parametro) From {
        '     New Parametro("id_negocio", ws_idnegocio)
        '     }

        'Dim responseneg = MuestraDataApi(lk_api_cadena_base + "negocio/local/listar", parametroneg) ' respuesta : vps_Usaurios
        Try
            '    lk_api_ListaLocales = JsonConvert.DeserializeObject(Of JsonListaLocales)(responseneg) 'Cái truyền tên Class vào

            For I = 0 To lk_sql_ListaLocales.Rows.Count - 1
                If lk_sql_ListaLocales.Rows(I).Item("fotolocal").ToString = "-" Then
                    lk_sql_ListaLocales.Rows(I).Item("fotolocal_local") = "-"
                    If lk_sql_ListaLocales.Rows(I).Item("id_tb_tipolocal").ToString = "1" Then
                        lk_sql_ListaLocales.Rows(I).Item("fotolocal_local_Defecto") = My.Resources.botica
                    ElseIf lk_sql_ListaLocales.Rows(I).Item("id_tb_tipolocal").ToString = "2" Then
                        lk_sql_ListaLocales.Rows(I).Item("fotolocal_local_Defecto") = My.Resources.farmacia
                    ElseIf lk_sql_ListaLocales.Rows(I).Item("id_tb_tipolocal").ToString = "3" Then
                        lk_sql_ListaLocales.Rows(I).Item("fotolocal_local_Defecto") = My.Resources.deli
                    ElseIf lk_sql_ListaLocales.Rows(I).Item("id_tb_tipolocal").ToString = "4" Then
                        lk_sql_ListaLocales.Rows(I).Item("fotolocal_local_Defecto") = My.Resources.distrib
                    Else
                        lk_sql_ListaLocales.Rows(I).Item("fotolocal_local_Defecto") = My.Resources.negocio
                    End If
                Else
                    Dim wRutaLocalfile As String = lk_Carpeta_Temp & System.IO.Path.GetFileName(lk_sql_ListaLocales.Rows(I).Item("fotolocal").ToString)
                    If System.IO.File.Exists(wRutaLocalfile) Then

                    Else
                        CLIENTE.DownloadFile(New Uri(lk_sql_ListaLocales.Rows(I).Item("fotolocal").ToString), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                    End If
                    lk_sql_ListaLocales.Rows(I).Item("fotolocal_local") = wRutaLocalfile
                End If
            Next


        Catch ex As Exception
            Exit Sub
        End Try

        If lk_sql_ListaLocales.Rows.Count = 0 Then
            Result = MensajesBox.Show("Todavia no a creado sus Locales." & Chr(13) & "Ingrese la Informacion de su local. ",
                                           "Crear Locales")
            GoTo NoIngresa
        End If



        MUESTRALOCALES()



        Exit Sub
NoIngresa:
    End Sub
    Private Sub MUESTRALOCALES()
        Dim FOTODEFECTO = My.Resources.negocio
        DGLocales.Rows.Clear()
        For I = 0 To lk_sql_ListaLocales.Rows.Count - 1
            DGLocales.Rows.Add()
            DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(0).Value = Trim(lk_sql_ListaLocales.Rows(I).Item("nombreabreviado").ToString & vbCrLf & "CODIGO : " & Trim(lk_sql_ListaLocales.Rows(I).Item("codigo").ToString) & vbCrLf & Trim(lk_sql_ListaLocales.Rows(I).Item("nombre").ToString))
            If lk_sql_ListaLocales.Rows(I).Item("fotolocal_local").ToString = "-" Then
                DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(1).Value = lk_sql_ListaLocales.Rows(I).Item("fotolocal_local_Defecto")
            Else
                DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(1).Value = Image.FromFile(lk_sql_ListaLocales.Rows(I).Item("fotolocal_local").ToString)
            End If

            DGLocales.Rows(DGLocales.Rows.Count - 1).Cells(2).Value = Trim(lk_sql_ListaLocales.Rows(I).Item("id_local").ToString)

            DGLocales.Columns(0).Width = 210
            DGLocales.Columns(1).Width = 210
            DGLocales.Columns(2).Width = 0
            DGLocales.Columns(2).Visible = False
            DGLocales.Rows(DGLocales.Rows.Count - 1).Height = 60


        Next
    End Sub
    Private Sub AsignaUBIGEO(CmbU1 As ComboBox, CmbU2 As ComboBox, CmbU3 As ComboBox, Id_U1 As String, Id_U2 As String, Id_U3 As String)
        ' asigno el ubiego 
        For i = 0 To CmbU1.Items.Count - 1
            If lk_sql_ListaUbigeoN1.Rows(i).Item("id_ubigeo_n1").ToString = Id_U1 Then
                CmbU1.SelectedIndex = i
                Exit For
            End If
        Next

        'llego el ubieo 2 asociado al 1 
        CmbU2.Items.Clear()
        For i = 0 To lk_sql_ListaUbigeoN2.Rows.Count - 1
            If lk_sql_ListaUbigeoN2.Rows(i).Item("id_ubigeo_n1").ToString = lk_sql_ListaUbigeoN1.Rows(CmbU1.SelectedIndex).Item("id_ubigeo_n1").ToString Then
                CmbU2.Items.Add(lk_sql_ListaUbigeoN2.Rows(i).Item("descripcion").ToString & Space(80) & lk_sql_ListaUbigeoN2.Rows(i).Item("id_ubigeo_n2").ToString) ' & Space(80) & lk_api_TipoDocPersona.data(i).id
            End If
        Next

        CmbubigeoN3Neg.Items.Clear()
        ' asigno el ubieo 2
        For i = 0 To CmbU2.Items.Count - 1
            If Trim(Strings.Right(CmbU2.Items(i).ToString, 10)) = Id_U2 Then
                CmbU2.SelectedIndex = i
                Exit For
            End If
        Next

        'llego loubigeo 3 con respecto a 2 
        For i = 0 To lk_sql_ListaUbigeoN3.Rows.Count - 1
            If lk_sql_ListaUbigeoN3.Rows(i).Item("id_ubigeo_n2").ToString = Trim(Strings.Right(CmbU2.Text, 10)) Then
                CmbU3.Items.Add(lk_sql_ListaUbigeoN3.Rows(i).Item("descripcion").ToString & Space(80) & lk_sql_ListaUbigeoN3.Rows(i).Item("id_ubigeo_n3").ToString)
            End If
        Next
        ' asigno el ubieo 3

        For i = 0 To CmbU3.Items.Count - 1
            If Trim(Strings.Right(CmbU2.Items(i).ToString, 10)) = Id_U3 Then
                CmbU3.SelectedIndex = i
                Exit For
            End If
        Next

    End Sub
    Private Sub CmbTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoDoc.SelectedIndexChanged

        wsfor_numerodigitos = lk_sql_ListaTipoDocPersona.Rows(CmbTipoDoc.SelectedIndex).Item("digitos")
        TxtNroRegistro.MaxLength = wsfor_numerodigitos
    End Sub

    Private Sub TxtNroRegistro_TextChanged(sender As Object, e As EventArgs) Handles TxtNroRegistro.TextChanged

    End Sub

    Private Sub GMapControl1_MouseClick(sender As Object, e As MouseEventArgs) Handles GMapControl1.MouseClick
        If Strings.Left(CmbActivaCambioGPS.Text, 2) = "&C" Then Exit Sub
        punto_lat = GMapControl1.FromLocalToLatLng(e.X, e.Y).Lat
        punto_lon = GMapControl1.FromLocalToLatLng(e.X, e.Y).Lng
        Flag_ModifoMapa = 1
        Dim Wlat As Double = Format(GMapControl1.FromLocalToLatLng(e.X, e.Y).Lat, "0.0000")
        Dim Wlon As Double = Format(GMapControl1.FromLocalToLatLng(e.X, e.Y).Lng, "0.0000")

        marker.Position = New PointLatLng(Wlat, Wlon)
        marker.ToolTipText = String.Format("Ubicacion :" & vbCrLf & "Lat : {0} " & vbCrLf & " Lon : {1}", Wlat, Wlon)
    End Sub

    Private Sub TxtNroRegistro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNroRegistro.KeyPress
        e.Handled = Solo_Numero(e)
    End Sub

    Private Sub txtNombreNeg_TextChanged(sender As Object, e As EventArgs) Handles txtNombreNeg.TextChanged

    End Sub

    Private Sub TxtNroRegistro_Validating(sender As Object, e As CancelEventArgs) Handles TxtNroRegistro.Validating

        'ValidaDAtosValidating(FaltaDatos, DatosOK, sender, "Dato Obligatorio: Numero de Documento")
        If Len(DirectCast(sender, TextBox).Text) <> wsfor_numerodigitos Then
            FaltaDatos.SetError(sender, "Debe indicar " & wsfor_numerodigitos & " Digitos para el Numero")
        Else
            FaltaDatos.SetError(sender, "")
        End If

    End Sub

    Private Sub txtNombreNeg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreNeg.KeyPress

    End Sub

    Private Sub TxtNombreComercial_TextChanged(sender As Object, e As EventArgs) Handles TxtNombreComercial.TextChanged

    End Sub

    Private Sub txtNombreNeg_Validating(sender As Object, e As CancelEventArgs) Handles txtNombreNeg.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio: Nombres")
    End Sub

    Private Sub TxtNombreComercial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNombreComercial.KeyPress

    End Sub

    Private Sub TxtDirecNego_TextChanged(sender As Object, e As EventArgs) Handles TxtDirecNego.TextChanged

    End Sub

    Private Sub TxtNombreComercial_Validating(sender As Object, e As CancelEventArgs) Handles TxtNombreComercial.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio: Nombre Comercial")
    End Sub

    Private Sub TxtDirecNego_Validating(sender As Object, e As CancelEventArgs) Handles TxtDirecNego.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio: Dirección ")
    End Sub

    Private Sub TxtRefNego_TextChanged(sender As Object, e As EventArgs) Handles TxtRefNego.TextChanged

    End Sub

    Private Sub TxtDirecNego_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDirecNego.KeyPress

    End Sub

    Private Sub TxtRefNego_Validating(sender As Object, e As CancelEventArgs) Handles TxtRefNego.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio: Referencia ")
    End Sub

    Private Sub CmbubigeoN1Neg_Validating(sender As Object, e As CancelEventArgs) Handles CmbubigeoN1Neg.Validating
        If Trim(CmbubigeoN1Neg.Text) = "" Then
            FaltaDatos.SetError(sender, "Debe indicar: Departamento")
        Else
            FaltaDatos.SetError(sender, "")
        End If
    End Sub

    Private Sub CmbubigeoN2Neg_Validating(sender As Object, e As CancelEventArgs) Handles CmbubigeoN2Neg.Validating
        If Trim(CmbubigeoN2Neg.Text) = "" Then
            FaltaDatos.SetError(sender, "Debe indicar: Departamento")
        Else
            FaltaDatos.SetError(sender, "")
        End If
    End Sub


    Private Sub CmbubigeoN1Local_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbubigeoN1Local.SelectedIndexChanged
        CmbubigeoN2Local.Items.Clear()
        If CmbubigeoN1Local.SelectedIndex = -1 Then Exit Sub
        For i = 0 To lk_sql_ListaUbigeoN2.Rows.Count - 1
            If lk_sql_ListaUbigeoN2.Rows(i).Item("id_ubigeo_n1").ToString = lk_sql_ListaUbigeoN1.Rows(CmbubigeoN1Local.SelectedIndex).Item("id_ubigeo_n1").ToString Then
                CmbubigeoN2Local.Items.Add(lk_sql_ListaUbigeoN2.Rows(i).Item("descripcion").ToString & Space(80) & lk_sql_ListaUbigeoN2.Rows(i).Item("id_ubigeo_n2").ToString)

            End If
        Next
        CmbubigeoN3Local.Items.Clear()
    End Sub

    Private Sub CmbubigeoN2Local_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbubigeoN2Local.SelectedIndexChanged
        CmbubigeoN3Local.Items.Clear()

        For i = 0 To lk_sql_ListaUbigeoN3.Rows.Count - 1
            If lk_sql_ListaUbigeoN3.Rows(i).Item("id_ubigeo_n2").ToString = Trim(Strings.Right(CmbubigeoN2Local.Text, 10)) Then
                CmbubigeoN3Local.Items.Add(lk_sql_ListaUbigeoN3.Rows(i).Item("descripcion") & Space(80) & lk_sql_ListaUbigeoN3.Rows(i).Item("id_ubigeo_n3").ToString)
            End If
        Next

    End Sub

    Private Sub CmbTipoLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoLocal.SelectedIndexChanged

        If westadoFotoSubir = "0" And Strings.Left(CmdAddLocal.Text, 2) = "&C" And CmbTipoLocal.Text <> "" Then
            If Trim(Strings.Right(CmbTipoLocal.Text, 20)) = 1 Then
                FotoLocal.Image = My.Resources.botica
                file.FileName = "-"
            ElseIf Trim(Strings.Right(CmbTipoLocal.Text, 20)) = 2 Then
                FotoLocal.Image = My.Resources.farmacia
                file.FileName = "-"
            ElseIf Trim(Strings.Right(CmbTipoLocal.Text, 20)) = 3 Then
                FotoLocal.Image = My.Resources.deli
                file.FileName = "-"
            ElseIf Trim(Strings.Right(CmbTipoLocal.Text, 20)) = 4 Then
                FotoLocal.Image = My.Resources.distrib
                file.FileName = "-"
            Else
                FotoLocal.Image = My.Resources.negocio
                file.FileName = "-"
            End If
        End If
    End Sub

    Private Sub CmbubigeoN3Neg_Validating(sender As Object, e As CancelEventArgs) Handles CmbubigeoN3Neg.Validating
        If Trim(CmbubigeoN3Neg.Text) = "" Then
            FaltaDatos.SetError(sender, "Debe indicar: Departamento")
        Else
            FaltaDatos.SetError(sender, "")
        End If
    End Sub

    Private Sub TxtNombreComercialLocal_TextChanged(sender As Object, e As EventArgs) Handles TxtNombreComercialLocal.TextChanged

    End Sub

    Private Sub CmbTipoLocal_Validating(sender As Object, e As CancelEventArgs) Handles CmbTipoLocal.Validating
        If CmbTipoLocal.Text = "" Then
            FaltaDatos.SetError(CmbTipoLocal, "Debe indicar Tipo de Local")
        Else
            FaltaDatos.SetError(CmbTipoLocal, "")
        End If


    End Sub

    Private Sub TxtAbreviadoLocal_TextChanged(sender As Object, e As EventArgs) Handles TxtAbreviadoLocal.TextChanged

    End Sub

    Private Sub TxtNombreComercialLocal_Validating(sender As Object, e As CancelEventArgs) Handles TxtNombreComercialLocal.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio.")
    End Sub

    Private Sub TxtCodigoLocal_TextChanged(sender As Object, e As EventArgs) Handles TxtCodigoLocal.TextChanged

    End Sub

    Private Sub TxtAbreviadoLocal_Validating(sender As Object, e As CancelEventArgs) Handles TxtAbreviadoLocal.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio.")
    End Sub

    Private Sub CmbTipoPropiedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoPropiedad.SelectedIndexChanged

    End Sub

    Private Sub TxtCodigoLocal_Validating(sender As Object, e As CancelEventArgs) Handles TxtCodigoLocal.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio.")
    End Sub

    Private Sub TxtDireccionLocal_TextChanged(sender As Object, e As EventArgs) Handles TxtDireccionLocal.TextChanged

    End Sub

    Private Sub CmbTipoPropiedad_Validating(sender As Object, e As CancelEventArgs) Handles CmbTipoPropiedad.Validating
        If CmbTipoPropiedad.Text = "" Then
            FaltaDatos.SetError(CmbTipoPropiedad, "Debe indicar Tipo de Local")
        Else
            FaltaDatos.SetError(CmbTipoPropiedad, "")
        End If

    End Sub

    Private Sub TxtDireccionLocal_Validating(sender As Object, e As CancelEventArgs) Handles TxtDireccionLocal.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio.")
    End Sub

    Private Sub CmbubigeoN1Local_Validating(sender As Object, e As CancelEventArgs) Handles CmbubigeoN1Local.Validating
        If CmbubigeoN1Local.Text = "" Then
            FaltaDatos.SetError(CmbubigeoN1Local, "Dato Obligatorio")
        Else
            FaltaDatos.SetError(CmbubigeoN1Local, "")
        End If

    End Sub

    Private Sub CmbubigeoN3Local_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbubigeoN3Local.SelectedIndexChanged

    End Sub

    Private Sub CmbubigeoN2Local_Validating(sender As Object, e As CancelEventArgs) Handles CmbubigeoN2Local.Validating
        If CmbubigeoN2Local.Text = "" Then
            FaltaDatos.SetError(CmbubigeoN2Local, "Dato Obligatorio")
        Else
            FaltaDatos.SetError(CmbubigeoN2Local, "")
        End If

    End Sub

    Private Sub TxtRefLocal_TextChanged(sender As Object, e As EventArgs) Handles TxtRefLocal.TextChanged

    End Sub

    Private Sub CmbubigeoN3Local_Validating(sender As Object, e As CancelEventArgs) Handles CmbubigeoN3Local.Validating
        If CmbubigeoN3Local.Text = "" Then
            FaltaDatos.SetError(CmbubigeoN3Local, "Dato Obligatorio")
        Else
            FaltaDatos.SetError(CmbubigeoN3Local, "")
        End If
    End Sub

    Private Sub CmbActivaCambioGPS_Click(sender As Object, e As EventArgs) Handles CmbActivaCambioGPS.Click
        If Strings.Left(CmbActivaCambioGPS.Text, 2) = "&C" Then
            CmbActivaCambioGPS.Text = "&Retorna Ubicación"
            CmbActivaCambioGPS.IconChar = FontAwesome.Sharp.IconChar.MapMarked
            marker.ToolTipText = String.Format("Usa el Mouse " & vbCrLf & "para ubicar el nuevo GPS.")
            marker.Position = New PointLatLng(temp_lat.Text, temp_lon.Text)
            Flag_ModifoMapa = 0

        Else
            CmbActivaCambioGPS.IconChar = FontAwesome.Sharp.IconChar.MapMarker
            CmbActivaCambioGPS.Text = "&Cambia Ubicación"
            marker.Position = New PointLatLng(temp_lat.Text, temp_lon.Text)
            marker.ToolTipText = String.Format("Ubicacion :" & vbCrLf & "Lat : {0} " & vbCrLf & " Lon : {1}", temp_lat.Text, temp_lon.Text)
            GMapControl1.DragButton = MouseButtons.Left
            GMapControl1.CanDragMap = True
            GMapControl1.MapProvider = GMapProviders.GoogleMap
            GMapControl1.Position = New PointLatLng(temp_lat.Text, temp_lon.Text)
            GMapControl1.MinZoom = 0
            GMapControl1.MaxZoom = 25
            GMapControl1.Zoom = 10
            GMapControl1.AutoScroll = True
            Flag_ModifoMapa = 1

        End If

    End Sub

    Private Sub TxtRefLocal_Validating(sender As Object, e As CancelEventArgs) Handles TxtRefLocal.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio.")
    End Sub

    Private Sub DGLocales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGLocales.CellContentClick

    End Sub

    Private Sub DGLocales_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGLocales.CellClick
        Dim ws_IdLocal As Integer
        Dim ws_IdIndex As Integer

        If DGLocales.Rows.Count = 0 Then Exit Sub
        LimpiaLocales()
        ' Muestra los datos para Editarlo 
        DGAlmacenes.Rows.Clear()
        PanelCentral.Visible = False
        PanelCentral.Dock = DockStyle.None
        PanelCreaNegocio.Visible = True
        PanelCreaNegocio.Top = 50
        PanelCreaNegocio.Left = 310
        westadoFotoSubir = "0"
        wsfor_numerodigitos = lk_sql_ListaTipoDocPersona.Rows(CmbTipoDoc.SelectedIndex).Item("digitos").ToString
        '  LimpiaNegocio()
        ws_IdLocal = DGLocales.Rows(e.RowIndex).Cells(2).Value
        id_Local.Text = ws_IdLocal ' lo guardo en pantalla para Actuzlair 
        Id_Local_alm.Text = ws_IdLocal
        For i = 0 To lk_sql_ListaLocales.Rows.Count - 1
            If lk_sql_ListaLocales.Rows(i).Item("id_local").ToString = ws_IdLocal Then
                ws_IdIndex = i
                Exit For
            End If
        Next

        TxtNombreComercialLocal.Text = lk_sql_ListaLocales.Rows(ws_IdIndex).Item("nombre").ToString
        TxtAbreviadoLocal.Text = lk_sql_ListaLocales.Rows(ws_IdIndex).Item("nombreabreviado").ToString
        txtkey_local.Enabled = False
        txtkey_local.Text = "****"
        TxtCodigoLocal.Text = lk_sql_ListaLocales.Rows(ws_IdIndex).Item("codigo").ToString
        TxtDireccionLocal.Text = lk_sql_ListaLocales.Rows(ws_IdIndex).Item("direccion").ToString

        TxtTelefonosLocal.Text = lk_sql_ListaLocales.Rows(ws_IdIndex).Item("telefonos").ToString
        TxtCorreoLocal.Text = lk_sql_ListaLocales.Rows(ws_IdIndex).Item("correo").ToString




        TxtRefLocal.Text = lk_sql_ListaLocales.Rows(ws_IdIndex).Item("referencia").ToString
        LblLocalRef.Text = lk_sql_ListaLocales.Rows(ws_IdIndex).Item("nombre").ToString
        Dim wsindexcambo As Integer



        For i = 0 To CmbTipoLocal.Items.Count - 1
            If lk_sql_ListaLocales.Rows(ws_IdIndex).Item("id_tb_tipolocal").ToString = Trim(Strings.Right(CmbTipoLocal.Items(i).ToString, 20)) Then
                wsindexcambo = i
                Exit For
            End If
        Next
        If CmbTipoLocal.Items.Count > 0 Then
            CmbTipoLocal.SelectedIndex = wsindexcambo
        End If

        For i = 0 To CmbTipoPropiedad.Items.Count - 1
            If lk_sql_ListaLocales.Rows(ws_IdIndex).Item("id_tb_propiedad").ToString = Trim(Strings.Right(CmbTipoPropiedad.Items(i).ToString, 20)) Then
                wsindexcambo = i
                Exit For
            End If
        Next
        If CmbTipoPropiedad.Items.Count > 0 Then
            CmbTipoPropiedad.SelectedIndex = wsindexcambo
        End If

        AsignaUBIGEO(CmbubigeoN1Local, CmbubigeoN2Local, CmbubigeoN3Local, lk_sql_ListaLocales.Rows(ws_IdIndex).Item("id_ubigeo_n1").ToString, lk_sql_ListaLocales.Rows(ws_IdIndex).Item("id_ubigeo_n2").ToString, lk_sql_ListaLocales.Rows(ws_IdIndex).Item("id_ubigeo_n3").ToString)
        CmdAddLocal.Text = "&Actualizar"

        id_Local.Text = lk_sql_ListaLocales.Rows(ws_IdIndex).Item("id_local").ToString


        Dim wpunto_lat As String = lk_sql_ListaLocales.Rows(ws_IdIndex).Item("lat").ToString
        Dim wpunto_lon As String = lk_sql_ListaLocales.Rows(ws_IdIndex).Item("lon").ToString
        If lk_sql_ListaLocales.Rows(ws_IdIndex).Item("fotolocal_local").ToString = "-" Then
            FotoLocal.Image = lk_sql_ListaLocales.Rows(ws_IdIndex).Item("fotolocal_local_Defecto")
            file.FileName = "-"
            westadoFotoSubir = "0"
        Else
            FotoLocal.Image = Image.FromFile(lk_sql_ListaLocales.Rows(ws_IdIndex).Item("fotolocal_local"))
        End If



        temp_lon.Text = wpunto_lon
        temp_lat.Text = wpunto_lat
        punto_lat = wpunto_lat
        punto_lon = wpunto_lon
        marker.Position = New PointLatLng(wpunto_lat, wpunto_lon)
        marker.ToolTipText = String.Format("Ubicacion :" & vbCrLf & "Lat : {0} " & vbCrLf & " Lon : {1}", wpunto_lat, wpunto_lon)
        GMapControl1.DragButton = MouseButtons.Left
        GMapControl1.CanDragMap = True
        GMapControl1.MapProvider = GMapProviders.GoogleMap
        GMapControl1.Position = New PointLatLng(wpunto_lat, wpunto_lon)
        GMapControl1.MinZoom = 0
        GMapControl1.MaxZoom = 25
        GMapControl1.Zoom = 10
        GMapControl1.AutoScroll = True

        CmbActivaCambioGPS.IconChar = FontAwesome.Sharp.IconChar.MapMarker
        CmbActivaCambioGPS.Text = "&Cambia Ubicación"
        Flag_ModifoMapa = 1
        CmbActivaCambioGPS.Enabled = True
        ' Muestra los datos para Editarlo 
        PanelCentral.Visible = False
        PanelCreaNegocio.Visible = False
        PanelCentral.Dock = DockStyle.None


        PanelLocales.Visible = True
        PanelLocales.Top = 50
        PanelLocales.Left = 300
        Flag_ModifoMapa = 1
        LblLocalRef.Text = lk_sql_ListaLocales.Rows(ws_IdIndex).Item("nombre").ToString
        llena_lista_Almacenes(ws_IdLocal)
        If lk_sql_ListaAlmacenes.Rows.Count = 0 Then ' Forzar que cree su primer almacen
            CmdCreaAlmacen_Click(Nothing, Nothing)

        Else
            ' Muestra los datos para Editarlo 
            PanelCentral.Visible = False
            PanelCreaNegocio.Visible = False
            PanelAlmacen.Visible = False
            PanelLocales.Visible = True
            PanelCentral.Dock = DockStyle.None
        End If


    End Sub
    Private Sub llena_lista_Almacenes(ws_idlocal As String)

        Dim result
        'Id_NegocioLocal.Text = ws_idlocal
        '  If lk_api_ListaNegocios Is Nothing Then

        Dim command As SqlCommand = New SqlCommand("n_lista_neg_almacen", lk_connection_master)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@id", ws_idlocal)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        lk_sql_ListaAlmacenes = New DataTable
        lk_sql_ListaAlmacenes.Columns.Clear()
        adapter.Fill(lk_sql_ListaAlmacenes)
        Dim tempColumn As DataColumn = New DataColumn("fotoalmacen_local", GetType(String))
        Dim tempColumn2 As DataColumn = New DataColumn("fotoalmacen_local_Defecto", GetType(Bitmap))
        lk_sql_ListaAlmacenes.Columns.Add(tempColumn)
        lk_sql_ListaAlmacenes.Columns.Add(tempColumn2)




        'Dim parametroneg = New List(Of Parametro) From {
        '     New Parametro("id_local", ws_idlocal)
        '     }

        'Dim responseneg = MuestraDataApi(lk_api_cadena_base + "negocio/almacen/listar", parametroneg) ' respuesta : vps_Usaurios
        'Try
        'lk_api_ListaAlmacenes = JsonConvert.DeserializeObject(Of JsonListaAlmacenes)(responseneg) 'Cái truyền tên Class vào
        'If lk_api_ListaAlmacenes.estado = True Then
        For I = 0 To lk_sql_ListaAlmacenes.Rows.Count - 1
            If lk_sql_ListaAlmacenes.Rows(I).Item("fotoalmacen").ToString = "-" Then
                lk_sql_ListaAlmacenes.Rows(I).Item("fotoalmacen_local_Defecto") = My.Resources.alma
                lk_sql_ListaAlmacenes.Rows(I).Item("fotoalmacen_local") = "-"
            Else
                Dim wRutaLocalfile As String = lk_Carpeta_Temp & System.IO.Path.GetFileName(lk_sql_ListaAlmacenes.Rows(I).Item("fotoalmacen").ToString)
                If System.IO.File.Exists(wRutaLocalfile) Then

                Else
                    CLIENTE.DownloadFile(New Uri(lk_sql_ListaAlmacenes.Rows(I).Item("fotoalmacen").ToString), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                End If
                lk_sql_ListaAlmacenes.Rows(I).Item("fotoalmacen_local") = wRutaLocalfile
            End If
        Next

        '   End If
        'Catch ex As Exception
        '    Exit Sub
        'End Try

        If lk_sql_ListaAlmacenes.Rows.Count = 0 Then
            result = MensajesBox.Show("Todavia no a creado sus Almacenes para el Local." & Chr(13) & "Ingrese la Informacion de su Almacen. ",
                                           "Crear Almacen")
            GoTo NoIngresa
        End If


        MUESTRA_ALMACENES()



        Exit Sub
NoIngresa:

    End Sub
    Private Sub MUESTRA_ALMACENES()
        Dim FOTODEFECTO = My.Resources.alma
        DGAlmacenes.Rows.Clear()
        For I = 0 To lk_sql_ListaAlmacenes.Rows.Count - 1
            DGAlmacenes.Rows.Add()
            DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(0).Value = Trim(lk_sql_ListaAlmacenes.Rows(I).Item("nombreabreviado").ToString & vbCrLf & "CODIGO : " & Trim(lk_sql_ListaAlmacenes.Rows(I).Item("codigo").ToString) & vbCrLf & Trim(lk_sql_ListaAlmacenes.Rows(I).Item("nombre").ToString))
            If lk_sql_ListaAlmacenes.Rows(I).Item("fotoalmacen_local").ToString = "-" Then
                DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(1).Value = lk_sql_ListaAlmacenes.Rows(I).Item("fotoalmacen_local_Defecto")
            Else
                DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(1).Value = Image.FromFile(lk_sql_ListaAlmacenes.Rows(I).Item("fotoalmacen_local").ToString)
            End If

            DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Cells(2).Value = Trim(lk_sql_ListaAlmacenes.Rows(I).Item("id_almacen").ToString)

            DGAlmacenes.Columns(0).Width = 210
            DGAlmacenes.Columns(1).Width = 210
            DGAlmacenes.Columns(2).Width = 0
            DGAlmacenes.Columns(2).Visible = False
            DGAlmacenes.Rows(DGAlmacenes.Rows.Count - 1).Height = 60


        Next
    End Sub

    Private Sub CmdSubirFotoLocal_Click(sender As Object, e As EventArgs) Handles CmdSubirFotoLocal.Click
        Dim ws_fotolocal As String
        westadoFotoSubir = "0"
        file.Filter = "Archivo JPG|*.bmp;*.jpg;*.png"
        If file.ShowDialog() = DialogResult.OK Then
            file.FileName = StrConv(file.FileName, vbLowerCase)
            ws_fotolocal = AjustarImagen(file.FileName)

            file.FileName = ws_fotolocal
            FotoLocal.Image = Image.FromFile(file.FileName)
            Redondeaimagen(FotoLocal)
            westadoFotoSubir = "2"
        End If
    End Sub

    Private Sub CmdQuitarFotoLocal_Click(sender As Object, e As EventArgs) Handles CmdQuitarFotoLocal.Click
        FotoLocal.Image = My.Resources.local
        file.FileName = "X"
        westadoFotoSubir = "0"
    End Sub

    Private Sub TxtCodigoLocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCodigoLocal.KeyPress
        e.Handled = Solo_Numero(e)
    End Sub

    Private Sub DGNegocios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGNegocios.CellContentClick

    End Sub

    Private Sub CmdSubirFotoAlmacen_Click(sender As Object, e As EventArgs) Handles CmdSubirFotoAlmacen.Click
        Dim ws_fotolocal As String
        westadoFotoSubir = "0"
        file.Filter = "Archivo JPG|*.bmp;*.jpg;*.png"
        If file.ShowDialog() = DialogResult.OK Then
            file.FileName = StrConv(file.FileName, vbLowerCase)
            ws_fotolocal = AjustarImagen(file.FileName)

            file.FileName = ws_fotolocal
            FotoAlmacen.Image = Image.FromFile(file.FileName)
            Redondeaimagen(FotoLocal)
            westadoFotoSubir = "2"
        End If
    End Sub

    Private Sub CmdQuitarFotoAlmacen_Click(sender As Object, e As EventArgs) Handles CmdQuitarFotoAlmacen.Click
        FotoAlmacen.Image = My.Resources.alma
        file.FileName = "X"
        westadoFotoSubir = "0"
    End Sub

    Private Sub PanelLocales_Paint(sender As Object, e As PaintEventArgs) Handles PanelLocales.Paint

    End Sub

    Private Sub CmbUbigeoN1Almacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbUbigeoN1Almacen.SelectedIndexChanged
        CmbUbigeoN2Almacen.Items.Clear()
        If CmbUbigeoN1Almacen.SelectedIndex = -1 Then Exit Sub
        For i = 0 To lk_sql_ListaUbigeoN2.Rows.Count - 1
            If lk_sql_ListaUbigeoN2.Rows(i).Item("id_ubigeo_n1").ToString = lk_sql_ListaUbigeoN1.Rows(CmbUbigeoN1Almacen.SelectedIndex).Item("id_ubigeo_n1").ToString Then
                CmbUbigeoN2Almacen.Items.Add(lk_sql_ListaUbigeoN2.Rows(i).Item("descripcion").ToString & Space(80) & lk_sql_ListaUbigeoN2.Rows(i).Item("id_ubigeo_n2").ToString) ' & Space(80) & lk_api_TipoDocPersona.data(i).id
            End If
        Next
        CmbUbigeoN3Almacen.Items.Clear()
    End Sub

    Private Sub CmbUbigeoN2Almacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbUbigeoN2Almacen.SelectedIndexChanged
        CmbUbigeoN3Almacen.Items.Clear()

        For i = 0 To lk_sql_ListaUbigeoN3.Rows.Count - 1
            If lk_sql_ListaUbigeoN3.Rows(i).Item("id_ubigeo_n2").ToString = Trim(Strings.Right(CmbUbigeoN2Almacen.Text, 10)) Then
                CmbUbigeoN3Almacen.Items.Add(lk_sql_ListaUbigeoN3.Rows(i).Item("descripcion").ToString & Space(80) & lk_sql_ListaUbigeoN3.Rows(i).Item("id_ubigeo_n3").ToString)
            End If
        Next
    End Sub

    Private Sub DGAlmacenes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGAlmacenes.CellContentClick

    End Sub

    Private Sub DGNegocios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGNegocios.CellClick
        Dim ws_IdNegocio As Integer
        Dim ws_IdIndex As Integer


        If DGNegocios.Rows.Count = 0 Then Exit Sub

        DGLocales.Rows.Clear()
        DGAlmacenes.Rows.Clear()
        westadoFotoSubir = "0"
        wsfor_numerodigitos = lk_sql_ListaTipoDocPersona.Rows(CmbTipoDoc.SelectedIndex).Item("digitos").ToString
        LimpiaNegocio()
        lk_api_ListaLocales = Nothing
        FotoLocal.Image = My.Resources.local
        file.FileName = "-"
        westadoFotoSubir = "0"

        ws_IdNegocio = DGNegocios.Rows(e.RowIndex).Cells(2).Value
        Id_Negocio.Text = ws_IdNegocio ' lo guardo en pantalla para Actuzlair 
        For i = 0 To lk_sql_Usuario_negocio.Rows.Count - 1
            If lk_sql_Usuario_negocio.Rows(i).Item("id_negocio").ToString = ws_IdNegocio Then
                ws_IdIndex = i
                Exit For
            End If

        Next
        TxtNroRegistro.Text = lk_sql_Usuario_negocio.Rows(ws_IdIndex).Item("neg_numerodoc").ToString
        txtNombreNeg.Text = lk_sql_Usuario_negocio.Rows(ws_IdIndex).Item("neg_nombre").ToString
        TxtNombreComercial.Text = lk_sql_Usuario_negocio.Rows(ws_IdIndex).Item("neg_abreviado").ToString
        LblNegocioRef.Text = lk_sql_Usuario_negocio.Rows(ws_IdIndex).Item("neg_nombre").ToString
        TxtDirecNego.Text = lk_sql_Usuario_negocio.Rows(ws_IdIndex).Item("direccion").ToString
        TxtRefNego.Text = lk_sql_Usuario_negocio.Rows(ws_IdIndex).Item("referencia").ToString
        For i = 0 To CmbTipoDoc.Items.Count - 1
            If lk_sql_ListaTipoDocPersona.Rows(i).Item("id_tipodoc").ToString = lk_sql_Usuario_negocio.Rows(ws_IdIndex).Item("id_tipdoc").ToString Then
                CmbTipoDoc.SelectedIndex = i
                Exit For
            End If
        Next
        AsignaUBIGEO(CmbubigeoN1Neg, CmbubigeoN2Neg, CmbubigeoN3Neg, lk_sql_Usuario_negocio.Rows(ws_IdIndex).Item("id_ubigeo_n1").ToString, lk_sql_Usuario_negocio.Rows(ws_IdIndex).Item("id_ubigeo_n2").ToString, lk_sql_Usuario_negocio.Rows(ws_IdIndex).Item("id_ubigeo_n3").ToString)

        LblEtiquetaNegocio.Text = "Negocio: ID[" & ws_IdNegocio & "] " & lk_sql_Usuario_negocio.Rows(ws_IdIndex).Item("neg_nombre").ToString
        CmdAddNegocio.Text = "&Actualizar"
        If lk_sql_Usuario_negocio.Rows(ws_IdIndex).Item("fotonegociolocal").ToString = "-" Then
            FotoNegocio.Image = My.Resources.negocio
        Else
            FotoNegocio.Image = Image.FromFile(lk_sql_Usuario_negocio.Rows(ws_IdIndex).Item("fotonegociolocal").ToString)
        End If

        Id_NegocioLocal.Text = ws_IdNegocio
        llena_Lista_Locales(ws_IdNegocio)
        If lk_sql_ListaLocales.Rows.Count = 0 Then ' Forzar que cree su primer local
            CmdCreaLocales_Click(Nothing, Nothing)

        Else
            ' Muestra los datos para Editarlo 
            PanelCentral.Visible = False
            PanelLocales.Visible = False
            PanelAlmacen.Visible = False
            PanelCentral.Dock = DockStyle.None
            PanelCreaNegocio.Visible = True
            PanelCreaNegocio.Top = 50
            PanelCreaNegocio.Left = 310
        End If
    End Sub

    Private Sub TxtCodigoAlmacen_TextChanged(sender As Object, e As EventArgs) Handles TxtCodigoAlmacen.TextChanged

    End Sub

    Private Sub DGAlmacenes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGAlmacenes.CellClick
        Dim ws_Id_Almacen As Integer
        Dim ws_IdIndex As Integer

        If DGAlmacenes.Rows.Count = 0 Then Exit Sub
        LimpiaAlmacen()
        ' Muestra los datos para Editarlo 
        PanelCentral.Visible = False
        PanelCentral.Dock = DockStyle.None
        PanelCreaNegocio.Visible = True


        westadoFotoSubir = "0"


        ws_Id_Almacen = DGAlmacenes.Rows(e.RowIndex).Cells(2).Value

        Id_Almacen.Text = ws_Id_Almacen ' lo guardo en pantalla para Actuzlair 

        For i = 0 To lk_sql_ListaAlmacenes.Rows.Count - 1
            If lk_sql_ListaAlmacenes.Rows(i).Item("id_almacen").ToString = ws_Id_Almacen Then
                ws_IdIndex = i
                Exit For
            End If
        Next

        TxtNombreAlmacen.Text = lk_sql_ListaAlmacenes.Rows(ws_IdIndex).Item("nombre").ToString
        TtxtAbreviadoAlmacen.Text = lk_sql_ListaAlmacenes.Rows(ws_IdIndex).Item("nombreabreviado").ToString
        TxtCodigoAlmacen.Text = lk_sql_ListaAlmacenes.Rows(ws_IdIndex).Item("codigo").ToString
        TxtDireccionAlmacen.Text = lk_sql_ListaAlmacenes.Rows(ws_IdIndex).Item("direccion").ToString
        TxtRefAlmacen.Text = lk_sql_ListaAlmacenes.Rows(ws_IdIndex).Item("referencia").ToString

        Dim wsindexcambo As Integer



        For i = 0 To CmbTipoAlmacen.Items.Count - 1
            If lk_sql_ListaAlmacenes.Rows(ws_IdIndex).Item("id_tb_tipoalm").ToString = Trim(Strings.Right(CmbTipoAlmacen.Items(i).ToString, 20)) Then
                wsindexcambo = i
                Exit For
            End If
        Next
        If CmbTipoAlmacen.Items.Count > 0 Then
            CmbTipoAlmacen.SelectedIndex = wsindexcambo
        End If

        AsignaUBIGEO(CmbUbigeoN1Almacen, CmbUbigeoN2Almacen, CmbUbigeoN3Almacen, lk_sql_ListaAlmacenes.Rows(ws_IdIndex).Item("id_ubigeo_n1").ToString, lk_sql_ListaAlmacenes.Rows(ws_IdIndex).Item("id_ubigeo_n2").ToString, lk_sql_ListaAlmacenes.Rows(ws_IdIndex).Item("id_ubigeo_n3").ToString)
        CmdAddAlmacen.Text = "&Actualizar"

        Id_Almacen.Text = lk_sql_ListaAlmacenes.Rows(ws_IdIndex).Item("id_almacen").ToString

        If lk_sql_ListaAlmacenes.Rows(ws_IdIndex).Item("fotoalmacen_local").ToString = "-" Then
            FotoAlmacen.Image = lk_sql_ListaAlmacenes.Rows(ws_IdIndex).Item("fotoalmacen_local_Defecto")
            file.FileName = "-"
            westadoFotoSubir = "0"
        Else
            FotoAlmacen.Image = Image.FromFile(lk_sql_ListaAlmacenes.Rows(ws_IdIndex).Item("fotoalmacen_local"))
        End If


        ' Muestra los datos para Editarlo 
        PanelCentral.Visible = False
        PanelCreaNegocio.Visible = False
        PanelCentral.Dock = DockStyle.None
        PanelLocales.Visible = False
        PanelAlmacen.Visible = True
        PanelAlmacen.Top = 50
        PanelAlmacen.Left = 300
    End Sub

    Private Sub TxtNombreAlmacen_TextChanged(sender As Object, e As EventArgs) Handles TxtNombreAlmacen.TextChanged

    End Sub

    Private Sub TxtCodigoAlmacen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCodigoAlmacen.KeyPress
        e.Handled = Solo_Numero(e)
    End Sub

    Private Sub TtxtAbreviadoAlmacen_TextChanged(sender As Object, e As EventArgs) Handles TtxtAbreviadoAlmacen.TextChanged

    End Sub

    Private Sub TxtNombreAlmacen_Validating(sender As Object, e As CancelEventArgs) Handles TxtNombreAlmacen.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio")
    End Sub

    Private Sub TtxtAbreviadoAlmacen_Validating(sender As Object, e As CancelEventArgs) Handles TtxtAbreviadoAlmacen.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio")
    End Sub

    Private Sub TxtDireccionAlmacen_TextChanged(sender As Object, e As EventArgs) Handles TxtDireccionAlmacen.TextChanged

    End Sub

    Private Sub TxtCodigoAlmacen_Validating(sender As Object, e As CancelEventArgs) Handles TxtCodigoAlmacen.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio")
    End Sub

    Private Sub TxtDireccionAlmacen_Validating(sender As Object, e As CancelEventArgs) Handles TxtDireccionAlmacen.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio")
    End Sub

    Private Sub CmbUbigeoN1Almacen_Validating(sender As Object, e As CancelEventArgs) Handles CmbUbigeoN1Almacen.Validating
        If Trim(CmbUbigeoN1Almacen.Text) = "" Then
            FaltaDatos.SetError(sender, "Debe indicar: Departamento")
        Else
            FaltaDatos.SetError(sender, "")
        End If
    End Sub

    Private Sub CmbUbigeoN3Almacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbUbigeoN3Almacen.SelectedIndexChanged

    End Sub

    Private Sub CmbUbigeoN2Almacen_Validated(sender As Object, e As EventArgs) Handles CmbUbigeoN2Almacen.Validated
        If Trim(CmbUbigeoN2Almacen.Text) = "" Then
            FaltaDatos.SetError(sender, "Debe indicar: Provincia")
        Else
            FaltaDatos.SetError(sender, "")
        End If
    End Sub

    Private Sub TxtRefAlmacen_TextChanged(sender As Object, e As EventArgs) Handles TxtRefAlmacen.TextChanged

    End Sub

    Private Sub CmbUbigeoN3Almacen_Validated(sender As Object, e As EventArgs) Handles CmbUbigeoN3Almacen.Validated
        If Trim(CmbUbigeoN3Almacen.Text) = "" Then
            FaltaDatos.SetError(sender, "Debe indicar: Distrito")
        Else
            FaltaDatos.SetError(sender, "")
        End If
    End Sub

    Private Sub CmbTipoAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoAlmacen.SelectedIndexChanged

    End Sub

    Private Sub TxtRefAlmacen_Validating(sender As Object, e As CancelEventArgs) Handles TxtRefAlmacen.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio")
    End Sub

    Private Sub CmdPermisos_Click(sender As Object, e As EventArgs) Handles CmdPermisos.Click
        If lk_NegocioActivo.id_Negocio = 0 Then
            Dim result = MensajesBox.Show("No puede dar accesos, no cuenta con negocio Propio.", lk_cabeza_msgbox)
            Exit Sub
        End If
        Dim frPermisoUsuarios As New FrmPermisoUsuario
        PlaySonidoMouse(lk_CodigoSonido)
        'frPermisoUsuarios.Width = 950
        frPermisoUsuarios.Top = Me.Top - 20
        frPermisoUsuarios.Left = Me.Left - 20
        frPermisoUsuarios.ShowDialog()

    End Sub

    Private Sub CmdConfLocal_Click(sender As Object, e As EventArgs) Handles CmdConfLocal.Click
        If lk_NegocioActivo.id_Negocio = 0 Then
            Dim result = MensajesBox.Show("No puede dar accesos, no cuenta con negocio Propio.", lk_cabeza_msgbox)
            Exit Sub
        End If
        Dim frConfig As New FrmConfLocal
        frConfig.Seleccion_id_local = Val(id_Local.Text)
        frConfig.Seleccion_id_Negocio = Val(Id_NegocioLocal.Text)
        PlaySonidoMouse(lk_CodigoSonido)
        'frPermisoUsuarios.Width = 950

        frConfig.ShowDialog()
        Carga_Paramtros_Generales()

    End Sub

    Private Sub CmbTipoAlmacen_Validating(sender As Object, e As CancelEventArgs) Handles CmbTipoAlmacen.Validating
        If CmbTipoAlmacen.Text = "" Then
            FaltaDatos.SetError(CmbTipoAlmacen, "Debe indicar Tipo de Almacen")
        Else
            FaltaDatos.SetError(CmbTipoAlmacen, "")
        End If
    End Sub




End Class
