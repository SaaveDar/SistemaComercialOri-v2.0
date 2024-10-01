Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Public Class FrmFormatosOper
    Public Property Local_detalle_oper As String
    Public Property Local_id_tb_oper As Integer

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
    Private Sub FrmFormatosOper_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblOperacion.Text = Local_detalle_oper
        marcaimpresora("0")
        formato_impresora("0")
        Muestra_conf(Local_id_tb_oper)


    End Sub
    Private Sub Muestra_conf(wsLocal_id_tb_oper As Integer)
        Obtiene_formatos()
        Dim Obtener_lk_sql_formatos() As DataRow = lk_sql_formatos.Select("id_tb_oper = " & wsLocal_id_tb_oper & "")
        If Obtener_lk_sql_formatos.Count = 0 Then
            Exit Sub
        End If

        Dim wid_tb_oper As Integer = Obtener_lk_sql_formatos(0)("id_tb_oper")
        Dim wid_destino As Integer = Obtener_lk_sql_formatos(0)("id_destino")
        Dim wid_formato As Integer = Obtener_lk_sql_formatos(0)("id_formato")

        marcaimpresora(wid_destino)
        formato_impresora(wid_formato)
        txtNroCopias.Text = Obtener_lk_sql_formatos(0)("id_copias")

        Asigna_impresora(Obtener_lk_sql_formatos(0)("impresora1"), ListaIMP1, Check_1)
        Asigna_impresora(Obtener_lk_sql_formatos(0)("impresora2"), ListaIMP2, Check_2)
        Asigna_impresora(Obtener_lk_sql_formatos(0)("impresora3"), ListaIMP3, Check_3)


    End Sub
    Private Sub Asigna_impresora(nombreImpresora As String, listaimp As ListBox, marcaimp As CheckBox)

        If nombreImpresora = "" Then
            marcaimp.Checked = False
            listaimp.DataSource = Nothing
            listaimp.Items.Clear()
            Exit Sub
        End If
        ' Configurar la impresión en la impresora predeterminada
        marcaimp.Checked = True
        Dim impresoras As PrinterSettings.StringCollection = PrinterSettings.InstalledPrinters
        ListaIMP1.DataSource = New BindingSource(impresoras, Nothing)

        Dim impresora As New PrinterSettings()
        impresora.PrinterName = nombreImpresora

        For i As Integer = 0 To listaimp.Items.Count - 1
            Dim nombreImpresoraEnLista As String = listaimp.Items(i).ToString()
            ' Comprobar si el nombre de la impresora coincide con el nombre predeterminado
            If nombreImpresoraEnLista = nombreImpresora Then
                ' Establecer el elemento seleccionado en ListaIMP
                listaimp.SelectedIndex = i
                Exit For ' Salir del bucle una vez que se ha encontrado la impresora predeterminada
            End If
        Next

    End Sub
    Private Sub CmdNoImprime_Click(sender As Object, e As EventArgs) Handles CmdNoImprime.Click
        marcaimpresora("1")
    End Sub
    Private Sub marcaimpresora(wcodigo As Integer)
        CmdNoImprime.BackColor = Color.Transparent
        CmdNoImprime.ForeColor = Color.Black
        CmdNoImprime.Tag = "1"
        id_destino.Text = "0"
        Cmdimpresora.BackColor = Color.Transparent
        Cmdimpresora.ForeColor = Color.Black
        Cmdimpresora.Tag = "2"
        cmdpantalla.BackColor = Color.Transparent
        cmdpantalla.ForeColor = Color.Black
        cmdpantalla.Tag = "3"


        cmdpdf.BackColor = Color.Transparent
        cmdpdf.ForeColor = Color.Black
        cmdpdf.Tag = "4"


        If wcodigo = 1 Then ' no imprime
            CmdNoImprime.BackColor = Color.Gray
            CmdNoImprime.ForeColor = Color.White
            id_destino.Text = "1"
            Check_1.Checked = False
            Check_2.Checked = False
            Check_3.Checked = False

            Check_1.Enabled = False
            Check_2.Enabled = False
            Check_3.Enabled = False

        ElseIf wcodigo = 2 Then ' directo a impresora
            Cmdimpresora.BackColor = Color.Gray
            Cmdimpresora.ForeColor = Color.White
            id_destino.Text = "2"
            Check_1.Checked = True

            Check_1.Enabled = True
            Check_2.Enabled = True
            Check_3.Enabled = True
            Dim nombreTabPageDeseada As String = "TabPage1"
            ' Buscar el TabPage con el nombre deseado en el TabControl
            Dim tabPage As TabPage = frameimp.TabPages(nombreTabPageDeseada)
            ' Establecer ese TabPage como el TabPage seleccionado en el TabControl
            frameimp.SelectedTab = tabPage

        ElseIf wcodigo = 3 Then ' directo a Pantalla
            cmdpantalla.BackColor = Color.Gray
            cmdpantalla.ForeColor = Color.White
            id_destino.Text = "3"
            Check_1.Checked = True
            Check_1.Enabled = True
            Check_2.Enabled = True
            Check_3.Enabled = True
        ElseIf wcodigo = 4 Then ' directo a pdf
            cmdpdf.BackColor = Color.Gray
            cmdpdf.ForeColor = Color.White
            id_destino.Text = "4"
            Check_1.Checked = True
            Check_1.Enabled = True
            Check_2.Enabled = True
            Check_3.Enabled = True
        End If

    End Sub

    Private Sub Cmdimpresora_Click(sender As Object, e As EventArgs) Handles Cmdimpresora.Click
        marcaimpresora("2")
    End Sub

    Private Sub cmdpantalla_Click(sender As Object, e As EventArgs) Handles cmdpantalla.Click
        marcaimpresora("3")
    End Sub
    Private Sub formato_impresora(wcodigo As Integer)
        Cmd56.BackColor = Color.Transparent
        Cmd56.ForeColor = Color.Black
        Cmd56.Tag = "1"
        id_formato.Text = "0"

        Cmd80.BackColor = Color.Transparent
        Cmd80.ForeColor = Color.Black
        Cmd80.Tag = "2"
        CmdA4.BackColor = Color.Transparent
        CmdA4.ForeColor = Color.Black
        CmdA4.Tag = "3"
        If id_destino.Text = "1" Then Exit Sub
        If wcodigo = 1 Then ' 56mm
            Cmd56.BackColor = Color.Gray
            Cmd56.ForeColor = Color.White
            id_formato.Text = "1"
        ElseIf wcodigo = 2 Then ' 80mm
            Cmd80.BackColor = Color.Gray
            Cmd80.ForeColor = Color.White
            id_formato.Text = "2"
        ElseIf wcodigo = 3 Then ' A4
            CmdA4.BackColor = Color.Gray
            CmdA4.ForeColor = Color.White
            id_formato.Text = "3"
        End If

    End Sub

    Private Sub Cmd56_Click(sender As Object, e As EventArgs) Handles Cmd56.Click
        formato_impresora("1")
    End Sub

    Private Sub Cmd80_Click(sender As Object, e As EventArgs) Handles Cmd80.Click
        formato_impresora("2")
    End Sub

    Private Sub CmdA4_Click(sender As Object, e As EventArgs) Handles CmdA4.Click
        formato_impresora("3")
    End Sub



    Private Sub cmdpdf_Click(sender As Object, e As EventArgs) Handles cmdpdf.Click
        marcaimpresora("4")
    End Sub

    Private Sub txtNroCopias_TextChanged(sender As Object, e As EventArgs) Handles txtNroCopias.TextChanged

    End Sub

    Private Sub txtNroCopias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNroCopias.KeyPress
        e.Handled = Solo_Numero(e)
    End Sub

    Private Sub cmenos_Click(sender As Object, e As EventArgs) Handles cmenos.Click
        CambiaCopias(-1)
    End Sub
    Private Sub CambiaCopias(wsigno As Integer)
        Dim wvalor As Integer = CInt(txtNroCopias.Text)
        If (wvalor + wsigno) <= 0 Or (wvalor + wsigno) > 10 Then Exit Sub
        txtNroCopias.Text = wvalor + (wsigno)
    End Sub

    Private Sub cmas_Click(sender As Object, e As EventArgs) Handles cmas.Click
        CambiaCopias(1)
    End Sub
    Private Sub CmdAsigna_Click(sender As Object, e As EventArgs) Handles CmdAsigna.Click
        ' Obtener el nombre de la impresora seleccionada por el usuario



        Dim werror As String = ""
        Dim Wresultado As String = ""

        Dim ws_id_negocio As Integer = lk_NegocioActivo.id_Negocio
        Dim ws_id_tb_oper As Integer = Local_id_tb_oper
        Dim ws_id_usuario As Integer = lk_id_usuario
        Dim ws_equipo As String = LK_NOMBRE_PC
        Dim ws_id_destino As Integer = CInt(id_destino.Text)
        Dim ws_id_formato As Integer = CInt(id_formato.Text)
        Dim ws_id_copias As Integer = CInt(txtNroCopias.Text)

        Dim ws_impresora1 As String = ""
        Dim ws_impresora2 As String = ""
        Dim ws_impresora3 As String = ""

        If Check_1.Checked Then
            If ListaIMP1.SelectedItem IsNot Nothing Then
                ws_impresora1 = ListaIMP1.SelectedItem.ToString()
            End If
        End If

        If Check_2.Checked Then
            If ListaIMP3.SelectedItem IsNot Nothing Then
                ws_impresora2 = ListaIMP2.SelectedItem.ToString()
            End If
        End If

        If Check_3.Checked Then
            If ListaIMP3.SelectedItem IsNot Nothing Then
                ws_impresora3 = ListaIMP3.SelectedItem.ToString()
            End If
        End If





            Using command As New SqlCommand("sp_insertar_formatos", lk_connection_cuenta)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Clear()
            ' Agrega los parámetros de entrada
            command.Parameters.AddWithValue("@id_negocio", ws_id_negocio)
            command.Parameters.AddWithValue("@id_tb_oper", ws_id_tb_oper)
            command.Parameters.AddWithValue("@id_usuario", ws_id_usuario)
            command.Parameters.AddWithValue("@equipo", ws_equipo)
            command.Parameters.AddWithValue("@id_destino", ws_id_destino)
            command.Parameters.AddWithValue("@id_formato", ws_id_formato)
            command.Parameters.AddWithValue("@id_copias", ws_id_copias)
            command.Parameters.AddWithValue("@impresora1", ws_impresora1)
            command.Parameters.AddWithValue("@impresora2", ws_impresora2)
            command.Parameters.AddWithValue("@impresora3", ws_impresora3)

            ' Agrega el parámetro de tabla temporal de detalle
            'Dim det_desglose As SqlParameter = command.Parameters.AddWithValue("@tabladesglose", dt_desglose)
            command.Parameters.Add("@Resultado", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            '           det_desglose.SqlDbType = SqlDbType.Structured

            ' Ejecuta el comando
            'Try
            command.ExecuteNonQuery()
            If command.Parameters("@Resultado").Value IsNot DBNull.Value Then
                Wresultado = DirectCast(command.Parameters("@Resultado").Value, String)
            Else
                ' Manejar el caso en el que el valor es DBNull (nulo)
                ' Por ejemplo, puedes asignar un valor predeterminado a Wresultado o lanzar una excepción personalizada.
            End If

            '
        End Using

        If werror <> String.Empty Then ' ERROR DE SQL
            MsgBox(werror)
        End If
        If Wresultado <> String.Empty Then
            Dim Result = MensajesBox.Show("Se Realizo la actualizacion",
                                     "Formatos.")
            Obtiene_formatos()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If


        'lk_FormatoActivo.id_negocio = 0




        'Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Recuperar el nombre de la impresora guardado
        Dim nombreImpresora As String = CmdAsigna.Tag

        ' Configurar la impresión en la impresora predeterminada
        Dim impresora As New PrinterSettings()
        impresora.PrinterName = nombreImpresora
        For i As Integer = 0 To ListaIMP1.Items.Count - 1
            Dim nombreImpresoraEnLista As String = ListaIMP1.Items(i).ToString()

            ' Comprobar si el nombre de la impresora coincide con el nombre predeterminado
            If nombreImpresoraEnLista = nombreImpresora Then
                ' Establecer el elemento seleccionado en ListaIMP
                ListaIMP1.SelectedIndex = i
                Exit For ' Salir del bucle una vez que se ha encontrado la impresora predeterminada
            End If
        Next


    End Sub

    Private Sub Check_1_CheckedChanged(sender As Object, e As EventArgs) Handles Check_1.CheckedChanged
        Dim impresoras As PrinterSettings.StringCollection = PrinterSettings.InstalledPrinters
        If Check_1.Checked Then
            ListaIMP1.DataSource = New BindingSource(impresoras, Nothing)
        Else
            ListaIMP1.DataSource = Nothing
            ListaIMP1.Items.Clear()
        End If
    End Sub

    Private Sub Check_2_CheckedChanged(sender As Object, e As EventArgs) Handles Check_2.CheckedChanged
        Dim impresoras As PrinterSettings.StringCollection = PrinterSettings.InstalledPrinters
        If Check_2.Checked Then
            ListaIMP2.DataSource = New BindingSource(impresoras, Nothing)
        Else
            ListaIMP2.DataSource = Nothing
            ListaIMP2.Items.Clear()
        End If
    End Sub

    Private Sub Check_3_CheckedChanged(sender As Object, e As EventArgs) Handles Check_3.CheckedChanged
        Dim impresoras As PrinterSettings.StringCollection = PrinterSettings.InstalledPrinters
        If Check_3.Checked Then
            ListaIMP3.DataSource = New BindingSource(impresoras, Nothing)
        Else
            ListaIMP3.DataSource = Nothing
            ListaIMP3.Items.Clear()
        End If
    End Sub
End Class