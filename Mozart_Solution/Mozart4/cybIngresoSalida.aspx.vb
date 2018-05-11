Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Partial Class cybIngresoSalida
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroDocumento") = Request.Params("NroDocumento")
            txtFchEmision.Text = ObjRutina.fechaddmmyyyy(0)

            'Tipo Documento Abono
            Dim wpcodBanco, wMoneda As String
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter
            da.SelectCommand = New SqlCommand
            da.SelectCommand.Connection = cn
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.CommandText = "TAB_TipoDocumentoBancos_S"
            da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "B"
            da.Fill(ds, "TTipoDocumento")
            ddlTipoDocumento.DataSource = ds.Tables("TTipoDocumento")
            ddlTipoDocumento.DataBind()

            If rbdolar.Checked Then
                wMoneda = "D"
            Else
                wMoneda = "S"
            End If

            If Viewstate("NroDocumento") = 0 Then
                CargaBanco("", wMoneda)
            Else
                Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
                ddlTipoDocumento.Items.FindByValue(Viewstate("TipoDocumento")).Selected = True
                ddlTipoDocumento.Enabled = False
                CargaDocumento()
            End If

        End If
    End Sub

    Public Sub CargaDocumento()
        lblNumero.Visible = True
        txtNumero.Visible = True
        txtNumero.Text = ViewState("NroDocumento")
        Dim wPIGV As Double = 0
        Dim wCodMoneda, wCodBanco, wSecBanco As String

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CYB_DBancoNroDoc_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                wCodMoneda = dr.GetValue(dr.GetOrdinal("CodMoneda"))
                wCodBanco = dr.GetValue(dr.GetOrdinal("CodBanco"))
                wSecBanco = dr.GetValue(dr.GetOrdinal("SecBanco"))
                txtFchEmision.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchEmision")))
                txtReferencia.Text = dr.GetValue(dr.GetOrdinal("Referencia"))
                txtImporte.Text = dr.GetValue(dr.GetOrdinal("Total"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        If wCodMoneda = "S" Then
            rbsoles.Checked = True
            rbdolar.Checked = False
        End If
        If wCodMoneda = "D" Then
            rbsoles.Checked = False
            rbdolar.Checked = True
        End If

        CargaBanco(wCodBanco, wCodMoneda)
        ddlNroCuenta.Items.FindByValue(wSecBanco).Selected = True
    End Sub

    Private Sub CargaBanco(ByVal pCodBanco As String, ByVal pmoneda As String)
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_BancoActivo_S"
        da.Fill(ds, "TBanco")
        ddlBanco.DataSource = ds.Tables("TBanco")
        ddlBanco.DataBind()
        If pCodBanco.Trim.Length > 0 Then
            ddlBanco.Items.FindByValue(pCodBanco).Selected = True
        End If

        If ddlBanco.Items.Count > 0 Then
            CargaNroCuenta(ddlBanco.SelectedItem.Value, pmoneda)
        Else
            CargaNroCuenta(" ", "")
        End If
    End Sub
    Private Sub CargaNroCuenta(ByVal pcodBanco As String, ByVal wMoneda As String)
        Dim wpcodBanco As String
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_BancoCuenta_S"
        da.SelectCommand.Parameters.Add("@CodBanco", SqlDbType.Char, 3).Value = pcodBanco
        da.SelectCommand.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wMoneda
        da.Fill(ds, "TBancoCuenta")
        ddlNroCuenta.DataSource = ds.Tables("TBancoCuenta")
        ddlNroCuenta.DataBind()
    End Sub


    Private Sub rbdolar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdolar.CheckedChanged
        Dim wpcodBanco, wMoneda As String

        rbsoles.Checked = False
        rbdolar.Checked = True
        wpcodBanco = ddlBanco.SelectedItem.Value
        If rbdolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If

        If Len(Trim(wpcodBanco)) <> 0 Then
            CargaNroCuenta(wpcodBanco, wMoneda)
        End If
    End Sub

    Private Sub rbsoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbsoles.CheckedChanged
        Dim wpcodBanco, wMoneda As String
        rbsoles.Checked = True
        rbdolar.Checked = False
        wpcodBanco = ddlBanco.SelectedItem.Value
        If rbdolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If

        If Len(Trim(wpcodBanco)) <> 0 Then
            CargaNroCuenta(wpcodBanco, wMoneda)
        End If
    End Sub
    Private Sub ddlBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlBanco.SelectedIndexChanged
        Dim wpcodBanco, wMoneda As String
        wpcodBanco = ddlBanco.SelectedItem.Value
        If rbdolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If

        If Len(Trim(wpcodBanco)) <> 0 Then
            CargaNroCuenta(wpcodBanco, wMoneda)
        End If
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If Not IsNumeric(txtImporte.Text) Then
            lblmsg.Text = " El Importe es un dato numérico"
            Return
        End If

        Dim cd As New SqlCommand
        Dim wMoneda, wNroDoc As String
        If rbdolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If
        cd.Connection = cn
        cd.CommandText = "CYB_IngresosSalidas_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroDoc", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0

        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        cd.Parameters.Add("@CodBanco", SqlDbType.Char, 3).Value = ddlBanco.SelectedItem.Value
        cd.Parameters.Add("@SecBanco", SqlDbType.Char, 2).Value = ddlNroCuenta.SelectedItem.Value
        cd.Parameters.Add("@FchEmision", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchEmision.Text)
        cd.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = txtReferencia.Text
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wMoneda
        cd.Parameters.Add("@Total", SqlDbType.Money).Value = txtImporte.Text
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")

        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblmsg.Text = cd.Parameters("@MsgTrans").Value
            wNroDoc = cd.Parameters("@NroDoc").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblmsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblmsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()

        If Trim(lblmsg.Text) = "OK" Then
            Response.Redirect("cybDocumentoBancos.aspx" & _
            "?Fecha=" & txtFchEmision.Text)
        End If
    End Sub

End Class
