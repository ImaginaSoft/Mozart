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
Partial Class comSelecComprobantes
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim wSubtotal As Double = 0
    Dim wIGV As Double = 0
    Dim wInafecto As Double = 0
    Dim wTotal As Double = 0
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("sortOrder") = ""

            Dim wNow As String
            Dim wmes, wano As Integer
            'Obtenemos la Fecha Inicial
            wNow = objRutina.fechayyyymmdd(objRutina.fechaddmmyyyy(0))

            ViewState("Opcion") = Request.Params("Opcion")
            If ViewState("Opcion") = "Actualiza" Then
                txtFchIni.Text = Request.Params("FchInicio")
                txtFchFin.Text = Request.Params("FchFin")
                wano = Request.Params("Ano")
                wmes = Request.Params("Mes")
                ViewState("Tipo") = Request.Params("Tipo")
                If ViewState("Tipo") = "P" Then
                    rbcompras.Checked = True
                    rbVentas.Checked = False
                Else
                    If ViewState("Tipo") = "C" Then
                        rbcompras.Checked = False
                        rbVentas.Checked = True
                    End If
                End If
            Else
                wano = CInt(Mid(wNow, 1, 4))
                wmes = CInt(Mid(wNow, 5, 2))
                txtFchIni.Text = objRutina.fechaddmmyyyy(-15)
                txtFchFin.Text = objRutina.fechaddmmyyyy(15)
            End If
            If wano = 0 Then
                txtano.Text = ""
            Else
                txtano.Text = wano
            End If

            CargaMes(wmes)
            CargaDocumentos("", "")
        End If
    End Sub
    Private Sub CargaMes(ByVal pMes As Integer)
        ddlCalendario.Items.Clear()
        ddlCalendario.Items.Insert(0, New ListItem(""))
        ddlCalendario.Items.Insert(1, New ListItem("Enero"))
        ddlCalendario.Items.Insert(2, New ListItem("Febrero"))
        ddlCalendario.Items.Insert(3, New ListItem("Marzo"))
        ddlCalendario.Items.Insert(4, New ListItem("Abril"))
        ddlCalendario.Items.Insert(5, New ListItem("Mayo"))
        ddlCalendario.Items.Insert(6, New ListItem("Junio"))
        ddlCalendario.Items.Insert(7, New ListItem("Julio"))
        ddlCalendario.Items.Insert(8, New ListItem("Agosto"))
        ddlCalendario.Items.Insert(8, New ListItem("Setiembre"))
        ddlCalendario.Items.Insert(10, New ListItem("Octubre"))
        ddlCalendario.Items.Insert(11, New ListItem("Noviembre"))
        ddlCalendario.Items.Insert(12, New ListItem("Diciembre"))

        If pMes = 0 Then
            ddlCalendario.Items.FindByValue("").Selected = True
        End If
        If pMes = 1 Then
            ddlCalendario.Items.FindByValue("Enero").Selected = True
        End If
        If pMes = 2 Then
            ddlCalendario.Items.FindByValue("Febrero").Selected = True
        End If
        If pMes = 3 Then
            ddlCalendario.Items.FindByValue("Marzo").Selected = True
        End If
        If pMes = 4 Then
            ddlCalendario.Items.FindByValue("Abril").Selected = True
        End If

        If pMes = 5 Then
            ddlCalendario.Items.FindByValue("Mayo").Selected = True
        End If
        If pMes = 6 Then
            ddlCalendario.Items.FindByValue("Junio").Selected = True
        End If
        If pMes = 7 Then
            ddlCalendario.Items.FindByValue("Julio").Selected = True
        End If
        If pMes = 8 Then
            ddlCalendario.Items.FindByValue("Agosto").Selected = True
        End If
        If pMes = 9 Then
            ddlCalendario.Items.FindByValue("Setiembre").Selected = True
        End If
        If pMes = 10 Then
            ddlCalendario.Items.FindByValue("Octubre").Selected = True
        End If
        If pMes = 11 Then
            ddlCalendario.Items.FindByValue("Noviembre").Selected = True
        End If
        If pMes = 12 Then
            ddlCalendario.Items.FindByValue("Diciembre").Selected = True
        End If
    End Sub
    Private Function Mes(ByVal pMes As String) As Integer
        If pMes = "" Then
            Return 0
        End If
        If pMes = "Enero" Then
            Return 1
        End If
        If pMes = "Febrero" Then
            Return 2
        End If
        If pMes = "Marzo" Then
            Return 3
        End If
        If pMes = "Abril" Then
            Return 4
        End If
        If pMes = "Mayo" Then
            Return 5
        End If
        If pMes = "Junio" Then
            Return 6
        End If
        If pMes = "Julio" Then
            Return 7
        End If
        If pMes = "Agosto" Then
            Return 8
        End If
        If pMes = "Setiembre" Then
            Return 9
        End If
        If pMes = "Octubre" Then
            Return 10
        End If
        If pMes = "Noviembre" Then
            Return 11
        End If
        If pMes = "Diciembre" Then
            Return 12
        End If

    End Function
    Private Sub CargaDocumentos(ByVal sortExp As String, ByVal sortDir As String)
        Dim wTipoSistema As Char

        If rbVentas.Checked Then
            wTipoSistema = "C"
            lblerror.Text = "C"
        Else
            If rbcompras.Checked Then
                wTipoSistema = "P"
                lblerror.Text = "P"
            End If
        End If

        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "COM_Comprobante_S"
        da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = wTipoSistema
        da.SelectCommand.Parameters.Add("@FchIni", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchIni.Text)
        da.SelectCommand.Parameters.Add("@FchFin", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchFin.Text)
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Documentos")
        ''dgDocumento.DataKeyField = "Correlativo"

        'se instancia un DataView para que se puedan ordenar los datos
        dv = New DataView(ds.Tables(0))
        'dv.Sort = ViewState("Campo")
        If Not String.IsNullOrEmpty(sortExp) Then
            dv.Sort = String.Format("{0} {1}", sortExp, sortDir)
        End If

        dgDocumento.DataSource = dv
        dgDocumento.DataBind()

        If rbVentas.Checked Then
            lblmsg.Text = CStr(nReg) + " Documento(s) de ventas"
        Else
            If rbcompras.Checked Then
                lblmsg.Text = CStr(nReg) + " Documento(s)de compras"
            End If
        End If
    End Sub
    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaDocumentos("", "")
    End Sub

    '    Private Sub dgDocumento_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgDocumento.SortCommand
    '       ViewState("Campo") = e.SortExpression()
    '      CargaDocumentos()
    ' End Sub

    Private Sub InitializeComponent()

    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If txtano.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtano.Text) Then
                lblerror.Visible = True
                lblerror.Text = "Error: Año es dato numerico o vacio"
                Return
            End If
        End If

        Dim wMes As String
        If Mes(ddlCalendario.SelectedItem.Value) < 10 Then
            wMes = "0" & CStr(Mes(ddlCalendario.SelectedItem.Value))
        Else
            wMes = CStr(Mes(ddlCalendario.SelectedItem.Value))
        End If

        ' Verifica si Mes Esta Cerrado
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "COM_CierreMesProcesado_S"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@NroDocs", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@AnoDeclara", SqlDbType.Char, 4).Value = txtano.Text
        cd.Parameters.Add("@MesDeclara", SqlDbType.Char, 2).Value = Trim(wMes)
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            If cd.Parameters("@NroDocs").Value > 0 Then
                lblmsg.Text = "Año-Mes ya esta cerrado, seleccione otro periodo"
                Return
            End If
        Catch ex1 As System.Data.SqlClient.SqlException
            lblmsg.Text = "Error:" & ex1.Message
            Return
        Catch ex2 As System.Exception
            lblmsg.Text = "Error:" & ex2.Message
            Return
        End Try
        cn.Close()

        ActualizarComprobante()
    End Sub
    Private Sub ActualizarComprobante()
        Dim wCheck As Boolean
        Dim wMes As String
        Dim wano As Integer

        wCheck = False
        Session("IdReg") = CStr(Now)

        'declaro un objeto de tipo ColumnaCheckBox la vinculo a la primera del datagrid respectivamente
        'Dim MiChkBox As ColumnaCheckBox = CType(dgDocumento.Columns(0), ColumnaCheckBox)
        Dim currentRowsFilePath As String


        Dim i As Integer = 0
        'declaro un objeto del tipo Seleccion (una estructura que contiene la llave primaria y el valor checked del checkbox)
        'Dim MiSeleccion As Seleccion

        'itero a traves de todas las llave primarias, y recupero su valor checked (true o false)
        For index As Integer = 0 To dgDocumento.Rows.Count - 1

            'Programmatically access the CheckBox from the TemplateField
            Dim cb As CheckBox = CType(dgDocumento.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)

            '            For Each MiSeleccion In MiChkBox.GetDataKeys
            'If MiSeleccion.Checked.ToString() Then
            If cb.Checked Then

                lblmsg.Text = ""
                wCheck = True
                wMes = ""
                If Mes(ddlCalendario.SelectedItem.Value) > 0 Then
                    If Mes(ddlCalendario.SelectedItem.Value) < 10 Then
                        wMes = "0" & CStr(Mes(ddlCalendario.SelectedItem.Value))
                    Else
                        wMes = CStr(Mes(ddlCalendario.SelectedItem.Value))
                    End If
                Else
                    wMes = ""
                End If

                Dim cd As New SqlCommand
                cd.Connection = cn
                cd.CommandText = "Com_Comprobante_U"
                cd.CommandType = CommandType.StoredProcedure

                Dim pa As New SqlParameter
                pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                pa.Direction = ParameterDirection.Output
                pa.Value = ""
                'cd.Parameters.Add("@Correlativo", SqlDbType.Int).Value = CInt(MiSeleccion.PrimaryKey.ToString))

                cd.Parameters.Add("@Correlativo", SqlDbType.Int).Value = CInt(dgDocumento.DataKeys(index).Value)
                cd.Parameters.Add("@AnoDeclara", SqlDbType.Char, 4).Value = txtano.Text
                cd.Parameters.Add("@MesDeclara", SqlDbType.Char, 2).Value = Trim(wMes)
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
                If Trim(lblmsg.Text) <> "OK" Then
                    Return
                End If
            End If
        Next

        If txtano.Text.Trim.Length = 0 Then
            wano = 0
        Else
            wano = txtano.Text
        End If

        If wCheck Then
            Response.Redirect("comSelecComprobantes.aspx" & _
            "?FchInicio=" & txtFchIni.Text & _
            "&FchFin=" & txtFchFin.Text & _
            "&Tipo=" & lblerror.Text & _
            "&Ano=" & wano & _
            "&Mes=" & Mes(ddlCalendario.SelectedItem.Value) & _
            "&Opcion=" & "Actualiza")
        End If

    End Sub


    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        'First, make sure we are dealing with an Item or AlternatingItem
        If e.Item.ItemType = ListItemType.Item Or _
              e.Item.ItemType = ListItemType.AlternatingItem Then
            'Snip out the ViewCount
            Dim dSubtotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "SSubtotal"))
            Dim dIGV As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "SIGV"))
            Dim dInafecto As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "SInafecto"))
            Dim dTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "STotal"))
            wSubtotal += dSubtotal
            wIGV += dIGV
            wInafecto += dInafecto
            wTotal += dTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(6).Text = String.Format("{0:###,###,###,###.##}", wSubtotal)
            e.Item.Cells(7).Text = String.Format("{0:###,###,###,###.##}", wIGV)
            e.Item.Cells(8).Text = String.Format("{0:###,###,###,###.##}", wInafecto)
            e.Item.Cells(9).Text = String.Format("{0:###,###,###,###.##}", wTotal)
        End If
    End Sub

    Protected Sub dgDocumento_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDocumento.DataBound
        Dim ArrayValues As New List(Of String)

        Try
            Dim cbHeader As CheckBox = CType(dgDocumento.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
            ArrayValues.Add(String.Concat("'", cbHeader.ClientID, "'"))
        Catch ex As Exception

        End Try

        For Each gvr As GridViewRow In dgDocumento.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("RowLevelCheckBox"), CheckBox)

            'If the checkbox is unchecked, ensure that the Header CheckBox is unchecked
            cb.Attributes("onclick") = "ChangeHeaderAsNeeded();"

            'Add the CheckBox's ID to the client-side CheckBoxIDs array
            ArrayValues.Add(String.Concat("'", cb.ClientID, "'"))
        Next

        'Output the array to the Literal control (CheckBoxIDsArray)
        CheckBoxIDsArray.Text = "<script type=""text/javascript"">" & vbCrLf & _
                                "<!--" & vbCrLf & _
                                String.Concat("var CheckBoxIDs =  new Array(", String.Join(",", ArrayValues.ToArray()), ");") & vbCrLf & _
                                "// -->" & vbCrLf & _
                                "</script>"



    End Sub



    '    Protected Sub dgDocumento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgDocumento.RowDataBound
    '       If e.Row.RowType = DataControlRowType.DataRow Then
    '  'Año declara 
    '         If e.Row.Cells(11).Text.Trim <> "" Then
    '            e.Row.Cells(0).Text = ""
    '        End If
    '    End If
    'End Sub

    Protected Sub dgDocumento_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles dgDocumento.Sorting
        CargaDocumentos(e.SortExpression, sortOrder)

    End Sub

    Public Property sortOrder() As String
        Get
            If ViewState("sortOrder").ToString() = "desc" Then
                ViewState("sortOrder") = "asc"
            Else
                ViewState("sortOrder") = "desc"
            End If
            Return ViewState("sortOrder").ToString()
        End Get
        Set(ByVal value As String)
            ViewState("sortOrder") = value
        End Set
    End Property
End Class
