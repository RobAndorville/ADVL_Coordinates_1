Public Class frmCoordinateSystems
    'The Coordinate Systems form is used to view, create or edit Coordinate Systems for datums and projections.

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

#Region " Form Display Methods - Code used to display this form." '----------------------------------------------------------------------------------------------------------------------------

    Private Sub frmCoordinateSystems_Load(sender As Object, e As EventArgs) Handles Me.Load

        RestoreFormSettings()

        Main.CoordinateSystem.AddUser()
        UpdateList()
        txtNRecords.Text = Main.CoordinateSystem.NRecords
        txtCoordSysListFileName.Text = Main.CoordinateSystem.ListFileName
        CurrentRecordNo = 1
        DisplayListData(1)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the form
        Main.CoordinateSystem.RemoveUser()
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub UpdateList()
        'Update the list of Coordinate Systems in ListBox1

        ListBox1.Items.Clear()

        Dim Index As Integer

        For Index = 0 To Main.CoordinateSystem.NRecords - 1
            ListBox1.Items.Add(Main.CoordinateSystem.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the Coordinate System list.

        If RecordNo < 1 Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Coordinate System data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.CoordinateSystem.NRecords Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Coordinate System data. Selected record number is too large." & vbCrLf)
            Exit Sub
        End If

        txtName.Text = Main.CoordinateSystem.List(RecordNo - 1).Name
        txtCode.Text = Main.CoordinateSystem.List(RecordNo - 1).Code
        txtAuthor.Text = Main.CoordinateSystem.List(RecordNo - 1).Author
        txtDeprecated.Text = Main.CoordinateSystem.List(RecordNo - 1).Deprecated

        ''Update the list of alias names:
        'cmbAliasNames.Items.Clear()
        'cmbAliasNames.Text = ""
        'For Each item As String In Main.AreaOfUse.List(RecordNo - 1).AliasName
        '    cmbAliasNames.Items.Add(item)
        'Next
        'If cmbAliasNames.Items.Count > 0 Then
        '    cmbAliasNames.SelectedIndex = 0 'Select first item
        'End If

        Select Case Main.CoordinateSystem.List(RecordNo - 1).Type
            Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Affine
                txtType.Text = "Affine"
            Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Cartesian
                txtType.Text = "Cartesian"
            Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Cylindrical
                txtType.Text = "Cylindrical"
            Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Ellipsoidal
                txtType.Text = "Ellipsoidal"
            Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Linear
                txtType.Text = "Linear"
            Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Polar
                txtType.Text = "Polar"
            Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Spherical
                txtType.Text = "Spherical"
            Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Vertical
                txtType.Text = "Vertical"
            Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Unknown
                txtType.Text = "Unknown"
        End Select
        txtDimension.Text = Main.CoordinateSystem.List(RecordNo - 1).Dimension
        txtComments.Text = Main.CoordinateSystem.List(RecordNo - 1).Comments

        'Clear the list of Axis parameters:
        txtAxisOrder1.Text = ""
        txtAxisName1.Text = ""
        txtAxisAbbr1.Text = ""
        txtAxisUnit1.Text = ""
        txtAxisOrientation1.Text = ""
        txtAxisOrder2.Text = ""
        txtAxisName2.Text = ""
        txtAxisAbbr2.Text = ""
        txtAxisUnit2.Text = ""
        txtAxisOrientation2.Text = ""
        txtAxisOrder3.Text = ""
        txtAxisName3.Text = ""
        txtAxisAbbr3.Text = ""
        txtAxisUnit3.Text = ""
        txtAxisOrientation3.Text = ""

        Dim NAxes As Integer
        NAxes = Main.CoordinateSystem.List(RecordNo - 1).Axis.Count
        If NAxes > 0 Then
            txtAxisOrder1.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(0).Order
            txtAxisName1.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(0).Name
            txtAxisAbbr1.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(0).Abbreviation
            txtAxisUnit1.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(0).UnitOfMeasure.Name
            txtAxisOrientation1.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(0).Orientation
            If NAxes > 1 Then
                txtAxisOrder2.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(1).Order
                txtAxisName2.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(1).Name
                txtAxisAbbr2.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(1).Abbreviation
                txtAxisUnit2.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(1).UnitOfMeasure.Name
                txtAxisOrientation2.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(1).Orientation
                If NAxes > 2 Then
                    txtAxisOrder3.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(2).Order
                    txtAxisName3.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(2).Name
                    txtAxisAbbr3.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(2).Abbreviation
                    txtAxisUnit3.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(2).UnitOfMeasure.Name
                    txtAxisOrientation3.Text = Main.CoordinateSystem.List(RecordNo - 1).Axis(2).Orientation
                End If
            End If
        End If
    End Sub

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the Coordinate System list from the EPSG database.
        Main.CoordinateSystem.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.CoordinateSystem.NRecords
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the Coordinate Systems list.

        Dim CoordSystemsListFileName As String = Trim(txtCoordSysListFileName.Text)

        If CoordSystemsListFileName = "" Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Please enter a file name for the Coordinate Systems list!" & vbCrLf)
            Exit Sub
        End If

        If CoordSystemsListFileName.EndsWith(".CoordSysList") Then
            'CoordSystemsListFileName has correct file extension.
            Main.CoordinateSystem.ListFileName = CoordSystemsListFileName
        Else
            'Add file extension to the file name.
            CoordSystemsListFileName &= ".CoordSysList"
            Main.CoordinateSystem.ListFileName = CoordSystemsListFileName
            txtCoordSysListFileName.Text = CoordSystemsListFileName
        End If

        Main.Project.SaveXmlData(CoordSystemsListFileName, Main.CoordinateSystem.ToXDoc())
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Find a Coordinate Systems list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select a Coordinate Systems list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Coordinate System List | *.CoordSysList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtCoordSysListFileName.Text = DataFileName
                    Main.CoordinateSystem.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.CoordinateSystem.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.CoordinateSystem.NRecords
                    txtRecordNo.Text = 1
                    DisplayListData(1)
                End If

            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                'Select an Area of Use list file from the project archive:

        End Select
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the Coordinate System list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in Coordinate Systems List

        If CurrentRecordNo = Main.CoordinateSystem.NRecords Then
            'Already at the last record.
            Exit Sub
        End If

        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in Coordinate Systems List

        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If

        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the Coordinate System list:
        CurrentRecordNo = Main.CoordinateSystem.NRecords
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNameFind_Click(sender As Object, e As EventArgs) Handles btnNameFind.Click
        'Find the first record with specified text contained within the Name field.
        FindRecord(txtSearchText.Text)

    End Sub

    Private Sub FindRecord(ByVal SearchString As String)
        'Find a record using the SearchString to match the Name field
        Dim FoundIndex As Integer
        FoundIndex = Main.CoordinateSystem.List.FindIndex(Function(x) x.Name.Contains(SearchString))
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
        FoundIndex = Main.CoordinateSystem.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.CoordinateSystem.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
            If FoundIndex = -1 Then
                Main.Message.Add("String not found." & vbCrLf)
            Else
                CurrentRecordNo = FoundIndex + 1
            End If
        Else
            Main.Message.Add("At first record in the list." & vbCrLf)
        End If
    End Sub

    Private Sub txtRecordNo_TextChanged(sender As Object, e As EventArgs) Handles txtRecordNo.TextChanged
        Dim NewRecordNo As Integer
        NewRecordNo = Int(Val(txtRecordNo.Text))

        If NewRecordNo < 1 Then
            Exit Sub
        End If

        If NewRecordNo > Main.CoordinateSystem.NRecords Then
            Exit Sub
        End If

        _currentRecordNo = NewRecordNo
        If ListBox1.Items.Count >= _currentRecordNo Then
            ListBox1.SelectedIndex = _currentRecordNo - 1
        End If
        DisplayListData(CurrentRecordNo)

    End Sub



#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Events - Events that can be triggered by this form." '--------------------------------------------------------------------------------------------------------------------------
#End Region 'Form Events ----------------------------------------------------------------------------------------------------------------------------------------------------------------------

  
   
  
  
 
   
 
 
  
  
   
End Class