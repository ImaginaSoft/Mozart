Imports System.Data
Imports System.Data.SqlClient
Imports cmpNegocio
Imports cmpTabla
Imports System.Drawing
Imports System.IO

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
            lblTitulo.Text = "Plantilla Nro. " & ViewState("NroPlantilla") & " - " & ViewState("DesPlantilla")

            'CargaProveedorS(0)
            'CargaCiudad("")
            'CargaTipoServicio(0)
            'CargaServicio(0)
            'CargaTipoAcomodacion(0)
            'CargaData()

        End If
    End Sub
    Public Function obtenerImagen(rutaOrden As String) As String

        Try

            Dim bytesImagen As Byte() = System.IO.File.ReadAllBytes(rutaOrden)
            Dim imagenBase64 As String = Convert.ToBase64String(bytesImagen)

            Dim tipoContenido As String

            Select Case Path.GetExtension(rutaOrden)

                Case ".jpg"
                    tipoContenido = "image/jpg"
                Case ".gif"
                    tipoContenido = "image/gif"
                Case ".png"
                    tipoContenido = "image/png"
                Case Else
                    Return Nothing

            End Select

            Return String.Format("data:{0};base64,{1}", tipoContenido, imagenBase64)

        Catch

            Return Nothing

        End Try

    End Function
    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click


        Dim grabarFichero As Boolean = True


        'If btnImportar.HasFile Then

        '    btnImportar.SaveAs(Server.MapPath("images//" + btnImportar.FileName));  
        '    Label1.Text = "Image Uploaded";  
        '    Label1.ForeColor = System.Drawing.Color.ForestGreen; 
        '    'Using reader As New BinaryReader(btnImportar.PostedFile.InputStream)
        '    '    Dim image As Byte() = reader.ReadBytes(btnImportar.PostedFile.ContentLength)
        '    '    objServicio.Imagen = image
        '    '    objServicio.FlagImg01 = 1
        '    'End Using

        'Else

        '    objServicio.Imagen = Nothing
        '    objServicio.FlagImg01 = Nothing

        'End If


        'If btnImportar2.HasFile Then
        '    Using reader2 As New BinaryReader(btnImportar2.PostedFile.InputStream)
        '        Dim image2 As Byte() = reader2.ReadBytes(btnImportar2.PostedFile.ContentLength)
        '        objServicio.Imagen2 = image2
        '        objServicio.FlagImg02 = 1
        '    End Using

        'Else

        '    objServicio.Imagen2 = Nothing
        '    objServicio.FlagImg02 = ""

        'End If


        'If btnImportar3.HasFile Then
        '    Using reader3 As New BinaryReader(btnImportar3.PostedFile.InputStream)
        '        Dim image3 As Byte() = reader3.ReadBytes(btnImportar3.PostedFile.ContentLength)
        '        objServicio.Imagen3 = image3
        '        objServicio.FlagImg03 = 1
        '    End Using

        'Else

        '    objServicio.Imagen3 = Nothing
        '    objServicio.FlagImg03 = ""

        'End If


        'Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        'Dim cd As New SqlCommand
        'cd.Connection = cn
        'cd.CommandText = "peru4me_new.VTA_Servicio_I_new"
        'cd.CommandType = CommandType.StoredProcedure

        'Dim pa As New SqlParameter
        'pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 250)
        'pa.Direction = ParameterDirection.Output
        'pa.Value = ""
        'pa = cd.Parameters.Add("@NroServicioOut", SqlDbType.Int)
        'pa.Direction = ParameterDirection.Output
        'pa.Value = 0


        'If m_Imagen Is Nothing Then
        '    cd.Parameters.Add("@Imagen1", SqlDbType.Image).Value = DBNull.Value
        '    cd.Parameters.Add("@FlagImg01", SqlDbType.Char, 1).Value = ""
        'Else
        '    cd.Parameters.Add("@Imagen1", SqlDbType.Image).Value = m_Imagen
        '    cd.Parameters.Add("@FlagImg01", SqlDbType.Char, 1).Value = sFlagImg01
        'End If

        'If m_Imagen2 Is Nothing Then
        '    cd.Parameters.Add("@Imagen2", SqlDbType.Image).Value = DBNull.Value
        '    cd.Parameters.Add("@FlagImg02", SqlDbType.Char, 1).Value = ""
        'Else
        '    cd.Parameters.Add("@Imagen2", SqlDbType.Image).Value = m_Imagen2
        '    cd.Parameters.Add("@FlagImg02", SqlDbType.Char, 1).Value = sFlagImg02
        'End If

        'If m_Imagen3 Is Nothing Then
        '    cd.Parameters.Add("@Imagen3", SqlDbType.Image).Value = DBNull.Value
        '    cd.Parameters.Add("@FlagImg03", SqlDbType.Char, 1).Value = sFlagImg03
        'Else
        '    cd.Parameters.Add("@Imagen3", SqlDbType.Image).Value = m_Imagen3
        '    cd.Parameters.Add("@FlagImg03", SqlDbType.Char, 1).Value = sFlagImg03
        'End If




        'Try
        '    cn.Open()
        '    cd.ExecuteNonQuery()
        '    If cd.Parameters("@MsgTrans").Value = "OK" Then
        '        sMsg = cd.Parameters("@MsgTrans").Value + CStr(cd.Parameters("@NroServicioOut").Value)
        '    Else
        '        sMsg = cd.Parameters("@MsgTrans").Value
        '    End If
        'Catch ex1 As System.Data.SqlClient.SqlException
        '    sMsg = "Error:" & ex1.Message
        'Catch ex2 As System.Exception
        '    sMsg = "Error:" & ex2.Message
        'End Try
        'cn.Close()
        'Return (sMsg)






    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sMsg As String
        If FileUpload1.HasFile Then
            FileUpload1.SaveAs(Server.MapPath("images//" & FileUpload1.FileName))
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
            FileUpload2.SaveAs(Server.MapPath("images//" & FileUpload2.FileName))
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
            FileUpload3.SaveAs(Server.MapPath("images//" & FileUpload3.FileName))
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
