Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class FrmBuscadores
    Dim dt_estructura_prod As New DataTable
    Dim dataTableFiltrado As New DataTable
    Dim MostrarSelloAgua As Border3DSide
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
    Private Sub FrmBuscadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MuestraBuscador(LblEtiqueta.Tag, 1, "")


        'Select Case LblEtiqueta.Tag
        '    Case "F1"
        '        ' Código a ejecutar si miVariable es igual a 1
        '    Case "F2"
        '        ' Código a ejecutar si miVariable es igual a 2
        '    Case Else
        '        ' exit sub
        'End Select
    End Sub

    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub MuestraBuscador(WcodigoEstru As String, wTipoBusqueda As Integer, Wdescrip As String)
        'lk_sql_estructura_prod
        Dim rowsFiltradas() As DataRow
        dataTableFiltrado = lk_sql_estructura_prod.Clone()
        If wTipoBusqueda = 1 Then
            rowsFiltradas = lk_sql_estructura_prod.Select("id_tbp_estru_id = " & WcodigoEstru)
        Else
            rowsFiltradas = lk_sql_estructura_prod.Select(" id_tbp_estru_id = " & WcodigoEstru & " and  descripcion like '%" & Wdescrip & "%'")
            'Dim rowsFiltradas() As DataRow = lk_sql_estructura_prod.Select("id_tbp_estru_id = " & WcodigoEstru)
        End If
        For Each row As DataRow In rowsFiltradas
            dataTableFiltrado.ImportRow(row)
        Next
        DataGridResul.DataSource = dataTableFiltrado
        IniciaCabeceraBusqueda()

    End Sub

    Private Sub IniciaCabeceraBusqueda()

        With DataGridResul.Columns

            .Item("descripcion").Visible = True
            .Item("descripcion").Width = 200
            .Item("masdetalle").Visible = True
            .Item("masdetalle").Width = 300
            .Item("id_tbp_estru_id").Visible = False
            .Item("id_tbp_id").Visible = False

            Dim imageColumn As New DataGridViewImageColumn()
            imageColumn.HeaderText = "Imagen"
            imageColumn.Name = "imagen"
            imageColumn.HeaderText = "Ver"
            imageColumn.Image = My.Resources.ver
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
            DataGridResul.Columns.Add(imageColumn)
            .Item("imagen").Width = 30
        End With
    End Sub




    Private Sub DataGridResul_Paint(sender As Object, e As PaintEventArgs) Handles DataGridResul.Paint
        If MostrarSelloAgua Then
            Dim watermarkText As String = "Buscando..."
            Dim font As New Font("Arial", 16, FontStyle.Italic)
            Dim brush As New SolidBrush(Color.FromArgb(255, System.Drawing.ColorTranslator.FromHtml(strColorAzul)))
            Dim stringSize As SizeF = e.Graphics.MeasureString(watermarkText, font)
            Dim x As Single = (DataGridResul.Width - stringSize.Width) / 2
            Dim y As Single = (DataGridResul.Height - stringSize.Height) / 2
            Dim watermarkPoint As New PointF(x, y)
            e.Graphics.DrawString(watermarkText, font, brush, watermarkPoint)
        End If
    End Sub

    Private Sub TxtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtBuscar.KeyDown

        If e.KeyCode = 27 Then
            Me.Close()
        End If


        If BuscarKeyDown(TxtBuscar, DataGridResul, e) Then
            ' carga_datosGrid(0, DataGridResul)
        End If
        'MuestraInfo_Prod(DataGridResul)
        If e.KeyCode = Keys.Enter Then
            '    'carga_datosGrid(0, DataGridResul)
        End If
    End Sub

    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscar.TextChanged
        Dim valorresul As Integer
        Dim wsTextoBusca As String
        Dim colbusca As String = "descripcion"
        Dim WCODIGO As Integer
        If TxtBuscar.Text = "" Then
            DataGridResul.DataSource = Nothing
            DataGridResul.Columns.Clear()
            DataGridResul.Rows.Clear()
            MostrarSelloAgua = True
            DataGridResul.Refresh()
            MuestraBuscador(LblEtiqueta.Tag, 1, "")
            MostrarSelloAgua = False
            DataGridResul.Refresh()
            'DataGridResul.DataSource = Nothing
            'DataGridResul.Columns.Clear()
            'DataGridResul.Rows.Clear()
            'DataGridResul.Refresh()
            ''TxtBox1.Text = ""
            ''TxtBox2.Text = ""
            ''LblProductoTit.Text = ""
            ''CmbPres.Items.Clear()
        End If
        WCODIGO = 1
        wsTextoBusca = ""
        If Strings.Left(TxtBuscar.Text, 1) = "*" Then
            Dim numCaracteres As Integer = TxtBuscar.Text.ToCharArray().Where(Function(c) c = "*").Count()
            If numCaracteres > 2 Then Exit Sub   ' USUARIO DIGITA MAS DE 2 ASTERISCOS
            If Strings.Left(TxtBuscar.Text, 1) = "*" And Strings.Right(TxtBuscar.Text, 1) = "*" And Len(TxtBuscar.Text) > 2 Then
                wsTextoBusca = Mid(TxtBuscar.Text, 2, Len(TxtBuscar.Text) - 2)
            End If ''

            WCODIGO = 2
        ElseIf Len(Trim(TxtBuscar.Text)) = 3 Then
            wsTextoBusca = TxtBuscar.Text
            WCODIGO = 1
        End If

        '      
        If True Then ' DAtos para Socio de NEgoci

            If wsTextoBusca <> "" Then

                DataGridResul.DataSource = Nothing
                DataGridResul.Columns.Clear()
                DataGridResul.Rows.Clear()
                MostrarSelloAgua = True
                DataGridResul.Refresh()
                MuestraBuscador(LblEtiqueta.Tag, WCODIGO, wsTextoBusca)
                MostrarSelloAgua = False
                DataGridResul.Refresh()
            End If

            valorresul = Busca_TextChanged(TxtBuscar, DataGridResul, colbusca, ayuda)


            If valorresul = 1 Then ' encuentra 
                ' Ir a encontrado
                '  MuestraInfo_Prod(DataGridResul)

            ElseIf valorresul = 2 Then ' Inicializa Data 
                ' Funcionar de iniciarlzar 
                'DataGridResul.DataSource = Nothing
                'DataGridResul.Columns.Clear()
                'DataGridResul.Rows.Clear()
                If DataGridResul.CurrentCell IsNot Nothing Then
                    If DataGridResul.Rows.Count > 0 Then
                        DataGridResul.CurrentCell = DataGridResul.Rows(0).Cells(0)
                    End If
                End If
            ElseIf valorresul = 3 Then ' No cuentra
                ' Sin Exito Busqueda
            End If


        End If
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click


        'Dim frPermisoUsuarios As New ModeloBase3
        'PlaySonidoMouse(lk_CodigoSonido)
        '' 'frPermisoUsuarios.Width = 950
        '' frPermisoUsuarios.Top = Me.Top - 20
        ''  frPermisoUsuarios.Left = Me.Left - 20

        'frPermisoUsuarios.ShowDialog()
    End Sub
End Class