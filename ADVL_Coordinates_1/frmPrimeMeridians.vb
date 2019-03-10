Public Class frmPrimeMeridians
    'The Prime Meridian form is used to view, create or edit unit Prime Meridian parameters.

#Region " Variable Declarations - All the variables used in this form and this application." '-------------------------------------------------------------------------------------------------

    Dim WithEvents Zip As ADVL_Utilities_Library_1.ZipComp

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Properties - All the properties used in this form and this application" '------------------------------------------------------------------------------------------------------------

    Private _currentRecordNo As Integer = 0
    Property CurrentRecordNo As Integer
        Get
            Return _currentRecordNo
        End Get
        Set(value As Integer)
            _currentRecordNo = value
            txtRecordNo.Text = _currentRecordNo
            If ListBox1.Items.Count >= _currentRecordNo Then
                ListBox1.SelectedIndex = _currentRecordNo - 1
            End If
        End Set
    End Property

#End Region 'Properties -----------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Process XML files - Read and write XML files." '-------------------------------------------------------------------------------------------------------------------------------------

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
            If Settings.<FormSettings>.<Left>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Left = Settings.<FormSettings>.<Left>.Value
            End If

            If Settings.<FormSettings>.<Top>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Top = Settings.<FormSettings>.<Top>.Value
            End If

            If Settings.<FormSettings>.<Height>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Height = Settings.<FormSettings>.<Height>.Value
            End If

            If Settings.<FormSettings>.<Width>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Width = Settings.<FormSettings>.<Width>.Value
            End If
        End If
    End Sub

#End Region 'Process XML Files ----------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Display Methods - Code used to display this form." '----------------------------------------------------------------------------------------------------------------------------

    Private Sub frmPrimeMeridian_Load(sender As Object, e As EventArgs) Handles Me.Load

        cmbUnits.Items.Add("Degrees")
        cmbUnits.Items.Add("Gradians")
        cmbUnits.Items.Add("Sexagesimal DMS")
        cmbUnits.SelectedIndex = 0 'Select the first item

        cmbWE.Items.Add("W")
        cmbWE.Items.Add("E")
        cmbWE.SelectedIndex = 1 'Select "E"

        RestoreFormSettings()

        'Show the PrimeMeridian list:
        If Main.PrimeMeridian.ListFileName = "" Then
            'No PrimeMeridian list has been selected.
        Else
            If Main.PrimeMeridian.NRecords = 0 Then
                'Load records from the selected PrimeMeridian file:
                Dim XmlDoc As System.Xml.Linq.XDocument
                Main.Project.DataLocn.ReadXmlData(Main.PrimeMeridian.ListFileName, XmlDoc)
                Main.PrimeMeridian.LoadXml(XmlDoc)
                UpdateList()
                Main.PrimeMeridian.AddUser()
                txtNRecords.Text = Main.PrimeMeridian.NRecords
                txtPmListFileName.Text = Main.PrimeMeridian.ListFileName
                CurrentRecordNo = 1
                DisplayListData(1)
            Else
                'Records have already been loaded.
                UpdateList()
                Main.PrimeMeridian.AddUser()
                txtNRecords.Text = Main.PrimeMeridian.NRecords
                txtPmListFileName.Text = Main.PrimeMeridian.ListFileName
                CurrentRecordNo = 1
                DisplayListData(1)
            End If
        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the form
        Main.PrimeMeridian.RemoveUser()
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the Prime Meridian list from the EPSG database.
        Main.PrimeMeridian.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.PrimeMeridian.NRecords
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub UpdateList()
        'Update the list of records in ListBox1
        ListBox1.Items.Clear()
        Dim Index As Integer
        For Index = 0 To Main.PrimeMeridian.NRecords - 1
            ListBox1.Items.Add(Main.PrimeMeridian.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the PrimeMeridian list.

        If RecordNo < 1 Then
            Main.Message.AddWarning("Cannot display Prime Meridian data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.PrimeMeridian.NRecords Then
            Main.Message.AddWarning("Cannot display Prime Meridian data. Selected record number is too large." & vbCrLf)
            Exit Sub
        End If

        txtPrimeMeridianName.Text = Main.PrimeMeridian.List(RecordNo - 1).Name
        txtPMAuthor.Text = Main.PrimeMeridian.List(RecordNo - 1).Author
        txtPmCode.Text = Main.PrimeMeridian.List(RecordNo - 1).Code
        txtPMDeprecated.Text = Main.PrimeMeridian.List(RecordNo - 1).Deprecated

        'Update the list of alias names:
        cmbAliasNames.Items.Clear()
        cmbAliasNames.Text = ""
        For Each item As String In Main.PrimeMeridian.List(RecordNo - 1).AliasName
            cmbAliasNames.Items.Add(item)
        Next

        If cmbAliasNames.Items.Count > 0 Then
            cmbAliasNames.SelectedIndex = 0 'Select first item
        End If

        txtComments.Text = Main.PrimeMeridian.List(RecordNo - 1).Comments

        Dim AngleConvert As New ADVL_Coordinates_Library_1.AngleConvert
        Dim AngleDMS As New ADVL_Coordinates_Library_1.AngleDegMinSec
        Select Case Main.PrimeMeridian.List(RecordNo - 1).LongitudeUOM
            Case ADVL_Coordinates_Library_1.PrimeMeridian.LongitudeUnits.Degree
                For Each item In cmbUnits.Items
                    If item.ToString = "Degrees" Then
                        cmbUnits.SelectedItem = item

                        txtDegrees.Enabled = False
                        txtMinutes.Enabled = False
                        txtSeconds.Enabled = False
                        cmbWE.Enabled = False
                        txtDecimalDegrees.Enabled = True
                        txtDecimalDegrees.Text = Main.PrimeMeridian.List(RecordNo - 1).LongitudeFromGreenwich
                        txtSexagesimalDegrees.Enabled = False
                        txtGrads.Enabled = False
                        txtRadians.Enabled = False

                        AngleConvert.DecimalDegrees = Main.PrimeMeridian.List(RecordNo - 1).LongitudeFromGreenwich
                        AngleConvert.ConvertDecimalDegreeToGradian()
                        txtGrads.Text = AngleConvert.Gradians
                        AngleConvert.ConvertDecimalDegreeToRadian()
                        txtRadians.Text = AngleConvert.Radians
                        AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                        txtSexagesimalDegrees.Text = AngleConvert.SexagesimalDegrees
                        If AngleConvert.DecimalDegrees < 0 Then
                            AngleDMS.DecimalDegreesToDegMinSec(AngleConvert.DecimalDegrees * -1)
                            For Each WEitem In cmbWE.Items
                                If WEitem.ToString = "W" Then
                                    cmbWE.SelectedItem = WEitem
                                End If
                            Next
                        Else
                            AngleDMS.DecimalDegreesToDegMinSec(AngleConvert.DecimalDegrees)
                            For Each WEitem In cmbWE.Items
                                If WEitem.ToString = "E" Then
                                    cmbWE.SelectedItem = WEitem
                                End If
                            Next
                        End If
                        txtDegrees.Text = AngleDMS.Degrees
                        txtMinutes.Text = AngleDMS.Minutes
                        txtSeconds.Text = AngleDMS.Seconds
                        Exit For
                    End If
                Next
            Case ADVL_Coordinates_Library_1.PrimeMeridian.LongitudeUnits.Gradian
                For Each item In cmbUnits.Items
                    If item.ToString = "Gradians" Then
                        cmbUnits.SelectedItem = item

                        txtDegrees.Enabled = False
                        txtMinutes.Enabled = False
                        txtSeconds.Enabled = False
                        cmbWE.Enabled = False
                        txtDecimalDegrees.Enabled = False
                        txtSexagesimalDegrees.Enabled = False
                        txtGrads.Enabled = True
                        txtGrads.Text = Main.PrimeMeridian.List(RecordNo - 1).LongitudeFromGreenwich
                        txtRadians.Enabled = False

                        AngleConvert.Gradians = Main.PrimeMeridian.List(RecordNo - 1).LongitudeFromGreenwich
                        AngleConvert.ConvertGradianToDecimalDegree()
                        txtDecimalDegrees.Text = AngleConvert.DecimalDegrees
                        AngleConvert.ConvertGradianToRadian()
                        txtRadians.Text = AngleConvert.Radians
                        AngleConvert.ConvertGradianToSexagesimalDegree()
                        txtSexagesimalDegrees.Text = AngleConvert.SexagesimalDegrees
                        If AngleConvert.DecimalDegrees < 0 Then
                            AngleDMS.DecimalDegreesToDegMinSec(AngleConvert.DecimalDegrees * -1)
                            For Each WEitem In cmbWE.Items
                                If WEitem.ToString = "W" Then
                                    cmbWE.SelectedItem = WEitem
                                End If
                            Next
                        Else
                            AngleDMS.DecimalDegreesToDegMinSec(AngleConvert.DecimalDegrees)
                            For Each WEitem In cmbWE.Items
                                If WEitem.ToString = "E" Then
                                    cmbWE.SelectedItem = WEitem
                                End If
                            Next
                        End If
                        txtDegrees.Text = AngleDMS.Degrees
                        txtMinutes.Text = AngleDMS.Minutes
                        txtSeconds.Text = AngleDMS.Seconds
                        Exit For
                    End If
                Next
            Case ADVL_Coordinates_Library_1.PrimeMeridian.LongitudeUnits.Sexagesimal_DMS
                For Each item In cmbUnits.Items
                    If item.ToString = "Sexagesimal DMS" Then
                        cmbUnits.SelectedItem = item

                        txtDegrees.Enabled = False
                        txtMinutes.Enabled = False
                        txtSeconds.Enabled = False
                        cmbWE.Enabled = False
                        txtDecimalDegrees.Enabled = False
                        txtSexagesimalDegrees.Enabled = True
                        txtSexagesimalDegrees.Text = Main.PrimeMeridian.List(RecordNo - 1).LongitudeFromGreenwich
                        txtGrads.Enabled = False
                        txtRadians.Enabled = False

                        AngleConvert.SexagesimalDegrees = Main.PrimeMeridian.List(RecordNo - 1).LongitudeFromGreenwich
                        AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                        txtDecimalDegrees.Text = AngleConvert.DecimalDegrees
                        AngleConvert.ConvertSexagesimalDegreeToGradian()
                        txtGrads.Text = AngleConvert.Gradians
                        AngleConvert.ConvertSexagesimalDegreeToRadian()
                        txtRadians.Text = AngleConvert.Radians
                        If AngleConvert.DecimalDegrees < 0 Then
                            AngleDMS.DecimalDegreesToDegMinSec(AngleConvert.DecimalDegrees * -1)
                            For Each WEitem In cmbWE.Items
                                If WEitem.ToString = "W" Then
                                    cmbWE.SelectedItem = WEitem
                                End If
                            Next
                        Else
                            AngleDMS.DecimalDegreesToDegMinSec(AngleConvert.DecimalDegrees)
                            For Each WEitem In cmbWE.Items
                                If WEitem.ToString = "E" Then
                                    cmbWE.SelectedItem = WEitem
                                End If
                            Next
                        End If
                        txtDegrees.Text = AngleDMS.Degrees
                        txtMinutes.Text = AngleDMS.Minutes
                        txtSeconds.Text = AngleDMS.Seconds
                        Exit For
                    End If
                Next
            Case ADVL_Coordinates_Library_1.PrimeMeridian.LongitudeUnits.Unknown

        End Select

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the Prime Meridian list.

        Dim PmListFileName As String = Trim(txtPmListFileName.Text)

        If PmListFileName = "" Then
            Main.Message.AddWarning("Please enter a file name for the Prime Meridian list!" & vbCrLf)
            Exit Sub
        End If

        If PmListFileName.EndsWith(".PmList") Then
            'UomListFileName has correct file extension.
            Main.PrimeMeridian.ListFileName = PmListFileName
        Else
            'Add file extension to the file name.
            PmListFileName &= ".PmList"
            Main.PrimeMeridian.ListFileName = PmListFileName
            txtPmListFileName.Text = PmListFileName
        End If

        Main.Project.SaveXmlData(PmListFileName, Main.PrimeMeridian.ToXDoc())
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Find a Prime Meridian list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select a Prime Meridian list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Prime Meridian List | *.PmList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtPmListFileName.Text = DataFileName
                    Main.PrimeMeridian.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.PrimeMeridian.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.PrimeMeridian.NRecords
                    txtRecordNo.Text = 1
                    DisplayListData(1)
                End If

            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                'Select an Area of Use list file from the project archive:
                'Show the zip archive file selection form:
                Zip = New ADVL_Utilities_Library_1.ZipComp
                Zip.ArchivePath = Main.Project.DataLocn.Path
                Zip.SelectFile()
                Zip.SelectFileForm.ApplicationName = Main.Project.ApplicationName
                Zip.SelectFileForm.SettingsLocn = Main.Project.SettingsLocn
                Zip.SelectFileForm.Show()
                Zip.SelectFileForm.RestoreFormSettings()
                Zip.SelectFileForm.FileExtension = ".PmList"
                Zip.SelectFileForm.GetFileList()
        End Select
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the Area of Use list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in PrimeMeridianList

        If CurrentRecordNo = Main.PrimeMeridian.NRecords Then
            'Already at the last record.
            Exit Sub
        End If

        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in PrimeMeridianList

        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If

        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the Area of Use list:
        CurrentRecordNo = Main.PrimeMeridian.NRecords
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub txtRecordNo_TextChanged(sender As Object, e As EventArgs) Handles txtRecordNo.TextChanged
        Dim NewRecordNo As Integer
        NewRecordNo = Int(Val(txtRecordNo.Text))

        If NewRecordNo < 1 Then
            Exit Sub
        End If

        If NewRecordNo > Main.PrimeMeridian.NRecords Then
            Exit Sub
        End If

        _currentRecordNo = NewRecordNo
        If ListBox1.Items.Count >= _currentRecordNo Then
            ListBox1.SelectedIndex = _currentRecordNo - 1
        End If
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim Index As Integer
        Index = ListBox1.SelectedIndex + 1
        CurrentRecordNo = Index
        DisplayListData(Index)
    End Sub

    Private Sub btnNameFind_Click(sender As Object, e As EventArgs) Handles btnNameFind.Click
        'Find the first record with specified text contained within the Name field.
        FindRecord(txtSearchText.Text)
    End Sub

    Private Sub FindRecord(ByVal SearchString As String)
        'Find a record using the SearchString to match the Name field
        Dim FoundIndex As Integer
        FoundIndex = Main.PrimeMeridian.List.FindIndex(Function(x) x.Name.Contains(SearchString))
        If FoundIndex = -1 Then
            Main.Message.Add("String not found." & vbCrLf)
        Else
            CurrentRecordNo = FoundIndex + 1
        End If
    End Sub

    Private Sub btnNameFindPrev_Click(sender As Object, e As EventArgs) Handles btnNameFindPrev.Click
        'Find the previous record with specified text contained within the Name field.
        FindPrevRecord(txtSearchText.Text)
    End Sub

    Private Sub FindPrevRecord(ByVal SearchString As String)
        Dim FoundIndex As Integer
        Dim Start As Integer
        If CurrentRecordNo > 1 Then
            Start = CurrentRecordNo - 2
            FoundIndex = Main.PrimeMeridian.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
            If FoundIndex = -1 Then
                Main.Message.Add("String not found." & vbCrLf)
            Else
                CurrentRecordNo = FoundIndex + 1
            End If
        Else
            Main.Message.Add("At first record in the list." & vbCrLf)
        End If
    End Sub

    Private Sub btnNameFindNext_Click(sender As Object, e As EventArgs) Handles btnNameFindNext.Click
        'Find the next record with specified text contained within the Name field.
        FindNextRecord(txtSearchText.Text)
    End Sub

    Private Sub FindNextRecord(ByVal SearchString As String)
        Dim FoundIndex As Integer
        FoundIndex = Main.PrimeMeridian.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
        If FoundIndex = -1 Then
            Main.Message.Add("String not found." & vbCrLf)
        Else
            CurrentRecordNo = FoundIndex + 1
        End If
    End Sub


#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Events - Events that can be triggered by this form." '--------------------------------------------------------------------------------------------------------------------------
#End Region 'Form Events ----------------------------------------------------------------------------------------------------------------------------------------------------------------------


End Class