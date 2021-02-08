Public Class frmDatums
    'The Datums form is used to display summary parameters of the datums in the list.

#Region " Variable Declarations - All the variables used in this form and this application." '-------------------------------------------------------------------------------------------------

    Dim AngleDegMinSec As New ADVL_Coordinates_Library_1.AngleDegMinSec 'Used for converting between decimal degrees and degrees-minutes-seconds
    Dim AngleConvert As New ADVL_Coordinates_Library_1.AngleConvert  'Used for converting between radians, decimal degrees and gradians

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

#End Region 'Process XML Files ----------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Display Methods - Code used to display this form." '----------------------------------------------------------------------------------------------------------------------------

    Private Sub frmDatums_Load(sender As Object, e As EventArgs) Handles Me.Load

        cmbELongWE.Items.Add("W")
        cmbELongWE.Items.Add("E")
        cmbELongWE.SelectedIndex = 1 'Select "E"

        cmbWLongWE.Items.Add("W")
        cmbWLongWE.Items.Add("E")
        cmbWLongWE.SelectedIndex = 1 'Select "E"

        cmbNLatNS.Items.Add("N")
        cmbNLatNS.Items.Add("S")
        cmbNLatNS.SelectedIndex = 0 'Select "N"

        cmbSLatNS.Items.Add("N")
        cmbSLatNS.Items.Add("S")
        cmbSLatNS.SelectedIndex = 0 'Select "N"

        AngleDegMinSec.SecondsDecimalPlaces = 5

        RestoreFormSettings()

        Main.Datum.AddUser()
        UpdateList()
        txtNRecords.Text = Main.Datum.NRecords
        txtDatumListFileName.Text = Main.Datum.ListFileName
        CurrentRecordNo = 1
        DisplayListData(1)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the form
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub UpdateList()
        'Update the list of Datums in ListBox1

        ListBox1.Items.Clear()

        Dim Index As Integer

        For Index = 0 To Main.Datum.NRecords - 1
            ListBox1.Items.Add(Main.Datum.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the CoordOpMethod list.

        If RecordNo < 1 Then
            Main.Message.AddWarning("Cannot display Coordinate Operation Method data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.Datum.NRecords Then
            Main.Message.AddWarning("Cannot display Coordinate Operation Method data. Selected record number is too large." & vbCrLf)
            Exit Sub
        End If

        txtDatumName.Text = Main.Datum.List(RecordNo - 1).Name
        txtDatumName2.Text = Main.Datum.List(RecordNo - 1).Name
        txtDatumAuthor.Text = Main.Datum.List(RecordNo - 1).Author
        txtDatumCode.Text = Main.Datum.List(RecordNo - 1).Code
        txtDatumDeprecated.Text = Main.Datum.List(RecordNo - 1).Deprecated
        Select Case Main.Datum.List(RecordNo - 1).Type
            Case ADVL_Coordinates_Library_1.DatumSummary.DatumTypes.Engineering
                txtDatumType.Text = "Engineering"
            Case ADVL_Coordinates_Library_1.DatumSummary.DatumTypes.Geodetic
                txtDatumType.Text = "Geodetic"
            Case ADVL_Coordinates_Library_1.DatumSummary.DatumTypes.Image
                txtDatumType.Text = "Image"
            Case ADVL_Coordinates_Library_1.DatumSummary.DatumTypes.Vertical
                txtDatumType.Text = "Vertical"
            Case ADVL_Coordinates_Library_1.DatumSummary.DatumTypes.Unknown
                txtDatumType.Text = "Unknown"
        End Select

        txtDatumComments.Text = Main.Datum.List(RecordNo - 1).Comments
        txtDatumOrigin.Text = Main.Datum.List(RecordNo - 1).OriginDescription
        txtDatumScope.Text = Main.Datum.List(RecordNo - 1).Scope

        'Update the list of alias names:
        cmbDatumAliasNames.Items.Clear()
        cmbDatumAliasNames.Text = ""
        For Each item As String In Main.Datum.List(RecordNo - 1).AliasName
            cmbDatumAliasNames.Items.Add(item)
        Next
        If cmbDatumAliasNames.Items.Count > 0 Then
            cmbDatumAliasNames.SelectedIndex = 0 'Select first item
        End If

        'Display area of use data: ------------------------------------------------------------------------------------------------------------
        txtAreaOfUseName.Text = Main.Datum.List(RecordNo - 1).AreaOfUse.Name
        txtEpsgAouCode.Text = Main.Datum.List(RecordNo - 1).AreaOfUse.Code

        'Update the list of alias names:
        cmbAouAliasNames.Items.Clear()
        cmbAouAliasNames.Text = ""
        For Each item As String In Main.Datum.List(RecordNo - 1).AreaOfUse.AliasName
            cmbAouAliasNames.Items.Add(item)
        Next
        If cmbAouAliasNames.Items.Count > 0 Then
            cmbAouAliasNames.SelectedIndex = 0 'Select first item
        End If

        txtAouComments.Text = Main.Datum.List(RecordNo - 1).AreaOfUse.Comments
        txtIso2CharCode.Text = Main.Datum.List(RecordNo - 1).AreaOfUse.IsoA2Code
        txtIso3CharCode.Text = Main.Datum.List(RecordNo - 1).AreaOfUse.IsoA3Code
        txtIsoNumericCode.Text = Main.Datum.List(RecordNo - 1).AreaOfUse.IsoNCode
        txtAouDescription.Text = Main.Datum.List(RecordNo - 1).AreaOfUse.Description

        'Bounding coordinates are stored as decimal degrees referenced to the WGS84 datum.
        'South latitude
        If Main.Datum.List(RecordNo - 1).AreaOfUse.SouthLatitude < 0 Then
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.Datum.List(RecordNo - 1).AreaOfUse.SouthLatitude * -1)
            For Each NSitem In cmbSLatNS.Items
                If NSitem.ToString = "S" Then
                    cmbSLatNS.SelectedItem = NSitem
                End If
            Next
        Else
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.Datum.List(RecordNo - 1).AreaOfUse.SouthLatitude)
            For Each NSitem In cmbSLatNS.Items
                If NSitem.ToString = "N" Then
                    cmbSLatNS.SelectedItem = NSitem
                End If
            Next
        End If
        txtNLatDegrees.Text = AngleDegMinSec.Degrees
        txtNLatMinutes.Text = AngleDegMinSec.Minutes
        txtNLatSeconds.Text = AngleDegMinSec.Seconds

        'North latitude
        If Main.Datum.List(RecordNo - 1).AreaOfUse.NorthLatitude < 0 Then
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.Datum.List(RecordNo - 1).AreaOfUse.NorthLatitude * -1)
            For Each NSitem In cmbNLatNS.Items
                If NSitem.ToString = "S" Then
                    cmbNLatNS.SelectedItem = NSitem
                End If
            Next
        Else
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.Datum.List(RecordNo - 1).AreaOfUse.NorthLatitude)
            For Each NSitem In cmbNLatNS.Items
                If NSitem.ToString = "N" Then
                    cmbNLatNS.SelectedItem = NSitem
                End If
            Next
        End If
        txtSLatDegrees.Text = AngleDegMinSec.Degrees
        txtSLatMinutes.Text = AngleDegMinSec.Minutes
        txtSLatSeconds.Text = AngleDegMinSec.Seconds

        'Left longitude
        If Main.Datum.List(RecordNo - 1).AreaOfUse.WestLongitude < 0 Then
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.Datum.List(RecordNo - 1).AreaOfUse.WestLongitude * -1)
            For Each WEitem In cmbWLongWE.Items
                If WEitem.ToString = "W" Then
                    cmbWLongWE.SelectedItem = WEitem
                End If
            Next
        Else
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.Datum.List(RecordNo - 1).AreaOfUse.WestLongitude)
            For Each WEitem In cmbWLongWE.Items
                If WEitem.ToString = "E" Then
                    cmbWLongWE.SelectedItem = WEitem
                End If
            Next
        End If
        txtWLongDegrees.Text = AngleDegMinSec.Degrees
        txtWLongMinutes.Text = AngleDegMinSec.Minutes
        txtWLongSeconds.Text = AngleDegMinSec.Seconds

        'right longitude
        If Main.Datum.List(RecordNo - 1).AreaOfUse.EastLongitude < 0 Then
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.Datum.List(RecordNo - 1).AreaOfUse.EastLongitude * -1)
            For Each WEitem In cmbELongWE.Items
                If WEitem.ToString = "W" Then
                    cmbELongWE.SelectedItem = WEitem
                End If
            Next
        Else
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.Datum.List(RecordNo - 1).AreaOfUse.EastLongitude)
            For Each WEitem In cmbELongWE.Items
                If WEitem.ToString = "E" Then
                    cmbELongWE.SelectedItem = WEitem
                End If
            Next
        End If
        txtELongDegrees.Text = AngleDegMinSec.Degrees
        txtELongMinutes.Text = AngleDegMinSec.Minutes
        txtELongSeconds.Text = AngleDegMinSec.Seconds

    End Sub

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the Datum list from the EPSG database.
        Main.Datum.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.Datum.NRecords
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the Datum list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in Datum List
        If CurrentRecordNo = Main.Datum.NRecords Then
            'Already at the last record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in Datum List
        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the Datum list:
        CurrentRecordNo = Main.Datum.NRecords
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the Datum list.

        Dim DatumListFileName As String = Trim(txtDatumListFileName.Text)

        If DatumListFileName = "" Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Please enter a file name for the Datum list!" & vbCrLf)
            Exit Sub
        End If

        If DatumListFileName.EndsWith(".DatumList") Then
            'DatumListFileName has correct file extension.
            Main.Datum.ListFileName = DatumListFileName
        Else
            'Add file extension to the file name.
            DatumListFileName &= ".DatumList"
            Main.Datum.ListFileName = DatumListFileName
            txtDatumListFileName.Text = DatumListFileName
        End If
        Main.Project.SaveXmlData(DatumListFileName, Main.Datum.ToXDoc())
    End Sub

    Private Sub txtRecordNo_TextChanged(sender As Object, e As EventArgs) Handles txtRecordNo.TextChanged
        Dim NewRecordNo As Integer
        NewRecordNo = Int(Val(txtRecordNo.Text))

        If NewRecordNo < 1 Then
            Exit Sub
        End If

        If NewRecordNo > Main.Datum.NRecords Then
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
        'Find a Datum list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select an Datum list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Datum List | *.DatumList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtDatumListFileName.Text = DataFileName
                    Main.Datum.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.Datum.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.Datum.NRecords
                    txtRecordNo.Text = 1
                    DisplayListData(1)
                End If

            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                'Select an Area of Use list file from the project archive:
                'Show the zip archive file selection form:
                Zip = New ADVL_Utilities_Library_1.ZipComp
                Zip.ArchivePath = Main.Project.DataLocn.Path
                Zip.SelectFile()
                'Zip.SelectFileForm.ApplicationName = Main.Project.ApplicationName
                Zip.SelectFileForm.ApplicationName = Main.Project.Application.Name
                Zip.SelectFileForm.SettingsLocn = Main.Project.SettingsLocn
                Zip.SelectFileForm.Show()
                Zip.SelectFileForm.RestoreFormSettings()
                Zip.SelectFileForm.FileExtension = ".DatumList"
                Zip.SelectFileForm.GetFileList()
        End Select
    End Sub

    Private Sub btnNameFind_Click(sender As Object, e As EventArgs) Handles btnNameFind.Click
        'Find the first record with specified text contained within the Name field.
        FindRecord(txtSearchText.Text)
    End Sub

    Private Sub FindRecord(ByVal SearchString As String)
        'Find a record using the SearchString to match the Name field
        Dim FoundIndex As Integer
        FoundIndex = Main.Datum.List.FindIndex(Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.Datum.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
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
        FoundIndex = Main.Datum.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
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