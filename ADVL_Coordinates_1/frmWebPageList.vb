Public Class frmWebPageList
    'The Web Pages form show a list of Web Pages in the project and has buttons to open and edit the pages..

#Region " Variable Declarations - All the variables used in this form and this application." '=================================================================================================

    Dim WithEvents Zip As ADVL_Utilities_Library_1.ZipComp

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Properties - All the properties used in this form and this application" '============================================================================================================

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

            CheckFormPos()
        End If
    End Sub

    Private Sub CheckFormPos()
        'Check that the form can be seen on a screen.

        Dim MinWidthVisible As Integer = 192 'Minimum number of X pixels visible. The form will be moved if this many form pixels are not visible.
        Dim MinHeightVisible As Integer = 64 'Minimum number of Y pixels visible. The form will be moved if this many form pixels are not visible.

        Dim FormRect As New Rectangle(Me.Left, Me.Top, Me.Width, Me.Height)
        Dim WARect As Rectangle = Screen.GetWorkingArea(FormRect) 'The Working Area rectangle - the usable area of the screen containing the form.

        ''Check if the top of the form is less than zero:
        'If Me.Top < 0 Then Me.Top = 0

        'Check if the top of the form is above the top of the Working Area:
        If Me.Top < WARect.Top Then
            Me.Top = WARect.Top
        End If

        'Check if the top of the form is too close to the bottom of the Working Area:
        If (Me.Top + MinHeightVisible) > (WARect.Top + WARect.Height) Then
            Me.Top = WARect.Top + WARect.Height - MinHeightVisible
        End If

        'Check if the left edge of the form is too close to the right edge of the Working Area:
        If (Me.Left + MinWidthVisible) > (WARect.Left + WARect.Width) Then
            Me.Left = WARect.Left + WARect.Width - MinWidthVisible
        End If

        'Check if the right edge of the form is too close to the left edge of the Working Area:
        If (Me.Left + Me.Width - MinWidthVisible) < WARect.Left Then
            Me.Left = WARect.Left - Me.Width + MinWidthVisible
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
        UpdateWebPageList()

        txtNewHtmlFileName.Text = "New Page.html"
        txtNewHtmlFileTitle.Text = "New Page"

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

    Public Sub UpdateWebPageList()
        'Update the list of web pages.

        lstWebPages.Items.Clear()

        If Main.Project.DataLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory Then

            For Each foundFile As String In My.Computer.FileSystem.GetFiles(Main.Project.DataLocn.Path, FileIO.SearchOption.SearchTopLevelOnly, "*.html")
                lstWebPages.Items.Add(IO.Path.GetFileName(foundFile))
            Next
        Else
            Zip = New ADVL_Utilities_Library_1.ZipComp
            Zip.ArchivePath = Main.Project.DataLocn.Path
            Dim FileNames As New ArrayList
            Zip.GetEntryList(FileNames, ".html")
            For Each Name As String In FileNames
                lstWebPages.Items.Add(Name)
            Next
        End If
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        'Open the selected html file.
        OpenWorkflowWebPage()

        'If lstWebPages.SelectedItem Is Nothing Then
        '    Main.Message.AddWarning("No page selected." & vbCrLf)
        '    Exit Sub
        'End If

        'Dim FileName As String
        'FileName = lstWebPages.SelectedItem.ToString

        'If FileName = "" Then

        'Else
        '    Dim FormNo As Integer = Main.OpenNewWebPage()
        '    Main.WebPageFormList(FormNo).FileName = FileName
        '    Main.WebPageFormList(FormNo).OpenDocument
        'End If
    End Sub

    Private Sub OpenWorkflowWebPage()
        'Open the selected Workflow Web Page:

        If lstWebPages.SelectedItem Is Nothing Then
            Main.Message.AddWarning("No page selected." & vbCrLf)
            Exit Sub
        End If

        Dim FileName As String
        FileName = lstWebPages.SelectedItem.ToString

        If FileName = "" Then

        Else
            'First check if the HTML file is already open:
            Dim FileFound As Boolean = False
            If Main.WebPageFormList.Count = 0 Then

            Else
                Dim I As Integer
                For I = 0 To Main.WebPageFormList.Count - 1
                    If Main.WebPageFormList(I) Is Nothing Then

                    Else
                        If Main.WebPageFormList(I).FileName = FileName Then
                            FileFound = True
                            Main.WebPageFormList(I).BringToFront
                        End If
                    End If
                Next
            End If

            If FileFound = False Then
                Dim FormNo As Integer = Main.OpenNewWebPage()
                Main.WebPageFormList(FormNo).FileName = FileName
                Main.WebPageFormList(FormNo).OpenDocument
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        'Edit the selected html file.

        If lstWebPages.SelectedItem Is Nothing Then
            Main.Message.AddWarning("No page selected." & vbCrLf)
            Exit Sub
        End If

        Dim FileName As String
        FileName = lstWebPages.SelectedItem.ToString

        If FileName = "" Then
            Main.Message.AddWarning("No page selected." & vbCrLf)
        Else
            Dim FormNo As Integer = Main.OpenNewHtmlDisplayPage()
            Main.HtmlDisplayFormList(FormNo).FileName = FileName
            Main.HtmlDisplayFormList(FormNo).OpenDocument
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) 
        'Create a new HTML file and open it in an HTML edit window.

        Dim PageTitle As String = Trim(txtNewHtmlFileTitle.Text)
        If PageTitle = "" Then
            Main.Message.AddWarning("Please enter a page title." & vbCrLf)
            Exit Sub
        End If

        Dim FileName As String = ""
        If LCase(txtNewHtmlFileName.Text).EndsWith(".html") Then
            FileName = IO.Path.GetFileNameWithoutExtension(txtNewHtmlFileName.Text) & ".html"
        ElseIf LCase(txtNewHtmlFileName.Text).EndsWith(".htm") Then
            FileName = IO.Path.GetFileNameWithoutExtension(txtNewHtmlFileName.Text) & ".html"
        ElseIf txtNewHtmlFileName.Text.Contains(".") Then
            Main.Message.AddWarning("Unknown file extension: " & IO.Path.GetExtension(txtNewHtmlFileName.Text) & vbCrLf)
            Exit Sub
        Else
            FileName = txtNewHtmlFileName.Text & ".html"
        End If

        txtNewHtmlFileName.Text = FileName

        If Main.Project.DataFileExists(FileName) Then
            Main.Message.AddWarning("HTML file already exists: " & FileName & vbCrLf)
        Else
            'Create the new web page:
            Dim htmData As New IO.MemoryStream
            Dim sw As New IO.StreamWriter(htmData)
            sw.Write(Main.DefaultHtmlString(PageTitle))
            sw.Flush()
            Main.Project.SaveData(FileName, htmData)
            lstWebPages.Items.Add(FileName)
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'Delete the selected web page.

        If lstWebPages.SelectedItem Is Nothing Then
            Main.Message.AddWarning("No page selected." & vbCrLf)
            Exit Sub
        End If

        Dim FileName As String = lstWebPages.SelectedItem.ToString

        Dim dr As System.Windows.Forms.DialogResult
        dr = MessageBox.Show("Are you sure you want to delete the web page: " & FileName, "Notice", MessageBoxButtons.YesNo)
        If dr = System.Windows.Forms.DialogResult.Yes Then
            Main.Project.DeleteData(FileName)
            lstWebPages.Items.Remove(lstWebPages.SelectedItem)
        Else

        End If
    End Sub

    Private Sub btnOpenInMain_Click(sender As Object, e As EventArgs) Handles btnOpenInMain.Click
        'Open the selected web page in the Main form Start Page tab.

        If lstWebPages.SelectedItem Is Nothing Then
            Main.Message.AddWarning("No page selected." & vbCrLf)
            Exit Sub
        End If

        Dim FileName As String

        FileName = lstWebPages.SelectedItem.ToString

        If FileName = "" Then

        Else
            If Main.Project.DataFileExists(FileName) Then
                Main.WorkflowFileName = FileName
                Dim rtbData As New IO.MemoryStream
                Main.Project.ReadData(FileName, rtbData)
                rtbData.Position = 0
                Dim sr As New IO.StreamReader(rtbData)
                Main.WebBrowser1.DocumentText = sr.ReadToEnd()
            Else
                Main.Message.AddWarning("Web page file not found: " & FileName & vbCrLf)
            End If
        End If
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        'Show Home page in Workflow tab of the Main form.
        Main.OpenStartPage()
    End Sub

    Private Sub lstWebPages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstWebPages.SelectedIndexChanged
        'A new Workflow file has been selected.
        'Show the file creation date and last edit date:

        Dim FileName As String
        FileName = lstWebPages.SelectedItem.ToString
        If FileName = "" Then
            txtCreated.Text = ""
            txtEdited.Text = ""
        Else
            Dim FileCreationDate As Date = Main.Project.DataFileCreationDate(FileName)
            txtCreated.Text = FileCreationDate.ToString

            Dim FileLastEditDate As Date = Main.Project.DataFileLastEditDate(FileName)
            txtEdited.Text = FileLastEditDate.ToString

            'Get the Workflow description:
            Dim WorkflowPage As String
            Dim WorkflowPageStream As New IO.MemoryStream
            Main.Project.ReadData(FileName, WorkflowPageStream)
            WorkflowPageStream.Position = 0
            Dim sr As New IO.StreamReader(WorkflowPageStream)
            WorkflowPage = sr.ReadToEnd

            'The Regular Expression should match the "Workflow description." in the HTML <meta> tag below:
            '<meta name="description" content="Workflow description.">
            Dim DescrPattern As String = "<meta name=""description"" content=""(?<Description>.+)"">"

            Dim myRegEx As New System.Text.RegularExpressions.Regex(DescrPattern)
            Dim myMatch As System.Text.RegularExpressions.Match = myRegEx.Match(WorkflowPage)

            If myMatch.Success Then
                'Main.Message.Add("Match" & vbCrLf)
                txtDescription.Text = myMatch.Groups("Description").ToString
            Else
                'Main.Message.Add("No Match" & vbCrLf)
                txtDescription.Text = ""
            End If
        End If
    End Sub

    Private Sub lstWebPages_DoubleClick(sender As Object, e As EventArgs) Handles lstWebPages.DoubleClick
        'Open the selected Workflow on Double-click.
        OpenWorkflowWebPage()
    End Sub

#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

End Class