Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class cppProveedorNuevo
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New cmpRutinas.clsRutinas
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("Opcion") = Request.Params("Opcion")

            If Viewstate("Opcion") = "A" Then

                Viewstate("CodProveedor") = Request.Params("CodProveedor")
                lblTitulo.Text = "Actualiza Proveedor " + Viewstate("CodProveedor")
                CargaDatos()
            End If
            If Viewstate("Opcion") = "N" Then
                lblTitulo.Text = "Nuevo Proveedor"
                'Llenado del pais
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter


                da.SelectCommand = New SqlCommand
                da.SelectCommand.Connection = cn
                da.SelectCommand.CommandText = "peru4me_new.TAB_Pais_S"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds, "TABPAIS")
                ddlpais.DataSource = ds.Tables("TABPAIS")
                ddlpais.DataBind()
            End If
            If Viewstate("Opcion") = "E" Then
                lblTitulo.Text = "Eliminar Proveedor"
                Viewstate("CodProveedor") = Request.Params("CodProveedor")
                CmdEliminar.Visible = True
                CmdGrabar.Visible = False
                CargaDatos()
            End If
        End If
    End Sub



    Private Sub CargaDatos()
        Dim wcodpais, westado As String

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPP_ProveedorCodProveedor_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = CInt(Viewstate("CodProveedor"))
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()

                westado = dr.GetValue(dr.GetOrdinal("StsProveedor"))
                wcodpais = dr.GetValue(dr.GetOrdinal("CodPais"))
                txtnombre.Text = Trim(dr.GetValue(dr.GetOrdinal("NomProveedor")))
                txtBcoCta.Text = Trim(dr.GetValue(dr.GetOrdinal("BancoCta")))
                txtrazon.Text = Trim(dr.GetValue(dr.GetOrdinal("RazonSocial")))
                txtruc.Text = Trim(dr.GetValue(dr.GetOrdinal("RUC")))
                txtdir1.Text = Trim(dr.GetValue(dr.GetOrdinal("Direccion")))
                txtciudad.Text = Trim(dr.GetValue(dr.GetOrdinal("Ciudad")))
                txtfax.Text = Trim(dr.GetValue(dr.GetOrdinal("Fax")))
                txtweb.Text = Trim(dr.GetValue(dr.GetOrdinal("Web")))
                txtSigla.Text = Trim(dr.GetValue(dr.GetOrdinal("sigla")))

                If dr.GetValue(dr.GetOrdinal("IGVHotel")) = "N" Then
                    ChkIGVHotel.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("IGVTerrestre")) = "N" Then
                    ChkIGVTerrestre.Checked = True
                End If
                If dr.GetValue(dr.GetOrdinal("IGVOtros")) = "N" Then
                    ChkIGVOtros.Checked = True
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        'ESTADO
        If Trim(westado) = "A" Then
            rbActivo.Checked = True
            rbInactivo.Checked = False
        Else
            rbInactivo.Checked = True
            rbActivo.Checked = False
        End If

        'Llenado del pais
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "peru4me_new.TAB_Pais_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.Fill(ds, "TABPAIS")
        ddlpais.DataSource = ds.Tables("TABPAIS")
        ddlpais.DataBind()
        If Len(Trim(wcodpais)) <> 0 Then
            ddlpais.Items.FindByValue(wcodpais).Selected = True
        End If
    End Sub

    Private Sub GrabaDatos()
        Dim westado As String
        Dim wIGVHotel, wIGVTerrestre, wIGVOtros As String

        If rbActivo.Checked Then
            westado = "A"
        Else
            westado = "I"
        End If

        wIGVHotel = " "
        If ChkIGVHotel.Checked Then
            wIGVHotel = "N"
        End If

        wIGVTerrestre = " "
        If ChkIGVTerrestre.Checked Then
            wIGVTerrestre = "N"
        End If

        wIGVOtros = " "
        If ChkIGVOtros.Checked Then
            wIGVOtros = "N"
        End If


        Dim cd As New SqlCommand

        cd.Connection = cn
        cd.CommandText = "CPP_Proveedor_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@CodProveedorOut", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0
        If Viewstate("Opcion") = "N" Then
            cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = 0
        Else
            cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        End If
        cd.Parameters.Add("@NomProveedor", SqlDbType.VarChar, 50).Value = txtnombre.Text
        cd.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 50).Value = txtrazon.Text
        cd.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = txtdir1.Text
        cd.Parameters.Add("@Ciudad ", SqlDbType.VarChar, 50).Value = txtciudad.Text
        cd.Parameters.Add("@CodPais ", SqlDbType.Char, 3).Value = Trim(ddlpais.SelectedItem.Value)
        cd.Parameters.Add("@RUC", SqlDbType.VarChar, 15).Value = txtruc.Text
        cd.Parameters.Add("@BancoCta", SqlDbType.VarChar, 50).Value = txtBcoCta.Text
        cd.Parameters.Add("@Fax", SqlDbType.VarChar, 20).Value = txtfax.Text
        cd.Parameters.Add("@Web", SqlDbType.VarChar, 50).Value = txtweb.Text
        cd.Parameters.Add("@StsProveedor", SqlDbType.Char, 1).Value = Trim(westado)
        cd.Parameters.Add("@IGVHotel", SqlDbType.Char, 1).Value = wIGVHotel
        cd.Parameters.Add("@IGVTerrestre", SqlDbType.Char, 1).Value = wIGVTerrestre
        cd.Parameters.Add("@IGVOtros", SqlDbType.Char, 1).Value = wIGVOtros
        cd.Parameters.Add("@Sigla", SqlDbType.VarChar, 20).Value = txtSigla.Text
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

        If Trim(lblError.Text) = "OK" Then
            Response.Redirect("cppProveedorFicha.aspx" & _
            "?CodProveedor=" & cd.Parameters("@CodProveedorOut").Value)
        End If
    End Sub

    Private Overloads Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        If Len(Trim(txtnombre.Text)) = 0 Then
            lblError.Text = "Error: Ingrese el Nombre Comercial"
            Return
        End If

        GrabaDatos()
    End Sub

    Private Sub cmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        Dim codigo As Integer
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPP_Proveedor_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        codigo = CInt(Viewstate("CodProveedor"))
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = codigo
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblError.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblError.Text = ObjRutina.fncErroresSQL(ex1.Errors)
            If lblError.Text = "547" Then
                lblError.Text = "Mensaje: Si desea eliminar Proveedor, primero debe eliminar los Pedidos,Historial, Documentos Cargo y Abono"
            End If
        Catch ex2 As System.Exception
            lblError.Text = "Error: " & ex2.Message
        End Try

        cn.Close()
        If Trim(lblError.Text) = "OK" Then
            Response.Redirect("cppProveedorBusca.aspx?CodProveedor=" & 0)
        End If
    End Sub

End Class
