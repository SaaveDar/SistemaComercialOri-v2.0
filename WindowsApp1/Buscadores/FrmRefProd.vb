Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class FrmRefProd
    Public Property REF_NOMBRE_PRODUCTO As String
    Public Property REF_CONTENIDO As String
    Public Property REF_ESTADO As String

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

    Private Sub FrmRefProd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LblNombreProd.Text = REF_NOMBRE_PRODUCTO
        t_ref_prod.Text = REF_CONTENIDO
        t_ref_prod.Select() ' Selecciona todo el texto en la caja de texto.
        t_ref_prod.SelectionStart = t_ref_prod.Text.Length ' 
        If REF_ESTADO = "bloq" Then
            t_ref_prod.ReadOnly = True
        Else
            t_ref_prod.ReadOnly = False
        End If



    End Sub



    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click

        REF_CONTENIDO = t_ref_prod.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub t_ref_prod_TextChanged(sender As Object, e As EventArgs) Handles t_ref_prod.TextChanged

    End Sub

    Private Sub CmdCancelar_Click(sender As Object, e As EventArgs) Handles CmdCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub t_ref_prod_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t_ref_prod.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub
End Class