Imports System.Runtime.InteropServices
Imports CrystalDecisions.CrystalReports.Engine
Imports ZXing
Imports ZXing.QrCode
Imports System.Drawing
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Drawing.Printing

Public Class FrmFormatosCR
    Public Property DataSeleccion As New DataTable
    Public Property LOC_NOMBRE_IMPRESORA As String
    Public Property LOC_ID_FORMATO As Integer
    Public Property LOC_ID_DESTINO As Integer
    Public Property LOC_NOMBRE_ARCHIVO As String
    Public Property LOC_COPIAS As Integer
    Public Property ES_CIERRE_FORMATO As Integer



    Public Property TituloInforme As String
    Private Sub FrmFormatosCR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)


        LblTituloInfo.Text = TituloInforme
        MuestraComprobanteFiltro()


    End Sub

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


    Public Function GenerarCodigoQR(data As String) As Image
        Dim writer As New BarcodeWriter()
        writer.Format = BarcodeFormat.QR_CODE
        Dim options As New QrCodeEncodingOptions()
        options.DisableECI = True
        options.CharacterSet = "UTF-8"
        options.Width = 300 ' Tamaño de la imagen del código QR
        options.Height = 300
        writer.Options = options

        Dim qrCodeBitmap As Bitmap = writer.Write(data)
        Return qrCodeBitmap
    End Function



    Private Sub MuestraComprobanteFiltro()

        Dim wtextoqr As String = lk_NegocioActivo.numdoc

        If DataSeleccion.Rows.Count > 0 Then
            wtextoqr = wtextoqr & " - " & Format(DataSeleccion.Rows(0).Item("fecha"), "dd/MM/yyyy") & " " & Trim(DataSeleccion.Rows(0).Item("comp_descrip")) & " " & Trim(DataSeleccion.Rows(0).Item("serie_comp")) & " - " & Trim(DataSeleccion.Rows(0).Item("numero_comp"))

        End If

        Dim codigoQR As Image = GenerarCodigoQR(wtextoqr)  ' Generar el código QR
        Dim stream As New MemoryStream()
        codigoQR.Save(stream, System.Drawing.Imaging.ImageFormat.Png)
        Dim bytesImagen As Byte() = stream.ToArray()

        Dim wlogo As Image = Image.FromFile(lk_NegocioActivo.fotonegocio)
        Dim streamlogo As New MemoryStream()
        wlogo.Save(streamlogo, System.Drawing.Imaging.ImageFormat.Png)
        Dim byteslogo As Byte() = streamlogo.ToArray()

        Dim wmonto As Double = 0
        Dim wid_moneda As Integer = 0



        ' Asignar la imagen al campo de imagen en el informe

        Dim DataTableNeg As New DataTable
        DataTableNeg.Columns.Add("id_Negocio", GetType(Int32))
        DataTableNeg.Columns.Add("nombre", GetType(String))
        DataTableNeg.Columns.Add("direccion", GetType(String))

        DataTableNeg.Columns.Add("todo_ubigeo", GetType(String))
        DataTableNeg.Columns.Add("nombre_local", GetType(String))
        DataTableNeg.Columns.Add("telefonos_local", GetType(String))
        DataTableNeg.Columns.Add("correo_local", GetType(String))

        DataTableNeg.Columns.Add("tipodoc", GetType(String))
        DataTableNeg.Columns.Add("numdoc", GetType(String))
        DataTableNeg.Columns.Add("qr", GetType(Byte()))
        DataTableNeg.Columns.Add("logo", GetType(Byte()))
        DataTableNeg.Columns.Add("total_letras", GetType(String))


        If DataSeleccion.Rows.Count > 0 Then
            wmonto = DataSeleccion.Rows(0).Item("total")
            wid_moneda = 1 'DataSeleccion.Rows(0).Item("id_moneda")
        End If

        If LOC_NOMBRE_ARCHIVO = "" Then Exit Sub


        Dim addrow As DataRow = DataTableNeg.NewRow()

        addrow.Item("id_negocio") = lk_NegocioActivo.id_Negocio
        addrow.Item("nombre") = lk_NegocioActivo.nombre
        addrow.Item("direccion") = lk_NegocioActivo.direccion
        addrow.Item("tipodoc") = lk_NegocioActivo.tipodoc
        addrow.Item("numdoc") = lk_NegocioActivo.numdoc
        addrow.Item("qr") = bytesImagen
        addrow.Item("logo") = byteslogo


        Dim wtotalletras As String = ConvertirMontoALetras(wmonto, wid_moneda)
        addrow.Item("total_letras") = wtotalletras

        DataTableNeg.Rows.Add(addrow)



        Dim dataSet As New DataSet_formatos() ' Reemplaza "DataSet_formatos" con el nombre real de tu DataSet
        dataSet.dt_Comprobante.Merge(DataSeleccion)
        dataSet.Negocio.Merge(DataTableNeg)

        'LK_RUTA_RPT = "H:\Fuentes\ORI\SistemaComercialOri\WindowsApp1\FormatosCrystal\"
        'reporte.Load("H:\ReportesOri\CR_Formatos.rpt")
        ' Asignar el informe al control de Crystal Report Viewer

        Dim reporte As New ReportDocument()
        reporte.Load(LK_RUTA_RPT + LOC_NOMBRE_ARCHIVO)
        ' Asignar el DataTable al informe
        reporte.SetDataSource(dataSet)

        '-- por pantalla
        ' Public Property LOC_NOMBRE_IMPRESORA As String
        ES_CIERRE_FORMATO = 0

        If LOC_ID_DESTINO = 1 Then  ' NO IMPRMIR
            Me.Visible = True
        ElseIf LOC_ID_DESTINO = 2 Then ' IMPRESORA
            ' Configurar el número de copias en el informe
            reporte.PrintOptions.PrinterName = LOC_NOMBRE_IMPRESORA ' Reemplaza con el nombre de tu impresora
            reporte.PrintToPrinter(LOC_COPIAS, False, 0, 0) ' 1 copia, sin diálogo de impresión
            ES_CIERRE_FORMATO = 1

        ElseIf LOC_ID_DESTINO = 3 Then ' PANTALLA
            Vista_formatoCR.ShowGroupTreeButton = False
            Vista_formatoCR.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Vista_formatoCR.ReportSource = reporte
            Me.Visible = True
        ElseIf LOC_ID_DESTINO = 4 Then '  PDF
            ' Permitir al usuario seleccionar la ubicación y el nombre del archivo PDF.
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf"
            saveFileDialog.Title = "Guardar Informe PDF"
            saveFileDialog.FileName = "formatoOri.pdf" ' Nombre de archivo predeterminado

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                ' Exportar el informe a la ubicación seleccionada por el usuario en formato PDF.
                reporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, saveFileDialog.FileName)
                ' Notificar al usuario que el informe se ha guardado correctamente.
                MessageBox.Show("El informe se ha guardado correctamente en " & saveFileDialog.FileName, "Informe Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ES_CIERRE_FORMATO = 1
        End If




        '**** original
        'Dim dataSet As New DataSet_formatos() ' Reemplaza "DataSet_formatos" con el nombre real de tu DataSet
        'dataSet.dt_Comprobante.Merge(DataSeleccion)
        'dataSet.Negocio.Merge(DataTableNeg)
        'Dim reporte As New ReportDocument()
        'reporte.Load("H:\Fuentes\ORI\SistemaComercialOri\WindowsApp1\FormatosCrystal\CR_Formatos.rpt") ' Reemplaza "ruta_al_informe.rpt" con la ruta real de tu informe
        '' Asignar el DataTable al informe
        'reporte.SetDataSource(dataSet)
        '' Asignar el informe al control de Crystal Report Viewer
        'Vista_formatoCR.ShowGroupTreeButton = False
        'Vista_formatoCR.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        'Vista_formatoCR.ReportSource = reporte
    End Sub

    Private Sub PanelSup_Paint_1()

    End Sub
End Class