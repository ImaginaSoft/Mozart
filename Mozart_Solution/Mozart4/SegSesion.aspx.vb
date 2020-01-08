Imports System.Data
Imports System.Data.SqlClient

Partial Class SegSesion
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
        End If
    End Sub

    Private Sub lbtLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtLogin.Click
        Response.Redirect("default.htm") 'Ingreso normal
    End Sub

End Class
