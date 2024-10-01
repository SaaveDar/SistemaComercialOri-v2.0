Imports WindowsApp1.ValidaUsuarios
Imports WindowsApp1.ListaTipoDocPersona
Imports WindowsApp1.AgregarUsuario
Imports WindowsApp1.ModificaUsuario
Imports WindowsApp1.RepiteUsuario
Imports WindowsApp1.ListaUsuarios
Imports WindowsApp1.ListaUbigeoN1
Imports WindowsApp1.ListaUbigeoN2
Imports WindowsApp1.ListaUbigeoN3
Imports WindowsApp1.EnviaSMS
Imports WindowsApp1.Negocio.AgregaNegocio
Imports WindowsApp1.Negocio.ListaNegocio
Imports WindowsApp1.ModificaDatos
Imports WindowsApp1.Locales.ListaLocales
Imports WindowsApp1.ListaTablas
Imports WindowsApp1.Negocio.NegocioActivo
Imports RestSharp
Imports WindowsApp1.Negocio.AgregaLocal
Imports WindowsApp1.Negocio.AgregarAlmacen
Imports WindowsApp1.Almacenes.ListaAlmacenes
Imports WindowsApp1.BuscaUsuarios
Imports WindowsApp1.ListaCuentaUser
Imports WindowsApp1.Negocio.ListaNegocioAcceso
Imports WindowsApp1.Negocio.ListaLocalAcceso
Imports WindowsApp1.Negocio.ListaHorarioLocal
Imports WindowsApp1.Negocio.ListaAlmacenAcceso
Imports WindowsApp1.Negocio.ListaAccesoNegocios
Imports WindowsApp1.Negocio

Module VariablesPublicas
    Public lk_client = New RestClient()

    Public lk_api_cadena_base As String = "http://207.180.246.8/backend-farmacia/public/api/"
    Public lk_api_ValidaUsuario As JsonValidaUsaurio
    Public lk_api_ListaTipoDocPersona As JsonListaTipoDocPersona
    Public lk_api_AgregarUsaurio As JsonAgregarUsuario
    Public lk_api_ModificaUsaurio As JsonModificaUsuario
    Public lk_api_RepiteUsuario As JsonRepiteUsuario
    Public lk_api_EnvioSMS As JsonEnvioSMS
    Public lk_api_ListaUsuarios As JsonListaUsuarios
    Public lk_api_BuscaUsuarios As JsonBuscaUsuarios
    Public lk_api_ListaCuentaUser As JsonListaCuentaUser


    Public lk_api_ListaUbigeoN1 As JsonListaUbigeoN1
    Public lk_api_ListaUbigeoN2 As JsonListaUbigeoN2
    Public lk_api_ListaUbigeoN3 As JsonListaUbigeoN3
    Public lk_api_ListaNegocios As JsonListaNegocios
    Public lk_api_ListaLocales As JsonListaLocales
    Public lk_api_ListaTablas As JsonListaTablas
    Public lk_api_ListaAlmacenes As JsonListaAlmacenes

    Public lk_api_AccesoNegocios As JsonAccesoNegocios


    Public lk_api_AgregaNegocio As JsonAgregaNegocio
    Public lk_api_ModificaDatos As JsonModificaDatos
    Public lk_api_AgregaLocal As JsonAgregarLocal
    Public lk_api_AgregarAlmacen As JsonAgregarAlmacen

    Public lk_api_ListaNegocioAcceso As JsonListaNegocioAcceso
    Public lk_api_ListalocalAcceso As JsonListaLocalAcceso
    Public lk_api_ListaHorarioLocal As JsonListaHorarioLocal
    Public lk_api_ListAlmacenAcceso As JsonListaAlmacenAcceso





    Public lk_NegocioActivo As New TempNegocioActivo
    Public lk_LocalActivo As New TempLocalActivo
    Public lk_AlmacenActivo As New TempAlmacenActivo
    Public lk_FormatoActivo As New TempFormato






End Module
