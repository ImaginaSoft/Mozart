Imports System
Imports cmpNegocio
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security

Imports System.Web.Mail
Imports System.Data.SqlClient
Imports cmpSeguridad

Imports System.IO
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Partial Class vtaServicioNuevoDes
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim sOpc As String
    Public dsEdit As New DataSet
    Private dv As DataView
    Dim objServicio As New clsServicio

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not IsPostBack Then
            Dim objAutoriza As New clsAutoriza
            If objAutoriza.AccesoOk(Session("CodPerfil"), "GPT030505") = "X" Then
                cmdGrabar.Visible = True
            End If



            Viewstate("NroServicio") = Request.Params("NroServicio")
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            Viewstate("CodCiudad") = Request.Params("CodCiudad")
            Viewstate("CodTipoServicio") = Request.Params("CodTipoServicio")
            lblTitulo.Text = Request.Params("NroServicio") + " " + Request.Params("DesProveedor")
            cmdGrabar.Text = "Grabar " & lbtResEspanol.Text
            ViewState("sOpc") = "Res1"
            LeeServicio()
            'LeeImg()
        End If
        '        With cmdGrabar
        '.Attributes.Add("onClick", "getHTML()")
        'End With
    End Sub
    Private Sub LeeServicio()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If ViewState("sOpc") = "Det1" Then
            da.SelectCommand.CommandText = "VTA_DesServicioDet_S"
        ElseIf ViewState("sOpc") = "Det2" Then
            da.SelectCommand.CommandText = "VTA_DesServicio2Det_S"
        ElseIf ViewState("sOpc") = "Det3" Then
            da.SelectCommand.CommandText = "VTA_DesServicio3Det_S"
        ElseIf ViewState("sOpc") = "Res1" Then
            da.SelectCommand.CommandText = "VTA_DesServicio_S"
        ElseIf ViewState("sOpc") = "Res2" Then
            da.SelectCommand.CommandText = "VTA_DesServicio2_S"
        ElseIf ViewState("sOpc") = "Res3" Then
            da.SelectCommand.CommandText = "VTA_DesServicio3_S"
        End If
        da.SelectCommand.Parameters.Add("@NroServicio", SqlDbType.Int).Value = ViewState("NroServicio")
        'dsEdit.Clear()
        'da.Fill(dsEdit, "Servicio")
        'txtRTB.DataBind()


        dsEdit.Clear()
        da.Fill(dsEdit, "Servicio")
        FreeTextBox1.DataBind()

    End Sub


    'Private Sub CargarGrid()
    '    dlgImg.DataSource = objServicio.CargaImg("1425")
    '    dlgImg.DataBind()
    'End Sub

    'Private Sub LeeImg()
    '    Dim ds As New DataSet
    '    ds = objServicio.CargaImg(ViewState("NroServicio"))

    '    dv = New DataView(ds.Tables(0))


    '    dv.Sort = ViewState("Imagen2")
    '    'dlgImg.DataKeyField = "dlgImg"
    '    dlgImg.DataSource = dv
    '    dlgImg.DataBind()

    'End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        lblmsg.Text = ""

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandType = CommandType.StoredProcedure

        If ViewState("sOpc") = "Det1" Then
            cd.CommandText = "VTA_DesServicioDet_U"
            cd.Parameters.Add("@DesServicioDet", SqlDbType.Text).Value = FreeTextBox1.Text
        ElseIf ViewState("sOpc") = "Det2" Then
            cd.CommandText = "VTA_DesServicio2Det_U"
            cd.Parameters.Add("@DesServicio2Det", SqlDbType.Text).Value = FreeTextBox1.Text
        ElseIf ViewState("sOpc") = "Det3" Then
            cd.CommandText = "VTA_DesServicio3Det_U"
            cd.Parameters.Add("@DesServicio3Det", SqlDbType.Text).Value = FreeTextBox1.Text
        ElseIf ViewState("sOpc") = "Res1" Then
            cd.CommandText = "VTA_DesServicio_U"
            cd.Parameters.Add("@DesServicio", SqlDbType.VarChar, 800).Value = FreeTextBox1.Text
        ElseIf ViewState("sOpc") = "Res2" Then
            cd.CommandText = "VTA_DesServicio2_U"
            cd.Parameters.Add("@DesServicio2", SqlDbType.VarChar, 800).Value = FreeTextBox1.Text
        ElseIf ViewState("sOpc") = "Res3" Then
            cd.CommandText = "VTA_DesServicio3_U"
            cd.Parameters.Add("@DesServicio3", SqlDbType.VarChar, 800).Value = FreeTextBox1.Text
        End If


        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = ViewState("NroServicio")
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

        If btnImportar.HasFile Or btnImportar2.HasFile Or btnImportar3.HasFile Then

            Dim cn2 As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

            Dim cd1 As New SqlCommand
            cd1.Connection = cn2
            cd1.CommandText = "VTA_ImgServicios_U"
            cd1.CommandType = CommandType.StoredProcedure

            If btnImportar2.HasFile Then
                Using reader As New BinaryReader(btnImportar.PostedFile.InputStream)
                    Dim image As Byte() = reader.ReadBytes(btnImportar.PostedFile.ContentLength)
                    cd1.Parameters.Add("@Imagen1", SqlDbType.Image, 500).Value = image
                    cd1.Parameters.Add("@FlagImg01", SqlDbType.Char, 1).Value = 1
                End Using
            Else
                cd1.Parameters.Add("@Imagen1", SqlDbType.Image, 500).Value = DBNull.Value
                cd1.Parameters.Add("@FlagImg01", SqlDbType.Char, 1).Value = DBNull.Value
            End If


            If btnImportar2.HasFile Then
                Using reader2 As New BinaryReader(btnImportar2.PostedFile.InputStream)
                    Dim image2 As Byte() = reader2.ReadBytes(btnImportar2.PostedFile.ContentLength)

                    cd1.Parameters.Add("@Imagen2", SqlDbType.Image, 500).Value = image2
                    cd1.Parameters.Add("@FlagImg02", SqlDbType.Char, 1).Value = 1

                End Using
            Else
                cd1.Parameters.Add("@Imagen2", SqlDbType.Image, 500).Value = DBNull.Value
                cd1.Parameters.Add("@FlagImg02", SqlDbType.Char, 1).Value = DBNull.Value
            End If


            If btnImportar3.HasFile Then
                Using reader3 As New BinaryReader(btnImportar3.PostedFile.InputStream)

                    Dim image3 As Byte() = reader3.ReadBytes(btnImportar3.PostedFile.ContentLength)
                    cd1.Parameters.Add("@Imagen3", SqlDbType.Image, 500).Value = image3
                    cd1.Parameters.Add("@FlagImg03", SqlDbType.Char, 1).Value = 1

                End Using
            Else
                cd1.Parameters.Add("@Imagen3", SqlDbType.Image, 500).Value = DBNull.Value
                cd1.Parameters.Add("@FlagImg03", SqlDbType.Char, 1).Value = DBNull.Value
                'cd1.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
            End If



            cd1.Parameters.Add("@NroServicio", SqlDbType.Int).Value = ViewState("NroServicio")
            cd1.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")


            Try
                cn2.Open()
                cd1.ExecuteNonQuery()
            Catch ex2 As System.Exception
            End Try
            cn2.Close()



        End If

        'LeeImg()

     


    End Sub


    Private Sub lbtResEspanol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtResEspanol.Click
        cmdGrabar.Text = "Grabar " & lbtResEspanol.Text
        ViewState("sOpc") = "Res1"
        LeeServicio()
    End Sub

    Private Sub lbtDetEspanol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDetEspanol.Click
        cmdGrabar.Text = "Grabar " & lbtDetEspanol.Text
        ViewState("sOpc") = "Det1"
        LeeServicio()
    End Sub

    Private Sub lbtResIngles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtResIngles.Click
        cmdGrabar.Text = "Grabar " & lbtResIngles.Text
        ViewState("sOpc") = "Res2"
        LeeServicio()
    End Sub

    Private Sub lbtDetIngles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDetIngles.Click
        cmdGrabar.Text = "Grabar " & lbtDetIngles.Text
        ViewState("sOpc") = "Det2"
        LeeServicio()
    End Sub

    Private Sub lbtServicios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtServicios.Click
        Response.Redirect("VtaServicioBusca.aspx" & _
            "?Opcion=" & "NuevoServicio" & _
            "&NroServicio=" & Viewstate("NroServicio") & _
            "&CodProveedor=" & Viewstate("CodProveedor") & _
            "&CodCiudad=" & Viewstate("CodCiudad") & _
            "&CodTipoServicio=" & Viewstate("CodTipoServicio"))
    End Sub


    Protected Sub lbtRes3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtRes3.Click
        cmdGrabar.Text = "Grabar " & lbtResIngles.Text
        ViewState("sOpc") = "Res3"
        LeeServicio()

    End Sub

    Protected Sub lbtDet3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtDet3.Click
        cmdGrabar.Text = "Grabar " & lbtDetIngles.Text
        ViewState("sOpc") = "Det3"
        LeeServicio()
    End Sub
End Class
