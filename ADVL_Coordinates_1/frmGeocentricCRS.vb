﻿Public Class frmGeocentricCRS
    'The Geocentric Coordinate Reference System form is used to view, create or edit Geocentric CRS parameters.

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

    Private Sub frmGeocentricCRS_Load(sender As Object, e As EventArgs) Handles Me.Load

        RestoreFormSettings()   'Restore the form settings

        Main.AreaOfUse.AddUser()
        Main.Datum.AddUser()
        Main.CoordinateSystem.AddUser()
        Main.GeocentricCRS.AddUser()

        UpdateList()
        txtNRecords.Text = Main.GeocentricCRS.NRecords
        txtGeocentricCRSListFileName.Text = Main.GeocentricCRS.ListFileName
        CurrentRecordNo = 1
        DisplayListData(1)


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Form
        Main.AreaOfUse.RemoveUser()
        Main.Datum.RemoveUser()
        Main.CoordinateSystem.RemoveUser()
        Main.GeocentricCRS.RemoveUser()

        Me.Close() 'Close the form
    End Sub

    Private Sub frmGeocentricCRS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
        'Save the Geocentric CRS list.

        Dim GeocentricCRSListFileName As String = Trim(txtGeocentricCRSListFileName.Text)

        If GeocentricCRSListFileName = "" Then
            Main.Message.AddWarning("Please enter a file name for the Geocentric CRS list!" & vbCrLf)
            Exit Sub
        End If

        If GeocentricCRSListFileName.EndsWith(".GeocentricCRSList") Then
            'GeocentricCRSListFileName has correct file extension.
            Main.GeocentricCRS.ListFileName = GeocentricCRSListFileName
        Else
            'Add file extension to the file name.
            GeocentricCRSListFileName &= ".GeocentricCRSList"
            Main.GeocentricCRS.ListFileName = GeocentricCRSListFileName
            txtGeocentricCRSListFileName.Text = GeocentricCRSListFileName
        End If
        Main.Project.SaveXmlData(GeocentricCRSListFileName, Main.GeocentricCRS.ToXDoc())
    End Sub

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the Geocentric CRS list from the EPSG database.
        Main.GeocentricCRS.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.GeocentricCRS.NRecords
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub UpdateList()
        'Update the list of records in ListBox1
        ListBox1.Items.Clear()
        Dim Index As Integer
        For Index = 0 To Main.GeocentricCRS.NRecords - 1
            ListBox1.Items.Add(Main.GeocentricCRS.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the Geocentric CRS list.

        If RecordNo < 1 Then
            Main.Message.AddWarning("Cannot display CRS data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.GeocentricCRS.NRecords Then
            Main.Message.AddWarning("Cannot display CRS data. Selected record number is too large." & vbCrLf)
            Main.Message.AddWarning("RecordNo = " & RecordNo & "   Main.GeocentricCRS.NRecords = " & Main.GeocentricCRS.NRecords & vbCrLf)
            Exit Sub
        End If

        txtCRSName.Text = Main.GeocentricCRS.List(RecordNo - 1).Name
        txtCRSName2.Text = Main.GeocentricCRS.List(RecordNo - 1).Name
        txtCrsAuthor.Text = Main.GeocentricCRS.List(RecordNo - 1).Author
        txtCrsCode.Text = Main.GeocentricCRS.List(RecordNo - 1).Code
        txtCrsDeprecated.Text = Main.GeocentricCRS.List(RecordNo - 1).Deprecated

        'Update the list of alias names:
        cmbCRSAliasNames.Items.Clear()
        cmbCRSAliasNames.Text = ""
        For Each item As String In Main.GeocentricCRS.List(RecordNo - 1).AliasName
            cmbCRSAliasNames.Items.Add(item)
        Next

        If cmbCRSAliasNames.Items.Count > 0 Then
            cmbCRSAliasNames.SelectedIndex = 0 'Select first item
        End If

        txtCrsScope.Text = Main.GeocentricCRS.List(RecordNo - 1).Scope
        txtCrsComments.Text = Main.GeocentricCRS.List(RecordNo - 1).Comments

        'Display Area Of Use data:
        txtAOUName.Text = Main.GeocentricCRS.List(RecordNo - 1).Area.Name
        DisplayAOUData(Main.GeocentricCRS.List(RecordNo - 1).Area.Author, Main.GeocentricCRS.List(RecordNo - 1).Area.Code)

        'Display Coordinate System data:
        txtCSName.Text = Main.GeocentricCRS.List(RecordNo - 1).CoordinateSystem.Name
        txtCSType.Text = Main.GeocentricCRS.List(RecordNo - 1).CoordinateSystem.Type
        DisplayCSData(Main.GeocentricCRS.List(RecordNo - 1).CoordinateSystem.Author, Main.GeocentricCRS.List(RecordNo - 1).CoordinateSystem.Code)

        'Display Datum data:
        txtDatumName.Text = Main.GeocentricCRS.List(RecordNo - 1).Datum.Name
        txtDatumType.Text = Main.GeocentricCRS.List(RecordNo - 1).Datum.Type
        DisplayDatumData(Main.GeocentricCRS.List(RecordNo - 1).Datum.Author, Main.GeocentricCRS.List(RecordNo - 1).Datum.Code)

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

    Private Sub DisplayCSData(ByVal Author As String, ByVal Code As Integer)
        'Display the Coordinate System parameters corresponding to the Author and Code.

        If Main.CoordinateSystem.List.Count = 0 Then
            'There is no Coordinate System data.
            Main.Message.AddWarning("There is no Coordinate System data!" & vbCrLf)
        Else
            Dim CoordSysMatch = From CoordSys In Main.CoordinateSystem.List Where CoordSys.Author = Author And CoordSys.Code = Code

            If CoordSysMatch.Count > 0 Then
                txtCoordSysName.Text = CoordSysMatch(0).Name
                txtCoordSysAuthor.Text = CoordSysMatch(0).Author
                txtCoordSysCode.Text = CoordSysMatch(0).Code
                txtCoordSysDeprecated.Text = CoordSysMatch(0).Deprecated
                Select Case CoordSysMatch(0).Type
                    Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Affine
                        txtCoordSysType.Text = "Affine"
                    Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Cartesian
                        txtCoordSysType.Text = "Cartesian"
                    Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Cylindrical
                        txtCoordSysType.Text = "Cylindrical"
                    Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Ellipsoidal
                        txtCoordSysType.Text = "Ellipsoidal"
                    Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Linear
                        txtCoordSysType.Text = "Linear"
                    Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Polar
                        txtCoordSysType.Text = "Polar"
                    Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Spherical
                        txtCoordSysType.Text = "Spherical"
                    Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Vertical
                        txtCoordSysType.Text = "Vertical"
                    Case ADVL_Coordinates_Library_1.CoordinateSystem.CSTypes.Unknown
                        txtCoordSysType.Text = "Unknown"
                End Select
                txtCoordSysDimension.Text = CoordSysMatch(0).Dimension

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
                NAxes = CoordSysMatch(0).Axis.Count
                If NAxes > 0 Then
                    txtAxisOrder1.Text = CoordSysMatch(0).Axis(0).Order
                    txtAxisName1.Text = CoordSysMatch(0).Axis(0).Name
                    txtAxisAbbr1.Text = CoordSysMatch(0).Axis(0).Abbreviation
                    txtAxisUnit1.Text = CoordSysMatch(0).Axis(0).UnitOfMeasure.Name
                    txtAxisOrientation1.Text = CoordSysMatch(0).Axis(0).Orientation
                    If NAxes > 1 Then
                        txtAxisOrder2.Text = CoordSysMatch(0).Axis(1).Order
                        txtAxisName2.Text = CoordSysMatch(0).Axis(1).Name
                        txtAxisAbbr2.Text = CoordSysMatch(0).Axis(1).Abbreviation
                        txtAxisUnit2.Text = CoordSysMatch(0).Axis(1).UnitOfMeasure.Name
                        txtAxisOrientation2.Text = CoordSysMatch(0).Axis(1).Orientation
                        If NAxes > 2 Then
                            txtAxisOrder3.Text = CoordSysMatch(0).Axis(2).Order
                            txtAxisName3.Text = CoordSysMatch(0).Axis(2).Name
                            txtAxisAbbr3.Text = CoordSysMatch(0).Axis(2).Abbreviation
                            txtAxisUnit3.Text = CoordSysMatch(0).Axis(2).UnitOfMeasure.Name
                            txtAxisOrientation3.Text = CoordSysMatch(0).Axis(2).Orientation
                        End If
                    End If
                End If

                If CoordSysMatch.Count > 1 Then
                    Main.Message.AddWarning("More than one Coordinate System found! " & Str(CoordSysMatch.Count) & " matches found for Author = " & Author & " and Code = " & Str(Code) & vbCrLf)
                End If
            Else
                Main.Message.AddWarning("No Coordinate System found for Author = " & Author & " and Code = " & Str(Code) & vbCrLf)
            End If
        End If

    End Sub

    Private Sub DisplayDatumData(ByVal Author As String, ByVal Code As Integer)
        'Display the Datum parameters corresponding to the Author and Code.

        If Main.Datum.List.Count = 0 Then
            Main.Message.AddWarning("There is no Datum data!" & vbCrLf)
        Else
            Dim DatumMatch = From Datum In Main.Datum.List Where Datum.Author = Author And Datum.Code = Code

            If DatumMatch.Count > 0 Then
                txtDatumName2.Text = DatumMatch(0).Name
                Select Case DatumMatch(0).Type
                    Case ADVL_Coordinates_Library_1.DatumSummary.DatumTypes.Engineering
                        txtDatumType2.Text = "Engineering"
                    Case ADVL_Coordinates_Library_1.DatumSummary.DatumTypes.Geodetic
                        txtDatumType2.Text = "Geodetic"
                    Case ADVL_Coordinates_Library_1.DatumSummary.DatumTypes.Image
                        txtDatumType2.Text = "Image"
                    Case ADVL_Coordinates_Library_1.DatumSummary.DatumTypes.Vertical
                        txtDatumType2.Text = "Vertical"
                    Case ADVL_Coordinates_Library_1.DatumSummary.DatumTypes.Unknown
                        txtDatumType2.Text = "Unknown"
                End Select
                txtDatumAuthor2.Text = DatumMatch(0).Author
                txtDatumCode2.Text = DatumMatch(0).Code
                txtDatumDeprecated.Text = DatumMatch(0).Deprecated

                cmbDatumAliasNames.Items.Clear()
                For Each item As String In DatumMatch(0).AliasName
                    cmbDatumAliasNames.Items.Add(item)
                Next
                If cmbDatumAliasNames.Items.Count > 0 Then
                    cmbDatumAliasNames.SelectedIndex = 0 'Select first item.
                End If

                txtDatumComments.Text = DatumMatch(0).Comments
                txtDatumOrigin.Text = DatumMatch(0).OriginDescription
                txtDatumScope.Text = DatumMatch(0).Scope


                If DatumMatch.Count > 1 Then
                    Main.Message.AddWarning("More than one Datum found! " & Str(DatumMatch.Count) & " matches found for Author = " & Author & " and Code = " & Str(Code) & vbCrLf)
                End If
            Else
                Main.Message.AddWarning("No Datum found for Author = " & Author & " and Code = " & Str(Code) & vbCrLf)
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
        FoundIndex = Main.GeocentricCRS.List.FindIndex(Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.GeocentricCRS.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
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
        FoundIndex = Main.GeocentricCRS.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
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

        If NewRecordNo > Main.GeocentricCRS.NRecords Then
            Exit Sub
        End If

        _currentRecordNo = NewRecordNo
        If ListBox1.Items.Count >= _currentRecordNo Then
            ListBox1.SelectedIndex = _currentRecordNo - 1
        End If
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the Geocentric CRS list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in Geocentric CRS List
        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in Geocentric CRS List
        If CurrentRecordNo = Main.GeocentricCRS.NRecords Then
            'Already at the last record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the Geographic 2D CRS list:
        CurrentRecordNo = Main.GeocentricCRS.NRecords
        DisplayListData(CurrentRecordNo)
    End Sub

  
    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Find a Geocentric CRS list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select a Geocentric CRS list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Geocentric CRS List | *.GeocentricCRSList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtGeocentricCRSListFileName.Text = DataFileName
                    Main.GeocentricCRS.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.GeocentricCRS.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.GeocentricCRS.NRecords
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
                Zip.SelectFileForm.FileExtension = ".GeocentricCRSList"
                Zip.SelectFileForm.GetFileList()

        End Select
    End Sub

    Private Sub Zip_FileSelected(FileName As String) Handles Zip.FileSelected
        txtGeocentricCRSListFileName.Text = FileName
        Main.GeocentricCRS.ListFileName = FileName
        Dim XmlDoc As System.Xml.Linq.XDocument
        Main.Project.DataLocn.ReadXmlData(FileName, XmlDoc)
        Main.GeocentricCRS.LoadXml(XmlDoc)
        UpdateList()
        txtNRecords.Text = Main.GeocentricCRS.NRecords
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