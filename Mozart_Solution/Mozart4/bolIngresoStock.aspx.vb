Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class bolIngresoStock
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchIngreso.Text = ObjRutina.fechaddmmyyyy(0)
        End If
    End Sub

    Private Sub txtSerieInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerieInicial.TextChanged
        CantidadBoletos()
    End Sub

    Private Sub CantidadBoletos()
        If IsNumeric(txtSerieInicial.Text) And IsNumeric(txtSerieFinal.Text) Then
            lblBoletos.Text = CStr(CInt(txtSerieFinal.Text) - CInt(txtSerieInicial.Text) + 1)
        Else
            lblBoletos.Text = " "
        End If
    End Sub

    Private Sub txtSerieFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerieFinal.TextChanged
        CantidadBoletos()
    End Sub

    Private Sub cmcElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblMsg.Text = ""
        If Not IsNumeric(txtSerieInicial.Text) Then
            lblMsg.Text = "Serie inicial es dato numerico"
            Return
        End If
        If Not IsNumeric(txtSerieFinal.Text) Then
            lblMsg.Text = "Serie final es dato numerico"
            Return
        End If
        If CInt(txtSerieFinal.Text) < CInt(txtSerieInicial.Text) Then
            lblMsg.Text = "Serie final es mayor o igual serie inicial"
            Return
        End If

        Dim wfchIngreso As String = ObjRutina.fechayyyymmdd(txtFchIngreso.Text)

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "BOL_BOLETO_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = ucddlProveedor1.CodProveedor
        cd.Parameters.Add("@Forma", SqlDbType.Char, 4).Value = txtForma.Text
        cd.Parameters.Add("@SerieInicial", SqlDbType.Int).Value = CInt(txtSerieInicial.Text)
        cd.Parameters.Add("@SerieFinal", SqlDbType.Int).Value = CInt(txtSerieFinal.Text)
        cd.Parameters.Add("@FchIngreso", SqlDbType.Char, 8).Value = wfchIngreso
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
            Response.Redirect("bolStock.aspx" & _
                            "?FchIngreso=" & wfchIngreso)
        End If
    End Sub

    Private Sub cmdIngresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresa.Click
        lblMsg.Text = ""
        If Not IsNumeric(txtSerieInicial.Text) Then
            lblMsg.Text = "Serie inicial es dato numerico"
            Return
        End If
        If Not IsNumeric(txtSerieFinal.Text) Then
            lblMsg.Text = "Serie final es dato numerico"
            Return
        End If
        If CInt(txtSerieFinal.Text) < CInt(txtSerieInicial.Text) Then
            lblMsg.Text = "Serie final es mayor o igual serie inicial"
            Return
        End If

        Dim wFchIngreso As String = txtFchIngreso.Text.Substring(6, 4) + txtFchIngreso.Text.Substring(3, 2) + txtFchIngreso.Text.Substring(0, 2)

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "BOL_BOLETO_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = ucddlProveedor1.CodProveedor
        cd.Parameters.Add("@Forma", SqlDbType.Char, 4).Value = txtForma.Text
        cd.Parameters.Add("@SerieInicial", SqlDbType.Int).Value = CInt(txtSerieInicial.Text)
        cd.Parameters.Add("@SerieFinal", SqlDbType.Int).Value = CInt(txtSerieFinal.Text)
        cd.Parameters.Add("@FchIngreso", SqlDbType.Char, 8).Value = wFchIngreso
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
            Response.Redirect("bolStock.aspx" & _
                            "?FchIngreso=" & wFchIngreso)
        End If
    End Sub

End Class
