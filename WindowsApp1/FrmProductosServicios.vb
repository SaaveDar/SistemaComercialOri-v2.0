Public Class FrmProductosServicios
    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Dim frmpadre As FrmMenuProductos = CType(Owner, FrmMenuProductos)

        frmpadre.IDGRILLA.Text = DGTabla.CurrentRow.Cells(0).Value.ToString()
        Me.Close()

        '  Dim frm As FormAgenda = CType(Owner, FormAgenda)
        ' frm.txtid.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        'frm.txtnombre.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString() + ", " + DataGridView1.CurrentRow.Cells(2).Value.ToString()
        'Me.Close()



    End Sub

    Private Sub FrmProductosServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox(TxtBuscaProducto.Tag)
        CmbBuscar.IconChar = FontAwesome.Sharp.IconChar.Search
        PanelMuestra.Dock = System.Windows.Forms.DockStyle.Fill
        PanelDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        PanelMuestra.Visible = True
        PanelDetalle.Visible = False





        'DataGridView1
        DGTabla.Visible = False
        For J = 1 To 3500
            DGTabla.Rows.Add()
            DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = J
            DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "ACEITE LA BOTIJA EXTRA VIRGEN LTA X 150ML  " & J & "CODI"
            DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "PORTUGAL"
            DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "CAP"
            DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
            DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
            DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
            DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
            DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
            DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        Next J

        '  DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(2).Value = "texto3"
        DGTabla.Rows.Add()
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = "123"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "ACEITE YONSON ORIGINAL X 50ML"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "PORTUGAL"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "CAP"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        DGTabla.Rows.Add()
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = "5466"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "JABON LIQUIDO PARA MANOS DOVE X 250ML                                                                "
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "BAYER"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "UND"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        DGTabla.Rows.Add()
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = "767"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "KLARIPHARMA 250MG/5ML X 50 ML                                                                        "
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "MARKOL"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "UND"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        DGTabla.Rows.Add()
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = "454"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "CREMA DEPILATORIA LA CCOPER 100G                                                                     "
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "PORTUGAL"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "CAJ"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        DGTabla.Rows.Add()
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = "3434"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "DESENREDANTE SPRAY YONSON X 200ML                                                                    "
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "PORTUGAL"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "FCO"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        DGTabla.Rows.Add()
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = "547"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "PANTOCALM 40 MG TAB                                                                                  "
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "PORTUGAL"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "CAPSULA"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        DGTabla.Rows.Add()
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = "3244"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "MYSTOL 200MCG TAB. X 30                                                                              "
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "PORTUGAL"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "CAPSULA"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        DGTabla.Rows.Add()
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = "35542"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "ACEITE LA BOTIJA EXTRA VIRGEN LTA X 150ML  "
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "PORTUGAL"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "CAPSULA"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        DGTabla.Rows.Add()
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = "25547614"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "DESODOR. NIVEA SPRAY FEM 150ML+NIVEA CUIDADO NUTR                                                    "
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "PORTUGAL"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "CAPSULA"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        DGTabla.Rows.Add()
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = "345345"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "COLLAR PARA HOMBRE ESIKA                                                                             "
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "PORTUGAL"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "CAPSULA"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        DGTabla.Rows.Add()
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = "2656514"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "ESPARADRAPO MICROPOROSO BENDI-C 2.5 X 2 Y                                                           "
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "PORTUGAL"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "CAPSULA"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        DGTabla.Rows.Add()
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = "978"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "ACEITE LA BOTIJA EXTRA VIRGEN LTA X 150ML  "
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "PORTUGAL"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "UND"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        DGTabla.Rows.Add()
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = "258975"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "ASSA-81  TAB.                                                                                        "
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "PORTUGAL"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "QUIMIZA"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        DGTabla.Rows.Add()
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(0).Value = "467"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(1).Value = "DENTITO ENJUAGUE BUCAL X 250 ML KIDS                                                                "
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(2).Value = "QUIMICA"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(3).Value = "CAJ"
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(4).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(5).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(6).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(7).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(8).Value = ""
        DGTabla.Rows(DGTabla.Rows.Count - 1).Cells(9).Value = ""
        DGTabla.Visible = True


    End Sub




    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        e.Handled = True
    End Sub

    Private Sub grid_Muestra_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTabla.CellContentClick


    End Sub

    Private Sub grid_Muestra_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTabla.CellDoubleClick
        PanelMuestra.Visible = False
        PanelDetalle.Visible = True
    End Sub

    Private Sub CmdAceptarDetalle_Click(sender As Object, e As EventArgs) Handles CmdAceptarDetalle.Click
        PanelMuestra.Visible = True
        PanelDetalle.Visible = False

    End Sub

    Private Sub TxtBuscaProducto_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscaProducto.TextChanged
        'this is your string
        Dim strMyString As String = "aaSomethingbb"

        'if your string contains these strings
        Dim TargetString1 As String = "Something"
        Dim TargetString2 As String = "Something2"

        'If strMyString.IndexOf(TargetString1) <> -1 Or strMyString.IndexOf(TargetString2) <> -1 Then

        'End If
        ' 
        '      Pasamos el texto a mayúscula para evitar diferencias
        ':::Por uso de minúsculas y mayúsculas


        '  Ahi va una mejora, busca en cualquier parte de celda

        '':::Try Capturador de errores
        'Try
        '    Dim DGTabla2 As DataGridView
        '    DGTabla2 = DGTabla
        '    ':::Nos permite recorrer las filas del DGTabla
        '    For Each Row As DataGridViewRow In DGTabla2.Rows
        '        ':::Nos permite recorrer las celdas del DGTabla
        '        For Each Cell As DataGridViewCell In Row.Cells
        '            ':::Validamos el registro del DGTabla contra el criterio de busqueda
        '            'MsgBox(Cell.Value.ToString)
        '            'If Cell.Value.ToString = txtFindDataGrid.Text Then
        '            ' ‘:::Nos ubicamos en la celda que contiene el registro encontrado
        '            ' DGTabla.CurrentCell = Cell
        '            'End If

        '            'BUSCA TEXTO EN CUALQUIER PARTE DE LA CELDA
        '            If InStr(Cell.Value.ToString, Trim(TxtBuscaProducto.Text), CompareMethod.Text) > 0 Then
        '                DGTabla2.CurrentCell = Cell
        '            End If

        '        Next
        '    Next
        'Try Catch ex As Exception
        '    MsgBox(“No se puede realizar la búsqueda por: ” & ex.Message)
        'End Try



        'Dim TextoUsuario As String = UCase(TxtBuscar.Text)

        '':::Realizar búsqueda por una columna con el ciclo For Each
        'For Each Row As DataGridViewRow In DGTabla.Rows
        '    ':::Pasamos a mayúscula el campo del DataGridView
        '    ':::Observa que indico en el valor "Cells" que se realizara la búsqueda
        '    ':::En la columna "Apellidos"
        '    Dim TextoDG As String = UCase(Row.Cells("Apellido").Value.ToString)

        '    If TextoDG = TextoUsuario Then
        '        DGTabla.CurrentCell = Row.Cells("Apellido")
        '        Row.Selected = True
        '        Exit For
        '    End If
        'Next



        '':::Try Capturador de errores
        'Try
        '    ':::Nos permite recorrer las filas del DGTabla
        '    For Each Row As DataGridViewRow In DGTabla.Rows
        '        ':::Nos permite recorrer las celdas del DGTabla
        '        For Each Cell As DataGridViewCell In Row.Cells
        '            ':::Validamos el registro del DGTabla contra el criterio de busqueda
        '            'If Cell.Value.ToString.IndexOf(TxtBuscaProducto.Text) <> -1 Then
        '            'If Cell.Value.ToString.IndexOf(TxtBuscaProducto.Text) <> -1 Then
        '            'If Cell.Value.ToString = TxtBuscaProducto.Text Then
        '            ':::Nos ubicamos en la celda que contiene el registro encontrado
        '            MsgBox(Cell.Value.ToString)
        '            'DGTabla.CurrentCell = Cell
        '            'End If
        '        Next
        '    Next
        'Catch ex As Exception
        '    MsgBox("No se puede realizar la búsqueda por: " & ex.Message)
        'End Try



        If BuscarLINQ(Trim(TxtBuscaProducto.Text), "Codigo", DGTabla) Then
            MsgBox("ENCONTRO")
        End If



        '' FUNCIONA 1 
        'If TxtBuscaProducto.Text <> "" Then

        '    For Each Fila As DataGridViewRow In DGTabla.Rows
        '        If Not Fila Is Nothing Then
        '            For Each Celda As DataGridViewCell In Fila.Cells

        '                If InStr(Celda.Value.ToString, Trim(TxtBuscaProducto.Text), CompareMethod.Text) > 0 Then
        '                    ' Fila.Visible = True
        '                    DGTabla.CurrentCell = Celda
        '                End If

        '                'If Celda.ToString().ToUpper().IndexOf(TxtBuscaProducto.Text.ToUpper()) <> -1 Then
        '                ' Fila.Visible = True
        '                ' ' Exit For
        '                'End If

        '            Next


        '        End If
        '    Next
        'Else
        '    For Each Fila As DataGridViewRow In DGTabla.Rows
        '        Fila.Visible = True
        '    Next
        'End If



        'If TxtBuscaProducto.Text <> "" Then
        '    For Each Fila As DataGridViewRow In grid_Muestra.Rows
        '        Fila.Visible = False
        '    Next

        '    For Each Fila As DataGridViewRow In grid_Muestra.Rows
        '        If Not Fila Is Nothing Then

        '            For Each Celda As DataGridViewCell In Fila.Cells
        '                If Celda.ToString().ToUpper().IndexOf(TxtBuscaProducto.Text.ToUpper()) <> -1 Then
        '                    Fila.Visible = True
        '                    Exit For
        '                End If

        '            Next


        '        End If
        '    Next
        'Else
        '    For Each Fila As DataGridViewRow In grid_Muestra.Rows
        '        Fila.Visible = True
        '    Next
        'End If


        ''If TxtBuscaProducto.Text <> "" Then
        ''    For Each Fila As DataGridViewRow In grid_Muestra.Rows
        ''        Fila.Visible = False
        ''    Next


        ''    For Each Celda As DataGridViewCell In Fila.Cells
        ''        'Código a ejecutar. Ejemplo
        ''        If Celda.ToString().ToUpper().IndexOf(TxtBuscaProducto.Text.ToUpper()) = 0 Then
        ''            Fila.Visible = False
        ''            Exit For
        '        End If
        '    Next

        'Else
        '    For Each Fila As DataGridViewRow In grid_Muestra.Rows
        '        Fila.Visible = True
        '    Next
        'End If


        'For Each Fila As DataGridViewRow In DataGridView1.Rows
        '    If Not Fila Is Nothing Then
        '        '-- Puedes usar el método 1 ---'
        '        For Each Celda As DataGridViewCell In Fila.Cells
        '            'Código a ejecutar. Ejemplo
        '            Textbox1.Text = Celda.Value
        '        Next

        '        '--- O puedes usar el método 2 ---'
        '        For Each Columna As DataGridViewColumn In DataGridView1.Columns
        '            'Código a ejecutar. Ejemplo
        '            Textbox1.Text = Registro.Cells(Columna.Name).Value
        '        Next
        '    End If
        ' Next


        'For Each Celda As DataGridViewCell In Fila.Cells
        '    'Código a ejecutar. Ejemplo
        '    Textbox1.Text = Celda.Value
        'Next



    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult = MensajesBox.Show("debe ingresar un usaurio para acceder")

        Exit Sub
        For Each Row As DataGridViewRow In DGTabla.Rows
            ':::Nos permite recorrer las celdas del DGTabla
            'For j = 0 To DGTabla.Columns.Count - 1
            For Each Cell As DataGridViewCell In Row.Cells
                ':::Validamos el registro del DGTabla contra el criterio de busqueda
                'MsgBox(Cell.Value.ToString)
                'If Cell.Value.ToString = txtFindDataGrid.Text Then
                ' ‘:::Nos ubicamos en la celda que contiene el registro encontrado
                ' DGTabla.CurrentCell = Cell
                'End If
                'DGTabla.CellBorderStyle()

                If Cell.ColumnIndex >= DGTabla.Columns.Count - 3 Then Exit For 'por que la ultima es imagen jajajaja todo un dia por que

                'MsgBox(Cell.Value.ToString)
                'BUSCA TEXTO EN CUALQUIER PARTE DE LA CELDA
                If InStr(Cell.Value.ToString, Trim(TxtBuscaProducto.Text), CompareMethod.Text) > 0 Then
                    DGTabla.CurrentCell = Cell
                End If

            Next
        Next


    End Sub

    Private Sub PanelMuestra_Paint(sender As Object, e As PaintEventArgs) Handles PanelMuestra.Paint

    End Sub
    Function BuscarLINQ(ByVal TextoABuscar As String, ByVal Columna As String, ByRef grid As DataGridView) As Boolean
        Dim encontrado As Boolean = False
        'TextoABuscar = "'%" & TextoABuscar & "%'"
        If TextoABuscar = String.Empty Then Return False
        If grid.RowCount = 0 Then Return False
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
                                                         Where row.Cells(Columna).Value.ToString().IndexOf(TextoABuscar) = 0
                                                         Select row

            If obj.Any() Then
                grid.Rows(obj.FirstOrDefault().Index).Selected = True
                grid.CurrentCell = grid.Rows(obj.FirstOrDefault().Index).Cells(0)
            End If

        End If
        Return encontrado
    End Function

    Private Sub PanelSup_Paint(sender As Object, e As PaintEventArgs) Handles PanelSup.Paint

    End Sub

    Private Sub DGTabla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTabla.CellClick
        'TxtBuscaProducto.Select(TxtBuscaProducto.Text.Length, 0)
        'TxtBuscaProducto.Focus()

    End Sub

    Private Sub CmdMin_Click(sender As Object, e As EventArgs) Handles CmdMin.Click

    End Sub

    Private Sub CmbBuscar_Click(sender As Object, e As EventArgs) Handles CmbBuscar.Click

    End Sub
End Class