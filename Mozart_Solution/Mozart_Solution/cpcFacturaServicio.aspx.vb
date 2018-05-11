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
Imports System.Web.Mail


Partial Class cpcFacturaServicio
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Dim MsgTrans As String = " "
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Dim objRutina As New cmpRutinas.clsRutinas
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter

            'Tipo Documento Cargo
            da.SelectCommand = New SqlCommand
            da.SelectCommand.Connection = cn
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            da.SelectCommand.CommandText = "TAB_TipoDocumento_S"
            da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "C"
            da.SelectCommand.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = "DC"
            da.Fill(ds, "TTipoDocumento")
            ddlTipoDocumento.DataSource = ds.Tables("TTipoDocumento")
            ddlTipoDocumento.DataBind()

            CargaCliente(0)
            txtFchInicial.Text = ObjRutina.fechaddmmyyyy(0)

            cmdGrabar.Visible = False
        End If
    End Sub

    Private Sub CargaServicios()
        txtTotal.Text = ""
        lblError.Text = ""
        cmdGrabar.Visible = False

        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "CPC_FacturarVersion_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = New SqlParameter("@CodCliente", SqlDbType.Int)
        If ddlCliente.Items.Count = 0 Then
            pa.Value = 0
        Else
            If ddlCliente.SelectedItem.Value = "Elegir Cliente" Then
                pa.Value = 0
            Else
                pa.Value = ddlCliente.SelectedItem.Value
            End If
        End If

        da.SelectCommand.Parameters.Add(pa)

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Servicios")
        'dgServicio.DataKeyField = "KeyReg"

        'se instancia un DataView para que se puedan ordenar los datos
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgServicio.DataSource = dv
        dgServicio.DataBind()

        ' lblmsg.Text = CStr(nReg) + " Versiones encontradas "

        If nReg = 0 Then
            cmdTotalizar.Visible = False
        Else
            cmdTotalizar.Visible = True
        End If

    End Sub

    Private Sub ddlCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCliente.SelectedIndexChanged
        CargaServicios()
        LimpiaCampos()
    End Sub

    Private Sub cmdTotalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTotalizar.Click
        LimpiaCampos()

        Dim currentRowsFilePath As String

        Dim i As Integer = 0

        'Cargando la Tabla Temporal
        'Session("IdReg") = CStr(Now)
        Dim wFchSys As Date = ObjRutina.FchSys
        Session("IdReg") = ToString.Format("{0:yyyyMMdd}", wFchSys) + " " + ToString.Format("{0:hh:mm:ss}", wFchSys) + Mid(Session("CodUsuario"), 1, 8)


        Dim wTotal As Double = 0
        Dim wNroPedidoFact As Integer = 0

        lblError.Text = ""
        lblBodyEmail.Text = "Cliente : " & ddlCliente.SelectedItem.Text & "<br><br>"

        For index As Integer = 0 To dgServicio.Rows.Count - 1
            Dim cb As CheckBox = CType(dgServicio.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then

                lblBodyEmail.Text = lblBodyEmail.Text & "Pedido N° " & Mid(dgServicio.DataKeys(index).Value, 1, 10)
                lblBodyEmail.Text = lblBodyEmail.Text & "   Versión N° " & Mid(dgServicio.DataKeys(index).Value, 14, 3) & "<br>"

                ' Desde la lista de pedidos seleccionados para facturar toma el 1er N° Pedido
                If wNroPedidoFact = 0 Then
                    wNroPedidoFact = Mid(dgServicio.DataKeys(index).Value, 1, 10)
                End If

                'Verifica que es un solo pedido el que se va ha facturar
                If wNroPedidoFact <> Mid(dgServicio.DataKeys(index).Value, 1, 10) Then
                    lblError.Text = "Error: Ud. está seleccionando varios pedidos. Solo esta permitido un Pedido y varias versiones"
                Else
                    Dim cd As New SqlCommand
                    cd.Connection = cn
                    cd.CommandText = "CPC_FacturarVersion1_I"
                    cd.CommandType = CommandType.StoredProcedure

                    Dim pa As New SqlParameter
                    pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                    pa.Direction = ParameterDirection.Output
                    pa.Value = ""
                    cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Session("IdReg")
                    cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ddlCliente.SelectedItem.Value()
                    cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Mid(dgServicio.DataKeys(index).Value, 1, 10)
                    cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Mid(dgServicio.DataKeys(index).Value, 11, 3)
                    cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = Mid(dgServicio.DataKeys(index).Value, 14, 3)
                    cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
                    Try
                        cn.Open()
                        cd.ExecuteNonQuery()
                        lblError.Text = cd.Parameters("@MsgTrans").Value
                    Catch ex1 As System.Data.SqlClient.SqlException
                        lblError.Text = "Error:" & ex1.Message
                    Catch ex2 As System.Exception
                        lblError.Text = "Error:" & ex2.Message
                    End Try
                    cn.Close()
                    If lblError.Text.Trim = "OK" Then
                        Session("NroPedido") = Mid(dgServicio.DataKeys(index).Value, 1, 10)
                        wTotal = wTotal + Mid(dgServicio.DataKeys(index).Value, 17, 10)
                        txtFchEmision3.Text = Mid(dgServicio.DataKeys(index).Value, 27, 10)
                    End If
                End If
            End If
        Next

        If Mid(lblError.Text, 1, 5) = "Error" Then
            Return
        End If

        txtTotal.Text = String.Format("{0:###,###,###.00}", wTotal, 2)

        If txtTotal.Text.Trim.Length > 0 Then
            txtp1.Text = "30"
            txtp3.Text = "70"

            CalculaMontos()

            txtFchEmision1.Text = ObjRutina.fechaddmmyyyy(0)
            cmdGrabar.Visible = True
        End If
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wTotal, wTotal1, wTotal2, wTotal3 As Double

        If txtMonto1.Text.Trim.Length = 0 Then
            wTotal1 = 0
        Else
            If IsNumeric(txtMonto1.Text) Then
                wTotal1 = txtMonto1.Text
                If txtFchEmision1.Text.Trim.Length <> 10 Then
                    lblError.Text = "Error: Falta seleccionar fecha para cuota 1"
                    Return
                End If
            Else
                lblError.Text = "Error: Monto 1 es dato númerico"
                Return
            End If
        End If

        If txtMonto2.Text.Trim.Length = 0 Then
            wTotal2 = 0
        Else
            If IsNumeric(txtMonto2.Text) Then
                wTotal2 = txtMonto2.Text
                If txtFchEmision2.Text.Trim.Length <> 10 Then
                    lblError.Text = "Error: Falta seleccionar fecha para cuota 2"
                    Return
                End If
            Else
                lblError.Text = "Error: Monto 2 es dato númerico"
                Return
            End If
        End If

        If txtMonto3.Text.Trim.Length = 0 Then
            wTotal3 = 0
        Else
            If IsNumeric(txtMonto3.Text) Then
                wTotal3 = txtMonto3.Text
                If txtFchEmision3.Text.Trim.Length <> 10 Then
                    lblError.Text = "Error: Falta seleccionar fecha para cuota 3"
                    Return
                End If
            Else
                lblError.Text = "Error: Monto 3 es dato númerico"
                Return
            End If
        End If

        wTotal = Math.Round(wTotal1 + wTotal2 + wTotal3, 2)
        If CDbl(txtTotal.Text) = wTotal Then
            'pasa
        Else
            lblError.Text = "Error: Suma de Cuotas = " & ToString.Format("{0:####,###,###.00}", wTotal) & " diferente al Total = " & ToString.Format("{0:####,###,###.00}", CDbl(txtTotal.Text))
            Return
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_FacturarVersion2_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroDoc", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0
        pa = cd.Parameters.Add("@TotalFact", SqlDbType.Money)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0
        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Session("IdReg")
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ddlCliente.SelectedItem.Value
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Session("NroPedido")
        cd.Parameters.Add("@Total1", SqlDbType.Money).Value = wTotal1
        cd.Parameters.Add("@Total2", SqlDbType.Money).Value = wTotal2
        cd.Parameters.Add("@Total3", SqlDbType.Money).Value = wTotal3
        cd.Parameters.Add("@FchEmision1", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchEmision1.Text)
        cd.Parameters.Add("@FchEmision2", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchEmision2.Text)
        cd.Parameters.Add("@FchEmision3", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchEmision3.Text)
        cd.Parameters.Add("@FchVersion", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchInicial.Text)
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblError.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblError.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblError.Text = "Error:" & ex2.Message
        End Try
        cn.Close()

        If Trim(lblError.Text.Trim) = "OK" Then
            CargaCliente(ddlCliente.SelectedItem.Value)
            CargaServicios()
            LimpiaCampos()
            cmdGrabar.Visible = False
        End If
    End Sub

    Private Sub CargaCliente(ByVal pCodCliente As Integer)
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        Dim nReg As Integer = 0

        If pCodCliente > 0 Then
            'Verifica que el cliente tiene servicios pendientes de facturar
            da.SelectCommand = New SqlCommand
            da.SelectCommand.Connection = cn
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.CommandText = "CPC_FacturarVersionCli2_S"
            da.SelectCommand.Parameters.Add("@CodCliente", SqlDbType.Int).Value = pCodCliente
            nReg = da.Fill(ds, "Servicios")
        End If

        ' Carga Clientes 
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "CPC_FacturarVersionCli_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.Fill(ds, "Cliente")
        ddlCliente.DataSource = ds.Tables("Cliente")
        ddlCliente.DataBind()

        If ddlCliente.Items.Count > 0 Then
            If nReg > 0 Then
                ddlCliente.Items.FindByValue(pCodCliente).Selected = True
            Else
                ddlCliente.Items.Insert(0, New ListItem("Elegir Cliente"))
                ddlCliente.Items.FindByValue("Elegir Cliente").Selected = True
            End If
        End If
    End Sub

    Private Sub txtp1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtp1.TextChanged
        If txtp1.Text.Trim.Length = 0 Then
            CalculaMontos()
        Else
            If IsNumeric(txtp1.Text) Then
                If CDbl(txtp1.Text) >= 0 And CDbl(txtp1.Text) <= 100 Then
                    CalculaMontos()
                Else
                    lblError.Text = "Error: Porcentaje esta fuera rango válido [0%-100%]"
                End If
            Else
                lblError.Text = "Error: Porcentaje es dato númerico"
            End If
        End If
    End Sub

    Private Sub CalculaMontos()
        If txtTotal.Text.Trim.Length > 0 Then
            Dim wp1 As Double = 0
            If txtp1.Text.Trim.Length > 0 Then
                wp1 = txtp1.Text
            End If

            txtp3.Text = 100 - CDbl(wp1)
            ' Se calcula el 1er. monto y por diferencia el 3ro monto
            txtMonto1.Text = String.Format("{0:###,###,###.00}", Math.Round(CDbl(txtTotal.Text) * (CDbl(wp1) / 100), 2))
            txtMonto3.Text = String.Format("{0:###,###,###.00}", Math.Round(CDbl(txtTotal.Text) - CDbl(txtMonto1.Text), 2))
        End If

    End Sub

    Private Sub LimpiaCampos()
        txtp1.Text = ""
        txtp3.Text = ""
        txtMonto1.Text = ""
        txtMonto2.Text = ""
        txtMonto3.Text = ""
        txtFchEmision1.Text = ""
        txtFchEmision2.Text = ""
        txtFchEmision3.Text = ""
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

    Protected Sub dgServicio_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles dgServicio.Sorting
        ViewState("Campo") = e.SortExpression()
        CargaServicios()
    End Sub
End Class
