Imports cmpTabla
Imports cmpNegocio
Imports System.Data
Imports System.Drawing

Partial Class VtaPlantillaBusca
    Inherits System.Web.UI.Page
    Dim objZonaVta As New clsZonaVta
    Dim objPlantilla As New clsPlantilla
    Dim objTablaElemento As New clsTablaElemento
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            ddlZonaVta.DataSource = objZonaVta.Cargar(Session("CodUsuario"))
            ddlZonaVta.DataBind()

            ddlTipoPlantilla.DataSource = objTablaElemento.CargaTablaEleNumxNroOrden(7, "E")
            ddlTipoPlantilla.DataBind()
        End If
    End Sub


    Private Sub dgPlantilla_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgPlantilla.SortCommand
        ViewState("Campo") = e.SortExpression()
        If rbtTitulo.Checked Then
            If txtCantDias.Text.Trim.Length = 0 Then
                CargaPlantilla("T")
            Else
                CargaPlantilla("D")
            End If
        ElseIf rbtFlag.Checked Then
            CargaPlantilla("F")
        Else
            CargaPlantilla("N")
        End If
    End Sub

    Private Sub dgPlantilla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPlantilla.SelectedIndexChanged
        Session("NroPlantilla") = CInt(dgPlantilla.Items(dgPlantilla.SelectedIndex).Cells(1).Text())
        Response.Redirect("VtaPlantillaFicha.aspx" & _
                          "?NroPlantilla=" & dgPlantilla.Items(dgPlantilla.SelectedIndex).Cells(1).Text)
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        lblMsg.Text = " "
        lblError1.Text = " "
        lblerror2.Text = " "

        If rbtTitulo.Checked Then
            If txtCantDias.Text.Trim.Length = 0 Then
                CargaPlantilla("T")
            ElseIf Not IsNumeric(txtCantDias.Text) Then
                lblError1.Text = "Dato es númerico"
            Else
                CargaPlantilla("D")
            End If
        ElseIf rbtNroPlantilla.Checked Then
            If txtNroPlantilla.Text.Trim.Length = 0 Then
                lblerror2.Text = "Dato obligatorio"
            ElseIf Not IsNumeric(txtNroPlantilla.Text) Then
                lblerror2.Text = "Dato es númerico"
            Else
                CargaPlantilla("N")
            End If
        ElseIf rbtFlag.Checked Then
            CargaPlantilla("F") 'Reemplazado por tipo de plantilla
        End If
    End Sub

    Private Sub CargaPlantilla(ByVal pTipo As String)
        Dim ds As New DataSet
        Dim iCodTipoPlantilla As Integer = 0

        If pTipo = "N" Then ' Por Nro. Plantilla
            ds = objPlantilla.CargaNroPlantilla(txtNroPlantilla.Text)

        ElseIf pTipo = "D" Then ' Por cantidad dias
            If rbtTodos.Checked Then
                ds = objPlantilla.CargaxDias("%" & Trim(txtTitulo.Text) & "%", txtCantDias.Text, ddlZonaVta.SelectedValue)
            Else
                If rbtActivo.Checked Then
                    ds = objPlantilla.CargaxDiasSts("A", "%" & Trim(txtTitulo.Text) & "%", txtCantDias.Text, ddlZonaVta.SelectedValue)
                Else
                    ds = objPlantilla.CargaxDiasSts("I", "%" & Trim(txtTitulo.Text) & "%", txtCantDias.Text, ddlZonaVta.SelectedValue)
                End If
            End If
        ElseIf pTipo = "F" Then ' Reemplazado por tipo de plantilla
            If ddlTipoPlantilla.Items.Count > 0 Then
                iCodTipoPlantilla = ddlTipoPlantilla.SelectedValue
            End If

            If rbtTodos.Checked Then
                ds = objPlantilla.CargaxTipoPlantilla(ddlZonaVta.SelectedValue, iCodTipoPlantilla)
            ElseIf rbtActivo.Checked Then
                ds = objPlantilla.CargaxTipoPlantilla(ddlZonaVta.SelectedValue, "A", iCodTipoPlantilla)
            Else
                ds = objPlantilla.CargaxTipoPlantilla(ddlZonaVta.SelectedValue, "I", iCodTipoPlantilla)
            End If
        Else
            If rbtTodos.Checked Then             ' Por Titulo
                ds = objPlantilla.CargaxTituloZonaVta("%" & Trim(txtTitulo.Text) & "%", ddlZonaVta.SelectedValue)
            ElseIf rbtActivo.Checked Then
                ds = objPlantilla.CargaxStsTituloZonaVta("A", "%" & Trim(txtTitulo.Text) & "%", ddlZonaVta.SelectedValue)
            Else
                ds = objPlantilla.CargaxStsTituloZonaVta("I", "%" & Trim(txtTitulo.Text) & "%", ddlZonaVta.SelectedValue)
            End If
        End If



        Dim nReg As Integer '= da.Fill(ds, "MPLANTILLA")
        dgPlantilla.DataKeyField = "NroPlantilla"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgPlantilla.DataSource = dv
        dgPlantilla.DataBind()

        lblMsg.Text = CStr(dgPlantilla.Items.Count) + " Plantilla(s)"
    End Sub

    Private Sub dgPlantilla_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPlantilla.ItemDataBound
        If Trim(e.Item.Cells(8).Text) = "Inactivo" Then
            e.Item.ForeColor = Color.Red
        End If
    End Sub


End Class
