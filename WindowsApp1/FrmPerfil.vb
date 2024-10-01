Imports System.Data.SqlClient
Imports System.IO
Imports Newtonsoft.Json
Imports WindowsApp1.ModificaUsuario
Imports WindowsApp1.ValidaUsuarios

Public Class FrmPerfil
    Dim file As New OpenFileDialog()
    Dim westadoFotoSubir As String
    Dim wImagenAjustada As String
    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub


    Private Sub CmdIniciar_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub FrmPerfil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        westadoFotoSubir = "0" ' 0 = NoTiene FOto , 1 = Tiene Foto , 2 = Cambia la Foto 
        Me.CenterToScreen()

        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)

        Me.FormBorderStyle = 1 ' Impedir que cambie el tamaño el formulario
        TxtUsuario.Enabled = False

        Dim result
        If lk_sql_ValidaUsuario.Rows.Count = 0 Then
            result = MensajesBox.Show("Verificar Conexion.",
                                       "Datos de Perfil")
            GoTo NoIngresa
        End If

        TxtUsuario.Text = lk_sql_ValidaUsuario.Rows(0).Item("Usuario").ToString
        TxtNumero.Text = lk_sql_ValidaUsuario.Rows(0).Item("numero_doc").ToString
        TxtNombres.Text = lk_sql_ValidaUsuario.Rows(0).Item("nombres").ToString
        TxtApellidos.Text = lk_sql_ValidaUsuario.Rows(0).Item("apellidos").ToString
        TxtCelular.Text = lk_sql_ValidaUsuario.Rows(0).Item("celular").ToString
        'FechaNac.Format = DateTimePickerFormat.Custom
        'FechaNac.CustomFormat = " "

        'FechaNac.Value = DateTime.MinValue
        ' FechaNac.ShowCheckBox = True
        ' FechaNac.Checked = False


        'FechaNac.Value = DateTime.MinValue


        'dateTimePicker1.MinDate = DateTime.Now.AddYears(-5)
        If lk_foto_perfil_id <> 0 Then
            westadoFotoSubir = "1"
        End If
        TxtxEmail.Text = lk_sql_ValidaUsuario.Rows(0).Item("email").ToString
        FotoPerfil.Image = FrmLogin.FotoUsuario.Image

        'FotoPerfil.Image = lk_foto_perfil
        MostrarPictureBoxCircular(FotoPerfil)
        'If IsDBNull(lk_sql_ValidaUsuario.Rows(0).Item("fotoimg")) Then
        '    FotoPerfil.Image = My.Resources.userd
        'Else
        '    MostrarImagenDesdeCampo("fotoimg", lk_sql_ValidaUsuario.Rows(0), FotoPerfil)
        '    MostrarPictureBoxCircular(FotoPerfil)
        'End If

        If lk_sql_ValidaUsuario.Rows(0).Item("email").ToString = "-" Then
            'FechaNac.Value = "01/01/1900"
            FechaNac.Value = DateTime.Now.AddYears(-70)
            FechaNac.MinDate = DateTime.Now.AddYears(-70)
            FechaNac.MaxDate = DateTime.Now.AddYears(-10)
        Else
            FechaNac.Value = lk_sql_ValidaUsuario.Rows(0).Item("fec_nac").ToString
        End If
        If lk_sql_ValidaUsuario.Rows(0).Item("genero").ToString = 1 Then
            Genero1.Checked = True
        ElseIf lk_sql_ValidaUsuario.Rows(0).Item("genero").ToString = 2 Then
            Genero2.Checked = True
        ElseIf lk_sql_ValidaUsuario.Rows(0).Item("genero").ToString = 3 Then
            Genero3.Checked = True
        End If
        If lk_sql_ListaTipoDocPersona Is Nothing Then
        Else
            CmbTipoDocUsuario.Items.Clear()
            For i = 0 To lk_sql_ListaTipoDocPersona.Rows.Count - 1
                CmbTipoDocUsuario.Items.Add(lk_sql_ListaTipoDocPersona.Rows(i).Item("descripcion").ToString) ' & Space(80) & lk_api_TipoDocPersona.data(i).id
                If lk_sql_ValidaUsuario.Rows(0).Item("id_tipodoc").ToString = lk_sql_ListaTipoDocPersona.Rows(i).Item("id_tipodoc").ToString Then
                    CmbTipoDocUsuario.SelectedIndex = i
                End If
            Next


        End If
        CmbCiudad.Items.Clear()
        CmbCiudad.Items.Add("Lima") ' & Space(80) & lk_api_TipoDocPersona.data(i).id
        CmbCiudad.SelectedIndex = 0


        Exit Sub
NoIngresa:
        MsgBox("???")

    End Sub

    Private Sub CmdFotoPerfil_Click(sender As Object, e As EventArgs) Handles CmdFotoPerfil.Click
        Dim Result As String
        file.Filter = "Archivo JPG|*.bmp;*.jpg;*.png"
        file.FilterIndex = 0
        file.Multiselect = False
        If file.ShowDialog() = DialogResult.OK Then
            Dim maxFileSize As Long = 524288 ' 1MB en bytes
            Dim fileInfo As New FileInfo(file.FileName)

            If fileInfo.Length <= maxFileSize Then

            Else
                Result = MensajesBox.Show("Imagen debe tener un maximo de 512KB", lk_cabeza_msgbox)
                Exit Sub
            End If


            file.FileName = StrConv(file.FileName, vbLowerCase)
            wImagenAjustada = AjustarImagen(file.FileName)
            file.FileName = wImagenAjustada
            FotoPerfil.Image = Image.FromFile(wImagenAjustada)
            westadoFotoSubir = "2"
            Redondeaimagen(FotoPerfil)
        End If

        'Dim openFileDialog As New OpenFileDialog()
        'OpenFileDialog.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif"
        'OpenFileDialog.FilterIndex = 0
        'openFileDialog.Multiselect = False

        ' If openFileDialog.ShowDialog() = DialogResult.OK Then

        '  End If






    End Sub

    Private Sub CmdActualizar_Click(sender As Object, e As EventArgs) Handles CmdActualizar.Click
        Dim result

        Try
            Dim mail As New System.Net.Mail.MailAddress(TxtxEmail.Text)
            FaltaDatos.SetError(TxtxEmail, "")
        Catch ex As Exception
            FaltaDatos.SetError(TxtxEmail, ex.Message)
            GoTo NO_Actualiza
        End Try



        If TxtNombres.Text = "" Or Len(TxtNombres.Text) <= 3 Then
            FaltaDatos.SetError(TxtNombres, "Debe Ingresar Nombres Completos o no menor de 3 letras.")
            GoTo NO_Actualiza
        Else
            FaltaDatos.SetError(TxtNombres, "")
        End If
        If TxtApellidos.Text = "" Or Len(TxtApellidos.Text) <= 3 Then
            FaltaDatos.SetError(TxtApellidos, "Debe Ingresar Apellidos Completos o no menor de 3 letras.")
            GoTo NO_Actualiza
        Else
            FaltaDatos.SetError(TxtApellidos, "")
        End If
        If IsDate(FechaNac.Value) Then
            If FechaNac.Value = "01/01/1900" Then
                FaltaDatos.SetError(FechaNac, "Debe Ingresar su Fecha de Nacimiento.")
                GoTo NO_Actualiza
            End If
        Else

            FaltaDatos.SetError(FechaNac, "Debe Ingresar su Fecha de Nacimiento.")
            GoTo NO_Actualiza
        End If
        FaltaDatos.SetError(FechaNac, "")
        If TxtxEmail.Text = "" Then
            FaltaDatos.SetError(TxtxEmail, "Debe Ingresar Email.")
            GoTo NO_Actualiza
        Else
            FaltaDatos.SetError(TxtxEmail, "")
        End If
        If Genero1.Checked = False And Genero2.Checked = False And Genero3.Checked = False Then
            FaltaDatos.SetError(Genero3, "Indique Su Genero.")
            GoTo NO_Actualiza
        Else
            FaltaDatos.SetError(Genero3, "")

        End If


        If westadoFotoSubir = "0" Then
            result = MensajesBox.Show("Complete su Foto de Perfil", lk_cabeza_msgbox)
            GoTo NO_Actualiza
        End If
        'Dim frEsperar As New FrmEsperar
        'frEsperar.Opacity = 0.5
        'frEsperar.Height = Me.Height
        'frEsperar.Width = Me.Width
        'frEsperar.PictureBox1.Left = (Me.Width - frEsperar.PictureBox1.Width) / 2
        'frEsperar.PictureBox1.Top = (Me.Height - frEsperar.PictureBox1.Height) / 2
        'frEsperar.Show()
        '   Dim wConfirmasubida As String

        Dim idGenerado As Integer
        Dim nombre As String = "" ' System.IO.Path.GetFileName(file.FileName)
        Dim extension As String = System.IO.Path.GetExtension(file.FileName)
        FotoPerfil.Tag = ""
        nombre = "perfilu" & Format(Now, "mmss") & lk_id_usuario & extension
        idGenerado = lk_foto_perfil_id
        If westadoFotoSubir = "2" Then ' Solo Subir si cambia la foto
            'CircularProgressBar1.Visible = True
            'Application.DoEvents()
            'wConfirmasubida = SubirImagen(file.FileName, lk_RutaSubir & nombre, lk_RutaSubir_User, lk_RutaSubir_clave)
            'If Mid(wConfirmasubida, 1, 1) = "*" Then
            '    result = MensajesBox.Show("Sin acceso a guadar Imagenes, codigo error " & wConfirmasubida, lk_cabeza_msgbox)
            '    GoTo NO_Actualiza
            'End If

            'My.Computer.FileSystem.CopyFile(
            '       file.FileName,
            '        lk_Carpeta_Temp & nombre,
            '        Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
            '        Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)

            '   'My.Computer.Network.UploadFile(file.FileName, RutaSubir & nombre, RutaSubir_User, RutaSubir_clave)
            'FotoPerfil.Tag = lk_RutaBD & nombre
            'lk_rutalocal_foto = lk_Carpeta_Temp & nombre
            'file.FileName = lk_rutalocal_foto
            'CircularProgressBar1.Visible = False

            ' 1. Crear la sentencia INSERT INTO con la lista de columnas que no son IDENTITY
            'USE [r23_images] GO             INSERT INTO [dbo].[tab_imagenes]            ([imagen]            ,[fecha])      VALUES           (<imagen, image,>
            ',<fecha, date,>)[tab_imagenes]
            'GO
            Dim bytesImagen_fotoperfil() As Byte = ConvertirImagenABytes(file.FileName)

            'Command.Parameters.AddWithValue("@fotoimg", bytesImagen_fotoperfil)

            If lk_foto_perfil_id = 0 Then
                Dim sqlInsert As String = "INSERT INTO tab_imagenes VALUES (@imagen, GETDATE()); SELECT SCOPE_IDENTITY();"
                Dim cmdInsert As SqlCommand = New SqlCommand(sqlInsert, lk_connection_imagenes)
                cmdInsert.Parameters.AddWithValue("@imagen", bytesImagen_fotoperfil)
                'cmdInsert.ExecuteNonQuery()
                idGenerado = Convert.ToInt32(cmdInsert.ExecuteScalar())
                lk_foto_perfil_id = idGenerado
            Else
                Dim sqlInsert As String = "UPDATE tab_imagenes SET  imagen =  @imagen  WHERE  id_img = @id_img "
                Dim cmdInsert As SqlCommand = New SqlCommand(sqlInsert, lk_connection_imagenes)
                cmdInsert.Parameters.AddWithValue("@imagen", bytesImagen_fotoperfil)
                cmdInsert.Parameters.AddWithValue("@id_img", lk_foto_perfil_id)
                cmdInsert.ExecuteNonQuery()
            End If
            FrmLogin.FotoUsuario.Image = FotoPerfil.Image
            MostrarPictureBoxCircular(FrmLogin.FotoUsuario)
        End If




            If ActualizaUsuario(idGenerado) = False Then
            GoTo NO_Actualiza
        End If



        If TraerDatosUsuario() = False Then
            result = MensajesBox.Show("Verifique Si actualizo su informacion.", lk_cabeza_msgbox)
            GoTo NO_Actualiza
        End If

        Me.Close()
        Exit Sub
NO_Actualiza:
        CircularProgressBar1.Visible = False
    End Sub

    Private Function TraerDatosUsuario() As Boolean

        Try
            Dim command As SqlCommand = New SqlCommand("u_login", lk_connection_master)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@usuario", lk_usuario)
            command.Parameters.AddWithValue("@clave", lk_sql_ValidaUsuario.Rows(0).Item("clave").ToString)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            lk_sql_ValidaUsuario = New DataTable()
            adapter.Fill(lk_sql_ValidaUsuario)


            ' Dim parametro = New List(Of Parametro) From {
            'New Parametro("usuario", lk_usuario),
            'New Parametro("clave", lk_api_ValidaUsuario.data(0).Clave)}
            ' Dim response = MuestraDataApi(lk_api_cadena_base + "auth/login", parametro) ' respuesta : vps_Usaurios

            ' lk_api_ValidaUsuario = JsonConvert.DeserializeObject(Of JsonValidaUsaurio)(response) 'Cái truyền tên Class vào
            ' If lk_api_ValidaUsuario Is Nothing Then
            '     TraerDatosUsuario = False
            ' End If
            If lk_sql_ValidaUsuario.Rows.Count = 0 Then
                TraerDatosUsuario = False
            End If
            lk_id_usuario = lk_sql_ValidaUsuario.Rows(0).Item("id_usuario").ToString
            lk_usuario = lk_sql_ValidaUsuario.Rows(0).Item("Usuario").ToString

        Catch
            TraerDatosUsuario = False
        End Try

        TraerDatosUsuario = True

    End Function
    Private Function ActualizaUsuario(wid_img As Integer) As Boolean
        Dim ws_id As String = lk_id_usuario
        Dim ws_usaurio As String = Nothing
        Dim ws_clave As String = Nothing
        Dim ws_id_tipodoc As String = lk_sql_ListaTipoDocPersona.Rows(CmbTipoDocUsuario.SelectedIndex).Item("id_tipodoc")
        Dim ws_fotoperfil As String = wid_img
        Dim ws_numero_doc As String = TxtNumero.Text
        Dim ws_nombres As String = TxtNombres.Text
        Dim ws_apellidos As String = TxtApellidos.Text ' TxtApellidos.Text
        Dim ws_id_pais As String = Nothing
        Dim ws_celular As String = Nothing ' TxtCelular.Text
        Dim ws_email As String = TxtxEmail.Text
        Dim ws_id_ciudad As String = Nothing ' Nothing
        Dim ws_fec_nac As String = Format(FechaNac.Value, "dd-MM-yyyy")
        Dim ws_genero As String = Nothing
        If Genero1.Checked Then
            ws_genero = 1
        ElseIf Genero2.Checked Then
            ws_genero = 2
        ElseIf Genero3.Checked Then
            ws_genero = 3
        End If
        Dim ws_estado As String = Nothing
        Dim ws_fec_registro As String = Format(Now, "dd-MM-yyyy hh:mm:ss")
        Dim ws_fec_conexion As String = Format(Now, "dd-MM-yyyy hh:mm:ss")
        Dim ws_idnegocio As String = Nothing
        Dim ws_idlocal As String = Nothing
        Dim ws_idalmacen As String = Nothing

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


        Dim command As New SqlCommand()
        command.Connection = lk_connection_master
        command.CommandType = CommandType.StoredProcedure
        command.CommandText = "u_modificarUsuario"
        command.Parameters.Clear()
        command.Parameters.AddWithValue("@id", ws_id)
        command.Parameters.AddWithValue("@usu", ws_usaurio)
        command.Parameters.AddWithValue("@clave", ws_clave)
        command.Parameters.AddWithValue("@tipodoc", ws_id_tipodoc)
        command.Parameters.AddWithValue("@id_foto", ws_fotoperfil)
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
        command.Parameters.AddWithValue("@idNeg", ws_idnegocio)
        command.Parameters.AddWithValue("@idLo", ws_idlocal)
        command.Parameters.AddWithValue("@idAlma", ws_idalmacen)
        ' .ToString(lk_formatoFechabd)

        'Dim bytesImagen_fotoperfil() As Byte = ConvertirImagenABytes(file.FileName)

        'command.Parameters.AddWithValue("@fotoimg", bytesImagen_fotoperfil)

        Dim filasActualizadas As Integer = command.ExecuteNonQuery()
        If filasActualizadas > 0 Then
            ' La actualización fue exitosa '
            ActualizaUsuario = True
        Else
            ActualizaUsuario = False
            Exit Function
        End If
        '

    End Function
    Private Function ConvertirImagenABytes(ByVal rutaImagen As String) As Byte()
        Dim bytesImagen As Byte() = Nothing

        If Not String.IsNullOrEmpty(rutaImagen) AndAlso System.IO.File.Exists(rutaImagen) Then
            Using imageFileStream As New FileStream(rutaImagen, FileMode.Open, FileAccess.Read)
                Using ms As New MemoryStream()
                    imageFileStream.CopyTo(ms)
                    bytesImagen = ms.ToArray()
                End Using
            End Using
        End If

        Return bytesImagen
    End Function

    Private Sub CmdCancelarCrear_Click(sender As Object, e As EventArgs) Handles CmdCancelarCrear.Click
        Me.Close()
    End Sub

    Private Sub TxtNumero_TextChanged(sender As Object, e As EventArgs) Handles TxtNumero.TextChanged

    End Sub

    Private Sub CmbTipoDocUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoDocUsuario.SelectedIndexChanged

    End Sub

    Private Sub TxtNombres_TextChanged(sender As Object, e As EventArgs) Handles TxtNombres.TextChanged

    End Sub

    Private Sub TxtxEmail_TextChanged(sender As Object, e As EventArgs) Handles TxtxEmail.TextChanged

    End Sub

    Private Sub TxtCelular_TextChanged(sender As Object, e As EventArgs) Handles TxtCelular.TextChanged

    End Sub
End Class