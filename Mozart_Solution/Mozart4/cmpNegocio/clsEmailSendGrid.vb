Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports cmpNegocio.clsRptaEmailSendGrid
Imports ws = cmpNegocio.wsMailsSendGrid

Public Class clsEmailSendGrid


    Public Shared Function Encriptar(ByVal cadena As String) As String

        Using md5Hash As MD5 = MD5.Create()
            Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(cadena))
            Dim sBuilder As StringBuilder = New StringBuilder()

            For i As Integer = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next

            Return sBuilder.ToString()
        End Using

    End Function
    Public Shared Function EnviarCorreo(ByVal pNombreEmisor As String, ByVal pCorreoEmisor As String, ByVal pDestinatarios As String, ByVal pAsunto As String, ByVal pCuerpoHtml As String, ByVal pAdjunto As String) As String

        Dim objClsRptaEmail As New clsRptaEmailSendGrid


        Try

            Dim send = New ws.wsMails()

            If pAdjunto IsNot Nothing Then

                Dim enviarAdjunto = send.EnviarCorreo(New ws.Autenticacion With {
                    .InWebId = ws.TipoWeb.Mozart,
                    .StUsuario = Encriptar(System.Configuration.ConfigurationManager.AppSettings("key_usuarioTk").ToString()),
                    .StClave = Encriptar(System.Configuration.ConfigurationManager.AppSettings("key_claveTk").ToString())
                        }, New ws.Correo With {
                     .NombreEmisor = pNombreEmisor,
                     .CorreoEmisor = pCorreoEmisor,
                     .Destinatarios = pDestinatarios,
                     .Asunto = pAsunto,
                       .Adjuntos = New List(Of ws.Adjunto) From {
                New ws.Adjunto With {
                    .NombreArchivo = "Documento.pdf",
                    .ArchivoBytes = Convert.ToBase64String(File.ReadAllBytes(System.Web.HttpContext.Current.Server.MapPath(pAdjunto)))
                }
            }.ToArray(),
                     .CuerpoHtml = pCuerpoHtml
                })

                objClsRptaEmail.Valor = enviarAdjunto.Valor
                objClsRptaEmail.OtroValor = enviarAdjunto.OtroValor
            Else

                Dim enviarSinAdjunto = send.EnviarCorreo(New ws.Autenticacion With {
                    .InWebId = ws.TipoWeb.Mozart,
                    .StUsuario = Encriptar(System.Configuration.ConfigurationManager.AppSettings("key_usuarioTk").ToString()),
                    .StClave = Encriptar(System.Configuration.ConfigurationManager.AppSettings("key_claveTk").ToString())
                        }, New ws.Correo With {
                     .NombreEmisor = pNombreEmisor,
                     .CorreoEmisor = pCorreoEmisor,
                     .Destinatarios = pDestinatarios,
                     .Asunto = pAsunto,
                     .CuerpoHtml = pCuerpoHtml
                })

                objClsRptaEmail.Valor = enviarSinAdjunto.Valor
                objClsRptaEmail.OtroValor = enviarSinAdjunto.OtroValor
            End If

        Catch ex As Exception
            objClsRptaEmail.Valor = ex.Message
        End Try

        Return objClsRptaEmail.Valor
    End Function

End Class
