﻿Public Class frmAreasOfUse
    'The Area Of Use form is used to view, create or edit areas of use for datums and projections.

#Region " Variable Declarations - All the variables used in this form." '----------------------------------------------------------------------------------------------------------------------

    Dim AngleDegMinSec As New ADVL_Coordinates_Library_1.AngleDegMinSec 'Used for converting between decimal degrees and degrees-minutes-seconds
    Dim AngleConvert As New ADVL_Coordinates_Library_1.AngleConvert  'Used for converting between radians, decimal degrees and gradians

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Properties - All the properties used in this form." '--------------------------------------------------------------------------------------------------------------------------------

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


#Region " Process XML Files - Read and write XML files." '-------------------------------------------------------------------------------------------------------------------------------------

    Private Sub SaveFormSettings()
        'Save the form settings in an XML document.

        Dim settingsData = <?xml version="1.0" encoding="utf-8"?>
                           <!---->
                           <!--Form settings for Main form.-->
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

        'Dim SettingsName As String = "FormSettings_" & Me.Text & ".xml"
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


#Region " Form Subroutines - Code used to display this form." '--------------------------------------------------------------------------------------------------------------------------------

    Private Sub frmAreaOfUse_Load(sender As Object, e As EventArgs) Handles Me.Load
        RestoreFormSettings()

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


        'Show the AreaOfUse list:
        'If Main.AreaOfUse.ListFileName = "" Then
        '    'No AreaOfUse list has been selected.
        'Else
        '    If Main.AreaOfUse.NRecords = 0 Then
        '        'Load records from the selected AreaOfUse file:
        '        Dim XmlDoc As System.Xml.Linq.XDocument
        '        Main.Project.DataLocn.ReadXmlData(Main.AreaOfUse.ListFileName, XmlDoc)
        '        Main.AreaOfUse.LoadXml(XmlDoc)
        '        UpdateList()
        '        Main.AreaOfUse.AddUser()
        '        txtNRecords.Text = Main.AreaOfUse.NRecords
        '        txtAouListFileName.Text = Main.AreaOfUse.ListFileName
        '        'txtRecordNo.Text = 1
        '        CurrentRecordNo = 1
        '        DisplayListData(1)
        '    Else
        '        'Records have already been loaded.
        '        UpdateList()
        '        Main.AreaOfUse.AddUser()
        '        txtNRecords.Text = Main.AreaOfUse.NRecords
        '        txtAouListFileName.Text = Main.AreaOfUse.ListFileName
        '        CurrentRecordNo = 1
        '        DisplayListData(1)
        '    End If
        'End If

        Main.AreaOfUse.AddUser()
        UpdateList()
        txtNRecords.Text = Main.AreaOfUse.NRecords
        txtAouListFileName.Text = Main.AreaOfUse.ListFileName
        CurrentRecordNo = 1
        DisplayListData(1)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the form
        Main.AreaOfUse.RemoveUser()
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Subroutines -----------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the Area of Use list from the EPSG database.
        Main.AreaOfUse.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.AreaOfUse.NRecords
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub UpdateList()
        'Update the list of Area of Use in ListBox1

        ListBox1.Items.Clear()

        Dim Index As Integer

        For Index = 0 To Main.AreaOfUse.NRecords - 1
            ListBox1.Items.Add(Main.AreaOfUse.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the AreaOfUse list.

        If RecordNo < 1 Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Area Of Use data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.AreaOfUse.NRecords Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Area Of Use data. Selected record number is too large." & vbCrLf)
            Exit Sub
        End If

        txtAreaOfUseName.Text = Main.AreaOfUse.List(RecordNo - 1).Name
        txtAouCode.Text = Main.AreaOfUse.List(RecordNo - 1).Code
        txtAuthor.Text = Main.AreaOfUse.List(RecordNo - 1).Author
        txtDeprecated.Text = Main.AreaOfUse.List(RecordNo - 1).Deprecated

        'Update the list of alias names:
        cmbAliasNames.Items.Clear()
        cmbAliasNames.Text = ""
        For Each item As String In Main.AreaOfUse.List(RecordNo - 1).AliasName
            cmbAliasNames.Items.Add(item)
        Next
        If cmbAliasNames.Items.Count > 0 Then
            cmbAliasNames.SelectedIndex = 0 'Select first item
        End If

        txtComments.Text = Main.AreaOfUse.List(RecordNo - 1).Comments
        txtIso2CharCode.Text = Main.AreaOfUse.List(RecordNo - 1).IsoA2Code
        txtIso3CharCode.Text = Main.AreaOfUse.List(RecordNo - 1).IsoA3Code
        txtIsoNumericCode.Text = Main.AreaOfUse.List(RecordNo - 1).IsoNCode
        txtAreaOfUse.Text = Main.AreaOfUse.List(RecordNo - 1).Description

        'Display North Latitude:----------------------------------------------------------------------------------
        If Main.AreaOfUse.List(RecordNo - 1).NorthLatitude < 0 Then
            For Each item In cmbNLatNS.Items
                If item.ToString = "S" Then
                    cmbNLatNS.SelectedItem = item
                    Exit For
                End If
            Next
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.AreaOfUse.List(RecordNo - 1).NorthLatitude * -1)
        Else
            For Each item In cmbNLatNS.Items
                If item.ToString = "N" Then
                    cmbNLatNS.SelectedItem = item
                    Exit For
                End If
            Next
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.AreaOfUse.List(RecordNo - 1).NorthLatitude)
        End If
        txtNLatDegrees.Text = AngleDegMinSec.Degrees
        txtNLatMinutes.Text = AngleDegMinSec.Minutes
        txtNLatSeconds.Text = AngleDegMinSec.Seconds

        'Display South Latitude:---------------------------------------------------------------------------------
        If Main.AreaOfUse.List(RecordNo - 1).SouthLatitude < 0 Then
            For Each item In cmbSLatNS.Items
                If item.ToString = "S" Then
                    cmbSLatNS.SelectedItem = item
                    Exit For
                End If
            Next
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.AreaOfUse.List(RecordNo - 1).SouthLatitude * -1)
        Else
            For Each item In cmbSLatNS.Items
                If item.ToString = "N" Then
                    cmbSLatNS.SelectedItem = item
                    Exit For
                End If
            Next
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.AreaOfUse.List(RecordNo - 1).SouthLatitude)
        End If
        txtSLatDegrees.Text = AngleDegMinSec.Degrees
        txtSLatMinutes.Text = AngleDegMinSec.Minutes
        txtSLatSeconds.Text = AngleDegMinSec.Seconds

        'Display West Longitude:------------------------------------------------------------------------------------
        If Main.AreaOfUse.List(RecordNo - 1).WestLongitude < 0 Then
            For Each item In cmbWLongWE.Items
                If item.ToString = "W" Then
                    cmbWLongWE.SelectedItem = item
                    Exit For
                End If
            Next
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.AreaOfUse.List(RecordNo - 1).WestLongitude * -1)
        Else
            For Each item In cmbWLongWE.Items
                If item.ToString = "E" Then
                    cmbWLongWE.SelectedItem = item
                    Exit For
                End If
            Next
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.AreaOfUse.List(RecordNo - 1).WestLongitude)
        End If
        txtWLongDegrees.Text = AngleDegMinSec.Degrees
        txtWLongMinutes.Text = AngleDegMinSec.Minutes
        txtWLongSeconds.Text = AngleDegMinSec.Seconds

        'Display East Longitude:-----------------------------------------------------------------------------------
        If Main.AreaOfUse.List(RecordNo - 1).EastLongitude < 0 Then
            For Each item In cmbELongWE.Items
                If item.ToString = "W" Then
                    cmbELongWE.SelectedItem = item
                    Exit For
                End If
            Next
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.AreaOfUse.List(RecordNo - 1).EastLongitude * -1)
        Else
            For Each item In cmbELongWE.Items
                If item.ToString = "E" Then
                    cmbELongWE.SelectedItem = item
                    Exit For
                End If
            Next
            AngleDegMinSec.DecimalDegreesToDegMinSec(Main.AreaOfUse.List(RecordNo - 1).EastLongitude)
        End If
        txtELongDegrees.Text = AngleDegMinSec.Degrees
        txtELongMinutes.Text = AngleDegMinSec.Minutes
        txtELongSeconds.Text = AngleDegMinSec.Seconds

    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the Area of Use list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in AreasOfUseList

        If CurrentRecordNo = Main.AreaOfUse.NRecords Then
            'Already at the last record.
            Exit Sub
        End If

        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in AreasOfUseList

        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If

        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the Area of Use list:
        CurrentRecordNo = Main.AreaOfUse.NRecords
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the Area of Use list.

        Dim AouListFileName As String = Trim(txtAouListFileName.Text)

        If AouListFileName = "" Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Please enter a file name for the Area of Use list!" & vbCrLf)
            Exit Sub
        End If

        If AouListFileName.EndsWith(".AouList") Then
            'Main.Message.SetNormalStyle()
            'Main.Message.Add("Area of use list file name = " & AouListFileName & vbCrLf)
            Main.AreaOfUse.ListFileName = AouListFileName
        Else
            'Main.Message.SetNormalStyle()
            'Main.Message.Add("Area of use list file name = " & AouListFileName & vbCrLf)
            'Main.Message.Add(".AouList file extension will be added " & vbCrLf)
            AouListFileName &= ".AouList"
            Main.AreaOfUse.ListFileName = AouListFileName
            txtAouListFileName.Text = AouListFileName
            'Main.Message.Add("New file name = " & AouListFileName & vbCrLf)
        End If

        Main.Project.SaveXmlData(AouListFileName, Main.AreaOfUse.ToXDoc())
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Find an Area of Use list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select an Area of Use list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Areas Of Use List | *.AouList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtAouListFileName.Text = DataFileName
                    Main.AreaOfUse.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.AreaOfUse.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.AreaOfUse.NRecords
                    txtRecordNo.Text = 1
                    DisplayListData(1)
                End If

            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                'Select an Area of Use list file from the project archive:

        End Select

    End Sub

    Private Sub txtRecordNo_TextChanged(sender As Object, e As EventArgs) Handles txtRecordNo.TextChanged
        Dim NewRecordNo As Integer
        NewRecordNo = Int(Val(txtRecordNo.Text))

        If NewRecordNo < 1 Then
            Exit Sub
        End If

        If NewRecordNo > Main.AreaOfUse.NRecords Then
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
        FoundIndex = Main.AreaOfUse.List.FindIndex(Function(x) x.Name.Contains(SearchString))
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
        FoundIndex = Main.AreaOfUse.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.AreaOfUse.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
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


  
   
  
  
End Class