Public Class frmUnitsOfMeasure
    'The Unit Of Measure form is used to view, create or edit unit of measure parameters.

#Region " Variable Declarations - All the variables used in this form." '----------------------------------------------------------------------------------------------------------------------

    Dim WithEvents Zip As ADVL_Utilities_Library_1.ZipComp

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


#Region " Form Subroutines - Code used to display this form." '--------------------------------------------------------------------------------------------------------------------------------

    Private Sub frmUnitOfMeasure_Load(sender As Object, e As EventArgs) Handles Me.Load

        RestoreFormSettings()

        cmbType.Items.Add("Angle")
        cmbType.Items.Add("Length")
        cmbType.Items.Add("Time")
        cmbType.Items.Add("Scale")

        If Main.UnitOfMeasure.ListFileName = "" Then
            txtUOMListFileName.Text = ""
            'No UnitOfMeasure list has been selected.
        Else
            If Main.UnitOfMeasure.NRecords = 0 Then
                'Load records from the selected UnitOfMeasure file:
                Dim XmlDoc As System.Xml.Linq.XDocument
                Main.Project.DataLocn.ReadXmlData(Main.UnitOfMeasure.ListFileName, XmlDoc)
                Main.UnitOfMeasure.LoadXml(XmlDoc)
                UpdateList()
                Main.UnitOfMeasure.AddUser()
                txtNRecords.Text = Main.UnitOfMeasure.NRecords
                txtUOMListFileName.Text = Main.UnitOfMeasure.ListFileName
                CurrentRecordNo = 1
                DisplayListData(1)
            Else
                'Records have already been loaded.
                UpdateList()
                Main.UnitOfMeasure.AddUser()
                txtNRecords.Text = Main.UnitOfMeasure.NRecords
                txtUOMListFileName.Text = Main.UnitOfMeasure.ListFileName
                CurrentRecordNo = 1
                DisplayListData(1)
            End If
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the form
        Main.UnitOfMeasure.RemoveUser()
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Subroutines -----------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the Unit of Measure list from the EPSG database.
        Main.UnitOfMeasure.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.UnitOfMeasure.NRecords
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub UpdateList()
        'Update the list of records in ListBox1
        ListBox1.Items.Clear()
        Dim Index As Integer
        For Index = 0 To Main.UnitOfMeasure.NRecords - 1
            ListBox1.Items.Add(Main.UnitOfMeasure.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the UnitOfMeasure list.

        If RecordNo < 1 Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Area Of Use data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.UnitOfMeasure.NRecords Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Area Of Use data. Selected record number is too large." & vbCrLf)
            Exit Sub
        End If

        txtUnitName.Text = Main.UnitOfMeasure.List(RecordNo - 1).Name
        txtAuthor.Text = Main.UnitOfMeasure.List(RecordNo - 1).Author
        txtUomCode.Text = Main.UnitOfMeasure.List(RecordNo - 1).Code
        txtDeprecated.Text = Main.UnitOfMeasure.List(RecordNo - 1).Deprecated

        'Update the list of alias names:
        cmbAliasNames.Items.Clear()
        cmbAliasNames.Text = ""
        For Each item As String In Main.UnitOfMeasure.List(RecordNo - 1).AliasName
            cmbAliasNames.Items.Add(item)
        Next

        If cmbAliasNames.Items.Count > 0 Then
            cmbAliasNames.SelectedIndex = 0 'Select first item
        End If

        txtComments.Text = Main.UnitOfMeasure.List(RecordNo - 1).Comments

        Select Case Main.UnitOfMeasure.List(RecordNo - 1).Type
            Case ADVL_Coordinates_Library_1.UnitOfMeasure.UOMTypes.Angle
                For Each item In cmbType.Items
                    If item.ToString = "Angle" Then
                        cmbType.SelectedItem = item
                        Exit For
                    End If
                Next
            Case ADVL_Coordinates_Library_1.UnitOfMeasure.UOMTypes.Length
                For Each item In cmbType.Items
                    If item.ToString = "Length" Then
                        cmbType.SelectedItem = item
                        Exit For
                    End If
                Next
            Case ADVL_Coordinates_Library_1.UnitOfMeasure.UOMTypes.Scale
                For Each item In cmbType.Items
                    If item.ToString = "Scale" Then
                        cmbType.SelectedItem = item
                        Exit For
                    End If
                Next
            Case ADVL_Coordinates_Library_1.UnitOfMeasure.UOMTypes.Time
                For Each item In cmbType.Items
                    If item.ToString = "Time" Then
                        cmbType.SelectedItem = item
                        Exit For
                    End If
                Next
        End Select

        txtStandardUOM.Text = Main.UnitOfMeasure.List(RecordNo - 1).StandardUnitName
        txtFactorB.Text = Main.UnitOfMeasure.List(RecordNo - 1).FactorB
        txtFactorC.Text = Main.UnitOfMeasure.List(RecordNo - 1).FactorC

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the Unit of Measure list.

        Dim UomListFileName As String = Trim(txtUOMListFileName.Text)

        If UomListFileName = "" Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Please enter a file name for the Unit of Measure list!" & vbCrLf)
            Exit Sub
        End If

        If UomListFileName.EndsWith(".UomList") Then
            'UomListFileName has correct file extension.
            Main.UnitOfMeasure.ListFileName = UomListFileName
        Else
            'Add file extension to the file name.
            UomListFileName &= ".UomList"
            Main.UnitOfMeasure.ListFileName = UomListFileName
            txtUOMListFileName.Text = UomListFileName
        End If

        Main.Project.SaveXmlData(UomListFileName, Main.UnitOfMeasure.ToXDoc())
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Find a Unit of Measure list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select an Area of Use list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Unit of Measure List | *.UomList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtUOMListFileName.Text = DataFileName
                    Main.UnitOfMeasure.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.UnitOfMeasure.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.UnitOfMeasure.NRecords
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
                Zip.SelectFileForm.FileExtension = ".UomList"
                Zip.SelectFileForm.GetFileList()
        End Select

    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the UnitOfMeasure list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in UnitOfMeasure List

        If CurrentRecordNo = Main.UnitOfMeasure.NRecords Then
            'Already at the last record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in UnitOfMeasureList
        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the UnitOfMeasure list:
        CurrentRecordNo = Main.UnitOfMeasure.NRecords
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub txtRecordNo_TextChanged(sender As Object, e As EventArgs) Handles txtRecordNo.TextChanged
        Dim NewRecordNo As Integer
        NewRecordNo = Int(Val(txtRecordNo.Text))
        If NewRecordNo < 1 Then
            Exit Sub
        End If
        If NewRecordNo > Main.UnitOfMeasure.NRecords Then
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
        FoundIndex = Main.UnitOfMeasure.List.FindIndex(Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.UnitOfMeasure.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
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
        FoundIndex = Main.UnitOfMeasure.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
        If FoundIndex = -1 Then
            Main.Message.Add("String not found." & vbCrLf)
        Else
            CurrentRecordNo = FoundIndex + 1
        End If
    End Sub


#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------


  
  
 
  
   
  
End Class