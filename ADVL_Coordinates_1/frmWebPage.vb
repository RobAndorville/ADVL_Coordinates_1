Imports System.Security.Permissions
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
<System.Runtime.InteropServices.ComVisibleAttribute(True)>
Public Class frmWebPage
    'This form displays a Web view of the HTML Code.

#Region " Variable Declarations - All the variables used in this form and this application." '=================================================================================================

    Public WithEvents XSeq As New ADVL_Utilities_Library_1.XSequence
    'To run and XSequence:
    '  XSeq.RunXSequence(xDoc, Status) 'ImportStatus in Import
    '    Handle events:
    '      XSeq.ErrorMsg
    '      XSeq.Instruction(Info, Locn)

    Private Status As New System.Collections.Specialized.StringCollection

    'Variables used to restore Item values on a web page.
    Private FormName As String
    Private ItemName As String
    Private SelectId As String


    'Private SettingsFileName As String 'The file name used to store the web page settings. 
    'If there is no ParentWebPage, this is FileName & "Settings".
    'If there is a ParentWebPage, this is Filename & "Settings" & ParentWebPageName.GetHashCode


#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Properties - All the properties used in this form and this application" '============================================================================================================

    'PROPERTIES:
    'FormNo - the index number of the web page form in WebPageFormList().
    'FileName - the file name of the displayed web document.
    'Description - a description of the displayed web page.
    'FileLocationType - Project or FileSystem - In this application, the web page file will always be located in the Project.
    'FileDirectory - the path of the directory for a file in the FileSystem - Not used in this application.
    'ParentWebPageFileName - 'The file name of the web page that opened this web page.
    'ParentWebPageFormNo - 'The form index number of the web page that opened this web page.

    Private _formNo As Integer = -1 'Multiple instances of this form can be displayed. FormNo is the index number of the form in XmlDisplayFormList.
    'If the form is included in Main.WebViewFormList() then FormNo will be > -1 --> when exiting set Main.ClosedFormNo and call Main.WebViewFormClosed(). 
    Public Property FormNo As Integer
        Get
            Return _formNo
        End Get
        Set(ByVal value As Integer)
            _formNo = value
            Debug.Print("FormNo = " & _formNo)
        End Set
    End Property

    Private _fileName As String = "" 'The file name of the displayed document.
    Public Property FileName As String
        Get
            Return _fileName
        End Get
        Set(value As String)
            _fileName = value
            txtDocumentFile.Text = _fileName
        End Set
    End Property

    Private _description As String = "" 'A description of the displayed document.
    Public Property Description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Enum LocationTypes
        Project
        FileSystem
    End Enum

    Private _fileLocationType As LocationTypes = LocationTypes.Project 'The location type of the Document File. (Either the current project or the file system.)
    Property FileLocationType As LocationTypes
        Get
            Return _fileLocationType
        End Get
        Set(value As LocationTypes)
            _fileLocationType = value
        End Set
    End Property

    Private _fileDirectory As String = "" 'The path of the directory containing the current file.
    Property FileDirectory As String
        Get
            Return _fileDirectory
        End Get
        Set(value As String)
            _fileDirectory = value
        End Set
    End Property

    Private _parentWebPageFileName As String = "" 'The file name of the web page that opened this web page.
    Property ParentWebPageFileName As String
        Get
            Return _parentWebPageFileName
        End Get
        Set(value As String)
            _parentWebPageFileName = value
        End Set
    End Property

    Private _parentWebPageFormNo As Integer = -2 'The form index number of the web page that opened this web page.
    Property ParentWebPageFormNo As Integer
        Get
            Return _parentWebPageFormNo
        End Get
        Set(value As Integer)
            _parentWebPageFormNo = value
        End Set
    End Property


#End Region 'Properties -----------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Process XML files - Read and write XML files." '=====================================================================================================================================

    Private Sub SaveFormSettings()
        'Save the form settings in an XML document.
        Dim settingsData = <?xml version="1.0" encoding="utf-8"?>
                           <!---->
                           <FormSettings>
                               <Left><%= Me.Left %></Left>
                               <Top><%= Me.Top %></Top>
                               <Width><%= Me.Width %></Width>
                               <Height><%= Me.Height %></Height>
                               <!---->
                           </FormSettings>

        'Add code to include other settings to save after the comment line <!---->

        Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Main.Project.SaveXmlSettings(SettingsFileName, settingsData)
    End Sub

    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"

        If Main.Project.SettingsFileExists(SettingsFileName) Then
            Dim Settings As System.Xml.Linq.XDocument
            Main.Project.ReadXmlSettings(SettingsFileName, Settings)

            If IsNothing(Settings) Then 'There is no Settings XML data.
                Exit Sub
            End If

            'Restore form position and size:
            If Settings.<FormSettings>.<Left>.Value <> Nothing Then Me.Left = Settings.<FormSettings>.<Left>.Value
            If Settings.<FormSettings>.<Top>.Value <> Nothing Then Me.Top = Settings.<FormSettings>.<Top>.Value
            If Settings.<FormSettings>.<Height>.Value <> Nothing Then Me.Height = Settings.<FormSettings>.<Height>.Value
            If Settings.<FormSettings>.<Width>.Value <> Nothing Then Me.Width = Settings.<FormSettings>.<Width>.Value

            'Add code to read other saved setting here:

        End If
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message) 'Save the form settings before the form is minimised:
        If m.Msg = &H112 Then 'SysCommand
            If m.WParam.ToInt32 = &HF020 Then 'Form is being minimised
                SaveFormSettings()
            End If
        End If
        MyBase.WndProc(m)
    End Sub

#End Region 'Process XML Files ----------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Display Methods - Code used to display this form." '============================================================================================================================

    'Private Sub frmTemplate_Load(sender As Object, e As EventArgs) Handles Me.Load
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        RestoreFormSettings()   'Restore the form settings

        Me.WebBrowser1.ObjectForScripting = Me

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Form

        SaveWebPageSettings() 'Save the web page settings.

        If FormNo > -1 Then
            Main.ClosedFormNo = FormNo 'The Main form property ClosedFormNo is set to this form number. This is used in the RtfDisplayFormClosed method to select the correct form to set to nothing.
        End If

        Me.Close() 'Close the form
    End Sub

    'Private Sub frmTemplate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If WindowState = FormWindowState.Normal Then
            SaveFormSettings()
        Else
            'Dont save settings if the form is minimised.
        End If
    End Sub


    Private Sub frmWebPage_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If FormNo > -1 Then
            Main.WebPageFormClosed()
        End If
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Open and Close Forms - Code used to open and close other forms." '===================================================================================================================

#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Methods - The main actions performed by this form." '===========================================================================================================================


    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        AddHandler WebBrowser1.Document.MouseOver, AddressOf Me.DisplayHyperlinks
    End Sub

    Public Sub DisplayHyperlinks(ByVal sender As Object, ByVal e As System.Windows.Forms.HtmlElementEventArgs)
        txtLink.Text = e.ToElement.GetAttribute("href")
    End Sub

    Public Sub OpenDocument()
        'Open the document specified by FileName, FileLocationType and FileDirectory.

        If FileLocationType = LocationTypes.Project Then

            Dim rtbData As New IO.MemoryStream
            Main.Project.ReadData(FileName, rtbData)
            rtbData.Position = 0
            Dim sr As New IO.StreamReader(rtbData)

            WebBrowser1.DocumentText = sr.ReadToEnd()

        Else

            WebBrowser1.Navigate("file:///" & FileDirectory & "\" & FileName)

        End If

    End Sub


#Region " Methods Called by JavaScript - A collection of methods that can be called by JavaScript in a web page shown in WebBrowser1" '========================================================

    Public Sub JSMethodTest1()
        'Test method that is called from JavaScript.
        Main.Message.Add("JSMethodTest1 called OK." & vbCrLf)
    End Sub

    Public Sub JSMethodTest2(ByVal Var1 As String, ByVal Var2 As String)
        'Test method that is called from JavaScript.
        Main.Message.Add("Var1 = " & Var1 & " Var2 = " & Var2 & vbCrLf)
    End Sub

    Public Sub JSDisplayXml(ByRef XDoc As XDocument)
        Main.Message.Add(XDoc.ToString & vbCrLf & vbCrLf)
    End Sub

    Public Sub ShowMessage(ByVal Msg As String)
        Main.Message.Add(Msg)
    End Sub

    Public Sub SaveHtmlSettings_Old2(ByVal xSettings As String, ByVal FileName As String)
        'Save the Html settings for a web page.

        'Convert the XSettings to XML format:
        Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"

        Dim XDocSettings As New System.Xml.Linq.XDocument

        Try
            XDocSettings = System.Xml.Linq.XDocument.Parse(XmlHeader & vbCrLf & xSettings)
        Catch ex As Exception
            Main.Message.AddWarning("Error saving HTML settings file. " & ex.Message & vbCrLf)
        End Try

        Main.Project.SaveXmlData(FileName, XDocSettings)

    End Sub

    Public Sub SaveHtmlSettings(ByVal xSettings As String)
        'Save the Html settings for a web page.

        Dim SettingsFileName As String = FileName & "Settings"

        If ParentWebPageFileName <> "" Then
            SettingsFileName = SettingsFileName & ParentWebPageFileName.GetHashCode
        End If

        'Convert the XSettings to XML format:
        Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"

        Dim XDocSettings As New System.Xml.Linq.XDocument

        Try
            XDocSettings = System.Xml.Linq.XDocument.Parse(XmlHeader & vbCrLf & xSettings)
        Catch ex As Exception
            Main.Message.AddWarning("Error saving HTML settings file. " & ex.Message & vbCrLf)
        End Try

        Main.Project.SaveXmlData(SettingsFileName, XDocSettings)

    End Sub

    Public Sub RestoreHtmlSettings_Old2(ByVal FileName As String)
        'Restore the Html settings for a web page.

        Dim XDocSettings As New System.Xml.Linq.XDocument
        Main.Project.ReadXmlData(FileName, XDocSettings)

        If XDocSettings Is Nothing Then
            Main.Message.Add("No HTML Settings file : " & FileName & vbCrLf)
        Else

            Dim XSettings As New System.Xml.XmlDocument
            Try
                XSettings.LoadXml(XDocSettings.ToString)

                'Run the Settings file:
                XSeq.RunXSequence(XSettings, Status)
            Catch ex As Exception
                Main.Message.AddWarning("Error restoring HTML settings. " & ex.Message & vbCrLf)
            End Try

        End If
    End Sub

    Public Sub RestoreHtmlSettings()
        'Restore the Html settings for a web page.

        Dim SettingsFileName As String = FileName & "Settings"

        If ParentWebPageFileName <> "" Then
            SettingsFileName = SettingsFileName & ParentWebPageFileName.GetHashCode
        End If

        Dim XDocSettings As New System.Xml.Linq.XDocument
        Main.Project.ReadXmlData(SettingsFileName, XDocSettings)

        If XDocSettings Is Nothing Then
            Main.Message.Add("No HTML Settings file : " & SettingsFileName & vbCrLf)
        Else

            Dim XSettings As New System.Xml.XmlDocument
            Try
                XSettings.LoadXml(XDocSettings.ToString)

                'Run the Settings file:
                XSeq.RunXSequence(XSettings, Status)
            Catch ex As Exception
                Main.Message.AddWarning("Error restoring HTML settings. " & ex.Message & vbCrLf)
            End Try

        End If
    End Sub

    Private Sub XSeq_ErrorMsg(ErrMsg As String) Handles XSeq.ErrorMsg
        Main.Message.AddWarning(ErrMsg & vbCrLf)
    End Sub

    Public Sub RunClipboardXSeq()
        'Run the XSequence instructions in the clipboard.

        Dim XDocSeq As System.Xml.Linq.XDocument
        Try
            XDocSeq = XDocument.Parse(My.Computer.Clipboard.GetText)
        Catch ex As Exception
            Main.Message.AddWarning("Error reading Clipboard data. " & ex.Message & vbCrLf)
            Exit Sub
        End Try

        If IsNothing(XDocSeq) Then
            Main.Message.Add("No XSequence instructions were found in the clipboard.")
            'Exit Sub
        Else
            Dim XmlSeq As New System.Xml.XmlDocument
            Try
                XmlSeq.LoadXml(XDocSeq.ToString) 'Convert XDocSeq to an XmlDocument to process with XSeq.

                'Run the sequence:
                XSeq.RunXSequence(XmlSeq, Status)
            Catch ex As Exception
                Main.Message.AddWarning("Error restoring HTML settings. " & ex.Message & vbCrLf)
            End Try
        End If

    End Sub


    Private Sub XSeq_Instruction(Info As String, Locn As String) Handles XSeq.Instruction
        'Execute each instruction produced by running the XSeq file.

        Select Case Locn
            Case "Settings:SendData:LatDegrees" 'REDUNDANT!
                RestoreSetting("SendData", "LatDegrees", Info)

            Case "Settings:SendData:LongDegrees" 'REDUNDANT!
                RestoreSetting("SendData", "LongDegrees", Info)

            Case "Settings:Form:Name"
                FormName = Info

            Case "Settings:Form:Item:Name"
                ItemName = Info

            Case "Settings:Form:Item:Value"
                RestoreSetting(FormName, ItemName, Info)

            Case "Settings:Form:SelectId"
                SelectId = Info

            Case "Settings:Form:OptionText"
                'RestoreOption(FormName, SelectId, Info)
                RestoreOption(SelectId, Info)

            Case "Settings"

            Case "EndOfSequence"
                'Main.Message.Add("End of processing sequence" & Info & vbCrLf)

            Case Else
                'Main.Message.AddWarning("Unknown location: " & Locn & "  Info: " & Info & vbCrLf)

                'If the instructions are not saved web page settings identified above, send them directly to the web page:
                XMsgInstruction(Info, Locn) 'The JavaScript function (also called XMsgInstruction) will attempt to process this instruction.

        End Select
    End Sub

    Public Sub RestoreSetting(ByVal FormName As String, ByVal ItemName As String, ByVal ItemValue As String)
        'Restore the setting value with the specified Form Name and Item Name.
        Me.WebBrowser1.Document.InvokeScript("RestoreSetting", New String() {FormName, ItemName, ItemValue})
    End Sub

    'Public Sub RestoreOption(ByVal FormName As String, ByVal SelectId As String, ByVal OptionText As String)
    Public Sub RestoreOption(ByVal SelectId As String, ByVal OptionText As String)
        'Restore the Option text in the Select control with the Id SelectId.
        Me.WebBrowser1.Document.InvokeScript("RestoreOption", New String() {SelectId, OptionText})
    End Sub

    Private Sub SaveWebPageSettings()
        'Call the SaveSettings JavaScript function:
        Try
            Me.WebBrowser1.Document.InvokeScript("SaveSettings")
        Catch ex As Exception
            Main.Message.AddWarning("Web page settings not saved: " & ex.Message & vbCrLf)
        End Try

    End Sub


    Public Function GetFormNo() As String
        'Return the Form Number of the current instance of the WebView form.
        Return FormNo.ToString
    End Function

    Public Function GetParentFormNo() As String
        'Return the Form Number of the Parent Form (that called this form).
        Return ParentWebPageFormNo.ToString
    End Function

    Public Sub RunXMessage(ByVal XMsg As String)
        'Run the XMessage by sending it to Main.InstrReceived.
        Main.InstrReceived = XMsg
    End Sub

    Public Function GetConnectionName() As String
        'Return the Connection Name of the Document Library application.
        Return Main.ConnectionName
    End Function

    Public Sub SendXMessage(ByVal AppNetName As String, ByVal ConnName As String, ByVal XMsg As String) 'UPDATED 2Feb19
        'Send the XMsg to the application with the connection name ConnName.
        If IsNothing(Main.client) Then
            Main.Message.Add("No client connection available!" & vbCrLf)
        Else
            If Main.client.State = ServiceModel.CommunicationState.Faulted Then
                Main.Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                Main.client.SendMessageAsync(AppNetName, ConnName, XMsg)
                Main.Message.XAddText("Message sent to " & ConnName & " (AppNet: " & AppNetName & ") " & ":" & vbCrLf, "XmlSentNotice") 'UPDATED 2Feb19
                Main.Message.XAddXml(XMsg)
                Main.Message.XAddText(vbCrLf, "Normal") 'Add extra line
            End If
        End If

    End Sub

    Public Sub AddText(ByVal Msg As String, ByVal TextType As String)
        Main.Message.AddText(Msg, TextType)
    End Sub

    Public Sub AddMessage(ByVal Msg As String)
        Main.Message.Add(Msg)
    End Sub

    Public Sub AddWarning(ByVal Msg As String)
        Main.Message.AddWarning(Msg)
    End Sub

    Public Sub XMsgInstruction(ByVal Info As String, ByVal Locn As String)
        'Send the XMessage Instruction to the JavaScript function XMsgInstruction for processing.
        Me.WebBrowser1.Document.InvokeScript("XMsgInstruction", New String() {Info, Locn})
    End Sub

    'Public Sub OpenWebPage(ByVal WebPageFileName As String, ByVal ParentWebPageName As String, ByVal ParentWebPageFormNo As Integer)
    Public Sub OpenWebPage(ByVal WebPageFileName As String)
        'Open a Web Page from the WebPageFileName.
        '  Pass the ParentName Property to the new web page. The is the name of this web page that is opening the new page.
        '  Pass the ParentWebPageFormNo Property to the new web page. This is the FormNo of this web page that is opening the new page.
        '    A hash code is generated from the ParentName. This is used to define a file name to save and restore the Web Page settings.
        '    The new web page can pass instructions back to the ParentWebPage using its ParentWebPageFormNo.

        Dim NewFormNo As Integer = Main.OpenNewWebPage()

        Main.WebPageFormList(NewFormNo).ParentWebPageFileName = FileName 'Set the Parent Web Page property.
        Main.WebPageFormList(NewFormNo).ParentWebPageFormNo = FormNo 'Set the Parent Form Number property.
        Main.WebPageFormList(NewFormNo).Description = ""             'The web page description can be blank.
        Main.WebPageFormList(NewFormNo).FileDirectory = ""           'Only Web files in the Project directory can be opened from another Web Page Form.
        Main.WebPageFormList(NewFormNo).FileLocationType = LocationTypes.Project 'Only Web files in the Project directory can be opened from another Web Page Form.
        Main.WebPageFormList(NewFormNo).FileName = WebPageFileName  'Set the web page file name to be opened.
        Main.WebPageFormList(NewFormNo).OpenDocument                'Open the web page file name.

    End Sub

#End Region 'Methods Called by JavaScript -----------------------------------------------------------------------------------------------------------------------------------------------------


#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

End Class