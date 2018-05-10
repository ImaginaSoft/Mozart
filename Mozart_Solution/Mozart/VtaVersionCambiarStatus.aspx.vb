Imports cmpNegocio
Imports cmpTabla
Imports System.Data
Imports System.Drawing

Partial Class VtaVersionCambiarStatus
    Inherits System.Web.UI.Page
    Dim objStsReserva As New clsStsReserva
    Dim objProveedor As New clsVersionDet
    Dim objVersionDet As New clsVersionDet
    Dim objReserva As New clsReserva

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("FlagEdita") = Request.Params("FlagEdita")

            lblTitulo.Text = "Cambiar el estado de la Reserva - Versión N° " & Viewstate("NroVersion")
            CargaStsReserva()
            CargaProveedor(0)
            CargaServicios()
        End If
    End Sub

    Private Sub CargaStsReserva()
        Dim ds As New DataSet
        ds = objStsReserva.Cargar
        ddlStsReserva.DataSource = ds
        ddlStsReserva.DataBind()
    End Sub

    Private Sub CargaProveedor(ByVal pCodProveedor As Integer)
        Dim ds As New DataSet
        ds = objProveedor.CargaProveedoresReserva(Viewstate("NroPedido"), Viewstate("NroPropuesta"), Viewstate("NroVersion"))
        ddlProveedor.DataSource = ds
        ddlProveedor.DataBind()
        Try
            ddlProveedor.Items.FindByValue(pCodProveedor).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargaServicios()
        Dim ds As New DataSet
        If ddlProveedor.SelectedItem.Value = 0 Then
            ds = objVersionDet.CargaServicios(Viewstate("NroPedido"), Viewstate("NroPropuesta"), Viewstate("NroVersion"))
        Else
            ds = objVersionDet.CargaServicios(Viewstate("NroPedido"), Viewstate("NroPropuesta"), Viewstate("NroVersion"), ddlProveedor.SelectedItem.Value)
        End If
        'dgServicio.DataKeyField = "KeyReg"
        dgServicio.DataSource = ds
        dgServicio.DataBind()
    End Sub



    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If ddlStsReserva.Items.Count() = 0 Then
            lblMsg.Text = "No existe estados de la reserva"
            Return
        End If

        Dim wCheck As Boolean = False
        Dim wNroDia, wNroOrden, wNroServicio As Integer
        Dim i As Integer = 0

        Dim currentRowsFilePath As String

        For index As Integer = 0 To dgServicio.Rows.Count - 1
            Dim cb As CheckBox = CType(dgServicio.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                wCheck = True
                wNroDia = Mid(dgServicio.DataKeys(index).Value, 13, 2)
                wNroOrden = Mid(dgServicio.DataKeys(index).Value, 15, 2)
                wNroServicio = Mid(dgServicio.DataKeys(index).Value, 17, 8)

                objVersionDet.NroPedido = ViewState("NroPedido")
                objVersionDet.NroPropuesta = ViewState("NroPropuesta")
                objVersionDet.NroVersion = ViewState("NroVersion")
                objVersionDet.NroDia = wNroDia
                objVersionDet.NroOrden = wNroOrden
                objVersionDet.NroServicio = wNroServicio
                objVersionDet.CodStsReserva = ddlStsReserva.SelectedItem.Value
                objVersionDet.CodUsuario = Session("CodUsuario")
                lblMsg.Text = objVersionDet.GrabarCambioStsServicio
                If lblMsg.Text.Trim <> "OK" Then
                    Return
                End If
            End If
        Next

        If wCheck Then
            If ddlProveedor.SelectedItem.Value > 0 Then
                CheckProveedor() ' Recarga proveedor+servicios
            Else
                CargaServicios() ' recarga solo servicios
            End If
        End If
    End Sub

    Private Sub lbtFichaVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaVersion.Click
        Response.Redirect("VtaVersionFicha.aspx" & _
            "?NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta") & _
            "&NroVersion=" & Viewstate("NroVersion"))
    End Sub


    Private Sub ddlProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProveedor.SelectedIndexChanged
        CheckProveedor()
    End Sub

    Private Sub CheckProveedor()
        cmdPedidosContratados.Enabled = False
        cmdPedidosAnulados.Enabled = False

        lblReserva.Text = ""
        If ddlProveedor.SelectedItem.Value > 0 Then
            lblMsg.Text = objReserva.EditarCodSolicita(Viewstate("NroPedido"), Viewstate("NroPropuesta"), Viewstate("NroVersion"), ddlProveedor.SelectedItem.Value)
            If lblMsg.Text.Trim = "OK" Then
                lblCodSolicita.Text = objReserva.CodSolicita

                If objReserva.DesRpta.Trim = "OK" Then
                    lblReserva.Text = "Versión OK, está en Pedidos Contratados"
                ElseIf objReserva.DesRpta.Trim = "AN" Then
                    lblReserva.Text = "Versión Anulado"
                ElseIf objReserva.CodSolicita.Trim = "C" Then 'Pendiente de confirmar
                    lblReserva.Text = "Versión pendiente de confirmar reserva, Rpta actual " & objReserva.DesRpta
                    lblNroFile.Text = objReserva.NroFile
                    cmdPedidosContratados.Enabled = True
                ElseIf objReserva.CodSolicita.Trim = "R" Then 'Pendiente de reserva
                    lblReserva.Text = "Versión en proceso de reserva"
                    cmdPedidosContratados.Enabled = True
                ElseIf objReserva.CodSolicita.Trim = "A" Then ' Pendiente de anular
                    lblReserva.Text = "Versión pendiente de eliminar reserva"
                    cmdPedidosAnulados.Enabled = True
                End If
            Else
                lblReserva.Text = lblMsg.Text
            End If
            lblMsg.Text = ""
            CargaServicios()
        End If
    End Sub
    Private Sub cmdPedidosContratados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPedidosContratados.Click
        If lblCodSolicita.Text = "C" Then
            objReserva.NroPedido = Viewstate("NroPedido")
            objReserva.NroPropuesta = Viewstate("NroPropuesta")
            objReserva.NroVersion = Viewstate("NroVersion")
            objReserva.CodProveedor = ddlProveedor.SelectedItem.Value
            objReserva.PrecioRpta = 0
            objReserva.NroFile = lblNroFile.Text
            objReserva.Deslog = ""
            objReserva.CantDesLog = 0
            objReserva.CodUsuario = Session("CodUsuario")
            'update OK todos los servicios del proveedor (solo pendiente)
            lblMsg.Text = objReserva.ConfirmaDeMozart
            If lblMsg.Text.Trim = "OK" Then
                'update ok la reserva
                lblMsg.Text = objReserva.Confirma
                If lblMsg.Text.Trim = "OK" Then
                    CheckProveedor()
                End If
            Else
                lblMsg.Text = "Error al actualizar OK los servicios de Version-Proveedor"
                lblMsg.CssClass = "error"
            End If
        Else
            lblMsg.Text = lblReserva.Text
            lblMsg.CssClass = "error"
        End If

    End Sub

    Private Sub cmdPedidosAnulados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPedidosAnulados.Click
        If lblCodSolicita.Text = "A" Then
            objReserva.NroPedido = Viewstate("NroPedido")
            objReserva.NroPropuesta = Viewstate("NroPropuesta")
            objReserva.NroVersion = Viewstate("NroVersion")
            objReserva.CodProveedor = ddlProveedor.SelectedItem.Value
            objReserva.Deslog = ""
            objReserva.CantDesLog = 0
            objReserva.CodUsuario = Session("CodUsuario")
            lblMsg.Text = objReserva.Anula
            If lblMsg.Text.Trim = "OK" Then
                CheckProveedor()
            End If
        Else
            lblMsg.Text = lblReserva.Text
            lblMsg.CssClass = "error"
        End If
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

    Protected Sub dgServicio_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgServicio.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(7).Text.Trim = "OK" Or e.Row.Cells(7).Text.Trim = "OF" Then
                e.Row.Cells(7).ForeColor = Color.Blue
            Else
                e.Row.Cells(5).ForeColor = Color.Red
                e.Row.Cells(6).ForeColor = Color.Red
                e.Row.Cells(7).ForeColor = Color.Red
            End If
        End If

    End Sub
End Class
