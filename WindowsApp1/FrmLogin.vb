Imports System.ComponentModel
Imports Newtonsoft.Json
Imports System.Net
Imports WindowsApp1.ValidaUsuarios
Imports WindowsApp1.ListaTipoDocPersona
Imports WindowsApp1.ListaUbigeoN1
Imports WindowsApp1.ListaUbigeoN2
Imports WindowsApp1.ListaUbigeoN3
Imports WindowsApp1.Negocio.NegocioActivo
Imports System.Net.Sockets
Imports System.Text
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Data.SqlClient
Imports Newtonsoft.Json.Serialization

Public Class FrmLogin
    Dim WsONOFF As Integer
    Dim lkfor_texto_sinnegocio As String = "Actualmente no tienes Negocio asociado." & vbLf & vbLf & " - Crear tu Propio negocio Farmacéutico con nosotros pulsado el botón " & vbLf & vbLf & "CREA TU NEGOCIO." & vbLf & vbLf & " -	Puedes darle el nombre de tu usuario a otros negocios para tener acceso"

    Dim ws_foto_perfil_local As String
    Dim frsegundoplano As New FrmEsperar
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

Empiezanuevamente:


        ' ****** CONEXION A SERVIDOR


        ''**********



        PCSERVER = "acosme"
        PASSSEVER = "159357852456"
        SASEVER = "sa"
        LK_ES_FORMATO_ESPANOL = True
        TxtUsuario.Text = "admin"
        txtContrasena.Text = "1234"
        LK_RUTA_RPT = "D:\Proyectos VisualStudio\Ori\SistemaComercialOri V2.0\WindowsApp1\FormatosCrystal\"



        '********************************
        'PCSERVER = "161.132.47.14"
        'PASSSEVER = "B]4O7mmD-S3("
        'SASEVER = "sa"
        'LK_ES_FORMATO_ESPANOL = False
        'Dim rutaInstalacion As String = AppDomain.CurrentDomain.BaseDirectory
        'LK_RUTA_RPT = rutaInstalacion

        ''LK_RUTA_RPT = "D:\Proyectos VisualStudio\Ori\SistemaComercialOri\WindowsApp1\FormatosCrystal\"

        ''**********

        'PCSERVER = "34.134.43.163"
        'PASSSEVER = "yp257sjtfBpqnNK8F%5s"
        'SASEVER = "sa"
        'LK_ES_FORMATO_ESPANOL = False
        'Dim rutaInstalacion As String = AppDomain.CurrentDomain.BaseDirectory
        'LK_RUTA_RPT = rutaInstalacion

        'LK_RUTA_RPT = "D:\Proyectos VisualStudio\Ori\SistemaComercialOri\WindowsApp1\FormatosCrystal\"

        'COPIAR ARCHIVOS DE CRYSTEAL REPORT  AL INSTALADOR 


        '**********


        ' PARAMETROS INICIALES 
        '============================================================
        ' RUTA PARA MENSAJES 
        'LK_ACTIVA_SMS = "A"
        ' ==============================


        LK_NOMBRE_PC = System.Environment.MachineName

        Dim frCargainfo As New FrmCarga
        frCargainfo.LogoMuestra.Dock = DockStyle.Fill
        frCargainfo.Show()
        Application.DoEvents()
        Try
            CERRAR_SESIONES()
            ConexionSQL_Maester()

            'ConexionSQL_Cuentas()

            ConexionSQL_Imagenes()

            Carga_Paramtros_Generales()
        Catch ex As Exception
            ' Manejo de excepciones aquí

            Dim Result As String = MensajesBox.Show("Hubo un problema en la conexion al Servidor , desea intentar nuevamente ?" & vbCrLf & MessageBoxIcon.Error & "
                    ", "Acceso al Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If Result = "7" Or Result = "2" Then ' es NO
                End
            End If
            GoTo Empiezanuevamente
        End Try

        'CArgar OParametro de Generas del aplicacion ""
        ' ==============================================



        '============================================================

        ImagenInicio.Image = My.Resources.farma
        ' FadeTransition(fondonegro, ImagenInicio, 100)

        ' lk_foto_perfil = ""
        ws_foto_perfil_local = ""
        CircularProgressBar1.Visible = True
        isOnline()
        DescargaInicial.RunWorkerAsync()
        Intenta.Start()


        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(256, 400)
        Me.MinimumSize = New System.Drawing.Size(800, 700)
        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea
        'Me.FormBorderStyleMe.FormBorderStyle = 1 ' Impedir que cambie el tamaño el formulario
        'Me.FormBorderStyle.for
        Me.Centrar()


        CmdIdNegocio.IconChar = FontAwesome.Sharp.IconChar.Store
        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        PanelLeft.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        PanelLeft.BackColor = System.Drawing.ColorTranslator.FromHtml("#00476D")

        PanelNegocio.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        PanelLeft.Dock = DockStyle.Left
        CmdIniciar.IconChar = FontAwesome.Sharp.IconChar.PlayCircle
        CmdMin.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize
        ' Asiganr Icons a barra de menu
        CmdConfigurar.IconChar = FontAwesome.Sharp.IconChar.Wrench
        CmdProcesar.IconChar = FontAwesome.Sharp.IconChar.Confluence
        CmdGestionar.IconChar = FontAwesome.Sharp.IconChar.Tasks
        CmdReportar.IconChar = FontAwesome.Sharp.IconChar.SignInAlt
        CmdDeclarar.IconChar = FontAwesome.Sharp.IconChar.Gavel
        CmdIntegrar.IconChar = FontAwesome.Sharp.IconChar.ArrowsAltH
        cmdayuda.IconChar = FontAwesome.Sharp.IconChar.Info
        'CmdSalir.Left = 55
        'CmdSalir.Top = 407
        'CmdReiniciar.Left = 17
        'CmdReiniciar.Top = 407
        Me.tt_leyenda.SetToolTip(Me.CmdSalir, "Salir")
        Me.tt_leyenda.SetToolTip(Me.CmdReiniciar, "Reiniciar")



        PanelInicial.Dock = DockStyle.Fill
        PanelInicial.Visible = True
        FotoUsuario.Visible = True

        FotoUsuario.Image = My.Resources.userd





        ''LblEstadoRed.ForeColor = Color.Red
        CmdIdNegocio.Enabled = False
        CmdConfigurPerfil.Enabled = False
        CmdCreaTuNegocio.Enabled = False


        FotoNegocio.Image = My.Resources.negocio
        CmdIdNegocio.Text = "---"
        ' TxtUsuario.CharacterCasing = CharacterCasing.Upper
        ' CircularProgressBar1.Visible = False
        CircularProgressBar1.Visible = True
        Redondeaimagen(FotoUsuario)
        'IndicadorGrafico

        PanelInicial.Dock = DockStyle.Fill
        PanelInicial.Visible = True

        ' inicializa el Marco de la foto en vacio
        MarcoPerfil.Image = Nothing
        frCargainfo.Close()
    End Sub
    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const CS_MAXIMIZE As Integer = &HF030I

    Public Sub Centrar()
        Dim xl, yl As Integer
        xl = (Screen.PrimaryScreen.WorkingArea.Width - Me.Size.Width) / 2
        yl = (Screen.PrimaryScreen.WorkingArea.Height - Me.Size.Height) / 2
        Me.Location = New Point(xl, yl)



    End Sub
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_SYSCOMMAND Then
            If m.WParam = New IntPtr(CS_MAXIMIZE) Then
                m.Result = IntPtr.Zero
                Me.Size = Me.MaximumSize
                Centrar()
                Return
            End If
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub CmdIniciar_Click(sender As Object, e As EventArgs) Handles CmdIniciar.Click
        Dim Rutalocal As String
        Dim RutaSubir_User As String = "innovate"
        Dim RutaSubir_clave As String = "V987;sVR1;cdbT"
        Dim frCargainfo As New FrmCarga
        Rutalocal = My.Computer.FileSystem.CurrentDirectory & "\"



        CmdIniciar.IconChar = FontAwesome.Sharp.IconChar.HourglassStart
        CmdIniciar.Refresh()

        Dim result
        PlaySonidoMouse(lk_CodigoSonido)


        If Trim(TxtUsuario.Text) = "" Or Trim(txtContrasena.Text) = "" Then
            result = MensajesBox.Show("Ingrese Usuario y Cotraseña.",
                                           "Validar Usaurio")
            TxtUsuario.Focus()
            CmdIniciar.IconChar = FontAwesome.Sharp.IconChar.PlayCircle
            Exit Sub
            'GoTo NoIngresa

        End If


        ' Configuramos la conexión a la base de datos

        ' Creamos un comando que llame al stored procedure y le pase los parámetros
        Dim command As SqlCommand = New SqlCommand("u_login", lk_connection_master)
        command.CommandType = CommandType.StoredProcedure

        ' Añadimos los parámetros al comando
        command.Parameters.AddWithValue("@usuario", TxtUsuario.Text)
        command.Parameters.AddWithValue("@clave", txtContrasena.Text)

        ' Creamos un adapter para ejecutar el comando y llenar un DataTable con los resultados
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        ' Dim dataTable As DataTable = New DataTable()

        ' Ejecutamos el adapter para llenar el DataTable
        adapter.Fill(lk_sql_ValidaUsuario)

        '  Dim valor As String = lk_sql_ValidaUsuario.Rows(0)("usuario").ToString()

        'Dim parametro = New List(Of Parametro) From {
        '        New Parametro("usuario", TxtUsuario.Text),
        '         New Parametro("clave", txtContrasena.Text)}
        'Dim response = MuestraDataApi(lk_api_cadena_base + "auth/login", parametro) ' respuesta : vps_Usaurios
        'If Mid(response, 1, 1) = "*" Then
        '    result = MensajesBox.Show("Error de Conexion Codigo:" & response,
        '                       "VPS")
        '    GoTo NoIngresa
        'End If
        'lk_api_ValidaUsuario = JsonConvert.DeserializeObject(Of JsonValidaUsaurio)(response) 'Cái truyền tên Class vào


        If lk_sql_ValidaUsuario Is Nothing Then
            result = MensajesBox.Show("Conexion Interrumpida.",
"VPS")
            GoTo NoIngresa
        End If
        If lk_sql_ValidaUsuario.Rows.Count = 0 Then
            result = MensajesBox.Show("Usaurio y/o contraseña Incorrectos.",
"Validar Usaurio")
            txtContrasena.Focus()
            GoTo NoIngresa
        End If

        lk_fecha_dia = Now
        FechaHoraVPS.Enabled = True
        FechaHoraVPS.Start()
        Me.Hide()
        frCargainfo.LogoMuestra.Dock = DockStyle.Fill
        frCargainfo.Show()
        Application.DoEvents()
        'Carga los negocios Asociados al Usuario

        lk_id_usuario = lk_sql_ValidaUsuario.Rows(0)("id_usuario").ToString()
        lk_usuario = lk_sql_ValidaUsuario.Rows(0)("Usuario").ToString()
        lk_id_cuemta_user = Val(lk_sql_ValidaUsuario.Rows(0)("id_cuenta_user").ToString())
        lk_Carpeta_Temp = My.Computer.FileSystem.CurrentDirectory & "\user" & lk_id_usuario & "\"
        My.Computer.FileSystem.CreateDirectory(lk_Carpeta_Temp)
        lk_foto_perfil_id = 0
        ' Creamos un comando que llame al stored procedure y le pase los parámetros
        If Not Convert.IsDBNull(lk_sql_ValidaUsuario.Rows(0)("id_fotoperfil")) Then
            Dim command2 As SqlCommand = New SqlCommand("select  * from [dbo].[tab_imagenes] where id_img = " & lk_sql_ValidaUsuario.Rows(0)("id_fotoperfil").ToString() & "", lk_connection_imagenes)
            Dim adapter2 As SqlDataAdapter = New SqlDataAdapter(command2)
            Dim DataNumerosAsoc As DataTable = New DataTable()
            adapter2.Fill(DataNumerosAsoc)

            If DataNumerosAsoc.Rows.Count <> 0 Then
                If IsDBNull(lk_sql_ValidaUsuario.Rows(0).Item("id_fotoperfil")) Then
                    FotoUsuario.Image = My.Resources.userd
                    lk_foto_perfil = Nothing
                Else
                    MostrarImagenDesdeCampo("imagen", DataNumerosAsoc.Rows(0), Me.FotoUsuario)
                    MostrarPictureBoxCircular(Me.FotoUsuario)
                    lk_foto_perfil = DirectCast(DataNumerosAsoc.Rows(0).Item("imagen"), Byte())
                    lk_foto_perfil_id = DataNumerosAsoc.Rows(0).Item("id_img")
                End If
            Else
                FotoUsuario.Image = My.Resources.userd
                lk_foto_perfil = Nothing
            End If
        Else
            FotoUsuario.Image = My.Resources.userd
            lk_foto_perfil = Nothing
        End If

        IniciarRegistros_tablasBasesORI()
        Negocio_Local_Almacen_Usuario()

        'RECARGARNEGOCIOS()
        ' Stop
        'If lk_sql_ValidaUsuario.Rows(0)("id_neg_def").ToString() = "" Then

        'Stop
        ' End If
        ' Stop
        'lk_NegocioActivo.id_Negocio = ""
        '' lk_Id_NegocioActivo = ""
        'If lk_sql_Usuario_negocio.Rows.Count > 0 Then
        '    '    For I = 0 To lk_sql_Usuario_negocio.Rows.Count - 1
        '    '        lk_NegocioActivo.id_Negocio = lk_sql_Usuario_negocio.Rows(I)("id_negocio").ToString
        '    '        lk_NegocioActivo.nombre = lk_sql_Usuario_negocio.Rows(I)("nombre").ToString
        '    '        'lk_NegocioActivo. = lk_api_ListaNegocios.data(I).id_tipdoc
        '    '        lk_NegocioActivo.numdoc = lk_sql_Usuario_negocio.Rows(I)("numeroreg").ToString
        '    '        lk_NegocioActivo.fotonegocio = lk_sql_Usuario_negocio.Rows(I)("fotonegociolocal").ToString
        '    '        Exit For
        '    '    Next
        'End If
        If lk_NegocioActivo.id_Negocio = "" Then ' NO TIENE NEGOCIO ASIGNADO
            CmdCreaTuNegocio.Text = "MI PRIMER NEGOCIO"
            CmdCreaTuNegocio.IconChar = FontAwesome.Sharp.IconChar.Store
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
            PublicidadInicio.Image = Nothing

            CmdIdNegocio.Text = lk_NegocioActivo.nombre
            CmdIdNegocio.Tag = lk_NegocioActivo.id_Negocio
            If lk_NegocioActivo.fotonegocio = "-" Then
                FotoNegocio.Image = My.Resources.negocio
            Else
                FotoNegocio.Image = Image.FromFile(lk_NegocioActivo.fotonegocio)
            End If
            CmdCreaTuNegocio.Text = "MI NEGOCIO"
            CmdCreaTuNegocio.IconColor = System.Drawing.ColorTranslator.FromHtml("#2A476D")
            CmdCreaTuNegocio.IconChar = FontAwesome.Sharp.IconChar.Stream
            Activa_Indicadores()
            Carga_Paramtros_Negocio(lk_NegocioActivo.id_Negocio)

            'lk_LocalActivo.id_local = 3
            'lk_LocalActivo.codigo = "019"
            'lk_LocalActivo.nombre = "XSAN MARTIN 1 - PRIMER PISO"
            'lk_AlmacenActivo.id_almacen = 1
            'lk_AlmacenActivo.codigo = "01"


        End If
        If lk_usuario.ToUpper = "ADMIN" Then  ' OPCIONES DE ADMINITACION DEL SISTEMA.
            CmdAdmin.Visible = True
        End If



        '         lk_Id_NegocioActivo = ""  para quitar el negocio activo

        WindowState = FormWindowState.Maximized
        PanelLeft.Visible = False
        PanelMenu.Dock = DockStyle.Left
        PanelFormularios.Dock = DockStyle.Fill
        PanelFormularios.Visible = True
        PanelMenu.Visible = True
        PanelMenu.Width = 65
        CmdContraerMenu.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft
        CmdContraerMenu.ImageAlign = ContentAlignment.MiddleRight
        CmdContraerMenu.Tag = 1
        PanelInicial.Visible = False

        NombreUser.Text = lk_usuario

        NombreUser.Tag = 100
        CmdIdNegocio.Enabled = True
        CmdConfigurPerfil.Enabled = True
        CmdCreaTuNegocio.Enabled = True


        PublicidadInicio.Height = 62
        PublicidadInicio.Width = 600
        PublicidadInicio.Visible = True

        If Descargas.IsBusy = False Then
            Descargas.RunWorkerAsync()
        End If


        ' If TxtUsuario.Text = "admin" Then
        ' MarcoPerfil.Image = My.Resources.fondo5
        ' Else
        MarcoPerfil.Image = Nothing
        ' End If

        Panel1.Controls.Add(FotoUsuario)
        Panel1.Controls.Add(MarcoPerfil)

        Panel1.Controls(0).Left = 50
        Panel1.Controls(0).Top = 4
        Panel1.Controls(1).Left = 0
        Panel1.Controls(1).Top = 0
        'Panel1.Controls(0).BackColor = Color.Transparent
        Panel1.Controls(0).BringToFront()

        'MarcoPerfil.Parent = FotoUsuario
        'MarcoPerfil.Visible = True

        Muestra_Info_Principal(lk_NegocioActivo.id_Negocio)



        frCargainfo.Close()
        Me.Show()
        'frsegundoplano.Close()

        Exit Sub
NoIngresa:
        CmdIniciar.IconChar = FontAwesome.Sharp.IconChar.PlayCircle
        frsegundoplano.Close()

    End Sub
    Dim WithEvents CLIENTE As New WebClient 'LO DECLARAMOS CON EVENTS PARA PODER UTILIZAR LOS PROCEDIMIENTOS PROGRESSCHANGED Y COMPLETED
    Public Sub Activa_Indicadores()
        PanelIndicadores.Visible = True
        'PanelInd_Logistico.Visible = True
        IndicadorGrafico.Visible = True
        PanelIndicadores.SendToBack()
        IndicadorGrafico.SendToBack()

        B_VENTAS.Text = "VENTAS" & vbLf & "S/ 2,412.78"
        B_COMPRAS.Text = "COMPRAS" & vbLf & "S/ 4,212.78"
        B_PROD_VENC.Text = "PRODUCTOS" & vbLf & "25"
        B_PORVENCER.Text = "POR VENCER" & vbLf & "124"
        B_VENCIDOS.Text = "VENCIDOS" & vbLf & "245"
        B_CREDITOS.Text = "CREDITOS" & vbLf & "S/ 5,100.22"
        B_CREDITOVENCIDOS.Text = "CRED.VENC." & vbLf & "S/ 1,433.00"
        B_PROD_POR_VENCER.Text = "CLIEN.ATEN." & vbLf & "12"



        ' Chart1.Location = New Point(10, 10)
        '  Chart1.Size = New Size(250, 250)

        ' Establece el tipo de gráfico a circular (pie)
        'Crear una nueva serie en el control Chart


        Chart1.Series.Clear()
        Chart1.Legends.Clear()
        Chart1.Titles.Clear()
        Chart1.Series.Add("Ventas")
        Chart1.Series("Ventas").ChartType = SeriesChartType.Pie
        Chart1.Series("Ventas").Color = Color.Transparent

        ' Agrega los datos al gráfico
        Chart1.Series("Ventas").Points.AddXY("Panedol 500 Mg", 154)
        Chart1.Series("Ventas").Points.AddXY("Aspirina 100", 304)
        Chart1.Series("Ventas").Points.AddXY("Antalgina 500mg", 89)

        ' Establece el fondo del gráfico como transparente
        Chart1.BackColor = Color.Transparent
        Chart1.BackImageTransparentColor = Color.Transparent ' <-- Aquí establecemos la transparencia del fondo

        ' Establece el título del gráfico

        ' Establece el título del gráfico
        Chart1.Titles.Add("Productos más vendidos")

        ' Establece la leyenda del gráfico
        Chart1.Legends.Add("Leyenda").BackColor = Color.Transparent
        Chart1.Legends.Item(0).ForeColor = Color.White

        'Chart1.Legends.Add("Leyenda").BackColor = Color.Transparent

        Chart1.Series("Ventas").LegendText = "#VALX (#PERCENT{P0})"
        Chart1.Series("Ventas").LegendToolTip = "#VALX: #VALY"

        ' Establece la etiqueta de datos para mostrar los valores de las ventas en el gráfico
        Chart1.Series("Ventas").IsValueShownAsLabel = True
        ' MsgBox(Chart1.Series("Ventas").LabelFormat)
        Chart1.Series("Ventas").LabelFormat = "" '  #VALY"

        ' Establece el estilo del gráfico
        Chart1.Series("Ventas").CustomProperties = "PieLabelStyle=Outside, LabelStyle=Stagger"

        ' Configura los colores del gráfico
        Chart1.Palette = ChartColorPalette.Pastel



    End Sub

    Private Sub BajarFotoPerfl(ws_foto As String, ws_foto_local As String)


        'If ws_foto = "" Then Exit Sub

        ''Dim wRutaLocalfile As String = My.Computer.FileSystem.CurrentDirectory & "\" & System.IO.Path.GetFileName(lk_api_ValidaUsuario.data(0).FotoPerfil)
        'Dim wRutaLocalfile As String = lk_Carpeta_Temp & System.IO.Path.GetFileName(lk_sql_ValidaUsuario.Rows(0)("FotoPerfil").ToString)
        'lk_rutalocal_foto = "X"
        'If System.IO.File.Exists(wRutaLocalfile) Then

        'Else
        '    CLIENTE.DownloadFile(New Uri(ws_foto), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
        'End If

        'Me.FotoUsuario.Image = Image.FromFile(wRutaLocalfile)
        'Redondeaimagen(Me.FotoUsuario)
        'lk_rutalocal_foto = wRutaLocalfile



    End Sub


    Private Sub CmdMin_Click(sender As Object, e As EventArgs) Handles CmdMin.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub CmdMax_Click(sender As Object, e As EventArgs) Handles CmdMax.Click
        Application.Exit()
    End Sub

    Private Sub CmdContraerMenu_Click(sender As Object, e As EventArgs) Handles CmdContraerMenu.Click
        If CmdContraerMenu.Tag = 1 Then
            Acoplar(True)

            'PanelMenu.Width = 30
            CmdContraerMenu.IconChar = FontAwesome.Sharp.IconChar.ArrowRight
            ' arrow-Right -to-bracket
            CmdContraerMenu.Tag = 0
            CmdContraerMenu.ImageAlign = ContentAlignment.MiddleLeft
            'CmdSalir.Left = 2
            ' CmdSalir.Top = 440
            'CmdReiniciar.Left = 2
            'CmdReiniciar.Top = 407



        Else
            Acoplar(False)
            'PanelMenu.Width = 65
            CmdContraerMenu.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft
            CmdContraerMenu.Tag = 1
            CmdContraerMenu.ImageAlign = ContentAlignment.MiddleRight
            'CmdSalir.Left = 44
            'CmdSalir.Top = 407
            'CmdReiniciar.Left = 6
            'CmdReiniciar.Top = 407


        End If
    End Sub




    Private Sub CmdSalir_Click(sender As Object, e As EventArgs) Handles CmdSalir.Click
        PlaySonidoMouse(lk_CodigoSonido)
        Application.Exit()
    End Sub


    Private Sub IconButton5_Click(sender As Object, e As EventArgs) Handles CmdCrearUsuario.Click
        '    Dim result
        TxtUsuario.Text = ""
        txtContrasena.Text = ""
        PlaySonidoMouse(lk_CodigoSonido)
        ImagenInicio.Visible = False
        Application.DoEvents()
        PanelLeft.Enabled = False
        PanelLeft.Visible = False


        Dim frCreaUsuario As New FrmCreaUsuario

        AddOwnedForm(frCreaUsuario)
        frCreaUsuario.TopLevel = False
        PanelInicial.Controls.Add(frCreaUsuario)

        frCreaUsuario.PanelOlvidoContrasena.Visible = False
        frCreaUsuario.Panel1.Visible = True
        frCreaUsuario.WindowState = FormWindowState.Maximized
        frCreaUsuario.Show()

        Exit Sub
NoIngresa:
    End Sub



    Private Sub CmdQuienesSomos_Click(sender As Object, e As EventArgs) Handles CmdQuienesSomos.Click

        Try
            System.Diagnostics.Process.Start(lk_pagina_quienessomos)



        Catch
            MsgBox("NO SE PUDO CARGAR LA PAGINA..")
        End Try
    End Sub

    Private Sub CmdComoFunciona_Click(sender As Object, e As EventArgs) Handles CmdComoFunciona.Click

        Try
            System.Diagnostics.Process.Start(lk_pagina_comofunciona)

        Catch
            MsgBox("NO SE PUDO CARGAR LA PAGINA..")
        End Try
    End Sub

    Private Sub CmdConfigurar_Click(sender As Object, e As EventArgs) Handles CmdConfigurar.Click
        PlaySonidoMouse(lk_CodigoSonido)

        If lk_NegocioActivo.id_Negocio = 0 Then
            Dim result = MensajesBox.Show(lkfor_texto_sinnegocio, lk_cabeza_msgbox)
            Exit Sub
        End If
        If Valida_Acceso() = False Then
            Dim result = MensajesBox.Show("Para Tener Acceso a las opciones debe Fijar un Local y Almacen por defecto.", lk_cabeza_msgbox)
            CmdIdNegocio_Click(Nothing, Nothing)
            Exit Sub
        End If

        If LlegoMaximoFormularios(PanelFormularios) Then
            Exit Sub
        End If

        Dim frConfigurar As New FrmMenuConfigurar
        frConfigurar.TopLevel = False
        PanelFormularios.Controls.Add(frConfigurar)
        frConfigurar.WindowState = FormWindowState.Normal
        frConfigurar.Left = 10
        frConfigurar.Top = 10
        frConfigurar.Width = PanelFormularios.Width / 1.1
        frConfigurar.Height = PanelFormularios.Height / 1.1
        frConfigurar.ENLACE_VIENE = "CONFIGURAR"
        frConfigurar.Show()
        PanelFormularios.Controls.Item(PanelFormularios.Controls.Count - 1).BringToFront() ' Ultimo Fomulario a primer plano


    End Sub
    Private Function LlegoMaximoFormularios(wspanel As Panel) As Boolean

        If wspanel.Controls.Count > lk_tope_maxform Then
            Dim result = MensajesBox.Show("Llego al maximo de formulario abiertos, debe de cerrar algunos.", lk_cabeza_msgbox)
            Return True
        End If
        Return False
    End Function

    Private Sub CmdProcesar_Click(sender As Object, e As EventArgs) Handles CmdProcesar.Click
        PlaySonidoMouse(lk_CodigoSonido)
        'If lk_id_Negocio = 0 Then
        '    Dim result = MensajesBox.Show(lkfor_texto_sinnegocio, lk_cabeza_msgbox)
        '    Exit Sub
        'End If PlaySonidoMouse(lk_CodigoSonido)
        If lk_NegocioActivo.id_Negocio = 0 Then
            Dim result = MensajesBox.Show(lkfor_texto_sinnegocio, lk_cabeza_msgbox)
            Exit Sub
        End If
        If Valida_Acceso() = False Then
            Dim result = MensajesBox.Show("Para Tener Acceso a las opciones debe Fijar un Local y Almacen por defecto.", lk_cabeza_msgbox)
            CmdIdNegocio_Click(Nothing, Nothing)
            Exit Sub
        End If
        If LlegoMaximoFormularios(PanelFormularios) Then
            Exit Sub
        End If
        Dim frMenuOperacion As New FrmOperaciones
        frMenuOperacion.Show()
        frMenuOperacion.TopLevel = False


        PanelFormularios.Controls.Add(frMenuOperacion)




        ' frMenuProductos.WindowState = FormWindowState.Normal
        frMenuOperacion.Left = 1
        frMenuOperacion.Top = 5
        ' frMenuProductos.Width = PanelFormularios.Width / 1.1
        ' frMenuProductos.Height = PanelFormularios.Height / 1.1

        PanelFormularios.Controls.Item(PanelFormularios.Controls.Count - 1).BringToFront() ' Ultimo Fomulario a primer plano
        SelectNextControl(ActiveControl, True, True, True, True)
        frMenuOperacion.Focus()
        frMenuOperacion.TxtOperacion.Focus()




    End Sub

    Private Sub CmdProdServ_Click(sender As Object, e As EventArgs) Handles CmdProdServ.Click

        'Dim result As DialogResult = MensajesBox.Show("Esperanos, pronto podras crear tu Negocio con nosotros.")

        'Dim frCreaNegocio As New FrmCreaNegocio
        'PlaySonidoMouse(lk_CodigoSonido)
        'frCreaNegocio.Width = 950
        'frCreaNegocio.ShowDialog()

        'Exit Sub
        If lk_NegocioActivo.id_Negocio = 0 Then
            Dim result = MensajesBox.Show(lkfor_texto_sinnegocio, lk_cabeza_msgbox)
            Exit Sub
        End If

        If Valida_Acceso() = False Then
            Dim result = MensajesBox.Show("Para Tener Acceso a las opciones debe Fijar un Local y Almacen por defecto.", lk_cabeza_msgbox)
            CmdIdNegocio_Click(Nothing, Nothing)
            Exit Sub
        End If

        If LlegoMaximoFormularios(PanelFormularios) Then
            Exit Sub
        End If

        Muestra_Info_Principal(lk_NegocioActivo.id_Negocio)
        PlaySonidoMouse(lk_CodigoSonido)

        Dim frMenuProductos As New FrmProductos
        frMenuProductos.Tag = 100
        frMenuProductos.TxtBuscar.Tag = ""
        frMenuProductos.ModoBusqeuda = "MAESTRO"
        frMenuProductos.TextoBusca = ""
        frMenuProductos.BUS_ID_ALMACEN = lk_AlmacenActivo.id_almacen
        frMenuProductos.BUS_ID_LOCAL = lk_LocalActivo.id_local
        frMenuProductos.Show()
        frMenuProductos.TopLevel = False
        PanelFormularios.Controls.Add(frMenuProductos)
        frMenuProductos.Left = 4
        frMenuProductos.Top = 10
        PanelFormularios.Controls.Item(PanelFormularios.Controls.Count - 1).BringToFront()
        SelectNextControl(ActiveControl, True, True, True, True)
        ' Agregar el enfoque al control "TxtBuscar"
        frMenuProductos.TxtBuscar.Select()
        frMenuProductos.TxtBuscar.Text = ""
        frMenuProductos.TxtBuscar.SelectionStart = 0








    End Sub

    Private Sub CmdGestionar_Click(sender As Object, e As EventArgs) Handles CmdGestionar.Click

        PlaySonidoMouse(lk_CodigoSonido)

        If LlegoMaximoFormularios(PanelFormularios) Then
            Exit Sub
        End If
        'If lk_id_Negocio = 0 Then
        '    Dim result = MensajesBox.Show(lkfor_texto_sinnegocio, lk_cabeza_msgbox)
        '    Exit Sub
        'End If PlaySonidoMouse(lk_CodigoSonido)
        If lk_NegocioActivo.id_Negocio = 0 Then
            Dim result = MensajesBox.Show(lkfor_texto_sinnegocio, lk_cabeza_msgbox)
            Exit Sub
        End If
        If Valida_Acceso() = False Then
            Dim result = MensajesBox.Show("Para Tener Acceso a las opciones debe Fijar un Local y Almacen por defecto.", lk_cabeza_msgbox)
            CmdIdNegocio_Click(Nothing, Nothing)
            Exit Sub
        End If

        Dim frMenuOperacion As New FrmGestionar
        frMenuOperacion.Show()
        frMenuOperacion.TopLevel = False
        PanelFormularios.Controls.Add(frMenuOperacion)




        ' frMenuProductos.WindowState = FormWindowState.Normal
        frMenuOperacion.Left = 4
        frMenuOperacion.Top = 10
        ' frMenuProductos.Width = PanelFormularios.Width / 1.1
        ' frMenuProductos.Height = PanelFormularios.Height / 1.1

        PanelFormularios.Controls.Item(PanelFormularios.Controls.Count - 1).BringToFront() ' Ultimo Fomulario a primer plano
        SelectNextControl(ActiveControl, True, True, True, True)
        frMenuOperacion.Focus()
        'frMenuOperacion.TxtOperacion.Focus()


        'If lk_id_Negocio = 0 Then
        ' Dim result = MensajesBox.Show(lkfor_texto_sinnegocio, lk_cabeza_msgbox)
        ' Exit Sub
        ' End If
    End Sub

    Private Sub CmdReportar_Click(sender As Object, e As EventArgs) Handles CmdReportar.Click
        PlaySonidoMouse(lk_CodigoSonido)
        If lk_id_Negocio = 0 Then
            Dim result = MensajesBox.Show(lkfor_texto_sinnegocio, lk_cabeza_msgbox)
            Exit Sub
        End If
        If Valida_Acceso() = False Then
            Dim result = MensajesBox.Show("Para Tener Acceso a las opciones debe Fijar un Local y Almacen por defecto.", lk_cabeza_msgbox)
            CmdIdNegocio_Click(Nothing, Nothing)
            Exit Sub
        End If
    End Sub

    Private Sub CmdDeclarar_Click(sender As Object, e As EventArgs) Handles CmdDeclarar.Click
        PlaySonidoMouse(lk_CodigoSonido)
        If Valida_Acceso() = False Then
            Dim result = MensajesBox.Show("Para Tener Acceso a las opciones debe Fijar un Local y Almacen por defecto.", lk_cabeza_msgbox)
            CmdIdNegocio_Click(Nothing, Nothing)
            Exit Sub
        End If
        If lk_id_Negocio = 0 Then
            Dim result = MensajesBox.Show(lkfor_texto_sinnegocio, lk_cabeza_msgbox)
            Exit Sub
        End If
    End Sub

    Private Sub CmdIntegrar_Click(sender As Object, e As EventArgs) Handles CmdIntegrar.Click
        PlaySonidoMouse(lk_CodigoSonido)
        If lk_id_Negocio = 0 Then
            Dim result = MensajesBox.Show(lkfor_texto_sinnegocio, lk_cabeza_msgbox)
            Exit Sub
        End If
        If Valida_Acceso() = False Then
            Dim result = MensajesBox.Show("Para Tener Acceso a las opciones debe Fijar un Local y Almacen por defecto.", lk_cabeza_msgbox)
            CmdIdNegocio_Click(Nothing, Nothing)
            Exit Sub
        End If
    End Sub

    Private Sub cmdayuda_Click(sender As Object, e As EventArgs) Handles cmdayuda.Click
        PlaySonidoMouse(lk_CodigoSonido)




    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles FotoNegocio.Click
        CmdIdNegocio_Click(Nothing, Nothing)
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles FotoNegocio.Paint
        '' Podemos mejorar el aspecto del borde redondeado aplicando antialias
        '' Graphics.SmoothingMode obtiene o establece la calidad de la representación del objeto Graphics
        'e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        '' Creamos un objeto de la clase GraphicsPath que representa una serie de líneas y curvas conectadas
        'Dim curra As GraphicsPath = New GraphicsPath
        '' Manipulando las variables que se corresponden con los puntos x.y, ancho y alto de la figura podemos variar su aspecto
        'Dim x, y, ancho, alto As Integer
        '' Posiciones x.y del objeto curra (las del control PictureBox)
        'x = PictureBox1.Left
        'y = PictureBox1.Top
        '' Anchura y altura del objeto curra, un poco menores que las del PictureBox para que se vea bien ajustado al control
        'ancho = PictureBox1.Width - 24
        'alto = PictureBox1.Height - 24
        '' Usamos el método AddEllipse para agregar la forma de un círculo o elipse al trazado actual (el control PictureBox)
        'curra.AddEllipse(New Rectangle(x, y, ancho, alto))
        '' En el PictureBox creamos una región que se corresponde con la forma del objeto GraphicsPath (cículo)
        '' y se dibuja en el PictureBox asignando el objeto curra a la región
        '' Region de System.Drawing describe el interior de una forma gráfica formada por rectángulos y trazados
        'Dim reg As Region
        'reg = New Region(curra)
        'PictureBox1.Region = reg
        '' Otra forma de realizarlo
        ''pBox.Region = New Region(curra)



    End Sub

    Private Sub FrmLogin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '  TxtUsuario.fo
        TxtUsuario.Focus()
    End Sub

    Private Sub CmdIdNegocio_Click(sender As Object, e As EventArgs) Handles CmdIdNegocio.Click


        'Dim result As DialogResult = MensajesBox.Show("Esperanos, pronto podras crear tu Negocio con nosotros.")
        Dim frDefectoNegocio As New FrmPorDefectoNegocio
        PlaySonidoMouse(lk_CodigoSonido)
        'frDefectoNegocio.Width = 950
        frDefectoNegocio.ShowDialog()
        '        Dim result = MensajesBox.Show(lkfor_texto_sinnegocio, lk_cabeza_msgbox)


    End Sub


    Private Sub TxtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUsuario.KeyPress
        e.Handled = Solo_TextoNumero(e)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        On Error GoTo sale

        Exit Sub
        If PublicidadInicio.Tag = "" Then
            PublicidadInicio.Image = Image.FromFile("H:\Acosme\Proyecto VEX - Movilidad Privado\Publicidad  Cinta Favorit\convenios\AutoBoutique\trux02-fina.gif")
            PublicidadInicio.Refresh()
            PublicidadInicio.Tag = "1"
        Else
            PublicidadInicio.Image = Image.FromFile("H:\Acosme\Proyecto VEX - Movilidad Privado\Publicidad  Cinta Favorit\convenios\celulares\celulares.gif")
            PublicidadInicio.Refresh()
            PublicidadInicio.Tag = ""
        End If

sale:
    End Sub

    Private Sub CmdOlvide_Click(sender As Object, e As EventArgs) Handles CmdOlvide.Click




        ImagenInicio.Visible = False
        Application.DoEvents()
        PanelLeft.Enabled = False
        PanelLeft.Visible = False

        Dim frCreaUsuario As New FrmCreaUsuario
        PlaySonidoMouse(lk_CodigoSonido)
        AddOwnedForm(frCreaUsuario)
        frCreaUsuario.TopLevel = False
        PanelInicial.Controls.Add(frCreaUsuario)
        frCreaUsuario.WindowState = FormWindowState.Maximized

        frCreaUsuario.Panel1.Visible = False
        frCreaUsuario.LblTitulo.Text = "Aquí te ayudamos a Restablecer tu Contraseña..."
        frCreaUsuario.PanelOlvidoContrasena.Visible = True

        frCreaUsuario.Show()


    End Sub

    Private Sub DescargaInicial_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles DescargaInicial.DoWork
        If isOnline() Then
            WsONOFF = 1
        Else
            WsONOFF = 0
        End If
    End Sub

    Private Sub DescargaInicial_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles DescargaInicial.RunWorkerCompleted
        If WsONOFF = 1 Then

            Me.LblEstadoRed.Text = "Conectado"
            Me.LblEstadoRed.ForeColor = Color.GreenYellow
            Me.LblEstadoRed.Tag = 1
            lk_onOfff = True
            CircularProgressBar1.Visible = False
            If Descargas.IsBusy = False Then
                Descargas.RunWorkerAsync()
            End If
        Else
            lk_onOfff = False
            Me.LblEstadoRed.Visible = True
            Me.LblEstadoRed.Text = "Sin Internet..."
            Me.LblEstadoRed.ForeColor = Color.Red
            Me.LblEstadoRed.Tag = 0
            CircularProgressBar1.Visible = True
        End If
    End Sub

    Private Sub Intenta_Tick(sender As Object, e As EventArgs) Handles Intenta.Tick
        If DescargaInicial.IsBusy = False Then
            DescargaInicial.RunWorkerAsync()
        End If

    End Sub

    Private Sub CmdConfigurPerfil_Click(sender As Object, e As EventArgs) Handles CmdConfigurPerfil.Click
        Dim frPerfil As New FrmPerfil
        PlaySonidoMouse(lk_CodigoSonido)
        If lk_rutalocal_foto = "X" Then Exit Sub

        frPerfil.ShowDialog()

        If lk_rutalocal_foto <> "" Then Me.FotoUsuario.Image = Image.FromFile(lk_rutalocal_foto)


    End Sub

    Private Sub PanelSup_Paint(sender As Object, e As PaintEventArgs) Handles PanelSup.Paint

    End Sub
    Private Sub IniciarRegistros_tablasBasesORI()
        If lk_usuario = "" Then Exit Sub

        Dim command As SqlCommand = New SqlCommand("u_obtenerTipoDoc", lk_connection_master)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        lk_sql_ListaTipoDocPersona = New DataTable
        adapter.Fill(lk_sql_ListaTipoDocPersona)

        CargaUBIGEOS()

    End Sub

    Private Sub TxtUsuario_TextChanged(sender As Object, e As EventArgs) Handles TxtUsuario.TextChanged

    End Sub

    Private Sub TxtUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUsuario.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            e.SuppressKeyPress = True
            SelectNextControl(ActiveControl, True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub txtContrasena_TextChanged(sender As Object, e As EventArgs) Handles txtContrasena.TextChanged

    End Sub

    Private Sub txtContrasena_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContrasena.KeyDown
        If e.KeyCode = Keys.Enter AndAlso ActiveControl IsNot Nothing Then
            e.SuppressKeyPress = True
            SelectNextControl(ActiveControl, True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub CmdCreaTuNegocio_Click(sender As Object, e As EventArgs) Handles CmdCreaTuNegocio.Click
        'Dim result As DialogResult = MensajesBox.Show("Esperanos, pronto podras crear tu Negocio con nosotros.")
        Dim frCreaNegocio As New FrmCreaNegocio
        PlaySonidoMouse(lk_CodigoSonido)
        frCreaNegocio.Width = 1000
        frCreaNegocio.ShowDialog()



    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CmdIniciar_MouseEnter(sender As Object, e As EventArgs) Handles CmdIniciar.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub CmdIdNegocio_MouseEnter(sender As Object, e As EventArgs) Handles CmdIdNegocio.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub CmdQuienesSomos_MouseEnter(sender As Object, e As EventArgs) Handles CmdQuienesSomos.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub CmdComoFunciona_MouseEnter(sender As Object, e As EventArgs) Handles CmdComoFunciona.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub CmdCreaTuNegocio_MouseEnter(sender As Object, e As EventArgs) Handles CmdCreaTuNegocio.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub CmdConfigurPerfil_MouseEnter(sender As Object, e As EventArgs) Handles CmdConfigurPerfil.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub CmdCrearUsuario_MouseEnter(sender As Object, e As EventArgs) Handles CmdCrearUsuario.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub CmdProdServ_MouseEnter(sender As Object, e As EventArgs) Handles CmdProdServ.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub CmdConfigurar_MouseEnter(sender As Object, e As EventArgs) Handles CmdConfigurar.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub CmdProcesar_MouseEnter(sender As Object, e As EventArgs) Handles CmdProcesar.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub CmdGestionar_MouseEnter(sender As Object, e As EventArgs) Handles CmdGestionar.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub CmdReportar_MouseEnter(sender As Object, e As EventArgs) Handles CmdReportar.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub CmdDeclarar_MouseEnter(sender As Object, e As EventArgs) Handles CmdDeclarar.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub CmdIntegrar_MouseEnter(sender As Object, e As EventArgs) Handles CmdIntegrar.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub cmdayuda_MouseEnter(sender As Object, e As EventArgs) Handles cmdayuda.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub CmdSalir_MouseEnter(sender As Object, e As EventArgs) Handles CmdSalir.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub MarcoPerfil_Click(sender As Object, e As EventArgs) Handles MarcoPerfil.Click
        If Panel1.Tag = "" Then
            MarcoPerfil.Image = My.Resources.fondo1
            Panel1.Tag = "1"
        ElseIf Panel1.Tag = "1" Then
            MarcoPerfil.Image = My.Resources.fondo2
            Panel1.Tag = "2"
        ElseIf Panel1.Tag = "2" Then
            MarcoPerfil.Image = My.Resources.fondo3
            Panel1.Tag = "3"
        ElseIf Panel1.Tag = "3" Then
            MarcoPerfil.Image = My.Resources.fondo4
            Panel1.Tag = "4"
        ElseIf Panel1.Tag = "4" Then
            MarcoPerfil.Image = My.Resources.fondo5
            Panel1.Tag = ""



        End If
    End Sub

    Private Sub CmdReiniciar_Click(sender As Object, e As EventArgs) Handles CmdReiniciar.Click
        'Cierra todas las formas abiertas
        ' For Each frm As Form In Application.OpenForms
        ' frm.Close()
        '  Next

        'Reinicia la aplicación
        Application.Restart()
    End Sub

    Private Sub FechaHoraVPS_Tick(sender As Object, e As EventArgs) Handles FechaHoraVPS.Tick
        lk_fecha_dia = lk_fecha_dia.AddSeconds(1)
        Application.DoEvents()
        Me.Lbl_Fecha_VPS.Text = Format(lk_fecha_dia, "dd/MM/yyyy")
        Me.Lbl_Hora_VPS.Text = Format(lk_fecha_dia, "hh:mm::ss")
    End Sub




    Private Sub B_VENTAS_MouseEnter(sender As Object, e As EventArgs) Handles B_VENTAS.MouseEnter
        PlaySonidoMouse(4)
    End Sub

    Private Sub B_COMPRAS_Click(sender As Object, e As EventArgs) Handles B_COMPRAS.Click

    End Sub

    Private Sub CmdAdmin_Click(sender As Object, e As EventArgs) Handles CmdAdmin.Click
        PlaySonidoMouse(lk_CodigoSonido)

        Dim frmAdmin As New FrmOper
        PlaySonidoMouse(lk_CodigoSonido)
        frmAdmin.Show()
        frmAdmin.TopLevel = False
        PanelFormularios.Controls.Add(frmAdmin)
        frmAdmin.Left = 10
        frmAdmin.Top = 10

        PanelFormularios.Controls.Item(PanelFormularios.Controls.Count - 1).BringToFront() ' Ultimo Fomulario a primer plano


        SelectNextControl(ActiveControl, True, True, True, True)


    End Sub

    Private Sub FotoUsuario_Click(sender As Object, e As EventArgs) Handles FotoUsuario.Click
        CmdConfigurPerfil_Click(Nothing, Nothing)
    End Sub

    Private Sub B_COMPRAS_MouseEnter(sender As Object, e As EventArgs) Handles B_COMPRAS.MouseEnter
        PlaySonidoMouse(4)
    End Sub

    Private Sub B_CLIENTES_Click(sender As Object, e As EventArgs) Handles B_PROD_POR_VENCER.Click

    End Sub

    Private Sub B_CLIENTES_MouseEnter(sender As Object, e As EventArgs) Handles B_PROD_POR_VENCER.MouseEnter
        PlaySonidoMouse(4)
    End Sub

    Private Sub B_PRODUCTOS_Click(sender As Object, e As EventArgs) Handles B_PROD_VENC.Click

    End Sub

    Private Sub B_PRODUCTOS_MouseEnter(sender As Object, e As EventArgs) Handles B_PROD_VENC.MouseEnter
        PlaySonidoMouse(4)
    End Sub

    Private Sub B_PORVENCER_Click(sender As Object, e As EventArgs) Handles B_PORVENCER.Click

    End Sub

    Private Sub B_PORVENCER_MouseEnter(sender As Object, e As EventArgs) Handles B_PORVENCER.MouseEnter
        PlaySonidoMouse(4)
    End Sub

    Private Sub B_VENCIDOS_Click(sender As Object, e As EventArgs) Handles B_VENCIDOS.Click

    End Sub

    Private Sub B_VENCIDOS_MouseEnter(sender As Object, e As EventArgs) Handles B_VENCIDOS.MouseEnter
        PlaySonidoMouse(4)
    End Sub

    Private Sub B_CREDITOS_Click(sender As Object, e As EventArgs) Handles B_CREDITOS.Click

    End Sub

    Private Sub B_CREDITOS_MouseEnter(sender As Object, e As EventArgs) Handles B_CREDITOS.MouseEnter
        PlaySonidoMouse(4)
    End Sub

    Private Sub B_CREDITOVENCIDOS_Click(sender As Object, e As EventArgs) Handles B_CREDITOVENCIDOS.Click

    End Sub

    Private Sub B_CREDITOVENCIDOS_MouseEnter(sender As Object, e As EventArgs) Handles B_CREDITOVENCIDOS.MouseEnter
        PlaySonidoMouse(4)
    End Sub

    Private Sub PublicidadInicio_Click(sender As Object, e As EventArgs) Handles PublicidadInicio.Click

    End Sub

    Private Sub CmdProdServ_MouseHover(sender As Object, e As EventArgs) Handles CmdProdServ.MouseHover
        Dim boton As Button = CType(sender, Button)
        tt_leyenda.SetToolTip(sender, boton.Text)
    End Sub

    Private Sub CmdConfigurar_MouseHover(sender As Object, e As EventArgs) Handles CmdConfigurar.MouseHover
        Dim boton As Button = CType(sender, Button)
        tt_leyenda.SetToolTip(sender, boton.Text)

    End Sub

    Private Sub CmdProcesar_MouseHover(sender As Object, e As EventArgs) Handles CmdProcesar.MouseHover
        Dim boton As Button = CType(sender, Button)
        tt_leyenda.SetToolTip(sender, boton.Text)

    End Sub

    Private Sub CmdGestionar_MouseHover(sender As Object, e As EventArgs) Handles CmdGestionar.MouseHover
        Dim boton As Button = CType(sender, Button)
        tt_leyenda.SetToolTip(sender, boton.Text)

    End Sub

    Private Sub CmdReportar_MouseHover(sender As Object, e As EventArgs) Handles CmdReportar.MouseHover
        Dim boton As Button = CType(sender, Button)
        tt_leyenda.SetToolTip(sender, boton.Text)

    End Sub

    Private Sub CmdDeclarar_MouseHover(sender As Object, e As EventArgs) Handles CmdDeclarar.MouseHover
        Dim boton As Button = CType(sender, Button)
        tt_leyenda.SetToolTip(sender, boton.Text)

    End Sub

    Private Sub CmdIntegrar_MouseHover(sender As Object, e As EventArgs) Handles CmdIntegrar.MouseHover
        Dim boton As Button = CType(sender, Button)
        tt_leyenda.SetToolTip(sender, boton.Text)

    End Sub

    Private Sub cmdayuda_MouseHover(sender As Object, e As EventArgs) Handles cmdayuda.MouseHover
        Dim boton As Button = CType(sender, Button)
        tt_leyenda.SetToolTip(sender, boton.Text)

    End Sub
    Private Sub Muestra_Info_Principal(wid_negocio)
        If wid_negocio Is Nothing Then Exit Sub
        Dim sql As String = "exec [sp_info_ObtenerCantidadProductosVcto] " & wid_negocio & ""
        Dim command As New SqlCommand(sql, lk_connection_cuenta)
        Dim adapter As New SqlDataAdapter(command)
        datos_sql_resul = New DataTable()
        adapter.Fill(datos_sql_resul)
        Dim Result As String = ""
        If datos_sql_resul.Rows.Count = 0 Then
        Else
            Result = "PROD. VENCIDOS " & vbCrLf & Format(datos_sql_resul.Rows(0).Item("cantidad_productos_vencidos").ToString, "0")
            B_PROD_VENC.Text = Result
            Result = "PROD. POR VENDER " & vbCrLf & Format(datos_sql_resul.Rows(0).Item("cantidad_productos_con_fecha_aviso_alerta").ToString, "0")
            B_PROD_POR_VENCER.Text = Result

        End If


    End Sub

    Private Sub CmdCajas_Click(sender As Object, e As EventArgs) Handles CmdCajas.Click
        PlaySonidoMouse(lk_CodigoSonido)
        If lk_NegocioActivo.id_Negocio = 0 Then
            Dim result = MensajesBox.Show(lkfor_texto_sinnegocio, lk_cabeza_msgbox)
            Exit Sub
        End If
        If Valida_Acceso() = False Then
            Dim result = MensajesBox.Show("Para Tener Acceso a las opciones debe Fijar un Local y Almacen por defecto.", lk_cabeza_msgbox)
            CmdIdNegocio_Click(Nothing, Nothing)
            Exit Sub
        End If
        If LlegoMaximoFormularios(PanelFormularios) Then
            Exit Sub
        End If


        Dim frControlCajas As New FrmControlCajas

        frControlCajas.TopLevel = False
        frControlCajas.Visible = False
        PanelFormularios.Controls.Add(frControlCajas)

        frControlCajas.WindowState = FormWindowState.Normal
        'frConfigurar.Top = PanelMenu.Top + 15
        'frConfigurar.Left = PanelSup.Left + 15
        frControlCajas.Left = 10
        frControlCajas.Top = 10
        'frControlCajas.Width = PanelFormularios.Width / 1.1
        'frControlCajas.Height = PanelFormularios.Height / 1.1

        'frConfigurarShowDialog(this)
        'frConfigurar.TopMost = True
        frControlCajas.Show()
        If frControlCajas.ES_FORMZAR_CIERRE = 1 Then
            frControlCajas.Close()
        End If


        PanelFormularios.Controls.Item(PanelFormularios.Controls.Count - 1).BringToFront() ' Ultimo Fomulario a primer plano

    End Sub

    Private Sub CmdCajas_MouseHover(sender As Object, e As EventArgs) Handles CmdCajas.MouseHover
        Dim boton As Button = CType(sender, Button)
        tt_leyenda.SetToolTip(sender, boton.Text)

    End Sub

    Private Sub CmdCajas_MouseEnter(sender As Object, e As EventArgs) Handles CmdCajas.MouseEnter
        PlaySonidoMouse(lk_CodigoSonido_pasa)
    End Sub

    Private Sub FrmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Dim Result As String = MensajesBox.Show("¿Estás seguro de que deseas cerrar la aplicación? ", "Confirmación de cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If Result = "7" Or Result = "2" Then ' es NO
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub Acoplar(es_acoplar As Boolean)
        Dim tooltip As New ToolTip()
        Dim miAlineacion As ContentAlignment
        Dim wtam As Integer = 0
        If es_acoplar Then
            CmdProdServ.Text = ""
            CmdConfigurar.Text = ""
            CmdCajas.Text = ""
            CmdProcesar.Text = ""
            CmdGestionar.Text = ""
            CmdReportar.Text = ""
            CmdDeclarar.Text = ""
            CmdIntegrar.Text = ""
            cmdayuda.Text = ""

            tooltip.SetToolTip(CmdProdServ, CmdProdServ.Tag)
            tooltip.SetToolTip(CmdConfigurar, CmdConfigurar.Tag)
            tooltip.SetToolTip(CmdCajas, CmdCajas.Tag)
            tooltip.SetToolTip(CmdProcesar, CmdProcesar.Tag)
            tooltip.SetToolTip(CmdGestionar, CmdGestionar.Tag)
            tooltip.SetToolTip(CmdReportar, CmdReportar.Tag)
            tooltip.SetToolTip(CmdDeclarar, CmdDeclarar.Tag)
            tooltip.SetToolTip(CmdIntegrar, CmdIntegrar.Tag)
            tooltip.SetToolTip(cmdayuda, cmdayuda.Tag)


            miAlineacion = ContentAlignment.MiddleLeft
            PanelMenu.Width = 30
            wtam = 25

            Lbl_Fecha_VPS.Visible = False
            Lbl_Hora_VPS.Visible = False
            Lbl_Version_ORI.Visible = False


        Else

            CmdProdServ.Text = CmdProdServ.Tag
            CmdConfigurar.Text = CmdConfigurar.Tag
            CmdCajas.Text = CmdCajas.Tag
            CmdProcesar.Text = CmdProcesar.Tag
            CmdGestionar.Text = CmdGestionar.Tag
            CmdReportar.Text = CmdReportar.Tag
            CmdDeclarar.Text = CmdDeclarar.Tag
            CmdIntegrar.Text = CmdIntegrar.Tag
            cmdayuda.Text = cmdayuda.Tag

            tooltip.SetToolTip(CmdProdServ, "")
            tooltip.SetToolTip(CmdConfigurar, "")
            tooltip.SetToolTip(CmdCajas, "")
            tooltip.SetToolTip(CmdProcesar, "")
            tooltip.SetToolTip(CmdGestionar, "")
            tooltip.SetToolTip(CmdReportar, "")
            tooltip.SetToolTip(CmdDeclarar, "")
            tooltip.SetToolTip(CmdIntegrar, "")
            tooltip.SetToolTip(cmdayuda, "")



            miAlineacion = ContentAlignment.TopCenter
            PanelMenu.Width = 63
            wtam = 25

            Lbl_Fecha_VPS.Visible = True
            Lbl_Hora_VPS.Visible = True
            Lbl_Version_ORI.Visible = True

        End If




        CmdProdServ.IconSize = wtam
        CmdConfigurar.IconSize = wtam
        CmdCajas.IconSize = wtam
        CmdProcesar.IconSize = wtam
        CmdGestionar.IconSize = wtam
        CmdReportar.IconSize = wtam
        CmdDeclarar.IconSize = wtam
        CmdIntegrar.IconSize = wtam
        cmdayuda.IconSize = wtam

        CmdProdServ.ImageAlign = miAlineacion
        CmdConfigurar.ImageAlign = miAlineacion
        CmdCajas.ImageAlign = miAlineacion
        CmdProcesar.ImageAlign = miAlineacion
        CmdGestionar.ImageAlign = miAlineacion
        CmdReportar.ImageAlign = miAlineacion
        CmdDeclarar.ImageAlign = miAlineacion
        CmdIntegrar.ImageAlign = miAlineacion
        cmdayuda.ImageAlign = miAlineacion
    End Sub

    Private Sub FrmLogin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub FrmLogin_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Me.PreviewKeyDown
        If e.KeyCode = Keys.G AndAlso Control.ModifierKeys = Keys.Control Then
            ' Evita que se procese la tecla normalmente.
            e.IsInputKey = True

            ' Muestra un MsgBox cuando se presionan "Ctrl+G".
            CmdProcesar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs)
        ' Obtén el valor actual del TrackBar y conviértelo en un factor de zoom.

    End Sub
End Class