Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class ucPedido
    Inherits System.Web.UI.UserControl
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
        End If
        LeePedido()
    End Sub

    Private Sub LeePedido()
        Dim wCodigo As Integer

        'Lee Nro Pedido
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_PedidoNroPedido_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = CInt(Viewstate("NroPedido"))
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                Cod.Text = dr.GetValue(dr.GetOrdinal("CodCliente"))
                lblNomCliente.Text = dr.GetValue(dr.GetOrdinal("NomCliente"))

                lblFono.Text = dr.GetValue(dr.GetOrdinal("Telefono"))
                If Not IsDBNull(dr.GetValue(dr.GetOrdinal("NomVendedor"))) Then
                    NomVendedor.Text = dr.GetValue(dr.GetOrdinal("NomVendedor"))
                End If
                lblEmailCliente.Text = dr.GetValue(dr.GetOrdinal("Email"))
                lblPais.Text = dr.GetValue(dr.GetOrdinal("NomPais"))
                lblClaveCliente.Text = dr.GetValue(dr.GetOrdinal("ClaveCliente"))

                lbldespedido.Text = CStr(ViewState("NroPedido")) & " - " & dr.GetValue(dr.GetOrdinal("DesPedido"))
                lblFecha.Text = String.Format("{0:dd-MM-yyyy}", (dr.GetValue(dr.GetOrdinal("FchPedido"))))

                'If Not IsDBNull(dr.GetValue(dr.GetOrdinal("FchNacimiento"))) Then
                'txtcumple.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchNacimiento")))
                'End If
                txtcumple.Text = dr.GetValue(dr.GetOrdinal("NomStsCaptacion"))
                lblIdioma.Text = dr.GetValue(dr.GetOrdinal("Idioma"))
                lblStsPedido.Text = dr.GetValue(dr.GetOrdinal("CodStsPedido"))

                lblEntradaSalida.Text = "Salida=" & CStr(dr.GetValue(dr.GetOrdinal("CantMsgSalida"))) & "&nbsp;&nbsp;&nbsp;" & _
                                        "Entrada=" & CStr(dr.GetValue(dr.GetOrdinal("CantMsgEntrada")))
                lblNomComprador.Text = dr.GetValue(dr.GetOrdinal("NomComprador"))
                lblIngresoWeb.Text = dr.GetValue(dr.GetOrdinal("CantIngWeb"))
                lblMesAno.Text = dr.GetValue(dr.GetOrdinal("AnoMes"))
                lblZonaVta.Text = dr.GetValue(dr.GetOrdinal("CodZonaVta"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub


    Public Property CodCliente() As Integer
        Get
            Return CInt(Cod.Text)
        End Get
        Set(ByVal Value As Integer)
            Cod.Text = CStr(Value)
        End Set
    End Property

    Public Property NomCliente() As String
        Get
            Return lblNomcliente.Text
        End Get
        Set(ByVal Value As String)
            lblNomCliente.Text = CStr(Value)
        End Set
    End Property

    Public Property EmailCliente() As String
        Get
            Return lblEmailCliente.Text
        End Get
        Set(ByVal Value As String)
            lblEmailCliente.Text = CStr(Value)
        End Set
    End Property

    Public Property Idioma() As String
        Get
            Return lblIdioma.Text
        End Get
        Set(ByVal Value As String)
            lblIdioma.Text = CStr(Value)
        End Set
    End Property

    Public Property StsPedido() As String
        Get
            Return lblStsPedido.Text
        End Get
        Set(ByVal Value As String)
            lblStsPedido.Text = CStr(Value)
        End Set
    End Property


End Class
