Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Runtime.InteropServices
Imports FontAwesome.Sharp
Imports System.ComponentModel
Imports WindowsApp1.clsJson

Public Class FrmMenuProductos
    Private Sub PanelSup_Paint(sender As Object, e As PaintEventArgs) Handles PanelSup.Paint

    End Sub

    Private Sub PanelSup_Resize(sender As Object, e As EventArgs) Handles PanelSup.Resize
        Me.Text = ""
        Me.ControlBox = False
    End Sub
#Region "MOVER EL FORMUALRIO CON EL PANEL SUPERIOR"
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
#End Region
    Private Sub ModeloBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.icologo
        PanelMenu.Dock = DockStyle.Right
        PanelPropios.Top = 34
        PanelImportar.Top = 34
        PanelSup.Height = 80

        PanelMenu.Visible = True
        PanelMenuImportar.Dock = DockStyle.Right
        PanelMenuImportar.Visible = False
        CmdCrear.IconChar = FontAwesome.Sharp.IconChar.PlusCircle
        CmdCancelar.IconChar = FontAwesome.Sharp.IconChar.Undo
        CmdCerrarMenu.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        CmdBuscar.IconChar = FontAwesome.Sharp.IconChar.Search


        CmdImportarCancelar.IconChar = FontAwesome.Sharp.IconChar.Undo
        CmdImportarImportar.IconChar = FontAwesome.Sharp.IconChar.CloudDownloadAlt
        CmdImportarCerrar.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        PanelDetalle.Dock = DockStyle.Fill




    End Sub

    Private Sub RadioDatoPropio_CheckedChanged(sender As Object, e As EventArgs) Handles RadioDatoPropio.CheckedChanged
        If RadioDatoPropio.Checked Then
            PanelPropios.Visible = True
            PanelImportar.Visible = False
            PanelMenu.Visible = True
            PanelMenuImportar.Visible = False
        Else
            PanelPropios.Visible = False
            PanelImportar.Visible = True
            PanelMenu.Visible = False
            PanelMenuImportar.Visible = True
        End If

    End Sub

    Private Sub RadioDatoImportar_CheckedChanged(sender As Object, e As EventArgs) Handles RadioDatoImportar.CheckedChanged

    End Sub

    Private Sub CmbBuscar_Click(sender As Object, e As EventArgs) Handles CmbBuscar.Click
        Dim Formulario As Form
        Formulario = PanelDetalle.Controls.OfType(Of FrmProductosServicios)().FirstOrDefault()
        If Formulario Is Nothing Then
            Dim frBuscaProducto As New FrmProductosServicios
            frBuscaProducto.TxtBuscaProducto.Tag = 45454
            AddOwnedForm(frBuscaProducto)
            frBuscaProducto.TopLevel = False
            PanelDetalle.Controls.Add(frBuscaProducto)

            frBuscaProducto.WindowState = FormWindowState.Maximized
            frBuscaProducto.Show()
        Else
            Formulario.BringToFront()
        End If
    End Sub

    Private Sub PanelDetalle_Paint(sender As Object, e As PaintEventArgs) Handles PanelDetalle.Paint

    End Sub

    Private Sub PanelDetalle_Click(sender As Object, e As EventArgs) Handles PanelDetalle.Click
        MsgBox(Me.PanelDetalle.Tag)
    End Sub

    Private Sub DGTabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTabla.CellContentClick

    End Sub

    Private Sub CmdBuscar_Click(sender As Object, e As EventArgs) Handles CmdBuscar.Click
        Dim Formulario As Form
        Formulario = PanelDetalle.Controls.OfType(Of FrmProductosServicios)().FirstOrDefault()
        If Formulario Is Nothing Then
        Else
            Formulario.Close()
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub


    Private Sub PanelBusca_Leave(sender As Object, e As EventArgs) Handles PanelBusca.Leave

    End Sub

    Private Sub PanelBusca_LostFocus(sender As Object, e As EventArgs) Handles PanelBusca.LostFocus
        PanelBusca.Visible = False
    End Sub

    Private Sub IconButton3_Click(sender As Object, e As EventArgs) Handles IconButton3.Click
        'If vps_Usaurios Is Nothing Then

        '    Dim parametro = New List(Of Parametro) From {
        '    New Parametro("id", "1")}

        '    Dim response = MuestraDataApi("https://backend-dev.favorit.pe/api/prueba/getInfo", parametro) ' respuesta : vps_Usaurios

        '    vps_Usaurios = JsonConvert.DeserializeObject(Of JsonRespuesta)(response) 'Cái truyền tên Class vào


        '    DataUsuarios.DataSource = vps_Usaurios.data
        '    ' DataUsuarios.Sort(DataUsuarios.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        '    'DataUsuarios.Sort(DataUsuarios.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        '    MsgBox(DataUsuarios.Rows.Count - 1)

        'Else
        '    DataUsuarios.DataSource = Nothing
        '    DataUsuarios.DataSource = vps_Usaurios.data
        '    'DataUsuarios.Sort(DataUsuarios.Columns(2), System.ComponentModel.ListSortDirection.Ascending)


        ' End If

        'Dim direction As ListSortDirection
        'direction = ListSortDirection.Descending
        'Dim Data As IBindingListView
        ''If (Me.DataUsuarios.GetType) Is GetType(BindingSource) Then
        'Data = New BindingSource(DataUsuarios, "")
        ''Data = CType(DataUsuarios, BindingSource)
        'DataUsuarios.Sort(DataUsuarios.Columns(0), ListSortDirection.Ascending)

        ''Data.RemoveSort()
        'Else
        '    Data = New BindingSource(Me.DataSource, Me.DataMember)
        'End If
        'Data.RemoveSort()





        'DataUsuarios.Sort(DataUsuarios.Columns(0), ListSortDirection.Ascending)








        ' PanelBusca
    End Sub

    Private Sub Busca_Laboratorio(MuestraPanel As Panel, DGdatos As DataGridView, Txtbusca As TextBox)


    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        BuscarDG_TextChanged(TextBox2.Text, "nombre", DataUsuarios)
    End Sub
End Class