Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Runtime.InteropServices

Public Class FrmConfLocal
    Dim loc_id_negocio As Integer
    Dim loc_id_local As Integer

    Public Property Seleccion_id_local As Integer
    Public Property Seleccion_id_Negocio As Integer



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

    Private Sub FrmConfLocal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
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

        Dim Obtener_impto() As DataRow = lk_sql_impuesto_mae.Select("id_local = " & Seleccion_id_local & " and codigo = 1 ")
        If Obtener_impto.Count = 0 Then
            Exit Sub
        End If
        TxtVal_imp.Text = Obtener_impto(0)("vporc")
        TxtEti_imp.Text = Obtener_impto(0)("descripcion")


        Lbl_local.Text = lk_NegocioActivo.nombre.ToString.Trim & " \ " & Seleccion_id_local ' & " - " & lk_LocalActivo.nombre
        loc_id_negocio = Seleccion_id_Negocio
        loc_id_local = Seleccion_id_local
        'Stop
        ' = lk_sql_impuesto_mae.ro
        'TxtVal_imp
        'sql_cade = "select  id_local , codigo, vporc, descripcion from impuesto_mae where id_negocio = " & wid_Negocio & "  and estado = 1 "
        'lk_sql_impuesto_mae = New DataTable()
        'Command = New SqlCommand(sql_cade, lk_connection_cuenta)
        'adaptador = New SqlDataAdapter(Command)
        'adaptador.Fill(lk_sql_impuesto_mae)


    End Sub

    Private Sub Muestra_Comprobantes(wid_tb_oper As Integer)
        Dim Comprobantes() As DataRow = lk_sql_comp_oper.Select("id_tb_oper = " & wid_tb_oper & " And es_interno = 0 ")
        ' Recorremos las filas filtradas
        Cabe_series()
        CmbListaComp.Items.Clear()
        If Comprobantes.Length = 0 Then
            Exit Sub
        End If

        For i = 0 To Comprobantes.Length - 1
            CmbListaComp.Items.Add(Comprobantes(i)("codigo") & " " & Comprobantes(i)("abreviado") & " " & Comprobantes(i)("descripcion") & Space(80) & Comprobantes(i)("id_comprobante"))
        Next i
        If CmbListaComp.Items.Count > 0 Then
            CmbListaComp.SelectedIndex = 0

        End If
    End Sub

    Private Sub CmdOperacion_Click(sender As Object, e As EventArgs) Handles CmdOperacion.Click


        Dim grupos As New List(Of String)()

        For Each fila As DataRow In lk_sql_listaOperMenu.Rows
            Dim grupo As String = fila("grupo")

            If Not grupos.Contains(grupo) Then
                grupos.Add(grupo)
            End If
        Next

        Dim menu As New ToolStripDropDownMenu()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'menu.AutoSize = False
        'menu.Width = CmdOperacion.Width
        ' menu.Height = CmdOperacion.Height


        For Each grupo As String In grupos
            Dim subMenu As New ToolStripMenuItem(grupo)

            For Each fila As DataRow In lk_sql_listaOperMenu.Rows
                If fila("grupo") = grupo Then
                    Dim detalle As String = fila("detalle")
                    Dim id As Integer = Convert.ToInt32(fila("codigo"))
                    Dim id_tb_oper As Integer = Convert.ToInt32(fila("id_tb_oper"))
                    Dim detalleItem As New ToolStripMenuItem(detalle)
                    detalleItem.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
                    detalleItem.ForeColor = Color.White
                    'detalleItem.AutoSize = False
                    'detalleItem.Width = CmdOperacion.Width
                    'detalleItem.Height = CmdOperacion.Height


                    ' Asociar el Id con el elemento del submenú
                    detalleItem.Tag = id
                    detalleItem.AccessibleName = id_tb_oper
                    detalleItem.AccessibleDescription = detalle

                    ' Agregar un controlador de eventos para el elemento del submenú
                    AddHandler detalleItem.Click, AddressOf Detalle_Click

                    subMenu.DropDownItems.Add(detalleItem)
                End If
            Next

            menu.Items.Add(subMenu)
        Next

        menu.Show(CmdOperacion, New Point(0, CmdOperacion.Height))

    End Sub
    Private Sub Detalle_Click(sender As Object, e As EventArgs)
        Dim Codigooper As Integer = Convert.ToInt32(DirectCast(sender, ToolStripMenuItem).Tag)
        Dim id_tb_oper As Integer = Convert.ToInt32(DirectCast(sender, ToolStripMenuItem).AccessibleName)
        Dim detalle As String = DirectCast(sender, ToolStripMenuItem).AccessibleDescription
        CmdOperacion.Text = detalle
        CmdOperacion.Tag = id_tb_oper
        TxtOperacion.Text = Codigooper

        Muestra_Comprobantes(id_tb_oper)
        ' Mostraroperacion(Codigooper)
    End Sub

    Private Sub TxtOperacion_TextChanged(sender As Object, e As EventArgs) Handles TxtOperacion.TextChanged

    End Sub

    Private Sub TxtOperacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtOperacion.KeyPress
        Solo_Numero(e)

        If e.KeyChar = Chr(13) Then

            Dim resulOper() As DataRow = lk_sql_listaOperMenu.Select("codigo = '" & Trim(TxtOperacion.Text) & "'")
            If resulOper.Length = 0 Then
                Exit Sub
            End If


            Dim Comprobantes() As DataRow = lk_sql_comp_oper.Select("id_tb_oper = '" & Trim(resulOper(0)("id_tb_oper")) & "' And es_interno = 0 ")
            ' Recorremos las filas filtradas

            CmbListaComp.Items.Clear()
            If Comprobantes.Length = 0 Then
                Exit Sub
            End If
            CmdOperacion.Text = resulOper(0)("detalle")
            CmdOperacion.Tag = Trim(resulOper(0)("id_tb_oper"))

            For i = 0 To Comprobantes.Length - 1
                CmbListaComp.Items.Add(Comprobantes(i)("codigo") & " " & Comprobantes(i)("abreviado") & " " & Comprobantes(i)("descripcion") & Space(80) & Comprobantes(i)("id_comprobante"))
            Next i
            If CmbListaComp.Items.Count > 0 Then
                CmbListaComp.SelectedIndex = 0
            End If

        End If
    End Sub

    Private Sub CmbListaComp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbListaComp.SelectedIndexChanged
        Dim ws_cod As Integer = Val(Strings.Right(CmbListaComp.Text, 10))
        ListaRegistros(ws_cod, loc_id_negocio, loc_id_local, Val(CmdOperacion.Tag))
    End Sub
    Private Sub ListaRegistros(ws_comprobante As Integer, wid_negocio As Integer, wid_local As Integer, wid_tb_oper As Integer)
        Cabe_series()
        Dim Comprobantes() As DataRow = lk_sql_comp_oper.Select("id_tb_oper = " & wid_tb_oper & " And id_comprobante = " & ws_comprobante & " ")
        ' Recorremos las filas filtradas
        If Comprobantes.Length = 0 Then
            Exit Sub
        End If

        If Comprobantes(0)("es_manual") = 1 Then
            LblTs.Text = "SERIES ES DIGITADO POR EL USUARIO"
            dt_Tablas_basicas.Columns.Clear()
            dt_Tablas_basicas.Rows.Clear()
        Else
            LblTs.Text = "LISTA DE SERIES PARA EL COMPROBANTE"


            Dim lk_sql_listafiltro As New DataTable
            Dim command As SqlCommand
            Dim adapter As SqlDataAdapter


            command = New SqlCommand("select  * from m_series where id_negocio = " & wid_negocio & " and id_local  = " & wid_local & " and  id_comprobante = " & ws_comprobante & " order by orden", lk_connection_cuenta)
            adapter = New SqlDataAdapter(command)
            lk_sql_listafiltro = New DataTable
            adapter.Fill(lk_sql_listafiltro)

            If lk_sql_listafiltro.Rows.Count = 0 Then

                Dim Result As String = MensajesBox.Show("No Existe Registros en su consulta. Debe Crear una serie para usar la Operacion...",
                                        "Lista de series.")
                Me.dt_Tablas_basicas.Rows.Add()
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("num").Value = 1
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("es_pordefecto").Value = 0
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("id_comprobante").Value = ws_comprobante
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("id_local").Value = wid_local
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("estado").Value = True
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("id_negocio").Value = wid_negocio


                Contador_filas()
                dt_Tablas_basicas.Focus()
                Exit Sub


            End If
            Dim witems As Integer = 0
            For i = 0 To lk_sql_listafiltro.Rows.Count - 1

                Me.dt_Tablas_basicas.Rows.Add()
                witems = witems + 1

                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("num").Value = witems
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("id_comprobante").Value = lk_sql_listafiltro.Rows(i).Item("id_comprobante")
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("serie").Value = lk_sql_listafiltro.Rows(i).Item("serie")
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("serie").ReadOnly = True

                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("es_inicial").Value = lk_sql_listafiltro.Rows(i).Item("es_inicial")
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("num_inicial").Value = lk_sql_listafiltro.Rows(i).Item("num_inicial")
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("num_final").Value = lk_sql_listafiltro.Rows(i).Item("num_final")
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("orden").Value = lk_sql_listafiltro.Rows(i).Item("orden")
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("es_pordefecto").Value = lk_sql_listafiltro.Rows(i).Item("es_pordefecto")
                If lk_sql_listafiltro.Rows(i).Item("estado") Then
                    dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("estado").Value = True
                Else
                    dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("estado").Value = False
                End If

                If lk_sql_listafiltro.Rows(i).Item("es_electronico") Then
                    dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("es_fe").Value = True
                Else
                    dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("es_fe").Value = False
                End If

                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("id_negocio").Value = lk_sql_listafiltro.Rows(i).Item("id_negocio")
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("id_local").Value = lk_sql_listafiltro.Rows(i).Item("id_local")



            Next
            Contador_filas()
            dt_Tablas_basicas.Focus()

        End If




    End Sub
    Private Sub Cabe_series()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()
        ' Dim controlLabel As Label



        dt_Tablas_basicas.Columns.Clear()



        dt_Tablas_basicas.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)

        textoColumn.Name = "num"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 25
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_comprobante"
        textoColumn.Tag = "N"
        textoColumn.HeaderText = "Id "
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 50
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "serie"
        textoColumn.Tag = "N"
        textoColumn.HeaderText = "SERIE"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 50
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = False

        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "es_inicial"
        checkColumn.HeaderText = "ACTIVA INICIAL"
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(checkColumn)
        dt_Tablas_basicas.Columns.Item(checkColumn.Name).Width = 40
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "num_inicial"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "NUM INICIAL"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 60
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "num_final"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "NUM FINAL"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 60
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "orden"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "NUM ORDEN"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 40
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = False


        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "estado"
        checkColumn.HeaderText = "EST"
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(checkColumn)
        dt_Tablas_basicas.Columns.Item(checkColumn.Name).Width = 40
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = False

        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "es_fe"
        checkColumn.HeaderText = "F.E."
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(checkColumn)
        dt_Tablas_basicas.Columns.Item(checkColumn.Name).Width = 40
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = False



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "es_pordefecto"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "es_pordefecto"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 40
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_negocio"
        textoColumn.HeaderText = "id_negocio"
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 50
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_local"
        textoColumn.HeaderText = "id_local"
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 50
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Visible = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "add"
        imageColumn.Image = My.Resources.add
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dt_Tablas_basicas.Columns.Add(imageColumn)
        dt_Tablas_basicas.Columns.Item(imageColumn.Name).Width = 28
        dt_Tablas_basicas.Columns.Item(imageColumn.Name).ReadOnly = False


        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "eli"
        imageColumn.Image = My.Resources.del
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dt_Tablas_basicas.Columns.Add(imageColumn)
        dt_Tablas_basicas.Columns.Item(imageColumn.Name).Width = 28
        dt_Tablas_basicas.Columns.Item(imageColumn.Name).ReadOnly = False
        dt_Tablas_basicas.Columns.Item(imageColumn.Name).Visible = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "ok"
        imageColumn.Image = My.Resources.ok
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dt_Tablas_basicas.Columns.Add(imageColumn)
        dt_Tablas_basicas.Columns.Item(imageColumn.Name).Width = 28
        dt_Tablas_basicas.Columns.Item(imageColumn.Name).ReadOnly = False



    End Sub
    Private Sub Contador_filas()



        'Exit Sub
        'Iterar por cada fila en el DataGridView
        If dt_Tablas_basicas.Visible = False Then Exit Sub

        If dt_Tablas_basicas.CurrentCell Is Nothing Then Exit Sub
        Dim ultimafila As Integer = 0
        For i As Integer = 0 To dt_Tablas_basicas.Rows.Count - 1
            'Actualizar el valor de la celda de la primera columna al número de fila actual
            dt_Tablas_basicas.Rows(i).Cells("num").Value = (i + 1).ToString()
            If i = dt_Tablas_basicas.Rows.Count - 1 Then
                dt_Tablas_basicas.Rows(i).Cells("eli").Value = My.Resources.del
                dt_Tablas_basicas.Rows(i).Cells("eli").Tag = "eli"
                dt_Tablas_basicas.Rows(i).Cells("add").Value = My.Resources.add
                dt_Tablas_basicas.Rows(i).Cells("add").Tag = "add"

            Else
                dt_Tablas_basicas.Rows(i).Cells("eli").Value = My.Resources.del
                dt_Tablas_basicas.Rows(i).Cells("eli").Tag = "eli"
                dt_Tablas_basicas.Rows(i).Cells("add").Value = My.Resources.edit
                dt_Tablas_basicas.Rows(i).Cells("add").Tag = ""
            End If
            ultimafila = i
        Next
        'If ultimafila = 0 Then Exit Sub
        ''If GridProductos.Rows.Count = 0 Then
        'Dim currentImage As Image = GridProductos.Rows(ultimafila + 1).Cells("eli").Value
        'If currentImage Is My.Resources.eliminar Then
        '    GridProductos.Rows(ultimafila + 1).Cells("eli").Value = My.Resources.ver
        'End If
        ''End If

    End Sub

    Private Sub dt_Tablas_basicas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dt_Tablas_basicas.CellContentClick

    End Sub

    Private Sub dt_Tablas_basicas_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dt_Tablas_basicas.RowsAdded
        Contador_filas()
    End Sub

    Private Sub dt_Tablas_basicas_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dt_Tablas_basicas.RowsRemoved
        Contador_filas()
    End Sub

    Private Sub dt_Tablas_basicas_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles dt_Tablas_basicas.PreviewKeyDown
        If e.KeyCode = Keys.Enter And dt_Tablas_basicas.Focused Then ' Verificar si se ha presionado la tecla "Delete" en el DataGridView
            If dt_Tablas_basicas.CurrentCell Is Nothing Then Exit Sub
            Dim columnIndex As Integer = dt_Tablas_basicas.CurrentCell.ColumnIndex ' Obtener el índice de la columna actual
            Dim columnName As String = dt_Tablas_basicas.Columns(columnIndex).Name ' Obtener el nombre de la columna actual
            Dim rowIndex As Integer = dt_Tablas_basicas.CurrentCell.RowIndex ' Obtener el índice de la fila actual
            'Dim rowTag As Object = GridProductos.Rows(rowIndex).Tag ' Obtener el contenido del tag de la fila actual
            Dim rowTag As Object = dt_Tablas_basicas.Rows(rowIndex).Cells("eli").Tag ' Obtener el contenido del tag de la celda actual


            If columnName = "eli" Then
                'If dt_Tablas_basicas.Rows.Count - 1 = 0 Then
                '    dt_Tablas_basicas.Rows.Clear()
                '    ' GridLoteProductos_Inicia()
                '    Me.dt_Tablas_basicas.Rows.Add()
                '    Contador_filas()
                '    Exit Sub
                'End If
                'dt_Tablas_basicas.Rows.Remove(dt_Tablas_basicas.CurrentRow) ' Eliminar la primera fila seleccionada

                'Me.dt_Tablas_basicas.CurrentCell = dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("num")
                'Me.dt_Tablas_basicas.BeginEdit(True)
                'Contador_filas()
            End If
            If columnName = "add" Then ' Verificar que se haya seleccionado alguna fila
                If dt_Tablas_basicas.Rows(rowIndex).Cells("add").Tag = "" Then Exit Sub
                Dim ws_cod As Integer = Val(Strings.Right(CmbListaComp.Text, 10))

                Me.dt_Tablas_basicas.Rows.Add()
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("num").Value = 1
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("es_pordefecto").Value = 0
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("id_comprobante").Value = ws_cod
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("id_local").Value = loc_id_local
                dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("id_negocio").Value = loc_id_negocio


                Me.dt_Tablas_basicas.CurrentCell = dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("num")
                Me.dt_Tablas_basicas.BeginEdit(True)
                Contador_filas()
                'GridProductos_PrimeraFila()
            End If
            If columnName = "ok" Then ' Verificar que se haya seleccionado alguna fila
                'ConfirmaTodoLote()
                'GridProductos_PrimeraFila()
            End If
        End If
    End Sub

    Private Sub CmdGrabar_Click(sender As Object, e As EventArgs) Handles CmdGrabar.Click
        Dim lk_sql_listafiltro As New DataTable

        Dim command As New SqlCommand()
        Dim Bus_command As SqlCommand
        Dim adapter As SqlDataAdapter
        Dim Result As String = ""
        command.Connection = lk_connection_cuenta
        For i As Integer = 0 To dt_Tablas_basicas.Rows.Count - 1
            'Actualizar el valor de la celda de la primera columna al número de fila actual
            If Val(dt_Tablas_basicas.Rows(i).Cells("id_comprobante").Value) <> 0 Then
                If dt_Tablas_basicas.Rows(i).Cells("serie").Value.ToString.Length <> 4 Then
                    Result = MensajesBox.Show("Debe indicar la Serie de 4 digitos  , Serie : " & dt_Tablas_basicas.Rows(i).Cells("serie").Value.ToString & " ?", "Series.")
                    Exit Sub
                End If
            End If

            If Val(dt_Tablas_basicas.Rows(i).Cells("num_inicial").Value) = 0 Then
                Result = MensajesBox.Show("Debe indicar Num. Inicial, minimo 1  , Serie :  " & dt_Tablas_basicas.Rows(i).Cells("serie").Value.ToString & " ?", "Series.")
                Exit Sub
            End If

            If Val(dt_Tablas_basicas.Rows(i).Cells("num_final").Value) = 0 Then
                Result = MensajesBox.Show("Debe indicar Num. Final, Maximo 99999999  , Serie : " & dt_Tablas_basicas.Rows(i).Cells("serie").Value.ToString & " ?", "Series.")
                Exit Sub
            End If
            If Val(dt_Tablas_basicas.Rows(i).Cells("orden").Value) = 0 Then
                Result = MensajesBox.Show("Debe indicar ORDEN, minimo 1 , Serie : " & dt_Tablas_basicas.Rows(i).Cells("serie").Value.ToString & " ?", "Series.")
                Exit Sub
            End If
        Next
        For i As Integer = 0 To dt_Tablas_basicas.Rows.Count - 1
            'Actualizar el valor de la celda de la primera columna al número de fila actual
            If Val(dt_Tablas_basicas.Rows(i).Cells("id_comprobante").Value) <> 0 Then
                Bus_command = New SqlCommand("select  id_comprobante from m_series where serie =  '" & dt_Tablas_basicas.Rows(i).Cells("serie").Value.ToString.Trim & "' and id_negocio = " & loc_id_negocio & " and id_local  = " & loc_id_local & " and  id_comprobante = " & Val(dt_Tablas_basicas.Rows(i).Cells("id_comprobante").Value) & " order by orden", lk_connection_cuenta)
                adapter = New SqlDataAdapter(Bus_command)
                lk_sql_listafiltro = New DataTable
                adapter.Fill(lk_sql_listafiltro)
                If lk_sql_listafiltro.Rows.Count = 0 Then
                    Try
                        command.CommandText = "insert into m_series values (@id_negocio,@id_local,@id_comprobante,@serie,1,@es_inicial,@num_inicial,@num_final,@orden,0,@estado,@es_electronico) "
                        command.Parameters.Clear()
                        command.Parameters.AddWithValue("@id_negocio", Val(dt_Tablas_basicas.Rows(i).Cells("id_negocio").Value))
                        command.Parameters.AddWithValue("@id_local", Val(dt_Tablas_basicas.Rows(i).Cells("id_local").Value))
                        command.Parameters.AddWithValue("@id_comprobante", Val(dt_Tablas_basicas.Rows(i).Cells("id_comprobante").Value))
                        command.Parameters.AddWithValue("@serie", dt_Tablas_basicas.Rows(i).Cells("serie").Value.ToString.Trim)
                        If dt_Tablas_basicas.Rows(i).Cells("es_inicial").Value Then
                            command.Parameters.AddWithValue("@es_inicial", 1)
                        Else
                            command.Parameters.AddWithValue("@es_inicial", 0)
                        End If
                        command.Parameters.AddWithValue("@num_inicial", Val(dt_Tablas_basicas.Rows(i).Cells("num_inicial").Value))
                        command.Parameters.AddWithValue("@num_final", Val(dt_Tablas_basicas.Rows(i).Cells("num_final").Value))
                        command.Parameters.AddWithValue("@orden", Val(dt_Tablas_basicas.Rows(i).Cells("orden").Value))
                        If dt_Tablas_basicas.Rows(i).Cells("estado").Value Then
                            command.Parameters.AddWithValue("@estado", 1)
                        Else
                            command.Parameters.AddWithValue("@estado", 0)
                        End If
                        If dt_Tablas_basicas.Rows(i).Cells("es_fe").Value Then
                            command.Parameters.AddWithValue("@es_electronico", 1)
                        Else
                            command.Parameters.AddWithValue("@es_electronico", 0)
                        End If


                        command.ExecuteNonQuery()
                        'command.Transaction.Commit()
                    Catch ex As Exception
                        Result = MensajesBox.Show("No Actualizo , Intentar Nuevamente " & dt_Tablas_basicas.Rows(i).Cells("serie").ToString & " ?", "Series.")
                        Exit Sub
                    End Try
                Else
                    Try
                        command.CommandText = "update m_series set es_inicial  = @es_inicial, num_inicial = @num_inicial  , num_final = @num_final , orden = @orden , estado = @estado , es_electronico = @es_electronico  where id_negocio = @id_negocio and id_local  = @id_local and  id_comprobante = @id_comprobante and serie = @serie"
                        command.Parameters.Clear()
                        command.Parameters.AddWithValue("@id_negocio", Val(dt_Tablas_basicas.Rows(i).Cells("id_negocio").Value))
                        command.Parameters.AddWithValue("@id_local", Val(dt_Tablas_basicas.Rows(i).Cells("id_local").Value))
                        command.Parameters.AddWithValue("@id_comprobante", Val(dt_Tablas_basicas.Rows(i).Cells("id_comprobante").Value))
                        command.Parameters.AddWithValue("@serie", dt_Tablas_basicas.Rows(i).Cells("serie").Value.ToString.Trim)
                        If dt_Tablas_basicas.Rows(i).Cells("es_inicial").Value Then
                            command.Parameters.AddWithValue("@es_inicial", 1)
                        Else
                            command.Parameters.AddWithValue("@es_inicial", 0)
                        End If
                        command.Parameters.AddWithValue("@num_inicial", Val(dt_Tablas_basicas.Rows(i).Cells("num_inicial").Value))
                        command.Parameters.AddWithValue("@num_final", Val(dt_Tablas_basicas.Rows(i).Cells("num_final").Value))
                        command.Parameters.AddWithValue("@orden", Val(dt_Tablas_basicas.Rows(i).Cells("orden").Value))
                        If dt_Tablas_basicas.Rows(i).Cells("estado").Value Then
                            command.Parameters.AddWithValue("@estado", 1)
                        Else
                            command.Parameters.AddWithValue("@estado", 0)
                        End If
                        If dt_Tablas_basicas.Rows(i).Cells("es_fe").Value Then
                            command.Parameters.AddWithValue("@es_electronico", 1)
                        Else
                            command.Parameters.AddWithValue("@es_electronico", 0)
                        End If
                        command.ExecuteNonQuery()
                    Catch ex As Exception
                        Result = MensajesBox.Show("No Actualizo , Intentar Nuevamente " & dt_Tablas_basicas.Rows(i).Cells("serie").ToString & " ?", "Series.")
                        Exit Sub
                    End Try
                End If
            End If

        Next
        Result = MensajesBox.Show("Se Realizo la Actualizacion de Registros de las Series  ", "Series.")


    End Sub

    Private Sub dt_Tablas_basicas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dt_Tablas_basicas.EditingControlShowing
        ' Verifica si la celda actual es de la columna "serie"
        If dt_Tablas_basicas.CurrentCell.ColumnIndex = dt_Tablas_basicas.Columns("serie").Index Then
            ' Agrega un controlador de eventos para el evento KeyPress del control de edición
            AddHandler e.Control.KeyPress, AddressOf serieTextBox_KeyPress
        Else
            ' Elimina el controlador de eventos para el evento KeyPress del control de edición
            RemoveHandler e.Control.KeyPress, AddressOf serieTextBox_KeyPress
        End If
    End Sub
    Private Sub serieTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Convierte el carácter ingresado a mayúsculas
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub
    Private Sub dt_Tablas_basicas_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dt_Tablas_basicas.CellValueChanged
        ' Verifica si la celda modificada es de la columna "serie"
        If dt_Tablas_basicas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then Exit Sub
        If e.ColumnIndex = dt_Tablas_basicas.Columns("serie").Index Then
            ' Convierte el valor de la celda a mayúsculas
            dt_Tablas_basicas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = dt_Tablas_basicas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString().ToUpper()
        End If
    End Sub

    Private Sub dt_Tablas_basicas_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dt_Tablas_basicas.CellValidating
        ' Verifica si la celda actual es de la columna "serie"
        If e.ColumnIndex = dt_Tablas_basicas.Columns("serie").Index Then
            Dim serieIngresada As String = e.FormattedValue.ToString().ToUpper()

            ' Verifica si la serie ingresada ya existe en otra fila del DataGridView
            For Each row As DataGridViewRow In dt_Tablas_basicas.Rows
                If row.Index <> e.RowIndex Then ' Excluye la fila actual
                    Dim serieExistente As String = row.Cells("serie").Value.ToString().ToUpper()

                    If serieIngresada = serieExistente Then
                        ' La serie ingresada ya existe en otra fila, muestra un mensaje de error
                        Dim Result As String = MensajesBox.Show("Serie ya Existe en el comprobante.", "Series.")
                        'dt_Tablas_basicas.Rows(e.RowIndex).ErrorText = "La serie ingresada ya existe en otra fila"
                        dt_Tablas_basicas.Rows(e.RowIndex).Cells("serie").Value = "" ' Limpia la celda ingresada
                        e.Cancel = True ' Cancela la validación y evita que se mueva a otra celda
                        Exit Sub
                    End If
                End If
            Next

            ' Si no se encontró una serie duplicada, se limpia el mensaje de error
            dt_Tablas_basicas.Rows(e.RowIndex).ErrorText = ""
        End If
    End Sub

    Private Sub CmdActImp_Click(sender As Object, e As EventArgs) Handles CmdActImp.Click
        Dim wid_negocio As Integer
        Dim wid_local As Integer
        Dim wcodigo As Integer
        Dim wvalorimp As Double
        Dim wdescri As String
        Dim westado As Integer
        Dim werror As String = ""
        Dim Wresultado As String = ""


        Lbl_local.Text = lk_NegocioActivo.nombre.ToString.Trim & " \ " & Seleccion_id_local ' & " - " & lk_LocalActivo.nombre

        wid_negocio = Seleccion_id_Negocio
        wid_local = Seleccion_id_local
        wcodigo = 1
        wvalorimp = Val(TxtVal_imp.Text)
        wdescri = TxtEti_imp.Text.Trim
        westado = 1





        Using command As New SqlCommand("sp_insertar_imp", lk_connection_cuenta)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Clear()
            ' Agrega los parámetros de entrada
            command.Parameters.AddWithValue("@id_negocio", wid_negocio)
            command.Parameters.AddWithValue("@id_local", wid_local)
            command.Parameters.AddWithValue("@codigo", wcodigo)
            command.Parameters.AddWithValue("@valorimp", wvalorimp)
            command.Parameters.AddWithValue("@descri", wdescri)
            command.Parameters.AddWithValue("@estado", westado)
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
        End Using
        If werror <> String.Empty Then ' ERROR DE SQL
            MsgBox(werror)
        End If
        If Wresultado <> String.Empty Then
            Dim Result = MensajesBox.Show("Se Realizo la actualizacion",
                                     "impuestos.")

            Dim sql_cade As String
            Dim command As SqlCommand
            Dim adaptador As SqlDataAdapter
            sql_cade = "select  id_local , codigo, vporc, descripcion from impuesto_mae where id_negocio = " & lk_NegocioActivo.id_Negocio & "  and estado = 1 "
            lk_sql_impuesto_mae = New DataTable()
            Command = New SqlCommand(sql_cade, lk_connection_cuenta)
            adaptador = New SqlDataAdapter(Command)
            adaptador.Fill(lk_sql_impuesto_mae)

        End If

    End Sub
End Class