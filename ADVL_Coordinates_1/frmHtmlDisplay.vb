Public Class frmHtmlDisplay
    'Form used to update the HTML code for the Start Page.

#Region " Variable Declarations - All the variables used in this form and this application." '=================================================================================================

    'Declare Forms used by the application:

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Properties - All the properties used in this form and this application" '============================================================================================================


    Private _formNo As Integer = -1 'Multiple instances of this form can be displayed. FormNo is the index number of the form in XmlDisplayFormList.
    'If the form is included in Main.WebViewFormList() then FormNo will be > -1 --> when exiting set Main.ClosedFormNo and call Main.WebViewFormClosed(). 
    Public Property FormNo As Integer
        Get
            Return _formNo
        End Get
        Set(ByVal value As Integer)
            _formNo = value
        End Set
    End Property

    Private _fileName As String = "" 'The file name of the displayed document.
    Public Property FileName As String
        Get
            Return _fileName
        End Get
        Set(value As String)
            _fileName = value
            txtFileName.Text = _fileName
        End Set
    End Property

    Private _docTextChanged As Boolean = False 'If True, the document text has been changed. Prompt to save the changes before they are lost.
    Property DocTextChanged As Boolean
        Get
            Return _docTextChanged
        End Get
        Set(value As Boolean)
            _docTextChanged = value
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

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load

        RestoreFormSettings()   'Restore the form settings

        XmlHtmDisplay1.WordWrap = False
        XmlHtmDisplay1.DefaultHtmlSettings()
        XmlHtmDisplay1.Settings.UpdateFontIndexes()
        XmlHtmDisplay1.Settings.UpdateColorIndexes()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Form

        Me.Close() 'Close the form
    End Sub

    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If WindowState = FormWindowState.Normal Then
            SaveFormSettings()
        Else
            'Dont save settings if the form is minimised.
        End If
    End Sub


#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '===================================================================================================================

#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '===========================================================================================================================

    Public Sub OpenDocument()
        'Open the document with the name stored in FileName property.

        Dim rtbData As New IO.MemoryStream
        Main.Project.ReadData(FileName, rtbData)
        XmlHtmDisplay1.Clear()
        rtbData.Position = 0
        XmlHtmDisplay1.LoadFile(rtbData, RichTextBoxStreamType.PlainText)
        Dim htmText As String = XmlHtmDisplay1.Text
        XmlHtmDisplay1.Rtf = XmlHtmDisplay1.HmlToRtf(htmText)
    End Sub



    Private Sub XmlHtmDisplay1_Click(sender As Object, e As EventArgs) Handles XmlHtmDisplay1.Click
        'Get the line number and column number of the cursor position:

        Dim LineNo As Integer = XmlHtmDisplay1.GetLineFromCharIndex(XmlHtmDisplay1.SelectionStart) + 1
        Dim CharIndex As Integer = XmlHtmDisplay1.SelectionStart
        Dim LineStartIndex As Integer = XmlHtmDisplay1.GetFirstCharIndexOfCurrentLine
        Dim ColNo As Integer = CharIndex - LineStartIndex

        txtInfo.Text = "L" & LineNo & " C" & ColNo
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'Update the Start Page.

        SaveDocument()

        If Main.StartPageFileName = FileName Then
            Main.DisplayStartPage()
        End If

        Main.UpdateWebPage(FileName)

    End Sub

    Private Sub SaveDocument()
        'Save the HTML document.

        If FileName = "" Then
            Beep()
        Else
            Dim htmData As New IO.MemoryStream
            XmlHtmDisplay1.SaveFile(htmData, RichTextBoxStreamType.PlainText)
            htmData.Position = 0
            Main.Project.SaveData(FileName, htmData)
            DocTextChanged = False
        End If
    End Sub

    Private Sub XmlHtmDisplay1_TextChanged(sender As Object, e As EventArgs) Handles XmlHtmDisplay1.TextChanged
        DocTextChanged = True
    End Sub

    Private Sub btnUpdateFormatting_Click(sender As Object, e As EventArgs) Handles btnUpdateFormatting.Click
        'Update the display.
        Dim HtmText As String = XmlHtmDisplay1.Text
        XmlHtmDisplay1.Rtf = XmlHtmDisplay1.HmlToRtf(HtmText)
    End Sub

#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

End Class