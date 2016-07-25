Public Class frmCoordOpMethods
    'The CoordOpMethods form is used to view, create or edit Coordinate Operation Methods parameters.


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

#End Region 'Properties -------------------------------------------------------------------------------------Formsettings----------------------------------------------------------------------------------

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

    Private Sub frmCoordOpMethods_Load(sender As Object, e As EventArgs) Handles Me.Load

        RestoreFormSettings()

        DataGridView1.ColumnCount = 4
        DataGridView1.Columns(0).HeaderText = "Parameter Name"
        DataGridView1.Columns(1).HeaderText = "Sort Order"
        DataGridView1.Columns(2).HeaderText = "Sign Reversal"
        DataGridView1.Columns(3).HeaderText = "Description"
        DataGridView1.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridView1.AutoResizeColumns()

        Main.CoordOpMethod.AddUser()
        UpdateList()
        txtNRecords.Text = Main.CoordOpMethod.NRecords
        txtCoordOpMethodListFileName.Text = Main.CoordOpMethod.ListFileName
        CurrentRecordNo = 1
        DisplayListData(1)


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the form
        Main.CoordOpMethod.RemoveUser()
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub UpdateList()
        'Update the list of Coordinate Operation Methods in ListBox1
        ListBox1.Items.Clear()
        Dim Index As Integer
        For Index = 0 To Main.CoordOpMethod.NRecords - 1
            ListBox1.Items.Add(Main.CoordOpMethod.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the CoordOpMethod list.

        If RecordNo < 1 Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Coordinate Operation Method data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.CoordOpMethod.NRecords Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Coordinate Operation Method data. Selected record number is too large." & vbCrLf)
            Exit Sub
        End If

        txtMethodName.Text = Main.CoordOpMethod.List(RecordNo - 1).Name
        txtMethodName2.Text = Main.CoordOpMethod.List(RecordNo - 1).Name
        txtAuthor.Text = Main.CoordOpMethod.List(RecordNo - 1).Author
        txtCode.Text = Main.CoordOpMethod.List(RecordNo - 1).Code
        txtDeprecated.Text = Main.CoordOpMethod.List(RecordNo - 1).Deprecated
        txtReversable.Text = Main.CoordOpMethod.List(RecordNo - 1).ReverseOp
        txtComments.Text = Main.CoordOpMethod.List(RecordNo - 1).Comments
        rtbFormula.Text = Main.CoordOpMethod.List(RecordNo - 1).Formula
        rtbExample.Text = Main.CoordOpMethod.List(RecordNo - 1).Example

        'Display parameters:
        Dim NParameters As Integer = Main.CoordOpMethod.List(RecordNo - 1).Parameter.Count

        If NParameters > 0 Then
            DataGridView1.RowCount = NParameters
            Dim RowNo As Integer
            For RowNo = 0 To NParameters - 1
                DataGridView1.Rows(RowNo).Cells(0).Value = Main.CoordOpMethod.List(RecordNo - 1).Parameter(RowNo).Name
                DataGridView1.Rows(RowNo).Cells(1).Value = Main.CoordOpMethod.List(RecordNo - 1).Parameter(RowNo).Order
                DataGridView1.Rows(RowNo).Cells(2).Value = Main.CoordOpMethod.List(RecordNo - 1).Parameter(RowNo).SignReversal
                DataGridView1.Rows(RowNo).Cells(3).Value = Main.CoordOpMethod.List(RecordNo - 1).Parameter(RowNo).Description
            Next
            DataGridView1.Columns(0).Width = 280
            DataGridView1.Columns(1).Width = 60
            DataGridView1.Columns(2).Width = 60
            DataGridView1.AutoResizeRows()
        Else
            DataGridView1.RowCount = 1
        End If



    End Sub

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the CoordOpMethod list from the EPSG database.
        Main.CoordOpMethod.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.CoordOpMethod.NRecords
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the CoordOpMethods list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in CoordOpMethods list.
        If CurrentRecordNo = Main.CoordOpMethod.NRecords Then
            'Already at the last record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in CoordOpMethods list.
        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the CoordOpMethods list:
        CurrentRecordNo = Main.CoordOpMethod.NRecords
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub DataGridView1_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnWidthChanged

        Dim DGVerticalScroll = DataGridView1.Controls.OfType(Of VScrollBar).SingleOrDefault.Visible

        If DGVerticalScroll Then
            DataGridView1.Columns(3).Width = DataGridView1.Width - DataGridView1.Columns(0).Width - DataGridView1.Columns(1).Width - DataGridView1.Columns(2).Width - DataGridView1.RowHeadersWidth - 20
        Else
            DataGridView1.Columns(3).Width = DataGridView1.Width - DataGridView1.Columns(0).Width - DataGridView1.Columns(1).Width - DataGridView1.Columns(2).Width - DataGridView1.RowHeadersWidth - 2
        End If

    End Sub

    Private Sub DataGridView1_Resize(sender As Object, e As EventArgs) Handles DataGridView1.Resize

        If DataGridView1.Columns.Count > 3 Then
            Dim DGVerticalScroll = DataGridView1.Controls.OfType(Of VScrollBar).SingleOrDefault.Visible

            If DGVerticalScroll Then
                DataGridView1.Columns(3).Width = DataGridView1.Width - DataGridView1.Columns(0).Width - DataGridView1.Columns(1).Width - DataGridView1.Columns(2).Width - DataGridView1.RowHeadersWidth - 20
            Else
                DataGridView1.Columns(3).Width = DataGridView1.Width - DataGridView1.Columns(0).Width - DataGridView1.Columns(1).Width - DataGridView1.Columns(2).Width - DataGridView1.RowHeadersWidth - 2
            End If
        Else
            'DataGridView1 has not been configured with 4 columns yet.
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the Ellipsoid list.

        Dim CoordOpMethodListFileName As String = Trim(txtCoordOpMethodListFileName.Text)

        If CoordOpMethodListFileName = "" Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Please enter a file name for the Coordinate Operation Method list!" & vbCrLf)
            Exit Sub
        End If

        If CoordOpMethodListFileName.EndsWith(".CoordOpMethodList") Then
            'CoordOpMethodListFileName has correct file extension.
            Main.CoordOpMethod.ListFileName = CoordOpMethodListFileName
        Else
            'Add file extension to the file name.
            CoordOpMethodListFileName &= ".CoordOpMethodList"
            Main.CoordOpMethod.ListFileName = CoordOpMethodListFileName
            txtCoordOpMethodListFileName.Text = CoordOpMethodListFileName
        End If

        Main.Project.SaveXmlData(CoordOpMethodListFileName, Main.CoordOpMethod.ToXDoc())
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Find an Ellipsoid list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select an Coordinate Operation Method list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Coordinate Operation Method List | *.CoordOpMethodList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtCoordOpMethodListFileName.Text = DataFileName
                    Main.CoordOpMethod.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.CoordOpMethod.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.CoordOpMethod.NRecords
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

        If NewRecordNo > Main.CoordOpMethod.NRecords Then
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
        FoundIndex = Main.CoordOpMethod.List.FindIndex(Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.CoordOpMethod.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
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
        FoundIndex = Main.CoordOpMethod.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
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