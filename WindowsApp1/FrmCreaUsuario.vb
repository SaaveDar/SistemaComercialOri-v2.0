Imports System.Drawing, System.Drawing.Drawing2D
Imports System.Web
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports FontAwesome.Sharp
Imports Newtonsoft.Json
Imports WindowsApp1.AgregarUsuario
Imports WindowsApp1.ListaTipoDocPersona
Imports WindowsApp1.RepiteUsuario
Imports WindowsApp1.ListaUsuarios
Imports WindowsApp1.EnviaSMS
Imports WindowsApp1.ModificaUsuario
Imports System.Data.SqlClient
Imports System.Net
Imports System.IO
Imports RestSharp.Extensions.MonoHttp
Imports System.Text
Imports System.Net.Http
Imports System.Threading

Public Class FrmCreaUsuario
    Dim wsVarSegundos As Integer
    Dim wVarListaPais As String()
    Dim wsfor_numerodigitos As Integer

    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
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

    Private Sub TxtUsuario_TextChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub FrmCreaUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'CmdEnvioSMS.IconChar = FontAwesome.Sharp.IconChar.Sms
        wsfor_numerodigitos = 15
        'If lk_api_ListaTipoDocPersona Is Nothing Then
        'Else
        '    For i As Integer = 0 To lk_api_ListaTipoDocPersona.data.Count - 1
        '        CmbTipoDocUsuario.Items.Add(lk_api_ListaTipoDocPersona.data(i).descripcion + Space(80) + lk_api_ListaTipoDocPersona.data(i).id)
        '    Next
        '    CmbTipoDocUsuario.SelectedIndex = 0
        '    wsfor_numerodigitos = lk_api_ListaTipoDocPersona.data(0).digitos
        'End If


        wVarListaPais = {"Peru (+51)"} 'ARRAY ELEMENTOS EN EL MISMO ORDEN QUE EL IMAGELIST
        CmbListaPais.Items.AddRange(wVarListaPais)
        CmbListaPais.DrawMode = DrawMode.OwnerDrawVariable 'PARA PODER PONER NUESTRAS IMAGENES
        CmbListaPais.DropDownStyle = ComboBoxStyle.DropDownList 'PARA QUE EN EL TEXTO APAREZCA LA IMAGEN Y EL TEXTO
        CmbListaPais.DropDownHeight = 200 'PARA QUE MUESTRE TODOS LOS ELEMENTOS. DEPENDE DEL NUMERO DE ELEMENTOS Y SU ALTURA
        CmbListaPais.SelectedIndex = 0

        CmbListaPaisOlvido.Items.AddRange(wVarListaPais)
        CmbListaPaisOlvido.DrawMode = DrawMode.OwnerDrawVariable 'PARA PODER PONER NUESTRAS IMAGENES
        CmbListaPaisOlvido.DropDownStyle = ComboBoxStyle.DropDownList 'PARA QUE EN EL TEXTO APAREZCA LA IMAGEN Y EL TEXTO
        CmbListaPaisOlvido.DropDownHeight = 200 'PARA QUE MUESTRE TODOS LOS ELEMENTOS. DEPENDE DEL NUMERO DE ELEMENTOS Y SU ALTURA
        CmbListaPaisOlvido.SelectedIndex = 0

        If lk_sql_ListaTipoDocPersona.Rows.Count = 0 Then
            Dim command As SqlCommand = New SqlCommand("u_obtenerTipoDoc", lk_connection_master)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            adapter.Fill(lk_sql_ListaTipoDocPersona)
        End If
        ' Iterate through the list.
        CmbTipoDocUsuario.Items.Clear()
        For i = 0 To lk_sql_ListaTipoDocPersona.Rows.Count - 1
            CmbTipoDocUsuario.Items.Add(lk_sql_ListaTipoDocPersona.Rows(i).Item("descripcion").ToString) ' & Space(80) & lk_api_TipoDocPersona.data(i).id
        Next
        CmbTipoDocUsuario.SelectedIndex = 0
        Panel1.Dock = DockStyle.Fill
        Panel2.Dock = DockStyle.Fill
        Panel3.Dock = DockStyle.Fill
        PanelOlvidoContrasena.Dock = DockStyle.Fill



        Exit Sub
NoIngresa:


    End Sub

    Private Sub CmdSiguiente_Click(sender As Object, e As EventArgs) Handles CmdSiguiente.Click
        Dim result
        ' If lk_api_TipoDocPersona Is Nothing Then
        If (txtContrasena.Text <> TxtRepitaContrasena.Text) Or txtContrasena.Text = "" Then
            FaltaDatos.SetError(txtContrasena, "Contraseña NO Coinciden.")
            ' result = MensajesBox.Show("Verificar las Contraseñas.",
            '                                "Creación de Usaurio")
            GoTo NoIngresa
        Else
            FaltaDatos.SetError(txtContrasena, "")
        End If
        If Len(Trim(txtContrasena.Text)) < 6 Then
            FaltaDatos.SetError(txtContrasena, "Longitud de contraseña, mayor o igual de 6 digitos.")
            GoTo NoIngresa
        Else
            FaltaDatos.SetError(txtContrasena, "")

        End If

        If TxtUsuario.Text = "" Then
            FaltaDatos.SetError(TxtUsuario, "Debe Ingresar Nombre de Usuario.")
            GoTo NoIngresa
        Else
            FaltaDatos.SetError(TxtUsuario, "")
        End If

        If TxtNumero.Text = "" Then
            FaltaDatos.SetError(TxtNumero, "Debe Ingresar Numero de Documento.")
            GoTo NoIngresa
        Else
            FaltaDatos.SetError(TxtNumero, "")
        End If
        If Len(TxtNumero.Text) <> wsfor_numerodigitos Then
            FaltaDatos.SetError(TxtNumero, "Debe indicar " & wsfor_numerodigitos & " Digitos para el Numero")
            GoTo NoIngresa
        Else
            FaltaDatos.SetError(TxtNumero, "")
        End If

        If TxtNombres.Text = "" Or Len(TxtNombres.Text) <= 3 Then
            FaltaDatos.SetError(TxtNombres, "Debe Ingresar Nombres Completos o no menor de 3 letras.")
            GoTo NoIngresa
        Else
            FaltaDatos.SetError(TxtNombres, "")
        End If
        If TxtApellidos.Text = "" Or Len(TxtApellidos.Text) <= 3 Then
            FaltaDatos.SetError(TxtApellidos, "Debe Ingresar Apellidos Completos o no menor de 3 letras.")
            GoTo NoIngresa
        Else
            FaltaDatos.SetError(TxtApellidos, "")
        End If
        Dim ResulDataTable As New DataTable
        Dim command As SqlCommand = New SqlCommand("select  id_usuario from m_usuarios where  usuario = '" & TxtUsuario.Text & "'", lk_connection_master)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        adapter.Fill(ResulDataTable)

        If ResulDataTable.Rows.Count > 0 Then
            result = MensajesBox.Show("Usuario Existe, Intente con otro nombre.",
                                           "Creación de Usaurio")
            GoTo NoIngresa
        End If
        ''If  TxtUsuario.Text ="admin"
        'Dim parametro = New List(Of Parametro) From {
        '    New Parametro("usuario", TxtUsuario.Text)
        '    }
        'Dim response = MuestraDataApi(lk_api_cadena_base + "usuario/validar", parametro) ' respuesta : vps_Usaurios

        'lk_api_RepiteUsuario = JsonConvert.DeserializeObject(Of JsonRepiteUsuario)(response) 'Cái truyền tên Class vào



        'If lk_api_RepiteUsuario.estado Then
        '    result = MensajesBox.Show("Usuario Existe, Intente con otro nombre.",
        '                                   "Creación de Usaurio")
        '    GoTo NoIngresa
        'End If


        ' End If

        Panel1.Visible = False
        Panel2.Visible = True
        LblMensaje1.Text = TxtNombres.Text + ", vamos a verificar para crear tu usaurio: " + TxtUsuario.Text
        TxtNumeroCel.Focus()
        Exit Sub
NoIngresa:
    End Sub

    Private Sub CmdAceptarSMS_Click(sender As Object, e As EventArgs) Handles CmdAceptarSMS.Click
        Dim frmpadre As FrmLogin = CType(Owner, FrmLogin)
        frmpadre.ImagenInicio.Enabled = True
        frmpadre.PanelLeft.Enabled = True
        frmpadre.ImagenInicio.Visible = True
        Me.Close()
    End Sub

    Private Sub CmdCancelarCrear_Click(sender As Object, e As EventArgs) Handles CmdCancelarCrear.Click
        Dim frmpadre As FrmLogin = CType(Owner, FrmLogin)
        frmpadre.ImagenInicio.Enabled = True
        frmpadre.PanelLeft.Enabled = True
        frmpadre.PanelLeft.Visible = True
        frmpadre.ImagenInicio.Visible = True
        Me.Close()
    End Sub

    Private Sub CmdAtras_Click(sender As Object, e As EventArgs) Handles CmdAtras.Click
        Panel2.Visible = False
        Panel1.Visible = True


    End Sub

    Private Sub CmdEnvioSMS_Click(sender As Object, e As EventArgs) Handles CmdEnvioSMS.Click
        If Len(TxtNumeroCel.Text) = 9 Then
            FaltaDatos.SetError(TxtNumeroCel, "")
        Else
            FaltaDatos.SetError(TxtNumeroCel, "Tu numero de Celular debe Contener 9 digitos")
            Exit Sub
        End If


        TxtCodigoValida.Tag = ""



        Dim thread As New Thread(AddressOf ProcesoEnvioMensajeSMS)
        thread.Start()

        'Esperar hasta que el hilo de fondo haya terminado antes de continuar con otras operaciones
        thread.Join()



        CmdEnvioSMS.Enabled = False
        TiempoSMS.Enabled = True

        TxtNumeroCel.Enabled = False
        TxtCodigoValida.Visible = True
        LblCodigoValida.Visible = True
        LblEsperaSMS.Visible = True
        CmdAtras.Enabled = False
        CmdCancelarMensaje.Visible = True
        TxtCodigoValida.Text = ""
        TxtCodigoValida.Focus()
        Exit Sub
NoIngresa:
    End Sub
    Private Sub ProcesoEnvioMensajeSMS()
        Dim result
        Dim codigosms As String
        codigosms = GenerarCodigoSMS()
        wsVarSegundos = 10
        If LK_ACTIVA_SMS = "A" Then
            wsVarSegundos = 60
            result = EnviarSMSAltiria("gaplicasac@gmail.com", "cfhgmquy", "+51" & Trim(TxtNumeroCel.Text), "(Plataforma ORI) Codigo de Verificación: " & codigosms)
            If result <> "" Then
                result = MensajesBox.Show("SMS no se logro Enviar. intente nuevamente.",
                                           "Creación de Usaurio")
                Exit Sub
            End If
            LblCodigoValida.BeginInvoke(Sub() LblCodigoValida.Text = "&Codigo de Verificación.   ")

            'LblCodigoValida.Text = "&Codigo de Verificación.   " ' lk_api_EnvioSMS.data
        Else
            LblCodigoValida.BeginInvoke(Sub() LblCodigoValida.Text = "&Codigo de Verificación.   " & codigosms)
            'LblCodigoValida.Text = "&Codigo de Verificación.   " & codigosms ' lk_api_EnvioSMS.data
        End If
        'TxtCodigoValida.Tag = codigosms
        TxtCodigoValida.BeginInvoke(Sub() TxtCodigoValida.Tag = codigosms)


    End Sub
    Private Sub TiempoSMS_Tick(sender As Object, e As EventArgs) Handles TiempoSMS.Tick

        wsVarSegundos = wsVarSegundos - 1
        LblEsperaSMS.Text = "Pronto le llegara el Codigo de Validación en su celular..." & Format(wsVarSegundos, "00")
        If wsVarSegundos <= 0 Then
            LblEsperaSMS.Text = ""
            CmdREEnvioSMS.Visible = True
            TiempoSMS.Stop()
        End If
    End Sub

    Private Sub CmdCancelarMensaje_Click(sender As Object, e As EventArgs) Handles CmdCancelarMensaje.Click
        CmdEnvioSMS.Enabled = True
        TiempoSMS.Stop()
        wsVarSegundos = 0
        TxtNumeroCel.Enabled = True
        TxtCodigoValida.Visible = False
        LblCodigoValida.Visible = False
        LblEsperaSMS.Visible = False
        CmdAtras.Enabled = True
        CmdCancelarMensaje.Visible = False
        CmdREEnvioSMS.Visible = False

    End Sub

    Private Sub CmdREEnvioSMS_Click(sender As Object, e As EventArgs) Handles CmdREEnvioSMS.Click
        Call CmdEnvioSMS_Click(Nothing, Nothing)
        wsVarSegundos = 10
        TiempoSMS.Start()
        CmdREEnvioSMS.Visible = False
        TxtCodigoValida.Text = ""
        TxtCodigoValida.Focus()
    End Sub



    Private Sub CmdIngresoSistema_Click(sender As Object, e As EventArgs) Handles CmdIngresoSistema.Click
        Dim frmpadre As FrmLogin = CType(Owner, FrmLogin)
        frmpadre.ImagenInicio.Enabled = True
        frmpadre.PanelLeft.Enabled = True
        frmpadre.PanelLeft.Visible = True
        frmpadre.ImagenInicio.Visible = True
        Me.Close()
    End Sub
    Private Sub TxtApellidos_LostFocus(sender As Object, e As EventArgs) Handles TxtApellidos.LostFocus
        If Trim(TxtUsuario.Text) <> "" Then Exit Sub
        Dim iniciales As String = ""
        Dim NombreCompleto As String
        Dim lngPosicion As Integer
        lngPosicion = InStr(Trim(TxtNombres.Text), " ")
        If lngPosicion = 0 Then lngPosicion = Len(TxtNombres.Text)

        iniciales = Trim(Strings.Left(TxtNombres.Text, lngPosicion))


        NombreCompleto = Trim(TxtApellidos.Text)
        For Each txt As String In NombreCompleto.Split(" ")
            If Not String.IsNullOrEmpty(txt) Then
                iniciales = iniciales & Trim(txt.First)
            End If
        Next
        TxtUsuario.Text = iniciales
    End Sub

    Private Sub txtContrasena_TextChanged(sender As Object, e As EventArgs) Handles txtContrasena.TextChanged

    End Sub

    Private Sub TxtUsuario_Validating(sender As Object, e As CancelEventArgs) Handles TxtUsuario.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio: Nombre de Usuario")
    End Sub
    Private Sub TxtNumero_Validating(sender As Object, e As CancelEventArgs) Handles TxtNumero.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio: Numero de Documento")
        If Len(DirectCast(sender, TextBox).Text) <> wsfor_numerodigitos Then
            FaltaDatos.SetError(sender, "Debe indicar " & wsfor_numerodigitos & " Digitos para el Numero")
        Else
            FaltaDatos.SetError(sender, "")
        End If
    End Sub

    Private Sub TxtNombres_Validating(sender As Object, e As CancelEventArgs) Handles TxtNombres.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio: Nombres")
    End Sub

    Private Sub TxtApellidos_Validating(sender As Object, e As CancelEventArgs) Handles TxtApellidos.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Dato Obligatorio: Apellidos")
    End Sub

    Private Sub txtContrasena_Validating(sender As Object, e As CancelEventArgs) Handles txtContrasena.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "ingrese su Contraseña")
        If DirectCast(sender, TextBox).Text = TxtRepitaContrasena.Text Then
            FaltaDatos.SetError(sender, "")
            FaltaDatos.SetError(TxtRepitaContrasena, "")

        Else
            FaltaDatos.SetError(sender, "Contraseña NO Coinciden ")

        End If
    End Sub

    Private Sub TxtRepitaContrasena_TextChanged(sender As Object, e As EventArgs) Handles TxtRepitaContrasena.TextChanged

    End Sub

    Private Sub TxtRepitaContrasena_Validating(sender As Object, e As CancelEventArgs) Handles TxtRepitaContrasena.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Repita su Contraseña")

        If DirectCast(sender, TextBox).Text = txtContrasena.Text Then
            FaltaDatos.SetError(sender, "")
            FaltaDatos.SetError(txtContrasena, "")
        Else

            FaltaDatos.SetError(sender, "Contraseña NO Coinciden ")
        End If


    End Sub

    Private Sub TxtNumeroCel_TextChanged(sender As Object, e As EventArgs) Handles TxtNumeroCel.TextChanged

    End Sub

    Private Sub TxtNumeroCel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumeroCel.KeyPress
        e.Handled = Solo_Numero(e)
    End Sub

    Private Sub TxtNumero_TextChanged(sender As Object, e As EventArgs) Handles TxtNumero.TextChanged

    End Sub

    Private Sub TxtNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumero.KeyPress
        e.Handled = Solo_Numero(e)
    End Sub

    Private Sub TxtNombres_TextChanged(sender As Object, e As EventArgs) Handles TxtNombres.TextChanged

    End Sub

    Private Sub TxtNombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNombres.KeyPress
        e.Handled = Solo_Texto(e)
    End Sub

    Private Sub TxtApellidos_TextChanged(sender As Object, e As EventArgs) Handles TxtApellidos.TextChanged

    End Sub

    Private Sub TxtApellidos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtApellidos.KeyPress
        e.Handled = Solo_Texto(e)
    End Sub

    Private Sub TxtUsuario_TextChanged_1(sender As Object, e As EventArgs) Handles TxtUsuario.TextChanged

    End Sub

    Private Sub TxtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUsuario.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        Else
            e.Handled = False
        End If


        'If Not e.KeyChar().IsLetter(e.KeyChar) = True And Not IsNumeric(e.KeyChar()) = True And e.KeyChar <> ChrW(Keys.Back) Then
        '    e.Handled = True
        'Else
        '    e.Handled = False
        'End If
    End Sub

    Private Sub CmbListaPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbListaPais.SelectedIndexChanged

    End Sub

    Private Sub CmbListaPaiOlvido_DrawItem(sender As Object, e As DrawItemEventArgs) Handles CmbListaPais.DrawItem
        Try
            e.Graphics.DrawImage(ImagenesPaises.Images(e.Index), e.Bounds.Left, e.Bounds.Top) 'DIBUJA LA IMAGEN
            e.Graphics.DrawString(wVarListaPais(e.Index), CmbListaPais.Font, Brushes.Black, e.Bounds.Left + ImagenesPaises.ImageSize.Width + 10, e.Bounds.Top) 'DIBUJA EL TEXTO
        Catch ex As Exception
        End Try
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
    Private Sub TxtNumeroCel_Validating(sender As Object, e As CancelEventArgs) Handles TxtNumeroCel.Validating
        FaltaDAtosValidating(FaltaDatos, sender, "Numero de celular.")
        If Len(TxtNumeroCel.Text) = 9 Then
            FaltaDatos.SetError(sender, "")
        Else
            FaltaDatos.SetError(sender, "Tu numero de Celular debe Contener 9 digitos")
        End If

    End Sub

    Private Sub CmdCancelarMensajeOlvido_Click(sender As Object, e As EventArgs) Handles CmdCancelarMensajeOlvido.Click
        Dim frmpadre As FrmLogin = CType(Owner, FrmLogin)
        frmpadre.ImagenInicio.Enabled = True
        frmpadre.PanelLeft.Enabled = True
        frmpadre.PanelLeft.Visible = True
        frmpadre.ImagenInicio.Visible = True
        Me.Close()
    End Sub




    Private Sub CmbListaPaisOlvido_MeasureItem(sender As Object, e As MeasureItemEventArgs) Handles CmbListaPaisOlvido.MeasureItem
        e.ItemHeight = ImagenesPaises.ImageSize.Height + 5 'PARA SEPARAR LOS ELEMENTOS
    End Sub

    Private Sub CmbListaPaisOlvido_DrawItem(sender As Object, e As DrawItemEventArgs) Handles CmbListaPaisOlvido.DrawItem
        Try
            e.Graphics.DrawImage(ImagenesPaises.Images(e.Index), e.Bounds.Left, e.Bounds.Top) 'DIBUJA LA IMAGEN
            e.Graphics.DrawString(wVarListaPais(e.Index), CmbListaPaisOlvido.Font, Brushes.Black, e.Bounds.Left + ImagenesPaises.ImageSize.Width + 10, e.Bounds.Top) 'DIBUJA EL TEXTO
        Catch ex As Exception
        End Try
    End Sub
    Private Function Addusuario() As Boolean


        Dim ws_usaurio As String = TxtUsuario.Text
        Dim ws_clave As String = txtContrasena.Text
        Dim ws_id_tipodoc As String = lk_sql_ListaTipoDocPersona.Rows(CmbTipoDocUsuario.SelectedIndex).Item("id_tipodoc").ToString
        Dim ws_fotoperfil As Integer = 0
        Dim ws_numero_doc As String = TxtNumero.Text
        Dim ws_nombres As String = TxtNombres.Text
        Dim ws_apellidos As String = TxtApellidos.Text
        Dim ws_id_pais As String = "1"
        Dim ws_celular As String = TxtNumeroCel.Text
        Dim ws_email As String = "-"
        Dim ws_id_ciudad As String = "1"
        Dim ws_fec_nac As String = Now.ToString(lk_formatoFechabd)
        Dim ws_genero As String = "9"
        Dim ws_estado As String = "1"
        Dim ws_fec_registro As String = Now.ToString(lk_formatoFechabd)
        Dim ws_fec_conexion As String = Now.ToString(lk_formatoFechabd)


        Dim command As New SqlCommand()
        command.Connection = lk_connection_master
        command.CommandType = CommandType.StoredProcedure
        command.CommandText = "u_registrarUsuario"
        command.Parameters.Clear()
        command.Parameters.AddWithValue("@usu", ws_usaurio)
        command.Parameters.AddWithValue("@clave", ws_clave)
        command.Parameters.AddWithValue("@tipodoc", ws_id_tipodoc)
        command.Parameters.AddWithValue("@foto", ws_fotoperfil)
        command.Parameters.AddWithValue("@numeroDoc", ws_numero_doc)
        command.Parameters.AddWithValue("@nombre", ws_nombres)
        command.Parameters.AddWithValue("@apellido", ws_apellidos)
        command.Parameters.AddWithValue("@pais", ws_id_pais)
        command.Parameters.AddWithValue("@celular", ws_celular)
        command.Parameters.AddWithValue("@email", ws_email)
        command.Parameters.AddWithValue("@ciudad", ws_id_ciudad)
        command.Parameters.AddWithValue("@fecNac", ws_fec_nac)
        command.Parameters.AddWithValue("@genero", ws_genero)
        command.Parameters.AddWithValue("@estado", ws_estado)
        command.Parameters.AddWithValue("@fecReg", ws_fec_registro)
        command.Parameters.AddWithValue("@fecConex", ws_fec_conexion)
        Dim filasActualizadas As Integer = command.ExecuteNonQuery()
        If filasActualizadas > 0 Then
            ' La actualización fue exitosa '
            Addusuario = True
        Else
            Addusuario = False
            Exit Function
        End If

        'Dim parametro = New List(Of Parametro) From {
        '    New Parametro("usuario", ws_usaurio),
        '    New Parametro("clave", ws_clave),
        '    New Parametro("id_tipodoc", ws_id_tipodoc),
        '    New Parametro("fotoperfil", ws_fotoperfil),
        '    New Parametro("numero_doc", ws_numero_doc),
        '    New Parametro("nombres", ws_nombres),
        '    New Parametro("apellidos", ws_apellidos),
        '    New Parametro("id_pais", ws_id_pais),
        '    New Parametro("celular", ws_celular),
        '    New Parametro("email", ws_email),
        '    New Parametro("id_ciudad", ws_id_ciudad),
        '    New Parametro("fec_nac", ws_fec_nac),
        '    New Parametro("genero", ws_genero),
        '    New Parametro("estado", ws_estado),
        '    New Parametro("fec_registro", ws_fec_registro),
        '    New Parametro("fec_conexion", ws_fec_conexion)
        '}

        'Dim response = MuestraDataApi(lk_api_cadena_base + "usuario/registrar", parametro) ' respuesta : vps_Usaurios

        'lk_api_AgregarUsaurio = JsonConvert.DeserializeObject(Of JsonAgregarUsuario)(response) 'Cái truyền tên Class vào
        'If lk_api_AgregarUsaurio.estado = False Then
        '    Addusuario = False
        'Else
        '    Addusuario = True
        'End If

    End Function

    Private Sub TxtCodigoValida_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtCodigoValida.MaskInputRejected

    End Sub

    Private Sub TxtCodigoValida_TextChanged(sender As Object, e As EventArgs) Handles TxtCodigoValida.TextChanged
        Dim result As String
        If TxtCodigoValida.MaskFull Then
            If TxtCodigoValida.Tag <> TxtCodigoValida.Text Then
                result = MensajesBox.Show("Codigo Incorrecto.",
                                       "Envio de SMS")
                'TxtCodigoValida.Text = "      "
                GoTo NoIngresa
            End If

            If Addusuario() = False Then
                result = MensajesBox.Show("No se registro el usuario, Intentar nuevamente ",
                                      "Envio de SMS")
                Exit Sub
            End If
            Panel2.Visible = False
            Panel3.Visible = True
            UserRegistrado.Text = TxtUsuario.Text
            Lblcelularregistrado.Text = TxtNumeroCel.Text
            'Enviar a Crear Producto


        End If



        Exit Sub
NoIngresa:
    End Sub

    Private Sub CmbTipoDocUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoDocUsuario.SelectedIndexChanged

        wsfor_numerodigitos = Val(lk_sql_ListaTipoDocPersona.Rows(CmbTipoDocUsuario.SelectedIndex).Item("digitos").ToString)
        TxtNumero.MaxLength = wsfor_numerodigitos
    End Sub

    Private Sub UserRegistrado_TextChanged(sender As Object, e As EventArgs) Handles UserRegistrado.TextChanged

    End Sub

    Private Sub UserRegistrado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UserRegistrado.KeyPress


        e.Handled = True


    End Sub

    Private Sub CmbTipoDocUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles CmbTipoDocUsuario.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNumero.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub TxtApellidos_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtApellidos.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub TxtUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUsuario.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub txtContrasena_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContrasena.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub TxtRepitaContrasena_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtRepitaContrasena.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNumeroCel_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNumeroCel.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNombres_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNombres.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub CmdEnvioSMSolvido_Click(sender As Object, e As EventArgs) Handles CmdEnvioSMSolvido.Click
        If Len(TxtNumeroCelOlvido.Text) = 9 Then
            FaltaDatos.SetError(TxtNumeroCelOlvido, "")
        Else
            FaltaDatos.SetError(TxtNumeroCelOlvido, "Tu numero de Celular debe Contener 9 digitos")
            Exit Sub
        End If

        ' If lk_api_TipoDocPersona Is Nothing Then

        Dim result
        Dim codigosms As String
        codigosms = GenerarCodigoSMS()
        wsVarSegundos = 10
        If LK_ACTIVA_SMS = "A" Then
            wsVarSegundos = 60
            result = EnviarSMSAltiria("gaplicasac@gmail.com", "cfhgmquy", "+51" & Trim(TxtNumeroCelOlvido.Text), "(Plataforma ORI) Codigo de Verificación: " & codigosms)
            If result <> "" Then
                result = MensajesBox.Show("SMS no se logro Enviar. intente nuevamente.",
                                           "Creación de Usaurio")
                GoTo NoIngresa
            End If
            LblCodigoValidaOlvido.Text = "&Codigo de Verificación.   " ' lk_api_EnvioSMS.data
        Else
            LblCodigoValidaOlvido.Text = "&Codigo de Verificación.   " & codigosms ' lk_api_EnvioSMS.data
        End If
        TxtValidaCodigoO.Tag = codigosms
        CmdEnvioSMSolvido.Enabled = False
        TiempoSMSOlvido.Enabled = True

        TxtNumeroCelOlvido.Enabled = False

        TxtValidaCodigoO.Visible = True
        LblCodigoValidaOlvido.Visible = True
        '  LblCodigoValida.Visible = True
        LblEsperaSMSOlvido.Visible = True
        'CmdAtras.Enabled = False
        ' CmdCancelarMensaje.Visible = True
        TxtValidaCodigoO.Text = ""
        TxtValidaCodigoO.Focus()
        Exit Sub
NoIngresa:
    End Sub

    Private Sub TiempoSMSOlvido_Tick(sender As Object, e As EventArgs) Handles TiempoSMSOlvido.Tick
        wsVarSegundos = wsVarSegundos - 1
        LblEsperaSMSOlvido.Text = "Pronto le llegara el Codigo de Validación en su celular..." & Format(wsVarSegundos, "00")
        If wsVarSegundos <= 0 Then
            LblEsperaSMSOlvido.Text = ""
            CmdREEnvioSMSOlvido.Visible = True
            TiempoSMSOlvido.Stop()
        End If
    End Sub

    Private Sub CmdREEnvioSMSOlvido_Click(sender As Object, e As EventArgs) Handles CmdREEnvioSMSOlvido.Click
        Call CmdEnvioSMSolvido_Click(Nothing, Nothing)

        wsVarSegundos = 10
        TiempoSMSOlvido.Start()
        CmdREEnvioSMSOlvido.Visible = False
        TxtValidaCodigoO.Text = ""
        TxtValidaCodigoO.Focus()
    End Sub



    Private Sub txtContrasenaOlvido_Validating(sender As Object, e As CancelEventArgs) Handles txtContrasenaOlvido.Validating
        If DirectCast(sender, TextBox).Text = TxtRepitaContrasenaOlvido.Text Then
            FaltaDatos.SetError(sender, "")
            FaltaDatos.SetError(TxtRepitaContrasenaOlvido, "")

        Else
            FaltaDatos.SetError(sender, "Contraseña NO Coinciden ")
        End If

    End Sub

    Private Sub TxtRepitaContrasenaOlvido_TextChanged(sender As Object, e As EventArgs) Handles TxtRepitaContrasenaOlvido.TextChanged

    End Sub

    Private Sub TxtRepitaContrasenaOlvido_Validating(sender As Object, e As CancelEventArgs) Handles TxtRepitaContrasenaOlvido.Validating
        If DirectCast(sender, TextBox).Text = txtContrasenaOlvido.Text Then
            FaltaDatos.SetError(sender, "")
            FaltaDatos.SetError(txtContrasenaOlvido, "")

        Else
            FaltaDatos.SetError(sender, "Contraseña NO Coinciden ")
        End If
    End Sub

    Private Sub CmbNumerosOlvido_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbNumerosOlvido.SelectedIndexChanged
        'If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
        SelectNextControl(ActiveControl, True, True, True, True)
        '    e.Handled = True
        '  End If
    End Sub

    Private Sub txtContrasenaOlvido_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContrasenaOlvido.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub TxtValidaCodigoO_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtValidaCodigoO.MaskInputRejected

    End Sub

    Private Sub TxtValidaCodigoO_TextChanged(sender As Object, e As EventArgs) Handles TxtValidaCodigoO.TextChanged
        Dim result As String

        If TxtValidaCodigoO.MaskFull Then
            If TxtValidaCodigoO.Tag <> TxtValidaCodigoO.Text Then
                result = MensajesBox.Show("Codigo Incorrecto.",
                                       "Envio de SMS")
                'TxtCodigoValida.Text = "      "
                GoTo NoIngresa
            End If

            LblEsperaSMSOlvido.Text = "Codigo Validado."
            CmdREEnvioSMSOlvido.Visible = False
            TiempoSMSOlvido.Stop()

            ' Creamos un comando que llame al stored procedure y le pase los parámetros
            Dim command As SqlCommand = New SqlCommand("u_buscarPorCelular", lk_connection_master)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@celular", TxtNumeroCelOlvido.Text)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            Dim DataNumerosAsoc As DataTable = New DataTable()
            adapter.Fill(DataNumerosAsoc)

            If DataNumerosAsoc.Rows.Count = 0 Then
                result = MensajesBox.Show("No tiene asignado usaurios." & Chr(13) & "Intente con otro Numero de celular.",
                                       "Validar SMS")
                Call CmdCancelarMensajeOlvido_Click(Nothing, Nothing)
                GoTo NoIngresa
            End If



            ''If  TxtUsuario.Text ="admin"
            'Dim parametro = New List(Of Parametro) From {
            'New Parametro("celular", TxtNumeroCelOlvido.Text)
            '}
            '    Dim response = MuestraDataApi(lk_api_cadena_base + "usuario/obtener", parametro) ' respuesta : vps_Usaurios
            '    Try
            '        lk_api_ListaUsuarios = JsonConvert.DeserializeObject(Of JsonListaUsuarios)(response) 'Cái truyền tên Class vào
            '    Catch ex As Exception
            '        GoTo NoIngresa
            '    End Try

            '    If lk_api_ListaUsuarios.estado = False Then
            '        result = MensajesBox.Show("No tiene asignado usaurios." & Chr(13) & "Intente con otro Numero de celular.",
            '                               "Validar SMS")
            '        Call CmdCancelarMensajeOlvido_Click(Nothing, Nothing)
            '        GoTo NoIngresa
            '    End If
            '    ' Iterate through the list.



            CmbNumerosOlvido.Items.Clear()
            For i = 0 To DataNumerosAsoc.Rows.Count - 1
                CmbNumerosOlvido.Items.Add(DataNumerosAsoc.Rows(i).Item("usuario").ToString & Space(80) & DataNumerosAsoc.Rows(i).Item("id").ToString)
            Next
            CmbNumerosOlvido.SelectedIndex = 0
            CmbNumerosOlvido.Focus()
            'CmbNumerosOlvido.DroppedDown = True
            CmdCambiaClave.Enabled = True
            CmdCambiaClave.Visible = True
            PanelValida.Enabled = False
            PanelRestablece.Enabled = True
            PanelRestablece.Visible = True
            'Enviar a Crear Producto


        End If
        Exit Sub
NoIngresa:
    End Sub

    Private Sub CmdCambiaClave_Click(sender As Object, e As EventArgs) Handles CmdCambiaClave.Click
        Dim result

        If (txtContrasenaOlvido.Text <> TxtRepitaContrasenaOlvido.Text) Or txtContrasenaOlvido.Text = "" Then
            FaltaDatos.SetError(TxtRepitaContrasenaOlvido, "Contraseña NO Coinciden ")
            Exit Sub
        Else
            FaltaDatos.SetError(TxtRepitaContrasenaOlvido, "")
        End If
        If Len(Trim(txtContrasenaOlvido.Text)) < 6 Then
            FaltaDatos.SetError(txtContrasenaOlvido, "Longitud de contraseña, mayor o igual de 6 digitos.")
            Exit Sub
        Else
            FaltaDatos.SetError(txtContrasenaOlvido, "")
        End If


        If CambiaClave() = False Then
            FaltaDatos.SetError(CmdCambiaClave, "Intente Nuevamente...")
            Exit Sub
        End If

        result = MensajesBox.Show("Contraseña del Usaurio Cambiado ." & Chr(13) & "Ahora podra ingresar al Sistema.",
                                           "Cambio efectuado")
        Call CmdCancelarMensajeOlvido_Click(Nothing, Nothing)


    End Sub
    Private Function CambiaClave() As Boolean
        Dim ws_id As String = Trim(Strings.Right(CmbNumerosOlvido.Text, 25))
        '  Dim ws_usaurio As String = Nothing
        Dim ws_clave As String = txtContrasenaOlvido.Text
        'Dim ws_id_tipodoc As String = Nothing
        'Dim ws_fotoperfil As String = Nothing
        'Dim ws_numero_doc As String = Nothing
        'Dim ws_nombres As String = Nothing
        'Dim ws_apellidos As String = Nothing
        'Dim ws_id_pais As String = Nothing
        'Dim ws_celular As String = Nothing ' TxtCelular.Text
        'Dim ws_email As String = Nothing
        'Dim ws_id_ciudad As String = Nothing ' Nothing
        'Dim ws_fec_nac As String = Nothing
        'Dim ws_genero As String = Nothing
        'Dim ws_estado As String = Nothing
        'Dim ws_fec_registro As String = Nothing
        'Dim ws_fec_conexion As String = Nothing


        'Dim parametro = New List(Of Parametro) From {
        '    New Parametro("id", ws_id),
        '    New Parametro("usuario", ws_usaurio),
        '    New Parametro("clave", ws_clave),
        '    New Parametro("id_tipodoc", ws_id_tipodoc),
        '    New Parametro("fotoperfil", ws_fotoperfil),
        '    New Parametro("numero_doc", ws_numero_doc),
        '    New Parametro("nombres", ws_nombres),
        '    New Parametro("apellidos", ws_apellidos),
        '    New Parametro("id_pais", ws_id_pais),
        '    New Parametro("celular", ws_celular),
        '    New Parametro("email", ws_email),
        '    New Parametro("id_ciudad", ws_id_ciudad),
        '    New Parametro("fec_nac", ws_fec_nac),
        '    New Parametro("genero", ws_genero),
        '    New Parametro("estado", ws_estado),
        '    New Parametro("fec_registro", ws_fec_registro),
        '    New Parametro("fec_conexion", ws_fec_conexion)
        '}

        'Dim response = MuestraDataApi(lk_api_cadena_base + "usuario/modificar", parametro) ' respuesta : vps_Usaurios

        'lk_api_ModificaUsaurio = JsonConvert.DeserializeObject(Of JsonModificaUsuario)(response) 'Cái truyền tên Class vào
        'If lk_api_ModificaUsaurio.estado = False Then
        '    CambiaClave = False
        'Else
        '    CambiaClave = True
        'End If

        Dim command As SqlCommand = New SqlCommand("update m_usuarios set clave = '" & ws_clave & "' where id_usuario= " & ws_id & "", lk_connection_master)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        Dim Sql_ActualizaUser As New DataTable

        adapter.Fill(Sql_ActualizaUser)
        Dim filasActualizadas As Integer = command.ExecuteNonQuery()
        If filasActualizadas = 0 Then

            CambiaClave = False
        Else
            CambiaClave = True
        End If



    End Function
    Private Sub txtContrasenaOlvido_TextChanged(sender As Object, e As EventArgs) Handles txtContrasenaOlvido.TextChanged

    End Sub

    Private Sub TxtValidaCodigoO_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtValidaCodigoO.KeyDown

    End Sub

    Private Sub TxtNumeroCelOlvido_TextChanged(sender As Object, e As EventArgs) Handles TxtNumeroCelOlvido.TextChanged

    End Sub

    Private Sub TxtNumeroCelOlvido_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNumeroCelOlvido.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            SelectNextControl(ActiveControl, True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub CmbListaPaisOlvido_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbListaPaisOlvido.SelectedIndexChanged

    End Sub
    Function GenerarCodigoSMS() As String
        Dim rand As New Random()
        Dim codigo As String = ""
        For i As Integer = 1 To 3 ' Generar tres pares de números
            Dim num As Integer = rand.Next(0, 5) * 2 ' Genera un número par entre 0 y 8
            codigo &= num.ToString() ' Agrega el primer número al código generado
            num = rand.Next(0, 5) * 2 ' Genera otro número par entre 0 y 8
            codigo &= num.ToString() ' Agrega el segundo número al código generado
            If i < 3 Then ' Si no es el último par, agrega un guión como separador
                codigo &= ""
            End If
        Next
        Return codigo ' Devuelve el código generado
    End Function
    Function EnviarSMSAltiria(pasausername As String, apiKey As String, destination As String, pasamessage As String) As String

        Dim client As HttpClient = New HttpClient
        client.BaseAddress = New Uri("Https://www.altiria.net:8443")
        'Fijamos TimeOut de espera de respuesta del servidor = 60 seg
        client.Timeout = TimeSpan.FromSeconds(60)
        'Se compone el mensaje a enviar
        'YY y ZZ se corresponden con los valores de identificaci´on del usuario en el sistema.
        Dim postData As List(Of KeyValuePair(Of String, String))
        postData = New List(Of KeyValuePair(Of String, String))
        postData.Add(New KeyValuePair(Of String, String)("cmd", "sendsms"))
        postData.Add(New KeyValuePair(Of String, String)("login", pasausername))
        postData.Add(New KeyValuePair(Of String, String)("passwd", "cfhgmquy"))
        ' Descomentar para utilizar la autentificaci´on mediante apikey
        postData.Add(New KeyValuePair(Of String, String)("apikey", "PnR7Vqd6Gj"))
        postData.Add(New KeyValuePair(Of String, String)("apisecret", "qryav5myet"))
        postData.Add(New KeyValuePair(Of String, String)("dest", destination))
        postData.Add(New KeyValuePair(Of String, String)("dest", destination))
        postData.Add(New KeyValuePair(Of String, String)("msg", pasamessage))
        ' No es posible utilizar el remitente en Am´erica pero s´ı en Espa~na y Europa
        ' Descomentar la l´ınea solo si se cuenta con un remitente autorizado por Altiria
        ' postData.Add(New KeyValuePair(Of String, String)("senderId", "remitente"))
        Dim content As HttpContent = New FormUrlEncodedContent(postData)
        Dim err = ""
        Dim resp = ""
        Try
            'Se fija la URL sobre la que enviar la petici´on POST
            Dim request As HttpRequestMessage
            request = New HttpRequestMessage(HttpMethod.Post, "/api/http")
            request.Content = content
            content.Headers.ContentType.CharSet = "UTF-8"
            Dim contentType = "application/x-www-form-urlencoded"
            request.Content.Headers.ContentType = New Headers.MediaTypeHeaderValue(contentType)
            Dim response As HttpResponseMessage = client.SendAsync(request).Result
            Dim responseString = response.Content.ReadAsStringAsync
            resp = responseString.Result
        Catch e1 As Exception
            err = e1.Message
        Finally
            If (err <> "") Then
                ' Console.WriteLine(err)
            Else
                ' Console.WriteLine(resp)
            End If
        End Try
        EnviarSMSAltiria = err
    End Function

    Private Sub TxtNumeroCelOlvido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumeroCelOlvido.KeyPress
        e.Handled = Solo_Numero(e)
    End Sub
End Class