Imports System.Data.SqlClient
Imports System.Net
Imports System.Runtime.InteropServices
Imports FontAwesome.Sharp
Imports Newtonsoft.Json
Imports WindowsApp1.BuscaUsuarios

Public Class FrmBuscaUsuarios
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
        Me.Hide()
    End Sub



    Private Sub CmdBuscar_Click(sender As Object, e As EventArgs) Handles CmdBuscar.Click
        BuscaUsuario()
    End Sub
    Dim WithEvents CLIENTE As New WebClient 'LO 
    Private Sub BuscaUsuario()

        DGUser.Tag = 0

        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter


        command = New SqlCommand("u_buscar_usuario", lk_connection_master)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@id_usuario", lk_id_usuario)
        command.Parameters.AddWithValue("@id_cuenta_user", lk_id_cuemta_user)
        command.Parameters.AddWithValue("@nombre", TxtBuscaUser.Text)

        adapter = New SqlDataAdapter(command)
        lk_sql_BuscaUsuarios = New DataTable
        adapter.Fill(lk_sql_BuscaUsuarios)

        If lk_sql_BuscaUsuarios.Rows.Count = 0 Then
            Exit Sub
        End If








        Try
            DGUser.Rows.Clear()

            If lk_sql_BuscaUsuarios.Rows.Count <> 0 Then

                DGUser.Columns(0).Width = 80
                DGUser.Columns(1).Width = 100
                DGUser.Columns(2).Width = 100
                DGUser.Columns(3).Width = 50
                DGUser.Columns(4).Width = 80
                DGUser.Columns(5).Width = 80
                DGUser.Columns(6).Width = 50
                DGUser.Columns(7).Width = 60

                DGUser.Columns(2).Visible = True

                For I = 0 To lk_sql_BuscaUsuarios.Rows.Count - 1
                    DGUser.Rows.Add()
                    DGUser.Rows(DGUser.Rows.Count - 1).Cells(0).Value = lk_sql_BuscaUsuarios.Rows(I).Item("usuario").ToString.ToUpper
                    DGUser.Rows(DGUser.Rows.Count - 1).Cells(1).Value = lk_sql_BuscaUsuarios.Rows(I).Item("nombres")
                    DGUser.Rows(DGUser.Rows.Count - 1).Cells(2).Value = lk_sql_BuscaUsuarios.Rows(I).Item("apellidos")
                    DGUser.Rows(DGUser.Rows.Count - 1).Cells(3).Value = lk_sql_BuscaUsuarios.Rows(I).Item("descripcion")
                    DGUser.Rows(DGUser.Rows.Count - 1).Cells(4).Value = lk_sql_BuscaUsuarios.Rows(I).Item("numero_doc")
                    DGUser.Rows(DGUser.Rows.Count - 1).Cells(5).Value = "***" & Strings.Right(lk_sql_BuscaUsuarios.Rows(I).Item("celular"), 3)
                    DGUser.Rows(DGUser.Rows.Count - 1).Cells(6).Value = "-"
                    If lk_sql_BuscaUsuarios.Rows(I).Item("ya_asignado") = "1" Then
                        DGUser.Rows(DGUser.Rows.Count - 1).Cells(7).Value = "Registrado"
                    Else
                        DGUser.Rows(DGUser.Rows.Count - 1).Cells(7).Value = ""
                    End If


                    DGUser.Rows(DGUser.Rows.Count - 1).Cells(8).Value = lk_sql_BuscaUsuarios.Rows(I).Item("id_usuario")
                    DGUser.Rows(DGUser.Rows.Count - 1).Cells(9).Value = I
                    DGUser.Rows(DGUser.Rows.Count - 1).Height = 30



                Next


            End If
        Catch ex As Exception
            MsgBox("ERRO Usuarios ")
            Exit Sub
        End Try



    End Sub

    Private Sub TxtBuscaUser_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscaUser.TextChanged

    End Sub

    Private Sub TxtBuscaUser_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBuscaUser.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscaUsuario()
        End If
    End Sub

    Private Sub CmdAtras_Click(sender As Object, e As EventArgs) Handles CmdAtras.Click
        Me.Hide()
    End Sub

    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click
        If DGUser.Rows.Count = 0 Then
            Exit Sub
        End If
        DGUser.Tag = DGUser.Rows(DGUser.CurrentRow.Index).Cells(9).Value ' pasa la posicion de lk_api_BuscaUsuarios.data(I).id_usuario para scar los datos del usaurio
        Me.Hide()
    End Sub

    Private Sub FrmBuscaUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGUser.Tag = ""
    End Sub
End Class