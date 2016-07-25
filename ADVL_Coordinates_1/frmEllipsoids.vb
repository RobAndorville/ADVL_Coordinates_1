Public Class frmEllipsoids
    'The Ellipsoid form is used to view, create or edit Ellipsoid parameters.


#Region " Variable Declarations - All the variables used in this form and this application." '-------------------------------------------------------------------------------------------------
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

    Private Sub frmEllipsoid_Load(sender As Object, e As EventArgs) Handles Me.Load

        RestoreFormSettings()

        'If Main.Ellipsoid.ListFileName = "" Then
        '    txtEllipsoidListFileName.Text = ""
        '    'No Ellipsoid list has been selected.
        'Else
        '    If Main.Ellipsoid.NRecords = 0 Then
        '        'Load records from the selected UnitOfMeasure file:
        '        Dim XmlDoc As System.Xml.Linq.XDocument
        '        Main.Project.DataLocn.ReadXmlData(Main.Ellipsoid.ListFileName, XmlDoc)
        '        Main.Ellipsoid.LoadXml(XmlDoc)
        '        UpdateList()
        '        Main.Ellipsoid.AddUser()
        '        txtNRecords.Text = Main.Ellipsoid.NRecords
        '        txtEllipsoidListFileName.Text = Main.Ellipsoid.ListFileName
        '        CurrentRecordNo = 1
        '        DisplayListData(1)
        '    Else
        '        'Records have already been loaded.
        '        UpdateList()
        '        Main.Ellipsoid.AddUser()
        '        txtNRecords.Text = Main.Ellipsoid.NRecords
        '        txtEllipsoidListFileName.Text = Main.Ellipsoid.ListFileName
        '        CurrentRecordNo = 1
        '        DisplayListData(1)
        '    End If
        'End If

        Main.Ellipsoid.AddUser()
        UpdateList()
        txtNRecords.Text = Main.Ellipsoid.NRecords
        txtEllipsoidListFileName.Text = Main.Ellipsoid.ListFileName
        CurrentRecordNo = 1
        DisplayListData(1)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the form
        Main.Ellipsoid.RemoveUser()
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the Ellipsoid list from the EPSG database.
        Main.Ellipsoid.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.Ellipsoid.NRecords
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub UpdateList()
        'Update the list of records in ListBox1
        ListBox1.Items.Clear()
        Dim Index As Integer
        For Index = 0 To Main.Ellipsoid.NRecords - 1
            ListBox1.Items.Add(Main.Ellipsoid.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the Ellipsoid list.

        If RecordNo < 1 Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Area Of Use data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.Ellipsoid.NRecords Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Area Of Use data. Selected record number is too large." & vbCrLf)
            Exit Sub
        End If

        txtEllipsoidName.Text = Main.Ellipsoid.List(RecordNo - 1).Name
        txtEllipsoidAuthor.Text = Main.Ellipsoid.List(RecordNo - 1).Author
        txtEllipsoidCode.Text = Main.Ellipsoid.List(RecordNo - 1).Code
        txtEllipsoidDeprecated.Text = Main.Ellipsoid.List(RecordNo - 1).Deprecated


        'Update the list of alias names:
        cmbAliasNames.Items.Clear()
        cmbAliasNames.Text = ""
        For Each item As String In Main.Ellipsoid.List(RecordNo - 1).AliasName
            cmbAliasNames.Items.Add(item)
        Next
        If cmbAliasNames.Items.Count > 0 Then
            cmbAliasNames.SelectedIndex = 0 'Select first item
        End If

        txtComments.Text = Main.Ellipsoid.List(RecordNo - 1).Comments

        If Main.Ellipsoid.List(RecordNo - 1).EllipsoidParameters = ADVL_Coordinates_Library_1.Ellipsoid.DefiningParameters.SemiMajorAxis_InverseFlattening Then
            rbSemiMajorAndInverseFlat.Checked = True
        Else
            rbSemiMajorAndSemiMinor.Checked = True
        End If

        txtSemiMajorAxis.Text = Main.Ellipsoid.List(RecordNo - 1).SemiMajorAxis
        txtInverseFlattening.Text = Main.Ellipsoid.List(RecordNo - 1).InverseFlattening
        txtSemiMinorAxis.Text = Main.Ellipsoid.List(RecordNo - 1).SemiMinorAxis
        txtAxisUnits.Text = Main.Ellipsoid.List(RecordNo - 1).Unit.Name

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the Ellipsoid list.

        Dim EllipsoidListFileName As String = Trim(txtEllipsoidListFileName.Text)

        If EllipsoidListFileName = "" Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Please enter a file name for the Ellipsoid list!" & vbCrLf)
            Exit Sub
        End If

        If EllipsoidListFileName.EndsWith(".EllipsoidList") Then
            'EllipsoidListFileName has correct file extension.
            Main.Ellipsoid.ListFileName = EllipsoidListFileName
        Else
            'Add file extension to the file name.
            EllipsoidListFileName &= ".EllipsoidList"
            Main.Ellipsoid.ListFileName = EllipsoidListFileName
            txtEllipsoidListFileName.Text = EllipsoidListFileName
        End If
        Main.Project.SaveXmlData(EllipsoidListFileName, Main.Ellipsoid.ToXDoc())
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the Ellipsoid list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in Ellipsoid List
        If CurrentRecordNo = Main.Ellipsoid.NRecords Then
            'Already at the last record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in Ellipsoid List
        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the Ellipsoid list:
        CurrentRecordNo = Main.Ellipsoid.NRecords
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub txtRecordNo_TextChanged(sender As Object, e As EventArgs) Handles txtRecordNo.TextChanged
        Dim NewRecordNo As Integer
        NewRecordNo = Int(Val(txtRecordNo.Text))

        If NewRecordNo < 1 Then
            Exit Sub
        End If

        If NewRecordNo > Main.Ellipsoid.NRecords Then
            Exit Sub
        End If

        _currentRecordNo = NewRecordNo
        If ListBox1.Items.Count >= _currentRecordNo Then
            ListBox1.SelectedIndex = _currentRecordNo - 1
        End If
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Find an Ellipsoid list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select an Ellipsoid list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Ellipsoid List | *.EllipsoidList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtEllipsoidListFileName.Text = DataFileName
                    Main.Ellipsoid.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.Ellipsoid.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.Ellipsoid.NRecords
                    txtRecordNo.Text = 1
                    DisplayListData(1)
                End If

            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                'Select an Area of Use list file from the project archive:

        End Select
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
        FoundIndex = Main.Ellipsoid.List.FindIndex(Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.Ellipsoid.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
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
        FoundIndex = Main.Ellipsoid.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
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