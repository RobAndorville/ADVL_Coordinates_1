Public Class frmProjectedCRS
    'The Projected CRS Form is used to view the set of Projected Cooordinate Reference Systems.

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

    Private Sub frmProjectedCRS_Load(sender As Object, e As EventArgs) Handles Me.Load
        RestoreFormSettings()

        Main.AreaOfUse.AddUser()
        Main.CoordinateSystem.AddUser()
        Main.CoordRefSystem.AddUser()
        'Main.Datum.AddUser()
        Main.Projection.AddUser()
        Main.CoordOpMethod.AddUser()
        Main.Geographic2DCRS.AddUser()
        Main.ProjectedCRS.AddUser()

        DataGridView1.ColumnCount = 3
        DataGridView1.Columns(0).HeaderText = "Name"
        DataGridView1.Columns(1).HeaderText = "Value"
        DataGridView1.Columns(2).HeaderText = "Unit of Measure"
        DataGridView1.AutoResizeColumns()

        UpdateList()
        txtNRecords.Text = Main.ProjectedCRS.NRecords
        txtProjectedCRSListFileName.Text = Main.ProjectedCRS.ListFileName
        CurrentRecordNo = 1
        DisplayListData(1)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the form
        Main.AreaOfUse.RemoveUser()
        Main.CoordinateSystem.RemoveUser()
        Main.CoordRefSystem.RemoveUser()
        Main.Projection.RemoveUser()
        Main.CoordOpMethod.RemoveUser()
        Main.ProjectedCRS.RemoveUser()
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
        For Index = 0 To Main.ProjectedCRS.NRecords - 1
            ListBox1.Items.Add(Main.ProjectedCRS.List(Index).Name)
        Next
    End Sub

    Private Sub DisplayListData(ByVal RecordNo As Integer)
        'Display a record in the Projected CRS list.

        If RecordNo < 1 Then
            Main.Message.AddWarning("Cannot display Projected CRS data. Selected record number is too small." & vbCrLf)
            Exit Sub
        End If

        If RecordNo > Main.ProjectedCRS.NRecords Then
            Main.Message.AddWarning("Cannot display Projectied CRS data. Selected record number is too large." & vbCrLf)
            Exit Sub
        End If

        txtProjectedCRSName.Text = Main.ProjectedCRS.List(RecordNo - 1).Name
        txtProjectedCrsName2.Text = Main.ProjectedCRS.List(RecordNo - 1).Name
        txtAuthor.Text = Main.ProjectedCRS.List(RecordNo - 1).Author
        txtCode.Text = Main.ProjectedCRS.List(RecordNo - 1).Code
        txtDeprecated.Text = Main.ProjectedCRS.List(RecordNo - 1).Deprecated

        'Update the list of alias names:
        cmbAliasNames.Items.Clear()
        cmbAliasNames.Text = ""
        For Each item As String In Main.ProjectedCRS.List(RecordNo - 1).AliasName
            cmbAliasNames.Items.Add(item)
        Next

        If cmbAliasNames.Items.Count > 0 Then
            cmbAliasNames.SelectedIndex = 0 'Select first item
        End If

        txtScope.Text = Main.ProjectedCRS.List(RecordNo - 1).Scope
        txtComments.Text = Main.ProjectedCRS.List(RecordNo - 1).Comments

        txtAreaOfUseName.Text = Main.ProjectedCRS.List(RecordNo - 1).Area.Name
        txtCoordinateSystemName.Text = Main.ProjectedCRS.List(RecordNo - 1).CoordinateSystem.Name
        txtBaseGeogrCRSName.Text = Main.ProjectedCRS.List(RecordNo - 1).SourceGeographicCRS.Name
        txtProjectionName.Text = Main.ProjectedCRS.List(RecordNo - 1).Projection.Name
        txtProjectionMethodName.Text = Main.ProjectedCRS.List(RecordNo - 1).ProjectionMethod.Name
      
        DisplayAOUData(Main.ProjectedCRS.List(RecordNo - 1).Area.Author, Main.ProjectedCRS.List(RecordNo - 1).Area.Code)
        DisplayCSData(Main.ProjectedCRS.List(RecordNo - 1).CoordinateSystem.Author, Main.ProjectedCRS.List(RecordNo - 1).CoordinateSystem.Code)
        DisplaySourceCRSData(Main.ProjectedCRS.List(RecordNo - 1).SourceGeographicCRS.Author, Main.ProjectedCRS.List(RecordNo - 1).SourceGeographicCRS.Code)
        DisplayProjectionData(Main.ProjectedCRS.List(RecordNo - 1).Projection.Author, Main.ProjectedCRS.List(RecordNo - 1).Projection.Code)
        DisplayProjectionMethodData(Main.ProjectedCRS.List(RecordNo - 1).ProjectionMethod.Author, Main.ProjectedCRS.List(RecordNo - 1).ProjectionMethod.Code)

    End Sub

    Private Sub DisplayAOUData(ByVal Author As String, ByVal Code As Integer)
        'Display the Area Of Use parameters corresponding to the Author and Code.

        If Main.AreaOfUse.List.Count = 0 Then
            'There is no Are Of Use data.
            Main.Message.AddWarning("There is no Area Of Use data!" & vbCrLf)
        Else
            Dim AreaMatch = From Area In Main.AreaOfUse.List Where Area.Author = Author And Area.Code = Code

            If AreaMatch.Count > 0 Then
                txtAreaOfUseName2.Text = AreaMatch(0).Name
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

    Private Sub DisplayProjectionData(ByVal Author As String, ByVal Code As Integer)
        'Display the Projection parameters for the record corresponding to the specified Author and Code.

        If Main.Projection.List.Count = 0 Then
            Main.Message.AddWarning("There is no Projection data!" & vbCrLf)
        Else
            Dim ProjectionMatch = From Projection In Main.Projection.List Where Projection.Author = Author And Projection.Code = Code
            If ProjectionMatch.Count > 0 Then
                txtProjectionName.Text = ProjectionMatch(0).Name
                txtProjectionName2.Text = ProjectionMatch(0).Name
                txtProjectionAuthor.Text = ProjectionMatch(0).Author
                txtProjectionCode.Text = ProjectionMatch(0).Code
                txtProjectionComments.Text = ProjectionMatch(0).Comments
                txtProjectionScope.Text = ProjectionMatch(0).Scope
                txtProjectionDeprecated.Text = ProjectionMatch(0).Deprecated
                txtProjectionMethod.Text = ProjectionMatch(0).Method.Name
                txtProjectionArea.Text = ProjectionMatch(0).Area.Name

                'Display Projection Parameters
                Dim NParameters As Integer = ProjectionMatch(0).ParameterValue.Count
                If NParameters > 0 Then
                    DataGridView1.RowCount = NParameters
                    Dim RowNo As Integer
                    For RowNo = 0 To NParameters - 1
                        DataGridView1.Rows(RowNo).Cells(0).Value = ProjectionMatch(0).ParameterValue(RowNo).Name
                        DataGridView1.Rows(RowNo).Cells(1).Value = ProjectionMatch(0).ParameterValue(RowNo).Value
                        DataGridView1.Rows(RowNo).Cells(2).Value = ProjectionMatch(0).ParameterValue(RowNo).Unit.Name
                    Next
                    DataGridView1.Columns(0).Width = 280
                    DataGridView1.Columns(1).Width = 120
                    DataGridView1.Columns(2).Width = 200
                Else
                    DataGridView1.RowCount = 1
                End If
            End If
        End If
    End Sub

    Private Sub DisplayProjectionMethodData(ByVal Author As String, ByVal Code As Integer)
        'Display the Projection Method data for the record corresponding to the specified Author and Code.

        If Main.CoordOpMethod.List.Count = 0 Then
            Main.Message.AddWarning("There is no Coordinate Operation Method data!" & vbCrLf)
        Else
            Dim MethodMatch = From Method In Main.CoordOpMethod.List Where Method.Author = Author And Method.Code = Code
            If MethodMatch.Count > 0 Then
                txtMethodName.Text = MethodMatch(0).Name
                txtMethodAuthor.Text = MethodMatch(0).Author
                txtMethodCode.Text = MethodMatch(0).Code
                txtMethodDeprecated.Text = MethodMatch(0).Deprecated
                txtMethodReverseOp.Text = MethodMatch(0).ReverseOp
                txtMethodComments.Text = MethodMatch(0).Comments
                rtbFormula.Text = MethodMatch(0).Formula
                rtbExample.Text = MethodMatch(0).Example
            End If
        End If
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the Projected CRS list.

        Dim ProjectedCRSListFileName As String = Trim(txtProjectedCRSListFileName.Text)

        If ProjectedCRSListFileName = "" Then
            Main.Message.AddWarning("Please enter a file name for the Projected CRS list!" & vbCrLf)
            Exit Sub
        End If

        If ProjectedCRSListFileName.EndsWith(".ProjectedCRSList") Then
            'ProjectionListFileName has correct file extension.
            Main.ProjectedCRS.ListFileName = ProjectedCRSListFileName
        Else
            'Add file extension to the file name.
            ProjectedCRSListFileName &= ".ProjectedCRSList"
            Main.ProjectedCRS.ListFileName = ProjectedCRSListFileName
            txtProjectedCRSListFileName.Text = ProjectedCRSListFileName
        End If

        Main.Project.SaveXmlData(ProjectedCRSListFileName, Main.ProjectedCRS.ToXDoc())

    End Sub


    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Move to the first record in the Projected CRS list:
        CurrentRecordNo = 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Move to the next record in Projected CRS List
        If CurrentRecordNo = Main.ProjectedCRS.NRecords Then
            'Already at the last record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo + 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Move to the previous record in Projected CRS List
        If CurrentRecordNo = 1 Then
            'Already at the first record.
            Exit Sub
        End If
        CurrentRecordNo = CurrentRecordNo - 1
        DisplayListData(CurrentRecordNo)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Move to the last record in the Projected CRS list:
        CurrentRecordNo = Main.ProjectedCRS.NRecords
        DisplayListData(CurrentRecordNo)
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
        Dim Index As Integer
        Index = ListBox1.SelectedIndex + 1
        CurrentRecordNo = Index
        DisplayListData(Index)
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Find a Projected CRS list file.

        Select Case Main.Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select a Projected CRS list file from the project directory:
                OpenFileDialog1.InitialDirectory = Main.Project.DataLocn.Path
                OpenFileDialog1.Filter = "Projected CRS List | *.ProjectedCRSList"
                If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim DataFileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    txtProjectedCRSListFileName.Text = DataFileName
                    Main.ProjectedCRS.ListFileName = DataFileName
                    Dim XmlDoc As System.Xml.Linq.XDocument
                    Main.Project.DataLocn.ReadXmlData(DataFileName, XmlDoc)
                    Main.ProjectedCRS.LoadXml(XmlDoc)
                    UpdateList()
                    txtNRecords.Text = Main.ProjectedCRS.NRecords
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
                Zip.SelectFileForm.FileExtension = ".ProjectedCRSList"
                Zip.SelectFileForm.GetFileList()
        End Select
    End Sub

    Private Sub btnGetEpsgList_Click(sender As Object, e As EventArgs) Handles btnGetEpsgList.Click
        'Get the ProjectedCRS list from the EPSG database.
        Main.ProjectedCRS.LoadEpsgDbList(Main.EpsgDatabasePath)
        UpdateList()
        txtNRecords.Text = Main.ProjectedCRS.NRecords
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
        FoundIndex = Main.ProjectedCRS.List.FindIndex(Function(x) x.Name.Contains(SearchString))
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
            FoundIndex = Main.ProjectedCRS.List.FindLastIndex(Start, Function(x) x.Name.Contains(SearchString))
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
        FoundIndex = Main.ProjectedCRS.List.FindIndex(CurrentRecordNo, Function(x) x.Name.Contains(SearchString))
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