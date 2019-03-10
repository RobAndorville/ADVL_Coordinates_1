Public Class frmGeographic3DCRS
    'This form displays the parameters for Geographic 3D Coordinate Reference Systems

#Region " Variable Declarations - All the variables used in this form and this application." '-------------------------------------------------------------------------------------------------

    Dim AngleConvert As New ADVL_Coordinates_Library_1.AngleConvert
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

    Private Sub frmGeographic3DCRS_Load(sender As Object, e As EventArgs) Handles Me.Load
        RestoreFormSettings()

        Main.AreaOfUse.AddUser()
        Main.CoordinateSystem.AddUser()
        Main.CoordRefSystem.AddUser()
        Main.Datum.AddUser()
        Main.Geographic3DCRS.AddUser()

        UpdateList()
        txtNRecords.Text = Main.Geographic3DCRS.NRecords
        txtGeogr3DCRSListFileName.Text = Main.Geographic3DCRS.ListFileName
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the form
        Main.Geographic3DCRS.RemoveUser()
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub UpdateList()
        'Update the list of records in ListBox1
        ListBox1.Items.Clear()
        Dim Index As Integer
        For Index = 0 To Main.Geographic3DCRS.NRecords - 1
            ListBox1.Items.Add(Main.Geographic3DCRS.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the PrimeMeridian list.

        If RecordNo < 1 Then
            Main.Message.AddWarning("Cannot display Coordinate Reference System data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.Geographic3DCRS.NRecords Then
            Main.Message.AddWarning("Cannot display Coordinate Reference System data. Selected record number is too large." & vbCrLf)
            Exit Sub
        End If

        txtCRSName.Text = Main.Geographic3DCRS.List(RecordNo - 1).Name
        txtCRSName2.Text = Main.Geographic3DCRS.List(RecordNo - 1).Name
        txtCrsAuthor.Text = Main.Geographic3DCRS.List(RecordNo - 1).Author
        txtCrsCode.Text = Main.Geographic3DCRS.List(RecordNo - 1).Code
        txtCrsDeprecated.Text = Main.Geographic3DCRS.List(RecordNo - 1).Deprecated

        'Update the list of alias names:
        cmbCRSAliasNames.Items.Clear()
        cmbCRSAliasNames.Text = ""
        For Each item As String In Main.Geographic3DCRS.List(RecordNo - 1).AliasName
            cmbCRSAliasNames.Items.Add(item)
        Next

        If cmbCRSAliasNames.Items.Count > 0 Then
            cmbCRSAliasNames.SelectedIndex = 0 'Select first item
        End If

        txtCrsScope.Text = Main.Geographic3DCRS.List(RecordNo - 1).Scope
        txtCrsComments.Text = Main.Geographic3DCRS.List(RecordNo - 1).Comments

        'Display Area Of Use data:
        txtAOUName.Text = Main.Geographic3DCRS.List(RecordNo - 1).Area.Name
        DisplayAOUData(Main.Geographic3DCRS.List(RecordNo - 1).Area.Author, Main.Geographic3DCRS.List(RecordNo - 1).Area.Code)

        'Display Coordinate System data:
        txtCSName.Text = Main.Geographic3DCRS.List(RecordNo - 1).CoordinateSystem.Name
        txtCSType.Text = Main.Geographic3DCRS.List(RecordNo - 1).CoordinateSystem.Type
        DisplayCSData(Main.Geographic3DCRS.List(RecordNo - 1).CoordinateSystem.Author, Main.Geographic3DCRS.List(RecordNo - 1).CoordinateSystem.Code)

        'Display Datum data:
        txtDatumName.Text = Main.Geographic3DCRS.List(RecordNo - 1).Datum.Name
        txtDatumType.Text = Main.Geographic3DCRS.List(RecordNo - 1).Datum.Type
        DisplayDatumData(Main.Geographic3DCRS.List(RecordNo - 1).Datum.Author, Main.Geographic3DCRS.List(RecordNo - 1).Datum.Code)

        'Display Base Coordinate Reference System data:
        txtBaseCRSName.Text = Main.Geographic3DCRS.List(RecordNo - 1).SourceGeographicCRS.Name
        txtBaseCRSType.Text = Main.Geographic3DCRS.List(RecordNo - 1).SourceGeographicCRS.Type
        DisplaySourceCRSData(Main.Geographic3DCRS.List(RecordNo - 1).SourceGeographicCRS.Author, Main.Geographic3DCRS.List(RecordNo - 1).SourceGeographicCRS.Code)

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

    Private Sub DisplaySourceCRSData(ByVal Author As String, ByVal Code As Integer)
        'Display the Source Coordinate Reference System parameters corresponding to the Author and Code.

        If Main.CoordRefSystem.List.Count = 0 Then
            Main.Message.AddWarning("There is no Coordinate Reference System data!" & vbCrLf)
        Else
            Dim CoordRefSysMatch = From CoordRefSys In Main.CoordRefSystem.List Where CoordRefSys.Author = Author And CoordRefSys.Code = Code

            If CoordRefSysMatch.Count > 0 Then
                txtSourceCRSName.Text = CoordRefSysMatch(0).Name
                txtSourceCRSAuthor.Text = CoordRefSysMatch(0).Author
                txtSourceCRSCode.Text = CoordRefSysMatch(0).Code
                txtSourceCRSDeprecated.Text = CoordRefSysMatch(0).Deprecated
                'txtSourceCRSType.Text = CoordRefSysMatch(0).Type
                Select Case CoordRefSysMatch(0).Type
                    Case ADVL_Coordinates_Library_1.CrsTypes.Compound
                        txtSourceCRSType.Text = "Compound"
                    Case ADVL_Coordinates_Library_1.CrsTypes.Engineering
                        txtSourceCRSType.Text = "Engineering"
                    Case ADVL_Coordinates_Library_1.CrsTypes.Geocentric
                        txtSourceCRSType.Text = "Geocentric"
                    Case ADVL_Coordinates_Library_1.CrsTypes.Geographic2D
                        txtSourceCRSType.Text = "Geographic2D"
                    Case ADVL_Coordinates_Library_1.CrsTypes.Geographic3D
                        txtSourceCRSType.Text = "Geographic3D"
                    Case ADVL_Coordinates_Library_1.CrsTypes.Projected
                        txtSourceCRSType.Text = "Projected"
                    Case ADVL_Coordinates_Library_1.CrsTypes.Vertical
                        txtSourceCRSType.Text = "Vertical"
                    Case ADVL_Coordinates_Library_1.CrsTypes.Unknown
                        txtSourceCRSType.Text = "Unknown"
                End Select

                cmbSourceCRSAliasNames.Items.Clear()
                For Each item As String In CoordRefSysMatch(0).AliasName
                    cmbSourceCRSAliasNames.Items.Add(item)
                Next
                If cmbSourceCRSAliasNames.Items.Count > 0 Then
                    cmbSourceCRSAliasNames.SelectedIndex = 0 'Select first item.
                End If

                txtSourceCRSScope.Text = CoordRefSysMatch(0).Scope
                txtSourceCRSComments.Text = CoordRefSysMatch(0).Comments

                If CoordRefSysMatch.Count > 1 Then
                    Main.Message.AddWarning("More than one Coordinate Reference System found! " & Str(CoordRefSysMatch.Count) & " matches found for Author = " & Author & " and Code = " & Str(Code) & vbCrLf)
                End If
            Else
                If (Author = "") And (Code = 0) Then
                    'No need to display a warning message: There is no Source CRS associated with this Geographic 2D CRS.
                Else
                    Main.Message.AddWarning("No Coordinate Reference System found for Author = " & Author & " and Code = " & Str(Code) & vbCrLf)
                End If

                txtSourceCRSName.Text = ""
                txtSourceCRSAuthor.Text = ""
                txtSourceCRSCode.Text = ""
                txtSourceCRSDeprecated.Text = ""
                txtSourceCRSType.Text = ""
                cmbSourceCRSAliasNames.Items.Clear()
                txtSourceCRSScope.Text = ""
                txtSourceCRSComments.Text = ""
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the Geographic 2D CRS list.

        Dim CRSListFileName As String = Trim(txtGeogr3DCRSListFileName.Text)

        If CRSListFileName = "" Then
            Main.Message.AddWarning("Please enter a file name for the Geographic 3D CRS list!" & vbCrLf)
            Exit Sub
        End If

        If CRSListFileName.EndsWith(".Geogr3DCRSList") Then
            'DatumListFileName has correct file extension.
            Main.Geographic3DCRS.ListFileName = CRSListFileName
        Else
            'Add file extension to the file name.
            CRSListFileName &= ".Geogr3DCRSList"
            Main.Geographic3DCRS.ListFileName = CRSListFileName
            txtGeogr3DCRSListFileName.Text = CRSListFileName
        End If

        Main.Project.SaveXmlData(CRSListFileName, Main.Geographic3DCRS.ToXDoc())
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the Geographic 2D CRS list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in Geographic 3D CRS List
        If CurrentRecordNo = Main.Geographic3DCRS.NRecords Then
            'Already at the last record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in Geographic 3D CRS List
        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the Geographic 3D CRS list:
        CurrentRecordNo = Main.Geographic3DCRS.NRecords
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub txtRecordNo_TextChanged(sender As Object, e As EventArgs) Handles txtRecordNo.TextChanged
        Dim NewRecordNo As Integer
        NewRecordNo = Int(Val(txtRecordNo.Text))

        If NewRecordNo < 1 Then
            Exit Sub
        End If

        If NewRecordNo > Main.Geographic3DCRS.NRecords Then
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
        'Find a Geographic 2D CRS list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select a Geographic 3D CRS list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Geographic 3D CRS List | *.Geogr3DCRSList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtGeogr3DCRSListFileName.Text = DataFileName
                    Main.Geographic3DCRS.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.Geographic3DCRS.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.Geographic3DCRS.NRecords
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
                Zip.SelectFileForm.FileExtension = ".Geogr3DCRSList"
                Zip.SelectFileForm.GetFileList()
        End Select
    End Sub

    Private Sub Zip_FileSelected(FileName As String) Handles Zip.FileSelected
        txtGeogr3DCRSListFileName.Text = FileName
        Main.Geographic3DCRS.ListFileName = FileName
        Dim XmlDoc As System.Xml.Linq.XDocument
        Main.Project.DataLocn.ReadXmlData(FileName, XmlDoc)
        Main.Geographic3DCRS.LoadXml(XmlDoc)
        UpdateList()
        txtNRecords.Text = Main.Geographic3DCRS.NRecords
        txtRecordNo.Text = 1
        DisplayListData(1)
    End Sub

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the Geographic3DCRS list from the EPSG database.
        Main.Geographic3DCRS.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.Geographic3DCRS.NRecords
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
        FoundIndex = Main.Geographic3DCRS.List.FindIndex(Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.Geographic3DCRS.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
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
        FoundIndex = Main.Geographic3DCRS.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
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