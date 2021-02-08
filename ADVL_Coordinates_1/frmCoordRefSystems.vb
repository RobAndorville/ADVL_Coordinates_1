Public Class frmCoordRefSystems
    'The CoordRefSystems form is used to view, create or edit Coordinate Reference Systems parameters.

#Region " Variable Declarations - All the variables used in this form and this application." '-------------------------------------------------------------------------------------------------

    Dim AngleDegMinSec As New ADVL_Coordinates_Library_1.AngleDegMinSec  'Used for converting between decimal degrees and degrees-minutes-seconds
    Dim AngleConvert As New ADVL_Coordinates_Library_1.AngleConvert      'Used for converting between radians, decimal degrees and gradians

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

    Private Sub frmCoorRefSystems_Load(sender As Object, e As EventArgs) Handles Me.Load

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

        Main.CoordRefSystem.AddUser()
        Main.AreaOfUse.AddUser()
        Main.CoordinateSystem.AddUser()
        UpdateList()
        txtNRecords.Text = Main.CoordRefSystem.NRecords
        txtCRSListFileName.Text = Main.CoordRefSystem.ListFileName
        CurrentRecordNo = 1
        DisplayListData(1)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the form
        Main.CoordRefSystem.RemoveUser()
        Main.AreaOfUse.RemoveUser()
        Main.CoordinateSystem.RemoveUser()
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub UpdateList()
        'Update the list of Coordinate Reference Systems in ListBox1
        ListBox1.Items.Clear()
        Dim Index As Integer
        For Index = 0 To Main.CoordRefSystem.NRecords - 1
            ListBox1.Items.Add(Main.CoordRefSystem.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Displays a record from the CRS list.

        If RecordNo < 1 Then
            Main.Message.AddWarning("Cannot display Coordinate Reference System data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.CoordRefSystem.NRecords Then
            Main.Message.AddWarning("Cannot display Coordinate Reference System data. Selected record number is too large." & vbCrLf)
            Exit Sub
        End If

        'Display Coordinate Reference System data: -------------------------------------------------------------------------------------
        txtCrsName.Text = Main.CoordRefSystem.List(RecordNo - 1).Name
        txtCrsName2.Text = Main.CoordRefSystem.List(RecordNo - 1).Name
        txtCrsAuthor.Text = Main.CoordRefSystem.List(RecordNo - 1).Author
        txtCrsCode.Text = Main.CoordRefSystem.List(RecordNo - 1).Code
        txtCrsDeprecated.Text = Main.CoordRefSystem.List(RecordNo - 1).Deprecated

        'Update the list of alias names:
        cmbCrsAliasNames.Items.Clear()
        cmbCrsAliasNames.Text = ""
        For Each item As String In Main.CoordRefSystem.List(RecordNo - 1).AliasName
            cmbCrsAliasNames.Items.Add(item)
        Next

        If cmbCrsAliasNames.Items.Count > 0 Then
            cmbCrsAliasNames.SelectedIndex = 0 'Select first item
        End If

        'txtCrsType.Text = CoordRefSystemList(RecordNo - 1).Type
        txtCrsType.Text = Main.CoordRefSystem.List(RecordNo - 1).Type.ToString
        txtCrsScope.Text = Main.CoordRefSystem.List(RecordNo - 1).Scope
        txtCrsComments.Text = Main.CoordRefSystem.List(RecordNo - 1).Comments

        'Display Area of Use Summary Data:
        txtAreaOfUseName.Text = Main.CoordRefSystem.List(RecordNo - 1).Area.Name
        txtAreaOfUseAuthor.Text = Main.CoordRefSystem.List(RecordNo - 1).Area.Author
        txtAreaOfUseCode.Text = Main.CoordRefSystem.List(RecordNo - 1).Area.Code
        DisplayAOUData(Main.CoordRefSystem.List(RecordNo - 1).Area.Author, Main.CoordRefSystem.List(RecordNo - 1).Area.Code)

        'Display Coordinate System summary data:
        txtCoordinateSystemName.Text = Main.CoordRefSystem.List(RecordNo - 1).CoordinateSystem.Name
        txtCoordinateSystemAuthor.Text = Main.CoordRefSystem.List(RecordNo - 1).CoordinateSystem.Author
        txtCoordinateSystemCode.Text = Main.CoordRefSystem.List(RecordNo - 1).CoordinateSystem.Code
        txtCoordinateSystemType.Text = Main.CoordRefSystem.List(RecordNo - 1).CoordinateSystem.Type
        DisplayCSData(Main.CoordRefSystem.List(RecordNo - 1).CoordinateSystem.Author, Main.CoordRefSystem.List(RecordNo - 1).CoordinateSystem.Code)

    End Sub

    Private Sub DisplayAOUData(ByVal Author As String, ByVal Code As Integer)
        'Display the Area Of Use parameters corresponding to the Author and Code.

        If Main.AreaOfUse.NRecords = 0 Then
            'There is no Are Of Use data.
            Main.Message.AddWarning("There is no Area Of Use data!" & vbCrLf)
        Else
            Dim AreaMatch = From Area In Main.AreaOfUse.List Where Area.Author = Author And Area.Code = Code

            If AreaMatch.Count > 0 Then
                txtAouName.Text = AreaMatch(0).Name
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
                    Main.Message.AddWarning("More than one Area Of Use found! " & Str(AreaMatch.Count) & " matches found for Author = " & Author & " and Code = " & Str(Code) & vbCrLf)
                End If
            Else
                Main.Message.AddWarning("No Area Of Use found for Author = " & Author & " and Code = " & Str(Code) & vbCrLf)
            End If
        End If


    End Sub

    Private Sub DisplayCSData(ByVal Author As String, ByVal Code As Integer)
        'Display the Coordinate System parameters corresponding to the Author and Code.
        If Main.CoordinateSystem.NRecords = 0 Then
            'There is no Coordinate System data.
            Main.Message.AddWarning("There is no Coordinate System data!" & vbCrLf)
        Else
            Dim CoordSysMatch = From Area In Main.CoordinateSystem.List Where Area.Author = Author And Area.Code = Code
            If CoordSysMatch.Count > 0 Then
                txtCsName.Text = CoordSysMatch(0).Name
                txtCsAuthor.Text = CoordSysMatch(0).Author
                txtCsCode.Text = CoordSysMatch(0).Code
                txtCsDimension.Text = CoordSysMatch(0).Dimension
                txtCsDeprecated.Text = CoordSysMatch(0).Deprecated

                cmbCsAliasNames.Items.Clear()
                For Each item As String In CoordSysMatch(0).AliasName
                    cmbCsAliasNames.Items.Add(item)
                Next
                If cmbCsAliasNames.Items.Count > 0 Then
                    cmbCsAliasNames.SelectedIndex = 0 'Select first item.
                End If

                txtCsType.Text = CoordSysMatch(0).Type
                txtCsComments.Text = CoordSysMatch(0).Comments

            End If

        End If


    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the CoordRefSystem list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in CoordRefSystem list.
        If CurrentRecordNo = Main.CoordRefSystem.NRecords Then
            'Already at the last record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in CoordRefSystem list.
        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the CoordRefSystem list:
        CurrentRecordNo = Main.AreaOfUse.NRecords
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the CoordRefSystem list.

        Dim CoordRefSystemListFileName As String = Trim(txtCRSListFileName.Text)

        If CoordRefSystemListFileName = "" Then
            Main.Message.AddWarning("Please enter a file name for the Coordinate Reference System list!" & vbCrLf)
            Exit Sub
        End If

        If CoordRefSystemListFileName.EndsWith(".CrsList") Then
            'CoordOpMethodListFileName has correct file extension.
            Main.CoordRefSystem.ListFileName = CoordRefSystemListFileName
        Else
            'Add file extension to the file name.
            CoordRefSystemListFileName &= ".CrsList"
            Main.CoordRefSystem.ListFileName = CoordRefSystemListFileName
            txtCRSListFileName.Text = CoordRefSystemListFileName
        End If

        Main.Project.SaveXmlData(CoordRefSystemListFileName, Main.CoordRefSystem.ToXDoc())
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Find an CoordRefSystem list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select an Coordinate Operation Method list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Coordinate Reference System List | *.CrsList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtCRSListFileName.Text = DataFileName
                    Main.CoordRefSystem.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.CoordRefSystem.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.CoordRefSystem.NRecords
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
                Zip.SelectFileForm.FileExtension = ".CrsList"
                Zip.SelectFileForm.GetFileList()
        End Select
    End Sub

    Private Sub txtRecordNo_TextChanged(sender As Object, e As EventArgs) Handles txtRecordNo.TextChanged
        Dim NewRecordNo As Integer
        NewRecordNo = Int(Val(txtRecordNo.Text))

        If NewRecordNo < 1 Then
            Exit Sub
        End If

        If NewRecordNo > Main.CoordRefSystem.NRecords Then
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

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the Coordinate Reference System list from the EPSG database.
        Main.CoordRefSystem.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.CoordRefSystem.NRecords
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub btnNameFind_Click(sender As Object, e As EventArgs) Handles btnNameFind.Click
        'Find the first record with specified text contained within the Name field.
        FindRecord(txtSearchText.Text)
    End Sub

    Private Sub FindRecord(ByVal SearchString As String)
        'Find a record using the SearchString to match the Name field
        Dim FoundIndex As Integer
        FoundIndex = Main.CoordRefSystem.List.FindIndex(Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.CoordRefSystem.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
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
        FoundIndex = Main.CoordRefSystem.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
        If FoundIndex = -1 Then
            Main.Message.Add("String not found." & vbCrLf)
        Else
            CurrentRecordNo = FoundIndex + 1
        End If
    End Sub

    Private Sub btnNext_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNext.MouseDown
        'Mouse has been clicked down.
        'Wait for 1000ms:
        Timer1.Interval = 1000
        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Move to the next record in CoordRefSystem list.
        If CurrentRecordNo = Main.CoordRefSystem.NRecords Then
            'Already at the last record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)

        Timer1.Interval = 250 'Change interval to 0.25 of a seconds.
    End Sub

    Private Sub btnNext_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNext.MouseUp
        'Mouse up.
        Timer1.Enabled = False
    End Sub

#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Events - Events that can be triggered by this form." '--------------------------------------------------------------------------------------------------------------------------
#End Region 'Form Events ----------------------------------------------------------------------------------------------------------------------------------------------------------------------






  
  
  
  
  
 
   
  
  
  
End Class