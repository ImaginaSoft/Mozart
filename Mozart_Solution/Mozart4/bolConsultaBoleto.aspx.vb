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

Partial Class bolConsultaBoleto
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim CodForma As String
            Dim CodProveedor As Integer = 94 'Proveedor BSP Default

            'Cargamos Proveedor
            CargaProveedor(CodProveedor)
            'Cargamos la Forma
            If ddlProveedor.Items.Count > 0 Then
                CargaForma(CodProveedor, "")
            End If
            'Cargamos la Serie
            If ddlForma.Items.Count > 0 Then
                CodForma = ddlForma.SelectedItem.Value
                CargaSerie(CodProveedor, CodForma, 0)
            End If
        End If
    End Sub

    Private Sub CargaProveedor(ByVal pcodProveedor As Integer)
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet()

        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_Proveedor_S"
        da.Fill(ds, "Proveedor")
        ddlProveedor.DataSource = ds.Tables("Proveedor")
        ddlProveedor.DataBind()

        If pcodProveedor > 0 Then
            ddlProveedor.Items.FindByValue(pcodProveedor).Selected = True
        End If

        If ddlProveedor.Items.Count > 0 Then
            txtProveedor.Text = ddlProveedor.SelectedItem.Value
        Else
            txtProveedor.Text = ""
        End If

        CargaForma(txtProveedor.Text, "")


    End Sub
    Private Sub CargaForma(ByVal pcodProveedor As Integer, ByVal pcodforma As String)

        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim wpcodBanco As String = ""

        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_BoletoCodForma_S"
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = pcodProveedor
        da.Fill(ds, "FORMA")
        ddlForma.DataSource = ds.Tables("FORMA")
        ddlForma.DataBind()

        If pcodforma.Trim.Length > 0 Then
            ddlForma.Items.FindByValue(pcodforma).Selected = True
        End If

        If ddlForma.Items.Count > 0 Then
            txtForma.Text = ddlForma.SelectedItem.Value
        Else
            txtForma.Text = ""
        End If

        CargaSerie(CInt(txtProveedor.Text), txtForma.Text, 0)

    End Sub
    Private Sub CargaSerie(ByVal pcodProveedor As Integer, ByVal pcodforma As String, ByVal pcodSerie As Integer)

        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim wpcodBanco As String = ""

        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "BOL_Series_S"
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = pcodProveedor
        da.SelectCommand.Parameters.Add("@Forma", SqlDbType.Char, 4).Value = pcodforma
        da.Fill(ds, "Serie")
        ddlSerie.DataSource = ds.Tables("Serie")
        ddlSerie.DataBind()

        If pcodSerie > 0 Then
            ddlSerie.Items.FindByValue(pcodSerie).Selected = True
        End If
        If ddlSerie.Items.Count > 0 Then
            txtSerie.Text = ddlSerie.SelectedItem.Value
        Else
            txtSerie.Text = ""
        End If
    End Sub

    Private Sub CargaBoleto()
        lblmsg.CssClass = "Error"
        If txtProveedor.Text.Trim.Length = 0 Then
            lblmsg.Text = "Código Proveedor es obligatorio"
        Else
            If Not IsNumeric(txtProveedor.Text) Then
                lblmsg.Text = "Código Proveedor es númerico"
                Return
            End If
        End If

        'Serie
        If txtSerie.Text.Trim.Length = 0 Then
            lblmsg.Text = "Series es obligatorio"
        Else
            If Not IsNumeric(txtSerie.Text) Then
                lblmsg.Text = "La serie es un número"
                Return
            End If
        End If

        If Not IsNumeric(txtCupon.Text) Then
            lblmsg.Text = "El cupon es un número 0,1,2,3 ó 4"
            Return
        End If


        'Dim da As New SqlDataAdapter
        Dim cd As New SqlCommand

        Dim wExiste As Boolean
        wExiste = False

        'Recuperación de Información
        cd.Connection = cn
        cd.CommandText = "BOL_ConsultaBoleto_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = txtProveedor.Text
        cd.Parameters.Add("@Forma", SqlDbType.Char, 4).Value = txtForma.Text
        cd.Parameters.Add("@Serie", SqlDbType.Int).Value = txtSerie.Text
        cd.Parameters.Add("@Cupon", SqlDbType.TinyInt).Value = txtCupon.Text
        Try
            cn.Open()
            Dim dr As SqlDataReader
            dr = cd.ExecuteReader
            Do While dr.Read()
                wExiste = True
                NroBoleto.Text = dr.GetValue(dr.GetOrdinal("NroBoleto"))
                stsubica.Text = dr.GetValue(dr.GetOrdinal("StsUbica"))
                stsBoleto.Text = dr.GetValue(dr.GetOrdinal("StsBoleto"))
                TipoPasajero.Text = dr.GetValue(dr.GetOrdinal("TipoPasajero"))
                NomLinea.Text = dr.GetValue(dr.GetOrdinal("NomLinea"))
                FchEmision.Text = ToString.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchEmision")))
                NomPasajero.Text = dr.GetValue(dr.GetOrdinal("NomPasajero"))
                Ruta.Text = dr.GetValue(dr.GetOrdinal("Ruta"))
                Observacion.Text = dr.GetValue(dr.GetOrdinal("Observacion"))
                FormaPago.Text = dr.GetValue(dr.GetOrdinal("Pago"))
                TipoBoleto.Text = dr.GetValue(dr.GetOrdinal("TipoBoleto"))
                NomCliente.Text = dr.GetValue(dr.GetOrdinal("NomCliente"))
                NroPedido.Text = dr.GetValue(dr.GetOrdinal("NroPedido"))
                NroVersion.Text = dr.GetValue(dr.GetOrdinal("NroVersion"))
                Reporte.Text = dr.GetValue(dr.GetOrdinal("TipoDocumento")) & " " & ToString.Format("{0:########}", dr.GetValue(dr.GetOrdinal("NroDocumento")))
                CodUsuario.Text = dr.GetValue(dr.GetOrdinal("codusuario"))
                fchsys.Text = dr.GetValue(dr.GetOrdinal("fchact"))

                Tarifa.Text = dr.GetValue(dr.GetOrdinal("Tarifa"))
                PIGV.Text = dr.GetValue(dr.GetOrdinal("PIGV")) & " %"
                IGV.Text = dr.GetValue(dr.GetOrdinal("IGV"))
                Otros.Text = dr.GetValue(dr.GetOrdinal("Impuesto"))
                Com1.Text = dr.GetValue(dr.GetOrdinal("Comision1"))
                Com2.Text = dr.GetValue(dr.GetOrdinal("Comision2"))
                pCom1.Text = dr.GetValue(dr.GetOrdinal("PComision1")) & " %"
                pCom2.Text = dr.GetValue(dr.GetOrdinal("PComision2")) & " %"
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        If wExiste Then
            lblmsg.Text = "Datos del Boleto"
            lblmsg.CssClass = "Msg"
        Else
            NroBoleto.Text = ""
            stsubica.Text = ""
            stsBoleto.Text = ""
            TipoPasajero.Text = ""
            NomLinea.Text = ""
            FchEmision.Text = ""
            NomPasajero.Text = ""
            Ruta.Text = ""
            Observacion.Text = ""
            FormaPago.Text = ""
            TipoBoleto.Text = ""
            NomCliente.Text = ""
            NroPedido.Text = ""
            NroVersion.Text = ""
            Reporte.Text = ""
            CodUsuario.Text = ""
            fchsys.Text = ""

            Tarifa.Text = ""
            PIGV.Text = ""
            IGV.Text = ""
            Otros.Text = ""
            Com1.Text = ""
            Com2.Text = ""
            pCom1.Text = ""
            pCom2.Text = ""

            lblmsg.Text = "Nro. Boleto no existe"
            lblmsg.CssClass = "Error"
        End If

    End Sub

    Private Sub ddlProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProveedor.SelectedIndexChanged
        Dim wCodLinea, wCodForma, wSerie As String

        If ddlProveedor.Items.Count > 0 Then
            wCodLinea = ddlProveedor.SelectedItem.Value
            CargaForma(wCodLinea, "")
            txtProveedor.Text = wCodLinea
        End If

        CargaSerie(wCodLinea, txtForma.Text, 0)
    End Sub
    Private Sub ddlForma_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlForma.SelectedIndexChanged
        Dim wCodLinea As String

        If ddlForma.Items.Count > 0 Then
            wCodLinea = txtProveedor.Text
            txtForma.Text = ddlForma.SelectedItem.Value
            CargaSerie(wCodLinea, txtForma.Text, 0)
        End If

    End Sub
    Private Sub ddlSerie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSerie.SelectedIndexChanged
        If ddlSerie.Items.Count > 0 Then
            txtSerie.Text = ddlSerie.SelectedItem.Value
        End If
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        CargaBoleto()
    End Sub
End Class
