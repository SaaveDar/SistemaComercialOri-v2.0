Imports System.Net
Imports System.Globalization
Imports Newtonsoft.Json.Linq
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports RestSharp
Imports System.Net.Http
Imports System.Text
Imports System.Net.Http.Headers
Imports System.Threading
Imports System.ComponentModel
Imports FontAwesome.Sharp

Public Class FrmOperaciones
    Dim loc_sql_lista_formato As DataTable
    Private formSize As Size

    Public Property ENLACE_TIPO As String '  1= eNVIAR iNFORMACION DE ENLACE 2 = MUESTRA iNFORMACION 
    Public Property ENLACE_MUESTRA_id_oper_maestro As Integer
    Public Property ENLACE_MUESTRA_id_comp_cabe As Integer

    Public Property ENLACE_ENVIO_OPER_CODIGO As String
    Public Property ENLACE_ENVIO_DATA_COMP As New DataTable
    Public Property ENLACE_id_oper_maestro As Integer
    Public Property ENLACE_id_comp_cabe As Integer
    Public Property ES_FORMZAR_CIERRE As Integer

    Dim dt_DatosEnlace_oper As DataTable

    Dim dt_DatosFinanzas_oper As DataTable

    Dim dt_DatosFinanzas_NC As DataTable

    Dim dt_Enlace_Envio_Oper As DataTable

    'Dim Flag_Buscando_Prod As Boolean = False

    ''''Dim frPermisoUsuarios As New FrmProductos
    Dim Loc_Tipo_Grid As String

    Dim Loc_Salto_Grid() As DataRow
    ' Variblaes 
    Dim Oper_Almacen_Defecto As New TempOerAlmacenDefecto
    Private Class TempOerAlmacenDefecto

        Public Property id_almacen As Integer

        Public Property nombre As String

        Public Property abreviado As String

        Public Property codigo As String

    End Class
    Private Sub FrmOperaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ActualizarColores()

        If lk_modoOscuro Then
            CmdOscuro.Text = "MODO CLARO"
        Else
            CmdOscuro.Text = "MODO OSCURO"
        End If
        Me.DoubleBuffered = True

        '============= PRUEBA PARA FORMALURO DE OPERACIONES ================================

        'CERRAR_SESIONES()
        'ConexionSQL_Maester()
        'ConexionSQL_Cuentas()
        'Carga_Paramtros_Generales()
        'Dim command As SqlCommand = New SqlCommand("u_login", lk_connection_master)
        'command.CommandType = CommandType.StoredProcedure
        'command.Parameters.AddWithValue("@usuario", "admin")
        'command.Parameters.AddWithValue("@clave", "1234")
        'Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        'adapter.Fill(lk_sql_ValidaUsuario)
        'lk_fecha_dia = Now
        'lk_id_usuario = lk_sql_ValidaUsuario.Rows(0)("id_usuario").ToString()
        'lk_usuario = lk_sql_ValidaUsuario.Rows(0)("Usuario").ToString()
        'lk_id_cuemta_user = lk_sql_ValidaUsuario.Rows(0)("id_cuenta_user").ToString()
        'lk_Carpeta_Temp = My.Computer.FileSystem.CurrentDirectory & "\user" & lk_id_usuario & "\"
        'My.Computer.FileSystem.CreateDirectory(lk_Carpeta_Temp)
        'lk_foto_perfil_id = 0
        'lk_id_cuemta_user = 1
        'Negocio_Local_Almacen_Usuario()


        '===============================================


        Carga_Paramtros_Negocio(lk_NegocioActivo.id_Negocio)

        Obtiene_formatos()

        Iniciar_Oper()

        ' Me.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorformulario)
        Me.MaximumSize = New Size(1500, 900) ' Establece el tamaño máximo a 800x600
        Me.MinimumSize = New Size(800, 600) ' Establece el tamaño mínimo a 400x300
        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        'Me.KeyPreview = True
        'CmbCondi_Lista.Items.Clear()
        'CmbCondi_Lista.Items.Add("07 DIAS ")
        'CmbCondi_Lista.Items.Add("10 DIAS ")
        'CmbCondi_Lista.Items.Add("15 DIAS ")
        'CmbCondi_Lista.Items.Add("20 DIAS ")
        'CmbCondi_Lista.Items.Add("30 DIAS ")
        'CmbCondi_Lista.Items.Add("45 DIAS ")
        'CmbCondi_Lista.Items.Add("60 DIAS ")
        'CmbCondi_Lista.Items.Add("TIENE DIAS DE CREDITO LIBRE")

        PanelCabecera.Visible = False
        PanelDEtalle.Visible = False
        PanelPie.Visible = False

        PanelCentral.Dock = DockStyle.Fill

        PanelCentral.Visible = True


        IniciarListar("I")
        CmdEstados.Text = "(TODOS SIN ANULADOS)"
        CmdEstados.Tag = "-1"

        Asigna_almacen_Defecto_Oper(lk_AlmacenActivo.id_almacen, lk_AlmacenActivo.codigo, lk_AlmacenActivo.nombre, lk_AlmacenActivo.abreviado)

        carga_lista_formatos()

        ' ...etc.

        Txt_Operacion_filtro.Text = ""
        CmdOperacion_filtro.Text = ""
        ' VERIFICAR SI VIENE DE OTRO COMPROBANTE PARA ENLAZAR
        ' ================================================
        If ENLACE_TIPO Is Nothing Then

        Else
            If ENLACE_TIPO = "1" Then
                If ENLACE_ENVIO_OPER_CODIGO Is Nothing Then
                Else
                    Enlace_Envio_Oper(ENLACE_ENVIO_DATA_COMP, ENLACE_ENVIO_OPER_CODIGO)
                End If
            ElseIf ENLACE_TIPO = "2" Then
                Muestra_Comprobante(lk_NegocioActivo.id_Negocio, ENLACE_MUESTRA_id_oper_maestro, ENLACE_MUESTRA_id_comp_cabe)
            End If
        End If
        Dim tooltip As New ToolTip()
        tooltip.SetToolTip(CmdInicialNum, "Mostrar Ultima Operaion realizada.")
        tooltip.SetToolTip(CmdConsultaReg, "Anterior Registro de Operación.")
        tooltip.SetToolTip(CmdConsultaReg_Sig, "Siguiente Registro de Operación.")
        tooltip.SetToolTip(CmdConOper, "Configurar a la Operación.")

    End Sub


    Private Sub Enlace_Envio_Oper(loc_datos_comp As DataTable, wcodigooper As String)
        Dim DataSeleccion As New DataTable
        Dim recp_alm_codigo As String = ""
        Dim recp_id_almacen As Integer = 0
        Dim recp_alm_abreviado As String = ""
        Dim wvien_id_almacen As Integer = 0

        Dim ws_base_signo_sn As Integer = 0
        Dim ws_base_saldo_sn As Double = 0
        Dim ws_ref_masinfo As String
        IniciarListar("I")
        Mostraroperacion(ENLACE_ENVIO_OPER_CODIGO)

        Dim comboCell As DataGridViewComboBoxCell

        MuestraEstadoComp(5, 0)
        CmdEnviarA.Enabled = False
        CmdTraerDe.Enabled = False
        CmdAanularOper.Enabled = False
        CmdGrabar.Enabled = True

        ws_base_saldo_sn = loc_datos_comp.Rows(0).Item("carterasn_saldo")
        ws_base_signo_sn = loc_datos_comp.Rows(0).Item("signo_sn")
        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        Estado_Operacion_OperMaestro(True)
        If Obtener_id_oper_maestro.Count = 0 Then
            Estado_Operacion_OperMaestro(False)
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            Exit Sub
        End If
        If ws_base_signo_sn <> 0 And Obtener_id_oper_maestro(0)("signo_cuentasn") <> 0 Then
            If loc_datos_comp.Rows(0).Item("total") <> ws_base_saldo_sn Then
                Dim Result As String = MensajesBox.Show("Comprobante Tiene ya Operaciones Asociadas, no procede.",
                                             "Operación.")
                CancelaOper("")
                ES_FORMZAR_CIERRE = 1
                Me.Close()
                Exit Sub

            End If
        End If


        ' local 
        CmdLocal.Text = loc_datos_comp.Rows(0).Item("local_nombre")
        CmdLocal.Tag = loc_datos_comp.Rows(0).Item("id_local")
        TxtLocal.Text = loc_datos_comp.Rows(0).Item("local_codigo")
        CmdLocal.AccessibleName = loc_datos_comp.Rows(0).Item("local_codigo")

        ' Socio de negocio
        TxtSocio_BoxSN.Text = loc_datos_comp.Rows(0).Item("sn_codigo")
        info_SN.Text = loc_datos_comp.Rows(0).Item("sn_boxsn")
        info_SN.Tag = loc_datos_comp.Rows(0).Item("id_sn_master")


        BoxTOT12.Text = loc_datos_comp.Rows(0).Item("id_oper_maestro") & " - " & loc_datos_comp.Rows(0).Item("id_comp_cab")
        TxtEstadoComp.AccessibleDescription = loc_datos_comp.Rows(0).Item("nivel_comp")  ' GUADA EL NIVEL DE DONDE VIENE EL ORIGEL DEL COMPROBANTE

        If Val(loc_datos_comp.Rows(0).Item("tipo_transf_kardex")) = 1 Then ' tipo envio
            Dim wid_almacen_transf As Integer = Val(loc_datos_comp.Rows(0).Item("dt_id_almacen"))
            Dim DatoAlmacen() As DataRow = lk_sql_Usuario_almacen.Select("id_negocio = " & lk_NegocioActivo.id_Negocio & " and id_almacen = " & wid_almacen_transf & "")
            If DatoAlmacen.Length <> 0 Then
                TxtAlmTransf.Text = DatoAlmacen(0)("alm_codigo").ToString.Trim
                TxtAlmTransf.Tag = DatoAlmacen(0)("id_almacen")
                CmdAlmTransf.Text = DatoAlmacen(0)("alm_codigo").ToString.Trim & " " & DatoAlmacen(0)("alm_abreviado").ToString.Trim
                CmdAlmTransf.Tag = DatoAlmacen(0)("id_almacen")
                wvien_id_almacen = DatoAlmacen(0)("id_almacen")
            End If
            wid_almacen_transf = Val(loc_datos_comp.Rows(0).Item("id_almacen_transf"))
            Dim DatoAlmacen_rep() As DataRow = lk_sql_Usuario_almacen.Select("id_negocio = " & lk_NegocioActivo.id_Negocio & " and id_almacen = " & wid_almacen_transf & "")
            If DatoAlmacen_rep.Length <> 0 Then
                recp_alm_codigo = DatoAlmacen_rep(0)("alm_codigo").ToString.Trim
                recp_id_almacen = DatoAlmacen_rep(0)("id_almacen")
                recp_alm_abreviado = DatoAlmacen_rep(0)("alm_abreviado").ToString.Trim
            End If
        End If

        If Val(loc_datos_comp.Rows(0).Item("es_servicio")) = 1 Then
            If Radio_Serv.Checked = False Then
                Radio_Serv.Checked = True
                Gestion_Columnas_PRO01(1) ' 
            End If
        End If
        If Val(loc_datos_comp.Rows(0).Item("es_servicio")) = 0 Then
            If Radio_Prod.Checked = False Then
                Radio_Prod.Checked = True
                Gestion_Columnas_PRO01(0) ' 
            End If
        End If

        ' fechas de emis y proceso
        'TxtFechas_Proc.Value = Format(loc_datos_comp.Rows(0).Item("fecha"), "dd/MM/yyyy")
        'TxtFechas_Emis.Value = Format(loc_datos_comp.Rows(0).Item("fecha_emis"), "dd/MM/yyyy")

        ' nro comprobante POR DEFCTO DEL COMROPBANTE

        '' nro comprobante
        'TxtComp_codigo.Text = loc_datos_comp.Rows(0).Item("comp_codigo")
        'TxtComp_codigo.Tag = loc_datos_comp.Rows(0).Item("id_comprobante")

        'CmdComprob.Text = Space(10) & loc_datos_comp.Rows(0).Item("comp_abreviado")
        'CmdComprob.Tag = loc_datos_comp.Rows(0).Item("id_comprobante")
        'CmdComprob.AccessibleName = loc_datos_comp.Rows(0).Item("comp_codigo")
        'CmdComprob.AccessibleDescription = 0
        '' serire y numero de comprobante
        'CmdSerireComp.Text = loc_datos_comp.Rows(0).Item("serie_comp")
        'CmdSerireComp.Tag = loc_datos_comp.Rows(0).Item("serie_comp")
        'TxtSerireComp.Text = loc_datos_comp.Rows(0).Item("serie_comp")
        'TxtSerireComp.Tag = loc_datos_comp.Rows(0).Item("serie_comp")
        'TxtComp_Numero.Text = Format(loc_datos_comp.Rows(0).Item("numero_comp"), "00000000")





        Dim wsec As Integer = 0
        Dim rea_cadenalote As String

        If Me.GridProductos.Tag = "PROD1" Then


            'If tabla.Rows(0).Item("saldo") = 0 Then
            '    Dim result = MensajesBox.Show("Comprobante sin saldo que aplicar.", lk_cabeza_msgbox)
            '    CancelaOper("")
            '    ES_FORMZAR_CIERRE = 1
            '    Me.Close()
            '    Exit Sub
            'End If

            If loc_datos_comp.Rows.Count = 0 Then Exit Sub
            GridProductos.Columns.Item("cantidad_saldo").Visible = False

            If TxtEstadoComp.AccessibleName = "1" Or TxtEstadoComp.AccessibleName = "2" Then
                GridProductos.Columns.Item("cantidad_saldo").Visible = True
            End If


            Me.GridProductos.Rows.Clear()
            Dim wcantidad As Double = 0
            Dim wcantidad_distrib As Double = 0
            wsec = 0
            For i = 0 To loc_datos_comp.Rows.Count - 1
                If Val(loc_datos_comp.Rows(i).Item("dt_cantidad")) - Val(loc_datos_comp.Rows(i).Item("cantidad_aplicada")) = 0 Then Continue For
                wsec = wsec + 1
                Me.GridProductos.Rows.Add()
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("descrip").Value = loc_datos_comp.Rows(i).Item("dt_nombreproducto")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("codigo").Value = loc_datos_comp.Rows(i).Item("dt_prod_codigo")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_prod_mae_codigo").Value = loc_datos_comp.Rows(i).Item("dt_prod_codigo")

                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("grupo").Value = loc_datos_comp.Rows(i).Item("dt_lab_linea")


                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_prod_mae").Value = loc_datos_comp.Rows(i).Item("id_prod_mae")
                wcantidad = (Val(loc_datos_comp.Rows(i).Item("dt_cantidad")) - Val(loc_datos_comp.Rows(i).Item("cantidad_aplicada"))) / Val(loc_datos_comp.Rows(i).Item("dt_equiv"))
                wcantidad_distrib = (Val(loc_datos_comp.Rows(i).Item("dt_cantidad")) - Val(loc_datos_comp.Rows(i).Item("cantidad_aplicada")))
                'GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("cantidad").Value = Val(loc_datos_comp.Rows(i).Item("dt_cantidad")) - Val(loc_datos_comp.Rows(i).Item("cantidad_aplicada"))
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("cantidad").Value = Format(wcantidad, "#,##0")

                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("cantidad_saldo").Value = wcantidad_distrib '  Val(loc_datos_comp.Rows(i).Item("dt_cantidad")) - Val(loc_datos_comp.Rows(i).Item("cantidad_aplicada"))

                'comboCell = CType(GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("present"), DataGridViewComboBoxCell)
                'comboCell.Items.Clear()
                'comboCell.Items.Add(loc_datos_comp.Rows(i).Item("dt_descrip_pres"))
                'comboCell.Value = loc_datos_comp.Rows(i).Item("dt_descrip_pres")
                ''GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("present").Value = dt_DatosAgrupados.Rows(i).Item("dt_abreviado_pres_def")
                'GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_pres").Value = loc_datos_comp.Rows(i).Item("dt_id_pres")
                'GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("equiv").Value = loc_datos_comp.Rows(i).Item("dt_equiv")

                Dim wpres As String = loc_datos_comp.Rows(i).Item("Unidades")

                Dim valores As List(Of Tuple(Of String, Integer, Integer)) = ConvertirCadena(wpres)
                'Dim comboCell As DataGridViewComboBoxCell
                comboCell = CType(GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("present"), DataGridViewComboBoxCell)
                comboCell.Items.Clear()
                Dim valoresDict As New Dictionary(Of Integer, Tuple(Of String, Integer, Integer)) ' Diccionario para almacenar los valores con su índice
                For t As Integer = 0 To valores.Count - 1
                    If loc_datos_comp.Rows(i).Item("dt_descrip_pres") = valores(t).Item1 Then '  para valir que solo se asocicio la unidad origien y no cambiar a otros equiv
                        comboCell.Items.Add(valores(t).Item1)
                        valoresDict.Add(t, valores(t)) '
                    End If
                Next
                comboCell.Tag = valoresDict
                comboCell.Value = loc_datos_comp.Rows(i).Item("dt_descrip_pres")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_pres").Value = loc_datos_comp.Rows(i).Item("dt_id_pres")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("equiv").Value = loc_datos_comp.Rows(i).Item("dt_equiv")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("present").Value = loc_datos_comp.Rows(i).Item("dt_descrip_pres")

                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("es_control_lote").Value = loc_datos_comp.Rows(i).Item("dt_es_control_lote")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("cadenalotes").Value = loc_datos_comp.Rows(i).Item("dt_loteser_det")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("cadenalotes_formato").Value = loc_datos_comp.Rows(i).Item("dt_loteser_det_formato")
                ws_ref_masinfo = loc_datos_comp.Rows(i).Item("dt_ref_prod_mae").ToString
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle").Tag = ws_ref_masinfo
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle").Value = If(ws_ref_masinfo = "", "", "(*)")


                If Val(loc_datos_comp.Rows(i).Item("dt_es_control_lote")) = "1" Then
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("lote").Value = ""
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("det_lote").Value = "Pulsar [F2] ver detalle Lotes/Serie"
                    Dim wdetid_negocio As Integer = loc_datos_comp.Rows(i).Item("id_negocio")
                    Dim wdetid_oper_maestro As Integer = loc_datos_comp.Rows(i).Item("id_oper_maestro")
                    Dim wdetid_comp_cab As Integer = loc_datos_comp.Rows(i).Item("id_comp_cab")
                    Dim wdetid_comp_det As Integer = loc_datos_comp.Rows(i).Item("id_comp_det")
                    rea_cadenalote = ReasignarLote_Recep(wdetid_negocio, wdetid_oper_maestro, wdetid_comp_cab, wdetid_comp_det)
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("cadenalotes").Value = rea_cadenalote

                Else
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("lote").Value = ""
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("det_lote").Value = "Sin Control de Lotes/Serie"
                End If

                If Val(loc_datos_comp.Rows(0).Item("tipo_transf_kardex")) = 1 Then ' tipo envio el cual viene para la recepcion
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("almacen").Value = recp_alm_codigo
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("lote").Value = ""
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_almacen").Value = recp_id_almacen
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("alm_abreviado").Value = recp_alm_abreviado
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_almacen_trasnf").Value = wvien_id_almacen
                Else

                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("almacen").Value = loc_datos_comp.Rows(i).Item("dt_alm_codigo")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("lote").Value = ""
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_almacen").Value = loc_datos_comp.Rows(i).Item("dt_id_almacen")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("alm_abreviado").Value = loc_datos_comp.Rows(i).Item("dt_alm_abreviado")
                End If
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("es_control_lote").Value = loc_datos_comp.Rows(i).Item("maeprod_es_control_lote")
                If GridProductos.Columns.Item("det_lote").Visible = True Then ' operacion con Ocpiones de Lote 
                    If loc_datos_comp.Rows(i).Item("maeprod_es_control_lote") = 1 Then
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("lote").Value = "..."
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("det_lote").Value = "Pulsar [F2] para definición de lotes"
                    Else
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("lote").Value = ""
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("det_lote").Value = "Sin Control de lotes/series"
                    End If


                End If
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_pres_base").Value = loc_datos_comp.Rows(i).Item("dt_id_pres_base")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("abreviado_base").Value = loc_datos_comp.Rows(i).Item("dt_abreviado_pres_base")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("equiv_base").Value = loc_datos_comp.Rows(i).Item("dt_equiv_base")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("es_inventariable").Value = loc_datos_comp.Rows(i).Item("dt_es_inventariable")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("es_exonerado").Value = loc_datos_comp.Rows(i).Item("dt_es_exonerado")

                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_comp_det_emlace").Value = loc_datos_comp.Rows(i).Item("id_comp_det") ' Identifica la Fila del documento




                If Val(loc_datos_comp.Rows(0).Item("es_servicio")) = 1 Then  ' solo para tipo productos 
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("detalle_serv").Value = ws_ref_masinfo
                End If
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_tb_tipo_serv").Value = loc_datos_comp.Rows(i).Item("id_tb_tipo_serv")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_serv").Value = loc_datos_comp.Rows(i).Item("id_serv")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_area").Value = loc_datos_comp.Rows(i).Item("id_area")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_uci").Value = loc_datos_comp.Rows(i).Item("id_uci")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_local_serv").Value = loc_datos_comp.Rows(i).Item("id_local_serv")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("tipo_serv_des").Value = loc_datos_comp.Rows(i).Item("tipo_serv_des")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("codigo_serv").Value = loc_datos_comp.Rows(i).Item("codigo_serv")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("des_serv").Value = loc_datos_comp.Rows(i).Item("des_serv")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("area_serv_des").Value = loc_datos_comp.Rows(i).Item("area_serv_des")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("uci_serv_des").Value = loc_datos_comp.Rows(i).Item("uci_serv_des")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("codigo_local_serv").Value = loc_datos_comp.Rows(i).Item("codigo_local_serv")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("des_local_serv").Value = loc_datos_comp.Rows(i).Item("des_local_serv")

                ' Valores del comprobante
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("preciobase").Value = loc_datos_comp.Rows(i).Item("dt_precio")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("des1").Value = ""
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("des2").Value = ""
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("impto").Value = loc_datos_comp.Rows(i).Item("dt_impto")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("subtotal").Value = loc_datos_comp.Rows(i).Item("dt_subtotal")


                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("ok").Value = My.Resources.bloq
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("ok").Tag = "bloq2"
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("num_sec").Value = wsec
            Next
            If loc_datos_comp(0)("modo_calculo") = 1 Then
                chkConIMPTO.Checked = True
                AsignarModoCalculo_GridPROD1(1)
            End If
            If loc_datos_comp(0)("modo_calculo") = 2 Then
                chkSinIMPTO.Checked = True
                AsignarModoCalculo_GridPROD1(2)
            End If

            If wsec = 0 Then ' no hay nada por generar cierra formlario
                Dim Result As String = MensajesBox.Show("Documento Cerrado no hay saldo pendientes por aplicar.",
                                             "Operación.")
                CancelaOper("")

                ES_FORMZAR_CIERRE = 1
                Me.Close()
                Exit Sub
            End If

            'Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("descrip")

            Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("eli").Tag = "ppp"
            If loc_datos_comp(0)("modo_calculo") = 1 Then
                chkConIMPTO.Checked = True
                AsignarModoCalculo_GridPROD1(1)
            End If
            If loc_datos_comp(0)("modo_calculo") = 2 Then
                chkSinIMPTO.Checked = True
                AsignarModoCalculo_GridPROD1(2)
            End If
            Contador_filas()
            Calcula_PROD1(Val(GridProductos.AccessibleDescription))


            DataSeleccion.Columns.Clear()
            DataSeleccion.Columns.Add("id_negocio", GetType(Integer))
            DataSeleccion.Columns.Add("id_enlace", GetType(Integer))
            DataSeleccion.Columns.Add("numsec", GetType(Integer))
            DataSeleccion.Columns.Add("id_local_base", GetType(Integer))
            DataSeleccion.Columns.Add("id_oper_maestro_base", GetType(Integer))

            DataSeleccion.Columns.Add("tipo_comp", GetType(String))
            DataSeleccion.Columns.Add("serie_comp", GetType(String))
            DataSeleccion.Columns.Add("numero_comp", GetType(String))

            DataSeleccion.Columns.Add("id_comp_cab_base", GetType(Integer))
            DataSeleccion.Columns.Add("id_comp_det_base", GetType(Integer))
            DataSeleccion.Columns.Add("id_almacen_base", GetType(Integer))
            DataSeleccion.Columns.Add("fecha", GetType(DateTime))
            DataSeleccion.Columns.Add("id_prod_mae", GetType(Double))
            DataSeleccion.Columns.Add("codigo_prod_mae", GetType(String))
            DataSeleccion.Columns.Add("nombre_prod_mae", GetType(String))
            DataSeleccion.Columns.Add("cantidad", GetType(Double))
            DataSeleccion.Columns.Add("equiv", GetType(Integer))
            DataSeleccion.Columns.Add("descrip_pres", GetType(String))
            DataSeleccion.Columns.Add("id_pres", GetType(Integer))
            DataSeleccion.Columns.Add("signo_kardex", GetType(Integer))
            DataSeleccion.Columns.Add("id_local_dest", GetType(Integer))
            DataSeleccion.Columns.Add("id_oper_maestro_dest", GetType(Integer))
            DataSeleccion.Columns.Add("id_comp_cab_dest", GetType(Integer))
            DataSeleccion.Columns.Add("situacion", GetType(Integer))
            DataSeleccion.Columns.Add("estado", GetType(Integer))
            DataSeleccion.Columns.Add("dt_abreviado_pres_base", GetType(String))
            DataSeleccion.Columns.Add("dt_id_pres_base", GetType(Integer))
            DataSeleccion.Columns.Add("dt_equiv_base", GetType(Integer))
            DataSeleccion.Columns.Add("nivel_comp", GetType(Integer))
            DataSeleccion.Columns.Add("id_sn_master", GetType(Integer))
            DataSeleccion.Columns.Add("sn_codigo", GetType(String))
            DataSeleccion.Columns.Add("sn_boxsn", GetType(String))



            Dim DetalleComp() As DataRow = loc_datos_comp.Select("id_negocio <>0 ")
            If DetalleComp.Length = 0 Then
                Dim Result As String = MensajesBox.Show("Existe un Problema de Conexion Intentar mas tarde.",
                                             "Operación.")
                Exit Sub
            End If

            wsec = 0
            For Each row As DataRow In DetalleComp

                If Val(row("dt_cantidad")) - Val(row("cantidad_aplicada")) = 0 Then Continue For

                wsec = wsec + 1
                Dim addrow As DataRow = DataSeleccion.NewRow()

                addrow.Item("id_negocio") = row("id_negocio")
                addrow.Item("id_enlace") = 1
                addrow.Item("numsec") = wsec
                addrow.Item("id_local_base") = row("id_local")
                addrow.Item("id_oper_maestro_base") = row("id_oper_maestro")

                addrow.Item("tipo_comp") = row("comp_abreviado")
                addrow.Item("serie_comp") = row("serie_comp")
                addrow.Item("numero_comp") = Format(row("numero_comp"), "00000000")
                addrow.Item("id_comp_cab_base") = row("id_comp_cab")
                addrow.Item("id_comp_det_base") = row("id_comp_det")
                addrow.Item("id_almacen_base") = row("dt_id_almacen")
                addrow.Item("fecha") = row("fecha")
                addrow.Item("id_prod_mae") = row("id_prod_mae")
                addrow.Item("codigo_prod_mae") = row("dt_prod_codigo")
                addrow.Item("nombre_prod_mae") = row("dt_nombreproducto")
                addrow.Item("cantidad") = Val(row("dt_cantidad")) - Val(row("cantidad_aplicada"))
                addrow.Item("equiv") = row("dt_equiv")
                addrow.Item("descrip_pres") = row("dt_descrip_pres")
                addrow.Item("id_pres") = row("dt_id_pres")
                addrow.Item("signo_kardex") = 1
                addrow.Item("id_local_dest") = 0
                addrow.Item("id_oper_maestro_dest") = 0
                addrow.Item("id_comp_cab_dest") = 0
                addrow.Item("situacion") = 1
                addrow.Item("estado") = 1
                addrow.Item("dt_abreviado_pres_base") = row("dt_abreviado_pres_base")
                addrow.Item("dt_id_pres_base") = row("dt_id_pres_base")
                addrow.Item("dt_equiv_base") = row("dt_equiv_base")

                addrow.Item("nivel_comp") = row("nivel_comp")
                addrow.Item("id_sn_master") = row("id_sn_master")
                addrow.Item("sn_codigo") = row("sn_codigo")
                addrow.Item("sn_boxsn") = row("sn_boxsn")


                DataSeleccion.Rows.Add(addrow)

            Next

            dt_DatosEnlace_oper = DataSeleccion


        End If


        If dg_cuentasn.Visible And dg_cuentasn.Tag = "CTASN1" Then

            'BoxTOT12.Text = loc_datos_comp.Rows(0).Item("id_oper_maestro") & " - " & loc_datos_comp.Rows(0).Item("id_comp_cab")
            TxtEstadoComp.AccessibleDescription = loc_datos_comp.Rows(0).Item("nivel_comp")  ' GUADA EL NIVEL DE DONDE VIENE EL ORIGEL DEL COMPROBANTE

            Dim sql As String = "exec [sp_muestra_carterasn] @id_negocio, @tipo_balance, @codigo_comp ,@serie_comp, @numero_comp, @es_oper_maestro ,@id_oper_maestro, @id_comp_cab"
            Dim command As New SqlCommand(sql, lk_connection_cuenta)
            command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
            command.Parameters.AddWithValue("@tipo_balance", Val(dg_cuentasn.AccessibleDescription))
            command.Parameters.AddWithValue("@codigo_comp", "")
            command.Parameters.AddWithValue("@serie_comp", "")
            command.Parameters.AddWithValue("@numero_comp", 0)
            command.Parameters.AddWithValue("@es_oper_maestro", 1)
            command.Parameters.AddWithValue("@id_oper_maestro", loc_datos_comp.Rows(0).Item("id_oper_maestro"))
            command.Parameters.AddWithValue("@id_comp_cab", loc_datos_comp.Rows(0).Item("id_comp_cab"))


            Dim adapter As New SqlDataAdapter(command)
            Dim tabla As New DataTable()
            adapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                Exit Sub
            End If

            If tabla.Rows(0).Item("saldo") = 0 Then
                Dim result = MensajesBox.Show("Comprobante sin saldo que aplicar.", lk_cabeza_msgbox)
                CancelaOper("")
                ES_FORMZAR_CIERRE = 1
                Me.Close()
                Exit Sub
            End If


            Me.dg_cuentasn.Rows.Clear()
            wsec = 0
            wsec = wsec + 1
            Me.dg_cuentasn.Rows.Add()

            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("codcomp").Value = loc_datos_comp.Rows(0).Item("comp_codigo")
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("seriecomp").Value = loc_datos_comp.Rows(0).Item("serie_comp")
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("numerocomp").Value = loc_datos_comp.Rows(0).Item("numero_comp")


            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("aplicar").Value = tabla.Rows(0).Item("saldo")

            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("codigo").Value = tabla.Rows(0).Item("sn_codigo").ToString
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("descrip").Value = tabla.Rows(0).Item("sn_razonsocial").ToString.Trim
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("masdetalle").Value = "..." 'tabla.Rows(0).Item("Codigo").ToString
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("fechaemis").Value = Format(tabla.Rows(0).Item("fecha_emis"), "dd/MM/yyyy")
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("local").Value = tabla.Rows(0).Item("local_codigo").ToString & " " & tabla.Rows(0).Item("local_abreviado").ToString
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("moneda").Value = tabla.Rows(0).Item("mod_simbolo").ToString
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("monto").Value = tabla.Rows(0).Item("total")
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("saldo").Value = tabla.Rows(0).Item("saldo")
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("fechavcto").Value = Format(tabla.Rows(0).Item("fecha_vcto"), "dd/MM/yyyy")
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("condicion").Value = tabla.Rows(0).Item("oper_nom_tipooper")
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("vendedor").Value = ""
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("hecho").Value = tabla.Rows(0).Item("usuario").ToString.Trim & " " & tabla.Rows(0).Item("nombres").ToString.Trim & " " & tabla.Rows(0).Item("apellidos").ToString.Trim
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("fechahora").Value = tabla.Rows(0).Item("fechahora").ToString.Trim

            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("id_oper_maestro").Value = tabla.Rows(0).Item("id_oper_maestro")
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("id_comp_cab").Value = tabla.Rows(0).Item("id_comp_cab")
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("id_carterasn_cab").Value = tabla.Rows(0).Item("id_carterasn_cab")
            dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("id_carterasn_det").Value = tabla.Rows(0).Item("id_carterasn_det")

            Contador_filas_cuentaSN()
            Calcula_CTASN1(1)
        End If





    End Sub
    Public Function ReasignarLote_Recep(ws_id_negocio As Integer, ws_id_oper_maestro As Integer, ws_id_comp_cab As Integer, ws_id_comp_det As String) As String
        Dim dt As DataTable
        Dim sql As String = "exec [sp_traer_lote_recep] " & ws_id_negocio & "," & ws_id_oper_maestro & "," & ws_id_comp_cab & "," & ws_id_comp_det & ""
        Dim command As New SqlCommand(sql, lk_connection_cuenta)
        Dim adapter As New SqlDataAdapter(command)

        dt = New DataTable()
        adapter.Fill(dt)


        'Dim Loc_lotes() As DataRow = datos_sql_resul.Select("saldo  <> 0 ")

        Dim detalle As String = ""
        For Each row As DataRow In dt.Rows
            For Each cell As DataColumn In dt.Columns
                If Not row.IsNull(cell) AndAlso Not TypeOf row(cell) Is Byte() Then
                    If TypeOf row(cell) Is Date Then
                        detalle &= "" & Format(CDate(row(cell)), "dd/MM/yyyy") & "#"
                    Else
                        detalle &= row(cell).ToString() & "#"
                    End If
                Else
                    detalle &= "0" & "#"
                End If
            Next
            detalle = detalle.TrimEnd("#"c) & ";" ' Separador de filas
        Next
        ReasignarLote_Recep = detalle


    End Function
    Public Sub Iniciar_NEgocio_Activo(wid_negocio)

        ' lk_NegocioActivo.id_Negocio

    End Sub
    Private Sub Iniciar_Oper()
        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        CmdEnlacesComp.Enabled = False
        BoxTienda.Visible = False
        BoxSocioNego.Visible = False
        BoxContacto.Visible = False
        BoxDirEntrega.Visible = False
        BoxMoneda.Visible = False
        BoxDocIntOper.Visible = False
        BoxFechas.Visible = False
        BoxComprobantes.Visible = False
        BoxCondicion.Visible = False
        BoxAtencion.Visible = False
        BoxAlmTransf.Visible = False
        BoxVendedor.Visible = False
        BoxEntidadF.Visible = False
        BoxDirCobro.Visible = False
        BoxEstado.Visible = False
        BoxGuiaAuto.Visible = False
        BoxTipoInterfaz.Visible = False
        BoxGridPROD1.Visible = False
        BoxEstadoSN.Visible = False
        BoxDocCanje.Visible = False
        BoxLineaCredito.Visible = False
        BoxLineaCredito.Visible = False
        BoxRefComp.Visible = False
        tref_codigo.Text = ""
        tref_fecha.Text = ""
        tref_numero.Text = ""
        tref_serie.Text = ""

        lc_monto.Text = ""
        lc_dias.Text = ""
        lblEti_lc.Text = ""
        lblEti_lc.Tag = 0
        txt_diaslc.Text = ""
        lbl_estado_lc.Text = ""


        link_saldo.Text = ""
        link_saldo.Tag = 0 ' es_carterasn 
        link_saldo.AccessibleName = 0  ' signo_carterasn 
        link_saldo.AccessibleDescription = 0
        dg_cuentasn.AccessibleDescription = 0
        CmdSubOper.Text = ""
        CmdSubOper.Tag = ""
        CmdTipoOper.Text = ""
        CmdTipoOper.Tag = ""
        CmdOperacion.Text = ""
        CmdOperacion.Tag = ""
        TxtOperacion.Text = ""
        TxtOperacion.Tag = ""
        TxtSocio_BoxSN.Text = ""
        info_SN.Text = ""
        CmdOperacion.AccessibleDescription = ""
        CmdAlmTransf.Tag = ""
        CmdAlmTransf.Text = ""
        TxtAlmTransf.Tag = ""
        TxtAlmTransf.Text = ""
        TxtDetallefn.AccessibleDescription = ""
        TxtDetallefn.AccessibleName = ""
        CmdActivarEdi.Text = Strings.Space(20)
        CmdActivarEdi.Tag = 0
        CmdActivarEdi.Enabled = False


        For Each ctrl As Control In PanelPie.Controls
            If TypeOf ctrl Is Label Then
                ctrl.Text = ""
                ctrl.Tag = ""
                ctrl.AccessibleName = ""
                ctrl.Visible = False
            End If
        Next

        TxtComp_codigo.Text = ""
        TxtComp_codigo.Tag = 0
        CmdComprob.Text = ""
        CmdComprob.Tag = 0
        CmdComprob.AccessibleName = ""
        CmdComprob.AccessibleDescription = ""

        TxtDocOper.Text = ""
        TxtSerieDocOper.Text = ""
        TxtNumDocOper.Text = ""

        CmdSerireComp.Text = ""
        CmdSerireComp.Tag = 0
        TxtSerireComp.Text = ""
        TxtSerireComp.Tag = 0
        TxtComp_Numero.Text = ""
        TxtEstadoComp.AccessibleDescription = "" '  inicializa nivel del comprobante origen 

        CmdTraerDe.Tag = "" 'limpiar


        ' Parabuscar control 
        'Dim controlLabel As Label = Panel1.Controls.Find("NombreControl", True).FirstOrDefault()

        'If controlLabel IsNot Nothing Then
        '    controlLabel.Text = ""
        '    controlLabel.Visible = True
        'End If

        dt_DatosFinanzas_oper = New DataTable()



        TxtOperacion.Select()


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
        formSize = Me.Size
        WindowState = FormWindowState.Minimized
        FrmLogin.PanelIndicadores.SendToBack()
        FrmLogin.IndicadorGrafico.SendToBack()
        Me.BringToFront()
        Me.Text = TxtOperacion.Text
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

    'Private Sub CmbBuscar_Click(sender As Object, e As EventArgs)
    '    'Dim frPermisoUsuarios As New FrmBuscadores
    '    'PlaySonidoMouse(lk_CodigoSonido)
    '    ''frPermisoUsuarios.Width = 950
    '    'frPermisoUsuarios.Top = Me.Top - 20
    '    'frPermisoUsuarios.Left = Me.Left - 20
    '    'frPermisoUsuarios.Show()
    '    'frPermisoUsuarios.TopLevel = False
    '    'Panel26.Controls.Add(frPermisoUsuarios)
    '    'FrmProductos.ActiveControl
    '    'FrmProductos.IrFocis1()

    '    'Me.ActiveControl = FrmProductos.TxtBuscar
    '    'FrmProductos.IrFocis1()
    '    frPermisoUsuarios.Activate()
    '    frPermisoUsuarios.TxtBuscar.Text = ""
    '    frPermisoUsuarios.TxtBuscar.Select()
    '    frPermisoUsuarios.TxtBuscar.Focus()
    '    'Me.SelectNextControl(FrmProductos.TxtBuscar, True, True, True, True)

    '    ' TextBox2.Select()
    '    ' TextBox2.Focus()
    '    BoxSocioNego.Location = New Point(17, 12)


    'End Sub



    Private Sub CmdOperacion_Click(sender As Object, e As EventArgs) Handles CmdOperacion.Click


        Dim grupos As New List(Of String)()

        For Each fila As DataRow In lk_sql_listaOperMenu.Rows
            Dim grupo As String = fila("grupo")

            If Not grupos.Contains(grupo) Then
                grupos.Add(grupo)
            End If
        Next

        Dim menu As New ToolStripDropDownMenu()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'menu.AutoSize = False
        'menu.Width = CmdOperacion.Width
        ' menu.Height = CmdOperacion.Height


        For Each grupo As String In grupos
            Dim subMenu As New ToolStripMenuItem(grupo)

            For Each fila As DataRow In lk_sql_listaOperMenu.Rows
                If fila("grupo") = grupo Then
                    Dim detalle As String = fila("detalle")
                    Dim id As Integer = Convert.ToInt32(fila("codigo"))
                    Dim detalleItem As New ToolStripMenuItem(detalle)
                    detalleItem.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
                    detalleItem.ForeColor = Color.White
                    'detalleItem.AutoSize = False
                    'detalleItem.Width = CmdOperacion.Width
                    'detalleItem.Height = CmdOperacion.Height


                    ' Asociar el Id con el elemento del submenú
                    detalleItem.Tag = id

                    ' Agregar un controlador de eventos para el elemento del submenú
                    AddHandler detalleItem.Click, AddressOf Detalle_Click

                    subMenu.DropDownItems.Add(detalleItem)
                End If
            Next

            menu.Items.Add(subMenu)
        Next

        menu.Show(CmdOperacion, New Point(0, CmdOperacion.Height))


    End Sub
    Private Sub Detalle_Click(sender As Object, e As EventArgs)
        Dim Codigooper As Integer = Convert.ToInt32(DirectCast(sender, ToolStripMenuItem).Tag)
        ' Se Limpia variables relacidas
        Limpieza_variables_Relacionados()

        Mostraroperacion(Codigooper)
    End Sub

    Private Sub TxtOperacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtOperacion.KeyPress
        e.Handled = Solo_Numero(e)


        If e.KeyChar = Chr(13) Then
            CmdBusoper_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub Valida_opereacion(wcodigo As String)

        Dim Result As String
        If Len(wcodigo) <> 4 Then
            Exit Sub
        End If

        Dim ListaOperacion() As DataRow = lk_sql_listaOperBox.Select("CodigoOper = '" & wcodigo & "'")
        ' Recorremos las filas filtradas
        If ListaOperacion.Length = 0 Then
            Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                                     "Operación.")
            Exit Sub
        End If
        Txt_Operacion_filtro.Text = ListaOperacion(0)("CodigoOper")
        Txt_Operacion_filtro.Tag = ListaOperacion(0)("id_tb_oper")
        CmdOperacion_filtro.Text = ListaOperacion(0)("DescripOper")
        CmdOperacion_filtro.Tag = ListaOperacion(0)("id_tb_oper")


    End Sub
    Private Sub Mostraroperacion(wcodigo As String)

        Dim Result As String
        If Len(wcodigo) <> 4 Then
            Exit Sub
        End If
        'CancelaOper("")

        Dim ListaOperacion() As DataRow = lk_sql_listaOperBox.Select("CodigoOper = '" & wcodigo & "'")
        ' Recorremos las filas filtradas
        If ListaOperacion.Length = 0 Then
            Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                                     "Operación.")
            Exit Sub
        End If


        Iniciar_Oper()
        TxtOperacion.Text = ListaOperacion(0)("CodigoOper")
        TxtOperacion.Tag = ListaOperacion(0)("id_tb_oper")
        CmdOperacion.Text = ListaOperacion(0)("DescripOper")
        CmdOperacion.Tag = ListaOperacion(0)("id_tb_oper")
        Dim wcolorOper As String = ListaOperacion(0)("color_oper")
        If wcolorOper <> "" Then
            PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(wcolorOper)
        End If

        Dim ListaSubOperacion() As DataRow = lk_sql_listaSubOper.Select("id_tb_oper = '" & CmdOperacion.Tag & "'")
        ' Recorremos las filas filtradas
        If ListaSubOperacion.Length = 0 Then
            Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                                     "Operación.")
            Exit Sub
        End If
        CmdSubOper.Text = ListaSubOperacion(0)("descrip_suboper")
        CmdSubOper.Tag = ListaSubOperacion(0)("id_tb_suboper")

        Dim ListaTipoOperacion() As DataRow = lk_sql_listaTipoOper.Select("id_tb_oper = '" & CmdOperacion.Tag & "'")
        ' Recorremos las filas filtradas
        If ListaTipoOperacion.Length = 0 Then
            Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                                     "Operación.")
            Exit Sub
        End If
        CmdTipoOper.Text = ListaTipoOperacion(0)("descrip_tipooper")
        CmdTipoOper.Tag = ListaTipoOperacion(0)("id_tb_tipooper")

        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        If Obtener_id_oper_maestro.Count = 0 Then
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            Exit Sub
        End If


        PanelDEtalle.Visible = False
        PanelDEtalle.Refresh()




        IniciaPantallaOperaciones()
        TipoySeries_Pordefecto()

        Muestra_Box(wcodigo, CmdOperacion.Tag)
        Bloqueo_Estado_Box(0) ' inicia si bloqeuo






        Dim currentDate As DateTime = lk_fecha_dia
        'TxtFechas_Proc.MinDate = Format(currentDate, "dd/MM/yyyy")
        'TxtFechas_Proc.MinDate = Format(currentDate, "dd/MM/yyyy")
        'TxtFechas_Proc.MaxDate = Format(currentDate, "dd/MM/yyyy")
        TxtFechas_Proc.Value = Format(currentDate, "dd/MM/yyyy")
        TxtFechas_Emis.Value = Format(currentDate, "dd/MM/yyyy")
        TxtCondi_FecVcto.Value = Format(currentDate, "dd/MM/yyyy")


        TxtPrioridad_FecAten.Value = Format(currentDate, "dd/MM/yyyy")

        MuestraEstadoComp(0, 0) ' CREANDO



        CmdGrabar.Enabled = True
        CmdAanularOper.Enabled = False
        CmdEnviarA.Enabled = False
        CmdTraerDe.Enabled = True
        CmdConsultaReg.Visible = True


        Dim wtipo_transf_kardex As Integer = Obtener_id_oper_maestro(0)("tipo_transf_kardex")

        If wtipo_transf_kardex = 1 And LblAlmTransf.Visible Then
            LblAlmTransf.Text = "ENVIO AL ALMACEN"
        ElseIf wtipo_transf_kardex = 2 And LblAlmTransf.Visible Then
            LblAlmTransf.Text = "RECEPCION  DEL ALMACEN"
        End If

        Actualiza_Oper_Maestro()



        'Dim frMenuProductos As New FrmProductos
        'PlaySonidoMouse(lk_CodigoSonido)
        'frMenuProductos.Show()
        'frMenuProductos.TopLevel = False
        'PanelFormularios.Controls.Add(frMenuProductos)

        'frMenuProductos.Left = 10
        'frMenuProductos.Top = 10
        'PanelFormularios.Controls.Item(PanelFormularios.Controls.Count - 1).BringToFront() ' Ultimo Fomulario a primer plano
        'SelectNextControl(ActiveControl, True, True, True, True)
        PanelDEtalle.Visible = True
        PanelDEtalle.Refresh()
    End Sub
    Public Sub TipoySeries_Pordefecto()
        Dim Result As String

        Dim LocalPorDefecto() As DataRow = lk_sql_Locales_Activos.Select("id_local = " & lk_LocalActivo.id_local & "")

        If LocalPorDefecto.Length = 0 Then
            Result = MensajesBox.Show("No cuenta con Local activo.",
                                     "Operación.")
            Me.Close()
            Exit Sub
        End If

        CmdLocal.Text = LocalPorDefecto(0)("nombre")
        CmdLocal.Tag = LocalPorDefecto(0)("id_local")
        TxtLocal.Text = LocalPorDefecto(0)("codigo")
        TxtLocal.Tag = LocalPorDefecto(0)("id_local")
        CmdLocal.AccessibleName = LocalPorDefecto(0)("codigo")


        CmdComprob.Text = ""
        CmdComprob.Tag = ""
        CmdComprob.AccessibleName = ""
        CmdComprob.AccessibleDescription = ""

        Dim Comprobantes() As DataRow = lk_sql_comp_oper.Select("id_tb_oper = " & TxtOperacion.Tag & " And es_interno = 0 ")
        ' Recorremos las filas filtradas
        If Comprobantes.Length = 0 Then
            CancelaOper("")
            SMS_Barra("Operacion sin Definicion de Comprobantes. Debe ir a configuracion de la tienda y crearlo", 3)
            Exit Sub
        End If
        TxtComp_codigo.Text = Comprobantes(0)("codigo")
        TxtComp_codigo.Tag = Comprobantes(0)("id_comprobante")

        CmdComprob.Text = Space(10) & Comprobantes(0)("abreviado")
        CmdComprob.Tag = Comprobantes(0)("id_comprobante")
        CmdComprob.AccessibleName = Comprobantes(0)("codigo")
        CmdComprob.AccessibleDescription = Comprobantes(0)("es_manual")


        Dim Comprobantes_Internos() As DataRow = lk_sql_comp_oper.Select("id_tb_oper = " & TxtOperacion.Tag & " And es_interno = 1 ")
        ' Recorremos las filas filtradas
        If Comprobantes_Internos.Length = 0 Then
            CancelaOper("")
            SMS_Barra("Operacion sin Definicion de Documentos Internos. Debe ir a configuracion del Negocio", 3)
            Exit Sub
        End If
        TxtDocOper.Text = Comprobantes_Internos(0)("codigo") & " " & Comprobantes_Internos(0)("abreviado")
        TxtDocOper.Tag = Comprobantes_Internos(0)("id_comprobante")



        PordefectoSerie(Val(CmdLocal.Tag), Val(CmdComprob.Tag))





        PorDefectoSerieInterno(Val(TxtDocOper.Tag))





        Dim Monedas() As DataRow = lk_sql_monedas_negocio.Select("id_negocio<> 0 and es_monedalocal= 1")
        ' Recorremos las filas filtradas
        If Monedas.Length = 0 Then
            Exit Sub
        End If
        CmdMonedaComp.Text = Monedas(0)("simbolo") & " " & Monedas(0)("nom_moneda") & " (" & Monedas(0)("abreviado").ToString.Trim & ")"
        CmdMonedaComp.Tag = Monedas(0)("id_moneda")
        CmdMonedaComp.AccessibleName = Monedas(0)("simbolo")
        CmdMonedaComp.AccessibleDescription = Monedas(0)("es_monedalocal")



        Dim ListaPrio() As DataRow = lk_sql_ListaTablas.Select("id_tipotabla = 75")
        ' Recorremos las filas filtradas
        If ListaPrio.Length = 0 Then
            CmdPrioridad.Text = ""
            CmdPrioridad.Tag = ""
            Exit Sub
        End If
        CmdPrioridad.Text = ListaPrio(0)("descripcion")
        CmdPrioridad.Tag = ListaPrio(0)("id_tb")



    End Sub

    Private Sub Muestra_Box(wcodigo As String, id_tb_oper As String)
        Dim wpos As String = ""
        Dim wpos_x As Integer = 0
        Dim wpos_y As Integer = 0
        Dim wprimer_enfoque As String = ""
        Dim Result As String
        Dim wtag_control As String
        Dim PanelBox As Panel
        Dim ListaOperacionBox() As DataRow = lk_sql_listaOperBox.Select("CodigoOper = '" & wcodigo & "'", "orden ASC")
        ' Recorremos las filas filtradas

        If ListaOperacionBox.Length = 0 Then
            Result = MensajesBox.Show("No asignado la Operacion sin BOX .",
                                     "Operación.")
            Exit Sub
        End If

        BoxModoCanculo.Visible = False
        BoxServicios.Visible = False
        CmdZonaDetalle.Enabled = False
        CmdMasDetalles.Enabled = False
        CmdAdjuntos.Enabled = False

        ' Panel de Cabecera buscar controles 
        For i = 0 To ListaOperacionBox.Length - 1
            wtag_control = ListaOperacionBox(i)("codigo_box")
            'If wtag_control = "39" Then Stop
            PanelBox = PanelCabecera.Controls.OfType(Of Panel).FirstOrDefault(Function(c) c.Tag = wtag_control)

            If PanelBox IsNot Nothing Then
                wpos = ListaOperacionBox(i)("ubica_xy")
                wpos_x = Val(Mid(wpos, 1, 4))
                wpos_y = Val(Mid(wpos, 6, 4))
                If wpos_x = 0 Or wpos_y = 0 Then
                Else
                    PanelBox.Location = New Point(wpos_x, wpos_y)
                End If
                PanelBox.AccessibleName = ListaOperacionBox(i)("codigo_salta") '  Guarda a ba al siguiente control
                PanelBox.Visible = True
                'If PanelBox.Tag = "38" Then Stop
                If PanelBox.Tag = "37" Then 'grid decanjes de LE y otros
                    PanelBox.Visible = True
                    Me.dg_doc_canje.Tag = "CAJELE"
                    Me.dg_doc_canje.AccessibleName = id_tb_oper
                    Me.dg_doc_canje.Visible = True
                    GridCuentasn_Inicia_DOC_CANJE(0, 0, 0)
                End If
                If PanelBox.Tag = "38" Then 'Opciones de Linea de Crediot Cleintes
                    CmdOpcionesLC.Tag = "1"
                    CmdOpcionesLC.Text = "AUMENTAR"

                End If


                If wprimer_enfoque = "" Then wprimer_enfoque = wtag_control
            End If
        Next

        ' Panel de detalles buscar controles 
        For i = 0 To ListaOperacionBox.Length - 1
            wtag_control = ListaOperacionBox(i)("codigo_box")
            PanelBox = ZonaDetalle.Controls.OfType(Of Panel).FirstOrDefault(Function(c) c.Tag = wtag_control)
            If PanelBox IsNot Nothing Then

                If PanelBox.Tag = "30" Then 'grid de mercaderia
                    PanelBox.Visible = True
                    PanelBox.Dock = DockStyle.Fill
                    Me.GridProductos.Tag = "PROD1"
                    Me.GridProductos.AccessibleName = id_tb_oper
                    Me.GridProductos.Visible = True
                    CmdZonaDetalle_Click(Nothing, Nothing)
                    GridProductos_Inicia_PROD1(Val(ListaOperacionBox(i)("es_opcional_lote")), Val(ListaOperacionBox(i)("es_condesc1")), Val(ListaOperacionBox(i)("es_condesc2")))
                    Radio_Prod.Checked = True
                    Gestion_Columnas_PRO01(0) '  - Por Defcto vista de productos 
                    GridProductos_PrimeraFila()
                    'PanelBox.Visible = True
                    BoxModoCanculo.Visible = True
                    BoxServicios.Visible = True
                    CmdZonaDetalle.Enabled = True
                    CmdMasDetalles.Enabled = True
                    CmdAdjuntos.Enabled = True
                    PanelBox.Refresh()
                End If
                If PanelBox.Tag = "36" Then 'grid de comp cuentasn
                    PanelBox.Visible = True
                    PanelBox.Dock = DockStyle.Fill
                    Me.dg_cuentasn.Tag = "CTASN1"
                    Me.dg_cuentasn.AccessibleName = id_tb_oper
                    Me.dg_cuentasn.Visible = True
                    CmdZonaDetalle_Click(Nothing, Nothing)
                    GridCuentasn_Inicia_CTASN1(Val(ListaOperacionBox(i)("es_opcional_lote")), Val(ListaOperacionBox(i)("es_condesc1")), Val(ListaOperacionBox(i)("es_condesc2")))
                    dg_cuentasn_PrimeraFila()

                End If

            End If
        Next


        CmdOperacion.AccessibleDescription = wprimer_enfoque
        SaltoBox(wprimer_enfoque)

    End Sub
    Private Sub SaltoBox(w_enfoca_a As String)
        Select Case w_enfoca_a
            Case "01"
                TxtLocal.Select()
                TxtLocal.Focus()
            Case "02"
                TxtSocio_BoxSN.Select()
                TxtSocio_BoxSN.Focus()
            Case "03"
            Case "04"
            Case "05"
                CmdMonedaComp.Select()
                CmdMonedaComp.Focus()
            Case "06"
            Case "07"
                TxtFechas_Emis.Select()
                TxtFechas_Emis.Focus()
            Case "08"
                TxtComp_codigo.Select()
                TxtComp_codigo.Focus()
            Case "09"
                TxtPrioridad_FecAten.Select()
                TxtPrioridad_FecAten.Focus()
            Case "10"
                'CmbCondi_Lista.Select()
                txt_diaslc.Focus()
            Case "11"

            Case "12"

            Case "13"

            Case "14"
                TxtVendedor_Codigo.Select()
                TxtVendedor_Codigo.Focus()
            Case "30"
                If GridProductos.Columns("codigo").Visible Then
                    Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("codigo")
                    Me.GridProductos.BeginEdit(True)
                ElseIf GridProductos.Columns("tipo_serv_des").Visible Then
                    Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("tipo_serv_des")
                End If
                Contador_filas()

        End Select

    End Sub
    Private Sub IniciarListar(wflag As String)
        If wflag = "I" Then
            CmdListaoper.Visible = True
            LblListar.Visible = True
            CmdIniciarOper.Visible = False
            LBLIniciar.Visible = False

            PanelListarOper.Visible = False
            CmdAccoper.Visible = True
            CmdAccesoSuboper.Visible = True
            CmdAccTipo.Visible = True
            CmdBusoper.Visible = True
            TxtOperacion.Visible = True
            CmdOperacion.Visible = True
            CmdSubOper.Visible = True
            CmdTipoOper.Visible = True
            TxtOperacion.Select()
            TxtOperacion.Focus()
            TxtOperacion.Text = ""
            TxtOperacion.Tag = ""
            CmdOperacion.Tag = ""
            CmdOperacion.Text = ""
            CmdSubOper.Text = ""
            CmdSubOper.Tag = ""
            CmdTipoOper.Text = ""
            CmdTipoOper.Tag = ""
            PanelCentral.Dock = DockStyle.None
            PanelCentral.Visible = False


        ElseIf wflag = "L" Then
            CmdListaoper.Visible = False
            LblListar.Visible = False
            CmdIniciarOper.Visible = True
            LBLIniciar.Visible = True

            PanelDEtalle.Visible = False
            PanelCabecera.Visible = False
            PanelPie.Visible = False
            PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)

            CmdAccoper.Visible = False
            CmdAccesoSuboper.Visible = False
            CmdAccTipo.Visible = False
            CmdBusoper.Visible = False
            TxtOperacion.Visible = False
            CmdOperacion.Visible = False
            CmdSubOper.Visible = False
            CmdTipoOper.Visible = False
            PanelCentral.Dock = DockStyle.Fill
            PanelCentral.Visible = True
            PanelListarOper.Visible = True
            dg_listaoper.Focus()

        End If

    End Sub

    Private Sub CmdSubOper_Click(sender As Object, e As EventArgs) Handles CmdSubOper.Click
        If BoxEstado.AccessibleName = "bloq" Then Exit Sub
        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        If Val(CmdSubOper.Tag) = 0 Then Exit Sub
        Dim ListaSubOperacion() As DataRow = lk_sql_listaSubOper.Select("id_tb_oper = '" & CmdOperacion.Tag & "'")
        ' Recorremos las filas filtradas
        Estado_Operacion_OperMaestro(True)
        If ListaSubOperacion.Length = 0 Then
            Estado_Operacion_OperMaestro(False)
            Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaSubOperacion
            Dim id As Integer = CInt(row("id_tb_suboper"))
            Dim detalle As String = CStr(row("descrip_suboper"))

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarSuboperacion(id, detalle)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdSubOper, New Point(0, CmdSubOper.Height))



    End Sub
    Private Sub MostrarSuboperacion(id As String, detalle As String)
        'Aquí puedes reemplazar con tu código para realizar la acción correspondiente
        ' MessageBox.Show($"Realizando acción con ID {id}")
        CmdSubOper.Text = detalle
        CmdSubOper.Tag = id

        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        Estado_Operacion_OperMaestro(True)
        If Obtener_id_oper_maestro.Count = 0 Then
            Estado_Operacion_OperMaestro(False)
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            ' Se  intenta Buscar al ultiomo Registro de Tipo 
            CmdTipoOper.Text = ""
            CmdTipoOper.Tag = 0
            CmdTipoOper_Click(Nothing, Nothing)
            Exit Sub
        End If

        Actualiza_Oper_Maestro()
        SaltoBox(CmdOperacion.AccessibleDescription)

    End Sub

    Private Sub CmdTipoOper_Click(sender As Object, e As EventArgs) Handles CmdTipoOper.Click
        If BoxEstado.AccessibleName = "bloq" Then Exit Sub



        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        'If Val(CmdTipoOper.Tag) = 0 Then Exit Sub

        Dim ListaTipoOperacion() As DataRow = lk_sql_listaTipoOper.Select("id_tb_oper = '" & CmdOperacion.Tag & "'")
        ' Recorremos las filas filtradas

        If ListaTipoOperacion.Length = 0 Then
            Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaTipoOperacion
            Dim id As Integer = CInt(row("id_tb_tipooper"))
            Dim detalle As String = CStr(row("descrip_tipooper"))

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarTipoOperacion(id, detalle)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdTipoOper, New Point(0, CmdTipoOper.Height))


    End Sub
    Private Sub MostrarTipoOperacion(id As String, detalle As String)
        'Aquí puedes reemplazar con tu código para realizar la acción correspondiente
        CmdTipoOper.Text = detalle
        CmdTipoOper.Tag = id
        SaltoBox(CmdOperacion.AccessibleDescription)
        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        Estado_Operacion_OperMaestro(True)
        If Obtener_id_oper_maestro.Count = 0 Then
            Estado_Operacion_OperMaestro(False)
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            ' Se  intenta Buscar al ultiomo Registro de Tipo 
            CmdTipoOper.Text = ""
            CmdTipoOper.Tag = 0
            CmdTipoOper_Click(Nothing, Nothing)
            Exit Sub
        End If


        Actualiza_Oper_Maestro()


    End Sub
    Private Sub Estado_Operacion_OperMaestro(wbloq As Boolean)
        CmdGrabar.Enabled = wbloq
    End Sub
    Private Sub Actualiza_Oper_Maestro()
        Dim wes_control_lote As Integer
        Dim wes_listaprecio As Integer
        Dim wes_finanzas As Integer
        Dim wes_inventario As Integer
        Dim wes_id_tb_tipo_balance As Integer
        Dim wes_prod_new As Integer
        Dim wes_canje_le As Integer
        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        Estado_Operacion_OperMaestro(True)
        If Obtener_id_oper_maestro.Count = 0 Then
            Estado_Operacion_OperMaestro(False)
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            ' Se  intenta Buscar al ultiomo Registro de Tipo 
            'CmdTipoOper.Text = ""
            '  CmdTipoOper.Tag = 0
            'CmdTipoOper_Click(Nothing, Nothing)
            Exit Sub
        End If
        wes_control_lote = Obtener_id_oper_maestro(0)("es_control_lote")
        wes_listaprecio = Obtener_id_oper_maestro(0)("es_listaprecio")
        wes_finanzas = Obtener_id_oper_maestro(0)("es_finanzas")
        wes_inventario = Obtener_id_oper_maestro(0)("es_inventario")
        wes_id_tb_tipo_balance = Obtener_id_oper_maestro(0)("id_tb_tipo_balance")
        wes_prod_new = Obtener_id_oper_maestro(0)("es_prod_new")
        Dim wes_bonificado As Integer = Obtener_id_oper_maestro(0)("es_bonificado")

        wes_canje_le = Obtener_id_oper_maestro(0)("es_canje_le")
        Dim wes_cuentasn As Integer = Obtener_id_oper_maestro(0)("es_cuentasn") ' afecta a registro de caunta correinte del socio de negocio

        BoxCondicion.AccessibleDescription = ""
        If BoxCondicion.Visible Then
            BoxCondicion.AccessibleDescription = wes_id_tb_tipo_balance
        End If



        dg_cuentasn.AccessibleDescription = ""
        If dg_cuentasn.Visible Then
            dg_cuentasn.AccessibleDescription = wes_id_tb_tipo_balance
        End If



        If GridProductos.Visible Then
            If Radio_Serv.Checked Then Exit Sub
            If wes_control_lote = 0 Then
                GridProductos.Columns.Item("det_lote").Visible = False
                GridProductos.Columns.Item("lote").Visible = False
            Else
                GridProductos.Columns.Item("det_lote").Visible = True
                GridProductos.Columns.Item("lote").Visible = True
            End If

            If wes_listaprecio = 1 Then
                GridProductos.Columns.Item("preciolista").Visible = True
            Else
                GridProductos.Columns.Item("preciolista").Visible = False
            End If
            If wes_prod_new = 1 Then
                GridProductos.Columns.Item("es_prod_new").Visible = True
            Else
                GridProductos.Columns.Item("es_prod_new").Visible = False
            End If


            If wes_bonificado = 1 Then
                GridProductos.Columns.Item("es_prod_bof").Visible = True
            Else
                GridProductos.Columns.Item("es_prod_bof").Visible = False
            End If


            GridProductos.Columns.Item("saldo_pend").Visible = False
        End If
        If Obtener_id_oper_maestro(0)("fn_directo_id_oper_maestro") <> 0 Then ' fUERZA A MOSTRAR tEMAS DE fIANNZAS YA QUE ESTA AOCIADO A OTRA OPER DE FINANZAAS
            BoxEntidadF.Visible = True
        Else
            If wes_canje_le = 1 Then
                BoxEntidadF.Visible = False
            Else
                If wes_finanzas = 1 Then
                    BoxEntidadF.Visible = True
                Else
                    BoxEntidadF.Visible = False
                End If
            End If


        End If

        If Val(CmdOperacion.Tag) = 6 Then ' VENTAS COMENRCALES
            If BoxEntidadF.Visible = True Then ' valida si tiene credi el SN
                BoxCondicion.Visible = False
            Else
                BoxCondicion.Visible = True
            End If
        End If



    End Sub
    Private Sub CmdBusoper_Click(sender As Object, e As EventArgs) Handles CmdBusoper.Click
        If TxtOperacion.Text.Trim() = "" Then
            CmdOperacion_Click(Nothing, Nothing)
        Else
            ' Se Limpia variables relacidas
            Limpieza_variables_Relacionados()

            Mostraroperacion(TxtOperacion.Text)
        End If

    End Sub

    Private Sub FrmOperaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'Stop
    End Sub

    Private Sub CmdLocal_Click(sender As Object, e As EventArgs) Handles CmdLocal.Click


        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub

        Dim ListaListaLocales() As DataRow = lk_sql_Locales_Activos.Select("id_local <> 0 and  id_usuario = " & lk_id_usuario & " ")
        ' Recorremos las filas filtradas
        If ListaListaLocales.Length = 0 Then
            Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaListaLocales
            Dim id As Integer = CInt(row("id_local"))
            Dim detalle As String = CStr(row("codigo") & " " & row("nombre"))
            Dim descrip As String = CStr(row("nombre"))
            Dim codigo As String = CStr(row("codigo"))

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarLocalActivo(id, detalle, descrip, codigo)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdLocal, New Point(0, CmdLocal.Height))
    End Sub
    Private Sub MostrarLocalActivo(id As String, detalle As String, descrip As String, codigo As String)
        'Aquí puedes reemplazar con tu código para realizar la acción correspondiente

        CmdLocal.Text = descrip
        CmdLocal.Tag = id
        TxtLocal.Text = codigo
        CmdLocal.AccessibleName = codigo
        PordefectoSerie(Val(CmdLocal.Tag), Val(CmdComprob.Tag))

        Dim AlmacenDefecto() As DataRow = lk_sql_lista_acc_almacenes.Select("id_local = " & id & "")
        If AlmacenDefecto.Length = 0 Then
            Dim Result = MensajesBox.Show("Local , No Tiene Almaces.",
                                     "Almacenes.")
            Exit Sub

        End If

        Asigna_almacen_Defecto_Oper(AlmacenDefecto(0)("id_almacen"), AlmacenDefecto(0)("codigo"), AlmacenDefecto(0)("nombre"), AlmacenDefecto(0)("nombreabreviado"))




    End Sub
    Private Sub Asigna_almacen_Defecto_Oper(wid_almacen As Integer, wcodigo As String, wnombre As String, wabreviado As String)
        Oper_Almacen_Defecto.id_almacen = wid_almacen
        Oper_Almacen_Defecto.codigo = wcodigo
        Oper_Almacen_Defecto.nombre = wnombre
        Oper_Almacen_Defecto.abreviado = wabreviado
        cambio_almacen_grid()
    End Sub
    Private Sub TxtLocal_TextChanged(sender As Object, e As EventArgs) Handles TxtLocal.TextChanged

    End Sub


    Private Function MostraLocal(wcodigo As String) As Boolean
        MostraLocal = False

        If Len(wcodigo) <> 3 Then
            'CmdLocal_Click(Nothing, Nothing)
            Exit Function
        End If

        Dim Local() As DataRow = lk_sql_Locales_Activos.Select("codigo = '" & wcodigo & "'")
        ' Recorremos las filas filtradas
        If Local.Length = 0 Then
            ' Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
            '                         "Local.")
            '  CmdLocal_Click(Nothing, Nothing)
            Exit Function
        End If
        TxtLocal.Text = Local(0)("codigo")
        TxtLocal.Tag = Local(0)("id_local")
        CmdLocal.Text = Local(0)("nombre")
        CmdLocal.Tag = Local(0)("id_local")
        CmdLocal.AccessibleName = Local(0)("codigo")

        Dim AlmacenDefecto() As DataRow = lk_sql_lista_acc_almacenes.Select("id_local = " & Local(0)("id_local") & "")
        If AlmacenDefecto.Length = 0 Then
            Dim Result = MensajesBox.Show("Local No Tiene almacen por defcto.",
                                     "Local.")
            Exit Function
        End If

        Asigna_almacen_Defecto_Oper(AlmacenDefecto(0)("id_almacen"), AlmacenDefecto(0)("codigo"), AlmacenDefecto(0)("nombre"), AlmacenDefecto(0)("nombreabreviado"))

        MostraLocal = True
    End Function

    Private Sub TxtLocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtLocal.KeyPress
        Solo_Numero(e)

        If e.KeyChar = Chr(13) Then
            If MostraLocal(TxtLocal.Text) = False Then
                SMS_Barra("Verificar Codigo de Tienda...", 2)
                TxtLocal.SelectAll()
                Exit Sub
            End If
            SaltoBox(BoxTienda.AccessibleName)
        End If
    End Sub

    Private Sub CmdBusca_BoxSN_Click(sender As Object, e As EventArgs) Handles CmdBusca_BoxSN.Click
        ' CmdBusca_BoxSN
        Busca_DatoSocioN_Box(TxtSocio_BoxSN.Text)


    End Sub


    Private Sub TxtSocio_BoxSN_TextChanged(sender As Object, e As EventArgs) Handles TxtSocio_BoxSN.TextChanged
        Dim idgrid As Integer

        If Len(TxtSocio_BoxSN.Text) = 3 Then
            If Not IsNumeric(TxtSocio_BoxSN.Text) Then

                Dim frbusca As New FrmMenuConfigurar
                '  frbusca.LblEtiqueta.Text = Trim(DirectCast(sender, Button).Text)
                ' frbusca.LblEtiqueta.Tag = DirectCast(sender, Button).Tag.ToString()
                'Dim tamaño As Rectangle = My.Computer.Screen.Bounds
                'frbusca.Left = (Me.Left) + 220
                'frbusca.Top = (Me.Top) + 120
                frbusca.TxtCodigo.Tag = 100
                frbusca.TxtBuscar.Tag = TxtSocio_BoxSN.Text
                frbusca.ENLACE_VIENE = "PROCESOS"
                frbusca.ShowDialog()

                idgrid = Val(frbusca.CmdBuscar.Tag)
                If idgrid <> -1 Then
                    Try
                        info_SN.Text = frbusca.DataGridResul.Rows(idgrid).Cells("boxsn").Value.ToString()
                        info_SN.Tag = frbusca.DataGridResul.Rows(idgrid).Cells("id_sn_maestro").Value.ToString()
                        info_SN.AccessibleName = frbusca.DataGridResul.Rows(idgrid).Cells("id_tipodoc").Value.ToString()
                        TxtSocio_BoxSN.Text = frbusca.DataGridResul.Rows(idgrid).Cells("codigo").Value.ToString()
                        Dim wdiascred As Integer = Val(frbusca.DataGridResul.Rows(idgrid).Cells("dias_credito").Value.ToString())
                        Dim wes_limite As Integer = Val(frbusca.DataGridResul.Rows(idgrid).Cells("es_limite_credito").Value.ToString())


                        Obtener_LineaCredito_SN(Val(frbusca.DataGridResul.Rows(idgrid).Cells("id_sn_maestro").Value.ToString()), wdiascred, wes_limite, 0)
                    Catch

                    End Try
                    TxtSocio_BoxSN.Select()
                    TxtSocio_BoxSN.SelectionStart = TxtSocio_BoxSN.Text.Length
                End If

                frbusca.Close()
                'BuscaProductos = False
            End If
        End If
    End Sub

    Private Sub TxtSocio_BoxSN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSocio_BoxSN.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If TxtSocio_BoxSN.Text = "" Then Exit Sub
            Busca_DatoSocioN_Box(TxtSocio_BoxSN.Text)
        End If
    End Sub
    Private Sub Busca_DatoSocioN_Box(wcadena As String)
        Dim Result As String
        Dim sql_cade As String
        Dim sql_result As DataTable
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim whacebusAdd As Boolean = False
        Dim wdig As Integer = wcadena.Trim.Length
        Dim wid_tipdoc As Integer = 0


        Dim ListaTipoPersona() As DataRow = lk_sql_ListaTipoDocPersona.Select("digitos = '" & wdig & "'")

        If ListaTipoPersona.Length <> 0 Then
            whacebusAdd = True

            wid_tipdoc = ListaTipoPersona(0)("id_tipodoc")
            '   Exit Sub
        End If

        'If wid_tipdoc = 0 Then
        ' primer paso  es buscar por codigo de socio de negocio


        sql_cade = "SELECT id_sn_maestro,  boxsn , id_tipodoc , monto ,es_limite_credito, dias_credito  FROM [dbo].[vw_snegocio] where id_negocio = " & lk_NegocioActivo.id_Negocio & " and codigo = '" & wcadena & "'"
        'Else
        'sql_cade = "SELECT id_sn_maestro,  boxsn , id_tipodoc   FROM [dbo].[vw_snegocio] where id_negocio = " & lk_NegocioActivo.id_Negocio & " and id_tipodoc = " & wid_tipdoc & " and numero= '" & wcadena & "'"
        'End If
        sql_result = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(sql_result)
        If sql_result.Rows.Count = 0 Then
            ' segundo  paso  es buscar por tipo de documento
            sql_cade = "SELECT id_sn_maestro,  boxsn , id_tipodoc , monto ,es_limite_credito, dias_credito  FROM [dbo].[vw_snegocio] where id_negocio = " & lk_NegocioActivo.id_Negocio & " and id_tipodoc = " & wid_tipdoc & " and numero= '" & wcadena & "'"
            sql_result = New DataTable()
            command = New SqlCommand(sql_cade, lk_connection_cuenta)
            adaptador = New SqlDataAdapter(command)
            adaptador.Fill(sql_result)
            If sql_result.Rows.Count = 0 Then
            Else
                GoTo CreaEncontroSN
            End If

        Else
            GoTo CreaEncontroSN
        End If



        If sql_result.Rows.Count = 0 Then
            ' detectar la cantidad de digitos de digitado
            If whacebusAdd = False Then
                Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                                         "Socio de Negocio.")
                TxtSocio_BoxSN.SelectAll()
                Exit Sub
            End If

            Dim wid_tipodoc As Integer = ListaTipoPersona(0)("id_tipodoc")

            ' BUSQUEDA AL MAESTER DE ORI
            '=============================

            sql_cade = "select  * from [vw_sn_maester] where  numero = '" & wcadena & "' and id_tipodoc= '" & wid_tipodoc & "'"
            sql_result = New DataTable()
            command = New SqlCommand(sql_cade, lk_connection_master)
            adaptador = New SqlDataAdapter(command)
            adaptador.Fill(sql_result)
            If sql_result.Rows.Count <> 0 Then
                Result = MensajesBox.Show("Socio de Negocio *Encontrado* , desea adicionarlo en su negocio?" & vbCrLf & sql_result.Rows(0).Item("boxsn").ToString & "
                ", "Cracion de Socio de Negocio", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                'MessageBoxButtons.YesNoCancel,
                '                       MessageBoxIcon.Warning,
                '                       MessageBoxDefaultButton.Button1)

                If Result = "7" Or Result = "2" Then ' es NO
                    Exit Sub
                End If
                ' Insertar del maestro a bd del negocio
                '=====================================

                command = New SqlCommand("sp_InsertarMaestroSN", lk_connection_cuenta)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Clear()
                command.Parameters.AddWithValue("@id_negocio", 22)
                command.Parameters.AddWithValue("@id_socionegocio", sql_result.Rows(0).Item("id_socionegocio").ToString)
                command.Parameters.Add("@id_sn_maestro_salida", SqlDbType.Int)
                command.Parameters("@id_sn_maestro_salida").Direction = ParameterDirection.Output
                command.ExecuteNonQuery()
                ' Obtener el valor del parámetro de salida
                Dim widSnMaestro = Convert.ToInt32(command.Parameters("@id_sn_maestro_salida").Value)

                sql_cade = "SELECT id_sn_maestro,  boxsn ,id_tipodoc , monto ,es_limite_credito, dias_credito FROM [dbo].[vw_snegocio] where id_sn_maestro = " & widSnMaestro & " "
                sql_result = New DataTable()
                command = New SqlCommand(sql_cade, lk_connection_cuenta)
                adaptador = New SqlDataAdapter(command)
                adaptador.Fill(sql_result)
                GoTo CreaEncontroSN
                Exit Sub
            Else

                ' MsgBox("Aqui a la consulta RUC")
                ' Exit Sub
                If ListaTipoPersona(0)("id_tipodoc") = 1 Or ListaTipoPersona(0)("id_tipodoc") = 4 Then

                Else

                    Result = MensajesBox.Show("Documento no encontrado (Plataforma Ori/SUNAT)* , desea ingresar manualmente en su negocio?", "Cracion de Socio de Negocio", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If Result = "7" Or Result = "2" Then ' es NO
                        Exit Sub
                    End If
                    Muestra_Pantalla_Manual()
                    Exit Sub
                End If


                If ListaTipoPersona(0)("id_tipodoc") = 1 Then
                    Dim wNombres = ObtenerNombrePorDNI(lk_Token_tigo, wcadena)
                    If wNombres.Trim() <> "" Then
                        Result = MensajesBox.Show("Socio de Negocio *Encontrado* , desea adicionarlo en su negocio?" & vbCrLf & vbCrLf & wNombres, "Cracion de Socio de Negocio- DNI", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        If Result = "7" Or Result = "2" Then ' es NO
                            Exit Sub
                        End If

                        ' Insertar del maestro a bd del negocio
                        '=====================================

                        command = New SqlCommand("[sp_InsertarDatosSN]", lk_connection_cuenta)
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.Clear()
                        command.Parameters.AddWithValue("@id_TipoDoc", ListaTipoPersona(0)("id_tipodoc"))
                        command.Parameters.AddWithValue("@numero", wcadena)
                        command.Parameters.AddWithValue("@razons", wNombres)
                        command.Parameters.AddWithValue("@comercial", "")
                        command.Parameters.AddWithValue("@estado", "1")
                        command.Parameters.AddWithValue("@condicion", "HABIDO")
                        command.Parameters.AddWithValue("@direccion", "")
                        command.Parameters.AddWithValue("@id_ubigeo_n1", "00")
                        command.Parameters.AddWithValue("@id_ubigeo_n2", "00")
                        command.Parameters.AddWithValue("@id_ubigeo_n3", "00")
                        command.Parameters.AddWithValue("@tipo_contribuyente", "PN")
                        command.Parameters.AddWithValue("@activdad_principal", "")
                        command.Parameters.AddWithValue("@fechainscripcion", DBNull.Value)
                        command.Parameters.AddWithValue("@fechainicio", DBNull.Value)
                        command.Parameters.AddWithValue("@id_negocio", 22)
                        command.Parameters.AddWithValue("@correo", "")
                        command.Parameters.AddWithValue("@correo_fe", "")
                        command.Parameters.AddWithValue("@id_tab_tiposocio", 1)
                        command.Parameters.AddWithValue("@id_tab_tipodirec", 1)
                        command.Parameters.AddWithValue("@es_principal", 1)
                        command.Parameters.Add("@id_sn_maestro_salida", SqlDbType.Int)
                        command.Parameters("@id_sn_maestro_salida").Direction = ParameterDirection.Output
                        command.ExecuteNonQuery()
                        ' Obtener el valor del parámetro de salida
                        Dim widSnMaestrodni = Convert.ToInt32(command.Parameters("@id_sn_maestro_salida").Value)

                        sql_cade = "SELECT id_sn_maestro,  boxsn, , id_tipodoc , monto ,es_limite_credito, dias_credito   FROM [dbo].[vw_snegocio] where id_sn_maestro = " & widSnMaestrodni & " "
                        sql_result = New DataTable()
                        command = New SqlCommand(sql_cade, lk_connection_cuenta)
                        adaptador = New SqlDataAdapter(command)
                        adaptador.Fill(sql_result)
                        GoTo CreaEncontroSN
                        ' info_SN.Text = wNombres

                    End If
                    Result = MensajesBox.Show("Nro. Documento no encontrado (Plataforma Ori/SUNAT)* , desea ingresar manualmente en su negocio?", "Cracion de Socio de Negocio", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If Result = "7" Or Result = "2" Then ' es NO
                        Exit Sub
                    End If
                    Muestra_Pantalla_Manual()
                    Exit Sub


                    Exit Sub
                End If


                Dim resul As String
                Dim consulta As New ConsultaRUC(lk_Token_tigo)
                Dim respuesta As JObject = consulta.ConsultarRUC(wcadena, ListaTipoPersona(0)("descripcion").ToString.ToLower)
                ' Obtener los datos del contribuyente
                If respuesta Is Nothing Then
                    Result = MensajesBox.Show("Documento no encontrado (Plataforma Ori/SUNAT)* , desea ingresar manualmente en su negocio?", "Cracion de Socio de Negocio", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If Result = "7" Or Result = "2" Then ' es NO
                        Exit Sub
                    End If
                    Muestra_Pantalla_Manual()
                    Exit Sub
                End If
                Dim wrazonSocial As String = respuesta("nombre_o_razon_social").ToString()
                Dim wruc As String = respuesta("ruc").ToString()
                Dim wdireccion As String = respuesta("direccion").ToString()
                Dim wubigeo As String
                If respuesta("ubigeo").ToString() = "" Then
                    wubigeo = "000000"
                Else
                    wubigeo = respuesta("ubigeo").ToString()
                End If

                Dim condicion_de_domicilio As String = respuesta("condicion_de_domicilio").ToString()
                Dim estado_del_contribuyente As String = respuesta("estado_del_contribuyente").ToString()
                Dim departamento As String = respuesta("departamento").ToString()
                Dim distrito As String = respuesta("distrito").ToString()
                Dim provincia As String = respuesta("provincia").ToString()



                resul = "[RUC] " & wruc & vbCrLf & "[Rz.Social:] " & wrazonSocial & vbCrLf & "[condicion:] " & condicion_de_domicilio & vbCrLf & "[Estado:] " & estado_del_contribuyente & vbCrLf & "[Direccion:] " & wdireccion & vbCrLf & ""
                Result = MensajesBox.Show("Socio de Negocio *Encontrado SUNAT* , desea adicionarlo en su negocio?" & vbCrLf & resul.ToUpper & "
", "Cracion de Socio de Negocio", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If Result = "7" Or Result = "2" Then ' es NO
                    Exit Sub
                End If

                ' Insertar del maestro a bd del negocio
                '=====================================

                command = New SqlCommand("[sp_InsertarDatosSN]", lk_connection_cuenta)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Clear()
                command.Parameters.AddWithValue("@id_TipoDoc", ListaTipoPersona(0)("id_tipodoc"))
                command.Parameters.AddWithValue("@numero", wcadena)
                command.Parameters.AddWithValue("@razons", wrazonSocial)
                command.Parameters.AddWithValue("@comercial", "")
                command.Parameters.AddWithValue("@estado", "1")
                command.Parameters.AddWithValue("@condicion", condicion_de_domicilio)
                command.Parameters.AddWithValue("@direccion", wdireccion)
                command.Parameters.AddWithValue("@id_ubigeo_n1", Mid(wubigeo, 1, 2))
                command.Parameters.AddWithValue("@id_ubigeo_n2", Mid(wubigeo, 3, 2))
                command.Parameters.AddWithValue("@id_ubigeo_n3", Mid(wubigeo, 5, 2))
                command.Parameters.AddWithValue("@tipo_contribuyente", "PJ")
                command.Parameters.AddWithValue("@activdad_principal", "")
                command.Parameters.AddWithValue("@fechainscripcion", DBNull.Value)
                command.Parameters.AddWithValue("@fechainicio", DBNull.Value)
                command.Parameters.AddWithValue("@id_negocio", 22)
                command.Parameters.AddWithValue("@correo", "")
                command.Parameters.AddWithValue("@correo_fe", "")
                command.Parameters.AddWithValue("@id_tab_tiposocio", 1)
                command.Parameters.AddWithValue("@id_tab_tipodirec", 1)
                command.Parameters.AddWithValue("@es_principal", 1)

                command.Parameters.Add("@id_sn_maestro_salida", SqlDbType.Int)
                command.Parameters("@id_sn_maestro_salida").Direction = ParameterDirection.Output

                command.ExecuteNonQuery()
                ' Obtener el valor del parámetro de salida
                Dim widSnMaestro = Convert.ToInt32(command.Parameters("@id_sn_maestro_salida").Value)

                sql_cade = "SELECT id_sn_maestro,  boxsn ,id_tipodoc , monto ,es_limite_credito, dias_credito FROM [dbo].[vw_snegocio] where id_sn_maestro = " & widSnMaestro & " "
                sql_result = New DataTable()
                command = New SqlCommand(sql_cade, lk_connection_cuenta)
                adaptador = New SqlDataAdapter(command)
                adaptador.Fill(sql_result)
                GoTo CreaEncontroSN


                info_SN.Text = resul
                ' info_SN.Tag = sql_result.Rows(0).Item("id_sn_maestro").ToString
                Exit Sub

            End If

            'Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
            '                         "Socio de Negocio.")
            'TxtSocio_BoxSN.SelectAll()
            Exit Sub
        Else
CreaEncontroSN:
            info_SN.Text = sql_result.Rows(0).Item("boxsn").ToString
            info_SN.Tag = sql_result.Rows(0).Item("id_sn_maestro").ToString
            info_SN.AccessibleName = sql_result.Rows(0).Item("id_tipodoc").ToString

            Dim wdiascred As Integer = Val(sql_result.Rows(0).Item("dias_credito").ToString)
            Dim wes_limite As Integer = Val(sql_result.Rows(0).Item("es_limite_credito").ToString)


            ', monto ,es_limite_credito, dias_credito

            SaltoBox(BoxSocioNego.AccessibleName)
            Obtener_LineaCredito_SN(Val(sql_result.Rows(0).Item("id_sn_maestro").ToString), wdiascred, wes_limite, 0)
        End If




    End Sub
    Private Sub mueve_fecha_vcto_dias(wdiascred As Integer)
        Dim fechaEmision As DateTime = TxtFechas_Emis.Value
        Dim fechaVencimiento As DateTime = fechaEmision.AddDays(wdiascred)
        TxtCondi_FecVcto.Text = TxtFechas_Emis.Text
        TxtCondi_FecVcto.Text = fechaVencimiento.ToString("dd/MM/yyyy") ' Formatear como desees
    End Sub
    Private Sub Muestra_Pantalla_Manual()
        Dim frConfigurar As New FrmMenuConfigurar
        frConfigurar.TopLevel = False
        FrmLogin.PanelFormularios.Controls.Add(frConfigurar)
        frConfigurar.WindowState = FormWindowState.Normal
        frConfigurar.Left = 10
        frConfigurar.Top = 10
        frConfigurar.Width = FrmLogin.PanelFormularios.Width / 1.1
        frConfigurar.Height = FrmLogin.PanelFormularios.Height / 1.1
        frConfigurar.ENLACE_VIENE = "CONFIGURAR"
        frConfigurar.Show()
        FrmLogin.PanelFormularios.Controls.Item(FrmLogin.PanelFormularios.Controls.Count - 1).BringToFront() ' Ultimo Fomulario a primer plano

    End Sub
    Private Sub TxtSocio_BoxSN_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSocio_BoxSN.KeyDown
        If e.KeyCode = Keys.F2 Then
            BOXSN_Modo(TxtSocio_BoxSN)
        End If

    End Sub
    Private Sub BOXSN_Modo(TxtSocio As TextBox)
        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        'If Val(CmdTipoOper.Tag) = 0 Then Exit Sub

        Dim ListaTipoOperacion() As DataRow = lk_sql_listaTipoOper.Select("id_tb_oper = '" & CmdOperacion.Tag & "'")
        ' Recorremos las filas filtradas
        If ListaTipoOperacion.Length = 0 Then
            Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaTipoOperacion
            Dim id As Integer = CInt(row("id_tb_tipooper"))
            Dim detalle As String = CStr(row("descrip_tipooper"))

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarTipoOperacion(id, detalle)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(TxtSocio, New Point(0, TxtSocio.Height))
    End Sub
    Public Class ConsultaRUC
        Private Const ConsultaUrl As String = "https://api.migo.pe/api/v1/ruc"

        Private ReadOnly _apiKey As String

        Public Sub New(apiKey As String)
            _apiKey = apiKey
        End Sub

        Public Function ConsultarRUC(numeroRUC As String, wtipo_dni_ruc As String) As JObject
            ' wtipoDNI_RUC = 'ruc' o dni
            ' Establecer los protocolos SSL/TLS
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11

            ' Crear el cliente REST
            Dim client As New RestClient(ConsultaUrl)

            ' Crear la solicitud POST
            Dim request As New RestRequest(Method.POST)
            request.AddHeader("accept", "application/json")
            request.AddHeader("content-type", "application/json")

            ' Agregar los parámetros de la solicitud
            Dim body As New JObject
            body.Add("token", _apiKey)
            body.Add(wtipo_dni_ruc, numeroRUC)
            request.AddParameter("application/json", body.ToString(), ParameterType.RequestBody)

            ' Realizar la solicitud
            Dim response As IRestResponse = client.Execute(request)

            ' Verificar si la respuesta fue exitosa
            If response.StatusCode = HttpStatusCode.OK Then
                Try
                    ' Analizar la respuesta JSON
                    Dim jsonResponse As JObject = JObject.Parse(response.Content)
                    Return jsonResponse
                Catch ex As Exception
                    ' Manejar el error de JSON inválido
                    Console.WriteLine("Error al analizar la respuesta JSON: " & ex.Message)
                End Try
            Else
                ' Manejar el error de solicitud HTTP no exitosa
                Console.WriteLine("Error de solicitud HTTP: " & response.ErrorMessage)
            End If

            Return Nothing
        End Function


    End Class
    'Public Function Consultardni() As Task(Of String)

    '    Dim dni As String = "18149375"
    '    Dim resultado As JObject = Await client.ConsultarDNI(dni)
    '    'MsgBox(resultado("nombre"))
    '    ' Aquí puedes hacer lo que quieras con el resultado de la consulta.
    '    ' End Sub


    'End Function

    Public Function ObtenerNombrePorDNI(ByVal token As String, ByVal dni As String) As String
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls

        Dim client As New HttpClient()
        Dim request As New HttpRequestMessage() With {
        .Method = HttpMethod.Post,
        .RequestUri = New Uri("https://api.migo.pe/api/v1/dni"),
        .Content = New StringContent($"{{""token"":""{token}"",""dni"":""{dni}""}}")
    }

        request.Headers.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
        request.Content.Headers.ContentType = New MediaTypeHeaderValue("application/json")
        request.Headers.Authorization = New AuthenticationHeaderValue("Bearer", token)
        Dim rnombre As String = ""
        Try
            Dim response As HttpResponseMessage = client.SendAsync(request).Result
            response.EnsureSuccessStatusCode()

            Dim body As String = response.Content.ReadAsStringAsync().Result
            ' Dim nombre As String = ObtenerNombreDesdeJson(body)


            Dim obj As JObject = JObject.Parse(body)
            Dim success As Boolean = obj("success").ToObject(Of Boolean)()

            rnombre = ""
            If success Then
                'Dim rdni As String = obj("dni").ToString()
                rnombre = obj("nombre").ToString()
            End If
            'Dim rfechaNacimiento As String = obj("fechaNacimiento").ToString()
            'Dim rgenero As String = obj("genero").ToString()

            'If success Then
            Return rnombre ' , fechaNacimiento, genero)
            ' Else
            Throw New Exception("No se pudieron obtener los datos")
            'End If




            'Return nombre
        Catch ex As Exception
            Return rnombre
            'Dim mensaje As String = $"Error al obtener el nombre: {ex.Message}"
            'Throw New Exception(mensaje, ex)
        End Try
    End Function

    Private Sub txtContactos_TextChanged(sender As Object, e As EventArgs) Handles txtContactos.TextChanged

    End Sub

    Private Sub CmdListaDias_Click(sender As Object, e As EventArgs)
        '  CmbCondi_Lista.DroppedDown = True
    End Sub
    Private Sub CmbDias_DropDown(sender As Object, e As EventArgs)
        'Dim maxWidth As Integer = CmbCondi_Lista.Width

        'For Each item As Object In CmbCondi_Lista.Items
        '    Dim itemWidth As Integer = TextRenderer.MeasureText(item.ToString(), CmbCondi_Lista.Font).Width

        '    If itemWidth > maxWidth Then
        '        maxWidth = itemWidth
        '    End If
        'Next

        'CmbCondi_Lista.DropDownWidth = maxWidth
    End Sub

    Private Sub CmbDias_DrawItem(sender As Object, e As DrawItemEventArgs)
        'e.DrawBackground()

        'If e.Index >= 0 Then
        '    Dim text As String = CmbCondi_Lista.Items(e.Index).ToString()
        '    Dim font As Font = CmbCondi_Lista.Font
        '    Dim brush As Brush = SystemBrushes.ControlText
        '    Dim bounds As Rectangle = e.Bounds

        '    ' Configuramos el formato de texto para mostrar dos líneas
        '    Dim format As New StringFormat()
        '    format.LineAlignment = StringAlignment.Center
        '    format.Alignment = StringAlignment.Near
        '    format.Trimming = StringTrimming.EllipsisWord
        '    format.FormatFlags = StringFormatFlags.NoWrap

        '    ' Dividimos el texto en dos líneas
        '    Dim lines() As String = text.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        '    ' Dibujamos cada línea por separado
        '    For i As Integer = 0 To lines.Length - 1
        '        Dim rect As New Rectangle(bounds.Left, bounds.Top + (i * font.Height), bounds.Width, font.Height)
        '        e.Graphics.DrawString(lines(i), font, brush, rect, format)
        '    Next
        'End If

        'e.DrawFocusRectangle()
    End Sub

    Private Sub DataGridResul_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub


    Private Sub CmdAccesoSuboper_Click(sender As Object, e As EventArgs) Handles CmdAccesoSuboper.Click
        CmdSubOper_Click(Nothing, Nothing)
    End Sub

    Private Sub CmdAccoper_Click(sender As Object, e As EventArgs) Handles CmdAccoper.Click
        If TxtOperacion.Text = "" Then
            CmdOperacion_Click(Nothing, Nothing)
        Else
            TxtOperacion.Select()
            TxtOperacion.SelectAll()
        End If
    End Sub

    Private Sub CmdAccTipo_Click(sender As Object, e As EventArgs) Handles CmdAccTipo.Click
        CmdTipoOper_Click(Nothing, Nothing)
    End Sub

    Private Sub CmdListaoper_Click(sender As Object, e As EventArgs) Handles CmdListaoper.Click
        IniciarListar("L")
    End Sub
    Private Sub IniciaPantallaOperaciones()
        'PanelDEtalle.Height = 400
        PanelDEtalle.Visible = True
        PanelCabecera.Visible = True
        PanelPie.Visible = True
        PanelCentral.Visible = False
    End Sub

    Private Sub CmdIniciarOper_Click(sender As Object, e As EventArgs) Handles CmdIniciarOper.Click
        IniciarListar("I")
    End Sub

    Private Sub LBLIniciar_Click(sender As Object, e As EventArgs) Handles LBLIniciar.Click
        CmdIniciarOper_Click(Nothing, Nothing)
    End Sub

    Private Sub LblListar_Click(sender As Object, e As EventArgs) Handles LblListar.Click
        CmdListaoper_Click(Nothing, Nothing)
    End Sub


    Private Function ObtenerDataTableDesdeCadena(wcadena As String, wid_prod_mae As Integer, wid_pres_base As Integer, wsigno_kardex As Integer, wid_comp_det As Integer, wid_oper_maestro As Integer) As DataTable
        Dim dtResultado As New DataTable()
        '0 - codigo
        '1 - id_loteser
        '3-fecvcto
        '4-ingreso
        '5-salida
        '6-estado
        '7-nombreestado
        '8-fecfab
        '12-unid_kardex
        '13-ingreso_kardex
        '14-salida_kardex
        ' Crear columnas en el DataTable

        dtResultado.Columns.Add("id_negocio", GetType(Integer))
        dtResultado.Columns.Add("id_oper_maestro", GetType(Integer))
        dtResultado.Columns.Add("id_comp_cab", GetType(Integer))
        dtResultado.Columns.Add("id_comp_det", GetType(Integer))
        dtResultado.Columns.Add("numsec", GetType(Integer))
        dtResultado.Columns.Add("id_prod_mae", GetType(Integer))
        dtResultado.Columns.Add("id_loteser", GetType(Integer))
        dtResultado.Columns.Add("es_nuevo", GetType(Integer))
        dtResultado.Columns.Add("Codigo", GetType(String))
        dtResultado.Columns.Add("fechareg", GetType(DateTime))
        dtResultado.Columns.Add("es_nocaduca", GetType(Integer))
        dtResultado.Columns.Add("fechavcto", GetType(DateTime))
        dtResultado.Columns.Add("id_pres", GetType(Integer))
        dtResultado.Columns.Add("cantidad", GetType(Double))
        dtResultado.Columns.Add("signo_kardex", GetType(Integer))
        dtResultado.Columns.Add("estado", GetType(Integer))
        dtResultado.Columns.Add("ingreso_kardex", GetType(Double))
        dtResultado.Columns.Add("salida_kardex", GetType(Double))

        Dim wnum As Integer = 0

        ' Dividir la cadena de detalle en filas y columnas
        Dim filas() As String = wcadena.Split(";"c)
        For Each fila As String In filas
            ' Dividir cada fila en columnas
            Dim columnas() As String = fila.Split("#"c)

            ' Crear una nueva fila en el DataTable
            Dim newRow As DataRow = dtResultado.NewRow()

            ' Asignar los valores a las columnas de la nueva fila
            If columnas.Length >= 3 Then ' Asegurar que haya suficientes columnas para evitar excepciones
                If Val(columnas(15).Trim()) = 0 And Val(columnas(16).Trim()) = 0 Then Continue For

                wnum = wnum + 1
                If Val(columnas(2).Trim()) = 0 Then ' SI NO TIENE ID ES NUEVO REGISTRO EN LOTE
                    newRow("es_nuevo") = 1
                Else
                    newRow("es_nuevo") = 0
                End If
                newRow("id_negocio") = lk_NegocioActivo.id_Negocio
                newRow("id_oper_maestro") = wid_oper_maestro
                newRow("id_comp_cab") = 0 ' se asigna en el sp
                newRow("id_comp_det") = wid_comp_det
                newRow("numsec") = wnum
                newRow("id_prod_mae") = wid_prod_mae
                newRow("id_loteser") = Val(columnas(2).Trim())
                newRow("id_pres") = wid_pres_base
                If Val(columnas(15).Trim()) <> 0 Then
                    newRow("cantidad") = Val(columnas(15).Trim())  ' ingreso
                Else
                    newRow("cantidad") = Val(columnas(16).Trim())  ' salida
                End If
                newRow("es_nocaduca") = 0
                newRow("signo_kardex") = wsigno_kardex
                newRow("estado") = Val(columnas(7).Trim())
                newRow("codigo") = columnas(1).Trim()
                newRow("fechavcto") = columnas(4).Trim()
                newRow("fechareg") = columnas(9).Trim()
                newRow("ingreso_kardex") = Val(columnas(15).Trim())
                newRow("salida_kardex") = Val(columnas(16).Trim())

                ' Agregar la nueva fila al DataTable
                dtResultado.Rows.Add(newRow)
            End If
        Next

        Return dtResultado
    End Function

    Public Sub GridProductos_PrimeraFila()


        If GridProductos.Columns.Count <= 10 Then Exit Sub
        'If Me.GridProductos.CurrentCell.RowIndex = Me.GridProductos.Rows.Count Then
        Me.GridProductos.Rows.Clear()
        Me.GridProductos.Rows.Add()
        If Me.GridProductos.Tag = "PROD1" Then
            If Radio_Prod.Checked Then
                Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("codigo")
            Else
                Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("tipo_serv_des")
            End If

            AddGridProductos_defecto()

            'Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle").Value = "..."
            'Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("descrip").Value = "APIRINA COMPUESTO CON GRAGEAS 50X10GR PLUSS"
            Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("eli").Tag = "ppp"
            Me.GridProductos.BeginEdit(True)
            Contador_filas()

        End If
        'Else
        ' Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count + 1).Cells("codigo")
        ' Me.GridProductos.BeginEdit(True)
        '
        '       End If



        ' Contador_filas()



        'Dim comboCell As DataGridViewComboBoxCell
        'comboCell = CType(GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("present"), DataGridViewComboBoxCell)
        'comboCell.Items.Add("UND")
        'comboCell.Items.Add("CJx1")
        'comboCell.Items.Add("PAQX24")
        'comboCell.Value = "UND"

    End Sub
    Public Sub dg_cuentasn_PrimeraFila()



        'If Me.GridProductos.CurrentCell.RowIndex = Me.GridProductos.Rows.Count Then
        Me.dg_cuentasn.Rows.Clear()
        Me.dg_cuentasn.Rows.Add()
        If Me.dg_cuentasn.Tag = "CTASN1" Then
            Me.dg_cuentasn.CurrentCell = dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("codigo")
            'Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle").Value = "..."
            'Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("descrip").Value = "APIRINA COMPUESTO CON GRAGEAS 50X10GR PLUSS"
            'Me.dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("eli").Tag = "ppp"
            Me.dg_cuentasn.BeginEdit(True)
            Contador_filas_cuentaSN()
        End If
        'Else
        ' Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count + 1).Cells("codigo")
        ' Me.GridProductos.BeginEdit(True)
        '
        '       End If



        ' Contador_filas()



        'Dim comboCell As DataGridViewComboBoxCell
        'comboCell = CType(GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("present"), DataGridViewComboBoxCell)
        'comboCell.Items.Add("UND")
        'comboCell.Items.Add("CJx1")
        'comboCell.Items.Add("PAQX24")
        'comboCell.Value = "UND"

    End Sub
    Private Sub Contador_filas()

        If GridProductos.Visible = False Then Exit Sub


        'Iterar por cada fila en el DataGridView
        If GridProductos.CurrentCell Is Nothing Then Exit Sub
        Dim ultimafila As Integer = 0
        For i As Integer = 0 To GridProductos.Rows.Count - 1
            'Actualizar el valor de la celda de la primera columna al número de fila actual
            GridProductos.Rows(i).Cells("num").Value = (i + 1).ToString()
            If i = GridProductos.Rows.Count - 1 Then
                GridProductos.Rows(i).Cells("eli").Value = My.Resources.del
                GridProductos.Rows(i).Cells("eli").Tag = "eli"
                GridProductos.Rows(i).Cells("add").Value = My.Resources.add
                GridProductos.Rows(i).Cells("add").Tag = "add"
            Else
                GridProductos.Rows(i).Cells("eli").Value = My.Resources.del
                GridProductos.Rows(i).Cells("eli").Tag = "eli"
                GridProductos.Rows(i).Cells("add").Value = My.Resources.edit
                GridProductos.Rows(i).Cells("add").Tag = ""
            End If
            ultimafila = i
        Next
        'If ultimafila = 0 Then Exit Sub
        ''If GridProductos.Rows.Count = 0 Then
        'Dim currentImage As Image = GridProductos.Rows(ultimafila + 1).Cells("eli").Value
        'If currentImage Is My.Resources.eliminar Then
        '    GridProductos.Rows(ultimafila + 1).Cells("eli").Value = My.Resources.ver
        'End If
        ''End If
    End Sub
    Private Sub Contador_filas_cuentaSN()

        If dg_cuentasn.Visible = False Then Exit Sub


        'Iterar por cada fila en el DataGridView
        If dg_cuentasn.CurrentCell Is Nothing Then Exit Sub
        Dim ultimafila As Integer = 0
        For i As Integer = 0 To dg_cuentasn.Rows.Count - 1
            'Actualizar el valor de la celda de la primera columna al número de fila actual
            dg_cuentasn.Rows(i).Cells("num").Value = (i + 1).ToString()
            If i = dg_cuentasn.Rows.Count - 1 Then
                dg_cuentasn.Rows(i).Cells("eli").Value = My.Resources.del
                dg_cuentasn.Rows(i).Cells("eli").Tag = "eli"
                dg_cuentasn.Rows(i).Cells("add").Value = My.Resources.add
                dg_cuentasn.Rows(i).Cells("add").Tag = "add"
            Else
                dg_cuentasn.Rows(i).Cells("eli").Value = My.Resources.del
                dg_cuentasn.Rows(i).Cells("eli").Tag = "eli"
                dg_cuentasn.Rows(i).Cells("add").Value = My.Resources.edit
                dg_cuentasn.Rows(i).Cells("add").Tag = ""
            End If
            ultimafila = i
        Next
        'If ultimafila = 0 Then Exit Sub
        ''If GridProductos.Rows.Count = 0 Then
        'Dim currentImage As Image = GridProductos.Rows(ultimafila + 1).Cells("eli").Value
        'If currentImage Is My.Resources.eliminar Then
        '    GridProductos.Rows(ultimafila + 1).Cells("eli").Value = My.Resources.ver
        'End If
        ''End If
    End Sub

    Private Sub GridProductos_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles GridProductos.PreviewKeyDown


        If e.KeyCode = Keys.F2 And GridProductos.Focused Then '
            AsignaLoteProducto(0)
            If GridProductos.Rows(GridProductos.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then Exit Sub
            ' Obtener la celda activa (la celda en la que el usuario está)
            Dim activeCell As DataGridViewCell = GridProductos.CurrentCell
            ' Verificar si la celda activa no es nula y si es una celda de datos (no es una celda de encabezado)
            If activeCell IsNot Nothing AndAlso activeCell.ColumnIndex >= 0 AndAlso activeCell.RowIndex >= 0 Then
                Dim nombreColumna As String = GridProductos.Columns(activeCell.ColumnIndex).Name
                If nombreColumna = "preciolista" Then
                    ' MsgBox("bien")
                    Dim cadenatexto As String = GridProductos.Rows(GridProductos.CurrentCell.RowIndex).Cells("cadenaprecios").Value
                    If cadenatexto = "" Then Exit Sub
                    Dim dtPrecios As DataTable = listaprecio_atabla(cadenatexto)
                    MuestraListaPrecios(dtPrecios, activeCell.RowIndex, activeCell.ColumnIndex)
                End If

            End If

        End If
        If e.KeyCode = Keys.Enter And GridProductos.Focused Then ' Verificar si se ha presionado la tecla "Delete" en el DataGridView
            If GridProductos.Rows(GridProductos.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then Exit Sub
            If GridProductos.CurrentCell Is Nothing Then Exit Sub
            Dim columnIndex As Integer = GridProductos.CurrentCell.ColumnIndex ' Obtener el índice de la columna actual
            Dim columnName As String = GridProductos.Columns(columnIndex).Name ' Obtener el nombre de la columna actual
            Dim rowIndex As Integer = GridProductos.CurrentCell.RowIndex ' Obtener el índice de la fila actual
            'Dim rowTag As Object = GridProductos.Rows(rowIndex).Tag ' Obtener el contenido del tag de la fila actual
            Dim rowTag As Object = GridProductos.Rows(rowIndex).Cells("eli").Tag ' Obtener el contenido del tag de la celda actual

            If columnName = "eli" Then
                If GridProductos.Rows(GridProductos.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then
                    Exit Sub
                End If

                If GridProductos.Rows.Count - 1 = 0 Then
                    GridProductos.Rows.Clear()
                    Me.GridProductos.Rows.Add()
                    AddGridProductos_defecto()
                    Contador_filas()
                    Exit Sub
                End If
                GridProductos.Rows.Remove(GridProductos.CurrentRow) ' Eliminar la primera fila seleccionada

                Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle")
                Me.GridProductos.BeginEdit(True)
                Contador_filas()
            End If
            If columnName = "add" Then ' Verificar que se haya seleccionado alguna fila
                If GridProductos.Rows(rowIndex).Cells("add").Tag = "" Then Exit Sub
                Me.GridProductos.Rows.Add()
                AddGridProductos_defecto()
                Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle")
                Me.GridProductos.BeginEdit(True)
                Contador_filas()
                'GridProductos_PrimeraFila()
            End If
            If columnName = "ok" Then ' Verificar que se haya seleccionado alguna fila
                'ConfirmaTodoLote()
                'GridProductos_PrimeraFila()
            End If










        End If



    End Sub
    Private Sub AsignaLoteProducto(wes_automatico As Integer)
        If GridProductos.CurrentCell Is Nothing Then Exit Sub

        Dim wes_bloqueado As String = "0"
        Dim columnIndex As Integer = GridProductos.CurrentCell.ColumnIndex ' Obtener el índice de la columna actual
        Dim columnName As String = GridProductos.Columns(columnIndex).Name ' Obtener el nombre de la columna actual
        Dim rowIndex As Integer = GridProductos.CurrentCell.RowIndex ' Obtener el índice de la fila actual
        If Val(GridProductos.Rows(rowIndex).Cells("es_sin_stock").Value) = 1 Then
            SMS_Barra("Producto, FALTA STOCK...", 2)
            GridProductos.Select()
            Exit Sub
        End If
        If Val(GridProductos.Rows(rowIndex).Cells("es_control_lote").Value) = 0 Then Exit Sub

        If GridProductos.Rows(rowIndex).Cells("ok").Tag = "bloq" And Val(TxtEstadoComp.Tag) <> 4 Then
            wes_bloqueado = "1"
        End If
        If wes_automatico = 1 Then GoTo irllena
        If columnName = "lote" Or columnName = "det_lote" Then
irllena:
            If Val(GridProductos.Rows(rowIndex).Cells("cantidad").Value) = 0 Then
                SMS_Barra("Debe Ingresar Cantidad Solicitada al Producto...", 2)
                GridProductos.Select()
                Exit Sub
            End If
            Dim wsigno_kardex As Integer
            Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
            If Obtener_id_oper_maestro.Count = 0 Then
                SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
                Exit Sub
            End If
            wsigno_kardex = Obtener_id_oper_maestro(0)("signo_inventario")
            Dim wdirecto_id_oper_maestro As Integer = Obtener_id_oper_maestro(0)("directo_id_oper_maestro")
            If wdirecto_id_oper_maestro <> 0 Then
                Dim Obtener_directo_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_oper_maestro = " & wdirecto_id_oper_maestro & "")
                If Obtener_directo_id_oper_maestro.Count = 0 Then
                    SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
                    Exit Sub
                End If
                wsigno_kardex = Obtener_directo_id_oper_maestro(0)("signo_inventario")
            End If

            If wes_automatico = 1 And wsigno_kardex <> -1 Then
                Exit Sub
            End If
            Dim frlote As New FrmLoteOper

            frlote.Tag = 100
            frlote.ModoBusqeuda = "PROCESOS"
            frlote.LOTE_ES_AUTOMATICO = wes_automatico
            frlote.LOTE_ID_PROD_NOMBRE = GridProductos.Rows(rowIndex).Cells("descrip").Value & " [" & Trim(GridProductos.Rows(rowIndex).Cells("grupo").Value) & "]"
            frlote.LOTE_CANTIDAD_LOTE = GridProductos.Rows(rowIndex).Cells("cantidad").Value
            frlote.LOTE_CANTIDAD_PRES = GridProductos.Rows(rowIndex).Cells("present").Value
            frlote.LOTE_ID_PROD_MAE = Val(GridProductos.Rows(rowIndex).Cells("id_prod_mae").Value)
            frlote.LOTE_ID_LOCAL = Val(CmdLocal.Tag)
            frlote.LOTE_ID_ALMACEN = Val(GridProductos.Rows(rowIndex).Cells("id_almacen").Value)
            frlote.LOTE_EQUIV_PRES = Val(GridProductos.Rows(rowIndex).Cells("equiv").Value)

            frlote.LOTE_CADENALOTES = Trim(GridProductos.Rows(rowIndex).Cells("cadenalotes").Value)
            frlote.LOTE_CADENALOTES_FORMATO = ""




            frlote.LOTE_ID_PRES_BASE = Val(GridProductos.Rows(rowIndex).Cells("id_pres_base").Value)
            frlote.LOTE_ABREVIADO_BASE = Trim(GridProductos.Rows(rowIndex).Cells("abreviado_base").Value)
            frlote.LOTE_EQUIV_BASE = Val(GridProductos.Rows(rowIndex).Cells("equiv_base").Value)
            frlote.LOTE_ES_BLOQUEADO = wes_bloqueado





            If wsigno_kardex = 1 Then
                frlote.TipoRegistro = "INGRESO"
            Else
                frlote.TipoRegistro = "SALIDA"
            End If
            ' frlote.TextoBusca = valorlote
            If frlote.ShowDialog() = DialogResult.OK Then
                If frlote.LOTE_SIN_LOTE = 1 Then
                Else
                    GridProductos.Rows(rowIndex).Cells("det_lote").Value = frlote.DatosLoteProd
                    GridProductos.Rows(rowIndex).Cells("lote").Value = frlote.lote_defecto
                    GridProductos.Rows(rowIndex).Cells("cadenalotes").Value = frlote.LOTE_CADENALOTES
                    GridProductos.Rows(rowIndex).Cells("cadenalotes_formato").Value = frlote.LOTE_CADENALOTES_FORMATO
                End If




            End If
            Exit Sub
        End If
    End Sub
    Private Sub AddGridProductos_defecto()
        If GridProductos.Rows.Count = 1 Then
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("almacen").Value = Oper_Almacen_Defecto.codigo
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("alm_abreviado").Value = Oper_Almacen_Defecto.abreviado
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_almacen").Value = Oper_Almacen_Defecto.id_almacen
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("codigo_local_serv").Value = TxtLocal.Text
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("des_local_serv").Value = CmdLocal.Text
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_local_serv").Value = CmdLocal.Tag

        Else
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("almacen").Value = GridProductos.Rows(GridProductos.Rows.Count - 2).Cells("almacen").Value
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("alm_abreviado").Value = GridProductos.Rows(GridProductos.Rows.Count - 2).Cells("alm_abreviado").Value
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_almacen").Value = GridProductos.Rows(GridProductos.Rows.Count - 2).Cells("id_almacen").Value

            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("codigo_local_serv").Value = GridProductos.Rows(GridProductos.Rows.Count - 2).Cells("codigo_local_serv").Value
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("des_local_serv").Value = GridProductos.Rows(GridProductos.Rows.Count - 2).Cells("des_local_serv").Value
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_local_serv").Value = GridProductos.Rows(GridProductos.Rows.Count - 2).Cells("id_local_serv").Value

            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("es_servicio").Value = GridProductos.Rows(GridProductos.Rows.Count - 2).Cells("es_servicio").Value
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_tb_tipo_serv").Value = GridProductos.Rows(GridProductos.Rows.Count - 2).Cells("id_tb_tipo_serv").Value
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("tipo_serv_des").Value = GridProductos.Rows(GridProductos.Rows.Count - 2).Cells("tipo_serv_des").Value
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("area_serv_des").Value = GridProductos.Rows(GridProductos.Rows.Count - 2).Cells("area_serv_des").Value
            GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_area").Value = GridProductos.Rows(GridProductos.Rows.Count - 2).Cells("id_area").Value

        End If
    End Sub

    Private Sub GridProductos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles GridProductos.RowsAdded
        Contador_filas()
    End Sub

    Private Sub GridProductos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles GridProductos.RowsRemoved
        Contador_filas()
    End Sub

    Private Sub GridProductos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridProductos.KeyPress
        e.Handled = False

        If Strings.Left(GridProductos.CurrentCell.OwningColumn.Tag, 1) = "C" And e.KeyChar <> Chr(13) Then ' cUALQUIER vALOR
            Dim comboBox As DataGridViewComboBoxCell = CType(GridProductos.CurrentCell, DataGridViewComboBoxCell)
            comboBox.Selected = False
            comboBox.DataGridView.BeginEdit(True)

            ' Mostrar la lista desplegable del ComboBox
            If comboBox.Items.Count > 0 Then
                comboBox.FlatStyle = FlatStyle.Flat
                comboBox.DisplayStyle = ComboBoxStyle.DropDown
            End If
        End If

    End Sub



    Private Sub GridCuentasn_Inicia_CTASN1(wes_opcional_lote As Integer, es_condesc1 As Integer, es_condesc2 As Integer)
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()
        ' Dim controlLabel As Label





        dg_cuentasn.Columns.Clear()



        dg_cuentasn.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)

        textoColumn.Name = "num"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 25
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "descrip"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "NOMBRES DE SOCIO DE NEGOCIO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'textoColumn.HeaderCell.Style.BackColor = Color.Gray ' Cambiar el color de fondo de la cabecera
        'textoColumn.HeaderCell.Style.ForeColor = Color.White ' Cambiar el color del texto de la cabecera
        'textoColumn.HeaderCell.Style.ForeColor = Color.White ' Cambiar el color del texto de la cabecera

        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 230
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True

        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "masdetalle"
        BotonColumn.HeaderText = "INF"
        BotonColumn.FlatStyle = FlatStyle.Flat
        dg_cuentasn.Columns.Add(BotonColumn)
        dg_cuentasn.Columns.Item(BotonColumn.Name).Width = 25

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigo"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "CODIGO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 50
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_sn_master"
        textoColumn.HeaderText = "id_sn_master"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 0
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codcomp"
        textoColumn.Tag = "C4"
        textoColumn.HeaderText = "COD COMP"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 35
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "seriecomp"
        textoColumn.Tag = "C4"
        textoColumn.HeaderText = "SERIE"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 35
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "numerocomp"
        textoColumn.Tag = "C8"
        textoColumn.HeaderText = "NUMERO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 55
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "BUS"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "buscarcomp"
        imageColumn.Image = My.Resources.buscar
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_cuentasn.Columns.Add(imageColumn)
        dg_cuentasn.Columns.Item(imageColumn.Name).Width = 25
        dg_cuentasn.Columns.Item(imageColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "VER"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "vercomp"
        imageColumn.Image = My.Resources.ver
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_cuentasn.Columns.Add(imageColumn)
        dg_cuentasn.Columns.Item(imageColumn.Name).Width = 20
        dg_cuentasn.Columns.Item(imageColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fechaemis"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "FEC.EMIS"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 75
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "local"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "LOCAL"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 35
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "MOD"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 30
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "monto"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MONTO COMP"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).MinimumWidth = 70
        dg_cuentasn.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "saldo"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "SALDO COMP"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).MinimumWidth = 70
        dg_cuentasn.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fechavcto"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "FECHA VCTO."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 50
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "aplicar"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MONTO APLICAR"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 70
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "condicion"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "COND COMP"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 40
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "vendedor"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "VEND."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 40
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "hecho"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "HECHO POR"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 50
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fechahora"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "FECHA HORA"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 70
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_oper_maestro"
        textoColumn.HeaderText = "id_oper_maestro"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 0
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_comp_cab"
        textoColumn.HeaderText = "id_comp_cab"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 0
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_carterasn_cab"
        textoColumn.HeaderText = "id_carterasn_cab"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 0
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_carterasn_det"
        textoColumn.HeaderText = "id_carterasn_det"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 0
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "oper_codigo"
        textoColumn.HeaderText = "oper_codigo"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 0
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "signo_sn"
        textoColumn.HeaderText = "signo_sn"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 0
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False






        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "add"
        imageColumn.Image = My.Resources.add
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_cuentasn.Columns.Add(imageColumn)
        dg_cuentasn.Columns.Item(imageColumn.Name).Width = 25
        dg_cuentasn.Columns.Item(imageColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "eli"
        imageColumn.Image = My.Resources.add
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_cuentasn.Columns.Add(imageColumn)
        dg_cuentasn.Columns.Item(imageColumn.Name).Width = 25
        dg_cuentasn.Columns.Item(imageColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "ok"
        imageColumn.Image = My.Resources.ok
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_cuentasn.Columns.Add(imageColumn)
        dg_cuentasn.Columns.Item(imageColumn.Name).Width = 25
        dg_cuentasn.Columns.Item(imageColumn.Name).ReadOnly = False



        Dim controlLabel As Label

        ' HABILITA TOTAL 
        controlLabel = PanelPie.Controls.Find("BoxTOT4", True).FirstOrDefault()
        If controlLabel IsNot Nothing Then
            controlLabel.Text = "TOTAL " & CmdMonedaComp.AccessibleName
            controlLabel.Visible = True
            controlLabel.Tag = "0"
            controlLabel.AccessibleName = "subtotal"
        End If




        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "almacen"
        'textoColumn.Tag = "E2"
        'textoColumn.HeaderText = "ALM"
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'dg_cuentasn.Columns.Add(textoColumn)
        'dg_cuentasn.Columns.Item(textoColumn.Name).Width = 30
        'dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        'textoColumn.DefaultCellStyle.Format = "00" ' Formato de porcentaje
        'textoColumn.ValueType = GetType(Integer) ' Tipo de valor de la celda
        'e


        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "preciobase"
        'textoColumn.Tag = "N10"
        'textoColumn.HeaderText = "PRECIO BASE"
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'dg_cuentasn.Columns.Add(textoColumn)
        'dg_cuentasn.Columns.Item(textoColumn.Name).MinimumWidth = 70
        'dg_cuentasn.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        'dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        'textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        'textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda









    End Sub

    Private Sub GridProductos_Inicia_PROD1(wes_opcional_lote As Integer, es_condesc1 As Integer, es_condesc2 As Integer)
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()
        Dim controlLabel As Label
        Dim wes_control_lote As Integer = 0
        Dim wpor_impt As Double = 18




        ' HABILITA TOTAL VALOR
        controlLabel = PanelPie.Controls.Find("BoxTOT1", True).FirstOrDefault()
        If controlLabel IsNot Nothing Then
            controlLabel.Text = "OP.GRAVADA " & CmdMonedaComp.AccessibleName
            controlLabel.Tag = "0"
            controlLabel.AccessibleName = "valor"
            controlLabel.Visible = True
        End If
        ' HABILITA TOTAL VALOR
        controlLabel = PanelPie.Controls.Find("BoxTOT2", True).FirstOrDefault()
        If controlLabel IsNot Nothing Then
            controlLabel.Text = "OP.EXONERADO " & CmdMonedaComp.AccessibleName
            controlLabel.Tag = "0"
            controlLabel.AccessibleName = "exonerado"
            controlLabel.Visible = True
        End If
        ' HABILITA IMPUESTO
        controlLabel = PanelPie.Controls.Find("BoxTOT3", True).FirstOrDefault()
        If controlLabel IsNot Nothing Then
            controlLabel.Text = "IMPTO(" & Format(wpor_impt, "##.##") & ") " & CmdMonedaComp.AccessibleName
            controlLabel.Tag = "0"
            controlLabel.AccessibleName = "impto"
            controlLabel.Visible = True
        End If

        ' HABILITA TOTAL 
        controlLabel = PanelPie.Controls.Find("BoxTOT4", True).FirstOrDefault()
        If controlLabel IsNot Nothing Then
            controlLabel.Text = "TOTAL " & CmdMonedaComp.AccessibleName
            controlLabel.Visible = True
            controlLabel.Tag = "0"
            controlLabel.AccessibleName = "subtotal"
        End If

        controlLabel = PanelPie.Controls.Find("BoxTOT5", True).FirstOrDefault()
        If controlLabel IsNot Nothing Then
            controlLabel.Text = "TOT.BONF(REF) " & CmdMonedaComp.AccessibleName
            controlLabel.Visible = True
            controlLabel.Tag = "0"
            controlLabel.AccessibleName = "bonif"
        End If






        GridProductos.Refresh()
        If GridProductos.Columns.Count > 10 Then
            Exit Sub
        End If
        GridProductos.Columns.Clear()



        GridProductos.DefaultCellStyle.Font = New Font("Segoe UI", 9.25)


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "num"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 25
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True



        ' COLUMNAS PARA OPCIONES DE SERVICIO
        '===================================

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "es_servicio"
        textoColumn.HeaderText = "es_servicio"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_tb_tipo_serv"
        textoColumn.HeaderText = "id_tb_tipo_serv"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_serv"
        textoColumn.HeaderText = "id_serv"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_area"
        textoColumn.HeaderText = "id_area"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_uci"
        textoColumn.HeaderText = "id_uci"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_local_serv"
        textoColumn.HeaderText = "id_local_serv"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False


        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "tipo_serv_des"
        BotonColumn.Tag = "A"
        BotonColumn.HeaderText = "DESCRIP"
        BotonColumn.FlatStyle = FlatStyle.Flat
        BotonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        BotonColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(BotonColumn)
        GridProductos.Columns.Item(BotonColumn.Name).Width = 70
        GridProductos.Columns.Item(BotonColumn.Name).ReadOnly = True
        BotonColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ' Alineación hacia la derecha

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigo_serv"
        textoColumn.Tag = "E2"
        textoColumn.HeaderText = "COD. SERV."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 40
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Integer) ' Tipo de valor de la celda


        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "des_serv"
        BotonColumn.Tag = "E2"
        BotonColumn.FlatStyle = FlatStyle.Flat
        BotonColumn.HeaderText = "DET. SERV."
        BotonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        BotonColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(BotonColumn)
        GridProductos.Columns.Item(BotonColumn.Name).Width = 70
        GridProductos.Columns.Item(BotonColumn.Name).ReadOnly = False
        BotonColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ' Alineación hacia la derecha
        BotonColumn.DefaultCellStyle.Format = "00" ' Formato de porcentaje
        BotonColumn.ValueType = GetType(Integer) ' Tipo de valor de la celda

        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "area_serv_des"
        BotonColumn.Tag = "A"
        BotonColumn.FlatStyle = FlatStyle.Flat
        BotonColumn.HeaderText = "AREA"
        BotonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        BotonColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        BotonColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ' Alineación hacia la derecha
        GridProductos.Columns.Add(BotonColumn)
        GridProductos.Columns.Item(BotonColumn.Name).Width = 70
        GridProductos.Columns.Item(BotonColumn.Name).ReadOnly = True



        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "uci_serv_des"
        BotonColumn.Tag = "A"
        BotonColumn.HeaderText = "U.C.I."
        BotonColumn.FlatStyle = FlatStyle.Flat
        BotonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        BotonColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        BotonColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ' Alineación hacia la derecha
        GridProductos.Columns.Add(BotonColumn)
        GridProductos.Columns.Item(BotonColumn.Name).Width = 70

        GridProductos.Columns.Item(BotonColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigo_local_serv"
        textoColumn.Tag = "E2"
        textoColumn.HeaderText = "LOCAL"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 40
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Integer) ' Tipo de valor de la celda


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "des_local_serv"
        textoColumn.Tag = "A"
        textoColumn.HeaderText = "DESCRIP"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 60
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha

        '================================================








        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "almacen"
        textoColumn.Tag = "E2"
        textoColumn.HeaderText = "ALM"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 30
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Integer) ' Tipo de valor de la celda


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "alm_abreviado"
        textoColumn.Tag = "A"
        textoColumn.HeaderText = "NOM"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 50
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha


        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "es_prod_new"
        checkColumn.HeaderText = "NEW PROD"
        checkColumn.HeaderCell.Style.Font = New Font("Arial", 5.5F)
        checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridProductos.Columns.Add(checkColumn)
        GridProductos.Columns.Item(checkColumn.Name).Width = 30
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "grupo"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "GRUPO ó LAB."
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 50
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True

        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "es_prod_bof"
        checkColumn.HeaderText = "BNF"
        checkColumn.HeaderCell.Style.Font = New Font("Arial", 5.5F)
        checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridProductos.Columns.Add(checkColumn)
        GridProductos.Columns.Item(checkColumn.Name).Width = 27
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "descrip"
        textoColumn.Tag = "A200"
        textoColumn.HeaderText = "DESCRIPCION PRODUCTO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 340
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "detalle_serv"
        textoColumn.Tag = "A200"
        textoColumn.HeaderText = "DETALLE SERV."
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 280
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True


        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "masdetalle"
        BotonColumn.HeaderText = "INF"
        BotonColumn.FlatStyle = FlatStyle.Flat
        GridProductos.Columns.Add(BotonColumn)
        GridProductos.Columns.Item(BotonColumn.Name).Width = 25



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigo"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "CODIGO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 60
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_prod_mae"
        textoColumn.HeaderText = "id_prod_mae"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 0
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_prod_mae_codigo"
        textoColumn.HeaderText = "id_prod_mae_codigo"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 0
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        GridProductos.Columns.Item(textoColumn.Name).Visible = False



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "cantidad"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "CANTID."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 50
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False




        comboColumn = New DataGridViewComboBoxColumn()
        comboColumn.Name = "present"
        comboColumn.Tag = "C"
        comboColumn.HeaderText = "PRESENT."
        comboColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        comboColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        comboColumn.FlatStyle = FlatStyle.Flat
        GridProductos.Columns.Add(comboColumn)
        GridProductos.Columns.Item(comboColumn.Name).Width = 80
        GridProductos.Columns.Item(comboColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_pres"
        textoColumn.HeaderText = "id_pres"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 50
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "equiv"
        textoColumn.HeaderText = "equiv"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 0
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True
        GridProductos.Columns.Item(textoColumn.Name).Visible = False



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "cantidad_saldo"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "CANTID. SALDO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 50
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        GridProductos.Columns.Item(textoColumn.Name).Visible = False


        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "lote"
        BotonColumn.Tag = "A20"
        BotonColumn.HeaderText = "LOT"
        BotonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        BotonColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        BotonColumn.FlatStyle = FlatStyle.Flat
        GridProductos.Columns.Add(BotonColumn)
        GridProductos.Columns.Item(BotonColumn.Name).Width = 40
        GridProductos.Columns.Item(BotonColumn.Name).ReadOnly = False
        BotonColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        If wes_control_lote = 0 Then
            GridProductos.Columns.Item(BotonColumn.Name).Visible = False
        Else
            GridProductos.Columns.Item(BotonColumn.Name).Visible = True
        End If

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "det_lote"
        textoColumn.Tag = "A"
        textoColumn.HeaderText = "FV"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 40
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        If wes_control_lote = 0 Then
            GridProductos.Columns.Item(textoColumn.Name).Visible = False
        Else
            GridProductos.Columns.Item(textoColumn.Name).Visible = True
        End If



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_almacen"
        textoColumn.HeaderText = "id_almacen"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 0
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "num_sec"
        textoColumn.HeaderText = "num_sec"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 0
        GridProductos.Columns.Item(textoColumn.Name).Visible = False



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "saldo_pend"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "CANTID. SALDO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 50
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        GridProductos.Columns.Item(textoColumn.Name).Visible = False



        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "BUSQ PREC"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "preciolista"
        imageColumn.Image = My.Resources.precio
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        GridProductos.Columns.Add(imageColumn)
        GridProductos.Columns.Item(imageColumn.Name).Width = 30
        GridProductos.Columns.Item(imageColumn.Name).ReadOnly = False




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "preciobase"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "PRECIO BASE"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).MinimumWidth = 70
        GridProductos.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#0.00##" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "des1"
        textoColumn.Tag = "N4"
        textoColumn.HeaderText = "DCTO1.%"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 55
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        If es_condesc1 = 1 Then
            GridProductos.Columns.Item(textoColumn.Name).Visible = True
        Else
            GridProductos.Columns.Item(textoColumn.Name).Visible = False
        End If



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "des2"
        textoColumn.Tag = "N4"
        textoColumn.HeaderText = "DCTO2.%"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 55
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        If es_condesc2 = 1 Then
            GridProductos.Columns.Item(textoColumn.Name).Visible = True
        Else
            GridProductos.Columns.Item(textoColumn.Name).Visible = False
        End If


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "valor"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "VALOR"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).MinimumWidth = 70
        GridProductos.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "impto"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "IMPTO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).MinimumWidth = 68
        GridProductos.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda



        '78
        '67
        '78

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "subtotal"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "VALOR SUBTOTAL*"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).MinimumWidth = 70
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        GridProductos.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda



        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "add"
        imageColumn.Image = My.Resources.add
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        GridProductos.Columns.Add(imageColumn)
        GridProductos.Columns.Item(imageColumn.Name).Width = 25
        GridProductos.Columns.Item(imageColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "eli"
        imageColumn.Image = My.Resources.add
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        GridProductos.Columns.Add(imageColumn)
        GridProductos.Columns.Item(imageColumn.Name).Width = 25
        GridProductos.Columns.Item(imageColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "ok"
        imageColumn.Image = My.Resources.ok
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        GridProductos.Columns.Add(imageColumn)
        GridProductos.Columns.Item(imageColumn.Name).Width = 25
        GridProductos.Columns.Item(imageColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "Unidades"
        textoColumn.Tag = "Unidades"
        textoColumn.HeaderText = "Guarda unidades"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 0
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_almacen_trasnf"
        textoColumn.Tag = "id_almacen_trasnf"
        textoColumn.HeaderText = "id_almacen_trasnf" ' Guarda If id almacen de las reciones de mercadeira
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 0
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "cadenalotes"
        textoColumn.Tag = "cadenalotes"
        textoColumn.HeaderText = "cadenalotes" ' Guarda cadena de detalle que seleciono lotes 
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 0
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "cadenalotes_formato"
        textoColumn.Tag = "cadenalotes_formato"
        textoColumn.HeaderText = "cadenalotes_formato" ' Guarda cadena de detalle que seleciono lotes 
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Width = 0
        GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True
        GridProductos.Columns.Item(textoColumn.Name).Visible = False



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_pres_base"
        textoColumn.HeaderText = "id_pres_base"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "abreviado_base"
        textoColumn.HeaderText = "abreviado_base"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "equiv_base"
        textoColumn.HeaderText = "equiv_base"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "es_control_lote"
        textoColumn.HeaderText = "es_control_lote"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_comp_det"
        textoColumn.HeaderText = "id_comp_det"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_comp_det_emlace"
        textoColumn.HeaderText = "id_comp_det_emlace"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "modocalculo"
        textoColumn.HeaderText = "modocalculo"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "precio_valor"
        textoColumn.HeaderText = "precio_valor"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "cosproactual"
        textoColumn.HeaderText = "cosproactual"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "stockactual"
        textoColumn.HeaderText = "stockactual"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "cadenaprecios"
        textoColumn.HeaderText = "cadenaprecios"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_pres_precio"
        textoColumn.HeaderText = "id_pres_precio"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "es_inventariable"
        textoColumn.HeaderText = "es_inventariable"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "es_exonerado"
        textoColumn.HeaderText = "es_exonerado"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "es_sin_stock"
        textoColumn.HeaderText = "es_sin_stock"
        GridProductos.Columns.Add(textoColumn)
        GridProductos.Columns.Item(textoColumn.Name).Visible = False





        GridProductos.Refresh()

        Actualiza_Oper_Maestro() ' ara opcions particuaes dela operacion 


        ' Asigna el modo el promer modo de calculo por defcto
        If chkConIMPTO.Checked Then AsignarModoCalculo_GridPROD1(1)
        If chkSinIMPTO.Checked Then AsignarModoCalculo_GridPROD1(2)


        ' AREA DE TOTALES:
        ' Parabuscar control 



        ' HABILITA ITEMS
        controlLabel = PanelPie.Controls.Find("BoxTOT11", True).FirstOrDefault()
        If controlLabel IsNot Nothing Then
            controlLabel.Text = "ITEM (0) "
            controlLabel.Visible = True
            controlLabel.Tag = "0"
            controlLabel.AccessibleName = "item"
        End If

        ' HABILITA PESO
        controlLabel = PanelPie.Controls.Find("BoxTOT12", True).FirstOrDefault()
        If controlLabel IsNot Nothing Then
            controlLabel.Text = "PESO()KG "
            controlLabel.Visible = True
            controlLabel.Tag = "0"
            controlLabel.AccessibleName = "peso"
        End If







    End Sub

    Private Sub AsignarModoCalculo_GridPROD1(wmodocal As Integer)
        Dim wcal_id_prod_mae As Integer
        ' PT =  DESDE EL PRECIO CON IMPTO
        ' TO =   DEL TOTAL HACIA EL PRECIO CON IMPTO
        ' PV =  DESDE EL PRECIO SIN IMPTO AL TOTAL
        ' VA =  DESDE AL VALOR SIN IMPTTO

        GridProductos.AccessibleDescription = wmodocal
        For i = 0 To GridProductos.Rows.Count - 1
            wcal_id_prod_mae = GridProductos.Rows(i).Cells("id_prod_mae").Value
            If wmodocal = 1 Then  ' ASIGNAR POR DEFETO AL PRECIO
                GridProductos.Rows(i).Cells("modocalculo").Value = "PT"
            Else
                GridProductos.Rows(i).Cells("modocalculo").Value = "PV"
            End If
        Next i

    End Sub
    Private Sub CmdZonaDetalle_Click(sender As Object, e As EventArgs) Handles CmdZonaDetalle.Click
        If ZonaDetalle.Visible = True Then Exit Sub
        ZonaMasDetalles.Visible = False
        ZonaAdjuntos.Visible = False
        ZonaDetalle.Dock = DockStyle.Fill
        ZonaDetalle.Visible = True

    End Sub

    Private Sub CmdMasDetalles_Click(sender As Object, e As EventArgs) Handles CmdMasDetalles.Click
        If ZonaMasDetalles.Visible = True Then Exit Sub
        ZonaAdjuntos.Visible = False
        ZonaDetalle.Visible = False
        ZonaMasDetalles.Dock = DockStyle.Fill
        ZonaMasDetalles.Visible = True
    End Sub

    Private Sub CmdAdjuntos_Click(sender As Object, e As EventArgs) Handles CmdAdjuntos.Click
        If ZonaAdjuntos.Visible = True Then Exit Sub
        ZonaMasDetalles.Visible = False
        ZonaDetalle.Visible = False
        ZonaAdjuntos.Dock = DockStyle.Fill
        ZonaAdjuntos.Visible = True
    End Sub

    Private Sub TxtComp_codigo_TextChanged(sender As Object, e As EventArgs) Handles TxtComp_codigo.TextChanged

    End Sub

    Private Sub TxtComp_codigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtComp_codigo.KeyPress
        Solo_Numero(e)

        If e.KeyChar = Chr(13) Then
            If MostraComprobante(TxtComp_codigo.Text) = False Then
                SMS_Barra("No Existe Codigo de Comprobante...", 2)
                TxtComp_codigo.SelectAll()
                Exit Sub
            End If
            If CmdSerireComp.Visible Then
                If e.KeyChar = Chr(Keys.Enter) Then
                    SaltoBox(BoxFechas.AccessibleName)
                End If

                '                CmdSerireComp.Select()
            Else
                TxtSerireComp.Focus()
            End If

        End If

    End Sub
    Private Function MostraComprobante(wcodigo As String) As Boolean
        MostraComprobante = False

        If Len(wcodigo) <> 2 Then
            'CmdLocal_Click(Nothing, Nothing)
            Exit Function
        End If




        Dim Comprobantes() As DataRow = lk_sql_comp_oper.Select("id_tb_oper = " & TxtOperacion.Tag & " and es_interno = 0 and codigo='" & wcodigo & "'")
        ' Recorremos las filas filtradas
        If Comprobantes.Length = 0 Then
            ' Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
            '                         "Local.")
            '  CmdLocal_Click(Nothing, Nothing)
            Exit Function
        End If
        TxtComp_codigo.Text = Comprobantes(0)("codigo")
        TxtComp_codigo.Tag = Comprobantes(0)("id_comprobante")

        CmdComprob.Text = Space(10) & Comprobantes(0)("abreviado")
        CmdComprob.Tag = Comprobantes(0)("id_comprobante")
        CmdComprob.AccessibleName = Comprobantes(0)("codigo")
        CmdComprob.AccessibleDescription = Comprobantes(0)("es_manual")
        PordefectoSerie(Val(CmdLocal.Tag), Val(CmdComprob.Tag))
        MostraComprobante = True
    End Function
    Private Sub TxtComp_Numero_TextChanged(sender As Object, e As EventArgs) Handles TxtComp_Numero.TextChanged

    End Sub

    Private Sub TxtComp_Numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtComp_Numero.KeyPress

        If e.KeyChar = Chr(Keys.Enter) Then
            SaltoBox(BoxComprobantes.AccessibleName)
        Else
            If CmdSerireComp.Visible Then e.Handled = True
        End If
    End Sub

    Private Sub TxtFechas_Emis_ValueChanged(sender As Object, e As EventArgs) Handles TxtFechas_Emis.ValueChanged

    End Sub

    Private Sub TxtFechas_Emis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFechas_Emis.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SaltoBox(BoxFechas.AccessibleName)
        End If
    End Sub


    Private Sub CmbMoneda_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub
    Private Sub CmbMoneda_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Enter Then
            SaltoBox(BoxMoneda.AccessibleName)
        End If
    End Sub

    Private Sub TxtCondi_FecVcto_ValueChanged(sender As Object, e As EventArgs) Handles TxtCondi_FecVcto.ValueChanged

    End Sub

    Private Sub TxtCondi_FecVcto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCondi_FecVcto.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SaltoBox(BoxCondicion.AccessibleName)
        End If

    End Sub

    Private Sub TxtPrioridad_FecAten_ValueChanged(sender As Object, e As EventArgs) Handles TxtPrioridad_FecAten.ValueChanged

    End Sub

    Private Sub TxtPrioridad_FecAten_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPrioridad_FecAten.KeyPress

        If e.KeyChar = Chr(Keys.Enter) Then
            SaltoBox(BoxAtencion.AccessibleName)
        End If
    End Sub





    Private Sub TxtVendedor_Codigo_TextChanged(sender As Object, e As EventArgs) Handles TxtVendedor_Codigo.TextChanged

    End Sub

    Private Sub TxtVendedor_Codigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtVendedor_Codigo.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SaltoBox(BoxVendedor.AccessibleName)
        End If
    End Sub



    Private Function BuscaProductos(cadena As String, wfila As Integer, wcol As Integer) As Boolean
        BuscaProductos = True
        If Len(cadena) = 3 Then
            'Si hay una fila seleccionada, establece una cadena vacía en la caja de texto de la celda de la columna "Precio"
            'If selectedRow IsNot Nothing Then
            'Obtén el control de caja de texto dentro de la celda de la columna "Precio"

            Dim GridselectedRow As DataGridViewRow = GridProductos.CurrentRow
            Dim txtBox As DataGridViewTextBoxEditingControl = CType(GridProductos("codigo", GridselectedRow.Index).DataGridView.EditingControl, DataGridViewTextBoxEditingControl)

            'Establece una cadena vacía en la caja de texto
            txtBox.Text = ""
            'End If

            GridProductos.Rows(wfila).Cells("codigo").Value = "" ' destruir para que no busque denuevo a su retrono




            Dim frbusca As New FrmProductos

            frbusca.Tag = 100
            frbusca.TxtBuscar.Tag = TxtSocio_BoxSN.Text
            frbusca.ModoBusqeuda = "PROCESOS"
            frbusca.TextoBusca = TxtNumDocOper.Text
            frbusca.ShowDialog()


            'Dim frbusca As New FrmProductos
            'frbusca.Tag = 100
            'frbusca.TxtBuscar.Tag = TxtSocio_BoxSN.Text
            'frbusca.ModoBusqeuda = "PROCESOS"
            'frbusca.TextoBusca = cadena
            'frbusca.ShowDialog()
            'Flag_Buscando_Prod = True
            'If frbusca.ShowDialog() = DialogResult.OK Then
            '    'Obtener la fila actual seleccionada del DataGridView devuelto del formulario secundario
            '    ' Dim selectedRow As DataGridViewRow = FrBuscaProducto.SelectedRow
            '    '  Dim MIVA As String = selectedRow.Cells("NombreProducto").Value.ToString()
            '    Stop
            '    'Dim value As String = selectedRow.Cells("NombreProducto").Value.ToString()

            '    ' GridProductos.Rows(wfila).Cells("descrip").Value = "PRODCTUIO AAAAA"
            '    '    ' GridProductos.Rows(wfila).Cells("codigo").Value = "100"

            '    'Aquí puedes utilizar la fila actual seleccionada del DataGridView devuelto para realizar cualquier acción que requieras
            'End If











            'Dim myNumber As Integer = 123
            'Dim form2 As New Form2()
            'form2.Number = myNumber
            'form2.Show()



            'frbusca.Close()
            'If Trim(frbusca.Tag) = "" Then
            'Else
            '    Dim windexR As Integer = Val(Trim(frbusca.Tag))
            '    Dim wcbarra As String = frbusca.DataGridResul.Rows(0).Cells("codigo").Value.ToString()

            '    '    MuestraGridProd_Linea(frbusca.DataGridResul, windexR, wfila)
            '    '    frbusca.Close()

            '    '    ' GridProductos.Rows(wfila).Cells("descrip").Value = "PRODCTUIO AAAAA"
            '    '    ' GridProductos.Rows(wfila).Cells("codigo").Value = "100"

            'End If

            BuscaProductos = False
        End If
    End Function
    Private Sub MuestraGridProd_Linea(GridLineaResul As DataGridView, windexR As Integer, wFilaGrid As Integer)
        Dim wnombre As String = GridLineaResul.Rows(windexR).Cells("NombreProducto").Value.ToString()
        Dim wcodigo As String = GridLineaResul.Rows(windexR).Cells("codigo").Value.ToString()
        Dim wcbarra As String = GridLineaResul.Rows(windexR).Cells("cbarra").Value.ToString()
        GridProductos.Rows(wFilaGrid).Cells("codigo").Value = wcodigo
        GridProductos.Rows(wFilaGrid).Cells("descrip").Value = wnombre
        'GridProductos.Columns.Item("descrip").ReadOnly = False

        'GridProductos.Columns.Item("descrip").ReadOnly = True




        '




    End Sub

    '.Item("Codigo").Visible = True
    '.Item("Codigo").Width = 40
    '.Item("id_prod_mae").Visible = False

    '.Item("id_prod").Visible = False
    '.Item("NombreProducto").Visible = True
    '.Item("NombreProducto").Width = 300
    '.Item("estado").Visible = False

    '.Item("es_exonerado").Visible = False

    '.Item("cbarra").Visible = False

    '.Item("id_tipo_prod").Visible = False

    '.Item("Lab_Linea").Visible = True
    '.Item("Lab_Linea").Width = 150
    '.Item("GrupoMed20").Visible = True
    '.Item("GrupoMed20").Width = 100
    '.Item("TipoProd10").Visible = True
    '.Item("TipoProd10").Width = 100
    '.Item("PrinActivo").Visible = False
    '.Item("Concentracion").Visible = False
    '.Item("PreLocalDef").Visible = False
    '.Item("StockAlmDef").Visible = False
    '.Item("id_presentacion").Visible = False
    '.Item("Presentaciones").Visible = False
    '.Item("Presentaciones").Visible = False

    '.Item("es_control_lote").Visible = False
    '.Item("es_inventariable").Visible = False
    '.Item("diasprevios_lote").Visible = False
    '.Item("diasalerta_lote").Visible = False
    '.Item("diasalerta_lote").Visible = False
    '.Item("Unidades").Visible = False
    '.Item("lotes").Visible = False





    Private Sub GridProductos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles GridProductos.CellValueChanged
        ' If Flag_Buscando_Prod = True Then Exit Sub


        If GridProductos.Visible = False Then Exit Sub
        If GridProductos.CurrentCell Is Nothing Then Exit Sub

        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso GridProductos.Columns(e.ColumnIndex).Name = "es_prod_bof" Then
            Calcula_PROD1(Val(GridProductos.AccessibleDescription))
            GridProductos.Refresh()

        End If
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso GridProductos.Columns(e.ColumnIndex).Name = "es_prod_new" Then
            ' Acción a realizar cuando se modifica la casilla de verificación.

            If CBool(GridProductos.Rows(e.RowIndex).Cells("es_prod_new").Value) Then
                ' La casilla de verificación se activó.
                Prepara_Columnas_NuevoProducto(True, e.RowIndex)
            Else
                Prepara_Columnas_NuevoProducto(False, e.RowIndex)
            End If
            Exit Sub
        End If



        If GridProductos.Rows(e.RowIndex).Cells("ok").Tag = "bloq" Then Exit Sub
        If Strings.Trim(GridProductos.CurrentCell.OwningColumn.Name) = "present" Then
            ' Valido si es producto nuevo 
            If GridProductos.Rows(e.RowIndex).Cells("es_prod_new").Value Then
                'Stop
                Exit Sub
            End If

            Dim wpres As String = GridProductos.Rows(e.RowIndex).Cells("Unidades").Value


            Dim comboCell As DataGridViewComboBoxCell = CType(GridProductos.Rows(e.RowIndex).Cells("present"), DataGridViewComboBoxCell)
            Dim currentCell As DataGridViewCell = GridProductos.CurrentCell
            Dim editedValue As Object = currentCell.EditedFormattedValue
            Dim selectedIndex As Integer = comboCell.Items.IndexOf(editedValue)
            If selectedIndex < 0 Then Exit Sub

            'Dim selectedIndex As Integer = comboCell.SelectedIndex '
            Dim valoresDict As Dictionary(Of Integer, Tuple(Of String, Integer, Integer)) = CType(comboCell.Tag, Dictionary(Of Integer, Tuple(Of String, Integer, Integer))) ' Obtenemos el diccionario almacenado en la propiedad Tag
            If valoresDict.ContainsKey(selectedIndex) Then
                Dim valorSeleccionado As Tuple(Of String, Integer, Integer) = valoresDict(selectedIndex) ' Obtenemos la tupla completa correspondiente al índice seleccionado
                ' Hacer algo con la tupla completa...
                Dim valor1 As String = valorSeleccionado.Item1
                Dim valor2 As Integer = valorSeleccionado.Item2
                Dim valor3 As Integer = valorSeleccionado.Item3
                GridProductos.Rows(e.RowIndex).Cells("id_pres").Value = valor3
                GridProductos.Rows(e.RowIndex).Cells("equiv").Value = valor2

                Dim wtipo_signo As Integer = -1
                Dim wid_prod_mae As Integer = GridProductos.Rows(e.RowIndex).Cells("id_prod_mae").Value
                Dim wid_negocio As Integer = lk_NegocioActivo.id_Negocio
                Dim wid_local As Integer = Val(CmdLocal.Tag)
                Dim wid_almacen As Integer = GridProductos.Rows(e.RowIndex).Cells("id_almacen").Value
                Dim wcantidad As Double = GridProductos.Rows(e.RowIndex).Cells("cantidad").Value
                Dim wequiv As Integer = GridProductos.Rows(e.RowIndex).Cells("equiv").Value

                'Dim wdet_lote As String = Muestra_lote_linea_def(wtipo_signo, wid_prod_mae, wid_negocio, wid_local, wid_almacen, wcantidad, wequiv)
                If Val(GridProductos.Rows(e.RowIndex).Cells("es_control_lote").Value) = 1 Then
                    GridProductos.Rows(e.RowIndex).Cells("lote").Value = "..." ' tabla.Rows(0).Item("Lote_def").ToString
                    GridProductos.Rows(e.RowIndex).Cells("det_lote").Value = "Pulsar [F2] para definición de lotes"
                    GridProductos.Rows(e.RowIndex).Cells("cadenalotes").Value = ""
                    GridProductos.Rows(e.RowIndex).Cells("cadenalotes_formato").Value = ""
                Else
                    GridProductos.Rows(e.RowIndex).Cells("lote").Value = "" ' tabla.Rows(0).Item("Lote_def").ToString
                    GridProductos.Rows(e.RowIndex).Cells("det_lote").Value = "Sin Control de lotes/series"
                    GridProductos.Rows(e.RowIndex).Cells("cadenalotes").Value = ""
                    GridProductos.Rows(e.RowIndex).Cells("cadenalotes_formato").Value = ""
                End If

                'Dim cadena_precios As String = listaprecio_atexto(lk_NegocioActivo.id_Negocio, Val(CmdMonedaComp.Tag), Val(GridProductos.Rows(e.RowIndex).Cells("id_prod_mae").Value), Val(GridProductos.Rows(e.RowIndex).Cells("id_pres").Value), Val(CmdLocal.Tag))
                'MsgBox(cadena_precios)
            End If
        End If
        If Strings.Trim(GridProductos.CurrentCell.OwningColumn.Name) = "cantidad" Then
            If Val(GridProductos.Rows(e.RowIndex).Cells("es_control_lote").Value) = 1 Then
                GridProductos.Rows(e.RowIndex).Cells("lote").Value = "..." ' tabla.Rows(0).Item("Lote_def").ToString
                GridProductos.Rows(e.RowIndex).Cells("det_lote").Value = "Pulsar [F2] para definición de lotes"
                GridProductos.Rows(e.RowIndex).Cells("cadenalotes").Value = ""
                GridProductos.Rows(e.RowIndex).Cells("cadenalotes_formato").Value = ""
            Else
                GridProductos.Rows(e.RowIndex).Cells("lote").Value = "" ' tabla.Rows(0).Item("Lote_def").ToString
                GridProductos.Rows(e.RowIndex).Cells("det_lote").Value = "Sin Control de lotes/series"
                GridProductos.Rows(e.RowIndex).Cells("cadenalotes").Value = ""
                GridProductos.Rows(e.RowIndex).Cells("cadenalotes_formato").Value = ""
            End If

            'GridProductos.Rows(e.RowIndex).Cells("lote").Value = "..." ' tabla.Rows(0).Item("Lote_def").ToString
            'GridProductos.Rows(e.RowIndex).Cells("det_lote").Value = "Pulsar [F2] para definición de lotes"
            'GridProductos.Rows(e.RowIndex).Cells("cadenalotes").Value = ""
            'GridProductos.Rows(e.RowIndex).Cells("cadenalotes_formato").Value = ""


        End If



        If Strings.Trim(GridProductos.CurrentCell.OwningColumn.Name) <> "codigo" Then Exit Sub

        If e.RowIndex < 0 Then Exit Sub
        Dim valorActual As Object = GridProductos.Rows(e.RowIndex).Cells("codigo").Value
        Dim ws_stockProd As Double = 0
        If valorActual Is Nothing Then Exit Sub

        If Len(valorActual) = 3 Then
            If IsNumeric(valorActual) Then Exit Sub

            Dim frbusca As New FrmProductos



            frbusca.Tag = 100
            frbusca.TxtBuscar.Tag = TxtSocio_BoxSN.Text
            frbusca.ModoBusqeuda = "PROCESOS"
            frbusca.TextoBusca = valorActual
            frbusca.BUS_ID_ALMACEN = GridProductos.Rows(e.RowIndex).Cells("id_almacen").Value  ' lk_AlmacenActivo.id_almacen
            frbusca.BUS_ID_LOCAL = Val(CmdLocal.Tag)
            Dim wfila As Integer = e.RowIndex
            If frbusca.ShowDialog() = DialogResult.OK Then
                Dim selectedRow As DataGridViewRow = frbusca.SelectedRow
                ' Desactiva el evento CellValueChanged
                RemoveHandler GridProductos.CellValueChanged, AddressOf GridProductos_CellValueChanged
                ' Asigna el valor procesado a la columna correspondiente en el DataGridView
                GridProductos.Rows(e.RowIndex).Cells("grupo").Value = selectedRow.Cells("Lab_Linea").Value.ToString()
                GridProductos.Rows(e.RowIndex).Cells("descrip").Value = selectedRow.Cells("NombreProducto").Value.ToString()
                GridProductos.Rows(e.RowIndex).Cells("codigo").Value = selectedRow.Cells("Codigo").Value.ToString()
                GridProductos.Rows(e.RowIndex).Cells("id_prod_mae").Value = selectedRow.Cells("id_prod_mae").Value.ToString()
                GridProductos.Rows(e.RowIndex).Cells("id_prod_mae_codigo").Value = selectedRow.Cells("Codigo").Value.ToString()

                GridProductos.Rows(e.RowIndex).Cells("almacen").Value = lk_AlmacenActivo.codigo
                GridProductos.Rows(e.RowIndex).Cells("id_almacen").Value = lk_AlmacenActivo.id_almacen
                GridProductos.Rows(e.RowIndex).Cells("alm_abreviado").Value = lk_AlmacenActivo.abreviado.ToString.Trim
                GridProductos.Rows(e.RowIndex).Cells("lote").Value = selectedRow.Cells("lotes").Value.ToString()
                GridProductos.Rows(e.RowIndex).Cells("id_pres_base").Value = selectedRow.Cells("id_pres_base").Value.ToString()
                GridProductos.Rows(e.RowIndex).Cells("abreviado_base").Value = selectedRow.Cells("abreviado_base").Value.ToString()
                GridProductos.Rows(e.RowIndex).Cells("equiv_base").Value = selectedRow.Cells("equiv_base").Value.ToString()
                GridProductos.Rows(e.RowIndex).Cells("es_control_lote").Value = selectedRow.Cells("es_control_lote").Value.ToString()
                GridProductos.Rows(e.RowIndex).Cells("es_inventariable").Value = selectedRow.Cells("es_inventariable").Value.ToString()
                GridProductos.Rows(e.RowIndex).Cells("es_exonerado").Value = selectedRow.Cells("es_exonerado").Value.ToString()


                ws_stockProd = selectedRow.Cells("stockactual").Value.ToString()
                GridProductos.Rows(e.RowIndex).Cells("cosproactual").Value = selectedRow.Cells("cosproactual").Value.ToString()
                GridProductos.Rows(e.RowIndex).Cells("stockactual").Value = selectedRow.Cells("stockactual").Value.ToString()
                GridProductos.Rows(e.RowIndex).Cells("id_pres_precio").Value = 0

                'MsgBox(GridProductos.Rows(e.RowIndex).Cells("descrip").Value)

                If Val(selectedRow.Cells("es_control_lote").Value.ToString()) = 1 Then
                    GridProductos.Rows(e.RowIndex).Cells("lote").Value = "..." ' tabla.Rows(0).Item("Lote_def").ToString

                    GridProductos.Rows(e.RowIndex).Cells("det_lote").Value = "Pulsar [F2] para definición de lotes"
                Else
                    GridProductos.Rows(e.RowIndex).Cells("lote").Value = "" ' tabla.Rows(0).Item("Lote_def").ToString
                    GridProductos.Rows(e.RowIndex).Cells("det_lote").Value = "Sin Control de lotes/series"
                End If


                GridProductos.CurrentCell = GridProductos.Rows(e.RowIndex).Cells("cantidad") ' salta a la sugiete columna

                AddHandler GridProductos.CellValueChanged, AddressOf GridProductos_CellValueChanged
                GridProductos.Rows(e.RowIndex).Cells("codigo").Value = selectedRow.Cells("Codigo").Value.ToString()

                Dim wpres As String = selectedRow.Cells("Unidades").Value.ToString()

                Dim valores As List(Of Tuple(Of String, Integer, Integer)) = ConvertirCadena(wpres)
                Dim comboCell As DataGridViewComboBoxCell
                comboCell = CType(GridProductos.Rows(e.RowIndex).Cells("present"), DataGridViewComboBoxCell)
                comboCell.Items.Clear()
                Dim valoresDict As New Dictionary(Of Integer, Tuple(Of String, Integer, Integer)) ' Diccionario para almacenar los valores con su índice
                For i As Integer = 0 To valores.Count - 1
                    comboCell.Items.Add(valores(i).Item1)
                    valoresDict.Add(i, valores(i)) '
                Next
                comboCell.Tag = valoresDict


                If valores.Count > 0 Then
                    comboCell.Value = valores(0).Item1
                    GridProductos.Rows(e.RowIndex).Cells("id_pres").Value = valores(0).Item3
                    GridProductos.Rows(e.RowIndex).Cells("equiv").Value = valores(0).Item2
                    GridProductos.Rows(e.RowIndex).Cells("Unidades").Value = wpres ' Valor original de la bd
                End If
                Dim cadena_precios As String() = listaprecio_atexto(lk_NegocioActivo.id_Negocio, Val(CmdMonedaComp.Tag), Val(GridProductos.Rows(e.RowIndex).Cells("id_prod_mae").Value), Val(GridProductos.Rows(e.RowIndex).Cells("id_pres").Value), Val(CmdLocal.Tag))
                GridProductos.Rows(e.RowIndex).Cells("id_pres_precio").Value = Val(GridProductos.Rows(e.RowIndex).Cells("id_pres").Value)
                GridProductos.Rows(e.RowIndex).Cells("cadenaprecios").Value = cadena_precios(0)
                GridProductos.Rows(e.RowIndex).Cells("preciobase").Value = Val(cadena_precios(1))

                If chkConIMPTO.Checked Then
                    AsignarModoCalculo_GridPROD1(1)
                    Calcula_PROD1(Val(GridProductos.AccessibleDescription))
                End If
                If chkSinIMPTO.Checked Then
                    AsignarModoCalculo_GridPROD1(2)
                    Calcula_PROD1(Val(GridProductos.AccessibleDescription))
                End If



            End If

        End If


    End Sub
    Private Function Validar_ProductoSinStock(ws_stockProd As Double, wfila As Integer) As Boolean

        Return True
    End Function
    Private Function Muestra_lote_linea_def(wtipo_signo As Integer, wid_prod_mae As Integer, wid_negocio As Integer, wid_local As Integer, wid_almacen As Integer, wcantidad As Double, wequiv As Integer) As String
        Dim wcanti As Integer = wcantidad
        Muestra_lote_linea_def = ""
        If wtipo_signo = -1 Then
            Dim sql As String = "exec [DistribuirCantidad] '" & wid_prod_mae & "'," & wid_negocio & "," & wid_local & "," & wid_almacen & ", " & wcantidad & " "
            Dim command As New SqlCommand(sql, lk_connection_cuenta)
            Dim adapter As New SqlDataAdapter(command)
            Dim dt_lotepro_def As New DataTable()
            adapter.Fill(dt_lotepro_def)

            Dim fuenteMonoespaciada As New Font("Consolas", 12)

            Dim resultado As New StringBuilder()

            ' Encabezado de la tabla
            resultado.AppendLine("LOTE   | CANT |  F.VCTO")

            ' Línea divisora
            resultado.AppendLine("-------+------+----------")

            ' Recorrer las filas del DataTable y construir la cadena con el formato deseado
            For Each row As DataRow In dt_lotepro_def.Rows
                If row("saldo") = 0 Then Continue For
                Dim codigo As String = CStr(row("codigo"))
                Dim cantidad As String = CStr(row("cantidad"))
                Dim fechavcto As DateTime = CDate(row("fechavcto"))

                ' Construir la línea con el formato y agregarla al resultado
                resultado.AppendLine($"{codigo.PadRight(7)} | {cantidad.PadRight(4)} | [{fechavcto.ToString("MM/yyyy")}]")
            Next

            ' La cadena de texto resultante estará en la variable 'resultado'
            Dim textoFormateado As String = resultado.ToString()

            ' Asignar el texto formateado al control donde se muestra
            Muestra_lote_linea_def = textoFormateado

            ' Aplicar la fuente monoespaciada al control
            ' Muestra_lote_linea_def.Font = fuenteMonoespaciada


            ' La cadena de texto resultante estará en la variable 'resultado'
            'Muestra_lote_linea_def = resultado.ToString()
        Else
        End If

    End Function
    Private Sub MuestraFilaProducto(wcodigo As String, wfila As Integer, wValores As List(Of Tuple(Of String, Integer, Integer)), wpresdb As String)
        GridProductos.Rows(wfila).Cells("id_pres").Value = wValores(0).Item1 & wValores(0).Item2
        GridProductos.Rows(wfila).Cells("equiv").Value = wValores(0).Item3
        GridProductos.Rows(wfila).Cells("Unidades").Value = wpresdb ' Valor original de la bd

    End Sub

    Private Sub Calcula_PROD1(wmodocal As Integer)
        ' 1 = Con Impuesto 
        ' 2 = Sin Impuestos
        If GridProductos.Columns.Count < 10 Then Exit Sub ' aseguro que si no se a defino las columnas no pasas

        'Dim controlLabel As Label

        Dim wcal_PrecioBase As Double
        Dim wcal_Impto As Double
        Dim wcal_PorcImpto As Double
        Dim wcal_Valor As Double
        Dim wcal_cantidad As Double
        Dim wcal_equiv As Double
        Dim wcal_id_prod_mae As Integer
        Dim wcal_ValSubtotal As Double = 0
        Dim wcal_SubTotal As Double

        Dim wtot_valor As Double = 0
        Dim wtot_impto As Double = 0
        Dim wtot_total As Double = 0
        Dim wcal_precio_valor As Double = 0

        Dim wcal_modocalculo As String
        Dim wprecio_cospro As Double = 0
        Dim wes_cospro As Integer = 0
        Dim wtipo_transf_kardex As Integer
        Dim wes_bloqueado As String = ""
        Dim wcal_id_serv As Integer
        Dim w_es_servicio As Integer = 0
        Dim wes_exonerado As Integer = 0
        Dim wvalor_porc_impto As Double = 0
        Dim wvalor_exonerado As Double = 0
        Dim wvalor_bonif As Double = 0

        Dim wes_bonif As Boolean = False
        If CmdOperacion.Tag Is Nothing Then Exit Sub

        Dim Obtener_impto() As DataRow = lk_sql_impuesto_mae.Select("id_local = " & CmdLocal.Tag & " and codigo = 1 ")
        If Obtener_impto.Count = 0 Then
            SMS_Barra("debe Confgurar Su Local- Operacion con Error: NO DEFINIDO IMPUESTO", 3)
            Exit Sub
        End If
        wvalor_porc_impto = Obtener_impto(0)("vporc")

        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        If Obtener_id_oper_maestro.Count = 0 Then
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            Exit Sub
        End If
        wes_cospro = Obtener_id_oper_maestro(0)("es_cospro")
        wtipo_transf_kardex = Obtener_id_oper_maestro(0)("tipo_transf_kardex")


        If wes_cospro = 1 Or wtipo_transf_kardex = 2 Then
            chkSinIMPTO.Checked = True
        End If

        w_es_servicio = 0

        If Radio_Serv.Checked Then
            w_es_servicio = 1
        End If

        ' PT =  DESDE EL PRECIO CON IMPTO
        ' TO =   DEL TOTAL HACIA EL PRECIO CON IMPTO
        ' PV =  DESDE EL PRECIO SIN IMPTO AL TOTAL
        ' VA =  DESDE AL VALOR SIN IMPTTO
        If GridProductos.Visible = False Then Exit Sub
        'Stop
        wvalor_exonerado = 0
        wes_bonif = 0
        For i = 0 To GridProductos.Rows.Count - 1

            wcal_id_prod_mae = GridProductos.Rows(i).Cells("id_prod_mae").Value
            wcal_id_serv = GridProductos.Rows(i).Cells("id_serv").Value
            wes_exonerado = GridProductos.Rows(i).Cells("es_exonerado").Value
            wes_bonif = CBool(GridProductos.Rows(i).Cells("es_prod_bof").Value)

            If w_es_servicio = 1 And wcal_id_serv = 0 Then Continue For
            If w_es_servicio = 0 And wcal_id_prod_mae = 0 Then Continue For

            If wes_exonerado = 1 Or wes_bonif = True Then
                wcal_PorcImpto = 0 ' exonerado 100% o es gratiuito
            Else
                wcal_PorcImpto = wvalor_porc_impto
            End If


            wcal_equiv = GridProductos.Rows(i).Cells("equiv").Value
            wes_bloqueado = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("ok").Tag

            If wes_cospro = 1 And wes_bloqueado <> "bloq" Then ' operacion es forzado a valor de costo promedio
                wprecio_cospro = Val(GridProductos.Rows(i).Cells("cosproactual").Value) * wcal_equiv
                GridProductos.Rows(i).Cells("preciobase").Value = Format(wprecio_cospro, "N4")
                wcal_modocalculo = "PV"
            ElseIf wes_cospro = 0 And wtipo_transf_kardex = 2 And wes_bloqueado <> "bloq" Then
                wprecio_cospro = Val(GridProductos.Rows(i).Cells("preciobase").Value) * wcal_equiv
                GridProductos.Rows(i).Cells("preciobase").Value = Format(wprecio_cospro, "N4")
                wcal_modocalculo = "PV"
            Else

                wcal_modocalculo = GridProductos.Rows(i).Cells("modocalculo").Value
            End If

            wcal_cantidad = Val(GridProductos.Rows(i).Cells("cantidad").Value)
            If GridProductos.Rows(i).Cells("preciobase").Value Is DBNull.Value Then
                wcal_PrecioBase = 0
            Else
                wcal_PrecioBase = GridProductos.Rows(i).Cells("preciobase").Value
            End If

            wcal_ValSubtotal = Val(GridProductos.Rows(i).Cells("subtotal").Value)
            wcal_Valor = Val(GridProductos.Rows(i).Cells("valor").Value)






            If wcal_modocalculo = "PT" Then

                wcal_SubTotal = (wcal_cantidad) * wcal_PrecioBase
                wcal_Valor = (wcal_SubTotal / (1 + (wcal_PorcImpto / 100)))
                wcal_Impto = wcal_SubTotal - wcal_Valor
                wcal_precio_valor = (wcal_Valor / wcal_cantidad)
            ElseIf wcal_modocalculo = "TO" Then
                wcal_PrecioBase = (wcal_ValSubtotal / wcal_cantidad)
                wcal_SubTotal = wcal_ValSubtotal
                wcal_Valor = (wcal_SubTotal / (1 + (wcal_PorcImpto / 100)))
                wcal_Impto = wcal_SubTotal - wcal_Valor
                wcal_precio_valor = (wcal_Valor / wcal_cantidad)
            ElseIf wcal_modocalculo = "PV" Then
                wcal_Valor = wcal_PrecioBase * wcal_cantidad
                wcal_Impto = wcal_Valor * ((wcal_PorcImpto / 100))
                wcal_SubTotal = (wcal_Valor) + wcal_Impto
                wcal_precio_valor = (wcal_PrecioBase)
            ElseIf wcal_modocalculo = "VA" Then
                wcal_PrecioBase = Format(wcal_Valor / wcal_cantidad, "#0.00##")
                wcal_Impto = wcal_Valor * ((wcal_PorcImpto / 100))
                wcal_SubTotal = (wcal_Valor) + wcal_Impto
                wcal_precio_valor = (wcal_PrecioBase)
            End If


            GridProductos.Rows(i).Cells("preciobase").Value = wcal_PrecioBase
            GridProductos.Rows(i).Cells("valor").Value = wcal_Valor
            GridProductos.Rows(i).Cells("impto").Value = wcal_Impto
            GridProductos.Rows(i).Cells("subtotal").Value = wcal_SubTotal
            GridProductos.Rows(i).Cells("precio_valor").Value = wcal_precio_valor


            GridProductos.Rows(i).Cells("valor").Style.Format = "N2"
            GridProductos.Rows(i).Cells("impto").Style.Format = "N2"
            GridProductos.Rows(i).Cells("subtotal").Style.Format = "N2"

            If wes_bonif = True Then
                wvalor_bonif = wvalor_bonif + wcal_Valor
            Else
                If wes_exonerado = 1 Then
                    wvalor_exonerado = wvalor_exonerado + wcal_Valor
                Else
                    wtot_valor = wtot_valor + wcal_Valor
                End If
            End If

            wtot_impto = wtot_impto + wcal_Impto
            wtot_total = wtot_total + wcal_SubTotal


            '  wcal_Valor = GridProductos.Rows(i).Cells("valor").Value
            '  wcal_Impto = GridProductos.Rows(i).Cells("impto").Value
            ' wcal_SubTotal = GridProductos.Rows(i).Cells("subtotal").Value

        Next i

        wtot_valor = Format(wtot_valor, "0.00")
        wtot_impto = Format(wtot_impto, "0.00")
        wtot_total = Format(wtot_total, "0.00")



        'controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "valor" AndAlso TypeOf c Is Label)
        'If controlLabel IsNot Nothing Then
        '    controlLabel.Text = "VALOR " & CmdMonedaComp.AccessibleName & " : " & Format(wtot_valor, "N2")
        '    controlLabel.Tag = wtot_valor
        '    controlLabel.Visible = True
        'End If
        Habilita_Box_Totales("valor", "OP.GRAVADA. ", wtot_valor)

        Habilita_Box_Totales("exonerado", "OP.EXON. ", wvalor_exonerado)


        'controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "impto" AndAlso TypeOf c Is Label)
        'If controlLabel IsNot Nothing Then
        '    controlLabel.Text = "IMPTO " & CmdMonedaComp.AccessibleName & " : " & Format(wtot_impto, "N2")
        '    controlLabel.Tag = wtot_impto
        '    controlLabel.Visible = True
        'End If

        Habilita_Box_Totales("impto", "IMPTO(" & Format(wvalor_porc_impto, "##.#") & "%) ", wtot_impto)

        Habilita_Box_Totales("bonif", "OP.BONIF. ", wvalor_bonif)


        'controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "subtotal" AndAlso TypeOf c Is Label)
        'If controlLabel IsNot Nothing Then
        '    controlLabel.Text = "TOTAL " & CmdMonedaComp.AccessibleName & " : " & Format(wtot_total, "N2")
        '    controlLabel.Tag = wtot_total
        '    controlLabel.Visible = True
        'End If
        Habilita_Box_Totales("subtotal", "TOTAL ", wtot_total)

        If BoxEntidadF.Visible Then
            If wtot_total <> Val(TxtDetallefn.Tag) Then
                TxtDetallefn.Text = "Pulsar [Alt+F] o Click Lupa, para Entidad Financiera y modo de pago..."
            End If

        End If


    End Sub
    Private Sub Habilita_Box_Totales(wcampo_box As String, wetiqueta As String, wvalor As Double)
        Dim controlLabel As Label
        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = wcampo_box AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            controlLabel.Text = wetiqueta & CmdMonedaComp.AccessibleName & " : " & Format(wvalor, "N2")
            controlLabel.Tag = wvalor
            controlLabel.Visible = True
        End If
    End Sub

    Private Sub Calcula_CTASN1(wmodocal As Integer)
        ' 1 = Con Impuesto 
        ' 2 = Sin Impuestos
        Dim controlLabel As Label


        Dim wcal_total As Double = 0


        Dim wtot_total As Double = 0




        For i = 0 To dg_cuentasn.Rows.Count - 1
            wcal_total = Val(dg_cuentasn.Rows(i).Cells("aplicar").Value)

            dg_cuentasn.Rows(i).Cells("aplicar").Style.Format = "N2"


            wtot_total = wtot_total + wcal_total

        Next i


        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "subtotal" AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            controlLabel.Text = "TOTAL " & CmdMonedaComp.AccessibleName & " : " & Format(wtot_total, "N2")
            controlLabel.Tag = wtot_total
            controlLabel.Visible = True
        End If


    End Sub
    Private Sub GridProductos_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GridProductos.CellValidating
        Dim nombreColumna As String = GridProductos.Columns(e.ColumnIndex).Name
        If nombreColumna = "preciobase" Or nombreColumna = "subtotal" Or nombreColumna = "valor" Then
            AsignaFilaGridModoCal(nombreColumna, e.RowIndex)
        End If
        If nombreColumna = "codigo" Then
            Dim wcodigook As String = GridProductos.Rows(e.RowIndex).Cells("id_prod_mae_codigo").Value
            If wcodigook = "" Then Exit Sub
            Dim wcodigodig As String = GridProductos.Rows(e.RowIndex).Cells("codigo").Value
            If wcodigook <> wcodigodig Then
                Dim Result = MensajesBox.Show("Esta Cambiando el codigo del Producto o servicio , continuar..?" & vbCrLf & "
                ", "Confirmar Cambio de Producto / Servicio ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                If Result = "7" Or Result = "2" Then ' es NO
                    GridProductos.Rows(e.RowIndex).Cells("codigo").Value = GridProductos.Rows(e.RowIndex).Cells("id_prod_mae_codigo").Value
                    Exit Sub
                Else
                    Limpia_Fila_Producto(e.RowIndex)
                    GridProductos.Rows(e.RowIndex).Cells("almacen").Value = Oper_Almacen_Defecto.codigo
                    GridProductos.Rows(e.RowIndex).Cells("alm_abreviado").Value = Oper_Almacen_Defecto.abreviado
                    GridProductos.Rows(e.RowIndex).Cells("id_almacen").Value = Oper_Almacen_Defecto.id_almacen
                    GridProductos.Rows(e.RowIndex).Cells("codigo_local_serv").Value = TxtLocal.Text
                    GridProductos.Rows(e.RowIndex).Cells("des_local_serv").Value = CmdLocal.Text
                    GridProductos.Rows(e.RowIndex).Cells("id_local_serv").Value = CmdLocal.Tag

                    'AddGridProductos_defecto()
                End If
            End If
        End If
        If nombreColumna = "almacen" Then
            Dim wcodigodig As Integer = Val(GridProductos.Rows(e.RowIndex).Cells("id_almacen").Value)
            If wcodigodig = 0 Then Limpia_Fila_Producto(e.RowIndex)
        End If



            Calcula_PROD1(Val(GridProductos.AccessibleDescription))
    End Sub

    Private Sub GridProductos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles GridProductos.EditingControlShowing
        Dim currentColumn = GridProductos.Columns(GridProductos.CurrentCell.ColumnIndex)
        Dim currentColumnName = currentColumn.Name

        ' Acceder al nombre de la cabecera de la columna
        'Dim columnName As String = columnHeader.HeaderText


        If TypeOf e.Control Is TextBox And Strings.Left(currentColumn.Tag, 1) = "A" Then ' Asegurarse de que el control de edición es un cuadro de texto
            AddHandler e.Control.TextChanged, AddressOf TextBox_TextChanged ' Agregar controlador de eventos TextChanged
            AddHandler e.Control.KeyDown, AddressOf BloqueoColumn_KeyDown
        End If



    End Sub

    Private Sub BloqueoColumn_KeyDown(sender As Object, e As KeyEventArgs)
        ' Verificar si se presiona la tecla retroceso
        Dim columnIndex As Integer = GridProductos.CurrentCell.ColumnIndex ' Obtener el índice de la columna actual
        Dim rowIndex As Integer = GridProductos.CurrentCell.RowIndex ' Obtener el índice de la columna actual
        Dim columnName As String = GridProductos.Columns(columnIndex).Name ' Obtener el nombre de la columna actual


        If GridProductos.Rows(rowIndex).Cells("es_prod_new").Value Then Exit Sub


        If columnName = "descrip" Or columnName = "num" Or columnName = "det_lote" Then
            If e.KeyCode = Keys.Back Then
                GridProductos.Columns(columnIndex).ReadOnly = True
                ' Bloquear la tecla retroceso en el control de edición
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        Dim originalSelectionStart As Integer = textBox.SelectionStart ' Guardar la posición actual del cursor
        textBox.Text = textBox.Text.ToUpper() ' Convertir texto en mayúsculas
        textBox.SelectionStart = textBox.Text.Length ' Mover el cursor al final del texto
    End Sub

    Private Sub Add_Operacion()
        'var Cabecera

        Stop

        Dim wnivel_comp As Integer = 0
        Dim wfecha As DateTime
        Dim wfecha_emis As DateTime
        Dim wid_doc_oper As Integer = 0
        Dim wserie_oper As String = ""
        Dim wnumero_oper As Integer
        Dim wid_comprobante As Integer = 0
        Dim wsere_comp As String = ""
        Dim wnumero_comp As Integer = 0
        Dim wid_sn_master As Integer = 0
        Dim wid_vendedor As Integer = 0
        Dim wid_entidad As Integer = 0
        Dim wid_contacto As Integer = 0
        Dim wid_dir_entrega As Integer = 0
        Dim wid_dir_cobro As Integer = 0
        Dim wid_condicion As Integer = 0
        Dim wfecha_vcto As DateTime
        Dim westado As Integer = 0
        Dim wid_moneda As Integer = 0
        Dim wid_prioridad As Integer = 0
        Dim wfecha_ate As DateTime
        Dim wref As String = ""
        Dim wvalor_gravado As Double
        Dim wvalor_nogravado As Double
        Dim wvalor_exonerado As Double
        Dim wimpto As Double
        Dim wtotal As Double
        Dim wid_usuario As Integer = 0
        Dim wes_kardex As Integer = 0
        Dim wes_servicio As Integer = 0
        Dim wsigno_entidad As Integer = 0
        Dim wsigno_sn As Integer = 0
        Dim wmodo_calculo As Integer = 0

        ' Var de detalle
        Dim wid_negocio As Integer
        Dim wid_local As Integer
        Dim wid_oper_maestro As Integer
        Dim wid_comp_cab As Integer
        Dim wid_comp_det As Integer
        Dim wid_almacen As Integer
        Dim wid_prod_mae As Double = 0
        Dim wref_prod_mae As String = ""
        Dim wcantidad As Double
        Dim wequiv As Integer
        Dim wdescrip_pres As String = ""
        Dim wid_pres As Integer
        Dim wsigno_kardex As Integer
        Dim wtipo_valor As Integer
        Dim wimpto_det As Double
        Dim wprecio As Double
        Dim wprecio_orig As Double
        Dim wsubtotal As Double
        Dim wes_control_lote As Integer
        Dim wsituacion_det As Integer
        Dim westado_det As Integer
        Dim wvalor As Double = 0
        Dim wprecio_valor As Double = 0

        Dim werror As String = String.Empty
        Dim Wresultado As String = String.Empty


        wnivel_comp = 0
        wfecha = "01/01/2023"
        wfecha_emis = "01/01/2023"
        wid_doc_oper = 1
        wserie_oper = "RQ1"
        wnumero_oper = 1
        wid_comprobante = 1
        wsere_comp = "REQCOMP"
        wnumero_comp = 1
        wid_sn_master = 22
        wid_vendedor = 0
        wid_entidad = 0
        wid_contacto = 1
        wid_dir_entrega = 1
        wid_dir_cobro = 1
        wid_condicion = 1
        wfecha_vcto = "01/01/2023"
        westado = 1
        wid_moneda = 1
        wid_prioridad = 1
        wfecha_ate = "01/01/2023"
        wref = ""
        wvalor_gravado = 100
        wvalor_nogravado = 10000
        wvalor_exonerado = 11.25
        wimpto = 1500
        wtotal = 652.25
        wid_usuario = 1
        wes_kardex = 1
        wes_servicio = 0
        wsigno_entidad = 0
        wsigno_sn = 0

        Dim connectionString As String = "Data Source=PCACOSME;Initial Catalog=r23_negocio_cuenta;User ID=sa;Password=159357852456"


        Using lk_connection_cuenta As New SqlConnection(connectionString)
            lk_connection_cuenta.Open()

            ' Crea un DataTable para representar la tabla temporal de detalle
            Dim detalle As New DataTable()
            detalle.Columns.Add("id_negocio", GetType(Integer))
            detalle.Columns.Add("id_local", GetType(Integer))
            detalle.Columns.Add("id_oper_maestro", GetType(Integer))
            detalle.Columns.Add("id_comp_cab", GetType(Integer))
            detalle.Columns.Add("id_comp_det", GetType(Integer))
            detalle.Columns.Add("id_almacen", GetType(Integer))
            detalle.Columns.Add("id_prod_mae", GetType(Double))
            detalle.Columns.Add("ref_prod_mae", GetType(String))
            detalle.Columns.Add("cantidad", GetType(Double))
            detalle.Columns.Add("equiv", GetType(Integer))
            detalle.Columns.Add("descrip_pres", GetType(String))
            detalle.Columns.Add("id_pres", GetType(Integer))
            detalle.Columns.Add("signo_kardex", GetType(Integer))
            detalle.Columns.Add("tipo_valor", GetType(Integer))
            detalle.Columns.Add("impto", GetType(Double))
            detalle.Columns.Add("precio", GetType(Double))
            detalle.Columns.Add("precio_orig", GetType(Double))
            detalle.Columns.Add("subtotal", GetType(Double))
            detalle.Columns.Add("es_control_lote", GetType(Integer))
            detalle.Columns.Add("situacion", GetType(Integer))
            detalle.Columns.Add("estado", GetType(Integer))


            For i = 1 To 5
                wid_negocio = 22
                wid_local = 1
                wid_oper_maestro = 1
                wid_comp_cab = 0 ' Se asigna dentro del proedimeinto
                wid_comp_det = i
                wid_almacen = 1
                wid_prod_mae = 2
                wref_prod_mae = ""
                wcantidad = 30
                wequiv = 1
                wdescrip_pres = "UND"
                wid_pres = 1
                wsigno_kardex = 1
                wtipo_valor = 1 ' 1 = GRABADO 
                wimpto_det = 0.84
                wprecio = 1.5
                wprecio_orig = 1.3
                wsubtotal = 100
                wes_control_lote = 0
                wsituacion_det = 1
                westado_det = 1

                detalle.Rows.Add(wid_negocio, wid_local, wid_oper_maestro, wid_comp_cab, wid_comp_det, wid_almacen, wid_prod_mae, wref_prod_mae, wcantidad, wequiv, wdescrip_pres, wid_pres, wsigno_kardex, wtipo_valor, wimpto_det, wprecio, wprecio_orig, wsubtotal, wes_control_lote, wsituacion_det, westado_det)
                'detalle.Rows.Add("id_local", wid_local)
                'detalle.Rows.Add("id_oper_maestro")
                'detalle.Rows.Add("id_comp_cab")
                'detalle.Rows.Add("id_comp_det")
                'detalle.Rows.Add("id_almacen")
                'detalle.Rows.Add("id_prod_mae")
                'detalle.Rows.Add("ref_prod_mae", )
                'detalle.Rows.Add("cantidad")
                'detalle.Rows.Add("equiv")
                'detalle.Rows.Add("descrip_pres")
                'detalle.Rows.Add("id_pres")
                'detalle.Rows.Add("signo_kardex")
                'detalle.Rows.Add("tipo_valor")
                'detalle.Rows.Add("impto")
                'detalle.Rows.Add("precio")
                'detalle.Rows.Add("precio_orig")
                'detalle.Rows.Add("subtotal")
                'detalle.Rows.Add("es_control_lote")
                'detalle.Rows.Add("situacion")
                'detalle.Rows.Add("estado")




                'detalle.Rows.Add("id_negocio", wid_negocio)
                'detalle.Rows.Add("id_local", wid_local)
                'detalle.Rows.Add("id_oper_maestro", wid_oper_maestro)
                'detalle.Rows.Add("id_comp_cab", wid_comp_cab)
                'detalle.Rows.Add("id_comp_det", wid_comp_det)
                'detalle.Rows.Add("id_almacen", wid_almacen)
                'detalle.Rows.Add("id_prod_mae", wid_prod_mae)
                'detalle.Rows.Add("ref_prod_mae", wref_prod_mae)
                'detalle.Rows.Add("cantidad", wcantidad)
                'detalle.Rows.Add("equiv", wequiv)
                'detalle.Rows.Add("descrip_pres", wdescrip_pres)
                'detalle.Rows.Add("id_pres", wid_pres)
                'detalle.Rows.Add("signo_kardex", wsigno_kardex)
                'detalle.Rows.Add("tipo_valor", wtipo_valor)
                'detalle.Rows.Add("impto", wimpto_det)
                'detalle.Rows.Add("precio", wprecio)
                'detalle.Rows.Add("precio_orig", wprecio_orig)
                'detalle.Rows.Add("subtotal", wsubtotal)
                'detalle.Rows.Add("es_control_lote", wes_control_lote)
                'detalle.Rows.Add("situacion", wsituacion_det)
                'detalle.Rows.Add("estado", westado_det)
            Next i


            ' Crea un objeto SqlCommand para llamar al SP
            Dim cmd As New SqlCommand("Oper_InsertarComp", lk_connection_cuenta)
            cmd.CommandType = CommandType.StoredProcedure






            ' Agrega los parámetros de entrada
            cmd.Parameters.AddWithValue("@id_negocio", wid_negocio)
            cmd.Parameters.AddWithValue("@id_oper_maestro", wid_oper_maestro)
            cmd.Parameters.AddWithValue("@id_comp_cab", wid_comp_cab)
            cmd.Parameters.AddWithValue("@id_local", wid_local)
            cmd.Parameters.AddWithValue("@nivel_comp", wnivel_comp)
            cmd.Parameters.AddWithValue("@fecha", wfecha)
            cmd.Parameters.AddWithValue("@fecha_emis", wfecha_emis)
            cmd.Parameters.AddWithValue("@id_doc_oper", wid_doc_oper)
            cmd.Parameters.AddWithValue("@serie_oper", wserie_oper)
            cmd.Parameters.AddWithValue("@numero_oper", wnumero_oper)
            cmd.Parameters.AddWithValue("@id_comprobante", wid_comprobante)
            cmd.Parameters.AddWithValue("@sere_comp", wsere_comp)
            cmd.Parameters.AddWithValue("@numero_comp", wnumero_comp)
            cmd.Parameters.AddWithValue("@id_sn_master", wid_sn_master)
            cmd.Parameters.AddWithValue("@id_vendedor", wid_vendedor)
            cmd.Parameters.AddWithValue("@id_entidad", wid_entidad)
            cmd.Parameters.AddWithValue("@id_contacto", wid_contacto)
            cmd.Parameters.AddWithValue("@id_dir_entrega", wid_dir_entrega)
            cmd.Parameters.AddWithValue("@id_dir_cobro", wid_dir_cobro)
            cmd.Parameters.AddWithValue("@id_condicion", wid_condicion)
            cmd.Parameters.AddWithValue("@fecha_vcto", wfecha_vcto)
            cmd.Parameters.AddWithValue("@estado", westado)
            cmd.Parameters.AddWithValue("@id_moneda", wid_moneda)
            cmd.Parameters.AddWithValue("@id_prioridad", wid_prioridad)
            cmd.Parameters.AddWithValue("@fecha_ate", wfecha_ate)
            cmd.Parameters.AddWithValue("@ref", wref)
            cmd.Parameters.AddWithValue("@valor_gravado", wvalor_gravado)
            cmd.Parameters.AddWithValue("@valor_nogravado", wvalor_nogravado)
            cmd.Parameters.AddWithValue("@valor_exonerado", wvalor_exonerado)
            cmd.Parameters.AddWithValue("@impto", wimpto)
            cmd.Parameters.AddWithValue("@total", wtotal)
            cmd.Parameters.AddWithValue("@id_usuario", wid_usuario)
            cmd.Parameters.AddWithValue("@es_kardex", wes_kardex)
            cmd.Parameters.AddWithValue("@es_servicio", wes_servicio)
            cmd.Parameters.AddWithValue("@signo_entidad", wsigno_entidad)
            cmd.Parameters.AddWithValue("@signo_sn", wsigno_sn)

            ' Agrega el parámetro de tabla temporal de detalle
            Dim detalleParam As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalDetalle", detalle)



            'Dim resultadoParam As SqlParameter = cmd.Parameters.Add("@Resultado", SqlDbType.VarChar, 50)
            'resultadoParam.Direction = ParameterDirection.Output

            'Dim resultado As String = String.Empty
            cmd.Parameters.Add("@Resultado", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output



            detalleParam.SqlDbType = SqlDbType.Structured
            detalleParam.TypeName = "dbo.Tipo_add_m_comprobantes_det"




            ' Ejecuta el comando
            Try
                cmd.ExecuteNonQuery()

                Wresultado = DirectCast(cmd.Parameters("@Resultado").Value, String)
            Catch ex As Exception
                werror = ex.Message
                ' manejo de excepciones  ex.Message 
            End Try
            'cmd.ExecuteNonQuery()
            ' Dim resultado As String = resultadoParam.Value.ToString()
            'MsgBox(resultado)
        End Using
        If werror <> String.Empty Then ' ERROR DE SQL
            MsgBox(werror)
        End If
        If Wresultado <> String.Empty Then
            ' MsgBox(Wresultado)
        End If
        'TextBox2.Text = TextBox2.Text & Wresultado & Chr(13)




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'Dim tarea1 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        'Dim tarea2 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        'Dim tarea3 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        'Dim tarea4 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        'Dim tarea5 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        'Dim tarea6 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        'Dim tarea7 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        'Dim tarea8 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        'Dim tarea9 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        'Dim tarea10 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        'Dim tarea11 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        'Dim tarea12 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        'Dim tarea13 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        'Dim tarea14 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        'Dim tarea15 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea16 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea17 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea18 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea19 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea20 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea21 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea22 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea23 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea24 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea25 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea26 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea27 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea28 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea29 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)
        ''Dim tarea30 As Task = Task.Factory.StartNew(AddressOf Add_Operacion)





        'Task.WaitAll(tarea1, tarea2, tarea3, tarea4, tarea5, tarea6, tarea7, tarea8, tarea9, tarea10, tarea11, tarea12, tarea13, tarea14, tarea15)

    End Sub

    Private Sub TimeNoti_Tick(sender As Object, e As EventArgs) Handles TimeNoti.Tick
        LblNoti.Visible = True ' LblNoti.Visible = False
        If Val(LblNoti.Tag) >= 5 Then
            TimeNoti.Enabled = False
            LblNoti.Visible = False
            LblNoti.Text = ""
        End If
        LblNoti.Tag = Val(LblNoti.Tag) + 1
    End Sub

    Private Sub SMS_Barra(wnoti As String, wtipo As Integer)
        LblNoti.Text = wnoti.ToUpper
        LblNoti.Tag = 0


        Dim Colorfondo_t1 As String
        Dim Colorfondo_t2 As String
        Dim Colorfondo_t3 As String

        Dim ColorTexto_t1 As String
        Dim ColorTexto_t2 As String
        Dim ColorTexto_t3 As String
        Dim ColorPanel As String

        If lk_modoOscuro Then
            Colorfondo_t1 = strColorModoVerde
            Colorfondo_t2 = strColorModoTurquesa
            Colorfondo_t3 = strColorModoGrisMedio

            ColorTexto_t1 = strColorModoBlanco
            ColorTexto_t2 = strColorModoNegro
            ColorTexto_t3 = strColorModoBlanco

            ColorPanel = strColorModoGrisMedio
        Else
            Colorfondo_t1 = strColorModoVerde
            Colorfondo_t2 = strColorModoRojo
            Colorfondo_t3 = strColorModoTurquesa

            ColorTexto_t1 = strColorModoBlanco
            ColorTexto_t2 = strColorModoBlanco
            ColorTexto_t3 = strColorModoNegro

            ColorPanel = strColorModoBlanco
        End If
        If wtipo = 1 Then ' Registrado
            PanelMensajes.BackColor = ColorTranslator.FromHtml(ColorPanel)
            LblNoti.ForeColor = ColorTranslator.FromHtml(ColorTexto_t1)
            LblNoti.BackColor = ColorTranslator.FromHtml(Colorfondo_t1)
        ElseIf wtipo = 2 Then ' Error Usuario
            PanelMensajes.BackColor = ColorTranslator.FromHtml(ColorPanel)
            LblNoti.ForeColor = ColorTranslator.FromHtml(ColorTexto_t2)
            LblNoti.BackColor = ColorTranslator.FromHtml(Colorfondo_t2)
        ElseIf wtipo = 3 Then ' Error Interno
            PanelMensajes.BackColor = ColorTranslator.FromHtml(ColorPanel)
            LblNoti.ForeColor = ColorTranslator.FromHtml(ColorTexto_t3)
            LblNoti.BackColor = ColorTranslator.FromHtml(Colorfondo_t3)
        End If
        TimeNoti.Enabled = True
    End Sub

    Private Sub TxtLocal_Validating(sender As Object, e As CancelEventArgs) Handles TxtLocal.Validating
        If CmdLocal.AccessibleName Is Nothing Then
            SMS_Barra("Verificar Codigo de Tienda...", 2)
            TxtLocal.SelectAll()
        Else
            If TxtLocal.Text.Trim <> CmdLocal.AccessibleName.Trim Then
                TxtLocal.Text = CmdLocal.AccessibleName.Trim
                'SMS_Barra("Verificar Codigo de Tienda...", 2)
                'TxtLocal.SelectAll()
            End If
        End If
    End Sub

    Private Sub CmdComprob_Click(sender As Object, e As EventArgs) Handles CmdComprob.Click

        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub
        If Val(TxtOperacion.Tag) = 0 Then
            Exit Sub
        End If

        Dim ListaComprobantes() As DataRow = lk_sql_comp_oper.Select("id_tb_oper = " & TxtOperacion.Tag & " and es_interno = 0")
        ' Recorremos las filas filtradas
        If ListaComprobantes.Length = 0 Then
            Result = MensajesBox.Show("No Tiene Comprobantes Asociados a la Operacion.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaComprobantes
            Dim id As Integer = CInt(row("id_comprobante"))
            Dim detalle As String = CStr(row("codigo") & " " & row("abreviado") & " - " & row("descripcion"))
            Dim descrip As String = CStr(row("descripcion"))
            Dim codigo As String = CStr(row("codigo"))
            Dim esmanual As String = CStr(row("es_manual"))

            Dim abreviado As String = CStr(Space(10) & row("abreviado").ToString.Trim)

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarComprobante(id, detalle, descrip, codigo, abreviado, esmanual)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdComprob, New Point(0, CmdComprob.Height))
    End Sub
    Private Sub MostrarComprobante(id As String, detalle As String, descrip As String, codigo As String, abreviado As String, esmanual As Integer)
        'Aquí puedes reemplazar con tu código para realizar la acción correspondiente
        CmdComprob.Text = abreviado
        CmdComprob.Tag = id
        CmdComprob.AccessibleName = codigo
        CmdComprob.AccessibleDescription = esmanual
        TxtComp_codigo.Text = codigo


        If esmanual = 1 Then
            CmdSerireComp.Visible = False
            TxtSerireComp.Visible = True
            TxtComp_Numero.Enabled = True
            TxtSerireComp.Text = ""
            TxtComp_Numero.Text = ""
            Exit Sub
        Else
            CmdSerireComp.Visible = True
            TxtSerireComp.Visible = False
            TxtComp_Numero.Enabled = False
            TxtSerireComp.Text = ""
            TxtComp_Numero.Text = ""
        End If

        ' CARGA SERIRES DEL COMPROBANTE:

        PordefectoSerie(Val(CmdLocal.Tag), Val(CmdComprob.Tag))



    End Sub

    Private Sub PordefectoSerie(wid_local As Integer, wid_comprobante As Integer)
        Dim Result As String
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub
        If Val(TxtOperacion.Tag) = 0 Then
            Exit Sub
        End If
        GridProductos.id_local_grid = wid_local ' pasa a la gridlla
        CmdSerireComp.Text = ""
        CmdSerireComp.Tag = 0
        TxtSerireComp.Text = ""
        TxtSerireComp.Tag = 0
        TxtComp_Numero.Text = ""

        If CmdComprob.AccessibleDescription = "1" Then
            CmdSerireComp.Visible = False
            TxtSerireComp.Visible = True
            TxtComp_Numero.Enabled = True
            Exit Sub
        Else
            CmdSerireComp.Visible = True
            TxtSerireComp.Visible = False
            TxtComp_Numero.Enabled = False
        End If


        Dim ListaSeries() As DataRow = lk_sql_serie_comp.Select("id_local = " & wid_local & " and id_comprobante = " & wid_comprobante & "")
        ' Recorremos las filas filtradas
        If ListaSeries.Length = 0 Then
            Result = MensajesBox.Show("No Tiene Asignado Serie al Comprobantes .",
                                     "Operación.")
            CmdSerireComp.Text = ""
            CmdSerireComp.Tag = 0
            TxtSerireComp.Text = ""
            TxtSerireComp.Tag = 0
            TxtComp_Numero.Text = ""
            Exit Sub
        End If
        CmdSerireComp.Text = ListaSeries(0)("serie")
        CmdSerireComp.Tag = ListaSeries(0)("serie")
        CmdSerireComp.AccessibleName = ListaSeries(0)("es_electronico")

        TxtSerireComp.Text = ListaSeries(0)("serie")
        TxtSerireComp.Tag = ListaSeries(0)("serie")
        TxtComp_Numero.Text = "********"

    End Sub
    Private Sub PorDefectoSerieInterno(wid_comprobante_int As Integer)
        ' SERIES PARA COMPROBANTES INTERNOS
        Dim Result As String
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub
        If Val(TxtOperacion.Tag) = 0 Then
            Exit Sub
        End If


        Dim SerieActiva_Interna() As DataRow = lk_sql_serie_comp.Select("id_tipo= 2 and  id_comprobante = " & wid_comprobante_int & "")
        ' Recorremos las filas filtradas
        If SerieActiva_Interna.Length = 0 Then
            Result = MensajesBox.Show("No Tiene Asignado Serie Internas al Comprobantes .",
                                     "Operación.")
            TxtSerieDocOper.Text = ""
            TxtSerieDocOper.Tag = 0
            TxtDocOper.Text = ""
            TxtDocOper.Tag = 0
            TxtNumDocOper.Text = ""
            Exit Sub
        End If
        TxtSerieDocOper.Text = SerieActiva_Interna(0)("serie")
        TxtSerieDocOper.Tag = SerieActiva_Interna(0)("serie")
        TxtNumDocOper.Text = "********"



    End Sub
    Private Sub CmdSerireComp_Click(sender As Object, e As EventArgs) Handles CmdSerireComp.Click
        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub
        If Val(TxtOperacion.Tag) = 0 Then
            Exit Sub
        End If
        If Val(CmdComprob.Tag) = 0 Then Exit Sub

        Dim ListaSeries() As DataRow = lk_sql_serie_comp.Select("id_local = " & CmdLocal.Tag & " and id_comprobante = " & CmdComprob.Tag & "")
        ' Recorremos las filas filtradas
        If ListaSeries.Length = 0 Then
            Result = MensajesBox.Show("Comprobante no Tiene serie asignado..",
                                     "Operación.")
            CmdSerireComp.Text = ""
            CmdSerireComp.Tag = 0
            TxtSerireComp.Text = ""
            TxtSerireComp.Tag = 0
            TxtComp_Numero.Text = ""
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaSeries

            Dim codigo As String = CStr(row("serie"))
            Dim abreviado As String = CStr(row("serie").ToString.Trim)
            Dim wes_electronico As Integer = Val(row("es_electronico"))
            Dim item As New ToolStripMenuItem(abreviado)
            AddHandler item.Click, Sub()
                                       MostrarSerie(codigo, abreviado, wes_electronico)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdSerireComp, New Point(0, CmdSerireComp.Height))
    End Sub
    Private Sub MostrarSerie(codigo As String, abreviado As String, wes_electronico As Integer)


        ' CARGA SERIRES DEL COMPROBANTE:

        CmdSerireComp.Text = codigo
        CmdSerireComp.Tag = codigo
        CmdSerireComp.AccessibleName = wes_electronico

        TxtSerireComp.Text = codigo
        TxtSerireComp.Tag = codigo

        TxtComp_Numero.Text = "********"


    End Sub

    Private Sub CmdMonedaComp_Click(sender As Object, e As EventArgs) Handles CmdMonedaComp.Click

        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub
        If Val(TxtOperacion.Tag) = 0 Then
            Exit Sub
        End If

        Dim ListaMoneda() As DataRow = lk_sql_monedas_negocio.Select("id_negocio <> 0")
        ' Recorremos las filas filtradas

        If ListaMoneda.Length = 0 Then
            Result = MensajesBox.Show("No Tiene Moneda el Comprobantes Asociados a la Operacion.",
                                     "Operación.")
            CmdMonedaComp.Text = ""
            CmdMonedaComp.Tag = ""
            CmdMonedaComp.AccessibleName = ""
            CmdMonedaComp.AccessibleDescription = ""
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        'S/ - SOLES (PE)
        For Each row As DataRow In ListaMoneda
            Dim id As Integer = CInt(row("id_moneda"))
            Dim detalle As String = CStr(row("simbolo") & "  " & row("nom_moneda") & " (" & row("abreviado").ToString.Trim & ")")
            Dim simbolo As String = CStr(row("simbolo"))
            Dim esmonlocal As String = CStr(row("es_monedalocal"))

            Dim abreviado As String = CStr(Space(10) & row("abreviado").ToString.Trim)

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarMoneda(id, detalle, simbolo, abreviado, esmonlocal)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdMonedaComp, New Point(0, CmdMonedaComp.Height))
    End Sub
    Private Sub MostrarMoneda(id As String, detalle As String, simbolo As String, abreviado As String, esmonlocal As String)
        'Aquí puedes reemplazar con tu código para realizar la acción correspondiente
        CmdMonedaComp.Text = detalle
        CmdMonedaComp.Tag = id
        CmdMonedaComp.AccessibleName = simbolo
        CmdMonedaComp.AccessibleDescription = esmonlocal
        Calcula_PROD1(Val(GridProductos.AccessibleDescription))

    End Sub

    Private Sub CmdPrioridad_Click(sender As Object, e As EventArgs) Handles CmdPrioridad.Click

        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub
        If Val(TxtOperacion.Tag) = 0 Then
            Exit Sub
        End If

        Dim ListaPrio() As DataRow = lk_sql_ListaTablas.Select("id_tipotabla = 75")
        ' Recorremos las filas filtradas

        If ListaPrio.Length = 0 Then
            Result = MensajesBox.Show("No Tiene Prioridades del Comprobantes Asociados a la Operacion.",
                                     "Operación.")
            CmdPrioridad.Text = ""
            CmdPrioridad.Tag = ""

            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        'S/ - SOLES (PE)
        For Each row As DataRow In ListaPrio
            Dim id As Integer = CInt(row("id_tb"))
            Dim detalle As String = CStr(row("descripcion"))
            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarPrioridad(id, detalle)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdPrioridad, New Point(0, CmdPrioridad.Height))

    End Sub
    Private Sub MostrarPrioridad(id As String, detalle As String)
        'Aquí puedes reemplazar con tu código para realizar la acción correspondiente
        CmdPrioridad.Text = detalle
        CmdPrioridad.Tag = id


    End Sub

    Private Sub CmdVerNumComp_Click(sender As Object, e As EventArgs) Handles CmdVerNumComp.Click
        'If Val(TxtEstadoComp.Tag) <> 0 Then Exit Sub
        If CmdSerireComp.Visible = False Then
            TxtComp_Numero.Select()
            Exit Sub
        End If

        TxtComp_Numero.Text = "..."
        Dim thread As New Thread(AddressOf MuestraSiguienteNumeroComp)
        thread.Start()

        'Esperar hasta que el hilo de fondo haya terminado antes de continuar con otras operaciones
        thread.Join()
    End Sub
    Private Sub MuestraSiguienteNumeroComp()

        Dim command As New SqlCommand("sp_obtener_siguiente_numero_comp", lk_connection_cuenta)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.AddWithValue("@id_local", CmdLocal.Tag)
        command.Parameters.AddWithValue("@id_comprobante", CmdComprob.Tag)
        command.Parameters.AddWithValue("@serie_comp", CmdSerireComp.Tag)
        Dim sec_id_comp_cab_param As New SqlParameter("@sec_id_comp_cab", SqlDbType.Int)
        sec_id_comp_cab_param.Direction = ParameterDirection.Output
        command.Parameters.Add(sec_id_comp_cab_param)
        command.ExecuteNonQuery()
        Dim numsec As Double = sec_id_comp_cab_param.Value
        TxtComp_Numero.BeginInvoke(Sub() TxtComp_Numero.Text = Format(numsec, "00000000"))


    End Sub

    Private Sub TxtDocOper_TextChanged(sender As Object, e As EventArgs) Handles TxtDocOper.TextChanged

    End Sub

    Private Sub TxtDocOper_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocOper.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtSerieDocOper_TextChanged(sender As Object, e As EventArgs) Handles TxtSerieDocOper.TextChanged

    End Sub

    Private Sub TxtSerieDocOper_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSerieDocOper.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtNumDocOper_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumDocOper.KeyPress
        e.Handled = True
    End Sub



    Private Sub CmdVerNumInt_Click(sender As Object, e As EventArgs) Handles CmdVerNumInt.Click
        If TxtSerieDocOper.Text = "" Then Exit Sub
        TxtNumDocOper.Text = "..."

        Dim thread As New Thread(AddressOf MuestraSiguienteNumeroInterno)
        thread.Start()

        'Esperar hasta que el hilo de fondo haya terminado antes de continuar con otras operaciones
        thread.Join()
    End Sub

    Private Sub MuestraSiguienteNumeroInterno()

        Dim command As New SqlCommand("sp_obtener_siguiente_numero_interno", lk_connection_cuenta)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.AddWithValue("@id_doc_oper", TxtDocOper.Tag)
        command.Parameters.AddWithValue("@serie_oper", TxtSerieDocOper.Tag)
        Dim sec_doc_oper As New SqlParameter("@sec_doc_oper", SqlDbType.Int)
        sec_doc_oper.Direction = ParameterDirection.Output
        command.Parameters.Add(sec_doc_oper)
        command.ExecuteNonQuery()
        Dim numsecInterno As Double = sec_doc_oper.Value
        TxtNumDocOper.BeginInvoke(Sub() TxtNumDocOper.Text = Format(numsecInterno, "00000000"))


    End Sub

    Private Sub TxtEstadoComp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtEstadoComp.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtEstadoComp_TextChanged(sender As Object, e As EventArgs) Handles TxtEstadoComp.TextChanged

    End Sub

    Private Sub info_SN_TextChanged(sender As Object, e As EventArgs) Handles info_SN.TextChanged

    End Sub

    Private Sub info_SN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles info_SN.KeyPress
        e.Handled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim froper As New FrmOper
        froper.ShowDialog()
        Carga_Paramtros_Negocio(lk_NegocioActivo.id_Negocio)

        Carga_Paramtros_Generales()
        Me.Close()
        '        Iniciar_Oper()


    End Sub

    Private Sub CmdGrabar_Click(sender As Object, e As EventArgs) Handles CmdGrabar.Click
        If Graba_Validacion_Box() = False Then
            Exit Sub
        End If
        Grabar_Operacion(CmdOperacion.Tag)

    End Sub

    Private Sub Grabar_Operacion(wCodOper As String)

        Dim controlLabel As Label

        'var Cabecera
        Dim wnivel_comp As Integer = 0
        Dim wfecha As DateTime
        Dim wfecha_emis As DateTime
        Dim wid_doc_oper As Integer = 0
        Dim wserie_oper As String = ""
        Dim wnumero_oper As Integer
        Dim wid_comprobante As Integer = 0
        Dim wsere_comp As String = ""
        Dim wnumero_comp As Integer = 0
        Dim wid_sn_master As Integer = 0
        Dim wid_vendedor As Integer = 0
        Dim wid_entidad As Integer = 0
        Dim wid_contacto As Integer = 0
        Dim wid_dir_entrega As Integer = 0
        Dim wid_dir_cobro As Integer = 0
        Dim wid_condicion As Integer = 0
        Dim wfecha_vcto As DateTime
        Dim westado As Integer = 0
        Dim wid_moneda As Integer = 0
        Dim wid_prioridad As Integer = 0
        Dim wfecha_ate As DateTime
        Dim wref As String = ""
        Dim wvalor_gravado As Double
        Dim wvalor_bonificado As Double = 0


        Dim wvalor_nogravado As Double
        Dim wvalor_exonerado As Double
        Dim wimpto As Double
        Dim wtotal As Double
        Dim wid_usuario As Integer = 0
        Dim wes_kardex As Integer = 0
        Dim wes_servicio As Integer = 0
        Dim wsigno_entidad As Integer = 0
        Dim wsigno_sn As Integer = 0
        Dim wes_comp_enlace As Integer = 0
        Dim wnivel_cuentasn As Integer = 0
        Dim wes_cuentasn As Integer = 0
        Dim wtipo_transf_kardex As Integer = 0
        Dim wmodo_calculo As Integer = 0
        Dim wes_canje_comp As Integer = 0
        Dim wes_canje_le As Integer = 0
        Dim wes_aplica_nc As Integer = 0
        Dim wes_finanzas As Integer = 0
        Dim wporc_impto As Double = 0
        Dim wdiasvcto As Integer = 0



        Dim wes_limite_credito As Double = 0
        Dim wdias_credito As Integer = 0

        Dim wsigno_lc As Integer = 0


        Dim wref_codigo_comp As String = ""
        Dim wref_serie_comp As String = ""
        Dim wref_numero_comp As String = ""
        Dim wref_fecha_comp As String = ""
        Dim wref_codigo_motivo As String = ""
        Dim wref_descripcion_motivo As String = ""







        Dim wdirecto_id_tb_oper As Integer = 0
        Dim wdirecto_id_oper_maestro As Integer = 0

        Dim wfn_directo_id_tb_oper As Integer = 0
        Dim wfn_directo_id_oper_maestro As Integer = 0




        ' Var de detalle
        Dim wid_negocio As Integer
        Dim wid_local As Integer
        Dim wid_oper_maestro As Integer
        Dim wid_comp_cab As Integer
        Dim wid_comp_det As Integer
        Dim wid_almacen As Integer
        Dim wid_prod_mae As Double = 0
        Dim wref_prod_mae As String = ""
        Dim wcantidad As Double
        Dim wequiv As Integer
        Dim wdescrip_pres As String = ""
        Dim wid_pres As Integer
        Dim wsigno_kardex As Integer
        Dim wtipo_valor As Integer
        Dim wimpto_det As Double
        Dim wprecio As Double
        Dim wprecio_orig As Double
        Dim wsubtotal As Double
        Dim wes_control_lote As Integer
        Dim wsituacion_det As Integer
        Dim westado_det As Integer
        Dim wes_manual_comp As Integer
        Dim wid_almacen_transf As Integer
        Dim wloteser_det As String = ""
        Dim wvalor As Double = 0
        Dim wprecio_valor As Double = 0
        Dim wes_costeo As Integer = 0



        Dim wes_prod_new As Integer = 0
        Dim wprod_new_nombre As String = ""
        Dim wprod_new_codigo As String = ""
        Dim wloteser_det_formato As String = ""
        Dim wes_inventariable As Integer = 0
        Dim wes_exonerado As Integer = 0
        Dim wes_bonificado As Integer = 0
        Dim wid_serv As Integer = 0
        Dim wid_area As Integer = 0
        Dim wid_uci As Integer = 0
        Dim wid_local_serv As Integer = 0


        ' Var de Enlaces
        Dim wid_enlace As Integer = 0
        Dim wnumsec_enlace As Integer = 0
        Dim wid_local_bas As Integer = 0
        Dim wid_oper_maestro_base As Integer = 0
        Dim wid_comp_cab_base As Integer = 0
        Dim wid_comp_det_base As Integer = 0
        Dim wid_almacen_base As Integer = 0
        Dim wfecha_enlace As DateTime
        Dim wid_prod_mae_enlace As Double = 0
        Dim wcantidad_enlace As Double = 0
        Dim wequiv_enlace As Integer = 0
        Dim wdescrip_pres_enlace As String = ""
        Dim wid_pres_enlace As Integer = 0
        Dim wsigno_kardex_enlace As Integer = 0
        Dim wid_local_dest_enlace As Integer = 0
        Dim wid_oper_maestro_dest_enlace As Integer = 0
        Dim wid_comp_cab_dest_enlace As Integer = 0
        Dim wsituacion_enlace As Integer = 0
        Dim westado_enlace As Integer = 0

        Dim wes_cospro As Integer = 0

        Dim westado_oper_def As Integer


        Dim werror As String = String.Empty
        Dim Wresultado As String = String.Empty
        Dim wreg_sec_numint As Integer = 0
        Dim wreg_sec_numcomp As Integer = 0

        Dim wreg_sec_carteracab As Integer = 0
        Dim wreg_sec_carteradet As Integer = 0


        wnivel_comp = 0
        wfecha = TxtFechas_Proc.Value
        wfecha_emis = TxtFechas_Emis.Value
        wid_doc_oper = Val(TxtDocOper.Tag)
        wserie_oper = TxtSerieDocOper.Tag
        wnumero_oper = 0 ' Se Asigan en el sp es automativo
        wid_comprobante = Val(CmdComprob.Tag)
        wsere_comp = TxtSerireComp.Text
        wnumero_comp = Val(TxtComp_Numero.Text)  ' Se Asigan en el sp es automativo
        wid_sn_master = Val(info_SN.Tag)
        wid_vendedor = 0
        wid_entidad = 0
        wid_contacto = 0
        wid_dir_entrega = 0
        wid_dir_cobro = 0
        wid_condicion = 0
        wfecha_vcto = TxtCondi_FecVcto.Value
        westado = 1
        wid_moneda = Val(CmdMonedaComp.Tag)
        wid_prioridad = 0
        wfecha_ate = TxtPrioridad_FecAten.Value
        wref = ""
        wid_usuario = lk_id_usuario
        wes_kardex = 0
        If Radio_Serv.Checked Then
            wes_servicio = 1
        Else
            wes_servicio = 0
        End If

        wsigno_entidad = 0
        wsigno_sn = 0
        wes_comp_enlace = 1
        If chkConIMPTO.Checked Then wmodo_calculo = 1
        If chkSinIMPTO.Checked Then wmodo_calculo = 2



        wid_almacen_transf = 0
        wvalor_gravado = 0
        wvalor_bonificado = 0

        wvalor_nogravado = 0
        wvalor_exonerado = 0
        wimpto = 0
        wtotal = 0
        wes_manual_comp = 0

        ' Validaciones Basicas de entorno:
        If BoxComprobantes.Visible Then
            If Val(CmdComprob.Tag) = 0 Then
                SMS_Barra("Operacion sin Comprobante , debe configurar la Tienda", 3)
                Exit Sub
            End If
            If Trim(TxtSerireComp.Tag) = "" Then
                SMS_Barra("Operacion sin Serires , debe configurar la Tienda", 3)
                Exit Sub
            End If
            wes_manual_comp = Val(CmdComprob.AccessibleDescription)
        End If




        Dim ListaOperacionAfecta() As DataRow = lk_sql_listaOperAfecta.Select("id_tb_oper = " & wCodOper & "", "orden ASC")
        ' Recorremos las filas filtradas
        For i = 0 To ListaOperacionAfecta.Count - 1
            If ListaOperacionAfecta(i)("codigo_afecta") = "001" Then
                wnivel_comp = 1
            End If
            If ListaOperacionAfecta(i)("codigo_afecta") = "002" Then
                wnivel_comp = 2
            End If
            If ListaOperacionAfecta(i)("codigo_afecta") = "003" Then
                wnivel_comp = 3
            End If
            If ListaOperacionAfecta(i)("codigo_afecta") = "004" Then
                wnivel_comp = 4

            End If


        Next i







        ' VALIDA Y ASIGNA EN ZONA DE TOTALES 
        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "valor" AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            wvalor_gravado = Val(controlLabel.Tag)
        End If

        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "bonif" AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            wvalor_bonificado = Val(controlLabel.Tag)
        End If





        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "exonerado" AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            wvalor_exonerado = Val(controlLabel.Tag)
        End If




        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "impto" AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            wimpto = Val(controlLabel.Tag)
        End If

        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "subtotal" AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            wtotal = Val(controlLabel.Tag)
        End If

        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & wCodOper & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        If Obtener_id_oper_maestro.Count = 0 Then
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            Exit Sub
        End If

        wid_oper_maestro = Obtener_id_oper_maestro(0)("id_oper_maestro")
        wes_cuentasn = Obtener_id_oper_maestro(0)("es_cuentasn") ' afecta a registro de caunta correinte del socio de negocio
        wsigno_sn = Obtener_id_oper_maestro(0)("signo_cuentasn")  ' Indica si es debe o haber + / -  0 aplica a registro de enlace
        wsigno_entidad = Obtener_id_oper_maestro(0)("signo_finanzas")
        wes_kardex = Obtener_id_oper_maestro(0)("es_inventario")
        wsigno_kardex = Obtener_id_oper_maestro(0)("signo_inventario")
        westado_oper_def = Obtener_id_oper_maestro(0)("estado_oper_def")
        wtipo_transf_kardex = Obtener_id_oper_maestro(0)("tipo_transf_kardex")
        wes_costeo = Obtener_id_oper_maestro(0)("es_costeo")
        wes_cospro = Obtener_id_oper_maestro(0)("es_cospro")
        wdirecto_id_tb_oper = Obtener_id_oper_maestro(0)("directo_id_tb_oper")
        wdirecto_id_oper_maestro = Obtener_id_oper_maestro(0)("directo_id_oper_maestro")
        wfn_directo_id_tb_oper = Obtener_id_oper_maestro(0)("fn_directo_id_tb_oper")
        wfn_directo_id_oper_maestro = Obtener_id_oper_maestro(0)("fn_directo_id_oper_maestro")
        wes_canje_comp = Obtener_id_oper_maestro(0)("es_canje_comp")
        wes_canje_le = Obtener_id_oper_maestro(0)("es_canje_le")
        wes_finanzas = Obtener_id_oper_maestro(0)("es_finanzas")
        wes_aplica_nc = Obtener_id_oper_maestro(0)("es_aplica_nc")


        westado = westado_oper_def   ' Toda operacion viene de la configuracion por defecto 1  o 8 
        If wtipo_transf_kardex = 1 Or wtipo_transf_kardex = 2 Then   ' 1= Envio , 2 = Recepecion , 0 = No es Trasnferencia
            wid_almacen_transf = Val(CmdAlmTransf.Tag)  ' almacena el almacen que se envia 
        End If


        If Val(TxtEstadoComp.AccessibleDescription) = 4 Then 'Fuerza si viene de un vinel 4 - verifica si veien de un nivel comprobante anterior si cumple para poner CERRADO-AT
            westado = 8
        End If

        Dim Obtener_impto() As DataRow = lk_sql_impuesto_mae.Select("id_local = " & CmdLocal.Tag & " and codigo = 1 ")
        If Obtener_impto.Count = 0 Then
            SMS_Barra("Operacion con Error: NO DEFINIDO IMPUESTO", 3)
            Exit Sub
        End If
        wporc_impto = Obtener_impto(0)("vporc")




        If wnivel_comp = 4 Then
            If dt_DatosEnlace_oper Is Nothing Then ' marca los comp en cerrado-auto a nivel 4
                If Val(TxtEstadoComp.AccessibleDescription) = 3 Then 'verifica si veien de un nivel comprobante anterior si cumple para poner CERRADO-AT
                    westado = 8
                End If
            Else
                If wnivel_comp = 4 Then
                    Dim Obtener_nivel() As DataRow = dt_DatosEnlace_oper.Select("nivel_comp = 3") 'verifica si veien de un nivel comprobante anterior si cumple para poner CERRADO-AT
                    If Obtener_nivel.Count <> 0 Then
                        westado = 8
                    End If
                End If
            End If

        End If
        ' Verificar Si la operacion es movieminto de inventario   o reserva oara cerrar si es servicio.
        If wes_servicio = 1 Then
            If wdirecto_id_oper_maestro <> 0 Then
                westado = 8
            End If
            If wsigno_kardex <> 0 Then
                westado = 8
            End If
        End If

        If BoxLineaCredito.Visible Then
            wtotal = Val(lc_monto.Text)

            If Val(lblEstado_lc.Tag) = 1 Then
                wes_limite_credito = 1
            Else
                wes_limite_credito = 0
            End If

            wdias_credito = Val(lc_dias.Text)
            wsigno_lc = Val(CmdOpcionesLC.Tag)
            wvalor_exonerado = wsigno_lc
        End If
        If BoxCondicion.Visible Then
            wdiasvcto = Val(txt_diaslc.Text)
        End If

        If BoxRefComp.Visible Then
            wref_codigo_comp = Strings.Left(tref_codigo.Text.Trim(), 2)
            wref_serie_comp = Strings.Left(tref_serie.Text.Trim(), 4)
            wref_numero_comp = Strings.Left(tref_numero.Text.Trim(), 8)
            wref_fecha_comp = tref_fecha.Text.Trim()
            wref_codigo_motivo = ""
            wref_descripcion_motivo = ""
        End If




        ' Crea un DataTable para representar la tabla temporal de detalle
        Dim Wtienedetalle As Integer = 0

        Dim detalle As New DataTable()
        detalle.Columns.Add("id_negocio", GetType(Integer))
        detalle.Columns.Add("id_local", GetType(Integer))
        detalle.Columns.Add("id_oper_maestro", GetType(Integer))
        detalle.Columns.Add("id_comp_cab", GetType(Integer))
        detalle.Columns.Add("id_comp_det", GetType(Integer))
        detalle.Columns.Add("id_almacen", GetType(Integer))
        detalle.Columns.Add("id_prod_mae", GetType(Double))
        detalle.Columns.Add("ref_prod_mae", GetType(String))
        detalle.Columns.Add("cantidad", GetType(Double))
        detalle.Columns.Add("equiv", GetType(Integer))
        detalle.Columns.Add("descrip_pres", GetType(String))
        detalle.Columns.Add("id_pres", GetType(Integer))
        detalle.Columns.Add("signo_kardex", GetType(Integer))
        detalle.Columns.Add("tipo_valor", GetType(Integer))
        detalle.Columns.Add("impto", GetType(Double))
        detalle.Columns.Add("precio", GetType(Double))
        detalle.Columns.Add("precio_orig", GetType(Double))
        detalle.Columns.Add("subtotal", GetType(Double))
        detalle.Columns.Add("es_control_lote", GetType(Integer))
        detalle.Columns.Add("situacion", GetType(Integer))
        detalle.Columns.Add("estado", GetType(Integer))
        detalle.Columns.Add("id_almacen_transf", GetType(Integer))
        detalle.Columns.Add("loteser_det", GetType(String))
        detalle.Columns.Add("valor", GetType(Double))
        detalle.Columns.Add("precio_valor", GetType(Double))
        detalle.Columns.Add("es_costeo", GetType(Integer))
        detalle.Columns.Add("es_prod_new", GetType(Integer))
        detalle.Columns.Add("prod_new_nombre", GetType(String))
        detalle.Columns.Add("prod_new_codigo", GetType(String))
        detalle.Columns.Add("loteser_det_formato", GetType(String))
        detalle.Columns.Add("es_inventariable", GetType(Integer))
        detalle.Columns.Add("id_serv", GetType(Integer))
        detalle.Columns.Add("id_area", GetType(Integer))
        detalle.Columns.Add("id_uci", GetType(Integer))
        detalle.Columns.Add("id_local_serv", GetType(Integer))
        detalle.Columns.Add("es_exonerado", GetType(Integer))
        detalle.Columns.Add("es_bonificado", GetType(Integer))



        Dim ws_flag_almerror As Integer = 0
        Wtienedetalle = 1
        If GridProductos.Visible Then
            Wtienedetalle = 0

            For i = 0 To GridProductos.Rows.Count - 1

                wid_serv = Val(GridProductos.Rows(i).Cells("id_serv").Value)
                wid_prod_mae = GridProductos.Rows(i).Cells("id_prod_mae").Value
                wcantidad = GridProductos.Rows(i).Cells("cantidad").Value
                If wes_servicio = 1 And wid_serv = 0 Then Continue For
                If wes_servicio = 0 And wid_prod_mae = 0 Then Continue For
                If wcantidad = 0 Then Continue For


                'If Val(GridProductos.Rows(i).Cells("id_prod_mae").Value) = 0 Then Continue For

                Wtienedetalle = 1 ' flag marca tienen detalle 
                wid_negocio = lk_NegocioActivo.id_Negocio
                wid_local = Val(CmdLocal.Tag)
                wid_comp_det = i + 1
                GridProductos.Rows(i).Cells("id_comp_det").Value = wid_comp_det ' Se Asigna para usar en enlaces_loteser
                wid_almacen = GridProductos.Rows(i).Cells("id_almacen").Value
                wref_prod_mae = GridProductos.Rows(i).Cells("masdetalle").Tag

                If wid_almacen = 0 Then
                    ws_flag_almerror = Val(GridProductos.Rows(i).Cells("num").Value)
                End If


                wequiv = GridProductos.Rows(i).Cells("equiv").Value
                wdescrip_pres = GridProductos.Rows(i).Cells("present").Value
                wid_pres = GridProductos.Rows(i).Cells("id_pres").Value
                wtipo_valor = 1 ' 1 = GRABADO 
                wimpto_det = GridProductos.Rows(i).Cells("impto").Value
                wprecio = GridProductos.Rows(i).Cells("preciobase").Value
                wprecio_orig = GridProductos.Rows(i).Cells("preciobase").Value
                wsubtotal = GridProductos.Rows(i).Cells("subtotal").Value
                wvalor = GridProductos.Rows(i).Cells("valor").Value
                wprecio_valor = GridProductos.Rows(i).Cells("precio_valor").Value

                wes_control_lote = Val(GridProductos.Rows(i).Cells("es_control_lote").Value)
                wsituacion_det = 1
                westado_det = 1
                If wtipo_transf_kardex = 2 Then   ' 1= Envio , 2 = Recepecion , 0 = No es Trasnferencia
                    wid_almacen_transf = Val(GridProductos.Rows(i).Cells("id_almacen_trasnf").Value)  ' almacena el almacen que se envia 
                End If
                wloteser_det = GridProductos.Rows(i).Cells("cadenalotes").Value

                If GridProductos.Rows(i).Cells("es_prod_new").Value Then
                    wes_prod_new = 1
                    wprod_new_nombre = GridProductos.Rows(i).Cells("descrip").Value
                    wprod_new_codigo = GridProductos.Rows(i).Cells("codigo").Value
                Else
                    wes_prod_new = 0
                    wprod_new_nombre = ""
                    wprod_new_codigo = ""
                End If
                If GridProductos.Rows(i).Cells("es_prod_bof").Value Then
                    wes_bonificado = 1
                Else
                    wes_bonificado = 0
                End If

                wloteser_det_formato = GridProductos.Rows(i).Cells("cadenalotes_formato").Value
                wes_inventariable = Val(GridProductos.Rows(i).Cells("es_inventariable").Value)
                wes_exonerado = Val(GridProductos.Rows(i).Cells("es_exonerado").Value)



                wid_area = Val(GridProductos.Rows(i).Cells("id_area").Value)
                wid_uci = Val(GridProductos.Rows(i).Cells("id_uci").Value)
                wid_local_serv = Val(GridProductos.Rows(i).Cells("id_local_serv").Value)
                If wes_servicio = 1 Then
                    wref_prod_mae = GridProductos.Rows(i).Cells("detalle_serv").Value
                End If


                detalle.Rows.Add(wid_negocio, wid_local, wid_oper_maestro, wid_comp_cab, wid_comp_det, wid_almacen, wid_prod_mae, wref_prod_mae, wcantidad, wequiv, wdescrip_pres, wid_pres, wsigno_kardex, wtipo_valor, wimpto_det, wprecio, wprecio_orig, wsubtotal, wes_control_lote, wsituacion_det, westado_det, wid_almacen_transf, wloteser_det, wvalor, wprecio_valor, wes_costeo, wes_prod_new, wprod_new_nombre, wprod_new_codigo, wloteser_det_formato, wes_inventariable, wid_serv, wid_area, wid_uci, wid_local_serv, wes_exonerado, wes_bonificado)
            Next i
        Else  ' el caso cuand es documento sin detalle 
            wid_negocio = lk_NegocioActivo.id_Negocio
            wid_local = Val(CmdLocal.Tag)
            wid_comp_det = 1
            wid_almacen = 0
            wid_prod_mae = 0
            wref_prod_mae = ""
            wcantidad = 1
            wequiv = 1
            wdescrip_pres = "SERV"
            wid_pres = 30
            wsigno_kardex = 1
            wtipo_valor = 1 ' 1 = GRABADO 
            wimpto_det = 0
            wprecio = 0
            wprecio_orig = 0
            wsubtotal = wtotal
            wes_control_lote = 0
            wsituacion_det = 1
            westado_det = 1

            wid_serv = 0

            'detalle.Rows.Add(wid_negocio, wid_local, wid_oper_maestro, wid_comp_cab, wid_comp_det, wid_almacen, wid_prod_mae, wref_prod_mae, wcantidad, wequiv, wdescrip_pres, wid_pres, wsigno_kardex, wtipo_valor, wimpto_det, wprecio, wprecio_orig, wsubtotal, wes_control_lote, wsituacion_det, westado_det)

            detalle.Rows.Add(wid_negocio, wid_local, wid_oper_maestro, wid_comp_cab, wid_comp_det, wid_almacen, wid_prod_mae, wref_prod_mae, wcantidad, wequiv, wdescrip_pres, wid_pres, wsigno_kardex, wtipo_valor, wimpto_det, wprecio, wprecio_orig, wsubtotal, wes_control_lote, wsituacion_det, westado_det, wid_almacen_transf, wloteser_det, wvalor, wprecio_valor, wes_costeo, wes_prod_new, wprod_new_nombre, wprod_new_codigo, wloteser_det_formato, wes_inventariable, wid_serv, wid_area, wid_uci, wid_local_serv)
        End If

        If Wtienedetalle = 0 Then
            SMS_Barra("Debe Ingresar detalla de Productos o servicio, Operacion con detalle ", 3)
            Exit Sub
        End If
        If ws_flag_almerror <> 0 Then
            SMS_Barra("Existe Una Fila con Almacen errado, verificar , Item: " & ws_flag_almerror, 3)
            Exit Sub
        End If




        ' Crea un enlace de Comprobamnte la tabla temporal 
        Dim enlace_comp As New DataTable()
        enlace_comp.Columns.Add("id_negocio", GetType(Integer))
        enlace_comp.Columns.Add("id_enlace", GetType(Integer))
        enlace_comp.Columns.Add("numsec", GetType(Integer))
        enlace_comp.Columns.Add("id_local_base", GetType(Integer))
        enlace_comp.Columns.Add("id_oper_maestro_base", GetType(Integer))
        enlace_comp.Columns.Add("id_comp_cab_base", GetType(Integer))
        enlace_comp.Columns.Add("id_comp_det_base", GetType(Integer))
        enlace_comp.Columns.Add("id_almacen_base", GetType(Integer))
        enlace_comp.Columns.Add("fecha", GetType(DateTime))
        enlace_comp.Columns.Add("id_prod_mae", GetType(Double))
        enlace_comp.Columns.Add("cantidad", GetType(Double))
        enlace_comp.Columns.Add("equiv", GetType(Integer))
        enlace_comp.Columns.Add("descrip_pres", GetType(String))
        enlace_comp.Columns.Add("id_pres", GetType(Integer))
        enlace_comp.Columns.Add("signo_kardex", GetType(Integer))
        enlace_comp.Columns.Add("id_local_dest", GetType(Integer))
        enlace_comp.Columns.Add("id_oper_maestro_dest", GetType(Integer))
        enlace_comp.Columns.Add("id_comp_cab_dest", GetType(Integer))
        enlace_comp.Columns.Add("situacion", GetType(Integer))
        enlace_comp.Columns.Add("estado", GetType(Integer))




        If dt_DatosEnlace_oper Is Nothing Then
        Else

            For i = 0 To dt_DatosEnlace_oper.Rows.Count - 1
                If CmdTraerDe.Tag <> "1" Then  ' Si es Traer DE , NO VALIDA ESO SE ENCARGA EL FORMULARIO DE tRAERde
                    For idet = 0 To GridProductos.Rows.Count - 1
                        If Val(dt_DatosEnlace_oper.Rows(i).Item("id_comp_det_base")) = Val(GridProductos.Rows(idet).Cells("id_comp_det_emlace").Value) Then
                            GoTo Almacena_Elace
                        End If
                    Next idet
                    GoTo Otro_registro_enlace
                End If
Almacena_Elace:


                    wid_enlace = 0
                    wid_local_bas = Val(CmdLocal.Tag)
                    wnumsec_enlace = i + 1
                    wid_oper_maestro_base = dt_DatosEnlace_oper.Rows(i).Item("id_oper_maestro_base")
                    wid_comp_cab_base = dt_DatosEnlace_oper.Rows(i).Item("id_comp_cab_base")
                    wid_comp_det_base = dt_DatosEnlace_oper.Rows(i).Item("id_comp_det_base")

                    wid_almacen_base = dt_DatosEnlace_oper.Rows(i).Item("id_almacen_base")
                    wfecha_enlace = TxtFechas_Proc.Value
                    wid_prod_mae_enlace = dt_DatosEnlace_oper.Rows(i).Item("id_prod_mae")
                    ' Si se Usa el Traer operacion hay que hacer la multiplizar de Equivalncia para llevarlo a unidades base
                    If CmdTraerDe.Tag = "1" Then  ' SOLO SE ACTIVA AL TRAER LOS DATOS 
                        wcantidad_enlace = dt_DatosEnlace_oper.Rows(i).Item("cantidad") * dt_DatosEnlace_oper.Rows(i).Item("equiv")
                    Else
                    wcantidad_enlace = dt_DatosEnlace_oper.Rows(i).Item("cantidad") ' * dt_DatosEnlace_oper.Rows(i).Item("equiv")  ' no necesita multiplzar por que viene ya convertifo a equiv base
                End If

                    wequiv_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_equiv_base")
                    wdescrip_pres_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_abreviado_pres_base")
                    wid_pres_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_id_pres_base")
                    wsigno_kardex_enlace = dt_DatosEnlace_oper.Rows(i).Item("signo_kardex")
                    wid_local_dest_enlace = Val(CmdLocal.Tag)

                    wid_oper_maestro_dest_enlace = 0
                    wid_comp_cab_dest_enlace = 0
                    wsituacion_enlace = 1
                    westado_enlace = westado
                    enlace_comp.Rows.Add(wid_negocio, wid_local_bas, wnumsec_enlace, wid_local_bas, wid_oper_maestro_base, wid_comp_cab_base, wid_comp_det_base,
                                   wid_almacen_base, wfecha_enlace, wid_prod_mae_enlace, wcantidad_enlace, wequiv_enlace, wdescrip_pres_enlace, wid_pres_enlace, wsigno_kardex_enlace, wid_local_dest_enlace,
                                   wid_oper_maestro_dest_enlace, wid_comp_cab_dest_enlace, wsituacion_enlace, westado_enlace)

Otro_registro_enlace:
                Next i

            End If

            ' LLENAR LOS DATOS DE CADA FILA DE PRODUCTO CON LOS LOTES OBTENIDOS
            Dim dtenlaces_loteser As New DataTable()
        dtenlaces_loteser.Columns.Add("id_negocio", GetType(Integer))
        dtenlaces_loteser.Columns.Add("id_oper_maestro", GetType(Integer))
        dtenlaces_loteser.Columns.Add("id_comp_cab", GetType(Integer))
        dtenlaces_loteser.Columns.Add("id_comp_det", GetType(Integer))
        dtenlaces_loteser.Columns.Add("numsec", GetType(Integer))
        dtenlaces_loteser.Columns.Add("id_prod_mae", GetType(Integer))
        dtenlaces_loteser.Columns.Add("id_loteser", GetType(Integer))
        dtenlaces_loteser.Columns.Add("es_nuevo", GetType(Integer))
        dtenlaces_loteser.Columns.Add("Codigo", GetType(String))
        dtenlaces_loteser.Columns.Add("fechareg", GetType(DateTime))
        dtenlaces_loteser.Columns.Add("es_nocaduca", GetType(Integer))
        dtenlaces_loteser.Columns.Add("fechavcto", GetType(DateTime))
        dtenlaces_loteser.Columns.Add("id_pres", GetType(Integer))
        dtenlaces_loteser.Columns.Add("cantidad", GetType(Double))
        dtenlaces_loteser.Columns.Add("signo_kardex", GetType(Integer))
        dtenlaces_loteser.Columns.Add("estado", GetType(Integer))
        dtenlaces_loteser.Columns.Add("ingreso_kardex", GetType(Double))
        dtenlaces_loteser.Columns.Add("salida_kardex", GetType(Double))

        If wdirecto_id_oper_maestro <> 0 Then GoTo Valida_Lotes ' Fuerza a una validacion de Lotes ya que esta asociado a una operacion a inventarios 

        If wes_kardex = 1 And wsigno_kardex <> 0 Then
Valida_Lotes:
            Dim ws_id_prod_mae As Integer
            Dim ws_id_pres_base As Integer
            Dim ws_id_comp_det As Integer

            ' Recorrer las filas del DataGridView y acumular los resultados en el DataTable dtAcumulado
            For Each fila As DataGridViewRow In GridProductos.Rows
                ' Supongamos que el valor de la columna "cadenaDatos" está en la primera celda de cada fila
                ws_id_prod_mae = Val(fila.Cells("id_prod_mae").Value)
                ws_id_pres_base = Val(fila.Cells("id_pres_base").Value)
                ws_id_comp_det = Val(fila.Cells("id_comp_det").Value)


                If ws_id_prod_mae = 0 Then Continue For
                If Val(fila.Cells("es_control_lote").Value) = 0 Then Continue For
                If Val(fila.Cells("cantidad").Value) = 0 Then Continue For

                Dim cadenaDatos As String = fila.Cells("cadenalotes").Value
                If cadenaDatos = Nothing Then
                    SMS_Barra("Item: " & fila.Cells("num").Value & " PRODUCTO : " & fila.Cells("descrip").Value & " Requiere Definir sus Lotes", 3)
                    Exit Sub
                End If
                If cadenaDatos.Length() < 10 Then
                    SMS_Barra("Item: " & fila.Cells("num").Value & " PRODUCTO : " & fila.Cells("descrip").Value & " Requiere Definir sus Lotes", 3)
                    Exit Sub
                End If

                ' Obtener el DataTable desde la cadena de datos
                Dim dtResultado As DataTable = ObtenerDataTableDesdeCadena(cadenaDatos, ws_id_prod_mae, ws_id_pres_base, wsigno_kardex, ws_id_comp_det, wid_oper_maestro)
                '                MsgBox(dtResultado.Rows.Count)
                ' Si el DataTable acumulado está vacío, copiar la estructura del DataTable resultado
                If dtenlaces_loteser.Rows.Count = 0 Then
                    dtenlaces_loteser = dtResultado.Clone()
                End If
                ' Agregar todas las filas del DataTable resultado al DataTable acumulado
                dtenlaces_loteser.Merge(dtResultado)
            Next

            'MsgBox(dtenlaces_loteser.Rows.Count)
            'Stop

        End If

        'Stop
        'Exit Sub

        Dim dt_cuentasn As New DataTable()
        dt_cuentasn.Columns.Add("id_negocio", GetType(Integer))
        dt_cuentasn.Columns.Add("id_oper_maestro", GetType(Integer))
        dt_cuentasn.Columns.Add("id_comp_cab", GetType(Integer))
        dt_cuentasn.Columns.Add("id_carterasn_cab", GetType(Integer))
        dt_cuentasn.Columns.Add("id_carterasn_det", GetType(Integer))
        dt_cuentasn.Columns.Add("nro_cuota", GetType(Integer))
        dt_cuentasn.Columns.Add("fecha_vcto", GetType(DateTime))
        dt_cuentasn.Columns.Add("fecha_vcto_orig", GetType(DateTime))
        dt_cuentasn.Columns.Add("ref", GetType(String))
        dt_cuentasn.Columns.Add("total", GetType(Double))
        dt_cuentasn.Columns.Add("estado", GetType(Integer))
        dt_cuentasn.Columns.Add("id_tb_tipdoc", GetType(Integer))
        dt_cuentasn.Columns.Add("serie_doc", GetType(String))
        dt_cuentasn.Columns.Add("numero_doc", GetType(String))


        Dim wcsn_id_carterasn_det As Integer
        Dim wcsn_nro_cuota As Integer
        Dim wcsn_fecha_vcto As DateTime
        Dim wcsn_fecha_vcto_orig As DateTime
        Dim wcsn_ref As String
        Dim wcsn_total As Double
        Dim wcsn_estado As Integer
        Dim wcsn_id_tb_tipdoc As Integer
        Dim wcsn_serie_doc As String
        Dim wcsn_numero_doc As String


        Dim wcsn_id_carterasn_cab As Integer


        If wes_cuentasn <> 0 Then
            wcsn_id_carterasn_cab = 1
            wnivel_cuentasn = 4
            wcsn_id_carterasn_det = 1
            wcsn_nro_cuota = 1
            wcsn_fecha_vcto = wfecha_emis
            wcsn_fecha_vcto_orig = wfecha_emis
            wcsn_ref = ""
            wcsn_total = wtotal
            wcsn_estado = 1
            wcsn_id_tb_tipdoc = 0
            wcsn_serie_doc = ""
            wcsn_numero_doc = ""

            dt_cuentasn.Rows.Add(wid_negocio, wid_oper_maestro, wid_comp_cab, wcsn_id_carterasn_cab, wcsn_id_carterasn_det, wcsn_nro_cuota, wcsn_fecha_vcto,
                               wcsn_fecha_vcto_orig, wcsn_ref, wcsn_total, wcsn_estado, wcsn_id_tb_tipdoc, wcsn_serie_doc, wcsn_numero_doc)

        End If

        Dim dt_cuentasn_letras As New DataTable()
        dt_cuentasn_letras.Columns.Add("id_negocio", GetType(Integer))
        dt_cuentasn_letras.Columns.Add("id_oper_maestro", GetType(Integer))
        dt_cuentasn_letras.Columns.Add("id_comp_cab", GetType(Integer))
        dt_cuentasn_letras.Columns.Add("id_carterasn_cab", GetType(Integer))
        dt_cuentasn_letras.Columns.Add("id_carterasn_det", GetType(Integer))
        dt_cuentasn_letras.Columns.Add("nro_cuota", GetType(Integer))
        dt_cuentasn_letras.Columns.Add("fecha_vcto", GetType(DateTime))
        dt_cuentasn_letras.Columns.Add("fecha_vcto_orig", GetType(DateTime))
        dt_cuentasn_letras.Columns.Add("ref", GetType(String))
        dt_cuentasn_letras.Columns.Add("total", GetType(Double))
        dt_cuentasn_letras.Columns.Add("estado", GetType(Integer))
        dt_cuentasn_letras.Columns.Add("id_tb_tipdoc", GetType(Integer))
        dt_cuentasn_letras.Columns.Add("serie_doc", GetType(String))
        dt_cuentasn_letras.Columns.Add("numero_doc", GetType(String))


        Dim wle_id_carterasn_det As Integer
        Dim wle_nro_cuota As Integer
        Dim wle_fecha_vcto As DateTime
        Dim wle_fecha_vcto_orig As DateTime
        Dim wle_ref As String
        Dim wle_total As Double
        Dim wle_estado As Integer
        Dim wle_id_tb_tipdoc As Integer
        Dim wle_serie_doc As String
        Dim wle_numero_doc As String





        If wes_canje_le <> 0 Then

            For i = 0 To dg_doc_canje.Rows.Count - 1

                wcsn_id_carterasn_cab = 1
                wnivel_cuentasn = 4
                wle_id_carterasn_det = dg_doc_canje.Rows(i).Cells("num").Value
                wle_nro_cuota = dg_doc_canje.Rows(i).Cells("num").Value
                wle_fecha_vcto = dg_doc_canje.Rows(i).Cells("fechavcto").Value
                wle_fecha_vcto_orig = dg_doc_canje.Rows(i).Cells("fechavcto").Value
                wle_ref = dg_doc_canje.Rows(i).Cells("ref").Value
                wle_total = dg_doc_canje.Rows(i).Cells("monto").Value
                wle_estado = 1
                wle_id_tb_tipdoc = 1
                wle_serie_doc = dg_doc_canje.Rows(i).Cells("serie").Value
                wle_numero_doc = dg_doc_canje.Rows(i).Cells("numero").Value
                dt_cuentasn_letras.Rows.Add(wid_negocio, wid_oper_maestro, wid_comp_cab, wcsn_id_carterasn_cab, wle_id_carterasn_det, wle_nro_cuota, wle_fecha_vcto,
                               wle_fecha_vcto_orig, wle_ref, wle_total, wle_estado, wle_id_tb_tipdoc, wle_serie_doc, wle_numero_doc)

            Next i

        End If


        Dim dt_cuentasn_enlace As New DataTable()
        dt_cuentasn_enlace.Columns.Add("id_negocio", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("id_carterasn_enlaces", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("numsec", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("id_oper_maestro", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("id_comp_cab", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("id_carterasn_cab", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("id_carterasn_det", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("total", GetType(Double))
        dt_cuentasn_enlace.Columns.Add("signo_sn", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("fecha", GetType(DateTime))
        dt_cuentasn_enlace.Columns.Add("id_cobrador", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("id_oper_maestro_base", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("id_comp_cab_base", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("estado", GetType(Integer))


        Dim wcsnen_id_carterasn_enlaces As Integer = 0
        Dim wcsnen_numsec As Integer = 0
        Dim wcsnen_id_oper_maestro As Integer = 0
        Dim wcsnen_id_comp_cab As Integer = 0
        Dim wcsnen_id_carterasn_cab As Integer = 0
        Dim wcsnen_id_carterasn_det As Integer = 0
        Dim wcsnen_signo_sn As Integer = 0
        Dim wcsnen_fecha As DateTime = lk_fecha_dia
        Dim wcsnen_id_cobrador As Integer = 0
        Dim wcsnen_id_oper_maestro_base As Integer = 0
        Dim wcsnen_id_comp_cab_base As Integer = 0
        Dim wcsnen_estado As Integer = 0
        Dim wcsnen_total As Double = 0
        Dim wes_liquidacion As Integer = 0

        If wsigno_sn = 2 Then
            wes_liquidacion = 1
        End If



        If wsigno_sn <> 0 And wsigno_entidad <> 0 And wes_liquidacion = 0 Then

            For i = 0 To dg_cuentasn.Rows.Count - 1
                If Val(dg_cuentasn.Rows(i).Cells("id_oper_maestro").Value) = 0 Then Continue For


                wid_negocio = lk_NegocioActivo.id_Negocio
                wcsnen_id_carterasn_enlaces = 1
                wcsnen_numsec = i + 1
                wcsnen_id_oper_maestro = dg_cuentasn.Rows(i).Cells("id_oper_maestro").Value
                wcsnen_id_comp_cab = dg_cuentasn.Rows(i).Cells("id_comp_cab").Value
                wcsnen_id_carterasn_cab = dg_cuentasn.Rows(i).Cells("id_carterasn_cab").Value
                wcsnen_id_carterasn_det = dg_cuentasn.Rows(i).Cells("id_carterasn_det").Value
                wcsnen_total = dg_cuentasn.Rows(i).Cells("aplicar").Value
                wcsnen_signo_sn = wsigno_sn
                wcsnen_fecha = lk_fecha_dia
                wcsnen_id_cobrador = 1
                wcsnen_id_oper_maestro_base = 1
                wcsnen_id_comp_cab_base = 1
                wcsnen_estado = 1
                dt_cuentasn_enlace.Rows.Add(wid_negocio, wcsnen_id_carterasn_enlaces, wcsnen_numsec, wcsnen_id_oper_maestro, wcsnen_id_comp_cab, wcsnen_id_carterasn_cab, wcsnen_id_carterasn_det, wcsnen_total, wcsnen_signo_sn, wcsnen_fecha, wcsnen_id_cobrador, wcsnen_id_oper_maestro_base, wcsnen_id_comp_cab_base, wcsnen_estado)
            Next i
        End If
        If wes_liquidacion = 1 Then
            For i = 0 To dg_cuentasn.Rows.Count - 1
                If Val(dg_cuentasn.Rows(i).Cells("id_oper_maestro").Value) = 0 Then Continue For

                wid_negocio = lk_NegocioActivo.id_Negocio
                wcsnen_id_carterasn_enlaces = 1
                wcsnen_numsec = i + 1
                wcsnen_id_oper_maestro = dg_cuentasn.Rows(i).Cells("id_oper_maestro").Value
                wcsnen_id_comp_cab = dg_cuentasn.Rows(i).Cells("id_comp_cab").Value
                wcsnen_id_carterasn_cab = dg_cuentasn.Rows(i).Cells("id_carterasn_cab").Value
                wcsnen_id_carterasn_det = dg_cuentasn.Rows(i).Cells("id_carterasn_det").Value
                wcsnen_total = dg_cuentasn.Rows(i).Cells("aplicar").Value
                wcsnen_signo_sn = dg_cuentasn.Rows(i).Cells("signo_sn").Value
                wcsnen_fecha = lk_fecha_dia
                wcsnen_id_cobrador = 1
                wcsnen_id_oper_maestro_base = 1
                wcsnen_id_comp_cab_base = 1
                wcsnen_estado = 1
                dt_cuentasn_enlace.Rows.Add(wid_negocio, wcsnen_id_carterasn_enlaces, wcsnen_numsec, wcsnen_id_oper_maestro, wcsnen_id_comp_cab, wcsnen_id_carterasn_cab, wcsnen_id_carterasn_det, wcsnen_total, wcsnen_signo_sn, wcsnen_fecha, wcsnen_id_cobrador, wcsnen_id_oper_maestro_base, wcsnen_id_comp_cab_base, wcsnen_estado)
            Next i
        End If



        Dim dt_finanzas_enlace As New DataTable()
        dt_finanzas_enlace.Columns.Add("id_negocio", GetType(Integer))
        dt_finanzas_enlace.Columns.Add("numsec", GetType(Integer))
        dt_finanzas_enlace.Columns.Add("id_moneda", GetType(Integer))
        dt_finanzas_enlace.Columns.Add("id_tb_formas_fn", GetType(Integer))
        dt_finanzas_enlace.Columns.Add("id_fn_maestro", GetType(Integer))
        dt_finanzas_enlace.Columns.Add("fecha_fn", GetType(DateTime))
        dt_finanzas_enlace.Columns.Add("nrodoc", GetType(String))
        dt_finanzas_enlace.Columns.Add("ref", GetType(String))
        dt_finanzas_enlace.Columns.Add("total", GetType(Double))
        dt_finanzas_enlace.Columns.Add("signo_fn", GetType(Integer))
        dt_finanzas_enlace.Columns.Add("id_controlcaja_det", GetType(Integer))

        If BoxEntidadF.Visible Then

            'End If
            'If wsigno_entidad <> 0 Then
            If dt_DatosFinanzas_oper Is Nothing Then
                SMS_Barra("Operacion sin Datos de Finanzas , debe ingresar la información", 2)
                Exit Sub
            End If
            If dt_DatosFinanzas_oper.Rows.Count = 0 Then
                SMS_Barra("Operacion sin Datos de Finanzas , debe ingresar la información", 2)
                Exit Sub
            End If

            dt_finanzas_enlace = dt_DatosFinanzas_oper.Copy()
            If wnivel_comp = 4 Then
                westado = 8
            End If
        End If

        Dim dt_cuentasn_nc_enlace As New DataTable()
        dt_cuentasn_nc_enlace.Columns.Add("id_negocio", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("id_carterasn_enlaces", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("numsec", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("id_oper_maestro", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("id_comp_cab", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("id_carterasn_cab", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("id_carterasn_det", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("total", GetType(Double))
        dt_cuentasn_nc_enlace.Columns.Add("signo_sn", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("fecha", GetType(DateTime))
        dt_cuentasn_nc_enlace.Columns.Add("id_cobrador", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("id_oper_maestro_base", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("id_comp_cab_base", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("estado", GetType(Integer))

        If wes_aplica_nc = 1 And wes_finanzas = 1 Then
            MsgBox(dt_DatosFinanzas_NC.Rows.Count)
            dt_cuentasn_nc_enlace = dt_DatosFinanzas_NC.Copy()

        End If


        If wes_canje_le = 1 Then
            Dim DataSeleccion_fn As New DataTable()
            DataSeleccion_fn.Columns.Clear()
            DataSeleccion_fn.Columns.Add("id_negocio", GetType(Integer))
            DataSeleccion_fn.Columns.Add("numsec", GetType(Integer))
            DataSeleccion_fn.Columns.Add("id_moneda", GetType(Integer))
            DataSeleccion_fn.Columns.Add("id_tb_formas_fn", GetType(Integer))
            DataSeleccion_fn.Columns.Add("id_fn_maestro", GetType(Integer))
            DataSeleccion_fn.Columns.Add("fecha_fn", GetType(DateTime))
            DataSeleccion_fn.Columns.Add("nrodoc", GetType(String))
            DataSeleccion_fn.Columns.Add("ref", GetType(String))
            DataSeleccion_fn.Columns.Add("total", GetType(Double))
            DataSeleccion_fn.Columns.Add("signo_fn", GetType(Integer))
            DataSeleccion_fn.Columns.Add("id_controlcaja_det", GetType(Integer))

            Dim addrow As DataRow = DataSeleccion_fn.NewRow()
            addrow.Item("id_negocio") = lk_NegocioActivo.id_Negocio
            addrow.Item("numsec") = 1
            addrow.Item("id_moneda") = Val(CmdMonedaComp.Tag)
            addrow.Item("id_tb_formas_fn") = 0
            addrow.Item("id_fn_maestro") = 0
            addrow.Item("fecha_fn") = wfecha
            addrow.Item("nrodoc") = ""
            addrow.Item("ref") = "Canje-AT"
            addrow.Item("total") = wtotal
            addrow.Item("signo_fn") = -1
            addrow.Item("id_controlcaja_det") = 0
            DataSeleccion_fn.Rows.Add(addrow)
            dt_finanzas_enlace = DataSeleccion_fn.Copy()
            If wnivel_comp = 4 Then
                westado = 8
            End If

        End If


        ' VALIDAR INGRESO DE ITEM

        'Stop
        'Exit Sub

        ' Dim connectionString As String = "Data Source=PCACOSME;Initial Catalog=r23_negocio_cuenta;User ID=sa;Password=159357852456"

        'Using lk_connection_cuenta As New SqlConnection(connectionString)
        '    lk_connection_cuenta.Open()

        '    ' Crea un objeto SqlCommand para llamar al SP
        '    Dim cmd As New SqlCommand("Oper_InsertarComp", lk_connection_cuenta)
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.Parameters.Clear()

        'Stop

        Using cmd As New SqlCommand("Oper_InsertarComp", lk_connection_cuenta)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Clear()

            ' Agrega los parámetros de entrada
            cmd.Parameters.AddWithValue("@id_negocio", wid_negocio)
            cmd.Parameters.AddWithValue("@id_oper_maestro", wid_oper_maestro)
            cmd.Parameters.AddWithValue("@id_comp_cab", wid_comp_cab)
            cmd.Parameters.AddWithValue("@id_local", wid_local)
            cmd.Parameters.AddWithValue("@nivel_comp", wnivel_comp)
            cmd.Parameters.AddWithValue("@fecha", wfecha)
            cmd.Parameters.AddWithValue("@fecha_emis", wfecha_emis)
            cmd.Parameters.AddWithValue("@id_doc_oper", wid_doc_oper)
            cmd.Parameters.AddWithValue("@serie_oper", wserie_oper)
            cmd.Parameters.AddWithValue("@numero_oper", wnumero_oper)
            cmd.Parameters.AddWithValue("@id_comprobante", wid_comprobante)
            cmd.Parameters.AddWithValue("@sere_comp", wsere_comp)
            cmd.Parameters.AddWithValue("@numero_comp", wnumero_comp)
            cmd.Parameters.AddWithValue("@id_sn_master", wid_sn_master)
            cmd.Parameters.AddWithValue("@id_vendedor", wid_vendedor)
            cmd.Parameters.AddWithValue("@id_entidad", wid_entidad)
            cmd.Parameters.AddWithValue("@id_contacto", wid_contacto)
            cmd.Parameters.AddWithValue("@id_dir_entrega", wid_dir_entrega)
            cmd.Parameters.AddWithValue("@id_dir_cobro", wid_dir_cobro)
            cmd.Parameters.AddWithValue("@id_condicion", wid_condicion)
            cmd.Parameters.AddWithValue("@fecha_vcto", wfecha_vcto)
            cmd.Parameters.AddWithValue("@estado", westado)
            cmd.Parameters.AddWithValue("@id_moneda", wid_moneda)
            cmd.Parameters.AddWithValue("@id_prioridad", wid_prioridad)
            cmd.Parameters.AddWithValue("@fecha_ate", wfecha_ate)
            cmd.Parameters.AddWithValue("@ref", wref)
            cmd.Parameters.AddWithValue("@valor_gravado", wvalor_gravado)
            cmd.Parameters.AddWithValue("@valor_bonificado", wvalor_bonificado)
            cmd.Parameters.AddWithValue("@valor_nogravado", wvalor_nogravado)
            cmd.Parameters.AddWithValue("@valor_exonerado", wvalor_exonerado)
            cmd.Parameters.AddWithValue("@impto", wimpto)
            cmd.Parameters.AddWithValue("@total", wtotal)
            cmd.Parameters.AddWithValue("@id_usuario", wid_usuario)
            cmd.Parameters.AddWithValue("@es_kardex", wes_kardex)
            cmd.Parameters.AddWithValue("@es_servicio", wes_servicio)
            cmd.Parameters.AddWithValue("@signo_entidad", wsigno_entidad)
            cmd.Parameters.AddWithValue("@signo_sn", wsigno_sn)
            cmd.Parameters.AddWithValue("@es_comp_enlace", wes_comp_enlace)
            cmd.Parameters.AddWithValue("@es_manual_comp", wes_manual_comp)
            cmd.Parameters.AddWithValue("@es_cuentasn", wes_cuentasn)
            cmd.Parameters.AddWithValue("@nivel_cuentasn", wnivel_cuentasn)
            cmd.Parameters.AddWithValue("@tipo_transf_kardex", wtipo_transf_kardex)
            cmd.Parameters.AddWithValue("@modo_calculo", wmodo_calculo)
            cmd.Parameters.AddWithValue("@es_canje_comp", wes_canje_comp)
            cmd.Parameters.AddWithValue("@es_canje_le", wes_canje_le)
            cmd.Parameters.AddWithValue("@es_aplica_nc", wes_aplica_nc)
            cmd.Parameters.AddWithValue("@porc_impto", wporc_impto)
            cmd.Parameters.AddWithValue("@es_limite_credito", wes_limite_credito)
            cmd.Parameters.AddWithValue("@dias_credito", wdias_credito)
            cmd.Parameters.AddWithValue("@signo_lc", wsigno_lc)
            cmd.Parameters.AddWithValue("@diasvcto", wdiasvcto)
            cmd.Parameters.AddWithValue("@ref_codigo_comp", wref_codigo_comp)
            cmd.Parameters.AddWithValue("@ref_serie_comp", wref_serie_comp)
            cmd.Parameters.AddWithValue("@ref_numero_comp", wref_numero_comp)
            cmd.Parameters.AddWithValue("@ref_fecha_comp", wref_fecha_comp)
            cmd.Parameters.AddWithValue("@ref_codigo_motivo", wref_codigo_motivo)
            cmd.Parameters.AddWithValue("@ref_descripcion_motivo", wref_descripcion_motivo)


            ' Agrega el parámetro de tabla temporal de detalle
            Dim detalleParam As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalDetalle", detalle)
            Dim enlacesParam As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalEnlaces", enlace_comp)
            Dim cuentasnParam As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalCarterasn", dt_cuentasn)
            Dim cuentasn_enla_Param As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalCarterasn_enlace", dt_cuentasn_enlace)
            Dim cuentasn_nc_enla_Param As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalCarterasn_nc_enlace", dt_cuentasn_nc_enlace)
            Dim finanzas_enla_Param As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalfinanzas_enlaces", dt_finanzas_enlace)
            Dim enlaces_loteser_Param As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalm_enlaces_loteser", dtenlaces_loteser)
            Dim cuentasnParam_letras As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalCarterasn_canje", dt_cuentasn_letras)

            'Dim resultadoParam As SqlParameter = cmd.Parameters.Add("@Resultado", SqlDbType.VarChar, 50)
            'resultadoParam.Direction = ParameterDirection.Output

            'Dim resultado As String = String.Empty
            cmd.Parameters.Add("@Resultado", SqlDbType.VarChar, 300).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@reg_sec_numint", SqlDbType.Int, 10).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@reg_sec_numcomp", SqlDbType.Int, 10).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@reg_sec_carteracab", SqlDbType.Int, 10).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@reg_sec_carteradet", SqlDbType.Int, 10).Direction = ParameterDirection.Output



            detalleParam.SqlDbType = SqlDbType.Structured
            'detalleParam.TypeName = "dbo.Tipo_add_m_comprobantes_det"




            ' Ejecuta el comando Operacion Activa
            Try

                cmd.ExecuteNonQuery()
                Wresultado = DirectCast(cmd.Parameters("@Resultado").Value, String)
                If Strings.Left(Wresultado, 6) = "STOCK*" Then ' VALIDACION RPO STOCK FALANTE
                    SMS_Barra("VALIDACION: " & Wresultado, 2)
                    Exit Sub
                End If
                If Strings.Left(Wresultado, 6) = "ACCES*" Then ' VALIDACION RPO STOCK FALANTE
                    PlaySonidoMouse(lk_CodigoSonido)
                    Dim Result = MensajesBox.Show("SISTEMA SE CERRARA : " + Wresultado,
                                     "ACCESO RESTRINGIDO.")
                    Application.Exit()
                    Exit Sub
                End If


                wreg_sec_numint = DirectCast(cmd.Parameters("@reg_sec_numint").Value, Integer)
                wreg_sec_numcomp = DirectCast(cmd.Parameters("@reg_sec_numcomp").Value, Integer)
                wreg_sec_carteracab = DirectCast(cmd.Parameters("@reg_sec_carteracab").Value, Integer)
                wreg_sec_carteradet = DirectCast(cmd.Parameters("@reg_sec_carteradet").Value, Integer)

            Catch ex As Exception
                werror = ex.Message
                ' manejo de excepciones  ex.Message 
            End Try

        End Using

        If werror <> String.Empty Then ' ERROR DE SQL
            MsgBox(werror)
        End If

        If Wresultado <> String.Empty Then
            If wdirecto_id_tb_oper <> 0 And wdirecto_id_oper_maestro <> 0 And wes_servicio <> 1 Then
                ' rutina adicional para las operaciones que estan enlazas para inventarios directo
                Grabar_Operacion_directo_Inventario("INV", wreg_sec_carteracab, wreg_sec_carteradet, wreg_sec_numcomp, wCodOper, wdirecto_id_tb_oper, wid_oper_maestro, wdirecto_id_oper_maestro)
            End If
            If wfn_directo_id_tb_oper <> 0 And wfn_directo_id_oper_maestro <> 0 Then
                ' rutina adicional para las operaciones que estan enlazas para inventarios directo
                Grabar_Operacion_directo_Inventario("FNZ", wreg_sec_carteracab, wreg_sec_carteradet, wreg_sec_numcomp, wCodOper, wfn_directo_id_tb_oper, wid_oper_maestro, wfn_directo_id_oper_maestro)
            End If




            'MsgBox("REGISTRO GRABADO:" & Wresultado)
            SMS_Barra("REGISTRO GRABADO CON EXITO : " & Wresultado, 1)
            '==========
            ' envio a impresion del comprobate
            '==========

            Envia_Impresion_Comprobante(wid_oper_maestro, wreg_sec_numcomp)

            ' Datos despuestde ede la grabacion Muestra COmprobantes Grabados
            TxtComp_Numero.Text = Format(wreg_sec_numcomp, "00000000")
            TxtNumDocOper.Text = Format(wreg_sec_numint, "00000000")
            CancelaOper("GRABAR")
            If CmdOperacion.AccessibleDescription <> "" Then 'Primera Ubiacion 
                SaltoBox(CmdOperacion.AccessibleDescription)
            End If
        End If




    End Sub

    Private Sub Grabar_Operacion_directo_Inventario(wtipo_Directo As String, wreg_sec_carteracab As Integer, wreg_sec_carteradet As Integer, wid_comp_cab_base_desde As Integer, wid_CodOpe_desde As Integer, wid_CodOpe_hacia As Integer, wid_oper_maestro_desde As Integer, wid_oper_maestro_hacia As Integer)
        ' wtipo_Directo = 'INV' O wtipo_Directo = 'FNZ'
        'wreg_sec_carteracab
        'wreg_sec_carteradet
        Dim controlLabel As Label

        'var Cabecera
        Dim wnivel_comp As Integer = 0
        Dim wfecha As DateTime
        Dim wfecha_emis As DateTime
        Dim wid_doc_oper As Integer = 0
        Dim wserie_oper As String = ""
        Dim wnumero_oper As Integer
        Dim wid_comprobante As Integer = 0
        Dim wsere_comp As String = ""
        Dim wnumero_comp As Integer = 0
        Dim wid_sn_master As Integer = 0
        Dim wid_vendedor As Integer = 0
        Dim wid_entidad As Integer = 0
        Dim wid_contacto As Integer = 0
        Dim wid_dir_entrega As Integer = 0
        Dim wid_dir_cobro As Integer = 0
        Dim wid_condicion As Integer = 0
        Dim wfecha_vcto As DateTime
        Dim westado As Integer = 0
        Dim wid_moneda As Integer = 0
        Dim wid_prioridad As Integer = 0
        Dim wfecha_ate As DateTime
        Dim wref As String = ""
        Dim wvalor_gravado As Double
        Dim wvalor_bonificado As Double = 0
        Dim wvalor_nogravado As Double



        Dim wvalor_exonerado As Double
        Dim wimpto As Double
        Dim wtotal As Double
        Dim wid_usuario As Integer = 0
        Dim wes_kardex As Integer = 0
        Dim wes_servicio As Integer = 0
        Dim wsigno_entidad As Integer = 0
        Dim wsigno_sn As Integer = 0
        Dim wes_comp_enlace As Integer = 0

        Dim wnivel_cuentasn As Integer = 0
        Dim wes_cuentasn As Integer = 0
        Dim wtipo_transf_kardex As Integer = 0

        Dim wmodo_calculo As Integer = 0
        Dim wes_canje_comp As Integer = 0
        Dim wes_canje_le As Integer = 0
        Dim wes_aplica_nc As Integer = 0
        Dim wes_finanzas As Integer = 0
        Dim wporc_impto As Double = 0

        Dim wes_limite_credito As Double = 0
        Dim wdias_credito As Integer = 0
        Dim wsigno_lc As Integer = 0
        Dim wdiasvcto As Integer = 0


        Dim wref_codigo_comp As String = ""
        Dim wref_serie_comp As String = ""
        Dim wref_numero_comp As String = ""
        Dim wref_fecha_comp As String = ""
        Dim wref_codigo_motivo As String = ""
        Dim wref_descripcion_motivo As String = ""





        ' Var de detalle
        Dim wid_negocio As Integer
        Dim wid_local As Integer
        Dim wid_oper_maestro As Integer
        Dim wid_comp_cab As Integer
        Dim wid_comp_det As Integer
        Dim wid_almacen As Integer
        Dim wid_prod_mae As Double = 0
        Dim wref_prod_mae As String = ""
        Dim wcantidad As Double
        Dim wequiv As Integer
        Dim wdescrip_pres As String = ""
        Dim wid_pres As Integer
        Dim wsigno_kardex As Integer
        Dim wtipo_valor As Integer
        Dim wimpto_det As Double
        Dim wprecio As Double
        Dim wprecio_orig As Double
        Dim wsubtotal As Double
        Dim wes_control_lote As Integer
        Dim wsituacion_det As Integer
        Dim westado_det As Integer
        Dim wes_manual_comp As Integer
        Dim wid_almacen_transf As Integer
        Dim wloteser_det As String = ""
        Dim wvalor As Double = 0
        Dim wprecio_valor As Double = 0
        Dim wes_costeo As Integer = 0

        Dim wes_prod_new As Integer = 0
        Dim wprod_new_nombre As String = ""
        Dim wprod_new_codigo As String = ""
        Dim wloteser_det_formato As String = ""
        Dim wes_inventariable As Integer = 0
        Dim wes_exonerado As Integer = 0
        Dim wes_bonificado As Integer = 0

        Dim wid_serv As Integer = 0
        Dim wid_area As Integer = 0
        Dim wid_uci As Integer = 0
        Dim wid_local_serv As Integer = 0



        ' Var de Enlaces
        Dim wid_enlace As Integer = 0
        Dim wnumsec_enlace As Integer = 0
        Dim wid_local_bas As Integer = 0
        Dim wid_oper_maestro_base As Integer = 0
        Dim wid_comp_cab_base As Integer = 0
        Dim wid_comp_det_base As Integer = 0
        Dim wid_almacen_base As Integer = 0
        Dim wfecha_enlace As DateTime
        Dim wid_prod_mae_enlace As Double = 0
        Dim wcantidad_enlace As Double = 0
        Dim wequiv_enlace As Integer = 0
        Dim wdescrip_pres_enlace As String = ""
        Dim wid_pres_enlace As Integer = 0
        Dim wsigno_kardex_enlace As Integer = 0
        Dim wid_local_dest_enlace As Integer = 0
        Dim wid_oper_maestro_dest_enlace As Integer = 0
        Dim wid_comp_cab_dest_enlace As Integer = 0
        Dim wsituacion_enlace As Integer = 0
        Dim westado_enlace As Integer = 0

        Dim wes_cospro As Integer = 0

        Dim westado_oper_def As Integer


        Dim werror As String = String.Empty
        Dim Wresultado As String = String.Empty
        Dim wreg_sec_numint As Integer = 0
        Dim wreg_sec_numcomp As Integer = 0



        wnivel_comp = 0
        wfecha = TxtFechas_Proc.Value
        wfecha_emis = TxtFechas_Emis.Value
        wid_doc_oper = Val(TxtDocOper.Tag)
        wserie_oper = TxtSerieDocOper.Tag
        wnumero_oper = 0 ' Se Asigan en el sp es automativo
        wid_comprobante = Val(CmdComprob.Tag)
        wsere_comp = TxtSerireComp.Text
        wnumero_comp = Val(TxtComp_Numero.Text)  ' Se Asigan en el sp es automativo
        wid_sn_master = Val(info_SN.Tag)
        wid_vendedor = 0
        wid_entidad = 0
        wid_contacto = 0
        wid_dir_entrega = 0
        wid_dir_cobro = 0
        wid_condicion = 0
        wfecha_vcto = TxtCondi_FecVcto.Value
        westado = 1
        wid_moneda = Val(CmdMonedaComp.Tag)
        wid_prioridad = 0
        wfecha_ate = TxtPrioridad_FecAten.Value
        wref = ""
        wid_usuario = lk_id_usuario
        wes_kardex = 0
        If Radio_Serv.Checked Then
            wes_servicio = 1
        Else
            wes_servicio = 0
        End If
        wsigno_entidad = 0
        wsigno_sn = 0
        wes_comp_enlace = 1
        If chkConIMPTO.Checked Then wmodo_calculo = 1
        If chkSinIMPTO.Checked Then wmodo_calculo = 2



        wid_almacen_transf = 0
        wvalor_gravado = 0
        wvalor_bonificado = 0
        wvalor_nogravado = 0
        wvalor_bonificado = 0
        wvalor_exonerado = 0
        wimpto = 0
        wtotal = 0
        wes_manual_comp = 0

        ' Validaciones Basicas de entorno:
        If BoxComprobantes.Visible Then
            If Val(CmdComprob.Tag) = 0 Then
                SMS_Barra("Operacion sin Comprobante , debe configurar la Tienda", 3)
                Exit Sub
            End If
            If Trim(TxtSerireComp.Tag) = "" Then
                SMS_Barra("Operacion sin Serires , debe configurar la Tienda", 3)
                Exit Sub
            End If
            wes_manual_comp = 0 ' Siempre sera Automativo nunca manual ya que viene de otra operacion  ''Val(CmdComprob.AccessibleDescription)
        End If







        Dim ListaOperacionAfecta() As DataRow = lk_sql_listaOperAfecta.Select("id_tb_oper = " & wid_CodOpe_hacia & "", "orden ASC")
        ' Recorremos las filas filtradas
        For i = 0 To ListaOperacionAfecta.Count - 1
            If ListaOperacionAfecta(i)("codigo_afecta") = "001" Then
                wnivel_comp = 1
            End If
            If ListaOperacionAfecta(i)("codigo_afecta") = "002" Then
                wnivel_comp = 2
            End If
            If ListaOperacionAfecta(i)("codigo_afecta") = "003" Then
                wnivel_comp = 3
            End If
            If ListaOperacionAfecta(i)("codigo_afecta") = "004" Then
                wnivel_comp = 4

            End If


        Next i







        ' VALIDA Y ASIGNA EN ZONA DE TOTALES 
        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "valor" AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            wvalor_gravado = Val(controlLabel.Tag)
        End If
        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "bonif" AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            wvalor_bonificado = Val(controlLabel.Tag)
        End If



        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "exonerado" AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            wvalor_exonerado = Val(controlLabel.Tag)
        End If

        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "impto" AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            wimpto = Val(controlLabel.Tag)
        End If

        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "subtotal" AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            wtotal = Val(controlLabel.Tag)
        End If

        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_oper_maestro = " & wid_oper_maestro_hacia & " ")
        If Obtener_id_oper_maestro.Count = 0 Then
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            Exit Sub
        End If
        wid_oper_maestro = Obtener_id_oper_maestro(0)("id_oper_maestro")
        wes_cuentasn = Obtener_id_oper_maestro(0)("es_cuentasn") ' afecta a registro de caunta correinte del socio de negocio
        wsigno_sn = Obtener_id_oper_maestro(0)("signo_cuentasn")  ' Indica si es debe o haber + / -  0 aplica a registro de enlace
        wsigno_entidad = Obtener_id_oper_maestro(0)("signo_finanzas")
        wes_kardex = Obtener_id_oper_maestro(0)("es_inventario")
        wsigno_kardex = Obtener_id_oper_maestro(0)("signo_inventario")
        westado_oper_def = Obtener_id_oper_maestro(0)("estado_oper_def")
        wtipo_transf_kardex = Obtener_id_oper_maestro(0)("tipo_transf_kardex")
        wes_costeo = Obtener_id_oper_maestro(0)("es_costeo")
        wes_cospro = Obtener_id_oper_maestro(0)("es_cospro")
        wes_canje_comp = Obtener_id_oper_maestro(0)("es_canje_comp")
        wes_canje_le = Obtener_id_oper_maestro(0)("es_canje_le")
        wes_finanzas = Obtener_id_oper_maestro(0)("es_finanzas")
        wes_aplica_nc = Obtener_id_oper_maestro(0)("es_aplica_nc")


        wid_local = Val(CmdLocal.Tag)

        Dim ListaComprobantes() As DataRow = lk_sql_comp_oper.Select("id_tb_oper = " & wid_CodOpe_hacia & " and es_interno = 0")
        If ListaComprobantes.Length = 0 Then
            Dim Result = MensajesBox.Show("OPERACION ENLAZADA FALTA CONFIGURACION:  No Tiene Comprobantes Asociados a la Operacion.",
                                     "Operación.")
            Exit Sub
        End If
        wid_comprobante = ListaComprobantes(0)("id_comprobante")
        Dim ListaSeries() As DataRow = lk_sql_serie_comp.Select("id_local = " & wid_local & " and id_comprobante = " & wid_comprobante & "")
        ' Recorremos las filas filtradas
        If ListaSeries.Length = 0 Then
            Dim Result = MensajesBox.Show("OPERACION ENLAZADA FALTA CONFIGURACION: No Tiene Serire Comprobante .",
                                     "Operación.")
            Exit Sub
        End If


        wsere_comp = ListaSeries(0)("serie")
        wnumero_comp = 0  'DEBE ESTAR CONFIGURADO AUTOMATIVO 

        'If wtipo_Directo = "FNZ" Then Stop

        westado = westado_oper_def   ' Toda operacion viene de la configuracion por defecto 1  o 8 

        If wtipo_transf_kardex = 1 Or wtipo_transf_kardex = 2 Then   ' 1= Envio , 2 = Recepecion , 0 = No es Trasnferencia
            wid_almacen_transf = Val(CmdAlmTransf.Tag)  ' almacena el almacen que se envia 
        End If


        If wnivel_comp = 4 Then 'Fuerza si viene de un vinel 4 - verifica si veien de un nivel comprobante anterior si cumple para poner CERRADO-AT
            westado = 8
        End If

        Dim Obtener_impto() As DataRow = lk_sql_impuesto_mae.Select("id_local = " & CmdLocal.Tag & " and codigo = 1 ")
        If Obtener_impto.Count = 0 Then
            SMS_Barra("Operacion con Error: NO DEFINIDO IMPUESTO", 3)
            Exit Sub
        End If
        wporc_impto = Obtener_impto(0)("vporc")

        If wnivel_comp = 4 Then
            If dt_DatosEnlace_oper Is Nothing Then ' marca los comp en cerrado-auto a nivel 4
                If wnivel_comp = 3 Then 'verifica si veien de un nivel comprobante anterior si cumple para poner CERRADO-AT
                    westado = 8
                End If
            Else
                If wnivel_comp = 4 Then
                    Dim Obtener_nivel() As DataRow = dt_DatosEnlace_oper.Select("nivel_comp = 3") 'verifica si veien de un nivel comprobante anterior si cumple para poner CERRADO-AT
                    If Obtener_nivel.Count <> 0 Then
                        westado = 8
                    End If
                End If
            End If

        End If



        ' Crea un DataTable para representar la tabla temporal de detalle
        Dim detalle As New DataTable()
        detalle.Columns.Add("id_negocio", GetType(Integer))
        detalle.Columns.Add("id_local", GetType(Integer))
        detalle.Columns.Add("id_oper_maestro", GetType(Integer))
        detalle.Columns.Add("id_comp_cab", GetType(Integer))
        detalle.Columns.Add("id_comp_det", GetType(Integer))
        detalle.Columns.Add("id_almacen", GetType(Integer))
        detalle.Columns.Add("id_prod_mae", GetType(Double))
        detalle.Columns.Add("ref_prod_mae", GetType(String))
        detalle.Columns.Add("cantidad", GetType(Double))
        detalle.Columns.Add("equiv", GetType(Integer))
        detalle.Columns.Add("descrip_pres", GetType(String))
        detalle.Columns.Add("id_pres", GetType(Integer))
        detalle.Columns.Add("signo_kardex", GetType(Integer))
        detalle.Columns.Add("tipo_valor", GetType(Integer))
        detalle.Columns.Add("impto", GetType(Double))
        detalle.Columns.Add("precio", GetType(Double))
        detalle.Columns.Add("precio_orig", GetType(Double))
        detalle.Columns.Add("subtotal", GetType(Double))
        detalle.Columns.Add("es_control_lote", GetType(Integer))
        detalle.Columns.Add("situacion", GetType(Integer))
        detalle.Columns.Add("estado", GetType(Integer))
        detalle.Columns.Add("id_almacen_transf", GetType(Integer))
        detalle.Columns.Add("loteser_det", GetType(String))
        detalle.Columns.Add("valor", GetType(Double))
        detalle.Columns.Add("precio_valor", GetType(Double))
        detalle.Columns.Add("es_costeo", GetType(Integer))
        detalle.Columns.Add("es_prod_new", GetType(Integer))
        detalle.Columns.Add("prod_new_nombre", GetType(String))
        detalle.Columns.Add("prod_new_codigo", GetType(String))
        detalle.Columns.Add("loteser_det_formato", GetType(String))
        detalle.Columns.Add("es_inventariable", GetType(Integer))
        detalle.Columns.Add("id_serv", GetType(Integer))
        detalle.Columns.Add("id_area", GetType(Integer))
        detalle.Columns.Add("id_uci", GetType(Integer))
        detalle.Columns.Add("id_local_serv", GetType(Integer))
        detalle.Columns.Add("es_exonerado", GetType(Integer))
        detalle.Columns.Add("es_bonificado", GetType(Integer))


        If GridProductos.Visible And wtipo_Directo = "INV" Then

            For i = 0 To GridProductos.Rows.Count - 1

                wid_serv = Val(GridProductos.Rows(i).Cells("id_serv").Value)
                wid_prod_mae = GridProductos.Rows(i).Cells("id_prod_mae").Value
                If wes_servicio = 1 And wid_serv = 0 Then Continue For
                If wes_servicio = 0 And wid_prod_mae = 0 Then Continue For


                wid_negocio = lk_NegocioActivo.id_Negocio
                wid_local = Val(CmdLocal.Tag)
                wid_comp_det = i + 1
                GridProductos.Rows(i).Cells("id_comp_det").Value = wid_comp_det ' Se Asigna para usar en enlaces_loteser
                wid_almacen = GridProductos.Rows(i).Cells("id_almacen").Value

                wref_prod_mae = GridProductos.Rows(i).Cells("masdetalle").Tag
                wcantidad = GridProductos.Rows(i).Cells("cantidad").Value
                wequiv = GridProductos.Rows(i).Cells("equiv").Value
                wdescrip_pres = GridProductos.Rows(i).Cells("present").Value
                wid_pres = GridProductos.Rows(i).Cells("id_pres").Value
                wtipo_valor = 1 ' 1 = GRABADO 
                wimpto_det = GridProductos.Rows(i).Cells("impto").Value
                wprecio = GridProductos.Rows(i).Cells("preciobase").Value
                wprecio_orig = GridProductos.Rows(i).Cells("preciobase").Value
                wsubtotal = GridProductos.Rows(i).Cells("subtotal").Value
                wvalor = GridProductos.Rows(i).Cells("valor").Value
                wprecio_valor = GridProductos.Rows(i).Cells("precio_valor").Value

                wes_control_lote = Val(GridProductos.Rows(i).Cells("es_control_lote").Value)
                wsituacion_det = 1
                westado_det = 1
                If wtipo_transf_kardex = 2 Then   ' 1= Envio , 2 = Recepecion , 0 = No es Trasnferencia
                    wid_almacen_transf = Val(GridProductos.Rows(i).Cells("id_almacen_trasnf").Value)  ' almacena el almacen que se envia 
                End If
                wloteser_det = GridProductos.Rows(i).Cells("cadenalotes").Value

                If GridProductos.Rows(i).Cells("es_prod_new").Value Then
                    wes_prod_new = 1
                    wprod_new_nombre = GridProductos.Rows(i).Cells("descrip").Value
                    wprod_new_codigo = GridProductos.Rows(i).Cells("codigo").Value
                Else
                    wes_prod_new = 0
                    wprod_new_nombre = ""
                    wprod_new_codigo = ""
                End If
                If GridProductos.Rows(i).Cells("es_prod_bof").Value Then
                    wes_bonificado = 1
                Else
                    wes_bonificado = 0
                End If

                wloteser_det_formato = GridProductos.Rows(i).Cells("cadenalotes_formato").Value
                wes_inventariable = Val(GridProductos.Rows(i).Cells("es_inventariable").Value)
                wes_exonerado = Val(GridProductos.Rows(i).Cells("es_exonerado").Value)




                wid_area = Val(GridProductos.Rows(i).Cells("id_area").Value)
                wid_uci = Val(GridProductos.Rows(i).Cells("id_uci").Value)
                wid_local_serv = Val(GridProductos.Rows(i).Cells("id_local_serv").Value)

                detalle.Rows.Add(wid_negocio, wid_local, wid_oper_maestro, wid_comp_cab, wid_comp_det, wid_almacen, wid_prod_mae, wref_prod_mae, wcantidad, wequiv, wdescrip_pres, wid_pres, wsigno_kardex, wtipo_valor, wimpto_det, wprecio, wprecio_orig, wsubtotal, wes_control_lote, wsituacion_det, westado_det, wid_almacen_transf, wloteser_det, wvalor, wprecio_valor, wes_costeo, wes_prod_new, wprod_new_nombre, wprod_new_codigo, wloteser_det_formato, wes_inventariable, wid_serv, wid_area, wid_uci, wid_local_serv, wes_exonerado, wes_bonificado)

            Next i
        Else  ' el caso cuand es documento sin detalle 
            wid_negocio = lk_NegocioActivo.id_Negocio
            wid_local = Val(CmdLocal.Tag)
            wid_comp_det = 1
            wid_almacen = 0
            wid_prod_mae = 0
            wref_prod_mae = ""
            wcantidad = 1
            wequiv = 1
            wdescrip_pres = "SERV"

            wid_pres = 30
            wsigno_kardex = 1
            wtipo_valor = 1 ' 1 = GRABADO 
            wimpto_det = 0
            wprecio = 0
            wprecio_orig = 0
            wsubtotal = wtotal
            wes_control_lote = 0
            wsituacion_det = 1
            westado_det = 1
            wid_almacen_transf = 0
            wloteser_det = ""
            wvalor = 0
            wprecio_valor = 0
            wes_costeo = 0
            wes_prod_new = 0
            wprod_new_nombre = ""
            wprod_new_codigo = ""
            wloteser_det_formato = ""
            wes_inventariable = 0
            wes_exonerado = 0
            wes_bonificado = 0
            wid_serv = 0
            wid_area = 0
            wid_uci = 0
            wid_local_serv = 0
            detalle.Rows.Add(wid_negocio, wid_local, wid_oper_maestro, wid_comp_cab, wid_comp_det, wid_almacen, wid_prod_mae, wref_prod_mae, wcantidad, wequiv, wdescrip_pres, wid_pres, wsigno_kardex, wtipo_valor, wimpto_det, wprecio, wprecio_orig, wsubtotal, wes_control_lote, wsituacion_det, westado_det, wid_almacen_transf, wloteser_det, wvalor, wprecio_valor, wes_costeo, wes_prod_new, wprod_new_nombre, wprod_new_codigo, wloteser_det_formato, wes_inventariable, wid_serv, wid_area, wid_uci, wid_local_serv, wes_exonerado, wes_bonificado)

        End If




        ' Crea un enlace de Comprobamnte la tabla temporal 
        Dim enlace_comp As New DataTable()
        enlace_comp.Columns.Add("id_negocio", GetType(Integer))
        enlace_comp.Columns.Add("id_enlace", GetType(Integer))
        enlace_comp.Columns.Add("numsec", GetType(Integer))
        enlace_comp.Columns.Add("id_local_base", GetType(Integer))
        enlace_comp.Columns.Add("id_oper_maestro_base", GetType(Integer))
        enlace_comp.Columns.Add("id_comp_cab_base", GetType(Integer))
        enlace_comp.Columns.Add("id_comp_det_base", GetType(Integer))
        enlace_comp.Columns.Add("id_almacen_base", GetType(Integer))
        enlace_comp.Columns.Add("fecha", GetType(DateTime))
        enlace_comp.Columns.Add("id_prod_mae", GetType(Double))
        enlace_comp.Columns.Add("cantidad", GetType(Double))
        enlace_comp.Columns.Add("equiv", GetType(Integer))
        enlace_comp.Columns.Add("descrip_pres", GetType(String))
        enlace_comp.Columns.Add("id_pres", GetType(Integer))
        enlace_comp.Columns.Add("signo_kardex", GetType(Integer))
        enlace_comp.Columns.Add("id_local_dest", GetType(Integer))
        enlace_comp.Columns.Add("id_oper_maestro_dest", GetType(Integer))
        enlace_comp.Columns.Add("id_comp_cab_dest", GetType(Integer))
        enlace_comp.Columns.Add("situacion", GetType(Integer))
        enlace_comp.Columns.Add("estado", GetType(Integer))

        If GridProductos.Visible And wtipo_Directo = "INV" Then
            enlace_comp.Rows.Clear()

            For i = 0 To GridProductos.Rows.Count - 1
                If Val(GridProductos.Rows(i).Cells("id_prod_mae").Value) = 0 Then Continue For
                wid_enlace = 0
                wid_local_bas = Val(CmdLocal.Tag)
                wnumsec_enlace = i + 1
                wid_oper_maestro_base = wid_oper_maestro_desde '  dt_DatosEnlace_oper.Rows(i).Item("id_oper_maestro_base")
                wid_comp_cab_base = wid_comp_cab_base_desde '  dt_DatosEnlace_oper.Rows(i).Item("id_comp_cab_base")
                wid_comp_det_base = i + 1 ' dt_DatosEnlace_oper.Rows(i).Item("id_comp_det_base")

                wid_almacen_base = GridProductos.Rows(i).Cells("id_almacen").Value '  dt_DatosEnlace_oper.Rows(i).Item("id_almacen_base")
                wfecha_enlace = TxtFechas_Proc.Value
                wid_prod_mae_enlace = Val(GridProductos.Rows(i).Cells("id_prod_mae").Value) ' dt_DatosEnlace_oper.Rows(i).Item("id_prod_mae")

                If CmdTraerDe.Tag = "1" Then  ' SOLO SE ACTIVA AL TRAER LOS DATOS 
                    wcantidad_enlace = dt_DatosEnlace_oper.Rows(i).Item("cantidad") * dt_DatosEnlace_oper.Rows(i).Item("equiv")
                    'wequiv_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_equiv_base")
                    'wdescrip_pres_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_abreviado_pres_base")
                    'wid_pres_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_id_pres_base")

                    wequiv_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_equiv_base")
                    wdescrip_pres_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_abreviado_pres_base")
                    wid_pres_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_id_pres_base")
                    wsigno_kardex_enlace = dt_DatosEnlace_oper.Rows(i).Item("signo_kardex")


                Else
                    wcantidad_enlace = GridProductos.Rows(i).Cells("cantidad").Value * GridProductos.Rows(i).Cells("equiv").Value ' no necesita multiplzar por que viene ya convertifo a equiv base
                    wequiv_enlace = GridProductos.Rows(i).Cells("equiv_base").Value
                    wdescrip_pres_enlace = GridProductos.Rows(i).Cells("abreviado_base").Value
                    wid_pres_enlace = GridProductos.Rows(i).Cells("id_pres_base").Value
                    wsigno_kardex_enlace = wsigno_kardex ' GridProductos.Rows(i).Cells("signo_kardex").Value


                    ' wequiv_enlace = GridProductos.Rows(i).Cells("equiv_base").Value
                    'wdescrip_pres_enlace = GridProductos.Rows(i).Cells("abreviado_base").Value
                    'wid_pres_enlace = GridProductos.Rows(i).Cells("id_pres_base").Value
                End If

                'wequiv_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_equiv_base")
                'wdescrip_pres_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_abreviado_pres_base")
                'wid_pres_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_id_pres_base")
                'wsigno_kardex_enlace = dt_DatosEnlace_oper.Rows(i).Item("signo_kardex")

                wid_local_dest_enlace = Val(CmdLocal.Tag)




                wsigno_kardex_enlace = wsigno_kardex ' dt_DatosEnlace_oper.Rows(i).Item("signo_kardex")
                wid_local_dest_enlace = Val(CmdLocal.Tag)
                wid_oper_maestro_dest_enlace = 0
                wid_comp_cab_dest_enlace = 0
                wsituacion_enlace = 1
                westado_enlace = westado


                enlace_comp.Rows.Add(wid_negocio, wid_local_bas, wnumsec_enlace, wid_local_bas, wid_oper_maestro_base, wid_comp_cab_base, wid_comp_det_base,
                                   wid_almacen_base, wfecha_enlace, wid_prod_mae_enlace, wcantidad_enlace, wequiv_enlace, wdescrip_pres_enlace, wid_pres_enlace, wsigno_kardex_enlace, wid_local_dest_enlace,
                                   wid_oper_maestro_dest_enlace, wid_comp_cab_dest_enlace, wsituacion_enlace, westado_enlace)
            Next i
        End If

        'If dt_DatosEnlace_oper Is Nothing Then
        'Else
        '    For i = 0 To dt_DatosEnlace_oper.Rows.Count - 1
        '        wid_enlace = 0
        '        wid_local_bas = Val(CmdLocal.Tag)
        '        wnumsec_enlace = i + 1
        '        wid_oper_maestro_base = wid_oper_maestro_desde '  dt_DatosEnlace_oper.Rows(i).Item("id_oper_maestro_base")
        '        wid_comp_cab_base = wid_comp_cab_base_desde '  dt_DatosEnlace_oper.Rows(i).Item("id_comp_cab_base")
        '        wid_comp_det_base = dt_DatosEnlace_oper.Rows(i).Item("id_comp_det_base")
        '        wid_almacen_base = dt_DatosEnlace_oper.Rows(i).Item("id_almacen_base")
        '        wfecha_enlace = TxtFechas_Proc.Value
        '        wid_prod_mae_enlace = dt_DatosEnlace_oper.Rows(i).Item("id_prod_mae")
        '        wcantidad_enlace = dt_DatosEnlace_oper.Rows(i).Item("cantidad") * dt_DatosEnlace_oper.Rows(i).Item("equiv")
        '        wequiv_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_equiv_base")
        '        wdescrip_pres_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_abreviado_pres_base")
        '        wid_pres_enlace = dt_DatosEnlace_oper.Rows(i).Item("dt_id_pres_base")
        '        wsigno_kardex_enlace = dt_DatosEnlace_oper.Rows(i).Item("signo_kardex")
        '        wid_local_dest_enlace = Val(CmdLocal.Tag)
        '        wid_oper_maestro_dest_enlace = 0
        '        wid_comp_cab_dest_enlace = 0
        '        wsituacion_enlace = 1
        '        westado_enlace = westado
        '        enlace_comp.Rows.Add(wid_negocio, wid_local_bas, wnumsec_enlace, wid_local_bas, wid_oper_maestro_base, wid_comp_cab_base, wid_comp_det_base,
        '                           wid_almacen_base, wfecha_enlace, wid_prod_mae_enlace, wcantidad_enlace, wequiv_enlace, wdescrip_pres_enlace, wid_pres_enlace, wsigno_kardex_enlace, wid_local_dest_enlace,
        '                           wid_oper_maestro_dest_enlace, wid_comp_cab_dest_enlace, wsituacion_enlace, westado_enlace)

        '    Next i

        'End If

        ' LLENAR LOS DATOS DE CADA FILA DE PRODUCTO CON LOS LOTES OBTENIDOS
        Dim dtenlaces_loteser As New DataTable()
        dtenlaces_loteser.Columns.Add("id_negocio", GetType(Integer))
        dtenlaces_loteser.Columns.Add("id_oper_maestro", GetType(Integer))
        dtenlaces_loteser.Columns.Add("id_comp_cab", GetType(Integer))
        dtenlaces_loteser.Columns.Add("id_comp_det", GetType(Integer))
        dtenlaces_loteser.Columns.Add("numsec", GetType(Integer))
        dtenlaces_loteser.Columns.Add("id_prod_mae", GetType(Integer))
        dtenlaces_loteser.Columns.Add("id_loteser", GetType(Integer))
        dtenlaces_loteser.Columns.Add("es_nuevo", GetType(Integer))
        dtenlaces_loteser.Columns.Add("Codigo", GetType(String))
        dtenlaces_loteser.Columns.Add("fechareg", GetType(DateTime))
        dtenlaces_loteser.Columns.Add("es_nocaduca", GetType(Integer))
        dtenlaces_loteser.Columns.Add("fechavcto", GetType(DateTime))
        dtenlaces_loteser.Columns.Add("id_pres", GetType(Integer))
        dtenlaces_loteser.Columns.Add("cantidad", GetType(Double))
        dtenlaces_loteser.Columns.Add("signo_kardex", GetType(Integer))
        dtenlaces_loteser.Columns.Add("estado", GetType(Integer))
        dtenlaces_loteser.Columns.Add("ingreso_kardex", GetType(Double))
        dtenlaces_loteser.Columns.Add("salida_kardex", GetType(Double))


        If wes_kardex = 1 And wsigno_kardex <> 0 And wtipo_Directo = "INV" Then

            Dim ws_id_prod_mae As Integer
            Dim ws_id_pres_base As Integer
            Dim ws_id_comp_det As Integer

            ' Recorrer las filas del DataGridView y acumular los resultados en el DataTable dtAcumulado
            For Each fila As DataGridViewRow In GridProductos.Rows
                ' Supongamos que el valor de la columna "cadenaDatos" está en la primera celda de cada fila
                ws_id_prod_mae = Val(fila.Cells("id_prod_mae").Value)
                ws_id_pres_base = Val(fila.Cells("id_pres_base").Value)
                ws_id_comp_det = Val(fila.Cells("id_comp_det").Value)


                If ws_id_prod_mae = 0 Then Continue For
                If Val(fila.Cells("es_control_lote").Value) = 0 Then Continue For

                Dim cadenaDatos As String = fila.Cells("cadenalotes").Value
                If cadenaDatos = Nothing Then
                    SMS_Barra("PRODUCTO : " & fila.Cells("descrip").Value & " Requiere Definir sus Lotes", 3)
                    Exit Sub
                End If
                If cadenaDatos.Length() < 10 Then
                    SMS_Barra("PRODUCTO : " & fila.Cells("descrip").Value & " Requiere Definir sus Lotes", 3)
                    Exit Sub
                End If

                ' Obtener el DataTable desde la cadena de datos
                Dim dtResultado As DataTable = ObtenerDataTableDesdeCadena(cadenaDatos, ws_id_prod_mae, ws_id_pres_base, wsigno_kardex, ws_id_comp_det, wid_oper_maestro)
                '                MsgBox(dtResultado.Rows.Count)
                ' Si el DataTable acumulado está vacío, copiar la estructura del DataTable resultado
                If dtenlaces_loteser.Rows.Count = 0 Then
                    dtenlaces_loteser = dtResultado.Clone()
                End If
                ' Agregar todas las filas del DataTable resultado al DataTable acumulado
                dtenlaces_loteser.Merge(dtResultado)
            Next

            'MsgBox(dtenlaces_loteser.Rows.Count)
            'Stop

        End If

        '        Stop

        Dim dt_cuentasn As New DataTable()
        dt_cuentasn.Columns.Add("id_negocio", GetType(Integer))
        dt_cuentasn.Columns.Add("id_oper_maestro", GetType(Integer))
        dt_cuentasn.Columns.Add("id_comp_cab", GetType(Integer))
        dt_cuentasn.Columns.Add("id_carterasn_cab", GetType(Integer))
        dt_cuentasn.Columns.Add("id_carterasn_det", GetType(Integer))
        dt_cuentasn.Columns.Add("nro_cuota", GetType(Integer))
        dt_cuentasn.Columns.Add("fecha_vcto", GetType(DateTime))
        dt_cuentasn.Columns.Add("fecha_vcto_orig", GetType(DateTime))
        dt_cuentasn.Columns.Add("ref", GetType(String))
        dt_cuentasn.Columns.Add("total", GetType(Double))
        dt_cuentasn.Columns.Add("estado", GetType(Integer))
        dt_cuentasn.Columns.Add("id_tb_tipdoc", GetType(Integer))
        dt_cuentasn.Columns.Add("serie_doc", GetType(String))
        dt_cuentasn.Columns.Add("numero_doc", GetType(String))

        Dim wcsn_id_carterasn_det As Integer
        Dim wcsn_nro_cuota As Integer
        Dim wcsn_fecha_vcto As DateTime
        Dim wcsn_fecha_vcto_orig As DateTime
        Dim wcsn_ref As String
        Dim wcsn_total As Double
        Dim wcsn_estado As Integer
        Dim wcsn_id_tb_tipdoc As Integer
        Dim wcsn_serie_doc As String
        Dim wcsn_numero_doc As String

        Dim wcsn_id_carterasn_cab As Integer


        If wes_cuentasn <> 0 Then
            wcsn_id_carterasn_cab = 1
            wnivel_cuentasn = 4
            wcsn_id_carterasn_det = 1
            wcsn_nro_cuota = 1
            wcsn_fecha_vcto = wfecha_emis
            wcsn_fecha_vcto_orig = wfecha_emis
            wcsn_ref = ""
            wcsn_total = wtotal
            wcsn_estado = 1
            wcsn_id_tb_tipdoc = 0
            wcsn_serie_doc = ""
            wcsn_numero_doc = ""

            dt_cuentasn.Rows.Add(wid_negocio, wid_oper_maestro, wid_comp_cab, wcsn_id_carterasn_cab, wcsn_id_carterasn_det, wcsn_nro_cuota, wcsn_fecha_vcto,
                               wcsn_fecha_vcto_orig, wcsn_ref, wcsn_total, wcsn_estado, wcsn_id_tb_tipdoc, wcsn_serie_doc, wcsn_numero_doc)
        End If



        Dim dt_cuentasn_enlace As New DataTable()
        dt_cuentasn_enlace.Columns.Add("id_negocio", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("id_carterasn_enlaces", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("numsec", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("id_oper_maestro", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("id_comp_cab", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("id_carterasn_cab", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("id_carterasn_det", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("total", GetType(Double))
        dt_cuentasn_enlace.Columns.Add("signo_sn", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("fecha", GetType(DateTime))
        dt_cuentasn_enlace.Columns.Add("id_cobrador", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("id_oper_maestro_base", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("id_comp_cab_base", GetType(Integer))
        dt_cuentasn_enlace.Columns.Add("estado", GetType(Integer))


        Dim wcsnen_id_carterasn_enlaces As Integer = 0
        Dim wcsnen_numsec As Integer = 0
        Dim wcsnen_id_oper_maestro As Integer = 0
        Dim wcsnen_id_comp_cab As Integer = 0
        Dim wcsnen_id_carterasn_cab As Integer = 0
        Dim wcsnen_id_carterasn_det As Integer = 0
        Dim wcsnen_signo_sn As Integer = 0
        Dim wcsnen_fecha As DateTime = lk_fecha_dia
        Dim wcsnen_id_cobrador As Integer = 0
        Dim wcsnen_id_oper_maestro_base As Integer = 0
        Dim wcsnen_id_comp_cab_base As Integer = 0
        Dim wcsnen_estado As Integer = 0
        Dim wcsnen_total As Double = 0
        Dim wes_liquidacion As Integer = 0

        If wsigno_sn = 2 Then
            wes_liquidacion = 1
        End If


        If wsigno_sn <> 0 And wsigno_entidad <> 0 And wes_liquidacion = 0 Then

            If wtipo_Directo = "FNZ" Then
                wid_negocio = lk_NegocioActivo.id_Negocio
                wcsnen_id_carterasn_enlaces = 1
                wcsnen_numsec = 1

                wcsnen_id_oper_maestro = wid_oper_maestro_desde
                wcsnen_id_comp_cab = wid_comp_cab_base_desde

                wcsnen_id_carterasn_cab = wreg_sec_carteracab
                wcsnen_id_carterasn_det = wreg_sec_carteradet
                wcsnen_total = wtotal
                wcsnen_signo_sn = wsigno_sn
                wcsnen_fecha = lk_fecha_dia
                wcsnen_id_cobrador = 1
                wcsnen_id_oper_maestro_base = 1
                wcsnen_id_comp_cab_base = 1
                wcsnen_estado = 1
                dt_cuentasn_enlace.Rows.Add(wid_negocio, wcsnen_id_carterasn_enlaces, wcsnen_numsec, wcsnen_id_oper_maestro, wcsnen_id_comp_cab, wcsnen_id_carterasn_cab, wcsnen_id_carterasn_det, wcsnen_total, wcsnen_signo_sn, wcsnen_fecha, wcsnen_id_cobrador, wcsnen_id_oper_maestro_base, wcsnen_id_comp_cab_base, wcsnen_estado)

            Else

                For i = 0 To dg_cuentasn.Rows.Count - 1
                    If Val(dg_cuentasn.Rows(i).Cells("id_oper_maestro").Value) = 0 Then Continue For

                    wid_negocio = lk_NegocioActivo.id_Negocio
                    wcsnen_id_carterasn_enlaces = 1
                    wcsnen_numsec = i + 1
                    wcsnen_id_oper_maestro = dg_cuentasn.Rows(i).Cells("id_oper_maestro").Value
                    wcsnen_id_comp_cab = dg_cuentasn.Rows(i).Cells("id_comp_cab").Value

                    wcsnen_id_carterasn_cab = dg_cuentasn.Rows(i).Cells("id_carterasn_cab").Value
                    wcsnen_id_carterasn_det = dg_cuentasn.Rows(i).Cells("id_carterasn_det").Value
                    wcsnen_total = dg_cuentasn.Rows(i).Cells("aplicar").Value
                    wcsnen_signo_sn = wsigno_sn
                    wcsnen_fecha = lk_fecha_dia
                    wcsnen_id_cobrador = 1
                    wcsnen_id_oper_maestro_base = 1
                    wcsnen_id_comp_cab_base = 1
                    wcsnen_estado = 1
                    dt_cuentasn_enlace.Rows.Add(wid_negocio, wcsnen_id_carterasn_enlaces, wcsnen_numsec, wcsnen_id_oper_maestro, wcsnen_id_comp_cab, wcsnen_id_carterasn_cab, wcsnen_id_carterasn_det, wcsnen_total, wcsnen_signo_sn, wcsnen_fecha, wcsnen_id_cobrador, wcsnen_id_oper_maestro_base, wcsnen_id_comp_cab_base, wcsnen_estado)
                Next i
            End If
        End If


        If wes_liquidacion = 1 Then
            For i = 0 To dg_cuentasn.Rows.Count - 1
                If Val(dg_cuentasn.Rows(i).Cells("id_oper_maestro").Value) = 0 Then Continue For

                wid_negocio = lk_NegocioActivo.id_Negocio
                wcsnen_id_carterasn_enlaces = 1
                wcsnen_numsec = i + 1
                wcsnen_id_oper_maestro = dg_cuentasn.Rows(i).Cells("id_oper_maestro").Value
                wcsnen_id_comp_cab = dg_cuentasn.Rows(i).Cells("id_comp_cab").Value
                wcsnen_id_carterasn_cab = dg_cuentasn.Rows(i).Cells("id_carterasn_cab").Value
                wcsnen_id_carterasn_det = dg_cuentasn.Rows(i).Cells("id_carterasn_det").Value
                wcsnen_total = dg_cuentasn.Rows(i).Cells("aplicar").Value
                wcsnen_signo_sn = dg_cuentasn.Rows(i).Cells("signo_sn").Value
                wcsnen_fecha = lk_fecha_dia
                wcsnen_id_cobrador = 1
                wcsnen_id_oper_maestro_base = 1
                wcsnen_id_comp_cab_base = 1
                wcsnen_estado = 1
                dt_cuentasn_enlace.Rows.Add(wid_negocio, wcsnen_id_carterasn_enlaces, wcsnen_numsec, wcsnen_id_oper_maestro, wcsnen_id_comp_cab, wcsnen_id_carterasn_cab, wcsnen_id_carterasn_det, wcsnen_total, wcsnen_signo_sn, wcsnen_fecha, wcsnen_id_cobrador, wcsnen_id_oper_maestro_base, wcsnen_id_comp_cab_base, wcsnen_estado)
            Next i
        End If

        Dim dt_finanzas_enlace As New DataTable()
        dt_finanzas_enlace.Columns.Add("id_negocio", GetType(Integer))
        dt_finanzas_enlace.Columns.Add("numsec", GetType(Integer))
        dt_finanzas_enlace.Columns.Add("id_moneda", GetType(Integer))
        dt_finanzas_enlace.Columns.Add("id_tb_formas_fn", GetType(Integer))
        dt_finanzas_enlace.Columns.Add("id_fn_maestro", GetType(Integer))
        dt_finanzas_enlace.Columns.Add("fecha_fn", GetType(DateTime))
        dt_finanzas_enlace.Columns.Add("nrodoc", GetType(String))
        dt_finanzas_enlace.Columns.Add("ref", GetType(String))
        dt_finanzas_enlace.Columns.Add("total", GetType(Double))
        dt_finanzas_enlace.Columns.Add("signo_fn", GetType(Integer))
        dt_finanzas_enlace.Columns.Add("id_controlcaja_det", GetType(Integer))

        If wsigno_entidad <> 0 Then
            If dt_DatosFinanzas_oper Is Nothing Then
                SMS_Barra("Operacion sin Datos de Finanzas , debe ingresar la información", 2)
                Exit Sub
            End If
            'MsgBox(dt_DatosFinanzas_oper.Rows(0).Item("total"))
            dt_finanzas_enlace = dt_DatosFinanzas_oper.Copy()

            If wnivel_comp = 4 Then
                westado = 8
            End If
        End If

        Dim dt_cuentasn_nc_enlace As New DataTable()
        dt_cuentasn_nc_enlace.Columns.Add("id_negocio", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("id_carterasn_enlaces", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("numsec", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("id_oper_maestro", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("id_comp_cab", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("id_carterasn_cab", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("id_carterasn_det", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("total", GetType(Double))
        dt_cuentasn_nc_enlace.Columns.Add("signo_sn", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("fecha", GetType(DateTime))
        dt_cuentasn_nc_enlace.Columns.Add("id_cobrador", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("id_oper_maestro_base", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("id_comp_cab_base", GetType(Integer))
        dt_cuentasn_nc_enlace.Columns.Add("estado", GetType(Integer))

        If wes_aplica_nc = 1 And wes_finanzas = 1 Then
            dt_cuentasn_nc_enlace = dt_DatosFinanzas_NC.Copy()
            'MsgBox(dt_cuentasn_nc_enlace.Rows.Count)

        End If



        'Stop
        'Exit Sub
        ' Dim connectionString As String = "Data Source=PCACOSME;Initial Catalog=r23_negocio_cuenta;User ID=sa;Password=159357852456"

        'Using lk_connection_cuenta As New SqlConnection(connectionString)
        '    lk_connection_cuenta.Open()

        '    ' Crea un objeto SqlCommand para llamar al SP
        '    Dim cmd As New SqlCommand("Oper_InsertarComp", lk_connection_cuenta)
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.Parameters.Clear()
        'Exit Sub
        Using cmd As New SqlCommand("Oper_InsertarComp", lk_connection_cuenta)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Clear()

            ' Agrega los parámetros de entrada
            cmd.Parameters.AddWithValue("@id_negocio", wid_negocio)
            cmd.Parameters.AddWithValue("@id_oper_maestro", wid_oper_maestro)
            cmd.Parameters.AddWithValue("@id_comp_cab", wid_comp_cab)
            cmd.Parameters.AddWithValue("@id_local", wid_local)
            cmd.Parameters.AddWithValue("@nivel_comp", wnivel_comp)
            cmd.Parameters.AddWithValue("@fecha", wfecha)
            cmd.Parameters.AddWithValue("@fecha_emis", wfecha_emis)
            cmd.Parameters.AddWithValue("@id_doc_oper", wid_doc_oper)
            cmd.Parameters.AddWithValue("@serie_oper", wserie_oper)
            cmd.Parameters.AddWithValue("@numero_oper", wnumero_oper)
            cmd.Parameters.AddWithValue("@id_comprobante", wid_comprobante)
            cmd.Parameters.AddWithValue("@sere_comp", wsere_comp)
            cmd.Parameters.AddWithValue("@numero_comp", wnumero_comp)
            cmd.Parameters.AddWithValue("@id_sn_master", wid_sn_master)
            cmd.Parameters.AddWithValue("@id_vendedor", wid_vendedor)
            cmd.Parameters.AddWithValue("@id_entidad", wid_entidad)
            cmd.Parameters.AddWithValue("@id_contacto", wid_contacto)
            cmd.Parameters.AddWithValue("@id_dir_entrega", wid_dir_entrega)
            cmd.Parameters.AddWithValue("@id_dir_cobro", wid_dir_cobro)
            cmd.Parameters.AddWithValue("@id_condicion", wid_condicion)
            cmd.Parameters.AddWithValue("@fecha_vcto", wfecha_vcto)
            cmd.Parameters.AddWithValue("@estado", westado)
            cmd.Parameters.AddWithValue("@id_moneda", wid_moneda)
            cmd.Parameters.AddWithValue("@id_prioridad", wid_prioridad)
            cmd.Parameters.AddWithValue("@fecha_ate", wfecha_ate)
            cmd.Parameters.AddWithValue("@ref", wref)
            cmd.Parameters.AddWithValue("@valor_gravado", wvalor_gravado)
            cmd.Parameters.AddWithValue("@valor_bonificado", wvalor_bonificado)
            cmd.Parameters.AddWithValue("@valor_nogravado", wvalor_nogravado)
            cmd.Parameters.AddWithValue("@valor_exonerado", wvalor_exonerado)
            cmd.Parameters.AddWithValue("@impto", wimpto)
            cmd.Parameters.AddWithValue("@total", wtotal)
            cmd.Parameters.AddWithValue("@id_usuario", wid_usuario)
            cmd.Parameters.AddWithValue("@es_kardex", wes_kardex)
            cmd.Parameters.AddWithValue("@es_servicio", wes_servicio)
            cmd.Parameters.AddWithValue("@signo_entidad", wsigno_entidad)
            cmd.Parameters.AddWithValue("@signo_sn", wsigno_sn)
            cmd.Parameters.AddWithValue("@es_comp_enlace", wes_comp_enlace)
            cmd.Parameters.AddWithValue("@es_manual_comp", wes_manual_comp)
            cmd.Parameters.AddWithValue("@es_cuentasn", wes_cuentasn)
            cmd.Parameters.AddWithValue("@nivel_cuentasn", wnivel_cuentasn)
            cmd.Parameters.AddWithValue("@tipo_transf_kardex", wtipo_transf_kardex)
            cmd.Parameters.AddWithValue("@modo_calculo", wmodo_calculo)
            cmd.Parameters.AddWithValue("@es_canje_comp", wes_canje_comp)
            cmd.Parameters.AddWithValue("@es_canje_le", wes_canje_le)
            cmd.Parameters.AddWithValue("@es_aplica_nc", wes_aplica_nc)
            cmd.Parameters.AddWithValue("@porc_impto", wporc_impto)
            cmd.Parameters.AddWithValue("@es_limite_credito", wes_limite_credito)
            cmd.Parameters.AddWithValue("@dias_credito", wdias_credito)
            cmd.Parameters.AddWithValue("@signo_lc", wsigno_lc)
            cmd.Parameters.AddWithValue("@diasvcto", wdiasvcto)
            cmd.Parameters.AddWithValue("@ref_codigo_comp", wref_codigo_comp)
            cmd.Parameters.AddWithValue("@ref_serie_comp", wref_serie_comp)
            cmd.Parameters.AddWithValue("@ref_numero_comp", wref_numero_comp)
            cmd.Parameters.AddWithValue("@ref_fecha_comp", wref_fecha_comp)
            cmd.Parameters.AddWithValue("@ref_codigo_motivo", wref_codigo_motivo)
            cmd.Parameters.AddWithValue("@ref_descripcion_motivo", wref_descripcion_motivo)
            ' Agrega el parámetro de tabla temporal de detalle
            Dim detalleParam As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalDetalle", detalle)
            Dim enlacesParam As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalEnlaces", enlace_comp)
            Dim cuentasnParam As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalCarterasn", dt_cuentasn)
            Dim cuentasn_enla_Param As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalCarterasn_enlace", dt_cuentasn_enlace)
            Dim cuentasn_nc_enla_Param As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalCarterasn_nc_enlace", dt_cuentasn_nc_enlace)
            Dim finanzas_enla_Param As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalfinanzas_enlaces", dt_finanzas_enlace)
            Dim enlaces_loteser_Param As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalm_enlaces_loteser", dtenlaces_loteser)

            'Dim resultadoParam As SqlParameter = cmd.Parameters.Add("@Resultado", SqlDbType.VarChar, 50)
            'resultadoParam.Direction = ParameterDirection.Output

            'Dim resultado As String = String.Empty
            cmd.Parameters.Add("@Resultado", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@reg_sec_numint", SqlDbType.Int, 10).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@reg_sec_numcomp", SqlDbType.Int, 10).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@reg_sec_carteracab", SqlDbType.Int, 10).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@reg_sec_carteradet", SqlDbType.Int, 10).Direction = ParameterDirection.Output





            detalleParam.SqlDbType = SqlDbType.Structured
            'detalleParam.TypeName = "dbo.Tipo_add_m_comprobantes_det"




            ' Ejecuta el comando Operacion Activa
            Try
                cmd.ExecuteNonQuery()
                Wresultado = DirectCast(cmd.Parameters("@Resultado").Value, String)
                wreg_sec_numint = DirectCast(cmd.Parameters("@reg_sec_numint").Value, Integer)
                wreg_sec_numcomp = DirectCast(cmd.Parameters("@reg_sec_numcomp").Value, Integer)
                wreg_sec_carteracab = DirectCast(cmd.Parameters("@reg_sec_carteracab").Value, Integer)
                wreg_sec_carteradet = DirectCast(cmd.Parameters("@reg_sec_carteradet").Value, Integer)



            Catch ex As Exception
                werror = ex.Message
                ' manejo de excepciones  ex.Message 
            End Try

        End Using
        If werror <> String.Empty Then ' ERROR DE SQL
            MsgBox(werror)
        End If
        If Wresultado <> String.Empty Then
            'MsgBox("REGISTRO GRABADO:" & Wresultado)
            SMS_Barra("REGISTRO GRABADO CON EXITO : " & Wresultado, 1)
            ' Datos despuestde ede la grabacion Muestra COmprobantes Grabados
            TxtComp_Numero.Text = Format(wreg_sec_numcomp, "00000000")
            TxtNumDocOper.Text = Format(wreg_sec_numint, "00000000")
        End If


    End Sub


    Private Function Graba_Validacion_Box() As Boolean
        Graba_Validacion_Box = True

        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        If Obtener_id_oper_maestro.Count = 0 Then
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            Graba_Validacion_Box = False
            Exit Function
        End If

        Dim wid_oper_maestro As Integer = Obtener_id_oper_maestro(0)("id_oper_maestro")
        Dim wes_cuentasn As Integer = Obtener_id_oper_maestro(0)("es_cuentasn") ' afecta a registro de caunta correinte del socio de negocio
        'Dim signo_sn As Integer = Obtener_id_oper_maestro(0)("signo_cuentasn")  ' Indica si es debe o haber + / -  0 aplica a registro de enlace
        'wsigno_entidad = Obtener_id_oper_maestro(0)("signo_finanzas")
        'wes_kardex = Obtener_id_oper_maestro(0)("es_inventario")
        'wsigno_kardex = Obtener_id_oper_maestro(0)("signo_inventario")
        'westado_oper_def = Obtener_id_oper_maestro(0)("estado_oper_def")
        'wtipo_transf_kardex = Obtener_id_oper_maestro(0)("tipo_transf_kardex")
        'wes_costeo = Obtener_id_oper_maestro(0)("es_costeo")
        'wes_cospro = Obtener_id_oper_maestro(0)("es_cospro")
        'wdirecto_id_tb_oper = Obtener_id_oper_maestro(0)("directo_id_tb_oper")
        'wdirecto_id_oper_maestro = Obtener_id_oper_maestro(0)("directo_id_oper_maestro")
        'wfn_directo_id_tb_oper = Obtener_id_oper_maestro(0)("fn_directo_id_tb_oper")
        'wfn_directo_id_oper_maestro = Obtener_id_oper_maestro(0)("fn_directo_id_oper_maestro")
        'wes_canje_comp = Obtener_id_oper_maestro(0)("es_canje_comp")
        'wes_canje_le = Obtener_id_oper_maestro(0)("es_canje_le")
        Dim wes_finanzas As Integer = Obtener_id_oper_maestro(0)("es_finanzas")
        If Val(CmdOperacion.Tag) = 6 And BoxEntidadF.Visible = False Then ' VENTAS COMENRCALES
            If lbl_estado_lc.Tag = 0 Then
                SMS_Barra("Socio de Negocio NO Tiene Acceso a Creditos .", 2)
                GoTo Go_Nopasa
            End If
            If Val(txt_diaslc.Text) = 0 Then
                SMS_Barra("Socio de Negocio, Debe Indicar por lo menos 1 dia de Credito .", 2)
                GoTo Go_Nopasa
            End If
        End If


        If BoxTienda.Visible Then
            If Val(CmdLocal.Tag) = 0 Then
                SMS_Barra("Debe Indicar Codigo de Tienda.", 2)
                GoTo Go_Nopasa
            End If
        End If
        If BoxFechas.Visible Then

        End If
        If BoxSocioNego.Visible Then
            If Val(info_SN.Tag) = 0 Then
                SMS_Barra("Debe Ingresar Socio de Negocio para la Operación.", 2)
                GoTo Go_Nopasa
            End If
            If CmdSerireComp.Visible And CmdSerireComp.AccessibleName = "1" And Strings.Left(CmdSerireComp.Text, 1) = "B" Then
                If info_SN.AccessibleName = 4 Then  ' id tipo de documento osea Tipo Boleta
                    SMS_Barra("Socio de Negocio, con RUC , no procede el registro de Boelta .", 2)
                    GoTo Go_Nopasa

                End If
            End If
            If CmdSerireComp.Visible And CmdSerireComp.AccessibleName = "1" And Strings.Left(CmdSerireComp.Text, 1) = "F" Then
                If info_SN.AccessibleName <> 4 Then  ' id tipo de documento osea Tipo Boleta
                    SMS_Barra("Socio de Negocio Debe Tener Tipo Docum. RUC , no procede el registro de Factura.", 2)
                    GoTo Go_Nopasa

                End If
            End If
        End If
        If BoxComprobantes.Visible Then
            If Val(CmdComprob.Tag) = 0 Then
                SMS_Barra("Debe indicar Tipo de Comprobante..", 2)
                GoTo Go_Nopasa
            End If
            If CmdSerireComp.Visible = False Then
                If Val(TxtComp_Numero.Text) = 0 Then
                    SMS_Barra("Debe indicar Numero de Comprobante..", 2)
                    GoTo Go_Nopasa
                End If
                If Trim(TxtSerireComp.Text) = "" Then
                    SMS_Barra("Debe indicar Serire para el Comprobante..", 2)
                    GoTo Go_Nopasa
                End If
            End If
        End If
        If BoxAlmTransf.Visible Then
            If Val(CmdAlmTransf.Tag) = 0 Then
                SMS_Barra("Debe indicar Almacen de destino para la Trasnferencia..", 2)
                GoTo Go_Nopasa
            End If
        End If

        If BoxLineaCredito.Visible Then
            If Val(lblEstado_lc.Tag) = 1 Then
                If Val(lc_monto.Text) = 0 And Val(lc_dias.Text) = 0 Then
                    SMS_Barra("Si ACTIVAS la linea de Credito debe Indicar el monto a la operacion.", 2)
                    GoTo Go_Nopasa
                End If

                If Val(lc_dias.Text) = 0 Then
                    SMS_Barra("Si ACTIVAS la linea de Credito debe Indicar los dias de credito.", 2)

                    GoTo Go_Nopasa
                End If

            End If
        End If



        If BoxMoneda.Visible Then

        End If
        If BoxCondicion.Visible Then

        End If
        If BoxAtencion.Visible Then

        End If
        If BoxEntidadF.Visible Then

        End If
        If BoxDocIntOper.Visible Then

        End If
        If BoxGuiaAuto.Visible Then

        End If
        If BoxEstado.Visible Then

        End If

        Exit Function

Go_Nopasa:
        Graba_Validacion_Box = False
    End Function
    Private Sub ActualizarColores()
        'Dim Oscuro_primario1 As String = "#353641"
        Dim FondoPanelyForm As String = "#353641"
        Dim FondoBotones As String = "#444654"
        Dim FondoCajaTextoyLabel As String = "#444654"

        Dim ColorTextoyEtiq As String = "#FFFFFF"
        Dim gridletra As String = "#FFDE77"
        Dim wprueba As String = "#19B4B8"
        Dim Oscuro_secundario2 As String = "#353641"
        Dim ColorIconoBotones As String
        Dim ColorTexoBoton As String
        If lk_modoOscuro Then
            FondoPanelyForm = "#353641"
            FondoCajaTextoyLabel = "#444654"
            ColorTextoyEtiq = "#D4D4D8"
            gridletra = "#FFFFFF"
            FondoBotones = "#353641"
            ColorIconoBotones = "#FFFFFF"
            ColorTexoBoton = "#FFFFFF"
        Else
            FondoPanelyForm = "#F0F2F5"
            FondoCajaTextoyLabel = "#FFFFFF"
            ColorTextoyEtiq = "#000000"
            gridletra = "#000000"
            FondoBotones = "#FFFFFF"
            ColorIconoBotones = "#2F476D"
            ColorTexoBoton = "#2F476D"
        End If


        Me.BackColor = ColorTranslator.FromHtml(FondoPanelyForm)
        Me.PanelCentral.BackColor = ColorTranslator.FromHtml(FondoPanelyForm)

        dg_listaoper.BackgroundColor = ColorTranslator.FromHtml(FondoPanelyForm)
        dg_listaoper.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(FondoCajaTextoyLabel) ' Cambiar el color de fondo de las celdas
        dg_listaoper.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(gridletra)

        'Me.ForeColor = Color.White
        For Each panel As Panel In Me.Controls.OfType(Of Panel)()
            If panel.Name = "PanelSup" Then Continue For
            If panel.Name = "PanelListarOper" Then Continue For

            panel.BackColor = ColorTranslator.FromHtml(FondoPanelyForm)

        Next
        For Each crtZonaDEt As Control In BoxGridPROD1.Controls
            ' Código a ejecutar para cada control dentro de Panel1
            If TypeOf crtZonaDEt Is DataGridView Then
                Dim dgv As DataGridView = CType(crtZonaDEt, DataGridView)
                dgv.BackgroundColor = ColorTranslator.FromHtml(FondoPanelyForm)
                dgv.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(FondoCajaTextoyLabel) ' Cambiar el color de fondo de las celdas
                dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(gridletra)

                ' dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(Oscuro_primario1)
                ' dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(wblanco)
                ' dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray ' Cambiar el color de fondo de todas las cabeceras
                ' dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White ' Cambiar el color del texto de todas las cabeceras

            End If
        Next

        For Each pnl As Panel In Me.Controls.OfType(Of Panel)()
            If pnl.Name = "PanelSup" Then Continue For
            If pnl.Name = "PanelListarOper" Then Continue For
            ' Recorre todos los iconButton dentro de cada panel
            For Each iconBtn As IconButton In pnl.Controls.OfType(Of IconButton)()
                ' Cambia el color de fondo del iconButton
                iconBtn.BackColor = ColorTranslator.FromHtml(FondoBotones)
                iconBtn.ForeColor = ColorTranslator.FromHtml(ColorTexoBoton)
                iconBtn.IconColor = ColorTranslator.FromHtml(ColorIconoBotones)

            Next
            For Each label As Label In pnl.Controls.OfType(Of Label)()
                ' Cambia el color de fondo del iconButton
                label.BackColor = ColorTranslator.FromHtml(FondoCajaTextoyLabel)
                label.ForeColor = ColorTranslator.FromHtml(ColorTextoyEtiq)
            Next
            For Each pnlbox As Panel In pnl.Controls.OfType(Of Panel)()
                If pnlbox.Name = "PanelSup" Then Continue For
                If pnlbox.Name = "PanelListarOper" Then Continue For
                For Each iconBtn_box As IconButton In pnlbox.Controls.OfType(Of IconButton)()
                    ' Cambia el color de fondo del iconButton
                    iconBtn_box.BackColor = ColorTranslator.FromHtml(FondoBotones)
                    iconBtn_box.ForeColor = ColorTranslator.FromHtml(ColorTexoBoton)
                    iconBtn_box.IconColor = ColorTranslator.FromHtml(ColorIconoBotones)
                Next
                For Each Label_box As Label In pnlbox.Controls.OfType(Of Label)()
                    ' Cambia el color de fondo del iconButton
                    Label_box.BackColor = ColorTranslator.FromHtml(FondoPanelyForm)
                    Label_box.ForeColor = ColorTranslator.FromHtml(ColorTextoyEtiq)
                Next
                For Each Texto_box As TextBox In pnlbox.Controls.OfType(Of TextBox)()
                    ' Cambia el color de fondo del iconButton
                    Texto_box.BackColor = ColorTranslator.FromHtml(FondoCajaTextoyLabel)
                    Texto_box.ForeColor = ColorTranslator.FromHtml(ColorTextoyEtiq)
                Next
                For Each RichTexto_box As RichTextBox In pnlbox.Controls.OfType(Of RichTextBox)()
                    ' Cambia el color de fondo del iconButton
                    RichTexto_box.BackColor = ColorTranslator.FromHtml(FondoCajaTextoyLabel)
                    RichTexto_box.ForeColor = ColorTranslator.FromHtml(ColorTextoyEtiq)
                Next
                For Each RadioB_box As RadioButton In pnlbox.Controls.OfType(Of RadioButton)()
                    ' Cambia el color de fondo del iconButton
                    RadioB_box.BackColor = ColorTranslator.FromHtml(FondoPanelyForm)
                    RadioB_box.ForeColor = ColorTranslator.FromHtml(ColorTextoyEtiq)
                Next

                pnlbox.BackColor = ColorTranslator.FromHtml(FondoPanelyForm)
            Next


        Next

        ' PanelSup.BackColor = ColorTranslator.FromHtml(strColorLogin)


    End Sub


    Private Sub TxtFechas_Proc_ValueChanged(sender As Object, e As EventArgs) Handles TxtFechas_Proc.ValueChanged

    End Sub

    Private Sub TxtFechas_Proc_Paint(sender As Object, e As PaintEventArgs) Handles TxtFechas_Proc.Paint
        Dim backBrush As New SolidBrush(Color.Red)
        e.Graphics.FillRectangle(backBrush, Me.ClientRectangle)
    End Sub

    Private Sub MyDateTimePicker1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CmdCancelarOper_Click(sender As Object, e As EventArgs) Handles CmdCancelarOper.Click

        'Iniciar_Oper()
        'Mostraroperacion(TxtOperacion.Text)
        CancelaOper("")
        SMS_Barra("Cancelando Operacion...", 3)

        If CmdOperacion.AccessibleDescription <> "" Then 'Primera Ubiacion 
            SaltoBox(CmdOperacion.AccessibleDescription)
        End If ' 



    End Sub
    Private Sub CancelaOper(wviene As String)
        If BoxSocioNego.Visible Then
            TxtSocio_BoxSN.Text = ""
            TxtSocio_BoxSN.Tag = ""
            TxtSocio_BoxSN.AccessibleDescription = ""
            TxtSocio_BoxSN.AccessibleName = ""

            info_SN.Text = ""
            info_SN.Tag = ""
            info_SN.AccessibleDescription = ""
            info_SN.AccessibleName = ""
        End If
        If BoxLineaCredito.Visible Then
            CmdOpcionesLC.Tag = "1"
            CmdOpcionesLC.Text = "AUMENTAR"
            lc_actual.Text = ""
            lc_dias.Text = ""
            lc_disponible.Text = ""
            lc_usado.Text = ""

        End If
        lblEti_lc.Text = ""
        lblEti_lc.Tag = 0
        txt_diaslc.Text = ""
        lbl_estado_lc.Text = ""
        If BoxRefComp.Visible Then
            tref_codigo.Text = ""
            tref_serie.Text = ""
            tref_numero.Text = ""
            tref_fecha.Text = ""
        End If


        If BoxFechas.Visible Then
            TxtFechas_Emis.Value = TxtFechas_Proc.Value
        End If

        If BoxCondicion.Visible Then
            TxtCondi_FecVcto.Value = TxtFechas_Proc.Value
        End If
        If BoxMoneda.Visible Then
            'CmdMonedaComp.
            'TxtFechas_Emis.Value = TxtFechas_Proc.Value
        End If
        If BoxGridPROD1.Visible Then
            GridProductos.Rows.Clear()
            GridProductos_PrimeraFila()
        End If
        If BoxEstadoSN.Visible Then
            dg_cuentasn.Rows.Clear()
            dg_cuentasn_PrimeraFila()
        End If
        If BoxAlmTransf.Visible Then
            CmdAlmTransf.Tag = ""
            CmdAlmTransf.Text = ""
            TxtAlmTransf.Tag = ""
            TxtAlmTransf.Text = ""
        End If



        If wviene = "GRABAR" Then
        Else
            If CmdSerireComp.Visible Then TxtComp_Numero.Text = "********"
            TxtNumDocOper.Text = "********"
        End If
        If BoxComprobantes.Visible Then
            If CmdSerireComp.Visible = True Then
                'CmdSerireComp.Text = ""
                'CmdSerireComp.Tag = 0
                'TxtSerireComp.Text = ""
                'TxtSerireComp.Tag = 0
                TxtComp_Numero.Text = "********"
            Else
                CmdSerireComp.Text = ""
                CmdSerireComp.Tag = 0
                TxtSerireComp.Text = ""
                TxtSerireComp.Tag = 0
                TxtComp_Numero.Text = ""
            End If
        End If
        MuestraEstadoComp(0, 0) ' CREANDO

        Limpieza_variables_Relacionados()


        TxtEstadoComp.AccessibleDescription = "" '  inicializa nivel del comprobante origen 
        If GridProductos.Visible Then
            GridProductos.Columns.Item("cantidad_saldo").Visible = False
            GridProductos.Columns.Item("present").ReadOnly = False
            GridProductos.Columns.Item("almacen").ReadOnly = False
            GridProductos.Columns.Item("saldo_pend").Visible = False
        End If
        CmdGrabar.Enabled = True
        CmdAanularOper.Enabled = False
        CmdEnviarA.Enabled = False
        CmdTraerDe.Enabled = True

        CmdActivarEdi.Text = Strings.Space(20)
        CmdActivarEdi.Tag = 0
        CmdActivarEdi.Enabled = False

        link_saldo.Text = ""
        link_saldo.Tag = 0 ' es_carterasn 
        link_saldo.AccessibleName = 0  ' signo_carterasn 
        link_saldo.AccessibleDescription = 0
        CmdTraerDe.Tag = "" 'limpiar
        dt_DatosFinanzas_oper = New DataTable()

        TxtDetallefn.AccessibleDescription = ""
        TxtDetallefn.AccessibleName = ""
        TxtDetallefn.Text = ""


        Bloqueo_Estado_Box(0) ' inicia si bloqeuo



    End Sub
    Private Sub Limpieza_variables_Relacionados()
        ENLACE_TIPO = Nothing
        ENLACE_MUESTRA_id_oper_maestro = 0
        ENLACE_MUESTRA_id_comp_cabe = 0
        ENLACE_ENVIO_OPER_CODIGO = ""
        ENLACE_ENVIO_DATA_COMP = Nothing
        ENLACE_id_oper_maestro = 0
        ENLACE_id_comp_cabe = 0
        dt_DatosEnlace_oper = Nothing
        dt_Enlace_Envio_Oper = Nothing
    End Sub
    Private Sub CmdOscuro_Click(sender As Object, e As EventArgs) Handles CmdOscuro.Click
        lk_modoOscuro = Not lk_modoOscuro
        ActualizarColores()
        If lk_modoOscuro Then
            CmdOscuro.Text = "MODO CLARO"
        Else
            CmdOscuro.Text = "MODO OSCURO"
        End If
    End Sub

    Private Sub GridProductos_ParentChanged(sender As Object, e As EventArgs) Handles GridProductos.ParentChanged

    End Sub

    Private Sub CmdTraerDe_Click(sender As Object, e As EventArgs) Handles CmdTraerDe.Click

        Dim Result As String
        Dim ListaOperTraer() As DataRow = lk_sql_EnlacesOper.Select("base_id_tb_oper  = '" & CmdOperacion.Tag & "' and tipo= 'T'")
        If ListaOperTraer.Length = 0 Then
            Result = MensajesBox.Show("Codigo de Operación No enlazado a Comprobantes Anteriores.",
                                     "Operación.")
            Exit Sub
        End If
        ' CmdTipoOper.Text = ListaOperTraer(0)("descrip_tipooper")
        ' CmdTipoOper.Tag = ListaOperTraer(0)("id_tb_tipooper")

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaOperTraer
            Dim wenlace_id_tb_oper As Integer = CInt(row("enlace_id_tb_oper"))
            Dim detalle As String = CStr(row("enlace_codigo") & " " & row("enlace_descripcion"))
            Dim codigo As String = CStr(row("enlace_codigo"))
            Dim wtipo As String = CStr(row("tipo"))
            Dim wes_inventario As String = CStr(row("enlace_es_inventario"))

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarEnlaceComprobante(wenlace_id_tb_oper, codigo, wtipo, wes_inventario)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdTraerDe, New Point(0, CmdTraerDe.Height))



    End Sub
    Private Sub MostrarEnlaceComprobante(wenlace_id_tb_oper As Integer, codigo As String, wtipo As String, wes_inventario_oper_traer As Integer)

        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        If Obtener_id_oper_maestro.Count = 0 Then
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            Exit Sub
        End If
        Dim ws_directo_id_oper_maestro As Integer = Obtener_id_oper_maestro(0)("directo_id_oper_maestro")
        Dim ws_es_reserva As Integer = Obtener_id_oper_maestro(0)("es_reserva")
        Dim ws_es_canje As Integer = Obtener_id_oper_maestro(0)("es_canje_comp")


        If wes_inventario_oper_traer <> 0 And ws_es_canje <> 0 Then
            Dim Result As String = MensajesBox.Show("No procede , ambas operaciones afectan a Inventario.",
                                    "Lista de Operación.")
            Exit Sub
        End If


        If wes_inventario_oper_traer <> 0 And ws_es_reserva <> 0 Then
            Dim Result As String = MensajesBox.Show("No procede , ambas operaciones afectan a Inventario.",
                                    "Lista de Operación.")
            Exit Sub
        End If

        If wes_inventario_oper_traer <> 0 And ws_directo_id_oper_maestro <> 0 Then
            Dim Result As String = MensajesBox.Show("No procede , ambas operaciones afectan a Inventario.",
                                    "Lista de Operación.")
            Exit Sub
        End If
        If wes_inventario_oper_traer <> 0 And Obtener_id_oper_maestro(0)("es_inventario") <> 0 Then
            Dim Result As String = MensajesBox.Show("No procede , ambas operaciones afectan a Inventario.",
                                    "Lista de Operación.")
            Exit Sub
        End If

        Dim wtipo_transf_kardex As Integer = Obtener_id_oper_maestro(0)("tipo_transf_kardex")

        Dim wes_canje_comp As Integer = Obtener_id_oper_maestro(0)("es_canje_comp")
        Dim wid_almacen_transf As Integer = Val(CmdAlmTransf.Tag)




        Dim frEnlace As New FrmEnlacesComp
        ' frlote.TextoBusca = valorlote
        frEnlace.FORM_id_tb_oper = wenlace_id_tb_oper
        frEnlace.FORM_estado = 1
        frEnlace.FORM_tipo_transf_kardex = wtipo_transf_kardex
        frEnlace.FORM_id_almacen_transf = wid_almacen_transf
        frEnlace.FORM_id_local = Val(CmdLocal.Tag)
        frEnlace.FORM_es_canje_comp = 0
        frEnlace.FORM_es_otros_comp = 0
        frEnlace.FORM_quitar_estado = 0

        If wes_canje_comp = 1 Then
            frEnlace.FORM_es_canje_comp = wes_canje_comp
            frEnlace.FORM_es_otros_comp = 0
            frEnlace.FORM_quitar_estado = 0
        ElseIf wes_canje_comp = 0 Then
            frEnlace.FORM_es_canje_comp = wes_canje_comp
            frEnlace.FORM_es_otros_comp = 1
            frEnlace.FORM_quitar_estado = 3
        End If







        CmdTraerDe.Tag = "" 'limpiar
        If frEnlace.ShowDialog() = DialogResult.OK Then
            Dim dt_DatosAgrupados As New DataTable
            dt_DatosEnlace_oper = frEnlace.FORM_DAtaEnlace
            dt_DatosAgrupados = AgrupayLlena_oper(frEnlace.FORM_DAtaEnlace)
            CmdTraerDe.Tag = "1" ' se Activa Parametro de Traerde
            Muestra_Enlace_Productos(dt_DatosAgrupados, frEnlace.FORM_DAtaEnlace, wtipo_transf_kardex)

            tref_codigo.Text = frEnlace.Enlace_ref_codigo_comp
            tref_serie.Text = frEnlace.Enlace_ref_serie_comp
            tref_numero.Text = frEnlace.Enlace_ref_numero_comp
            tref_fecha.Text = frEnlace.Enlace_ref_fecha_comp
            CmdGrabar.Enabled = True
            CmdGrabar.Select()
            CmdAanularOper.Enabled = False
        Else
            Limpieza_variables_Relacionados()
        End If
    End Sub
    Private Sub Muestra_Enlace_Productos(dt_DatosAgrupados As DataTable, dt_DatosDEtallado As DataTable, wtipo_transf_kardex As Integer)
        Dim comboCell As DataGridViewComboBoxCell
        Dim ws_precio As Double

        MuestraEstadoComp(4, 0) ' "CREACION (TRAER DE.)"

        If Me.GridProductos.Tag = "PROD1" Then
            If dt_DatosAgrupados.Rows.Count = 0 Then Exit Sub


            If dt_DatosDEtallado.Rows.Count <> 0 Then
                TxtEstadoComp.AccessibleDescription = dt_DatosDEtallado(0)("nivel_comp") ' nivel del comprobante origen 
                ' Tienda 
                'CmdLocal.Text = dt_DatosDEtallado.Rows(0).Item("local_nombre")
                'CmdLocal.Tag = dt_DatosDEtallado.Rows(0).Item("id_local")
                'TxtLocal.Text = dt_DatosDEtallado.Rows(0).Item("local_codigo")
                'CmdLocal.AccessibleName = dt_DatosDEtallado.Rows(0).Item("local_codigo")
                ' socio de negocio
                TxtSocio_BoxSN.Text = dt_DatosDEtallado.Rows(0).Item("sn_codigo")
                info_SN.Text = dt_DatosDEtallado.Rows(0).Item("sn_boxsn")
                info_SN.Tag = dt_DatosDEtallado.Rows(0).Item("id_sn_master")
                info_SN.AccessibleName = dt_DatosDEtallado.Rows(0).Item("id_tipodoc")


            End If

            ' Socio de negocio
            Dim wcantidad As Double = 0
            Me.GridProductos.Rows.Clear()
            For i = 0 To dt_DatosAgrupados.Rows.Count - 1
                Me.GridProductos.Rows.Add()
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("descrip").Value = dt_DatosAgrupados.Rows(i).Item("nombre_prod_mae")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("grupo").Value = dt_DatosAgrupados.Rows(i).Item("dt_lab_linea")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("codigo").Value = dt_DatosAgrupados.Rows(i).Item("codigo_prod_mae")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_prod_mae").Value = dt_DatosAgrupados.Rows(i).Item("id_prod_mae")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_prod_mae_codigo").Value = dt_DatosAgrupados.Rows(i).Item("codigo_prod_mae")

                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("es_inventariable").Value = dt_DatosAgrupados.Rows(i).Item("dt_es_inventariable")


                'wcantidad = (Val(dt_DatosAgrupados.Rows(i).Item("cantidad")) / Val(dt_DatosAgrupados.Rows(i).Item("dt_equiv")))

                '                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("cantidad").Value = Val(loc_datos_comp.Rows(i).Item("dt_cantidad")) - Val(loc_datos_comp.Rows(i).Item("cantidad_aplicada"))
                'GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("cantidad").Value = Format(wcantidad, "#,##0")

                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("cantidad").Value = dt_DatosAgrupados.Rows(i).Item("cantidad")

                comboCell = CType(GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("present"), DataGridViewComboBoxCell)
                comboCell.Items.Clear()
                'addrow.Item("equiv") = Row("dt_equiv") ' row("dt_equiv_base")
                ' addrow.Item("descrip_pres") = Row("dt_descrip_pres") 'row("dt_abreviado_pres_base")

                comboCell.Items.Add(dt_DatosAgrupados.Rows(i).Item("descrip_pres"))
                comboCell.Value = dt_DatosAgrupados.Rows(i).Item("descrip_pres")

                'comboCell.Items.Add(dt_DatosAgrupados.Rows(i).Item("dt_abreviado_pres_base"))
                'comboCell.Value = dt_DatosAgrupados.Rows(i).Item("dt_abreviado_pres_base")

                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_pres").Value = dt_DatosAgrupados.Rows(i).Item("id_pres")
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("equiv").Value = dt_DatosAgrupados.Rows(i).Item("equiv")


                'GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_pres").Value = dt_DatosAgrupados.Rows(i).Item("dt_id_pres_base")
                'GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("equiv").Value = dt_DatosAgrupados.Rows(i).Item("dt_equiv_base")



                Dim PrecioPromerio() As DataRow = dt_DatosDEtallado.Select("id_prod_mae = '" & dt_DatosAgrupados.Rows(i).Item("id_prod_mae") & "'")
                ws_precio = 0
                If PrecioPromerio.Length <> 0 Then
                    For j = 0 To PrecioPromerio.Length - 1
                        ws_precio = ws_precio + Val(PrecioPromerio(j)("precio"))
                    Next
                    ws_precio = Format(ws_precio / PrecioPromerio.Length, "0.0000")
                End If

                '.dt_id_almacen = Group.First().Field(Of Integer)("dt_id_almacen"),
                '                .dt_alm_codigo = Group.First().Field(Of String)("dt_alm_codigo"),
                '                .dt_alm_abreviado = Group.First().Field(Of String)("dt_alm_abreviado")

                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("preciobase").Value = ws_precio
                If wtipo_transf_kardex = 2 Then ' es flag indica recepcion de mercaderia 
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("almacen").Value = TxtAlmTransf.Text.ToString.Trim
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_almacen").Value = CmdAlmTransf.Tag
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("alm_abreviado").Value = CmdAlmTransf.Text
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_almacen_trasnf").Value = dt_DatosAgrupados.Rows(i).Item("id_almacen_trasnf")

                Else

                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("almacen").Value = dt_DatosDEtallado.Rows(0).Item("dt_alm_codigo") ' lk_AlmacenActivo.codigo
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_almacen").Value = dt_DatosDEtallado.Rows(0).Item("dt_id_almacen") 'lk_AlmacenActivo.id_almacen
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("alm_abreviado").Value = dt_DatosDEtallado.Rows(0).Item("dt_alm_abreviado") 'lk_AlmacenActivo.abreviado.ToString.Trim
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_almacen_trasnf").Value = 0
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("stockactual").Value = dt_DatosDEtallado.Rows(0).Item("dt_stockactual")

                End If
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("es_control_lote").Value = dt_DatosAgrupados.Rows(i).Item("maeprod_es_control_lote")
                If GridProductos.Columns.Item("det_lote").Visible = True Then ' operacion con Ocpiones de Lote 
                    If dt_DatosAgrupados.Rows(i).Item("maeprod_es_control_lote") = 1 Then
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("lote").Value = "..."
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("det_lote").Value = "Pulsar [F2] para definición de lotes"
                    Else
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("lote").Value = ""
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("det_lote").Value = "Sin Control de lotes/series"
                    End If


                End If



                Marca_Stock_Disponible(GridProductos.Rows.Count - 1)
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("ok").Value = My.Resources.bloq
                GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("ok").Tag = "bloq"
            Next

            GridProductos.Columns.Item("present").ReadOnly = True

            If dt_DatosDEtallado.Rows(0).Item("modo_calculo") = 1 Then
                chkConIMPTO.Checked = True
                AsignarModoCalculo_GridPROD1(1)
            End If
            If dt_DatosDEtallado.Rows(0).Item("modo_calculo") = 2 Then
                chkSinIMPTO.Checked = True
                AsignarModoCalculo_GridPROD1(2)
            End If

            Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("num")
            Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("eli").Tag = "ppp"


            Me.GridProductos.BeginEdit(True)
            Contador_filas()
        End If
        Calcula_PROD1(Val(GridProductos.AccessibleDescription))
        'imageColumn.Name = "ok"
        'imageColumn.Image = My.Resources.ok
        'imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom









    End Sub
    Private Function AgrupayLlena_oper(ws_data_enlace As DataTable) As DataTable



        Dim dtAgrupado As New DataTable

        ' Definimos las columnas del nuevo DataTable
        dtAgrupado.Columns.Add("id_prod_mae", GetType(Double))
        dtAgrupado.Columns.Add("codigo_prod_mae", GetType(String))
        dtAgrupado.Columns.Add("nombre_prod_mae", GetType(String))
        dtAgrupado.Columns.Add("cantidad", GetType(Double))

        dtAgrupado.Columns.Add("descrip_pres", GetType(String))
        dtAgrupado.Columns.Add("id_pres", GetType(Integer))
        dtAgrupado.Columns.Add("equiv", GetType(Integer))

        dtAgrupado.Columns.Add("id_almacen_trasnf", GetType(Integer))
        dtAgrupado.Columns.Add("maeprod_es_control_lote", GetType(Integer))
        dtAgrupado.Columns.Add("dt_lab_linea", GetType(String))
        dtAgrupado.Columns.Add("dt_es_inventariable", GetType(Integer))



        Dim query = From row In ws_data_enlace.AsEnumerable()
                    Group By id_prod_mae = row.Field(Of Double)("id_prod_mae"), codigo_prod_mae = row.Field(Of String)("codigo_prod_mae")
            Into Group
                    Select New With {
                .id_prod_mae = id_prod_mae,
                .codigo_prod_mae = codigo_prod_mae,
                .nombre_prod_mae = Group.First().Field(Of String)("nombre_prod_mae"),
                .descrip_pres = Group.First().Field(Of String)("descrip_pres"),
                .id_pres = Group.First().Field(Of Integer)("id_pres"),
                .equiv = Group.First().Field(Of Integer)("equiv"),
                .cantidad = Group.Sum(Function(row) row.Field(Of Double)("cantidad")),
                .id_almacen_trasnf = Group.Sum(Function(row) row.Field(Of Integer)("id_almacen_base")),
                .maeprod_es_control_lote = Group.Sum(Function(row) row.Field(Of Integer)("maeprod_es_control_lote")),
                .dt_lab_linea = Group.First().Field(Of String)("dt_lab_linea"),
                .dt_es_inventariable = Group.First().Field(Of Integer)("dt_es_inventariable")
            }

        For Each item In query
            Dim newRow As DataRow = dtAgrupado.NewRow()
            newRow("id_prod_mae") = item.id_prod_mae
            newRow("codigo_prod_mae") = item.codigo_prod_mae
            newRow("nombre_prod_mae") = item.nombre_prod_mae
            newRow("cantidad") = item.cantidad
            newRow("descrip_pres") = item.descrip_pres
            newRow("id_pres") = item.id_pres
            newRow("equiv") = item.equiv
            newRow("id_almacen_trasnf") = item.id_almacen_trasnf
            newRow("maeprod_es_control_lote") = item.maeprod_es_control_lote
            newRow("dt_lab_linea") = item.dt_lab_linea
            newRow("dt_es_inventariable") = item.dt_es_inventariable
            dtAgrupado.Rows.Add(newRow)
        Next
        AgrupayLlena_oper = dtAgrupado


    End Function
    Private Sub CmdSerireComp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CmdSerireComp.KeyPress
        If e.KeyChar = Chr(13) Then
            TxtComp_Numero.Select()
            TxtComp_Numero.Focus()
        End If


    End Sub

    Private Sub TxtSerireComp_TextChanged(sender As Object, e As EventArgs) Handles TxtSerireComp.TextChanged

    End Sub

    Private Sub TxtSerireComp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSerireComp.KeyPress
        If e.KeyChar = Chr(13) Then
            TxtComp_Numero.Select()
            TxtComp_Numero.Focus()
        End If

    End Sub

    Private Sub Txt_Operacion_filtro_TextChanged(sender As Object, e As EventArgs) Handles Txt_Operacion_filtro.TextChanged
        'Txt_Operacion_filtro.Text = ListaOperacion(0)("CodigoOper")
        Txt_Operacion_filtro.Tag = ""
        CmdOperacion_filtro.Text = ""
        CmdOperacion_filtro.Tag = ""


    End Sub

    Private Sub Txt_Operacion_filtro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Operacion_filtro.KeyPress
        e.Handled = Solo_Numero(e)


        If e.KeyChar = Chr(13) Then
            CmdBusoper_filtro_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub CmdBusoper_filtro_Click(sender As Object, e As EventArgs) Handles CmdBusoper_filtro.Click
        If Txt_Operacion_filtro.Text.Trim() = "" Then
            CmdOperacion_filtro_Click(Nothing, Nothing)
        Else
            Valida_opereacion(Txt_Operacion_filtro.Text)
        End If
    End Sub

    Private Sub CmdOperacion_filtro_Click(sender As Object, e As EventArgs) Handles CmdOperacion_filtro.Click
        Dim grupos As New List(Of String)()

        For Each fila As DataRow In lk_sql_listaOperMenu.Rows
            Dim grupo As String = fila("grupo")

            If Not grupos.Contains(grupo) Then
                grupos.Add(grupo)
            End If
        Next

        Dim menu As New ToolStripDropDownMenu()
        menu.BackColor = PanelListarOper.BackColor '  System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'menu.AutoSize = False
        'menu.Width = CmdOperacion.Width
        ' menu.Height = CmdOperacion.Height


        For Each grupo As String In grupos
            Dim subMenu As New ToolStripMenuItem(grupo)

            For Each fila As DataRow In lk_sql_listaOperMenu.Rows
                If fila("grupo") = grupo Then
                    Dim detalle As String = fila("detalle")
                    Dim id As Integer = Convert.ToInt32(fila("codigo"))
                    Dim detalleItem As New ToolStripMenuItem(detalle)
                    detalleItem.BackColor = PanelListarOper.BackColor ' System.Drawing.ColorTranslator.FromHtml(strColorLogin)
                    detalleItem.ForeColor = Color.White
                    'detalleItem.AutoSize = False
                    'detalleItem.Width = CmdOperacion.Width
                    'detalleItem.Height = CmdOperacion.Height


                    ' Asociar el Id con el elemento del submenú
                    detalleItem.Tag = id

                    ' Agregar un controlador de eventos para el elemento del submenú
                    AddHandler detalleItem.Click, AddressOf muestraoper_Click

                    subMenu.DropDownItems.Add(detalleItem)
                End If
            Next

            menu.Items.Add(subMenu)
        Next

        menu.Show(CmdOperacion_filtro, New Point(0, CmdOperacion_filtro.Height))



    End Sub
    Private Sub muestraoper_Click(sender As Object, e As EventArgs)
        Dim Codigooper As Integer = Convert.ToInt32(DirectCast(sender, ToolStripMenuItem).Tag)

        Valida_opereacion(Codigooper)
    End Sub

    Private Sub CmdMuestraFiltro_Click(sender As Object, e As EventArgs) Handles CmdMuestraFiltro.Click
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter
        Dim lk_sql_listafiltro = New DataTable()
        Dim wcade_filtro_oper As String = ""
        dg_listaoper.Dock = DockStyle.Fill
        Inicia_dg_listaoper()
        dg_listaoper.Visible = True
        If Trim(Txt_Operacion_filtro.Text) <> "" Then
            wcade_filtro_oper = " and oper_codigo = '" & Trim(Txt_Operacion_filtro.Text) & "'"
        End If
        If Val(CmdEstados.Tag) <> 0 Then
            If Val(CmdEstados.Tag) = -1 Then
                wcade_filtro_oper = wcade_filtro_oper & " and estado <> 10"
            Else
                wcade_filtro_oper = wcade_filtro_oper & " and estado = " & CmdEstados.Tag & " "
            End If
        End If
        ' Aquí decides si usarás el formato en inglés o español según la base de datos


        ' == Lista de SubOperaciones de todas las operaciones de la plataforma
        sql_cade = "select  * from [vw_comprobantes_cab] where id_negocio = @id_negocio and fecha >=  @fecha1  and fecha <=  @fecha2  " & wcade_filtro_oper ' filtro para buscar por el id : id_oper_maestro
        sql_cade = sql_cade + " order by fecha, numoperdia"
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        parametro = New SqlParameter("@fecha1", t_fechaIni.Value.ToString(lk_formatoFechabd))
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@fecha2", Format(t_fechaFin.Value.ToString(lk_formatoFechabd)))
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.Add(parametro)


        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_listafiltro)
        If lk_sql_listafiltro.Rows.Count = 0 Then

            Dim Result As String = MensajesBox.Show("No Existe Registros en su consulta.",
                                    "Lista de Operación.")
            Exit Sub

        End If
        Dim witems As Integer = 0
        For i = 0 To lk_sql_listafiltro.Rows.Count - 1

            Me.dg_listaoper.Rows.Add()
            witems = witems + 1
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("numoper").Value = lk_sql_listafiltro.Rows(i).Item("numoperdia")
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("usuario").Value = lk_sql_listafiltro.Rows(i).Item("usuario")
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("fecha").Value = Format(lk_sql_listafiltro.Rows(i).Item("fecha"), "dd/MM/yyyy")
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("hora").Value = Format(lk_sql_listafiltro.Rows(i).Item("fechahora"), "hh:mm:ss tt")

            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("local").Value = lk_sql_listafiltro.Rows(i).Item("local_codigo") & " " & lk_sql_listafiltro.Rows(i).Item("local_abreviado")

            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("oper_abreviado").Value = lk_sql_listafiltro.Rows(i).Item("oper_codigo") & " " & lk_sql_listafiltro.Rows(i).Item("oper_nom_oper") & " " & lk_sql_listafiltro.Rows(i).Item("oper_nom_suboper") & " " & lk_sql_listafiltro.Rows(i).Item("oper_nom_tipooper")
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("comp_abreviado").Value = lk_sql_listafiltro.Rows(i).Item("comp_abreviado") & " " & lk_sql_listafiltro.Rows(i).Item("comp_descrip")
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("serie").Value = lk_sql_listafiltro.Rows(i).Item("serie_comp")
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("numero").Value = Format(lk_sql_listafiltro.Rows(i).Item("numero_comp"), "00000000")
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("moneda").Value = lk_sql_listafiltro.Rows(i).Item("mod_simbolo")
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("monto").Value = lk_sql_listafiltro.Rows(i).Item("total")
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("sn_abreviado").Value = lk_sql_listafiltro.Rows(i).Item("sn_razonsocial").ToString.Trim
            If lk_sql_listafiltro.Rows(i).Item("es_comprobante_fe") = 1 Then
                dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("es_fe").Tag = lk_sql_listafiltro.Rows(i).Item("estado_fe")
                If lk_sql_listafiltro.Rows(i).Item("estado_fe") = 1 Then
                    dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("es_fe").Value = "ENVIADO"
                ElseIf lk_sql_listafiltro.Rows(i).Item("estado_fe") = 0 Then
                    dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("es_fe").Value = "NO ENVIADO"
                ElseIf lk_sql_listafiltro.Rows(i).Item("estado_fe") = 2 Then
                    dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("es_fe").Value = "SIN REGISTRO"
                End If
            Else
                dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("es_fe").Value = ""
            End If

            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("vendedor").Value = ""
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("estado").Value = MuestraEstadoComp(Val(lk_sql_listafiltro.Rows(i).Item("estado")), 0)
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("estado").Tag = lk_sql_listafiltro.Rows(i).Item("estado")
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("id_negocio").Value = lk_sql_listafiltro.Rows(i).Item("id_negocio")
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("id_oper_maestro").Value = lk_sql_listafiltro.Rows(i).Item("id_oper_maestro")
            dg_listaoper.Rows(dg_listaoper.Rows.Count - 1).Cells("id_comp_cab").Value = lk_sql_listafiltro.Rows(i).Item("id_comp_cab")

        Next

        dg_listaoper.Focus()

    End Sub
    Private Sub Inicia_dg_listaoper()

        Dim textoColumn As New DataGridViewTextBoxColumn()

        Dim imageColumn As New DataGridViewImageColumn()


        dg_listaoper.Columns.Clear()

        dg_listaoper.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)

        textoColumn.Name = "numoper"
        textoColumn.HeaderText = "OPER DIA"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 40
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = True



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fecha"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "FECHA"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 65
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "hora"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "HORA"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 75
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "local"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "LOCAL"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 70
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "oper_abreviado"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "OPERACION"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 120
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = True


        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "VER"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "vercomp"
        imageColumn.Image = My.Resources.ver
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_listaoper.Columns.Add(imageColumn)
        dg_listaoper.Columns.Item(imageColumn.Name).Width = 20
        dg_listaoper.Columns.Item(imageColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "comp_abreviado"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "COMPRO BANTE"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 100
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "serie"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "SERIE"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 50
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "numero"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "NUMERO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 60
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "MOD"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 20
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "monto"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MONTO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).MinimumWidth = 70
        dg_listaoper.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "sn_abreviado"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "SOCIO NEGOCIO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 150
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = True



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "estado"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "ESTADO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 75
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "es_fe"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "ES DOC.ELECTRO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 100
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "vendedor"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "VENDEDOR"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 0
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "usuario"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "USUARIO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 60
        dg_listaoper.Columns.Item(textoColumn.Name).ReadOnly = True



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_negocio"
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 0
        dg_listaoper.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_oper_maestro"
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 0
        dg_listaoper.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_comp_cab"
        dg_listaoper.Columns.Add(textoColumn)
        dg_listaoper.Columns.Item(textoColumn.Name).Width = 0
        dg_listaoper.Columns.Item(textoColumn.Name).Visible = False


    End Sub

    Private Sub CmdEnviarA_Click(sender As Object, e As EventArgs) Handles CmdEnviarA.Click

        Dim Result As String
        Dim ListaOperTraer() As DataRow = lk_sql_EnlacesOper.Select("base_id_tb_oper  = '" & CmdOperacion.Tag & "' and tipo= 'E'")
        If ListaOperTraer.Length = 0 Then
            Result = MensajesBox.Show("Codigo de Operación No enlazado a Comprobantes Anteriores.",
                                     "Operación.")
            Exit Sub
        End If
        ' CmdTipoOper.Text = ListaOperTraer(0)("descrip_tipooper")
        ' CmdTipoOper.Tag = ListaOperTraer(0)("id_tb_tipooper")

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaOperTraer
            Dim wenlace_id_tb_oper As Integer = CInt(row("enlace_id_tb_oper"))
            Dim detalle As String = CStr(row("enlace_codigo") & " " & row("enlace_descripcion"))
            Dim codigo As String = CStr(row("enlace_codigo"))
            Dim wtipo As String = CStr(row("tipo"))
            Dim wes_valida_estado As Integer = CStr(row("es_valida_estado"))


            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       Mostrar_EnvioOperacion_enlace(wenlace_id_tb_oper, codigo, wtipo, wes_valida_estado)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdEnviarA, New Point(0, CmdEnviarA.Height))

    End Sub
    Private Sub Mostrar_EnvioOperacion_enlace(wenlace_id_tb_oper As Integer, codigo As String, wtipo As String, wes_valida_estado As Integer)
        PlaySonidoMouse(lk_CodigoSonido)
        'If lk_id_Negocio = 0 Then
        '    Dim result = MensajesBox.Show(lkfor_texto_sinnegocio, lk_cabeza_msgbox)
        '    Exit Sub
        'End If PlaySonidoMouse(lk_CodigoSonido)
        If lk_NegocioActivo.id_Negocio = 0 Then
            Dim result = MensajesBox.Show("Bloqueo por Negocio No activo", lk_cabeza_msgbox)
            Exit Sub
        End If
        If wes_valida_estado = 1 Then
            If TxtEstadoComp.Tag = "3" Or TxtEstadoComp.Tag = "8" Or TxtEstadoComp.Tag = "10" Then
                Dim result = MensajesBox.Show("Comprobante Cerrado.  (wes_valida_estado = 1)", lk_cabeza_msgbox)
                Exit Sub
            End If
        End If
        CmdEnviarA.Enabled = False
        CmdAanularOper.Enabled = False
        'CmdEnviarA..col = System.Drawing.ColorTranslator.FromHtml(strColorRojo)

        Dim frMenuOperacion As New FrmOperaciones
        frMenuOperacion.ENLACE_TIPO = "1"
        frMenuOperacion.ES_FORMZAR_CIERRE = 0
        frMenuOperacion.ENLACE_ENVIO_OPER_CODIGO = codigo
        frMenuOperacion.ENLACE_ENVIO_DATA_COMP = dt_Enlace_Envio_Oper
        frMenuOperacion.Show()
        If frMenuOperacion.ES_FORMZAR_CIERRE = 1 Then
            frMenuOperacion.Close()
            Exit Sub
        End If
        frMenuOperacion.TopLevel = False
        FrmLogin.PanelFormularios.Controls.Add(frMenuOperacion)

        frMenuOperacion.Left = 15
        frMenuOperacion.Top = 15

        FrmLogin.PanelFormularios.Controls.Item(FrmLogin.PanelFormularios.Controls.Count - 1).BringToFront() ' Ultimo Fomulario a primer plano
        SelectNextControl(ActiveControl, True, True, True, True)
        frMenuOperacion.Focus()
        frMenuOperacion.CmdGrabar.Focus()





    End Sub
    Private Sub GridProductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GridProductos.CellEnter

        If GridProductos.Columns.Count < 10 Then Exit Sub

        Dim columnIndex As Integer = GridProductos.CurrentCell.ColumnIndex ' Obtener el índice de la columna actual
        Dim columnName As String = GridProductos.Columns(columnIndex).Name ' Obtener el nombre de la columna actual
        If columnName = "present" Then
            Marca_Stock_Disponible(e.RowIndex)
        End If

        If GridProductos.Rows(GridProductos.CurrentCell.RowIndex).Cells("es_control_lote").Value = "1" Then
            GridProductos.Columns("lote").ReadOnly = False
            GridProductos.Columns("det_lote").ReadOnly = False

            If columnName = "lote" Then
                Dim cadenaDatos As String = GridProductos.Rows(GridProductos.CurrentCell.RowIndex).Cells("cadenalotes").Value
                If cadenaDatos = Nothing Then
                    AsignaLoteProducto(1)
                    Exit Sub
                End If
                If cadenaDatos.Length() < 10 Then
                    AsignaLoteProducto(1)
                    Exit Sub
                End If

            End If

        Else
            GridProductos.Columns("lote").ReadOnly = True
            GridProductos.Columns("det_lote").ReadOnly = True
            If Val(GridProductos.Rows(e.RowIndex).Cells("es_sin_stock").Value) = 1 Then
                SMS_Barra("Producto, FALTA STOCK...", 2)
                GridProductos.Select()
                Exit Sub
            End If
        End If
        If GridProductos.Rows(GridProductos.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then
            GridProductos.Columns.Item(columnName).ReadOnly = True
        Else
            GridProductos.Columns.Item(columnName).ReadOnly = False
        End If


        'End If
    End Sub

    Private Sub dg_listaoper_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_listaoper.CellContentClick

    End Sub

    Private Sub dg_listaoper_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_listaoper.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub
        dg_listaoper.Enabled = False
        Dim wid_negocio As Integer
        Dim wid_oper_maestro As Integer
        Dim wid_comp_cab As Integer

        Dim frCargainfo As New FrmCarga
        frCargainfo.LogoMuestra.Visible = False
        frCargainfo.LogoSolicdo.Visible = True
        frCargainfo.Show()


        wid_negocio = dg_listaoper.Rows(e.RowIndex).Cells("id_negocio").Value
        wid_oper_maestro = dg_listaoper.Rows(e.RowIndex).Cells("id_oper_maestro").Value
        wid_comp_cab = dg_listaoper.Rows(e.RowIndex).Cells("id_comp_cab").Value

        Muestra_Comprobante(wid_negocio, wid_oper_maestro, wid_comp_cab)
        frCargainfo.Close()
        dg_listaoper.Enabled = True
    End Sub
    Private Sub Muestra_Comprobante(wid_negocio As Integer, wid_oper_maestro As Integer, wid_comp_cab As Integer)

        Dim sql As String = "exec [sp_muestra_comprobante] @id_negocio, @id_oper_maestro, @id_comp_cab"
        Dim command As New SqlCommand(sql, lk_connection_cuenta)
        command.Parameters.AddWithValue("@id_negocio", wid_negocio)
        command.Parameters.AddWithValue("@id_oper_maestro", wid_oper_maestro)
        command.Parameters.AddWithValue("@id_comp_cab", wid_comp_cab)

        Dim adapter As New SqlDataAdapter(command)
        Dim loc_datos_comp As New DataTable()
        adapter.Fill(loc_datos_comp)

        Dim ws_resultadofn As String = ""
        Dim ws_ref_masinfo As String = ""
        'Dim tempColumn As DataColumn
        'tempColumn = New DataColumn("canti_solicita", GetType(Double))
        'tempColumn.DefaultValue = 0
        'loc_datos_comp.Columns.Add(tempColumn)
        dt_Enlace_Envio_Oper = Nothing

        If loc_datos_comp.Rows.Count = 0 Then
            Dim Result As String = MensajesBox.Show("No Existe Registros en su consulta.",
                                 "Muestra Comprobante.")
            Exit Sub
        End If

        dt_Enlace_Envio_Oper = loc_datos_comp
        IniciarListar("I")
        'Datos de la operacion 

        Mostraroperacion(loc_datos_comp.Rows(0).Item("oper_codigo").ToString.Trim)

        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        If Obtener_id_oper_maestro.Count = 0 Then
            Estado_Operacion_OperMaestro(False)
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            Exit Sub
        End If




        CmdTipoOper.Text = loc_datos_comp(0)("oper_nom_tipooper")
        CmdTipoOper.Tag = loc_datos_comp(0)("id_tb_tipooper")
        CmdSubOper.Text = loc_datos_comp(0)("oper_nom_suboper")
        CmdSubOper.Tag = loc_datos_comp(0)("id_tb_suboper")
        Actualiza_Oper_Maestro()

        ENLACE_TIPO = 2
        ENLACE_MUESTRA_id_oper_maestro = wid_oper_maestro
        ENLACE_MUESTRA_id_comp_cabe = wid_comp_cab

        Dim comboCell As DataGridViewComboBoxCell

        MuestraEstadoComp(Val(loc_datos_comp.Rows(0).Item("estado")), Val(loc_datos_comp.Rows(0).Item("nivel_comp")))

        CmdAanularOper.Enabled = False
        CmdGrabar.Enabled = False
        CmdEnviarA.Enabled = False
        CmdTraerDe.Enabled = False

        If TxtEstadoComp.Tag.ToString.Trim = "1" Or TxtEstadoComp.Tag.ToString.Trim = "8" Then ' abierto O COMPLETADO
            CmdAanularOper.Enabled = True

        End If
        If BoxRefComp.Visible Then
            tref_codigo.Text = "***"
            tref_serie.Text = "***"
            tref_numero.Text = "***"
            tref_fecha.Text = "***"
        End If



        Dim wes_inventario As Integer = Obtener_id_oper_maestro(0)("es_inventario")
        Dim wes_cuentasn As Integer = Obtener_id_oper_maestro(0)("es_cuentasn")
        Dim wes_finanzas As Integer = Obtener_id_oper_maestro(0)("es_finanzas")

        If TxtEstadoComp.Tag.ToString.Trim = "1" And wes_inventario = 0 And wes_cuentasn = 0 And wes_finanzas = 0 Then
            CmdActivarEdi.Text = "ACTIVAR &EDICION"
            CmdActivarEdi.Tag = 0
            CmdActivarEdi.Enabled = True
        Else
            CmdActivarEdi.Text = Strings.Space(20)
            CmdActivarEdi.Tag = "-1"
            CmdActivarEdi.Enabled = False
        End If








        ' local 
        CmdLocal.Text = loc_datos_comp.Rows(0).Item("local_nombre")
        CmdLocal.Tag = loc_datos_comp.Rows(0).Item("id_local")
        TxtLocal.Text = loc_datos_comp.Rows(0).Item("local_codigo")
        CmdLocal.AccessibleName = loc_datos_comp.Rows(0).Item("local_codigo")
        ' nro comprobante
        TxtComp_codigo.Text = loc_datos_comp.Rows(0).Item("comp_codigo")
        TxtComp_codigo.Tag = loc_datos_comp.Rows(0).Item("id_comprobante")

        CmdComprob.Text = Space(10) & loc_datos_comp.Rows(0).Item("comp_abreviado")
        CmdComprob.Tag = loc_datos_comp.Rows(0).Item("id_comprobante")
        CmdComprob.AccessibleName = loc_datos_comp.Rows(0).Item("comp_codigo")
        CmdComprob.AccessibleDescription = 0
        ' serire y numero de comprobante
        CmdSerireComp.Text = loc_datos_comp.Rows(0).Item("serie_comp")
        CmdSerireComp.Tag = loc_datos_comp.Rows(0).Item("serie_comp")
        TxtSerireComp.Text = loc_datos_comp.Rows(0).Item("serie_comp")
        TxtSerireComp.Tag = loc_datos_comp.Rows(0).Item("serie_comp")
        TxtComp_Numero.Text = Format(loc_datos_comp.Rows(0).Item("numero_comp"), "00000000")


        TxtDocOper.Text = Space(10) & loc_datos_comp.Rows(0).Item("docoper_abreviado")
        TxtSerieDocOper.Text = loc_datos_comp.Rows(0).Item("serie_oper")
        TxtNumDocOper.Text = Format(loc_datos_comp.Rows(0).Item("numero_oper"), "00000000")

        If Not IsDBNull(loc_datos_comp.Rows(0).Item("sn_codigo")) Then
            TxtSocio_BoxSN.Text = loc_datos_comp.Rows(0).Item("sn_codigo")
            info_SN.Text = loc_datos_comp.Rows(0).Item("sn_boxsn")
            info_SN.Tag = loc_datos_comp.Rows(0).Item("id_sn_master")

        End If
        If Val(loc_datos_comp.Rows(0).Item("tipo_transf_kardex")) = 1 Or Val(loc_datos_comp.Rows(0).Item("tipo_transf_kardex")) = 2 Then ' tipo envio
            Dim wid_almacen_transf As Integer = Val(loc_datos_comp.Rows(0).Item("id_almacen_transf"))
            Dim DatoAlmacen() As DataRow = lk_sql_Usuario_almacen.Select("id_negocio = " & lk_NegocioActivo.id_Negocio & " and id_almacen = " & wid_almacen_transf & "")
            If DatoAlmacen.Length <> 0 Then
                TxtAlmTransf.Text = DatoAlmacen(0)("alm_codigo").ToString.Trim
                TxtAlmTransf.Tag = DatoAlmacen(0)("id_almacen")
                CmdAlmTransf.Text = DatoAlmacen(0)("alm_codigo").ToString.Trim & " " & DatoAlmacen(0)("alm_abreviado").ToString.Trim
                CmdAlmTransf.Tag = DatoAlmacen(0)("id_almacen")
            End If
        End If
        If Val(loc_datos_comp.Rows(0).Item("es_servicio")) = 1 Then
            If Radio_Serv.Checked = False Then
                Radio_Serv.Checked = True
                Gestion_Columnas_PRO01(1) ' 
            End If
        End If
        If Val(loc_datos_comp.Rows(0).Item("es_servicio")) = 0 Then
            If Radio_Prod.Checked = False Then
                Radio_Prod.Checked = True
                Gestion_Columnas_PRO01(0) ' 
            End If
        End If


        ' Socio de negocio

        ' fechas de emis y proceso
        TxtFechas_Proc.Value = Format(loc_datos_comp.Rows(0).Item("fecha"), "dd/MM/yyyy")
        TxtFechas_Emis.Value = Format(loc_datos_comp.Rows(0).Item("fecha_emis"), "dd/MM/yyyy")
        'TxtCondi_FecVcto.Value = Format(loc_datos_comp.Rows(0).Item("fecha_vcto"), "dd/MM/yyyy")


        CmdEnlacesComp.Enabled = True

        ' Almacena varaibles de llabe de comprobante
        ENLACE_id_oper_maestro = loc_datos_comp.Rows(0).Item("id_oper_maestro")
        ENLACE_id_comp_cabe = loc_datos_comp.Rows(0).Item("id_comp_cab")



        BoxTOT12.Text = loc_datos_comp.Rows(0).Item("id_oper_maestro") & " - " & loc_datos_comp.Rows(0).Item("id_comp_cab")
        BoxTOT12.Visible = True
        TxtEstadoComp.AccessibleDescription = loc_datos_comp(0)("nivel_comp") ' nivel del comprobante origen 
        ws_resultadofn = loc_datos_comp(0)("resultadofn")

        Bloqueo_Estado_Box(1) ' inicia si bloqeuo

        If BoxLineaCredito.Visible Then

            Obtener_LineaCredito_SN(Val(loc_datos_comp.Rows(0).Item("id_sn_master")), 0, 0, 0)
            lc_monto.Text = loc_datos_comp.Rows(0).Item("total")
            Dim wes_exonerado As Integer = loc_datos_comp.Rows(0).Item("valor_exonerado")
            If wes_exonerado = 1 Then
                CmdOpcionesLC.Tag = "1"
                CmdOpcionesLC.Text = "AUMENTAR"
            Else
                CmdOpcionesLC.Tag = "-1"
                CmdOpcionesLC.Text = "DISMINUIR"
            End If

            'lc_monto.Text = loc_datos_comp.Rows(0).Item("total")
        End If


        If dg_cuentasn.Visible Then
            If dg_cuentasn.Tag = "CTASN1" Then
                Dim sql_sn As String = "exec [sp_muestra_detalle_carterasn] @id_negocio, @id_oper_maestro, @id_comp_cab"
                Dim command_sn As New SqlCommand(sql_sn, lk_connection_cuenta)
                command_sn.Parameters.AddWithValue("@id_negocio", wid_negocio)
                command_sn.Parameters.AddWithValue("@id_oper_maestro", wid_oper_maestro)
                command_sn.Parameters.AddWithValue("@id_comp_cab", wid_comp_cab)

                Dim adapter_sn As New SqlDataAdapter(command_sn)
                Dim loc_datos_comp_sn = New DataTable()
                adapter_sn.Fill(loc_datos_comp_sn)

                dg_cuentasn.Visible = False
                dg_cuentasn.Refresh()
                Application.DoEvents()
                dg_cuentasn.SuspendLayout()
                Me.dg_cuentasn.Rows.Clear()
                For i = 0 To loc_datos_comp_sn.Rows.Count - 1
                    Me.dg_cuentasn.Rows.Add()




                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("codcomp").Value = loc_datos_comp_sn.Rows(i).Item("comp_codigo")
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("seriecomp").Value = loc_datos_comp_sn.Rows(i).Item("serie_comp")
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("numerocomp").Value = loc_datos_comp_sn.Rows(i).Item("numero_comp")

                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("aplicar").Value = loc_datos_comp_sn.Rows(i).Item("monto_oper")
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("monto").Value = loc_datos_comp_sn.Rows(i).Item("monto_comp")


                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("codigo").Value = loc_datos_comp_sn.Rows(i).Item("sn_codigo")
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("descrip").Value = loc_datos_comp_sn.Rows(i).Item("sn_razonsocial")
                    'dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("masdetalle").Tag = loc_datos_comp_sn.Rows(i).Item("ref_prod_mae")
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("fechaemis").Value = loc_datos_comp_sn.Rows(i).Item("fecha_emis")
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("local").Value = loc_datos_comp_sn.Rows(i).Item("local_codigo")
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("moneda").Value = loc_datos_comp_sn.Rows(i).Item("mod_simbolo")
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("saldo").Value = 0
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("fechavcto").Value = loc_datos_comp_sn.Rows(i).Item("fecha_vcto")
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("condicion").Value = ""
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("vendedor").Value = ""
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("hecho").Value = ""
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("fechahora").Value = Format(loc_datos_comp.Rows(0).Item("fecha"), "dd/MM/yyyy")

                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("id_oper_maestro").Value = loc_datos_comp_sn.Rows(i).Item("id_oper_maestro")
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("id_comp_cab").Value = loc_datos_comp_sn.Rows(i).Item("id_comp_cab")
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("id_carterasn_cab").Value = loc_datos_comp_sn.Rows(i).Item("id_carterasn_cab")
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("id_carterasn_det").Value = loc_datos_comp_sn.Rows(i).Item("id_carterasn_det")
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("ok").Value = My.Resources.bloq
                    dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("ok").Tag = "bloq"

                Next
                dg_cuentasn.Refresh()
                dg_cuentasn.ResumeLayout()
                dg_cuentasn.Visible = True
                Contador_filas_cuentaSN()
                Calcula_CTASN1(1)
            End If
        End If


        If GridProductos.Visible Then
            PanelDEtalle.Visible = False
            PanelDEtalle.Refresh()

            GridProductos.Columns.Item("saldo_pend").Visible = False
            If Val(loc_datos_comp.Rows(0).Item("es_servicio")) = 0 Then  ' solo para tipo productos 
                If TxtEstadoComp.Tag = "1" Or TxtEstadoComp.Tag = "2" Then
                    GridProductos.Columns.Item("cantidad_saldo").Visible = True
                End If
                GridProductos.Columns.Item("cantidad_saldo").Visible = False
                If TxtEstadoComp.Tag.ToString.Trim = "1" Or TxtEstadoComp.Tag.ToString.Trim = "2" Then ' abierto u parcialmente
                    GridProductos.Columns.Item("saldo_pend").Visible = True
                End If
            End If
            'loc_datos_comp(0)("mod_simbolo")
            If loc_datos_comp(0)("es_carterasn") = 1 Then
                link_saldo.Text = "SALDO COMPROB: " & loc_datos_comp(0)("mod_simbolo") & " " & Format(loc_datos_comp(0)("carterasn_saldo"), "#,##0.00")
                If Val(loc_datos_comp(0)("carterasn_saldo")) <> Val(loc_datos_comp(0)("total") * loc_datos_comp(0)("signo_sn")) Then
                    link_saldo.Tag = 1 ' BLOQUEO - NO SE PUEDE ANULAR 
                Else
                    link_saldo.Tag = 0
                End If
                link_saldo.AccessibleName = loc_datos_comp(0)("es_carterasn")
                link_saldo.AccessibleDescription = loc_datos_comp(0)("carterasn_saldo")
            Else
                link_saldo.Text = ""
                link_saldo.Tag = 0 ' es_carterasn 
                link_saldo.AccessibleName = 0  ' signo_carterasn 
                link_saldo.AccessibleDescription = 0
            End If


            If Me.GridProductos.Tag = "PROD1" Then
                GridProductos.Visible = False
                GridProductos.Refresh()

                Application.DoEvents()
                GridProductos.SuspendLayout()
                If loc_datos_comp.Rows.Count = 0 Then Exit Sub
                Me.GridProductos.Rows.Clear()
                For i = 0 To loc_datos_comp.Rows.Count - 1
                    Me.GridProductos.Rows.Add()

                    If loc_datos_comp.Rows(i).Item("dt_es_prod_new") = 1 Then
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("es_prod_new").Value = True
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("descrip").Value = loc_datos_comp.Rows(i).Item("dt_prod_new_nombre")
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("codigo").Value = loc_datos_comp.Rows(i).Item("dt_prod_new_codigo")
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_prod_mae_codigo").Value = loc_datos_comp.Rows(i).Item("dt_prod_new_codigo")
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("grupo").Value = "NUEVO PRODUCTO / SERVICIO"
                    Else
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("es_prod_new").Value = False
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("descrip").Value = loc_datos_comp.Rows(i).Item("dt_nombreproducto")
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("codigo").Value = loc_datos_comp.Rows(i).Item("dt_prod_codigo")
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_prod_mae_codigo").Value = loc_datos_comp.Rows(i).Item("dt_prod_codigo")
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("grupo").Value = loc_datos_comp.Rows(i).Item("dt_lab_linea")
                    End If
                    ws_ref_masinfo = loc_datos_comp.Rows(i).Item("dt_ref_prod_mae").ToString
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle").Tag = ws_ref_masinfo
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle").Value = If(ws_ref_masinfo = "", "", "(*)")

                    'dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("masdetalle").Tag = loc_datos_comp_sn.Rows(i).Item("ref_prod_mae")


                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_prod_mae").Value = loc_datos_comp.Rows(i).Item("id_prod_mae")


                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("cantidad").Value = Val(loc_datos_comp.Rows(i).Item("dt_cantidad") / loc_datos_comp.Rows(i).Item("dt_equiv"))
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("cantidad_saldo").Value = Val(loc_datos_comp.Rows(i).Item("dt_cantidad")) - Val(loc_datos_comp.Rows(i).Item("cantidad_aplicada"))

                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("saldo_pend").Value = ((Val(loc_datos_comp.Rows(i).Item("dt_cantidad")) - Val(loc_datos_comp.Rows(i).Item("cantidad_aplicada"))) / loc_datos_comp.Rows(i).Item("dt_equiv"))

                    'comboCell = CType(GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("present"), DataGridViewComboBoxCell)
                    'comboCell.Items.Clear()
                    'comboCell.Items.Add(loc_datos_comp.Rows(i).Item("dt_descrip_pres"))
                    'comboCell.Value = loc_datos_comp.Rows(i).Item("dt_descrip_pres")
                    ''GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("present").Value = dt_DatosAgrupados.Rows(i).Item("dt_abreviado_pres_def")
                    'GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_pres").Value = loc_datos_comp.Rows(i).Item("dt_id_pres")
                    'GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("equiv").Value = loc_datos_comp.Rows(i).Item("dt_equiv")



                    Dim wpres As String = loc_datos_comp.Rows(i).Item("Unidades")

                    Dim valores As List(Of Tuple(Of String, Integer, Integer)) = ConvertirCadena(wpres)
                    'Dim comboCell As DataGridViewComboBoxCell
                    comboCell = CType(GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("present"), DataGridViewComboBoxCell)
                    comboCell.Items.Clear()
                    Dim valoresDict As New Dictionary(Of Integer, Tuple(Of String, Integer, Integer)) ' Diccionario para almacenar los valores con su índice
                    For t As Integer = 0 To valores.Count - 1
                        comboCell.Items.Add(valores(t).Item1)
                        valoresDict.Add(t, valores(t)) '
                    Next
                    comboCell.Tag = valoresDict
                    comboCell.Value = loc_datos_comp.Rows(i).Item("dt_descrip_pres")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_pres").Value = loc_datos_comp.Rows(i).Item("dt_id_pres")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("equiv").Value = loc_datos_comp.Rows(i).Item("dt_equiv")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("present").Value = loc_datos_comp.Rows(i).Item("dt_descrip_pres")


                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("almacen").Value = loc_datos_comp.Rows(i).Item("dt_alm_codigo")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("lote").Value = ""
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_almacen").Value = loc_datos_comp.Rows(i).Item("dt_id_almacen")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("alm_abreviado").Value = loc_datos_comp.Rows(i).Item("dt_alm_abreviado")
                    ' Valores del comprobante
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("preciobase").Value = loc_datos_comp.Rows(i).Item("dt_precio")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("des1").Value = ""
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("des2").Value = ""
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("impto").Value = loc_datos_comp.Rows(i).Item("dt_impto")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("subtotal").Value = loc_datos_comp.Rows(i).Item("dt_subtotal")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("valor").Value = loc_datos_comp.Rows(i).Item("dt_valor")

                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("es_control_lote").Value = loc_datos_comp.Rows(i).Item("dt_es_control_lote")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("cadenalotes").Value = loc_datos_comp.Rows(i).Item("dt_loteser_det")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("cadenalotes_formato").Value = loc_datos_comp.Rows(i).Item("dt_loteser_det_formato")

                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_pres_base").Value = loc_datos_comp.Rows(i).Item("dt_id_pres_base")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("abreviado_base").Value = loc_datos_comp.Rows(i).Item("dt_abreviado_pres_base")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("equiv_base").Value = loc_datos_comp.Rows(i).Item("dt_equiv_base")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("es_inventariable").Value = loc_datos_comp.Rows(i).Item("dt_es_inventariable")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("es_exonerado").Value = loc_datos_comp.Rows(i).Item("dt_es_exonerado")



                    If Val(loc_datos_comp.Rows(0).Item("es_servicio")) = 1 Then  ' solo para tipo productos 
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("detalle_serv").Value = ws_ref_masinfo
                    End If
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_tb_tipo_serv").Value = loc_datos_comp.Rows(i).Item("id_tb_tipo_serv")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_serv").Value = loc_datos_comp.Rows(i).Item("id_serv")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_area").Value = loc_datos_comp.Rows(i).Item("id_area")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_uci").Value = loc_datos_comp.Rows(i).Item("id_uci")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("id_local_serv").Value = loc_datos_comp.Rows(i).Item("id_local_serv")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("tipo_serv_des").Value = loc_datos_comp.Rows(i).Item("tipo_serv_des")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("codigo_serv").Value = loc_datos_comp.Rows(i).Item("codigo_serv")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("des_serv").Value = loc_datos_comp.Rows(i).Item("des_serv")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("area_serv_des").Value = loc_datos_comp.Rows(i).Item("area_serv_des")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("uci_serv_des").Value = loc_datos_comp.Rows(i).Item("uci_serv_des")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("codigo_local_serv").Value = loc_datos_comp.Rows(i).Item("codigo_local_serv")
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("des_local_serv").Value = loc_datos_comp.Rows(i).Item("des_local_serv")



                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("es_prod_bof").Value = loc_datos_comp.Rows(i).Item("dt_es_bonificado")




                    If Val(loc_datos_comp.Rows(i).Item("dt_es_control_lote")) = "1" Then
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("lote").Value = ""
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("det_lote").Value = "Pulsar [F2] ver detalle Lotes/Serie"
                    Else
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("lote").Value = ""
                        GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("det_lote").Value = "Sin Control de Lotes/Serie"
                    End If

                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("ok").Value = My.Resources.bloq
                    GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("ok").Tag = "bloq"

                Next


                Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("eli").Tag = "ppp"
                GridProductos.Columns.Item("present").ReadOnly = True
                GridProductos.Columns.Item("almacen").ReadOnly = True
                '            Me.GridProductos.BeginEdit(True)
                If loc_datos_comp(0)("modo_calculo") = 1 Then
                    chkConIMPTO.Checked = True
                    AsignarModoCalculo_GridPROD1(1)
                End If
                If loc_datos_comp(0)("modo_calculo") = 2 Then
                    chkSinIMPTO.Checked = True
                    AsignarModoCalculo_GridPROD1(2)
                End If
                PanelDEtalle.Visible = True
                PanelDEtalle.Refresh()

                GridProductos.Refresh()
                GridProductos.ResumeLayout()
                GridProductos.Visible = True
                If Radio_Serv.Checked = True Then
                    Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("tipo_serv_des")
                Else
                    Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("descrip")
                End If
                Contador_filas()
                Calcula_PROD1(Val(GridProductos.AccessibleDescription))
            End If
        End If


        If TxtEstadoComp.Tag.ToString.Trim = "1" Or TxtEstadoComp.Tag.ToString.Trim = "2" Then ' abierto
            CmdEnviarA.Enabled = True
        Else
            If loc_datos_comp(0)("es_carterasn") = 1 Then
                If Val(link_saldo.AccessibleDescription) <> 0 Then
                    CmdEnviarA.Enabled = True
                End If
            End If
        End If

        If BoxEntidadF.Visible Then
            TxtDetallefn.AccessibleDescription = ws_resultadofn
            TxtDetallefn.AccessibleName = "bloq"
            TxtDetallefn.Text = "Pulsar [Alt+F] o Click Lupa, para Mostrar detalle..."
        End If

        If BoxEstadoSN.Visible Then





        End If




    End Sub

    Private Function Obtener_Detalle_fn(wresultadofn As String) As DataTable


        Dim dataTable_fn As New DataTable()





        dataTable_fn.Columns.Clear()
        dataTable_fn.Columns.Add("id_negocio", GetType(Integer))
        dataTable_fn.Columns.Add("numsec", GetType(Integer))
        dataTable_fn.Columns.Add("id_moneda", GetType(Integer))
        dataTable_fn.Columns.Add("id_tb_formas_fn", GetType(Integer))
        dataTable_fn.Columns.Add("id_fn_maestro", GetType(Integer))
        dataTable_fn.Columns.Add("fecha_fn", GetType(DateTime))
        dataTable_fn.Columns.Add("nrodoc", GetType(String))
        dataTable_fn.Columns.Add("ref", GetType(String))
        dataTable_fn.Columns.Add("total", GetType(Double))
        dataTable_fn.Columns.Add("signo_fn", GetType(Integer))
        dataTable_fn.Columns.Add("id_controlcaja_det", GetType(Integer))



        Dim resultado As String = wresultadofn

        Dim filas As String() = resultado.Split("%"c)

        ' Paso 3: Recorrer cada fila y dividirla en elementos utilizando el carácter '#'
        For i As Integer = 0 To filas.Length - 1

            Dim elementos As String() = filas(i).Trim("["c, "]"c).Split("["c)

            ' Crear una nueva fila en el DataTable
            Dim nuevaFila As DataRow = dataTable_fn.NewRow()

            If elementos(0).ToString.Trim = "" Then Continue For
            ' Asignar los valores a las columnas de la fila

            nuevaFila("id_negocio") = elementos(0).Substring(0, elementos(0).Length - 1)
            nuevaFila("numsec") = elementos(4).Substring(0, elementos(4).Length - 1)
            nuevaFila("id_moneda") = elementos(9).Substring(0, elementos(9).Length - 1)
            nuevaFila("id_tb_formas_fn") = elementos(5).Substring(0, elementos(5).Length - 1)
            nuevaFila("id_fn_maestro") = elementos(8).Substring(0, elementos(8).Length - 1)
            nuevaFila("fecha_fn") = elementos(3).Substring(0, elementos(3).Length - 1)
            nuevaFila("nrodoc") = elementos(11).Substring(0, elementos(11).Length - 1)
            nuevaFila("ref") = elementos(12).Substring(0, elementos(12).Length - 1)
            nuevaFila("total") = elementos(10).Substring(0, elementos(10).Length - 1)
            nuevaFila("id_controlcaja_det") = elementos(7).Substring(0, elementos(7).Length - 1)
            nuevaFila("signo_fn") = elementos(14)

            ' Agregar la fila al DataTable
            dataTable_fn.Rows.Add(nuevaFila)
        Next

        '0[' + CONVERT(VARCHAR, fn_cab.id_negocio) + ']' +
        '1[',fn_cab.id_oper_maestro, ']',
        '2[',fn_cab.id_comp_cab, ']',
        '3[',CONVERT(VARCHAR, fn_cab.fecha_fn, 120), ']',
        '4[',fn_cab.numsec, ']',
        '5[',fn_cab.id_tb_formas_fn, ']',
        '6[',fn_cab.signo_fn, ']',
        '7[',fn_cab.id_controlcaja_det, ']',
        '8[',fn_cab.id_fn_maestro, ']',
        '9[',fn_cab.id_moneda, ']',
        '10[',fn_cab.total, ']',
        '11[',fn_cab.nrodoc, ']',
        '12[',fn_cab.ref, ']',
        '13[',detcarsn.estado, ']',
        '14[', fn_cab.signo_fn, ']'
        'Stop

        Return dataTable_fn

    End Function

    Private Sub CmdEnlacesComp_Click(sender As Object, e As EventArgs) Handles CmdEnlacesComp.Click
        Dim Result As String

        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim whacebusAdd As Boolean = False
        Dim lk_sql_listaenlaces As New DataTable()


        Dim sql As String = "exec [sp_muestra_enlaces] @id_negocio, @id_oper_maestro, @id_comp_cab"
        command = New SqlCommand(sql, lk_connection_cuenta)
        command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.AddWithValue("@id_oper_maestro", ENLACE_id_oper_maestro)
        command.Parameters.AddWithValue("@id_comp_cab", ENLACE_id_comp_cabe)
        adaptador = New SqlDataAdapter(command)
        Dim loc_datos_comp As New DataTable()
        adaptador.Fill(lk_sql_listaenlaces)


        Dim ListaOperEnlaces() As DataRow = lk_sql_listaenlaces.Select("")
        If ListaOperEnlaces.Length = 0 Then
            Result = MensajesBox.Show("Codigo de Operación No enlazado a Comprobantes Anteriores.",
                                     "Operación.")
            Exit Sub
        End If
        ' CmdTipoOper.Text = ListaOperTraer(0)("descrip_tipooper")
        ' CmdTipoOper.Tag = ListaOperTraer(0)("id_tb_tipooper")

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorAzul)
        menu.ForeColor = Color.White
        menu.Font = New Font(menu.Font.FontFamily, 8, FontStyle.Regular)
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaOperEnlaces
            Dim wenlace_id_negocio As Integer = CInt(row("id_negocio"))
            Dim wenlace_id_oper_maestro As Integer = CInt(row("id_oper_maestro"))
            Dim detalle As String = row("tipo").ToString & " " & row("comp_abreviado").ToString.Trim & " (" & CStr(Format(row("fecha"), "dd/MM/yyyy") & ") " & row("comp_abreviado").ToString.Trim & " " & row("serie_comp").ToString & " " & Format(row("numero_comp"), "00000000"))
            Dim wenlace_id_comp_cab As String = CStr(row("id_comp_cab"))
            Dim wcodigooper As String = CStr(row("oper_codigo"))

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       Muestras_EnlacesComp(wenlace_id_negocio, wcodigooper, wenlace_id_oper_maestro, wenlace_id_comp_cab)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdTraerDe, New Point(0, CmdTraerDe.Height))
    End Sub
    Private Sub Muestras_EnlacesComp(wenlace_id_negocio As Integer, wcodigooper As String, wenlace_id_oper_maestro As Integer, wenlace_id_comp_cab As Integer)
        PlaySonidoMouse(lk_CodigoSonido)


        If lk_NegocioActivo.id_Negocio = 0 Then
            Dim result = MensajesBox.Show("Bloqueo por Negocio No activo", lk_cabeza_msgbox)
            Exit Sub
        End If

        Dim frMenuOperacion As New FrmOperaciones
        frMenuOperacion.ENLACE_TIPO = "2"
        frMenuOperacion.ENLACE_MUESTRA_id_oper_maestro = wenlace_id_oper_maestro
        frMenuOperacion.ENLACE_MUESTRA_id_comp_cabe = wenlace_id_comp_cab
        frMenuOperacion.Show()
        frMenuOperacion.TopLevel = False
        FrmLogin.PanelFormularios.Controls.Add(frMenuOperacion)
        frMenuOperacion.Left = Me.Left + 10
        frMenuOperacion.Top = Me.Top + 10
        FrmLogin.PanelFormularios.Controls.Item(FrmLogin.PanelFormularios.Controls.Count - 1).BringToFront() ' Ultimo Fomulario a primer plano
        SelectNextControl(ActiveControl, True, True, True, True)
        frMenuOperacion.Focus()
        frMenuOperacion.CmdGrabar.Focus()



    End Sub
    Private Function MuestraEstadoComp(westado As Integer, wnivelcomp As Integer) As String
        TxtEstadoComp.Tag = westado
        TxtEstadoComp.AccessibleName = wnivelcomp
        CmdActualizarComp.Enabled = False
        Select Case westado
            Case 0
                TxtEstadoComp.Text = "CREANDO."
                TxtEstadoComp.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoNegro)
            Case 1
                TxtEstadoComp.Text = "ABIERTO"
                TxtEstadoComp.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoNegro)
                CmdActualizarComp.Enabled = True
            Case 2
                TxtEstadoComp.Text = "PARCIALMENTE ABIERTO"
                TxtEstadoComp.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorNaranja)
                CmdActualizarComp.Enabled = True
            Case 3
                TxtEstadoComp.Text = "CERRADO"
                TxtEstadoComp.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoVerde)
                CmdActualizarComp.Enabled = True
            Case 4
                TxtEstadoComp.Text = "CREACION (TRAER DE.)"
                TxtEstadoComp.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoNegro)
            Case 5
                TxtEstadoComp.Text = "CREACION (ENVIAR A.)"
                TxtEstadoComp.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoNegro)
            Case 8
                TxtEstadoComp.Text = "CERRADO-AT"
                TxtEstadoComp.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoVerde)
                CmdActualizarComp.Enabled = True
            Case 10
                TxtEstadoComp.Text = "ANULADO."
                TxtEstadoComp.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorRojo)
        End Select
        MuestraEstadoComp = TxtEstadoComp.Text





    End Function

    Private Sub GridProductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles GridProductos.CellEndEdit
        Dim nombreColumna As String
        If ENLACE_TIPO Is Nothing Then
        Else
            If ENLACE_TIPO = "1" Then
                nombreColumna = GridProductos.Columns(e.ColumnIndex).Name
                If nombreColumna = "cantidad" Then
                    If Val(GridProductos.Rows(e.RowIndex).Cells("cantidad").Value) > Val(GridProductos.Rows(e.RowIndex).Cells("cantidad_saldo").Value) Then
                        GridProductos.Rows(e.RowIndex).Cells("cantidad").Value = Val(GridProductos.Rows(e.RowIndex).Cells("cantidad_saldo").Value)
                        Calcula_PROD1(Val(GridProductos.AccessibleDescription))
                        Exit Sub
                    Else
                        Dim rowsToEdit() As DataRow = dt_DatosEnlace_oper.Select("numsec = " & Val(GridProductos.Rows(e.RowIndex).Cells("num_sec").Value))
                        For Each row As DataRow In rowsToEdit
                            row("cantidad") = Val(GridProductos.Rows(e.RowIndex).Cells("cantidad").Value)
                        Next
                    End If

                End If
            End If
        End If
        nombreColumna = GridProductos.Columns(e.ColumnIndex).Name
        If nombreColumna = "preciobase" Or nombreColumna = "subtotal" Or nombreColumna = "valor" Then
            AsignaFilaGridModoCal(nombreColumna, e.RowIndex)
            Calcula_PROD1(Val(GridProductos.AccessibleDescription))
        End If


    End Sub
    Private Sub AsignaFilaGridModoCal(nombreColumna As String, filagrid As Integer)
        ' PT =  DESDE EL PRECIO CON IMPTO
        ' TO =   DEL TOTAL HACIA EL PRECIO CON IMPTO
        ' PV =  DESDE EL PRECIO SIN IMPTO AL TOTAL
        ' VA =  DESDE AL VALOR SIN IMPTTO
        If GridProductos.AccessibleDescription = "1" Then ' AFECTO AL IPTO
            If nombreColumna = "preciobase" Then
                GridProductos.Rows(filagrid).Cells("modocalculo").Value = "PT"
            ElseIf nombreColumna = "subtotal" Then
                GridProductos.Rows(filagrid).Cells("modocalculo").Value = "TO"
            End If
        ElseIf GridProductos.AccessibleDescription = "2" Then ' AFECTO AL IPTO
            If nombreColumna = "preciobase" Then
                GridProductos.Rows(filagrid).Cells("modocalculo").Value = "PV"
            ElseIf nombreColumna = "valor" Then
                GridProductos.Rows(filagrid).Cells("modocalculo").Value = "VA"
            End If

        End If
    End Sub
    Private Sub CmdAanularOper_Click(sender As Object, e As EventArgs) Handles CmdAanularOper.Click
        Dim result As String = ""
        If ENLACE_TIPO Is Nothing Then
            result = MensajesBox.Show("VERIFICAR NO ASOCIADO , CARGAR NUEVAMENTE LA OPERACION",
                                                     "Operación.")
            Exit Sub
        Else
            If ENLACE_TIPO = "1" Then
                Exit Sub
            End If
        End If
        If link_saldo.AccessibleName = "1" Then   ' COMPROBANTE TIENE AFECTO A CARTERASN
            If link_saldo.Tag = "1" Then ' ACTIVO EL BLOQUE POR QUE EL SALDO ES DIFENRTE AL TOTAL DEL CCOMPORBANTE
                result = MensajesBox.Show("Comprobante tiene Operaciones que estan afectando al saldo.",
                                                     "Operación.")
                Exit Sub
            End If
        End If


        result = MensajesBox.Show("Confirmar la ANULACION del comprobante...?", "ANULAR!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If Result = "7" Or Result = "2" Then ' es NO
            Exit Sub
        End If
        Dim wAnul_resultado As String = ""
        Dim storedProcedureName As String = "Oper_anularComp"
        Using command As New SqlCommand(storedProcedureName, lk_connection_cuenta)

            '            Dim sql As String = "exec [Oper_anularComp] @id_negocio, @id_oper_maestro, @id_comp_cab, @id_usuario"
            '           Dim command As New SqlCommand(sql, lk_connection_cuenta)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
            command.Parameters.AddWithValue("@id_oper_maestro", ENLACE_MUESTRA_id_oper_maestro)
            command.Parameters.AddWithValue("@id_comp_cab", ENLACE_MUESTRA_id_comp_cabe)
            command.Parameters.AddWithValue("@id_usuario", lk_id_usuario)


            Dim outputParameter As New SqlParameter("@Resultado", SqlDbType.NVarChar, -1)
            outputParameter.Direction = ParameterDirection.Output
            command.Parameters.Add(outputParameter)

            'Stop
            command.ExecuteNonQuery()

            ' Obtener el valor de retorno (cadena de texto)
            wAnul_resultado = CStr(outputParameter.Value)

        End Using
        'Dim resultado As Integer = outputParameter.Value


        'Dim adapter As New SqlDataAdapter(command)
        'Dim sql_datos_comp As New DataTable()
        'adapter.Fill(sql_datos_comp)
        If wAnul_resultado = "C000" Then
            SMS_Barra("COMPROBANTE ANULADO CON EXITO : " & "", 1)
            CancelaOper("")

            If CmdOperacion.AccessibleDescription <> "" Then 'Primera Ubiacion 
                SaltoBox(CmdOperacion.AccessibleDescription)
            End If ' 
        ElseIf wAnul_resultado = "C100" Then
            result = MensajesBox.Show("EXISTE PRODUCTOS CON INGRESOS O ENVIO DE TRASNFERENCIA POSTERIORES QUE AFECTARIAN AL COSTEO , NO PROCEDE ",
                                                     "Operación.")
        ElseIf wAnul_resultado = "C101" Then
            result = MensajesBox.Show("EXISTE PRODUCTOS QUE LLEGARAN A UN STOCK NEGATIVO, NO PROCEDE",
                                                     "Operación.")
        ElseIf wAnul_resultado = "C102" Then
            result = MensajesBox.Show("EXISTE PRODUCTOS CON LOTE!! QUE LLEGARAN A UN STOCK NEGATIVO, NO PROCEDE",
                                                     "Operación.")

        Else
            result = MensajesBox.Show("ANULACION NO PROCEDE, VERIFICAR COMPROBANTE",
                                                     "Operación.")
        End If

    End Sub

    Private Sub CmdEstados_Click(sender As Object, e As EventArgs) Handles CmdEstados.Click




        Dim codigos() As String = {"-1", "0", "1", "2", "3", "8", "10"}
        Dim nombres() As String = {"(TODOS SIN ANULADOS)", "(TODOS)", "ABIERTO", "PARCIAALMENTE ABIERTO", "CERRADO", "CERRADO-AT", "ANULADOS"}

        Dim menu As New ContextMenuStrip()
        menu.BackColor = PanelListarOper.BackColor
        menu.ForeColor = Color.White

        For i As Integer = 0 To codigos.Length - 1
            Dim codigo As String = codigos(i)
            Dim nombre As String = nombres(i)

            Dim item As New ToolStripMenuItem(nombre)
            item.Tag = codigo ' Puedes asignar el código como valor de la propiedad Tag del elemento de menú

            ' Agregar un controlador de eventos para el evento Click del elemento de menú
            AddHandler item.Click, Sub()
                                       ' Acción a realizar cuando se hace clic en el elemento de menú
                                       'Dim menuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
                                       '     Dim selectedCodigo As String = menuItem.Tag.ToString()

                                       ' Llamar al procedimiento con los parámetros
                                       ListaEstados(codigo, nombre)
                                   End Sub



            menu.Items.Add(item)
        Next
        menu.Show(CmdEstados, New Point(0, CmdEstados.Height))




    End Sub
    Private Sub ListaEstados(wcodigo As String, wdetalle As String)
        CmdEstados.Text = wdetalle.Trim
        CmdEstados.Tag = wcodigo.Trim
    End Sub

    Private Sub dg_listaoper_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dg_listaoper.CellFormatting
        If e.ColumnIndex = dg_listaoper.Columns("estado").Index AndAlso e.RowIndex >= 0 Then
            Dim estado As String = CStr(e.Value)
            Dim codigoEstado As String = CStr(dg_listaoper.Rows(e.RowIndex).Cells("estado").Tag)

            ' Asignar color al texto según el tipo de estado
            Select Case codigoEstado
                Case "1"

                Case "2"
                    e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorNaranja)

                Case "3"
                    e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoVerde)

                Case "8"
                    e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoVerde)

                Case "10"
                    e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorRojo)
                Case Else
                    ' Establecer el color predeterminado para otros casos
                    e.CellStyle.ForeColor = dg_listaoper.DefaultCellStyle.ForeColor
            End Select
        End If
        If e.ColumnIndex = dg_listaoper.Columns("es_fe").Index AndAlso e.RowIndex >= 0 Then
            Dim estado As String = CStr(e.Value)
            Dim codigoEstado As String = CStr(dg_listaoper.Rows(e.RowIndex).Cells("es_fe").Tag)

            ' Asignar color al texto según el tipo de estado
            Select Case codigoEstado

                Case "1"
                    e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoVerde)

                Case "0"
                    e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorRojo)
                Case Else
                    ' Establecer el color predeterminado para otros casos
                    e.CellStyle.ForeColor = dg_listaoper.DefaultCellStyle.ForeColor
            End Select
        End If

    End Sub

    Private Sub cmdFormato_Click(sender As Object, e As EventArgs) Handles cmdFormato.Click
        'CmdEnviarA..col = System.Drawing.ColorTranslator.FromHtml(strColorRojo)


        Envia_formato(dt_Enlace_Envio_Oper, 6, "00")

    End Sub
    Private Sub Envia_Impresion_Comprobante(wid_oper_maestro As Integer, wid_comp_cab As Integer)

        Dim wcodigo As String = "00"
        Dim Listaformato() As DataRow = loc_sql_lista_formato.Select("id_tb_oper =  " & Val(TxtOperacion.Tag) & " and codigo = '" & wcodigo & "'")
        ' Recorremos las filas filtradas
        If Listaformato.Length = 0 Then
            'Dim Result = MensajesBox.Show("Comprobante no tiene asignado Formato de impresion.",
            '                         "Operación.")
            Exit Sub
        End If
        '================================
        ' Destino:
        ' 1- no imprime
        ' 2- impresora
        ' 3- panrtalla
        ' 4- PDF
        ' formato:
        ' 1- 56
        ' 2- 80
        ' 3- a4
        '================================

        Dim wid_destino As Integer = Listaformato(0)("id_destino")
        If wid_destino = 1 Then Exit Sub ' NO ENVIA NADA

        Dim wid_negocio As Integer

        wid_negocio = lk_NegocioActivo.id_Negocio


        Dim sql As String = "exec [sp_muestra_comprobante] @id_negocio, @id_oper_maestro, @id_comp_cab"
        Dim command As New SqlCommand(sql, lk_connection_cuenta)
        command.Parameters.AddWithValue("@id_negocio", wid_negocio)
        command.Parameters.AddWithValue("@id_oper_maestro", wid_oper_maestro)
        command.Parameters.AddWithValue("@id_comp_cab", wid_comp_cab)

        Dim adapter As New SqlDataAdapter(command)
        Dim loc_datos_comp As New DataTable()
        adapter.Fill(loc_datos_comp)

        dt_Enlace_Envio_Oper = Nothing

        If loc_datos_comp.Rows.Count = 0 Then
            Dim Result As String = MensajesBox.Show("No Existe Registros en su consulta.",
                                 "Muestra Comprobante.")
            Exit Sub
        End If

        dt_Enlace_Envio_Oper = loc_datos_comp

        Envia_formato(dt_Enlace_Envio_Oper, Val(TxtOperacion.Tag), wcodigo)

    End Sub

    Private Sub Envia_formato(dt_Enlace_Envio_Oper As DataTable, wid_tb_oper As Integer, wcodigo_formato As String)
        If dt_Enlace_Envio_Oper Is Nothing Then
            Exit Sub
        End If
        Dim Listaformato() As DataRow = loc_sql_lista_formato.Select("id_tb_oper =  " & wid_tb_oper & " and codigo = '" & wcodigo_formato & "'")
        ' Recorremos las filas filtradas
        If Listaformato.Length = 0 Then
            Dim Result = MensajesBox.Show("Comprobante no tiene asignado Formato de impresion.",
                                     "Operación.")
            Exit Sub
        End If
        '================================
        ' Destino:
        ' 1- no imprime
        ' 2- impresora
        ' 3- panrtalla
        ' 4- PDF
        ' formato:
        ' 1- 56
        ' 2- 80
        ' 3- a4
        '================================

        Dim wid_destino As Integer = Listaformato(0)("id_destino")
        If wid_destino = 1 Then Exit Sub ' NO ENVIA NADA


        Dim wid_formato As Integer = Listaformato(0)("id_formato")
        Dim wimp1 As String = Listaformato(0)("impresora1")
        Dim wimp2 As String = Listaformato(0)("impresora2")
        Dim wimp3 As String = Listaformato(0)("impresora3")
        Dim wnrocopias As String = Listaformato(0)("id_copias")
        Dim warchivo56 As String = Listaformato(0)("archivo56")
        Dim warchivo80 As String = Listaformato(0)("archivo80")
        Dim warchivoA4 As String = Listaformato(0)("archivoA4")





        Dim frformato As New FrmFormatosCR

        frformato.TopLevel = False
        frformato.DataSeleccion = dt_Enlace_Envio_Oper
        frformato.LOC_NOMBRE_IMPRESORA = wimp1
        frformato.LOC_ID_FORMATO = wid_formato
        frformato.LOC_ID_DESTINO = wid_destino
        frformato.LOC_COPIAS = wnrocopias
        If wid_formato = 1 Then '56
            frformato.LOC_NOMBRE_ARCHIVO = warchivo56
        ElseIf wid_formato = 2 Then '80
            frformato.LOC_NOMBRE_ARCHIVO = warchivo80
        ElseIf wid_formato = 3 Then 'a4
            frformato.LOC_NOMBRE_ARCHIVO = warchivoA4
        Else
            frformato.LOC_NOMBRE_ARCHIVO = ""
        End If


        frformato.TituloInforme = CmdComprob.Text.Trim & " " & TxtSerireComp.Text & " " & TxtComp_Numero.Text
        FrmLogin.PanelFormularios.Controls.Add(frformato)
        FrmLogin.PanelFormularios.Controls.Item(FrmLogin.PanelFormularios.Controls.Count - 1).BringToFront() ' Ultimo Fomulario a primer plano
        frformato.Show()
        If frformato.ES_CIERRE_FORMATO = 1 Then
            frformato.Close()
        Else
            SelectNextControl(ActiveControl, True, True, True, True)
            frformato.Focus()
        End If


    End Sub
    Private Sub carga_lista_formatos()
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter

        Dim sql_cade As String = "select  * from [dbo].[vw_formatos] where id_negocio = " & lk_NegocioActivo.id_Negocio & " and id_usuario = " & lk_id_usuario & " and equipo = '" & LK_NOMBRE_PC & "'"
        ''--Select Case* from [confg_grid] where id_negocio  = " & lk_NegocioActivo.id_Negocio & " order by id_tb_oper , orden" ' filtro para buscar por el id : id_oper_maestro
        loc_sql_lista_formato = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        adaptador = New SqlDataAdapter(Command)
        adaptador.Fill(loc_sql_lista_formato)

    End Sub
    Private Sub dg_cuentasn_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_cuentasn.CellContentClick

    End Sub

    Private Sub dg_cuentasn_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dg_cuentasn.CellValidating
        Calcula_CTASN1(1)
    End Sub

    Private Sub GridProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridProductos.CellContentClick

    End Sub

    Private Sub dg_cuentasn_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles dg_cuentasn.PreviewKeyDown
        If dg_cuentasn.Rows(dg_cuentasn.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then Exit Sub
        If e.KeyCode = Keys.Enter And dg_cuentasn.Focused Then ' Verificar si se ha presionado la tecla "Delete" en el DataGridView
            If dg_cuentasn.CurrentCell Is Nothing Then Exit Sub
            Dim columnIndex As Integer = dg_cuentasn.CurrentCell.ColumnIndex ' Obtener el índice de la columna actual
            Dim columnName As String = dg_cuentasn.Columns(columnIndex).Name ' Obtener el nombre de la columna actual
            Dim rowIndex As Integer = dg_cuentasn.CurrentCell.RowIndex ' Obtener el índice de la fila actual
            'Dim rowTag As Object = GridProductos.Rows(rowIndex).Tag ' Obtener el contenido del tag de la fila actual
            Dim rowTag As Object = dg_cuentasn.Rows(rowIndex).Cells("eli").Tag ' Obtener el contenido del tag de la celda actual

            If columnName = "eli" Then
                If dg_cuentasn.Rows(dg_cuentasn.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then
                    Exit Sub
                End If

                If dg_cuentasn.Rows.Count - 1 = 0 Then
                    dg_cuentasn.Rows.Clear()
                    ' GridLoteProductos_Inicia()
                    Me.dg_cuentasn.Rows.Add()
                    Contador_filas_cuentaSN()
                    Exit Sub
                End If
                dg_cuentasn.Rows.Remove(dg_cuentasn.CurrentRow) ' Eliminar la primera fila seleccionada

                Me.dg_cuentasn.CurrentCell = dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("masdetalle")
                Me.dg_cuentasn.BeginEdit(True)
                Contador_filas_cuentaSN()
            End If
            If columnName = "add" Then ' Verificar que se haya seleccionado alguna fila
                If dg_cuentasn.Rows(rowIndex).Cells("add").Tag = "" Then Exit Sub
                Me.dg_cuentasn.Rows.Add()

                Me.dg_cuentasn.CurrentCell = dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("masdetalle")
                Me.dg_cuentasn.BeginEdit(True)
                Contador_filas_cuentaSN()
                'GridProductos_PrimeraFila()
            End If
            If columnName = "ok" Then ' Verificar que se haya seleccionado alguna fila
                'ConfirmaTodoLote()
                'GridProductos_PrimeraFila()
            End If





            'If columnName = "eli" Then

            '    If rowTag = "add" Then ' Verificar que se haya seleccionado alguna fila

            '        Me.GridProductos.Rows.Add()
            '        If Me.GridProductos.Tag = "PROD1" Then
            '            Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle")
            '            Me.GridProductos.BeginEdit(True)
            '            Contador_filas()
            '        End If

            '        'GridProductos_PrimeraFila()
            '    ElseIf rowTag = "eli" Then
            '        If GridProductos.Rows(GridProductos.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then
            '            Exit Sub
            '        End If
            '        GridProductos.Rows.Remove(GridProductos.CurrentRow) ' Eliminar la primera fila seleccionada
            '        If Me.GridProductos.Tag = "PROD1" Then
            '            Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle")
            '            Me.GridProductos.BeginEdit(True)
            '        End If

            '    End If
            'End If







        End If

    End Sub

    Private Sub dg_cuentasn_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dg_cuentasn.RowsAdded
        Contador_filas_cuentaSN()
    End Sub

    Private Sub dg_cuentasn_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dg_cuentasn.RowsRemoved
        Contador_filas_cuentaSN()
    End Sub

    Private Sub CmdActualizarComp_Click(sender As Object, e As EventArgs) Handles CmdActualizarComp.Click
        ' ================================================
        If ENLACE_TIPO Is Nothing Then

        Else
            If ENLACE_TIPO = "1" Then
                ' If ENLACE_ENVIO_OPER_CODIGO Is Nothing Then
                ' Else
                '     Enlace_Envio_Oper(ENLACE_ENVIO_DATA_COMP, ENLACE_ENVIO_OPER_CODIGO)
                ' End If
            ElseIf ENLACE_TIPO = "2" Then
                Muestra_Comprobante(lk_NegocioActivo.id_Negocio, ENLACE_MUESTRA_id_oper_maestro, ENLACE_MUESTRA_id_comp_cabe)
            End If
        End If
    End Sub

    Private Sub CmdActualizarComp_MouseHover(sender As Object, e As EventArgs) Handles CmdActualizarComp.MouseHover
        tt_leyenda.SetToolTip(CmdActualizarComp, "Actualiza Estado " & Chr(13) & "Comprobante") ' Reemplaza "MiBoton" con el nombre real de tu botón y "Texto del tooltip" con el texto que deseas mostrar en el tooltip

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub

    Private Sub CmdFinanzas_Click(sender As Object, e As EventArgs) Handles CmdFinanzas.Click
        ' validamos si tienen acceso para fiannzas y control de pagos
        Dim controlLabel As Label




        Traer_Datos_ControlCajas(lk_NegocioActivo.id_Negocio)

        Dim Local() As DataRow = lk_sql_ListaControlCajas.Select("id_usuario = '" & lk_id_usuario & "'")
        ' Recorremos las filas filtradas
        If Local.Length = 0 Then
            Dim Result = MensajesBox.Show("Su Usuario no tiene acceso Control Caja.",
                                     "Control ed Caja.")
            Exit Sub
        End If

        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        If Obtener_id_oper_maestro.Count = 0 Then
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            Exit Sub
        End If

        'Enlace_signo_entidad = 1
        Dim frFinanzas As New FrmOperFinanzas
        ' frlote.TextoBusca = valorlote
        Dim ws_fn_directo_id_oper_maestro As Integer = 0
        Dim ws_fn_directo_id_tb_oper As Integer = 0
        ws_fn_directo_id_oper_maestro = Val(Obtener_id_oper_maestro(0)("fn_directo_id_oper_maestro"))
        ws_fn_directo_id_tb_oper = Val(Obtener_id_oper_maestro(0)("fn_directo_id_tb_oper"))
        If ws_fn_directo_id_oper_maestro <> 0 Then

            Dim Finanzas_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & ws_fn_directo_id_tb_oper & " and id_oper_maestro = " & ws_fn_directo_id_oper_maestro & " ")
            If Finanzas_id_oper_maestro.Count = 0 Then
                SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
                Exit Sub
            End If
            frFinanzas.Enlace_signo_entidad = Finanzas_id_oper_maestro(0)("signo_finanzas")
        Else
            frFinanzas.Enlace_signo_entidad = Obtener_id_oper_maestro(0)("signo_finanzas")
        End If



        frFinanzas.FORM_id_local = Val(CmdLocal.Tag)
        frFinanzas.FORM_Lista_Cajas = Local
        frFinanzas.FORM_Estado = ""
        frFinanzas.FORM_id_moneda = Val(CmdMonedaComp.Tag)
        frFinanzas.FORM_Tipo_Balance = Val(Obtener_id_oper_maestro(0)("id_tb_tipo_balance"))
        frFinanzas.FORM_es_aplica_nc = Val(Obtener_id_oper_maestro(0)("es_aplica_nc"))





        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "subtotal" AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            Dim wtotal As Double = Val(controlLabel.Tag)
            If wtotal = 0 Then
                SMS_Barra("Monto debe ser Mayor a 0.00 para aplicar a Finanzas...", 2)
                Exit Sub
            End If
            frFinanzas.FORM_monto_aplicar = wtotal
        End If


        If TxtDetallefn.AccessibleName = "bloq" Then
            Dim ws_resultadofn As String = TxtDetallefn.AccessibleDescription
            frFinanzas.FORM_Estado = "bloq"
            If ws_resultadofn <> "" Then frFinanzas.FORM_DatosFinanzas_Temp = Obtener_Detalle_fn(ws_resultadofn)
        Else
            frFinanzas.FORM_DatosFinanzas_Temp = dt_DatosFinanzas_oper
            frFinanzas.FORM_DatosFinanzas_NC_Temp = dt_DatosFinanzas_NC


        End If

        If frFinanzas.ShowDialog() = DialogResult.OK Then
            Dim dt_DatosAgrupados As New DataTable
            TxtDetallefn.Tag = frFinanzas.FORM_valor_total
            TxtDetallefn.Text = frFinanzas.FORM_Cadena_contenidos
            TxtDetallefn.Font = New Font("Courier New", TxtDetallefn.Font.Size)
            dt_DatosFinanzas_oper = frFinanzas.FORM_DataFianzas

            dt_DatosFinanzas_NC = frFinanzas.FORM_DataFianzas_nc



            'MsgBox(dt_DatosFinanzas_oper.Rows(0).Item("total"))
            CmdGrabar.Enabled = True
            CmdAanularOper.Enabled = False

        End If

    End Sub

    Private Sub dg_cuentasn_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_cuentasn.CellClick
        Dim columnName As String = dg_cuentasn.Columns(e.ColumnIndex).Name ' Obtener el nombre de la columna actual
        If columnName = "buscarcomp" Then

            Dim frBusSaldos As New FrmSaldosSN
            ' frlote.TextoBusca = valorlote


            frBusSaldos.FORM_tipo_balance = Val(dg_cuentasn.AccessibleDescription)

            If frBusSaldos.ShowDialog() = DialogResult.OK Then
                Dim tabla As New DataTable
                tabla = frBusSaldos.DataSeleccion
                Dim wid As Integer = dg_cuentasn.CurrentCell.RowIndex


                For j = 0 To tabla.Rows.Count - 1
                    For i = 0 To dg_cuentasn.Rows.Count - 1
                        If dg_cuentasn.Rows(i).Cells("id_oper_maestro").Value = tabla.Rows(j).Item("id_oper_maestro") And
                        dg_cuentasn.Rows(i).Cells("id_comp_cab").Value = tabla.Rows(j).Item("id_comp_cab") And
                        dg_cuentasn.Rows(i).Cells("id_carterasn_cab").Value = tabla.Rows(j).Item("id_carterasn_cab") And
                        dg_cuentasn.Rows(i).Cells("id_carterasn_det").Value = tabla.Rows(j).Item("id_carterasn_det") Then

                            Dim Result = MensajesBox.Show("Documento Existe en la Lista ." & vbCrLf &
                                                     tabla.Rows(j).Item("codcomp") & " " & tabla.Rows(j).Item("numerocomp") & " - " & tabla.Rows(j).Item("seriecomp"),
                                                            "Operación.")
                            Exit Sub
                        End If
                    Next i

                Next j


                For i = 0 To tabla.Rows.Count - 1
                    dg_cuentasn.Rows(wid).Cells("codigo").Value = tabla.Rows(i).Item("codigo").ToString.Trim
                    dg_cuentasn.Rows(wid).Cells("descrip").Value = tabla.Rows(i).Item("descrip").ToString.Trim
                    dg_cuentasn.Rows(wid).Cells("masdetalle").Value = "..." 'tabla.Rows(0).Item("Codigo").ToString
                    dg_cuentasn.Rows(wid).Cells("fechaemis").Value = Format(tabla.Rows(i).Item("fechaemis"), "dd/MM/yyyy")
                    dg_cuentasn.Rows(wid).Cells("local").Value = tabla.Rows(i).Item("local").ToString.Trim
                    dg_cuentasn.Rows(wid).Cells("moneda").Value = tabla.Rows(i).Item("moneda")
                    dg_cuentasn.Rows(wid).Cells("monto").Value = tabla.Rows(i).Item("monto")
                    dg_cuentasn.Rows(wid).Cells("saldo").Value = tabla.Rows(i).Item("saldo")
                    dg_cuentasn.Rows(wid).Cells("fechavcto").Value = Format(tabla.Rows(i).Item("fechavcto"), "dd/MM/yyyy")
                    dg_cuentasn.Rows(wid).Cells("condicion").Value = tabla.Rows(i).Item("condicion")
                    dg_cuentasn.Rows(wid).Cells("vendedor").Value = ""
                    dg_cuentasn.Rows(wid).Cells("aplicar").Value = tabla.Rows(i).Item("aplicar")
                    dg_cuentasn.Rows(wid).Cells("hecho").Value = tabla.Rows(i).Item("hecho") '  & " " & tabla.Rows(i).Item("nombres").ToString.Trim & " " & tabla.Rows(0).Item("apellidos").ToString.Trim
                    dg_cuentasn.Rows(wid).Cells("fechahora").Value = tabla.Rows(i).Item("fechahora")

                    dg_cuentasn.Rows(wid).Cells("id_oper_maestro").Value = tabla.Rows(i).Item("id_oper_maestro")
                    dg_cuentasn.Rows(wid).Cells("id_comp_cab").Value = tabla.Rows(i).Item("id_comp_cab")
                    dg_cuentasn.Rows(wid).Cells("id_carterasn_cab").Value = tabla.Rows(i).Item("id_carterasn_cab")
                    dg_cuentasn.Rows(wid).Cells("id_carterasn_det").Value = tabla.Rows(i).Item("id_carterasn_det")

                    dg_cuentasn.Rows(wid).Cells("codcomp").Value = tabla.Rows(i).Item("codcomp")
                    dg_cuentasn.Rows(wid).Cells("seriecomp").Value = tabla.Rows(i).Item("seriecomp")
                    dg_cuentasn.Rows(wid).Cells("numerocomp").Value = tabla.Rows(i).Item("numerocomp")
                    dg_cuentasn.Rows(wid).Cells("signo_sn").Value = tabla.Rows(i).Item("signo_sn")

                    dg_cuentasn.Rows.Add()

                    wid = wid + 1

                Next i
                Calcula_CTASN1(1)
            End If


        End If

        If columnName = "vercomp" Then
            If Val(dg_cuentasn.Rows(e.RowIndex).Cells("id_oper_maestro").Value) = 0 Then Exit Sub
            Dim wenlace_id_negocio As Integer = lk_NegocioActivo.id_Negocio
            Dim wenlace_id_oper_maestro As Integer = dg_cuentasn.Rows(e.RowIndex).Cells("id_oper_maestro").Value
            Dim wenlace_id_comp_cab As String = dg_cuentasn.Rows(e.RowIndex).Cells("id_comp_cab").Value
            Dim wcodigooper As String = dg_cuentasn.Rows(e.RowIndex).Cells("oper_codigo").Value
            Muestras_EnlacesComp(wenlace_id_negocio, wcodigooper, wenlace_id_oper_maestro, wenlace_id_comp_cab)
        End If
    End Sub

    Private Sub CmdAlmTransf_Click(sender As Object, e As EventArgs) Handles CmdAlmTransf.Click

        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub
        If Val(TxtOperacion.Tag) = 0 Then
            Exit Sub
        End If

        Dim DatoAlmacen() As DataRow = lk_sql_Usuario_almacen.Select("id_negocio = " & lk_NegocioActivo.id_Negocio & "")

        If DatoAlmacen.Length = 0 Then
            Result = MensajesBox.Show("No Tiene almacenes con acceso.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In DatoAlmacen
            Dim id As Integer = CInt(row("id_almacen"))
            Dim detalle As String = CStr(row("alm_codigo") & " " & row("alm_abreviado") & " - " & row("alm_nombre"))
            Dim codigo As String = CStr(row("alm_codigo"))
            Dim abreviado As String = CStr(Space(10) & row("alm_abreviado").ToString.Trim)

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       Mostrar_AlmTrasnsferencia(id, detalle, codigo, abreviado)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdAlmTransf, New Point(0, CmdAlmTransf.Height))
    End Sub
    Private Sub Mostrar_AlmTrasnsferencia(id As Integer, detalle As String, codigo As String, abreviado As String)
        TxtAlmTransf.Text = codigo
        TxtAlmTransf.Tag = id

        CmdAlmTransf.Text = abreviado
        CmdAlmTransf.Tag = id


    End Sub

    Private Sub TxtAlmTransf_TextChanged(sender As Object, e As EventArgs) Handles TxtAlmTransf.TextChanged

    End Sub

    Private Sub TxtAlmTransf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtAlmTransf.KeyPress
        Solo_Numero(e)

        If e.KeyChar = Chr(13) Then
            If MostrarDatosAlmacenTransf(TxtAlmTransf.Text) = False Then
                SMS_Barra("No Existe Codigo de Almacen...", 2)
                TxtAlmTransf.SelectAll()
                Exit Sub
            End If
        End If



    End Sub
    Private Function MostrarDatosAlmacenTransf(wcodigo As String) As Boolean
        MostrarDatosAlmacenTransf = True

        Dim DatoAlmacen() As DataRow = lk_sql_Usuario_almacen.Select("id_negocio = " & lk_NegocioActivo.id_Negocio & " and alm_codigo = " & wcodigo & "")
        If DatoAlmacen.Length = 0 Then
            MostrarDatosAlmacenTransf = False
        Else
            TxtAlmTransf.Text = DatoAlmacen(0)("alm_codigo").ToString.Trim
            TxtAlmTransf.Tag = DatoAlmacen(0)("id_almacen")
            CmdAlmTransf.Text = DatoAlmacen(0)("alm_codigo").ToString.Trim & " " & DatoAlmacen(0)("alm_abreviado").ToString.Trim
            CmdAlmTransf.Tag = DatoAlmacen(0)("id_almacen")

        End If


    End Function

    Private Sub CmdClonarOper_Click(sender As Object, e As EventArgs) Handles CmdClonarOper.Click
        If ENLACE_TIPO <> 2 Then Exit Sub


        Dim wenlace_id_negocio As Integer = lk_NegocioActivo.id_Negocio
        Dim wenlace_id_oper_maestro As Integer = ENLACE_MUESTRA_id_oper_maestro
        Dim wenlace_id_comp_cab As String = ENLACE_MUESTRA_id_comp_cabe
        Dim wcodigooper As String = TxtOperacion.Text

        Muestras_EnlacesComp(wenlace_id_negocio, wcodigooper, wenlace_id_oper_maestro, wenlace_id_comp_cab)



    End Sub

    Private Sub TxtOperacion_TextChanged(sender As Object, e As EventArgs) Handles TxtOperacion.TextChanged

    End Sub

    Private Sub CmdConsultaReg_Click(sender As Object, e As EventArgs) Handles CmdConsultaReg.Click
        'If Val(CmdConsultaReg.Tag) <> 0 Then
        CmdConsultaReg.Enabled = False
        Mover_por_Operaciones(False, False, True)
        CmdConsultaReg.Enabled = True
        'End If

    End Sub

    Private Sub CmdConsultaReg_Sig_Click(sender As Object, e As EventArgs) Handles CmdConsultaReg_Sig.Click
        ' If Val(CmdConsultaReg.Tag) <> 0 Then
        CmdConsultaReg_Sig.Enabled = False
        Mover_por_Operaciones(False, True, False)
        CmdConsultaReg_Sig.Enabled = True
        'End If


    End Sub

    Private Sub Mover_por_Operaciones(es_ultimo As Boolean, es_sig As Boolean, es_atras As Boolean)
        Dim wid_oper_maestro As Integer
        Dim wid_comp_cab As Integer = 0




        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter
        Dim wcade_filtro_oper As String = ""

        If Val(TxtOperacion.Tag) = 0 Then Exit Sub  ' no hay operacion activa

        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        If Obtener_id_oper_maestro.Count = 0 Then
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            Exit Sub
        End If
        Dim frCargainfo As New FrmCarga
        frCargainfo.LogoMuestra.Visible = False
        frCargainfo.LogoSolicdo.Visible = True
        frCargainfo.Show()
        wid_oper_maestro = Obtener_id_oper_maestro(0)("id_oper_maestro")

        If es_ultimo Then
            sql_cade = "select  top 1 id_comp_cab from m_comprobantes_cab where id_negocio = @id_negocio  and id_oper_maestro = " & wid_oper_maestro & " and estado <> 10  order by id_comp_cab desc "
            command = New SqlCommand(sql_cade, lk_connection_cuenta)
            parametro = New SqlParameter("@id_negocio", lk_NegocioActivo.id_Negocio)
            command.Parameters.Add(parametro)
            adaptador = New SqlDataAdapter(command)
            Dim dt_Datosultimo As New DataTable
            adaptador.Fill(dt_Datosultimo)
            If dt_Datosultimo.Rows.Count = 0 Then
                SMS_Barra("NO Existe Operación Registrada...", 3)
                frCargainfo.Close()
                Exit Sub
            End If
            'CmdConsultaReg.AccessibleName = wid_oper_maestro
            'CmdConsultaReg.Tag = dt_Datosultimo.Rows(0).Item("id_comp_cab").ToString
            wid_comp_cab = Val(dt_Datosultimo.Rows(0).Item("id_comp_cab").ToString())
        ElseIf es_sig Then

            If Val(ENLACE_MUESTRA_id_comp_cabe) <> 0 Then
                wid_oper_maestro = ENLACE_MUESTRA_id_oper_maestro
                'CmdConsultaReg.Tag = ENLACE_MUESTRA_id_comp_cabe + 1
                wid_comp_cab = Val(ENLACE_MUESTRA_id_comp_cabe) + 1
            End If
        ElseIf es_atras Then
            If Val(ENLACE_MUESTRA_id_comp_cabe) <> 0 Then
                wid_oper_maestro = ENLACE_MUESTRA_id_oper_maestro
                'CmdConsultaReg.Tag = ENLACE_MUESTRA_id_comp_cabe + 1
                wid_comp_cab = Val(ENLACE_MUESTRA_id_comp_cabe) - 1
            End If
            '            wid_oper_maestro = Val(CmdConsultaReg.AccessibleName)
            '            CmdConsultaReg.Tag = Val(CmdConsultaReg.Tag) - 1
            '           wid_comp_cab = Val(CmdConsultaReg.Tag)

        End If
        ' wid_comp_cab = Val(dt_Datosultimo.Rows(0).Item("id_comp_cab").ToString)
        Muestra_Comprobante(lk_NegocioActivo.id_Negocio, wid_oper_maestro, wid_comp_cab)
        frCargainfo.Close()
    End Sub
    Private Sub GridProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridProductos.CellDoubleClick
        If e.ColumnIndex = GridProductos.Columns("add").Index AndAlso e.RowIndex >= 0 Then
            SendKeys.Send("{ENTER}")
        End If
        If e.ColumnIndex = GridProductos.Columns("eli").Index AndAlso e.RowIndex >= 0 Then

            SendKeys.Send("{ENTER}")
        End If
    End Sub

    Private Sub CmdCostosVinc_Click(sender As Object, e As EventArgs) Handles CmdCostosVinc.Click
        If Val(CmdCostosVinc.Tag) = "0" Then
            CmdCostosVinc.Text = "ASIGNAR COSTOS VINCULADOS"
            CmdCostosVinc.Tag = "1"
        Else
            CmdCostosVinc.Text = "COSTOS VINCULADOS S/ 50,00.00"
            CmdCostosVinc.Tag = "0"
        End If


    End Sub

    Private Sub chkConIMPTO_CheckedChanged(sender As Object, e As EventArgs) Handles chkConIMPTO.CheckedChanged
        If chkConIMPTO.Checked Then
            AsignarModoCalculo_GridPROD1(1)
            Calcula_PROD1(Val(GridProductos.AccessibleDescription))
        End If
        If chkSinIMPTO.Checked Then
            AsignarModoCalculo_GridPROD1(2)
            Calcula_PROD1(Val(GridProductos.AccessibleDescription))
        End If
        GridProductos.Select()

    End Sub

    Private Sub chkSinIMPTO_CheckedChanged(sender As Object, e As EventArgs) Handles chkSinIMPTO.CheckedChanged
        If chkConIMPTO.Checked Then AsignarModoCalculo_GridPROD1(1)
        If chkSinIMPTO.Checked Then AsignarModoCalculo_GridPROD1(2)
    End Sub
    Private Function listaprecio_atexto(wid_negocio As Integer, wid_moneda As Integer, wid_prod_mae As Integer, wid_pres As Integer, wid_local As Integer) As String()

        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter
        Dim dt_DatosConsulta_Prod As DataTable


        sql_cade = "select id_precio, abreviado , descripcion , valor_precio, valor_precio_min 
        from  [vw_lista_precios_producto]    where id_negocio = @wid_negocio and   id_moneda = @wid_moneda and id_prod_mae = @wid_prod_mae and 
        id_presentacion = @wid_pres and id_local = @wid_local"
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        parametro = New SqlParameter("@wid_negocio", wid_negocio)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@wid_moneda", wid_moneda)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@wid_prod_mae", wid_prod_mae)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@wid_pres", wid_pres)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@wid_local", wid_local)
        command.Parameters.Add(parametro)
        adaptador = New SqlDataAdapter(command)
        dt_DatosConsulta_Prod = New DataTable
        adaptador.Fill(dt_DatosConsulta_Prod)
        Dim retorna(1) As String

        Dim wpre_pordefcto As String = ""

        Dim resultado As New StringBuilder()

        For Each row As DataRow In dt_DatosConsulta_Prod.Rows
            Dim id_precio As Integer = CInt(row("id_precio"))
            Dim abreviado As String = row("abreviado").ToString()
            Dim descripcion As String = row("descripcion").ToString()
            Dim valor_precio As Decimal = CDec(row("valor_precio"))
            Dim valor_precio_min As Decimal = CDec(row("valor_precio_min"))
            If wpre_pordefcto = "" Then wpre_pordefcto = row("valor_precio")
            ' Concatenar los valores de cada columna en el formato deseado
            resultado.Append($"{id_precio}#{abreviado}#{descripcion}#{valor_precio}#{valor_precio_min}:")
        Next
        ' Eliminar el último ":" que sobra
        If resultado.Length > 0 Then
            resultado.Length -= 1
        End If

        retorna(0) = resultado.ToString()
        retorna(1) = wpre_pordefcto

        Return retorna




    End Function
    Private Function listaprecio_atabla(texto As String) As DataTable

        Dim dt As New DataTable()

        ' Definir las columnas de la DataTable
        dt.Columns.Add("id_precio", GetType(Integer))
        dt.Columns.Add("abreviado", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("valor_precio", GetType(Decimal))
        dt.Columns.Add("valor_precio_min", GetType(Decimal))

        ' Separar las filas utilizando ":"
        Dim filas As String() = texto.Split(":"c)

        ' Recorrer cada fila
        For Each fila As String In filas
            ' Separar las columnas utilizando "#"
            Dim columnas As String() = fila.Split("#"c)

            ' Crear una nueva fila en la DataTable y agregar los valores
            If columnas.Length = 5 Then
                Dim newRow As DataRow = dt.NewRow()
                newRow("id_precio") = Integer.Parse(columnas(0))
                newRow("abreviado") = columnas(1)
                newRow("descripcion") = columnas(2)
                newRow("valor_precio") = Decimal.Parse(columnas(3))
                newRow("valor_precio_min") = Decimal.Parse(columnas(4))

                dt.Rows.Add(newRow)
            End If
        Next

        Return dt
    End Function
    Private Sub MuestraListaPrecios(wdataprecios As DataTable, wfila As Integer, wcol As Integer)
        'adaptador.Fill(lk_sql_Presentaciones)


        'adaptador.Fill(lk_sql_TipoPres

        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' Dim temp_finanzas As DataTable = lk_sql_finanzas_local.Copy()

        Dim ListaPrecios() As DataRow = wdataprecios.Select("id_precio <> 0")
        If ListaPrecios.Length = 0 Then
            Result = MensajesBox.Show("No Tiene Definido Lista de Precios.",
                                     "Operación.")
            Exit Sub
        End If


        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.WhiteSmoke
        Dim maxDescripcionLength As Integer = 15 ' ListaPresentacion.Max(Function(item) item("descripcion").ToString().Length)
        Dim maxAbreviadoLength As Integer = 10 'ListaPresentacion.Max(Function(item) item("abreviado").ToString().Trim().Length)
        Dim maxEquivLength As Integer = 5 'ListaPresentacion.Max(Function(item) item("equiv").ToString().Length)
        Dim maxPrecio As Integer = 10
        Dim maxPrecioMin As Integer = 10
        Dim maxid_precio As Integer = 10

        For i = 0 To ListaPrecios.Length - 1
            Dim wid_precio As String = ListaPrecios(i)("id_precio")
            Dim wabreviado As String = ListaPrecios(i)("abreviado").ToString.Trim
            Dim wdescripcion As String = ListaPrecios(i)("descripcion").ToString().Trim()
            Dim wvalor_precio As String = Format(ListaPrecios(i)("valor_precio"), "0.00")
            Dim wvalor_precio_min As String = Format(ListaPrecios(i)("valor_precio_min"), "0.00")


            Dim formattedId_precio As String = wdescripcion.PadRight(maxid_precio)
            Dim formattedDescripcion As String = wdescripcion.PadRight(maxDescripcionLength)
            Dim formattedAbreviado As String = wabreviado.PadRight(maxAbreviadoLength)
            Dim formattedPrecio As String = wvalor_precio.PadRight(maxPrecio)
            Dim formattedPrecioMin As String = wvalor_precio.PadRight(maxPrecioMin)

            Dim wdes As String = $"{formattedDescripcion} {formattedAbreviado} {formattedPrecio}"

            Dim item As New ToolStripMenuItem(wdes)
            AddHandler item.Click, Sub()
                                       Menu_Precios(wfila, wid_precio, wabreviado, wdes, wdescripcion, wvalor_precio, wvalor_precio_min)

                                   End Sub
            menu.Items.Add(item)
        Next
        For Each item In menu.Items
            Dim menuItem As ToolStripMenuItem = TryCast(item, ToolStripMenuItem)
            If menuItem IsNot Nothing Then
                menuItem.Font = New Font("Courier New", menuItem.Font.Size)
            End If
        Next



        Dim row As Integer = wfila  ' Número de fila deseado
        Dim column As Integer = wcol ' Número de columna deseado

        Dim cell As DataGridViewCell = GridProductos.Rows(row).Cells(column)
        Dim cellBounds As Rectangle = GridProductos.GetCellDisplayRectangle(column, row, False)
        Dim cellPosition As Point = GridProductos.PointToScreen(New Point(cellBounds.Left, cellBounds.Bottom))

        menu.Show(cellPosition)
    End Sub
    Private Sub Menu_Precios(wfila As Integer, wid_precio As Integer, wabreviado As String, wdes As String, wdescripcion As String, wvalor_precio As String, wvalor_precio_min As String)
        'Dim wdif_id As Integer = Val(GridProductos.Rows(wfila).Cells("id_presentacion").Value)
        'If Existe_Presentacion(wid, wdif_id) Then
        '    Dim Result As String = MensajesBox.Show("Presentación," & wdescripcion.Trim & " Existe en el producto.",
        '                            "Presentaciones.")
        '    Exit Sub
        'End If
        GridProductos.Rows(wfila).Cells("preciobase").Value = wvalor_precio
        Calcula_PROD1(Val(GridProductos.AccessibleDescription))
        'GridProductos.Rows(we.RowIndex).Cells("presentacion").Value = wdescripcion.Trim
        'GridProductos.Rows(we.RowIndex).Cells("abreviado").Value = wabre
        'GridProductos.Rows(we.RowIndex).Cells("equiv").Value = wequiv
        'GridProductos.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid


    End Sub
    Private Sub GridProductos_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles GridProductos.CellLeave

        Dim valorCelda As Object = GridProductos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

        Dim nombreColumna As String = GridProductos.Columns(e.ColumnIndex).Name
        If nombreColumna = "present" Or nombreColumna = "codigo" Then
            ' Verifica que si ya se extrayo la lista y se guarda en la columna 
            If Val(GridProductos.Rows(e.RowIndex).Cells("id_pres").Value) = Val(GridProductos.Rows(e.RowIndex).Cells("id_pres_precio").Value) Then
            Else
                Dim cadena_precios As String() = listaprecio_atexto(lk_NegocioActivo.id_Negocio, Val(CmdMonedaComp.Tag), Val(GridProductos.Rows(e.RowIndex).Cells("id_prod_mae").Value), Val(GridProductos.Rows(e.RowIndex).Cells("id_pres").Value), Val(CmdLocal.Tag))
                GridProductos.Rows(e.RowIndex).Cells("id_pres_precio").Value = Val(GridProductos.Rows(e.RowIndex).Cells("id_pres").Value)
                GridProductos.Rows(e.RowIndex).Cells("cadenaprecios").Value = cadena_precios(0)
                GridProductos.Rows(e.RowIndex).Cells("preciobase").Value = Val(cadena_precios(1))
                Marca_Stock_Disponible(e.RowIndex)
                '
                ' datos de stock 
                If chkConIMPTO.Checked Then
                    AsignarModoCalculo_GridPROD1(1)
                    Calcula_PROD1(Val(GridProductos.AccessibleDescription))
                End If
                If chkSinIMPTO.Checked Then
                    AsignarModoCalculo_GridPROD1(2)
                    Calcula_PROD1(Val(GridProductos.AccessibleDescription))
                End If
            End If

        End If
    End Sub
    Private Sub Marca_Stock_Disponible(wfila As Integer)
        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        Estado_Operacion_OperMaestro(True)
        If Obtener_id_oper_maestro.Count = 0 Then
            Estado_Operacion_OperMaestro(False)
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)

            Exit Sub
        End If
        Dim wes_inventario As Integer = Obtener_id_oper_maestro(0)("es_inventario")
        Dim wsigno_kardex As Integer = Obtener_id_oper_maestro(0)("signo_inventario")
        Dim wdirecto_id_tb_oper As Integer = Obtener_id_oper_maestro(0)("directo_id_tb_oper")
        Dim wdirecto_id_oper_maestro As Integer = Obtener_id_oper_maestro(0)("directo_id_oper_maestro")

        If wdirecto_id_tb_oper <> 0 Then
            Dim Obtener_id_oper_maestro_INV() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & wdirecto_id_tb_oper & " and id_oper_maestro = " & wdirecto_id_oper_maestro & "")
            If Obtener_id_oper_maestro_INV.Count = 0 Then
                Estado_Operacion_OperMaestro(False)
                SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
                Exit Sub
            End If
            wes_inventario = Obtener_id_oper_maestro_INV(0)("es_inventario")
            wsigno_kardex = Obtener_id_oper_maestro_INV(0)("signo_inventario")
        End If


        If wsigno_kardex <> -1 Then
            GridProductos.Rows(wfila).Cells("es_sin_stock").Value = 0
            Exit Sub
        End If
        Dim ws_cantid As Double = GridProductos.Rows(wfila).Cells("cantidad").Value
        Dim ws_equiv As Double = GridProductos.Rows(wfila).Cells("equiv").Value
        Dim ws_stock As Double = GridProductos.Rows(wfila).Cells("stockactual").Value
        Dim wsaldost As Double = ws_stock - (ws_cantid * ws_equiv)
        GridProductos.Rows(wfila).Cells("es_sin_stock").Value = 0
        If wsaldost < 0 Then
            GridProductos.Rows(wfila).Cells("es_sin_stock").Value = 1
        End If
    End Sub

    Private Sub LinkConfImp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkConfImp.LinkClicked
        Dim frimp As New FrmFormatosOper
        ' frlote.TextoBusca = valorlote

        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " And id_tb_sub_oper = " & CmdSubOper.Tag & " And id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        If Obtener_id_oper_maestro.Count = 0 Then
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            Exit Sub
        End If
        Dim wid_tb_oper As Integer = Obtener_id_oper_maestro(0)("id_tb_oper")
        Dim wid_almacen_transf As Integer = Val(CmdAlmTransf.Tag)


        frimp.Local_detalle_oper = CmdOperacion.Text & " - " & CmdSubOper.Text & " - " & CmdTipoOper.Text
        frimp.Local_id_tb_oper = wid_tb_oper
        If frimp.ShowDialog() = DialogResult.OK Then
            carga_lista_formatos()
        End If
    End Sub


    Private Sub Bloqueo_Estado_Box(wcodigoestado As Integer)
        Dim wbooaccesto As Boolean = True
        If wcodigoestado = 1 Then
            wbooaccesto = False
            BoxEstado.AccessibleName = "bloq"
        Else
            wbooaccesto = True
            BoxEstado.AccessibleName = ""
        End If

        Dim wpos As String = ""
        Dim wpos_x As Integer = 0
        Dim wpos_y As Integer = 0
        Dim wprimer_enfoque As String = ""
        'Dim Result As String
        Dim wtag_control As String
        Dim PanelBox As Panel
        Dim ListaOperacionBox() As DataRow = lk_sql_listaOperBox.Select("CodigoOper = '" & TxtOperacion.Text & "'", "orden ASC")
        ' Recorremos las filas filtradas




        ' Panel de Cabecera buscar controles 
        For i = 0 To ListaOperacionBox.Length - 1
            wtag_control = ListaOperacionBox(i)("codigo_box")
            PanelBox = PanelCabecera.Controls.OfType(Of Panel).FirstOrDefault(Function(c) c.Tag = wtag_control)
            If PanelBox IsNot Nothing Then
                PanelBox.Enabled = wbooaccesto
                If wprimer_enfoque = "" Then wprimer_enfoque = wtag_control
            End If
        Next
        BoxEstado.Enabled = True
        If BoxEntidadF.Visible Then BoxEntidadF.Enabled = True



    End Sub

    Private Sub CmdInicialNum_Click(sender As Object, e As EventArgs) Handles CmdInicialNum.Click
        CmdInicialNum.Enabled = False
        Mover_por_Operaciones(True, False, False)
        CmdInicialNum.Enabled = True

    End Sub

    Private Sub TxtDetallefn_TextChanged(sender As Object, e As EventArgs) Handles TxtDetallefn.TextChanged

    End Sub

    Private Sub TxtDetallefn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDetallefn.KeyPress
        e.Handled = True
    End Sub

    Private Sub CmdAccFN_Click(sender As Object, e As EventArgs) Handles CmdAccFN.Click
        CmdFinanzas_Click(Nothing, Nothing)
    End Sub

    Private Sub dg_cuentasn_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dg_cuentasn.CellValueChanged


    End Sub

    Private Sub FrmOperaciones_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then
            ' El formulario se ha minimizado
            ' Puedes realizar acciones específicas aquí
            'Stop
        ElseIf Me.WindowState = FormWindowState.Normal Then
            ' El formulario se ha restaurado a su estado normal
            ' Puedes realizar acciones específicas aquí
            If Me.Visible Then Me.Size = formSize



            'Stop
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            ' El formulario se ha maximizado
            ' Puedes realizar acciones específicas aquí
            'Stop
        End If

    End Sub

    Private Sub GridProductos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles GridProductos.CellFormatting
        PintaGridProductos(sender, e)


    End Sub
    Private Sub PintaGridProductos(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 0 AndAlso GridProductos.Columns(e.ColumnIndex).Name = "saldo_pend" Then
            ' Verifica si la columna actual es la columna "saldo_pend"
            Dim cell As DataGridViewCell = GridProductos.Rows(e.RowIndex).Cells(e.ColumnIndex)
            If lk_modoOscuro Then
                cell.Style.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorModoVerde)
            Else
                cell.Style.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorAmarillo)
            End If

        End If


        If e.RowIndex >= 0 AndAlso GridProductos.Columns(e.ColumnIndex).Name = "subtotal" Then
            If GridProductos.Rows(e.RowIndex).Cells("es_prod_bof").Value Then
                If e.Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(e.Value.ToString()) Then
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorModoTurquesa)
                    e.CellStyle.ForeColor = Color.Black
                End If
            End If
        End If
    End Sub
    Private Sub cambio_almacen_grid()
        If GridProductos.Visible Then
            For i = 0 To GridProductos.Rows.Count - 1
                If Oper_Almacen_Defecto.id_almacen <> 0 Then
                    GridProductos.Rows(i).Cells("almacen").Value = Oper_Almacen_Defecto.codigo
                    GridProductos.Rows(i).Cells("alm_abreviado").Value = Oper_Almacen_Defecto.abreviado
                    GridProductos.Rows(i).Cells("lote").Value = ""
                    GridProductos.Rows(i).Cells("cadenalotes").Value = ""
                    GridProductos.Rows(i).Cells("cadenalotes_formato").Value = ""
                    GridProductos.Rows(i).Cells("lote").Value = ""
                    GridProductos.Rows(i).Cells("det_lote").Value = "Pulsar [F2] ver detalle Lotes/Serie"
                    GridProductos.Rows(i).Cells("id_almacen").Value = Oper_Almacen_Defecto.id_almacen
                Else
                    GridProductos.Rows(i).Cells("almacen").Value = ""
                    GridProductos.Rows(i).Cells("alm_abreviado").Value = ""
                    GridProductos.Rows(i).Cells("cadenalotes").Value = ""
                    GridProductos.Rows(i).Cells("cadenalotes_formato").Value = ""
                    GridProductos.Rows(i).Cells("lote").Value = ""
                    GridProductos.Rows(i).Cells("det_lote").Value = "Digitar Codigo de Almacen"
                    GridProductos.Rows(i).Cells("id_almacen").Value = 0
                End If
            Next i
        End If


    End Sub

    Private Sub GridProductos_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GridProductos.RowEnter

    End Sub
    Private Sub GridProductos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles GridProductos.CurrentCellDirtyStateChanged
        If GridProductos.IsCurrentCellDirty Then
            GridProductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If


    End Sub
    Private Sub Prepara_Columnas_NuevoProducto(wes_activo As Boolean, wrow As Integer)


        If wes_activo Then
            GridProductos.Rows(wrow).Cells("grupo").Value = "NUEVO PRODUCTO"
            GridProductos.Rows(wrow).Cells("descrip").Value = ""
            GridProductos.Rows(wrow).Cells("masdetalle").Value = ""
            GridProductos.Rows(wrow).Cells("equiv").Value = 1
            GridProductos.Rows(wrow).Cells("Codigo").Value = ""
            GridProductos.Rows(wrow).Cells("id_prod_mae_codigo").Value = ""


            GridProductos.Rows(wrow).Cells("id_prod_mae").Value = 1
            GridProductos.Rows(wrow).Cells("Unidades").Value = ""
            GridProductos.Rows(wrow).Cells("present").Value = ""
            Dim comboCell As DataGridViewComboBoxCell = CType(GridProductos.Rows(wrow).Cells("present"), DataGridViewComboBoxCell)
            comboCell.Items.Clear()
            GridProductos.Rows(wrow).Cells("id_pres").Value = 0
            GridProductos.Rows(wrow).Cells("lote").Value = ""
            GridProductos.Rows(wrow).Cells("det_lote").Value = ""
            GridProductos.CurrentCell = GridProductos.Rows(wrow).Cells("descrip")
            GridProductos.BeginEdit(True)
            Contador_filas()
        Else
            GridProductos.Rows(wrow).Cells("grupo").Value = ""
            GridProductos.Rows(wrow).Cells("descrip").Value = ""
            GridProductos.Rows(wrow).Cells("masdetalle").Value = ""
            GridProductos.Rows(wrow).Cells("equiv").Value = 0
            GridProductos.Rows(wrow).Cells("Unidades").Value = ""
            GridProductos.Rows(wrow).Cells("Codigo").Value = ""
            GridProductos.Rows(wrow).Cells("id_prod_mae_codigo").Value = ""


            GridProductos.Rows(wrow).Cells("id_prod_mae").Value = 0
            GridProductos.Rows(wrow).Cells("present").Value = ""
            Dim comboCell As DataGridViewComboBoxCell = CType(GridProductos.Rows(wrow).Cells("present"), DataGridViewComboBoxCell)
            comboCell.Items.Clear()
            GridProductos.Rows(wrow).Cells("id_pres").Value = 0
            GridProductos.Rows(wrow).Cells("lote").Value = ""
            GridProductos.Rows(wrow).Cells("det_lote").Value = ""
            GridProductos.CurrentCell = GridProductos.Rows(wrow).Cells("Codigo")
            GridProductos.BeginEdit(True)
        End If



    End Sub

    Private Sub GridProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridProductos.CellClick


        If e.ColumnIndex = GridProductos.Columns("masdetalle").Index AndAlso e.RowIndex >= 0 Then
            'Dim valorCelda As String = dg_grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            'Dim wd_forma As Integer = dg_grid.Rows(e.RowIndex).Cells("descrip_tipo").Tag
            'Muestra_MENU_TipoPres(e)



            Dim FrRProd As New FrmRefProd
            If Radio_Serv.Checked Then
                FrRProd.REF_NOMBRE_PRODUCTO = GridProductos.Rows(e.RowIndex).Cells("detalle_serv").Value
                If Not IsDBNull(GridProductos.Rows(e.RowIndex).Cells("masdetalle").Tag) Then
                    FrRProd.REF_CONTENIDO = GridProductos.Rows(e.RowIndex).Cells("masdetalle").Tag
                End If
                FrRProd.REF_ESTADO = GridProductos.Rows(e.RowIndex).Cells("ok").Tag
            Else
                FrRProd.REF_NOMBRE_PRODUCTO = GridProductos.Rows(e.RowIndex).Cells("descrip").Value
                If Not IsDBNull(GridProductos.Rows(e.RowIndex).Cells("masdetalle").Tag) Then
                    FrRProd.REF_CONTENIDO = GridProductos.Rows(e.RowIndex).Cells("masdetalle").Tag
                End If
                FrRProd.REF_ESTADO = GridProductos.Rows(e.RowIndex).Cells("ok").Tag
            End If


            If FrRProd.ShowDialog() = DialogResult.OK Then
                GridProductos.Rows(e.RowIndex).Cells("masdetalle").Tag = FrRProd.REF_CONTENIDO
                If Radio_Serv.Checked Then
                    GridProductos.Rows(e.RowIndex).Cells("detalle_serv").Value = FrRProd.REF_CONTENIDO
                End If
            End If


        End If

        If e.ColumnIndex = GridProductos.Columns("lote").Index AndAlso e.RowIndex >= 0 Then
            AsignaLoteProducto(0)
        End If


        If e.ColumnIndex = GridProductos.Columns("preciolista").Index AndAlso e.RowIndex >= 0 Then
            SendKeys.Send("{F2}")
        End If



        If e.ColumnIndex = GridProductos.Columns("tipo_serv_des").Index AndAlso e.RowIndex >= 0 Then
            'Dim valorCelda As String = dg_grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            'Dim wd_forma As Integer = dg_grid.Rows(e.RowIndex).Cells("descrip_tipo").Tag
            Muestra_MENU_ServTipo(e)
        End If
        If e.ColumnIndex = GridProductos.Columns("des_serv").Index AndAlso e.RowIndex >= 0 Then
            'Dim valorCelda As String = dg_grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            'Dim wd_forma As Integer = dg_grid.Rows(e.RowIndex).Cells("descrip_tipo").Tag
            Muestra_MENU_Servicio(e)
        End If


        If e.ColumnIndex = GridProductos.Columns("area_serv_des").Index AndAlso e.RowIndex >= 0 Then
            'Dim valorCelda As String = dg_grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            'Dim wd_forma As Integer = dg_grid.Rows(e.RowIndex).Cells("descrip_tipo").Tag
            Muestra_MENU_Areas(e)

        End If



        If e.ColumnIndex = GridProductos.Columns("uci_serv_des").Index AndAlso e.RowIndex >= 0 Then
            'Dim valorCelda As String = dg_grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            'Dim wd_forma As Integer = dg_grid.Rows(e.RowIndex).Cells("descrip_tipo").Tag
            Muestra_MENU_UCI(e)

        End If

    End Sub
    Private Sub Muestra_MENU_UCI(we As DataGridViewCellEventArgs)


        Dim Result As String
        'Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        If lk_sql_lista_uci.Rows.Count = 0 Then
            Result = MensajesBox.Show("Areas, No definidas.",
                                     "Operaciones.")
            Exit Sub

        End If

        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White

        Dim itemTodos As New ToolStripMenuItem("")
        AddHandler itemTodos.Click, Sub()
                                        GridProductos.Rows(we.RowIndex).Cells("id_uci").Value = 0
                                        GridProductos.Rows(we.RowIndex).Cells(we.ColumnIndex).Value = ""
                                        GridProductos.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = 0
                                    End Sub
        menu.Items.Add(itemTodos)



        For I = 0 To lk_sql_lista_uci.Rows.Count - 1
            Dim wid As Integer = lk_sql_lista_uci.Rows(I).Item("id_uci").ToString
            Dim wdes As String = lk_sql_lista_uci.Rows(I).Item("descripcion").ToString
            Dim wdes_abre As String = lk_sql_lista_uci.Rows(I).Item("abreviado").ToString
            Dim item As New ToolStripMenuItem(wdes)
            AddHandler item.Click, Sub()
                                       Muestra_UCI(we, wid, wdes, wdes_abre)
                                   End Sub
            menu.Items.Add(item)
        Next

        Dim row As Integer = we.RowIndex
        Dim column As Integer = we.ColumnIndex

        Dim cell As DataGridViewCell = GridProductos.Rows(row).Cells(column)
        Dim cellBounds As Rectangle = GridProductos.GetCellDisplayRectangle(column, row, False)
        Dim cellPosition As Point = GridProductos.PointToScreen(New Point(cellBounds.Left, cellBounds.Bottom))

        menu.Show(cellPosition)


        '        menu.Show(CmdMonedaComp, New Point(0, CmdMonedaComp.Height))
    End Sub
    Private Sub Muestra_UCI(we As DataGridViewCellEventArgs, wid As Integer, wdes As String, wdes_abre As String)


        GridProductos.Rows(we.RowIndex).Cells("id_uci").Value = wid
        GridProductos.Rows(we.RowIndex).Cells(we.ColumnIndex).Value = wdes_abre
        GridProductos.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid


        'dg_finanzas.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid_tb_formas_fn

    End Sub
    Private Sub Muestra_MENU_Areas(we As DataGridViewCellEventArgs)


        Dim Result As String
        'Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        If lk_sql_areas_neg.Rows.Count = 0 Then
            Result = MensajesBox.Show("Areas, No definidas.",
                                     "Operaciones.")
            Exit Sub

        End If

        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White

        For I = 0 To lk_sql_areas_neg.Rows.Count - 1
            Dim wid As Integer = lk_sql_areas_neg.Rows(I).Item("id_tb").ToString
            Dim wdes As String = lk_sql_areas_neg.Rows(I).Item("descripcion").ToString
            Dim item As New ToolStripMenuItem(wdes)
            AddHandler item.Click, Sub()
                                       Muestra_AREAS(we, wid, wdes)
                                   End Sub
            menu.Items.Add(item)
        Next

        Dim row As Integer = we.RowIndex
        Dim column As Integer = we.ColumnIndex

        Dim cell As DataGridViewCell = GridProductos.Rows(row).Cells(column)
        Dim cellBounds As Rectangle = GridProductos.GetCellDisplayRectangle(column, row, False)
        Dim cellPosition As Point = GridProductos.PointToScreen(New Point(cellBounds.Left, cellBounds.Bottom))

        menu.Show(cellPosition)


        '        menu.Show(CmdMonedaComp, New Point(0, CmdMonedaComp.Height))
    End Sub
    Private Sub Muestra_AREAS(we As DataGridViewCellEventArgs, wid As Integer, wdes As String)


        GridProductos.Rows(we.RowIndex).Cells("id_area").Value = wid
        GridProductos.Rows(we.RowIndex).Cells(we.ColumnIndex).Value = wdes
        GridProductos.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid


        'dg_finanzas.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid_tb_formas_fn

    End Sub
    Private Sub Muestra_MENU_Servicio(we As DataGridViewCellEventArgs)

        'adaptador.Fill(lk_sql_Presentaciones)


        'adaptador.Fill(lk_sql_TipoPres

        Dim Result As String
        'Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' Dim temp_finanzas As DataTable = lk_sql_finanzas_local.Copy()
        Dim w_tiposerv As Integer = GridProductos.Rows(we.RowIndex).Cells("id_tb_tipo_serv").Value

        'Dim ListaServicio() As DataRow = lk_sql_servicios_mae.Select("id_serv <> 0 and id_tb_tipo_serv = " & w_tiposerv & "")

        Dim filasFiltradas() As DataRow = lk_sql_servicios_mae.Select("id_serv <> 0 and id_tb_tipo_serv = " & w_tiposerv, "orden ASC, des_serv ASC")
        Dim ListaServicio() As DataRow = filasFiltradas

        If ListaServicio.Length = 0 Then
            Result = MensajesBox.Show("Local , No Tiene Almaces.",
                                     "Almacenes.")
            Exit Sub

        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante





        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White

        For I = 0 To ListaServicio.Length - 1
            Dim wid As Integer = ListaServicio(I)("id_serv")
            Dim wcodigo As String = ListaServicio(I)("codigo_serv")
            Dim wdes As String = ListaServicio(I)("des_serv")
            Dim wdes_abre As String = ListaServicio(I)("abre_serv")

            Dim item As New ToolStripMenuItem(wdes)
            AddHandler item.Click, Sub()
                                       Muestra_Servicios(we, wid, wcodigo, wdes, wdes_abre)
                                   End Sub
            menu.Items.Add(item)
        Next

        Dim row As Integer = we.RowIndex
        Dim column As Integer = we.ColumnIndex

        Dim cell As DataGridViewCell = GridProductos.Rows(row).Cells(column)
        Dim cellBounds As Rectangle = GridProductos.GetCellDisplayRectangle(column, row, False)
        Dim cellPosition As Point = GridProductos.PointToScreen(New Point(cellBounds.Left, cellBounds.Bottom))

        menu.Show(cellPosition)


        '        menu.Show(CmdMonedaComp, New Point(0, CmdMonedaComp.Height))
    End Sub
    Private Sub Muestra_Servicios(we As DataGridViewCellEventArgs, wid As Integer, wcodigo As String, wdes As String, wdes_abre As String)


        GridProductos.Rows(we.RowIndex).Cells("id_serv").Value = wid
        GridProductos.Rows(we.RowIndex).Cells("codigo_serv").Value = wcodigo
        GridProductos.Rows(we.RowIndex).Cells(we.ColumnIndex).Value = wdes_abre
        GridProductos.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid

        GridProductos.Rows(we.RowIndex).Cells("cantidad").Value = 1
        GridProductos.Rows(we.RowIndex).Cells("equiv").Value = 1
        GridProductos.Rows(we.RowIndex).Cells("present").Value = "SERV"
        GridProductos.Rows(we.RowIndex).Cells("id_pres").Value = 0
        GridProductos.Rows(we.RowIndex).Cells("cantidad_saldo").Value = 0



        'dg_finanzas.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid_tb_formas_fn

    End Sub

    Private Sub Muestra_MENU_ServTipo(we As DataGridViewCellEventArgs)



        Dim Result As String

        Dim menu_SubOper As New ToolStripDropDownMenu()


        Dim Obtener_id_oper_maestro() As DataRow = lk_sql_OperMaestro.Select("id_tb_oper = " & CmdOperacion.Tag & " and id_tb_sub_oper = " & CmdSubOper.Tag & " and id_tb_tipo_oper = " & CmdTipoOper.Tag & "")
        If Obtener_id_oper_maestro.Count = 0 Then
            SMS_Barra("Operacion con Error: No se Encontro el id_oper_maestro", 3)
            Exit Sub
        End If
        Dim w_tipo_bala As Integer = Obtener_id_oper_maestro(0)("id_tb_tipo_balance")




        Dim sql_filtro As DataTable = lk_sql_servicios_mae.Select("id_tb_tipo_balance = " & w_tipo_bala).CopyToDataTable()



        If sql_filtro.Rows.Count = 0 Then
            Result = MensajesBox.Show("No Tiene Definido Tipo de Servicios.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White



        ' Agrupa los datos por id_tb_tipo_serv y des_tipo_serv utilizando LINQ
        Dim grupos = From fila In sql_filtro.AsEnumerable()
                     Group By id_tb_tipo_serv = fila.Field(Of Integer)("id_tb_tipo_serv"),
                      des_tipo_serv = fila.Field(Of String)("des_tipo_serv"),
                      abre_tipo_serv = fila.Field(Of String)("abre_tipo_serv"),
                      codigo_tipo = fila.Field(Of String)("codigo_tipo")
        Into GrupoDatos = Group
                     Select New With {
                 .id_tb_tipo_serv = id_tb_tipo_serv,
                 .des_tipo_serv = des_tipo_serv,
                 .abre_tipo_serv = abre_tipo_serv,
                 .codigo_tipo = codigo_tipo,
                 .Filas = GrupoDatos.ToList()
             }

        ' Itera sobre los grupos resultantes
        For Each grupo In grupos
            'Console.WriteLine("ID: " & grupo.id_tb_tipo_serv)
            'Console.WriteLine("Descripción: " & grupo.des_tipo_serv)

            Dim wid As Integer = grupo.id_tb_tipo_serv
            Dim wcodigo As String = grupo.codigo_tipo
            Dim wdes As String = grupo.des_tipo_serv
            Dim wdes_abre As String = grupo.abre_tipo_serv


            Dim item As New ToolStripMenuItem(wdes)
            AddHandler item.Click, Sub()
                                       Muestra_TipoServicios(we, wid, wcodigo, wdes, wdes_abre)
                                   End Sub
            menu.Items.Add(item)

        Next


        'For i = 0 To lk_sql_servicios_mae.Rows.Count - 1

        '    Dim wid As String = lk_sql_servicios_mae.Rows(i).Item("id_tb_tipo_serv")
        '    Dim wdes As String = lk_sql_servicios_mae.Rows(i).Item("des_tipo_serv")

        '    Dim item As New ToolStripMenuItem(wdes)
        '    AddHandler item.Click, Sub()
        '                               Muestra_TipoServicios(we, wid, wdes)
        '                           End Sub
        '    menu.Items.Add(item)
        'Next

        Dim row As Integer = we.RowIndex  ' Número de fila deseado
        Dim column As Integer = we.ColumnIndex ' Número de columna deseado

        Dim cell As DataGridViewCell = GridProductos.Rows(row).Cells(column)
        Dim cellBounds As Rectangle = GridProductos.GetCellDisplayRectangle(column, row, False)
        Dim cellPosition As Point = GridProductos.PointToScreen(New Point(cellBounds.Left, cellBounds.Bottom))

        menu.Show(cellPosition)


        '        menu.Show(CmdMonedaComp, New Point(0, CmdMonedaComp.Height))
    End Sub
    Private Sub Muestra_TipoServicios(we As DataGridViewCellEventArgs, wid As Integer, wcodigo As String, wdes As String, wdes_abre As String)


        GridProductos.Rows(we.RowIndex).Cells("id_tb_tipo_serv").Value = wid
        GridProductos.Rows(we.RowIndex).Cells("tipo_serv_des").Value = wcodigo
        GridProductos.Rows(we.RowIndex).Cells(we.ColumnIndex).Value = wdes_abre
        GridProductos.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid


        'dg_finanzas.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid_tb_formas_fn

    End Sub

    Private Sub CmdActivarEdi_Click(sender As Object, e As EventArgs) Handles CmdActivarEdi.Click
        If CmdActivarEdi.Tag = "0" Then ' ir a Rutina de Activar la Edicion
            CmdActivarEdi.Text = "&GRABAR"
            CmdActivarEdi.Tag = 1
            cmdFormato.Enabled = False
            CmdAanularOper.Enabled = False
            'MsgBox("ACTIVA EDITAR")
        ElseIf CmdActivarEdi.Tag = "1" Then ' Ir Ruta para Grabar la Edicion
            CmdActivarEdi.Text = "&EDICION"
            CmdActivarEdi.Tag = 0
            cmdFormato.Enabled = True
            CmdAanularOper.Enabled = True
            'MsgBox("GRABA ")
        End If


    End Sub
    Private Sub Gestion_Columnas_PRO01(wes_servicio As Integer)
        If GridProductos.Columns.Count < 10 Then Exit Sub
        If wes_servicio = 0 Then
            If Radio_Prod.Checked And GridProductos.Columns.Item("detalle_serv").Visible Then
            Else
                Exit Sub
            End If
        End If
        If wes_servicio = 1 Then
            If Radio_Serv.Checked And GridProductos.Columns.Item("descrip").Visible Then
            Else
                Exit Sub
            End If
        End If


        If GridProductos.Visible And GridProductos.Columns.Count > 10 Then
        Else
            Exit Sub
        End If


        Dim wesvalor_col_serv As Boolean
        Dim wesvalor_col_prod As Boolean
        If wes_servicio = 1 Then
            wesvalor_col_serv = True
            wesvalor_col_prod = False

        Else
            wesvalor_col_serv = False
            wesvalor_col_prod = True
        End If



        'GridProductos.Visible = False
        GridProductos.Columns.Item("uci_serv_des").Visible = wesvalor_col_serv
        GridProductos.Columns.Item("codigo_local_serv").Visible = wesvalor_col_serv
        GridProductos.Columns.Item("des_local_serv").Visible = wesvalor_col_serv

        GridProductos.Columns.Item("area_serv_des").Visible = wesvalor_col_serv
        GridProductos.Columns.Item("codigo_serv").Visible = wesvalor_col_serv
        GridProductos.Columns.Item("des_serv").Visible = wesvalor_col_serv
        GridProductos.Columns.Item("tipo_serv_des").Visible = wesvalor_col_serv
        GridProductos.Columns.Item("detalle_serv").Visible = wesvalor_col_serv



        GridProductos.Columns.Item("es_prod_new").Visible = wesvalor_col_prod
        GridProductos.Columns.Item("grupo").Visible = wesvalor_col_prod
        GridProductos.Columns.Item("descrip").Visible = wesvalor_col_prod
        GridProductos.Columns.Item("Codigo").Visible = wesvalor_col_prod
        GridProductos.Columns.Item("cantidad").Visible = wesvalor_col_prod
        GridProductos.Columns.Item("present").Visible = wesvalor_col_prod
        GridProductos.Columns.Item("lote").Visible = wesvalor_col_prod
        GridProductos.Columns.Item("det_lote").Visible = wesvalor_col_prod

        'GridProductos.Visible = True
        GridProductos.Refresh()


    End Sub

    Private Sub Radio_Prod_CheckedChanged(sender As Object, e As EventArgs) Handles Radio_Prod.CheckedChanged
        If Radio_Prod.Checked Then
            Gestion_Columnas_PRO01(0)
            GridProductos_PrimeraFila()
        End If
    End Sub

    Private Sub Radio_Serv_CheckedChanged(sender As Object, e As EventArgs) Handles Radio_Serv.CheckedChanged
        If Radio_Serv.Checked Then
            Gestion_Columnas_PRO01(1)
            GridProductos_PrimeraFila()
        End If
    End Sub

    Private Sub Radio_Prod_Validating(sender As Object, e As CancelEventArgs) Handles Radio_Prod.Validating
        ' Realiza tu validación aquí

    End Sub

    Private Sub Radio_Prod_Click(sender As Object, e As EventArgs) Handles Radio_Prod.Click

    End Sub

    Private Sub Radio_Prod_Enter(sender As Object, e As EventArgs) Handles Radio_Prod.Enter
        ' Realiza tu validación aquí
        Dim wmodo As String
        If Radio_Prod.Checked Then
            wmodo = Radio_Prod.Text
        Else
            wmodo = Radio_Serv.Text
        End If
        Dim wtotal As Double = 0
        Dim controlLabel As Label
        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "subtotal" AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            wtotal = Val(controlLabel.Tag)
        End If
        If wtotal <> 0 Then
            Dim Result = MensajesBox.Show("Confirmar el cambio de modo " & wmodo & "  ?" & vbCrLf & "SE ELIMINARA EL CONTENIDO INGRESASO " & "
            ", "MODO DE REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If Result = "7" Or Result = "2" Then ' es NO
                'If Radio_Prod.Checked Then
                GridProductos.Select()
                Radio_Serv.Checked = True
                Radio_Prod.Checked = False
                'End If
                Exit Sub
            Else
                GridProductos.Select()
                Radio_Serv.Checked = False
                Radio_Prod.Checked = True
            End If
        End If

    End Sub

    Private Sub Radio_Serv_Enter(sender As Object, e As EventArgs) Handles Radio_Serv.Enter
        ' Realiza tu validación aquí
        Dim wmodo As String
        If Radio_Serv.Checked Then
            wmodo = Radio_Serv.Text
        Else
            wmodo = Radio_Serv.Text
        End If
        Dim wtotal As Double = 0
        Dim controlLabel As Label
        controlLabel = PanelPie.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.AccessibleName IsNot Nothing AndAlso c.AccessibleName.ToString() = "subtotal" AndAlso TypeOf c Is Label)
        If controlLabel IsNot Nothing Then
            wtotal = Val(controlLabel.Tag)
        End If
        If wtotal <> 0 Then
            Dim Result = MensajesBox.Show("Confirmar el cambio de modo " & wmodo & "  ?" & vbCrLf & "SE ELIMINARA EL CONTENIDO INGRESASO " & "
            ", "MODO DE REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If Result = "7" Or Result = "2" Then ' es NO
                'If Radio_Prod.Checked Then
                GridProductos.Select()
                Radio_Serv.Checked = False
                Radio_Prod.Checked = True
                'End If
                Exit Sub
            Else
                GridProductos.Select()
                Radio_Serv.Checked = True
                Radio_Prod.Checked = False
            End If
        End If

    End Sub

    Private Sub dg_cuentasn_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dg_cuentasn.CellEndEdit
        Dim ws_saldo As Double = Val(Math.Abs(dg_cuentasn.Rows(e.RowIndex).Cells("saldo").Value))

        If Val(dg_cuentasn.Rows(e.RowIndex).Cells("id_comp_cab").Value) <> 0 And Val(dg_cuentasn.Rows(e.RowIndex).Cells("aplicar").Value) > ws_saldo Then
            dg_cuentasn.Rows(e.RowIndex).Cells("aplicar").Value = ""
            Exit Sub
        End If
    End Sub

    Private Sub CmdConOper_Click(sender As Object, e As EventArgs) Handles CmdConOper.Click
    End Sub

    Private Sub Cmd_Canje_Tipos_Click(sender As Object, e As EventArgs) Handles Cmd_Canje_Tipos.Click
        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub
        If Val(TxtOperacion.Tag) = 0 Then
            Exit Sub
        End If

        Dim ListaComprobantes() As DataRow = lk_sql_TipoCanjes.Select("id_tb <> 0 ")
        ' Recorremos las filas filtradas
        If ListaComprobantes.Length = 0 Then
            Result = MensajesBox.Show("No Tiene Comprobantes Asociados a la Operacion.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaComprobantes
            Dim id As Integer = CInt(row("id_tb"))
            Dim descrip As String = CStr(row("descripcion"))
            Dim abreviado As String = CStr(Space(10) & row("abreviado").ToString.Trim)

            Dim item As New ToolStripMenuItem(abreviado.ToString.Trim() & " - " & descrip.ToString.Trim())
            AddHandler item.Click, Sub()
                                       MostrarTipoCanjes(id, descrip, abreviado)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(Cmd_Canje_Tipos, New Point(0, Cmd_Canje_Tipos.Height))


    End Sub
    Private Sub MostrarTipoCanjes(id As Integer, descrip As String, abreviado As String)
        'Aquí puedes reemplazar con tu código para realizar la acción correspondiente
        Cmd_Canje_Tipos.Text = abreviado.ToString.Trim() & " - " & descrip.ToString.Trim()
        Cmd_Canje_Tipos.Tag = id

    End Sub
    Private Sub MuestraBoxCanjes()
        Dim currentDate As DateTime = lk_fecha_dia
        BoxDocCanje.Visible = True
        Txt_canje_monto.Text = "0"
        Txt_canje_fecemi.Value = Format(currentDate, "dd/MM/yyyy")
        Txt_canje_cuotas.Text = "1"
        BoxDocCanje.Visible = True
        GridCuentasn_Inicia_DOC_CANJE(0, 0, 0)

    End Sub
    Private Sub Asigna_filas_canje(NroCuotas As Integer, wsmonto As Double, wfecEmis As DateTime, diacta As Integer)
        Dim wcuo As Double
        Dim wsuma As Double = 0
        Dim wajus As Double = 0
        Dim wfechavcto As DateTime
        Dim wacudias As Integer = 0
        Dim wconsultar As Integer = 0
        For i = 0 To dg_doc_canje.Rows.Count - 1
            If dg_doc_canje.Rows(i).Cells("flag_control").Value = "1" Then
                wconsultar = 1
            End If
        Next
        If wconsultar = 1 Then
            Dim wconfir As Integer = 0
            If Txt_canje_cuotas.Text <> Txt_canje_cuotas.Tag Then
                wconfir = 1
            End If
            If Txt_canje_monto.Tag <> Txt_canje_monto.Text Then
                wconfir = 1
            End If
            If Txt_canje_cuotas.Tag <> Txt_canje_cuotas.Text Then
                wconfir = 1
            End If
            If Format(Txt_canje_fecemi.Tag, "dd/MM/yyyy") <> Format(Txt_canje_fecemi.Value, "dd/MM/yyyy") Then
                wconfir = 1
            End If
            If Txt_diasletras.Tag <> Txt_diasletras.Text Then
                wconfir = 1
            End If
            If wconfir = 1 Then
                Dim Result = MensajesBox.Show("Realizo Cambio en sus Documentos de Canje, al contnuar se Inicializara la lista , continuar?" & vbCrLf & "
                ", "Lista de Documentos para Canje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                If Result = "7" Or Result = "2" Then ' es NO
                    Txt_canje_cuotas.Text = Txt_canje_cuotas.Tag
                    Txt_canje_monto.Text = Txt_canje_monto.Tag
                    Txt_canje_fecemi.Value = Txt_canje_fecemi.Tag
                    Txt_diasletras.Text = Txt_diasletras.Tag

                    Exit Sub
                Else

                End If
            Else
                Exit Sub
            End If

        End If




        dg_doc_canje.Rows.Clear()
        If NroCuotas = 0 Then Exit Sub
        If wsmonto = 0 Then Exit Sub
        If diacta = 0 Then Exit Sub
        wcuo = Format(wsmonto / NroCuotas, "0.00")
        wajus = Format(wsmonto - (wcuo * NroCuotas), "0.00")

        For i = 1 To NroCuotas
            wsuma = wsuma + wcuo

            wacudias = wacudias + diacta
            dg_doc_canje.Rows.Add()
            dg_doc_canje.Rows(dg_doc_canje.Rows.Count - 1).Cells("num").Value = (i).ToString()
            dg_doc_canje.Rows(dg_doc_canje.Rows.Count - 1).Cells("moneda").Value = CmdMonedaComp.AccessibleName
            If i = NroCuotas Then
                dg_doc_canje.Rows(dg_doc_canje.Rows.Count - 1).Cells("monto").Value = wcuo + wajus
            Else
                dg_doc_canje.Rows(dg_doc_canje.Rows.Count - 1).Cells("monto").Value = wcuo
            End If

            wfechavcto = wfecEmis.AddDays(wacudias)
            dg_doc_canje.Rows(dg_doc_canje.Rows.Count - 1).Cells("fechavcto").Value = Format(wfechavcto, "dd/MM/yyyy")
            dg_doc_canje.Rows(dg_doc_canje.Rows.Count - 1).Cells("diasem").Value = wfechavcto.ToString("dddd").ToUpper
            dg_doc_canje.Rows(dg_doc_canje.Rows.Count - 1).Cells("dias").Value = wacudias

        Next i
        Txt_canje_cuotas.Tag = NroCuotas
        Txt_canje_monto.Tag = wsmonto
        Txt_canje_fecemi.Tag = wfecEmis
        Txt_diasletras.Tag = diacta

    End Sub
    Private Sub GridCuentasn_Inicia_DOC_CANJE(wes_opcional_lote As Integer, es_condesc1 As Integer, es_condesc2 As Integer)
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()
        ' Dim controlLabel As Label





        dg_doc_canje.Columns.Clear()



        dg_doc_canje.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)

        textoColumn.Name = "num"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_doc_canje.Columns.Add(textoColumn)
        dg_doc_canje.Columns.Item(textoColumn.Name).Width = 25
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_doc_canje.Columns.Item(textoColumn.Name).ReadOnly = True





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "serie"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "SERIE"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_doc_canje.Columns.Add(textoColumn)
        dg_doc_canje.Columns.Item(textoColumn.Name).Width = 35
        dg_doc_canje.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "numero"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "NUMERO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_doc_canje.Columns.Add(textoColumn)
        dg_doc_canje.Columns.Item(textoColumn.Name).Width = 50
        dg_doc_canje.Columns.Item(textoColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "MOD"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_doc_canje.Columns.Add(textoColumn)
        dg_doc_canje.Columns.Item(textoColumn.Name).Width = 30
        dg_doc_canje.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "monto"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MONTO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_doc_canje.Columns.Add(textoColumn)
        dg_doc_canje.Columns.Item(textoColumn.Name).Width = 70
        dg_doc_canje.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "dias"
        textoColumn.Tag = "E3"
        textoColumn.HeaderText = "DIAS"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_doc_canje.Columns.Add(textoColumn)
        dg_doc_canje.Columns.Item(textoColumn.Name).Width = 35
        dg_doc_canje.Columns.Item(textoColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fechavcto"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "FEC.VCTO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_doc_canje.Columns.Add(textoColumn)
        dg_doc_canje.Columns.Item(textoColumn.Name).Width = 75
        dg_doc_canje.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "diasem"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "DIA"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_doc_canje.Columns.Add(textoColumn)
        dg_doc_canje.Columns.Item(textoColumn.Name).Width = 70
        dg_doc_canje.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "ref"
        textoColumn.Tag = "A200"
        textoColumn.HeaderText = "REFERENC."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_doc_canje.Columns.Add(textoColumn)
        dg_doc_canje.Columns.Item(textoColumn.Name).Width = 70
        dg_doc_canje.Columns.Item(textoColumn.Name).ReadOnly = False



        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "masdetalle"
        BotonColumn.HeaderText = "..."
        BotonColumn.FlatStyle = FlatStyle.Flat
        BotonColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_doc_canje.Columns.Add(BotonColumn)
        dg_doc_canje.Columns.Item(BotonColumn.Name).Width = 25



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "oper_codigo"
        textoColumn.HeaderText = "oper_codigo"
        dg_doc_canje.Columns.Add(textoColumn)
        dg_doc_canje.Columns.Item(textoColumn.Name).Width = 0
        dg_doc_canje.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "flag_control"
        textoColumn.HeaderText = "flag_control"
        dg_doc_canje.Columns.Add(textoColumn)
        dg_doc_canje.Columns.Item(textoColumn.Name).Visible = False


    End Sub

    Private Sub Txt_canje_cuotas_TextChanged(sender As Object, e As EventArgs) Handles Txt_canje_cuotas.TextChanged

    End Sub

    Private Sub Txt_canje_cuotas_Leave(sender As Object, e As EventArgs) Handles Txt_canje_cuotas.Leave
        Dim wcuotas As Integer = Val(Txt_canje_cuotas.Text)
        Dim wsmonto As Double = Val(Txt_canje_monto.Text)
        Dim wfecEmis As DateTime = TxtFechas_Emis.Value
        Dim diacta As Integer = Val(Txt_diasletras.Text)
        Asigna_filas_canje(wcuotas, wsmonto, wfecEmis, diacta)

    End Sub

    Private Sub dg_doc_canje_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_doc_canje.CellContentClick

    End Sub

    Private Sub dg_doc_canje_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dg_doc_canje.CellEndEdit
        Dim currentValuetext As String
        Dim wfechaok As DateTime = Now
        If dg_doc_canje.Columns(e.ColumnIndex).Name = "fechavcto" Then
            Dim cell As DataGridViewCell = Me.dg_doc_canje(e.ColumnIndex, e.RowIndex)
            currentValuetext = dg_doc_canje.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If currentValuetext Is Nothing Then
                dg_doc_canje.CancelEdit()
                Exit Sub
            End If

            If currentValuetext.Length = 5 Or currentValuetext.Length = 7 Then
                Dim parts() As String = currentValuetext.Split("/"c) 'Dividir el valor en dos partes: mes y año
                If parts.Count = 2 Then
                Else
                    cell.Value = ""
                    Exit Sub
                End If
                If Integer.Parse(parts(0)) >= 1 And Integer.Parse(parts(0)) <= 12 Then
                Else
                    cell.Value = ""
                    Exit Sub
                End If
                If Integer.Parse(parts(1)) >= 1900 And Integer.Parse(parts(1)) <= 3000 Then
                ElseIf Integer.Parse(parts(1)) >= 10 And Integer.Parse(parts(1)) <= 99 Then
                    parts(1) = Val(parts(1)) + 2000
                Else
                    cell.Value = ""
                    dg_doc_canje.Rows(e.RowIndex).Cells("diasem").Value = ""
                    dg_doc_canje.Rows(e.RowIndex).Cells("dias").Value = ""
                    dg_doc_canje.Rows(e.RowIndex).Cells("flag_control").Value = "1"
                    Exit Sub
                End If
                'Dim parts() As String = currentValuetext.Split("/"c) 'Dividir el valor en dos partes: mes y año
                Dim month As Integer = Integer.Parse(parts(0)) 'Obtener el mes como un entero
                Dim year As Integer = Integer.Parse(parts(1))  'Obtener el año como un entero

                Dim lastDay As Integer = DateTime.DaysInMonth(year, month) 'Obtener el último día del mes correspondiente

                Dim fechaCompleta As New DateTime(year, month, lastDay) 'Crear un objeto DateTime con el último día del mes
                Dim formattedDate As String = fechaCompleta.ToString("dd/MM/yyyy") 'Convertir la fecha en formato "dd/MM/yyyy"

                cell.Value = formattedDate 'Asignar el valor a la celda del DataGridView
                wfechaok = formattedDate
            Else
                Dim inputString As String = currentValuetext
                Dim formats As String() = {"dd/MM/yyyy", "dd/MM/yy"}
                Dim parsedDate As DateTime
                If DateTime.TryParseExact(inputString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
                    ' La cadena tiene formato de fecha válido
                Else
                    cell.Value = ""
                    dg_doc_canje.Rows(e.RowIndex).Cells("diasem").Value = ""
                    dg_doc_canje.Rows(e.RowIndex).Cells("dias").Value = ""
                    dg_doc_canje.Rows(e.RowIndex).Cells("flag_control").Value = "1"
                    Exit Sub
                End If
                wfechaok = currentValuetext
            End If
            Dim wfechaemi As DateTime = Txt_canje_fecemi.Value
            If (wfechaok - wfechaemi).Days < 0 Then
                cell.Value = ""
                dg_doc_canje.Rows(e.RowIndex).Cells("diasem").Value = ""
                dg_doc_canje.Rows(e.RowIndex).Cells("dias").Value = ""
                dg_doc_canje.Rows(e.RowIndex).Cells("flag_control").Value = "1"
                Exit Sub
            End If
            dg_doc_canje.Rows(e.RowIndex).Cells("dias").Value = (wfechaok - wfechaemi).Days
            dg_doc_canje.Rows(e.RowIndex).Cells("diasem").Value = wfechaok.ToString("dddd").ToUpper
            dg_doc_canje.Rows(e.RowIndex).Cells("flag_control").Value = "1"

        End If
        If dg_doc_canje.Columns(e.ColumnIndex).Name = "dias" Then
            Dim wfechaemi As DateTime = Txt_canje_fecemi.Value
            currentValuetext = Val(dg_doc_canje.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
            If currentValuetext > 0 And currentValuetext < 1000 Then
            Else
                dg_doc_canje.Rows(e.RowIndex).Cells("diasem").Value = ""
                dg_doc_canje.Rows(e.RowIndex).Cells("dias").Value = ""
                dg_doc_canje.Rows(e.RowIndex).Cells("fechavcto").Value = ""
                dg_doc_canje.Rows(e.RowIndex).Cells("flag_control").Value = "1"
                Exit Sub
            End If
            wfechaok = wfechaemi.AddDays(currentValuetext)
            dg_doc_canje.Rows(e.RowIndex).Cells("fechavcto").Value = Format(wfechaok, "dd/MM/yyyy")
            dg_doc_canje.Rows(e.RowIndex).Cells("diasem").Value = wfechaok.ToString("dddd").ToUpper
            dg_doc_canje.Rows(e.RowIndex).Cells("flag_control").Value = "1"
        End If
        If dg_doc_canje.Columns(e.ColumnIndex).Name = "serie" Or dg_doc_canje.Columns(e.ColumnIndex).Name = "numero" Then
            dg_doc_canje.Rows(e.RowIndex).Cells("flag_control").Value = "1"
        End If

    End Sub

    Private Sub Txt_canje_cuotas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_canje_cuotas.KeyPress
        Solo_Numero(e)
    End Sub

    Private Sub Txt_canje_monto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_canje_monto.KeyPress
        Solo_TextoNumero(e)
    End Sub


    Private Sub Txt_diasletras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_diasletras.KeyPress
        Solo_Numero(e)
    End Sub

    Private Sub Txt_canje_monto_TextChanged(sender As Object, e As EventArgs) Handles Txt_canje_monto.TextChanged

    End Sub

    Private Sub Txt_canje_monto_Leave(sender As Object, e As EventArgs) Handles Txt_canje_monto.Leave
        Dim wcuotas As Integer = Val(Txt_canje_cuotas.Text)
        Dim wsmonto As Double = Val(Txt_canje_monto.Text)
        Dim wfecEmis As DateTime = TxtFechas_Emis.Value
        Dim diacta As Integer = Val(Txt_diasletras.Text)
        Asigna_filas_canje(wcuotas, wsmonto, wfecEmis, diacta)
    End Sub

    Private Sub Txt_diasletras_TextChanged(sender As Object, e As EventArgs) Handles Txt_diasletras.TextChanged

    End Sub

    Private Sub Txt_diasletras_Leave(sender As Object, e As EventArgs) Handles Txt_diasletras.Leave
        Dim wcuotas As Integer = Val(Txt_canje_cuotas.Text)
        Dim wsmonto As Double = Val(Txt_canje_monto.Text)
        Dim wfecEmis As DateTime = TxtFechas_Emis.Value
        Dim diacta As Integer = Val(Txt_diasletras.Text)
        Asigna_filas_canje(wcuotas, wsmonto, wfecEmis, diacta)
    End Sub

    Private Sub Txt_canje_fecemi_ValueChanged(sender As Object, e As EventArgs) Handles Txt_canje_fecemi.ValueChanged

    End Sub

    Private Sub Txt_canje_fecemi_Leave(sender As Object, e As EventArgs) Handles Txt_canje_fecemi.Leave
        Dim wcuotas As Integer = Val(Txt_canje_cuotas.Text)
        Dim wsmonto As Double = Val(Txt_canje_monto.Text)
        Dim wfecEmis As DateTime = Txt_canje_fecemi.Value
        Dim diacta As Integer = Val(Txt_diasletras.Text)
        Asigna_filas_canje(wcuotas, wsmonto, wfecEmis, diacta)
    End Sub

    Private Sub CmdSN_fin_Click(sender As Object, e As EventArgs) Handles CmdSN_fin.Click

        info_SN.SelectionStart = TextBox1.Text.Length
        info_SN.ScrollToCaret()
    End Sub

    Private Sub CmdSN_inicio_Click(sender As Object, e As EventArgs) Handles CmdSN_inicio.Click
        info_SN.SelectionStart = 0
        info_SN.ScrollToCaret()
    End Sub

    Private Sub CmdOpcionesLC_Click(sender As Object, e As EventArgs) Handles CmdOpcionesLC.Click
        Dim codigos() As String = {"1", "-1"}
        Dim nombres() As String = {"AUMENTAR", "DISMINUIR"}

        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White

        For i As Integer = 0 To codigos.Length - 1
            Dim codigo As String = codigos(i)
            Dim nombre As String = nombres(i)

            Dim item As New ToolStripMenuItem(nombre)
            item.Tag = codigo ' Puedes asignar el código como valor de la propiedad Tag del elemento de menú

            ' Agregar un controlador de eventos para el evento Click del elemento de menú
            AddHandler item.Click, Sub()
                                       ' Acción a realizar cuando se hace clic en el elemento de menú
                                       'Dim menuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
                                       '     Dim selectedCodigo As String = menuItem.Tag.ToString()

                                       ' Llamar al procedimiento con los parámetros
                                       ListaLimCre(codigo, nombre)
                                   End Sub



            menu.Items.Add(item)
        Next
        menu.Show(CmdOpcionesLC, New Point(0, CmdOpcionesLC.Height))
    End Sub
    Private Sub ListaLimCre(wcodigo As String, wdetalle As String)
        CmdOpcionesLC.Text = wdetalle.Trim
        CmdOpcionesLC.Tag = wcodigo.Trim
    End Sub
    Private Sub Obtener_LineaCredito_SN(wid_sn_maestro As Integer, wdiascred As Integer, wes_limite As Integer, w_monto As Double)
        If BoxCondicion.AccessibleDescription = "3" Then Exit Sub

        lblEti_lc.Text = "UN MAXIMO (" & wdiascred & ")"
        lblEti_lc.Tag = wdiascred
        txt_diaslc.Text = wdiascred
        If wes_limite = 1 Then
            lbl_estado_lc.Text = "ACTIVO"
            lbl_estado_lc.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorVerde)
            lbl_estado_lc.ForeColor = Color.White
            lbl_estado_lc.Tag = 1
            mueve_fecha_vcto_dias(wdiascred)
        Else
            lbl_estado_lc.Text = "* DESACTIVO *"
            lbl_estado_lc.Tag = 0
            lbl_estado_lc.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorRojo)
            lbl_estado_lc.ForeColor = Color.White
        End If

        If BoxLineaCredito.Visible = False Then
            Exit Sub
        End If
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter



        Dim dt_DatosConsulta_Lista As DataTable

        sql_cade = "exec [datos_limiteCredito_sn] @id_negocio , @tipo_balance ,  @id_sn_maestro, @id_moneda"
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        parametro = New SqlParameter("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@tipo_balance", 1)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@id_sn_maestro", wid_sn_maestro)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@id_moneda", 1)
        command.Parameters.Add(parametro)

        adaptador = New SqlDataAdapter(command)
        dt_DatosConsulta_Lista = New DataTable
        adaptador.Fill(dt_DatosConsulta_Lista)

        If dt_DatosConsulta_Lista.Rows.Count <> 0 Then
            lc_actual.Text = dt_DatosConsulta_Lista.Rows(0).Item("monto").ToString
            lc_usado.Text = dt_DatosConsulta_Lista.Rows(0).Item("saldo_pend").ToString
            lc_dias.Text = dt_DatosConsulta_Lista.Rows(0).Item("dias_credito").ToString
            lc_disponible.Text = dt_DatosConsulta_Lista.Rows(0).Item("monto").ToString - dt_DatosConsulta_Lista.Rows(0).Item("saldo_pend").ToString
            If dt_DatosConsulta_Lista.Rows(0).Item("es_limite_credito").ToString = 1 Then
                lblEstado_lc.Text = "ACTIVO"
                lblEstado_lc.Tag = 1
                CmdEstado_lc.Text = "DESACTIVAR"
                lc_monto.Enabled = True
                lc_dias.Enabled = True
            Else
                lblEstado_lc.Text = "***DESACTIVADO***"
                lblEstado_lc.Tag = 0
                CmdEstado_lc.Text = "ACTIVAR"
                lc_monto.Enabled = False
                lc_dias.Enabled = False
            End If

        End If

    End Sub

    Private Sub CmdEstado_lc_Click(sender As Object, e As EventArgs) Handles CmdEstado_lc.Click
        If Val(lblEstado_lc.Tag) = 0 Then
            CmdEstado_lc.Text = "DESACTIVAR"
            lblEstado_lc.Text = "ACTIVO"
            lblEstado_lc.Tag = 1
            CmdEstado_lc.Text = "DESACTIVAR"
            lc_monto.Enabled = True
            lc_dias.Enabled = True
            lc_monto.Select()
        Else
            lblEstado_lc.Text = "***DESACTIVADO***"
            lblEstado_lc.Tag = 0
            CmdEstado_lc.Text = "ACTIVAR"
            lc_monto.Enabled = False
            lc_dias.Enabled = False
            lc_monto.Text = ""
            lc_dias.Text = ""
        End If
    End Sub

    Private Sub lc_dias_TextChanged(sender As Object, e As EventArgs) Handles lc_dias.TextChanged

    End Sub

    Private Sub lc_dias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lc_dias.KeyPress
        Solo_Numero(e)

    End Sub

    Private Sub lc_monto_TextChanged(sender As Object, e As EventArgs) Handles lc_monto.TextChanged

    End Sub

    Private Sub lc_monto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lc_monto.KeyPress

        e.Handled = Solo_Numerico(e, lc_monto)

    End Sub

    Private Sub txt_diaslc_TextChanged(sender As Object, e As EventArgs) Handles txt_diaslc.TextChanged
        mueve_fecha_vcto_dias(Val(txt_diaslc.Text))
    End Sub

    Private Sub txt_diaslc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_diaslc.KeyPress
        e.Handled = Solo_Numero(e)

    End Sub

    Private Sub tref_codigo_TextChanged(sender As Object, e As EventArgs) Handles tref_codigo.TextChanged

    End Sub

    Private Sub tref_codigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tref_codigo.KeyPress
        e.Handled = True
    End Sub

    Private Sub tref_serie_TextChanged(sender As Object, e As EventArgs) Handles tref_serie.TextChanged

    End Sub

    Private Sub tref_serie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tref_serie.KeyPress
        e.Handled = True
    End Sub

    Private Sub tref_numero_TextChanged(sender As Object, e As EventArgs) Handles tref_numero.TextChanged

    End Sub

    Private Sub tref_numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tref_numero.KeyPress
        e.Handled = True
    End Sub

    Private Sub tref_fecha_TextChanged(sender As Object, e As EventArgs) Handles tref_fecha.TextChanged

    End Sub

    Private Sub tref_fecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tref_fecha.KeyPress
        e.Handled = True
    End Sub

    Private Sub GridProductos_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles GridProductos.CellMouseClick

    End Sub
    Private Sub Limpia_Fila_Producto(wfil As Integer)
        'For c = 0 To GridProductos.Columns.Count - 1
        '    GridProductos.Rows(wfil).Cells(c).Value = ""
        'Next c
        GridProductos.Rows(wfil).Cells("grupo").Value = Nothing
        GridProductos.Rows(wfil).Cells("descrip").Value = Nothing
        GridProductos.Rows(wfil).Cells("codigo").Value = Nothing
        GridProductos.Rows(wfil).Cells("id_prod_mae").Value = 0
        GridProductos.Rows(wfil).Cells("id_prod_mae_codigo").Value = Nothing

        GridProductos.Rows(wfil).Cells("almacen").Value = Nothing
        GridProductos.Rows(wfil).Cells("id_almacen").Value = 0
        GridProductos.Rows(wfil).Cells("alm_abreviado").Value = Nothing
        GridProductos.Rows(wfil).Cells("lote").Value = Nothing
        GridProductos.Rows(wfil).Cells("id_pres_base").Value = 0
        GridProductos.Rows(wfil).Cells("abreviado_base").Value = Nothing
        GridProductos.Rows(wfil).Cells("equiv_base").Value = 0
        GridProductos.Rows(wfil).Cells("es_control_lote").Value = 0
        GridProductos.Rows(wfil).Cells("es_inventariable").Value = 0
        GridProductos.Rows(wfil).Cells("es_exonerado").Value = 0
        GridProductos.Rows(wfil).Cells("cosproactual").Value = 0
        GridProductos.Rows(wfil).Cells("stockactual").Value = 0
        GridProductos.Rows(wfil).Cells("id_pres_precio").Value = 0
        GridProductos.Rows(wfil).Cells("lote").Value = Nothing
        GridProductos.Rows(wfil).Cells("det_lote").Value = Nothing
        GridProductos.Rows(wfil).Cells("cantidad").Value = Nothing
        GridProductos.Rows(wfil).Cells("present").Value = Nothing
        GridProductos.Rows(wfil).Cells("id_pres").Value = 0
        GridProductos.Rows(wfil).Cells("equiv").Value = 0
        GridProductos.Rows(wfil).Cells("Unidades").Value = Nothing
        GridProductos.Rows(wfil).Cells("id_pres_precio").Value = 0
        GridProductos.Rows(wfil).Cells("cadenaprecios").Value = Nothing
        GridProductos.Rows(wfil).Cells("preciobase").Value = 0
        GridProductos.Rows(wfil).Cells("preciobase").Value = Nothing
        GridProductos.Rows(wfil).Cells("valor").Value = Nothing
        GridProductos.Rows(wfil).Cells("impto").Value = Nothing
        GridProductos.Rows(wfil).Cells("subtotal").Value = Nothing
        GridProductos.Rows(wfil).Cells("precio_valor").Value = Nothing


    End Sub

    Private Sub PanelCabecera_Paint(sender As Object, e As PaintEventArgs) Handles PanelCabecera.Paint

    End Sub
End Class








