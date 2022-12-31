Imports System.IO
Imports System.IO.Compression
Public Class frmArchive
    'Archive form used to view the data in Project Archive files.

    'NOTE: The following reference must be added to the Project to access ZipFile methods:
    '      Project \ Add Reference \ Assemblies \ System.IO.Compression.FileSystem
    'Also add this reference:
    '      Project \ Add Reference \ Assemblies \ System.IO.Compression

#Region " Variable Declarations - All the variables used in this form and this application." '=================================================================================================

    'Dim ZipStream As System.IO.FileStream
    Dim Zip As System.IO.Compression.ZipArchive

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Properties - All the properties used in this form and this application" '============================================================================================================

    Private _title As String = "Archive"
    Property Title As String
        Get
            Return _title
        End Get
        Set(value As String)
            _title = value
            Me.Text = _title
            RestoreFormSettings()   'Restore the form settings
        End Set
    End Property

    Private _path As String 'The path of the archive file.
    Property Path As String
        Get
            Return _path
        End Get
        Set(value As String)
            _path = value
            'ZipStream = New System.IO.FileStream(_path, IO.FileMode.Open)
            'Zip = New IO.Compression.ZipArchive(ZipStream, IO.Compression.ZipArchiveMode.Read)
            'Dim archive As ZipArchive = ZipFile.OpenRead(_path)
            'Zip = ZipFile.OpenRead(_path)
            'Zip = ZipFile.Open(_path, ZipArchiveMode.Update)
            GetArchiveFileList()
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

        'Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Title & ".xml"
        Main.Project.SaveXmlSettings(SettingsFileName, settingsData)
    End Sub

    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        'Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Title & ".xml"

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
        'RestoreFormSettings()   'Restore the form settings 'THIS IS NOW DONE WHEN THE TITLE PROPERTY IS SET.

        DataGridView1.ColumnCount = 4
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView1.Font, FontStyle.Bold) 'Use bold font for the column headers
        DataGridView1.Columns(0).HeaderText = "File Name"
        DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridView1.Columns(1).HeaderText = "Date Modified"
        DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'DataGridView1.Columns(2).HeaderText = "Type"
        'DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridView1.Columns(2).HeaderText = "Size"
        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(3).HeaderText = "Compressed"
        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.AllowUserToAddRows = False

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Form
        'Zip.Dispose() 'Now already disposed.
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

    Private Sub GetArchiveFileList()
        DataGridView1.Rows.Clear()

        Zip = ZipFile.OpenRead(_path)

        For Each entry As ZipArchiveEntry In Zip.Entries
            DataGridView1.Rows.Add(entry.Name, entry.LastWriteTime, entry.Length, entry.CompressedLength)
        Next
        Zip.Dispose()
        DataGridView1.AutoResizeColumns()

    End Sub

    Private Sub btnPaste_Click(sender As Object, e As EventArgs) Handles btnPaste.Click

        Dim FileList As System.Collections.Specialized.StringCollection

        If Clipboard.ContainsFileDropList Then
            FileList = Clipboard.GetFileDropList()
            Dim FileName As String
            Zip = ZipFile.Open(_path, ZipArchiveMode.Update)
            For Each item In FileList
                If System.IO.File.Exists(item) Then
                    FileName = System.IO.Path.GetFileName(item)
                    If IsNothing(Zip.GetEntry(FileName)) Then
                        Zip.CreateEntryFromFile(item, FileName)
                    Else
                        Main.Message.AddWarning("A file with the same name is already in the archive: " & item & vbCrLf)
                    End If
                    'UPDATE:
                    'Dim entry As ZipArchiveEntry = Zip.GetEntry(FileName)
                    'If IsNothing(entry) Then

                    'Else
                    '    entry.Delete()
                    'End If
                    'Dim newEntry As ZipArchiveEntry = Zip.CreateEntry(FileName)

                Else
                    Main.Message.AddWarning("The file to paste was not found: " & item & vbCrLf)
                End If
            Next
            Zip.Dispose()
            GetArchiveFileList()
        Else
            Main.Message.AddWarning("The Clipboard does not contain a file list." & vbCrLf)
        End If

    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        'Copy the selected files

        If Main.Project.Type = ADVL_Utilities_Library_1.Project.Types.Hybrid Then
            'This is a Hybrid project.
            'The Project Directory is at: Main.Project.Path
            'Check if the Temp directory exists:
            If System.IO.Directory.Exists(Main.Project.Path & "\Temp") Then

            Else
                'Create the Temp directory:
                System.IO.Directory.CreateDirectory(Main.Project.Path & "\Temp")
            End If
            If System.IO.Directory.Exists(Main.Project.Path & "\Temp") Then
                Dim FileName As String
                Dim ExtractDir As String = Main.Project.Path & "\Temp"
                Dim FileList As New System.Collections.Specialized.StringCollection
                'Copy each selected file to \Temp and add the path to the file list:

                If DataGridView1.SelectedRows.Count > 0 Then
                    Zip = ZipFile.OpenRead(_path)
                    For Each item As DataGridViewRow In DataGridView1.SelectedRows
                        FileName = item.Cells(0).Value
                        Dim myEntry As ZipArchiveEntry = Zip.GetEntry(FileName)
                        If IsNothing(myEntry) Then
                            Main.Message.AddWarning("This file was not found in the archive: " & FileName & vbCrLf)
                        Else
                            'Copy the file:
                            myEntry.ExtractToFile(ExtractDir & "\" & FileName, True)
                            FileList.Add(ExtractDir & "\" & FileName)
                        End If
                    Next
                    Zip.Dispose()
                    Clipboard.SetFileDropList(FileList)
                Else
                    Main.Message.AddWarning("No files have been selected for copying." & vbCrLf)
                End If
            Else
                Main.Message.AddWarning("The temporary directory does not exist: " & Main.Project.Path & "\Temp" & vbCrLf)
            End If
        End If


    End Sub

#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Events - Events that can be triggered by this form." '==========================================================================================================================

#End Region 'Form Events ----------------------------------------------------------------------------------------------------------------------------------------------------------------------

End Class