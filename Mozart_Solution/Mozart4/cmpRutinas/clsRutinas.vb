Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class clsRutinas
    Function SINO(ByVal pSI As Boolean) As String
        If pSI Then
            Return ("S")
        Else
            Return ("N")
        End If
    End Function

    Function ConvierteEntero(ByVal pdato As String) As Integer
        Dim wValor As Integer
        If pdato.Trim.Length = 0 Then
            wValor = 0
        Else
            If IsNumeric(pdato) Then
                wValor = CInt(pdato)
            Else
                wValor = 0
            End If
        End If
        Return (wValor)
    End Function

    ' Rutina para devolver errores de SQL
    Function fncErroresSQL(ByVal ex1Errores As SqlClient.SqlErrorCollection) As String
        Dim erData As SqlClient.SqlErrorCollection = ex1Errores
        Dim i As Integer
        Dim Msg1 As String = ""
        Dim Msg2 As String = " "
        For i = 0 To erData.Count - 1
            Msg1 &= ("Error " & i & " : " & _
            erData(i).Number & " , " & _
            erData(i).Class & " , " & _
            erData(i).Message & "<br>")
            Select Case erData(i).Number
                Case 2627
                    Msg2 = "No puede insertar registro duplicado"
                Case 547
                    'Por Integridad no se puede eliminar registros
                    Msg2 = "547"
            End Select
        Next i
        If Msg2 = " " Then
            Return (Msg1)
        Else
            Return (Msg2)
        End If
    End Function

    Function fechaddmmyyyy(ByVal pNroDias As Integer) As String
        Dim wfecha
        Dim dia, mes, ano As String

        wfecha = Now.AddDays(pNroDias)
        dia = Day(wfecha)
        mes = Month(wfecha)
        ano = Year(wfecha)

        If Len(Trim(dia)) = 1 Then
            dia = "0" + dia
        End If

        If Len(Trim(mes)) = 1 Then
            mes = "0" + mes
        End If
        Return (dia + "-" + mes + "-" + ano)

    End Function

    Function fechayyyymmdd(ByVal pfecha As String) As String
        Dim wfecha As String
        If pfecha.Trim.Length = 10 Then
            wfecha = pfecha.Substring(6, 4) + pfecha.Substring(3, 2) + pfecha.Substring(0, 2)
        Else
            wfecha = Space(8)
        End If
        Return (wfecha)
    End Function

    'Establece un tamaño especifico (tam) a un texto determinado (txt)
    Function setTamano(ByVal txt As String, ByVal tam As Integer) As String
        If txt.Length > tam Then
            txt = txt.Substring(0, tam)
        ElseIf txt.Length < tam Then
            txt = txt.PadRight(tam)
        End If
        Return txt
    End Function

    Public Function LeeRecordatorio(ByVal pIdioma, ByVal pNroRecordatorio) As Boolean
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        Dim nReg As Integer = 0

        cd.Connection = cn
        cd.CommandText = "TAB_RecordatorioValida_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@Idioma", SqlDbType.Char, 1).Value = pIdioma
        cd.Parameters.Add("@NroRecordatorio", SqlDbType.Int).Value = pNroRecordatorio
        Try
            cn.Open()
            Dim dr As SqlDataReader
            dr = cd.ExecuteReader
            Do While dr.Read()
                nReg = dr.GetValue(dr.GetOrdinal("nReg"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        If nReg > 0 Then
            Return (True) ' Encontro el registro
        Else
            Return (False) ' No existe registro
        End If
    End Function


    Public Function GrabaHistorial(ByVal pDesLog As String, _
                               ByVal pCodCliente As Integer, _
                               ByVal pNroPedido As Integer, _
                               ByVal pNroPropuesta As Integer, _
                               ByVal pNroVersion As Integer, _
                               ByVal pTipoLog As String, _
                               ByVal pTipoMsg As String, _
                               ByVal pCodUsuario As String) As String
        'pTipoLog=1 Registra historial del Pedido, Propuesta y Version
        '        =2 Registra email de Propuesta y Version visible en PERU4ME
        '        =3 Registra en PERU4ME
        '        =4 Registra tareas y procesos automaticos
        '        =5 Registra email de Pedido no visible en PERU4ME
        '        =6 Registra email - recordatorios automaticos
        '        =7 (Registra en PERU4ME) fue leido por el vendedor, de 3 pasa a 7

        'pTipoMsg=L Mensaje libre (su registro es solo informtivo)
        '        =E Mensaje entrada
        '        =S Mensaje salida


        Dim wMsg As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_ClienteLog_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@DesLog", SqlDbType.Text).Value = pDesLog
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = pCodCliente
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = pNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = pNroVersion
        cd.Parameters.Add("@TipoLog", SqlDbType.Char, 1).Value = pTipoLog
        cd.Parameters.Add("@TipoMsg", SqlDbType.Char, 1).Value = pTipoMsg
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = pCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            wMsg = Trim(cd.Parameters("@MsgTrans").Value)
        Catch ex1 As System.Data.SqlClient.SqlException
            wMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            wMsg = "Error:" & ex2.Message
        End Try
        cn.Close()
        Return (wMsg)
    End Function

    Public Function GrabaLogProveedor(ByVal pDesLog As String, _
                           ByVal pCodProveedor As Integer, _
                           ByVal pNroPedido As Integer, _
                           ByVal pNroPropuesta As Integer, _
                           ByVal pNroVersion As Integer, _
                           ByVal pTipoLog As String, _
                           ByVal pCodUsuario As String) As String
        Dim wMsg As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_ProveedorLog_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroLog", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0

        cd.Parameters.Add("@DesLog", SqlDbType.Text).Value = pDesLog
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = pCodProveedor
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = pNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = pNroVersion
        cd.Parameters.Add("@TipoLog", SqlDbType.Char, 1).Value = pTipoLog
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = pCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
        Catch ex1 As System.Data.SqlClient.SqlException
            wMsg = "Error:" & ex1.Message
            Return (wMsg)
        Catch ex2 As System.Exception
            wMsg = "Error:" & ex2.Message
            Return (wMsg)
        End Try
        cn.Close()
        Return (cd.Parameters("@NroLog").Value)
    End Function

    Public Function LeeParametroNumero(ByVal pNomCampo As String) As Double
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        Dim wValor As Double = 0

        cd.Connection = cn
        cd.CommandText = "TAB_Control_S"
        cd.Parameters.Add("@NomCampo", SqlDbType.Char).Value = pNomCampo
        cd.CommandType = CommandType.StoredProcedure
        Try
            cn.Open()
            Dim dr As SqlDataReader
            dr = cd.ExecuteReader
            Do While dr.Read()
                wValor = dr.GetValue(dr.GetOrdinal("ValorCampo"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (wValor)
    End Function

    Public Function LeeParametroTexto(ByVal pNomCampo As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader

        Dim sTexto As String = ""
        cd.Connection = cn
        cd.CommandText = "TAB_Control_S"
        cd.Parameters.Add("@NomCampo", SqlDbType.Char).Value = pNomCampo
        cd.CommandType = CommandType.StoredProcedure
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                sTexto = dr.GetValue(dr.GetOrdinal("TextoCampo"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
        Return (sTexto)
    End Function

    Public Function FchSys() As Date
        Dim wFchSys As Date
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "SEG_FchSys_S"
        cd.CommandType = CommandType.StoredProcedure
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                wFchSys = dr.GetValue(dr.GetOrdinal("FchSys"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
        Return (wFchSys)
    End Function

    Public Function NumMes(ByVal pMes As String) As Integer
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

    Public Function NomMes(ByVal pMes As Integer) As String
        If pMes = 1 Then
            Return ("Enero")
        End If
        If pMes = 2 Then
            Return ("Febrero")
        End If
        If pMes = 3 Then
            Return ("Marzo")
        End If
        If pMes = 4 Then
            Return ("Abril")
        End If

        If pMes = 5 Then
            Return ("Mayo")
        End If
        If pMes = 6 Then
            Return ("Junio")
        End If
        If pMes = 7 Then
            Return ("Julio")
        End If
        If pMes = 8 Then
            Return ("Agosto")
        End If
        If pMes = 9 Then
            Return ("Setiembre")
        End If
        If pMes = 10 Then
            Return ("Octubre")
        End If
        If pMes = 11 Then
            Return ("Noviembre")
        End If
        If pMes = 12 Then
            Return ("Diciembre")
        End If
    End Function

    Public Function LeeTipoCambioVta(ByVal pFecha As String) As Double
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        Dim dTipoCambio As Double = 0

        cd.Connection = cn
        cd.CommandText = "RUT_LeeTipoCambioVta_S"
        cd.Parameters.Add("@Fecha", SqlDbType.Char, 8).Value = pFecha
        cd.CommandType = CommandType.StoredProcedure
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                dTipoCambio = dr.GetValue(dr.GetOrdinal("TipoCambioVta"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
        Return (dTipoCambio)
    End Function

End Class

