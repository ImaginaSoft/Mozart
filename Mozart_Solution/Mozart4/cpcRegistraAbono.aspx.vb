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
Imports Microsoft.ApplicationBlocks.Data

Partial Class cpcRegistraAbono
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim wCodMoneda As String


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodCliente") = Request.Params("CodCliente")
            Viewstate("NroDocumento") = Request.Params("NroDocumento")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")

            If Viewstate("NroDocumento") > 0 Then
                Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
                lblNroDocumento.Visible = True
                txtNroDocumento.Visible = True
                txtNroDocumento.Text = Viewstate("NroDocumento")
                EditaNroDocumento()
            Else
                lblNroDocumento.Visible = False
                txtNroDocumento.Visible = False
                txtFchEmision.Text = ObjRutina.fechaddmmyyyy(0)
                txtpIGV.Text = Session("PIGV")
                CargaTipoDocumento(True)
            End If

            If Viewstate("NroVersion") > 0 Then
                Viewstate("TipoDocumento") = "NA"
                CargaTipoDocumento(False)
                txtPedido.Text = "Ajuste Pedido # " & CStr(Viewstate("NroPedido")) & " Version " & CStr(Viewstate("NroVersion"))
            End If
            CargaCargos()
        End If
    End Sub


    Private Sub EditaNroDocumento()
        CargaTipoDocumento(False)

        'Dim ds As New DataSet
        'Dim da As New SqlDataAdapter
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPC_NroDocumento_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = ViewState("NroDocumento")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                txtFchEmision.Text = ToString.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("fchemision")))
                txtReferencia.Text = dr.GetValue(dr.GetOrdinal("Referencia"))
                txtpIGV.Text = String.Format("{0:##0.00}", dr.GetValue(dr.GetOrdinal("PIGV")))
                txtImporte.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Importe")))
                txtIGV.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("IGV")))
                txtTotal.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("total")))
                If dr.GetValue(dr.GetOrdinal("CodMoneda")) = "D" Then
                    rbdolar.Checked = True
                    rbsoles.Checked = False
                Else
                    rbdolar.Checked = False
                    rbsoles.Checked = True
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub CargaTipoDocumento(ByVal ptodos As Boolean)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If ptodos Then
            da.SelectCommand.CommandText = "TAB_TipoDocumentoAfectaCaja_S"
            da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "C"
            da.SelectCommand.Parameters.Add("@TipoOperacion", SqlDbType.Char, 1).Value = "A"
            da.SelectCommand.Parameters.Add("@AfectaCaja", SqlDbType.Char, 1).Value = "N"
        Else
            da.SelectCommand.CommandText = "TAB_TipoDocumento_S"
            da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "C"
            da.SelectCommand.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        End If
        da.Fill(ds, "TTipoDocumento")
        ddlTipoDocumento.DataSource = ds.Tables("TTipoDocumento")
        ddlTipoDocumento.DataBind()
    End Sub

    Private Sub CargaCargos()
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_CargosCliente_S", New SqlParameter("@CodCliente", Viewstate("CodCliente")))
        'dgServicio.DataKeyField = "KeyReg"
        dgServicio.DataSource = ds.Tables(0)
        dgServicio.DataBind()
    End Sub

    Private Sub rbdolar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdolar.CheckedChanged
        rbsoles.Checked = False
        rbdolar.Checked = True
    End Sub

    Private Sub rbsoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbsoles.CheckedChanged
        rbsoles.Checked = True
        rbdolar.Checked = False
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If Not IsNumeric(txtImporte.Text) Then
            lblmsg.Text = "Error: Importe es dato numerico"
            Return
        End If

        Dim i As Integer = 0
        Dim wCodMoneda, wMoneda As String

        'Validacionde moneda
        If rbdolar.Checked Then
            wCodMoneda = "D"
            wMoneda = "Dolares"
        Else
            wCodMoneda = "S"
            wMoneda = "Nuevos Soles"
        End If


        lblmsg.Text = ""
        Dim currentRowsFilePath As String
        For index As Integer = 0 To dgServicio.Rows.Count - 1
            Dim cb As CheckBox = CType(dgServicio.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                If wCodMoneda <> Mid(dgServicio.DataKeys(index).Value, 13, 1) Then
                    lblmsg.Text = "Seleccione Servicios con el  Tipo de moneda en " & wMoneda
                    Return
                End If
            End If

        Next

        If Len(lblmsg.Text.Trim()) <> 0 Then
            Return
        End If

        'Cargando la Tabla Temporal

        Session("IdReg") = Mid(CStr(Now) & " " & Session("CodUsuario"), 1, 25)
        'itero a traves de todas las llave primarias, y recupero su valor checked (true o false)
        For index As Integer = 0 To dgServicio.Rows.Count - 1
            Dim cb As CheckBox = CType(dgServicio.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                Dim cd As New SqlCommand
                cd.Connection = cn
                cd.CommandText = "CPC_CargosconSaldo_I"
                cd.CommandType = CommandType.StoredProcedure

                Dim pa As New SqlParameter
                pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                pa.Direction = ParameterDirection.Output
                pa.Value = ""
                cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Session("IdReg")
                cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Mid(dgServicio.DataKeys(index).Value, 1, 2)
                cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = CInt(Mid(dgServicio.DataKeys(index).Value, 3, 10))
                cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
                Try
                    cn.Open()
                    cd.ExecuteNonQuery()
                    lblmsg.Text = cd.Parameters("@MsgTrans").Value
                Catch ex1 As System.Data.SqlClient.SqlException
                    lblmsg.Text = "Error:" & ex1.Message
                Catch ex2 As System.Exception
                    lblmsg.Text = "Error:" & ex2.Message
                End Try
                cn.Close()
                If lblmsg.Text.Trim <> "OK" Then
                    Return
                End If
            End If

        Next
        If Trim(lblmsg.Text) <> "OK" And Len(Trim(lblmsg.Text)) <> 0 Then
            Return
        End If
        GrabaAbono()
    End Sub

    Private Sub GrabaAbono()
        Dim wNroDoc As String

        Dim wNroDocumento As Integer
        If Viewstate("NroDocumento") > 0 Then
            wNroDocumento = Viewstate("NroDocumento")
        Else
            wNroDocumento = 0
        End If

        Dim wNroPedido, wNroPro, wNroVer As Integer
        If Viewstate("NroVersion") > 0 Then
            wNroPedido = Viewstate("NroPedido")
            wNroPro = Viewstate("NroPropuesta")
            wNroVer = Viewstate("NroVersion")
        Else
            wNroPedido = 0
            wNroPro = 0
            wNroVer = 0
        End If
        If rbdolar.Checked Then
            wCodMoneda = "D"
        Else
            wCodMoneda = "S"
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_RegistraAbono_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroDoc", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0

        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Session("IdReg")
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = Viewstate("CodCliente")
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = wNroDocumento
        cd.Parameters.Add("@FchEmision", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchEmision.Text)
        cd.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = txtReferencia.Text
        cd.Parameters.Add("@GlosaDocumento", SqlDbType.VarChar, 50).Value = " "
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wCodMoneda
        cd.Parameters.Add("@Importe", SqlDbType.Money).Value = txtImporte.Text
        cd.Parameters.Add("@PIGV", SqlDbType.SmallMoney).Value = txtpIGV.Text
        cd.Parameters.Add("@IGV", SqlDbType.Money).Value = txtIGV.Text
        cd.Parameters.Add("@Total", SqlDbType.Money).Value = txtTotal.Text
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = wNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = wNroPro
        cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = wNroVer
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblmsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblmsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblmsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()

        If Trim(lblmsg.Text) = "OK" Then
            wNroDocumento = cd.Parameters("@NroDoc").Value
            Response.Redirect("cpcDocumento.aspx" & _
                            "?CodCliente=" & Viewstate("CodCliente"))
        End If
    End Sub

    Private Sub txtImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte.TextChanged
        CalculaTotal()
    End Sub

    Private Sub txtpIGV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpIGV.TextChanged
        CalculaTotal()
    End Sub

    Private Sub CalculaTotal()
        Dim wPIGV, wIGV, wTOTAL, wIMPORTE As Double

        If Len(Trim(txtpIGV.Text)) = 0 Then
            wPIGV = 0
        Else
            If Not IsNumeric(Trim(txtpIGV.Text)) Then
                lblmsg.Text = "Porcentaje IGV es dato númerico"
                Return
            Else
                wPIGV = txtpIGV.Text
            End If
        End If
        If Len(Trim(txtImporte.Text)) = 0 Then
            wIMPORTE = 0
        Else
            If Not IsNumeric(Trim(txtImporte.Text)) Then
                lblmsg.Text = "Importe es dato númerico"
                Return
            Else
                wIMPORTE = txtImporte.Text
                wIMPORTE = Math.Round(wIMPORTE, 2)
                txtImporte.Text = wIMPORTE
            End If
        End If
        wIGV = Math.Round(wPIGV * wIMPORTE / 100, 2)
        txtIGV.Text = CStr(wIGV)
        txtTotal.Text = CStr(wIGV + wIMPORTE)
    End Sub

    Protected Sub dgServicio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgServicio.DataBound
        Dim ArrayValues As New List(Of String)

        Try
            Dim cbHeader As CheckBox = CType(dgServicio.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
            ArrayValues.Add(String.Concat("'", cbHeader.ClientID, "'"))
        Catch ex As Exception

        End Try

        For Each gvr As GridViewRow In dgServicio.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("RowLevelCheckBox"), CheckBox)

            'If the checkbox is unchecked, ensure that the Header CheckBox is unchecked
            cb.Attributes("onclick") = "ChangeHeaderAsNeeded();"

            'Add the CheckBox's ID to the client-side CheckBoxIDs array
            ArrayValues.Add(String.Concat("'", cb.ClientID, "'"))
        Next

        'Output the array to the Literal control (CheckBoxIDsArray)
        CheckBoxIDsArray.Text = "<script type=""text/javascript"">" & vbCrLf & _
                                "<!--" & vbCrLf & _
                                String.Concat("var CheckBoxIDs =  new Array(", String.Join(",", ArrayValues.ToArray()), ");") & vbCrLf & _
                                "// -->" & vbCrLf & _
                                "</script>"



    End Sub
End Class
