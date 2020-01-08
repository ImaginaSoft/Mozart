Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpTabla
Partial Class TabPaisNuevo
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New cmpRutinas.clsRutinas
    Dim objPais As New clsPais

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("Opcion") = Request.Params("Opcion")

            If Viewstate("Opcion") = "Nuevo" Then
                lbltitulo.Text = "Nuevo País"
            Else
                lbltitulo.Text = "Modificar País"
                Viewstate("CodPais") = Request.Params("CodPais")
                EditaPais()
            End If
        End If
    End Sub

    Private Sub EditaPais()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "TAB_PaisxCodPais_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodPais", SqlDbType.Char, 3).Value = Viewstate("CodPais")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                txtCodigo.Text = RTrim(dr.GetValue(dr.GetOrdinal("CodPais")))
                txtNombre.Text = RTrim(dr.GetValue(dr.GetOrdinal("NomPais")))
                txtNomPaisIngles.Text = RTrim(dr.GetValue(dr.GetOrdinal("NomPaisIngles")))
                txtDocReqEsp.Text = RTrim(dr.GetValue(dr.GetOrdinal("DocReqEsp")))
                txtDocReqIng.Text = RTrim(dr.GetValue(dr.GetOrdinal("DocReqIng")))
                txtTollFree.Text = RTrim(dr.GetValue(dr.GetOrdinal("TollFree")))
                If dr.GetValue(dr.GetOrdinal("StsPais")) = "A" Then
                    rbActivo.Checked = True
                Else
                    rbInactivo.Checked = True
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub rbInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbActivo.Checked = False
        rbInactivo.Checked = True
    End Sub

    Private Sub rbActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbInactivo.Checked = False
        rbActivo.Checked = True
    End Sub


    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If rbActivo.Checked Then
            objPais.StsPais = "A"
        Else
            objPais.StsPais = "I"
        End If
        objPais.CodPais = txtCodigo.Text
        objPais.NomPais = txtNombre.Text
        objPais.NomPaisIngles = txtNomPaisIngles.Text
        objPais.TollFree = txtTollFree.Text
        objPais.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objPais.Grabar(txtDocReqEsp.Text, txtDocReqIng.Text)
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("tabpais.aspx")
        End If
    End Sub

End Class
