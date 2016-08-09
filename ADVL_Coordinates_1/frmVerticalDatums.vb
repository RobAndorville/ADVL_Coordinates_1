Public Class frmVerticalDatums
    'The Vertical Datums form is used to create, select and edit vertical datums.

#Region " Variable Declarations - All the variables used in this form and this application." '-------------------------------------------------------------------------------------------------

    Dim AngleConvert As New ADVL_Coordinates_Library_1.AngleConvert
    Dim AngleDMS As New ADVL_Coordinates_Library_1.AngleDegMinSec

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

        'Dim SettingsFileName As String = "Formsettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Main.Project.SaveXmlSettings(SettingsFileName, settingsData)

    End Sub

    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        'Dim SettingsFileName As String = "Formsettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
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

    Private Sub frmVerticalDatums_Load(sender As Object, e As EventArgs) Handles Me.Load
        RestoreFormSettings()

        cmbNLatNS.Items.Add("N")
        cmbNLatNS.Items.Add("S")
        cmbNLatNS.SelectedIndex = 0 'Select "N"

        cmbSLatNS.Items.Add("N")
        cmbSLatNS.Items.Add("S")
        cmbSLatNS.SelectedIndex = 0 'Select "N"

        cmbWLongWE.Items.Add("W")
        cmbWLongWE.Items.Add("E")
        cmbWLongWE.SelectedIndex = 1 'Select "E"

        cmbELongWE.Items.Add("W")
        cmbELongWE.Items.Add("E")
        cmbELongWE.SelectedIndex = 1 'Select "E"

        Main.VerticalDatum.AddUser()
        Main.AreaOfUse.AddUser()

        UpdateList()
        txtNRecords.Text = Main.VerticalDatum.NRecords
        txtDatumListFileName.Text = Main.VerticalDatum.ListFileName
        CurrentRecordNo = 1
        DisplayListData(1)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the form
        Main.VerticalDatum.RemoveUser()
        Main.AreaOfUse.RemoveUser()
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the Vertical Datum list from the EPSG database.
        Main.VerticalDatum.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.VerticalDatum.NRecords
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub UpdateList()
        'Update the list of records in ListBox1
        ListBox1.Items.Clear()
        Dim Index As Integer
        For Index = 0 To Main.VerticalDatum.NRecords - 1
            ListBox1.Items.Add(Main.VerticalDatum.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the Vertical Datum list.

        If RecordNo < 1 Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Vertical Datum data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.VerticalDatum.NRecords Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Vertical Datum data. Selected record number is too large." & vbCrLf)
            Exit Sub
        End If

        txtVerticalDatumName.Text = Main.VerticalDatum.List(RecordNo - 1).Name
        txtDatumAuthor.Text = Main.VerticalDatum.List(RecordNo - 1).Author
        txtDatumCode.Text = Main.VerticalDatum.List(RecordNo - 1).Code
        txtDatumDeprecated.Text = Main.VerticalDatum.List(RecordNo - 1).Deprecated

        'Update the list of alias names:
        cmbDatumAliasNames.Items.Clear()
        cmbDatumAliasNames.Text = ""
        For Each item As String In Main.VerticalDatum.List(RecordNo - 1).AliasName
            cmbDatumAliasNames.Items.Add(item)
        Next

        If cmbDatumAliasNames.Items.Count > 0 Then
            cmbDatumAliasNames.SelectedIndex = 0 'Select first item
        End If

        txtDatumComments.Text = Main.VerticalDatum.List(RecordNo - 1).Comments
        txtDatumOrigin.Text = Main.VerticalDatum.List(RecordNo - 1).OriginDescription
        txtDatumScope.Text = Main.VerticalDatum.List(RecordNo - 1).Scope


        'Display area of use data: ------------------------------------------------------------------------------------------------------------
        txtAreaOfUseName.Text = Main.VerticalDatum.List(RecordNo - 1).Area.Name
        txtAouCode.Text = Main.VerticalDatum.List(RecordNo - 1).Area.Code
        txtAreaAuthor.Text = Main.VerticalDatum.List(RecordNo - 1).Area.Author

        Dim AreaMatch = From Area In Main.AreaOfUse.List Where Area.Author = Main.VerticalDatum.List(RecordNo - 1).Area.Author And Area.Code = Main.VerticalDatum.List(RecordNo - 1).Area.Code

        If AreaMatch.Count > 0 Then
            'Update the list of alias names:
            cmbAouAliasNames.Items.Clear()
            cmbAouAliasNames.Text = ""
            For Each item As String In AreaMatch(0).AliasName
                cmbAouAliasNames.Items.Add(item)
            Next

            If cmbAouAliasNames.Items.Count > 0 Then
                cmbAouAliasNames.SelectedIndex = 0 'Select first item
            End If

            txtAouComments.Text = AreaMatch(0).Comments
            txtIso2CharCode.Text = AreaMatch(0).IsoA2Code
            txtIso3CharCode.Text = AreaMatch(0).IsoA3Code
            txtIsoNumericCode.Text = AreaMatch(0).IsoNCode
            txtAouDescription.Text = AreaMatch(0).Description

            'Bounding coordinates are stored as decimal degrees referenced to the WGS84 datum.
            'South latitude
            If AreaMatch(0).SouthLatitude < 0 Then
                AngleDMS.DecimalDegreesToDegMinSec(AreaMatch(0).SouthLatitude * -1)
                For Each NSitem In cmbSLatNS.Items
                    If NSitem.ToString = "S" Then
                        cmbSLatNS.SelectedItem = NSitem
                    End If
                Next
            Else
                AngleDMS.DecimalDegreesToDegMinSec(AreaMatch(0).SouthLatitude)
                For Each NSitem In cmbSLatNS.Items
                    If NSitem.ToString = "N" Then
                        cmbSLatNS.SelectedItem = NSitem
                    End If
                Next
            End If
            txtNLatDegrees.Text = AngleDMS.Degrees
            txtNLatMinutes.Text = AngleDMS.Minutes
            txtNLatSeconds.Text = AngleDMS.Seconds

            'North latitude
            If AreaMatch(0).NorthLatitude < 0 Then
                AngleDMS.DecimalDegreesToDegMinSec(AreaMatch(0).NorthLatitude * -1)
                For Each NSitem In cmbNLatNS.Items
                    If NSitem.ToString = "S" Then
                        cmbNLatNS.SelectedItem = NSitem
                    End If
                Next
            Else
                AngleDMS.DecimalDegreesToDegMinSec(AreaMatch(0).NorthLatitude)
                For Each NSitem In cmbNLatNS.Items
                    If NSitem.ToString = "N" Then
                        cmbNLatNS.SelectedItem = NSitem
                    End If
                Next
            End If
            txtSLatDegrees.Text = AngleDMS.Degrees
            txtSLatMinutes.Text = AngleDMS.Minutes
            txtSLatSeconds.Text = AngleDMS.Seconds

            'Left longitude
            If AreaMatch(0).WestLongitude < 0 Then
                AngleDMS.DecimalDegreesToDegMinSec(AreaMatch(0).WestLongitude * -1)
                For Each WEitem In cmbWLongWE.Items
                    If WEitem.ToString = "W" Then
                        cmbWLongWE.SelectedItem = WEitem
                    End If
                Next
            Else
                AngleDMS.DecimalDegreesToDegMinSec(AreaMatch(0).WestLongitude)
                For Each WEitem In cmbWLongWE.Items
                    If WEitem.ToString = "E" Then
                        cmbWLongWE.SelectedItem = WEitem
                    End If
                Next
            End If
            txtWLongDegrees.Text = AngleDMS.Degrees
            txtWLongMinutes.Text = AngleDMS.Minutes
            txtWLongSeconds.Text = AngleDMS.Seconds

            'right longitude
            If AreaMatch(0).EastLongitude < 0 Then
                AngleDMS.DecimalDegreesToDegMinSec(AreaMatch(0).EastLongitude * -1)
                For Each WEitem In cmbELongWE.Items
                    If WEitem.ToString = "W" Then
                        cmbELongWE.SelectedItem = WEitem
                    End If
                Next
            Else
                AngleDMS.DecimalDegreesToDegMinSec(AreaMatch(0).EastLongitude)
                For Each WEitem In cmbELongWE.Items
                    If WEitem.ToString = "E" Then
                        cmbELongWE.SelectedItem = WEitem
                    End If
                Next
            End If
            txtELongDegrees.Text = AngleDMS.Degrees
            txtELongMinutes.Text = AngleDMS.Minutes
            txtELongSeconds.Text = AngleDMS.Seconds
        Else

        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the Vertical Datum list.

        Dim DatumListFileName As String = Trim(txtDatumListFileName.Text)

        If DatumListFileName = "" Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Please enter a file name for the Vertical Datum list!" & vbCrLf)
            Exit Sub
        End If

        If DatumListFileName.EndsWith(".VertDatumList") Then
            'DatumListFileName has correct file extension.
            Main.VerticalDatum.ListFileName = DatumListFileName
        Else
            'Add file extension to the file name.
            DatumListFileName &= ".VertDatumList"
            Main.VerticalDatum.ListFileName = DatumListFileName
            txtDatumListFileName.Text = DatumListFileName
        End If

        Main.Project.SaveXmlData(DatumListFileName, Main.VerticalDatum.ToXDoc())
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the Vertical Datum list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in Vertical Datum List
        If CurrentRecordNo = Main.VerticalDatum.NRecords Then
            'Already at the last record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in Vertical Datum List
        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the Vertical Datum list:
        CurrentRecordNo = Main.VerticalDatum.NRecords
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub txtRecordNo_TextChanged(sender As Object, e As EventArgs) Handles txtRecordNo.TextChanged
        Dim NewRecordNo As Integer
        NewRecordNo = Int(Val(txtRecordNo.Text))

        If NewRecordNo < 1 Then
            Exit Sub
        End If

        If NewRecordNo > Main.VerticalDatum.NRecords Then
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

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Find a Vertical Datum list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select a Vertical Datum list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Vertical Datum List | *.VertDatumList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtDatumListFileName.Text = DataFileName
                    Main.VerticalDatum.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.VerticalDatum.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.VerticalDatum.NRecords
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
                Zip.SelectFileForm.FileExtension = ".VertDatumList"
                Zip.SelectFileForm.GetFileList()
        End Select
    End Sub

    Private Sub Zip_FileSelected(FileName As String) Handles Zip.FileSelected
        txtDatumListFileName.Text = FileName
        Main.VerticalDatum.ListFileName = FileName
        Dim XmlDoc As System.Xml.Linq.XDocument
        Main.Project.DataLocn.ReadXmlData(FileName, XmlDoc)
        Main.VerticalDatum.LoadXml(XmlDoc)
        UpdateList()
        txtNRecords.Text = Main.VerticalDatum.NRecords
        txtRecordNo.Text = 1
        DisplayListData(1)
    End Sub

    Private Sub btnNameFind_Click(sender As Object, e As EventArgs) Handles btnNameFind.Click
        'Find the first record with specified text contained within the Name field.
        FindRecord(txtSearchText.Text)
    End Sub

    Private Sub FindRecord(ByVal SearchString As String)
        'Find a record using the SearchString to match the Name field
        Dim FoundIndex As Integer
        FoundIndex = Main.VerticalDatum.List.FindIndex(Function(x) x.Name.Contains(SearchString))
        If FoundIndex = -1 Then
            Main.Message.Add("String not found." & vbCrLf)
        Else
            CurrentRecordNo = FoundIndex + 1
        End If
    End Sub

    Private Sub btnNameFindNext_Click(sender As Object, e As EventArgs) Handles btnNameFindNext.Click
        'Find the next record with specified text contained within the Name field.
        FindNextRecord(txtSearchText.Text)
    End Sub

    Private Sub FindNextRecord(ByVal SearchString As String)
        Dim FoundIndex As Integer
        FoundIndex = Main.VerticalDatum.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.VerticalDatum.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
            If FoundIndex = -1 Then
                Main.Message.Add("String not found." & vbCrLf)
            Else
                CurrentRecordNo = FoundIndex + 1
            End If
        Else
            Main.Message.Add("At first record in the list." & vbCrLf)
        End If
    End Sub

#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Events - Events that can be triggered by this form." '--------------------------------------------------------------------------------------------------------------------------
#End Region 'Form Events ----------------------------------------------------------------------------------------------------------------------------------------------------------------------



   

End Class