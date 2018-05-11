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

Partial Class cppRegistraLiq
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("CodProveedor") = Request.Params("CodProveedor")
            ViewState("TipoDocumento") = Request.Params("TipoDocumento")
            ViewState("NroDocumento") = Request.Params("NroDocumento")
            ViewState("Tabla") = Request.Params("Tabla")
            CargaAbonos()
            EditaNroDocumento()
        End If

    End Sub

    Private Sub EditaNroDocumento()
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandType = CommandType.StoredProcedure
        If Viewstate("Tabla") = "B" Then
            cd.CommandText = "CYB_ConsultaNroDocumento_S"
        Else
            cd.CommandText = "cpp_ProveedorDocDet_S"
            cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        End If
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblTipoDocumento.Text = dr.GetValue(dr.GetOrdinal("NomDocumento"))
                lblNroDocumento.Text = ViewState("NroDocumento")
                lblFchEmision.Text = ToString.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("fchemision")))
                lblStsDoc.Text = dr.GetValue(dr.GetOrdinal("DesStsDocumento"))
                lblReferencia.Text = dr.GetValue(dr.GetOrdinal("Referencia"))


                lblPago.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("Total"))) & " " & dr.GetValue(dr.GetOrdinal("Moneda"))
                lblPendiente.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("Saldo"))) & " " & dr.GetValue(dr.GetOrdinal("Moneda"))
                lblsaldo.Text = dr.GetValue(dr.GetOrdinal("Saldo"))
                lblCodMoneda.Text = dr.GetValue(dr.GetOrdinal("CodMoneda"))
                lblMoneda.Text = dr.GetValue(dr.GetOrdinal("Moneda"))
                'Datos si es documento de bancos
                If ViewState("Tabla") = "B" Then
                    lblImporte.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("DocMonto"))) & " " & dr.GetValue(dr.GetOrdinal("DesMoneda"))
                    lblTipoCambio.Text = dr.GetValue(dr.GetOrdinal("tipocambio"))
                    lblNomBanco.Text = dr.GetValue(dr.GetOrdinal("NomBanco"))
                    lblNroCuenta.Text = dr.GetValue(dr.GetOrdinal("NroCuenta"))
                End If

                If dr.GetValue(dr.GetOrdinal("Saldo")) = 0 Then
                    lblmsg.Text = "Documento ya fue liquidado, monto pendiente es cero"
                    cmdGrabar.Enabled = False
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub


    Private Sub CargaAbonos()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_AbonosProveedor_S"
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        Dim ds As New DataSet()
        Dim nReg As Integer = da.Fill(ds, "Documento")
        'dgDocumento.DataKeyField = "KeyReg"
        dgDocumento.DataSource = ds.Tables("Documento")
        dgDocumento.DataBind()
        lblmsg.Text = CStr(nReg) + " Documento(s) encontrado(s)"
    End Sub


    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim i As Integer = 0

        'Validacion de moneda pago a proveedor
        lblmsg.Text = ""
        Dim currentRowsFilePath As String

        For index As Integer = 0 To dgDocumento.Rows.Count - 1
            Dim cb As CheckBox = CType(dgDocumento.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                If lblCodMoneda.Text <> Mid(dgDocumento.DataKeys(index).Value, 3, 1) Then
                    lblmsg.Text = "Seleccione Servicios con el  Tipo de moneda en " & lblMoneda.Text
                    Return
                End If
            End If

        Next
        If Len(lblmsg.Text.Trim()) <> 0 Then
            Return
        End If

        'Cargando la Tabla Temporal

        Session("IdReg") = CStr(Now)
        'itero a traves de todas las llave primarias, y recupero su valor checked (true o false)
        For index As Integer = 0 To dgDocumento.Rows.Count - 1
            Dim cb As CheckBox = CType(dgDocumento.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                Dim cd As New SqlCommand
                cd.Connection = cn
                cd.CommandText = "CPP_AbonosconSaldo_I"
                cd.CommandType = CommandType.StoredProcedure

                Dim pa As New SqlParameter()
                pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                pa.Direction = ParameterDirection.Output
                pa.Value = ""
                cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Session("IdReg")
                cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Mid(dgDocumento.DataKeys(index).Value, 1, 2)
                cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = CInt(Mid(dgDocumento.DataKeys(index).Value, 4, 9))
                cd.Parameters.Add("@Pago", SqlDbType.Money).Value = 0
                cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
                cn.Open()
                cd.ExecuteNonQuery()
                lblmsg.Text = cd.Parameters("@MsgTrans").Value
                cn.Close()
            End If
        Next
        GrabaPagos()
    End Sub

    Private Sub GrabaPagos()
        If CDbl(lblsaldo.Text) = 0 Then
            lblmsg.Text = "No existe monto pendiente para liquidar"
            Return
        End If

        Dim cd As New SqlCommand()
        cd.Connection = cn
        cd.CommandText = "CPP_RegistraLiq_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter()
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Session("IdReg")
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        cd.Parameters.Add("@Tabla", SqlDbType.Char, 1).Value = Viewstate("Tabla")
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
            Response.Redirect("cppDocumento.aspx" & _
                    "?CodProveedor=" & Viewstate("CodProveedor"))
        End If
    End Sub


    Protected Sub dgDocumento_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDocumento.DataBound
        Dim ArrayValues As New List(Of String)

        Try
            Dim cbHeader As CheckBox = CType(dgDocumento.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
            ArrayValues.Add(String.Concat("'", cbHeader.ClientID, "'"))
        Catch ex As Exception

        End Try

        For Each gvr As GridViewRow In dgDocumento.Rows
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
