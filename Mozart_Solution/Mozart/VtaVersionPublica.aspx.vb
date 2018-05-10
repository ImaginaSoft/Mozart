Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class VtaVersionPublica
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
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

            lblTitulo.Text = "Publica Versión N° " & Viewstate("NroVersion")
            Viewstate("TipoCambio") = objRutina.LeeParametroNumero("TipoCambioEuro")
        End If

    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wFlagPublica As String
        Dim wFlagPublicaEuro As String
        Dim wFlagAtencion As String
        ' Publica Version
        If rbtSi.Checked = True Then
            wFlagPublica = "S" 'SI
        Else
            wFlagPublica = "N" 'NO
        End If

        ' Publica en EUROS
        If rbtEuroSI.Checked = True Then
            wFlagPublicaEuro = "S" 'SI
        Else
            wFlagPublicaEuro = "N" 'NO
        End If

        ' Muestra itinerario en número de dias o fechas    
        If rbtNroDia.Checked = True Then
            wFlagAtencion = "D" ' Dias
        Else
            If txtFchInicio.Text.Trim.Length = 0 Then
                lblMsg.Text = "Fecha inicio es obligatorio, para mostrar itinerario con fechas"
                Return
            Else
                wFlagAtencion = "F" ' Fechas
            End If
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionPublica_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        cd.Parameters.Add("@FlagPublica", SqlDbType.Char, 1).Value = wFlagPublica
        cd.Parameters.Add("@FlagPublicaEuro", SqlDbType.Char, 1).Value = wFlagPublicaEuro
        cd.Parameters.Add("@TipoCambioEuro", SqlDbType.SmallMoney).Value = lblTipoCambioEuro.Text
        cd.Parameters.Add("@FlagAtencion", SqlDbType.Char, 1).Value = wFlagAtencion
        cd.Parameters.Add("@FchInicio", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchInicio.Text)
        cd.Parameters.Add("@StsCaptacion", SqlDbType.Char, 1).Value = ddlStsCaptacion.SelectedItem.Value
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
                     "?NroPedido=" & Viewstate("NroPedido") & _
                     "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                     "&NroVersion=" & Viewstate("NroVersion"))
        End If
    End Sub

    Private Sub EditaVersion()
        Dim wStsCaptacion As String
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
                lblStsVersion.Text = dr.GetValue(dr.GetOrdinal("StsVersion"))
                lblPorUtilidad.Text = String.Format("{0:##0.00}", dr.GetValue(dr.GetOrdinal("PorUtilidad")))
                lblTipoCambioEuro.Text = String.Format("{0:##,##0.0000}", dr.GetValue(dr.GetOrdinal("TipoCambioEuro")))

                If dr.GetValue(dr.GetOrdinal("CantAdultos")) > 0 Then
                    lblPasajeros.Text = "Adultos " & CStr(dr.GetValue(dr.GetOrdinal("CantAdultos")))
                End If

                If dr.GetValue(dr.GetOrdinal("CantNinos")) > 0 Then
                    lblPasajeros.Text = lblPasajeros.Text & " Niños " & CStr(dr.GetValue(dr.GetOrdinal("CantNinos")))
                End If

                If dr.GetValue(dr.GetOrdinal("FlagPublica")) = "S" Then
                    rbtSi.Checked = True
                Else
                    rbtNo.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("FlagPublicaEuro")) = "S" Then
                    rbtEuroSI.Checked = True
                Else
                    rbtEuroNO.Checked = True
                End If

                If dr.GetValue(dr.GetOrdinal("FlagAtencion")) = "D" Then
                    rbtNroDia.Checked = True
                Else
                    rbtFecha.Checked = True
                End If

                If Not IsDBNull(dr.GetValue(dr.GetOrdinal("FchInicio"))) Then
                    txtFchInicio.Text = ToString.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("fchInicio")))
                End If

                wStsCaptacion = dr.GetValue(dr.GetOrdinal("StsCaptacion"))

                ' Verifica si puede actualizar
                If lblStsVersion.Text.Substring(0, 1) = "C" Or lblStsVersion.Text.Substring(0, 1) = "R" Then
                    cmdGrabar.Visible = True
                Else
                    cmdGrabar.Visible = False
                    lblMsg.CssClass = "msg"
                    If dr.GetValue(dr.GetOrdinal("FlagEdita")) = "E" Then
                        lblMsg.Text = "La versión es de otra empresa, no se puede modificar"
                    ElseIf dr.GetValue(dr.GetOrdinal("FlagEdita")) = "N" Then
                        lblMsg.Text = "La versión es modelo antiguo, no se puede modificar"
                    ElseIf lblStsVersion.Text.Substring(0, 1) = "V" Then
                        lblMsg.Text = "La versión ya fue vendido, está pendiente de facturar los servicios"
                    ElseIf lblStsVersion.Text.Substring(0, 1) = "F" Then
                        lblMsg.Text = "La versión ya fue facturado, no se puede modificar"
                    End If
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
        CargaStsCaptacion(wStsCaptacion)
    End Sub

    Private Sub CargaStsCaptacion(ByVal pStsCaptacion As String)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "TAB_StsCaptacion_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim ds As New DataSet
        da.Fill(ds, "StsCaptacion")
        ddlStsCaptacion.DataSource = ds.Tables("StsCaptacion")
        ddlStsCaptacion.DataBind()
        If pStsCaptacion.Trim.Length > 0 Then
            ddlStsCaptacion.Items.FindByValue(pStsCaptacion).Selected = True
        End If
    End Sub

    Private Sub rbtEuroSI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtEuroSI.CheckedChanged
        lblTipoCambioEuro.Text = Viewstate("TipoCambio")
    End Sub

    Private Sub rbtEuroNO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtEuroNO.CheckedChanged
        lblTipoCambioEuro.Text = "0.0"
    End Sub


End Class
