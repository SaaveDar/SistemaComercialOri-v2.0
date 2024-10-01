Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports documentManager.CapaDatos
Imports documentManager.Clases
Imports documentManager.Entidades

Public Class ModeloBase3
    Dim w_fila_edit As Integer

    Public Event NuevoMensaje As EventHandler(Of MensajeEventArgs)
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

    Private Sub CmdMin_Click(sender As Object, e As EventArgs) Handles CmdMin.Click
        WindowState = FormWindowState.Minimized
        Me.Text = ""
        Me.ControlBox = True

    End Sub

    Private Sub CmdRestaurar_Click(sender As Object, e As EventArgs) Handles CmdRestaurar.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub ModeloBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load






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













        Me.Icon = My.Resources.icologo



        Me.ToolTipBotones.SetToolTip(CmdOcultaFiltro, "Ocultar Filtros")
        PanelFiltros.Visible = True
        PanelFiltros.Width = 270
        CmdOcultaFiltro.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft
        dtDetalle.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

        'Dim template As New DataGridViewExpanderColumn.DataGridViewExpanderColumnTemplate()
        'Dim column As New DataGridViewExpanderColumn(template)

        '' Asignar la plantilla personalizada a la columna de grupo
        'dgDocumentos.Columns.Insert(0, column)
        'dgDocumentos.Columns(0).HeaderText = "Grupo"
        'dgDocumentos.Columns(0).Width = 150

        '' Agregar datos al control dgDocumentos
        'Dim dt As New DataTable()
        'dt.Columns.Add("Grupo", GetType(String))
        'dt.Columns.Add("Detalle1", GetType(String))
        'dt.Columns.Add("Detalle2", GetType(String))
        'dt.Columns.Add("Detalle3", GetType(String))

        '' Grupo 1
        'dt.Rows.Add("Grupo 1", "Detalle 1.1", "Detalle 1.2", "Detalle 1.3")
        'dt.Rows.Add("Grupo 1", "Detalle 2.1", "Detalle 2.2", "Detalle 2.3")
        'dt.Rows.Add("Grupo 1", "Detalle 3.1", "Detalle 3.2", "Detalle 3.3")

        '' Grupo 2
        'dt.Rows.Add("Grupo 2", "Detalle 4.1", "Detalle 4.2", "Detalle 4.3")
        'dt.Rows.Add("Grupo 2", "Detalle 5.1", "Detalle 5.2", "Detalle 5.3")
        'dt.Rows.Add("Grupo 2", "Detalle 6.1", "Detalle 6.2", "Detalle 6.3")

        'dgDocumentos.DataSource = dt


    End Sub
    Private Function GetDocumentos() As DataTable
        Dim dt As New DataTable()

        ' Crear las columnas del DataTable
        dt.Columns.Add("Id", GetType(Integer))
        dt.Columns.Add("Nombre", GetType(String))
        dt.Columns.Add("Fecha", GetType(Date))

        ' Agregar algunas filas de ejemplo
        dt.Rows.Add(1, "Documento 1", New Date(2022, 1, 1))
        dt.Rows.Add(2, "Documento 2", New Date(2022, 2, 1))
        dt.Rows.Add(3, "Documento 3", New Date(2022, 3, 1))

        Return dt
    End Function

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim btn As New Button()
        Dim btnQuitar As New Button()
        Dim textB As String
        If ComboBox4.SelectedIndex = -1 Then Exit Sub
        For i = 0 To FlowLayoutPanel1.Controls.Count - 1
            If FlowLayoutPanel1.Controls.Item(i).Tag = ComboBox4.SelectedIndex Then
                Exit Sub
            End If
        Next

        'IconButton1.Tag = ComboBox4.SelectedIndex
        With btn
            .Tag = ComboBox4.SelectedIndex
            .Name = IconButton1.Tag
            Me.ToolTipBotones.SetToolTip(btn, ComboBox4.Items(ComboBox4.SelectedIndex).ToString)
            textB = Strings.Left(ComboBox4.Items(ComboBox4.SelectedIndex).ToString, 10)
            .Text = textB
            .FlatStyle = FlatStyle.Flat
            .ForeColor = Color.White
            .TextAlign = ContentAlignment.TopLeft
            .Font = New Font(New FontFamily("Microsoft Sans Serif"), 7)
            .Width = 100
        End With
        With btnQuitar
            .Tag = ComboBox4.SelectedIndex
            .Name = IconButton1.Tag
            Me.ToolTipBotones.SetToolTip(btn, ComboBox4.Items(ComboBox4.SelectedIndex).ToString)
            textB = "X"
            .Text = textB
            .FlatStyle = FlatStyle.Flat
            .ForeColor = Color.White
            .TextAlign = ContentAlignment.TopCenter
            .Font = New Font(New FontFamily("Microsoft Sans Serif"), 10)
            .Width = 20
        End With

        AddHandler btnQuitar.Click, AddressOf Button_Click   ' Asocias el evento al método Button_Click

        ComboBox4.SelectedIndex = -1

        FlowLayoutPanel1.Controls.Add(btn)  ' Agregas el botón al formulario.
        FlowLayoutPanel1.Controls.Add(btnQuitar)  ' Agregas el botón al formulario.
    End Sub
    Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim c As Control

        For Each c In FlowLayoutPanel1.Controls
            If c.Tag = CType(sender, System.Windows.Forms.Button).Tag Then
                FlowLayoutPanel1.Controls.Remove(c)
                Exit For
            End If
        Next
        For Each c In FlowLayoutPanel1.Controls
            If c.Tag = CType(sender, System.Windows.Forms.Button).Tag Then
                FlowLayoutPanel1.Controls.Remove(c)
                Exit For
            End If
        Next





    End Sub

    Private Sub ComboBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox4.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            e.Handled = True
        Else
            e.Handled = False
        End If
        'Case vbKeyLeft : Print "Ha pulsado la Flecha Izquierda"
        'Case vbKeyRight : Print "Ha pulsado la Flecha Derecha"
        'Case vbKeyUp : Print "Ha pulsado la Flecha Arriba"
        'Case vbKeyDown : Print "Ha pulsado la Flecha Abajo"
        'End Select
    End Sub
    Public Sub NuevaFila()
        dtDetalle.Rows.Add()
        dtDetalle.CurrentCell = dtDetalle.Rows(dtDetalle.Rows.Count - 1).Cells(0)
        dtDetalle.BeginEdit(True)

        'GRID.Rows.Add()
        'GRID.CurrentCell = GRID.Rows(GRID.Rows.Count - 1).Cells(0)
        'GRID.BeginEdit(True)
    End Sub
    Private Sub IconButton3_Click(sender As Object, e As EventArgs) Handles IconButton3.Click

        'DataGridView1.Rows.Add()

        'Exit Sub

        With dtDetalle.Columns

            .Item("Descripcion").Visible = True
            .Item("Descripcion").Width = 150
            .Item("MasDetalle").Visible = True
            .Item("MasDetalle").Width = 150
            .Item("Codigo").Visible = True
            .Item("Codigo").Width = 80
            .Item("id_prod_mae").Visible = False
            .Item("Cantidad").Visible = True
            .Item("Cantidad").Width = 80
            .Item("Present").Visible = True
            .Item("Present").Width = 80
            .Item("id_pres").Visible = False
            .Item("v_equix").Visible = False
            .Item("Alm").Visible = True
            'Dim imageColumn As New DataGridViewImageColumn()
            'imageColumn.HeaderText = "Imagen"
            'imageColumn.Name = "imagen"
            'imageColumn.HeaderText = "Ver"
            'imageColumn.Image = My.Resources.ver
            'imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
            'DataGridResul.Columns.Add(imageColumn)
            '.Item("imagen").Width = 30
        End With


        NuevaFila()



        Exit Sub

    End Sub



    Private Sub DigitaCeldaGrid_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        Dim dataGridView As DataGridView = GetParentDataGridView(textBox)
        If dataGridView IsNot Nothing Then
            Dim currentCell As DataGridViewCell = dataGridView.CurrentCell ' Obtiene la celda actualmente seleccionada
            If textBox.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
                Dim row As Integer = currentCell.RowIndex
                Dim column As Integer = currentCell.ColumnIndex
                'MessageBox.Show($"Ha escrito " & textBox.Text & " más de 3 caracteres en la celda en la fila {row} y la columna {column}.")
                '  BUSCAR(textBox.Text)
            End If
        End If

    End Sub
    Private Sub BUSCAR(TEXTO As String)
        MsgBox(" BbUSCAR : " & TEXTO)
    End Sub
    Private Function GetParentDataGridView(control As Control) As DataGridView
        Dim currentControl As Control = control
        Do While currentControl IsNot Nothing AndAlso Not TypeOf currentControl Is DataGridView
            currentControl = currentControl.Parent
        Loop
        Return CType(currentControl, DataGridView)
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '' Crear una instancia del formulario que deseas cargar
        'Dim formularioACentrar As New FrmFilaGrid()

        '' Establecer la propiedad StartPosition en CenterParent
        'formularioACentrar.StartPosition = FormStartPosition.CenterParent

        '' Establecer la propiedad Owner en el formulario actual
        'formularioACentrar.Owner = Me

        '' Mostrar el formulario centrado en el formulario actual
        'formularioACentrar.ShowDialog()


        ''Dim formularioACentrar As New FrmFilaGrid()

        '''' Establecer la posición del formulario para que esté centrado en el control


        '''' Mostrar el formulario centrado en el control
        ''formularioACentrar.ShowDialog()


        ''formularioACentrar.Location = New Point(DataGridView1.Left + (DataGridView1.Width - formularioACentrar.Width) \ 2,
        ''                                DataGridView1.Top + (DataGridView1.Height - formularioACentrar.Height) \ 2)

        ''Dim posicionRelativa As Point = DataGridView1.Location

        '''' Calcular la posición en la que el formulario debe ubicarse para que esté centrado en el control
        ''Dim posicionFormulario As New Point(posicionRelativa.X + (DataGridView1.Width - formularioACentrar.Width) \ 2,
        ''                                     posicionRelativa.Y + (DataGridView1.Height - formularioACentrar.Height) \ 2)

        '' Establecer la posición del formulario
        ''    formularioACentrar.Location = posicionFormulario

        '' Mostrar el formulario centrado en el control
        ''formularioACentrar.ShowDialog()



        '    End
    End Sub


    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.RowIndex < 0 Then Exit Sub
        Dim valorActual As Object = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        ' Pasar valorActual a otra parte de su programa

        ActualizarBaseDeDatos(valorActual.ToString)
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        ActualizarBaseDeDatos("Fijo")
    End Sub
    Private Sub ActualizarBaseDeDatos(wval As String)
        ' Código para actualizar la base de datos aquí
        MsgBox("escribiendo :  " & wval)
    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dtDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtDetalle.CellContentClick

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub dtDetalle_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dtDetalle.CurrentCellDirtyStateChanged
        If dtDetalle.IsCurrentCellDirty Then
            dtDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If



    End Sub

    Private Sub dtDetalle_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtDetalle.CellValueChanged
        If e.RowIndex < 0 Then Exit Sub
        Dim valorActual As Object = dtDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        If valorActual Is Nothing Then Exit Sub



        ' Pasar valorActual a otra parte de su programa
        If BuscaProductos(valorActual.ToString, e.RowIndex, e.ColumnIndex) = False Then
            dtDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
            dtDetalle.CancelEdit()
            dtDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
        End If
    End Sub
    Private Function BuscaProductos(cadena As String, wfila As Integer, wcol As Integer) As Boolean
        BuscaProductos = True
        If Len(cadena) = 3 And wcol = 0 Then
            '  MsgBox(cadena & " Fila : " & wfila & " Col : " & wcol)
            Dim frbusca As New FrmProductos
            '  frbusca.LblEtiqueta.Text = Trim(DirectCast(sender, Button).Text)
            ' frbusca.LblEtiqueta.Tag = DirectCast(sender, Button).Tag.ToString()
            'Dim tamaño As Rectangle = My.Computer.Screen.Bounds
            'frbusca.Left = (Me.Left) + 220
            'frbusca.Top = (Me.Top) + 120
            frbusca.TxtBuscar.Tag = cadena
            frbusca.ShowDialog()
            BuscaProductos = False
        End If
    End Function


    Private Sub dtDetalle_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dtDetalle.EditingControlShowing

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Crear un objeto DataTable
        ' Crear una lista de documentos de ejemplo
        Dim documentos As New List(Of Documento)()

        ' Agregar algunos documentos a la lista
        Dim documento1 As New Documento()
        documento1.ID = 1
        documento1.Fecha = #2023-04-25#
        documento1.Nombre = "Documento 1"
        documento1.Detalles = New List(Of DetalleDocumento) From {
    New DetalleDocumento() With {.Descripcion = "Detalle 1"},
    New DetalleDocumento() With {.Descripcion = "Detalle 2"}
}
        documentos.Add(documento1)

        Dim documento2 As New Documento()
        documento2.ID = 2
        documento2.Fecha = #2023-04-26#
        documento2.Nombre = "Documento 2"
        documento2.Detalles = New List(Of DetalleDocumento) From {
    New DetalleDocumento() With {.Descripcion = "Detalle 1"},
    New DetalleDocumento() With {.Descripcion = "Detalle 2"},
    New DetalleDocumento() With {.Descripcion = "Detalle 3"}
}
        documentos.Add(documento2)

        Dim documento3 As New Documento()
        documento3.ID = 3
        documento3.Fecha = #2023-04-27#
        documento3.Nombre = "Documento 3"
        documento3.Detalles = New List(Of DetalleDocumento) From {
    New DetalleDocumento() With {.Descripcion = "Detalle 1"}
}
        documentos.Add(documento3)

        ' Crear un objeto DataTable
        Dim dtDocumentos As New DataTable()

        ' Configurar la propiedad de agrupamiento por el ID del documento
        dgDocumentos.RowHeadersVisible = False
        dgDocumentos.RowTemplate.Height = 30 ' Altura de las filas
        dgDocumentos.RowTemplate.DefaultCellStyle.BackColor = Color.White ' Fondo de las filas

        For Each documento As Documento In documentos ' donde "documentos" es una lista de objetos Documento
            Dim nuevaFilaDocumento As DataGridViewRow = dgDocumentos.Rows(dgDocumentos.Rows.Add())
            nuevaFilaDocumento.Cells("ID").Value = documento.ID
            nuevaFilaDocumento.Cells("Fecha").Value = documento.Fecha
            nuevaFilaDocumento.Cells("Nombre").Value = documento.Nombre

            For Each detalle As DetalleDocumento In documento.Detalles ' donde "Detalles" es una lista de objetos DetalleDocumento
                Dim nuevaFilaDetalle As DataGridViewRow = dgDocumentos.Rows(dgDocumentos.Rows.Add())
                nuevaFilaDetalle.Cells("ID").Value = documento.ID
                nuevaFilaDetalle.Cells("Detalle").Value = detalle.Descripcion
                nuevaFilaDetalle.Tag = nuevaFilaDocumento ' Asignar la fila de documento como "padre" de la fila de detalle
                nuevaFilaDetalle.Visible = False ' Ocultar las filas de detalle por defecto
            Next
        Next

        ' Configurar las propiedades del DataGridView
        dgDocumentos.Columns("ID").Width = 50
        dgDocumentos.Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
        dgDocumentos.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgDocumentos.Columns("Detalle").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        ' Agregar un controlador de eventos para expandir y contraer las filas de detalle


        For Each fila As DataGridViewRow In dgDocumentos.Rows
            If fila.Cells("Detalle").Value IsNot Nothing Then ' Solo expandir y contraer las filas de detalle
                If fila.Visible Then ' Si la fila está visible, ocultarla y mostrar la fila "padre"
                    fila.Visible = False ' Ocultar la fila actual
                    Dim filaPadre As DataGridViewRow = DirectCast(fila.Tag, DataGridViewRow) ' Obtener la fila "padre"
                    filaPadre.Visible = True ' Mostrar la fila "padre"
                Else ' Si la fila está oculta, mostrarla y ocultar todas las filas "hijas"
                    fila.Visible = True ' Mostrar la fila actual
                    For Each filaHija As DataGridViewRow In dgDocumentos.Rows
                        If filaHija.Visible AndAlso filaHija.Tag Is fila Then
                            filaHija.Visible = False
                        End If
                    Next
                End If
            End If
        Next


    End Sub
    ' Método para obtener los datos de detalle de una fila de maestro

    Private Function GetDetailData(masterId As Integer) As DataTable
        Dim data As New DataTable()
        ' Lógica para obtener los datos de detalle del maestro seleccionado
        Return data
    End Function

    Private Sub dgDocumentos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDocumentos.CellContentClick
        'If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
        '    ' Obtener los datos de detalle de la fila seleccionada
        '    Dim idDocumento As Integer = CInt(dgDocumentos.Rows(e.RowIndex).Cells("Id").Value)
        '    Dim nombreDocumento As String = CStr(dgDocumentos.Rows(e.RowIndex).Cells("Nombre").Value)
        '    Dim fechaDocumento As Date = CDate(dgDocumentos.Rows(e.RowIndex).Cells("Fecha").Value)

        '    ' Mostrar el detalle en una ventana emergente
        '    MessageBox.Show($"ID: {idDocumento}{vbCrLf}Nombre: {nombreDocumento}{vbCrLf}Fecha: {fechaDocumento}",
        '                    "Detalle del documento", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    Private Sub dgDocumentos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDocumentos.CellClick

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click



        Dim remitente As String = "UsuarioRemitente"
        Dim destinatario As String = "UsuarioDestinatario"
        Dim contenido As String = "¡Hola! Has recibido un nuevo mensaje."

        ' Insertar el mensaje en la base de datos aquí

        ' Publicar el evento de "nuevo mensaje"
        RaiseEvent NuevoMensaje(Me, New MensajeEventArgs(remitente, destinatario, contenido))

        Exit Sub








        Dim command As New SqlCommand()
        'Dim wid_oper As Integer
        'Dim adapter As SqlDataAdapter
        Dim dt_operaciones As New DataTable


        command.CommandText = "INSERT INTO m_noti VALUES (@id_negocio, @id_usuario_rem, @id_usuario_des, @sms)"
        command.Parameters.Clear()
        command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.AddWithValue("@id_usuario_rem", lk_id_usuario)
        command.Parameters.AddWithValue("@id_usuario_des", 1)
        command.Parameters.AddWithValue("@sms", "Hola Hora:" & DateTime.Now.ToString("HH:mm tt"))

        command.ExecuteNonQuery()



        'sql_cade = "select  * from [dbo].[vw_lista_box] " ' filtro para buscar por el id : id_oper_maestro
        'lk_sql_listaOperBox = New DataTable()
        'Command = New SqlCommand(sql_cade, lk_connection_master)
        'adaptador = New SqlDataAdapter(Command)
        'adaptador.Fill(lk_sql_listaOperBox)





    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim frMenuProductos As New FrmFilaGrid
        ' PlaySonidoMouse(lk_CodigoSonido)
        frMenuProductos.Show()
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click

    End Sub

    Private Sub CmdOcultaFiltro_Click(sender As Object, e As EventArgs) Handles CmdOcultaFiltro.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Connection.srv = "34.134.43.163"
        Connection.bd = "r23_negocio_cuenta"
        Connection.usr = "sa"
        Connection.pwd = "yp257sjtfBpqnNK8F%5s"
        Connection.port = "1433"
        Parametros.url_carpeta = "D:\Tempo" ' archivos xml temp

        ' Crear una instancia de la clase Connection
        Dim oCn As New Connection()

        ' Intentar establecer la conexión
        If oCn.setConnection() IsNot Nothing Then
            MessageBox.Show("Se conectó correctamente")

            ' Crear una instancia de la clase EmpresaCredencialesDAL
            Dim empresaDAL As New EmpresaCredencialesDAL()

            ' Cargar el entorno con el ID 22
            empresaDAL.loadEnviroment(22)
        End If

        MessageBox.Show(Parametros.razon_social)
    End Sub
End Class
Public Class MensajeEventArgs
    Inherits EventArgs

    Public Property Remitente As String
    Public Property Destinatario As String
    Public Property Contenido As String

    Public Sub New(remitente As String, destinatario As String, contenido As String)
        Me.Remitente = remitente
        Me.Destinatario = destinatario
        Me.Contenido = contenido
    End Sub
End Class

Public Class Documento
    Public Property ID As Integer
    Public Property Fecha As Date
    Public Property Nombre As String
    Public Property Detalles As List(Of DetalleDocumento)
End Class
Public Class DetalleDocumento
    Public Property Descripcion As String
End Class