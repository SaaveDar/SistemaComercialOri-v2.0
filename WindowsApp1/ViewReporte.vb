Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices

Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions
Public Class ViewReporte

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
        'WindowState = FormWindowState.Minimized
        'Me.Text = ""
        'Me.ControlBox = True

        ' Simular minimización: Ajustar tamaño y ubicación en la parte inferior izquierda del panel
        Me.WindowState = FormWindowState.Normal  ' Asegurarse de que no esté minimizado en la barra de tareas

        ' Cambiar el tamaño del formulario para simular minimización
        Me.Height = 50  ' Ajustar la altura para que parezca minimizado (puedes ajustar este valor)
        Me.Width = 200  ' Ajustar el ancho del formulario (ajústalo según el diseño que prefieras)

        ' Colocar el formulario en la parte inferior izquierda del panel
        Me.Top = Me.Parent.ClientSize.Height - Me.Height  ' Poner en la parte inferior
        Me.Left = 0  ' Alinear a la izquierda
        CmdMin.Visible = False

    End Sub

    Private Sub CmdRestaurar_Click(sender As Object, e As EventArgs) Handles CmdRestaurar.Click

        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
            CmdMin.Visible = True
        Else
            WindowState = FormWindowState.Normal
            CmdMin.Visible = True
        End If

    End Sub

    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    ' Método para recibir el reporte desde Form1
    Public Sub SetReporte(ByVal reporte As Object)
        ' Asignar el reporte al CrystalReportViewer de Form2
        cr_reporte2.ReportSource = reporte
    End Sub

    ' Método para recibir el nombre del nodo seleccionado del TreeView
    Public Sub SetTreeViewLabel(ByVal nombreNodo As String)
        ' Asignar el texto al Label
        lbtitulo2.Text = nombreNodo
    End Sub


    Private Sub ViewReporte_Load(sender As Object, e As EventArgs)


    End Sub



End Class