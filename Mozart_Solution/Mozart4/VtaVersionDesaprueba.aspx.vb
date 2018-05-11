Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class VtaVersionDesaprueba
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodCliente") = Request.Params("CodCliente")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            EditaVersion()
            lblTitulo.Text = "Desaprueba Versión N° " & Viewstate("NroVersion")
        End If

    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionDesaprueba_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = Viewstate("CodCliente")
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblMsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()

        If Trim(lblMsg.Text) = "OK" Then
            Response.Redirect("VtaVersionFicha.aspx" & _
                     "?CodCliente=" & Viewstate("CodCliente") & _
                     "&NroPedido=" & Viewstate("NroPedido") & _
                     "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                     "&NroVersion=" & Viewstate("NroVersion"))
        End If
    End Sub

    Private Sub EditaVersion()
        lblNroVersion.Text = CStr(Viewstate("NroVersion"))

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
                lblDesVersion.Text = dr.GetValue(dr.GetOrdinal("DesVersion"))
                lblFchVersion.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchVersion")))
                lblFchInicio.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchInicio")))
                lblStsVersion.Text = dr.GetValue(dr.GetOrdinal("StsVersion"))
                lblPorUtilidad.Text = String.Format("{0:##0.00}", dr.GetValue(dr.GetOrdinal("PorUtilidad")))

                If dr.GetValue(dr.GetOrdinal("CantAdultos")) > 0 Then
                    lblPasajeros.Text = "Adultos " & CStr(dr.GetValue(dr.GetOrdinal("CantAdultos")))
                End If

                If dr.GetValue(dr.GetOrdinal("CantNinos")) > 0 Then
                    lblPasajeros.Text = lblPasajeros.Text & " Niños " & CStr(dr.GetValue(dr.GetOrdinal("CantNinos")))
                End If

                If dr.GetValue(dr.GetOrdinal("FlagPublica")) = "S" Then
                    lblFlagPublica.Text = "SI"
                Else
                    lblFlagPublica.Text = "NO"
                End If

                lblFlagAtencion.Text = dr.GetValue(dr.GetOrdinal("FlagAtencion"))

                ' Verifica si puede Desaprobar
                If lblStsVersion.Text.Substring(0, 1) = "V" Then
                    'lblMsg.Text = "Ud. esta seguro que desea desaprobar"
                    cmdGrabar.Visible = True
                Else
                    cmdGrabar.Visible = False
                    If dr.GetValue(dr.GetOrdinal("FlagAtencion")) = "N" Then
                        lblMsg.Text = "La versión es modelo antiguo , no se puede desaprobar"
                    ElseIf lblStsVersion.Text.Substring(0, 1) = "C" Or lblStsVersion.Text.Substring(0, 1) = "R" Then
                        lblMsg.Text = "La versión esta en construcción, no se puede desaprobar"
                    ElseIf lblStsVersion.Text.Substring(0, 1) = "F" Then
                        lblMsg.Text = "La versión ya fue facturado, no se puede desaprobar"
                    End If
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub
End Class
