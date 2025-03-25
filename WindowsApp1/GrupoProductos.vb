Imports System.Runtime.InteropServices
Imports Newtonsoft.Json

Imports System.Data.SqlClient
Imports System.Windows.Documents
Imports Microsoft.VisualBasic.Logging


Public Class GrupoProductos

    Public Property local_dt_FiltroGrupos As New DataTable()

    'Public Property local_dt_FiltroGrupos As DataTable


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

    Private Sub CmdMin_Click(sender As Object, e As EventArgs) Handles CmdMin.Click
        WindowState = FormWindowState.Minimized
        Me.Text = ""
        Me.ControlBox = True
    End Sub


    Private Sub Muestra_ItemGrupos(ws_ListaItem As ListBox, ws_TxtEtiqueta As Label)
        Dim frBuscar As New FrmGruposProd
        Dim ws_ID_ITEM_GRUPO As Integer = 0
        Dim ws_ID_DESCRI_GRUPO As String = ""
        frBuscar.LblEtiqueta.Text = Trim(ws_TxtEtiqueta.Text)
        frBuscar.LblEtiqueta.Tag = Trim(ws_TxtEtiqueta.Tag)
        Dim tamaño As Rectangle = My.Computer.Screen.Bounds

        'frBuscar.Left = (Me.Left) + 220
        'frBuscar.Top = (Me.Top) + 120
        frBuscar.CODIGO_GRUPO = frBuscar.LblEtiqueta.Tag
        frBuscar.ID_PROD = 0
        frBuscar.ID_ITEM_GRUPO = 0
        frBuscar.ID_DESCRIP_GRUPO = ""

        ' Mostrar el formulario para seleccionar un grupo
        If frBuscar.ShowDialog() = DialogResult.OK Then
            ws_ID_ITEM_GRUPO = Val(frBuscar.ID_ITEM_GRUPO)
            ws_ID_DESCRI_GRUPO = frBuscar.ID_DESCRIP_GRUPO

            ' Verificar si el elemento ya existe en el ListBox
            Dim existe As Boolean = False
            For i As Integer = 0 To ws_ListaItem.Items.Count - 1
                ' Cambiar la condición para verificar si el item completo existe
                If ws_ListaItem.Items(i).ToString().Contains(ws_ID_DESCRI_GRUPO & Space(100) & ws_ID_ITEM_GRUPO) Then
                    existe = True
                    Exit For
                End If
            Next

            If existe Then
                ' Mostrar mensaje si ya existe
                Dim result = MensajesBox.Show("El item ya existe en la lista, por favor verifica.", lk_cabeza_msgbox)
            Else
                ' Agregar el nuevo item al ListBox
                ws_ListaItem.Items.Add(ws_ID_DESCRI_GRUPO & Space(100) & ws_ID_ITEM_GRUPO)
            End If
        End If
    End Sub

    'Private Sub Muestra_ItemGrupos(ws_ListaItem As ListBox, ws_TxtEtiqueta As Label)
    '    Dim frBuscar As New FrmGruposProd
    '    Dim ws_ID_ITEM_GRUPO As Integer = 0
    '    Dim ws_ID_DESCRI_GRUPO As String = ""
    '    frBuscar.LblEtiqueta.Text = Trim(ws_TxtEtiqueta.Text)
    '    frBuscar.LblEtiqueta.Tag = Trim(ws_TxtEtiqueta.Tag)
    '    Dim tamaño As Rectangle = My.Computer.Screen.Bounds

    '    'frBuscar.Left = (Me.Left) + 220
    '    'frBuscar.Top = (Me.Top) + 120
    '    frBuscar.CODIGO_GRUPO = frBuscar.LblEtiqueta.Tag
    '    frBuscar.ID_PROD = 0
    '    frBuscar.ID_ITEM_GRUPO = 0
    '    frBuscar.ID_DESCRIP_GRUPO = ""

    '    'frBuscar.ShowDialog() sigue  inactivo esta linea


    '    If frBuscar.ShowDialog() = DialogResult.OK Then
    '        ws_ID_ITEM_GRUPO = Val(frBuscar.ID_ITEM_GRUPO)
    '        ws_ID_DESCRI_GRUPO = frBuscar.ID_DESCRIP_GRUPO
    '        Dim wflag_add As Integer = 0
    '        For i = 0 To ws_ListaItem.Items.Count - 1
    '            If Trim(Strings.Right(ws_ListaItem.Items(i).ToString, 10)) = ws_ID_ITEM_GRUPO Then
    '                wflag_add = 1
    '                Exit For
    '            End If
    '        Next i
    '        If wflag_add = 1 Then
    '            Dim result = MensajesBox.Show("Existe en la Lista , verificar.", lk_cabeza_msgbox)
    '        Else

    '            ws_ListaItem.Items.Add(ws_ID_DESCRI_GRUPO & Space(100) & ws_ID_ITEM_GRUPO)
    '        End If
    '    End If

    'End Sub

    Private Sub Quitar_ItemGrupos(ws_ListaItem As ListBox, ws_fila As Integer)

        If ws_fila < 0 Then
            Dim resultms = MensajesBox.Show("Debe Seleccionar de la lista ", lk_cabeza_msgbox)
            Exit Sub
        End If
        Dim ws_ID_ITEM_GRUPO As Integer = 0
        Dim ws_ID_DESCRI_GRUPO As String = ""
        Dim tamaño As Rectangle = My.Computer.Screen.Bounds

        'frBuscar.Left = (Me.Left) + 220

        Dim wflag_add As Integer = 0
        If ws_ListaItem.Items(ws_fila) Is Nothing Then Exit Sub

        Dim wdescriquitar As String = ws_ListaItem.Items(ws_fila).ToString()

        Dim Result As String '= MensajesBox.Show("Confirmar Si desea Quitar el Registro : continuar?" & vbCrLf & wdescriquitar, "Quitar de la lista", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If Result = "7" Or Result = "2" Then ' es NO
        Else
            ws_ListaItem.Items.RemoveAt(ws_fila)
        End If

    End Sub


    Private Sub Cmd_add10_Click(sender As Object, e As EventArgs) Handles Cmd_add10.Click
        Muestra_ItemGrupos(ListTipo10, LblTipo10)
    End Sub


    'Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click

    '    local_dt_FiltroGrupos.Columns.Clear()
    '    local_dt_FiltroGrupos.Columns.Add("descripcion", GetType(String))
    '    local_dt_FiltroGrupos.Columns.Add("id_tipo_prod", GetType(Integer))
    '    local_dt_FiltroGrupos.Columns.Add("id_tbp_estru_id", GetType(Integer))
    '    local_dt_FiltroGrupos.Columns.Add("id_tbp_id", GetType(Integer))
    '    local_dt_FiltroGrupos.Rows.Clear()
    '    llena_registroGrupo(ListTipo10, 10, 1)
    '    llena_registroGrupo(ListTipo20, 20, 1)
    '    llena_registroGrupo(ListTipo30, 30, 1)
    '    llena_registroGrupo(ListTipo40, 40, 1)
    '    llena_registroGrupo(ListTipo50, 50, 1)
    '    llena_registroGrupo(ListTipo60, 60, 1)
    '    llena_registroGrupo(ListTipo70, 70, 1)
    '    llena_registroGrupo(ListTipo80, 80, 1)
    '    llena_registroGrupo(ListTipo90, 90, 1)
    '    llena_registroGrupo(ListTipo100, 100, 1)

    '    ' EnviarDatosATablaTemporal()
    '    Me.DialogResult = DialogResult.OK
    '    Me.Close()
    '    ' MsgBox(local_dt_FiltroGrupos.Rows.Count) ' para testear los registro del datatable en el listbox
    '    Dim it As Integer
    '    For it = 0 To local_dt_FiltroGrupos.Rows.Count - 1
    '        MsgBox(local_dt_FiltroGrupos.Rows(it).Item("descripcion") & " " & local_dt_FiltroGrupos.Rows(it).Item("id_tipo_prod") & " " &
    '               local_dt_FiltroGrupos.Rows(it).Item("id_tbp_estru_id") & " " & local_dt_FiltroGrupos.Rows(it).Item("id_tbp_id") & " ")
    '    Next it
    'End Sub

    ' Método para llenar o actualizar los registros en el DataTable
    'Private Sub llena_registroGrupo(listag As ListBox, wid_tbp_estru_id As Integer, wid_tipo_prod As Integer)
    '    Dim wdescripcion As String = ""
    '    Dim wid_tbp_id As Integer

    '    For i = 0 To listag.Items.Count - 1
    '        ' Obtener el id_tbp_id del item del ListBox
    '        wid_tbp_id = Val(Trim(Strings.Right(listag.Items(i).ToString, 10)))
    '        wdescripcion = Trim(Strings.Left(listag.Items(i).ToString, 80))

    '        ' Solo guardar si el id_tbp_id es diferente de 0
    '        If wid_tbp_id <> 0 Then
    '            ' Verificar si el registro ya existe en el DataTable
    '            Dim rowExists As Boolean = False
    '            For Each row As DataRow In local_dt_FiltroGrupos.Rows
    '                ' Comparar si el registro ya existe en el DataTable
    '                If row("descripcion").ToString() = wdescripcion AndAlso CInt(row("id_tbp_estru_id")) = wid_tbp_estru_id AndAlso CInt(row("id_tbp_id")) = wid_tbp_id Then
    '                    rowExists = True
    '                    Exit For
    '                End If
    '            Next

    '            ' Si el registro no existe, se agrega al DataTable
    '            If Not rowExists Then
    '                local_dt_FiltroGrupos.Rows.Add(wdescripcion, wid_tipo_prod, wid_tbp_estru_id, wid_tbp_id)
    '            End If
    '        End If
    '    Next i
    'End Sub


    'Private Sub llena_registroGrupo(listag As ListBox, wid_tbp_estru_id As Integer, wid_tipo_prod As Integer)

    '    Dim wdescripcion As String = ""

    '    Dim wid_tbp_id As Integer
    '    For i = 0 To listag.Items.Count - 1
    '        wid_tbp_id = Val((Strings.Right(listag.Items(i).ToString, 10)))
    '        wdescripcion = (Trim(Strings.Left(listag.Items(i).ToString, 80)))
    '        local_dt_FiltroGrupos.Rows.Add(wdescripcion, wid_tipo_prod, wid_tbp_estru_id, wid_tbp_id)


    '    Next i

    'End Sub

    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click
        ' Guardar los registros desde los ListBox si no están duplicados
        local_dt_FiltroGrupos.Rows.Clear()
        guarda_registroGrupo(ListTipo10, 10, 1)
        guarda_registroGrupo(ListTipo20, 20, 1)
        guarda_registroGrupo(ListTipo30, 30, 1)
        guarda_registroGrupo(ListTipo40, 40, 1)
        guarda_registroGrupo(ListTipo50, 50, 1)
        guarda_registroGrupo(ListTipo60, 60, 1)
        guarda_registroGrupo(ListTipo70, 70, 1)
        guarda_registroGrupo(ListTipo80, 80, 1)
        guarda_registroGrupo(ListTipo90, 90, 1)
        guarda_registroGrupo(ListTipo100, 100, 1)

        ' Cerrar el formulario
        Me.DialogResult = DialogResult.OK
        Me.Close()

        'MsgBox(local_dt_FiltroGrupos.Rows.Count) ' para testear los registro del datatable en el listbox
        'Dim it As Integer
        'For it = 0 To local_dt_FiltroGrupos.Rows.Count - 1
        '    MsgBox(local_dt_FiltroGrupos.Rows(it).Item("descripcion") & " " & local_dt_FiltroGrupos.Rows(it).Item("id_tipo_prod") & " " &
        '           local_dt_FiltroGrupos.Rows(it).Item("id_tbp_estru_id") & " " & local_dt_FiltroGrupos.Rows(it).Item("id_tbp_id") & " ")
        '    '    Stop
        'Next it
    End Sub

    ' Método para guardar registros en el DataTable desde el ListBox sin duplicar
    Private Sub guarda_registroGrupo(listag As ListBox, wid_tbp_estru_id As Integer, wid_tipo_prod As Integer)
        Dim wdescripcion As String = ""
        Dim wid_tbp_id As Integer

        For i = 0 To listag.Items.Count - 1
            ' Obtener el id_tbp_id del item del ListBox
            wid_tbp_id = Val(Trim(Strings.Right(listag.Items(i).ToString, 10)))
            wdescripcion = Trim(Strings.Left(listag.Items(i).ToString, 80))

            ' Solo guardar si el id_tbp_id es diferente de 0
            'If wid_tipo_prod <> 0 Then 'wid_tbp_id <> 0 Then
            ' Verificar si el registro ya existe en el DataTable
            Dim rowExists As Boolean = False
                For Each row As DataRow In local_dt_FiltroGrupos.Rows
                    ' Comparar si el registro ya existe en el DataTable
                    If row("descripcion").ToString() = wdescripcion AndAlso CInt(row("id_tbp_estru_id")) = wid_tbp_estru_id AndAlso CInt(row("id_tbp_id")) = wid_tbp_id Then
                        rowExists = True
                        Exit For
                    End If
                Next

                ' Si el registro no existe, se agrega al DataTable
                If Not rowExists Then
                    local_dt_FiltroGrupos.Rows.Add(wdescripcion, wid_tipo_prod, wid_tbp_estru_id, wid_tbp_id)
                End If
            'End If
        Next i
    End Sub

    ' Evento Load para cargar los datos previamente guardados en los ListBox
    Private Sub GrupoProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Verifica si hay datos en el DataTable
        If local_dt_FiltroGrupos IsNot Nothing AndAlso local_dt_FiltroGrupos.Rows.Count > 0 Then
            ' Cargar los datos en los ListBox desde el DataTable
            CargarListBox(ListTipo10, 10)
            CargarListBox(ListTipo20, 20)
            CargarListBox(ListTipo30, 30)
            CargarListBox(ListTipo40, 40)
            CargarListBox(ListTipo50, 50)
            CargarListBox(ListTipo60, 60)
            CargarListBox(ListTipo70, 70)
            CargarListBox(ListTipo80, 80)
            CargarListBox(ListTipo90, 90)
            CargarListBox(ListTipo100, 100)
        End If
    End Sub

    ' Método para cargar los datos en el ListBox según id_tbp_estru_id
    Private Sub CargarListBox(listag As ListBox, wid_tbp_estru_id As Integer)
        listag.Items.Clear()

        For Each row As DataRow In local_dt_FiltroGrupos.Rows
            ' Verificar que id_tbp_estru_id coincida
            If Not IsDBNull(row("id_tbp_estru_id")) AndAlso CInt(row("id_tbp_estru_id")) = wid_tbp_estru_id Then
                ' Agregar la descripción al ListBox sin el id_tbp_id (solo mostrar la descripción)
                listag.Items.Add(row("descripcion").ToString() & Space(100) & row("id_tbp_id").ToString())
            End If
        Next
    End Sub


    Private Sub CmdCancelarOper_Click(sender As Object, e As EventArgs) Handles CmdCancelarOper.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Cmd_Quitar10_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar10.Click
        Quitar_ItemGrupos(ListTipo10, ListTipo10.SelectedIndex)
    End Sub


    Private Sub Cmd_add20_Click(sender As Object, e As EventArgs) Handles Cmd_add20.Click
        Muestra_ItemGrupos(ListTipo20, LblTipo20)
    End Sub

    Private Sub Cmd_Quitar20_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar20.Click
        Quitar_ItemGrupos(ListTipo20, ListTipo20.SelectedIndex)
    End Sub

    Private Sub Cmd_add30_Click(sender As Object, e As EventArgs) Handles Cmd_add30.Click
        Muestra_ItemGrupos(ListTipo30, LblTipo30)
    End Sub

    Private Sub Cmd_Quitar30_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar30.Click
        Quitar_ItemGrupos(ListTipo30, ListTipo30.SelectedIndex)
    End Sub

    Private Sub Cmd_add40_Click(sender As Object, e As EventArgs) Handles Cmd_add40.Click
        Muestra_ItemGrupos(ListTipo40, LblTipo40)
    End Sub

    Private Sub Cmd_Quitar40_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar40.Click
        Quitar_ItemGrupos(ListTipo40, ListTipo40.SelectedIndex)
    End Sub

    Private Sub Cmd_add50_Click(sender As Object, e As EventArgs) Handles Cmd_add50.Click
        Muestra_ItemGrupos(ListTipo50, LblTipo50)
    End Sub

    Private Sub Cmd_Quitar50_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar50.Click
        Quitar_ItemGrupos(ListTipo50, ListTipo50.SelectedIndex)
    End Sub

    Private Sub Cmd_add60_Click(sender As Object, e As EventArgs) Handles Cmd_add60.Click
        Muestra_ItemGrupos(ListTipo60, LblTipo60)
    End Sub

    Private Sub Cmd_Quitar60_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar60.Click
        Quitar_ItemGrupos(ListTipo60, ListTipo60.SelectedIndex)
    End Sub

    Private Sub Cmd_add70_Click(sender As Object, e As EventArgs) Handles Cmd_add70.Click
        Muestra_ItemGrupos(ListTipo70, LblTipo70)
    End Sub

    Private Sub Cmd_Quitar70_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar70.Click
        Quitar_ItemGrupos(ListTipo70, ListTipo70.SelectedIndex)
    End Sub

    Private Sub Cmd_add80_Click(sender As Object, e As EventArgs) Handles Cmd_add80.Click
        Muestra_ItemGrupos(ListTipo80, LblTipo80)
    End Sub

    Private Sub Cmd_Quitar80_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar80.Click
        Quitar_ItemGrupos(ListTipo80, ListTipo80.SelectedIndex)
    End Sub

    Private Sub Cmd_add90_Click(sender As Object, e As EventArgs) Handles Cmd_add90.Click
        Muestra_ItemGrupos(ListTipo90, LblTipo90)
    End Sub

    Private Sub Cmd_Quitar90_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar90.Click
        Quitar_ItemGrupos(ListTipo90, ListTipo90.SelectedIndex)
    End Sub

    Private Sub Cmd_add100_Click(sender As Object, e As EventArgs) Handles Cmd_add100.Click
        Muestra_ItemGrupos(ListTipo100, LblTipo100)
    End Sub

    Private Sub Cmd_Quitar100_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar100.Click
        Quitar_ItemGrupos(ListTipo100, ListTipo100.SelectedIndex)
    End Sub

    Private Sub PanelProductos_Paint(sender As Object, e As PaintEventArgs) Handles PanelProductos.Paint

    End Sub
End Class