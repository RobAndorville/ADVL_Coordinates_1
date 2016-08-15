
Imports System.ServiceModel
Public Class MsgServiceCallback
    Implements ServiceReference1.IMsgServiceCallback

    Public Sub OnSendMessage(message As String) Implements ServiceReference1.IMsgServiceCallback.OnSendMessage
        'A message has been received.
        'Set the InstrReceived property value to the message (usually in XMessage format). This will also apply the instructions in the XMessage.
        Main.InstrReceived = message
    End Sub
End Class
