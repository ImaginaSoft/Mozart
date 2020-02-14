Imports System.Data
Imports System.Data.SqlClient
Imports cmpNegocio
Partial Class VtaPlantillaImg
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objServicio As New clsServicio
    Dim objPlantilla As New clsPlantilla
    Dim objProveedor As New clsProveedor

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("NroPlantilla") = Request.Params("NroPlantilla")
            ViewState("DesPlantilla") = Request.Params("DesPlantilla")

            obtenerImagen(ViewState("NroPlantilla"))
        End If
    End Sub
    Private Sub obtenerImagen(nroPlantilla As Integer)

        Dim plantilla As New List(Of clsPlantilla)()
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "latinamericajourneys.LAJ_ImagenPlantilla_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = ViewState("NroPlantilla")

        Try
            cn.Open()
            Dim reader As SqlDataReader = cd.ExecuteReader()

            Dim Fila As New clsPlantilla()

            While reader.Read()
                Fila = New clsPlantilla()

                If reader("IdImg") Is DBNull.Value Then

                Else

                    Fila.IdImgPlantilla = reader("IdImg")

                End If

                If reader("strURL") Is DBNull.Value Then

                Else

                    Fila.UrlImgPlantilla = reader("strURL")

                End If

                plantilla.Add(Fila)

            End While

            For i As Integer = 0 To plantilla.Count()

                If i = 0 Then
                    Image1.ImageUrl = plantilla(i).UrlImgPlantilla
                ElseIf i = 1 Then

                    Image2.ImageUrl = plantilla(i).UrlImgPlantilla
                Else
                    Image3.ImageUrl = plantilla(i).UrlImgPlantilla


                End If
            Next

            If plantilla.FirstOrDefault().IdImgPlantilla = 1 Then
                Image1.ImageUrl = plantilla.FirstOrDefault().UrlImgPlantilla
            ElseIf plantilla.FirstOrDefault().IdImgPlantilla = 2 Then
                Image2.ImageUrl = plantilla.FirstOrDefault().UrlImgPlantilla
            Else
                Image3.ImageUrl = plantilla.FirstOrDefault().UrlImgPlantilla
            End If
            'cd.ExecuteNonQuery()
            'If cd.Parameters("@MsgTrans").Value = "OK" Then
            '    sMsg = cd.Parameters("@MsgTrans").Value
            'Else
            '    sMsg = cd.Parameters("@MsgTrans").Value
            'End If
        Catch ex1 As System.Data.SqlClient.SqlException
            'sMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            'sMsg = "Error:" & ex2.Message
        End Try
        cn.Close()

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sMsg As String
        If FileUpload1.HasFile Then
            FileUpload1.SaveAs(Server.MapPath("images//" & ViewState("NroPlantilla") & "-" & "1" & "-" & FileUpload1.FileName))
            Label1.Text = "Imagen cargada"
            Label1.ForeColor = System.Drawing.Color.ForestGreen
        Else
            Label1.Text = "Por favor selecciona una imagen"
            Label1.ForeColor = System.Drawing.Color.Red
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "latinamericajourneys.LAJ_ImagenTour_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 250)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        Dim url As String = System.Configuration.ConfigurationManager.AppSettings("URL_Img") + "/" + ViewState("NroPlantilla") + "-" + "1" + "-" + FileUpload1.FileName.ToString()

        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = ViewState("NroPlantilla")
        cd.Parameters.Add("@IdImg", SqlDbType.Int).Value = 1
        cd.Parameters.Add("@NombreImagen", SqlDbType.VarChar).Value = ViewState("NroPlantilla") + "-" + "1" + "-" + FileUpload1.FileName.ToString()
        cd.Parameters.Add("@Url", SqlDbType.VarChar).Value = url


        Try
            cn.Open()
            cd.ExecuteNonQuery()
            If cd.Parameters("@MsgTrans").Value = "OK" Then
                sMsg = cd.Parameters("@MsgTrans").Value
            Else
                sMsg = cd.Parameters("@MsgTrans").Value
            End If
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        End Try
        cn.Close()

    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sMsg As String

        If FileUpload2.HasFile Then
            FileUpload2.SaveAs(Server.MapPath("images//" & ViewState("NroPlantilla") & "-" & "2" & "-" & FileUpload2.FileName))
            Label2.Text = "Imagen cargada"
            Label2.ForeColor = System.Drawing.Color.ForestGreen
        Else
            Label2.Text = "Por favor selecciona una imagen"
            Label2.ForeColor = System.Drawing.Color.Red
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "latinamericajourneys.LAJ_ImagenTour_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 250)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        Dim url As String = System.Configuration.ConfigurationManager.AppSettings("URL_Img") + "/" + ViewState("NroPlantilla") + "-" + "2" + "-" + FileUpload2.FileName.ToString()

        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = ViewState("NroPlantilla")
        cd.Parameters.Add("@IdImg", SqlDbType.Int).Value = 2
        cd.Parameters.Add("@NombreImagen", SqlDbType.VarChar).Value = ViewState("NroPlantilla") + "-" + "2" + "-" + FileUpload2.FileName.ToString()
        cd.Parameters.Add("@Url", SqlDbType.VarChar).Value = url


        Try
            cn.Open()
            cd.ExecuteNonQuery()
            If cd.Parameters("@MsgTrans").Value = "OK" Then
                sMsg = cd.Parameters("@MsgTrans").Value
            Else
                sMsg = cd.Parameters("@MsgTrans").Value
            End If
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        End Try
        cn.Close()
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sMsg As String

        If FileUpload3.HasFile Then
            FileUpload3.SaveAs(Server.MapPath("images//" & ViewState("NroPlantilla") & "-" & "3" & "-" & FileUpload3.FileName))
            Label3.Text = "Imagen cargada"
            Label3.ForeColor = System.Drawing.Color.ForestGreen
        Else
            Label3.Text = "Por favor selecciona una imagen"
            Label3.ForeColor = System.Drawing.Color.Red
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "latinamericajourneys.LAJ_ImagenTour_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 250)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        Dim url As String = System.Configuration.ConfigurationManager.AppSettings("URL_Img") + "/" + ViewState("NroPlantilla") + "-" + "3" + "-" + FileUpload3.FileName.ToString()

        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = ViewState("NroPlantilla")
        cd.Parameters.Add("@IdImg", SqlDbType.Int).Value = 3
        cd.Parameters.Add("@NombreImagen", SqlDbType.VarChar).Value = ViewState("NroPlantilla") + "-" + "3" + "-" + FileUpload3.FileName.ToString()
        cd.Parameters.Add("@Url", SqlDbType.VarChar).Value = url


        Try
            cn.Open()
            cd.ExecuteNonQuery()
            If cd.Parameters("@MsgTrans").Value = "OK" Then
                sMsg = cd.Parameters("@MsgTrans").Value
            Else
                sMsg = cd.Parameters("@MsgTrans").Value
            End If
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        End Try
        cn.Close()
    End Sub
End Class
