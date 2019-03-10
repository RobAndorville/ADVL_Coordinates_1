Public Class frmCompoundCRS
    'The Compound Coordinate Reference System form is used to view, create or edit Compound CRS parameters.

#Region " Variable Declarations - All the variables used in this form and this application." '-------------------------------------------------------------------------------------------------

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

#Region " Form Display Methods - Code used to display this form." '----------------------------------------------------------------------------------------------------------------------------

    Private Sub frmCompoundCRS_Load(sender As Object, e As EventArgs) Handles Me.Load
        RestoreFormSettings()   'Restore the form settings

        Main.AreaOfUse.AddUser()
        Main.CompoundCRS.AddUser()

        UpdateList()
        txtNRecords.Text = Main.CompoundCRS.NRecords
        txtCompoundCRSListFileName.Text = Main.CompoundCRS.ListFileName
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Form
        Main.AreaOfUse.RemoveUser()
        Main.CompoundCRS.RemoveUser()

        Me.Close() 'Close the form
    End Sub

    Private Sub frmCompoundCRS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If WindowState = FormWindowState.Normal Then
            SaveFormSettings()
        Else
            'Dont save settings is form is minimised.
        End If
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the Compound CRS list.

        Dim CompoundCRSListFileName As String = Trim(txtCompoundCRSListFileName.Text)

        If CompoundCRSListFileName = "" Then
            Main.Message.AddWarning("Please enter a file name for the Compound CRS list!" & vbCrLf)
            Exit Sub
        End If

        If CompoundCRSListFileName.EndsWith(".CompoundCRSList") Then
            'CompoundCRSListFileName has correct file extension.
            Main.CompoundCRS.ListFileName = CompoundCRSListFileName
        Else
            'Add file extension to the file name.
            CompoundCRSListFileName &= ".CompoundCRSList"
            Main.CompoundCRS.ListFileName = CompoundCRSListFileName
            txtCompoundCRSListFileName.Text = CompoundCRSListFileName
        End If
        Main.Project.SaveXmlData(CompoundCRSListFileName, Main.CompoundCRS.ToXDoc())
    End Sub

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the Compound CRS list from the EPSG database.
        Main.CompoundCRS.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.CompoundCRS.NRecords
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub UpdateList()
        'Update the list of records in ListBox1
        ListBox1.Items.Clear()
        Dim Index As Integer
        For Index = 0 To Main.CompoundCRS.NRecords - 1
            ListBox1.Items.Add(Main.CompoundCRS.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the Compound CRS list.

        If RecordNo < 1 Then
            Main.Message.AddWarning("Cannot display CRS data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.CompoundCRS.NRecords Then
            Main.Message.AddWarning("Cannot display CRS data. Selected record number is too large." & vbCrLf)
            Main.Message.AddWarning("RecordNo = " & RecordNo & "   Main.CompoundCRS.NRecords = " & Main.CompoundCRS.NRecords & vbCrLf)
            Exit Sub
        End If

        txtCRSName.Text = Main.CompoundCRS.List(RecordNo - 1).Name
        txtCRSName2.Text = Main.CompoundCRS.List(RecordNo - 1).Name
        txtCrsAuthor.Text = Main.CompoundCRS.List(RecordNo - 1).Author
        txtCrsCode.Text = Main.CompoundCRS.List(RecordNo - 1).Code
        txtCrsDeprecated.Text = Main.CompoundCRS.List(RecordNo - 1).Deprecated

        'Update the list of alias names:
        cmbCRSAliasNames.Items.Clear()
        cmbCRSAliasNames.Text = ""
        For Each item As String In Main.CompoundCRS.List(RecordNo - 1).AliasName
            cmbCRSAliasNames.Items.Add(item)
        Next

        If cmbCRSAliasNames.Items.Count > 0 Then
            cmbCRSAliasNames.SelectedIndex = 0 'Select first item
        End If

        txtCrsScope.Text = Main.CompoundCRS.List(RecordNo - 1).Scope
        txtCrsComments.Text = Main.CompoundCRS.List(RecordNo - 1).Comments

        'Display Area Of Use data:
        txtAOUName.Text = Main.CompoundCRS.List(RecordNo - 1).Area.Name
        DisplayAOUData(Main.CompoundCRS.List(RecordNo - 1).Area.Author, Main.CompoundCRS.List(RecordNo - 1).Area.Code)

        txtHorCRSName.Text = Main.CompoundCRS.List(RecordNo - 1).HorizontalCRS.Name
        txtHorCRSType.Text = Main.CompoundCRS.List(RecordNo - 1).HorizontalCRS.Type.ToString

        txtVertCRSName.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.Name

        'Display Horizontal CRS Info:
        txtHorCRSName2.Text = Main.CompoundCRS.List(RecordNo - 1).HorizontalCRS.Name
        txtHorCRSType2.Text = Main.CompoundCRS.List(RecordNo - 1).HorizontalCRS.Type.ToString
        txtHorCRSAuthor.Text = Main.CompoundCRS.List(RecordNo - 1).HorizontalCRS.Author
        txtHorCRSCode.Text = Main.CompoundCRS.List(RecordNo - 1).HorizontalCRS.Code
        txtHorCRSDeprecated.Text = Main.CompoundCRS.List(RecordNo - 1).HorizontalCRS.Deprecated
        txtHorCRSScope.Text = Main.CompoundCRS.List(RecordNo - 1).HorizontalCRS.Scope
        'Update the list of alias names:
        cmbHorCRSAliasNames.Items.Clear()
        cmbHorCRSAliasNames.Text = ""
        For Each item As String In Main.CompoundCRS.List(RecordNo - 1).HorizontalCRS.AliasName
            cmbHorCRSAliasNames.Items.Add(item)
        Next

        If cmbHorCRSAliasNames.Items.Count > 0 Then
            cmbHorCRSAliasNames.SelectedIndex = 0 'Select first item
        End If
        txtHorCSName.Text = Main.CompoundCRS.List(RecordNo - 1).HorizontalCRS.CoordinateSystem.Name
        txtHorCSAuthor.Text = Main.CompoundCRS.List(RecordNo - 1).HorizontalCRS.CoordinateSystem.Author
        txtHorCSCode.Text = Main.CompoundCRS.List(RecordNo - 1).HorizontalCRS.CoordinateSystem.Code
        txtHorCSType.Text = Main.CompoundCRS.List(RecordNo - 1).HorizontalCRS.CoordinateSystem.Type.ToString
        txtHorCRSComments.Text = Main.CompoundCRS.List(RecordNo - 1).HorizontalCRS.Comments


        'Display Horizontal CRS Info:
        txtVertCRSName2.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.Name
        txtVertCRSAuthor.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.Author
        txtVertCRSCode.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.Code
        txtVertCRSDeprecated.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.Deprecated
        txtVertCRSScope.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.Scope
        'Update the list of alias names:
        cmbVertCRSAliasNames.Items.Clear()
        cmbVertCRSAliasNames.Text = ""
        For Each item As String In Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.AliasName
            cmbVertCRSAliasNames.Items.Add(item)
        Next

        If cmbVertCRSAliasNames.Items.Count > 0 Then
            cmbVertCRSAliasNames.SelectedIndex = 0 'Select first item
        End If

        txtVertCSName.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.CoordinateSystem.Name
        txtVertCSAuthor.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.CoordinateSystem.Author
        txtVertCSCode.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.CoordinateSystem.Code
        txtVertCSType.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.CoordinateSystem.Type

        txtVertCRSDatumName.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.Datum.Name
        txtVertCRSDatumAuthor.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.Datum.Author
        txtVertCRSDatumCode.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.Datum.Code
        txtVertCRSDatumType.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.Datum.Type

        txtVertCRSComments.Text = Main.CompoundCRS.List(RecordNo - 1).VerticalCRS.Comments


    End Sub

    Private Sub DisplayAOUData(ByVal Author As String, ByVal Code As Integer)
        'Display the Area Of Use parameters corresponding to the Author and Code.

        If Main.AreaOfUse.List.Count = 0 Then
            'There is no Are Of Use data.
            Main.Message.AddWarning("There is no Area Of Use data!" & vbCrLf)
        Else
            Dim AreaMatch = From Area In Main.AreaOfUse.List Where Area.Author = Author And Area.Code = Code

            If AreaMatch.Count > 0 Then
                txtAreaOfUseName.Text = AreaMatch(0).Name
                txtAreaOfUseAuthor.Text = AreaMatch(0).Author
                txtAreaOfUseCode.Text = AreaMatch(0).Code
                txtAreaOfUseDeprecated.Text = AreaMatch(0).Deprecated

                cmbAreaAliasNames.Items.Clear()
                For Each item As String In AreaMatch(0).AliasName
                    cmbAreaAliasNames.Items.Add(item)
                Next
                If cmbAreaAliasNames.Items.Count > 0 Then
                    cmbAreaAliasNames.SelectedIndex = 0 'Select first item.
                End If

                txtAreaComments.Text = AreaMatch(0).Comments
                txtIso2CharCode.Text = AreaMatch(0).IsoA2Code
                txtIso3CharCode.Text = AreaMatch(0).IsoA3Code
                txtIsoNumericCode.Text = AreaMatch(0).IsoNCode

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

                If AreaMatch.Count > 1 Then
                    Main.Message.AddWarning("More than one Area Of Use found! " & Str(AreaMatch.Count) & " matches found for Author = " & Author & " and Code = " & Str(Code) & vbCrLf)
                End If
            Else
                Main.Message.AddWarning("No Area Of Use found for Author = " & Author & " and Code = " & Str(Code) & vbCrLf)
            End If
        End If
    End Sub

    Private Sub btnNameFind_Click(sender As Object, e As EventArgs) Handles btnNameFind.Click
        'Find the first record with specified text contained within the Name field.
        FindRecord(txtSearchText.Text)
    End Sub

    Private Sub FindRecord(ByVal SearchString As String)
        'Find a record using the SearchString to match the Name field
        Dim FoundIndex As Integer
        FoundIndex = Main.CompoundCRS.List.FindIndex(Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.CompoundCRS.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
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
        FoundIndex = Main.CompoundCRS.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
        If FoundIndex = -1 Then
            Main.Message.Add("String not found." & vbCrLf)
        Else
            CurrentRecordNo = FoundIndex + 1
        End If
    End Sub

    Private Sub txtRecordNo_TextChanged(sender As Object, e As EventArgs) Handles txtRecordNo.TextChanged
        Dim NewRecordNo As Integer
        NewRecordNo = Int(Val(txtRecordNo.Text))

        If NewRecordNo < 1 Then
            Exit Sub
        End If

        If NewRecordNo > Main.CompoundCRS.NRecords Then
            Exit Sub
        End If

        _currentRecordNo = NewRecordNo
        If ListBox1.Items.Count >= _currentRecordNo Then
            ListBox1.SelectedIndex = _currentRecordNo - 1
        End If
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the Engineering CRS list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in Vertical CRS List
        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in Vertical CRS List
        If CurrentRecordNo = Main.CompoundCRS.NRecords Then
            'Already at the last record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the Vertical 2D CRS list:
        CurrentRecordNo = Main.CompoundCRS.NRecords
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Find a Engineering CRS list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select a Compound CRS list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Compound CRS List | *.CompoundCRSList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtCompoundCRSListFileName.Text = DataFileName
                    Main.CompoundCRS.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.CompoundCRS.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.CompoundCRS.NRecords
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
                Zip.SelectFileForm.FileExtension = ".CompoundCRSList"
                Zip.SelectFileForm.GetFileList()
        End Select
    End Sub

    Private Sub Zip_FileSelected(FileName As String) Handles Zip.FileSelected
        txtCompoundCRSListFileName.Text = FileName
        Main.CompoundCRS.ListFileName = FileName
        Dim XmlDoc As System.Xml.Linq.XDocument
        Main.Project.DataLocn.ReadXmlData(FileName, XmlDoc)
        Main.CompoundCRS.LoadXml(XmlDoc)
        UpdateList()
        txtNRecords.Text = Main.CompoundCRS.NRecords
        txtRecordNo.Text = 1
        DisplayListData(1)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim Index As Integer
        Index = ListBox1.SelectedIndex + 1
        CurrentRecordNo = Index
        DisplayListData(Index)
    End Sub


#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Events - Events that can be triggered by this form." '--------------------------------------------------------------------------------------------------------------------------
#End Region 'Form Events ----------------------------------------------------------------------------------------------------------------------------------------------------------------------

  
  
End Class