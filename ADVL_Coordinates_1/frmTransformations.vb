Public Class frmTransformations
    'The Transformations form is used to display coordinate transformation parameters.



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

    Private Sub frmTransformations_Load(sender As Object, e As EventArgs) Handles Me.Load

        RestoreFormSettings()

        DataGridView1.ColumnCount = 3
        DataGridView1.Columns(0).HeaderText = "Name"
        DataGridView1.Columns(1).HeaderText = "Value"
        DataGridView1.Columns(2).HeaderText = "Unit of Measure"
        DataGridView1.AutoResizeColumns()

        'Main.Transformation.AddUser()

        'Show the Transformation list:
        If Main.Transformation.ListFileName = "" Then
            'No Transformation list has been selected.
        Else
            If Main.Transformation.NRecords = 0 Then
                'Load records from the selected Transformation file:
                Dim XmlDoc As System.Xml.Linq.XDocument
                Main.Project.DataLocn.ReadXmlData(Main.Transformation.ListFileName, XmlDoc)
                Main.Transformation.LoadXml(XmlDoc)
                UpdateList()
                Main.Transformation.AddUser()
                txtNRecords.Text = Main.Transformation.NRecords
                txtTransformationListFileName.Text = Main.Transformation.ListFileName
                'txtRecordNo.Text = 1
                CurrentRecordNo = 1
                DisplayListData(1)
            Else
                'Records have already been loaded.
                UpdateList()
                Main.Transformation.AddUser()
                txtNRecords.Text = Main.Transformation.NRecords
                txtTransformationListFileName.Text = Main.Transformation.ListFileName
                CurrentRecordNo = 1
                DisplayListData(1)
            End If
        End If


    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the form
        Main.Transformation.RemoveUser()
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the Transformation list from the EPSG database.
        Main.Transformation.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.Transformation.NRecords
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub UpdateList()
        'Update the list of records in ListBox1
        ListBox1.Items.Clear()
        Dim Index As Integer
        For Index = 0 To Main.Transformation.NRecords - 1
            ListBox1.Items.Add(Main.Transformation.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the Transformation list.

        If RecordNo < 1 Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Transformation data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.Transformation.NRecords Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Transformation data. Selected record number is too large." & vbCrLf)
            Exit Sub
        End If

        txtTransformationName.Text = Main.Transformation.List(RecordNo - 1).Name
        txtTransformationName2.Text = Main.Transformation.List(RecordNo - 1).Name
        txtAuthor.Text = Main.Transformation.List(RecordNo - 1).Author
        txtCode.Text = Main.Transformation.List(RecordNo - 1).Code
        txtDeprecated.Text = Main.Transformation.List(RecordNo - 1).Deprecated

        txtVersion.Text = Main.Transformation.List(RecordNo - 1).Version
        txtVariant.Text = Main.Transformation.List(RecordNo - 1).VariantNo
        txtAccuracy.Text = Main.Transformation.List(RecordNo - 1).Accuracy

        ''Update the list of alias names:
        'cmbAliasNames.Items.Clear()
        'cmbAliasNames.Text = ""
        'For Each item As String In Main.Projection.List(RecordNo - 1).AliasName
        '    cmbAliasNames.Items.Add(item)
        'Next

        'If cmbAliasNames.Items.Count > 0 Then
        '    cmbAliasNames.SelectedIndex = 0 'Select first item
        'End If

        txtComments.Text = Main.Transformation.List(RecordNo - 1).Comments

        txtScope.Text = Main.Transformation.List(RecordNo - 1).Scope
        txtArea.Text = Main.Transformation.List(RecordNo - 1).Area.Name
        txtSourceCRS.Text = Main.Transformation.List(RecordNo - 1).SourceCRS.Name
        txtTargetCRS.Text = Main.Transformation.List(RecordNo - 1).TargetCRS.Name
        txtMethod.Text = Main.Transformation.List(RecordNo - 1).Method.Name
        txtReverseOp.Text = Main.Transformation.List(RecordNo - 1).ReverseOp
        txtSourceCoordDiffUnit.Text = Main.Transformation.List(RecordNo - 1).SourceCoordDiffUnit.Name
        txtTargetCoordDiffUnit.Text = Main.Transformation.List(RecordNo - 1).TargetCoordDiffUnit.Name

        'Display Projection Parameters
        Dim NParameters As Integer = Main.Transformation.List(RecordNo - 1).ParameterValue.Count

        If NParameters > 0 Then
            DataGridView1.RowCount = NParameters
            Dim RowNo As Integer
            For RowNo = 0 To NParameters - 1
                DataGridView1.Rows(RowNo).Cells(0).Value = Main.Transformation.List(RecordNo - 1).ParameterValue(RowNo).Name
                DataGridView1.Rows(RowNo).Cells(1).Value = Main.Transformation.List(RecordNo - 1).ParameterValue(RowNo).Value
                DataGridView1.Rows(RowNo).Cells(2).Value = Main.Transformation.List(RecordNo - 1).ParameterValue(RowNo).Unit.Name
            Next
            'DataGridView1.AutoResizeColumns()
            DataGridView1.Columns(0).Width = 280
            DataGridView1.Columns(1).Width = 120
            DataGridView1.Columns(2).Width = 200
        Else
            DataGridView1.RowCount = 1
        End If

        'Display Area of Use Data: -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'DisplayAOUData(Main.Projection.List(RecordNo - 1).Area.Author, Main.Projection.List(RecordNo - 1).Area.Code)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the Transformation list.

        Dim TransformationListFileName As String = Trim(txtTransformationListFileName.Text)

        If TransformationListFileName = "" Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Please enter a file name for the Transformation list!" & vbCrLf)
            Exit Sub
        End If

        If TransformationListFileName.EndsWith(".TransformationList") Then
            'ProjectionListFileName has correct file extension.
            Main.Transformation.ListFileName = TransformationListFileName
        Else
            'Add file extension to the file name.
            TransformationListFileName &= ".TransformationList"
            Main.Transformation.ListFileName = TransformationListFileName
            txtTransformationListFileName.Text = TransformationListFileName
        End If

        Main.Project.SaveXmlData(TransformationListFileName, Main.Transformation.ToXDoc())
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the Transformation list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in Transformation List

        If CurrentRecordNo = Main.Transformation.NRecords Then
            'Already at the last record.
            Exit Sub
        End If

        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in Transformation List

        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If

        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the Transformation list:
        CurrentRecordNo = Main.Transformation.NRecords
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub txtRecordNo_TextChanged(sender As Object, e As EventArgs) Handles txtRecordNo.TextChanged
        Dim NewRecordNo As Integer
        NewRecordNo = Int(Val(txtRecordNo.Text))

        If NewRecordNo < 1 Then
            Exit Sub
        End If

        If NewRecordNo > Main.Transformation.NRecords Then
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
        'Find an Transformation list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select a Transformation list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Transformation List | *.TransformationList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtTransformationListFileName.Text = DataFileName
                    Main.Transformation.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.Transformation.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.Transformation.NRecords
                    txtRecordNo.Text = 1
                    DisplayListData(1)
                End If

            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                'Select an Area of Use list file from the project archive:

        End Select
    End Sub

    Private Sub btnNameFind_Click(sender As Object, e As EventArgs) Handles btnNameFind.Click
        'Find the first record with specified text contained within the Name field.
        FindRecord(txtSearchText.Text)
    End Sub

    Private Sub FindRecord(ByVal SearchString As String)
        'Find a record using the SearchString to match the Name field
        Dim FoundIndex As Integer
        FoundIndex = Main.Transformation.List.FindIndex(Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.Transformation.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
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
        FoundIndex = Main.Transformation.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
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