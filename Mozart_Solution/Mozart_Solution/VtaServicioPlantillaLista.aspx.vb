Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Partial Class VtaServicioPlantillaLista
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            lblServicio.Text = " Servicio: " & Request.Params("NroServicio") & " -  " & Request.Params("Titulo")
            Viewstate("NroServicio") = Request.Params("NroServicio")
            CargaPlantillas()
        End If
    End Sub

    Private Sub CargaPlantillas()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_PlantillaNroServicio_S"
        da.SelectCommand.Parameters.Add("@NroServicio", SqlDbType.Int).Value = Viewstate("NroServicio")

        Dim ds As New DataSet()
        Dim nReg As Integer = da.Fill(ds, "MPLANTILLA")
        dgPlantilla.DataKeyField = "NroPlantilla"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgPlantilla.DataSource = dv
        dgPlantilla.DataBind()

        lblMsg.Text = CStr(nReg) + " Plantilla(s) encontrada(s)"
    End Sub


    Private Sub dgPlantilla_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgPlantilla.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaPlantillas()
    End Sub

    Private Sub dgPlantilla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPlantilla.SelectedIndexChanged
        Session("NroPlantilla") = CInt(dgPlantilla.Items(dgPlantilla.SelectedIndex).Cells(1).Text())
        Response.Redirect("VtaPlantillaFicha.aspx" & _
                          "?NroPlantilla=" & dgPlantilla.Items(dgPlantilla.SelectedIndex).Cells(1).Text)
    End Sub

    Private Sub dgPlantilla_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPlantilla.ItemDataBound
        If Trim(e.Item.Cells(6).Text) = "Inactivo" Then
            e.Item.ForeColor = Color.Red
        End If
    End Sub

End Class
