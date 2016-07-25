Public Class frmGeodeticDatums
    'The Geodetic Datums form is used to create, select and edit geodetic datums.


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

    Private Sub frmGeodeticDatums_Load(sender As Object, e As EventArgs) Handles Me.Load

        RestoreFormSettings()

        cmbPmUnits.Items.Add("Degrees")
        cmbPmUnits.Items.Add("Gradians")
        cmbPmUnits.Items.Add("Sexagesimal DMS")
        cmbPmUnits.Items.Add("Unknown")
        cmbPmUnits.SelectedIndex = 0 'Select the first item

        cmbPmWE.Items.Add("W")
        cmbPmWE.Items.Add("E")
        cmbPmWE.SelectedIndex = 1 'Select "E"

        cmbNLatNS.Items.Add("N")
        cmbNLatNS.Items.Add("S")
        cmbNLatNS.SelectedIndex = 0 'Select "N"

        cmbSLatNS.Items.Add("N")
        cmbSLatNS.Items.Add("S")
        cmbSLatNS.SelectedIndex = 0 'Select "N"

        cmbWLongWE.Items.Add("W")
        cmbWLongWE.Items.Add("E")
        cmbWLongWE.SelectedIndex = 1 'Select "E"

        cmbELongWE.Items.Add("W")
        cmbELongWE.Items.Add("E")
        cmbELongWE.SelectedIndex = 1 'Select "E"

      
        Main.GeodeticDatum.AddUser()
        Main.Ellipsoid.AddUser()
        Main.PrimeMeridian.AddUser()
        Main.AreaOfUse.AddUser()

        UpdateList()
        txtNRecords.Text = Main.GeodeticDatum.NRecords
        txtDatumListFileName.Text = Main.GeodeticDatum.ListFileName
        CurrentRecordNo = 1
        DisplayListData(1)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the form
        Main.GeodeticDatum.RemoveUser()
        Main.Ellipsoid.RemoveUser()
        Main.PrimeMeridian.RemoveUser()
        Main.AreaOfUse.RemoveUser()
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the Geodetic Datum list from the EPSG database.
        Main.GeodeticDatum.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.GeodeticDatum.NRecords
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub UpdateList()
        'Update the list of records in ListBox1
        ListBox1.Items.Clear()
        Dim Index As Integer
        For Index = 0 To Main.GeodeticDatum.NRecords - 1
            ListBox1.Items.Add(Main.GeodeticDatum.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the GeodeticDatum list.

        If RecordNo < 1 Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Geodetic Datum data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.GeodeticDatum.NRecords Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Cannot display Geodetic Datum data. Selected record number is too large." & vbCrLf)
            Exit Sub
        End If

        txtGeodeticDatumName.Text = Main.GeodeticDatum.List(RecordNo - 1).Name
        txtDatumAuthor.Text = Main.GeodeticDatum.List(RecordNo - 1).Author
        txtDatumCode.Text = Main.GeodeticDatum.List(RecordNo - 1).Code
        txtDatumDeprecated.Text = Main.GeodeticDatum.List(RecordNo - 1).Deprecated

        'Update the list of alias names:
        cmbDatumAliasNames.Items.Clear()
        cmbDatumAliasNames.Text = ""
        For Each item As String In Main.GeodeticDatum.List(RecordNo - 1).AliasName
            cmbDatumAliasNames.Items.Add(item)
        Next

        If cmbDatumAliasNames.Items.Count > 0 Then
            cmbDatumAliasNames.SelectedIndex = 0 'Select first item
        End If

        txtDatumComments.Text = Main.GeodeticDatum.List(RecordNo - 1).Comments
        txtDatumOrigin.Text = Main.GeodeticDatum.List(RecordNo - 1).OriginDescription
        txtDatumScope.Text = Main.GeodeticDatum.List(RecordNo - 1).Scope

        'Display ellipsoid data: ------------------------------------------------------------------------------------------------------------
        txtEllipsoidName.Text = Main.GeodeticDatum.List(RecordNo - 1).Ellipsoid.Name
        txtEllipsoidCode.Text = Main.GeodeticDatum.List(RecordNo - 1).Ellipsoid.Code
        txtEllipsoidAuthor.Text = Main.GeodeticDatum.List(RecordNo - 1).Ellipsoid.Author

        Dim EllipsoidMatch = From Ellipsoid In Main.Ellipsoid.List Where Ellipsoid.Author = Main.GeodeticDatum.List(RecordNo - 1).Ellipsoid.Author And Ellipsoid.Code = Main.GeodeticDatum.List(RecordNo - 1).Ellipsoid.Code

        If EllipsoidMatch.Count > 0 Then
            'Update the list of alias names:
            cmbEllipsoidAliasNames.Items.Clear()
            cmbEllipsoidAliasNames.Text = ""
            'For Each item As String In Main.GeodeticDatum.List(RecordNo - 1).Ellipsoid.AliasName
            For Each item As String In EllipsoidMatch(0).AliasName
                cmbEllipsoidAliasNames.Items.Add(item)
            Next

            If cmbEllipsoidAliasNames.Items.Count > 0 Then
                cmbEllipsoidAliasNames.SelectedIndex = 0 'Select first item
            End If

            'txtEllipsoidComments.Text = Main.GeodeticDatum.List(RecordNo - 1).Ellipsoid.Comments
            txtEllipsoidComments.Text = EllipsoidMatch(0).Comments

            'If Main.GeodeticDatum.List(RecordNo - 1).Ellipsoid.EllipsoidParameters = ADVL_Coordinates_Library.Coordinates.Ellipsoid.DefiningParameters.SemiMajorAxis_InverseFlattening Then
            If EllipsoidMatch(0).EllipsoidParameters = ADVL_Coordinates_Library_1.Ellipsoid.DefiningParameters.SemiMajorAxis_InverseFlattening Then
                rbSemiMajorAndInverseFlat.Checked = True
            Else
                rbSemiMajorAndSemiMinor.Checked = True
            End If

            'txtSemiMajorAxis.Text = Main.GeodeticDatum.List(RecordNo - 1).Ellipsoid.SemiMajorAxis
            txtSemiMajorAxis.Text = EllipsoidMatch(0).SemiMajorAxis
            'txtInverseFlattening.Text = Main.GeodeticDatum.List(RecordNo - 1).Ellipsoid.InverseFlattening
            txtInverseFlattening.Text = EllipsoidMatch(0).InverseFlattening
            'txtSemiMinorAxis.Text = Main.GeodeticDatum.List(RecordNo - 1).Ellipsoid.SemiMinorAxis
            txtSemiMinorAxis.Text = EllipsoidMatch(0).SemiMinorAxis
            'txtAxisUnits.Text = Main.GeodeticDatum.List(RecordNo - 1).Ellipsoid.Unit.Name
            txtAxisUnits.Text = EllipsoidMatch(0).Unit.Name
        Else

        End If


        'Display prime meridian data: ------------------------------------------------------------------------------------------------------------
        Dim AngleConvert As New ADVL_Coordinates_Library_1.AngleConvert
        Dim AngleDMS As New ADVL_Coordinates_Library_1.AngleDegMinSec

        txtPrimeMeridianName.Text = Main.GeodeticDatum.List(RecordNo - 1).PrimeMeridian.Name
        txtPmCode.Text = Main.GeodeticDatum.List(RecordNo - 1).PrimeMeridian.Code
        txtPmAuthor.Text = Main.GeodeticDatum.List(RecordNo - 1).PrimeMeridian.Author

        Dim PmMatch = From PrimeMeridian In Main.PrimeMeridian.List Where PrimeMeridian.Author = Main.GeodeticDatum.List(RecordNo - 1).PrimeMeridian.Author And PrimeMeridian.Code = Main.GeodeticDatum.List(RecordNo - 1).PrimeMeridian.Code

        If PmMatch.Count > 0 Then
            'Update the list of alias names:
            cmbPrimeMeridianAliasNames.Items.Clear()
            cmbPrimeMeridianAliasNames.Text = ""
            'For Each item As String In Main.GeodeticDatum.List(RecordNo - 1).PrimeMeridian.AliasName
            For Each item As String In PmMatch(0).AliasName
                cmbPrimeMeridianAliasNames.Items.Add(item)
            Next

            If cmbPrimeMeridianAliasNames.Items.Count > 0 Then
                cmbPrimeMeridianAliasNames.SelectedIndex = 0 'Select first item
            End If

           
            'txtPrimeMeridianComments.Text = Main.GeodeticDatum.List(RecordNo - 1).PrimeMeridian.Comments
            txtPrimeMeridianComments.Text = PmMatch(0).Comments
            'Select Case Main.GeodeticDatum.List(RecordNo - 1).PrimeMeridian.LongitudeUOM
            Select Case PmMatch(0).LongitudeUOM
                Case ADVL_Coordinates_Library_1.PrimeMeridian.LongitudeUnits.Degree
                    For Each item In cmbPmUnits.Items
                        If item.ToString = "Degrees" Then
                            cmbPmUnits.SelectedItem = item
                            txtPmDegrees.Enabled = False
                            txtPmMinutes.Enabled = False
                            txtPmSeconds.Enabled = False
                            cmbPmWE.Enabled = False
                            txtPmDecimalDegrees.Enabled = True
                            'txtPmDecimalDegrees.Text = Main.GeodeticDatum.List(RecordNo - 1).PrimeMeridian.LongitudeFromGreenwich
                            txtPmDecimalDegrees.Text = PmMatch(0).LongitudeFromGreenwich
                            txtPmSexagesimalDegrees.Enabled = False
                            txtPmGrads.Enabled = False
                            txtPmRadians.Enabled = False
                            'AngleConvert.DecimalDegrees = Main.GeodeticDatum.List(RecordNo - 1).PrimeMeridian.LongitudeFromGreenwich
                            AngleConvert.DecimalDegrees = PmMatch(0).LongitudeFromGreenwich
                            AngleConvert.ConvertDecimalDegreeToGradian()
                            txtPmGrads.Text = AngleConvert.Gradians
                            AngleConvert.ConvertDecimalDegreeToRadian()
                            txtPmRadians.Text = AngleConvert.Radians
                            AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                            txtPmSexagesimalDegrees.Text = AngleConvert.SexagesimalDegrees
                            If AngleConvert.DecimalDegrees < 0 Then
                                AngleDMS.DecimalDegreesToDegMinSec(AngleConvert.DecimalDegrees * -1)
                                For Each WEitem In cmbPmWE.Items
                                    If WEitem.ToString = "W" Then
                                        cmbPmWE.SelectedItem = WEitem
                                    End If
                                Next
                            Else
                                AngleDMS.DecimalDegreesToDegMinSec(AngleConvert.DecimalDegrees)
                                For Each WEitem In cmbPmWE.Items
                                    If WEitem.ToString = "E" Then
                                        cmbPmWE.SelectedItem = WEitem
                                    End If
                                Next
                            End If
                            txtPmDegrees.Text = AngleDMS.Degrees
                            txtPmMinutes.Text = AngleDMS.Minutes
                            txtPmSeconds.Text = AngleDMS.Seconds
                            Exit For
                        End If
                    Next
                Case ADVL_Coordinates_Library_1.PrimeMeridian.LongitudeUnits.Gradian
                    For Each item In cmbPmUnits.Items
                        If item.ToString = "Gradians" Then
                            cmbPmUnits.SelectedItem = item
                            txtPmDegrees.Enabled = False
                            txtPmMinutes.Enabled = False
                            txtPmSeconds.Enabled = False
                            cmbPmWE.Enabled = False
                            txtPmDecimalDegrees.Enabled = False
                            txtPmSexagesimalDegrees.Enabled = False
                            txtPmGrads.Enabled = True
                            'txtPmGrads.Text = Main.GeodeticDatum.List(RecordNo - 1).PrimeMeridian.LongitudeFromGreenwich
                            txtPmGrads.Text = PmMatch(0).LongitudeFromGreenwich
                            txtPmRadians.Enabled = False
                            'AngleConvert.Gradians = Main.GeodeticDatum.List(RecordNo - 1).PrimeMeridian.LongitudeFromGreenwich
                            AngleConvert.Gradians = PmMatch(0).LongitudeFromGreenwich
                            AngleConvert.ConvertGradianToDecimalDegree()
                            txtPmDecimalDegrees.Text = AngleConvert.DecimalDegrees
                            AngleConvert.ConvertGradianToRadian()
                            txtPmRadians.Text = AngleConvert.Radians
                            AngleConvert.ConvertGradianToSexagesimalDegree()
                            txtPmSexagesimalDegrees.Text = AngleConvert.SexagesimalDegrees
                            If AngleConvert.DecimalDegrees < 0 Then
                                AngleDMS.DecimalDegreesToDegMinSec(AngleConvert.DecimalDegrees * -1)
                                For Each WEitem In cmbPmWE.Items
                                    If WEitem.ToString = "W" Then
                                        cmbPmWE.SelectedItem = WEitem
                                    End If
                                Next
                            Else
                                AngleDMS.DecimalDegreesToDegMinSec(AngleConvert.DecimalDegrees)
                                For Each WEitem In cmbPmWE.Items
                                    If WEitem.ToString = "E" Then
                                        cmbPmWE.SelectedItem = WEitem
                                    End If
                                Next
                            End If
                            txtPmDegrees.Text = AngleDMS.Degrees
                            txtPmMinutes.Text = AngleDMS.Minutes
                            txtPmSeconds.Text = AngleDMS.Seconds
                            Exit For
                        End If
                    Next
                Case ADVL_Coordinates_Library_1.PrimeMeridian.LongitudeUnits.Sexagesimal_DMS
                    For Each item In cmbPmUnits.Items
                        If item.ToString = "Sexagesimal DMS" Then
                            cmbPmUnits.SelectedItem = item
                            txtPmDegrees.Enabled = False
                            txtPmMinutes.Enabled = False
                            txtPmSeconds.Enabled = False
                            cmbPmWE.Enabled = False
                            txtPmDecimalDegrees.Enabled = False
                            txtPmSexagesimalDegrees.Enabled = True
                            'txtPmSexagesimalDegrees.Text = Main.GeodeticDatum.List(RecordNo - 1).PrimeMeridian.LongitudeFromGreenwich
                            txtPmSexagesimalDegrees.Text = PmMatch(0).LongitudeFromGreenwich
                            txtPmGrads.Enabled = False
                            txtPmRadians.Enabled = False
                            'AngleConvert.SexagesimalDegrees = Main.GeodeticDatum.List(RecordNo - 1).PrimeMeridian.LongitudeFromGreenwich
                            AngleConvert.SexagesimalDegrees = PmMatch(0).LongitudeFromGreenwich
                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                            txtPmDecimalDegrees.Text = AngleConvert.DecimalDegrees
                            AngleConvert.ConvertSexagesimalDegreeToGradian()
                            txtPmGrads.Text = AngleConvert.Gradians
                            AngleConvert.ConvertSexagesimalDegreeToRadian()
                            txtPmRadians.Text = AngleConvert.Radians
                            If AngleConvert.DecimalDegrees < 0 Then
                                AngleDMS.DecimalDegreesToDegMinSec(AngleConvert.DecimalDegrees * -1)
                                For Each WEitem In cmbPmWE.Items
                                    If WEitem.ToString = "W" Then
                                        cmbPmWE.SelectedItem = WEitem
                                    End If
                                Next
                            Else
                                AngleDMS.DecimalDegreesToDegMinSec(AngleConvert.DecimalDegrees)
                                For Each WEitem In cmbPmWE.Items
                                    If WEitem.ToString = "E" Then
                                        cmbPmWE.SelectedItem = WEitem
                                    End If
                                Next
                            End If
                            txtPmDegrees.Text = AngleDMS.Degrees
                            txtPmMinutes.Text = AngleDMS.Minutes
                            txtPmSeconds.Text = AngleDMS.Seconds
                            Exit For
                        End If
                    Next
                Case ADVL_Coordinates_Library_1.PrimeMeridian.LongitudeUnits.Unknown
                    For Each item In cmbPmUnits.Items
                        If item.ToString = "Unknown" Then
                            cmbPmUnits.SelectedItem = item
                            txtPmDegrees.Enabled = False
                            txtPmMinutes.Enabled = False
                            txtPmSeconds.Enabled = False
                            cmbPmWE.Enabled = False
                            txtPmDecimalDegrees.Enabled = False
                            txtPmSexagesimalDegrees.Enabled = False
                            txtPmGrads.Enabled = False
                            txtPmRadians.Enabled = False
                            txtPmDegrees.Text = ""
                            txtPmMinutes.Text = ""
                            txtPmSeconds.Text = ""
                            txtPmDecimalDegrees.Text = ""
                            txtPmSexagesimalDegrees.Text = ""
                            txtPmGrads.Text = ""
                            txtPmRadians.Text = ""
                            Exit For
                        End If
                    Next

            End Select
        Else

        End If
      

        'Display area of use data: ------------------------------------------------------------------------------------------------------------
        'txtAreaOfUseName.Text = Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.Name
        txtAreaOfUseName.Text = Main.GeodeticDatum.List(RecordNo - 1).Area.Name
        'txtAouCode.Text = Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.Code
        txtAouCode.Text = Main.GeodeticDatum.List(RecordNo - 1).Area.Code
        txtAreaAuthor.Text = Main.GeodeticDatum.List(RecordNo - 1).Area.Author

        Dim AreaMatch = From Area In Main.AreaOfUse.List Where Area.Author = Main.GeodeticDatum.List(RecordNo - 1).Area.Author And Area.Code = Main.GeodeticDatum.List(RecordNo - 1).Area.Code

        If AreaMatch.Count > 0 Then
            'Update the list of alias names:
            cmbAouAliasNames.Items.Clear()
            cmbAouAliasNames.Text = ""
            'For Each item As String In Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.AliasName
            For Each item As String In AreaMatch(0).AliasName
                cmbAouAliasNames.Items.Add(item)
            Next

            If cmbAouAliasNames.Items.Count > 0 Then
                cmbAouAliasNames.SelectedIndex = 0 'Select first item
            End If

            'txtAouComments.Text = Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.Comments
            txtAouComments.Text = AreaMatch(0).Comments
            'txtIso2CharCode.Text = Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.IsoA2Code
            txtIso2CharCode.Text = AreaMatch(0).IsoA2Code
            'txtIso3CharCode.Text = Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.IsoA3Code
            txtIso3CharCode.Text = AreaMatch(0).IsoA3Code
            'txtIsoNumericCode.Text = Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.IsoNCode
            txtIsoNumericCode.Text = AreaMatch(0).IsoNCode
            'txtAouDescription.Text = Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.Description
            txtAouDescription.Text = AreaMatch(0).Description

            'Bounding coordinates are stored as decimal degrees referenced to the WGS84 datum.
            'South latitude
            'If Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.SouthLatitude < 0 Then
            If AreaMatch(0).SouthLatitude < 0 Then
                'AngleDMS.DecimalDegreesToDegMinSec(Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.SouthLatitude * -1)
                AngleDMS.DecimalDegreesToDegMinSec(AreaMatch(0).SouthLatitude * -1)
                For Each NSitem In cmbSLatNS.Items
                    If NSitem.ToString = "S" Then
                        cmbSLatNS.SelectedItem = NSitem
                    End If
                Next
            Else
                'AngleDMS.DecimalDegreesToDegMinSec(Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.SouthLatitude)
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
            'If Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.NorthLatitude < 0 Then
            If AreaMatch(0).NorthLatitude < 0 Then
                'AngleDMS.DecimalDegreesToDegMinSec(Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.NorthLatitude * -1)
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
            'If Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.WestLongitude < 0 Then
            If AreaMatch(0).WestLongitude < 0 Then
                'AngleDMS.DecimalDegreesToDegMinSec(Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.WestLongitude * -1)
                AngleDMS.DecimalDegreesToDegMinSec(AreaMatch(0).WestLongitude * -1)
                For Each WEitem In cmbWLongWE.Items
                    If WEitem.ToString = "W" Then
                        cmbWLongWE.SelectedItem = WEitem
                    End If
                Next
            Else
                'AngleDMS.DecimalDegreesToDegMinSec(Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.WestLongitude)
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
            'If Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.EastLongitude < 0 Then
            If AreaMatch(0).EastLongitude < 0 Then
                'AngleDMS.DecimalDegreesToDegMinSec(Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.EastLongitude * -1)
                AngleDMS.DecimalDegreesToDegMinSec(AreaMatch(0).EastLongitude * -1)
                For Each WEitem In cmbELongWE.Items
                    If WEitem.ToString = "W" Then
                        cmbELongWE.SelectedItem = WEitem
                    End If
                Next
            Else
                'AngleDMS.DecimalDegreesToDegMinSec(Main.GeodeticDatum.List(RecordNo - 1).AreaOfUse.EastLongitude)
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
        Else

        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the Geodetic Datum list.

        Dim DatumListFileName As String = Trim(txtDatumListFileName.Text)

        If DatumListFileName = "" Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Please enter a file name for the Geodetic Datum list!" & vbCrLf)
            Exit Sub
        End If

        If DatumListFileName.EndsWith(".GeoDatumList") Then
            'DatumListFileName has correct file extension.
            Main.GeodeticDatum.ListFileName = DatumListFileName
        Else
            'Add file extension to the file name.
            DatumListFileName &= ".GeoDatumList"
            Main.GeodeticDatum.ListFileName = DatumListFileName
            txtDatumListFileName.Text = DatumListFileName
        End If

        Main.Project.SaveXmlData(DatumListFileName, Main.GeodeticDatum.ToXDoc())
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the Geodetic Datum list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in Geodetic Datum List
        If CurrentRecordNo = Main.GeodeticDatum.NRecords Then
            'Already at the last record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in Geodetic Datum List
        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the Geodetic Datum list:
        CurrentRecordNo = Main.GeodeticDatum.NRecords
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub txtRecordNo_TextChanged(sender As Object, e As EventArgs) Handles txtRecordNo.TextChanged
        Dim NewRecordNo As Integer
        NewRecordNo = Int(Val(txtRecordNo.Text))

        If NewRecordNo < 1 Then
            Exit Sub
        End If

        If NewRecordNo > Main.GeodeticDatum.NRecords Then
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
        'Find a Geodetic Datum list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select a Geodetic Datum list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Geodetic Datum List | *.GeoDatumList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtDatumListFileName.Text = DataFileName
                    Main.GeodeticDatum.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.GeodeticDatum.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.GeodeticDatum.NRecords
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
        FoundIndex = Main.GeodeticDatum.List.FindIndex(Function(x) x.Name.Contains(SearchString))
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
        FoundIndex = Main.GeodeticDatum.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.GeodeticDatum.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
            If FoundIndex = -1 Then
                Main.Message.Add("String not found." & vbCrLf)
            Else
                CurrentRecordNo = FoundIndex + 1
            End If
        Else
            Main.Message.Add("At first record in the list." & vbCrLf)
        End If
    End Sub


#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Events - Events that can be triggered by this form." '--------------------------------------------------------------------------------------------------------------------------
#End Region 'Form Events ----------------------------------------------------------------------------------------------------------------------------------------------------------------------

  
 
  

  
   
  
   
   
End Class