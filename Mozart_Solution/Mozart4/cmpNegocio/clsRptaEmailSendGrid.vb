Public Class clsRptaEmailSendGrid
    Private iValor As String
    Private iOtroValor As String
    Private iTipo As TipoRespuesta


    Public Enum TipoRespuesta
        Exito = 0
        Alerta = 1
        [Error] = 2
    End Enum

    Property Valor() As String
        Get
            Return iValor
        End Get


        Set(ByVal value As String)
            iValor = (value)
        End Set
    End Property

    Property OtroValor() As String
        Get
            Return iOtroValor
        End Get


        Set(ByVal value As String)
            iOtroValor = (value)
        End Set
    End Property
End Class
