Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class ucVersion
    Inherits System.Web.UI.UserControl
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            LeeVersion()
        End If
    End Sub

    Private Sub LeeVersion()
        Dim wUtilidad, wServicio, wTotal As Double

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_VersionNroVersion_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblIDCliente.Text = dr.GetValue(dr.GetOrdinal("IDCliente"))
                lblCliente.Text = RTrim(dr.GetValue(dr.GetOrdinal("Nombre"))) & " " & RTrim(dr.GetValue(dr.GetOrdinal("Paterno"))) & " " & RTrim(dr.GetValue(dr.GetOrdinal("Materno")))

                lblNombre.Text = dr.GetValue(dr.GetOrdinal("CodCliente")) & " - " & _
                                 dr.GetValue(dr.GetOrdinal("Nomcliente")) & _
                                 "<span class=msg>&nbsp;" & dr.GetValue(dr.GetOrdinal("NomComprador")) & "&nbsp;</span>" & _
                                 "<span class=msg>(" & dr.GetValue(dr.GetOrdinal("NomStsCaptacion")) & ")  &nbsp;&nbsp;&nbsp;</span>" & _
                                 "Atención " & dr.GetValue(dr.GetOrdinal("AnoMes"))
                'dr.GetValue(dr.GetOrdinal("TipoPersona")) & ")"
                lblDesPedido.Text = CStr(ViewState("NroPedido")) & " - " & dr.GetValue(dr.GetOrdinal("DesPedido")) & _
                                 "&nbsp;&nbsp;&nbsp;&nbsp;<span class=msg>(" & dr.GetValue(dr.GetOrdinal("CodVendedor")) & ")  &nbsp;&nbsp;&nbsp;</span>"

                'If dr.GetValue(dr.GetOrdinal("AnoMes")) <> " " Then
                'lblAtencion.Text = lblAtencion.Text & "Atención " & dr.GetValue(dr.GetOrdinal("AnoMes"))
                'End If


                'Version
                NV.Text = ViewState("NroVersion")
                lblDesVersion.Text = dr.GetValue(dr.GetOrdinal("DesVersion")) & _
                                     " (" & CStr(dr.GetValue(dr.GetOrdinal("CantDias"))) & " dias)"
                utilidad.Text = "Uti.(" & String.Format("{0:###.##}", dr.GetValue(dr.GetOrdinal("PorUtilidad"))) + "%)"

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

                lblFlagIdioma.Text = dr.GetValue(dr.GetOrdinal("FlagIdioma"))
                If dr.GetValue(dr.GetOrdinal("FlagIdioma")) = "I" Then
                    lblCantPersonas.Text = lblCantPersonas.Text & ", Ingles"
                ElseIf dr.GetValue(dr.GetOrdinal("FlagIdioma")) = "E" Then
                    lblCantPersonas.Text = lblCantPersonas.Text & ", Español"
                Else
                    lblCantPersonas.Text = lblCantPersonas.Text & ", Portugués"
                End If

                lblCantPersonas.Text = lblCantPersonas.Text & ", <span class=msg>" & dr.GetValue(dr.GetOrdinal("StsVersion")) & "</span>"

                If dr.GetValue(dr.GetOrdinal("FlagPublica")) = "S" Then
                    lblCantPersonas.Text = lblCantPersonas.Text & " y Publicado"
                    lblPublica.Text = "S"
                End If

                lblstsVersion.Text = dr.GetValue(dr.GetOrdinal("CodStsVersion"))

                Dim wcosto1, wcosto2, wcosto3, wcosto4 As String

                wServicio = dr.GetValue(dr.GetOrdinal("PrecioNeto"))
                wUtilidad = dr.GetValue(dr.GetOrdinal("Utilidad"))
                wTotal = dr.GetValue(dr.GetOrdinal("PrecioTotal"))

                lblIGV.Text = String.Format("{0:###,###,##0.00}", dr.GetValue(dr.GetOrdinal("IGV")))

                Dim URL_perutourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_perutourism")
                Dim URL_chiletourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_chiletourism")
                Dim URL_galapagostourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_galapagostourism")
                Dim URL_gayperutourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_gayperutourism")
                Dim URL_latajourneys As String = System.Configuration.ConfigurationManager.AppSettings("URL_latajourneys")


                'PRODUCCION Actual
                If dr.GetValue(dr.GetOrdinal("CodZonaVta")) = "PER" Then
                    If dr.GetValue(dr.GetOrdinal("FlagIdioma")) = "I" Then
                        lblPaginaPersonalizada.Text = URL_perutourism & "/ilogin.aspx?ID=" & lblIDCliente.Text
                    Else
                        lblPaginaPersonalizada.Text = URL_perutourism & "/elogin.aspx?ID=" & lblIDCliente.Text
                    End If
                ElseIf dr.GetValue(dr.GetOrdinal("CodZonaVta")) = "ECU" Then
                    If dr.GetValue(dr.GetOrdinal("FlagIdioma")) = "I" Then
                        lblPaginaPersonalizada.Text = URL_galapagostourism & "/ilogin.aspx?ID=" & lblIDCliente.Text
                    Else
                        lblPaginaPersonalizada.Text = URL_galapagostourism & "/elogin.aspx?ID=" & lblIDCliente.Text
                    End If
                ElseIf dr.GetValue(dr.GetOrdinal("CodZonaVta")) = "CHL" Then
                    If dr.GetValue(dr.GetOrdinal("FlagIdioma")) = "I" Then
                        lblPaginaPersonalizada.Text = URL_chiletourism & "/ilogin.aspx?ID=" & lblIDCliente.Text
                    Else
                        lblPaginaPersonalizada.Text = URL_chiletourism & "/elogin.aspx?ID=" & lblIDCliente.Text
                    End If
                ElseIf dr.GetValue(dr.GetOrdinal("CodZonaVta")) = "GAY" Then
                    If dr.GetValue(dr.GetOrdinal("FlagIdioma")) = "I" Then
                        lblPaginaPersonalizada.Text = URL_gayperutourism & "/ilogin.aspx?ID=" & lblIDCliente.Text
                    Else
                        lblPaginaPersonalizada.Text = URL_gayperutourism & "/elogin.aspx?ID=" & lblIDCliente.Text
                    End If

                ElseIf dr.GetValue(dr.GetOrdinal("CodZonaVta")) = "LAJ" Then
                    If dr.GetValue(dr.GetOrdinal("FlagIdioma")) = "I" Then
                        lblPaginaPersonalizada.Text = URL_latajourneys & "/ilogin.aspx?ID=" & lblIDCliente.Text
                    Else
                        lblPaginaPersonalizada.Text = URL_latajourneys & "/elogin.aspx?ID=" & lblIDCliente.Text
                    End If
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try


        Dim cd2 As New SqlCommand
        Dim dr2 As SqlDataReader
        cd2.Connection = cn
        cd2.CommandText = "VTA_VersionAjuste_S"
        cd2.CommandType = CommandType.StoredProcedure
        cd2.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
        cd2.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
        cd2.Parameters.Add("@NroVersion", SqlDbType.Int).Value = ViewState("NroVersion")
        lblAju.Text = "(NO)"
        Try
            cn.Open()
            dr2 = cd2.ExecuteReader
            Do While dr2.Read()
                wServicio = wServicio + dr2.GetValue(dr2.GetOrdinal("Servicio"))
                wUtilidad = wUtilidad + dr2.GetValue(dr2.GetOrdinal("Utilidad"))
                wTotal = wTotal + dr2.GetValue(dr2.GetOrdinal("Total"))

                If dr2.GetValue(dr2.GetOrdinal("CantReg")) > 0 Then
                    lblAju.Text = "(SI)"
                End If
            Loop
            dr2.Close()
        Finally
            cn.Close()
        End Try

        lblSer.Text = String.Format("{0:###,###,##0.00}", wServicio)
        lbluti.Text = String.Format("{0:###,###,##0.00}", wUtilidad)
        lbltot.Text = String.Format("{0:###,###,##0.00}", wTotal)
    End Sub

    Public Property NroVersion() As Integer
        Get
            Return CInt(NV.Text)
        End Get
        Set(ByVal Value As Integer)
            NV.Text = CStr(Value)
        End Set
    End Property

    Public Property DesVersion() As String
        Get
            Return lblDesVersion.Text
        End Get
        Set(ByVal Value As String)
            lblDesVersion.Text = Value
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

    Public Property StsVersion() As String
        Get
            Return lblstsVersion.Text
        End Get
        Set(ByVal Value As String)
            lblstsVersion.Text = Value
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

    Public Property Cliente() As String
        Get
            Return lblCliente.Text
        End Get
        Set(ByVal Value As String)
            lblCliente.Text = Value
        End Set
    End Property


    Public Property FlagIdioma() As String
        Get
            Return lblFlagIdioma.Text
        End Get
        Set(ByVal Value As String)
            lblFlagIdioma.Text = Value
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
