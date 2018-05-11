Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization

Partial Class vtaVersionPrintIn
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodCliente") = 0 Then
            Response.Redirect("icerrar.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("I1")
            Viewstate("NroPropuesta") = Request.Params("I2")
            Viewstate("NroVersion") = Request.Params("I3")
            Version()
        End If
    End Sub


    Private Sub Version()
        ' Configurado Ingles EEUU
        System.Threading.Thread.CurrentThread.CurrentCulture = _
        New System.Globalization.CultureInfo("en-US")

        Dim wFlagAtencion, wFlagIdioma As String
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "P4I_VersionNroVersion_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                'Cliente
                lblNomCliente.Text = "Personalized itinerary to " & Request.Params("I4")

                'If Not IsDBNull(dr.GetValue(dr.GetOrdinal("Nombre"))) Then
                'lblNomCliente.Text = lblNomCliente.Text & " " & Trim(dr.GetValue(dr.GetOrdinal("Nombre")))
                'End If

                'If Not IsDBNull(dr.GetValue(dr.GetOrdinal("Paterno"))) Then
                'lblNomCliente.Text = lblNomCliente.Text & " " & Trim(dr.GetValue(dr.GetOrdinal("Paterno")))
                'End If

                'If Not IsDBNull(dr.GetValue(dr.GetOrdinal("Materno"))) Then
                'lblNomCliente.Text = lblNomCliente.Text & " " & Trim(dr.GetValue(dr.GetOrdinal("Materno")))
                'End If

                'Propuesta
                Dim wtexto As String
                If dr.GetValue(dr.GetOrdinal("CodStsVersion")) = "F" Then
                    wtexto = "Sold"
                Else
                    wtexto = "Proposal"
                End If

                '            Programa.Text = wtexto & "&nbsp" & Session("NroVersion")
                '           Dias.Text = "&nbsp(" & dr.GetValue(dr.GetOrdinal("CantDias")) & " days tour)"

                'Dias.Text = wtexto & "&nbsp" & Session("NroVersion") & "&nbsp - " & dr.GetValue(dr.GetOrdinal("CantDias")) & " days tour"
                '          DesPrograma.Text = dr.GetValue(dr.GetOrdinal("DesVersion"))

                '         lblFechayHora.Text = "Published on " & String.Format("{0,1:dd MMM yyyy}{0,13:hh:mm tt }", dr.GetValue(dr.GetOrdinal("FchSys")))

                If Not IsDBNull(dr.GetValue(dr.GetOrdinal("FchIniTour"))) Then
                    If Year(dr.GetValue(dr.GetOrdinal("FchIniTour"))) = Year(dr.GetValue(dr.GetOrdinal("FchFinTour"))) And Month(dr.GetValue(dr.GetOrdinal("FchIniTour"))) = Month(dr.GetValue(dr.GetOrdinal("FchFinTour"))) Then
                        lblPeriodo.Text = String.Format("{0,1:MMMM yyyy}", dr.GetValue(dr.GetOrdinal("FchFinTour")))

                    ElseIf Year(dr.GetValue(dr.GetOrdinal("FchIniTour"))) = Year(dr.GetValue(dr.GetOrdinal("FchFinTour"))) Then
                        lblPeriodo.Text = String.Format("{0,1:MMMM}", dr.GetValue(dr.GetOrdinal("FchIniTour"))) & " - " & String.Format("{0,1:MMMM yyyy}", dr.GetValue(dr.GetOrdinal("FchFinTour")))
                    Else
                        lblPeriodo.Text = String.Format("{0,1:MMMM yyyy}", dr.GetValue(dr.GetOrdinal("FchIniTour"))) & " - " & String.Format("{0,1:MMMM yyyy}", dr.GetValue(dr.GetOrdinal("FchFinTour")))
                    End If
                End If

                wFlagAtencion = dr.GetValue(dr.GetOrdinal("FlagAtencion"))
                wFlagIdioma = dr.GetValue(dr.GetOrdinal("FlagIdioma"))

                lblResumen.Text = dr.GetValue(dr.GetOrdinal("Resumen"))

            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        VersionServicios(wFlagAtencion, wFlagIdioma)
        VersionHoteles()
        '        VerLinks()
    End Sub

    Private Sub VersionServicios(ByVal pFlagAtencion As String, _
                              ByVal pFlagIdioma As String)

        If pFlagAtencion = "F" Then
            dgItinerary.Columns(0).Visible = False
        Else
            dgItinerary.Columns(1).Visible = False
        End If
        dgItinerary.Columns(5).Visible = False

        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "P4I_VersionServiciosDet_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "ITINERARY")
        dgItinerary.DataKeyField = "KeyReg"
        dgItinerary.DataSource = ds.Tables("ITINERARY")
        dgItinerary.DataBind()
    End Sub


    Private Sub VersionHoteles()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "P4I_VersionHotel_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblHotel.Text = lblHotel.Text & _
                        "<div><span class=hotel>&nbsp;" & dr.GetValue(dr.GetOrdinal("NomCiudad")) & ":&nbsp" & _
                        dr.GetValue(dr.GetOrdinal("Titulo")) & "</span></div>"
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub VerLinks()
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandText = "P4I_VersionLink_S"
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        cn.Open()
    End Sub

End Class
