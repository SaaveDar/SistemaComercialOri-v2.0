Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices
'Imports System.Data.OleDb
Public Class FrmOper
    Dim fileExcel As New OpenFileDialog()
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

    Private Sub FrmOper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CERRAR_SESIONES()
        'ConexionSQL_Maester()
        'ConexionSQL_Cuentas()




        cab_operaciones()
        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        Dim dt_tablas_basicas As New DataTable
        Dim dt_tablas As New DataTable
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        CmbTipo.Items.Clear()
        CmbModulo.Items.Clear()

        command = New SqlCommand("select  id_tb , (codigo + ' ' + descripcion) descripcion  from tablas_basicas  where estado = 1 and id_tipotabla = 501 order by descripcion", lk_connection_master)
        adapter = New SqlDataAdapter(command)
        dt_tablas = New DataTable
        adapter.Fill(dt_tablas)
        CmbSub.Items.Clear()
        For i = 0 To dt_tablas.Rows.Count - 1
            CmbSub.Items.Add(dt_tablas.Rows(i).Item("descripcion").ToString & Space(80) & dt_tablas.Rows(i).Item("id_tb").ToString)
        Next i


        command = New SqlCommand("select  id_tb , (codigo + ' ' + descripcion) descripcion from tablas_basicas  where estado = 1 and id_tipotabla = 502 order by descripcion", lk_connection_master)
        adapter = New SqlDataAdapter(command)
        dt_tablas = New DataTable
        adapter.Fill(dt_tablas)

        For i = 0 To dt_tablas.Rows.Count - 1
            CmbTipo.Items.Add(dt_tablas.Rows(i).Item("descripcion").ToString & Space(80) & dt_tablas.Rows(i).Item("id_tb").ToString)
        Next i

        command = New SqlCommand("select  id_tb ,(codigo + ' ' + descripcion) descripcion  from tablas_basicas  where estado = 1 and id_tipotabla = 503 order by descripcion", lk_connection_master)
        adapter = New SqlDataAdapter(command)
        dt_tablas = New DataTable
        adapter.Fill(dt_tablas)

        For i = 0 To dt_tablas.Rows.Count - 1
            CmbModulo.Items.Add(dt_tablas.Rows(i).Item("descripcion").ToString & Space(80) & dt_tablas.Rows(i).Item("id_tb").ToString)
        Next i

        command = New SqlCommand("select  id_tb ,(codigo + ' ' + descripcion) descripcion  from tablas_basicas  where estado = 1 and id_tipotabla = 505 order by codigo", lk_connection_master)
        adapter = New SqlDataAdapter(command)
        dt_tablas = New DataTable
        adapter.Fill(dt_tablas)
        CmbBoxSALTO.Items.Clear()
        CmbBox.Items.Clear()
        For i = 0 To dt_tablas.Rows.Count - 1
            CmbBox.Items.Add(dt_tablas.Rows(i).Item("descripcion").ToString & Space(80) & dt_tablas.Rows(i).Item("id_tb").ToString)
            CmbBoxSALTO.Items.Add(dt_tablas.Rows(i).Item("descripcion").ToString & Space(80) & dt_tablas.Rows(i).Item("id_tb").ToString)

        Next i
        CmbBoxSALTO.Items.Add("FIN SALTO" & Space(80) & 0)




        command = New SqlCommand("SELECT  * FROM tablas_basicas_mae", lk_connection_master)
        adapter = New SqlDataAdapter(command)
        dt_tablas_basicas = New DataTable
        adapter.Fill(dt_tablas_basicas)
        CmbListaTabla.Items.Clear()
        For i = 0 To dt_tablas_basicas.Rows.Count - 1
            CmbListaTabla.Items.Add(Format(dt_tablas_basicas.Rows(i).Item("id_tipotabla"), "000") & " " & dt_tablas_basicas.Rows(i).Item("descripcion").ToString.Trim)
        Next i



    End Sub
    Private Sub cab_operaciones()
        dg_operaciones.Rows.Clear()
        dg_operaciones.Columns.Clear()

        With dg_operaciones.Columns
            .Add("id_Modulo", "Id_Modulo")
            .Item("id_Modulo").Width = 30

            .Add("descrip_modulo", "Descripcion Modulo")
            .Item("descrip_modulo").Width = 140

            .Add("id_suboper", "Id_SubOper")
            .Item("id_suboper").Width = 30

            .Add("descrip_suboper", "Descrip. SubOper")
            .Item("descrip_suboper").Width = 220

            .Add("id_tipo_oper", "Id_TipoOper")
            .Item("id_tipo_oper").Width = 30

            .Add("descrip_tipo_oper", "Descrip. TipóOper")
            .Item("descrip_tipo_oper").Width = 180

            .Add("estado_oper", "ESTADO")
            .Item("estado_oper").Width = 40

            .Add("id_oper_maestro", "id_oper_maestro")
            .Item("id_oper_maestro").Width = 50

            .Add("id_tb_oper", "id_tb_oper")
            .Item("id_tb_oper").Visible = False

        End With
        Dim imageColumn As New DataGridViewImageColumn()
        imageColumn.Name = "eliminar"
        imageColumn.HeaderText = "Quitar"
        imageColumn.Image = My.Resources.eliminar
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_operaciones.Columns.Add(imageColumn)
        dg_operaciones.Columns.Item("eliminar").Width = 35

    End Sub


    Private Sub cab_box_operaciones()
        dg_box_oper.Columns.Clear()

        With dg_box_oper.Columns
            .Add("descripcion", "descripcion")
            .Item("descripcion").Width = 120

            .Add("codigo_box", "codigo_box")
            .Item("codigo_box").Width = 40

            .Add("descrip_box", "descrip_box")
            .Item("descrip_box").Width = 120

            .Add("nro_ubica", "nro_ubica")
            .Item("nro_ubica").Width = 40

            .Add("orden", "orden")
            .Item("orden").Width = 40

            .Add("codigo_salta", "codigo_salta")
            .Item("codigo_salta").Width = 40

            .Add("descrip_salta", "descrip_salta")
            .Item("descrip_salta").Width = 120

            .Add("es_opcional", "es_opcional")
            .Item("es_opcional").Width = 40

            .Add("es_opcional_lote", "es_opcional_lote")
            .Item("es_opcional_lote").Width = 40

            .Add("es_condesc1", "es_condesc1")
            .Item("es_condesc1").Width = 40

            .Add("es_condesc2", "es_condesc2")
            .Item("es_condesc2").Width = 40

            .Add("id_oper_maestro", "id_oper_maestro")
            .Item("id_oper_maestro").Visible = False
            .Add("id_tb_estru_oper", "id_tb_estru_oper")
            .Item("id_tb_estru_oper").Visible = False
            .Add("id_tb_estru_oper_item", "id_tb_estru_oper_item")
            .Item("id_tb_estru_oper_item").Visible = False
            .Add("id_tb_box", "id_tb_box")
            .Item("id_tb_box").Visible = False


        End With
        Dim imageColumn As New DataGridViewImageColumn()
        imageColumn.Name = "eliminar"
        imageColumn.HeaderText = "Quitar"
        imageColumn.Image = My.Resources.eliminar
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_box_oper.Columns.Add(imageColumn)
        dg_box_oper.Columns.Item("eliminar").Width = 35

    End Sub

    Private Sub txtOper_TextChanged(sender As Object, e As EventArgs) Handles txtOper.TextChanged

    End Sub

    Private Sub txtOper_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOper.KeyPress
        Dim Result As String
        Dim dt_operaciones As New DataTable
        If e.KeyChar <> Chr(13) Then Exit Sub
        txtOper.Tag = ""
        lbloper.Text = ""

        Dim command As SqlCommand = New SqlCommand("select  * from tablas_basicas  where id_tipotabla = 500 and codigo = '" & txtOper.Text & "'", lk_connection_master)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        adapter.Fill(dt_operaciones)

        If dt_operaciones.Rows.Count = 0 Then
            Result = MensajesBox.Show("Codigo no Encontrado",
                                           "Operaciones")
            Exit Sub
        End If
        txtOper.Tag = dt_operaciones.Rows(0).Item("id_tb").ToString
        lbloper.Text = dt_operaciones.Rows(0).Item("descripcion").ToString
        id_operacion.Text = dt_operaciones.Rows(0).Item("id_tb").ToString
        Muestra_operaciones()
        Muestra_Box_operaciones()
    End Sub
    Private Sub Muestra_operaciones()


        Dim dt_operaciones As New DataTable
        cab_operaciones()
        dg_operaciones.Rows.Clear()
        Dim command As SqlCommand = New SqlCommand("select  * from vw_lista_oper  where id_tb_oper = '" & txtOper.Tag & "' order by descrip_suboper ,  descrip_tipooper ", lk_connection_master)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        adapter.Fill(dt_operaciones)
        If dt_operaciones.Rows.Count = 0 Then
            NotiAvisos(PanelNoti, LblNoti, "ADVERTENCIA", " No Exite Operaciones Definidas ", TimeNoti)
            ' ´' Result = MensajesBox.Show("NO Contiene lista",
            '                                 "Operaciones")
            Exit Sub
        End If


        For i = 0 To dt_operaciones.Rows.Count - 1
            dg_operaciones.Rows.Add()
            dg_operaciones.Rows(dg_operaciones.Rows.Count - 1).Cells("Id_Modulo").Value = dt_operaciones.Rows(i).Item("id_tb").ToString()
            dg_operaciones.Rows(dg_operaciones.Rows.Count - 1).Cells("descrip_modulo").Value = dt_operaciones.Rows(i).Item("descripcion").ToString()

            dg_operaciones.Rows(dg_operaciones.Rows.Count - 1).Cells("id_suboper").Value = dt_operaciones.Rows(i).Item("id_tb_suboper").ToString()
            dg_operaciones.Rows(dg_operaciones.Rows.Count - 1).Cells("descrip_suboper").Value = dt_operaciones.Rows(i).Item("descrip_suboper").ToString()

            dg_operaciones.Rows(dg_operaciones.Rows.Count - 1).Cells("id_tipo_oper").Value = dt_operaciones.Rows(i).Item("id_tb_tipooper").ToString()
            dg_operaciones.Rows(dg_operaciones.Rows.Count - 1).Cells("descrip_tipo_oper").Value = dt_operaciones.Rows(i).Item("descrip_tipooper").ToString()

            dg_operaciones.Rows(dg_operaciones.Rows.Count - 1).Cells("estado_oper").Value = dt_operaciones.Rows(i).Item("estado").ToString()
            dg_operaciones.Rows(dg_operaciones.Rows.Count - 1).Cells("id_oper_maestro").Value = dt_operaciones.Rows(i).Item("id_oper_maestro").ToString()
            dg_operaciones.Rows(dg_operaciones.Rows.Count - 1).Cells("id_tb_oper").Value = dt_operaciones.Rows(i).Item("id_tb_oper").ToString()



        Next i








    End Sub
    Private Sub Muestra_Box_operaciones()


        Dim dt_operaciones As New DataTable
        cab_box_operaciones()
        dg_box_oper.Rows.Clear()

        Dim command As SqlCommand = New SqlCommand("select  * from vw_lista_box where id_tb_oper =  '" & txtOper.Tag & "'  order by orden , descripcion ", lk_connection_master)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        adapter.Fill(dt_operaciones)
        If dt_operaciones.Rows.Count = 0 Then
            NotiAvisos(PanelNoti, LblNoti, "ADVERTENCIA", " No Exite Box para esta Operación.", TimeNoti)
            '  Result = MensajesBox.Show("NO Contiene lista",
            '                                "Operaciones")
            Exit Sub
        End If




        For i = 0 To dt_operaciones.Rows.Count - 1
            dg_box_oper.Rows.Add()
            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("descripcion").Value = dt_operaciones.Rows(i).Item("descripcion").ToString()
            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("codigo_box").Value = dt_operaciones.Rows(i).Item("codigo_box").ToString()

            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("descrip_box").Value = dt_operaciones.Rows(i).Item("descrip_box").ToString()
            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("nro_ubica").Value = dt_operaciones.Rows(i).Item("nro_ubica").ToString()

            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("orden").Value = dt_operaciones.Rows(i).Item("orden").ToString()
            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("codigo_salta").Value = dt_operaciones.Rows(i).Item("codigo_salta").ToString()

            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("es_opcional").Value = dt_operaciones.Rows(i).Item("es_opcional").ToString()
            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("es_opcional_lote").Value = dt_operaciones.Rows(i).Item("es_opcional_lote").ToString()
            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("es_condesc1").Value = dt_operaciones.Rows(i).Item("es_condesc1").ToString()
            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("es_condesc2").Value = dt_operaciones.Rows(i).Item("es_condesc2").ToString()


            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("descrip_salta").Value = dt_operaciones.Rows(i).Item("descrip_salta").ToString()
            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("id_oper_maestro").Value = dt_operaciones.Rows(i).Item("id_oper_maestro").ToString()
            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("id_tb_estru_oper").Value = dt_operaciones.Rows(i).Item("id_tb_estru_oper").ToString()
            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("id_tb_estru_oper_item").Value = dt_operaciones.Rows(i).Item("id_tb_estru_oper_item").ToString()
            dg_box_oper.Rows(dg_box_oper.Rows.Count - 1).Cells("id_tb_box").Value = dt_operaciones.Rows(i).Item("id_tb_box").ToString()


        Next i

        TxtUbica.Text = ""

    End Sub
    Private Sub CmdAddOper_Click(sender As Object, e As EventArgs) Handles CmdAddOper.Click
        Dim command As New SqlCommand()
        Dim wid_oper As Integer
        Dim adapter As SqlDataAdapter
        Dim dt_operaciones As New DataTable
        command.Connection = lk_connection_master


        If CmbSub.Text = "" Or CmbTipo.Text = "" Or CmbModulo.Text = "" Then
            NotiAvisos(PanelNoti, LblNoti, "ALERTA", "Definir: SubOper, Tipo o Modulo.", TimeNoti)
            Exit Sub
        End If
        command.CommandText = "SELECT count(id_tb_oper) as reg  FROM operaciones_mae  WHERE id_tb_oper = @id_tb_oper and id_tb_sub_oper =  @id_tb_sub_oper  and id_tb_tipo_oper = @id_tb_tipo_oper "
        command.Parameters.Clear()

        command.Parameters.AddWithValue("@id_tb_oper", txtOper.Tag)
        command.Parameters.AddWithValue("@id_tb_tipo_oper", Trim(Strings.Right(CmbTipo.Text, 10)))
        command.Parameters.AddWithValue("@id_tb_sub_oper", Trim(Strings.Right(CmbSub.Text, 10)))
        command.Parameters.AddWithValue("@id_tb_modulo", Trim(Strings.Right(CmbModulo.Text, 10)))

        wid_oper = 0
        adapter = New SqlDataAdapter(command)
        dt_operaciones = New DataTable
        adapter.Fill(dt_operaciones)
        wid_oper = dt_operaciones.Rows(0).Item("reg")
        If wid_oper > 0 Then
            NotiAvisos(PanelNoti, LblNoti, "ALERTA", "NO Procede, Ya Existe la Combinacion de datos.", TimeNoti)
            Exit Sub
        End If







        command.Transaction = lk_connection_master.BeginTransaction(IsolationLevel.Serializable)

        Try

            ' Insertar registro en tabla1

            command.CommandText = "SELECT (ISNULL(MAX(id_oper_maestro), 0) + 1) correla  FROM operaciones_mae  " ' WHERE id_tb_oper = @id_tb_oper and id_tb_sub_oper =  @id_tb_sub_oper  and id_tb_tipo_oper = @id_tb_tipo_oper "
            command.Parameters.Clear()
            'command.Parameters.AddWithValue("@id_tb_oper", txtOper.Tag)
            'command.Parameters.AddWithValue("@id_tb_tipo_oper", Trim(Strings.Right(CmbTipo.Text, 10)))
            'command.Parameters.AddWithValue("@id_tb_sub_oper", Trim(Strings.Right(CmbSub.Text, 10)))
            ' command.Parameters.AddWithValue("@id_tb_modulo", Trim(Strings.Right(CmbModulo.Text, 10)))
            wid_oper = 0
            adapter = New SqlDataAdapter(command)
            dt_operaciones = New DataTable
            adapter.Fill(dt_operaciones)
            wid_oper = dt_operaciones.Rows(0).Item("correla")

            command.CommandText = "INSERT INTO operaciones_mae VALUES (@id_oper_maestro, @id_tb_oper, @id_tb_sub_oper, @id_tb_tipo_oper,
            @id_tb_modulo, @estado , @es_inventario , @es_ceuntasn , @es_finanzas , @signo_inventario , @signo_cuentasn , @signo_finanzas,
            @id_tb_tipo_balance, @estado_oper_def, @tipo_transf_kardex, @es_costeo,@es_cospro,@es_control_lote,@es_listaprecio,
            @directo_id_tb_oper,@directo_id_oper_maestro,@fn_directo_id_tb_oper,@fn_directo_id_oper_maestro, @es_canje_comp,@es_reserva ,@es_prod_new,@es_canje_le,@es_aplica_nc,@es_bonificado) "

            command.Parameters.Clear()
            command.Parameters.AddWithValue("@id_oper_maestro", wid_oper)
            command.Parameters.AddWithValue("@id_tb_oper", Trim(txtOper.Tag))
            command.Parameters.AddWithValue("@id_tb_sub_oper", Trim(Strings.Right(CmbSub.Text, 10)))
            command.Parameters.AddWithValue("@id_tb_tipo_oper", Trim(Strings.Right(CmbTipo.Text, 10)))
            command.Parameters.AddWithValue("@id_tb_modulo", Trim(Strings.Right(CmbModulo.Text, 10)))
            command.Parameters.AddWithValue("@estado", 1)
            command.Parameters.AddWithValue("@es_inventario", 0)
            command.Parameters.AddWithValue("@es_ceuntasn", 0)
            command.Parameters.AddWithValue("@es_finanzas", 0)
            command.Parameters.AddWithValue("@signo_inventario", 0)
            command.Parameters.AddWithValue("@signo_cuentasn", 0)
            command.Parameters.AddWithValue("@signo_finanzas", 0)
            command.Parameters.AddWithValue("@id_tb_tipo_balance", 0)
            command.Parameters.AddWithValue("@estado_oper_def", 0)
            command.Parameters.AddWithValue("@tipo_transf_kardex", 0)
            command.Parameters.AddWithValue("@es_costeo", 0)
            command.Parameters.AddWithValue("@es_cospro", 0)
            command.Parameters.AddWithValue("@es_control_lote", 0)
            command.Parameters.AddWithValue("@es_listaprecio", 0)
            command.Parameters.AddWithValue("@directo_id_tb_oper", 0)
            command.Parameters.AddWithValue("@directo_id_oper_maestro", 0)
            command.Parameters.AddWithValue("@fn_directo_id_tb_oper", 0)
            command.Parameters.AddWithValue("@fn_directo_id_oper_maestro", 0)
            command.Parameters.AddWithValue("@es_canje_comp", 0)
            command.Parameters.AddWithValue("@es_reserva", 0)
            command.Parameters.AddWithValue("@es_prod_new", 0)
            command.Parameters.AddWithValue("@es_canje_le", 0)
            command.Parameters.AddWithValue("@es_aplica_nc", 0)
            command.Parameters.AddWithValue("@es_bonificado", 0)
            command.ExecuteNonQuery()

            '' Insertar registro en tabla2
            'command.CommandText = "INSERT INTO tabla2 (campo3, campo4) VALUES (@valor3, @valor4)"
            'command.Parameters.Clear()
            'command.Parameters.AddWithValue("@valor3", valor3)
            'command.Parameters.AddWithValue("@valor4", valor4)
            'command.ExecuteNonQuery()


            command.Transaction.Commit()
            NotiAvisos(PanelNoti, LblNoti, "EXITO", "REGISTRO CREADO CON EXITO", TimeNoti)
            Muestra_operaciones()
        Catch ex As Exception
            command.Transaction.Rollback()
            NotiAvisos(PanelNoti, LblNoti, "ALERTA", "ERROR INTERNO: " + ex.Message, TimeNoti)
            'MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub NotiAvisos(ct_Panel As Panel, ct_label As Label, wTipoNoti As String, wNoti As String, wtimer As Timer)
        ct_Panel.Visible = True
        If wTipoNoti = "ALERTA" Then
            ct_Panel.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorRojo)
            ct_label.ForeColor = Color.White
        ElseIf wTipoNoti = "EXITO" Then
            ct_Panel.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorVerde)
            ct_label.ForeColor = Color.White
        ElseIf wTipoNoti = "ADVERTENCIA" Then
            ct_Panel.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorAzul)
            ct_label.ForeColor = Color.White
        End If
        ct_label.Text = wNoti.ToUpper
        ct_label.Tag = 0
        wtimer.Enabled = True

    End Sub

    Private Sub TimeNoti_Tick(sender As Object, e As EventArgs) Handles TimeNoti.Tick
        LblNoti.Visible = True
        If Val(LblNoti.Tag) >= 10 Then
            TimeNoti.Enabled = False
            PanelNoti.BackColor = Color.White
            PanelNoti.Visible = False
        End If
        LblNoti.Tag = Val(LblNoti.Tag) + 1
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub dg_operaciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_operaciones.CellContentClick

    End Sub

    Private Sub dg_operaciones_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_operaciones.CellClick
        Dim Result As String
        If e.RowIndex < 0 Then Exit Sub

        Try
            Dim lk_sql_listafiltro As New DataTable
            Dim command As SqlCommand
            Dim adapter As SqlDataAdapter


            command = New SqlCommand("SELECT  * FROM [dbo].[operaciones_mae] where id_oper_maestro = " & dg_operaciones.Rows(e.RowIndex).Cells("id_oper_maestro").Value & "", lk_connection_master)
            adapter = New SqlDataAdapter(command)
            lk_sql_listafiltro = New DataTable
            adapter.Fill(lk_sql_listafiltro)

            If lk_sql_listafiltro.Rows.Count <> 0 Then
                l_id_oper_maestro.Text = dg_operaciones.Rows(e.RowIndex).Cells("id_oper_maestro").Value
                t_esinventario.Text = lk_sql_listafiltro.Rows(0).Item("es_inventario")
                t_esfinanzas.Text = lk_sql_listafiltro.Rows(0).Item("es_finanzas")
                t_escosteo.Text = lk_sql_listafiltro.Rows(0).Item("es_costeo")
                t_escospro.Text = lk_sql_listafiltro.Rows(0).Item("es_cospro")
                t_escontrollote.Text = lk_sql_listafiltro.Rows(0).Item("es_control_lote")
                t_escuentasn.Text = lk_sql_listafiltro.Rows(0).Item("es_cuentasn")
                t_estado.Text = lk_sql_listafiltro.Rows(0).Item("estado")
                t_signoinventario.Text = lk_sql_listafiltro.Rows(0).Item("signo_inventario")
                t_signocuentasn.Text = lk_sql_listafiltro.Rows(0).Item("signo_cuentasn")
                t_signofinanzas.Text = lk_sql_listafiltro.Rows(0).Item("signo_finanzas")
                t_tipotransf.Text = lk_sql_listafiltro.Rows(0).Item("tipo_transf_kardex")
                t_estadodef.Text = lk_sql_listafiltro.Rows(0).Item("estado_oper_def")
                t_edtipoBalance.Text = lk_sql_listafiltro.Rows(0).Item("id_tb_tipo_balance")
                t_eslistaprecio.Text = lk_sql_listafiltro.Rows(0).Item("es_listaprecio")
                t_directo_id_tb_oper.Text = lk_sql_listafiltro.Rows(0).Item("directo_id_tb_oper")
                t_directo_id_oper_maestro.Text = lk_sql_listafiltro.Rows(0).Item("directo_id_oper_maestro")
                t_fn_directo_id_tb_oper.Text = lk_sql_listafiltro.Rows(0).Item("fn_directo_id_tb_oper")
                t_fn_directo_id_oper_maestro.Text = lk_sql_listafiltro.Rows(0).Item("fn_directo_id_oper_maestro")
                t_escanjecomp.Text = lk_sql_listafiltro.Rows(0).Item("es_canje_comp")
                t_escanjele.Text = lk_sql_listafiltro.Rows(0).Item("es_canje_le")
                t_esreserva.Text = lk_sql_listafiltro.Rows(0).Item("es_reserva")
                tes_prod_new.Text = lk_sql_listafiltro.Rows(0).Item("es_prod_new")
                t_esbonificado.Text = lk_sql_listafiltro.Rows(0).Item("es_bonificado")
                t_esaplicanc.Text = lk_sql_listafiltro.Rows(0).Item("es_aplica_nc")




            End If

        Catch ex As Exception

            NotiAvisos(PanelNoti, LblNoti, "ALERTA", "ERROR INTERNO: " + ex.Message, TimeNoti)


        End Try



        If dg_operaciones.Columns(e.ColumnIndex).HeaderText.ToUpper = "QUITAR" Then

            'Dim result = RJMessageBox.Show("This is an example of an Yes, No Button Message Box.",
            '                               "Yes-No Button",
            '                               MessageBoxButtons.YesNo)
            'labelDialogResult.Text = result.ToString() & " Selected"
            'Dim result = RJMessageBox.Show("This is an example of an Yes, No Button Message Box.",
            '                           "Yes-No Button",
            '                           MessageBoxButtons.YesNo)


            Result = MensajesBox.Show("Confirmar la Eliminacion de forma permanente.", "Eliminar", MessageBoxButtons.YesNo)
            If Result = "7" Then ' es NO
                Exit Sub
            End If
            Dim command As New SqlCommand()

            Try
                command.Connection = lk_connection_master
                command.Transaction = lk_connection_master.BeginTransaction(IsolationLevel.Serializable)


                command.CommandText = "delete from  operaciones_mae WHERE  id_oper_maestro =  @id_oper_maestro  AND id_tb_oper = @id_tb_oper  and id_tb_sub_oper = @id_tb_sub_oper and id_tb_tipo_oper = @id_tb_tipo_oper"
                command.Parameters.Clear()

                command.Parameters.AddWithValue("@id_oper_maestro", dg_operaciones.Rows(e.RowIndex).Cells("id_oper_maestro").Value)
                command.Parameters.AddWithValue("@id_tb_oper", dg_operaciones.Rows(e.RowIndex).Cells("id_tb_oper").Value)
                command.Parameters.AddWithValue("@id_tb_sub_oper", dg_operaciones.Rows(e.RowIndex).Cells("id_suboper").Value)
                command.Parameters.AddWithValue("@id_tb_tipo_oper", dg_operaciones.Rows(e.RowIndex).Cells("id_tipo_oper").Value)
                command.ExecuteNonQuery()
                command.Transaction.Commit()
                NotiAvisos(PanelNoti, LblNoti, "EXITO", "REGISTRO ELIMINADO CON EXITO", TimeNoti)
                Muestra_operaciones()
                Muestra_Box_operaciones()
            Catch ex As Exception
                command.Transaction.Rollback()
                NotiAvisos(PanelNoti, LblNoti, "ALERTA", "ERROR INTERNO: " + ex.Message, TimeNoti)
                'MessageBox.Show("Error: " & ex.Message)
            End Try
            Exit Sub
        End If
        CmdEstructura.Items.Clear()
        CmdEstructura.Items.Add(lbloper.Text & Space(80) & txtOper.Tag) '  index 0 501
        CmdEstructura.Items.Add(dg_operaciones.Rows(e.RowIndex).Cells("descrip_suboper").Value & Space(80) & dg_operaciones.Rows(e.RowIndex).Cells("id_suboper").Value) '  index 0 501
        CmdEstructura.Items.Add(dg_operaciones.Rows(e.RowIndex).Cells("descrip_tipo_oper").Value & Space(80) & dg_operaciones.Rows(e.RowIndex).Cells("id_tipo_oper").Value)  ' index 1 502
        CmdEstructura.Tag = dg_operaciones.Rows(e.RowIndex).Cells("id_oper_maestro").Value


    End Sub

    Private Sub CmdAddBox_Click(sender As Object, e As EventArgs) Handles CmdAddBox.Click
        If CmdEstructura.Text = "" Or CmbBox.Text = "" Or CmbBoxSALTO.Text = "" Then
            NotiAvisos(PanelNoti, LblNoti, "ALERTA", "Definir: Estructura , Box y SaltoBox  -  Verifique si a Selecionado una Sub Operación", TimeNoti)
            Exit Sub
        End If
        If TxtUbica.Text = "" Then
            NotiAvisos(PanelNoti, LblNoti, "ALERTA", "Asigne una Ubicación", TimeNoti)
            Exit Sub
        End If
        If Val(TxtUbica.Text) >= 0 And Val(TxtUbica.Text) <= 30 Then
        Else
            NotiAvisos(PanelNoti, LblNoti, "ALERTA", "Rango es de 0 = Sin Salto y del 1 al 17 ", TimeNoti)
            Exit Sub
        End If


        If CmdEstructura.Items.Count <> 3 Then ' validad que debe de tenr 2 unoes 501  y el otro es 502 codigo de estcruruias
            NotiAvisos(PanelNoti, LblNoti, "ALERTA", "VERIFICAR TIPO DE ESTRCUTRUA : DEBE DE TENER 2 EN LA LISTA ", TimeNoti)
            Exit Sub
        End If
        Dim command As New SqlCommand()
        Dim wid_codestru As Integer
        command.Connection = lk_connection_master
        command.Transaction = lk_connection_master.BeginTransaction(IsolationLevel.Serializable)

        Try

            ' Insertar registro en tabla1
            If CmdEstructura.SelectedIndex = 0 Then
                wid_codestru = 500
            ElseIf CmdEstructura.SelectedIndex = 1 Then
                wid_codestru = 501
            ElseIf CmdEstructura.SelectedIndex = 2 Then
                wid_codestru = 502
            End If

            ' id_oper_maestro id_tb_estru_oper  id_tb_estru_oper_item id_tb_box   nro_ubica orden salto_id_tb_box
            command.CommandText = "INSERT INTO operaciones_box VALUES (@id_oper_maestro, @id_tb_estru_oper, @id_tb_estru_oper_item, @id_tb_box, @nro_ubica, @orden, @salto_id_tb_box, @es_opcional , @es_opcional_lote, @es_condesc1, @es_condesc2)"
            command.Parameters.Clear()
            command.Parameters.AddWithValue("@id_oper_maestro", Trim(CmdEstructura.Tag))
            command.Parameters.AddWithValue("@id_tb_estru_oper", wid_codestru)
            command.Parameters.AddWithValue("@id_tb_estru_oper_item", Trim(Strings.Right(CmdEstructura.Text, 10)))
            command.Parameters.AddWithValue("@id_tb_box", Trim(Strings.Right(CmbBox.Text, 10)))
            command.Parameters.AddWithValue("@nro_ubica", Val(TxtUbica.Text))
            command.Parameters.AddWithValue("@orden", Val(TxtOrden.Text))
            command.Parameters.AddWithValue("@salto_id_tb_box", Trim(Strings.Right(CmbBoxSALTO.Text, 10)))
            If es_opcional.Checked Then
                command.Parameters.AddWithValue("@es_opcional", 1)
            Else
                command.Parameters.AddWithValue("@es_opcional", 0)
            End If
            If es_opcional_lote.Checked Then
                command.Parameters.AddWithValue("@es_opcional_lote", 1)
            Else
                command.Parameters.AddWithValue("@es_opcional_lote", 0)
            End If
            If es_condesc1.Checked Then
                command.Parameters.AddWithValue("@es_condesc1", 1)
            Else
                command.Parameters.AddWithValue("@es_condesc1", 0)
            End If
            If es_condesc2.Checked Then
                command.Parameters.AddWithValue("@es_condesc2", 1)
            Else
                command.Parameters.AddWithValue("@es_condesc2", 0)
            End If




            command.ExecuteNonQuery()




            command.Transaction.Commit()
            NotiAvisos(PanelNoti, LblNoti, "EXITO", "REGISTRO CREADO CON EXITO", TimeNoti)
            Muestra_Box_operaciones()
        Catch ex As Exception
            command.Transaction.Rollback()
            NotiAvisos(PanelNoti, LblNoti, "ALERTA", "ERROR INTERNO: " + ex.Message, TimeNoti)
            'MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub



    Private Sub dg_box_oper_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_box_oper.CellContentClick

    End Sub
    Private Sub dg_box_oper_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_box_oper.CellDoubleClick
        CmdActu.Text = "Reeplazar:  " & dg_box_oper.Rows(e.RowIndex).Cells("id_oper_maestro").Value
        CmdActu.Tag = dg_box_oper.Rows(e.RowIndex).Cells("id_oper_maestro").Value
        TxtOrden.Select()




    End Sub

    Private Sub dg_box_oper_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_box_oper.CellClick
        Dim Result As String
        If dg_box_oper.Columns(e.ColumnIndex).HeaderText.ToUpper = "QUITAR" Then


            Result = MensajesBox.Show("Confirmar la Eliminacion de forma permanente.", "Eliminar", MessageBoxButtons.YesNo)
            If Result = "7" Then ' es NO
                Exit Sub
            End If
            Dim command As New SqlCommand()

            Try
                command.Connection = lk_connection_master
                command.Transaction = lk_connection_master.BeginTransaction(IsolationLevel.Serializable)

                command.CommandText = "delete from operaciones_box  where id_oper_maestro = @id_oper_maestro and id_tb_estru_oper = @id_tb_estru_oper and id_tb_estru_oper_item = @id_tb_estru_oper_item and id_tb_box= @id_tb_box"
                command.Parameters.Clear()

                command.Parameters.AddWithValue("@id_oper_maestro", dg_box_oper.Rows(e.RowIndex).Cells("id_oper_maestro").Value)
                command.Parameters.AddWithValue("@id_tb_estru_oper", dg_box_oper.Rows(e.RowIndex).Cells("id_tb_estru_oper").Value)
                command.Parameters.AddWithValue("@id_tb_estru_oper_item", dg_box_oper.Rows(e.RowIndex).Cells("id_tb_estru_oper_item").Value)
                command.Parameters.AddWithValue("@id_tb_box", dg_box_oper.Rows(e.RowIndex).Cells("id_tb_box").Value)
                command.ExecuteNonQuery()
                command.Transaction.Commit()
                NotiAvisos(PanelNoti, LblNoti, "EXITO", "REGISTRO ELIMINADO CON EXITO", TimeNoti)

                Muestra_Box_operaciones()
            Catch ex As Exception
                command.Transaction.Rollback()
                NotiAvisos(PanelNoti, LblNoti, "ALERTA", "ERROR INTERNO: " + ex.Message, TimeNoti)
                'MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub CmdArchi_Click(sender As Object, e As EventArgs) Handles CmdArchi.Click

        fileExcel.Filter = "Archivo xlsx|*.xlsx"
        fileExcel.FilterIndex = 0
        fileExcel.Multiselect = False
        CmdArchi.Tag = ""
        If fileExcel.ShowDialog() = DialogResult.OK Then
            CmdArchi.Tag = fileExcel.FileName
        End If
    End Sub

    Private Sub SubirUBIGEO_Click(sender As Object, e As EventArgs) Handles SubirUBIGEO.Click

        Dim command As New SqlCommand()
        command.Connection = lk_connection_master
        ' command.Transaction = lk_connection_master.BeginTransaction(IsolationLevel.Serializable)
        '
        Dim rutaArchivo As String = CmdArchi.Tag
        Dim vString1 As String = "-vacio-"
        Dim CONTENIDO As String = "-"
        Dim Fila As Long = 4
        Try
            Dim oExcel As Object
            Dim oLibro As Object
            Dim oHoja As Object
            Dim oRango As Object

            oExcel = CreateObject("Excel.Application")
            '   oLibro = oExcel.Workbooks.Add
            oLibro = oExcel.Workbooks.Open(rutaArchivo)
            'oHoja = oLibro.ActiveSheet ' ABRE LA HOJA PRIMERA
            oHoja = oLibro.Sheets("HOJA1")
            Dim wdepa_id As String
            Dim wdepa_Nom As String
            Dim wdepa_n1 As String = ""
            Dim wdepa_n2 As String = ""

            oExcel.Visible = True ' Muestra el archivo Excel abierto

            '            


            '            


            '            insert into 
            '[ubigeo_n3]
            '            values(1, '01' , 'nombre','n2','1')





            For Fila = 1 To 2112

                If oHoja.Cells(Fila, 1).value <> "" And Trim(oHoja.Cells(Fila, 2).value) = "" And Trim(oHoja.Cells(Fila, 3).value) = "" Then
                    wdepa_id = Strings.Left(oHoja.Cells(Fila, 1).value, 2)
                    wdepa_Nom = Mid(oHoja.Cells(Fila, 1).value, 4, Len(oHoja.Cells(Fila, 1).value))
                    wdepa_n1 = wdepa_id
                    ' addd departarmete
                    oHoja.Cells(Fila, 4).value = "adddepa"
                    command.CommandText = "insert into [ubigeo_n1] values(@id_pais, @codigo , @nombre,@estado)"
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("@id_pais", 1)
                    command.Parameters.AddWithValue("@codigo", wdepa_id)
                    command.Parameters.AddWithValue("@nombre", wdepa_Nom.ToUpper)
                    command.Parameters.AddWithValue("@estado", 1)
                    command.ExecuteNonQuery()

                End If
                If oHoja.Cells(Fila, 1).value <> "" And Trim(oHoja.Cells(Fila, 2).value) <> "" And Trim(oHoja.Cells(Fila, 3).value) = "" Then

                    wdepa_id = Strings.Left(oHoja.Cells(Fila, 2).value, 2)
                    wdepa_Nom = Mid(oHoja.Cells(Fila, 2).value, 4, Len(oHoja.Cells(Fila, 2).value))
                    wdepa_n2 = wdepa_id
                    ' addd departarmete
                    'insert into            [ubigeo_n2]            values(1, '01' , 'nombre','n1','1')
                    oHoja.Cells(Fila, 4).value = "adddepa"
                    command.CommandText = "insert into [ubigeo_n2] values(@id_pais, @codigo , @nombre,@codigon1, @estado)"
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("@id_pais", 1)
                    command.Parameters.AddWithValue("@codigo", wdepa_id)
                    command.Parameters.AddWithValue("@codigon1", wdepa_n1)
                    command.Parameters.AddWithValue("@nombre", wdepa_Nom.ToUpper)
                    command.Parameters.AddWithValue("@estado", 1)
                    command.ExecuteNonQuery()
                    '  command.Transaction.Commit()

                End If
                If oHoja.Cells(Fila, 1).value <> "" And Trim(oHoja.Cells(Fila, 2).value) <> "" And Trim(oHoja.Cells(Fila, 3).value) <> "" Then
                    wdepa_id = Strings.Left(oHoja.Cells(Fila, 3).value, 2)
                    wdepa_Nom = Mid(oHoja.Cells(Fila, 3).value, 4, Len(oHoja.Cells(Fila, 2).value))
                    ' addd departarmete
                    'insert into            [ubigeo_n2]            values(1, '01' , 'nombre','n1','1')
                    oHoja.Cells(Fila, 4).value = "adddepa"
                    command.CommandText = "insert into [ubigeo_n3] values(@id_pais, @codigo , @nombre,@codigon2, @codigon1 ,@estado)"
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("@id_pais", 1)
                    command.Parameters.AddWithValue("@codigo", wdepa_id)
                    command.Parameters.AddWithValue("@codigon2", wdepa_n2)
                    command.Parameters.AddWithValue("@codigon1", wdepa_n1)

                    command.Parameters.AddWithValue("@nombre", wdepa_Nom.ToUpper)
                    command.Parameters.AddWithValue("@estado", 1)
                    command.ExecuteNonQuery()
                    'command.Transaction.Commit()
                End If

            Next Fila

            oRango = Nothing
            oHoja = Nothing
            oLibro = Nothing
            oExcel.quit()
            oExcel = Nothing

            MsgBox(vString1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub SubirFINEI_Click(sender As Object, e As EventArgs) Handles SubirFINEI.Click
        Dim adapter As SqlDataAdapter
        Dim command As New SqlCommand()

        command.Connection = lk_connection_master
        ' command.Transaction = lk_connection_master.BeginTransaction(IsolationLevel.Serializable)
        '
        Dim rutaArchivo As String = CmdArchi.Tag
        Dim vString1 As String = "-vacio-"
        Dim CONTENIDO As String = "-"
        Dim Fila As Long = 4
        Try
            Dim oExcel As Object
            Dim oLibro As Object
            Dim oHoja As Object
            Dim oRango As Object

            oExcel = CreateObject("Excel.Application")
            '   oLibro = oExcel.Workbooks.Add
            oLibro = oExcel.Workbooks.Open(rutaArchivo)
            'oHoja = oLibro.ActiveSheet ' ABRE LA HOJA PRIMERA
            oHoja = oLibro.Sheets("HOJA1")
            Dim wdepa_id As String
            Dim wdepa_Nom As String
            Dim wdepa_n1 As String = ""
            Dim wdepa_n2 As String = ""

            oExcel.Visible = True ' Muestra el archivo Excel abierto


            '            insert into 
            '[ubigeo_n3]
            '            values(1, '01' , 'nombre','n2','1')
            'Dim Result As String
            Dim dt_operaciones As New DataTable




            For Fila = 2 To 1900

                lblava2.Text = Fila
                oHoja.Cells(3, 3).value = "Add" & Fila
                Application.DoEvents()
                If oHoja.Cells(Fila, 1).value = "" Then GoTo sigue
                'wdepa_id = Strings.Left(oHoja.Cells(Fila, 1).value, 2)


                wdepa_id = Mid(oHoja.Cells(Fila, 1).value, 1, 2)

                command = New SqlCommand("select  * from ubigeo_n1 where  id_ubigeo_n1= '" & wdepa_id & "'", lk_connection_master)
                adapter = New SqlDataAdapter(command)
                dt_operaciones = New DataTable
                adapter.Fill(dt_operaciones)
                If dt_operaciones.Rows.Count = 0 Then
                    ' wdepa_id = Strings.Left(oHoja.Cells(Fila, 1).value, 2)
                    wdepa_Nom = oHoja.Cells(Fila, 2).value
                    wdepa_n1 = wdepa_id
                    ' addd departarmete
                    'oHoja.Cells(Fila, 4).value = "adddepa"
                    command.CommandText = "insert into [ubigeo_n1] values(@id_pais, @codigo , @nombre,@estado)"
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("@id_pais", 1)
                    command.Parameters.AddWithValue("@codigo", wdepa_id)
                    command.Parameters.AddWithValue("@nombre", wdepa_Nom.ToUpper)
                    command.Parameters.AddWithValue("@estado", 1)
                    command.ExecuteNonQuery()
                End If

                wdepa_id = Mid(oHoja.Cells(Fila, 1).value, 1, 2)
                wdepa_n1 = Mid(oHoja.Cells(Fila, 1).value, 3, 2)

                command = New SqlCommand("select  * from ubigeo_n2 where  id_ubigeo_n2= '" & wdepa_n1 & "' and id_ubigeo_n1= '" & wdepa_id & "'", lk_connection_master)
                adapter = New SqlDataAdapter(command)
                dt_operaciones = New DataTable
                adapter.Fill(dt_operaciones)
                If dt_operaciones.Rows.Count = 0 Then
                    ' wdepa_id = Strings.Left(oHoja.Cells(Fila, 1).value, 2)
                    wdepa_Nom = oHoja.Cells(Fila, 3).value
                    'wdepa_n1 = wdepa_id
                    ' addd departarmete
                    'oHoja.Cells(Fila, 4).value = "addddistr"
                    command.CommandText = "insert into [ubigeo_n2] values(@id_pais, @codigo , @nombre,@codigon1, @estado)"
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("@id_pais", 1)
                    command.Parameters.AddWithValue("@codigo", wdepa_n1)
                    command.Parameters.AddWithValue("@codigon1", wdepa_id)
                    command.Parameters.AddWithValue("@nombre", wdepa_Nom.ToUpper)
                    command.Parameters.AddWithValue("@estado", 1)
                    command.ExecuteNonQuery()
                End If

                wdepa_id = Mid(oHoja.Cells(Fila, 1).value, 1, 2)
                wdepa_n1 = Mid(oHoja.Cells(Fila, 1).value, 3, 2)
                wdepa_n2 = Mid(oHoja.Cells(Fila, 1).value, 5, 2)

                command = New SqlCommand("select  * from ubigeo_n3 where  id_ubigeo_n3= '" & wdepa_n2 & "'  and id_ubigeo_n2= '" & wdepa_n1 & "' and id_ubigeo_n1= '" & wdepa_id & "'", lk_connection_master)
                adapter = New SqlDataAdapter(command)
                dt_operaciones = New DataTable
                adapter.Fill(dt_operaciones)
                If dt_operaciones.Rows.Count = 0 Then
                    ' wdepa_id = Strings.Left(oHoja.Cells(Fila, 1).value, 2)
                    wdepa_Nom = oHoja.Cells(Fila, 4).value
                    'wdepa_n1 = wdepa_id

                    command.CommandText = "insert into [ubigeo_n3] values(@id_pais, @codigo , @nombre,@codigon2, @codigon1 ,@estado,@region)"
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("@id_pais", 1)
                    command.Parameters.AddWithValue("@codigo", wdepa_n2)
                    command.Parameters.AddWithValue("@codigon2", wdepa_n1)
                    command.Parameters.AddWithValue("@codigon1", wdepa_id)

                    command.Parameters.AddWithValue("@nombre", wdepa_Nom.ToUpper)
                    command.Parameters.AddWithValue("@estado", 1)
                    command.Parameters.AddWithValue("@region", oHoja.Cells(Fila, 10).value)
                    command.ExecuteNonQuery()
                End If


sigue:
            Next Fila

            oRango = Nothing
            oHoja = Nothing
            oLibro = Nothing
            oExcel.quit()
            oExcel = Nothing

            MsgBox(vString1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub CmdActu_Click(sender As Object, e As EventArgs) Handles CmdActu.Click
        If Val(CmdActu.Tag) = 0 Then
            MsgBox("Selecion antes con Doble Click")
            Exit Sub
        End If

        If CmdEstructura.Text = "" Or CmbBox.Text = "" Or CmbBoxSALTO.Text = "" Then
            NotiAvisos(PanelNoti, LblNoti, "ALERTA", "Definir: Estructura , Box y SaltoBox  -  Verifique si a Selecionado una Sub Operación", TimeNoti)
            Exit Sub
        End If
        If TxtUbica.Text = "" Then
            NotiAvisos(PanelNoti, LblNoti, "ALERTA", "Asigne una Ubicación", TimeNoti)
            Exit Sub
        End If
        If Val(TxtUbica.Text) >= 0 And Val(TxtUbica.Text) <= 30 Then
        Else
            NotiAvisos(PanelNoti, LblNoti, "ALERTA", "Rango es de 0 = Sin Salto y del 1 al 17 ", TimeNoti)
            Exit Sub
        End If


        If CmdEstructura.Items.Count <> 3 Then ' validad que debe de tenr 2 unoes 501  y el otro es 502 codigo de estcruruias
            NotiAvisos(PanelNoti, LblNoti, "ALERTA", "VERIFICAR TIPO DE ESTRCUTRUA : DEBE DE TENER 2 EN LA LISTA ", TimeNoti)
            Exit Sub
        End If







        Dim wid_codestru As Integer
        ' Insertar registro en tabla1
        If CmdEstructura.SelectedIndex = 0 Then
            wid_codestru = 500
        ElseIf CmdEstructura.SelectedIndex = 1 Then
            wid_codestru = 501
        ElseIf CmdEstructura.SelectedIndex = 2 Then
            wid_codestru = 502
        End If

        Dim command As New SqlCommand()
        Try
            Command.Connection = lk_connection_master
            Command.Transaction = lk_connection_master.BeginTransaction(IsolationLevel.Serializable)

            command.CommandText = "update operaciones_box  set 
                    id_oper_maestro = @id_oper_maestro_new , id_tb_estru_oper = @id_tb_estru_oper_new
                 , id_tb_estru_oper_item = @id_tb_estru_oper_item_new , id_tb_box = @id_tb_box_new
                , nro_ubica = @nro_ubica , orden = @orden  , es_opcional = @es_opcional
                , salto_id_tb_box = @salto_id_tb_box , es_opcional_lote = @es_opcional_lote ,  es_condesc1 = @es_condesc1 , es_condesc2 = @es_condesc2
                where id_oper_maestro = @id_oper_maestro and id_tb_estru_oper = @id_tb_estru_oper and id_tb_estru_oper_item = @id_tb_estru_oper_item and id_tb_box= @id_tb_box"
            command.Parameters.Clear()

            command.Parameters.AddWithValue("@id_oper_maestro", dg_box_oper.Rows(dg_box_oper.CurrentCell.RowIndex).Cells("id_oper_maestro").Value)
            command.Parameters.AddWithValue("@id_tb_estru_oper", dg_box_oper.Rows(dg_box_oper.CurrentCell.RowIndex).Cells("id_tb_estru_oper").Value)
            command.Parameters.AddWithValue("@id_tb_estru_oper_item", dg_box_oper.Rows(dg_box_oper.CurrentCell.RowIndex).Cells("id_tb_estru_oper_item").Value)
            command.Parameters.AddWithValue("@id_tb_box", dg_box_oper.Rows(dg_box_oper.CurrentCell.RowIndex).Cells("id_tb_box").Value)

            command.Parameters.AddWithValue("@id_oper_maestro_new", Trim(CmdEstructura.Tag))
            command.Parameters.AddWithValue("@id_tb_estru_oper_new", wid_codestru)
            command.Parameters.AddWithValue("@id_tb_estru_oper_item_new", Trim(Strings.Right(CmdEstructura.Text, 10)))
            command.Parameters.AddWithValue("@id_tb_box_new", Trim(Strings.Right(CmbBox.Text, 10)))
            command.Parameters.AddWithValue("@nro_ubica", Val(TxtUbica.Text))
            command.Parameters.AddWithValue("@orden", Val(TxtOrden.Text))
            command.Parameters.AddWithValue("@salto_id_tb_box", Trim(Strings.Right(CmbBoxSALTO.Text, 10)))
            If es_opcional.Checked Then
                command.Parameters.AddWithValue("@es_opcional", 1)
            Else
                command.Parameters.AddWithValue("@es_opcional", 0)
            End If
            If es_opcional_lote.Checked Then
                command.Parameters.AddWithValue("@es_opcional_lote", 1)
            Else
                command.Parameters.AddWithValue("@es_opcional_lote", 0)
            End If
            If es_condesc1.Checked Then
                command.Parameters.AddWithValue("@es_condesc1", 1)
            Else
                command.Parameters.AddWithValue("@es_condesc1", 0)
            End If
            If es_condesc2.Checked Then
                command.Parameters.AddWithValue("@es_condesc2", 1)
            Else
                command.Parameters.AddWithValue("@es_condesc2", 0)
            End If

            command.ExecuteNonQuery()
            command.Transaction.Commit()
            NotiAvisos(PanelNoti, LblNoti, "EXITO", "REGISTRO ELIMINADO CON EXITO", TimeNoti)
            Muestra_Box_operaciones()
            CmdActu.Tag = "0"
            CmdActu.Text = "Dobleick Edit"
        Catch ex As Exception
            Command.Transaction.Rollback()
            NotiAvisos(PanelNoti, LblNoti, "ALERTA", "ERROR INTERNO: " + ex.Message, TimeNoti)
            'MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub ListaRegistros(ws_idTabla As Integer)
        Cabe_TablasBasicas()

        Dim lk_sql_listafiltro As New DataTable
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter


        command = New SqlCommand("SELECT * FROM  tablas_basicas where id_tipotabla = " & ws_idTabla & " order by id_tb", lk_connection_master)
        adapter = New SqlDataAdapter(command)
        lk_sql_listafiltro = New DataTable
        adapter.Fill(lk_sql_listafiltro)

        If lk_sql_listafiltro.Rows.Count = 0 Then

            Dim Result As String = MensajesBox.Show("No Existe Registros en su consulta.",
                                    "Lista de Tablas.")
            Exit Sub

        End If
        Dim witems As Integer = 0
        For i = 0 To lk_sql_listafiltro.Rows.Count - 1

            Me.dt_Tablas_basicas.Rows.Add()
            witems = witems + 1

            dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("num").Value = witems
            dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("id_tb").Value = lk_sql_listafiltro.Rows(i).Item("id_tb")
            dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("id_tipotabla").Value = lk_sql_listafiltro.Rows(i).Item("id_tipotabla")
            dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("descripcion").Value = lk_sql_listafiltro.Rows(i).Item("descripcion")
            dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("abreviado").Value = lk_sql_listafiltro.Rows(i).Item("abreviado")
            dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("estado").Value = lk_sql_listafiltro.Rows(i).Item("estado")
            dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("codigo").Value = lk_sql_listafiltro.Rows(i).Item("codigo")
            dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("opcional1").Value = lk_sql_listafiltro.Rows(i).Item("opcional1")
            dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("actualizar").Value = "UPD"
            dt_Tablas_basicas.Rows(dt_Tablas_basicas.Rows.Count - 1).Cells("eliminar").Value = "DEL"

        Next

        dt_Tablas_basicas.Focus()

    End Sub
    Private Sub Cabe_TablasBasicas()
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
        textoColumn.Name = "id_tb"
        textoColumn.Tag = "N"
        textoColumn.HeaderText = "id_tb"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 50
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_tipotabla"
        textoColumn.Tag = "N"
        textoColumn.HeaderText = "Tipo"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 50
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "descripcion"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "descripcion"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 200
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "abreviado"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "abreviado"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 90
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "estado"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "estado"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 40
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigo"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "codigo"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 70
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "opcional1"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "opcional1"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_Tablas_basicas.Columns.Add(textoColumn)
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).Width = 70
        dt_Tablas_basicas.Columns.Item(textoColumn.Name).ReadOnly = False


        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "actualizar"
        BotonColumn.HeaderText = "Graba"
        BotonColumn.FlatStyle = FlatStyle.Flat
        dt_Tablas_basicas.Columns.Add(BotonColumn)
        dt_Tablas_basicas.Columns.Item(BotonColumn.Name).Width = 40

        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "eliminar"
        BotonColumn.HeaderText = "Eliminar"
        BotonColumn.FlatStyle = FlatStyle.Flat
        dt_Tablas_basicas.Columns.Add(BotonColumn)
        dt_Tablas_basicas.Columns.Item(BotonColumn.Name).Width = 40

    End Sub

    Private Sub CmbListaTabla_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbListaTabla.SelectedIndexChanged
        Dim ws_cod As Integer = Val(Strings.Left(CmbListaTabla.Text, 3))
        ListaRegistros(ws_cod)

    End Sub

    Private Sub dt_Tablas_basicas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dt_Tablas_basicas.CellContentClick
        If e.ColumnIndex = dt_Tablas_basicas.Columns("actualizar").Index AndAlso e.RowIndex >= 0 Then
            Dim wtipotabla As Integer = dt_Tablas_basicas.Rows(dt_Tablas_basicas.CurrentCell.RowIndex).Cells("id_tipotabla").Value
            Dim wid_tb As Integer = dt_Tablas_basicas.Rows(dt_Tablas_basicas.CurrentCell.RowIndex).Cells("id_tb").Value
            Dim wdescripcion As String = dt_Tablas_basicas.Rows(dt_Tablas_basicas.CurrentCell.RowIndex).Cells("descripcion").Value
            Dim wabreviado As String = dt_Tablas_basicas.Rows(dt_Tablas_basicas.CurrentCell.RowIndex).Cells("abreviado").Value
            Dim westado As String = dt_Tablas_basicas.Rows(dt_Tablas_basicas.CurrentCell.RowIndex).Cells("estado").Value
            Dim wcodigo As String = dt_Tablas_basicas.Rows(dt_Tablas_basicas.CurrentCell.RowIndex).Cells("codigo").Value
            Dim wopcional1 As String = dt_Tablas_basicas.Rows(dt_Tablas_basicas.CurrentCell.RowIndex).Cells("opcional1").Value


            Dim wcade_act As String = "UPDATE tablas_basicas SET descripcion = '" & wdescripcion & "' , abreviado = '" & wabreviado & "' , estado = " & westado & " , codigo = '" & wcodigo & "' , opcional1= '" & wopcional1 & "' where id_tipotabla = " & wtipotabla & " and id_tb = " & wid_tb & ""
            Dim command As SqlCommand = New SqlCommand(wcade_act, lk_connection_master)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            Dim Sql_ActualizaUser As New DataTable

            adapter.Fill(Sql_ActualizaUser)
            Dim filasActualizadas As Integer = command.ExecuteNonQuery()
            If filasActualizadas = 0 Then
                MsgBox("NO SE REALIZO LA Actualziado." & wtipotabla & "  " & wid_tb)
            Else
                'MsgBox("Actualziado." & wtipotabla & "  " & wid_tb)
                '    MsgBox("REGISTRO ELIMINADO .")
                ListaRegistros(Val(Strings.Left(CmbListaTabla.Text, 3)))
            End If
        End If
        If e.ColumnIndex = dt_Tablas_basicas.Columns("eliminar").Index AndAlso e.RowIndex >= 0 Then

            Dim Result As String = MensajesBox.Show("DESEA ELIMINAR DE FORMA PERMANENTE ..?" & vbCrLf & MessageBoxIcon.Error & "
                    ", "TABLAS_BASICAS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If Result = "7" Or Result = "2" Then ' es NO
                Exit Sub
            End If

            Dim wtipotabla As Integer = dt_Tablas_basicas.Rows(dt_Tablas_basicas.CurrentCell.RowIndex).Cells("id_tipotabla").Value
            Dim wid_tb As Integer = dt_Tablas_basicas.Rows(dt_Tablas_basicas.CurrentCell.RowIndex).Cells("id_tb").Value
            Try
                Dim wcade_act As String = "DELETE tablas_basicas  where id_tipotabla = " & wtipotabla & " and id_tb = " & wid_tb & ""
                Dim command As SqlCommand = New SqlCommand(wcade_act, lk_connection_master)
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
                Dim Sql_ActualizaUser As New DataTable
                adapter.Fill(Sql_ActualizaUser)
                '    MsgBox("REGISTRO ELIMINADO .")
                ListaRegistros(Val(Strings.Left(CmbListaTabla.Text, 3)))

            Catch
                MsgBox("NO SE REALIZO LA ELIMINACION, VERIFIQUE EL CODIGO INGRESADO.")
            End Try


        End If

    End Sub

    Private Sub cmdAddTab_Click(sender As Object, e As EventArgs) Handles cmdAddTab.Click
        ' Pedir al usuario que ingrese un valor utilizando InputBox
        Dim valorIngresado As String = InputBox("Ingrese el id_tab , siguiente :")
        Dim ws_cod As Integer = Val(Strings.Left(CmbListaTabla.Text, 3))
        ' Verificar si el usuario ingresó un valor
        If Not String.IsNullOrEmpty(valorIngresado) Then
            ' Realizar cualquier acción deseada con el valor ingresado
            Try
                Dim wcade_act As String = "insert into tablas_basicas values(" & valorIngresado & ", " & ws_cod & ",'','',1," & valorIngresado & ",'')"
                Dim command As SqlCommand = New SqlCommand(wcade_act, lk_connection_master)
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
                Dim Sql_ActualizaUser As New DataTable
                adapter.Fill(Sql_ActualizaUser)
                'MsgBox("Actualziado." & ws_cod & "  " & valorIngresado)

                ListaRegistros(Val(Strings.Left(CmbListaTabla.Text, 3)))
            Catch
                MsgBox("NO ACTUALIZO VERIFIQUE EL CODIGO INGRESADO." & ws_cod & "  " & valorIngresado)
            End Try



        Else
            ' El usuario no ingresó ningún valor
            Exit Sub
        End If
    End Sub

    Private Sub CmdUpdate_Click(sender As Object, e As EventArgs) Handles CmdUpdate.Click
        If Val(t_directo_id_oper_maestro.Text) <> 0 And Val(t_escontrollote.Text) = 0 Then
            MsgBox("Estas Asociando Una operacion de destino de Inventario y no tienes Activado el Lote")
            Exit Sub
        End If

        Dim wcade_act As String = "UPDATE operaciones_mae SET es_inventario = " & Val(t_esinventario.Text) & " ,
        directo_id_tb_oper = " & Val(t_directo_id_tb_oper.Text) & " , directo_id_oper_maestro = " & Val(t_directo_id_oper_maestro.Text) & " ,   
        fn_directo_id_tb_oper = " & Val(t_fn_directo_id_tb_oper.Text) & " , fn_directo_id_oper_maestro = " & Val(t_fn_directo_id_oper_maestro.Text) & " ,   
        es_listaprecio = " & Val(t_eslistaprecio.Text) & " , es_control_lote = " & Val(t_escontrollote.Text) & " ,   
        es_cospro = " & Val(t_escospro.Text) & " , es_costeo = " & Val(t_escosteo.Text) & " , es_finanzas = " & Val(t_esfinanzas.Text) & " , 
        es_cuentasn = " & Val(t_escuentasn.Text) & " , estado = " & Val(t_estado.Text) & " , signo_inventario= " & Val(t_signoinventario.Text) & " , 
        signo_cuentasn= " & Val(t_signocuentasn.Text) & " , signo_finanzas= " & Val(t_signofinanzas.Text) & " , tipo_transf_kardex= " & Val(t_tipotransf.Text) & " , 
        estado_oper_def= " & Val(t_estadodef.Text) & " , id_tb_tipo_balance= " & Val(t_edtipoBalance.Text) & ",
        es_canje_comp = " & Val(t_escanjecomp.Text) & " ,
        es_canje_le = " & Val(t_escanjele.Text) & " ,
        es_reserva = " & Val(t_esreserva.Text) & " ,
        es_prod_new = " & Val(tes_prod_new.Text) & " ,
        es_bonificado = " & Val(t_esbonificado.Text) & " ,
        es_aplica_nc = " & Val(t_esaplicanc.Text) & " 
        where id_oper_maestro = " & Val(l_id_oper_maestro.Text) & ""
        Dim command As SqlCommand = New SqlCommand(wcade_act, lk_connection_master)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        Dim Sql_ActualizaUser As New DataTable

        adapter.Fill(Sql_ActualizaUser)
        Dim filasActualizadas As Integer = command.ExecuteNonQuery()
        If filasActualizadas = 0 Then
            MsgBox("NO SE REALIZO LA Actualziado.")
        Else
            MsgBox("Actualziado.")
            '    MsgBox("REGISTRO ELIMINADO .")
            'ListaRegistros(Val(Strings.Left(CmbListaTabla.Text, 3)))
        End If

    End Sub


End Class

