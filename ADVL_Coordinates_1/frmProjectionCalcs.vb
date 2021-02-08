Public Class frmProjectionCalcs
    'This form is used to convert between geographic and projected coordinates.

#Region " Variable Declarations - All the variables used in this form and this application." '-------------------------------------------------------------------------------------------------

    Private DataSettings As New List(Of DataType)(5)

    Dim AngleDegMinSec As New ADVL_Coordinates_Library_1.AngleDegMinSec 'Used for converting between decimal degrees and degrees-minutes-seconds
    Dim AngleConvert As New ADVL_Coordinates_Library_1.AngleConvert 'Used for converting between radians, decimal degrees and gradians

    Dim TransverseMercator As New ADVL_Coordinates_Library_1.TransverseMercator

    Dim AutoModeLevel As Integer = 0

    Dim PointNumber() As Integer
    Dim PointDescription() As String
    Dim PointLatitude() As Double
    Dim PointLongitude() As Double

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Properties - All the properties used in this form and this application" '------------------------------------------------------------------------------------------------------------

    Private _currentRecordNo As Integer 'The selected index number of the Projected CRS in the selection combobox.
    Property CurrentRecordNo As Integer
        Get
            Return _currentRecordNo
        End Get
        Set(value As Integer)
            _currentRecordNo = value
            If cmbProjectedCRS.Items.Count >= _currentRecordNo Then
                cmbProjectedCRS.SelectedIndex = _currentRecordNo - 1
            End If
        End Set
    End Property

#End Region 'Properties -----------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Process XML files - Read and write XML files." '-------------------------------------------------------------------------------------------------------------------------------------

    Private Sub SaveFormSettings()
        'Save the form settings in an XML document.

        SavePoints(-1) 'Save all the points in DataGridView1.
        'These will be saved in PointNumber(), PointDescription(), PointLatitude() and PointLongitude().

        Dim settingsData = <?xml version="1.0" encoding="utf-8"?>
                           <!---->
                           <FormSettings>
                               <Left><%= Me.Left %></Left>
                               <Top><%= Me.Top %></Top>
                               <Width><%= Me.Width %></Width>
                               <Height><%= Me.Height %></Height>
                               <!---->
                               <!--CurrentRecordNo is the selected index number of the Projected CRS in the selection combobox.-->
                               <CurrentRecordNo><%= CurrentRecordNo %></CurrentRecordNo>
                               <!---->
                               <!--Settings saved from the DataSettings list:-->
                               <DataSettingsList>
                                   <%= From item In DataSettings _
                                       Select _
                                   <DataSettings>
                                       <DataType><%= item.DataType %></DataType>
                                       <DistanceUnit><%= item.DistanceUnit %></DistanceUnit>
                                       <AngleUnit><%= item.AngleUnit %></AngleUnit>
                                       <ValueDirection><%= item.ValueDirection %></ValueDirection>
                                       <PointNumberWidth><%= item.PointNumberWidth %></PointNumberWidth>
                                       <PointDescriptionWidth><%= item.PointDescriptionWidth %></PointDescriptionWidth>
                                       <PlusMinusWidth><%= item.PlusMinusWidth %></PlusMinusWidth>
                                       <NSWidth><%= item.NSWidth %></NSWidth>
                                       <WEWidth><%= item.WEWidth %></WEWidth>
                                       <NorthSouthWidth><%= item.NorthSouthWidth %></NorthSouthWidth>
                                       <WestEastWidth><%= item.WestEastWidth %></WestEastWidth>
                                       <LongitudeDmsDegreesWidth><%= item.LongitudeDmsDegreesWidth %></LongitudeDmsDegreesWidth>
                                       <LongitudeDmsMinutesWidth><%= item.LongitudeDmsMinutesWidth %></LongitudeDmsMinutesWidth>
                                       <LongitudeDmsSecondsWidth><%= item.LongitudeDmsSecondsWidth %></LongitudeDmsSecondsWidth>
                                       <LatitudeDmsDegreesWidth><%= item.LatitudeDmsDegreesWidth %></LatitudeDmsDegreesWidth>
                                       <LatitudeDmsMinutesWidth><%= item.LatitudeDmsMinutesWidth %></LatitudeDmsMinutesWidth>
                                       <LatitudeDmsSecondsWidth><%= item.LatitudeDmsSecondsWidth %></LatitudeDmsSecondsWidth>
                                       <LongitudeWidth><%= item.LongitudeWidth %></LongitudeWidth>
                                       <LatitudeWidth><%= item.LatitudeWidth %></LatitudeWidth>
                                       <EastingWidth><%= item.EastingWidth %></EastingWidth>
                                       <NorthingWidth><%= item.NorthingWidth %></NorthingWidth>
                                       <DataPosition><%= item.DataPosition %></DataPosition>
                                       <FirstColumnNo><%= item.FirstColumnNo %></FirstColumnNo>
                                   </DataSettings>
                                   %>
                               </DataSettingsList>
                               <!---->
                               <!--The saved points in DataGridView1.-->
                               <!--PointNumber() array:-->
                               <PointNumbers>
                                   <Count><%= PointNumber.Count %></Count>
                                   <%= From item In PointNumber _
                                       Select _
                                       <Value><%= item %></Value>
                                   %>
                               </PointNumbers>
                               <!--PointDescription() array:-->
                               <PointDescriptions>
                                   <Count><%= PointDescription.Count %></Count>
                                   <%= From item In PointDescription _
                                       Select _
                                       <Description><%= item %></Description>
                                   %>
                               </PointDescriptions>
                               <!--PointLatitude() array:-->
                               <PointLatitudes>
                                   <Count><%= PointLatitude.Count %></Count>
                                   <%= From item In PointLatitude _
                                       Select _
                                       <Value><%= item %></Value>
                                   %>
                               </PointLatitudes>
                               <!--PointLongitude() array:-->
                               <PointLongitudes>
                                   <Count><%= PointLongitude.Count %></Count>
                                   <%= From item In PointLongitude _
                                       Select _
                                       <Value><%= item %></Value>
                                   %>
                               </PointLongitudes>
                               <!--The number of rows in DataGridView1:-->
                               <GridRowCount><%= DataGridView1.RowCount %></GridRowCount>
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

            If Settings.<FormSettings>.<CurrentRecordNo>.Value = Nothing Then
                'Form setting not saved.
            Else
                CurrentRecordNo = Settings.<FormSettings>.<CurrentRecordNo>.Value
            End If

            'Restore DataSettings list:
            If IsNothing(Settings.<FormSettings>.<DataSettingsList>) Then
            Else
                Dim DataSettingsItems = From item In Settings.<FormSettings>.<DataSettingsList>.<DataSettings>

                DataSettings.Clear()
                For Each dataItem In DataSettingsItems
                    Dim NewItem As New DataType
                    Select Case dataItem.<DataType>.Value
                        Case "_Nothing"
                            NewItem.DataType = DataType.DataTypes._Nothing
                        Case "Easting_Northing"
                            NewItem.DataType = DataType.DataTypes.Easting_Northing
                        Case "Latitude_Longitude"
                            NewItem.DataType = DataType.DataTypes.Latitude_Longitude
                        Case "Longitude_Latitude"
                            NewItem.DataType = DataType.DataTypes.Longitude_Latitude
                        Case "Northing_Easting"
                            NewItem.DataType = DataType.DataTypes.Northing_Easting
                        Case "Point_Description"
                            NewItem.DataType = DataType.DataTypes.Point_Description
                        Case "Point_Number"
                            NewItem.DataType = DataType.DataTypes.Point_Number
                    End Select
                    'NewItem.DataType = dataItem.<DataType>.Value
                    Select Case dataItem.<DistanceUnit>.Value
                        Case "_Default"
                            NewItem.DistanceUnit = DataType.DistanceUnits._Default
                        Case "Metres"
                            NewItem.DistanceUnit = DataType.DistanceUnits.Metres
                    End Select
                    'NewItem.DistanceUnit = dataItem.<DistanceUnit>.Value
                    Select Case dataItem.<AngleUnit>.Value
                        Case "Decimal_Degrees"
                            NewItem.AngleUnit = DataType.AngleUnits.Decimal_Degrees
                        Case "Degrees_Minutes_Seconds"
                            NewItem.AngleUnit = DataType.AngleUnits.Degrees_Minutes_Seconds
                        Case "Gradians"
                            NewItem.AngleUnit = DataType.AngleUnits.Gradians
                        Case "Radians"
                            NewItem.AngleUnit = DataType.AngleUnits.Radians
                        Case "Sexagesimal_Degrees"
                            NewItem.AngleUnit = DataType.AngleUnits.Sexagesimal_Degrees
                        Case "Turns"
                            NewItem.AngleUnit = DataType.AngleUnits.Turns
                    End Select
                    'NewItem.AngleUnit = dataItem.<AngleUnit>.Value
                    Select Case dataItem.<ValueDirection>.Value
                        Case "E_W_N_S"
                            NewItem.ValueDirection = DataType.ValueDirections.E_W_N_S
                        Case "East_West_North_South"
                            NewItem.ValueDirection = DataType.ValueDirections.East_West_North_South
                        Case "Plus_Minus"
                            NewItem.ValueDirection = DataType.ValueDirections.Plus_Minus
                    End Select
                    'NewItem.ValueDirection = dataItem.<ValueDirection>.Value
                    Dim MinimumWidth As Integer = 30
                    NewItem.PointNumberWidth = dataItem.<PointNumberWidth>.Value
                    If NewItem.PointNumberWidth < MinimumWidth Then NewItem.PointNumberWidth = MinimumWidth
                    NewItem.PointDescriptionWidth = dataItem.<PointDescriptionWidth>.Value
                    If NewItem.PointDescriptionWidth < MinimumWidth Then NewItem.PointDescriptionWidth = MinimumWidth
                    NewItem.PlusMinusWidth = dataItem.<PlusMinusWidth>.Value
                    If NewItem.PlusMinusWidth < MinimumWidth Then NewItem.PlusMinusWidth = MinimumWidth
                    NewItem.NSWidth = dataItem.<NSWidth>.Value
                    If NewItem.NSWidth < MinimumWidth Then NewItem.NSWidth = MinimumWidth
                    NewItem.WEWidth = dataItem.<WEWidth>.Value
                    If NewItem.WEWidth < MinimumWidth Then NewItem.WEWidth = MinimumWidth
                    NewItem.NorthSouthWidth = dataItem.<NorthSouthWidth>.Value
                    If NewItem.NorthSouthWidth < MinimumWidth Then NewItem.NorthSouthWidth = MinimumWidth
                    NewItem.WestEastWidth = dataItem.<WestEastWidth>.Value
                    If NewItem.WestEastWidth < MinimumWidth Then NewItem.WestEastWidth = MinimumWidth
                    NewItem.LongitudeDmsDegreesWidth = dataItem.<LongitudeDmsDegreesWidth>.Value
                    If NewItem.LongitudeDmsDegreesWidth < MinimumWidth Then NewItem.LongitudeDmsDegreesWidth = MinimumWidth
                    NewItem.LongitudeDmsMinutesWidth = dataItem.<LongitudeDmsMinutesWidth>.Value
                    If NewItem.LongitudeDmsMinutesWidth < MinimumWidth Then NewItem.LongitudeDmsMinutesWidth = MinimumWidth
                    NewItem.LongitudeDmsSecondsWidth = dataItem.<LongitudeDmsSecondsWidth>.Value
                    If NewItem.LongitudeDmsSecondsWidth < MinimumWidth Then NewItem.LongitudeDmsSecondsWidth = MinimumWidth
                    NewItem.LatitudeDmsDegreesWidth = dataItem.<LatitudeDmsDegreesWidth>.Value
                    If NewItem.LatitudeDmsDegreesWidth < MinimumWidth Then NewItem.LatitudeDmsDegreesWidth = MinimumWidth
                    NewItem.LatitudeDmsMinutesWidth = dataItem.<LatitudeDmsMinutesWidth>.Value
                    If NewItem.LatitudeDmsMinutesWidth < MinimumWidth Then NewItem.LatitudeDmsMinutesWidth = MinimumWidth
                    NewItem.LatitudeDmsSecondsWidth = dataItem.<LatitudeDmsSecondsWidth>.Value
                    If NewItem.LatitudeDmsSecondsWidth < MinimumWidth Then NewItem.LatitudeDmsSecondsWidth = MinimumWidth
                    NewItem.LongitudeWidth = dataItem.<LongitudeWidth>.Value
                    If NewItem.LongitudeWidth < MinimumWidth Then NewItem.LongitudeWidth = MinimumWidth
                    NewItem.LatitudeWidth = dataItem.<LatitudeWidth>.Value
                    If NewItem.LatitudeWidth < MinimumWidth Then NewItem.LatitudeWidth = MinimumWidth
                    NewItem.EastingWidth = dataItem.<EastingWidth>.Value
                    If NewItem.EastingWidth < MinimumWidth Then NewItem.EastingWidth = MinimumWidth
                    NewItem.NorthingWidth = dataItem.<NorthingWidth>.Value
                    If NewItem.NorthingWidth < MinimumWidth Then NewItem.NorthingWidth = MinimumWidth
                    NewItem.DataPosition = dataItem.<DataPosition>.Value
                    If NewItem.DataPosition < MinimumWidth Then NewItem.DataPosition = MinimumWidth
                    NewItem.FirstColumnNo = dataItem.<FirstColumnNo>.Value
                    If NewItem.FirstColumnNo < MinimumWidth Then NewItem.FirstColumnNo = MinimumWidth
                    DataSettings.Add(NewItem)
                Next
            End If

            'Restore PointNumber() array:
            If IsNothing(Settings.<FormSettings>.<PointNumbers>) Then
            Else
                Dim PointNumberCount As Integer = Settings.<FormSettings>.<PointNumbers>.<Count>.Value
                ReDim PointNumber(PointNumberCount - 1)
                Dim PointNumberItems = From item In Settings.<FormSettings>.<PointNumbers>.<Value>
                For I = 0 To PointNumberItems.Count - 1
                    PointNumber(I) = PointNumberItems(I).Value
                Next
            End If

            'Restore PointDescription() array:
            If IsNothing(Settings.<FormSettings>.<PointDescriptions>) Then
            Else
                Dim PointDescriptionCount As Integer = Settings.<FormSettings>.<PointDescriptions>.<Count>.Value
                ReDim PointDescription(PointDescriptionCount - 1)
                Dim PointDescriptionItems = From item In Settings.<FormSettings>.<PointDescriptions>.<Description>
                For I = 0 To PointDescriptionItems.Count - 1
                    PointDescription(I) = PointDescriptionItems(I).Value
                Next
            End If

            'Restore PointLatitude() array:
            If IsNothing(Settings.<FormSettings>.<PointLatitudes>) Then
            Else
                Dim PointLatitudeCount As Integer = Settings.<FormSettings>.<PointLatitudes>.<Count>.Value
                ReDim PointLatitude(PointLatitudeCount - 1)
                Dim PointLatitudeItems = From item In Settings.<FormSettings>.<PointLatitudes>.<Value>
                For I = 0 To PointLatitudeItems.Count - 1
                    PointLatitude(I) = PointLatitudeItems(I).Value
                Next
            End If

            'Restore PointLongitude() array:
            If IsNothing(Settings.<FormSettings>.<PointLongitudes>) Then
            Else
                Dim PointLongitudeCount As Integer = Settings.<FormSettings>.<PointLongitudes>.<Count>.Value
                ReDim PointLongitude(PointLongitudeCount - 1)
                Dim PointLongitudeItems = From item In Settings.<FormSettings>.<PointLongitudes>.<Value>
                For I = 0 To PointLongitudeItems.Count - 1
                    PointLongitude(I) = PointLongitudeItems(I).Value
                Next
            End If
            'Restore DataGridView1.RowCount:
            If IsNothing(Settings.<FormSettings>.<GridRowCount>.Value) Then

            Else
                DataGridView1.RowCount = Settings.<FormSettings>.<GridRowCount>.Value
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

    Private Sub frmProjectionCalcs_Load(sender As Object, e As EventArgs) Handles Me.Load

        Main.ProjectedCRS.AddUser()
        Main.Projection.AddUser()
        Main.CoordRefSystem.AddUser()
        Main.Geographic2DCRS.AddUser()
        Main.GeodeticDatum.AddUser()
        Main.Ellipsoid.AddUser()

        'Fill the list of Projected CRS: cmbProjectedCRS
        Dim I As Integer
        Dim NRecords As Integer
        NRecords = Main.ProjectedCRS.NRecords
        For I = 0 To NRecords - 1
            cmbProjectedCRS.Items.Add(Main.ProjectedCRS.List(I).Name)
        Next
        If cmbProjectedCRS.Items.Count >= CurrentRecordNo Then
            cmbProjectedCRS.SelectedIndex = CurrentRecordNo - 1
        End If

        Dim dgvColHeaderStyle As New DataGridViewCellStyle
        dgvColHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvColHeaderStyle.WrapMode = DataGridViewTriState.True 'This mode allows multi-line header text.
        DataGridView1.ColumnHeadersDefaultCellStyle = dgvColHeaderStyle

        InitialiseDataSettingsArray() 'Sets the initial data types, units and width for each data column.

        DataSettings(0).DataType = DataType.DataTypes.Point_Number
        DataSettings(1).DataType = DataType.DataTypes.Point_Description
        DataSettings(2).DataType = DataType.DataTypes.Latitude_Longitude
        DataSettings(3).DataType = DataType.DataTypes.Easting_Northing
        DataSettings(4).DataType = DataType.DataTypes._Nothing
        DataSettings(5).DataType = DataType.DataTypes._Nothing

        DataGridView1.ColumnCount = 4
        DataGridView1.Columns(0).HeaderText = "Latitude" & vbCrLf & "(Decimal deg)"
        DataGridView1.Columns(0).Width = 120
        DataGridView1.Columns(1).HeaderText = "Longitude" & vbCrLf & "(Decimal deg)"
        DataGridView1.Columns(1).DividerWidth = 2
        DataGridView1.Columns(1).Width = 120

        DataGridView1.Columns(2).HeaderText = "Easting" & vbCrLf & "(m)"
        DataGridView1.Columns(2).Width = 120
        DataGridView1.Columns(3).HeaderText = "Northing" & vbCrLf & "(m)"
        DataGridView1.Columns(3).Width = 120

        DataGridView1.RowHeadersWidth = 60 'The leftmost column in DataGridView1. This width is set wide enough so the CRS headers are clear of the "Data Type", "Units" and "Direction" labels.

        ResizeGridCRSHeaders()

        cmbDataType1.Items.Clear()
        cmbDataType1.Items.Add("Nothing")
        cmbDataType1.Items.Add("Point number")
        cmbDataType1.Items.Add("Point description")
        cmbDataType1.Items.Add("Latitude, Longitude")
        cmbDataType1.Items.Add("Longitude, Latitude")
        cmbDataType1.Items.Add("Easting, Northing")
        cmbDataType1.Items.Add("Northing, Easting")
        cmbDataType1.SelectedIndex = 1

        cmbDataType2.Items.Clear()
        cmbDataType2.Items.Add("Nothing")
        cmbDataType2.Items.Add("Point number")
        cmbDataType2.Items.Add("Point description")
        cmbDataType2.Items.Add("Latitude, Longitude")
        cmbDataType2.Items.Add("Longitude, Latitude")
        cmbDataType2.Items.Add("Easting, Northing")
        cmbDataType2.Items.Add("Northing, Easting")
        cmbDataType2.SelectedIndex = 2

        cmbDataType3.Items.Clear()
        cmbDataType3.Items.Add("Nothing")
        cmbDataType3.Items.Add("Point number")
        cmbDataType3.Items.Add("Point description")
        cmbDataType3.Items.Add("Latitude, Longitude")
        cmbDataType3.Items.Add("Longitude, Latitude")
        cmbDataType3.Items.Add("Easting, Northing")
        cmbDataType3.Items.Add("Northing, Easting")
        cmbDataType3.SelectedIndex = 3

        cmbDataType4.Items.Clear()
        cmbDataType4.Items.Add("Nothing")
        cmbDataType4.Items.Add("Point number")
        cmbDataType4.Items.Add("Point description")
        cmbDataType4.Items.Add("Latitude, Longitude")
        cmbDataType4.Items.Add("Longitude, Latitude")
        cmbDataType4.Items.Add("Easting, Northing")
        cmbDataType4.Items.Add("Northing, Easting")
        cmbDataType4.SelectedIndex = 6

        cmbDataType5.Items.Clear()
        cmbDataType5.Items.Add("Nothing")
        cmbDataType5.Items.Add("Point number")
        cmbDataType5.Items.Add("Point description")
        cmbDataType5.Items.Add("Latitude, Longitude")
        cmbDataType5.Items.Add("Longitude, Latitude")
        cmbDataType5.Items.Add("Easting, Northing")
        cmbDataType5.Items.Add("Northing, Easting")
        cmbDataType5.SelectedIndex = 0

        cmbDataType6.Items.Clear()
        cmbDataType6.Items.Add("Nothing")
        cmbDataType6.Items.Add("Point number")
        cmbDataType6.Items.Add("Point description")
        cmbDataType6.Items.Add("Latitude, Longitude")
        cmbDataType6.Items.Add("Longitude, Latitude")
        cmbDataType6.Items.Add("Easting, Northing")
        cmbDataType6.Items.Add("Northing, Easting")
        cmbDataType6.SelectedIndex = 0

        cmbDirection1.Items.Clear()
        cmbDirection1.Items.Add("+/-")
        cmbDirection1.Items.Add("E/W_N/S")
        cmbDirection1.Items.Add("East/West_North/South")
        cmbDirection1.SelectedIndex = 0

        cmbDirection2.Items.Clear()
        cmbDirection2.Items.Add("+/-")
        cmbDirection2.Items.Add("E/W_N/S")
        cmbDirection2.Items.Add("East/West_North/South")
        cmbDirection2.SelectedIndex = 0

        cmbDirection3.Items.Clear()
        cmbDirection3.Items.Add("+/-")
        cmbDirection3.Items.Add("E/W_N/S")
        cmbDirection3.Items.Add("East/West_North/South")
        cmbDirection3.SelectedIndex = 0

        cmbDirection4.Items.Clear()
        cmbDirection4.Items.Add("+/-")
        cmbDirection4.Items.Add("E/W_N/S")
        cmbDirection4.Items.Add("East/West_North/South")
        cmbDirection4.SelectedIndex = 0

        cmbDirection5.Items.Clear()
        cmbDirection5.Items.Add("+/-")
        cmbDirection5.Items.Add("E/W_N/S")
        cmbDirection5.Items.Add("East/West_North/South")
        cmbDirection5.SelectedIndex = 0

        cmbDirection6.Items.Clear()
        cmbDirection6.Items.Add("+/-")
        cmbDirection6.Items.Add("E/W_N/S")
        cmbDirection6.Items.Add("East/West_North/South")
        cmbDirection6.SelectedIndex = 0

        RestoreFormSettings()

        UpdateDataGridView()
        RestorePoints()

    End Sub

    Private Sub InitialiseDataSettingsArray()
        'Initialise DataSettings()

        Dim I As Integer ' Loop Index

        For I = 0 To 5
            Dim NewDataSettings As New DataType
            NewDataSettings.DataType = DataType.DataTypes._Nothing
            NewDataSettings.DistanceUnit = DataType.DistanceUnits.Metres
            NewDataSettings.AngleUnit = DataType.AngleUnits.Decimal_Degrees
            NewDataSettings.EastingWidth = 120
            NewDataSettings.NorthingWidth = 120
            NewDataSettings.LatitudeDmsDegreesWidth = 80
            NewDataSettings.LatitudeDmsMinutesWidth = 80
            NewDataSettings.LatitudeDmsSecondsWidth = 120
            NewDataSettings.LongitudeDmsDegreesWidth = 80
            NewDataSettings.LongitudeDmsMinutesWidth = 80
            NewDataSettings.LongitudeDmsSecondsWidth = 120
            NewDataSettings.LatitudeWidth = 120
            NewDataSettings.LongitudeWidth = 120
            NewDataSettings.PointDescriptionWidth = 200
            NewDataSettings.PointNumberWidth = 90

            DataSettings.Add(NewDataSettings)
        Next
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'SaveFormSettings() 'Form settings are now save when the form is closing and the WindowState is normal (not minimised).

        Main.ProjectedCRS.RemoveUser()
        Main.Projection.RemoveUser()
        Main.CoordRefSystem.RemoveUser()
        Main.Geographic2DCRS.RemoveUser()
        Main.GeodeticDatum.RemoveUser()
        Main.Ellipsoid.RemoveUser()

        Me.Close()
    End Sub

    Private Sub frmProjectionCalcs_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If WindowState = FormWindowState.Normal Then
            SaveFormSettings()
        End If
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub ResizeGridCRSHeaders()
        'Resize the Geographic CRS taxt box and the Projected CRS text box.
        txtDescr1.Left = DataGridView1.Left + DataGridView1.RowHeadersWidth
        txtDescr1.Top = DataGridView1.Top - 22
        txtDescr1.Width = DataGridView1.Columns(0).Width + DataGridView1.Columns(1).Width
        txtDescr2.Left = txtDescr1.Left + txtDescr1.Width + 2
        txtDescr2.Top = DataGridView1.Top - 22
        txtDescr2.Width = DataGridView1.Columns(2).Width + DataGridView1.Columns(3).Width
    End Sub

    Private Sub UpdateDataGridView()
        'Update the DataGridView1 to match the settings in DataSettings().

        Dim NCols As Integer

        NCols = DataSettings(0).NColumns + DataSettings(1).NColumns + DataSettings(2).NColumns + DataSettings(3).NColumns + DataSettings(4).NColumns + DataSettings(5).NColumns

        DataGridView1.ColumnCount = NCols

        'Process each data position in DataSettings()
        Dim I As Integer 'Loop index
        Dim GridColumnNo As Integer = 0 'GridColumnNo is the number of the column in DataGridView
        For I = 0 To 5
            Select Case DataSettings(I).DataType
                Case DataType.DataTypes._Nothing 'Data Type is Nothing

                Case DataType.DataTypes.Point_Number 'Data Type is Point Number
                    DataGridView1.Columns(GridColumnNo).HeaderText = "Point" & vbCrLf & "Number"
                    DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).PointNumberWidth
                    DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                    GridColumnNo += 1
                Case DataType.DataTypes.Point_Description 'Data Type is Point Description
                    DataGridView1.Columns(GridColumnNo).HeaderText = "Point" & vbCrLf & "Description"
                    DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).PointDescriptionWidth
                    DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                    GridColumnNo += 1
                Case DataType.DataTypes.Latitude_Longitude 'Data Type is Latitude_Longitude
                    Select Case DataSettings(I).AngleUnit
                        Case DataType.AngleUnits.Decimal_Degrees 'Latitude_Longitude in Decimal Degrees -------------------------------------------------------------------------------------
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then '| +/- | Latitude Dec Deg
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "(Decimal Degrees)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeWidth
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                            Else
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                            End If
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| N/S |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "N/S"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| North/South |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "North/" & vbCrLf & "South"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            End If
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then '| +/- | Longitude Dec Deg
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "(Decimal Degrees)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeWidth
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                            Else
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                            End If
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| E/W |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "E/W"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).WEWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| East/West |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "East/" & vbCrLf & "West"
                                DataGridView1.Columns(GridColumnNo).Width = 60
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            End If
                        Case DataType.AngleUnits.Degrees_Minutes_Seconds 'Latitude_Longitude in Deg Min Sec --------------------------------------------------------------------------------------------
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Latitude Deg | Min | Sec |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "+/-"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).PlusMinusWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                                GridColumnNo += 1
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "Degrees"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeDmsDegreesWidth
                            DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                            GridColumnNo += 1
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "Minutes"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeDmsMinutesWidth
                            DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                            GridColumnNo += 1
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "Seconds"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeDmsSecondsWidth
                            DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| N/S |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "N/S"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1 'Thin divider between Lat and Long
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| North/South |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "North/" & vbCrLf & "South"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1 'Thin divider between Lat and Long
                                GridColumnNo += 1
                            End If
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then '| +/- | Longitude Deg | Min | Sec |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "+/-"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).PlusMinusWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                                GridColumnNo += 1
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "Degrees"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeDmsDegreesWidth
                            DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                            GridColumnNo += 1
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "Minutes"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeDmsMinutesWidth
                            DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                            GridColumnNo += 1
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "Seconds"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeDmsSecondsWidth
                            DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| E/W |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "E/W"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2 'Wide divider at the end of Lat Long pair
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| East/West |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "East/" & vbCrLf & "West"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2 'Wide divider at the end of Lat Long pair
                                GridColumnNo += 1
                            End If
                        Case DataType.AngleUnits.Gradians 'Latitude_Longitude in Gradians -----------------------------------------------------------------------------------------------------------
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Latitude Gradians
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "(Gradians)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeWidth
                            DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| N/S |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "N/S"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| North/South |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "North/" & vbCrLf & "South"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            End If
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Longitude Gradians
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "(Gradians)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeWidth
                            DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| E/W |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "E/W"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| East/West |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "East/" & vbCrLf & "West"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            End If
                        Case DataType.AngleUnits.Radians 'Latitude_Longitude in Radians ------------------------------------------------------------------------------------------------------------
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Latitude Radians
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "(Radians)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeWidth
                            DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| N/S |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "N/S"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| North/South |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "North/" & vbCrLf & "South"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            End If
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Longitude Radians
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "(Radians)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeWidth
                            DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| E/W |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "E/W"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| East/West |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "East/" & vbCrLf & "West"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            End If
                        Case DataType.AngleUnits.Sexagesimal_Degrees 'Latitude_Longitude in Sexagesimal Degrees ------------------------------------------------------------------------------------------------
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Latitude Sexagesimal
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "(Sexagesimal Degrees)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeWidth
                            DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| N/S |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "N/S"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| North/South |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "North/" & vbCrLf & "South"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            End If
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Longitude Sexagesimal
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "(Sexagesimal Degrees)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeWidth
                            DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| E/W |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "E/W"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| East/West |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "East/" & vbCrLf & "West"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            End If
                        Case DataType.AngleUnits.Turns 'Latitude_Longitude in Turns ----------------------------------------------------------------------------------------------------------------
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Latitude Turns
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "(Turns)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeWidth
                            DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| N/S |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "N/S"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| North/South |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "North/" & vbCrLf & "South"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            End If
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Longitude Turns
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "(Turns)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeWidth
                            DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| E/W |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "E/W"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| East/West |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "East/" & vbCrLf & "West"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            End If
                    End Select
                Case DataType.DataTypes.Longitude_Latitude  'Data Type is Longitude_Latitude
                    Select Case DataSettings(I).AngleUnit
                        Case DataType.AngleUnits.Decimal_Degrees 'Longitude_Latitude in Decimal Degrees--------------------------------------------------------------------------------------------------------------
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Longitude Dec Deg
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "(Decimal Degrees)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeWidth
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                            Else
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                            End If

                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| E/W |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "E/W"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| East/West |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "East/" & vbCrLf & "West"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            End If
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Latitude Dec Deg
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "(Decimal Degrees)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeWidth
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                            Else
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                            End If

                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| N/S |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "N/S"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| North/South |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "North/" & vbCrLf & "South"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            End If
                        Case DataType.AngleUnits.Degrees_Minutes_Seconds 'Longitude_Latitude in Deg Min Sec ---------------------------------------------------------------------------------------------------------
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Longitude Deg | Min | Sec |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "+/-"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).PlusMinusWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                                GridColumnNo += 1
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "Degrees"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeDmsDegreesWidth
                            GridColumnNo += 1
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "Minutes"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeDmsMinutesWidth
                            GridColumnNo += 1
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "Seconds"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeDmsSecondsWidth
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| E/W |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "E/W"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| East/West |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "East/" & vbCrLf & "West"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            End If
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Latitude Deg | Min | Sec |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "+/-"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).PlusMinusWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 0
                                GridColumnNo += 1
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "Degrees"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeDmsDegreesWidth
                            GridColumnNo += 1
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "Minutes"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeDmsMinutesWidth
                            GridColumnNo += 1
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "Seconds"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeDmsSecondsWidth
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| N/S |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "N/S"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| North/South |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "North/" & vbCrLf & "South"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            End If
                        Case DataType.AngleUnits.Gradians 'Longitude_Latitude in Gradians ----------------------------------------------------------------------------------------------------------------------
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Longitude Gradians
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "(Gradians)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeWidth
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| E/W |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "E/W"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).WEWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| East/West |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "East/" & vbCrLf & "West"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).WestEastWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            End If
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Latitude Gradians
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "(Gradians)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeWidth
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| N/S |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "N/S"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| North/South |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "North/" & vbCrLf & "South"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            End If
                        Case DataType.AngleUnits.Radians 'Longitude_Latitude in Radians ------------------------------------------------------------------------------------------------------------------------
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Longitude Radians
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "(Radians)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeWidth
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| E/W |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "E/W"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| East/West |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "East/" & vbCrLf & "West"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            End If
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Latitude Radians
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "(Radians)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeWidth
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| N/S |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "N/S"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| North/South |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "North/" & vbCrLf & "South"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            End If
                        Case DataType.AngleUnits.Sexagesimal_Degrees 'Longitude_Latitude in Sexagesimal Degrees -----------------------------------------------------------------------------------------------------------
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Longitude Sexagesimal Deg
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "(Sexagesimal Degrees)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeWidth
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| E/W |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "E/W"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| East/West |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "East/" & vbCrLf & "West"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            End If
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Latitude Sexagesimal Deg
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "(Sexagesimal Degrees)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeWidth
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| N/S |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "N/S"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| North/South |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "North/" & vbCrLf & "South"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            End If
                        Case DataType.AngleUnits.Turns 'Longitude_Latitude in Turns ------------------------------------------------------------------------------------------------------------------------
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Longitude Sexagesiam Deg
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Longitude" & vbCrLf & "(Turns)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LongitudeWidth
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| E/W |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "E/W"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| East/West |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "East/" & vbCrLf & "West"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 2
                                GridColumnNo += 1
                            End If
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.Plus_Minus Then  '| +/- | Latitude
                                'UPDATE: Don't add an separate column to show +/-. The sign is now included in the value column.
                            End If
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Latitude" & vbCrLf & "(Turns)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).LatitudeWidth
                            GridColumnNo += 1
                            If DataSettings(I).ValueDirection = DataType.ValueDirections.E_W_N_S Then '| N/S |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "N/S"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NSWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            ElseIf DataSettings(I).ValueDirection = DataType.ValueDirections.East_West_North_South Then '| North/South |
                                DataGridView1.Columns(GridColumnNo).HeaderText = "North/" & vbCrLf & "South"
                                DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthSouthWidth
                                DataGridView1.Columns(GridColumnNo).DividerWidth = 1
                                GridColumnNo += 1
                            End If
                    End Select
                Case DataType.DataTypes.Northing_Easting 'Data Type is Northing_Easting
                    Select Case DataSettings(I).DistanceUnit
                        Case DataType.DistanceUnits.Metres 'Northing_Easting in Metres -------------------------------------------------------------------------------------------------------------------------
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Northing" & vbCrLf & "(Metres)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthingWidth
                            GridColumnNo += 1
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Easting" & vbCrLf & "(Metres)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).EastingWidth
                            GridColumnNo += 1
                        Case DataType.DistanceUnits._Default 'Northing_Easting in Default Units ---------------------------------------------------------------------------------------------------------------------------
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Northing" & vbCrLf & "(" & TransverseMercator.Projection.DistanceUnits & ")"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthingWidth
                            GridColumnNo += 1
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Easting" & vbCrLf & "(" & TransverseMercator.Projection.DistanceUnits & ")"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).EastingWidth
                            GridColumnNo += 1
                    End Select
                Case DataType.DataTypes.Easting_Northing 'Data Type is Easting_Northing
                    Select Case DataSettings(I).DistanceUnit
                        Case DataType.DistanceUnits.Metres 'Easting_Northing in Metres -------------------------------------------------------------------------------------------------------------------------
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Easting" & vbCrLf & "(Metres)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).EastingWidth
                            GridColumnNo += 1
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Northing" & vbCrLf & "(Metres)"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthingWidth
                            GridColumnNo += 1
                        Case DataType.DistanceUnits._Default 'Easting_Northing in Default Units ---------------------------------------------------------------------------------------------------------------------------
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Easting" & vbCrLf & "(" & TransverseMercator.Projection.DistanceUnits & ")"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).EastingWidth
                            GridColumnNo += 1
                            DataGridView1.Columns(GridColumnNo).HeaderText = "Northing" & vbCrLf & "(" & TransverseMercator.Projection.DistanceUnits & ")"
                            DataGridView1.Columns(GridColumnNo).Width = DataSettings(I).NorthingWidth
                            GridColumnNo += 1
                    End Select
            End Select
        Next

        'Update DataSettings()
        Dim MinWidth As Integer = 80 'The minimum width of a data position.
        DataSettings(0).DataPosition = DataGridView1.RowHeadersWidth 'The first data position should be located after the row headers.
        DataSettings(0).FirstColumnNo = 0
        DataSettings(1).DataPosition = DataSettings(0).DataPosition + DataSettings(0).DataWidth
        DataSettings(1).FirstColumnNo = DataSettings(0).FirstColumnNo + DataSettings(0).NColumns
        If DataSettings(0).DataWidth = 0 Then
            DataSettings(1).DataPosition += MinWidth 'MinWidth sets the minimum width of the data labels above DataGridView. This is set to a value large enough for the labels to be read.
        End If
        DataSettings(2).DataPosition = DataSettings(1).DataPosition + DataSettings(1).DataWidth
        DataSettings(2).FirstColumnNo = DataSettings(1).FirstColumnNo + DataSettings(1).NColumns
        If DataSettings(1).DataWidth = 0 Then
            DataSettings(2).DataPosition += MinWidth
        End If
        DataSettings(3).DataPosition = DataSettings(2).DataPosition + DataSettings(2).DataWidth
        DataSettings(3).FirstColumnNo = DataSettings(2).FirstColumnNo + DataSettings(2).NColumns
        If DataSettings(2).DataWidth = 0 Then
            DataSettings(3).DataPosition += MinWidth
        End If
        DataSettings(4).DataPosition = DataSettings(3).DataPosition + DataSettings(3).DataWidth
        DataSettings(4).FirstColumnNo = DataSettings(3).FirstColumnNo + DataSettings(3).NColumns
        If DataSettings(3).DataWidth = 0 Then
            DataSettings(4).DataPosition += MinWidth
        End If
        DataSettings(5).DataPosition = DataSettings(4).DataPosition + DataSettings(4).DataWidth
        DataSettings(5).FirstColumnNo = DataSettings(4).FirstColumnNo + DataSettings(4).NColumns
        If DataSettings(4).DataWidth = 0 Then
            DataSettings(5).DataPosition += MinWidth
        End If

        'Update Data labels:
        Dim LabelRowTop As Integer = txtDescr1.Location.Y '186 UPDATE: 165
        Dim LabelX As Integer
        LabelX = DataSettings(0).DataPosition + DataGridView1.Location.X
        txtDescr1.Location = New Point(LabelX, LabelRowTop)
        txtDescr1.Width = DataSettings(0).DataWidth
        cmbDirection1.Location = New Point(LabelX, LabelRowTop - 20) '145

        cmbDirection1.Width = DataSettings(0).DataWidth
        cmbUnits1.Location = New Point(LabelX, LabelRowTop - 40) '125

        cmbUnits1.Width = DataSettings(0).DataWidth
        cmbDataType1.Location = New Point(LabelX, LabelRowTop - 60) '105

        AutoModeLevel += 1 'Increment the AutoMode level. This indicates that the following changes to DataGridView1 are being made automatically.

        cmbDataType1.Width = DataSettings(0).DataWidth
        If cmbDataType1.Width = 0 Then
            cmbDataType1.Width = MinWidth
        End If
        If DataSettings(0).DataType = DataType.DataTypes.Latitude_Longitude Then
            txtDescr1.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).SourceGeographicCRS.Name
            txtDescr1.Visible = True
            cmbDataType1.Text = "Latitude, Longitude"
            Select Case DataSettings(0).AngleUnit
                Case DataType.AngleUnits.Decimal_Degrees
                    cmbUnits1.Text = "Decimal Degrees"
                Case DataType.AngleUnits.Degrees_Minutes_Seconds
                    cmbUnits1.Text = "Degrees Minutes Seconds"
                Case DataType.AngleUnits.Gradians
                    cmbUnits1.Text = "Gradians"
                Case DataType.AngleUnits.Radians
                    cmbUnits1.Text = "Radians"
                Case DataType.AngleUnits.Sexagesimal_Degrees
                    cmbUnits1.Text = "Sexagesimal Degrees"
                Case DataType.AngleUnits.Turns
                    cmbUnits1.Text = "Turns"
            End Select
            cmbDirection1.Enabled = True
            Select Case DataSettings(0).ValueDirection
                Case DataType.ValueDirections.E_W_N_S
                    cmbDirection1.Text = "E/W_N/S"
                Case DataType.ValueDirections.East_West_North_South
                    cmbDirection1.Text = "East/West_North/South"
                Case DataType.ValueDirections.Plus_Minus
                    cmbDirection1.Text = "+/-"
            End Select
        ElseIf DataSettings(0).DataType = DataType.DataTypes.Longitude_Latitude Then
            txtDescr1.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).SourceGeographicCRS.Name
            txtDescr1.Visible = True
            cmbDataType1.Text = "Longitude, Latitude"
            Select Case DataSettings(0).AngleUnit
                Case DataType.AngleUnits.Decimal_Degrees
                    cmbUnits1.Text = "Decimal Degrees"
                Case DataType.AngleUnits.Degrees_Minutes_Seconds
                    cmbUnits1.Text = "Degrees Minutes Seconds"
                Case DataType.AngleUnits.Gradians
                    cmbUnits1.Text = "Gradians"
                Case DataType.AngleUnits.Radians
                    cmbUnits1.Text = "Radians"
                Case DataType.AngleUnits.Sexagesimal_Degrees
                    cmbUnits1.Text = "Sexagesimal Degrees"
                Case DataType.AngleUnits.Turns
                    cmbUnits1.Text = "Turns"
            End Select
            cmbDirection1.Enabled = True
            Select Case DataSettings(0).ValueDirection
                Case DataType.ValueDirections.E_W_N_S
                    cmbDirection1.Text = "E/W_N/S"
                Case DataType.ValueDirections.East_West_North_South
                    cmbDirection1.Text = "East/West_North/South"
                Case DataType.ValueDirections.Plus_Minus
                    cmbDirection1.Text = "+/-"
            End Select
        ElseIf DataSettings(0).DataType = DataType.DataTypes.Easting_Northing Then
            txtDescr1.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).Name
            txtDescr1.Visible = True
            cmbDataType1.Text = "Easting, Northing"
            Select Case DataSettings(0).DistanceUnit
                Case DataType.DistanceUnits._Default
                    cmbUnits1.Text = "Default"
                Case DataType.DistanceUnits.Metres
                    cmbUnits1.Text = "Metres"
            End Select
            cmbDirection1.Enabled = False
        ElseIf DataSettings(0).DataType = DataType.DataTypes.Northing_Easting Then
            txtDescr1.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).Name
            txtDescr1.Visible = True
            cmbDataType1.Text = "Northing, Easting"
            Select Case DataSettings(0).DistanceUnit
                Case DataType.DistanceUnits._Default
                    cmbUnits1.Text = "Default"
                Case DataType.DistanceUnits.Metres
                    cmbUnits1.Text = "Metres"
            End Select
            cmbDirection1.Enabled = False
        ElseIf DataSettings(0).DataType = DataType.DataTypes.Point_Description Then
            txtDescr1.Visible = False
            cmbDataType1.Text = "Point description"
            cmbUnits1.Text = "Text"
            cmbDirection1.Enabled = False
        ElseIf DataSettings(0).DataType = DataType.DataTypes.Point_Number Then
            txtDescr1.Visible = False
            cmbDataType1.Text = "Point number"
            cmbUnits1.Text = "Number"
            cmbDirection1.Enabled = False
        ElseIf DataSettings(0).DataType = DataType.DataTypes._Nothing Then
            txtDescr1.Visible = False
            cmbDataType1.Text = "Nothing"
            cmbUnits1.Text = "Nothing"
            cmbDirection1.Enabled = False
        End If

        LabelX = DataSettings(1).DataPosition + DataGridView1.Location.X
        txtDescr2.Location = New Point(LabelX, LabelRowTop)
        txtDescr2.Width = DataSettings(1).DataWidth
        cmbDirection2.Location = New Point(LabelX, LabelRowTop - 20)
        cmbDirection2.Width = DataSettings(1).DataWidth
        cmbUnits2.Location = New Point(LabelX, LabelRowTop - 40)
        cmbUnits2.Width = DataSettings(1).DataWidth
        cmbDataType2.Location = New Point(LabelX, LabelRowTop - 60)
        cmbDataType2.Width = DataSettings(1).DataWidth
        If cmbDataType2.Width = 0 Then
            cmbDataType2.Width = MinWidth
        End If
        If DataSettings(1).DataType = DataType.DataTypes.Latitude_Longitude Then
            txtDescr2.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).SourceGeographicCRS.Name
            txtDescr2.Visible = True
            cmbDataType2.Text = "Latitude, Longitude"
            Select Case DataSettings(1).AngleUnit
                Case DataType.AngleUnits.Decimal_Degrees
                    cmbUnits2.Text = "Decimal Degrees"
                Case DataType.AngleUnits.Degrees_Minutes_Seconds
                    cmbUnits2.Text = "Degrees Minutes Seconds"
                Case DataType.AngleUnits.Gradians
                    cmbUnits2.Text = "Gradians"
                Case DataType.AngleUnits.Radians
                    cmbUnits2.Text = "Radians"
                Case DataType.AngleUnits.Sexagesimal_Degrees
                    cmbUnits2.Text = "Sexagesimal Degrees"
                Case DataType.AngleUnits.Turns
                    cmbUnits2.Text = "Turns"
            End Select
            cmbDirection2.Enabled = True
            Select Case DataSettings(1).ValueDirection
                Case DataType.ValueDirections.E_W_N_S
                    cmbDirection2.Text = "E/W_N/S"
                Case DataType.ValueDirections.East_West_North_South
                    cmbDirection2.Text = "East/West_North/South"
                Case DataType.ValueDirections.Plus_Minus
                    cmbDirection2.Text = "+/-"
            End Select
        ElseIf DataSettings(1).DataType = DataType.DataTypes.Longitude_Latitude Then
            txtDescr2.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).SourceGeographicCRS.Name
            txtDescr2.Visible = True
            cmbDataType2.Text = "Longitude, Latitude"
            Select Case DataSettings(1).AngleUnit
                Case DataType.AngleUnits.Decimal_Degrees
                    cmbUnits2.Text = "Decimal Degrees"
                Case DataType.AngleUnits.Degrees_Minutes_Seconds
                    cmbUnits2.Text = "Degrees Minutes Seconds"
                Case DataType.AngleUnits.Gradians
                    cmbUnits2.Text = "Gradians"
                Case DataType.AngleUnits.Radians
                    cmbUnits2.Text = "Radians"
                Case DataType.AngleUnits.Sexagesimal_Degrees
                    cmbUnits2.Text = "Sexagesimal Degrees"
                Case DataType.AngleUnits.Turns
                    cmbUnits2.Text = "Turns"
            End Select
            cmbDirection2.Enabled = True
            Select Case DataSettings(1).ValueDirection
                Case DataType.ValueDirections.E_W_N_S
                    cmbDirection2.Text = "E/W_N/S"
                Case DataType.ValueDirections.East_West_North_South
                    cmbDirection2.Text = "East/West_North/South"
                Case DataType.ValueDirections.Plus_Minus
                    cmbDirection2.Text = "+/-"
            End Select
        ElseIf DataSettings(1).DataType = DataType.DataTypes.Easting_Northing Then
            txtDescr2.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).Name
            txtDescr2.Visible = True
            cmbDataType2.Text = "Easting, Northing"
            Select Case DataSettings(1).DistanceUnit
                Case DataType.DistanceUnits._Default
                    cmbUnits2.Text = "Default"
                Case DataType.DistanceUnits.Metres
                    cmbUnits2.Text = "Metres"
            End Select
            cmbDirection2.Enabled = False
        ElseIf DataSettings(1).DataType = DataType.DataTypes.Northing_Easting Then
            txtDescr2.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).Name
            txtDescr2.Visible = True
            cmbDataType2.Text = "Northing, Easting"
            Select Case DataSettings(1).DistanceUnit
                Case DataType.DistanceUnits._Default
                    cmbUnits2.Text = "Default"
                Case DataType.DistanceUnits.Metres
                    cmbUnits2.Text = "Metres"
            End Select
            cmbDirection2.Enabled = False
        ElseIf DataSettings(1).DataType = DataType.DataTypes.Point_Description Then
            txtDescr2.Visible = False
            cmbDataType2.Text = "Point description"
            cmbUnits2.Text = "Text"
            cmbDirection2.Enabled = False
        ElseIf DataSettings(1).DataType = DataType.DataTypes.Point_Number Then
            txtDescr2.Visible = False
            cmbDataType2.Text = "Point number"
            cmbUnits2.Text = "Number"
            cmbDirection2.Enabled = False
        ElseIf DataSettings(1).DataType = DataType.DataTypes._Nothing Then
            txtDescr2.Visible = False
            cmbDataType2.Text = "Nothing"
            cmbUnits2.Text = "Nothing"
            cmbDirection2.Enabled = False
        End If

        LabelX = DataSettings(2).DataPosition + DataGridView1.Location.X
        txtDescr3.Location = New Point(LabelX, LabelRowTop)
        txtDescr3.Width = DataSettings(2).DataWidth
        cmbDirection3.Location = New Point(LabelX, LabelRowTop - 20)
        cmbDirection3.Width = DataSettings(2).DataWidth
        cmbUnits3.Location = New Point(LabelX, LabelRowTop - 40)
        cmbUnits3.Width = DataSettings(2).DataWidth
        cmbDataType3.Location = New Point(LabelX, LabelRowTop - 60)
        cmbDataType3.Width = DataSettings(2).DataWidth
        If cmbDataType3.Width = 0 Then
            cmbDataType3.Width = MinWidth
        End If
        If DataSettings(2).DataType = DataType.DataTypes.Latitude_Longitude Then
            If CurrentRecordNo > 0 Then
                txtDescr3.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).SourceGeographicCRS.Name
            End If
            txtDescr3.Visible = True
            cmbDataType3.Text = "Latitude, Longitude"
            Select Case DataSettings(2).AngleUnit
                Case DataType.AngleUnits.Decimal_Degrees
                    cmbUnits3.Text = "Decimal Degrees"
                Case DataType.AngleUnits.Degrees_Minutes_Seconds
                    cmbUnits3.Text = "Degrees Minutes Seconds"
                Case DataType.AngleUnits.Gradians
                    cmbUnits3.Text = "Gradians"
                Case DataType.AngleUnits.Radians
                    cmbUnits3.Text = "Radians"
                Case DataType.AngleUnits.Sexagesimal_Degrees
                    cmbUnits3.Text = "Sexagesimal Degrees"
                Case DataType.AngleUnits.Turns
                    cmbUnits3.Text = "Turns"
            End Select
            cmbDirection3.Enabled = True
            Select Case DataSettings(2).ValueDirection
                Case DataType.ValueDirections.E_W_N_S
                    cmbDirection3.Text = "E/W_N/S"
                Case DataType.ValueDirections.East_West_North_South
                    cmbDirection3.Text = "East/West_North/South"
                Case DataType.ValueDirections.Plus_Minus
                    cmbDirection3.Text = "+/-"
            End Select
        ElseIf DataSettings(2).DataType = DataType.DataTypes.Longitude_Latitude Then
            If CurrentRecordNo > 0 Then
                txtDescr3.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).SourceGeographicCRS.Name
            End If
            txtDescr3.Visible = True
            cmbDataType3.Text = "Longitude, Latitude"
            Select Case DataSettings(2).AngleUnit
                Case DataType.AngleUnits.Decimal_Degrees
                    cmbUnits3.Text = "Decimal Degrees"
                Case DataType.AngleUnits.Degrees_Minutes_Seconds
                    cmbUnits3.Text = "Degrees Minutes Seconds"
                Case DataType.AngleUnits.Gradians
                    cmbUnits3.Text = "Gradians"
                Case DataType.AngleUnits.Radians
                    cmbUnits3.Text = "Radians"
                Case DataType.AngleUnits.Sexagesimal_Degrees
                    cmbUnits3.Text = "Sexagesimal Degrees"
                Case DataType.AngleUnits.Turns
                    cmbUnits3.Text = "Turns"
            End Select
            cmbDirection3.Enabled = True
            Select Case DataSettings(2).ValueDirection
                Case DataType.ValueDirections.E_W_N_S
                    cmbDirection3.Text = "E/W_N/S"
                Case DataType.ValueDirections.East_West_North_South
                    cmbDirection3.Text = "East/West_North/South"
                Case DataType.ValueDirections.Plus_Minus
                    cmbDirection3.Text = "+/-"
            End Select
        ElseIf DataSettings(2).DataType = DataType.DataTypes.Easting_Northing Then
            If CurrentRecordNo > 0 Then
                txtDescr3.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).Name
            End If
            txtDescr3.Visible = True
            cmbDataType3.Text = "Easting, Northing"
            Select Case DataSettings(2).DistanceUnit
                Case DataType.DistanceUnits._Default
                    cmbUnits3.Text = "Default"
                Case DataType.DistanceUnits.Metres
                    cmbUnits3.Text = "Metres"
            End Select
            cmbDirection3.Enabled = False
        ElseIf DataSettings(2).DataType = DataType.DataTypes.Northing_Easting Then
            If CurrentRecordNo > 0 Then
                txtDescr3.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).Name
            End If
            txtDescr3.Visible = True
            cmbDataType3.Text = "Northing, Easting"
            Select Case DataSettings(2).DistanceUnit
                Case DataType.DistanceUnits._Default
                    cmbUnits3.Text = "Default"
                Case DataType.DistanceUnits.Metres
                    cmbUnits3.Text = "Metres"
            End Select
            cmbDirection3.Enabled = False
        ElseIf DataSettings(2).DataType = DataType.DataTypes.Point_Description Then
            txtDescr3.Visible = False
            cmbDataType3.Text = "Point description"
            cmbUnits3.Text = "Text"
            cmbDirection3.Enabled = False
        ElseIf DataSettings(2).DataType = DataType.DataTypes.Point_Number Then
            txtDescr3.Visible = False
            cmbDataType3.Text = "Point number"
            cmbUnits3.Text = "Number"
            cmbDirection3.Enabled = False
        ElseIf DataSettings(2).DataType = DataType.DataTypes._Nothing Then
            txtDescr3.Visible = False
            cmbDataType3.Text = "Nothing"
            cmbUnits3.Text = "Nothing"
            cmbDirection3.Enabled = False
        End If

        LabelX = DataSettings(3).DataPosition + DataGridView1.Location.X
        txtDescr4.Location = New Point(LabelX, LabelRowTop)
        txtDescr4.Width = DataSettings(3).DataWidth
        cmbDirection4.Location = New Point(LabelX, LabelRowTop - 20)
        cmbDirection4.Width = DataSettings(3).DataWidth
        cmbUnits4.Location = New Point(LabelX, LabelRowTop - 40)
        cmbUnits4.Width = DataSettings(3).DataWidth
        cmbDataType4.Location = New Point(LabelX, LabelRowTop - 60)
        cmbDataType4.Width = DataSettings(3).DataWidth
        If cmbDataType4.Width = 0 Then
            cmbDataType4.Width = MinWidth
        End If
        If DataSettings(3).DataType = DataType.DataTypes.Latitude_Longitude Then
            If CurrentRecordNo > 0 Then
                txtDescr4.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).SourceGeographicCRS.Name
            End If
            txtDescr4.Visible = True
            cmbDataType4.Text = "Latitude, Longitude"
            Select Case DataSettings(3).AngleUnit
                Case DataType.AngleUnits.Decimal_Degrees
                    cmbUnits4.Text = "Decimal Degrees"
                Case DataType.AngleUnits.Degrees_Minutes_Seconds
                    cmbUnits4.Text = "Degrees Minutes Seconds"
                Case DataType.AngleUnits.Gradians
                    cmbUnits4.Text = "Gradians"
                Case DataType.AngleUnits.Radians
                    cmbUnits4.Text = "Radians"
                Case DataType.AngleUnits.Sexagesimal_Degrees
                    cmbUnits4.Text = "Sexagesimal Degrees"
                Case DataType.AngleUnits.Turns
                    cmbUnits4.Text = "Turns"
            End Select
            cmbDirection4.Enabled = True
            Select Case DataSettings(3).ValueDirection
                Case DataType.ValueDirections.E_W_N_S
                    cmbDirection4.Text = "E/W_N/S"
                Case DataType.ValueDirections.East_West_North_South
                    cmbDirection4.Text = "East/West_North/South"
                Case DataType.ValueDirections.Plus_Minus
                    cmbDirection4.Text = "+/-"
            End Select
        ElseIf DataSettings(3).DataType = DataType.DataTypes.Longitude_Latitude Then
            If CurrentRecordNo > 0 Then
                txtDescr4.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).SourceGeographicCRS.Name
            End If
            txtDescr4.Visible = True
            cmbDataType4.Text = "Longitude, Latitude"
            Select Case DataSettings(3).AngleUnit
                Case DataType.AngleUnits.Decimal_Degrees
                    cmbUnits4.Text = "Decimal Degrees"
                Case DataType.AngleUnits.Degrees_Minutes_Seconds
                    cmbUnits4.Text = "Degrees Minutes Seconds"
                Case DataType.AngleUnits.Gradians
                    cmbUnits4.Text = "Gradians"
                Case DataType.AngleUnits.Radians
                    cmbUnits4.Text = "Radians"
                Case DataType.AngleUnits.Sexagesimal_Degrees
                    cmbUnits4.Text = "Sexagesimal Degrees"
                Case DataType.AngleUnits.Turns
                    cmbUnits4.Text = "Turns"
            End Select
            cmbDirection4.Enabled = True
            Select Case DataSettings(3).ValueDirection
                Case DataType.ValueDirections.E_W_N_S
                    cmbDirection4.Text = "E/W_N/S"
                Case DataType.ValueDirections.East_West_North_South
                    cmbDirection4.Text = "East/West_North/South"
                Case DataType.ValueDirections.Plus_Minus
                    cmbDirection4.Text = "+/-"
            End Select
        ElseIf DataSettings(3).DataType = DataType.DataTypes.Easting_Northing Then
            If CurrentRecordNo > 0 Then
                txtDescr4.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).Name
            End If
            txtDescr4.Visible = True
            cmbDataType4.Text = "Easting, Northing"
            Select Case DataSettings(3).DistanceUnit
                Case DataType.DistanceUnits._Default
                    cmbUnits4.Text = "Default"
                Case DataType.DistanceUnits.Metres
                    cmbUnits4.Text = "Metres"
            End Select
            cmbDirection4.Enabled = False
        ElseIf DataSettings(3).DataType = DataType.DataTypes.Northing_Easting Then
            If CurrentRecordNo > 0 Then
                txtDescr4.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).Name
            End If
            txtDescr4.Visible = True
            cmbDataType4.Text = "Northing, Easting"
            Select Case DataSettings(3).DistanceUnit
                Case DataType.DistanceUnits._Default
                    cmbUnits4.Text = "Default"
                Case DataType.DistanceUnits.Metres
                    cmbUnits4.Text = "Metres"
            End Select
            cmbDirection4.Enabled = False
        ElseIf DataSettings(3).DataType = DataType.DataTypes.Point_Description Then
            txtDescr4.Visible = False
            cmbDataType4.Text = "Point description"
            cmbUnits4.Text = "Text"
            cmbDirection4.Enabled = False
        ElseIf DataSettings(3).DataType = DataType.DataTypes.Point_Number Then
            txtDescr4.Visible = False
            cmbDataType4.Text = "Point number"
            cmbUnits4.Text = "Number"
            cmbDirection4.Enabled = False
        ElseIf DataSettings(3).DataType = DataType.DataTypes._Nothing Then
            txtDescr4.Visible = False
            cmbDataType4.Text = "Nothing"
            cmbUnits4.Text = "Nothing"
            cmbDirection4.Enabled = False
        End If

        LabelX = DataSettings(4).DataPosition + DataGridView1.Location.X
        txtDescr5.Location = New Point(LabelX, LabelRowTop)
        txtDescr5.Width = DataSettings(4).DataWidth
        cmbDirection5.Location = New Point(LabelX, LabelRowTop - 20)
        cmbDirection5.Width = DataSettings(4).DataWidth
        cmbUnits5.Location = New Point(LabelX, LabelRowTop - 40)
        cmbUnits5.Width = DataSettings(4).DataWidth
        cmbDataType5.Location = New Point(LabelX, LabelRowTop - 60)
        cmbDataType5.Width = DataSettings(4).DataWidth
        If cmbDataType5.Width = 0 Then
            cmbDataType5.Width = MinWidth
        End If
        If DataSettings(4).DataType = DataType.DataTypes.Latitude_Longitude Then
            If CurrentRecordNo > 0 Then
                txtDescr5.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).SourceGeographicCRS.Name
            End If
            txtDescr5.Visible = True
            cmbDataType5.Text = "Latitude, Longitude"
            Select Case DataSettings(4).AngleUnit
                Case DataType.AngleUnits.Decimal_Degrees
                    cmbUnits5.Text = "Decimal Degrees"
                Case DataType.AngleUnits.Degrees_Minutes_Seconds
                    cmbUnits5.Text = "Degrees Minutes Seconds"
                Case DataType.AngleUnits.Gradians
                    cmbUnits5.Text = "Gradians"
                Case DataType.AngleUnits.Radians
                    cmbUnits5.Text = "Radians"
                Case DataType.AngleUnits.Sexagesimal_Degrees
                    cmbUnits5.Text = "Sexagesimal Degrees"
                Case DataType.AngleUnits.Turns
                    cmbUnits5.Text = "Turns"
            End Select
            cmbDirection5.Enabled = True
            Select Case DataSettings(4).ValueDirection
                Case DataType.ValueDirections.E_W_N_S
                    cmbDirection5.Text = "E/W_N/S"
                Case DataType.ValueDirections.East_West_North_South
                    cmbDirection5.Text = "East/West_North/South"
                Case DataType.ValueDirections.Plus_Minus
                    cmbDirection5.Text = "+/-"
            End Select
        ElseIf DataSettings(4).DataType = DataType.DataTypes.Longitude_Latitude Then
            If CurrentRecordNo > 0 Then
                txtDescr5.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).SourceGeographicCRS.Name
            End If
            txtDescr5.Visible = True
            cmbDataType5.Text = "Longitude, Latitude"
            Select Case DataSettings(4).AngleUnit
                Case DataType.AngleUnits.Decimal_Degrees
                    cmbUnits5.Text = "Decimal Degrees"
                Case DataType.AngleUnits.Degrees_Minutes_Seconds
                    cmbUnits5.Text = "Degrees Minutes Seconds"
                Case DataType.AngleUnits.Gradians
                    cmbUnits5.Text = "Gradians"
                Case DataType.AngleUnits.Radians
                    cmbUnits5.Text = "Radians"
                Case DataType.AngleUnits.Sexagesimal_Degrees
                    cmbUnits5.Text = "Sexagesimal Degrees"
                Case DataType.AngleUnits.Turns
                    cmbUnits5.Text = "Turns"
            End Select
            cmbDirection5.Enabled = True
            Select Case DataSettings(4).ValueDirection
                Case DataType.ValueDirections.E_W_N_S
                    cmbDirection5.Text = "E/W_N/S"
                Case DataType.ValueDirections.East_West_North_South
                    cmbDirection5.Text = "East/West_North/South"
                Case DataType.ValueDirections.Plus_Minus
                    cmbDirection5.Text = "+/-"
            End Select
        ElseIf DataSettings(4).DataType = DataType.DataTypes.Easting_Northing Then
            If CurrentRecordNo > 0 Then
                txtDescr5.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).Name
            End If
            txtDescr5.Visible = True
            cmbDataType5.Text = "Easting, Northing"
            Select Case DataSettings(4).DistanceUnit
                Case DataType.DistanceUnits._Default
                    cmbUnits5.Text = "Default"
                Case DataType.DistanceUnits.Metres
                    cmbUnits5.Text = "Metres"
            End Select
            cmbDirection5.Enabled = False
        ElseIf DataSettings(4).DataType = DataType.DataTypes.Northing_Easting Then
            If CurrentRecordNo > 0 Then
                txtDescr2.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).Name
            End If
            txtDescr5.Visible = True
            cmbDataType5.Text = "Northing, Easting"
            Select Case DataSettings(4).DistanceUnit
                Case DataType.DistanceUnits._Default
                    cmbUnits5.Text = "Default"
                Case DataType.DistanceUnits.Metres
                    cmbUnits5.Text = "Metres"
            End Select
            cmbDirection5.Enabled = False
        ElseIf DataSettings(4).DataType = DataType.DataTypes.Point_Description Then
            txtDescr5.Visible = False
            cmbDataType5.Text = "Point description"
            cmbUnits5.Text = "Text"
            cmbDirection5.Enabled = False
        ElseIf DataSettings(4).DataType = DataType.DataTypes.Point_Number Then
            txtDescr5.Visible = False
            cmbDataType5.Text = "Point number"
            cmbUnits5.Text = "Number"
            cmbDirection5.Enabled = False
        ElseIf DataSettings(4).DataType = DataType.DataTypes._Nothing Then
            txtDescr5.Visible = False
            cmbDataType5.Text = "Nothing"
            cmbUnits5.Text = "Nothing"
            cmbDirection5.Enabled = False
        End If

        LabelX = DataSettings(5).DataPosition + DataGridView1.Location.X
        txtDescr6.Location = New Point(LabelX, LabelRowTop)
        txtDescr6.Width = DataSettings(5).DataWidth
        cmbDirection6.Location = New Point(LabelX, LabelRowTop - 20)
        cmbDirection6.Width = DataSettings(5).DataWidth
        cmbUnits6.Location = New Point(LabelX, LabelRowTop - 40)
        cmbUnits6.Width = DataSettings(5).DataWidth
        cmbDataType6.Location = New Point(LabelX, LabelRowTop - 60)
        cmbDataType6.Width = DataSettings(5).DataWidth
        If cmbDataType6.Width = 0 Then
            cmbDataType6.Width = MinWidth
        End If
        If DataSettings(5).DataType = DataType.DataTypes.Latitude_Longitude Then
            If CurrentRecordNo > 0 Then
                txtDescr6.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).SourceGeographicCRS.Name
            End If
            txtDescr6.Visible = True
            cmbDataType6.Text = "Latitude, Longitude"
            Select Case DataSettings(5).AngleUnit
                Case DataType.AngleUnits.Decimal_Degrees
                    cmbUnits6.Text = "Decimal Degrees"
                Case DataType.AngleUnits.Degrees_Minutes_Seconds
                    cmbUnits6.Text = "Degrees Minutes Seconds"
                Case DataType.AngleUnits.Gradians
                    cmbUnits6.Text = "Gradians"
                Case DataType.AngleUnits.Radians
                    cmbUnits6.Text = "Radians"
                Case DataType.AngleUnits.Sexagesimal_Degrees
                    cmbUnits6.Text = "Sexagesimal Degrees"
                Case DataType.AngleUnits.Turns
                    cmbUnits6.Text = "Turns"
            End Select
            cmbDirection6.Enabled = True
            Select Case DataSettings(5).ValueDirection
                Case DataType.ValueDirections.E_W_N_S
                    cmbDirection6.Text = "E/W_N/S"
                Case DataType.ValueDirections.East_West_North_South
                    cmbDirection6.Text = "East/West_North/South"
                Case DataType.ValueDirections.Plus_Minus
                    cmbDirection6.Text = "+/-"
            End Select
        ElseIf DataSettings(5).DataType = DataType.DataTypes.Longitude_Latitude Then
            If CurrentRecordNo > 0 Then
                txtDescr6.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).SourceGeographicCRS.Name
            End If
            txtDescr6.Visible = True
            cmbDataType6.Text = "Longitude, Latitude"
            Select Case DataSettings(5).AngleUnit
                Case DataType.AngleUnits.Decimal_Degrees
                    cmbUnits6.Text = "Decimal Degrees"
                Case DataType.AngleUnits.Degrees_Minutes_Seconds
                    cmbUnits6.Text = "Degrees Minutes Seconds"
                Case DataType.AngleUnits.Gradians
                    cmbUnits6.Text = "Gradians"
                Case DataType.AngleUnits.Radians
                    cmbUnits6.Text = "Radians"
                Case DataType.AngleUnits.Sexagesimal_Degrees
                    cmbUnits6.Text = "Sexagesimal Degrees"
                Case DataType.AngleUnits.Turns
                    cmbUnits6.Text = "Turns"
            End Select
            cmbDirection6.Enabled = True
            Select Case DataSettings(5).ValueDirection
                Case DataType.ValueDirections.E_W_N_S
                    cmbDirection6.Text = "E/W_N/S"
                Case DataType.ValueDirections.East_West_North_South
                    cmbDirection6.Text = "East/West_North/South"
                Case DataType.ValueDirections.Plus_Minus
                    cmbDirection6.Text = "+/-"
            End Select
        ElseIf DataSettings(5).DataType = DataType.DataTypes.Easting_Northing Then
            If CurrentRecordNo > 0 Then
                txtDescr6.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).Name
            End If
            txtDescr6.Visible = True
            cmbDataType6.Text = "Easting, Northing"
            Select Case DataSettings(5).DistanceUnit
                Case DataType.DistanceUnits._Default
                    cmbUnits6.Text = "Default"
                Case DataType.DistanceUnits.Metres
                    cmbUnits6.Text = "Metres"
            End Select
            cmbDirection6.Enabled = False
        ElseIf DataSettings(5).DataType = DataType.DataTypes.Northing_Easting Then
            If CurrentRecordNo > 0 Then
                txtDescr6.Text = Main.ProjectedCRS.List(CurrentRecordNo - 1).Name
            End If
            txtDescr6.Visible = True
            cmbDataType6.Text = "Northing, Easting"
            Select Case DataSettings(5).DistanceUnit
                Case DataType.DistanceUnits._Default
                    cmbUnits6.Text = "Default"
                Case DataType.DistanceUnits.Metres
                    cmbUnits6.Text = "Metres"
            End Select
            cmbDirection6.Enabled = False
        ElseIf DataSettings(5).DataType = DataType.DataTypes.Point_Description Then
            txtDescr6.Visible = False
            cmbDataType6.Text = "Point description"
            cmbUnits6.Text = "Text"
            cmbDirection6.Enabled = False
        ElseIf DataSettings(5).DataType = DataType.DataTypes.Point_Number Then
            txtDescr6.Visible = False
            cmbDataType6.Text = "Point number"
            cmbUnits6.Text = "Number"
            cmbDirection6.Enabled = False
        ElseIf DataSettings(5).DataType = DataType.DataTypes._Nothing Then
            txtDescr6.Visible = False
            cmbDataType6.Text = "Nothing"
            cmbUnits6.Text = "Nothing"
            cmbDirection6.Enabled = False
        End If

        AutoModeLevel -= 1 'Decrement the AutoMode level.

        'Remove the focus from any display selections:
        cmbDataType1.SelectionLength = 0
        cmbDataType2.SelectionLength = 0
        cmbDataType3.SelectionLength = 0
        cmbDataType4.SelectionLength = 0
        cmbDataType5.SelectionLength = 0
        cmbDataType6.SelectionLength = 0
        cmbUnits1.SelectionLength = 0
        cmbUnits2.SelectionLength = 0
        cmbUnits3.SelectionLength = 0
        cmbUnits4.SelectionLength = 0
        cmbUnits5.SelectionLength = 0
        cmbUnits6.SelectionLength = 0
        cmbDirection1.SelectionLength = 0
        cmbDirection2.SelectionLength = 0
        cmbDirection3.SelectionLength = 0
        cmbDirection4.SelectionLength = 0
        cmbDirection5.SelectionLength = 0
        cmbDirection6.SelectionLength = 0

    End Sub

    Private Sub cmbProjectedCRS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProjectedCRS.SelectedIndexChanged
        SelectNewProjectedCRS()
    End Sub

    Public Sub SelectNewProjectedCRS()

        Main.Message.Add("Getting the projection parameters for Index No: " & cmbProjectedCRS.SelectedIndex & vbCrLf)

        Dim Index As Integer
        Index = cmbProjectedCRS.SelectedIndex
        CurrentRecordNo = Index + 1
        Main.Message.Add("-----------------------------------------------------------------------------------------------------------------" & vbCrLf)
        Main.Message.Add("Selected index number is: " & Str(Index) & vbCrLf)
        Main.Message.Add("Projected coordinate reference system: " & cmbProjectedCRS.SelectedItem.ToString & vbCrLf)

        txtProjectionMethod.Text = Main.ProjectedCRS.List(Index).ProjectionMethod.Name
        txtDescr1.Text = Main.ProjectedCRS.List(Index).SourceGeographicCRS.Name 'txtDescr1.Text contains a description of the data contained in Data Column 1 (Eg geodetic datum GDA94)
        txtGeographicCRS2.Text = Main.ProjectedCRS.List(Index).SourceGeographicCRS.Name
        Main.Message.Add("Geographic coordinate reference system is: " & Main.ProjectedCRS.List(Index).SourceGeographicCRS.Name & " Type: " & Main.ProjectedCRS.List(Index).SourceGeographicCRS.Type & vbCrLf)
        txtDescr2.Text = Main.ProjectedCRS.List(Index).Name 'txtDescr2.Text contains a description of the data contained in Data Column 2 (Eg map projection MGA94)

        'Set the Projection parameters :
        'All the Projection Parameters are stored in Main.ProjectionList()
        If Main.Projection.NRecords = 0 Then
            Main.Message.AddWarning("There is no Projection data!" & vbCrLf)
        Else
            Select Case Main.ProjectedCRS.List(Index).ProjectionMethod.Name
                Case "Transverse Mercator"
                    GetTransverseMercatorParameters()
                    GetTMEllipsoidParameters()
                Case "Oblique Stereographic"
                    Main.Message.Add("Oblique Stereographic projection not yet coded. " & vbCrLf)
                Case "Transverse Mercator (South Orientated)"
                    Main.Message.Add("Transverse Mercator (South Orientated) projection not yet coded. " & vbCrLf)
                Case "Hotine Oblique Mercator (variant B)"
                    Main.Message.Add("Hotine Oblique Mercator (variant B) projection not yet coded. " & vbCrLf)
                Case "Lambert Conic Conformal (1SP)"
                    Main.Message.Add("Lambert Conic Conformal (1SP) projection not yet coded. " & vbCrLf)
                Case "Krovak"
                    Main.Message.Add("Krovak projection not yet coded. " & vbCrLf)
                Case "Cassini-Soldner"
                    Main.Message.Add("Cassini-Soldner projection not yet coded. " & vbCrLf)
                Case "Lambert Conic Conformal (2SP)"
                    Main.Message.Add("Lambert Conic Conformal (2SP) projection not yet coded. " & vbCrLf)
                Case Else
                    Main.Message.Add("Unknown projection method: " & Main.ProjectedCRS.List(Index).ProjectionMethod.Name & vbCrLf)
            End Select
        End If
    End Sub

    Private Sub GetTransverseMercatorParameters()
        'Get the Transverse Mercator projection parameters:

        Dim ProjectionMatch = From Projection In Main.Projection.List Where Projection.Author = Main.ProjectedCRS.List(cmbProjectedCRS.SelectedIndex).Projection.Author And Projection.Code = Main.ProjectedCRS.List(cmbProjectedCRS.SelectedIndex).Projection.Code
        If ProjectionMatch.Count > 0 Then
            TransverseMercator.Projection.Name = ProjectionMatch(0).Name
            TransverseMercator.Projection.Author = ProjectionMatch(0).Author
            TransverseMercator.Projection.Code = ProjectionMatch(0).Code

            For Each item In ProjectionMatch(0).ParameterValue
                TransverseMercator.Projection.DistanceUnits = "Unknown"
                Select Case item.Name
                    Case "Latitude of natural origin"
                        Main.Message.Add("Latitude of natural origin is : " & item.Value & "   units: " & item.Unit.Name & vbCrLf)
                        Select Case item.Unit.Name
                            Case "degree"
                                TransverseMercator.Projection.LatitudeOfNaturalOrigin = item.Value 'Store Latitude of natural origin as degrees
                            Case "sexagesimal DMS"
                                AngleConvert.SexagesimalDegrees = item.Value
                                AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                TransverseMercator.Projection.LatitudeOfNaturalOrigin = AngleConvert.DecimalDegrees 'Store Latitude of natural origin as degrees
                            Case Else
                                'DISPLAY ERROR MESSAGE
                        End Select
                    Case "Longitude of natural origin"
                        Main.Message.Add("Longitude of natural origin is : " & item.Value & "   units: " & item.Unit.Name & vbCrLf)
                        Select Case item.Unit.Name
                            Case "degree"
                                TransverseMercator.Projection.LongitudeOfNaturalOrigin = item.Value 'Store Longitude of natural origin as degrees
                            Case "sexagesimal DMS"
                                AngleConvert.SexagesimalDegrees = item.Value
                                AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                TransverseMercator.Projection.LongitudeOfNaturalOrigin = AngleConvert.DecimalDegrees  'Store Longitude of natural origin as degrees
                            Case Else
                                'DISPLAY ERROR MESSAGE
                        End Select
                    Case "Scale factor at natural origin"
                        Main.Message.Add("Scale factor at natural origin is : " & item.Value & "   units: " & item.Unit.Name & vbCrLf)
                        Select Case item.Unit.Name
                            Case "unity"
                                TransverseMercator.Projection.ScaleFactorAtNaturalOrigin = item.Value
                            Case Else
                                'DISPLAY ERROR MESSAGE
                        End Select
                    Case "False easting"
                        Main.Message.Add("False easting is : " & item.Value & "   units: " & item.Unit.Name & vbCrLf)
                        If TransverseMercator.Projection.DistanceUnits = "Unknown" Then
                            TransverseMercator.Projection.DistanceUnits = item.Unit.Name
                            If TransverseMercator.Projection.DistanceUnits = item.Unit.Name Then
                                'Distance units are consistent
                            Else
                                'Inconsistent distance units.
                                'DISPLAY ERROR MESSAGE
                                Main.Message.Add("Inconsistent distance units! False easting units are: " & item.Unit.Name & "   other units used are: " & TransverseMercator.Projection.DistanceUnits & vbCrLf)
                            End If
                        End If
                        TransverseMercator.Projection.FalseEasting = item.Value
                    Case "False northing"
                        Main.Message.Add("False northing is : " & item.Value & "   units: " & item.Unit.Name & vbCrLf)
                        If TransverseMercator.Projection.DistanceUnits = "Unknown" Then
                            TransverseMercator.Projection.DistanceUnits = item.Unit.Name
                            If TransverseMercator.Projection.DistanceUnits = item.Unit.Name Then
                                'Distance units are consistent
                            Else
                                'Inconsistent distance units.
                                'DISPLAY ERROR MESSAGE
                                Main.Message.Add("Inconsistent distance units! False northing units are: " & item.Unit.Name & "   other units used are: " & TransverseMercator.Projection.DistanceUnits & vbCrLf)
                            End If
                        End If
                        TransverseMercator.Projection.FalseNorthing = item.Value
                End Select
            Next
        Else
            Main.Message.Add("Projection not found: Author = " & Main.ProjectedCRS.List(cmbProjectedCRS.SelectedIndex).Projection.Author & "  Code = " & Main.ProjectedCRS.List(cmbProjectedCRS.SelectedIndex).Projection.Code & vbCrLf)
        End If

    End Sub

    Private Sub GetTMEllipsoidParameters()
        'Get the Transverse Mercator Ellipsoid parameters:

        If Main.ProjectedCRS.List(cmbProjectedCRS.SelectedIndex).SourceGeographicCRS.Type = "geographic 2D" Then
            Dim BaseCrsMatch = From BaseCrs In Main.Geographic2DCRS.List Where BaseCrs.Author = Main.ProjectedCRS.List(cmbProjectedCRS.SelectedIndex).SourceGeographicCRS.Author And BaseCrs.Code = Main.ProjectedCRS.List(cmbProjectedCRS.SelectedIndex).SourceGeographicCRS.Code

            If BaseCrsMatch.Count > 0 Then
                TransverseMercator.GeographicCRS.Name = BaseCrsMatch(0).Name
                TransverseMercator.GeographicCRS.Author = BaseCrsMatch(0).Author
                TransverseMercator.GeographicCRS.Code = BaseCrsMatch(0).Code
                Main.Message.Add("Base coordinate reference system found: " & BaseCrsMatch(0).Name & vbCrLf)
                Main.Message.Add("Base coordinate reference system author: " & BaseCrsMatch(0).Author & vbCrLf)
                Main.Message.Add("Base coordinate reference system code: " & BaseCrsMatch(0).Code & vbCrLf & vbCrLf)

                'This subroutine is called to get the datum's ellipsoid parameters.
                GetDatumMatch(BaseCrsMatch(0).Datum.Author, BaseCrsMatch(0).Datum.Code)
                '(if this code is included within this subroutine, it runs very slowly!!!!!)
                '(See original code below.)

                'Use Datum Author and Code to get Datum record:
                'Dim DatumMatch = From Datum In Main.GeodeticDatumList Where Datum.Author = BaseCrsMatch(0).Datum.Author And Datum.Code = BaseCrsMatch(0).Datum.Code
                'Main.MessageAdd("About to search for geodetic datum: " & vbCrLf)
                'Dim DatumMatch = From GeoDatum In Main.GeodeticDatumList Where GeoDatum.Author = BaseCrsMatch(0).Datum.Author And GeoDatum.Code = BaseCrsMatch(0).Datum.Code
                'Main.MessageAdd("Finished searching: " & vbCrLf)

                'If DatumMatch.Count > 0 Then
                '    Main.MessageAdd("Match found: " & vbCrLf)
                '    TransverseMercator.GeographicCRS.DatumName = DatumMatch(0).Name
                '    TransverseMercator.GeographicCRS.EllipsoidName = DatumMatch(0).Ellipsoid.Name
                '    TransverseMercator.GeographicCRS.InverseFlattening = DatumMatch(0).Ellipsoid.InverseFlattening
                '    TransverseMercator.GeographicCRS.SemiMajorAxis = DatumMatch(0).Ellipsoid.SemiMajorAxis
                '    TransverseMercator.GeographicCRS.SemiMinorAxis = DatumMatch(0).Ellipsoid.SemiMinorAxis
                '    Main.MessageAdd("Base datum found: " & DatumMatch(0).Name & vbCrLf)
                '    'ACCESSING DatumMatch(0)  is VERY SLOW !!!!!!!!!
                '    'Main.MessageAdd("Ellipsoid name: " & DatumMatch(0).Ellipsoid.Name & vbCrLf)
                '    'Main.MessageAdd("Inverse Flattening: " & DatumMatch(0).Ellipsoid.InverseFlattening & vbCrLf)
                '    'Main.MessageAdd("Semi Major Axis: " & DatumMatch(0).Ellipsoid.SemiMajorAxis & vbCrLf)
                '    'Main.MessageAdd("Semi Minor Axis: " & DatumMatch(0).Ellipsoid.SemiMinorAxis & vbCrLf)
                '    Main.MessageAdd("Ellipsoid name: " & TransverseMercator.GeographicCRS.EllipsoidName & vbCrLf)
                '    Main.MessageAdd("Inverse Flattening: " & TransverseMercator.GeographicCRS.InverseFlattening & vbCrLf)
                '    Main.MessageAdd("Semi Major Axis: " & TransverseMercator.GeographicCRS.SemiMajorAxis & vbCrLf)
                '    Main.MessageAdd("Semi Minor Axis: " & TransverseMercator.GeographicCRS.SemiMinorAxis & vbCrLf)

                'Else
                '    Main.MessageAdd("No matching datum found for Datum.Author = " & BaseCrsMatch(0).Datum.Author & " and Datum.Code =  " & BaseCrsMatch(0).Datum.Code & vbCrLf)
                '    Main.MessageAdd("Number of entries in the Geodetic Datum List is: " & Main.GeodeticDatumList.Count & vbCrLf)
                'End If
            Else
                Main.Message.Add("No matching base coordinate reference system found for Datum.Author =  " & Main.ProjectedCRS.List(cmbProjectedCRS.SelectedIndex).SourceGeographicCRS.Author & " and Datum.Code = " & Main.ProjectedCRS.List(cmbProjectedCRS.SelectedIndex).SourceGeographicCRS.Code & vbCrLf)

            End If

        ElseIf Main.ProjectedCRS.List(cmbProjectedCRS.SelectedIndex).SourceGeographicCRS.Type = "geographic 3D" Then
            Main.Message.Add("Source Geographic CRS = geographic 3D. Not yet coded." & vbCrLf)
        Else
            Main.Message.Add("Unknown Source Geographic CRS:" & Main.ProjectedCRS.List(cmbProjectedCRS.SelectedIndex).SourceGeographicCRS.Type.ToString & vbCrLf)
        End If
    End Sub


    Private Sub GetDatumMatch(ByVal Author As String, ByVal Code As Integer)
        'Use Datum Author and Code to get Datum record:
        Dim DatumMatch = From Datum In Main.GeodeticDatum.List Where Datum.Author = Author And Datum.Code = Code

        If DatumMatch.Count > 0 Then
            TransverseMercator.GeographicCRS.DatumName = DatumMatch(0).Name
            TransverseMercator.GeographicCRS.EllipsoidName = DatumMatch(0).Ellipsoid.Name
            Main.Message.Add("Base datum found: " & DatumMatch(0).Name & vbCrLf)
            Main.Message.Add("Ellipsoid name: " & DatumMatch(0).Ellipsoid.Name & vbCrLf)
            Dim EllipsoidMatch = From Ellipsoid In Main.Ellipsoid.List Where Ellipsoid.Author = DatumMatch(0).Ellipsoid.Author And Ellipsoid.Code = DatumMatch(0).Ellipsoid.Code

            If EllipsoidMatch.Count > 0 Then
                If EllipsoidMatch(0).EllipsoidParameters = ADVL_Coordinates_Library_1.Ellipsoid.DefiningParameters.SemiMajorAxis_InverseFlattening Then
                    TransverseMercator.GeographicCRS.SemiMajorAxis = EllipsoidMatch(0).SemiMajorAxis
                    TransverseMercator.GeographicCRS.InverseFlattening = EllipsoidMatch(0).InverseFlattening
                    'Calculate SemiMinorAxis:
                    TransverseMercator.GeographicCRS.SemiMinorAxis = EllipsoidMatch(0).SemiMajorAxis - (EllipsoidMatch(0).SemiMajorAxis / EllipsoidMatch(0).InverseFlattening)
                ElseIf EllipsoidMatch(0).EllipsoidParameters = ADVL_Coordinates_Library_1.Ellipsoid.DefiningParameters.SemiMajorAxis_SemiMinorAxis Then
                    TransverseMercator.GeographicCRS.SemiMajorAxis = EllipsoidMatch(0).SemiMajorAxis
                    TransverseMercator.GeographicCRS.SemiMinorAxis = EllipsoidMatch(0).SemiMinorAxis
                    'Calculate InverseFlattening:
                    TransverseMercator.GeographicCRS.InverseFlattening = EllipsoidMatch(0).SemiMajorAxis / (EllipsoidMatch(0).SemiMajorAxis - EllipsoidMatch(0).SemiMinorAxis)
                Else
                    Main.Message.Add("Unknown ellipsoid specification: " & vbCrLf)
                    TransverseMercator.GeographicCRS.SemiMajorAxis = EllipsoidMatch(0).SemiMajorAxis
                    TransverseMercator.GeographicCRS.SemiMinorAxis = EllipsoidMatch(0).SemiMinorAxis
                    TransverseMercator.GeographicCRS.InverseFlattening = EllipsoidMatch(0).InverseFlattening
                End If
                Main.Message.Add("Inverse Flattening: " & EllipsoidMatch(0).InverseFlattening & vbCrLf)
                Main.Message.Add("Semi Major Axis: " & EllipsoidMatch(0).SemiMajorAxis & vbCrLf)
                Main.Message.Add("Semi Minor Axis: " & EllipsoidMatch(0).SemiMinorAxis & vbCrLf)
            End If

        Else
            Main.Message.Add("No matching datum found for Datum.Author = " & Author & " and Datum.Code =  " & "6658" & vbCrLf)
            Main.Message.Add("Number of entries in the Geodetic Datum List is: " & Main.GeodeticDatum.List.Count & vbCrLf)
        End If
    End Sub

    Private Sub cmbDataType1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDataType1.SelectedIndexChanged
        'Change datatype in position 1

        If AutoModeLevel = 0 Then 'The units have been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            'SavePoints()
            SavePoints(0)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level. This indicates that the following changes to DataGridView1 are being made automatically.
        Select Case cmbDataType1.SelectedItem
            Case "Nothing"
                DataSettings(0).DataType = DataType.DataTypes._Nothing
                cmbUnits1.Items.Clear()
                cmbUnits1.Items.Add("Nothing")
                cmbUnits1.SelectedIndex = 0
                UpdateDataGridView()
            Case "Point number"
                DataSettings(0).DataType = DataType.DataTypes.Point_Number
                cmbUnits1.Items.Clear()
                cmbUnits1.Items.Add("Number")
                cmbUnits1.SelectedIndex = 0
                UpdateDataGridView()
            Case "Point description"
                DataSettings(0).DataType = DataType.DataTypes.Point_Description
                cmbUnits1.Items.Clear()
                cmbUnits1.Items.Add("Text")
                cmbUnits1.SelectedIndex = 0
                UpdateDataGridView()
            Case "Latitude, Longitude" 'DataColumn1 will display Latitude and Longitude. The choice of angle units will be updated.
                DataSettings(0).DataType = DataType.DataTypes.Latitude_Longitude
                cmbUnits1.Items.Clear()
                cmbUnits1.Items.Add("Decimal Degrees")
                cmbUnits1.Items.Add("Degrees Minutes Seconds")
                cmbUnits1.Items.Add("Sexagesimal Degrees")
                cmbUnits1.Items.Add("Radians")
                cmbUnits1.Items.Add("Gradians")
                cmbUnits1.Items.Add("Turns")
                cmbUnits1.SelectedIndex = 0
                UpdateDataGridView()
            Case "Longitude, Latitude"  'DataColumn1 will display Longitude and Latitude. The choice of angle units will be updated.
                DataSettings(0).DataType = DataType.DataTypes.Longitude_Latitude
                cmbUnits1.Items.Clear()
                cmbUnits1.Items.Add("Decimal Degrees")
                cmbUnits1.Items.Add("Degrees Minutes Seconds")
                cmbUnits1.Items.Add("Sexagesimal Degrees")
                cmbUnits1.Items.Add("Radians")
                cmbUnits1.Items.Add("Gradians")
                cmbUnits1.Items.Add("Turns")
                cmbUnits1.SelectedIndex = 0
                UpdateDataGridView()
            Case "Easting, Northing"  'DataColumn1 will display Easting and Northing. The choice of angle units will be updated.
                DataSettings(0).DataType = DataType.DataTypes.Easting_Northing
                cmbUnits1.Items.Clear()
                cmbUnits1.Items.Add("Metres")
                cmbUnits1.Items.Add("Default")
                cmbUnits1.SelectedIndex = 1
                UpdateDataGridView()
            Case "Northing, Easting" 'DataColumn1 will display Northing and Easting. The choice of angle units will be updated.
                DataSettings(0).DataType = DataType.DataTypes.Northing_Easting
                cmbUnits1.Items.Clear()
                cmbUnits1.Items.Add("Metres")
                cmbUnits1.Items.Add("Default")
                cmbUnits1.SelectedIndex = 1
                UpdateDataGridView()
            Case Else
                Main.Message.Add("Data type in position 1 not recognised: " & cmbDataType1.SelectedItem & vbCrLf)
                DataSettings(0).DataType = DataType.DataTypes._Nothing
                cmbUnits1.Items.Clear()
                cmbUnits1.Items.Add("Nothing")
                cmbUnits1.SelectedIndex = 0
                UpdateDataGridView()
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then
            RestorePoints()
        End If
    End Sub

    Private Sub cmbDataType2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDataType2.SelectedIndexChanged
        'Change datatype in position 2

        If AutoModeLevel = 0 Then 'The units have been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            'SavePoints()
            SavePoints(1)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level. his indicates that the following changes to DataGridView1 are being made automatically.
        Select Case cmbDataType2.SelectedItem
            Case "Nothing"
                DataSettings(1).DataType = DataType.DataTypes._Nothing
                cmbUnits2.Items.Clear()
                cmbUnits2.Items.Add("Nothing")
                cmbUnits2.SelectedIndex = 0
                UpdateDataGridView()
            Case "Point number"
                DataSettings(1).DataType = DataType.DataTypes.Point_Number
                cmbUnits2.Items.Clear()
                cmbUnits2.Items.Add("Number")
                cmbUnits2.SelectedIndex = 0
                UpdateDataGridView()
            Case "Point description"
                DataSettings(1).DataType = DataType.DataTypes.Point_Description
                cmbUnits2.Items.Clear()
                cmbUnits2.Items.Add("Text")
                cmbUnits2.SelectedIndex = 0
                UpdateDataGridView()
            Case "Latitude, Longitude"
                DataSettings(1).DataType = DataType.DataTypes.Latitude_Longitude
                cmbUnits2.Items.Clear()
                cmbUnits2.Items.Add("Decimal Degrees")
                cmbUnits2.Items.Add("Degrees Minutes Seconds")
                cmbUnits2.Items.Add("Sexagesimal Degrees")
                cmbUnits2.Items.Add("Radians")
                cmbUnits2.Items.Add("Gradians")
                cmbUnits2.Items.Add("Turns")
                cmbUnits2.SelectedIndex = 0
                UpdateDataGridView()
            Case "Longitude, Latitude"
                DataSettings(1).DataType = DataType.DataTypes.Longitude_Latitude
                cmbUnits2.Items.Clear()
                cmbUnits2.Items.Add("Decimal Degrees")
                cmbUnits2.Items.Add("Degrees Minutes Seconds")
                cmbUnits2.Items.Add("Sexagesimal Degrees")
                cmbUnits2.Items.Add("Radians")
                cmbUnits2.Items.Add("Gradians")
                cmbUnits2.Items.Add("Turns")
                cmbUnits2.SelectedIndex = 0
                UpdateDataGridView()
            Case "Easting, Northing"
                DataSettings(1).DataType = DataType.DataTypes.Easting_Northing
                cmbUnits2.Items.Clear()
                cmbUnits2.Items.Add("Metres")
                cmbUnits2.Items.Add("Default")
                cmbUnits2.SelectedIndex = 1
                UpdateDataGridView()
            Case "Northing, Easting"
                DataSettings(1).DataType = DataType.DataTypes.Northing_Easting
                cmbUnits2.Items.Clear()
                cmbUnits2.Items.Add("Metres")
                cmbUnits2.Items.Add("Default")
                cmbUnits2.SelectedIndex = 1
                UpdateDataGridView()
            Case Else
                Main.Message.Add("Data type in position 1 not recognised: " & cmbDataType2.SelectedItem & vbCrLf)
                DataSettings(1).DataType = DataType.DataTypes._Nothing
                cmbUnits2.Items.Clear()
                cmbUnits2.Items.Add("Nothing")
                cmbUnits2.SelectedIndex = 0
                UpdateDataGridView()
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then
            RestorePoints()
        End If

    End Sub

    Private Sub cmbDataType3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDataType3.SelectedIndexChanged
        'Change datatype in position 3

        If AutoModeLevel = 0 Then 'The units have been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(2)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level. This indicates that the following changes to DataGridView1 are being made automatically.
        Select Case cmbDataType3.SelectedItem
            Case "Nothing"
                DataSettings(2).DataType = DataType.DataTypes._Nothing
                cmbUnits3.Items.Clear()
                cmbUnits3.Items.Add("Nothing")
                cmbUnits3.SelectedIndex = 0
                UpdateDataGridView()
            Case "Point number"
                DataSettings(2).DataType = DataType.DataTypes.Point_Number
                cmbUnits3.Items.Clear()
                cmbUnits3.Items.Add("Number")
                cmbUnits3.SelectedIndex = 0
                UpdateDataGridView()
            Case "Point description"
                DataSettings(2).DataType = DataType.DataTypes.Point_Description
                cmbUnits3.Items.Clear()
                cmbUnits3.Items.Add("Text")
                cmbUnits3.SelectedIndex = 0
                UpdateDataGridView()
            Case "Latitude, Longitude"
                DataSettings(2).DataType = DataType.DataTypes.Latitude_Longitude
                cmbUnits3.Items.Clear()
                cmbUnits3.Items.Add("Decimal Degrees")
                cmbUnits3.Items.Add("Degrees Minutes Seconds")
                cmbUnits3.Items.Add("Sexagesimal Degrees")
                cmbUnits3.Items.Add("Radians")
                cmbUnits3.Items.Add("Gradians")
                cmbUnits3.Items.Add("Turns")
                cmbUnits3.SelectedIndex = 0
                UpdateDataGridView()
            Case "Longitude, Latitude"
                DataSettings(2).DataType = DataType.DataTypes.Longitude_Latitude
                cmbUnits3.Items.Clear()
                cmbUnits3.Items.Add("Decimal Degrees")
                cmbUnits3.Items.Add("Degrees Minutes Seconds")
                cmbUnits3.Items.Add("Sexagesimal Degrees")
                cmbUnits3.Items.Add("Radians")
                cmbUnits3.Items.Add("Gradians")
                cmbUnits3.Items.Add("Turns")
                cmbUnits3.SelectedIndex = 0
                UpdateDataGridView()
            Case "Easting, Northing"
                DataSettings(2).DataType = DataType.DataTypes.Easting_Northing
                cmbUnits3.Items.Clear()
                cmbUnits3.Items.Add("Metres")
                cmbUnits3.Items.Add("Default")
                cmbUnits3.SelectedIndex = 1
                UpdateDataGridView()
            Case "Northing, Easting"
                DataSettings(2).DataType = DataType.DataTypes.Northing_Easting
                cmbUnits3.Items.Clear()
                cmbUnits3.Items.Add("Metres")
                cmbUnits3.Items.Add("Default")
                cmbUnits3.SelectedIndex = 1
                UpdateDataGridView()
            Case Else
                Main.Message.Add("Data type in position 1 not recognised: " & cmbDataType3.SelectedItem & vbCrLf)
                DataSettings(2).DataType = DataType.DataTypes._Nothing
                cmbUnits3.Items.Clear()
                cmbUnits3.Items.Add("Nothing")
                cmbUnits3.SelectedIndex = 0
                UpdateDataGridView()
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then
            RestorePoints()
        End If

    End Sub

    Private Sub cmbDataType4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDataType4.SelectedIndexChanged
        'Change datatype in position 4

        If AutoModeLevel = 0 Then 'The units have been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(3)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level. This indicates that the following changes to DataGridView1 are being made automatically.
        Select Case cmbDataType4.SelectedItem
            Case "Nothing"
                DataSettings(3).DataType = DataType.DataTypes._Nothing
                cmbUnits4.Items.Clear()
                cmbUnits4.Items.Add("Nothing")
                cmbUnits4.SelectedIndex = 0
                UpdateDataGridView()
            Case "Point number"
                DataSettings(3).DataType = DataType.DataTypes.Point_Number
                cmbUnits4.Items.Clear()
                cmbUnits4.Items.Add("Number")
                cmbUnits4.SelectedIndex = 0
                UpdateDataGridView()
            Case "Point description"
                DataSettings(3).DataType = DataType.DataTypes.Point_Description
                cmbUnits4.Items.Clear()
                cmbUnits4.Items.Add("Text")
                cmbUnits4.SelectedIndex = 0
                UpdateDataGridView()
            Case "Latitude, Longitude"
                DataSettings(3).DataType = DataType.DataTypes.Latitude_Longitude
                cmbUnits4.Items.Clear()
                cmbUnits4.Items.Add("Decimal Degrees")
                cmbUnits4.Items.Add("Degrees Minutes Seconds")
                cmbUnits4.Items.Add("Sexagesimal Degrees")
                cmbUnits4.Items.Add("Radians")
                cmbUnits4.Items.Add("Gradians")
                cmbUnits4.Items.Add("Turns")
                cmbUnits4.SelectedIndex = 0
                UpdateDataGridView()
            Case "Longitude, Latitude"
                DataSettings(3).DataType = DataType.DataTypes.Longitude_Latitude
                cmbUnits4.Items.Clear()
                cmbUnits4.Items.Add("Decimal Degrees")
                cmbUnits4.Items.Add("Degrees Minutes Seconds")
                cmbUnits4.Items.Add("Sexagesimal Degrees")
                cmbUnits4.Items.Add("Radians")
                cmbUnits4.Items.Add("Gradians")
                cmbUnits4.Items.Add("Turns")
                cmbUnits4.SelectedIndex = 0
                UpdateDataGridView()
            Case "Easting, Northing"
                DataSettings(3).DataType = DataType.DataTypes.Easting_Northing
                cmbUnits4.Items.Clear()
                cmbUnits4.Items.Add("Metres")
                cmbUnits4.Items.Add("Default")
                cmbUnits4.SelectedIndex = 1
                UpdateDataGridView()
            Case "Northing, Easting"
                DataSettings(3).DataType = DataType.DataTypes.Northing_Easting
                cmbUnits4.Items.Clear()
                cmbUnits4.Items.Add("Metres")
                cmbUnits4.Items.Add("Default")
                cmbUnits4.SelectedIndex = 1
                UpdateDataGridView()
            Case Else
                Main.Message.Add("Data type in position 1 not recognised: " & cmbDataType4.SelectedItem & vbCrLf)
                DataSettings(3).DataType = DataType.DataTypes._Nothing
                cmbUnits4.Items.Clear()
                cmbUnits4.Items.Add("Nothing")
                cmbUnits4.SelectedIndex = 0
                UpdateDataGridView()
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then
            RestorePoints()
        End If

    End Sub

    Private Sub cmbDataType5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDataType5.SelectedIndexChanged
        'Change datatype in position 5

        If AutoModeLevel = 0 Then 'The units have been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(4)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level. This indicates that the following changes to DataGridView1 are being made automatically.
        Select Case cmbDataType5.SelectedItem
            Case "Nothing"
                DataSettings(4).DataType = DataType.DataTypes._Nothing
                cmbUnits5.Items.Clear()
                cmbUnits5.Items.Add("Nothing")
                cmbUnits5.SelectedIndex = 0
                UpdateDataGridView()
            Case "Point number"
                DataSettings(4).DataType = DataType.DataTypes.Point_Number
                cmbUnits5.Items.Clear()
                cmbUnits5.Items.Add("Number")
                cmbUnits5.SelectedIndex = 0
                UpdateDataGridView()
            Case "Point description"
                DataSettings(4).DataType = DataType.DataTypes.Point_Description
                cmbUnits5.Items.Clear()
                cmbUnits5.Items.Add("Text")
                cmbUnits5.SelectedIndex = 0
                UpdateDataGridView()
            Case "Latitude, Longitude"
                DataSettings(4).DataType = DataType.DataTypes.Latitude_Longitude
                cmbUnits5.Items.Clear()
                cmbUnits5.Items.Add("Decimal Degrees")
                cmbUnits5.Items.Add("Degrees Minutes Seconds")
                cmbUnits5.Items.Add("Sexagesimal Degrees")
                cmbUnits5.Items.Add("Radians")
                cmbUnits5.Items.Add("Gradians")
                cmbUnits5.Items.Add("Turns")
                cmbUnits5.SelectedIndex = 0
                UpdateDataGridView()
            Case "Longitude, Latitude"
                DataSettings(4).DataType = DataType.DataTypes.Longitude_Latitude
                cmbUnits5.Items.Clear()
                cmbUnits5.Items.Add("Decimal Degrees")
                cmbUnits5.Items.Add("Degrees Minutes Seconds")
                cmbUnits5.Items.Add("Sexagesimal Degrees")
                cmbUnits5.Items.Add("Radians")
                cmbUnits5.Items.Add("Gradians")
                cmbUnits5.Items.Add("Turns")
                cmbUnits5.SelectedIndex = 0
                UpdateDataGridView()
            Case "Easting, Northing"
                DataSettings(4).DataType = DataType.DataTypes.Easting_Northing
                cmbUnits5.Items.Clear()
                cmbUnits5.Items.Add("Metres")
                cmbUnits5.Items.Add("Default")
                cmbUnits5.SelectedIndex = 1
                UpdateDataGridView()
            Case "Northing, Easting"
                DataSettings(4).DataType = DataType.DataTypes.Northing_Easting
                cmbUnits5.Items.Clear()
                cmbUnits5.Items.Add("Metres")
                cmbUnits5.Items.Add("Default")
                cmbUnits5.SelectedIndex = 1
                UpdateDataGridView()
            Case Else
                Main.Message.Add("Data type in position 1 not recognised: " & cmbDataType5.SelectedItem & vbCrLf)
                DataSettings(4).DataType = DataType.DataTypes._Nothing
                cmbUnits5.Items.Clear()
                cmbUnits5.Items.Add("Nothing")
                cmbUnits5.SelectedIndex = 0
                UpdateDataGridView()
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then
            RestorePoints()
        End If

    End Sub

    Private Sub cmbDataType6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDataType6.SelectedIndexChanged
        'Change datatype in position 6

        If AutoModeLevel = 0 Then 'The units have been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(5)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level. This indicates that the following changes to DataGridView1 are being made automatically.
        Select Case cmbDataType6.SelectedItem
            Case "Nothing"
                DataSettings(5).DataType = DataType.DataTypes._Nothing
                cmbUnits6.Items.Clear()
                cmbUnits6.Items.Add("Nothing")
                cmbUnits6.SelectedIndex = 0
                UpdateDataGridView()
            Case "Point number"
                DataSettings(5).DataType = DataType.DataTypes.Point_Number
                cmbUnits6.Items.Clear()
                cmbUnits6.Items.Add("Number")
                cmbUnits6.SelectedIndex = 0
                UpdateDataGridView()
            Case "Point description"
                DataSettings(5).DataType = DataType.DataTypes.Point_Description
                cmbUnits6.Items.Clear()
                cmbUnits6.Items.Add("Text")
                cmbUnits6.SelectedIndex = 0
                UpdateDataGridView()
            Case "Latitude, Longitude"
                DataSettings(5).DataType = DataType.DataTypes.Latitude_Longitude
                cmbUnits6.Items.Clear()
                cmbUnits6.Items.Add("Decimal Degrees")
                cmbUnits6.Items.Add("Degrees Minutes Seconds")
                cmbUnits6.Items.Add("Sexagesimal Degrees")
                cmbUnits6.Items.Add("Radians")
                cmbUnits6.Items.Add("Gradians")
                cmbUnits6.Items.Add("Turns")
                cmbUnits6.SelectedIndex = 0
                UpdateDataGridView()
            Case "Longitude, Latitude"
                DataSettings(5).DataType = DataType.DataTypes.Longitude_Latitude
                cmbUnits6.Items.Clear()
                cmbUnits6.Items.Add("Decimal Degrees")
                cmbUnits6.Items.Add("Degrees Minutes Seconds")
                cmbUnits6.Items.Add("Sexagesimal Degrees")
                cmbUnits6.Items.Add("Radians")
                cmbUnits6.Items.Add("Gradians")
                cmbUnits6.Items.Add("Turns")
                cmbUnits6.SelectedIndex = 0
                UpdateDataGridView()
            Case "Easting, Northing"
                DataSettings(5).DataType = DataType.DataTypes.Easting_Northing
                cmbUnits6.Items.Clear()
                cmbUnits6.Items.Add("Metres")
                cmbUnits6.Items.Add("Default")
                cmbUnits6.SelectedIndex = 1
                UpdateDataGridView()
            Case "Northing, Easting"
                DataSettings(5).DataType = DataType.DataTypes.Northing_Easting
                cmbUnits6.Items.Clear()
                cmbUnits6.Items.Add("Metres")
                cmbUnits6.Items.Add("Default")
                cmbUnits6.SelectedIndex = 1
                UpdateDataGridView()
            Case Else
                Main.Message.Add("Data type in position 1 not recognised: " & cmbDataType6.SelectedItem & vbCrLf)
                DataSettings(5).DataType = DataType.DataTypes._Nothing
                cmbUnits6.Items.Clear()
                cmbUnits6.Items.Add("Nothing")
                cmbUnits6.SelectedIndex = 0
                UpdateDataGridView()
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then
            RestorePoints()
        End If

    End Sub

    Private Sub cmbUnits1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUnits1.SelectedIndexChanged
        'Change Units in position 1
        'Angle units can be Decimal Degrees, Drgrees-Minutes-Seconds, Sexagesimal Degrees, Radians, Gradians or Turns.
        'Distance units can be Metres or Default (default units are defined for the projection and can be Metres, foot, US survey foot, Clarke's foot, British foot, Indain foot etc.

        If AutoModeLevel = 0 Then 'The units have been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            'SavePoints()
            SavePoints(0)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level.
        Select Case cmbUnits1.SelectedItem
            Case "Nothing"

            Case "Number"

            Case "Text"

            Case "Decimal Degrees"
                DataSettings(0).AngleUnit = DataType.AngleUnits.Decimal_Degrees
            Case "Degrees Minutes Seconds"
                DataSettings(0).AngleUnit = DataType.AngleUnits.Degrees_Minutes_Seconds
            Case "Sexagesimal Degrees"
                DataSettings(0).AngleUnit = DataType.AngleUnits.Sexagesimal_Degrees
            Case "Radians"
                DataSettings(0).AngleUnit = DataType.AngleUnits.Radians
            Case "Gradians"
                DataSettings(0).AngleUnit = DataType.AngleUnits.Gradians
            Case "Turns"
                DataSettings(0).AngleUnit = DataType.AngleUnits.Turns
            Case "Metres"
                DataSettings(0).DistanceUnit = DataType.DistanceUnits.Metres
            Case "Default"
                DataSettings(0).DistanceUnit = DataType.DistanceUnits._Default
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then 'The units have been changed manually. Update the DataGridView using the latest display settings and restore the set of saved coordinate points.
            UpdateDataGridView()
            RestorePoints()
        End If

    End Sub

    Private Sub cmbUnits2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUnits2.SelectedIndexChanged
        'Change Units in position 2

        If AutoModeLevel = 0 Then 'The units have been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(1)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level.
        Select Case cmbUnits2.SelectedItem
            Case "Nothing"

            Case "Number"

            Case "Text"

            Case "Decimal Degrees"
                DataSettings(1).AngleUnit = DataType.AngleUnits.Decimal_Degrees
            Case "Degrees Minutes Seconds"
                DataSettings(1).AngleUnit = DataType.AngleUnits.Degrees_Minutes_Seconds
            Case "Sexagesimal Degrees"
                DataSettings(1).AngleUnit = DataType.AngleUnits.Sexagesimal_Degrees
            Case "Radians"
                DataSettings(1).AngleUnit = DataType.AngleUnits.Radians
            Case "Gradians"
                DataSettings(1).AngleUnit = DataType.AngleUnits.Gradians
            Case "Turns"
                DataSettings(1).AngleUnit = DataType.AngleUnits.Turns
            Case "Metres"
                DataSettings(1).DistanceUnit = DataType.DistanceUnits.Metres
            Case "Default"
                DataSettings(1).DistanceUnit = DataType.DistanceUnits._Default
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then 'The units have been changed manually. Update the DataGridView using the latest display settings and restore the set of saved coordinate points.
            UpdateDataGridView()
            RestorePoints()
        End If

    End Sub

    Private Sub cmbUnits3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUnits3.SelectedIndexChanged
        'Change Units in position 3

        If AutoModeLevel = 0 Then 'The units have been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(2)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level.
        Select Case cmbUnits3.SelectedItem
            Case "Nothing"

            Case "Number"

            Case "Text"

            Case "Decimal Degrees"
                DataSettings(2).AngleUnit = DataType.AngleUnits.Decimal_Degrees
            Case "Degrees Minutes Seconds"
                DataSettings(2).AngleUnit = DataType.AngleUnits.Degrees_Minutes_Seconds
            Case "Sexagesimal Degrees"
                DataSettings(2).AngleUnit = DataType.AngleUnits.Sexagesimal_Degrees
            Case "Radians"
                DataSettings(2).AngleUnit = DataType.AngleUnits.Radians
            Case "Gradians"
                DataSettings(2).AngleUnit = DataType.AngleUnits.Gradians
            Case "Turns"
                DataSettings(2).AngleUnit = DataType.AngleUnits.Turns
            Case "Metres"
                DataSettings(2).DistanceUnit = DataType.DistanceUnits.Metres
            Case "Default"
                DataSettings(2).DistanceUnit = DataType.DistanceUnits._Default
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then 'The units have been changed manually. Update the DataGridView using the latest display settings and restore the set of saved coordinate points.
            UpdateDataGridView()
            RestorePoints()
        End If

    End Sub

    Private Sub cmbUnits4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUnits4.SelectedIndexChanged
        'Change Units in position 4

        If AutoModeLevel = 0 Then 'The units have been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(3)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level.
        Select Case cmbUnits4.SelectedItem
            Case "Nothing"

            Case "Number"

            Case "Text"

            Case "Decimal Degrees"
                DataSettings(3).AngleUnit = DataType.AngleUnits.Decimal_Degrees
            Case "Degrees Minutes Seconds"
                DataSettings(3).AngleUnit = DataType.AngleUnits.Degrees_Minutes_Seconds
            Case "Sexagesimal Degrees"
                DataSettings(3).AngleUnit = DataType.AngleUnits.Sexagesimal_Degrees
            Case "Radians"
                DataSettings(3).AngleUnit = DataType.AngleUnits.Radians
            Case "Gradians"
                DataSettings(3).AngleUnit = DataType.AngleUnits.Gradians
            Case "Turns"
                DataSettings(3).AngleUnit = DataType.AngleUnits.Turns
            Case "Metres"
                DataSettings(3).DistanceUnit = DataType.DistanceUnits.Metres
            Case "Default"
                DataSettings(3).DistanceUnit = DataType.DistanceUnits._Default
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then 'The units have been changed manually. Update the DataGridView using the latest display settings and restore the set of saved coordinate points.
            UpdateDataGridView()
            RestorePoints()
        End If

    End Sub

    Private Sub cmbUnits5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUnits5.SelectedIndexChanged
        'Change Units in position 5

        If AutoModeLevel = 0 Then 'The units have been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(4)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level.
        Select Case cmbUnits5.SelectedItem
            Case "Nothing"

            Case "Number"

            Case "Text"

            Case "Decimal Degrees"
                DataSettings(4).AngleUnit = DataType.AngleUnits.Decimal_Degrees
            Case "Degrees Minutes Seconds"
                DataSettings(4).AngleUnit = DataType.AngleUnits.Degrees_Minutes_Seconds
            Case "Sexagesimal Degrees"
                DataSettings(4).AngleUnit = DataType.AngleUnits.Sexagesimal_Degrees
            Case "Radians"
                DataSettings(4).AngleUnit = DataType.AngleUnits.Radians
            Case "Gradians"
                DataSettings(4).AngleUnit = DataType.AngleUnits.Gradians
            Case "Turns"
                DataSettings(4).AngleUnit = DataType.AngleUnits.Turns
            Case "Metres"
                DataSettings(4).DistanceUnit = DataType.DistanceUnits.Metres
            Case "Default"
                DataSettings(4).DistanceUnit = DataType.DistanceUnits._Default
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then 'The units have been changed manually. Update the DataGridView using the latest display settings and restore the set of saved coordinate points.
            UpdateDataGridView()
            RestorePoints()
        End If

    End Sub

    Private Sub cmbUnits6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUnits6.SelectedIndexChanged
        'Change Units in position 6

        If AutoModeLevel = 0 Then 'The units have been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(5)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level.
        Select Case cmbUnits6.SelectedItem
            Case "Nothing"

            Case "Number"

            Case "Text"

            Case "Decimal Degrees"
                DataSettings(5).AngleUnit = DataType.AngleUnits.Decimal_Degrees
            Case "Degrees Minutes Seconds"
                DataSettings(5).AngleUnit = DataType.AngleUnits.Degrees_Minutes_Seconds
            Case "Sexagesimal Degrees"
                DataSettings(5).AngleUnit = DataType.AngleUnits.Sexagesimal_Degrees
            Case "Radians"
                DataSettings(5).AngleUnit = DataType.AngleUnits.Radians
            Case "Gradians"
                DataSettings(5).AngleUnit = DataType.AngleUnits.Gradians
            Case "Turns"
                DataSettings(5).AngleUnit = DataType.AngleUnits.Turns
            Case "Metres"
                DataSettings(5).DistanceUnit = DataType.DistanceUnits.Metres
            Case "Default"
                DataSettings(5).DistanceUnit = DataType.DistanceUnits._Default
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then 'The units have been changed manually. Update the DataGridView using the latest display settings and restore the set of saved coordinate points.
            UpdateDataGridView()
            RestorePoints()
        End If

    End Sub

    Private Sub cmbDirection1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDirection1.SelectedIndexChanged
        'Change direction code in position 1

        If AutoModeLevel = 0 Then 'The direction has been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(0)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level.
        Select Case cmbDirection1.SelectedItem
            Case "+/-"
                DataSettings(0).ValueDirection = DataType.ValueDirections.Plus_Minus
            Case "E/W_N/S"
                DataSettings(0).ValueDirection = DataType.ValueDirections.E_W_N_S
            Case "East/West_North/South"
                DataSettings(0).ValueDirection = DataType.ValueDirections.East_West_North_South
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then 'The units have been changed manually. Update the DataGridView using the latest display settings and restore the set of saved coordinate points.
            UpdateDataGridView()
            RestorePoints()
        End If

    End Sub

    Private Sub cmbDirection2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDirection2.SelectedIndexChanged
        'Change direction code in position 2

        If AutoModeLevel = 0 Then 'The direction has been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(1)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level.
        Select Case cmbDirection2.SelectedItem
            Case "+/-"
                DataSettings(1).ValueDirection = DataType.ValueDirections.Plus_Minus
            Case "E/W_N/S"
                DataSettings(1).ValueDirection = DataType.ValueDirections.E_W_N_S
            Case "East/West_North/South"
                DataSettings(1).ValueDirection = DataType.ValueDirections.East_West_North_South
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then 'The units have been changed manually. Update the DataGridView using the latest display settings and restore the set of saved coordinate points.
            UpdateDataGridView()
            RestorePoints()
        End If

    End Sub

    Private Sub cmbDirection3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDirection3.SelectedIndexChanged
        'Change direction code in position 3

        If AutoModeLevel = 0 Then 'The direction has been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(2)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level.
        Select Case cmbDirection3.SelectedItem
            Case "+/-"
                DataSettings(2).ValueDirection = DataType.ValueDirections.Plus_Minus
            Case "E/W_N/S"
                DataSettings(2).ValueDirection = DataType.ValueDirections.E_W_N_S
            Case "East/West_North/South"
                DataSettings(2).ValueDirection = DataType.ValueDirections.East_West_North_South
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then 'The units have been changed manually. Update the DataGridView using the latest display settings and restore the set of saved coordinate points.
            UpdateDataGridView()
            RestorePoints()
        End If

    End Sub

    Private Sub cmbDirection4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDirection4.SelectedIndexChanged
        'Change direction code in position 4

        If AutoModeLevel = 0 Then 'The direction has been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(3)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level.
        Select Case cmbDirection4.SelectedItem
            Case "+/-"
                DataSettings(3).ValueDirection = DataType.ValueDirections.Plus_Minus
            Case "E/W_N/S"
                DataSettings(3).ValueDirection = DataType.ValueDirections.E_W_N_S
            Case "East/West_North/South"
                DataSettings(3).ValueDirection = DataType.ValueDirections.East_West_North_South
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then 'The units have been changed manually. Update the DataGridView using the latest display settings and restore the set of saved coordinate points.
            UpdateDataGridView()
            RestorePoints()
        End If

    End Sub

    Private Sub cmbDirection5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDirection5.SelectedIndexChanged
        'Change direction code in position 5

        If AutoModeLevel = 0 Then 'The direction has been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(4)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level.
        Select Case cmbDirection5.SelectedItem
            Case "+/-"
                DataSettings(4).ValueDirection = DataType.ValueDirections.Plus_Minus
            Case "E/W_N/S"
                DataSettings(4).ValueDirection = DataType.ValueDirections.E_W_N_S
            Case "East/West_North/South"
                DataSettings(4).ValueDirection = DataType.ValueDirections.East_West_North_South
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then 'The units have been changed manually. Update the DataGridView using the latest display settings and restore the set of saved coordinate points.
            UpdateDataGridView()
            RestorePoints()
        End If

    End Sub

    Private Sub cmbDirection6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDirection6.SelectedIndexChanged
        'Change direction code in position 6

        If AutoModeLevel = 0 Then 'The direction has been changed manually. Save the current set of coordinate points then clear the DataGridView1 values.
            SavePoints(5)
            ClearGridValues()
        End If

        AutoModeLevel += 1 'Increment the AutoMode level.
        Select Case cmbDirection6.SelectedItem
            Case "+/-"
                DataSettings(5).ValueDirection = DataType.ValueDirections.Plus_Minus
            Case "E/W_N/S"
                DataSettings(5).ValueDirection = DataType.ValueDirections.E_W_N_S
            Case "East/West_North/South"
                DataSettings(5).ValueDirection = DataType.ValueDirections.East_West_North_South
        End Select
        AutoModeLevel -= 1 'Decrement the AutoMode level.

        If AutoModeLevel = 0 Then 'The units have been changed manually. Update the DataGridView using the latest display settings and restore the set of saved coordinate points.
            UpdateDataGridView()
            RestorePoints()
        End If

    End Sub




    Private Sub SavePoints(ByVal ExcludeDataColNo As Integer)
        'Save all the points in DataGridView1.
        'The column number in ExcludeDataColNo is excluded from the save.

        'The following arrays (declared at form level above) store the set of points while the grid display settings are being modified.
        'Dim PointNumber() As Integer
        'Dim PointDescription() As String
        'Dim PointLatitude() As Double
        'Dim PointLongitude() As Double

        Dim NumberDataCol As Integer = -1      'The number of the data column containing point numbers. (-1 if none found.)
        Dim DescriptionDataCol As Integer = -1 'The number of the data column containing point descriptions. (-1 if none found.)
        Dim LocationDataCol As Integer = -1    'The number of the data column containing the point locations. (-1 if none found.) 
        '                                       The first single lat long data column will be used. 
        '                                       If no single lat long data column is found, the first Lat Long data column will be used.  
        '                                       If no Lat Long data columms found, the first Easting Northing data column will be used.

        Dim NumberGridCol As Integer            'The column number in DataGridView corresponding to NumberDataCol.
        Dim DescrGridCol As Integer             'The column number in DataGridView corresponding to DescriptionDataCol
        Dim LocationGridCol As Integer          'The column number in DataGridView at the start ofLocationDataCol

        Dim GridColumnNo As Integer = 0 'GridColumnNo is the number of the column in DataGridView

        'Find the data column numbers:
        Dim DataColumn As Integer

        For DataColumn = 0 To 5
            If DataColumn = ExcludeDataColNo Then
                'This column is excluded from processing. (The column type may have been changed and the column data is no longer valid.)
            Else
                Select Case DataSettings(DataColumn).DataType
                    Case DataType.DataTypes.Point_Number
                        If NumberDataCol = -1 Then 'Select this data column for the Number Data
                            NumberDataCol = DataColumn
                        End If
                    Case DataType.DataTypes.Point_Description
                        If DescriptionDataCol = -1 Then 'Select this data column for the Description Data
                            DescriptionDataCol = DataColumn
                        End If
                    Case DataType.DataTypes.Latitude_Longitude
                        If DataSettings(DataColumn).AngleUnit = DataType.AngleUnits.Decimal_Degrees Then
                            If LocationDataCol = -1 Then
                                LocationDataCol = DataColumn
                            End If
                        End If
                    Case DataType.DataTypes.Longitude_Latitude
                        If DataSettings(DataColumn).AngleUnit = DataType.AngleUnits.Decimal_Degrees Then
                            If LocationDataCol = -1 Then
                                LocationDataCol = DataColumn
                            End If
                        End If
                End Select
            End If
        Next

        If LocationDataCol = -1 Then 'Lat Long decimal degrees data column not found. Find any other Lat Long data column.
            For DataColumn = 0 To 5
                If DataColumn = ExcludeDataColNo Then
                    'This column is excluded from processing. (The column type may have been changed and the column data is no longer valid.)
                Else
                    Select Case DataSettings(DataColumn).DataType
                        Case DataType.DataTypes.Latitude_Longitude
                            If LocationDataCol = -1 Then
                                LocationDataCol = DataColumn
                            End If
                        Case DataType.DataTypes.Longitude_Latitude
                            If LocationDataCol = -1 Then
                                LocationDataCol = DataColumn
                            End If
                    End Select
                End If
            Next
        End If

        If LocationDataCol = -1 Then 'No Lat Long data columns have been found. Find a easting northing data column.
            For DataColumn = 0 To 5
                If DataColumn = ExcludeDataColNo Then
                    'This column is excluded from processing. (The column type may have been changed and the column data is no longer valid.)
                Else
                    Select Case DataSettings(DataColumn).DataType
                        Case DataType.DataTypes.Northing_Easting
                            If LocationDataCol = -1 Then
                                LocationDataCol = DataColumn
                            End If
                        Case DataType.DataTypes.Easting_Northing
                            If LocationDataCol = -1 Then
                                LocationDataCol = DataColumn
                            End If
                    End Select
                End If
            Next
        End If

        Dim NPoints As Integer 'The number of points to save.
        NPoints = DataGridView1.Rows.Count - 1

        Dim I As Integer

        'NCols = DataSettings(0).NColumns + DataSettings(1).NColumns + DataSettings(2).NColumns + DataSettings(3).NColumns + DataSettings(4).NColumns + DataSettings(5).NColumns
        'NumberDataCol The number of the data column containing point numbers. (-1 if none found.)
        'GridColumnNo is the number of the column in DataGridView

        If NumberDataCol = -1 Then
            'There is not a Point Number column in DataGridView1
        Else 'NumberDataCol points to the DataColumn containing the Point Numbers.
            NumberGridCol = DataSettings(NumberDataCol).FirstColumnNo
        End If

        If DescriptionDataCol = -1 Then
            'There is not a Description column in DataGridView1
        Else 'DescriptionDataCol points to the DataColumn containing the Point Descriptions.
            DescrGridCol = DataSettings(DescriptionDataCol).FirstColumnNo
        End If

        If LocationDataCol = -1 Then
            'There is not a Location column in DataGridView1
        Else
            LocationGridCol = DataSettings(LocationDataCol).FirstColumnNo
        End If

        'Read the Point Number data:
        If NumberDataCol = -1 Then
            'No point number data available.
            ReDim PointNumber(0 To 0)
        Else
            ReDim PointNumber(0 To NPoints - 1)
            For I = 0 To NPoints - 1
                PointNumber(I) = DataGridView1.Rows(I).Cells(NumberGridCol).Value
            Next
        End If

        'Read the Point Description data:
        If DescriptionDataCol = -1 Then
            'No point description data available.
            ReDim PointDescription(0 To 0)
        Else
            ReDim PointDescription(0 To NPoints - 1)
            For I = 0 To NPoints - 1
                PointDescription(I) = DataGridView1.Rows(I).Cells(DescrGridCol).Value
            Next
        End If

        'Read the Point Location data:
        If LocationDataCol = -1 Then
            'No point location data available.
            ReDim PointLatitude(0 To 0)
            ReDim PointLongitude(0 To 0)
        Else
            ReDim PointLatitude(0 To NPoints - 1)
            ReDim PointLongitude(0 To NPoints - 1)
            Select Case DataSettings(LocationDataCol).DataType
                Case DataType.DataTypes.Latitude_Longitude
                    Select Case DataSettings(LocationDataCol).AngleUnit
                        Case DataType.AngleUnits.Decimal_Degrees
                            Select Case DataSettings(LocationDataCol).ValueDirection
                                Case DataType.ValueDirections.E_W_N_S '| Lat Dec Deg | N/S | Lon Dec Deg | E/W | --------------------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "N" Then
                                            PointLatitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "S" Then
                                            PointLatitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol).Value * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "E" Then
                                            PointLongitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "W" Then
                                            PointLongitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.East_West_North_South '| Lat Dec Deg | North/South | Lon Dec Deg | East/West | ----------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "North" Then
                                            PointLatitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "South" Then
                                            PointLatitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol).Value * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "East" Then
                                            PointLongitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "West" Then
                                            PointLongitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.Plus_Minus '| +/- Lat Dec Deg | +/- Lon Dec Deg | ---------------------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        PointLatitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                        PointLongitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                    Next
                            End Select
                        Case DataType.AngleUnits.Gradians
                            Select Case DataSettings(LocationDataCol).ValueDirection
                                Case DataType.ValueDirections.E_W_N_S '| Lat Dec Gradians | N/S | Lon Dec Gradians | E/W | ----------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "N" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "S" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "E" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "W" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.East_West_North_South '| Lat Dec Gradians | North/South | Lon Dec Gradians | East/West | -------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "North" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "South" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "East" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "West" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.Plus_Minus  '| +/- Lat Dec Gradians | +/- Lon Dec Gradians | -----------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                        AngleConvert.ConvertGradianToDecimalDegree()
                                        PointLatitude(I) = AngleConvert.DecimalDegrees
                                        AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                        AngleConvert.ConvertGradianToDecimalDegree()
                                        PointLongitude(I) = AngleConvert.DecimalDegrees
                                    Next
                            End Select
                        Case DataType.AngleUnits.Radians
                            Select Case DataSettings(LocationDataCol).ValueDirection
                                Case DataType.ValueDirections.E_W_N_S  '| Lat Dec Radians | N/S | Lon Dec Radians | E/W | -----------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "N" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "S" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "E" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "W" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.East_West_North_South '| Lat Dec Radians | North/South | Lon Dec Radians | East/West | --------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "North" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "South" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "East" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "West" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.Plus_Minus '| +/- Lat Dec Radians | +/- Lon Dec Radians | -------------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                        AngleConvert.ConvertRadianToDecimalDegree()
                                        PointLatitude(I) = AngleConvert.DecimalDegrees
                                        AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                        AngleConvert.ConvertRadianToDecimalDegree()
                                        PointLongitude(I) = AngleConvert.DecimalDegrees
                                    Next
                            End Select
                        Case DataType.AngleUnits.Sexagesimal_Degrees
                            Select Case DataSettings(LocationDataCol).ValueDirection
                                Case DataType.ValueDirections.E_W_N_S  '| Lat Sexagesimal Deg | N/S | Lon Sexagesimal Deg | E/W | ---------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "N" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "S" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "E" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "W" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.East_West_North_South '| Lat Sexagesimal Deg | North/South | Lon Sexagesimal Deg | East/West | ------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "North" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "South" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "East" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "West" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.Plus_Minus '| +/- Lat Sexagesimal Deg | +/- Lon Sexagesimal Deg | -----------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                        AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                        PointLatitude(I) = AngleConvert.DecimalDegrees
                                        AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                        AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                        PointLongitude(I) = AngleConvert.DecimalDegrees
                                    Next
                            End Select
                        Case DataType.AngleUnits.Turns
                            Select Case DataSettings(LocationDataCol).ValueDirection
                                Case DataType.ValueDirections.E_W_N_S '| Lat Dec Turns | N/S | Lon Dec Turns | E/W | ----------------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "N" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "S" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "E" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "W" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.East_West_North_South  '| Lat Dec Turns | North/South | Lon Dec Turns | East/West | -----------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "North" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "South" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "East" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "West" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.Plus_Minus '| +/- Lat Dec Turns | +/- Lon Dec Turns | -----------------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                        AngleConvert.ConvertTurnToDecimalDegree()
                                        PointLatitude(I) = AngleConvert.DecimalDegrees
                                        AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                        AngleConvert.ConvertTurnToDecimalDegree()
                                        PointLongitude(I) = AngleConvert.DecimalDegrees
                                    Next
                            End Select
                        Case DataType.AngleUnits.Degrees_Minutes_Seconds
                            Select Case DataSettings(LocationDataCol).ValueDirection
                                Case DataType.ValueDirections.E_W_N_S '| Lat Deg | Min | Sec | N/S | Lon Dec | Min | Sec | E/W | ----------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "N" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            PointLatitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "S" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            PointLatitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value = "E" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 4).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 5).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 6).Value
                                            PointLongitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value = "W" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 4).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 5).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 6).Value
                                            PointLongitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.East_West_North_South '| Lat Deg | Min | Sec | North/South | Lon Dec | Min | Sec | East/West | ------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "North" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            PointLatitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "South" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            PointLatitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value = "East" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 4).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 5).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 6).Value
                                            PointLongitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value = "West" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 4).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 5).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 6).Value
                                            PointLongitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.Plus_Minus '| +/- | Lat Deg | Min | Sec | +/- | Lon Dec | Min | Sec | -------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol).Value = "+" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value
                                            PointLatitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol).Value = "-" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value
                                            PointLatitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 4).Value = "+" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 5).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 6).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value
                                            PointLongitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 4).Value = "-" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 5).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 6).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value
                                            PointLongitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 4).Value & vbCrLf)
                                        End If
                                    Next
                            End Select
                    End Select
                Case DataType.DataTypes.Longitude_Latitude
                    Select Case DataSettings(LocationDataCol).AngleUnit
                        Case DataType.AngleUnits.Decimal_Degrees
                            Select Case DataSettings(LocationDataCol).ValueDirection
                                Case DataType.ValueDirections.E_W_N_S '| Lon Dec Deg | N/S | Lat Dec Deg | E/W | --------------------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "N" Then
                                            PointLongitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "S" Then
                                            PointLongitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol).Value * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "E" Then
                                            PointLatitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "W" Then
                                            PointLatitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.East_West_North_South  '| Lon Dec Deg | North/South | Lat Dec Deg | East/West | -----------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "North" Then
                                            PointLongitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "South" Then
                                            PointLongitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol).Value * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "East" Then
                                            PointLatitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "West" Then
                                            PointLatitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.Plus_Minus '| +/- Lon Dec Deg | +/- Lat Dec Deg | ---------------------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        PointLongitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                        PointLatitude(I) = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                    Next
                            End Select
                        Case DataType.AngleUnits.Gradians
                            Select Case DataSettings(LocationDataCol).ValueDirection
                                Case DataType.ValueDirections.E_W_N_S '| Lon Dec Gradians | N/S | Lat Dec Gradians | E/W | ----------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "N" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "S" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "E" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "W" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.East_West_North_South '| Lon Dec Gradians | North/South | Lat Dec Gradians | East/West | -----------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "North" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "South" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "East" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "West" Then
                                            AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertGradianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.Plus_Minus '| +/- Lon Dec Gradians | +/- Lat Dec Gradians | ----------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                        AngleConvert.ConvertGradianToDecimalDegree()
                                        PointLongitude(I) = AngleConvert.DecimalDegrees
                                        AngleConvert.Gradians = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                        AngleConvert.ConvertGradianToDecimalDegree()
                                        PointLatitude(I) = AngleConvert.DecimalDegrees
                                    Next
                            End Select
                        Case DataType.AngleUnits.Radians
                            Select Case DataSettings(LocationDataCol).ValueDirection
                                Case DataType.ValueDirections.E_W_N_S '| Lon Dec Radians | N/S | Lat Dec Radians | E/W | ----------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "N" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "S" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "E" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "W" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.East_West_North_South  '| Lon Dec Radians | North/South | Lat Dec Radians | East/West | ------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "North" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "South" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "East" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "West" Then
                                            AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertRadianToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.Plus_Minus '| +/- Lon Dec Radians | +/- Lat Dec Radians | ----------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                        AngleConvert.ConvertRadianToDecimalDegree()
                                        PointLongitude(I) = AngleConvert.DecimalDegrees
                                        AngleConvert.Radians = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                        AngleConvert.ConvertRadianToDecimalDegree()
                                        PointLatitude(I) = AngleConvert.DecimalDegrees
                                    Next
                            End Select
                        Case DataType.AngleUnits.Sexagesimal_Degrees
                            Select Case DataSettings(LocationDataCol).ValueDirection
                                Case DataType.ValueDirections.E_W_N_S '| Lon Sexagesimal Deg | N/S | Lat Sexagesimal Deg | E/W | ---------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "N" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "S" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "E" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "W" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.East_West_North_South '| Lon Sexagesimal Deg | North/South | Lat Sexagesimal Deg | East/West | -----------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "North" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "South" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "East" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "West" Then
                                            AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.Plus_Minus '| +/- Lon Sexagesimal Deg | +/- Lat Sexagesimal Deg | ----------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                        AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                        PointLongitude(I) = AngleConvert.DecimalDegrees
                                        AngleConvert.SexagesimalDegrees = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                        AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                        PointLatitude(I) = AngleConvert.DecimalDegrees
                                    Next
                            End Select
                        Case DataType.AngleUnits.Turns
                            Select Case DataSettings(LocationDataCol).ValueDirection
                                Case DataType.ValueDirections.E_W_N_S '| Lon Dec Turns | N/S | Lat Dec Turns | E/W | ----------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "N" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "S" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "E" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "W" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.East_West_North_South '| Lon Dec Turns | North/South | Lat Dec Turns | East/West | ------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "North" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value = "South" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLongitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "East" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "West" Then
                                            AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleConvert.ConvertTurnToDecimalDegree()
                                            PointLatitude(I) = AngleConvert.DecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.Plus_Minus '| +/- Lon Dec Turns | +/- Lat Dec Turns | ----------------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                        AngleConvert.ConvertTurnToDecimalDegree()
                                        PointLongitude(I) = AngleConvert.DecimalDegrees
                                        AngleConvert.Turns = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                        AngleConvert.ConvertTurnToDecimalDegree()
                                        PointLatitude(I) = AngleConvert.DecimalDegrees
                                    Next
                            End Select
                        Case DataType.AngleUnits.Degrees_Minutes_Seconds
                            Select Case DataSettings(LocationDataCol).ValueDirection
                                Case DataType.ValueDirections.E_W_N_S '| Lon Deg | Min | Sec | N/S | Lat Dec | Min | Sec | E/W | ----------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "N" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            PointLongitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "S" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            PointLongitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value = "E" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 4).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 5).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 6).Value
                                            PointLatitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value = "W" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 4).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 5).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 6).Value
                                            PointLatitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.East_West_North_South '| Lon Deg | Min | Sec | North/South | Lat Dec | Min | Sec | East/West | ------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "North" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            PointLongitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value = "South" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            PointLongitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value = "East" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 4).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 5).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 6).Value
                                            PointLatitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value = "West" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 4).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 5).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 6).Value
                                            PointLatitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value & vbCrLf)
                                        End If
                                    Next
                                Case DataType.ValueDirections.Plus_Minus '| +/- | Lon Deg | Min | Sec | +/- | Lat Dec | Min | Sec | -------------------------------------------------------------------
                                    For I = 0 To NPoints - 1
                                        If DataGridView1.Rows(I).Cells(LocationGridCol).Value = "+" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value
                                            PointLongitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol).Value = "-" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 1).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 2).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 3).Value
                                            PointLongitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown latitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol).Value & vbCrLf)
                                        End If
                                        If DataGridView1.Rows(I).Cells(LocationGridCol + 4).Value = "+" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 5).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 6).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value
                                            PointLatitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees
                                        ElseIf DataGridView1.Rows(I).Cells(LocationGridCol + 4).Value = "-" Then
                                            AngleDegMinSec.Degrees = DataGridView1.Rows(I).Cells(LocationGridCol + 5).Value
                                            AngleDegMinSec.Minutes = DataGridView1.Rows(I).Cells(LocationGridCol + 6).Value
                                            AngleDegMinSec.Seconds = DataGridView1.Rows(I).Cells(LocationGridCol + 7).Value
                                            PointLatitude(I) = AngleDegMinSec.DegMinSecToDecimalDegrees * -1
                                        Else
                                            Main.Message.Add("Unknown longitude direction code: " & DataGridView1.Rows(I).Cells(LocationGridCol + 4).Value & vbCrLf)
                                        End If
                                    Next
                            End Select
                    End Select
                Case DataType.DataTypes.Easting_Northing
                    Select Case DataSettings(LocationDataCol).DistanceUnit
                        Case DataType.DistanceUnits._Default '| Easting | Northing | (default units)
                            Main.Message.Add("No latitude, longitude points avaiable. Easting, Northing points (default units) avaialble. " & vbCrLf)
                        Case DataType.DistanceUnits.Metres '| Easting | Northing | (metres)
                            Main.Message.Add("No latitude, longitude points avaiable. Easting, Northing points (metres) avaialble. " & vbCrLf)
                    End Select
                Case DataType.DataTypes.Northing_Easting
                    Select Case DataSettings(LocationDataCol).DistanceUnit
                        Case DataType.DistanceUnits._Default  '| Easting | Northing | (default units)
                            Main.Message.Add("No latitude, longitude points avaiable. Northing, Easting points (default units) avaialble. " & vbCrLf)
                        Case DataType.DistanceUnits.Metres '| NorthingEasting | Northing | (metres)
                            Main.Message.Add("No latitude, longitude points avaiable. Northing, Easting points (metres) avaialble. " & vbCrLf)
                    End Select
            End Select
        End If

    End Sub

    Private Sub RestorePoints()
        'Restores the value of the points in DataGridView1.

        'The following arrays (declared at form level above) store the set of points while the grid display settings are being modified.
        'Dim PointNumber() As Integer
        'Dim PointDescription() As String
        'Dim PointLatitude() As Double
        'Dim PointLongitude() As Double

        AutoModeLevel += 1 'Increment the AutoMode level.

        Dim DataColNo As Integer 'The current data column number.
        Dim FirstGridCol As Integer 'The corresponding first grid column number in DataGridView1
        Dim RowNo As Integer 'The current row number in DataGridView1
        Dim NRows As Integer 'The number of rows of data to write to DataGridView1.


        For DataColNo = 0 To 5
            FirstGridCol = DataSettings(DataColNo).FirstColumnNo
            Select Case DataSettings(DataColNo).DataType
                Case DataType.DataTypes._Nothing

                Case DataType.DataTypes.Point_Number
                    NRows = PointNumber.Count
                    For RowNo = 0 To NRows - 1
                        DataGridView1.Rows(RowNo).Cells(DataSettings(DataColNo).FirstColumnNo).Value = PointNumber(RowNo)
                    Next
                Case DataType.DataTypes.Point_Description
                    NRows = PointDescription.Count
                    For RowNo = 0 To NRows - 1
                        DataGridView1.Rows(RowNo).Cells(DataSettings(DataColNo).FirstColumnNo).Value = PointDescription(RowNo)
                    Next
                Case DataType.DataTypes.Latitude_Longitude
                    If (PointLatitude.Count > 0) And (PointLongitude.Count > 0) Then
                        Select Case DataSettings(DataColNo).AngleUnit
                            Case DataType.AngleUnits.Decimal_Degrees
                                Select Case DataSettings(DataColNo).ValueDirection
                                    Case DataType.ValueDirections.E_W_N_S '| Lat Dec Deg | N/S | Lon Dec Deg | E/W | --------------------------------------------------------------------------------------
                                        For I = 0 To NRows - 1
                                            If PointLatitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "N"
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = PointLatitude(I)
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "S"
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = Math.Abs(PointLatitude(I))
                                            End If
                                            If PointLongitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "E"
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = PointLongitude(I)
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "W"
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = Math.Abs(PointLongitude(I))
                                            End If
                                        Next
                                    Case DataType.ValueDirections.East_West_North_South '| Lat Dec Deg | North/South | Lon Dec Deg | East/West | ----------------------------------------------------------
                                        For I = 0 To NRows - 1
                                            If PointLatitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "North"
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = PointLatitude(I)
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "South"
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = Math.Abs(PointLatitude(I))
                                            End If
                                            If PointLongitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "East"
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = PointLongitude(I)
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "West"
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = Math.Abs(PointLongitude(I))
                                            End If
                                        Next
                                    Case DataType.ValueDirections.Plus_Minus '| +/- Lat Dec Deg | +/- Lon Dec Deg | ---------------------------------------------------------------------------------------
                                        For I = 0 To NRows - 1
                                            DataGridView1.Rows(I).Cells(FirstGridCol).Value = PointLatitude(I)
                                            DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = PointLongitude(I)
                                        Next
                                End Select
                            Case DataType.AngleUnits.Gradians
                                Select Case DataSettings(DataColNo).ValueDirection
                                    Case DataType.ValueDirections.E_W_N_S '| Lat Dec Gradians | N/S | Lon Dec Gradians | E/W | ----------------------------------------------------------------------------
                                        For I = 0 To NRows - 1
                                            If PointLatitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "N"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToGradian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleConvert.Gradians
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "S"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToGradian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = Math.Abs(AngleConvert.Gradians)
                                            End If
                                            If PointLongitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "E"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToGradian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = AngleConvert.Gradians
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "W"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToGradian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = Math.Abs(AngleConvert.Gradians)
                                            End If
                                        Next
                                    Case DataType.ValueDirections.East_West_North_South '| Lat Dec Gradians | North/South | Lon Dec Gradians | East/West | -------------------------------------------------
                                        For I = 0 To NRows - 1
                                            If PointLatitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "North"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToGradian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleConvert.Gradians
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "South"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToGradian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = Math.Abs(AngleConvert.Gradians)
                                            End If
                                            If PointLongitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "East"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToGradian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = AngleConvert.Gradians
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "West"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToGradian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = Math.Abs(AngleConvert.Gradians)
                                            End If
                                        Next
                                    Case DataType.ValueDirections.Plus_Minus  '| +/- Lat Dec Gradians | +/- Lon Dec Gradians | -----------------------------------------------------------------------------
                                        For I = 0 To NRows - 1
                                            AngleConvert.DecimalDegrees = PointLatitude(I)
                                            AngleConvert.ConvertDecimalDegreeToGradian()
                                            DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleConvert.Gradians
                                            AngleConvert.DecimalDegrees = PointLongitude(I)
                                            AngleConvert.ConvertDecimalDegreeToGradian()
                                            DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = AngleConvert.Gradians
                                        Next
                                End Select
                            Case DataType.AngleUnits.Radians
                                Select Case DataSettings(DataColNo).ValueDirection
                                    Case DataType.ValueDirections.E_W_N_S  '| Lat Dec Radians | N/S | Lon Dec Radians | E/W | -----------------------------------------------------------------------------
                                        For I = 0 To NRows - 1
                                            If PointLatitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "N"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToRadian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleConvert.Radians
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "S"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToRadian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = Math.Abs(AngleConvert.Radians)
                                            End If
                                            If PointLongitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "E"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToRadian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = AngleConvert.Radians
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "W"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToRadian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = Math.Abs(AngleConvert.Radians)
                                            End If
                                        Next
                                    Case DataType.ValueDirections.East_West_North_South '| Lat Dec Radians | North/South | Lon Dec Radians | East/West | --------------------------------------------------
                                        For I = 0 To NRows - 1
                                            If PointLatitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "North"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToRadian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleConvert.Radians
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "South"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToRadian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = Math.Abs(AngleConvert.Radians)
                                            End If
                                            If PointLongitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "East"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToRadian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = AngleConvert.Radians
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "West"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToRadian()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = Math.Abs(AngleConvert.Radians)
                                            End If
                                        Next
                                    Case DataType.ValueDirections.Plus_Minus '| +/- Lat Dec Radians | +/- Lon Dec Radians | -------------------------------------------------------------------------------
                                        For I = 0 To NRows - 1
                                            AngleConvert.DecimalDegrees = PointLatitude(I)
                                            AngleConvert.ConvertDecimalDegreeToRadian()
                                            DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleConvert.Radians
                                            AngleConvert.DecimalDegrees = PointLongitude(I)
                                            AngleConvert.ConvertDecimalDegreeToRadian()
                                            DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = AngleConvert.Radians
                                        Next
                                End Select
                            Case DataType.AngleUnits.Sexagesimal_Degrees
                                Select Case DataSettings(DataColNo).ValueDirection
                                    Case DataType.ValueDirections.E_W_N_S  '| Lat Sexagesimal Deg | N/S | Lon Sexagesimal Deg | E/W | ---------------------------------------------------------------------
                                        For I = 0 To NRows - 1
                                            If PointLatitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "N"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleConvert.SexagesimalDegrees
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "S"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = Math.Abs(AngleConvert.SexagesimalDegrees)
                                            End If
                                            If PointLongitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "E"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = AngleConvert.SexagesimalDegrees
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "W"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = Math.Abs(AngleConvert.SexagesimalDegrees)
                                            End If
                                        Next
                                    Case DataType.ValueDirections.East_West_North_South '| Lat Sexagesimal Deg | North/South | Lon Sexagesimal Deg | East/West | ------------------------------------------
                                        For I = 0 To NRows - 1
                                            If PointLatitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "North"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleConvert.SexagesimalDegrees
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "South"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = Math.Abs(AngleConvert.SexagesimalDegrees)
                                            End If
                                            If PointLongitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "East"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = AngleConvert.SexagesimalDegrees
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "West"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = Math.Abs(AngleConvert.SexagesimalDegrees)
                                            End If
                                        Next
                                    Case DataType.ValueDirections.Plus_Minus '| +/- Lat Sexagesimal Deg | +/- Lon Sexagesimal Deg | -----------------------------------------------------------------------
                                        For I = 0 To NRows - 1
                                            AngleConvert.DecimalDegrees = PointLatitude(I)
                                            AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                            DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleConvert.SexagesimalDegrees
                                            AngleConvert.DecimalDegrees = PointLongitude(I)
                                            AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                            DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = AngleConvert.SexagesimalDegrees
                                        Next
                                End Select
                            Case DataType.AngleUnits.Turns
                                Select Case DataSettings(DataColNo).ValueDirection
                                    Case DataType.ValueDirections.E_W_N_S '| Lat Dec Turns | N/S | Lon Dec Turns | E/W | ----------------------------------------------------------------------------------
                                        For I = 0 To NRows - 1
                                            If PointLatitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "N"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToTurn()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleConvert.Turns
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "S"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToTurn()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = Math.Abs(AngleConvert.Turns)
                                            End If
                                            If PointLongitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "E"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToTurn()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = AngleConvert.Turns
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "W"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToTurn()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = Math.Abs(AngleConvert.Turns)
                                            End If
                                        Next
                                    Case DataType.ValueDirections.East_West_North_South  '| Lat Dec Turns | North/South | Lon Dec Turns | East/West | -----------------------------------------------------
                                        For I = 0 To NRows - 1
                                            If PointLatitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "North"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToTurn()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleConvert.Turns
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = "South"
                                                AngleConvert.DecimalDegrees = PointLatitude(I)
                                                AngleConvert.ConvertDecimalDegreeToTurn()
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = Math.Abs(AngleConvert.Turns)
                                            End If
                                            If PointLongitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "East"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToTurn()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = AngleConvert.Turns
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "West"
                                                AngleConvert.DecimalDegrees = PointLongitude(I)
                                                AngleConvert.ConvertDecimalDegreeToTurn()
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = Math.Abs(AngleConvert.Turns)
                                            End If
                                        Next
                                    Case DataType.ValueDirections.Plus_Minus '| +/- Lat Dec Turns | +/- Lon Dec Turns | -----------------------------------------------------------------------------------
                                        For I = 0 To NRows - 1
                                            AngleConvert.DecimalDegrees = PointLatitude(I)
                                            AngleConvert.ConvertDecimalDegreeToTurn()
                                            DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleConvert.Turns
                                            AngleConvert.DecimalDegrees = PointLongitude(I)
                                            AngleConvert.ConvertDecimalDegreeToTurn()
                                            DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = AngleConvert.Turns
                                        Next
                                End Select
                            Case DataType.AngleUnits.Degrees_Minutes_Seconds
                                Select Case DataSettings(DataColNo).ValueDirection
                                    Case DataType.ValueDirections.E_W_N_S '| Lat Deg | Min | Sec | N/S | Lon Dec | Min | Sec | E/W | ----------------------------------------------------------------------
                                        For I = 0 To NRows - 1
                                            If PointLatitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "N"
                                                AngleDegMinSec.DecimalDegreesToDegMinSec(PointLatitude(I))
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleDegMinSec.Degrees
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = AngleDegMinSec.Minutes
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = AngleDegMinSec.Seconds
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "S"
                                                AngleDegMinSec.DecimalDegreesToDegMinSec(Math.Abs(PointLatitude(I)))
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleDegMinSec.Degrees
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = AngleDegMinSec.Minutes
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = AngleDegMinSec.Seconds
                                            End If
                                            If PointLongitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 7).Value = "E"
                                                AngleDegMinSec.DecimalDegreesToDegMinSec(PointLongitude(I))
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 4).Value = AngleDegMinSec.Degrees
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 5).Value = AngleDegMinSec.Minutes
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 6).Value = AngleDegMinSec.Seconds
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 7).Value = "W"
                                                AngleDegMinSec.DecimalDegreesToDegMinSec(Math.Abs(PointLongitude(I)))
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 4).Value = AngleDegMinSec.Degrees
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 5).Value = AngleDegMinSec.Minutes
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 6).Value = AngleDegMinSec.Seconds
                                            End If
                                        Next
                                    Case DataType.ValueDirections.East_West_North_South '| Lat Deg | Min | Sec | North/South | Lon Dec | Min | Sec | East/West | ------------------------------------------
                                        For I = 0 To NRows - 1
                                            If PointLatitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "North"
                                                AngleDegMinSec.DecimalDegreesToDegMinSec(PointLatitude(I))
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleDegMinSec.Degrees
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = AngleDegMinSec.Minutes
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = AngleDegMinSec.Seconds
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = "South"
                                                AngleDegMinSec.DecimalDegreesToDegMinSec(Math.Abs(PointLatitude(I)))
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = AngleDegMinSec.Degrees
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = AngleDegMinSec.Minutes
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = AngleDegMinSec.Seconds
                                            End If
                                            If PointLongitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 7).Value = "East"
                                                AngleDegMinSec.DecimalDegreesToDegMinSec(PointLongitude(I))
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 4).Value = AngleDegMinSec.Degrees
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 5).Value = AngleDegMinSec.Minutes
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 6).Value = AngleDegMinSec.Seconds
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 7).Value = "West"
                                                AngleDegMinSec.DecimalDegreesToDegMinSec(Math.Abs(PointLongitude(I)))
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 4).Value = AngleDegMinSec.Degrees
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 5).Value = AngleDegMinSec.Minutes
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 6).Value = AngleDegMinSec.Seconds
                                            End If
                                        Next
                                    Case DataType.ValueDirections.Plus_Minus '| +/- | Lat Deg | Min | Sec | +/- | Lon Dec | Min | Sec | -------------------------------------------------------------------
                                        For I = 0 To NRows - 1
                                            If PointLatitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = "+"
                                                AngleDegMinSec.DecimalDegreesToDegMinSec(PointLatitude(I))
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = AngleDegMinSec.Degrees
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = AngleDegMinSec.Minutes
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = AngleDegMinSec.Seconds
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol).Value = "-"
                                                AngleDegMinSec.DecimalDegreesToDegMinSec(Math.Abs(PointLatitude(I)))
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = AngleDegMinSec.Degrees
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 2).Value = AngleDegMinSec.Minutes
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 3).Value = AngleDegMinSec.Seconds
                                            End If
                                            If PointLongitude(I) >= 0 Then
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 4).Value = "+"
                                                AngleDegMinSec.DecimalDegreesToDegMinSec(PointLongitude(I))
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 5).Value = AngleDegMinSec.Degrees
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 6).Value = AngleDegMinSec.Minutes
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 7).Value = AngleDegMinSec.Seconds
                                            Else
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 4).Value = "-"
                                                AngleDegMinSec.DecimalDegreesToDegMinSec(Math.Abs(PointLongitude(I)))
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 5).Value = AngleDegMinSec.Degrees
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 6).Value = AngleDegMinSec.Minutes
                                                DataGridView1.Rows(I).Cells(FirstGridCol + 7).Value = AngleDegMinSec.Seconds
                                            End If
                                        Next
                                End Select
                        End Select
                    End If
                Case DataType.DataTypes.Longitude_Latitude
                    'TO DO ----------------------------------------------------------------------

                Case DataType.DataTypes.Northing_Easting
                    If (PointLatitude.Count > 0) And (PointLongitude.Count > 0) Then
                        Select Case DataSettings(DataColNo).DistanceUnit
                            Case DataType.DistanceUnits._Default
                                For I = 0 To NRows - 1
                                    TransverseMercator.Location.Latitude = PointLatitude(I)
                                    TransverseMercator.Location.Longitude = PointLongitude(I)
                                    TransverseMercator.LatLonToEastNorth()
                                    DataGridView1.Rows(I).Cells(FirstGridCol).Value = TransverseMercator.Location.Northing
                                    DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = TransverseMercator.Location.Easting
                                Next
                            Case DataType.DistanceUnits.Metres

                        End Select
                    End If
                Case DataType.DataTypes.Easting_Northing
                    If (PointLatitude.Count > 0) And (PointLongitude.Count > 0) Then
                        Select Case DataSettings(DataColNo).DistanceUnit
                            Case DataType.DistanceUnits._Default
                                For I = 0 To NRows - 1
                                    TransverseMercator.Location.Latitude = PointLatitude(I)
                                    TransverseMercator.Location.Longitude = PointLongitude(I)
                                    TransverseMercator.LatLonToEastNorth()
                                    DataGridView1.Rows(I).Cells(FirstGridCol).Value = TransverseMercator.Location.Easting
                                    DataGridView1.Rows(I).Cells(FirstGridCol + 1).Value = TransverseMercator.Location.Northing
                                Next
                            Case DataType.DistanceUnits.Metres

                        End Select
                    End If
            End Select
        Next

        AutoModeLevel -= 1 'Decrement the AutoMode level.

    End Sub

    Private Sub ClearGridValues()
        'Clear all the values from DataGridView1

        Main.Message.Add("Clearing grid values" & vbCrLf)

        Dim RowNo As Integer
        Dim NRows As Integer
        Dim ColNo As Integer
        Dim NCols As Integer

        NRows = DataGridView1.Rows.Count
        NCols = DataGridView1.Columns.Count

        AutoModeLevel += 1 'Increment the AutoMode level.

        For ColNo = 0 To NCols - 1
            For RowNo = 0 To NRows - 1
                DataGridView1.Rows(RowNo).Cells(ColNo).Value = Nothing
            Next
        Next

        AutoModeLevel -= 1 'Decrement the AutoMode level.

    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        'A cell value has changed in DataGridView1

        If AutoModeLevel > 0 Then 'Cell values have been changed automatically. No need to process the changes.
            Exit Sub
        End If

        AutoModeLevel += 1

        Dim RowNo As Integer
        Dim CurrentGridColumnNo As Integer 'The column number in DataGridView of the cell value that changed.
        Dim NDataColumns As Integer 'The number of data columns. This is currently set at 6. Each data column may have more than one value column (eg deg, min ,sec). A data column may be set to "Nothing".
        Dim DataColumnNo As Integer = -1 'The data column number of the cell value that changed. (A value of -1 indicates an invalid column number.)
        Dim DataSubColumnNo As Integer = -1 'The sub column within the data column of the cell value that changed. (A value of -1 indicates an invalid sub column number.)
        Dim Col1 As Integer = -1 'The first Grid Column Number of the first sub column in the current data column.

        '|   Data Col 1          |   Data Col 2      |    Data Col 3         |      Data Col 4       |
        '| eg Point Number       | eg Point Descr    | eg Lat    : eg Long   | eg East   : eg North  |
        '| Sub Col 1             | Sub Col 1         | Sub Col 1 : Sub Col 2 | Sub Col 1 : Sub Col 2 |
        '|
        '

        RowNo = e.RowIndex
        If RowNo < 0 Then
            AutoModeLevel -= 1
            Exit Sub
        End If

        CurrentGridColumnNo = e.ColumnIndex 'This is the column number of the edited cell in DataGridView1

        NDataColumns = DataSettings.Count 'This is the number of data columns that can be displayed in DataGridView1. (Some data columns use more than one grid column.)

        Dim I As Integer

        'Get the data column number:
        For I = 0 To NDataColumns - 1
            If CurrentGridColumnNo >= DataSettings(I).FirstColumnNo Then
                If CurrentGridColumnNo <= DataSettings(I).FirstColumnNo + DataSettings(I).NColumns - 1 Then
                    DataColumnNo = I
                    DataSubColumnNo = CurrentGridColumnNo - DataSettings(I).FirstColumnNo
                    Col1 = DataSettings(I).FirstColumnNo
                    Exit For
                End If
            End If
        Next

        If DataColumnNo > -1 Then
            'Main.Message.Add("Current data column type: " & DataSettings(DataColumnNo).DataType.ToString & "  Angle units: " & DataSettings(DataColumnNo).AngleUnit.ToString & vbCrLf)

            Select Case DataSettings(DataColumnNo).DataType.ToString
                Case "Point_Number"
                    'The point number has been edited. No further processing required.
                Case "Point_Description"
                    'The point description has been edited. No further processing required.
                Case "Latitude_Longitude"
                    'The latitude,Longitude coordinates have been edited.
                    Select Case DataSettings(DataColumnNo).AngleUnit.ToString
                        Case "Decimal_Degrees"
                            Select Case DataSettings(DataColumnNo).ValueDirection.ToString
                                Case "Plus_Minus"
                                    'Data format is |+/-Latitude|+/-Longitude|
                                    TransverseMercator.Location.Latitude = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value)
                                    TransverseMercator.Location.Longitude = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value)
                                    TransverseMercator.LatLonToEastNorth()
                                    UpdateDataGridViewRow(RowNo, DataColumnNo) 'RowNo is the row to be updated. DataColumnNo id the column that has just been edited and will NOT be updated.
                                Case "East_West_North_South"
                                    'Data format is |Latitude|North/South|Longitude|East/West|
                                    If DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value = "North" Then
                                        TransverseMercator.Location.Latitude = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value)
                                    ElseIf DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value = "South" Then
                                        TransverseMercator.Location.Latitude = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value) * -1
                                    Else
                                        Main.Message.Add("Unknown Latitude direction: " & DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value & vbCrLf)
                                    End If
                                    If DataGridView1.Rows(RowNo).Cells(Col1 + 3).Value = "East" Then
                                        TransverseMercator.Location.Longitude = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 2).Value)
                                    ElseIf DataGridView1.Rows(RowNo).Cells(Col1 + 3).Value = "West" Then
                                        TransverseMercator.Location.Longitude = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 2).Value) * -1
                                    Else
                                        Main.Message.Add("Unknown Longitude direction: " & DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value & vbCrLf)
                                    End If
                                    TransverseMercator.LatLonToEastNorth()
                                    UpdateDataGridViewRow(RowNo, DataColumnNo) 'RowNo is the row to be updated. DataColumnNo is the column that has just been edited and will NOT be updated.
                                Case "E_W_N_S"
                                    'Data format is |Latitude|N/S|Longitude|E/W|
                                    If DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value = "N" Then
                                        TransverseMercator.Location.Latitude = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value)
                                    ElseIf DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value = "S" Then
                                        TransverseMercator.Location.Latitude = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value) * -1
                                    Else
                                        Main.Message.Add("Unknown Latitude direction: " & DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value & vbCrLf)
                                    End If
                                    If DataGridView1.Rows(RowNo).Cells(Col1 + 3).Value = "E" Then
                                        TransverseMercator.Location.Longitude = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 2).Value)
                                    ElseIf DataGridView1.Rows(RowNo).Cells(Col1 + 3).Value = "W" Then
                                        TransverseMercator.Location.Longitude = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 2).Value) * -1
                                    Else
                                        Main.Message.Add("Unknown Longitude direction: " & DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value & vbCrLf)
                                    End If
                                    TransverseMercator.LatLonToEastNorth()
                                    UpdateDataGridViewRow(RowNo, DataColumnNo) 'RowNo is the row to be updated. DataColumnNo is the column that has just been edited and will NOT be updated.
                            End Select
                        Case "Degrees_Minutes_Seconds"
                            Select Case DataSettings(DataColumnNo).ValueDirection.ToString
                                Case "Plus_Minus"
                                    'Data format is |+/-|Latitude Degrees|Minutes|Seconds|+/-|Longitude Degrees|Minutes|Seconds|
                                    If Trim(DataGridView1.Rows(RowNo).Cells(Col1).Value) = "" Then
                                        DataGridView1.Rows(RowNo).Cells(Col1).Value = "+"
                                    End If
                                    If DataGridView1.Rows(RowNo).Cells(Col1).Value = "+" Then
                                        AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Positive 'TDS_Utilities.Coordinates.clsAngleDegMinSec.Sign.Positive
                                    ElseIf DataGridView1.Rows(RowNo).Cells(Col1).Value = "-" Then
                                        AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative 'TDS_Utilities.Coordinates.clsAngleDegMinSec.Sign.Negative
                                    Else
                                        Main.Message.Add("Unknown Latitude direction: " & DataGridView1.Rows(RowNo).Cells(Col1).Value & vbCrLf)
                                    End If
                                    AngleDegMinSec.Degrees = DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value
                                    AngleDegMinSec.Minutes = DataGridView1.Rows(RowNo).Cells(Col1 + 2).Value
                                    AngleDegMinSec.Seconds = DataGridView1.Rows(RowNo).Cells(Col1 + 3).Value
                                    TransverseMercator.Location.Latitude = AngleDegMinSec.DegMinSecToDecimalDegrees()
                                    Main.Message.Add("Latitude = " & TransverseMercator.Location.Latitude & vbCrLf)
                                    If Trim(DataGridView1.Rows(RowNo).Cells(Col1 + 4).Value) = "" Then
                                        DataGridView1.Rows(RowNo).Cells(Col1 + 4).Value = "+"
                                    End If
                                    If DataGridView1.Rows(RowNo).Cells(Col1 + 4).Value = "+" Then
                                        AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Positive 'TDS_Utilities.Coordinates.clsAngleDegMinSec.Sign.Positive
                                    ElseIf DataGridView1.Rows(RowNo).Cells(Col1 + 4).Value = "-" Then
                                        AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative 'TDS_Utilities.Coordinates.clsAngleDegMinSec.Sign.Negative
                                    Else
                                        Main.Message.Add("Unknown Longitude direction: " & DataGridView1.Rows(RowNo).Cells(Col1 + 4).Value & vbCrLf)
                                    End If
                                    AngleDegMinSec.Degrees = DataGridView1.Rows(RowNo).Cells(Col1 + 5).Value
                                    AngleDegMinSec.Minutes = DataGridView1.Rows(RowNo).Cells(Col1 + 6).Value
                                    AngleDegMinSec.Seconds = DataGridView1.Rows(RowNo).Cells(Col1 + 7).Value
                                    TransverseMercator.Location.Longitude = AngleDegMinSec.DegMinSecToDecimalDegrees()
                                    Main.Message.Add("Longitude = " & TransverseMercator.Location.Longitude & vbCrLf)
                                    TransverseMercator.LatLonToEastNorth()
                                    UpdateDataGridViewRow(RowNo, DataColumnNo) 'RowNo is the row to be updated. DataColumnNo is the column that has just been edited and will NOT be updated.
                                Case "East_West_North_South"
                                    'Data format is |Latitude Degrees|Minutes|Seconds|North/South|Longitude Degrees|Minutes|Seconds|East/West|
                                    AngleDegMinSec.Degrees = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value)
                                    AngleDegMinSec.Minutes = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value)
                                    AngleDegMinSec.Seconds = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 2).Value)
                                    If DataGridView1.Rows(RowNo).Cells(Col1 + 3).Value = "South" Then
                                        AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative
                                    Else
                                        AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Positive
                                    End If
                                    TransverseMercator.Location.Latitude = AngleDegMinSec.DegMinSecToDecimalDegrees()
                                    AngleDegMinSec.Degrees = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 4).Value)
                                    AngleDegMinSec.Minutes = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 5).Value)
                                    AngleDegMinSec.Seconds = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 6).Value)
                                    If DataGridView1.Rows(RowNo).Cells(Col1 + 7).Value = "West" Then
                                        AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative
                                    Else
                                        AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Positive
                                    End If
                                    TransverseMercator.Location.Longitude = AngleDegMinSec.DegMinSecToDecimalDegrees()
                                    TransverseMercator.LatLonToEastNorth()
                                    UpdateDataGridViewRow(RowNo, DataColumnNo) 'RowNo is the row to be updated. DataColumnNo is the column that has just been edited and will NOT be updated.
                                Case "E_W_N_S"
                                    'Data format is |Latitude Degrees|Minutes|Seconds|N/S|Longitude Degrees|Minutes|Seconds|E/W|
                                    AngleDegMinSec.Degrees = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value)
                                    AngleDegMinSec.Minutes = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value)
                                    AngleDegMinSec.Seconds = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 2).Value)
                                    If DataGridView1.Rows(RowNo).Cells(Col1 + 3).Value = "S" Then
                                        AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative
                                    Else
                                        AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Positive
                                    End If
                                    TransverseMercator.Location.Latitude = AngleDegMinSec.DegMinSecToDecimalDegrees()
                                    AngleDegMinSec.Degrees = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 4).Value)
                                    AngleDegMinSec.Minutes = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 5).Value)
                                    AngleDegMinSec.Seconds = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 6).Value)
                                    If DataGridView1.Rows(RowNo).Cells(Col1 + 7).Value = "W" Then
                                        AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative
                                    Else
                                        AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Positive
                                    End If
                                    TransverseMercator.Location.Longitude = AngleDegMinSec.DegMinSecToDecimalDegrees()
                                    TransverseMercator.LatLonToEastNorth()
                                    UpdateDataGridViewRow(RowNo, DataColumnNo) 'RowNo is the row to be updated. DataColumnNo is the column that has just been edited and will NOT be updated.
                            End Select
                        Case "Sexagesimal_Degrees"
                            Select Case DataSettings(DataColumnNo).ValueDirection.ToString
                                Case "Plus_Minus"
                                    'Data format is |+/- Latitude Sexagesimal Degrees|+/- Longitude Sexagesimal Degrees|
                                    AngleConvert.SexagesimalDegrees = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value)
                                    AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                    TransverseMercator.Location.Latitude = AngleConvert.DecimalDegrees
                                    AngleConvert.SexagesimalDegrees = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value)
                                    AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                    TransverseMercator.Location.Longitude = AngleConvert.DecimalDegrees
                                    TransverseMercator.LatLonToEastNorth()
                                    UpdateDataGridViewRow(RowNo, DataColumnNo) 'RowNo is the row to be updated. DataColumnNo id the column that has just been edited and will NOT be updated.
                                Case "East_West_North_South"
                                    'Data format is |Latitude Sexagesimal Degrees|North/South|Longitude Sexagesimal Degrees|East/West|
                                    If DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value = "North" Then
                                        'TransverseMercator.Location.Latitude = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value)
                                        AngleConvert.SexagesimalDegrees = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value)
                                    ElseIf DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value = "South" Then
                                        'TransverseMercator.Location.Latitude = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value) * -1
                                        AngleConvert.SexagesimalDegrees = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value) * -1
                                    Else
                                        Main.Message.Add("Unknown Latitude direction: " & DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value & vbCrLf)
                                        AngleConvert.SexagesimalDegrees = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value)  'Assume it is North
                                    End If
                                    'AngleConvert.SexagesimalDegrees = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value)
                                    AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                    TransverseMercator.Location.Latitude = AngleConvert.DecimalDegrees
                                    If DataGridView1.Rows(RowNo).Cells(Col1 + 3).Value = "East" Then
                                        'TransverseMercator.Location.Longitude = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 2).Value)
                                        AngleConvert.SexagesimalDegrees = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 2).Value)
                                    ElseIf DataGridView1.Rows(RowNo).Cells(Col1 + 3).Value = "West" Then
                                        'TransverseMercator.Location.Longitude = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 2).Value) * -1
                                        AngleConvert.SexagesimalDegrees = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 2).Value) * -1
                                    Else
                                        Main.Message.Add("Unknown Longitude direction: " & DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value & vbCrLf)
                                        AngleConvert.SexagesimalDegrees = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 2).Value) 'Assume it is East
                                    End If
                                    'AngleConvert.SexagesimalDegrees = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value)
                                    AngleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                    TransverseMercator.Location.Longitude = AngleConvert.DecimalDegrees
                                    TransverseMercator.LatLonToEastNorth()
                                    UpdateDataGridViewRow(RowNo, DataColumnNo) 'RowNo is the row to be updated. DataColumnNo id the column that has just been edited and will NOT be updated.
                                Case "E_W_N_S"
                                    'Data format is |Latitude Sexagesimal Degrees|N/S|Longitude Sexagesimal Degrees|E/W|
                            End Select
                        Case "Radians"
                            Select Case DataSettings(DataColumnNo).ValueDirection.ToString
                                Case "Plus_Minus"
                                    'Data format is |+/-|Latitude Radians|+/-|Longitude Radians|
                                Case "East_West_North_South"
                                    'Data format is |Latitude Radians|North/South|Longitude Radians|East/West|
                                Case "E_W_N_S"
                                    'Data format is |Latitude Radians|N/S|Longitude Radians|E/W|
                            End Select
                        Case "Gradians"
                            Select Case DataSettings(DataColumnNo).ValueDirection.ToString
                                Case "Plus_Minus"
                                    'Data format is |+/-|Latitude Gradians|+/-|Longitude Gradians|
                                Case "East_West_North_South"
                                    'Data format is |Latitude Gradians|North/South|Longitude Gradians|East/West|
                                Case "E_W_N_S"
                                    'Data format is |Latitude Gradians|N/S|Longitude Gradians|E/W|
                            End Select
                        Case "Turns"
                            Select Case DataSettings(DataColumnNo).ValueDirection.ToString
                                Case "Plus_Minus"
                                    'Data format is |+/-|Latitude Turns|+/-|Longitude Turns|
                                Case "East_West_North_South"
                                    'Data format is |Latitude Turns|North/South|Longitude Turns|East/West|
                                Case "E_W_N_S"
                                    'Data format is |Latitude Turns|N/S|Longitude Turns|E/W|
                            End Select
                    End Select
                Case "Longitude_Latitude"

                Case "Northing_Easting"
                    TransverseMercator.Location.Northing = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value)
                    TransverseMercator.Location.Easting = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value)
                    TransverseMercator.EastNorthToLatLon()
                    UpdateDataGridViewRow(RowNo, DataColumnNo) 'RowNo is the row to be updated. DataColumnNo id the column that has just been edited and will NOT be updated.
                Case "Easting_Northing"
                    TransverseMercator.Location.Easting = Val(DataGridView1.Rows(RowNo).Cells(Col1).Value)
                    TransverseMercator.Location.Northing = Val(DataGridView1.Rows(RowNo).Cells(Col1 + 1).Value)
                    TransverseMercator.EastNorthToLatLon()
                    UpdateDataGridViewRow(RowNo, DataColumnNo) 'RowNo is the row to be updated. DataColumnNo id the column that has just been edited and will NOT be updated.
            End Select

            'DataType:
            '_Nothing            'No data is stored in this position.
            'Point_Number        'The number of the point.
            'Point_Description   'A description of the point.
            'Latitude_Longitude  'The latitude and longitude of the point.
            'Longitude_Latitude  'The longitude and latitude of the point.
            'Northing_Easting    'The northing and easting of the point.
            'Easting_Northing    'The easting and northing of the point.

            'AngleUnits:
            'Decimal_Degrees
            'Degrees_Minutes_Seconds
            'Sexagesimal_Degrees
            'Radians
            'Gradians
            'Turns

            'DistanceUnits:
            'Metres
            'Feet

            'ValueDirection:
            'Plus_Minus
            'East_West_North_South
            'E_W_N_S
            '()
        End If

        AutoModeLevel -= 1

    End Sub

    Private Sub UpdateDataGridViewRow(ByVal RowNo As Integer, ByVal EditedDataColumnNo As Integer)
        'Update the row RowNo in DataGridView.
        '
        'THIS CODE HANDLES TRANSVERSE MERCATOR PROJECTIONS ONLY - NEED TO UPDATE FOR OTHER PROJECTIONS
        'The updated latitudes, longitudes, easting and northings are in TransverseMercator.
        'EditedDataColumnNo is the DataColumn that contains the new point coordinates and need not be changed.
        'All other coordinate data columns must be updated with the coordinate values found in TransverseMercator.

        'Coordinates are stored in TransverseMercator:
        'TransverseMercator.Location.Latitude
        'TransverseMercator.Location.Longitude
        'TransverseMercator.Location.Easting
        'TransverseMercator.Location.Northing

        Dim NCols As Integer

        NCols = DataSettings(0).NColumns + DataSettings(1).NColumns + DataSettings(2).NColumns + DataSettings(3).NColumns + DataSettings(4).NColumns + DataSettings(5).NColumns
        Main.Message.Add("Total number of columns in DataGridView1: " & NCols & vbCrLf)

        DataGridView1.ColumnCount = NCols

        'Process each data position in DataSettings()
        Dim DataCol As Integer 'Loop index
        Dim FirstGridColNo As Integer = 0 'GridColumnNo is the number of the column in DataGridView
        For DataCol = 0 To 5
            FirstGridColNo = DataSettings(DataCol).FirstColumnNo 'The number of the first grid column of this data type when displayed in the DataGridView.
            If DataCol = EditedDataColumnNo Then
                'This column was just edited and should not be changed.
            Else
                Select Case DataSettings(DataCol).DataType
                    Case DataType.DataTypes.Point_Number
                        'Leave entry unchanged
                    Case DataType.DataTypes.Point_Description
                        'Leave entry unchanged
                    Case DataType.DataTypes.Longitude_Latitude '
                        Select Case DataSettings(DataCol).AngleUnit
                            Case DataType.AngleUnits.Decimal_Degrees
                                Select Case DataSettings(DataCol).ValueDirection
                                    Case DataType.ValueDirections.Plus_Minus '| +/- Dec Deg Longitude | +/- Dec Deg Latitude | ---------------------------------------------------------------------------
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = TransverseMercator.Location.Longitude
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = TransverseMercator.Location.Latitude
                                    Case DataType.ValueDirections.E_W_N_S '| Dec Deg Longitude | E/W | Dec Deg Latitude | N/S | --------------------------------------------------------------------------
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(TransverseMercator.Location.Longitude)
                                        If TransverseMercator.Location.Longitude >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "E"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "W"
                                        End If
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(TransverseMercator.Location.Latitude)
                                        If TransverseMercator.Location.Latitude >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "N"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "S"
                                        End If
                                    Case DataType.ValueDirections.East_West_North_South '| Deg Deg Longitude | East/West | Dec Deg Latitude | North/South | ----------------------------------------------
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(TransverseMercator.Location.Longitude)
                                        If TransverseMercator.Location.Longitude >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "East"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "West"
                                        End If
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(TransverseMercator.Location.Latitude)
                                        If TransverseMercator.Location.Latitude >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "North"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "South"
                                        End If
                                End Select
                            Case DataType.AngleUnits.Gradians
                                Select Case DataSettings(DataCol).ValueDirection
                                    Case DataType.ValueDirections.Plus_Minus '| +/- Gradians Longitude | +/- Gradians Latitude | ---------------------------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToGradian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = AngleConvert.Gradians
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToGradian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = AngleConvert.Gradians
                                    Case DataType.ValueDirections.E_W_N_S '| Gradians Longitude | E/W | Gradians Latitude | N/S | ------------------------------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToGradian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "E"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "W"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToGradian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "N"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "S"
                                        End If
                                    Case DataType.ValueDirections.East_West_North_South '| Gradians Longitude | East/West | Gradians Latitude | North/South | --------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToGradian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "East"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "West"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToGradian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "North"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "South"
                                        End If
                                End Select
                            Case DataType.AngleUnits.Radians
                                Select Case DataSettings(DataCol).ValueDirection
                                    Case DataType.ValueDirections.Plus_Minus  '| +/- Radians Longitude | +/- Radians Latitude | ----------------------------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToRadian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = AngleConvert.Radians
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToRadian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = AngleConvert.Radians
                                    Case DataType.ValueDirections.E_W_N_S '| Radians Longitude | E/W | Radians Latitude | N/S | --------------------------------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToRadian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.Radians)
                                        If AngleConvert.Radians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "E"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "W"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToRadian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.Radians)
                                        If AngleConvert.Radians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "N"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "S"
                                        End If
                                    Case DataType.ValueDirections.East_West_North_South '| Radians Longitude | East/West | Radians Latitude | North/South | ----------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToRadian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.Radians)
                                        If AngleConvert.Radians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "East"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "West"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToRadian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.Radians)
                                        If AngleConvert.Radians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "North"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "South"
                                        End If
                                End Select
                            Case DataType.AngleUnits.Sexagesimal_Degrees
                                Select Case DataSettings(DataCol).ValueDirection
                                    Case DataType.ValueDirections.Plus_Minus  '| +/- Sexagesimal Degrees Longitude | +/- Sexagesimal Degrees Latitude | ----------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = AngleConvert.SexagesimalDegrees
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = AngleConvert.SexagesimalDegrees
                                    Case DataType.ValueDirections.E_W_N_S '| Sexagesimal Degrees Longitude | E/W | Sexagesimal Degrees Latitude | N/S | --------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.SexagesimalDegrees)
                                        If AngleConvert.SexagesimalDegrees >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "E"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "W"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.SexagesimalDegrees)
                                        If AngleConvert.SexagesimalDegrees >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "N"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "S"
                                        End If
                                    Case DataType.ValueDirections.East_West_North_South '| Sexagesimal Degrees Longitude | East/West | Sexagesimal Degrees Latitude | North/South | ----------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.SexagesimalDegrees)
                                        If AngleConvert.SexagesimalDegrees >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "East"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "West"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.SexagesimalDegrees)
                                        If AngleConvert.SexagesimalDegrees >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "North"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "South"
                                        End If
                                End Select
                            Case DataType.AngleUnits.Turns
                                Select Case DataSettings(DataCol).ValueDirection
                                    Case DataType.ValueDirections.Plus_Minus  '| +/- Turns Longitude | +/- Turns Latitude | --------------------------------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToTurn()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = AngleConvert.Turns
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToTurn()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = AngleConvert.Turns
                                    Case DataType.ValueDirections.E_W_N_S '| Turns Longitude | E/W | Turns Latitude | N/S | ------------------------------------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToTurn()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.Turns)
                                        If AngleConvert.Turns >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "E"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "W"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToTurn()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.Turns)
                                        If AngleConvert.Turns >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "N"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "S"
                                        End If
                                    Case DataType.ValueDirections.East_West_North_South '| Turns Longitude | East/West | Turns Latitude | North/South | --------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToTurn()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.Turns)
                                        If AngleConvert.Turns >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "East"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "West"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToTurn()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.Turns)
                                        If AngleConvert.Turns >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "North"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "South"
                                        End If
                                End Select
                            Case DataType.AngleUnits.Degrees_Minutes_Seconds
                                Select Case DataSettings(DataCol).ValueDirection
                                    Case DataType.ValueDirections.Plus_Minus '| +/- | Deg Min Sec Longitude | +/- | Deg Min Sec Latitude | ---------------------------------------------------------------
                                        AngleDegMinSec.DecimalDegreesToDegMinSec(TransverseMercator.Location.Longitude)
                                        If AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = "-"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = "+"
                                        End If
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = AngleDegMinSec.Degrees
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = AngleDegMinSec.Minutes
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = AngleDegMinSec.Seconds
                                        AngleDegMinSec.DecimalDegreesToDegMinSec(TransverseMercator.Location.Latitude)
                                        If AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 4).Value = "-"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 4).Value = "+"
                                        End If
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 5).Value = AngleDegMinSec.Degrees
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 6).Value = AngleDegMinSec.Minutes
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 7).Value = AngleDegMinSec.Seconds
                                    Case DataType.ValueDirections.E_W_N_S '| Deg Min Sec Longitude | E/W | Deg Min Sec Latitude | N/S | ------------------------------------------------------------------
                                        AngleDegMinSec.DecimalDegreesToDegMinSec(TransverseMercator.Location.Longitude)
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = AngleDegMinSec.Degrees
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = AngleDegMinSec.Minutes
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = AngleDegMinSec.Seconds
                                        If AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "W"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "E"
                                        End If
                                        AngleDegMinSec.DecimalDegreesToDegMinSec(TransverseMercator.Location.Latitude)
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 4).Value = AngleDegMinSec.Degrees
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 5).Value = AngleDegMinSec.Minutes
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 6).Value = AngleDegMinSec.Seconds
                                        If AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 7).Value = "S"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 7).Value = "N"
                                        End If
                                    Case DataType.ValueDirections.East_West_North_South '| Deg Min Sec Longitude | East/West | Deg Min Sec Latitude | North/South | --------------------------------------
                                        AngleDegMinSec.DecimalDegreesToDegMinSec(TransverseMercator.Location.Longitude)
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = AngleDegMinSec.Degrees
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = AngleDegMinSec.Minutes
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = AngleDegMinSec.Seconds
                                        If AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "West"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "East"
                                        End If
                                        AngleDegMinSec.DecimalDegreesToDegMinSec(TransverseMercator.Location.Latitude)
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 4).Value = AngleDegMinSec.Degrees
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 5).Value = AngleDegMinSec.Minutes
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 6).Value = AngleDegMinSec.Seconds
                                        If AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 7).Value = "South"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 7).Value = "North"
                                        End If
                                End Select
                        End Select
                    Case DataType.DataTypes.Latitude_Longitude
                        Select Case DataSettings(DataCol).AngleUnit
                            Case DataType.AngleUnits.Decimal_Degrees
                                Select Case DataSettings(DataCol).ValueDirection
                                    Case DataType.ValueDirections.Plus_Minus '| +/- | Dec Deg Latitude | +/- | Dec Deg Longitude | -----------------------------------------------------------------------
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = TransverseMercator.Location.Latitude
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = TransverseMercator.Location.Longitude
                                    Case DataType.ValueDirections.E_W_N_S '| Dec Deg Latitude | N/S | Dec Deg Longitude | E/W | ---------------------------------------------------------------------------
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(TransverseMercator.Location.Latitude)
                                        If TransverseMercator.Location.Latitude >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "N"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "S"
                                        End If
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(TransverseMercator.Location.Longitude)
                                        If TransverseMercator.Location.Longitude >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "E"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "W"
                                        End If
                                    Case DataType.ValueDirections.East_West_North_South '| Deg Deg Latitude | North/South | Dec Deg Longitude | East/West | ----------------------------------------------
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(TransverseMercator.Location.Latitude)
                                        If TransverseMercator.Location.Latitude >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "North"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "South"
                                        End If
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(TransverseMercator.Location.Longitude)
                                        If TransverseMercator.Location.Longitude >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "East"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "West"
                                        End If
                                End Select
                            Case DataType.AngleUnits.Gradians
                                Select Case DataSettings(DataCol).ValueDirection
                                    Case DataType.ValueDirections.Plus_Minus '| +/- Gradians Latitude | +/- Gradians Longitude | ---------------------------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToGradian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = AngleConvert.Gradians
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToGradian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = AngleConvert.Gradians
                                    Case DataType.ValueDirections.E_W_N_S '| Gradians Latitude | N/S | Gradians Longitude | E/W | ------------------------------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToGradian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "E"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "W"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToGradian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "N"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "S"
                                        End If
                                    Case DataType.ValueDirections.East_West_North_South '| Gradians Latitude | North/South | Gradians Longitude | East/West | --------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToGradian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "East"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "West"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToGradian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "North"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "South"
                                        End If
                                End Select
                            Case DataType.AngleUnits.Radians
                                Select Case DataSettings(DataCol).ValueDirection
                                    Case DataType.ValueDirections.Plus_Minus  '| +/- | Radians Latitude | +/- | Radians Longitude | ----------------------------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToRadian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = AngleConvert.Gradians
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToRadian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = AngleConvert.Gradians
                                    Case DataType.ValueDirections.E_W_N_S '| Radians Latitude | N/S | Radians Longitude | E/W | --------------------------------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToRadian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "E"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "W"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToRadian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "N"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "S"
                                        End If
                                    Case DataType.ValueDirections.East_West_North_South '| Radians Latitude | North/South | Radians Longitude | East/West | ----------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToRadian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "East"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "West"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToRadian()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "North"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "South"
                                        End If
                                End Select
                            Case DataType.AngleUnits.Sexagesimal_Degrees
                                Select Case DataSettings(DataCol).ValueDirection
                                    Case DataType.ValueDirections.Plus_Minus  '| +/- | Sexagesimal Degrees Latitude | +/- | Sexagesimal Degrees Longitude | ----------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = AngleConvert.Gradians
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = AngleConvert.Gradians
                                    Case DataType.ValueDirections.E_W_N_S '| Sexagesimal Degrees Latitude | N/S | Sexagesimal Degrees Longitude | E/W | --------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "E"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "W"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "N"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "S"
                                        End If
                                    Case DataType.ValueDirections.East_West_North_South '| Sexagesimal Degrees Latitude | North/South | Sexagesimal Degrees Longitude | East/West | ----------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "East"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "West"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "North"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "South"
                                        End If
                                End Select
                            Case DataType.AngleUnits.Turns
                                Select Case DataSettings(DataCol).ValueDirection
                                    Case DataType.ValueDirections.Plus_Minus  '| +/- | Turns Latitude | +/- | Turns Longitude | --------------------------------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToTurn()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = AngleConvert.Gradians
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToTurn()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = AngleConvert.Gradians
                                    Case DataType.ValueDirections.E_W_N_S '| Turns Latitude | N/S | Turns Longitude | E/W | ------------------------------------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToTurn()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "E"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "W"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToTurn()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "N"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "S"
                                        End If
                                    Case DataType.ValueDirections.East_West_North_South '| Turns Latitude | North/South | Turns Longitude | East/West | --------------------------------------------------
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Latitude
                                        AngleConvert.ConvertDecimalDegreeToTurn()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "East"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = "West"
                                        End If
                                        AngleConvert.DecimalDegrees = TransverseMercator.Location.Longitude
                                        AngleConvert.ConvertDecimalDegreeToTurn()
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = Math.Abs(AngleConvert.Gradians)
                                        If AngleConvert.Gradians >= 0 Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "North"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "South"
                                        End If
                                End Select
                            Case DataType.AngleUnits.Degrees_Minutes_Seconds
                                Select Case DataSettings(DataCol).ValueDirection
                                    Case DataType.ValueDirections.Plus_Minus '| +/- | Deg Min Sec Latitude | +/- | Deg Min Sec Longitude | ---------------------------------------------------------------
                                        AngleDegMinSec.DecimalDegreesToDegMinSec(TransverseMercator.Location.Latitude)
                                        If AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = "-"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = "+"
                                        End If
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = AngleDegMinSec.Degrees
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = AngleDegMinSec.Minutes
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = AngleDegMinSec.Seconds
                                        AngleDegMinSec.DecimalDegreesToDegMinSec(TransverseMercator.Location.Longitude)
                                        If AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 4).Value = "-"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 4).Value = "+"
                                        End If
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 5).Value = AngleDegMinSec.Degrees
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 6).Value = AngleDegMinSec.Minutes
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 7).Value = AngleDegMinSec.Seconds
                                    Case DataType.ValueDirections.E_W_N_S '| Deg Min Sec Latitude | N/S | Deg Min Sec Longitude | E/W | ------------------------------------------------------------------
                                        AngleDegMinSec.DecimalDegreesToDegMinSec(TransverseMercator.Location.Latitude)
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = AngleDegMinSec.Degrees
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = AngleDegMinSec.Minutes
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = AngleDegMinSec.Seconds
                                        If AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "S"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "N"
                                        End If
                                        AngleDegMinSec.DecimalDegreesToDegMinSec(TransverseMercator.Location.Longitude)
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 4).Value = AngleDegMinSec.Degrees
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 5).Value = AngleDegMinSec.Minutes
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 6).Value = AngleDegMinSec.Seconds
                                        If AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 7).Value = "W"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 7).Value = "E"
                                        End If
                                    Case DataType.ValueDirections.East_West_North_South '| Deg Min Sec Latitude | North/South | Deg Min Sec Longitude | East/West | --------------------------------------
                                        AngleDegMinSec.DecimalDegreesToDegMinSec(TransverseMercator.Location.Latitude)
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = AngleDegMinSec.Degrees
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = AngleDegMinSec.Minutes
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 2).Value = AngleDegMinSec.Seconds
                                        If AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "South"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 3).Value = "North"
                                        End If
                                        AngleDegMinSec.DecimalDegreesToDegMinSec(TransverseMercator.Location.Longitude)
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 4).Value = AngleDegMinSec.Degrees
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 5).Value = AngleDegMinSec.Minutes
                                        DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 6).Value = AngleDegMinSec.Seconds
                                        If AngleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative Then
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 7).Value = "West"
                                        Else
                                            DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 7).Value = "East"
                                        End If
                                End Select
                        End Select
                    Case DataType.DataTypes.Northing_Easting
                        Select Case DataSettings(DataCol).DistanceUnit
                            Case DataType.DistanceUnits.Metres
                                'DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = TransverseMercator.Location.Northing
                                'DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = TransverseMercator.Location.Easting
                            Case DataType.DistanceUnits._Default
                                DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = TransverseMercator.Location.Northing
                                DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = TransverseMercator.Location.Easting
                        End Select
                    Case DataType.DataTypes.Easting_Northing
                        Select Case DataSettings(DataCol).DistanceUnit
                            Case DataType.DistanceUnits.Metres
                                'DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = TransverseMercator.Location.Easting
                                'DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = TransverseMercator.Location.Northing
                            Case DataType.DistanceUnits._Default
                                DataGridView1.Rows(RowNo).Cells(FirstGridColNo).Value = TransverseMercator.Location.Easting
                                DataGridView1.Rows(RowNo).Cells(FirstGridColNo + 1).Value = TransverseMercator.Location.Northing
                        End Select
                    Case DataType.DataTypes._Nothing

                    Case Else

                End Select
            End If
        Next

    End Sub

    Private Sub DataGridView1_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnWidthChanged
        'Update DataSettings() with the new column width:

        Dim CurrentGridColumnNo As Integer = e.Column.Index
        Dim NewColumnWidth As Integer = e.Column.Width
        Dim NDataColumns As Integer 'The number of data columns. This is currently set at 6. Each data column may have more than one value column (eg deg, min ,sec). A data column may be set to "Nothing".
        Dim DataColumnNo As Integer = -1 'The data column number of the cell value that changed. (A value of -1 indicates an invalid column number.)
        Dim DataSubColumnNo As Integer = -1 'The sub column within the data column of the cell value that changed. (A value of -1 indicates an invalid sub column number.)
        Dim Col1 As Integer = -1 'The first Grid Column Number of the first sub column in the current data column.

        NDataColumns = DataSettings.Count 'This is the number of data columns that can be displayed in DataGridView1. (Some data columns use more than one grid column.)

        Dim I As Integer
        'Get the data column number:
        For I = 0 To NDataColumns - 1
            If CurrentGridColumnNo >= DataSettings(I).FirstColumnNo Then
                If CurrentGridColumnNo <= DataSettings(I).FirstColumnNo + DataSettings(I).NColumns - 1 Then
                    DataColumnNo = I
                    DataSubColumnNo = CurrentGridColumnNo - DataSettings(I).FirstColumnNo
                    Col1 = DataSettings(I).FirstColumnNo
                    Exit For
                End If
            End If
        Next

        If DataColumnNo > -1 Then
            Select Case DataSettings(DataColumnNo).DataType.ToString
                Case "Point_Number"
                    'The point number has been edited. No further processing required.
                    DataSettings(DataColumnNo).PointNumberWidth = NewColumnWidth
                Case "Point_Description"
                    'The point description has been edited. No further processing required.
                    DataSettings(DataColumnNo).PointDescriptionWidth = NewColumnWidth
                Case "Latitude_Longitude"
                    'The latitude,Longitude coordinates have been edited.
                    Select Case DataSettings(DataColumnNo).AngleUnit.ToString
                        Case "Decimal_Degrees"
                            Select Case DataSettings(DataColumnNo).ValueDirection.ToString
                                Case "Plus_Minus"
                                    'Data format is |+/-Latitude|+/-Longitude|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    End If
                                Case "East_West_North_South"
                                    'Data format is |Latitude|North/South|Longitude|East/West|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).NorthSouthWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 2 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 3 Then
                                        DataSettings(DataColumnNo).WestEastWidth = NewColumnWidth
                                    End If
                                Case "E_W_N_S"
                                    'Data format is |Latitude|N/S|Longitude|E/W|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).NSWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 2 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 3 Then
                                        DataSettings(DataColumnNo).WEWidth = NewColumnWidth
                                    End If
                            End Select
                        Case "Degrees_Minutes_Seconds"
                            Select Case DataSettings(DataColumnNo).ValueDirection.ToString
                                Case "Plus_Minus"
                                    'Data format is |+/-|Latitude Degrees|Minutes|Seconds|+/-|Longitude Degrees|Minutes|Seconds|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).PlusMinusWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).LatitudeDmsDegreesWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 2 Then
                                        DataSettings(DataColumnNo).LatitudeDmsMinutesWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 3 Then
                                        DataSettings(DataColumnNo).LatitudeDmsSecondsWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 4 Then
                                        DataSettings(DataColumnNo).PlusMinusWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 5 Then
                                        DataSettings(DataColumnNo).LongitudeDmsDegreesWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 6 Then
                                        DataSettings(DataColumnNo).LongitudeDmsMinutesWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 7 Then
                                        DataSettings(DataColumnNo).LongitudeDmsSecondsWidth = NewColumnWidth
                                    End If
                                Case "East_West_North_South"
                                    'Data format is |Latitude Degrees|Minutes|Seconds|North/South|Longitude Degrees|Minutes|Seconds|East/West|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeDmsDegreesWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).LatitudeDmsMinutesWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 2 Then
                                        DataSettings(DataColumnNo).LatitudeDmsSecondsWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 3 Then
                                        DataSettings(DataColumnNo).NorthSouthWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 4 Then
                                        DataSettings(DataColumnNo).LongitudeDmsDegreesWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 5 Then
                                        DataSettings(DataColumnNo).LongitudeDmsMinutesWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 6 Then
                                        DataSettings(DataColumnNo).LongitudeDmsSecondsWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 7 Then
                                        DataSettings(DataColumnNo).WestEastWidth = NewColumnWidth
                                    End If
                                Case "E_W_N_S"
                                    'Data format is |Latitude Degrees|Minutes|Seconds|N/S|Longitude Degrees|Minutes|Seconds|E/W|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeDmsDegreesWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).LatitudeDmsMinutesWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 2 Then
                                        DataSettings(DataColumnNo).LatitudeDmsSecondsWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 3 Then
                                        DataSettings(DataColumnNo).NSWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 4 Then
                                        DataSettings(DataColumnNo).LongitudeDmsDegreesWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 5 Then
                                        DataSettings(DataColumnNo).LongitudeDmsMinutesWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 6 Then
                                        DataSettings(DataColumnNo).LongitudeDmsSecondsWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 7 Then
                                        DataSettings(DataColumnNo).WEWidth = NewColumnWidth
                                    End If
                            End Select
                        Case "Sexagesimal_Degrees"
                            Select Case DataSettings(DataColumnNo).ValueDirection.ToString
                                Case "Plus_Minus"
                                    'Data format is |+/-|Latitude Sexagesimal Degrees|+/-|Longitude Sexagesimal Degrees|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    End If
                                Case "East_West_North_South"
                                    'Data format is |Latitude Sexagesimal Degrees|North/South|Longitude Sexagesimal Degrees|East/West|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).NorthSouthWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 2 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 3 Then
                                        DataSettings(DataColumnNo).WestEastWidth = NewColumnWidth
                                    End If
                                Case "E_W_N_S"
                                    'Data format is |Latitude Sexagesimal Degrees|N/S|Longitude Sexagesimal Degrees|E/W|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).NSWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 2 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 3 Then
                                        DataSettings(DataColumnNo).WEWidth = NewColumnWidth
                                    End If
                            End Select
                        Case "Radians"
                            Select Case DataSettings(DataColumnNo).ValueDirection.ToString
                                Case "Plus_Minus"
                                    'Data format is |+/-|Latitude Radians|+/-|Longitude Radians|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    End If
                                Case "East_West_North_South"
                                    'Data format is |Latitude Radians|North/South|Longitude Radians|East/West|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).NorthSouthWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 2 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 3 Then
                                        DataSettings(DataColumnNo).WestEastWidth = NewColumnWidth
                                    End If
                                Case "E_W_N_S"
                                    'Data format is |Latitude Radians|N/S|Longitude Radians|E/W|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).NSWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 2 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 3 Then
                                        DataSettings(DataColumnNo).WEWidth = NewColumnWidth
                                    End If
                            End Select
                        Case "Gradians"
                            Select Case DataSettings(DataColumnNo).ValueDirection.ToString
                                Case "Plus_Minus"
                                    'Data format is |+/-|Latitude Gradians|+/-|Longitude Gradians|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    End If
                                Case "East_West_North_South"
                                    'Data format is |Latitude Gradians|North/South|Longitude Gradians|East/West|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).NorthSouthWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 2 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 3 Then
                                        DataSettings(DataColumnNo).WestEastWidth = NewColumnWidth
                                    End If
                                Case "E_W_N_S"
                                    'Data format is |Latitude Gradians|N/S|Longitude Gradians|E/W|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).NSWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 2 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 3 Then
                                        DataSettings(DataColumnNo).WEWidth = NewColumnWidth
                                    End If
                            End Select
                        Case "Turns"
                            Select Case DataSettings(DataColumnNo).ValueDirection.ToString
                                Case "Plus_Minus"
                                    'Data format is |+/-|Latitude Turns|+/-|Longitude Turns|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    End If
                                Case "East_West_North_South"
                                    'Data format is |Latitude Turns|North/South|Longitude Turns|East/West|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).NorthSouthWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 2 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 3 Then
                                        DataSettings(DataColumnNo).WestEastWidth = NewColumnWidth
                                    End If
                                Case "E_W_N_S"
                                    'Data format is |Latitude Turns|N/S|Longitude Turns|E/W|
                                    If DataSubColumnNo = 0 Then
                                        DataSettings(DataColumnNo).LatitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 1 Then
                                        DataSettings(DataColumnNo).NSWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 2 Then
                                        DataSettings(DataColumnNo).LongitudeWidth = NewColumnWidth
                                    ElseIf DataSubColumnNo = 3 Then
                                        DataSettings(DataColumnNo).WEWidth = NewColumnWidth
                                    End If
                            End Select
                    End Select
                Case "Longitude_Latitude"

                Case "Northing_Easting"
                    'The Northing, Easting coordinates have been edited.
                    If DataSubColumnNo = 0 Then
                        DataSettings(DataColumnNo).NorthingWidth = NewColumnWidth
                    ElseIf DataSubColumnNo = 1 Then
                        DataSettings(DataColumnNo).EastingWidth = NewColumnWidth
                    End If
                Case "Easting_Northing"
                    'The Easting, Northing coordinates have been edited.
                    If DataSubColumnNo = 0 Then
                        DataSettings(DataColumnNo).EastingWidth = NewColumnWidth
                    ElseIf DataSubColumnNo = 1 Then
                        DataSettings(DataColumnNo).NorthingWidth = NewColumnWidth
                    End If
            End Select
        End If
        UpdateDataGridView()
    End Sub

#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Events - Events that can be triggered by this form." '--------------------------------------------------------------------------------------------------------------------------
#End Region 'Form Events ----------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region "Class Code - Classes used in this form."

    Private Class DataPointInfo
        'clsDataPointInfo stores PointNo, PointDescription, Latitude and Longitude values for a point.

        Private _number As Integer
        Property Number As Integer
            Get
                Return _number
            End Get
            Set(value As Integer)
                _number = value
            End Set
        End Property

        Private _description As String
        Property Description As String
            Get
                Return _description
            End Get
            Set(value As String)
                _description = value
            End Set
        End Property

        Private _latitude As Double
        Property Latitude As Double
            Get
                Return _latitude
            End Get
            Set(value As Double)
                _latitude = value
            End Set
        End Property

        Private _longitude As Double
        Property Longitude As Double
            Get
                Return _longitude
            End Get
            Set(value As Double)
                _longitude = value
            End Set
        End Property

    End Class

    Private Class DataType
        'clsDataType stores the definition of data contained in columns in the Projection Calculations grid.

        'The list of data type options.
        Public Enum DataTypes
            _Nothing            'No data is stored in this position.
            Point_Number        'The number of the point.
            Point_Description   'A description of the point.
            Latitude_Longitude  'The latitude and longitude of the point.
            Longitude_Latitude  'The longitude and latitude of the point.
            Northing_Easting    'The northing and easting of the point.
            Easting_Northing    'The easting and northing of the point.
        End Enum

        'The list of distance unit options.
        Public Enum DistanceUnits
            Metres
            _Default 'Projected coordinate units can be 
        End Enum

        'The list of angle unit options.
        Public Enum AngleUnits
            Decimal_Degrees
            Degrees_Minutes_Seconds
            Sexagesimal_Degrees
            Radians
            Gradians
            Turns
        End Enum

        'The list of value direction options.
        Public Enum ValueDirections
            Plus_Minus
            East_West_North_South
            E_W_N_S
        End Enum

        'The data type stores in this column or set of columns.
        Private _dataType As DataTypes = DataTypes._Nothing
        Property DataType As DataTypes
            Get
                Return _dataType
            End Get
            Set(value As DataTypes)
                _dataType = value
                Select Case _dataType
                    Case DataTypes._Nothing
                        _nColumns = 0
                    Case DataTypes.Easting_Northing
                        If ValueDirection = ValueDirections.Plus_Minus Then
                            _nColumns = 2
                        Else
                            _nColumns = 4 'Extra columns needed for North/South and East/West
                        End If
                    Case DataTypes.Latitude_Longitude
                        Select Case _angleUnit
                            Case AngleUnits.Degrees_Minutes_Seconds
                                _nColumns = 8 'Extra columns needed for +/- or North/South, East/West
                            Case Else
                                If _valueDirection = ValueDirections.Plus_Minus Then
                                    _nColumns = 2 '+/- included in each value column (separate +/- columns not needed.)
                                Else
                                    _nColumns = 4 'Extra columns needed for North/South, East/West
                                End If
                        End Select
                    Case DataTypes.Longitude_Latitude
                        Select Case _angleUnit
                            Case AngleUnits.Degrees_Minutes_Seconds
                                _nColumns = 8 'Extra columns needed for +/- or North/South, East/West
                            Case Else
                                If _valueDirection = ValueDirections.Plus_Minus Then
                                    _nColumns = 2 '+/- included in each value column (separate +/- columns not needed.)
                                Else
                                    _nColumns = 4 'Extra columns needed for North/South, East/West
                                End If
                        End Select
                    Case DataTypes.Northing_Easting
                        If ValueDirection = ValueDirections.Plus_Minus Then
                            _nColumns = 2
                        Else
                            _nColumns = 4 'Extra columns needed for North/South and East/West
                        End If

                    Case DataTypes.Point_Description
                        _nColumns = 1
                    Case DataTypes.Point_Number
                        _nColumns = 1
                End Select
            End Set
        End Property

        'The units used for the easting and northing values.
        Private _distanceUnit As DistanceUnits = DistanceUnits.Metres
        Property DistanceUnit As DistanceUnits
            Get
                Return _distanceUnit
            End Get
            Set(value As DistanceUnits)
                _distanceUnit = value
            End Set
        End Property

        'The units used for the latitude and longitude values.
        Private _angleUnit As AngleUnits = AngleUnits.Decimal_Degrees
        Property AngleUnit As AngleUnits
            Get
                Return _angleUnit
            End Get
            Set(value As AngleUnits)
                _angleUnit = value
                Select Case DataType
                    Case DataTypes._Nothing
                        'Angle Units will not change this data type. Do not change the number of columns
                    Case DataTypes.Easting_Northing
                        'Angle Units will not change this data type. Do not change the number of columns
                    Case DataTypes.Latitude_Longitude
                        If _angleUnit = AngleUnits.Degrees_Minutes_Seconds Then
                            _nColumns = 8 'Extra columns needed for +/- or North/South, East/West
                        Else
                            If _valueDirection = ValueDirections.Plus_Minus Then
                                _nColumns = 2 '+/- included in each value column (separate +/- columns not needed.)
                            Else
                                _nColumns = 4 'Extra columns needed for North/South, East/West
                            End If
                        End If
                    Case DataTypes.Longitude_Latitude
                        If _angleUnit = AngleUnits.Degrees_Minutes_Seconds Then
                            _nColumns = 8 'Extra columns needed for +/- or North/South, East/West
                        Else
                            If _valueDirection = ValueDirections.Plus_Minus Then
                                _nColumns = 2 '+/- included in each value column (separate +/- columns not needed.)
                            Else
                                _nColumns = 4 'Extra columns needed for North/South, East/West
                            End If
                        End If
                    Case DataTypes.Northing_Easting
                        'Angle Units will not change this data type. Do not change the number of columns
                    Case DataTypes.Point_Description
                        'Angle Units will not change this data type. Do not change the number of columns
                    Case DataTypes.Point_Number
                        'Angle Units will not change this data type. Do not change the number of columns
                End Select
            End Set
        End Property

        'The method used to indicate the value direction
        Private _valueDirection As ValueDirections = ValueDirections.Plus_Minus
        Property ValueDirection As ValueDirections
            Get
                Return _valueDirection
            End Get
            Set(value As ValueDirections)
                _valueDirection = value
                Select Case DataType
                    Case DataTypes._Nothing

                    Case DataTypes.Easting_Northing

                    Case DataTypes.Latitude_Longitude
                        If _angleUnit = AngleUnits.Degrees_Minutes_Seconds Then
                            _nColumns = 8 'Extra columns needed for or North/South, East/West
                        Else
                            If _valueDirection = ValueDirections.Plus_Minus Then
                                _nColumns = 2 '+/- included in each value column (separate +/- columns not needed.)
                            Else
                                _nColumns = 4 'Extra columns needed for North/South, East/West
                            End If
                        End If

                    Case DataTypes.Longitude_Latitude
                        If _angleUnit = AngleUnits.Degrees_Minutes_Seconds Then
                            _nColumns = 8 'Extra columns needed for +/- or North/South, East/West
                        Else
                            If _valueDirection = ValueDirections.Plus_Minus Then
                                _nColumns = 2 '+/- included in each value column (separate +/- columns not needed.)
                            Else
                                _nColumns = 4 'Extra columns needed for North/South, East/West
                            End If
                        End If

                    Case DataTypes.Northing_Easting

                    Case DataTypes.Point_Description
                        'Value direction will not change this data type. Do not change the number of columns.
                    Case DataTypes.Point_Number
                        'Value direction will not change this data type. Do not change the number of columns.
                End Select
            End Set
        End Property

        'The width of the Point Number column (if displayed at this position). 
        Private _pointNumberWidth As Integer = 120
        Property PointNumberWidth As Integer
            Get
                Return _pointNumberWidth
            End Get
            Set(value As Integer)
                _pointNumberWidth = value
            End Set
        End Property

        'The width of the Point Description column (if displayed at this position).
        Private _pointDescriptionWidth As Integer = 120
        Property PointDescriptionWidth As Integer
            Get
                Return _pointDescriptionWidth
            End Get
            Set(value As Integer)
                _pointDescriptionWidth = value
            End Set
        End Property

        'The width of the +/- column. (This column indicates if the associated Northing, Easting, Latitude or Longitude value is positive or negative.
        Private _plusMinusWidth As Integer = 30
        Property PlusMinusWidth As Integer
            Get
                Return _plusMinusWidth
            End Get
            Set(value As Integer)
                _plusMinusWidth = value
            End Set
        End Property

        'The width of the NS column. (This column indicates if the associated Northing or Latitude value is in the North or South direction.
        Private _NSWidth As Integer = 30
        Property NSWidth As Integer
            Get
                Return _NSWidth
            End Get
            Set(value As Integer)
                _NSWidth = value
            End Set
        End Property

        'The width of the WE column. (This column indicates if the associated Easting or Longitude value is in the West or East direction.
        Private _WEWidth As Integer = 30
        Property WEWidth As Integer
            Get
                Return _WEWidth
            End Get
            Set(value As Integer)
                _WEWidth = value
            End Set
        End Property

        'The width of the NorthSouth column. (This column indicates if the associated Northing or Latitude value is in the North or South direction.
        Private _NorthSouthWidth As Integer = 48
        Property NorthSouthWidth As Integer
            Get
                Return _NorthSouthWidth
            End Get
            Set(value As Integer)
                _NorthSouthWidth = value
            End Set
        End Property

        'The width of the WestEast column. (This column indicates if the associated Easting or Longitude value is in the West or East direction.
        Private _WestEastWidth As Integer = 48
        Property WestEastWidth As Integer
            Get
                Return _WestEastWidth
            End Get
            Set(value As Integer)
                _WestEastWidth = value
            End Set
        End Property

        'The width of the Longitude Degrees column, where longitude is displayed as degrees, minutes and seconds.
        Private _longitudeDmsDegreesWidth As Integer = 120
        Property LongitudeDmsDegreesWidth As Integer
            Get
                Return _longitudeDmsDegreesWidth
            End Get
            Set(value As Integer)
                _longitudeDmsDegreesWidth = value
            End Set
        End Property

        'The width of the Longitude Minutes column, where longitude is displayed as degrees, minutes and seconds.
        Private _longitudeDmsMinutesWidth As Integer = 120
        Property LongitudeDmsMinutesWidth As Integer
            Get
                Return _longitudeDmsMinutesWidth
            End Get
            Set(value As Integer)
                _longitudeDmsMinutesWidth = value
            End Set
        End Property

        'The width of the Longitude Seconds column, where longitude is displayed as degrees, minutes and seconds.
        Private _longitudeDmsSecondsWidth As Integer = 120
        Property LongitudeDmsSecondsWidth As Integer
            Get
                Return _longitudeDmsSecondsWidth
            End Get
            Set(value As Integer)
                _longitudeDmsSecondsWidth = value
            End Set
        End Property

        'The width of the Latitude Degrees column, where longitude is displayed as degrees, minutes and seconds.
        Private _latitudeDmsDegreesWidth As Integer = 120
        Property LatitudeDmsDegreesWidth As Integer
            Get
                Return _latitudeDmsDegreesWidth
            End Get
            Set(value As Integer)
                _latitudeDmsDegreesWidth = value
            End Set
        End Property

        'The width of the Longitude Minutes column, where longitude is displayed as degrees, minutes and seconds.
        Private _latitudeDmsMinutesWidth As Integer = 120
        Property LatitudeDmsMinutesWidth As Integer
            Get
                Return _latitudeDmsMinutesWidth
            End Get
            Set(value As Integer)
                _latitudeDmsMinutesWidth = value
            End Set
        End Property

        'The width of the Longitude Seconds column, where longitude is displayed as degrees, minutes and seconds.
        Private _latitudeDmsSecondsWidth As Integer = 120
        Property LatitudeDmsSecondsWidth As Integer
            Get
                Return _latitudeDmsSecondsWidth
            End Get
            Set(value As Integer)
                _longitudeDmsSecondsWidth = value
            End Set
        End Property

        'The width of the longitude column, where longitude is displayed as decimal degrees, sexagesimal degrees, radians, gradians or turns.
        Private _longitudeWidth As Integer = 120
        Property LongitudeWidth As Integer
            Get
                Return _longitudeWidth
            End Get
            Set(value As Integer)
                _longitudeWidth = value
            End Set
        End Property

        'The width of the latitude column, where latitude is displayed as decimal degrees, sexagesimal degrees, radians, gradians or turns.
        Private _latitudeWidth As Integer = 120
        Property LatitudeWidth As Integer
            Get
                Return _latitudeWidth
            End Get
            Set(value As Integer)
                _latitudeWidth = value
            End Set
        End Property

        'The width of the easting column, where easting is displayed as metres or default units.
        Private _eastingWidth As Integer = 120
        Property EastingWidth As Integer
            Get
                Return _eastingWidth
            End Get
            Set(value As Integer)
                _eastingWidth = value
            End Set
        End Property

        'The width of the northing column, where northing is displayed as metres or default units.
        Private _northingWidth As Integer = 120
        Property NorthingWidth As Integer
            Get
                Return _northingWidth
            End Get
            Set(value As Integer)
                _northingWidth = value
            End Set
        End Property

        'The position of the first column of this DataType in the DataGridView. (This is calculated by the host application.)
        Private _dataPosition As Integer
        Property DataPosition As Integer
            Get
                Return _dataPosition
            End Get
            Set(value As Integer)
                _dataPosition = value
            End Set
        End Property

        'The number of the first column of this DataType in the DataGridView. (This is calculated by the host application.)
        Private _firstColumnNo As Integer
        Property FirstColumnNo As Integer
            Get
                Return _firstColumnNo
            End Get
            Set(value As Integer)
                _firstColumnNo = value
            End Set
        End Property

        'The width of all columns in the DataType.
        ReadOnly Property DataWidth As Integer
            Get
                Dim Width As Integer
                Select Case _dataType
                    Case DataTypes._Nothing
                        Return 0
                    Case DataTypes.Easting_Northing
                        Width = _northingWidth + _eastingWidth 'The width of the Easting and Northing columns
                        Return Width
                    Case DataTypes.Latitude_Longitude
                        Select Case _angleUnit
                            Case AngleUnits.Degrees_Minutes_Seconds
                                Width = _latitudeDmsDegreesWidth + _latitudeDmsMinutesWidth + LatitudeDmsSecondsWidth + _longitudeDmsDegreesWidth + _longitudeDmsMinutesWidth + _longitudeDmsSecondsWidth 'The width of the Latitude DMS columns and the Longitude DMS columns.
                                If _valueDirection = ValueDirections.E_W_N_S Then
                                    Width = Width + _WEWidth + _NSWidth 'Add the width of the W/E column and the N/S column.
                                ElseIf _valueDirection = ValueDirections.East_West_North_South Then
                                    Width = Width + _WestEastWidth + _NorthSouthWidth 'Add the width of the West/East column and the North/South column.
                                ElseIf _valueDirection = ValueDirections.Plus_Minus Then
                                    Width = Width + _plusMinusWidth + _plusMinusWidth 'Add the width of the Easting sign column and the Northing sign column.
                                End If
                            Case Else
                                Width = _latitudeWidth + _longitudeWidth 'The width of the Latitude and Longitude columns.
                                If _valueDirection = ValueDirections.E_W_N_S Then
                                    Width = Width + _WEWidth + _NSWidth 'Add the width of the W/E column and the N/S column.
                                ElseIf _valueDirection = ValueDirections.East_West_North_South Then
                                    Width = Width + _WestEastWidth + _NorthSouthWidth 'Add the width of the West/East column and the North/South column.
                                ElseIf _valueDirection = ValueDirections.Plus_Minus Then
                                    'No change to width - There are no extra +/- columns.
                                End If
                        End Select

                        Return Width
                    Case DataTypes.Longitude_Latitude
                        Select Case _angleUnit
                            Case AngleUnits.Degrees_Minutes_Seconds
                                Width = _latitudeDmsDegreesWidth + _latitudeDmsMinutesWidth + LatitudeDmsSecondsWidth + _longitudeDmsDegreesWidth + _longitudeDmsMinutesWidth + _longitudeDmsSecondsWidth 'The width of the Latitude DMS columns and the Longitude DMS columns.
                                If _valueDirection = ValueDirections.E_W_N_S Then
                                    Width = Width + _WEWidth + _NSWidth 'Add the width of the W/E column and the N/S column.
                                ElseIf _valueDirection = ValueDirections.East_West_North_South Then
                                    Width = Width + _WestEastWidth + _NorthSouthWidth 'Add the width of the West/East column and the North/South column.
                                ElseIf _valueDirection = ValueDirections.Plus_Minus Then
                                    Width = Width + _plusMinusWidth + _plusMinusWidth 'Add the width of the Easting sign column and the Northing sign column.
                                End If
                            Case Else
                                Width = _latitudeWidth + _longitudeWidth 'The width of the Latitude and Longitude columns.
                                If _valueDirection = ValueDirections.E_W_N_S Then
                                    Width = Width + _WEWidth + _NSWidth 'Add the width of the W/E column and the N/S column.
                                ElseIf _valueDirection = ValueDirections.East_West_North_South Then
                                    Width = Width + _WestEastWidth + _NorthSouthWidth 'Add the width of the West/East column and the North/South column.
                                ElseIf _valueDirection = ValueDirections.Plus_Minus Then
                                    'No change to width - There are no extra +/- columns.
                                End If
                        End Select
                        Return Width
                    Case DataTypes.Northing_Easting
                        Width = _northingWidth + _eastingWidth 'The width of the Easting and Northing columns
                        Return Width
                    Case DataTypes.Point_Description
                        Return _pointDescriptionWidth
                    Case DataTypes.Point_Number
                        Return _pointNumberWidth
                End Select
            End Get
        End Property

        'The number of columns in the DataType. This value is set when DataType is selected
        Private _nColumns As Integer
        ReadOnly Property NColumns As Integer
            Get
                Return _nColumns
            End Get
        End Property

    End Class

#End Region

    Private Sub btnShowDataSettings_Click(sender As Object, e As EventArgs) Handles btnShowDataSettings.Click
        Main.Message.Add(vbCrLf)
        Main.Message.Add("Data Settings:" & vbCrLf)

        Dim I As Integer

        For I = 0 To 5
            Main.Message.Add(vbCrLf)
            Main.Message.Add("Data column " & Str(I) & ":" & vbCrLf)
            'Data Type:
            Main.Message.Add("Data type: " & DataSettings(I).DataType.ToString & vbCrLf)
            'Column info:
            Main.Message.Add("Fist column no: " & DataSettings(I).FirstColumnNo & vbCrLf)
            Main.Message.Add("NColumns: " & DataSettings(I).NColumns & vbCrLf)
            'Layout:
            Main.Message.Add("Data position: " & DataSettings(I).DataPosition & vbCrLf)
            Main.Message.Add("Data width: " & DataSettings(I).DataWidth & vbCrLf)
            'Units:
            Main.Message.Add("Distance unit: " & DataSettings(I).DistanceUnit.ToString & vbCrLf)
            Main.Message.Add("Angle unit: " & DataSettings(I).AngleUnit.ToString & vbCrLf)
            'Direction
            Main.Message.Add("Value direction: " & DataSettings(I).ValueDirection.ToString & vbCrLf)
        Next



    End Sub

    Private Sub btnUpdateDataGridView_Click(sender As Object, e As EventArgs)

    End Sub
End Class