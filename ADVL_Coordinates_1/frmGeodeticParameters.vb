Public Class frmGeodeticParameters
    'The Geodetic Parameters form is used to display and edit coordinate reference system parameters.

#Region " Variable Declarations - All the variables used in this form and this application." '-------------------------------------------------------------------------------------------------

    'Declare forms used by this form:
    Public WithEvents AreaOfUseForm As frmAreasOfUse
    Public WithEvents UnitOfMeasureForm As frmUnitsOfMeasure
    Public WithEvents PrimeMeridianForm As frmPrimeMeridians
    Public WithEvents EllipsoidForm As frmEllipsoids
    Public WithEvents ProjectionForm As frmProjections
    Public WithEvents CoordOpMethodsForm As frmCoordOpMethods
    Public WithEvents CoordinateSystemsForm As frmCoordinateSystems
    Public WithEvents DatumsForm As frmDatums
    Public WithEvents TransformationsForm As frmTransformations
    Public WithEvents GeodeticDatumsForm As frmGeodeticDatums
    Public WithEvents VerticalDatumsForm As frmVerticalDatums
    Public WithEvents EngineeringDatumsForm As frmEngineeringDatums
    Public WithEvents CoordRefSystemsForm As frmCoordRefSystems
    Public WithEvents Geographic2DCRSForm As frmGeographic2DCRS
    Public WithEvents Geographic3DCRSForm As frmGeographic3DCRS
    Public WithEvents ProjectedCRSForm As frmProjectedCRS
    Public WithEvents GeocentricCRSForm As frmGeocentricCRS
    Public WithEvents VerticalCRSForm As frmVerticalCRS
    Public WithEvents EngineeringCRSForm As frmEngineeringCRS
    Public WithEvents CompoundCRSForm As frmCompoundCRS


#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Properties - All the properties used in this form." '--------------------------------------------------------------------------------------------------------------------------------

#End Region 'Properties -----------------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Process XML Files - Read and write XML files." '-------------------------------------------------------------------------------------------------------------------------------------

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

        'Dim SettingsName As String = "Formsettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Dim SettingsName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Main.Project.SaveXmlSettings(SettingsName, settingsData)

    End Sub

    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        'Dim SettingsName As String = "Formsettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Dim SettingsName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"

        If Main.Project.SettingsFileExists(SettingsName) Then
            Dim Settings As System.Xml.Linq.XDocument
            Main.Project.ReadXmlSettings(SettingsName, Settings)

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

    Private Sub frmGeodeticParameters_Load(sender As Object, e As EventArgs) Handles Me.Load
        RestoreFormSettings()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------

    Private Sub btnAreasOfUse_Click(sender As Object, e As EventArgs) Handles btnAreasOfUse.Click
        'Open the Area of Use form:
        If IsNothing(AreaOfUseForm) Then
            AreaOfUseForm = New frmAreasOfUse
            AreaOfUseForm.Show()
        Else
            AreaOfUseForm.Show()
        End If
    End Sub

    Private Sub AreaOfUseForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles AreaOfUseForm.FormClosed
        AreaOfUseForm = Nothing
    End Sub

    Private Sub btnUnitsOfMeasure_Click(sender As Object, e As EventArgs) Handles btnUnitsOfMeasure.Click
        'Open the  Unit of Measure form:
        If IsNothing(UnitOfMeasureForm) Then
            UnitOfMeasureForm = New frmUnitsOfMeasure
            UnitOfMeasureForm.Show()
        Else
            UnitOfMeasureForm.Show()
        End If
    End Sub

    Private Sub UnitOfMeasureForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles UnitOfMeasureForm.FormClosed
        UnitOfMeasureForm = Nothing
    End Sub

    Private Sub btnPrimeMeridians_Click(sender As Object, e As EventArgs) Handles btnPrimeMeridians.Click
        'Open the  Prime Meridian form:
        If IsNothing(PrimeMeridianForm) Then
            PrimeMeridianForm = New frmPrimeMeridians
            PrimeMeridianForm.Show()
        Else
            PrimeMeridianForm.Show()
        End If
    End Sub

    Private Sub PrimeMeridianForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles PrimeMeridianForm.FormClosed
        PrimeMeridianForm = Nothing
    End Sub

    Private Sub btnEllipsoids_Click(sender As Object, e As EventArgs) Handles btnEllipsoids.Click
        'Open the  Ellipsoid form:
        If IsNothing(EllipsoidForm) Then
            EllipsoidForm = New frmEllipsoids
            EllipsoidForm.Show()
        Else
            EllipsoidForm.Show()
        End If
    End Sub

    Private Sub EllipsoidForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles EllipsoidForm.FormClosed
        EllipsoidForm = Nothing
    End Sub

    Private Sub btnProjections_Click(sender As Object, e As EventArgs) Handles btnProjections.Click
        'Open the  Projection form:
        If IsNothing(ProjectionForm) Then
            ProjectionForm = New frmProjections
            ProjectionForm.Show()
        Else
            ProjectionForm.Show()
        End If
    End Sub

    Private Sub ProjectionForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles ProjectionForm.FormClosed
        ProjectionForm = Nothing
    End Sub

    Private Sub btnCoordOpMethods_Click(sender As Object, e As EventArgs) Handles btnCoordOpMethods.Click
        'Open the  CoordOpMethods form:
        If IsNothing(CoordOpMethodsForm) Then
            CoordOpMethodsForm = New frmCoordOpMethods
            CoordOpMethodsForm.Show()
        Else
            CoordOpMethodsForm.Show()
        End If
    End Sub

    Private Sub CoordOpMethodsForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles CoordOpMethodsForm.FormClosed
        CoordOpMethodsForm = Nothing
    End Sub

    Private Sub btnCoordinateSystems_Click(sender As Object, e As EventArgs) Handles btnCoordinateSystems.Click
        'Open the  CoordinateSystems form:
        If IsNothing(CoordinateSystemsForm) Then
            CoordinateSystemsForm = New frmCoordinateSystems
            CoordinateSystemsForm.Show()
        Else
            CoordinateSystemsForm.Show()
        End If
    End Sub

    Private Sub CoordinateSystemsForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles CoordinateSystemsForm.FormClosed
        CoordinateSystemsForm = Nothing
    End Sub

    Private Sub btnDatumList_Click(sender As Object, e As EventArgs) Handles btnDatumList.Click
        'Open the  Datums form:
        If IsNothing(DatumsForm) Then
            DatumsForm = New frmDatums
            DatumsForm.Show()
        Else
            DatumsForm.Show()
        End If
    End Sub

    Private Sub DatumsForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles DatumsForm.FormClosed
        DatumsForm = Nothing
    End Sub

    Private Sub btnTransformations_Click(sender As Object, e As EventArgs) Handles btnTransformations.Click
        'Open the  Transformations form:
        If IsNothing(TransformationsForm) Then
            TransformationsForm = New frmTransformations
            TransformationsForm.Show()
        Else
            TransformationsForm.Show()
        End If
    End Sub

    Private Sub TransformationsForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles TransformationsForm.FormClosed
        TransformationsForm = Nothing
    End Sub

    Private Sub btnGeodeticDatums_Click(sender As Object, e As EventArgs) Handles btnGeodeticDatums.Click
        'Open the  Geodetic Datums form:
        If IsNothing(GeodeticDatumsForm) Then
            GeodeticDatumsForm = New frmGeodeticDatums
            GeodeticDatumsForm.Show()
        Else
            GeodeticDatumsForm.Show()
        End If
    End Sub

    Private Sub GeodeticDatumsForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles GeodeticDatumsForm.FormClosed
        GeodeticDatumsForm = Nothing
    End Sub

    Private Sub btnCRSList_Click(sender As Object, e As EventArgs) Handles btnCRSList.Click
        'Open the  Coordinate Reference Systems form:
        If IsNothing(CoordRefSystemsForm) Then
            CoordRefSystemsForm = New frmCoordRefSystems
            CoordRefSystemsForm.Show()
        Else
            CoordRefSystemsForm.Show()
        End If
    End Sub

    Private Sub CoordRefSystemsForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles CoordRefSystemsForm.FormClosed
        CoordRefSystemsForm = Nothing
    End Sub

    Private Sub btnGeographic2D_Click(sender As Object, e As EventArgs) Handles btnGeographic2D.Click
        'Open the  Geographic 2D Coordinate Reference Systems form:
        If IsNothing(Geographic2DCRSForm) Then
            Geographic2DCRSForm = New frmGeographic2DCRS
            Geographic2DCRSForm.Show()
        Else
            Geographic2DCRSForm.Show()
        End If
    End Sub

    Private Sub Geographic2DCRSForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Geographic2DCRSForm.FormClosed
        Geographic2DCRSForm = Nothing
    End Sub

    Private Sub btnProjected_Click(sender As Object, e As EventArgs) Handles btnProjected.Click
        'Open the  Projected Coordinate Reference Systems form:
        If IsNothing(ProjectedCRSForm) Then
            ProjectedCRSForm = New frmProjectedCRS
            ProjectedCRSForm.Show()
        Else
            ProjectedCRSForm.Show()
        End If
    End Sub

    Private Sub ProjectedCRSForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles ProjectedCRSForm.FormClosed
        ProjectedCRSForm = Nothing
    End Sub

    Private Sub btnGeocentric_Click(sender As Object, e As EventArgs) Handles btnGeocentric.Click
        'Open the  Geocentric Coordinate Reference Systems form:
        If IsNothing(GeocentricCRSForm) Then
            GeocentricCRSForm = New frmGeocentricCRS
            GeocentricCRSForm.Show()
        Else
            GeocentricCRSForm.Show()
        End If
    End Sub

    Private Sub GeocentricCRSForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles GeocentricCRSForm.FormClosed
        GeocentricCRSForm = Nothing
    End Sub

    Private Sub btnVerticalDatum_Click(sender As Object, e As EventArgs) Handles btnVerticalDatum.Click
        'Open the  Vertical Datums form:
        If IsNothing(VerticalDatumsForm) Then
            VerticalDatumsForm = New frmVerticalDatums
            VerticalDatumsForm.Show()
        Else
            VerticalDatumsForm.Show()
        End If
    End Sub

    Private Sub VerticalDatumsForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles VerticalDatumsForm.FormClosed
        VerticalDatumsForm = Nothing
    End Sub

    Private Sub btnEngineeringDatum_Click(sender As Object, e As EventArgs) Handles btnEngineeringDatum.Click
        'Open the  Engineering Datums form:
        If IsNothing(EngineeringDatumsForm) Then
            EngineeringDatumsForm = New frmEngineeringDatums
            EngineeringDatumsForm.Show()
        Else
            EngineeringDatumsForm.Show()
        End If
    End Sub

    Private Sub EngineeringDatumsForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles EngineeringDatumsForm.FormClosed
        EngineeringDatumsForm = Nothing
    End Sub

    Private Sub btnVerticalCRS_Click(sender As Object, e As EventArgs) Handles btnVerticalCRS.Click
        'Open the  Vertical CRS form:
        If IsNothing(VerticalCRSForm) Then
            VerticalCRSForm = New frmVerticalCRS
            VerticalCRSForm.Show()
        Else
            VerticalCRSForm.Show()
        End If
    End Sub

    Private Sub VerticalCRSForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles VerticalCRSForm.FormClosed
        VerticalCRSForm = Nothing
    End Sub

    Private Sub btnGeographic3D_Click(sender As Object, e As EventArgs) Handles btnGeographic3D.Click
        'Open the  Geographic 3D Coordinate Reference Systems form:
        If IsNothing(Geographic3DCRSForm) Then
            Geographic3DCRSForm = New frmGeographic3DCRS
            Geographic3DCRSForm.Show()
        Else
            Geographic3DCRSForm.Show()
        End If
    End Sub

    Private Sub Geographic3DCRSForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Geographic3DCRSForm.FormClosed
        Geographic3DCRSForm = Nothing
    End Sub

    Private Sub btnEngineering_Click(sender As Object, e As EventArgs) Handles btnEngineering.Click
        'Open the  Engineering CRS form:
        If IsNothing(EngineeringCRSForm) Then
            EngineeringCRSForm = New frmEngineeringCRS
            EngineeringCRSForm.Show()
        Else
            EngineeringCRSForm.Show()
        End If
    End Sub

    Private Sub EngineeringCRSForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles EngineeringCRSForm.FormClosed
        EngineeringCRSForm = Nothing
    End Sub

    Private Sub btnCompound_Click(sender As Object, e As EventArgs) Handles btnCompound.Click
        'Open the  Compound CRS form:
        If IsNothing(CompoundCRSForm) Then
            CompoundCRSForm = New frmCompoundCRS
            CompoundCRSForm.Show()
        Else
            CompoundCRSForm.Show()
        End If
    End Sub

    Private Sub CompoundCRSForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles CompoundCRSForm.FormClosed
        CompoundCRSForm = Nothing
    End Sub

#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------



#End Region


  

  
  
  
  
  
   
  
  
 
  
  
  
  
End Class