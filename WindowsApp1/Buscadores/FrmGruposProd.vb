Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports documentManager.CapaDatos
Imports documentManager.Clases
Imports documentManager.Entidades
Public Class FrmGruposProd
    Dim local_sql_listaGrupos As DataTable
    Public Property CODIGO_GRUPO As String
    Public Property ID_PROD As Integer
    Public Property ID_ITEM_GRUPO As Integer
    Public Property ID_DESCRIP_GRUPO As String





    Private Sub FrmGruposProd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        GridGrupos.Dock = DockStyle.Fill
        Obtiene_Grupo(CODIGO_GRUPO)



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


    Public Sub Obtiene_Grupo(id_codigo As String)
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        sql_cade = "select id_tbp_id , descripcion , abreviado , estado  from prod_tablas_estru_items where id_tbp_estru_id = " & id_codigo & " and estado = 1  order by orden "
        local_sql_listaGrupos = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_master)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(local_sql_listaGrupos)
        SN_Cabecera_Grupos()
        GridGrupos.Rows.Clear()

        For i = 0 To local_sql_listaGrupos.Rows.Count - 1
            GridGrupos.Rows.Add()
            GridGrupos.Rows(GridGrupos.Rows.Count - 1).Cells("num").Value = i + 1
            GridGrupos.Rows(GridGrupos.Rows.Count - 1).Cells("descripcion").Value = local_sql_listaGrupos.Rows(i).Item("descripcion").ToString.Trim
            GridGrupos.Rows(GridGrupos.Rows.Count - 1).Cells("abreviado").Value = local_sql_listaGrupos.Rows(i).Item("abreviado").ToString.Trim
            GridGrupos.Rows(GridGrupos.Rows.Count - 1).Cells("id_tbp_id").Value = local_sql_listaGrupos.Rows(i).Item("id_tbp_id")
        Next i


    End Sub
    Private Sub SN_Cabecera_Grupos()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()


        GridGrupos.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        GridGrupos.Columns.Clear()
        GridGrupos.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)

        textoColumn.Name = "num"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridGrupos.Columns.Add(textoColumn)
        GridGrupos.Columns.Item(textoColumn.Name).Width = 25
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        GridGrupos.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "descripcion"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "DESCRIPCION"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridGrupos.Columns.Add(textoColumn)
        GridGrupos.Columns.Item(textoColumn.Name).Width = 250
        GridGrupos.Columns.Item(textoColumn.Name).ReadOnly = True
        GridGrupos.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "abreviado"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "ABREVIADO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridGrupos.Columns.Add(textoColumn)
        GridGrupos.Columns.Item(textoColumn.Name).Width = 50
        GridGrupos.Columns.Item(textoColumn.Name).ReadOnly = True
        GridGrupos.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_tbp_id"
        textoColumn.HeaderText = "id_tbp_id"
        GridGrupos.Columns.Add(textoColumn)
        GridGrupos.Columns.Item(textoColumn.Name).Width = 0
        GridGrupos.Columns.Item(textoColumn.Name).Visible = False




    End Sub

    Private Sub CmdAddItem_Click(sender As Object, e As EventArgs) Handles CmdAddItem.Click
        ID_ITEM_GRUPO = GridGrupos.Rows(GridGrupos.CurrentCell.RowIndex).Cells("id_tbp_id").Value
        ID_DESCRIP_GRUPO = GridGrupos.Rows(GridGrupos.CurrentCell.RowIndex).Cells("descripcion").Value
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class