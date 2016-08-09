Public Class frmProjections
    'The Projections form is used to display map projection parameters.

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

    Private Sub frmProjections_Load(sender As Object, e As EventArgs) Handles Me.Load

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

        'Set up DataGridView1 to display projection parameter values:
        DataGridView1.ColumnCount = 3
        DataGridView1.Columns(0).HeaderText = "Name"
        DataGridView1.Columns(1).HeaderText = "Value"
        DataGridView1.Columns(2).HeaderText = "Unit of Measure"
        DataGridView1.AutoResizeColumns()

        'Set up DataGridView2 to display the projection parameter list:
        DataGridView2.ColumnCount = 4
        DataGridView2.Columns(0).HeaderText = "Parameter Name"
        DataGridView2.Columns(1).HeaderText = "Sort Order"
        DataGridView2.Columns(2).HeaderText = "Sign Reversal"
        DataGridView2.Columns(3).HeaderText = "Description"
        DataGridView2.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridView2.AutoResizeColumns()

        RestoreFormSettings()

        'Load the Area Of Use list:
        Main.AreaOfUse.AddUser()
     
        Main.Projection.AddUser()
        Main.CoordOpMethod.AddUser()


        UpdateList()
        txtNRecords.Text = Main.Projection.NRecords
        txtProjectionListFileName.Text = Main.Projection.ListFileName
        CurrentRecordNo = 1
        DisplayListData(1)


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the form
        Main.AreaOfUse.RemoveUser()
        Main.Projection.RemoveUser()
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the Projection list from the EPSG database.
        Main.Projection.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.Projection.NRecords
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub UpdateList()
        'Update the list of records in ListBox1
        ListBox1.Items.Clear()
        Dim Index As Integer
        For Index = 0 To Main.Projection.NRecords - 1
            ListBox1.Items.Add(Main.Projection.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the Projection list.

        If RecordNo < 1 Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Projection data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.Projection.NRecords Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Projection data. Selected record number is too large." & vbCrLf)
            Exit Sub
        End If

        txtProjectionName.Text = Main.Projection.List(RecordNo - 1).Name
        txtProjectionName2.Text = Main.Projection.List(RecordNo - 1).Name
        txtProjectionAuthor.Text = Main.Projection.List(RecordNo - 1).Author
        txtProjectionCode.Text = Main.Projection.List(RecordNo - 1).Code
        txtProjectionDeprecated.Text = Main.Projection.List(RecordNo - 1).Deprecated

        'Update the list of alias names:
        cmbAliasNames.Items.Clear()
        cmbAliasNames.Text = ""
        For Each item As String In Main.Projection.List(RecordNo - 1).AliasName
            cmbAliasNames.Items.Add(item)
        Next

        If cmbAliasNames.Items.Count > 0 Then
            cmbAliasNames.SelectedIndex = 0 'Select first item
        End If

        txtProjectionComments.Text = Main.Projection.List(RecordNo - 1).Comments

        txtProjectionScope.Text = Main.Projection.List(RecordNo - 1).Scope
        txtProjectionMethod.Text = Main.Projection.List(RecordNo - 1).Method.Name
        txtProjectionArea.Text = Main.Projection.List(RecordNo - 1).Area.Name

        'Display Projection Parameters
        Dim NParameters As Integer = Main.Projection.List(RecordNo - 1).ParameterValue.Count

        If NParameters > 0 Then
            DataGridView1.RowCount = NParameters
            Dim RowNo As Integer
            For RowNo = 0 To NParameters - 1
                DataGridView1.Rows(RowNo).Cells(0).Value = Main.Projection.List(RecordNo - 1).ParameterValue(RowNo).Name
                DataGridView1.Rows(RowNo).Cells(1).Value = Main.Projection.List(RecordNo - 1).ParameterValue(RowNo).Value
                DataGridView1.Rows(RowNo).Cells(2).Value = Main.Projection.List(RecordNo - 1).ParameterValue(RowNo).Unit.Name
            Next
            'DataGridView1.AutoResizeColumns()
            DataGridView1.Columns(0).Width = 280
            DataGridView1.Columns(1).Width = 120
            DataGridView1.Columns(2).Width = 200
        Else
            DataGridView1.RowCount = 1
        End If

        'Display Area of Use Data: -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        DisplayAOUData(Main.Projection.List(RecordNo - 1).Area.Author, Main.Projection.List(RecordNo - 1).Area.Code)

        'Display Method Data: ---------------------------------
        DisplayMethodData(Main.Projection.List(RecordNo - 1).Method.Author, Main.Projection.List(RecordNo - 1).Method.Code)

        'TEST CODE:
        'Testing FindIndex function in the AreaOfUse list:
        If Main.AreaOfUse.NRecords > 0 Then
            Dim Index As Integer = Main.AreaOfUse.FindIndex(Main.Projection.List(RecordNo - 1).Area.Author, Main.Projection.List(RecordNo - 1).Area.Code)
            Main.Message.Add("Area of Use index: " & Index & "  Name: " & Main.Projection.List(RecordNo - 1).Area.Name & vbCrLf)
            Main.Message.Add("Area of Use name: " & Main.AreaOfUse.List(Index).Name & vbCrLf)
        End If
      

    End Sub

    Private Sub DisplayAOUData(ByVal Author As String, ByVal Code As Integer)
        'Display the Area of Use record with the specified Author and Code.

        If Main.AreaOfUse.NRecords > 0 Then
            Dim AreaMatch = From Area In Main.AreaOfUse.List Where Area.Author = Author And Area.Code = Code

            If AreaMatch.Count > 0 Then
                txtAreaOfUseName.Text = AreaMatch(0).Name
                txtAouAuthor.Text = AreaMatch(0).Author
                txtAouCode.Text = AreaMatch(0).Code
                txtAouDeprecated.Text = AreaMatch(0).Deprecated

                cmbAouAliasNames.Items.Clear()
                For Each item As String In AreaMatch(0).AliasName
                    cmbAouAliasNames.Items.Add(item)
                Next
                If cmbAouAliasNames.Items.Count > 0 Then
                    cmbAouAliasNames.SelectedIndex = 0 'Select first item.
                End If

                txtAouComments.Text = AreaMatch(0).Comments
                txtIso2CharCode.Text = AreaMatch(0).IsoA2Code
                txtIso3CharCode.Text = AreaMatch(0).IsoA3Code
                txtIsoNumericCode.Text = AreaMatch(0).IsoNCode
                txtAreaOfUse.Text = AreaMatch(0).Description

                'Bounding coordinates are stored as decimal degrees referenced to the WGS84 datum.
                'South latitude
                If AreaMatch(0).SouthLatitude < 0 Then
                    AngleDegMinSec.DecimalDegreesToDegMinSec(AreaMatch(0).SouthLatitude * -1)
                    For Each NSitem In cmbSLatNS.Items
                        If NSitem.ToString = "S" Then
                            cmbSLatNS.SelectedItem = NSitem
                        End If
                    Next
                Else
                    AngleDegMinSec.DecimalDegreesToDegMinSec(AreaMatch(0).SouthLatitude)
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
                If AreaMatch(0).NorthLatitude < 0 Then
                    AngleDegMinSec.DecimalDegreesToDegMinSec(AreaMatch(0).NorthLatitude * -1)
                    For Each NSitem In cmbNLatNS.Items
                        If NSitem.ToString = "S" Then
                            cmbNLatNS.SelectedItem = NSitem
                        End If
                    Next
                Else
                    AngleDegMinSec.DecimalDegreesToDegMinSec(AreaMatch(0).NorthLatitude)
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
                If AreaMatch(0).WestLongitude < 0 Then
                    AngleDegMinSec.DecimalDegreesToDegMinSec(AreaMatch(0).WestLongitude * -1)
                    For Each WEitem In cmbWLongWE.Items
                        If WEitem.ToString = "W" Then
                            cmbWLongWE.SelectedItem = WEitem
                        End If
                    Next
                Else
                    AngleDegMinSec.DecimalDegreesToDegMinSec(AreaMatch(0).WestLongitude)
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
                If AreaMatch(0).EastLongitude < 0 Then
                    AngleDegMinSec.DecimalDegreesToDegMinSec(AreaMatch(0).EastLongitude * -1)
                    For Each WEitem In cmbELongWE.Items
                        If WEitem.ToString = "W" Then
                            cmbELongWE.SelectedItem = WEitem
                        End If
                    Next
                Else
                    AngleDegMinSec.DecimalDegreesToDegMinSec(AreaMatch(0).EastLongitude)
                    For Each WEitem In cmbELongWE.Items
                        If WEitem.ToString = "E" Then
                            cmbELongWE.SelectedItem = WEitem
                        End If
                    Next
                End If
                txtELongDegrees.Text = AngleDegMinSec.Degrees
                txtELongMinutes.Text = AngleDegMinSec.Minutes
                txtELongSeconds.Text = AngleDegMinSec.Seconds

                If AreaMatch.Count > 1 Then
                    'Main.MessageStyleWarningSet()
                    'Main.MessageAdd("More than one Area Of Use found! " & Str(AreaMatch.Count) & " matches found for Author = " & Author & " and Code = " & Str(Code) & vbCrLf)
                    'Main.MessageStyleNormalSet()
                    Main.Message.SetWarningStyle()
                    Main.Message.Add("More than one Area Of Use found! " & Str(AreaMatch.Count) & " matches found for Author = " & Author & " and Code = " & Str(Code) & vbCrLf)
                End If
            Else
                'Main.MessageStyleWarningSet()
                'Main.MessageAdd("No Area Of Use found for Author = " & Author & " and Code = " & Str(Code) & vbCrLf)
                'Main.MessageStyleNormalSet()
                Main.Message.SetWarningStyle()
                Main.Message.Add("No Area Of Use found for Author = " & Author & " and Code = " & Str(Code) & vbCrLf)
            End If
        End If
    End Sub

    Private Sub DisplayMethodData(ByVal Author As String, ByVal Code As Integer)

        If Main.CoordOpMethod.NRecords > 0 Then
            Dim MethodMatch = From Method In Main.CoordOpMethod.List Where Method.Author = Author And Method.Code = Code

            If MethodMatch.Count > 0 Then
                rtbExample.Text = MethodMatch(0).Example
                rtbFormula.Text = MethodMatch(0).Formula
                txtMethodName2.Text = MethodMatch(0).Name
                txtMethodAuthor.Text = MethodMatch(0).Author
                txtMethodCode.Text = MethodMatch(0).Code
                txtMethodDeprecated.Text = MethodMatch(0).Deprecated
                txtMethodReversable.Text = MethodMatch(0).ReverseOp

                'Update the list of alias names:
                cmbMethodAliasNames.Items.Clear()
                cmbMethodAliasNames.Text = ""
                For Each item As String In MethodMatch(0).AliasName
                    cmbMethodAliasNames.Items.Add(item)
                Next

                If cmbMethodAliasNames.Items.Count > 0 Then
                    cmbMethodAliasNames.SelectedIndex = 0 'Select first item
                End If

                txtMethodComments.Text = MethodMatch(0).Comments

                'Display projection parameters:
                Dim NParameters As Integer = MethodMatch(0).Parameter.Count

                If NParameters > 0 Then
                    DataGridView2.RowCount = NParameters
                    Dim RowNo As Integer
                    For RowNo = 0 To NParameters - 1
                        DataGridView2.Rows(RowNo).Cells(0).Value = MethodMatch(0).Parameter(RowNo).Name
                        DataGridView2.Rows(RowNo).Cells(1).Value = MethodMatch(0).Parameter(RowNo).Order
                        DataGridView2.Rows(RowNo).Cells(2).Value = MethodMatch(0).Parameter(RowNo).SignReversal
                        DataGridView2.Rows(RowNo).Cells(3).Value = MethodMatch(0).Parameter(RowNo).Description
                    Next

                    DataGridView2.Columns(0).Width = 280
                    DataGridView2.Columns(1).Width = 60
                    DataGridView2.Columns(2).Width = 60
                    DataGridView2.AutoResizeRows()
                Else
                    'This projection has no parameters!
                    DataGridView2.RowCount = 1
                End If

            Else
                'No Coordinate Operation Methods found matching the specified Author and Code

                'Clear the coordinate operation method parameters:
                txtMethodName2.Text = ""
                txtMethodAuthor.Text = ""
                txtMethodCode.Text = ""
                txtMethodDeprecated.Text = ""
                txtMethodReversable.Text = ""
                txtMethodComments.Text = ""
                rtbFormula.Text = ""
                rtbExample.Text = ""
                DataGridView2.RowCount = 1
                DataGridView2.ColumnCount = 4
                DataGridView2.Rows(0).Cells(0).Value = " "
                DataGridView2.Rows(0).Cells(1).Value = " "
                DataGridView2.Rows(0).Cells(2).Value = " "
                DataGridView2.Rows(0).Cells(3).Value = " "

            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the Projection list.

        Dim ProjectionListFileName As String = Trim(txtProjectionListFileName.Text)

        If ProjectionListFileName = "" Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Please enter a file name for the Projection list!" & vbCrLf)
            Exit Sub
        End If

        If ProjectionListFileName.EndsWith(".ProjectionList") Then
            'ProjectionListFileName has correct file extension.
            Main.Projection.ListFileName = ProjectionListFileName
        Else
            'Add file extension to the file name.
            ProjectionListFileName &= ".ProjectionList"
            Main.Projection.ListFileName = ProjectionListFileName
            txtProjectionListFileName.Text = ProjectionListFileName
        End If

        Main.Project.SaveXmlData(ProjectionListFileName, Main.Projection.ToXDoc())

    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the Projection list:
        CurrentRecordNo = 1
        'DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in Projection List
        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo - 1
        'DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in Projection List
        If CurrentRecordNo = Main.Projection.NRecords Then
            'Already at the last record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo + 1
        'DisplayListData(CurrentRecordNo) 'This is called when the CurrentRecordNo is changed
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the Area of Use list:
        CurrentRecordNo = Main.Projection.NRecords
        'DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub txtRecordNo_TextChanged(sender As Object, e As EventArgs) Handles txtRecordNo.TextChanged
        Dim NewRecordNo As Integer
        NewRecordNo = Int(Val(txtRecordNo.Text))

        If NewRecordNo < 1 Then
            Exit Sub
        End If

        If NewRecordNo > Main.Projection.NRecords Then
            Exit Sub
        End If

        _currentRecordNo = NewRecordNo
        If ListBox1.Items.Count >= _currentRecordNo Then
            ListBox1.SelectedIndex = _currentRecordNo - 1
        End If
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        'Only update the index if LitBox1 is the active control
        If Me.ActiveControl Is ListBox1 Then
            Dim Index As Integer
            Index = ListBox1.SelectedIndex + 1
            CurrentRecordNo = Index
            'DisplayListData(Index)
        End If

    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Find a Projection list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select a Projection list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Projection List | *.ProjectionList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtProjectionListFileName.Text = DataFileName
                    Main.Projection.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.Projection.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.Projection.NRecords
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
                Zip.SelectFileForm.FileExtension = ".ProjectionList"
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
        FoundIndex = Main.Projection.List.FindIndex(Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.Projection.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
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
        FoundIndex = Main.Projection.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
        If FoundIndex = -1 Then
            Main.Message.Add("String not found." & vbCrLf)
        Else
            CurrentRecordNo = FoundIndex + 1
        End If
    End Sub

    Private Sub DataGridView2_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView2.ColumnWidthChanged
        Dim DGVerticalScroll = DataGridView1.Controls.OfType(Of VScrollBar).SingleOrDefault.Visible

        If DGVerticalScroll Then
            DataGridView2.Columns(3).Width = DataGridView2.Width - DataGridView2.Columns(0).Width - DataGridView2.Columns(1).Width - DataGridView2.Columns(2).Width - DataGridView2.RowHeadersWidth - 20
        Else
            DataGridView2.Columns(3).Width = DataGridView2.Width - DataGridView2.Columns(0).Width - DataGridView2.Columns(1).Width - DataGridView2.Columns(2).Width - DataGridView2.RowHeadersWidth - 2
        End If
    End Sub

    Private Sub DataGridView2_Resize(sender As Object, e As EventArgs) Handles DataGridView2.Resize
        If DataGridView2.Columns.Count > 3 Then
            Dim DGVerticalScroll = DataGridView2.Controls.OfType(Of VScrollBar).SingleOrDefault.Visible

            If DGVerticalScroll Then
                DataGridView2.Columns(3).Width = DataGridView2.Width - DataGridView2.Columns(0).Width - DataGridView2.Columns(1).Width - DataGridView2.Columns(2).Width - DataGridView2.RowHeadersWidth - 20
            Else
                DataGridView2.Columns(3).Width = DataGridView2.Width - DataGridView2.Columns(0).Width - DataGridView2.Columns(1).Width - DataGridView2.Columns(2).Width - DataGridView2.RowHeadersWidth - 2
            End If
        Else
            'DataGridView2 has not been configured with 4 columns yet.
        End If

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub


#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Events - Events that can be triggered by this form." '--------------------------------------------------------------------------------------------------------------------------
#End Region 'Form Events ----------------------------------------------------------------------------------------------------------------------------------------------------------------------
















End Class