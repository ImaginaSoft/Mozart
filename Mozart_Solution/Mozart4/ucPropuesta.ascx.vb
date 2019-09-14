Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class ucPropuesta
    Inherits System.Web.UI.UserControl
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Not Page.IsPostBack Then
            ViewState("NroPedido") = Request.Params("NroPedido")
            ViewState("NroPropuesta") = Request.Params("NroPropuesta")
            CargaData()
        End If
    End Sub

    Private Sub CargaData()
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaNroPropuesta_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = CInt(Viewstate("NroPedido"))
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = CInt(Viewstate("NroPropuesta"))
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblNombre.Text = CStr(ViewState("CodCliente")) & " " & _
                                 dr.GetValue(dr.GetOrdinal("Nomcliente")) & _
                                 "&nbsp;<span class=msg>" & dr.GetValue(dr.GetOrdinal("NomComprador")) & "  &nbsp;&nbsp;&nbsp;</span>" & _
                                 "<span class=msg>(" & dr.GetValue(dr.GetOrdinal("NomStsCaptacion")) & ")  &nbsp;&nbsp;&nbsp;</span>" & _
                                 "Atención " & dr.GetValue(dr.GetOrdinal("AnoMes"))

                '                 dr.GetValue(dr.GetOrdinal("TipoPersona")) & ")"

                lblCodCliente.Text = dr.GetValue(dr.GetOrdinal("CodCliente"))
                lblIDCliente.Text = dr.GetValue(dr.GetOrdinal("IDCliente"))
                lblEmailCliente.Text = dr.GetValue(dr.GetOrdinal("EmailCliente"))
                lblFlagEdita.Text = dr.GetValue(dr.GetOrdinal("FlagEdita"))
                lblCodZonaVta.Text = dr.GetValue(dr.GetOrdinal("CodZonaVta"))

                Nro.Text = ViewState("NroPropuesta")
                lblDesPropuesta.Text = CStr(ViewState("NroPropuesta")) & _
                         " " & dr.GetValue(dr.GetOrdinal("DesPropuesta")) & _
                         " (" & CStr(dr.GetValue(dr.GetOrdinal("CantDias"))) & " Dias)"

                '            If dr.GetValue(dr.GetOrdinal("AnoMes")) <> " " Then
                '           lblAtencion.Text = lblAtencion.Text & "Atención " & dr.GetValue(dr.GetOrdinal("AnoMes"))
                '          End If

                lblCantPersonas.Text = ""
                If dr.GetValue(dr.GetOrdinal("CantAdultos")) > 0 Then
                    lblCantPersonas.Text = CStr(dr.GetValue(dr.GetOrdinal("CantAdultos"))) & "ADT "
                End If
                If dr.GetValue(dr.GetOrdinal("CantNinos")) > 0 Then
                    lblCantPersonas.Text &= CStr(dr.GetValue(dr.GetOrdinal("CantNinos"))) & "CHD "
                End If

                If dr.GetValue(dr.GetOrdinal("CantSimple")) + _
                    dr.GetValue(dr.GetOrdinal("CantDoble")) + _
                    dr.GetValue(dr.GetOrdinal("CantTriple")) + _
                    dr.GetValue(dr.GetOrdinal("CantCuadruple")) Then

                    lblCantPersonas.Text &= " y "

                    If dr.GetValue(dr.GetOrdinal("CantSimple")) > 0 Then
                        lblCantPersonas.Text &= CStr(dr.GetValue(dr.GetOrdinal("CantSimple"))) & "SGL "
                    End If
                    If dr.GetValue(dr.GetOrdinal("CantDoble")) > 0 Then
                        lblCantPersonas.Text &= CStr(dr.GetValue(dr.GetOrdinal("Cantdoble"))) & "DBL "
                    End If
                    If dr.GetValue(dr.GetOrdinal("CantTriple")) > 0 Then
                        lblCantPersonas.Text &= CStr(dr.GetValue(dr.GetOrdinal("CantTriple"))) & "TPL "
                    End If
                    If dr.GetValue(dr.GetOrdinal("CantCuadruple")) > 0 Then
                        lblCantPersonas.Text &= CStr(dr.GetValue(dr.GetOrdinal("CantCuadruple"))) & "CDL "
                    End If
                End If

                If dr.GetValue(dr.GetOrdinal("FlagIdioma")) = "I" Then
                    lblCantPersonas.Text = lblCantPersonas.Text & ", Ingles"
                ElseIf dr.GetValue(dr.GetOrdinal("FlagIdioma")) = "E" Then
                    lblCantPersonas.Text = lblCantPersonas.Text & ", Español"
                Else
                    lblCantPersonas.Text = lblCantPersonas.Text & ", Portugués"
                End If

                lblCantPersonas.Text = lblCantPersonas.Text & ", " & dr.GetValue(dr.GetOrdinal("StsPropuesta"))
                lblstsPropuesta.Text = Mid(dr.GetValue(dr.GetOrdinal("StsPropuesta")), 1, 1)

                If dr.GetValue(dr.GetOrdinal("FlagPublica")) = "S" Then
                    lblCantPersonas.Text = lblCantPersonas.Text & " y Publicado"
                    lblPublica.Text = "S"
                End If

                lblSer.Text = String.Format("{0:###,###,##0.00}", dr.GetValue(dr.GetOrdinal("PrecioNeto")))
                lblIGV.Text = String.Format("{0:###,###,##0.00}", dr.GetValue(dr.GetOrdinal("IGV")))
                utilidad.Text = "Utilidad (" & String.Format("{0:###.##}", dr.GetValue(dr.GetOrdinal("PorUtilidad"))) + "%)"
                lbluti.Text = String.Format("{0:###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Utilidad")))
                lbltot.Text = String.Format("{0:###,###,##0.00}", dr.GetValue(dr.GetOrdinal("PrecioTotal")))

                Dim URL_perutourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_perutourism")
                Dim URL_perutourism_new As String = System.Configuration.ConfigurationManager.AppSettings("URL_perutourism_new")

                Dim URL_chiletourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_chiletourism")
                Dim URL_galapagostourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_galapagostourism")
                Dim URL_gayperutourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_gayperutourism")
                Dim URL_latajourneys As String = System.Configuration.ConfigurationManager.AppSettings("URL_latajourneys")
                'Dim URL_perutourism_test As String = System.Configuration.ConfigurationManager.AppSettings("URL_perutourism_test")
                'Dim URL_perutourism_local As String = System.Configuration.ConfigurationManager.AppSettings("URL_perutourism_local")




                'PRODUCCION Actual
                If dr.GetValue(dr.GetOrdinal("CodZonaVta")) = "PER" Then

                    lblPaginaPersonalizada.Text = URL_perutourism_new & "/" & lblIDCliente.Text
                    lblPaginaPersonalizada_old.Text = URL_perutourism & "/ilogin.aspx?ID=" & lblIDCliente.Text
                    'lblPaginaPersonalizada.Text = URL_perutourism & "/ilogin.aspx?ID=" & lblIDCliente.Text

                    'If dr.GetValue(dr.GetOrdinal("FlagIdioma")) = "I" Then
                    '    lblPaginaPersonalizada.Text = URL_perutourism & "/ilogin.aspx?ID=" & lblIDCliente.Text
                    'Else
                    '    lblPaginaPersonalizada.Text = URL_perutourism & "/elogin.aspx?ID=" & lblIDCliente.Text
                    'End If
                ElseIf dr.GetValue(dr.GetOrdinal("CodZonaVta")) = "ECU" Then

                    lblPaginaPersonalizada.Text = URL_perutourism_new & "/" & lblIDCliente.Text
                    lblPaginaPersonalizada_old.Text = URL_galapagostourism & "/ilogin.aspx?ID=" & lblIDCliente.Text
                    'lblPaginaPersonalizada.Text = URL_galapagostourism & "/ilogin.aspx?ID=" & lblIDCliente.Text

                    'If dr.GetValue(dr.GetOrdinal("FlagIdioma")) = "I" Then
                    '    lblPaginaPersonalizada.Text = URL_galapagostourism & "/ilogin.aspx?ID=" & lblIDCliente.Text
                    'Else
                    '    lblPaginaPersonalizada.Text = URL_galapagostourism & "/elogin.aspx?ID=" & lblIDCliente.Text
                    'End If
                ElseIf dr.GetValue(dr.GetOrdinal("CodZonaVta")) = "CHL" Then

                    lblPaginaPersonalizada.Text = URL_perutourism_new & "/" & lblIDCliente.Text
                    lblPaginaPersonalizada_old.Text = URL_chiletourism & "/ilogin.aspx?ID=" & lblIDCliente.Text

                    'lblPaginaPersonalizada.Text = URL_chiletourism & "/ilogin.aspx?ID=" & lblIDCliente.Text

                    'If dr.GetValue(dr.GetOrdinal("FlagIdioma")) = "I" Then
                    '    lblPaginaPersonalizada.Text = URL_chiletourism & "/ilogin.aspx?ID=" & lblIDCliente.Text
                    'Else
                    '    lblPaginaPersonalizada.Text = URL_chiletourism & "/elogin.aspx?ID=" & lblIDCliente.Text
                    'End If
                ElseIf dr.GetValue(dr.GetOrdinal("CodZonaVta")) = "GAY" Then

                    lblPaginaPersonalizada.Text = URL_perutourism_new & "/" & lblIDCliente.Text
                    lblPaginaPersonalizada_old.Text = URL_gayperutourism & "/ilogin.aspx?ID=" & lblIDCliente.Text
                    'lblPaginaPersonalizada.Text = URL_gayperutourism & "/ilogin.aspx?ID=" & lblIDCliente.Text
                    'If dr.GetValue(dr.GetOrdinal("FlagIdioma")) = "I" Then
                    '    lblPaginaPersonalizada.Text = URL_gayperutourism & "/ilogin.aspx?ID=" & lblIDCliente.Text
                    'Else
                    '    lblPaginaPersonalizada.Text = URL_gayperutourism & "/elogin.aspx?ID=" & lblIDCliente.Text
                    'End If
                ElseIf dr.GetValue(dr.GetOrdinal("CodZonaVta")) = "LAJ" Then

                    lblPaginaPersonalizada.Text = URL_perutourism_new & "/" & lblIDCliente.Text
                    lblPaginaPersonalizada_old.Text = URL_latajourneys & "/ilogin.aspx?ID=" & lblIDCliente.Text

                    'lblPaginaPersonalizada.Text = URL_latajourneys & "/ilogin.aspx?ID=" & lblIDCliente.Text

                End If

            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Public Property NroPropuesta() As Integer
        Get
            Return CInt(Nro.Text)
        End Get
        Set(ByVal Value As Integer)
            Nro.Text = CStr(Value)
        End Set
    End Property

    Public Property DesPropuesta() As String
        Get
            Return lblDesPropuesta.Text
        End Get
        Set(ByVal Value As String)
            lblDesPropuesta.Text = Value
        End Set
    End Property

    Public Property FlagPublica() As String
        Get
            Return lblPublica.Text
        End Get
        Set(ByVal Value As String)
            lblPublica.Text = Value
        End Set
    End Property

    Public Property StsPropuesta() As String
        Get
            Return lblstsPropuesta.Text
        End Get
        Set(ByVal Value As String)
            lblstsPropuesta.Text = Value
        End Set
    End Property

    Public Property CodCliente() As Integer
        Get
            Return CInt(lblCodCliente.Text)
        End Get
        Set(ByVal Value As Integer)
            lblCodCliente.Text = CStr(Value)
        End Set
    End Property
    Public Property IDCliente() As String
        Get
            Return lblIDCliente.Text
        End Get
        Set(ByVal Value As String)
            lblIDCliente.Text = Value
        End Set
    End Property

    Public Property EmailCliente() As String
        Get
            Return lblEmailCliente.Text
        End Get
        Set(ByVal Value As String)
            lblEmailCliente.Text = Value
        End Set
    End Property

    Public Property FlagEdita() As String
        Get
            Return lblFlagEdita.Text
        End Get
        Set(ByVal Value As String)
            lblFlagEdita.Text = Value
        End Set
    End Property

    Public Property CodZonaVta() As String
        Get
            Return lblCodZonaVta.Text
        End Get
        Set(ByVal Value As String)
            lblCodZonaVta.Text = Value
        End Set
    End Property
    Public Property PaginaPersonalizada() As String
        Get
            Return lblPaginaPersonalizada.Text
        End Get
        Set(ByVal Value As String)
            lblPaginaPersonalizada.Text = Value
        End Set
    End Property

End Class
