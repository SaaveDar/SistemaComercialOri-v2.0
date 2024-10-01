Imports System.Drawing, System.Drawing.Drawing2D
Imports Newtonsoft.Json
Imports WindowsApp1.clsJson
Imports System.Text
Imports System.Net.NetworkInformation
Imports System
Imports WindowsApp1.Negocio.ListaNegocio
Imports System.Net
Imports System.Drawing.Imaging
Imports System.Data.SqlClient
Imports System.IO
Imports System.Globalization
Imports Microsoft.Win32

Module Funciones
    Dim WithEvents CLIENTE As New WebClient 'LO DECLARAMOS CON EVENTS PARA PODER UTILIZAR LOS PROCEDIMIENTOS PROGRESSCHANGED Y COMPLETED
    Public Function Valida_Acceso() As Boolean
        Valida_Acceso = True
        If lk_AlmacenActivo.id_almacen = Nothing Then
            Valida_Acceso = False
        End If
        ''      Stop
        'MsgBox(lk_LocalActivo.id_local)

    End Function
    Public Sub Negocio_Local_Almacen_Usuario()
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Dim tempColumn As DataColumn
        Dim flag_propios As Integer = 0

        ' Datos de Negocio , local y almacen por defcto
        Dim wid_neg_def As Integer = Val(lk_sql_ValidaUsuario.Rows(0)("id_neg_def").ToString())
        Dim wid_loc_def As Integer = Val(lk_sql_ValidaUsuario.Rows(0)("id_loc_def").ToString())
        Dim wid_alm_def As Integer = Val(lk_sql_ValidaUsuario.Rows(0)("id_alm_def").ToString())

        Dim windex_Negoio As Integer = -1
        Dim windex_local As Integer = -1
        Dim windex_almacen As Integer = -1







        command = New SqlCommand("sp_acceso_negocios", lk_connection_master)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@id_usuario", lk_id_usuario)
        adapter = New SqlDataAdapter(command)
        lk_sql_Usuario_negocio = New DataTable
        adapter.Fill(lk_sql_Usuario_negocio)
        tempColumn = New DataColumn("fotonegociolocal", GetType(String))

        lk_sql_Usuario_negocio.Columns.Add(tempColumn)

        If lk_sql_Usuario_negocio.Rows.Count = 0 Then
            Exit Sub
        End If


        Try

            For I = 0 To lk_sql_Usuario_negocio.Rows.Count - 1
                If lk_sql_Usuario_negocio.Rows(I)("TIPO").ToString = "PROPIO" Then flag_propios = 1
                If wid_neg_def = Val(lk_sql_Usuario_negocio.Rows(I)("id_negocio").ToString) Then windex_Negoio = I
                If lk_sql_Usuario_negocio.Rows(I)("neg_fotonegocio").ToString = "-" Then
                    lk_sql_Usuario_negocio.Rows(I)("fotonegociolocal") = "-"
                Else

                    Dim wRutaLocalfile As String = lk_Carpeta_Temp & System.IO.Path.GetFileName(lk_sql_Usuario_negocio.Rows(I)("neg_fotonegocio").ToString)
                    If System.IO.File.Exists(wRutaLocalfile) Then

                    Else
                        CLIENTE.DownloadFile(New Uri(lk_sql_Usuario_negocio.Rows(I)("neg_fotonegocio").ToString), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                    End If
                    lk_sql_Usuario_negocio.Rows(I)("fotonegociolocal") = wRutaLocalfile

                End If
            Next


        Catch ex As Exception
            MsgBox("ERRO RECARGARNEGOCIOS ")
            Exit Sub
        End Try

        command = New SqlCommand("sp_acceso_locales", lk_connection_master)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@id_usuario", lk_id_usuario)
        adapter = New SqlDataAdapter(command)
        lk_sql_Usuario_local = New DataTable
        adapter.Fill(lk_sql_Usuario_local)
        tempColumn = New DataColumn("fotolocal_local", GetType(String))
        lk_sql_Usuario_local.Columns.Add(tempColumn)
        tempColumn = New DataColumn("fotolocallocal_Defecto", GetType(Bitmap))
        lk_sql_Usuario_local.Columns.Add(tempColumn)


        If lk_sql_Usuario_local.Rows.Count = 0 Then
            Exit Sub
        End If
        Try

            For I = 0 To lk_sql_Usuario_local.Rows.Count - 1
                If wid_loc_def = Val(lk_sql_Usuario_local.Rows(I)("id_local").ToString) Then windex_local = I
                If lk_sql_Usuario_local.Rows(I)("local_fotolocal").ToString = "-" Then
                    lk_sql_Usuario_local.Rows(I)("fotolocal_local") = "-"
                Else

                    Dim wRutaLocalfile As String = lk_Carpeta_Temp & System.IO.Path.GetFileName(lk_sql_Usuario_local.Rows(I)("local_fotolocal").ToString)
                    If System.IO.File.Exists(wRutaLocalfile) Then

                    Else
                        CLIENTE.DownloadFile(New Uri(lk_sql_Usuario_local.Rows(I)("local_fotolocal").ToString), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                    End If
                    lk_sql_Usuario_local.Rows(I)("fotolocal_local") = wRutaLocalfile

                End If
            Next


        Catch ex As Exception
            MsgBox("ERRO RECARGARNEGOCIOS ")
            Exit Sub
        End Try

        command = New SqlCommand("sp_acceso_almacenes", lk_connection_master)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@id_usuario", lk_id_usuario)
        adapter = New SqlDataAdapter(command)
        lk_sql_Usuario_almacen = New DataTable
        adapter.Fill(lk_sql_Usuario_almacen)
        tempColumn = New DataColumn("fotoalmacen_local", GetType(String))
        lk_sql_Usuario_almacen.Columns.Add(tempColumn)
        tempColumn = New DataColumn("fotoalmacenlocal_Defecto", GetType(Bitmap))
        lk_sql_Usuario_almacen.Columns.Add(tempColumn)

        If lk_sql_Usuario_almacen.Rows.Count = 0 Then
            Exit Sub
        End If
        Try

            For I = 0 To lk_sql_Usuario_almacen.Rows.Count - 1
                If wid_alm_def = Val(lk_sql_Usuario_almacen.Rows(I)("id_almacen").ToString) Then windex_almacen = I
                If lk_sql_Usuario_almacen.Rows(I)("alm_fotoalmacen").ToString = "-" Then
                    lk_sql_Usuario_almacen.Rows(I)("fotoalmacen_local") = "-"
                Else

                    Dim wRutaLocalfile As String = lk_Carpeta_Temp & System.IO.Path.GetFileName(lk_sql_Usuario_almacen.Rows(I)("alm_fotoalmacen").ToString)
                    If System.IO.File.Exists(wRutaLocalfile) Then

                    Else
                        CLIENTE.DownloadFile(New Uri(lk_sql_Usuario_almacen.Rows(I)("alm_fotoalmacen").ToString), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                    End If
                    lk_sql_Usuario_almacen.Rows(I)("fotoalmacen_local") = wRutaLocalfile

                End If
            Next


        Catch ex As Exception
            MsgBox("ERRO RECARGARNEGOCIOS ")
            Exit Sub
        End Try

        If windex_Negoio = -1 Then
            windex_Negoio = 0
            windex_almacen = 0
            windex_local = 0
        End If

        lk_NegocioActivo.id_Negocio = lk_sql_Usuario_negocio.Rows(windex_Negoio)("id_negocio").ToString
        lk_NegocioActivo.estado = lk_sql_Usuario_negocio.Rows(windex_Negoio)("estado").ToString
        lk_NegocioActivo.numdoc = lk_sql_Usuario_negocio.Rows(windex_Negoio)("neg_numerodoc").ToString
        lk_NegocioActivo.tipodoc = lk_sql_Usuario_negocio.Rows(windex_Negoio)("des_tipdoc").ToString

        lk_NegocioActivo.nombre = lk_sql_Usuario_negocio.Rows(windex_Negoio)("neg_nombre").ToString
        lk_NegocioActivo.nombrecomercial = lk_sql_Usuario_negocio.Rows(windex_Negoio)("neg_abreviado").ToString
        lk_NegocioActivo.fotonegocio = lk_sql_Usuario_negocio.Rows(windex_Negoio)("fotonegociolocal").ToString


        If windex_local < 0 Then Exit Sub ' no hay acceso

        lk_LocalActivo.id_Negocio = lk_sql_Usuario_negocio.Rows(windex_Negoio)("id_negocio").ToString
        lk_LocalActivo.id_local = lk_sql_Usuario_local.Rows(windex_local)("id_local").ToString
        lk_LocalActivo.estado = lk_sql_Usuario_local.Rows(windex_local)("estado").ToString
        lk_LocalActivo.codigo = lk_sql_Usuario_local.Rows(windex_local)("local_codigo").ToString
        lk_LocalActivo.nombre = lk_sql_Usuario_local.Rows(windex_local)("local_nombre").ToString
        lk_LocalActivo.abreviado = lk_sql_Usuario_local.Rows(windex_local)("local_abreviado").ToString
        lk_LocalActivo.fotolocal = lk_sql_Usuario_local.Rows(windex_local)("fotolocal_local").ToString
        If windex_almacen < 0 Then Exit Sub
        lk_AlmacenActivo.id_almacen = lk_sql_Usuario_almacen.Rows(windex_almacen)("id_almacen").ToString
        lk_AlmacenActivo.id_local = lk_sql_Usuario_local.Rows(windex_local)("id_local").ToString
        lk_AlmacenActivo.id_Negocio = lk_sql_Usuario_negocio.Rows(windex_Negoio)("id_negocio").ToString

        lk_AlmacenActivo.codigo = lk_sql_Usuario_almacen.Rows(windex_almacen)("alm_codigo").ToString
        lk_AlmacenActivo.nombre = lk_sql_Usuario_almacen.Rows(windex_almacen)("alm_nombre").ToString
        lk_AlmacenActivo.abreviado = lk_sql_Usuario_almacen.Rows(windex_almacen)("alm_abreviado").ToString
        lk_AlmacenActivo.fotoalmacen = lk_sql_Usuario_almacen.Rows(windex_almacen)("fotoalmacen_local").ToString

    End Sub


    Public Sub RECARGARNEGOCIOS()
        Dim command As SqlCommand = New SqlCommand("n_lista_neg_maestro", lk_connection_master)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@id", lk_id_usuario)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        lk_sql_Usuario_negocio = New DataTable
        adapter.Fill(lk_sql_Usuario_negocio)
        Dim tempColumn As DataColumn = New DataColumn("fotonegociolocal", GetType(String))
        lk_sql_Usuario_negocio.Columns.Add(tempColumn)


        Try

            For I = 0 To lk_sql_Usuario_negocio.Rows.Count - 1

                If lk_sql_Usuario_negocio.Rows(I)("fotonegocio").ToString = "-" Then
                    lk_sql_Usuario_negocio.Rows(I)("fotonegociolocal") = "-"
                Else

                    Dim wRutaLocalfile As String = lk_Carpeta_Temp & System.IO.Path.GetFileName(lk_sql_Usuario_negocio.Rows(I)("fotonegocio").ToString)
                    If System.IO.File.Exists(wRutaLocalfile) Then

                    Else
                        CLIENTE.DownloadFile(New Uri(lk_sql_Usuario_negocio.Rows(I)("fotonegocio").ToString), wRutaLocalfile) ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                    End If
                    lk_sql_Usuario_negocio.Rows(I)("fotonegociolocal") = wRutaLocalfile

                End If
            Next


        Catch ex As Exception
            MsgBox("ERRO RECARGARNEGOCIOS ")
            Exit Sub
        End Try
    End Sub


    Public Sub FaltaDAtosValidating(wfaltadatos As ErrorProvider, wsender As Object, wmensaje As String)
        If DirectCast(wsender, TextBox).Text <> "" Then
            wfaltadatos.SetError(wsender, "")
        Else
            wfaltadatos.SetError(wsender, wmensaje)
        End If
    End Sub

    Public Function Solo_TextoNumero(wtecla As KeyPressEventArgs) As Boolean
        If Not (Char.IsLetter(wtecla.KeyChar)) = True And Not IsNumeric(wtecla.KeyChar()) = True And wtecla.KeyChar <> ChrW(Keys.Back) Then
            Solo_TextoNumero = True
        Else
            Solo_TextoNumero = False
        End If
    End Function


    Public Function Solo_Texto(wtecla As KeyPressEventArgs) As Boolean
        If Not (Char.IsLetter(wtecla.KeyChar)) = True And wtecla.KeyChar <> ChrW(Keys.Back) And wtecla.KeyChar <> ChrW(Keys.Space) Then
            Solo_Texto = True
        Else
            Solo_Texto = False
        End If

    End Function

    Public Function Solo_Numero(wtecla As KeyPressEventArgs) As Boolean
        If Not IsNumeric(wtecla.KeyChar()) = True And wtecla.KeyChar <> ChrW(Keys.Back) Then
            Solo_Numero = True
        Else
            Solo_Numero = False
        End If

    End Function
    Public Function Solo_Numerico(wtecla As KeyPressEventArgs, textBox As TextBox) As Boolean

        If (Not Char.IsDigit(wtecla.KeyChar) AndAlso wtecla.KeyChar <> ChrW(Keys.Back) AndAlso wtecla.KeyChar <> "."c) Then
            Solo_Numerico = True
        ElseIf (wtecla.KeyChar = "."c AndAlso textBox.Text.Contains(".")) Then
            Solo_Numerico = True
        Else
            Solo_Numerico = False
        End If

        'If (Not Char.IsDigit(wtecla.KeyChar) AndAlso wtecla.KeyChar <> ChrW(Keys.Back) AndAlso wtecla.KeyChar <> "."c) Then
        '    Solo_Numerico = True
        'Else
        '    Solo_Numerico = False
        'End If

        'If KeyData.KeyChar() >= ChrW(Keys.A) And KeyData.KeyChar() <= ChrW(Keys.Z) Then
        '    Return False
        'End If

        'If KeyData.KeyChar() = ChrW(Keys.Add) Or KeyData.KeyChar() = ChrW(Keys.Subtract) Or KeyData.KeyChar() = ChrW(Keys.Multiply) Or KeyData.KeyChar() = ChrW(Keys.Divide) Or KeyData.KeyChar() = ChrW(Keys.OemQuestion) Then
        '    Return False
        'End If
        '' Obtener el valor actual de la celda
        'Dim currentValue As String = wtexto
        'Dim firstDecimalPointIndex As Integer = currentValue.IndexOf(".")
        'If firstDecimalPointIndex >= 0 And KeyData.KeyChar() = ChrW(Keys.Decimal) Then
        '    Return False
        'End If

        'Return True
    End Function
    'Public vps_Usaurios As JsonRespuesta
    Public Function PlaySonidoMouse(CodSonido As Integer) As Boolean

        If CodSonido = 1 Then 'click 
            If OnSonidos Then My.Computer.Audio.Play(My.Resources.click1, AudioPlayMode.Background)
        ElseIf CodSonido = 2 Then ' Gota
            If OnSonidos Then My.Computer.Audio.Play(My.Resources.gota1, AudioPlayMode.Background)
        ElseIf CodSonido = 3 Then ' Gota
            If OnSonidos Then My.Computer.Audio.Play(My.Resources.click2, AudioPlayMode.Background)
        ElseIf CodSonido = 4 Then ' Gota
            If OnSonidos Then My.Computer.Audio.Play(My.Resources.click4, AudioPlayMode.Background)
        End If
        Return True
    End Function
    Public Function isOnline() As Boolean

        Dim p As New Ping
        Try
            Dim Rst As PingReply = p.Send("google.com")
            lk_onOfff = True
            Return True
            'Dim Datos As New StringBuilder
        Catch ex As Exception
            '  MsgBox("error red " & ex.ToString)
            Return False
        End Try


        'Dim Url As New System.Uri("http://www.google.com/")
        'Dim oWebReq As System.Net.WebRequest
        'oWebReq = System.Net.WebRequest.Create(Url)
        'Dim oResp As System.Net.WebResponse
        'Try
        '    oResp = oWebReq.GetResponse
        '    oResp.Close()
        '    oWebReq = Nothing
        '    Return True
        'Catch ex As Exception
        '    'oResp.Close()
        '    oWebReq = Nothing
        '    Return False
        'End Try
    End Function

    Public Sub RedondearFoto(ControlPict As PictureBox, e As PaintEventArgs)
        Dim Figura As GraphicsPath = New GraphicsPath
        Dim x, y, ancho, alto As Integer
        ancho = 150
        alto = 150
        x = (ControlPict.Width - ancho) / 2
        y = (ControlPict.Height - alto) / 2
        Figura.AddEllipse(New Rectangle(x, y, ancho, alto))
        ControlPict.Region = New Region(Figura)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality
    End Sub


    Public Function MuestraDataApi(url As String, parametro As List(Of Parametro)) As String
        Dim repite As Integer

        If lk_onOfff = False Then ' formar temporal 
            MuestraDataApi = "*400"  '  Sin Conexionn
            Exit Function
        End If
        repite = lk_nro_intentos_leer
Intenta:
        Try

            repite = repite - 1
            Dim api = New DBApi()
            Dim headers = New List(Of Parametro) From {
                New Parametro("Authorization", ""), New Parametro("Cookie", "")}
            Dim respuesta1 As New Object
            Dim response = api.Post(url, headers, parametro, respuesta1)
            If response = "" Then
                If repite < 0 Then
                    MuestraDataApi = "*600" ' Data Vacio
                Else
                    GoTo Intenta
                End If
            End If
            MuestraDataApi = response
        Catch

            If repite < 0 Then
                MuestraDataApi = "*500" ' Error No Responde
            Else
                GoTo Intenta
            End If

        End Try


    End Function


    Public Function SubirImagen(ws_filelocal As String, ws_rutaSubir As String, ws_RutaSubir_User As String, ws_RutaSubir_clave As String)
        SubirImagen = ""
        Try
            My.Computer.Network.UploadFile(ws_filelocal, ws_rutaSubir, ws_RutaSubir_User, ws_RutaSubir_clave)
        Catch ex As InvalidOperationException
            'MsgBox(ex.Message)
            SubirImagen = "*400" ' acceso a internet
            Exit Function
        End Try
    End Function
    Public Sub BuscarDG_TextChanged(ByVal TextoABuscar As String, ByVal Columna As String, ByRef grid As DataGridView)


        grid.CurrentCell = Nothing
        Dim wsTextoBusca As String
        If Left(TextoABuscar, 1) = "*" And Right(TextoABuscar, 1) = "*" And Len(TextoABuscar) > 2 Then
            wsTextoBusca = Mid(TextoABuscar, 2, Len(TextoABuscar) - 2)
            'MsgBox(wsTextoBusca)
            grid.Visible = False


            For Each Fila As DataGridViewRow In grid.Rows
                Fila.Visible = False
            Next

            For Each Fila As DataGridViewRow In grid.Rows
                If Not Fila Is Nothing Then
                    For Each Celda As DataGridViewCell In Fila.Cells
                        If InStr(Fila.Cells(Columna).Value.ToUpper.ToString(), wsTextoBusca.ToUpper, CompareMethod.Text) > 0 Then

                            Fila.Visible = True

                            Exit For
                        End If
                    Next
                End If
            Next
            grid.Visible = True
        Else
            wsTextoBusca = TextoABuscar
            'TextoABuscar = "'%" & TextoABuscar & "%'"
            If TextoABuscar = String.Empty Then Exit Sub
            If grid.RowCount = 0 Then Exit Sub
            grid.ClearSelection()
            If Columna = String.Empty Then
                Dim obj As IEnumerable(Of DataGridViewRow) = From row As DataGridViewRow In grid.Rows.Cast(Of DataGridViewRow)()
                                                             From celda As DataGridViewCell In row.Cells
                                                             Where celda.OwningRow.Equals(row) And celda.Value = TextoABuscar
                                                             Select row
                If obj.Any() Then
                    grid.Rows(obj.FirstOrDefault().Index).Selected = True
                End If

            Else
                ' InStr(Cell.Value.ToString, Trim(TxtBuscaProducto.Text), CompareMethod.Text) > 0
                ' Where row.Cells(Columna).Value = TextoABuscar ' original
                'Celda.ToString().ToUpper().IndexOf(TxtBuscaProducto.Text.ToUpper()) = 0
                'Where line.Contains("admin.aspx 401")

                Dim obj As IEnumerable(Of DataGridViewRow) = From row As DataGridViewRow In grid.Rows.Cast(Of DataGridViewRow)()
                                                             Where row.Cells(Columna).Value.ToString().IndexOf(wsTextoBusca) = 0
                                                             Select row

                'Dim obj As IEnumerable(Of DataGridViewRow) = From row As DataGridViewRow In grid.Rows.Cast(Of DataGridViewRow)()
                ' Where row.Cells(Columna).Value.ToString().IndexOf(TextoABuscar) = 0
                ' Select Case row


                If obj.Any() Then
                    grid.Rows(obj.FirstOrDefault().Index).Selected = True
                    grid.CurrentCell = grid.Rows(obj.FirstOrDefault().Index).Cells(0)
                End If

            End If
        End If

    End Sub
    Public Sub Redondeaimagen(imagenPic As PictureBox)
        Exit Sub
        Dim originalImage = imagenPic.Image
        Dim croppedImage As New Bitmap(originalImage.Width, originalImage.Height)
        'MsgBox(originalImage.Width)
        'MsgBox(originalImage.Height)
        Dim ancho, alto, x, y As Integer
        ancho = 150
        alto = 150
        x = (imagenPic.Width - ancho) / 2
        y = (imagenPic.Height - alto) / 2

        Using g = Graphics.FromImage(croppedImage)
            Dim path As New GraphicsPath

            path.AddEllipse(0, 0, croppedImage.Width, croppedImage.Height)
            Dim reg As New Region(path)
            g.Clip = reg
            g.DrawImage(originalImage, Point.Empty)
        End Using
        imagenPic.Image = croppedImage
    End Sub
    Public Function AjustarImagen(RutaImagenOriginal As String) As String
        Dim imagenOriginal As Bitmap
        Dim imagenRedimensionada As Bitmap
        Dim wruta As String
        'Carga de la imagen original
        imagenOriginal = New Bitmap(RutaImagenOriginal)
        Dim nombre As String = System.IO.Path.GetFileName(RutaImagenOriginal)
        'creamos una imagen con las dimensiones que se desean
        'en este caso la creamos de 100x100 pixels
        imagenRedimensionada = New Bitmap(250, 250)

        'creamos un objeto graphics desde la nueva imagen
        Using gr As Graphics = Graphics.FromImage(imagenRedimensionada)

            'en la nueva imagen "pintamos" la antigua imagen con las dimensiones de la nueva imagen
            gr.DrawImage(imagenOriginal, 0, 0, imagenRedimensionada.Width, imagenRedimensionada.Height)

        End Using

        'se guarda la nueva imagen
        wruta = My.Computer.FileSystem.CurrentDirectory & "\" & Format(Now, "mmss") & nombre
        imagenRedimensionada.Save(wruta)
        'imagenRedimensionada.|
        AjustarImagen = wruta
    End Function

    Public Function Valida_Hora_Acceso(wHoraInicio As String, wHoraFin As String, wHoraServer As String) As Boolean
        Dim horaI As Integer
        Dim horaF As Integer
        Dim minI As Integer
        Dim minF As Integer
        Dim hora_compara As Integer
        Dim min_compara As Integer

        horaI = Strings.Left(wHoraInicio, 2)
        horaF = Strings.Left(wHoraFin, 2)
        minI = Strings.Right(wHoraInicio, 2)
        minF = Strings.Right(wHoraFin, 2)

        hora_compara = Val(Strings.Left(wHoraServer, 2))
        min_compara = Val(Strings.Right(wHoraServer, 2))

        Valida_Hora_Acceso = False
        If horaF = 0 And horaI <> 0 Then
            If min_compara >= minI Then
                Valida_Hora_Acceso = True
                Exit Function
            End If
        End If

        If horaI = 0 And horaF = 0 And minI = 0 And minF = 0 Then
            Valida_Hora_Acceso = True
            Exit Function
        End If
        If hora_compara >= horaI And hora_compara <= horaF Then
            If hora_compara = horaI And hora_compara = horaF Then
                If min_compara >= minI And min_compara <= minF Then
                    Valida_Hora_Acceso = True
                End If
                Exit Function
            End If
            If hora_compara = horaI Then
                If min_compara >= minI Then
                    Valida_Hora_Acceso = True
                End If
                Exit Function
            End If
            If hora_compara = horaF Then
                If min_compara <= minF Then
                    Valida_Hora_Acceso = True
                End If
                Exit Function
            End If
        End If
    End Function

    Public Sub CERRAR_SESIONES()
        ' VALIDAR SI TIENE LA CONFIGUCACION DE ESPAOÑ PERU
        Dim Result As String = ""
        Dim currentCulture As CultureInfo = CultureInfo.CurrentCulture
        If currentCulture.Name = "es-PE" Then

        Else
            Result = MensajesBox.Show("El Sistema detecto la Configuracion Regional " & currentCulture.DisplayName & " " & currentCulture.NativeName & vbCrLf &
                "Desea Cambiar la configuracion Regional adecuado para el sistema de forma permanente.", "Configuracion Regional", MessageBoxButtons.YesNo)
            If Result = "7" Then ' es NO
                End
                Exit Sub
            End If
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Control Panel\International", True)
            key.SetValue("sShortDate", "dd/MM/yyyy") 'Establece el formato de fecha corta en dd/MM/yyyy para Español PERU
            key.SetValue("sThousand", ",") 'Establece el separador de miles en "," para Español PERU
            key.SetValue("sDecimal", ".") 'Establece el separador decimal en "." para Español PERU
            key.SetValue("sLanguage", "es-PE") 'Establece el idioma en Español PERU
            key.Close()

            Dim REcurrentCulture As CultureInfo = CultureInfo.CurrentCulture
            If REcurrentCulture.Name = "es-PE" Then
            Else

                Process.Start("control.exe", "intl.cpl")
                End
            End If



        End If






            Dim procesos As Process() = Process.GetProcesses()

        Dim procesoActual As Process = Process.GetCurrentProcess()

        ' Obtener el nombre del proceso actual
        Dim nombreProceso As String = procesoActual.ProcessName

        ' Imprimir el nombre del proceso actual
        ' Console.WriteLine("El nombre del proceso que inició la aplicación es: " & nombreProceso)



        ' Filtrar los procesos que corresponden a conexiones abiertas por el usuario
        For Each proceso As Process In procesos
            If proceso.ProcessName = nombreProceso Then
                'If proceso.ProcessName.StartsWith("sqlservr") OrElse proceso.ProcessName.StartsWith("mysqld") Then
                ' Si el proceso es una conexión abierta, intentar cerrarlo
                Try
                    proceso.CloseMainWindow()
                Catch ex As Exception
                    ' Manejar cualquier excepción que pueda ocurrir al cerrar el proceso
                    '  MsgBox("DD")
                End Try
            End If
        Next
    End Sub
    Public Sub FadeTransition(ByVal pictureBox1 As PictureBox, ByVal pictureBox2 As PictureBox, ByVal duration As Integer)
        'Crear un bitmap a partir de la imagen del PictureBox2
        Dim bmp As New Bitmap(pictureBox2.Image)

        'Establecer el tamaño del bitmap
        bmp = New Bitmap(bmp, pictureBox1.Width, pictureBox1.Height)

        'Establecer la opacidad inicial del PictureBox2
        pictureBox2.Image = SetImageOpacity(pictureBox2.Image, 1)

        'Dibujar el bitmap gradualmente en el PictureBox1
        For i As Integer = 0 To duration Step 20
            Dim opacity As Double = 1 - (i / duration)

            'Crear un nuevo bitmap con la opacidad deseada
            Dim tempBmp As Bitmap = SetImageOpacity(bmp, opacity)

            'Dibujar el nuevo bitmap en el PictureBox1
            Dim g As Graphics = pictureBox1.CreateGraphics()
            g.DrawImage(tempBmp, 0, 0)
            g.Dispose()

            'Esperar un momento para mostrar el efecto gradualmente
            Threading.Thread.Sleep(50)
        Next

        'Actualizar la imagen del PictureBox1 con la imagen del PictureBox2
        pictureBox1.Image = pictureBox2.Image

        'Restaurar la opacidad del PictureBox2
        pictureBox2.Image = SetImageOpacity(bmp, 1)
    End Sub

    Public Function SetImageOpacity(ByVal image As Image, ByVal opacity As Double) As Bitmap
        Dim bmp As New Bitmap(image.Width, image.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim colormatrix As New ColorMatrix()
        colormatrix.Matrix33 = opacity
        Dim imgattribute As New ImageAttributes()
        imgattribute.SetColorMatrix(colormatrix, ColorMatrixFlag.[Default], ColorAdjustType.Bitmap)
        g.DrawImage(image, New Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height,
            GraphicsUnit.Pixel, imgattribute)
        g.Dispose()
        Return bmp
    End Function

    Public Sub BuscarGrid(ByVal TextoABuscar As String, ByVal Columna As String, ByRef grid As DataGridView)

        Dim filaselecion As Integer

        grid.CurrentCell = Nothing
        Dim wsTextoBusca As String
        grid.Tag = ""
        Try
            If Strings.Left(TextoABuscar, 1) = "*" And Strings.Right(TextoABuscar, 1) = "*" And Len(TextoABuscar) > 2 Then
                'wsTextoBusca = Mid(TextoABuscar, 2, Len(TextoABuscar) - 2)
                'grid.Tag = "BUSCA_AVA"
                ''MsgBox(wsTextoBusca)
                'grid.Visible = False
                '' For Each Fila As DataGridViewRow In grid.Rows
                '' Fila.Visible = False
                '' Next

                'For Each Fila As DataGridViewRow In grid.Rows
                '    Fila.Visible = False
                'Next
                'filaselecion = -1
                'For Each Fila As DataGridViewRow In grid.Rows
                '    If Not Fila Is Nothing Then
                '        For Each Celda As DataGridViewCell In Fila.Cells
                '            If InStr(Fila.Cells(Columna).Value.ToUpper.ToString(), wsTextoBusca.ToUpper, CompareMethod.Text) > 0 Then
                '                If filaselecion = -1 Then filaselecion = Fila.Index
                '                Fila.Visible = True
                '                Exit For
                '            End If
                '        Next
                '    End If
                'Next
                ' grid.Visible = True
                If filaselecion <> -1 Then
                    grid.Rows(filaselecion).Selected = True
                    grid.CurrentCell = grid.Rows(filaselecion).Cells(Columna)
                End If
            Else
                wsTextoBusca = UCase(TextoABuscar)
                'TextoABuscar = "'%" & TextoABuscar & "%'"
                If TextoABuscar = String.Empty Then Exit Sub
                If grid.RowCount = 0 Then Exit Sub
                grid.ClearSelection()
                If Columna = String.Empty Then
                    Dim obj As IEnumerable(Of DataGridViewRow) = From row As DataGridViewRow In grid.Rows.Cast(Of DataGridViewRow)()
                                                                 From celda As DataGridViewCell In row.Cells
                                                                 Where celda.OwningRow.Equals(row) And celda.Value = TextoABuscar
                                                                 Select row
                    'TextBox1.Text = TextBox1.Text & obj.Any() & Chr(13)
                    If obj.Any() Then
                        grid.Rows(obj.FirstOrDefault().Index).Selected = True
                        grid.CurrentCell = grid.Rows(obj.FirstOrDefault().Index).Cells(Columna)

                    End If

                Else
                    ' InStr(Cell.Value.ToString, Trim(TxtBuscaProducto.Text), CompareMethod.Text) > 0
                    ' Where row.Cells(Columna).Value = TextoABuscar ' original
                    'Celda.ToString().ToUpper().IndexOf(TxtBuscaProducto.Text.ToUpper()) = 0
                    'Where line.Contains("admin.aspx 401")

                    Dim obj As IEnumerable(Of DataGridViewRow) = From row As DataGridViewRow In grid.Rows.Cast(Of DataGridViewRow)()
                                                                 Where row.Cells(Columna).Value.ToString().IndexOf(wsTextoBusca) = 0
                                                                 Select row

                    'Dim obj As IEnumerable(Of DataGridViewRow) = From row As DataGridViewRow In grid.Rows.Cast(Of DataGridViewRow)()
                    ' Where row.Cells(Columna).Value.ToString().IndexOf(TextoABuscar) = 0
                    ' Select Case row


                    If obj.Any() Then
                        grid.Rows(obj.FirstOrDefault().Index).Selected = True
                        grid.CurrentCell = grid.Rows(obj.FirstOrDefault().Index).Cells(Columna)
                    End If

                End If
            End If
        Catch ex As Exception

        Finally
        End Try
    End Sub
    Public Function Busca_TextChanged(TxtCajaBuscar As TextBox, DataGrid As DataGridView, Descrip_col_busca As String, crtaviso As ErrorProvider) As Integer
        ' posibles resultado de la funcion 
        ' 1 = Enceuntra resultado
        ' 2 = Inicializar DataGrid
        ' 3 = No Encuentra conicidencia
        Busca_TextChanged = 3
        If TxtCajaBuscar.Text = "" Then
            Busca_TextChanged = 2
        Else
            BuscarGrid(TxtCajaBuscar.Text, Descrip_col_busca, DataGrid)
            If DataGrid.SelectedRows.Count > 0 Then ' ENCUENTRA PARA MOSTRAR
                Busca_TextChanged = 1
            End If
            crtaviso.SetError(TxtCajaBuscar, "Uso de la busqueda avanzada. escribe entre asterisco, Ejemplo: " & vbLf & "*ASPIRI* ,*AMOXI*." & vbLf & "Pulsa la tecla ESC. Reiniciar busqueda.")
        End If
    End Function
    Public Function BuscarKeyDown(TxtBusca As TextBox, GridData As DataGridView, e As KeyEventArgs) As Boolean
        ' PARA USAR LA BUSQUEDA LA COLUMA 0 DEBE ESTAR VISIBLE .
        BuscarKeyDown = False
        If GridData.SelectedRows.Count <= 0 Then
            Exit Function
        End If
        If e.KeyCode = Keys.Down Then
            ' If GridData.CurrentRow.Index = 0 Then Exit Function
            If GridData.CurrentRow Is Nothing Then Exit Function
            For i = GridData.CurrentRow.Index + 1 To GridData.Rows.Count - 1
                If GridData.Rows(i).Visible Then
                    GridData.Rows(i).Selected = True
                    GridData.CurrentCell = GridData.Rows(i).Cells(0)
                    ' carga_datosGrid(0, DataUsuarios)
                    BuscarKeyDown = True
                    Exit Function
                End If
            Next
            TxtBusca.SelectionLength = TxtBusca.Text.Length
            TxtBusca.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            If GridData.CurrentCell Is Nothing Then Exit Function
            If GridData.CurrentRow.Index = 0 Then Exit Function
            For i = GridData.CurrentRow.Index - 1 To 0 Step -1
                If GridData.Rows(i).Visible Then
                    GridData.Rows(i).Selected = True
                    GridData.CurrentCell = GridData.Rows(i).Cells(0)
                    BuscarKeyDown = True
                    Exit Function
                End If
            Next
            TxtBusca.Focus()
            TxtBusca.SelectionStart = TxtBusca.Text.Length
        End If
    End Function
    Public Sub MostrarPictureBoxCircular(ControlPictureBox As PictureBox)
        Dim originalImage As Image = ControlPictureBox.Image
        ' Crear una nueva imagen circular
        Dim newImage As New Bitmap(originalImage.Width, originalImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        Using g As Graphics = Graphics.FromImage(newImage)
            Dim path As New Drawing2D.GraphicsPath()
            path.AddEllipse(0, 0, newImage.Width, newImage.Height)
            Dim region As New Region(path)
            g.Clear(Color.Transparent)
            g.SetClip(region, Drawing2D.CombineMode.Replace)
            g.DrawImage(originalImage, Point.Empty)
        End Using
        ' Asignar la nueva imagen al PictureBox
        ControlPictureBox.Image = newImage
    End Sub
    Public Sub MostrarImagenDesdeCampo(ByVal nombreCampo As String, ByVal fila As DataRow, ByVal pictureBox As PictureBox)
        If Not IsDBNull(fila(nombreCampo)) Then
            Dim imageBytes() As Byte = DirectCast(fila(nombreCampo), Byte())
            pictureBox.Image = Image.FromStream(New MemoryStream(imageBytes))
        Else
            pictureBox.Image = Nothing
        End If
    End Sub
    Public lk_sql_listaOperMenu As DataTable
    Public lk_sql_listaOperBox As DataTable
    Public lk_sql_listaTipoOper As DataTable
    Public lk_sql_EnlacesOper As DataTable
    Public lk_sql_listaSubOper As DataTable
    Public lk_sql_OperMaestro As DataTable
    Public lk_sql_formatos As DataTable
    Public lk_sql_servicios_mae As DataTable



    Public lk_sql_Locales_Activos As DataTable
    Public lk_sql_Salto_Grid As DataTable
    Public lk_sql_Presentaciones As DataTable
    Public lk_sql_TipoPres As DataTable
    Public lk_sql_areas_neg As DataTable


    Public lk_sql_comp_oper As DataTable
    Public lk_sql_TipoCanjes As DataTable
    Public lk_sql_tablas_estru_prod As DataTable
    Public lk_sql_Lista_estru_prod As DataTable
    Public lk_sql_Lista_dinero As DataTable



    Public lk_sql_serie_comp As DataTable
    Public lk_sql_impuesto_mae As DataTable

    Public lk_sql_monedas_negocio As DataTable
    Public lk_sql_listaOperAfecta As DataTable
    Public lk_sql_lista_acc_almacenes As DataTable
    Public lk_sql_lista_uci As DataTable
    Public lk_sql_nombre_bd As DataTable


    Public lk_formatoFechabd As String = ""


    Public Sub Carga_Paramtros_Generales()
        ' == Lista de opraciones para los Menus en Operaciones
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter


        lk_Token_tigo = "KYOcW1brJhiSospJDULv72FiAWeNJFHMXyzIxjdpLKI5PjSOCICrYPhCeVA7"

        lk_formatoFechabd = If(UsarFormatoEnEspañol(), "dd/MM/yyyy", FechaFormato)


        sql_cade = "select det_oper.id_tb , det_oper.descripcion as grupo, tablaoper.codigo + ' '+ tablaoper.descripcion detalle,
      tablaoper.codigo , tablaoper.id_tb as id_tb_oper from vw_lista_oper det_oper 
inner join tablas_basicas  tablaoper on tablaoper.id_tb =  det_oper.id_tb_oper and tablaoper.id_tipotabla = 500
GROUP BY det_oper.id_tb , det_oper.descripcion , tablaoper.codigo + ' '+ tablaoper.descripcion ,
       tablaoper.codigo , tablaoper.id_tb"

        lk_sql_listaOperMenu = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_listaOperMenu)



        sql_cade = "select  * from [vw_servicios_mae]" ' filtro para buscar por el id : id_oper_maestro
        lk_sql_servicios_mae = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_servicios_mae)


        ' == Lista de BOX  de todas las operaciones de la plataforma
        sql_cade = "select  * from [dbo].[vw_lista_box] " ' filtro para buscar por el id : id_oper_maestro
        lk_sql_listaOperBox = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_listaOperBox)


        ' == Lista de BOX  de todas las operaciones de la plataforma
        sql_cade = "select  * from vw_lista_oper_afecta " ' filtro para buscar por el id : id_oper_maestro
        lk_sql_listaOperAfecta = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_listaOperAfecta)


        ' == Lista de SubOperaciones de todas las operaciones de la plataforma
        sql_cade = "select  * from [vw_lista_suboper] " ' filtro para buscar por el id : id_oper_maestro
        lk_sql_listaSubOper = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_listaSubOper)

        ' == Lista de Tipo de operaciones de todas las operaciones de la plataforma
        sql_cade = "select  * from [vw_lista_tipooper]  " ' filtro para buscar por el id : id_oper_maestro
        lk_sql_listaTipoOper = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_listaTipoOper)


        ' == LISTA DE LOS ENLACES DE LAS OPERACIONES
        sql_cade = "select  * from vw_operaciones_enlaces " ' filtro para buscar por el id : id_oper_maestro
        lk_sql_EnlacesOper = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_EnlacesOper)





        ' carga todos los tipo de documentos persona
        sql_cade = "select * from [dbo].[m_tipdoc_personas] " ' filtro para buscar por el id : id_oper_maestro
        lk_sql_ListaTipoDocPersona = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_ListaTipoDocPersona)


        sql_cade = "select  rtrim(UPPER(m.descripcion)) descripcion , rtrim(UPPER(m.ref)) masdetalle , m.id_tbp_id ,m.id_tbp_estru_id   from r23_master.dbo.prod_tablas_estru_items m order by descripcion" ' filtro para buscar por el id : id_oper_maestro
        lk_sql_estructura_prod = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_estructura_prod)



        sql_cade = "select   * from operaciones_mae where  id_oper_maestro <> 0"
        lk_sql_OperMaestro = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_OperMaestro)


        sql_cade = "select  id_tb_tippres, id_presentacion , descripcion , abreviado, equiv  from r23_master.dbo.prod_presentacion order by equiv "
        lk_sql_Presentaciones = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_Presentaciones)

        sql_cade = "select id_tb , descripcion , opcional1 from r23_master.dbo.tablas_basicas where id_tipotabla = 70  order by codigo"
        lk_sql_TipoPres = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_TipoPres)


        sql_cade = "select id_tb , descripcion from r23_master.dbo.tablas_basicas where id_tipotabla = 84  order by codigo"
        lk_sql_areas_neg = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_areas_neg)

        sql_cade = "select id_tb , descripcion, abreviado from r23_master.dbo.tablas_basicas where id_tipotabla = 55  order by codigo"
        lk_sql_TipoCanjes = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_TipoCanjes)







        sql_cade = "select   c.id_tb_oper ,  c.id_comprobante , c.es_manual , c.es_interno,  cdes.codigo, cdes.abreviado  , cdes.descripcion, cdes.estado , c.orden 
                    from r23_master.dbo.operaciones_comp  c  inner join r23_master.dbo.operaciones_comp_tabla cdes on c.id_comprobante = cdes.id_comprobante
                    where  c.id_tb_oper <> 0  order by id_tb_oper , es_interno, orden "
        lk_sql_comp_oper = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_comp_oper)


        'sql_cade = "select  * from [dbo].[prod_tablas_estru_items]"
        'lk_sql_tablas_estru_prod = New DataTable()
        'command = New SqlCommand(sql_cade, lk_connection_master)
        'adaptador = New SqlDataAdapter(command)
        'adaptador.Fill(lk_sql_tablas_estru_prod)


        sql_cade = "select  * from [dbo].[prod_tablas_estru]"
        lk_sql_Lista_estru_prod = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_Lista_estru_prod)

        sql_cade = "select  id_moneda ,id_dinero , tipo, abreviado , valor from r23_master.dbo.dinero_mae where id_pais = 1  order by tipo desc, orden"
        lk_sql_Lista_dinero = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_Lista_dinero)



        sql_cade = "SELECT GETDATE() AS CurrentDateTime"
        Dim sqlfecha = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(sqlfecha)
        lk_fecha_dia = sqlfecha.Rows(0).Item("CurrentDateTime")

        CargaUBIGEOS()



    End Sub
    ' == Lista de Locales por id de Negocio Activo
    Public Sub Carga_Paramtros_Negocio(wid_Negocio As String)
        lk_modo_oscuro = 0
        ModoColoPantalla()

        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter

        'sql_cade = "select id_local , codigo, nombre,fotolocal, estado  from [dbo].[neg_local] where id_negocio = " & wid_Negocio & " order by codigo " ' filtro para buscar por el id : id_oper_maestro
        'sql_cade = " select mae_loc.id_local , mae_loc.codigo, mae_loc.nombre,mae_loc.fotolocal, mae_loc.estado  
        '            , acc_loc.id_usuario , mae_loc.id_negocio from [dbo].[neg_local]  mae_loc
        '            inner join acceso_local acc_loc on (mae_loc.id_local = acc_loc.id_local and acc_loc.estado = 1) and mae_loc.id_negocio  = " & wid_Negocio & " and acc_loc.id_usuario = " & lk_id_usuario & " "

        sql_cade = "EXEC [sp_lista_locales_activos] " & wid_Negocio & " , " & lk_id_usuario & " "
        lk_sql_Locales_Activos = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_Locales_Activos)

        sql_cade = "select  * from [confg_grid] where id_negocio  = " & wid_Negocio & " order by id_tb_oper , orden" ' filtro para buscar por el id : id_oper_maestro
        lk_sql_Salto_Grid = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_Salto_Grid)

        sql_cade = "select  * from m_series where id_negocio = " & wid_Negocio & " and estado = 1  order by id_negocio,id_local, id_comprobante ,  orden " '  select  * from [confg_grid] where id_negocio  = " & wid_Negocio & " order by id_tb_oper , orden" ' filtro para buscar por el id : id_oper_maestro
        lk_sql_serie_comp = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_serie_comp)

        sql_cade = "select  id_local , codigo, vporc, descripcion from impuesto_mae where id_negocio = " & wid_Negocio & "  and estado = 1 "
        lk_sql_impuesto_mae = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_impuesto_mae)


        sql_cade = "select  mnge.id_negocio, mnge.id_moneda , mon.nombre nom_moneda , mon.simbolo , mon.id_pais ,
                    pai.descripcion nom_pais,  pai.abreviado , pai.codigo as codigopais ,mon.estado estadomoneda , mnge.es_monedalocal
                    from r23_master.dbo.neg_maestro_monedas  mnge
                    inner join r23_master.dbo.neg_maestro nego on nego.id_negocio =  mnge.id_negocio 
                    inner join r23_master.dbo.m_pais pai on pai.id_pais =  nego.id_pais
                    inner join r23_master.dbo.m_moneda mon on mon.id_moneda =  mnge.id_moneda  and mon.id_pais = nego.id_pais
                    where  mnge.id_negocio =  " & wid_Negocio & " order by mnge.orden"
        lk_sql_monedas_negocio = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_monedas_negocio)


        sql_cade = "select * from vw_lista_acc_almacenes where id_negocio = " & wid_Negocio & " and id_usuario = " & lk_id_usuario & " "
        lk_sql_lista_acc_almacenes = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_lista_acc_almacenes)



        sql_cade = "SELECT  id_uci, codigo , descripcion , abreviado FROM [dbo].[uci_mae] where id_negocio = " & lk_NegocioActivo.id_Negocio & " and estado = 1"
        lk_sql_lista_uci = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_lista_uci)


    End Sub
    Public Sub Traer_Datos_ControlCajas(wid_negocio As Integer)
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        command = New SqlCommand("sp_muestra_controlcajas", lk_connection_cuenta)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@id_negocio", wid_negocio)
        adaptador = New SqlDataAdapter(command)
        lk_sql_ListaControlCajas = New DataTable
        adaptador.Fill(lk_sql_ListaControlCajas)
    End Sub
    Public Function ConvertirCadena(cadena As String) As List(Of Tuple(Of String, Integer, Integer))
        Dim subcadenas As String() = cadena.Split(New Char() {")"c}, StringSplitOptions.RemoveEmptyEntries)
        Dim valores As New List(Of Tuple(Of String, Integer, Integer))

        If subcadenas.Length > 0 Then
            For Each subcadena As String In subcadenas
                Try
                    Dim partes As String() = subcadena.TrimStart("("c).Split(","c)
                    If partes.Length = 3 Then
                        Dim abreviado As String = partes(0).Trim()
                        Dim equiv1 As Integer = Integer.Parse(partes(1).Trim())
                        Dim equiv2 As Integer = Integer.Parse(partes(2).Trim())
                        valores.Add(Tuple.Create(abreviado, equiv1, equiv2))
                    Else
                        Throw New FormatException($"Error de formato en la subcadena {subcadena}")
                    End If
                Catch ex As FormatException
                    ' Manejar el error de formato
                    Console.WriteLine(ex.Message)
                Catch ex As Exception
                    ' Manejar cualquier otro tipo de excepción
                    Console.WriteLine($"Error al procesar la subcadena {subcadena}: {ex.Message}")
                End Try
            Next
        End If

        Return valores
    End Function
    Public Function TieneFormatoFecha(ByVal valor As String) As Boolean
        Dim fecha As DateTime
        Return DateTime.TryParseExact(valor, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, fecha) OrElse DateTime.TryParse(valor, fecha)
    End Function
    Public Sub ModoColoPantalla()
        If lk_modo_oscuro = 0 Then
            strColorformulario = "#FAFAFA"
            strColorPaneles = "#FAFAFA"
            strColorMenu = strColorAzul
            strColorIcoBotones = "#FFFFFF"
        Else
            strColorformulario = strModoOscuro_verde
            strColorPaneles = strModoOscuro_verde
            strColorMenu = strModoOscuro_verde
            strColorIcoBotones = strModoOscuro_amarillo
        End If


    End Sub
    Public Const FechaFormato As String = "yyyy/MM/dd" ' Puedes definir aquí el formato por defecto en inglés

    Function UsarFormatoEnEspañol() As Boolean
        ' Aquí puedes implementar la lógica para decidir si usar el formato en español o no
        ' Por ejemplo, podrías consultar la configuración de la base de datos, el idioma de la aplicación, etc.
        Return LK_ES_FORMATO_ESPANOL ' Cambia esto según tus necesidades
    End Function
    Public Function formato_ListaCajas(westado As Integer, wfecha As DateTime, wid As Integer) As String
        Dim detalle As String = ""
        If westado = 1 Then
            detalle = Format(wid, "0000") & " ABIERTA : " & CDate(wfecha).ToString("dd/MM/yyyy HH:mm")
        ElseIf westado = 2 Then
            detalle = Format(wid, "0000") & " CERRADA S/V : " & CDate(wfecha).ToString("dd/MM/yyyy HH:mm")
        ElseIf westado = 3 Then
            detalle = Format(wid, "0000") & " CERRADA : " & CDate(wfecha).ToString("dd/MM/yyyy HH:mm")
        End If

        Return detalle
    End Function

    Public Sub Obtiene_formatos()
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        sql_cade = "select  id_tb_oper, id_destino, id_formato, id_copias,impresora1 , impresora2 , impresora3 from m_comprobantes_formatos  
          where id_negocio = " & lk_NegocioActivo.id_Negocio & " and id_usuario = " & lk_id_usuario & "   and equipo = '" & LK_NOMBRE_PC & "'"
        lk_sql_formatos = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_formatos)
    End Sub
    Public Function ConvertirMontoALetras(ByVal monto As Decimal, ByVal id_moneda As Integer) As String
        Dim unidades() As String = {"", "UN", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE"}
        Dim decenas() As String = {"", "DIEZ", "VEINTE", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA"}
        Dim centenas() As String = {"", "CIENTO", "DOSCIENTOS", "TRESCIENTOS", "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS"}
        Dim miles() As String = {"", "MIL", "MILLÓN", "MIL MILLONES"}

        Dim numero As String = monto.ToString("0.00") ' Asegura que el monto tenga 2 decimales.

        Dim enteroParte As String = numero.Split(".")(0) ' Parte entera del monto.
        Dim decimalParte As String = numero.Split(".")(1) ' Parte decimal del monto.

        Dim letras As String = ""
        Dim contador As Integer = 0

        Do While enteroParte.Length > 0
            Dim tresDigitos As String = enteroParte.Substring(Math.Max(0, enteroParte.Length - 3))
            enteroParte = enteroParte.Substring(0, Math.Max(0, enteroParte.Length - 3))
            Dim valor As Integer = Integer.Parse(tresDigitos)

            If valor = 1 And contador = 1 Then
                letras = miles(contador) & " " & letras
            ElseIf valor > 0 Then
                Dim digitoCientos As Integer = valor \ 100
                Dim digitoDecenas As Integer = (valor \ 10) Mod 10
                Dim digitoUnidades As Integer = valor Mod 10

                If digitoCientos > 0 Then
                    letras = centenas(digitoCientos) & " " & letras
                    If digitoDecenas > 0 Or digitoUnidades > 0 Then
                        letras = letras & "Y "
                    End If
                End If

                If digitoDecenas > 0 Then
                    letras = letras & decenas(digitoDecenas)
                    If digitoUnidades > 0 Then
                        letras = letras & " Y "
                    End If
                End If

                If digitoUnidades > 0 Then
                    letras = letras & unidades(digitoUnidades)
                End If

                If contador > 0 Then
                    letras = letras & " " & miles(contador)
                End If
            End If

            contador += 1
        Loop

        If letras.Length = 0 Then
            letras = "CERO"
        End If

        If id_moneda = 1 Then ' Soles
            letras = letras & " SOLES"
        ElseIf id_moneda = 2 Then ' Dolares
            letras = letras & " DÓLARES"
        End If

        letras = letras & " CON " & decimalParte & "/100"

        Return letras
    End Function


End Module
