Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class cpcVisitasConsultaDet
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("TipoVisita") = Request.Params("TipoVisita")
            EditaVisita()
        End If
    End Sub

    Private Sub EditaVisita()
        Dim wResponsable, wStsVisita, wMeridiano, wObservacion, wCodVendedor As String
        Dim wCodEvaluacion As String

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPC_Visita_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@TipoVisita", SqlDbType.Char, 1).Value = Viewstate("TipoVisita")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblNroPedido.Text = CStr(dr.GetValue(dr.GetOrdinal("NroPedido")))
                lblDesPedido.Text = dr.GetValue(dr.GetOrdinal("DesPedido"))
                lblNomCliente.Text = dr.GetValue(dr.GetOrdinal("NomCliente"))
                lblNomVendedor.Text = dr.GetValue(dr.GetOrdinal("NomVendedor"))
                lblPax.Text = CStr(dr.GetValue(dr.GetOrdinal("CantPasajeros")))
                If dr.GetValue(dr.GetOrdinal("TipoVisita")) = "E" Then
                    lblTipo.Text = "Entrada"
                Else
                    lblTipo.Text = "Salida"
                End If
                lblFchVisita.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchVisita")))
                lblHoraVisita.Text = dr.GetValue(dr.GetOrdinal("HoraVisita"))
                lblResponsable.Text = dr.GetValue(dr.GetOrdinal("CodResponsable"))
                lblVisita.Text = dr.GetValue(dr.GetOrdinal("StsVisit"))
                lblEvaluacion.Text = dr.GetValue(dr.GetOrdinal("NomEvaluacion"))
                lblDesLog.Text = dr.GetValue(dr.GetOrdinal("DesLog"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

End Class
