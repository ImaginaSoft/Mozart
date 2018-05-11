Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpRutinas
Imports cmpTabla

Partial Class VtaVersionNueva
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New clsRutinas
    Dim objIdioma As New clsIdioma


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("CodCliente") = Request.Params("CodCliente")
            ViewState("NroPedido") = Request.Params("NroPedido")
            ViewState("NroPropuesta") = Request.Params("NroPropuesta")
            ViewState("NroVersion") = Request.Params("NroVersion")
            If Len(Trim(Request.Params("NroVersion"))) = 0 Then
                lblTitulo.Text = "Nueva Versión"
            Else
                EditaVersion()
                lblTitulo.Text = "Modificar Versión N° " & ViewState("NroVersion")
            End If
        End If

    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wPUtilidad As Double
        If txtPorUtilidad.Text.Trim.Length = 0 Then
            wPUtilidad = 0
        Else
            If IsNumeric(txtPorUtilidad.Text) Then
                wPUtilidad = txtPorUtilidad.Text
            Else
                lblMsg.Text = "Error : % Utilidad es dato númerico"
                Return
            End If
        End If
        Dim wCantAduSGL As Integer = objRutina.ConvierteEntero(txtAS.Text)
        Dim wCantAduDBL As Integer = objRutina.ConvierteEntero(txtAD.Text)
        Dim wCantAduTPL As Integer = objRutina.ConvierteEntero(txtAT.Text)
        Dim wCantAduCDL As Integer = objRutina.ConvierteEntero(txtAC.Text)

        Dim wCantNinSGL As Integer = objRutina.ConvierteEntero(txtNS.Text)
        Dim wCantNinDBL As Integer = objRutina.ConvierteEntero(txtND.Text)
        Dim wCantNinTPL As Integer = objRutina.ConvierteEntero(txtNT.Text)
        Dim wCantNinCDL As Integer = objRutina.ConvierteEntero(txtNC.Text)
        If wCantAduSGL + wCantAduDBL + wCantAduTPL + wCantAduCDL + wCantNinSGL + wCantNinDBL + wCantNinTPL + wCantNinCDL = 0 Then
            lblMsg.Text = "Error : Ingrese por lo menos un pasajero"
            Return
        End If

        Dim wNroVersion As Integer
        If lblNroVersion.Text.Trim.Length = 0 Then
            wNroVersion = 0
        Else
            wNroVersion = CInt(lblNroVersion.Text)
        End If


        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_Version_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroVersionOut", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0

        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = wNroVersion
        cd.Parameters.Add("@DesVersion", SqlDbType.VarChar, 100).Value = Trim(txtDesVersion.Text)
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = Viewstate("CodCliente")
        cd.Parameters.Add("@PorUtilidad", SqlDbType.Money).Value = wPUtilidad
        cd.Parameters.Add("@FlagIdioma", SqlDbType.Char, 1).Value = ddlIdioma.SelectedValue
        cd.Parameters.Add("@CantAduSGL", SqlDbType.TinyInt).Value = wCantAduSGL
        cd.Parameters.Add("@CantAduDBL", SqlDbType.TinyInt).Value = wCantAduDBL
        cd.Parameters.Add("@CantAduTPL", SqlDbType.TinyInt).Value = wCantAduTPL
        cd.Parameters.Add("@CantAduCDL", SqlDbType.TinyInt).Value = wCantAduCDL
        cd.Parameters.Add("@CantNinSGL", SqlDbType.TinyInt).Value = wCantNinSGL
        cd.Parameters.Add("@CantNinDBL", SqlDbType.TinyInt).Value = wCantNinDBL
        cd.Parameters.Add("@CantNinTPL", SqlDbType.TinyInt).Value = wCantNinTPL
        cd.Parameters.Add("@CantNinCDL", SqlDbType.TinyInt).Value = wCantNinCDL
        cd.Parameters.Add("@FchInicio", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchInicio.Text)
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
                     "&NroVersion=" & cd.Parameters("@NroVersionOut").Value)
        End If
    End Sub

    Private Sub EditaVersion()
        lblNroVersion.Text = CStr(ViewState("NroVersion"))
        Dim sIdioma As String = ""

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
                txtDesVersion.Text = dr.GetValue(dr.GetOrdinal("DesVersion"))
                lblFchVersion.Text = ToString.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchVersion")))
                lblStsVersion.Text = dr.GetValue(dr.GetOrdinal("StsVersion"))
                txtPorUtilidad.Text = String.Format("{0:##0.00}", dr.GetValue(dr.GetOrdinal("PorUtilidad")))

                If dr.GetValue(dr.GetOrdinal("CantAduSGL")) > 0 Then txtAS.Text = dr.GetValue(dr.GetOrdinal("CantAduSGL"))
                If dr.GetValue(dr.GetOrdinal("CantAduDBL")) > 0 Then txtAD.Text = dr.GetValue(dr.GetOrdinal("CantAduDBL"))
                If dr.GetValue(dr.GetOrdinal("CantAduTPL")) > 0 Then txtAT.Text = dr.GetValue(dr.GetOrdinal("CantAduTPL"))
                If dr.GetValue(dr.GetOrdinal("CantAduCDL")) > 0 Then txtAC.Text = dr.GetValue(dr.GetOrdinal("CantAduCDL"))
                If dr.GetValue(dr.GetOrdinal("CantNinSGL")) > 0 Then txtNS.Text = dr.GetValue(dr.GetOrdinal("CantNinSGL"))
                If dr.GetValue(dr.GetOrdinal("CantNinDBL")) > 0 Then txtND.Text = dr.GetValue(dr.GetOrdinal("CantNinDBL"))
                If dr.GetValue(dr.GetOrdinal("CantNinTPL")) > 0 Then txtNT.Text = dr.GetValue(dr.GetOrdinal("CantNinTPL"))
                If dr.GetValue(dr.GetOrdinal("CantNinCDL")) > 0 Then txtNC.Text = dr.GetValue(dr.GetOrdinal("CantNinCDL"))

                txtFchInicio.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchInicio")))
                If dr.GetValue(dr.GetOrdinal("FlagPublica")) = "S" Then
                    lblPublica.Text = "Si"
                Else
                    lblPublica.Text = "No"
                End If

                sIdioma = dr.GetValue(dr.GetOrdinal("FlagIdioma"))

                cmdGrabar.Visible = False
                lblMsg.CssClass = "Msg"
                If dr.GetValue(dr.GetOrdinal("FlagEdita")) = "E" Then
                    lblMsg.Text = "La versión es de otra empresa, no se puede modificar"
                ElseIf dr.GetValue(dr.GetOrdinal("FlagEdita")) = "N" Then
                    lblMsg.Text = "La versión es modelo antiguo, no se puede modificar"
                ElseIf dr.GetValue(dr.GetOrdinal("CodStsVersion")) = "V" Then
                    lblMsg.Text = "La versión fue aprobado, esta pendiente de facturar"
                ElseIf dr.GetValue(dr.GetOrdinal("CodStsVersion")) = "F" Then
                    lblMsg.Text = "La versión ya fue facturado, no se puede modificar"
                ElseIf dr.GetValue(dr.GetOrdinal("FlagPublica")) = "S" Then
                    lblMsg.Text = "La versión está publicada, no se puede modificar"
                Else
                    'OK
                    cmdGrabar.Visible = True
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        CargaIdioma(sIdioma)
    End Sub

    Private Sub CargaIdioma(ByVal pIdioma As String)
        Dim ds As New DataSet
        ds = objIdioma.Cargar()
        ddlIdioma.DataSource = ds
        ddlIdioma.DataBind()
        If pIdioma.Trim.Length > 0 Then
            Try
                ddlIdioma.Items.FindByValue(pIdioma).Selected = True
            Catch ex As Exception

            End Try
        End If
    End Sub

End Class
