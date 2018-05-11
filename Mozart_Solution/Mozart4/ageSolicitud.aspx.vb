Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class ageSolicitud
    Inherits System.Web.UI.Page
    '    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodCliente") = Request.Params("CodCliente")
            Viewstate("NroSolicitud") = Request.Params("NroSolicitud")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            lblTitulo.Text = "Solicitud N° " & Request.Params("NroSolicitud")
            EditaSolicitud()
        End If
    End Sub
    Private Sub EditaSolicitud()
        Dim wCodVendedor As String = ""
        Dim Ano As String = ""

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "AGE_SolicitudNroSolicitud_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroSolicitud", SqlDbType.Int).Value = Viewstate("NroSolicitud")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblNombre.Text = dr.GetValue(dr.GetOrdinal("Nombre"))
                lblNomPais.Text = dr.GetValue(dr.GetOrdinal("NomPais"))
                lblCantDias.Text = dr.GetValue(dr.GetOrdinal("CantDias"))

                If dr.GetValue(dr.GetOrdinal("CantAdultos")) > 0 Then
                    lblCantPasa.Text = CStr(dr.GetValue(dr.GetOrdinal("CantAdultos"))) + " Adultos   "
                End If
                If dr.GetValue(dr.GetOrdinal("CantNinos")) > 0 Then
                    lblCantPasa.Text = lblCantPasa.Text & CStr(dr.GetValue(dr.GetOrdinal("CantNinos"))) + " Niños"
                End If

                If dr.GetValue(dr.GetOrdinal("CantSimple")) > 0 Then
                    lblCantHab.Text = CStr(dr.GetValue(dr.GetOrdinal("CantSimple"))) + " Simple   "
                End If
                If dr.GetValue(dr.GetOrdinal("CantDoble")) > 0 Then
                    lblCantHab.Text = lblCantHab.Text & CStr(dr.GetValue(dr.GetOrdinal("CantDoble"))) + " Doble   "
                End If
                If dr.GetValue(dr.GetOrdinal("CantTriple")) > 0 Then
                    lblCantHab.Text = lblCantHab.Text & CStr(dr.GetValue(dr.GetOrdinal("CantTriple"))) + " Triple"
                End If

                lblMesAno.Text = CStr(dr.GetValue(dr.GetOrdinal("MesAtencion"))) + "-" + CStr(dr.GetValue(dr.GetOrdinal("AnoAtencion")))
                If dr.GetValue(dr.GetOrdinal("HotelEconomico")) = "S" Then
                    cbHotelEconomico.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("HotelStandard")) = "S" Then
                    cbHotelStandard.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("HotelSuperior")) = "S" Then
                    cbHotelSuperior.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("HotelDeluxe")) = "S" Then
                    cbHotelDeluxe.Checked = True
                End If

                If dr.GetValue(dr.GetOrdinal("TourCultural")) = "S" Then
                    cbTourCultural.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("TourAventura")) = "S" Then
                    cbTourAventura.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("TourNaturaleza")) = "S" Then
                    cbTourNaturaleza.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("TourVivencial")) = "S" Then
                    cbTourVivencial.Checked = True
                End If

                If dr.GetValue(dr.GetOrdinal("DestCuzco")) = "S" Then
                    cbDestCuzco.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("DestTiticaca")) = "S" Then
                    cbDestTiticaca.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("DestColca")) = "S" Then
                    cbDestColca.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("DestSelva")) = "S" Then
                    cbDestSelva.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("DestManu")) = "S" Then
                    cbDestManu.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("DestLima")) = "S" Then
                    cbDestLima.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("DestSipan")) = "S" Then
                    cbDestSipan.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("DestNazca")) = "S" Then
                    cbDestNazca.Checked = True
                End If
                lblComentario.Text = dr.GetValue(dr.GetOrdinal("ComentarioSol"))
                If dr.GetValue(dr.GetOrdinal("NroPedido")) > 0 Then
                    lbtCreaPedido.Visible = False
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub lbtCreaPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCreaPedido.Click
        Response.Redirect("VtaPedido.aspx" & _
        "?CodCliente=" & Viewstate("CodCliente") & _
        "&NroSolicitud=" & Viewstate("NroSolicitud"))
    End Sub
End Class
