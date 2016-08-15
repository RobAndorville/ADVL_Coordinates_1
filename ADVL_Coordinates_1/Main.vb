'----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
'
'Copyright 2016 Signalworks Pty Ltd, ABN 26 066 681 598

'Licensed under the Apache License, Version 2.0 (the "License");
'you may not use this file except in compliance with the License.
'You may obtain a copy of the License at
'
'http://www.apache.org/licenses/LICENSE-2.0
'
'Unless required by applicable law or agreed to in writing, software
'distributed under the License is distributed on an "AS IS" BASIS,
'WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'See the License for the specific language governing permissions and
'limitations under the License.
'
'----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


Public Class Main
    'The ADVL_Coordinates_1 application is used to store geographic and projected coordinate parameters and convert between coordinate systems.

    'References:
    'Project \ Add Reference... \ ADVL_System_Utilties.dll
    'Project \ Add Reference... \ ADVL_Coordinates_Library.dll

#Region " CODING NOTES: Using the Info Exchange Client"
    'CODING NOTES:
    'ADD THE SERVICE REFERENCE:
    'A service reference to the InfoExchange must be added to the source code before this service can be used.
    'Run the ADVL_Info_Exchange application to start the Info Exchange message service.
    'In Microsoft Visual Studio select: Project \ Add Service Reference
    'Press the down arrow and select the address of the service used by the Message Exchange:
    'http://localhost:8733/Design_Time_Addresses/WcfMsgServiceLib/Service1/mex
    'Press the Go button.
    'MsgService is found.
    'Press OK to add ServiceReference1 to the project.
    '
    'ADD THE MsgServiceCallback CODE:
    'In Microsoft Visual Studio select: Project \ Add Class
    'MsgServiceCallback.vb
    'Add the following code to the class:
    'Imports System.ServiceModel
    'Public Class MsgServiceCallback
    '    Implements ServiceReference1.IMsgServiceCallback
    '    Public Sub OnSendMessage(message As String) Implements ServiceReference1.IMsgServiceCallback.OnSendMessage
    '        'A message has been received.
    '        'Set the InstrReceived property value to the XMessage. This will also apply the instructions in the XMessage.
    '        Main.InstrReceived = message
    '    End Sub
    'End Class
#End Region


#Region " Variable declarations - All the variables used in this form and this application." '-------------------------------------------------------------------------------------------------

    Public WithEvents ApplicationInfo As New ADVL_Utilities_Library_1.ApplicationInfo 'This object is used to store application information.
    Public WithEvents Project As New ADVL_Utilities_Library_1.Project 'This object is used to store Project information.
    Public WithEvents Message As New ADVL_Utilities_Library_1.Message 'This object is used to display messages in the Messages window.
    Public WithEvents ApplicationUsage As New ADVL_Utilities_Library_1.Usage 'This object stores application usage information.

    'Forms used by this application:
    Public WithEvents EpsgDatabaseForm As frmEpsgDatabase
    'Public WithEvents GeodeticParametersForm As frmGeodeticParameters
    Public WithEvents ConversionsForm As frmConversions
    Public WithEvents ProjectionCalcsForm As frmProjectionCalcs

    'Forms used to view Geodetic Paramters:
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

    'Lists of Coordinate System parameter lists:
    Public WithEvents AreaOfUse As New ADVL_Coordinates_Library_1.AreaOfUseList
    Public WithEvents UnitOfMeasure As New ADVL_Coordinates_Library_1.UnitOfMeasureList
    Public WithEvents PrimeMeridian As New ADVL_Coordinates_Library_1.PrimeMeridianList
    Public WithEvents Ellipsoid As New ADVL_Coordinates_Library_1.EllipsoidList
    Public WithEvents Projection As New ADVL_Coordinates_Library_1.ProjectionList
    Public WithEvents CoordOpMethod As New ADVL_Coordinates_Library_1.CoordOpMethodList
    Public WithEvents CoordRefSystem As New ADVL_Coordinates_Library_1.CoordRefSystemList
    Public WithEvents CoordinateSystem As New ADVL_Coordinates_Library_1.CoordSystemList
    Public WithEvents Datum As New ADVL_Coordinates_Library_1.DatumList
    Public WithEvents Transformation As New ADVL_Coordinates_Library_1.TransformationList
    Public WithEvents GeodeticDatum As New ADVL_Coordinates_Library_1.GeodeticDatumList
    Public WithEvents VerticalDatum As New ADVL_Coordinates_Library_1.VerticalDatumList
    Public WithEvents EngineeringDatum As New ADVL_Coordinates_Library_1.EngineeringDatumList
    Public WithEvents Geographic2DCRS As New ADVL_Coordinates_Library_1.Geographic2DCRSList
    Public WithEvents Geographic3DCRS As New ADVL_Coordinates_Library_1.Geographic3DCRSList
    Public WithEvents ProjectedCRS As New ADVL_Coordinates_Library_1.ProjectedCRSList
    Public WithEvents GeocentricCRS As New ADVL_Coordinates_Library_1.GeocentricCRSList
    Public WithEvents VerticalCRS As New ADVL_Coordinates_Library_1.VerticalCRSList
    Public WithEvents EngineeringCRS As New ADVL_Coordinates_Library_1.EngineeringCRSList
    Public WithEvents CompoundCRS As New ADVL_Coordinates_Library_1.CompoundCRSList

    'Declare objects used to connect to the Application Network:
    Public client As ServiceReference1.MsgServiceClient
    Public WithEvents XMsg As New ADVL_Utilities_Library_1.XMessage 'TDS_Utilities.XMessage
    Public Status As New System.Collections.Specialized.StringCollection
    Dim XDoc As New System.Xml.XmlDocument
    Dim MessageDest As String 'The destination of a message sent through the Application Network
    Dim MessageText As String 'The text of a message sent through the Application Network
    Dim ClientName As String 'The name of the client requesting coordinate operations

    'Variables used for angle conversions:
    Dim angleConvert As New ADVL_Coordinates_Library_1.AngleConvert 'TDS_Utilities.Coordinates.clsAngleConvert
    Dim angleDegMinSec As New ADVL_Coordinates_Library_1.AngleDegMinSec 'TDS_Utilities.Coordinates.clsAngleDegMinSec
    Dim OutputDmsSignName As String 'The name of the XML element that will store the Output DMS sign
    Dim OutputDmsDegreesName As String 'The name of the XML element that will store the Output DMS Degrees
    Dim OutputDmsMinutesName As String 'The name of the XML element that will store the Output DMS Minutes
    Dim OutputDmsSecondsName As String 'The name of the XML element that will store the Output DMS Seconds
    Dim OutputAngleName As String 'The name of the XML element that will store the Output angle (Decimal degrees, radians, gradians or turns.)
    Dim ProjectedCrsInfo As New ProjectedCrsInfo 'Stores information about the selected projected CRS.
    Dim TransverseMercator As ADVL_Coordinates_Library_1.TransverseMercator

    Public dictDistanceUnits As New Dictionary(Of String, ConversionFactors)

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Properties - All the properties used in this form." '--------------------------------------------------------------------------------------------------------------------------------

    Private _epsgDatabasePath = "" 'The path of the EPSG Database. This database contains a comprehensive set of coordinate reference system parameters.
    Property EpsgDatabasePath
        Get
            Return _epsgDatabasePath
        End Get
        Set(value)
            _epsgDatabasePath = value
        End Set
    End Property

    'The Andorville Exchange connection hashcode. This is used to identify a connection in the Andorville Exchange when reconnecting.
    Private _connectionHashcode As Integer
    Property ConnectionHashcode As Integer
        Get
            Return _connectionHashcode
        End Get
        Set(value As Integer)
            _connectionHashcode = value
        End Set
    End Property

    ''True if the application is connected to the Message Exchange.
    'Private _connectedToExchange As Boolean = False
    'Property ConnectedToExchange As Boolean
    '    Get
    '        Return _connectedToExchange
    '    End Get
    '    Set(value As Boolean)
    '        _connectedToExchange = value
    '    End Set
    'End Property

    'True if the application is connected to the Application Network.
    Private _connectedToAppNet As Boolean = False
    Property ConnectedToAppnet As Boolean
        Get
            Return _connectedToAppNet
        End Get
        Set(value As Boolean)
            _connectedToAppNet = value
        End Set
    End Property

    Private _instrReceived As String = "" 'Contains Instructions received from the message service.
    Property InstrReceived As String
        Get
            Return _instrReceived
        End Get
        Set(value As String)
            If value = Nothing Then
                Message.Add("Empty message received!")
            Else
                _instrReceived = value

                'Add the message to the XMessages window:
                Message.Color = Color.Blue
                Message.FontStyle = FontStyle.Bold
                'Message.Add("Message received: " & vbCrLf)
                Message.XAdd("Message received: " & vbCrLf)
                Message.SetNormalStyle()
                Message.XAdd(_instrReceived & vbCrLf & vbCrLf)

                If _instrReceived.StartsWith("<XMsg>") Then 'This is an XMessage set of instructions.
                    Try
                        Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
                        XDoc.LoadXml(XmlHeader & vbCrLf & _instrReceived)
                        XMsg.Run(XDoc, Status)
                    Catch ex As Exception
                        Message.Add("Error running XMsg: " & ex.Message & vbCrLf)
                    End Try

                    'XMessage has been run.
                    'Reply to this message:
                    'Add the message reply to the XMessages window:
                    If ClientName = "" Then
                        'No client to send a message to!
                    Else
                        Message.Color = Color.Red
                        Message.FontStyle = FontStyle.Bold
                        'Message.Add("Message sent to " & ClientName & ":" & vbCrLf)
                        Message.XAdd("Message sent to " & ClientName & ":" & vbCrLf)
                        Message.SetNormalStyle()
                        Message.XAdd(MessageText & vbCrLf & vbCrLf)
                        MessageDest = ClientName
                        'SendMessage sends the contents of MessageText to MessageDest.
                        SendMessage() 'This subroutine triggers the timer to send the message after a short delay.
                    End If
                Else

                End If
            End If

        End Set
    End Property


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

        'Dim SettingsFileName As String = "Formsettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Project.SaveXmlSettings(SettingsFileName, settingsData)

    End Sub

    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        'Dim SettingsFileName As String = "Formsettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"

        If Project.SettingsFileExists(SettingsFileName) Then
            Dim Settings As System.Xml.Linq.XDocument
            Project.ReadXmlSettings(SettingsFileName, Settings)

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

    Private Sub SaveProjectSettings()
        'Save the project settings in an XML file.

        Dim settingsData = <?xml version="1.0" encoding="utf-8"?>
                           <!---->
                           <!--Project settings for ADVL_Coordinates_1 application.-->
                           <ProjectSettings>
                               <EpsgDatabasePath><%= EpsgDatabasePath %></EpsgDatabasePath>
                               <AreaOfUseListFileName><%= AreaOfUse.ListFileName %></AreaOfUseListFileName>
                               <UnitOfMeasureListFileName><%= UnitOfMeasure.ListFileName %></UnitOfMeasureListFileName>
                               <PrimeMeridianListFileName><%= PrimeMeridian.ListFileName %></PrimeMeridianListFileName>
                               <EllipsoidListFileName><%= Ellipsoid.ListFileName %></EllipsoidListFileName>
                               <ProjectionListFileName><%= Projection.ListFileName %></ProjectionListFileName>
                               <CoordOpMethodListFileName><%= CoordOpMethod.ListFileName %></CoordOpMethodListFileName>
                               <CoordRefSystemListFileName><%= CoordRefSystem.ListFileName %></CoordRefSystemListFileName>
                               <CoordinateSystemListFileName><%= CoordinateSystem.ListFileName %></CoordinateSystemListFileName>
                               <DatumListFileName><%= Datum.ListFileName %></DatumListFileName>
                               <TransformationListFileName><%= Transformation.ListFileName %></TransformationListFileName>
                               <GeodeticDatumListFileName><%= GeodeticDatum.ListFileName %></GeodeticDatumListFileName>
                               <VerticalDatumListFileName><%= VerticalDatum.ListFileName %></VerticalDatumListFileName>
                               <EngineeringDatumListFileName><%= EngineeringDatum.ListFileName %></EngineeringDatumListFileName>
                               <Geographic2DCRSListFileName><%= Geographic2DCRS.ListFileName %></Geographic2DCRSListFileName>
                               <Geographic3DCRSListFileName><%= Geographic3DCRS.ListFileName %></Geographic3DCRSListFileName>
                               <ProjectedCRSListFileName><%= ProjectedCRS.ListFileName %></ProjectedCRSListFileName>
                               <GeocentricCRSListFileName><%= GeocentricCRS.ListFileName %></GeocentricCRSListFileName>
                               <VerticalCRSListFileName><%= VerticalCRS.ListFileName %></VerticalCRSListFileName>
                               <EngineeringCRSListFileName><%= EngineeringCRS.ListFileName %></EngineeringCRSListFileName>
                               <CompoundCRSListFileName><%= CompoundCRS.ListFileName %></CompoundCRSListFileName>
                           </ProjectSettings>

        Dim SettingsFileName As String = "ProjectSettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Project.SaveXmlSettings(SettingsFileName, settingsData)
    End Sub

    Private Sub RestoreProjectSettings()
        'Restore the project settings from an XML document.

        Dim SettingsFileName As String = "ProjectSettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"

        If Project.SettingsFileExists(SettingsFileName) Then
            Dim Settings As System.Xml.Linq.XDocument
            Project.ReadXmlSettings(SettingsFileName, Settings)

            If IsNothing(Settings) Then 'There is no Settings XML data.
                Exit Sub
            End If

            'Restore EPSG database path:
            If Settings.<ProjectSettings>.<EpsgDatabasePath>.Value = Nothing Then
                'Project setting not saved.
                EpsgDatabasePath = ""
            Else
                EpsgDatabasePath = Settings.<ProjectSettings>.<EpsgDatabasePath>.Value
            End If

            'Restore AreaOfUse list file name:
            If Settings.<ProjectSettings>.<AreaOfUseListFileName>.Value = Nothing Then
                'Project setting not saved.
                AreaOfUse.ListFileName = ""
            Else
                AreaOfUse.ListFileName = Settings.<ProjectSettings>.<AreaOfUseListFileName>.Value
            End If

            'Restore UnitOfMeasure list file name:
            If Settings.<ProjectSettings>.<UnitOfMeasureListFileName>.Value = Nothing Then
                'Project setting not saved.
                UnitOfMeasure.ListFileName = ""
            Else
                UnitOfMeasure.ListFileName = Settings.<ProjectSettings>.<UnitOfMeasureListFileName>.Value
            End If

            'Restore PrimeMeridian list file name:
            If Settings.<ProjectSettings>.<PrimeMeridianListFileName>.Value = Nothing Then
                'Project setting not saved.
                PrimeMeridian.ListFileName = ""
            Else
                PrimeMeridian.ListFileName = Settings.<ProjectSettings>.<PrimeMeridianListFileName>.Value
            End If

            'Restore Ellipsoid list file name:
            If Settings.<ProjectSettings>.<EllipsoidListFileName>.Value = Nothing Then
                'Project setting not saved.
                Ellipsoid.ListFileName = ""
            Else
                Ellipsoid.ListFileName = Settings.<ProjectSettings>.<EllipsoidListFileName>.Value
            End If

            'Restore Projection list file name:
            If Settings.<ProjectSettings>.<ProjectionListFileName>.Value = Nothing Then
                'Project setting not saved.
                Projection.ListFileName = ""
            Else
                Projection.ListFileName = Settings.<ProjectSettings>.<ProjectionListFileName>.Value
            End If

            'Restore CoordOpMethod list file name:
            If Settings.<ProjectSettings>.<CoordOpMethodListFileName>.Value = Nothing Then
                'Project setting not saved.
                CoordOpMethod.ListFileName = ""
            Else
                CoordOpMethod.ListFileName = Settings.<ProjectSettings>.<CoordOpMethodListFileName>.Value
            End If

            'Restore CoordRefSystem list file name:
            If Settings.<ProjectSettings>.<CoordRefSystemListFileName>.Value = Nothing Then
                'Project setting not saved.
                CoordRefSystem.ListFileName = ""
            Else
                CoordRefSystem.ListFileName = Settings.<ProjectSettings>.<CoordRefSystemListFileName>.Value
            End If

            'Restore CoordinateSystem list file name:
            If Settings.<ProjectSettings>.<CoordinateSystemListFileName>.Value = Nothing Then
                'Project setting not saved.
                CoordinateSystem.ListFileName = ""
            Else
                CoordinateSystem.ListFileName = Settings.<ProjectSettings>.<CoordinateSystemListFileName>.Value
            End If

            'Restore Datum list file name:
            If Settings.<ProjectSettings>.<DatumListFileName>.Value = Nothing Then
                'Project setting not saved.
                Datum.ListFileName = ""
            Else
                Datum.ListFileName = Settings.<ProjectSettings>.<DatumListFileName>.Value
            End If

            'Restore Transformation list file name:
            If Settings.<ProjectSettings>.<TransformationListFileName>.Value = Nothing Then
                'Project setting not saved.
                Transformation.ListFileName = ""
            Else
                Transformation.ListFileName = Settings.<ProjectSettings>.<TransformationListFileName>.Value
            End If

            'Restore Geodetic Datum list file name:
            If Settings.<ProjectSettings>.<GeodeticDatumListFileName>.Value = Nothing Then
                'Project setting not saved.
                GeodeticDatum.ListFileName = ""
            Else
                GeodeticDatum.ListFileName = Settings.<ProjectSettings>.<GeodeticDatumListFileName>.Value
            End If

            'Restore Vertical Datum list file name:
            If Settings.<ProjectSettings>.<VerticalDatumListFileName>.Value = Nothing Then
                'Project setting not saved.
                VerticalDatum.ListFileName = ""
            Else
                VerticalDatum.ListFileName = Settings.<ProjectSettings>.<VerticalDatumListFileName>.Value
            End If

            'Restore Engineering Datum list file name:
            If Settings.<ProjectSettings>.<EngineeringDatumListFileName>.Value = Nothing Then
                'Project setting not saved.
                EngineeringDatum.ListFileName = ""
            Else
                EngineeringDatum.ListFileName = Settings.<ProjectSettings>.<EngineeringDatumListFileName>.Value
            End If

            'Restore Geographic2DCRS list file name:
            If Settings.<ProjectSettings>.<Geographic2DCRSListFileName>.Value = Nothing Then
                'Project setting not saved.
                Geographic2DCRS.ListFileName = ""
            Else
                Geographic2DCRS.ListFileName = Settings.<ProjectSettings>.<Geographic2DCRSListFileName>.Value
            End If

            'Restore Geographic3DCRS list file name:
            If Settings.<ProjectSettings>.<Geographic3DCRSListFileName>.Value = Nothing Then
                'Project setting not saved.
                Geographic3DCRS.ListFileName = ""
            Else
                Geographic3DCRS.ListFileName = Settings.<ProjectSettings>.<Geographic3DCRSListFileName>.Value
            End If

            'Restore ProjectedCRS list file name:
            If Settings.<ProjectSettings>.<ProjectedCRSListFileName>.Value = Nothing Then
                'Project setting not saved.
                ProjectedCRS.ListFileName = ""
            Else
                ProjectedCRS.ListFileName = Settings.<ProjectSettings>.<ProjectedCRSListFileName>.Value
            End If

            'Restore GeocentricCRS list file name:
            If Settings.<ProjectSettings>.<GeocentricCRSListFileName>.Value = Nothing Then
                'Project setting not saved.
                GeocentricCRS.ListFileName = ""
            Else
                GeocentricCRS.ListFileName = Settings.<ProjectSettings>.<GeocentricCRSListFileName>.Value
            End If

            'Restore VerticalCRS list file name:
            If Settings.<ProjectSettings>.<VerticalCRSListFileName>.Value = Nothing Then
                'Project setting not saved.
                VerticalCRS.ListFileName = ""
            Else
                VerticalCRS.ListFileName = Settings.<ProjectSettings>.<VerticalCRSListFileName>.Value
            End If

            'Restore EngineeringCRS list file name:
            If Settings.<ProjectSettings>.<EngineeringCRSListFileName>.Value = Nothing Then
                'Project setting not saved.
                EngineeringCRS.ListFileName = ""
            Else
                EngineeringCRS.ListFileName = Settings.<ProjectSettings>.<EngineeringCRSListFileName>.Value
            End If

            'Restore CompoundCRS list file name:
            If Settings.<ProjectSettings>.<CompoundCRSListFileName>.Value = Nothing Then
                'Project setting not saved.
                CompoundCRS.ListFileName = ""
            Else
                CompoundCRS.ListFileName = Settings.<ProjectSettings>.<CompoundCRSListFileName>.Value
            End If

        End If

    End Sub

    Private Sub ReadApplicationInfo()
        'Read the Application Information.
        'Generate a new ApplicationInfo file if none exists.
        'ApplicationInfo.ApplicationDir = My.Application.Info.DirectoryPath.ToString 'Set the Application Directory property
        If ApplicationInfo.FileExists Then
            ApplicationInfo.ReadFile()
        Else
            'There is no Application_Info.xml file.
            'Set up default application properties: ---------------------------------------------------------------------------
            DefaultAppProperties()
        End If

    End Sub

    Private Sub DefaultAppProperties()

        ApplicationInfo.Name = "ADVL_Coordinates_1"

        'ApplicationInfo.ApplicationDir is set when the application is started.
        ApplicationInfo.ExecutablePath = Application.ExecutablePath

        ApplicationInfo.Description = "Application for viewing coordinate reference system parameters and converting locations between systems."
        ApplicationInfo.CreationDate = "7-Jan-2016 12:00:00"

        'Author -----------------------------------------------------------------------------------------------------------
        ApplicationInfo.Author.Name = "Signalworks Pty Ltd"
        ApplicationInfo.Author.Description = "Signalworks Pty Ltd" & vbCrLf &
        "Australian Proprietary Company" & vbCrLf &
        "ABN 26 066 681 598" & vbCrLf &
        "Registration Date 05/10/1994"

        ApplicationInfo.Author.Contact = "http://www.andorville.com.au/"


        'File Associations: -----------------------------------------------------------------------------------------------
        Dim Assn1 As New ADVL_Utilities_Library_1.FileAssociation
        Assn1.Extension = "ADVLCoord"
        Assn1.Description = "Andorville (TM) software coordinate system parameter file"
        ApplicationInfo.FileAssociations.Add(Assn1)

        'Version ----------------------------------------------------------------------------------------------------------
        ApplicationInfo.Version.Major = My.Application.Info.Version.Major
        ApplicationInfo.Version.Minor = My.Application.Info.Version.Minor
        ApplicationInfo.Version.Build = My.Application.Info.Version.Build
        ApplicationInfo.Version.Revision = My.Application.Info.Version.Revision

        'Copyright --------------------------------------------------------------------------------------------------------
        ApplicationInfo.Copyright.OwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        ApplicationInfo.Copyright.PublicationYear = "2016"

        'Trademarks -------------------------------------------------------------------------------------------------------
        Dim Trademark1 As New ADVL_Utilities_Library_1.Trademark
        Trademark1.OwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        Trademark1.Text = "Andorville"
        Trademark1.Registered = False 'Note the trademark may be registered in some countries. Setting Registered to False displays the TM symbol instead of the registered trademark symbol. 
        'This is the suitable notice for any country, where the trademark is registered or unregistered.
        Trademark1.GenericTerm = "software"
        ApplicationInfo.Trademarks.Add(Trademark1)

        Dim Trademark2 As New ADVL_Utilities_Library_1.Trademark
        Trademark2.OwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        Trademark2.Text = "AL-H7"
        Trademark2.Registered = False 'Note the trademark may be registered in some countries. Setting Registered to False displays the TM symbol instead of the registered trademark symbol.
        'This is the suitable notice for any country, where the trademark is registered or unregistered.
        Trademark2.GenericTerm = "software"
        ApplicationInfo.Trademarks.Add(Trademark2)

        'License -------------------------------------------------------------------------------------------------------
        ApplicationInfo.License.Type = ADVL_Utilities_Library_1.License.Types.Apache_License_2_0
        ApplicationInfo.License.CopyrightOwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        ApplicationInfo.License.PublicationYear = "2016"
        ApplicationInfo.License.Notice = ApplicationInfo.License.ApacheLicenseNotice
        ApplicationInfo.License.Text = ApplicationInfo.License.ApacheLicenseText

        'Source Code: --------------------------------------------------------------------------------------------------
        ApplicationInfo.SourceCode.Language = "Visual Basic 2015"
        ApplicationInfo.SourceCode.FileName = ""
        ApplicationInfo.SourceCode.FileSize = 0
        ApplicationInfo.SourceCode.FileHash = ""
        ApplicationInfo.SourceCode.WebLink = ""
        ApplicationInfo.SourceCode.Contact = ""
        ApplicationInfo.SourceCode.Comments = ""

        'ModificationSummary: -----------------------------------------------------------------------------------------
        ApplicationInfo.ModificationSummary.BaseCodeName = ""
        ApplicationInfo.ModificationSummary.BaseCodeDescription = ""
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Major = 0
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Minor = 0
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Build = 0
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Revision = 0
        ApplicationInfo.ModificationSummary.Description = "This is the first released version of the application. No earlier base code used."

        'Library List: ------------------------------------------------------------------------------------------------
        'Add ADVL_System_Utilties library:
        Dim NewLib As New ADVL_Utilities_Library_1.LibrarySummary
        NewLib.Name = "ADVL_System_Utilities"
        NewLib.Description = "System Utility classes used in Andorville (TM) software development system applications"
        NewLib.CreationDate = "7-Jan-2016 12:00:00"
        NewLib.LicenseNotice = "Copyright 2016 Signalworks Pty Ltd, ABN 26 066 681 598" & vbCrLf &
                           vbCrLf &
                           "Licensed under the Apache License, Version 2.0 (the ""License"");" & vbCrLf &
                           "you may not use this file except in compliance with the License." & vbCrLf &
                           "You may obtain a copy of the License at" & vbCrLf &
                           vbCrLf &
                           "http://www.apache.org/licenses/LICENSE-2.0" & vbCrLf &
                           vbCrLf &
                           "Unless required by applicable law or agreed to in writing, software" & vbCrLf &
                           "distributed under the License is distributed on an ""AS IS"" BASIS," & vbCrLf &
                           "WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied." & vbCrLf &
                           "See the License for the specific language governing permissions and" & vbCrLf &
                           "limitations under the License." & vbCrLf

        NewLib.CopyrightNotice = "Copyright 2016 Signalworks Pty Ltd, ABN 26 066 681 598"

        NewLib.Version.Major = 1
        NewLib.Version.Minor = 0
        NewLib.Version.Build = 1
        NewLib.Version.Revision = 0

        NewLib.Author.Name = "Signalworks Pty Ltd"
        NewLib.Author.Description = "Signalworks Pty Ltd" & vbCrLf &
        "Australian Proprietary Company" & vbCrLf &
        "ABN 26 066 681 598" & vbCrLf &
        "Registration Date 05/10/1994"


        NewLib.Author.Contact = "http://www.andorville.com.au/"

        Dim NewClass1 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass1.Name = "ZipComp"
        NewClass1.Description = "The ZipComp class is used to compress files into and extract files from a zip file."
        NewLib.Classes.Add(NewClass1)
        Dim NewClass2 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass2.Name = "XSequence"
        NewClass2.Description = "The XSequence class is used to run an XML property sequence (XSequence) file. XSequence files are used to record and replay processing sequences in Andorville (TM) software applications."
        NewLib.Classes.Add(NewClass2)
        Dim NewClass3 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass3.Name = "XMessage"
        NewClass3.Description = "The XMessage class is used to read an XML Message (XMessage). An XMessage is a simplified XSequence used to exchange information between Andorville (TM) software applications."
        NewLib.Classes.Add(NewClass3)
        Dim NewClass4 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass4.Name = "Location"
        NewClass4.Description = "The Location class consists of properties and methods to store data in a location, which is either a directory or archive file."
        NewLib.Classes.Add(NewClass4)
        Dim NewClass5 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass5.Name = "Project"
        NewClass5.Description = "An Andorville (TM) software application can store data within one or more projects. Each project stores a set of related data files. The Project class contains properties and methods used to manage a project."
        NewLib.Classes.Add(NewClass5)
        Dim NewClass6 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass6.Name = "ProjectSummary"
        NewClass6.Description = "ProjectSummary stores a summary of a project."
        NewLib.Classes.Add(NewClass6)
        Dim NewClass7 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass7.Name = "DataFileInfo"
        NewClass7.Description = "The DataFileInfo class stores information about a data file."
        NewLib.Classes.Add(NewClass7)
        Dim NewClass8 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass8.Name = "Message"
        NewClass8.Description = "The Message class contains text properties and methods used to display messages in an Andorville (TM) software application."
        NewLib.Classes.Add(NewClass8)
        Dim NewClass9 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass9.Name = "ApplicationSummary"
        NewClass9.Description = "The ApplicationSummary class stores a summary of an Andorville (TM) software application."
        NewLib.Classes.Add(NewClass9)
        Dim NewClass10 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass10.Name = "LibrarySummary"
        NewClass10.Description = "The LibrarySummary class stores a summary of a software library used by an application."
        NewLib.Classes.Add(NewClass10)
        Dim NewClass11 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass11.Name = "ClassSummary"
        NewClass11.Description = "The ClassSummary class stores a summary of a class contained in a software library."
        NewLib.Classes.Add(NewClass11)
        Dim NewClass12 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass12.Name = "ModificationSummary"
        NewClass12.Description = "The ModificationSummary class stores a summary of any modifications made to an application or library."
        NewLib.Classes.Add(NewClass12)
        Dim NewClass13 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass13.Name = "ApplicationInfo"
        NewClass13.Description = "The ApplicationInfo class stores information about an Andorville (TM) software application."
        NewLib.Classes.Add(NewClass13)
        Dim NewClass14 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass14.Name = "Version"
        NewClass14.Description = "The Version class stores application, library or project version information."
        NewLib.Classes.Add(NewClass14)
        Dim NewClass15 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass15.Name = "Author"
        NewClass15.Description = "The Author class stores information about an Author."
        NewLib.Classes.Add(NewClass15)
        Dim NewClass16 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass16.Name = "FileAssociation"
        NewClass16.Description = "The FileAssociation class stores the file association extension and description. An application can open files on its file association list."
        NewLib.Classes.Add(NewClass16)
        Dim NewClass17 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass17.Name = "Copyright"
        NewClass17.Description = "The Copyright class stores copyright information."
        NewLib.Classes.Add(NewClass17)
        Dim NewClass18 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass18.Name = "License"
        NewClass18.Description = "The License class stores license information."
        NewLib.Classes.Add(NewClass18)
        Dim NewClass19 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass19.Name = "SourceCode"
        NewClass19.Description = "The SourceCode class stores information about the source code for the application."
        NewLib.Classes.Add(NewClass19)
        Dim NewClass20 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass20.Name = "Usage"
        NewClass20.Description = "The Usage class stores information about application or project usage."
        NewLib.Classes.Add(NewClass20)
        Dim NewClass21 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass21.Name = "Trademark"
        NewClass21.Description = "The Trademark class stored information about a trademark used by the author of an application or data."
        NewLib.Classes.Add(NewClass21)

        ApplicationInfo.Libraries.Add(NewLib)

        'Add ADVL_Coordinates_Library:
        Dim NewLib2 As New ADVL_Utilities_Library_1.LibrarySummary
        NewLib2.Name = "ADVL_Coordinates_Library"
        NewLib2.Description = "Coordinates Library classes used in the Andorville (TM) software ADVL_Coordinates_1 application"
        NewLib2.CreationDate = "7-Jan-2016 12:00:00"
        NewLib2.LicenseNotice = "Copyright 2016 Signalworks Pty Ltd, ABN 26 066 681 598" & vbCrLf &
                           vbCrLf &
                           "Licensed under the Apache License, Version 2.0 (the ""License"");" & vbCrLf &
                           "you may not use this file except in compliance with the License." & vbCrLf &
                           "You may obtain a copy of the License at" & vbCrLf &
                           vbCrLf &
                           "http://www.apache.org/licenses/LICENSE-2.0" & vbCrLf &
                           vbCrLf &
                           "Unless required by applicable law or agreed to in writing, software" & vbCrLf &
                           "distributed under the License is distributed on an ""AS IS"" BASIS," & vbCrLf &
                           "WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied." & vbCrLf &
                           "See the License for the specific language governing permissions and" & vbCrLf &
                           "limitations under the License." & vbCrLf

        NewLib2.CopyrightNotice = "Copyright 2016 Signalworks Pty Ltd, ABN 26 066 681 598"

        NewLib2.Version.Major = 1
        NewLib2.Version.Minor = 0
        NewLib2.Version.Build = 1
        NewLib2.Version.Revision = 0

        NewLib2.Author.Name = "Signalworks Pty Ltd"
        NewLib2.Author.Description = "Signalworks Pty Ltd" & vbCrLf &
        "Australian Proprietary Company" & vbCrLf &
        "ABN 26 066 681 598" & vbCrLf &
        "Registration Date 05/10/1994"


        NewLib2.Author.Contact = "http://www.andorville.com.au/"

        Dim NewClass201 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass201.Name = "CoordinateAxisName"
        NewClass201.Description = "The CoordinateAxisName class is used to store coordinate axis names read from a EPSG database."
        NewLib2.Classes.Add(NewClass201)
        Dim NewClass202 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass202.Name = "CoordinateAxis"
        NewClass202.Description = "The CoordinateAxis class stores the parameters used to define a coordinate axis."
        NewLib2.Classes.Add(NewClass202)
        Dim NewClass203 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass203.Name = "CoordinateSystem"
        NewClass203.Description = "The CoordinateSystem class stores information about coordinate systems."
        NewLib2.Classes.Add(NewClass203)
        Dim NewClass204 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass204.Name = "CoordinateReferenceSystemSummary"
        NewClass204.Description = "The CoordinateReferenceSystemSummary class stores a summary of each coordinate reference system."
        NewLib2.Classes.Add(NewClass204)
        Dim NewClass205 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass205.Name = "CompoundCRS"
        NewClass205.Description = "The CompoundCRS class stores detailed parameters for Compound coordinate reference systems."
        NewLib2.Classes.Add(NewClass205)
        Dim NewClass206 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass206.Name = "EngineeringCRS"
        NewClass206.Description = "The EngineeringCRS class stores detailed parameters for Engineering coordinate reference systems."
        NewLib2.Classes.Add(NewClass206)
        Dim NewClass207 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass207.Name = "GeocentricCRS"
        NewClass207.Description = "The GeocentricCRS class stores detailed parameters for Geocentric coordinate reference systems."
        NewLib2.Classes.Add(NewClass207)
        Dim NewClass208 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass208.Name = "Geographic2DCRS"
        NewClass208.Description = "The Geographic2DCRS class stores detailed parameters for Geographic 2D coordinate reference systems."
        NewLib2.Classes.Add(NewClass208)
        Dim NewClass209 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass209.Name = "Geographic3DCRS"
        NewClass209.Description = "The Geographic3DCRS class stores detailed parameters for Geographic 3D coordinate reference systems."
        NewLib2.Classes.Add(NewClass209)
        Dim NewClass210 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass210.Name = "ProjectedCRS"
        NewClass210.Description = "The ProjectedCRS class stores detailed parameters for Projected coordinate reference systems."
        NewLib2.Classes.Add(NewClass210)
        Dim NewClass211 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass211.Name = "VerticalCRS"
        NewClass211.Description = "The VerticalCRS class stores detailed parameters for Vertical coordinate reference systems."
        NewLib2.Classes.Add(NewClass211)
        Dim NewClass212 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass212.Name = "GeographicCRSSummary"
        NewClass212.Description = "The GeographicCRSSummary class stores a summary of a Geographic coordinate reference system. This is used to describe the Source Geographic CRS used in some of the 2D Geographic CRSs."
        NewLib2.Classes.Add(NewClass212)
        Dim NewClass213 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass213.Name = "Geographic2DCRSSummary"
        NewClass213.Description = "The Geographic2DCRSSummary class stores a summary of a Geographic 2D coordinate reference system. Excludes the parameters for Area of Use, Coordinate System, Datum and Base CRS."
        NewLib2.Classes.Add(NewClass213)
        Dim NewClass214 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass214.Name = "NameAuthorCodeInfo"
        NewClass214.Description = "The NameAuthorCodeInfo class stores the Name, Author and Code of a set of parameters. These are used to select a parameter record from a list."
        NewLib2.Classes.Add(NewClass214)
        Dim NewClass215 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass215.Name = "TransverseMercator"
        NewClass215.Description = "The TransverseMercator class stores the projection parameters and converts coordinates between the geographic and projected values."
        NewLib2.Classes.Add(NewClass215)
        Dim NewClass216 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass216.Name = "TransverseMercatorProjectionParameters"
        NewClass216.Description = "The TransverseMercatorProjectionParameters class is used in the TransverseMercator class to store the projection parameters."
        NewLib2.Classes.Add(NewClass216)
        Dim NewClass217 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass217.Name = "GeographicCRSParameters"
        NewClass217.Description = "The GeographicCRSParameters class is used in the TransverseMercator class to store the Geographic CRS parameters."
        NewLib2.Classes.Add(NewClass217)
        Dim NewClass218 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass218.Name = "Projection"
        NewClass218.Description = "The Projection class stores parameters for each projection."
        NewLib2.Classes.Add(NewClass218)
        Dim NewClass219 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass219.Name = "CoordOpMethod"
        NewClass219.Description = "The CoordOpMethod class stores information about a coordinate operation method. These methods are used for coordinate projections and datum transformations."
        NewLib2.Classes.Add(NewClass219)
        Dim NewClass220 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass220.Name = "Transformation"
        NewClass220.Description = "The Transformation class stores parameters for a Coordinate Transformation."
        NewLib2.Classes.Add(NewClass220)
        Dim NewClass221 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass221.Name = "ValueSummary"
        NewClass221.Description = "The ValueSummary class consists of value quantity and a summary of the associated units."
        NewLib2.Classes.Add(NewClass221)

        Dim NewClass222 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass222.Name = "Value"
        NewClass222.Description = "The Value class consists of value quantity and associated units."
        NewLib2.Classes.Add(NewClass222)

        Dim NewClass223 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass223.Name = "ParameterSummary"
        NewClass223.Description = "The ParameterSummary class stores coordinate operation parameters (excluding the parameter value and units)."
        NewLib2.Classes.Add(NewClass223)

        Dim NewClass224 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass224.Name = "Parameter"
        NewClass224.Description = "The Parameter class stores coordinate operation parameters."
        NewLib2.Classes.Add(NewClass224)

        Dim NewClass225 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass225.Name = "CoordinateOperationMethod"
        NewClass225.Description = "The CoordinateOperationMethod class stores information about a coordinate operation method."
        NewLib2.Classes.Add(NewClass225)

        Dim NewClass226 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass226.Name = "DatumSummary"
        NewClass226.Description = "The DatumSummary class stores summary information about a Datum."
        NewLib2.Classes.Add(NewClass226)

        Dim NewClass227 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass227.Name = "DatumSummaryWithArea"
        NewClass227.Description = "The DatumSummaryWithArea class stores summary information about a Datum and the Area Of Use."
        NewLib2.Classes.Add(NewClass227)

        Dim NewClass228 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass228.Name = "GeodeticDatum"
        NewClass228.Description = "The Geodetic Datum class is used to store the parameters of different geodetic datums. These are used to define point locations."
        NewLib2.Classes.Add(NewClass228)

        Dim NewClass229 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass229.Name = "Ellipsoid"
        NewClass229.Description = "The ellipsoid class is used to store ellispod parameters."
        NewLib2.Classes.Add(NewClass229)

        Dim NewClass230 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass230.Name = "PrimeMeridian"
        NewClass230.Description = "The PrimeMeridian class stores Prime Meridian parmeters, which are used to define a datum."
        NewLib2.Classes.Add(NewClass230)

        Dim NewClass231 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass231.Name = "UnitOfMeasureSummary"
        NewClass231.Description = "The UnitOfMeasureSummary class stores Unit of Measure summary parameters."
        NewLib2.Classes.Add(NewClass231)

        Dim NewClass232 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass232.Name = "UnitOfMeasure"
        NewClass232.Description = "The UnitOfMeasure class stores Unit of Measure parameters. This class can also convert values to standard units of measure."
        NewLib2.Classes.Add(NewClass232)

        Dim NewClass233 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass233.Name = "AreaOfUse"
        NewClass233.Description = "The AreaOfUse class is used to store Area Of Use parameters."
        NewLib2.Classes.Add(NewClass233)

        Dim NewClass234 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass234.Name = "SevenParamTransformation"
        NewClass234.Description = "The SevenParamTransformation class is used to store the parameters used for a datum transformation."
        NewLib2.Classes.Add(NewClass234)

        Dim NewClass235 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass235.Name = "AngleDegMinSec"
        NewClass235.Description = "The AngleDegMinSec class stores an angle expressed as degress, minutes and seconds (DMS). This class also converts between decimal degrees and DMS."
        NewLib2.Classes.Add(NewClass235)

        Dim NewClass236 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass236.Name = "AngleConvert"
        NewClass236.Description = "The AngleConvert class converts angles between turns, decimal degrees, sexagesimal degrees, radians, grads (or gradians) and DMS."
        NewLib2.Classes.Add(NewClass236)

        Dim NewClass237 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass237.Name = "AngleConvertAuto"
        NewClass237.Description = "The AngleConvertAuto class converts angles between turns, decimal degrees, sexagesimal degrees, radians, grads (or gradians) and DMS. The class includes an option to automatically convert to preferred angle units."
        NewLib2.Classes.Add(NewClass237)

        Dim NewClass238 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass238.Name = "Location"
        NewClass238.Description = "The Location class is used to store a point location in different forms."
        NewLib2.Classes.Add(NewClass238)

        'ListInfo class is redundant!!! This information is not included in the Lisat of Parameters classes.

        Dim NewClass239 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass239.Name = "AreaOfUseList"
        NewClass239.Description = "The AreaOfUseList class is used to store a list of Area Of Use parameters."
        NewLib2.Classes.Add(NewClass239)

        'Add new list classes here...

        ApplicationInfo.Libraries.Add(NewLib2)

    End Sub

#End Region 'Process XML Files ----------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Subroutines - Code used to display this form." '--------------------------------------------------------------------------------------------------------------------------------

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Starting the Main form.

        'Write the startup messages in a stringbuilder object.
        'Messages cannot be written using Message.Add until this is set up later in the startup sequence.
        Dim sb As New System.Text.StringBuilder
        sb.Append("------------------- Starting Application: ADVL Coordinates -------------------------------------------------------------------------- " & vbCrLf)

        'Set the Application Directory path:
        Project.ApplicationDir = My.Application.Info.DirectoryPath.ToString
        sb.Append("Application Directory = " & Project.ApplicationDir & vbCrLf)

        'Read the Application Information file: ---------------------------------------------
        ApplicationInfo.ApplicationDir = My.Application.Info.DirectoryPath.ToString 'Set the Application Directory property
        If ApplicationInfo.ApplicationLocked Then
            MessageBox.Show("The application is locked. If the application is not already in use, remove the 'Application_Info.lock file from the application directory: " & ApplicationInfo.ApplicationDir, "Notice", MessageBoxButtons.OK)
            Dim dr As Windows.Forms.DialogResult
            dr = MessageBox.Show("Press 'Yes' to unlock the application", "Notice", MessageBoxButtons.YesNo)
            If dr = Windows.Forms.DialogResult.Yes Then
                ApplicationInfo.UnlockApplication()
            Else
                Application.Exit()
            End If
        End If
        ReadApplicationInfo()
        ApplicationInfo.LockApplication()
        sb.Append("Application Info file has been read." & vbCrLf)

        'Read the Application Usage information: --------------------------------------------
        ApplicationUsage.StartTime = Now
        ApplicationUsage.SaveLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
        ApplicationUsage.SaveLocn.Path = Project.ApplicationDir
        ApplicationUsage.RestoreUsageInfo()
        sb.Append("Application usage: Total duration = " & ApplicationUsage.TotalDuration.TotalHours & " hours" & vbCrLf)

        Project.ApplicationName = ApplicationInfo.Name
        sb.Append("Project.ApplicationName =  " & ApplicationInfo.Name & vbCrLf)

        'Read the Settings Location for the last project used:
        Project.ReadLastProjectInfo()
        'The Last_Project_Info.xml file contains:
        '  Project Name and Description. Settings Location Type and Settings Location Path.

        sb.Append("Last project info has been read." & vbCrLf)
        sb.Append("Project.SettingsLocn.Type  " & Project.SettingsLocn.Type.ToString & vbCrLf)
        sb.Append("Project.SettingsLocn.Path  " & Project.SettingsLocn.Path & vbCrLf)

        'Read the Project Information file: -------------------------------------------------
        Project.ReadProjectInfoFile()
        'Read the file in the SettingsLocation: ADVL_Project_Info.xml

        sb.Append("Reading project info." & vbCrLf)

        'Set the project start time. This is used to track project usage.
        Project.Usage.StartTime = Now

        ApplicationInfo.SettingsLocn = Project.SettingsLocn

        'Set up Message object:
        Message.ApplicationName = ApplicationInfo.Name
        Message.SettingsLocn = Project.SettingsLocn

        RestoreFormSettings()
        RestoreProjectSettings()

        'Show the project information:
        txtProjectName.Text = Project.Name
        txtProjectDescription.Text = Project.Description
        Select Case Project.Type
            Case ADVL_Utilities_Library_1.Project.Types.Directory
                txtProjectType.Text = "Directory"
            Case ADVL_Utilities_Library_1.Project.Types.Archive
                txtProjectType.Text = "Archive"
            Case ADVL_Utilities_Library_1.Project.Types.Hybrid
                txtProjectType.Text = "Hybrid"
            Case ADVL_Utilities_Library_1.Project.Types.None
                txtProjectType.Text = "None"
        End Select
        txtCreationDate.Text = Format(Project.Usage.FirstUsed, "d-MMM-yyyy H:mm:ss")
        txtLastUsed.Text = Format(Project.Usage.LastUsed, "d-MMM-yyyy H:mm:ss")
        Select Case Project.SettingsLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtSettingsLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtSettingsLocationType.Text = "Archive"
        End Select
        txtSettingsLocationPath.Text = Project.SettingsLocn.Path
        Select Case Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtDataLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtDataLocationType.Text = "Archive"
        End Select
        txtDataLocationPath.Text = Project.DataLocn.Path

        'Set up the location information for each list
        AreaOfUse.FileLocation = Project.DataLocn
        UnitOfMeasure.FileLocation = Project.DataLocn
        PrimeMeridian.FileLocation = Project.DataLocn
        Ellipsoid.FileLocation = Project.DataLocn
        Projection.FileLocation = Project.DataLocn
        CoordOpMethod.FileLocation = Project.DataLocn
        CoordRefSystem.FileLocation = Project.DataLocn
        CoordinateSystem.FileLocation = Project.DataLocn
        Datum.FileLocation = Project.DataLocn
        Transformation.FileLocation = Project.DataLocn
        GeodeticDatum.FileLocation = Project.DataLocn
        VerticalDatum.FileLocation = Project.DataLocn
        EngineeringDatum.FileLocation = Project.DataLocn
        Geographic2DCRS.FileLocation = Project.DataLocn
        Geographic3DCRS.FileLocation = Project.DataLocn
        ProjectedCRS.FileLocation = Project.DataLocn
        GeocentricCRS.FileLocation = Project.DataLocn
        VerticalCRS.FileLocation = Project.DataLocn
        EngineeringCRS.FileLocation = Project.DataLocn
        CompoundCRS.FileLocation = Project.DataLocn

        SetupDistanceUnitsDictionary()

        sb.Append("------------------- Started OK ------------------------------------------------------------------------------------------------------ " & vbCrLf & vbCrLf)
        Me.Show() 'Show this form before showing the Message form
        Message.Add(sb.ToString)

        'https://msdn.microsoft.com/en-us/library/z2d603cy(v=vs.80).aspx#Y550
        'Process any command line arguments:
        Try
            For Each s As String In My.Application.CommandLineArgs
                Message.Add("Command line argument: " & vbCrLf & s & vbCrLf)
                InstrReceived = s
            Next
        Catch ex As Exception
            Message.Add("Error processing command line arguments: " & ex.Message & vbCrLf)
        End Try

        ShowEPSGTermsOfUse()

    End Sub

    Private Sub ShowEPSGTermsOfUse()
        Message.SetWarningStyle()
        Message.Add("Important Notice" & vbCrLf)
        Message.SetNormalStyle()
        Message.Add("This software can import and use the EPSG Geodetic Parameter Dataset." & vbCrLf)
        Message.Add("EPSG specify Terms of Use for this dataset." & vbCrLf)
        Message.Add("These terms can be found at: http://www.epsg.org/Termsofuse.aspx" & vbCrLf & vbCrLf)
        Message.Add("The terms include:" & vbCrLf)
        Message.Add("    The EPSG Facilities are published by IOGP at no charge. Distribution for profit is forbidden." & vbCrLf)
        Message.Add("    The data may be included in any commercial package provided that any commerciality is based on value added by the provider and not on a value ascribed to the EPSG Dataset which is made available at no charge." & vbCrLf)
        Message.Add("    Ownership of the EPSG Dataset by IOGP must be acknowledged in any publication or transmission (by whatever means) thereof (including permitted modifications)." & vbCrLf)
        Message.Add("    Modification of parameter values is permitted as described in the table 1 to allow change to the content of the information provided that numeric equivalence is achieved." & vbCrLf)
        Message.Add("    No data that has been modified other than as permitted in these Terms of Use shall be attributed to the EPSG Dataset." & vbCrLf & vbCrLf)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Application

        DisconnectFromAppNet() 'Disconnect from the Application Network.

        SaveFormSettings() 'Save the settings of this form.

        SaveProjectSettings()  'Save the project settings.

        ApplicationInfo.WriteFile()  'Update the Application Information file.
        ApplicationInfo.UnlockApplication()

        Project.SaveLastProjectInfo() 'Save information about the last project used.

        'Project.SaveProjectInfoFile() 'Update the Project Information file. This is not required unless there is a change made to the project.

        Project.Usage.SaveUsageInfo() 'Save Project usage information.

        ApplicationUsage.SaveUsageInfo() 'Save Application Usage information.

        Application.Exit()

    End Sub

    Private Sub SetupDistanceUnitsDictionary()
        'Set up the dictionary of distance units: 

        'Create conversion factor object, set the conversion factor values, add to the dictionary:
        Dim MillimetreFactors As New ConversionFactors
        MillimetreFactors.FactorB = 1
        MillimetreFactors.FactorC = 1000
        dictDistanceUnits.Add("millimetre", MillimetreFactors)
        Dim CentimetreFactors As New ConversionFactors
        CentimetreFactors.FactorB = 1
        CentimetreFactors.FactorC = 100
        dictDistanceUnits.Add("centimetre", CentimetreFactors)
        'Create conversion factor object, add to the dictionary, set the conversion factor values:
        Dim metreFactors As New ConversionFactors
        dictDistanceUnits.Add("metre", metreFactors)
        dictDistanceUnits("metre").FactorB = 1
        dictDistanceUnits("metre").FactorC = 1
        Dim footFactors As New ConversionFactors
        dictDistanceUnits.Add("foot", footFactors)
        dictDistanceUnits("foot").FactorB = 0.3048
        dictDistanceUnits("foot").FactorC = 1
        Dim usSurveyFootFactors As New ConversionFactors
        dictDistanceUnits.Add("US survey foot", usSurveyFootFactors)
        dictDistanceUnits("US survey foot").FactorB = 12
        dictDistanceUnits("US survey foot").FactorC = 39.37
        Dim clarkesFootFactors As New ConversionFactors
        dictDistanceUnits.Add("Clarke's foot", clarkesFootFactors)
        dictDistanceUnits("Clarke's foot").FactorB = 0.3047972654
        dictDistanceUnits("Clarke's foot").FactorC = 1

        'Add conversion factor object to the dictionary, set the conversion factor values:
        'This method of adding a new entry to the Distance Units dictionary only takes 3 lines.
        dictDistanceUnits.Add("fathom", New ConversionFactors)
        dictDistanceUnits("fathom").FactorB = 1.8288
        dictDistanceUnits("fathom").FactorC = 1
        dictDistanceUnits.Add("nautical mile", New ConversionFactors)
        dictDistanceUnits("nautical mile").FactorB = 1852
        dictDistanceUnits("nautical mile").FactorC = 1
        dictDistanceUnits.Add("German legal metre", New ConversionFactors)
        dictDistanceUnits("German legal metre").FactorB = 1.0000135965
        dictDistanceUnits("German legal metre").FactorC = 1
        dictDistanceUnits.Add("US survey chain", New ConversionFactors)
        dictDistanceUnits("US survey chain").FactorB = 792
        dictDistanceUnits("US survey chain").FactorC = 39.37
        dictDistanceUnits.Add("US survey link", New ConversionFactors)
        dictDistanceUnits("US survey link").FactorB = 7.92
        dictDistanceUnits("US survey link").FactorC = 39.37
        dictDistanceUnits.Add("US survey mile", New ConversionFactors)
        dictDistanceUnits("US survey mile").FactorB = 63360
        dictDistanceUnits("US survey mile").FactorC = 39.37
        dictDistanceUnits.Add("kilometre", New ConversionFactors)
        dictDistanceUnits("kilometre").FactorB = 1000
        dictDistanceUnits("kilometre").FactorC = 1
        dictDistanceUnits.Add("Clarke's yard", New ConversionFactors)
        dictDistanceUnits("Clarke's yard").FactorB = 0.9143917962
        dictDistanceUnits("Clarke's yard").FactorC = 1
        dictDistanceUnits.Add("Clarke's chain", New ConversionFactors)
        dictDistanceUnits("Clarke's chain").FactorB = 20.1166195164
        dictDistanceUnits("Clarke's chain").FactorC = 1
        dictDistanceUnits.Add("Clarke's link", New ConversionFactors)
        dictDistanceUnits("Clarke's link").FactorB = 0.201166195164
        dictDistanceUnits("Clarke's link").FactorC = 1
        dictDistanceUnits.Add("British yard (Sears 1922)", New ConversionFactors)
        dictDistanceUnits("British yard (Sears 1922)").FactorB = 36
        dictDistanceUnits("British yard (Sears 1922)").FactorC = 39.370147
        dictDistanceUnits.Add("British foot (Sears 1922)", New ConversionFactors)
        dictDistanceUnits("British foot (Sears 1922)").FactorB = 12
        dictDistanceUnits("British foot (Sears 1922)").FactorC = 39.370147
        dictDistanceUnits.Add("British chain (Sears 1922)", New ConversionFactors)
        dictDistanceUnits("British chain (Sears 1922)").FactorB = 792
        dictDistanceUnits("British chain (Sears 1922)").FactorC = 39.370147
        dictDistanceUnits.Add("British link (Sears 1922)", New ConversionFactors)
        dictDistanceUnits("British link (Sears 1922)").FactorB = 7.92
        dictDistanceUnits("British link (Sears 1922)").FactorC = 39.370147
        dictDistanceUnits.Add("British yard (Benoit 1895 A)", New ConversionFactors)
        dictDistanceUnits("British yard (Benoit 1895 A)").FactorB = 0.9143992
        dictDistanceUnits("British yard (Benoit 1895 A)").FactorC = 1
        dictDistanceUnits.Add("British foot (Benoit 1895 A)", New ConversionFactors)
        dictDistanceUnits("British foot (Benoit 1895 A)").FactorB = 0.9143992
        dictDistanceUnits("British foot (Benoit 1895 A)").FactorC = 3
        dictDistanceUnits.Add("British chain (Benoit 1895 A)", New ConversionFactors)
        dictDistanceUnits("British chain (Benoit 1895 A)").FactorB = 20.1167824
        dictDistanceUnits("British chain (Benoit 1895 A)").FactorC = 1
        dictDistanceUnits.Add("British link (Benoit 1895 A)", New ConversionFactors)
        dictDistanceUnits("British link (Benoit 1895 A)").FactorB = 0.201167824
        dictDistanceUnits("British link (Benoit 1895 A)").FactorC = 1
        dictDistanceUnits.Add("British yard (Benoit 1895 B)", New ConversionFactors)
        dictDistanceUnits("British yard (Benoit 1895 B)").FactorB = 36
        dictDistanceUnits("British yard (Benoit 1895 B)").FactorC = 39.370113
        dictDistanceUnits.Add("British foot (Benoit 1895 B)", New ConversionFactors)
        dictDistanceUnits("British foot (Benoit 1895 B)").FactorB = 12
        dictDistanceUnits("British foot (Benoit 1895 B)").FactorC = 39.370113
        dictDistanceUnits.Add("British chain (Benoit 1895 B)", New ConversionFactors)
        dictDistanceUnits("British chain (Benoit 1895 B)").FactorB = 792
        dictDistanceUnits("British chain (Benoit 1895 B)").FactorC = 39.370113
        dictDistanceUnits.Add("British link (Benoit 1895 B)", New ConversionFactors)
        dictDistanceUnits("British link (Benoit 1895 B)").FactorB = 7.92
        dictDistanceUnits("British link (Benoit 1895 B)").FactorC = 39.370113
        dictDistanceUnits.Add("British foot (1865)", New ConversionFactors)
        dictDistanceUnits("British foot (1865)").FactorB = 0.9144025
        dictDistanceUnits("British foot (1865)").FactorC = 3
        dictDistanceUnits.Add("Indian foot", New ConversionFactors)
        dictDistanceUnits("Indian foot").FactorB = 12
        dictDistanceUnits("Indian foot").FactorC = 39.370142
        dictDistanceUnits.Add("Indian foot (1937)", New ConversionFactors)
        dictDistanceUnits("Indian foot (1937)").FactorB = 0.30479841
        dictDistanceUnits("Indian foot (1937)").FactorC = 1
        dictDistanceUnits.Add("Indian foot (1962)", New ConversionFactors)
        dictDistanceUnits("Indian foot (1962)").FactorB = 0.3047996
        dictDistanceUnits("Indian foot (1962)").FactorC = 1
        dictDistanceUnits.Add("Indian foot (1975)", New ConversionFactors)
        dictDistanceUnits("Indian foot (1975)").FactorB = 0.3047995
        dictDistanceUnits("Indian foot (1975)").FactorC = 1
        dictDistanceUnits.Add("Indian yard", New ConversionFactors)
        dictDistanceUnits("Indian yard").FactorB = 36
        dictDistanceUnits("Indian yard").FactorC = 39.370142
        dictDistanceUnits.Add("Indian yard (1937)", New ConversionFactors)
        dictDistanceUnits("Indian yard (1937)").FactorB = 0.91439523
        dictDistanceUnits("Indian yard (1937)").FactorC = 1
        dictDistanceUnits.Add("Indian yard (1962)", New ConversionFactors)
        dictDistanceUnits("Indian yard (1962)").FactorB = 0.9143988
        dictDistanceUnits("Indian yard (1962)").FactorC = 1
        dictDistanceUnits.Add("Indian yard (1975)", New ConversionFactors)
        dictDistanceUnits("Indian yard (1975)").FactorB = 0.9143985
        dictDistanceUnits("Indian yard (1975)").FactorC = 1
        dictDistanceUnits.Add("Statute mile", New ConversionFactors)
        dictDistanceUnits("Statute mile").FactorB = 1609.344
        dictDistanceUnits("Statute mile").FactorC = 1
        dictDistanceUnits.Add("Gold Coast foot", New ConversionFactors)
        dictDistanceUnits("Gold Coast foot").FactorB = 6378300
        dictDistanceUnits("Gold Coast foot").FactorC = 20926201
        dictDistanceUnits.Add("British foot (1936)", New ConversionFactors)
        dictDistanceUnits("British foot (1936)").FactorB = 0.3048007491
        dictDistanceUnits("British foot (1936)").FactorC = 1
        dictDistanceUnits.Add("yard", New ConversionFactors)
        dictDistanceUnits("yard").FactorB = 0.9144
        dictDistanceUnits("yard").FactorC = 1
        dictDistanceUnits.Add("chain", New ConversionFactors)
        dictDistanceUnits("chain").FactorB = 20.1168
        dictDistanceUnits("chain").FactorC = 1
        dictDistanceUnits.Add("link", New ConversionFactors)
        dictDistanceUnits("link").FactorB = 20.1168
        dictDistanceUnits("link").FactorC = 100
        dictDistanceUnits.Add("British yard (Sears 1922 truncated)", New ConversionFactors)
        dictDistanceUnits("British yard (Sears 1922 truncated)").FactorB = 0.914398
        dictDistanceUnits("British yard (Sears 1922 truncated)").FactorC = 1
        dictDistanceUnits.Add("British foot (Sears 1922 truncated)", New ConversionFactors)
        dictDistanceUnits("British foot (Sears 1922 truncated)").FactorB = 0.914398
        dictDistanceUnits("British foot (Sears 1922 truncated)").FactorC = 3
        dictDistanceUnits.Add("British chain (Sears 1922 truncated)", New ConversionFactors)
        dictDistanceUnits("British chain (Sears 1922 truncated)").FactorB = 20.116756
        dictDistanceUnits("British chain (Sears 1922 truncated)").FactorC = 1
        dictDistanceUnits.Add("British link (Sears 1922 truncated)", New ConversionFactors)
        dictDistanceUnits("British link (Sears 1922 truncated)").FactorB = 20.116756
        dictDistanceUnits("British link (Sears 1922 truncated)").FactorC = 100

        'Example code: getting conversion factors from the DistanceUnits dictionary:
        'Dim ConversionFactors As New clsConversionFactors
        'ConversionFactors = dictDistanceUnits("millimetre")
        'Dim FactorB As Double
        'FactorB = dictDistanceUnits("millimetre").FactorB

    End Sub

#End Region 'Form Subroutines -----------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and close forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------

    Private Sub btnEpsgDatabase_Click(sender As Object, e As EventArgs) Handles btnEpsgDatabase.Click
        'Open the EPSG Database form:
        If IsNothing(EpsgDatabaseForm) Then
            EpsgDatabaseForm = New frmEpsgDatabase
            EpsgDatabaseForm.Show()
        Else
            EpsgDatabaseForm.Show()
        End If
    End Sub

    Private Sub EpsgDatabaseForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles EpsgDatabaseForm.FormClosed
        EpsgDatabaseForm = Nothing
    End Sub

    Private Sub btnMessages_Click(sender As Object, e As EventArgs) Handles btnMessages.Click
        Message.ApplicationName = ApplicationInfo.Name
        Message.SettingsLocn = Project.SettingsLocn
        Message.Show()
        Message.MessageForm.BringToFront()
    End Sub

    Private Sub btnConversions_Click(sender As Object, e As EventArgs) Handles btnConversions.Click
        'Open the Conversions form:
        If IsNothing(ConversionsForm) Then
            ConversionsForm = New frmConversions
            ConversionsForm.Show()
        Else
            ConversionsForm.Show()
        End If
    End Sub

    Private Sub ConversionsForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles ConversionsForm.FormClosed
        ConversionsForm = Nothing
    End Sub

    Private Sub btnProjectionCalcs_Click(sender As Object, e As EventArgs) Handles btnProjectionCalcs.Click
        'Open the Projection Calculations form:
        If IsNothing(ProjectionCalcsForm) Then
            ProjectionCalcsForm = New frmProjectionCalcs
            ProjectionCalcsForm.Show()
        Else
            ProjectionCalcsForm.Show()
        End If
    End Sub

    Private Sub ProjectionCalcsForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles ProjectionCalcsForm.FormClosed
        ProjectionCalcsForm = Nothing
    End Sub


#Region "Show Geodetic Parameters Forms" '----------------------------------------------------------------------------------------------------------------------------------------

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

#End Region 'Show Geodetic Parameters Forms" '------------------------------------------------------------------------------------------------------------------------------------

#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub txtProjectName_LostFocus(sender As Object, e As EventArgs) Handles txtProjectName.LostFocus
        'The Project Name has been changed
        Project.Name = txtProjectName.Text
    End Sub

    Private Sub txtProjectDescription_LostFocus(sender As Object, e As EventArgs) Handles txtProjectDescription.LostFocus
        'The Project Description has been changed
        Project.Description = txtProjectDescription.Text
    End Sub

    Private Sub txtProjectType_LostFocus(sender As Object, e As EventArgs) Handles txtProjectType.LostFocus
        'The Project Type had been changed.
        Select Case txtProjectType.Text
            Case "Archive"
                Project.Type = ADVL_Utilities_Library_1.Project.Types.Archive
            Case "Directory"
                Project.Type = ADVL_Utilities_Library_1.Project.Types.Directory
            Case "Hybrid"
                Project.Type = ADVL_Utilities_Library_1.Project.Types.Hybrid
            Case "None"
                Project.Type = ADVL_Utilities_Library_1.Project.Types.None
            Case Else
                txtProjectType.Text = Project.Type.ToString
        End Select
    End Sub

    Private Sub txtDataLocationType_LostFocus(sender As Object, e As EventArgs) Handles txtDataLocationType.LostFocus
        'The Data Location Type has been changed.
        Select Case txtDataLocationType.Text
            Case "Archive"
                Project.DataLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive
            Case "Directory"
                Project.DataLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
            Case Else
                txtDataLocationType.Text = Project.DataLocn.Type.ToString
        End Select
    End Sub

    Private Sub txtDataLocationPath_LostFocus(sender As Object, e As EventArgs) Handles txtDataLocationPath.LostFocus
        'The Data Location Path has been changed.
        Project.DataLocn.Path = txtDataLocationPath.Text
    End Sub

#Region " Display Messages"

    Private Sub AreaOfUse_ErrorMessage(Message As String) Handles AreaOfUse.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub AreaOfUse_Message(Message As String) Handles AreaOfUse.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub btnAppInfo_Click(sender As Object, e As EventArgs) Handles btnAppInfo.Click
        ApplicationInfo.ShowInfo()
    End Sub

    Private Sub CoordOpMethod_ErrorMessage(Message As String) Handles CoordOpMethod.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub CoordOpMethod_Message(Message As String) Handles CoordOpMethod.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub CoordinateSystem_ErrorMessage(Message As String) Handles CoordinateSystem.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub CoordinateSystem_Message(Message As String) Handles CoordinateSystem.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub Datum_ErrorMessage(Message As String) Handles Datum.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub Datum_Message(Message As String) Handles Datum.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub Transformation_ErrorMessage(Message As String) Handles Transformation.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub Transformation_Message(Message As String) Handles Transformation.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub GeodeticDatum_ErrorMessage(Message As String) Handles GeodeticDatum.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub GeodeticDatum_Message(Message As String) Handles GeodeticDatum.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub CoordRefSystem_ErrorMessage(Message As String) Handles CoordRefSystem.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub CoordRefSystem_Message(Message As String) Handles CoordRefSystem.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub Geographic2DCRS_ErrorMessage(Message As String) Handles Geographic2DCRS.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub Geographic2DCRS_Message(Message As String) Handles Geographic2DCRS.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub ProjectedCRS_ErrorMessage(Message As String) Handles ProjectedCRS.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub ProjectedCRS_Message(Message As String) Handles ProjectedCRS.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub Project_ErrorMessage(Message As String) Handles Project.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub Project_Message(Message As String) Handles Project.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub UnitOfMeasure_ErrorMessage(Message As String) Handles UnitOfMeasure.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub UnitOfMeasure_Message(Message As String) Handles UnitOfMeasure.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub PrimeMeridian_ErrorMessage(Message As String) Handles PrimeMeridian.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub PrimeMeridian_Message(Message As String) Handles PrimeMeridian.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub Ellipsoid_ErrorMessage(Message As String) Handles Ellipsoid.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub Ellipsoid_Message(Message As String) Handles Ellipsoid.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub Projection_ErrorMessage(Message As String) Handles Projection.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub Projection_Message(Message As String) Handles Projection.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub CompoundCRS_ErrorMessage(Message As String) Handles CompoundCRS.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message)
    End Sub

    Private Sub CompoundCRS_Message(Message As String) Handles CompoundCRS.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message)
    End Sub

#End Region 'Display Messages

    Private Sub btnProject_Click(sender As Object, e As EventArgs) Handles btnProject.Click
        Project.SelectProject() 'This opens the Project Form - A list of projects is displayed - Any of these can be selected.
    End Sub

    'Private Sub Project_ProjectChanging() Handles Project.ProjectChanging
    Private Sub Project_Closing() Handles Project.Closing
        'The current project is closing.

        'Save the current project settings:
        SaveProjectSettings()

        'Update the old Project Information file:
        'UPDATE: THIS DOES NOT NEED TO BE CHANGED.
        'Project.SaveProjectInfoFile()

        ''Save the old project usage information:
        Project.Usage.SaveUsageInfo()

    End Sub

    'Private Sub Project_ProjectSelected() Handles Project.ProjectSelected
    Private Sub Project_Selected() Handles Project.Selected
        'A new project has been selected.

        'Message.Add("------------------------- A project has been selected --------------------------------------------------------------" & vbCrLf)

        'Clear the parameter lists:
        'Message.Add("Clearing the old coordinate parameter lists." & vbCrLf)
        AreaOfUse.Clear()
        UnitOfMeasure.Clear()
        PrimeMeridian.Clear()
        Ellipsoid.Clear()
        Projection.Clear()
        CoordOpMethod.Clear()
        CoordRefSystem.Clear()
        CoordinateSystem.Clear()
        Datum.Clear()
        Transformation.Clear()
        GeodeticDatum.Clear()
        Geographic2DCRS.Clear()
        ProjectedCRS.Clear()

        'When a project is selected, initially only the settings location is specified.
        'The project information is read from the settings location to get the remaining information including the data location.

        'Read the Project Information file: -------------------------------------------------
        'ReadProjectInfo()
        Project.ReadProjectInfoFile()


        'Set the project start time. This is used to track project usage.
        Project.Usage.StartTime = Now

        ApplicationInfo.SettingsLocn = Project.SettingsLocn



        'Set up Message object:
        Message.ApplicationName = ApplicationInfo.Name
        Message.SettingsLocn = Project.SettingsLocn

        RestoreProjectSettings()

        'Message.SettingsLocn = Project.SettingsLocn

        'Update the project display.

        'Show the project information:
        txtProjectName.Text = Project.Name
        txtProjectDescription.Text = Project.Description
        Select Case Project.Type
            Case ADVL_Utilities_Library_1.Project.Types.Directory
                txtProjectType.Text = "Directory"
            Case ADVL_Utilities_Library_1.Project.Types.Archive
                txtProjectType.Text = "Archive"
            Case ADVL_Utilities_Library_1.Project.Types.Hybrid
                txtProjectType.Text = "Hybrid"
            Case ADVL_Utilities_Library_1.Project.Types.None
                txtProjectType.Text = "None"
        End Select
        'txtCreationDate.Text = Format(Project.CreationDate, "d-MMM-yyyy H:mm:ss")
        'txtLastUsed.Text = Format(Project.LastUsed, "d-MMM-yyyy H:mm:ss")
        'txtCreationDate.Text = Format(Project.Usage.FirstUsed, "d-MMM-yyyy H:mm:ss")
        txtCreationDate.Text = Format(Project.CreationDate, "d-MMM-yyyy H:mm:ss")
        txtLastUsed.Text = Format(Project.Usage.LastUsed, "d-MMM-yyyy H:mm:ss")
        Select Case Project.SettingsLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtSettingsLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtSettingsLocationType.Text = "Archive"
        End Select
        txtSettingsLocationPath.Text = Project.SettingsLocn.Path
        Select Case Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtDataLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtDataLocationType.Text = "Archive"
        End Select
        txtDataLocationPath.Text = Project.DataLocn.Path

        'Set up the location information for each list
        'Message.Add("Setting up new location information for each list." & vbCrLf)
        'Message.Add("Project.DataLocn.Type: " & Project.DataLocn.Type.ToString & vbCrLf)
        'Message.Add("Project.DataLocn.Path: " & Project.DataLocn.Path & vbCrLf)
        AreaOfUse.FileLocation = Project.DataLocn
        UnitOfMeasure.FileLocation = Project.DataLocn
        PrimeMeridian.FileLocation = Project.DataLocn
        Ellipsoid.FileLocation = Project.DataLocn
        Projection.FileLocation = Project.DataLocn
        CoordOpMethod.FileLocation = Project.DataLocn
        CoordRefSystem.FileLocation = Project.DataLocn
        CoordinateSystem.FileLocation = Project.DataLocn
        Datum.FileLocation = Project.DataLocn
        Transformation.FileLocation = Project.DataLocn
        GeodeticDatum.FileLocation = Project.DataLocn
        Geographic2DCRS.FileLocation = Project.DataLocn
        ProjectedCRS.FileLocation = Project.DataLocn

        'Message.Add("-------------------------- Finished selecting project --------------------------------------------------------------" & vbCrLf & vbCrLf)

    End Sub

    Private Sub btnAndorville_Click(sender As Object, e As EventArgs) Handles btnAndorville.Click
        ApplicationInfo.ShowInfo()
    End Sub

#Region " Online/Offline code"

    Private Sub btnOnline_Click(sender As Object, e As EventArgs) Handles btnOnline.Click
        'Connect to or disconnect from the Message Exchange.
        'If ConnectedToExchange = False Then
        If ConnectedToAppnet = False Then
            'ConnectToExchange()
            ConnectToAppNet()
        Else
            'DisconnectFromExchange()
            DisconnectFromAppNet()
        End If
    End Sub

    'Private Sub ConnectToExchange()
    Private Sub ConnectToAppNet()
        'Connect to the Message Exchange.

        Dim Result As Boolean

        If IsNothing(client) Then
            client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
        End If

        'client.Endpoint.Binding.ReceiveTimeout = New TimeSpan(1, 0, 0) '1 hour, 0 minutes, 0 seconds
        'client.Endpoint.Binding.OpenTimeout = New TimeSpan(1, 0, 0) '1 hour, 0 minutes, 0 seconds
        'client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) '1 hour, 0 minutes, 0 seconds
        'client.Endpoint.Binding.CloseTimeout = New System.TimeSpan(1, 0, 0) '1 hour, 0 minutes, 0 seconds

        If client.State = ServiceModel.CommunicationState.Faulted Then
            Message.SetWarningStyle()
            Message.Add("client state is faulted. Connection not made!" & vbCrLf)
        Else
            Try
                'client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 2) 'Temporarily set the send timeaout to 2 seconds
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 8) 'Temporarily set the send timeaout to 8 seconds

                'Result = client.Connect(ApplicationName, ServiceReference1.clsConnectionenumAppType.Application, False, False) 'Application Name is "CoordinatesServer"
                'Result = client.Connect(ApplicationInfo.Name, ServiceReference1.clsConnectionenumAppType.Application, False, False) 'Application Name is "CoordinatesServer"
                Result = client.Connect(ApplicationInfo.Name, ServiceReference1.clsConnectionAppTypes.Application, False, False) 'Application Name is "CoordinatesServer"
                'appName, appType, getAllWarnings, getAllMessages

                If Result = True Then
                    'Message.Add("Connected to the Message Exchange as CoordinatesServer" & vbCrLf)
                    'Message.Add("Connected to the Application Network as CoordinatesServer" & vbCrLf)
                    Message.Add("Connected to the Application Network as " & ApplicationInfo.Name & vbCrLf)
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                    btnOnline.Text = "Online"
                    btnOnline.ForeColor = Color.ForestGreen
                    'ConnectedToExchange = True
                    ConnectedToAppnet = True
                    SendApplicationInfo()
                Else
                    'Message.Add("Connection to the Message Exchange failed!" & vbCrLf)
                    Message.Add("Connection to the Application Network failed!" & vbCrLf)
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                End If
            Catch ex As System.TimeoutException
                'Message.Add("Timeout error. Check if the MessageExchange is running." & vbCrLf)
                Message.Add("Timeout error. Check if the Application Network is running." & vbCrLf)
            Catch ex As Exception
                'MessageAdd("Error: " & ex.InnerException.Message & vbCrLf)
                Message.Add("Error message: " & ex.Message & vbCrLf)
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
            End Try
        End If

    End Sub

    'Private Sub DisconnectFromExchange()
    Private Sub DisconnectFromAppNet()
        'Disconnect from the Message Exchange.

        Dim Result As Boolean

        If IsNothing(client) Then
            'Message.Add("Already disconnected from the Message Exchange." & vbCrLf)
            Message.Add("Already disconnected from the Application Network." & vbCrLf)
            btnOnline.Text = "Offline"
            btnOnline.ForeColor = Color.Black
            'ConnectedToExchange = False
            ConnectedToAppnet = False
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted." & vbCrLf)
            Else
                Try
                    'client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
                    Message.Add("Running client.Disconnect(ApplicationName)   ApplicationName = " & ApplicationInfo.Name & vbCrLf)
                    client.Disconnect(ApplicationInfo.Name) 'NOTE: If Application Network has closed, this application freezes at this line!!!!!!! Try Catch EndTry added to fix this.
                    btnOnline.Text = "Offline"
                    btnOnline.ForeColor = Color.Black
                    'ConnectedToExchange = False
                    ConnectedToAppnet = False
                    'client.Close()
                Catch ex As Exception
                    Message.SetWarningStyle()
                    Message.Add("Error disconnecting from Application Network: " & ex.Message & vbCrLf)
                End Try
            End If
        End If
    End Sub

    Private Sub SendApplicationInfo()
        'Send the application information to the Administrator connections.

        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                'client.SendMessageAsync("CoordinateServer", doc.ToString)

                'Create the XML instructions to send application information.
                Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                Dim applicationInfo As New XElement("ApplicationInfo")
                'Dim name As New XElement("Name", applicationInfo.Name)
                Dim name As New XElement("Name", Me.ApplicationInfo.Name)
                applicationInfo.Add(name)
                Dim exePath As New XElement("ExecutablePath", Me.ApplicationInfo.ExecutablePath)
                applicationInfo.Add(exePath)
                'Dim directory As New XElement("Directory", ApplicationDir)
                Dim directory As New XElement("Directory", Me.ApplicationInfo.ApplicationDir)
                applicationInfo.Add(directory)
                'Dim description As New XElement("Description", ApplicationDescription)
                Dim description As New XElement("Description", Me.ApplicationInfo.Description)
                applicationInfo.Add(description)
                xmessage.Add(applicationInfo)

                'Dim exeName As New XElement("ExeName", Me.ApplicationInfo.)


                doc.Add(xmessage)
                'client.SendMessageAsync("CoordinateServer", doc.ToString)
                'client.SendAdminMessageAsync(doc.ToString) 'Send the application information to all Admin connections.
                'client.SendMainNodeMessageAsync(doc.ToString) 'Send the application information to the Main Node.
                'client.SendMessage("MessageExchange", doc.ToString)
                Message.Color = Color.Red
                Message.FontStyle = FontStyle.Bold
                Message.XAdd("Application Info Message sent to Application Network" & vbCrLf)
                Message.SetNormalStyle()
                Message.XAdd(doc.ToString & vbCrLf & vbCrLf)

                client.SendMessage("ApplicationNetwork", doc.ToString)
            End If
        End If

    End Sub

#End Region 'Online/Offline code


    'Process XMessages: ---------------------------------------------------------------------------------------------------

    'Private Sub XMsg_Instruction(Path As String, Prop As String) Handles XMsg.Instruction
    'Private Sub XMsg_Instruction(Path As String, Pval As String) Handles XMsg.Instruction
    'Process each instruction to set the Property Value at that specified Path.
    'Private Sub XMsg_Instruction(Locn As String, Info As String) Handles XMsg.Instruction
    Private Sub XMsg_Instruction(Info As String, Locn As String) Handles XMsg.Instruction
        'Process each instruction to transfer the specified information to the specified location.

        'angleConvert and angleDegMinSec are used for angle conversions

        Select Case Locn
            Case "ClientName"
                ClientName = Info 'The name of the client requesting service.
                'MessageDest is usually set to ClientName when replying to the service request.

            'Case "Command"
            '    If Info = "ConnectToAppNet" Then
            '        If ConnectedToAppnet = False Then
            '            ConnectToAppNet()
            '        End If
            '    End If

            Case "Command"
                Select Case Info
                    Case "GetProjectedCrsList"    'Get the list of projected coordinate reference systems
                        GetProjectedCrsListForClient()

                    Case "ConnectToAppNet"
                        If ConnectedToAppnet = False Then
                            ConnectToAppNet()
                        End If
                End Select


            Case "ConvertAngle:InputDmsSign"
                If Info = "+" Then
                    angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Positive 'TDS_Utilities.Coordinates.clsAngleConvert.Sign.Positive
                ElseIf Info = "-" Then
                    angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Negative 'TDS_Utilities.Coordinates.clsAngleConvert.Sign.Negative
                Else
                    'Unknown sign
                End If

            Case "ConvertAngle:InputDmsDegrees"
                'The degrees value of the input DMS angle
                angleConvert.DmsDegrees = Info

            Case "ConvertAngle:InputDmsMinutes"
                'The minutes value of the input DMS angle
                angleConvert.DmsMinutes = Info

            Case "ConvertAngle:InputDmsSeconds"
                'The seconds value of the input DMS angle
                angleConvert.DmsSeconds = Info

            Case "ConvertAngle:InputDecimalDegrees"
                'The value of the input decimal degrees angle
                angleConvert.DecimalDegrees = Info

            Case "ConvertAngle:InputSexagesimalDegrees"
                'The value of the input sexagesimal degrees angle
                angleConvert.SexagesimalDegrees = Info

            Case "ConvertAngle:InputRadians"
                'The value of the input radians angle
                angleConvert.Radians = Info

            Case "ConvertAngle:InputGradians"
                'The value of the input gradians angle
                angleConvert.Gradians = Info

            Case "ConvertAngle:InputTurns"
                'The value of the input turns angle
                angleConvert.Turns = Info

            Case "ConvertAngle:OutputDmsSignName"
                'The name assigned to the output angle DMS sign  (Eg OutputDmsSign)
                OutputDmsSignName = Info

            Case "ConvertAngle:OutputDmsDegreesName"
                'The name assigned to the output angle DMS sign  (Eg OutputDmsDegrees)
                OutputDmsDegreesName = Info

            Case "ConvertAngle:OutputDmsMinutesName"
                'The name assigned to the output angle DMS sign  (Eg OutputDmsMinutes)
                OutputDmsMinutesName = Info

            Case "ConvertAngle:OutputDmsSecondsName"
                'The name assigned to the output angle DMS sign  (Eg OutputDmsSeconds)
                OutputDmsSecondsName = Info

            Case "ConvertAngle:OutputAngleName"
                'The name assigned to the output angle value (Eg OutputDecimalDegrees)
                OutputAngleName = Info

            Case "ConvertAngle:Command"
                'A convert angle command
                Dim Decl As New XDeclaration("1.0", "utf-8", "yes")
                Dim doc As New XDocument(Decl, Nothing) 'Create an XDocument to store the instructions.
                Dim process As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                Dim operation As New XElement("ConvertedAngle")
                Select Case Info
                    Case "ConvertDmsToDms"
                        If angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Negative Then
                            Dim outputDmsSign As New XElement(OutputDmsSignName, "-")
                            operation.Add(outputDmsSign)
                        Else
                            Dim outputDmsSign As New XElement(OutputDmsSignName, "+")
                            operation.Add(outputDmsSign)
                        End If
                        Dim OutputDmsDegrees As New XElement(OutputDmsDegreesName, angleConvert.DmsDegrees)
                        operation.Add(OutputDmsDegrees)
                        Dim OutputDmsMinutes As New XElement(OutputDmsMinutesName, angleConvert.DmsMinutes)
                        operation.Add(OutputDmsMinutes)
                        Dim OutputDmsSeconds As New XElement(OutputDmsSecondsName, angleConvert.DmsSeconds)
                        operation.Add(OutputDmsSeconds)

                    Case "ConvertDmsToDecimalDegrees"
                        angleConvert.ConvertDegMinSecToDecimalDegrees()
                        Dim outputDecimalDegrees As New XElement(OutputAngleName, angleConvert.DecimalDegrees)
                        operation.Add(outputDecimalDegrees)

                    Case "ConvertDmsToSexagecimalDegrees"
                        angleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                        Dim outputSexagesimalDegrees As New XElement(OutputAngleName, angleConvert.SexagesimalDegrees)
                        operation.Add(outputSexagesimalDegrees)

                    Case "ConvertDmsToRadians"
                        angleConvert.ConvertDegMinSecToRadians()
                        Dim outputRadians As New XElement(OutputAngleName, angleConvert.Radians)
                        operation.Add(outputRadians)

                    Case "ConvertDmsToGradians"
                        angleConvert.ConvertDegMinSecToGradians()
                        Dim outputGradians As New XElement(OutputAngleName, angleConvert.Gradians)
                        operation.Add(outputGradians)

                    Case "ConvertDmsToTurns"
                        angleConvert.ConvertDegMinSecToTurns()
                        Dim outputTurns As New XElement(OutputAngleName, angleConvert.Turns)
                        operation.Add(outputTurns)

                    Case "ConvertDecimalDegreesToDms"
                        angleConvert.ConvertDecimalDegreeToDegMinSec()
                        If angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Negative Then
                            Dim outputDmsSign As New XElement(OutputDmsSignName, "-")
                            operation.Add(outputDmsSign)
                        Else
                            Dim outputDmsSign As New XElement(OutputDmsSignName, "+")
                            operation.Add(outputDmsSign)
                        End If
                        Dim OutputDmsDegrees As New XElement(OutputDmsDegreesName, angleConvert.DmsDegrees)
                        operation.Add(OutputDmsDegrees)
                        Dim OutputDmsMinutes As New XElement(OutputDmsMinutesName, angleConvert.DmsMinutes)
                        operation.Add(OutputDmsMinutes)
                        Dim OutputDmsSeconds As New XElement(OutputDmsSecondsName, angleConvert.DmsSeconds)
                        operation.Add(OutputDmsSeconds)

                    Case "ConvertDecimalDegreesToDecimalDegrees"
                        Dim outputDecimalDegrees As New XElement(OutputAngleName, angleConvert.DecimalDegrees)
                        operation.Add(outputDecimalDegrees)

                    Case "ConvertDecimalDegreesToSexagesimalDegrees"
                        angleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                        Dim outputSexagesimalDegrees As New XElement(OutputAngleName, angleConvert.SexagesimalDegrees)
                        operation.Add(outputSexagesimalDegrees)

                    Case "ConvertDecimalDegreesToRadians"
                        angleConvert.ConvertDecimalDegreeToRadian()
                        Dim outputRadians As New XElement(OutputAngleName, angleConvert.Radians)
                        operation.Add(outputRadians)

                    Case "ConvertDecimalDegreesToGradians"
                        angleConvert.ConvertDecimalDegreeToGradian()
                        Dim outputGradians As New XElement(OutputAngleName, angleConvert.Gradians)
                        operation.Add(outputGradians)

                    Case "ConvertDecimalDegreesToTurns"
                        angleConvert.ConvertDecimalDegreeToTurn()
                        Dim outputTurns As New XElement(OutputAngleName, angleConvert.Turns)
                        operation.Add(outputTurns)

                    Case "ConvertSexagesimalDegreesToDms"
                        angleConvert.ConvertSexagesimalDegreeToDegMinSec()
                        If angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Negative Then
                            Dim outputDmsSign As New XElement(OutputDmsSignName, "-")
                            operation.Add(outputDmsSign)
                        Else
                            Dim outputDmsSign As New XElement(OutputDmsSignName, "+")
                            operation.Add(outputDmsSign)
                        End If
                        Dim OutputDmsDegrees As New XElement(OutputDmsDegreesName, angleConvert.DmsDegrees)
                        operation.Add(OutputDmsDegrees)
                        Dim OutputDmsMinutes As New XElement(OutputDmsMinutesName, angleConvert.DmsMinutes)
                        operation.Add(OutputDmsMinutes)
                        Dim OutputDmsSeconds As New XElement(OutputDmsSecondsName, angleConvert.DmsSeconds)
                        operation.Add(OutputDmsSeconds)

                    Case "ConvertSexagesimalDegreesToDecimalDegrees"
                        angleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                        Dim outputDecimalDegrees As New XElement(OutputAngleName, angleConvert.DecimalDegrees)
                        operation.Add(outputDecimalDegrees)

                    Case "ConvertSexagesimalDegreesToSexagesimalDegrees"
                        Dim outputSexagesimalDegrees As New XElement(OutputAngleName, angleConvert.SexagesimalDegrees)
                        operation.Add(outputSexagesimalDegrees)

                    Case "ConvertSexagesimalDegreesToRadians"
                        angleConvert.ConvertSexagesimalDegreeToRadian()
                        Dim outputRadians As New XElement(OutputAngleName, angleConvert.Radians)
                        operation.Add(outputRadians)

                    Case "ConvertSexagesimalDegreesToGradians"
                        angleConvert.ConvertSexagesimalDegreeToGradian()
                        Dim outputGradians As New XElement(OutputAngleName, angleConvert.Gradians)
                        operation.Add(outputGradians)

                    Case "ConvertSexagesimalDegreesToTurns"
                        angleConvert.ConvertSexagesimalDegreeToTurn()
                        Dim outputTurns As New XElement(OutputAngleName, angleConvert.Turns)
                        operation.Add(outputTurns)

                    Case "ConvertRadiansToDms"
                        angleConvert.ConvertRadianToDegMinSec()
                        If angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Negative Then
                            Dim outputDmsSign As New XElement(OutputDmsSignName, "-")
                            operation.Add(outputDmsSign)
                        Else
                            Dim outputDmsSign As New XElement(OutputDmsSignName, "+")
                            operation.Add(outputDmsSign)
                        End If
                        Dim OutputDmsDegrees As New XElement(OutputDmsDegreesName, angleConvert.DmsDegrees)
                        operation.Add(OutputDmsDegrees)
                        Dim OutputDmsMinutes As New XElement(OutputDmsMinutesName, angleConvert.DmsMinutes)
                        operation.Add(OutputDmsMinutes)
                        Dim OutputDmsSeconds As New XElement(OutputDmsSecondsName, angleConvert.DmsSeconds)
                        operation.Add(OutputDmsSeconds)

                    Case "ConvertRadiansToDecimalDegrees"
                        angleConvert.ConvertRadianToDecimalDegree()
                        Dim outputDecimalDegrees As New XElement(OutputAngleName, angleConvert.DecimalDegrees)
                        operation.Add(outputDecimalDegrees)

                    Case "ConvertRadiansToSexagesimalDegrees"
                        angleConvert.ConvertRadianToSexagesimalDegree()
                        Dim outputSexagesimalDegrees As New XElement(OutputAngleName, angleConvert.SexagesimalDegrees)
                        operation.Add(outputSexagesimalDegrees)

                    Case "ConvertRadiansToRadians"
                        Dim outputRadians As New XElement(OutputAngleName, angleConvert.Radians)
                        operation.Add(outputRadians)

                    Case "ConvertRadiansToGradians"
                        angleConvert.ConvertRadianToGradian()
                        Dim outputRadians As New XElement(OutputAngleName, angleConvert.Radians)
                        operation.Add(outputRadians)

                    Case "ConvertRadiansToTurns"
                        angleConvert.ConvertRadianToTurn()
                        Dim outputTurns As New XElement(OutputAngleName, angleConvert.Turns)
                        operation.Add(outputTurns)

                    Case "ConvertGradiansToDms"
                        angleConvert.ConvertGradianToDegMinSec()
                        If angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Negative Then
                            Dim outputDmsSign As New XElement(OutputDmsSignName, "-")
                            operation.Add(outputDmsSign)
                        Else
                            Dim outputDmsSign As New XElement(OutputDmsSignName, "+")
                            operation.Add(outputDmsSign)
                        End If
                        Dim OutputDmsDegrees As New XElement(OutputDmsDegreesName, angleConvert.DmsDegrees)
                        operation.Add(OutputDmsDegrees)
                        Dim OutputDmsMinutes As New XElement(OutputDmsMinutesName, angleConvert.DmsMinutes)
                        operation.Add(OutputDmsMinutes)
                        Dim OutputDmsSeconds As New XElement(OutputDmsSecondsName, angleConvert.DmsSeconds)
                        operation.Add(OutputDmsSeconds)

                    Case "ConvertGradiansToDecimalDegrees"
                        angleConvert.ConvertGradianToDecimalDegree()
                        Dim outputDecimalDegrees As New XElement(OutputAngleName, angleConvert.DecimalDegrees)
                        operation.Add(outputDecimalDegrees)

                    Case "ConvertGradiansToSexagesimalDegrees"
                        angleConvert.ConvertGradianToSexagesimalDegree()
                        Dim outputSexagesiamlDegrees As New XElement(OutputAngleName, angleConvert.SexagesimalDegrees)
                        operation.Add(outputSexagesiamlDegrees)

                    Case "ConvertGradiansToRadians"
                        angleConvert.ConvertGradianToRadian()
                        Dim outputRadians As New XElement(OutputAngleName, angleConvert.Radians)
                        operation.Add(outputRadians)

                    Case "ConvertGradiansToGradians"
                        Dim outputGradians As New XElement(OutputAngleName, angleConvert.Gradians)
                        operation.Add(outputGradians)

                    Case "ConvertGradiansToTurns"
                        angleConvert.ConvertGradianToTurn()
                        Dim outputTurns As New XElement(OutputAngleName, angleConvert.Turns)
                        operation.Add(outputTurns)

                    Case "ConvertTurnsToDms"
                        angleConvert.ConvertTurnToDegMinSec()
                        If angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Negative Then
                            Dim outputDmsSign As New XElement(OutputDmsSignName, "-")
                            operation.Add(outputDmsSign)
                        Else
                            Dim outputDmsSign As New XElement(OutputDmsSignName, "+")
                            operation.Add(outputDmsSign)
                        End If
                        Dim OutputDmsDegrees As New XElement(OutputDmsDegreesName, angleConvert.DmsDegrees)
                        operation.Add(OutputDmsDegrees)
                        Dim OutputDmsMinutes As New XElement(OutputDmsMinutesName, angleConvert.DmsMinutes)
                        operation.Add(OutputDmsMinutes)
                        Dim OutputDmsSeconds As New XElement(OutputDmsSecondsName, angleConvert.DmsSeconds)
                        operation.Add(OutputDmsSeconds)

                    Case "ConvertTurnsToDecimalDegrees"
                        angleConvert.ConvertTurnToDecimalDegree()
                        Dim outputDecimalDegrees As New XElement(OutputAngleName, angleConvert.DecimalDegrees)
                        operation.Add(outputDecimalDegrees)

                    Case "ConvertTurnsToSexagesimalDegrees"
                        angleConvert.ConvertTurnToSexagesimalDegree()
                        Dim outputSexagesiamlDegrees As New XElement(OutputAngleName, angleConvert.SexagesimalDegrees)
                        operation.Add(outputSexagesiamlDegrees)

                    Case "ConvertTurnsToRadians"
                        angleConvert.ConvertTurnToRadian()
                        Dim outputRadians As New XElement(OutputAngleName, angleConvert.Radians)
                        operation.Add(outputRadians)

                    Case "ConvertTurnsToGradians"
                        angleConvert.ConvertTurnToGradian()
                        Dim outputRadians As New XElement(OutputAngleName, angleConvert.Radians)
                        operation.Add(outputRadians)

                    Case "ConvertTurnsToTurns"
                        Dim outputTurns As New XElement(OutputAngleName, angleConvert.Turns)
                        operation.Add(outputTurns)

                    Case Else

                End Select 'ConvertAngle:Command Prop

                process.Add(operation)
                doc.Add(process)
                'doc now contains the instructions to return to the client application.
                MessageText = doc.ToString 'This message is sent after the input message is processed.

                'Convert Projected Coordinates ----------------------------------------------------------------------------------------------------------------------------------------
            Case "ConvertProjectedCoordinates:ProjectedCRS" 'Convert Projected Coordinates operation: set the Projected CRS.
                ProjectedCrsInfo.Name = Info
                GetProjectedCrsParameters() 'Get the projected CRS parameters corresponding to ProjectionInfo.Name

            Case "ConvertProjectedCoordinates:InputCoordinates:Type"
                If Info = "Geographic" Then
                    ProjectedCrsInfo.InputCoordinatesType = ProjectedCrsInfo.CoordsType.Geographic
                ElseIf Info = "Projected" Then
                    ProjectedCrsInfo.InputCoordinatesType = ProjectedCrsInfo.CoordsType.Projected
                End If

            Case "ConvertProjectedCoordinates:InputCoordinates:Easting"
                SetEasting(Info)

            Case "ConvertProjectedCoordinates:InputCoordinates:Northing"
                SetNorthing(Info)

            Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeDmsSign"
                If Info = "-" Then
                    ProjectedCrsInfo.InputLatitude.DmsSign = InputAngle.Sign.Negative
                Else
                    ProjectedCrsInfo.InputLatitude.DmsSign = InputAngle.Sign.Positive
                End If

            Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeDmsDegrees"

                ProjectedCrsInfo.InputLatitude.DmsDegrees = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeDmsMinutes"
                ProjectedCrsInfo.InputLatitude.DmsMinutes = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeDmsSeconds"
                ProjectedCrsInfo.InputLatitude.DmsSeconds = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeDecimalDegrees"
                ProjectedCrsInfo.InputLatitude.DecimalDegrees = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeSexagesimalDegrees"
                ProjectedCrsInfo.InputLatitude.SexagesimalDegrees = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeRadians"
                ProjectedCrsInfo.InputLatitude.Radians = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeGradians"
                ProjectedCrsInfo.InputLatitude.Gradians = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeTurns"
                ProjectedCrsInfo.InputLatitude.Turns = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeDmsSign"
                If Info = "-" Then
                    ProjectedCrsInfo.InputLongitude.DmsSign = InputAngle.Sign.Negative
                Else
                    ProjectedCrsInfo.InputLongitude.DmsSign = InputAngle.Sign.Positive
                End If

            Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeDmsDegrees"
                ProjectedCrsInfo.InputLongitude.DmsDegrees = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeDmsMinutes"
                ProjectedCrsInfo.InputLongitude.DmsMinutes = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeDmsSeconds"
                ProjectedCrsInfo.InputLongitude.DmsSeconds = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeDecimalDegrees"
                ProjectedCrsInfo.InputLongitude.DecimalDegrees = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeSexagesimalDegrees"
                ProjectedCrsInfo.InputLongitude.SexagesimalDegrees = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeRadians"
                ProjectedCrsInfo.InputLongitude.Radians = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeGradians"
                ProjectedCrsInfo.InputLongitude.Gradians = Info

            Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeTurns"
                ProjectedCrsInfo.InputLongitude.Turns = Info

            Case "ConvertProjectedCoordinates:OutputCoordinates:Type"
                If Info = "Geographic" Then
                    ProjectedCrsInfo.OutputCoordinatesType = ProjectedCrsInfo.CoordsType.Geographic
                ElseIf Info = "Projected" Then
                    ProjectedCrsInfo.OutputCoordinatesType = ProjectedCrsInfo.CoordsType.Projected
                End If

            Case "ConvertProjectedCoordinates:OutputCoordinates:EastingUnits"
                ProjectedCrsInfo.OutputEasting.OutputUnit = Info

            Case "ConvertProjectedCoordinates:OutputCoordinates:NorthingUnits"
                ProjectedCrsInfo.OutputNorthing.OutputUnit = Info

            Case "ConvertProjectedCoordinates:Command"
                Select Case Info
                    Case "ConvertCoordinates"
                        If ProjectedCrsInfo.InputCoordinatesType = ProjectedCrsInfo.CoordsType.Geographic Then
                            LatLongToEastingNorthing()
                        ElseIf ProjectedCrsInfo.InputCoordinatesType = ProjectedCrsInfo.CoordsType.Projected Then
                            EastingNorthingToLatLong()
                        End If
                End Select
                'End Convert Projected Coordinates ---------------------------------------------------------------------------------------------------------------------------------

            'Command Case used above
            'Case "Command"
            '    Select Case Info
            '        Case "GetProjectedCrsList"    'Get the list of projected coordinate reference systems
            '            GetProjectedCrsListForClient()
            '    End Select

                'Case "MessageExchangeClosing"
            Case "ApplicationNetworkClosing"

                btnOnline.Text = "Offline"
                btnOnline.ForeColor = Color.Black
                'ConnectedToExchange = False
                ConnectedToAppnet = False
                Try
                    client.Close()
                Catch ex As Exception
                    client.Abort()
                End Try
                client = Nothing

            Case "EndOfSequence"

            Case Else
                Message.SetWarningStyle()
                Message.Add("Statement not recognized: " & Locn & "  value: " & Info & vbCrLf)
        End Select

    End Sub

    Private Sub XMsg_ErrorMsg(ErrMsg As String) Handles XMsg.ErrorMsg
        'Process the error message:
        Message.SetWarningStyle()
        Message.Add("Error message: " & ErrMsg & vbCrLf)
    End Sub

    Private Sub SendMessage()
        'Code used to send a message after a timer delay.
        'The message destination is stored in MessageDest
        'The message text is stored in MessageText
        Timer1.Interval = 100 '100ms delay
        Timer1.Enabled = True 'Start the timer.
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If IsNothing(client) Then
            Message.SetWarningStyle()
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.SetWarningStyle()
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                Try
                    Message.Add("Sending a message. Number of characters: " & MessageText.Length & vbCrLf)
                    'client.SendMessageAsync(MessageDest, MessageText)
                    client.SendMessage(MessageDest, MessageText)

                    'Show sent message in the Sent Messages tab
                    'Check if the Messages form is open:
                    'If IsNothing(Messages) Then
                    '    Messages = New frmMessages
                    '    Messages.Show()
                    '    Messages.rtbInstructionsSent.Text = MessageText & vbCrLf
                    'Else
                    '    Messages.Show()
                    '    Messages.rtbInstructionsSent.Text = MessageText & vbCrLf
                    'End If

                    'Message.XAdd(MessageText & vbCrLf)

                    MessageText = "" 'Clear the message after it has been sent.
                Catch ex As Exception
                    Message.SetWarningStyle()
                    Message.Add("Error sending message: " & ex.Message & vbCrLf)
                End Try

            End If

        End If

        'Stop timer:
        Timer1.Enabled = False
    End Sub

    Private Sub GetProjectedCrsParameters()
        'Get the projected CRS parameters corresponding to ProjectionInfo.ProjectedCrsName

        'If ProjectedCRSList.Count = 0 Then
        '    OpenProjectedCRSListFile()
        'End If
        ProjectedCRS.AddUser()

        'If ProjectedCRSList.Count > 0 Then
        If ProjectedCRS.NRecords > 0 Then
            'Find the selected Projected CRS:
            Dim ProjCrsMatch = From ProjCrs In ProjectedCRS.List Where ProjCrs.Name = ProjectedCrsInfo.Name

            If ProjCrsMatch.Count > 0 Then
                Select Case ProjCrsMatch(0).ProjectionMethod.Name
                    Case "Transverse Mercator"
                        'ProjectedCrsInfo.Projection.Type = clsProjnInfo.ProjectionType.Transverse_Mercator
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Transverse_Mercator
                        ProjectedCrsInfo.Author = ProjCrsMatch(0).Author
                        ProjectedCrsInfo.Code = ProjCrsMatch(0).Code
                        ProjectedCrsInfo.Projection.Name = ProjCrsMatch(0).Projection.Name 'Not the same as the projection method
                        ProjectedCrsInfo.Projection.Author = ProjCrsMatch(0).Projection.Author
                        ProjectedCrsInfo.Projection.Code = ProjCrsMatch(0).Projection.Code
                        ProjectedCrsInfo.SourceGeogCrsType = ProjCrsMatch(0).SourceGeographicCRS.Type
                        ProjectedCrsInfo.SourceGeogCrsAuthor = ProjCrsMatch(0).SourceGeographicCRS.Author
                        ProjectedCrsInfo.SourceGeogCrsCode = ProjCrsMatch(0).SourceGeographicCRS.Code

                        'ProjectedCrsInfo.
                        GetTransverseMercatorParameters()
                        GetTMEllipsoidParameters()

                    Case "Albers Equal Area"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Albers_Equal_Area
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "American Polyconic"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.American_Polyconic
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Bonne (South Oriented)"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Bonne_South_Orientated
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Cassini Soldner"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Cassini_Soldner
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Colomia Urban"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Colombia_Urban
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Equidistant Cylindrical"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Equidistant_Cylindrical
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Equidistant Cylindrical Spherical"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Equidistant_Cylindrical_Spherical
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Guam Projection"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Guam_Projection
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Hotine Oblique Mercator Variant A"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Hotine_Oblique_Mercator_Variant_A
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Hotine Oblique Mercator Variant B"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Hotine_Oblique_Mercator_Variant_B
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Hyperbolic Cassini Soldner"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Hyperbolic_Cassini_Soldner
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Krovak"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Krovak
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Krovak Modified"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Krovak_Modified
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Krovak Modified North Oriented"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Krovak_Modified_North_Orientated
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Krovak North Oriented"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Krovak_North_Orientated
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Lambert Azimuthal Equal Area"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Lambert_Azimuthal_Equal_Area
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Lambert Azimuthal Equal Area Spherical"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Lambert_Azimuthal_Equal_Area_Spherical
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Lambert Conic Conformal 1SP"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_1SP
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Lambert Conic Conformal 2SP"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Lambert Conic Conformal 2SP Belgium"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP_Belgium
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Lambert Conic Conformal 2SP Michigan"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP_Michigan
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Lambert Conic Conformal West Oriented"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_West_Orientated
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Lambert Conic Conformal West Oriented"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Lambert_Conic_Near_Conformal
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Lambert Cylindrical Equal Area Spherical"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Lambert_Cylindrical_Equal_Area_Spherical
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Mercator Variant A"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Mercator_Variant_A
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Mercator Variant B"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Mercator_Variant_B
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Modified Azimuthal Equidistant"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Modified_Azimuthal_Equidistant
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "New Zealand Map Grid"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.New_Zealand_Map_Grid
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Oblique Stereographic"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Oblique_Stereographic
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Polar Stereographic Variant A"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_A
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Polar Stereographic Variant B"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_B
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Polar Stereographic Variant C"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_C
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Popular Visualization Pseudo Mercator"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Popular_Visualization_Pseudo_Mercator
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Transverse Mercator Zoned Grid System"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Transverse_Mercator_Zoned_Grid_System
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case "Tunisia Minig Grid"
                        ProjectedCrsInfo.Projection.Type = ProjectionInfo.ProjectionTypes.Tunisia_Mining_Grid
                        Message.Add("Projection method not currently supported: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                    Case Else
                        Message.Add("Unknown projection method: " & ProjCrsMatch(0).ProjectionMethod.Name & vbCrLf)
                End Select
            End If
        Else

        End If

        ProjectedCRS.RemoveUser()

    End Sub

    Private Sub GetTransverseMercatorParameters()
        'Get the Transverse Mercator projection parameters corresponding to ProjectionInfo.Name

        'If ProjectionList.Count = 0 Then
        '    OpenProjectionListFile()
        'End If

        Projection.AddUser()

        TransverseMercator = New ADVL_Coordinates_Library_1.TransverseMercator 'TDS_Utilities.Coordinates.clsTransverseMercator

        'Dim ProjectionMatch = From Projection In ProjectionList Where Projection.Author = ProjectionInfo.Author And Projection.Code = ProjectionInfo.Code
        Dim ProjectionMatch = From Projection In Projection.List Where Projection.Author = ProjectedCrsInfo.Projection.Author And Projection.Code = ProjectedCrsInfo.Projection.Code

        If ProjectionMatch.Count > 0 Then
            TransverseMercator.Projection.Name = ProjectionMatch(0).Name
            TransverseMercator.Projection.Author = ProjectionMatch(0).Author
            TransverseMercator.Projection.Code = ProjectionMatch(0).Code

            TransverseMercator.Projection.DistanceUnits = "Unknown"
            For Each item In ProjectionMatch(0).ParameterValue
                Select Case item.Name
                    Case "Latitude of natural origin"
                        Message.Add("Latitude of natural origin is : " & item.Value & "   units: " & item.Unit.Name & vbCrLf)
                        Select Case item.Unit.Name
                            Case "degree"
                                TransverseMercator.Projection.LatitudeOfNaturalOrigin = item.Value 'Store Latitude of natural origin as degrees
                            Case "sexagesimal DMS"
                                angleConvert.SexagesimalDegrees = item.Value
                                angleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                TransverseMercator.Projection.LatitudeOfNaturalOrigin = angleConvert.DecimalDegrees 'Store Latitude of natural origin as degrees
                            Case Else
                                'DISPLAY ERROR MESSAGE
                        End Select
                    Case "Longitude of natural origin"
                        Message.Add("Longitude of natural origin is : " & item.Value & "   units: " & item.Unit.Name & vbCrLf)
                        Select Case item.Unit.Name
                            Case "degree"
                                TransverseMercator.Projection.LongitudeOfNaturalOrigin = item.Value 'Store Longitude of natural origin as degrees
                            Case "sexagesimal DMS"
                                angleConvert.SexagesimalDegrees = item.Value
                                angleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                                TransverseMercator.Projection.LongitudeOfNaturalOrigin = angleConvert.DecimalDegrees  'Store Longitude of natural origin as degrees
                            Case Else
                                'DISPLAY ERROR MESSAGE
                        End Select
                    Case "Scale factor at natural origin"
                        Message.Add("Scale factor at natural origin is : " & item.Value & "   units: " & item.Unit.Name & vbCrLf)
                        Select Case item.Unit.Name
                            Case "unity"
                                TransverseMercator.Projection.ScaleFactorAtNaturalOrigin = item.Value
                            Case Else
                                'DISPLAY ERROR MESSAGE
                        End Select
                    Case "False easting"
                        Message.Add("False easting is : " & item.Value & "   units: " & item.Unit.Name & vbCrLf)
                        If TransverseMercator.Projection.DistanceUnits = "Unknown" Then
                            TransverseMercator.Projection.DistanceUnits = item.Unit.Name
                        Else
                            If TransverseMercator.Projection.DistanceUnits = item.Unit.Name Then
                                'Distance units are consistent
                            Else
                                'Inconsistent distance units.
                                'DISPLAY ERROR MESSAGE
                                Message.Add("Inconsistent distance units! False easting units are: " & item.Unit.Name & "   other units used are: " & TransverseMercator.Projection.DistanceUnits & vbCrLf)
                            End If
                        End If
                        TransverseMercator.Projection.FalseEasting = item.Value
                    Case "False northing"
                        Message.Add("False northing is : " & item.Value & "   units: " & item.Unit.Name & vbCrLf)
                        If TransverseMercator.Projection.DistanceUnits = "Unknown" Then
                            TransverseMercator.Projection.DistanceUnits = item.Unit.Name
                        Else
                            If TransverseMercator.Projection.DistanceUnits = item.Unit.Name Then
                                'Distance units are consistent
                            Else
                                'Inconsistent distance units.
                                'DISPLAY ERROR MESSAGE
                                Message.Add("Inconsistent distance units! False northing units are: " & item.Unit.Name & "   other units used are: " & TransverseMercator.Projection.DistanceUnits & vbCrLf)
                            End If
                        End If
                        TransverseMercator.Projection.FalseNorthing = item.Value
                End Select
            Next
            ProjectedCrsInfo.ParametersLoaded = True
        Else
            Message.Add("Projection not found:  Author= " & ProjectedCrsInfo.Projection.Author & "   Code = " & ProjectedCrsInfo.Projection.Code & vbCrLf)
            ProjectedCrsInfo.ParametersLoaded = False
        End If

        Projection.RemoveUser()

    End Sub

    Private Sub GetTMEllipsoidParameters()
        'Get the Transverse Mercator Ellipsoid parameters.

        Ellipsoid.AddUser()

        If ProjectedCrsInfo.SourceGeogCrsType = "geographic 2D" Then
            'If Geographic2DCRSList.Count = 0 Then
            '    OpenGeographic2DCRSListFile()
            'End If
            Geographic2DCRS.AddUser()

            'Dim BaseCrsMatch = From BaseCrs In Geographic2DCRSList Where BaseCrs.Author = ProjectedCrsInfo.SourceGeogCrsAuthor And BaseCrs.Code = ProjectedCrsInfo.SourceGeogCrsCode
            Dim BaseCrsMatch = From BaseCrs In Geographic2DCRS.List Where BaseCrs.Author = ProjectedCrsInfo.SourceGeogCrsAuthor And BaseCrs.Code = ProjectedCrsInfo.SourceGeogCrsCode

            If BaseCrsMatch.Count > 0 Then
                TransverseMercator.GeographicCRS.Name = BaseCrsMatch(0).Name
                TransverseMercator.GeographicCRS.Author = BaseCrsMatch(0).Author
                TransverseMercator.GeographicCRS.Code = BaseCrsMatch(0).Code
                GetDatumMatch(BaseCrsMatch(0).Datum.Author, BaseCrsMatch(0).Datum.Code)
            End If
        ElseIf ProjectedCrsInfo.SourceGeogCrsType = "geographic 3D" Then

        End If

        Ellipsoid.RemoveUser()

    End Sub

    Private Sub GetDatumMatch(ByVal Author As String, ByVal Code As Integer)
        'Get Datum record corresponding to Datum Author and Code.

        'If GeodeticDatumList.Count = 0 Then
        '    OpenGeodeticDatumListFile()
        'End If

        GeodeticDatum.AddUser()
        Dim DatumMatch = From Datum In GeodeticDatum.List Where Datum.Author = Author And Datum.Code = Code

        If DatumMatch.Count > 0 Then
            TransverseMercator.GeographicCRS.DatumName = DatumMatch(0).Name
            TransverseMercator.GeographicCRS.EllipsoidName = DatumMatch(0).Ellipsoid.Name

            Dim EllipsoidMatch = From Ellipsoid In Ellipsoid.List Where Ellipsoid.Author = DatumMatch(0).Ellipsoid.Author And Ellipsoid.Code = DatumMatch(0).Ellipsoid.Code

            If EllipsoidMatch.Count > 0 Then
                'If DatumMatch(0).Ellipsoid.EllipsoidParameters = ADVL_Coordinates_Library_1.Coordinates.Ellipsoid.DefiningParameters.SemiMajorAxis_InverseFlattening Then
                If EllipsoidMatch(0).EllipsoidParameters = ADVL_Coordinates_Library_1.Ellipsoid.DefiningParameters.SemiMajorAxis_InverseFlattening Then
                    'TransverseMercator.GeographicCRS.SemiMajorAxis = DatumMatch(0).Ellipsoid.SemiMajorAxis
                    TransverseMercator.GeographicCRS.SemiMajorAxis = EllipsoidMatch(0).SemiMajorAxis
                    'TransverseMercator.GeographicCRS.InverseFlattening = DatumMatch(0).Ellipsoid.InverseFlattening
                    TransverseMercator.GeographicCRS.InverseFlattening = EllipsoidMatch(0).InverseFlattening
                    'Calculate SemiMinorAxis:
                    'TransverseMercator.GeographicCRS.SemiMinorAxis = DatumMatch(0).Ellipsoid.SemiMajorAxis - (DatumMatch(0).Ellipsoid.SemiMajorAxis / DatumMatch(0).Ellipsoid.InverseFlattening)
                    TransverseMercator.GeographicCRS.SemiMinorAxis = EllipsoidMatch(0).SemiMajorAxis - (EllipsoidMatch(0).SemiMajorAxis / EllipsoidMatch(0).InverseFlattening)
                    Message.Add("Calculated Semi Minor Axis: " & TransverseMercator.GeographicCRS.SemiMinorAxis & vbCrLf)
                    'ElseIf DatumMatch(0).Ellipsoid.EllipsoidParameters = ADVL_Coordinates_Library.Coordinates.Ellipsoid.DefiningParameters.SemiMajorAxis_SemiMinorAxis Then
                ElseIf EllipsoidMatch(0).EllipsoidParameters = ADVL_Coordinates_Library_1.Ellipsoid.DefiningParameters.SemiMajorAxis_SemiMinorAxis Then
                    'TransverseMercator.GeographicCRS.SemiMajorAxis = DatumMatch(0).Ellipsoid.SemiMajorAxis
                    TransverseMercator.GeographicCRS.SemiMajorAxis = EllipsoidMatch(0).SemiMajorAxis
                    'TransverseMercator.GeographicCRS.SemiMinorAxis = DatumMatch(0).Ellipsoid.SemiMinorAxis
                    TransverseMercator.GeographicCRS.SemiMinorAxis = EllipsoidMatch(0).SemiMinorAxis
                    'Calculate InverseFlattening:
                    'TransverseMercator.GeographicCRS.InverseFlattening = DatumMatch(0).Ellipsoid.SemiMajorAxis / (DatumMatch(0).Ellipsoid.SemiMajorAxis - DatumMatch(0).Ellipsoid.SemiMinorAxis)
                    TransverseMercator.GeographicCRS.InverseFlattening = EllipsoidMatch(0).SemiMajorAxis / (EllipsoidMatch(0).SemiMajorAxis - EllipsoidMatch(0).SemiMinorAxis)
                    Message.Add("Calculated Inverse Flattening: " & TransverseMercator.GeographicCRS.InverseFlattening & vbCrLf)
                Else
                    Message.Add("Unknown ellipsoid specification: " & vbCrLf)
                    'TransverseMercator.GeographicCRS.SemiMajorAxis = DatumMatch(0).Ellipsoid.SemiMajorAxis
                    TransverseMercator.GeographicCRS.SemiMajorAxis = EllipsoidMatch(0).SemiMajorAxis
                    'TransverseMercator.GeographicCRS.SemiMinorAxis = DatumMatch(0).Ellipsoid.SemiMinorAxis
                    TransverseMercator.GeographicCRS.SemiMinorAxis = EllipsoidMatch(0).SemiMinorAxis
                    'TransverseMercator.GeographicCRS.InverseFlattening = DatumMatch(0).Ellipsoid.InverseFlattening
                    TransverseMercator.GeographicCRS.InverseFlattening = EllipsoidMatch(0).InverseFlattening
                End If
                Message.Add("Base datum found: " & DatumMatch(0).Name & vbCrLf)

                Message.Add("Ellipsoid name: " & DatumMatch(0).Ellipsoid.Name & vbCrLf)
                'Message.Add("Inverse Flattening: " & DatumMatch(0).Ellipsoid.InverseFlattening & vbCrLf)
                Message.Add("Inverse Flattening: " & EllipsoidMatch(0).InverseFlattening & vbCrLf)
                'Message.Add("Semi Major Axis: " & DatumMatch(0).Ellipsoid.SemiMajorAxis & vbCrLf)
                Message.Add("Semi Major Axis: " & EllipsoidMatch(0).SemiMajorAxis & vbCrLf)
                'Message.Add("Semi Minor Axis: " & DatumMatch(0).Ellipsoid.SemiMinorAxis & vbCrLf)
                Message.Add("Semi Minor Axis: " & EllipsoidMatch(0).SemiMinorAxis & vbCrLf)
            Else
                'No Ellipsoid match
                Message.Add("No matching Ellipsoid found for Ellipsoid.Author = " & DatumMatch(0).Ellipsoid.Author & " and Ellipsoid.Code =  " & DatumMatch(0).Ellipsoid.Code & vbCrLf)
                Message.Add("Number of entries in the Ellipsoid List is: " & Ellipsoid.List.Count & vbCrLf)
            End If
        Else
            'No Datum match
            Message.Add("No matching datum found for Datum.Author = " & Author & " and Datum.Code =  " & Code & vbCrLf)
            Message.Add("Number of entries in the Geodetic Datum List is: " & GeodeticDatum.List.Count & vbCrLf)
        End If


    End Sub

    Private Sub GetProjectedCrsListForClient()
        'Get the projected CRS list and sent it to the client.

        'If ProjectedCRSListInfo.FilePath = "" Then
        '    Message.Add("No projected CRS list file is specified!" & vbCrLf)
        'Else
        '    OpenProjectedCRSListFile()
        'End If

        ProjectedCRS.AddUser()

        'Create the XMsg instructions to return the list:
        Dim decl As New XDeclaration("1.0", "utf-8", "yes")
        Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.

        Dim xmessage As New XElement("XMsg")

        Dim list As New XElement("ProjectedCrsList")

        Dim I As Integer
        Dim NRecords As Integer
        NRecords = ProjectedCRS.List.Count
        Message.Add("Number of Projected CRS's: " & NRecords & vbCrLf)

        For I = 0 To NRecords - 1
            Dim crsName As New XElement("ProjectedCrsName", ProjectedCRS.List(I).Name)
            list.Add(crsName)
        Next

        xmessage.Add(list)

        doc.Add(xmessage)

        MessageText = doc.ToString

    End Sub

    Private Sub EastingNorthingToLatLong()

        Dim Decl As New XDeclaration("1.0", "utf-8", "yes")
        Dim doc As New XDocument(Decl, Nothing) 'Create an XDocument to store the instructions.
        Dim process As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
        Dim operation As New XElement("TransformedCoordinates")

        Select Case ProjectedCrsInfo.Projection.Type
            Case ProjectionInfo.ProjectionTypes.Albers_Equal_Area
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.American_Polyconic
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Bonne_South_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Cassini_Soldner
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Colombia_Urban
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Equidistant_Cylindrical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Equidistant_Cylindrical_Spherical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Guam_Projection
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Hotine_Oblique_Mercator_Variant_A
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Hotine_Oblique_Mercator_Variant_B
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Hyperbolic_Cassini_Soldner
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak_Modified
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak_Modified_North_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak_North_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Azimuthal_Equal_Area
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Azimuthal_Equal_Area_Spherical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_1SP
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP_Belgium
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP_Michigan
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_West_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Near_Conformal
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Cylindrical_Equal_Area_Spherical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Mercator_Variant_A
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Mercator_Variant_B
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Modified_Azimuthal_Equidistant
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.New_Zealand_Map_Grid
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Oblique_Stereographic
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_A
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_B
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_C
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Popular_Visualization_Pseudo_Mercator
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Transverse_Mercator
                If IsNothing(TransverseMercator) Then
                    Message.Add("Transverse Mercator settings have not been loaded!" & vbCrLf)
                Else
                    TransverseMercator.EastNorthToLatLon() 'Convert Easting and Northing to Latitude and Longitude
                    Dim outputLatitude As New XElement("OutputLatitude", TransverseMercator.Location.Latitude)
                    operation.Add(outputLatitude)
                    Dim outputLongitude As New XElement("OutputLongitude", TransverseMercator.Location.Longitude)
                    operation.Add(outputLongitude)
                End If
            Case ProjectionInfo.ProjectionTypes.Transverse_Mercator_Zoned_Grid_System
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Tunisia_Mining_Grid
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case Else
                Message.Add("Projection type not found: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
        End Select

        process.Add(operation)
        doc.Add(process)
        'doc now contains the instructions to return to the client application.
        MessageText = doc.ToString 'This message is sent after the input message is processed.

    End Sub

    Private Sub LatLongToEastingNorthing()

        Dim Decl As New XDeclaration("1.0", "utf-8", "yes")
        Dim doc As New XDocument(Decl, Nothing) 'Create an XDocument to store the instructions.
        Dim process As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
        Dim operation As New XElement("TransformedCoordinates")

        Select Case ProjectedCrsInfo.Projection.Type
            Case ProjectionInfo.ProjectionTypes.Albers_Equal_Area
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.American_Polyconic
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Bonne_South_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Cassini_Soldner
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Colombia_Urban
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Equidistant_Cylindrical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Equidistant_Cylindrical_Spherical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Guam_Projection
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Hotine_Oblique_Mercator_Variant_A
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Hotine_Oblique_Mercator_Variant_B
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Hyperbolic_Cassini_Soldner
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak_Modified
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak_Modified_North_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak_North_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Azimuthal_Equal_Area
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Azimuthal_Equal_Area_Spherical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_1SP
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP_Belgium
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP_Michigan
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_West_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Near_Conformal
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Cylindrical_Equal_Area_Spherical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Mercator_Variant_A
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Mercator_Variant_B
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Modified_Azimuthal_Equidistant
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.New_Zealand_Map_Grid
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Oblique_Stereographic
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_A
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_B
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_C
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Popular_Visualization_Pseudo_Mercator
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Transverse_Mercator
                If IsNothing(TransverseMercator) Then
                    Message.Add("Transverse Mercator settings have not been loaded!" & vbCrLf)
                Else
                    TransverseMercator.Location.Latitude = ProjectedCrsInfo.InputLatitude.DecimalDegrees
                    TransverseMercator.Location.Longitude = ProjectedCrsInfo.InputLongitude.DecimalDegrees
                    TransverseMercator.LatLonToEastNorth() 'Convert Latitude and Longitude to Easting and Northing
                    Dim outputEasting As New XElement("OutputEasting", TransverseMercator.Location.Easting)
                    operation.Add(outputEasting)
                    Dim outputNorthing As New XElement("OutputNorthing", TransverseMercator.Location.Northing)
                    operation.Add(outputNorthing)
                End If
            Case ProjectionInfo.ProjectionTypes.Transverse_Mercator_Zoned_Grid_System
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Tunisia_Mining_Grid
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case Else
                Message.Add("Projection type not found: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
        End Select

        process.Add(operation)
        doc.Add(process)
        'doc now contains the instructions to return to the client application.
        MessageText = doc.ToString 'This message is sent after the input message is processed.

    End Sub

    Private Sub SetEasting(ByRef Easting As Double)

        Select Case ProjectedCrsInfo.Projection.Type
            Case ProjectionInfo.ProjectionTypes.Albers_Equal_Area
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.American_Polyconic
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Bonne_South_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Cassini_Soldner
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Colombia_Urban
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Equidistant_Cylindrical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Equidistant_Cylindrical_Spherical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Guam_Projection
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Hotine_Oblique_Mercator_Variant_A
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Hotine_Oblique_Mercator_Variant_B
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Hyperbolic_Cassini_Soldner
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak_Modified
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak_Modified_North_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak_North_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Azimuthal_Equal_Area
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Azimuthal_Equal_Area_Spherical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_1SP
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP_Belgium
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP_Michigan
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_West_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Near_Conformal
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Cylindrical_Equal_Area_Spherical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Mercator_Variant_A
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Mercator_Variant_B
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Modified_Azimuthal_Equidistant
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.New_Zealand_Map_Grid
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Oblique_Stereographic
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_A
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_B
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_C
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Popular_Visualization_Pseudo_Mercator
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Transverse_Mercator
                If IsNothing(TransverseMercator) Then
                    Message.Add("Transverse Mercator settings have not been loaded!" & vbCrLf)
                Else
                    TransverseMercator.Location.Easting = Easting
                End If
            Case ProjectionInfo.ProjectionTypes.Transverse_Mercator_Zoned_Grid_System
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Tunisia_Mining_Grid
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case Else
                Message.Add("Projection type not found: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
        End Select
    End Sub

    Private Sub SetNorthing(ByRef Northing As Double)
        Select Case ProjectedCrsInfo.Projection.Type
            Case ProjectionInfo.ProjectionTypes.Albers_Equal_Area
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.American_Polyconic
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Bonne_South_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Cassini_Soldner
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Colombia_Urban
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Equidistant_Cylindrical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Equidistant_Cylindrical_Spherical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Guam_Projection
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Hotine_Oblique_Mercator_Variant_A
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Hotine_Oblique_Mercator_Variant_B
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Hyperbolic_Cassini_Soldner
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak_Modified
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak_Modified_North_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Krovak_North_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Azimuthal_Equal_Area
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Azimuthal_Equal_Area_Spherical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_1SP
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP_Belgium
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_2SP_Michigan
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Conformal_West_Orientated
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Conic_Near_Conformal
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Lambert_Cylindrical_Equal_Area_Spherical
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Mercator_Variant_A
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Mercator_Variant_B
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Modified_Azimuthal_Equidistant
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.New_Zealand_Map_Grid
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Oblique_Stereographic
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_A
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_B
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Polar_Stereographic_Variant_C
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Popular_Visualization_Pseudo_Mercator
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Transverse_Mercator
                If IsNothing(TransverseMercator) Then
                    Message.Add("Transverse Mercator settings have not been loaded!" & vbCrLf)
                Else
                    TransverseMercator.Location.Northing = Northing
                End If
            Case ProjectionInfo.ProjectionTypes.Transverse_Mercator_Zoned_Grid_System
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case ProjectionInfo.ProjectionTypes.Tunisia_Mining_Grid
                Message.Add("Projection type not yet supported: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
            Case Else
                Message.Add("Projection type not found: " & ProjectedCrsInfo.Projection.Type.ToString & vbCrLf)
        End Select
    End Sub

    'END Process XMessages ------------------------------------------------------------------------------------------------

#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

End Class


'Class used for converting input angles (latitude or longitude) from multiple units into decimal degrees.
Public Class InputAngle
    'Class used for converting input angles (latitude or longitude) from multiple units into decimal degrees.

    'Properties for angle in Degrees-Minutes-Seconds: Sign, Degrees, Minutes and Seconds -----------------------------------------------------------------------------------------------------
    Public Enum Sign
        Positive
        Negative
    End Enum

    Private _dmsSign As Sign = Sign.Positive
    Property DmsSign As Sign
        Get
            Return _dmsSign
        End Get
        Set(value As Sign)
            _dmsSign = value
            If _dmsSign = Sign.Positive Then
                _decimalDegrees = _dmsDegrees + _dmsMinutes / 60 + _dmsSeconds / 3600
            Else
                _decimalDegrees = (_dmsDegrees + _dmsMinutes / 60 + _dmsSeconds / 3600) * -1
            End If
        End Set
    End Property

    Private _dmsDegrees As Integer = 0
    Property DmsDegrees As Integer
        Get
            Return _dmsDegrees
        End Get
        Set(value As Integer)
            _dmsDegrees = value
            If _dmsSign = Sign.Positive Then
                _decimalDegrees = _dmsDegrees + _dmsMinutes / 60 + _dmsSeconds / 3600
            Else
                _decimalDegrees = (_dmsDegrees + _dmsMinutes / 60 + _dmsSeconds / 3600) * -1
            End If
        End Set
    End Property

    Private _dmsMinutes As Integer = 0
    Property DmsMinutes As Integer
        Get
            Return _dmsMinutes
        End Get
        Set(value As Integer)
            _dmsMinutes = value
            If _dmsSign = Sign.Positive Then
                _decimalDegrees = _dmsDegrees + _dmsMinutes / 60 + _dmsSeconds / 3600
            Else
                _decimalDegrees = (_dmsDegrees + _dmsMinutes / 60 + _dmsSeconds / 3600) * -1
            End If
        End Set
    End Property

    Private _dmsSeconds As Double = 0
    Property DmsSeconds As Double
        Get
            Return _dmsSeconds
        End Get
        Set(value As Double)
            _dmsSeconds = value
            If _dmsSign = Sign.Positive Then
                _decimalDegrees = _dmsDegrees + _dmsMinutes / 60 + _dmsSeconds / 3600
            Else
                _decimalDegrees = (_dmsDegrees + _dmsMinutes / 60 + _dmsSeconds / 3600) * -1
            End If
        End Set
    End Property


    Private _sexagesimalDegrees As Double
    Property SexagesimalDegrees As Double
        Get
            Return _sexagesimalDegrees
        End Get
        Set(value As Double)
            _sexagesimalDegrees = value
            Dim SexagesimalStr As String = Format(_sexagesimalDegrees, "##0.0000##############")
            Dim DecimalPointPos As Integer = SexagesimalStr.IndexOf(".") 'The (zero based) character position of the decimal point
            Dim Minutes As Integer = SexagesimalStr.Substring(DecimalPointPos + 1, 2) 'Selects the two characters past the decimal point
            Dim Seconds As Double = SexagesimalStr.Substring(DecimalPointPos + 3, SexagesimalStr.Length - DecimalPointPos - 3)
            If SexagesimalStr.StartsWith("-") Then
                _decimalDegrees = (SexagesimalStr.Substring(1, DecimalPointPos - 1) + Minutes / 60 + Seconds / 3600) * -1
            ElseIf SexagesimalStr.StartsWith("+") Then
                _decimalDegrees = SexagesimalStr.Substring(1, DecimalPointPos - 1) + Minutes / 60 + Seconds / 3600
            Else
                _decimalDegrees = SexagesimalStr.Substring(0, DecimalPointPos) + Minutes / 60 + Seconds / 3600
            End If
        End Set
    End Property

    Private _gradians As Double
    Property Gradians As Double
        Get
            Return _gradians
        End Get
        Set(value As Double)
            _gradians = value
            _decimalDegrees = _gradians * 360 / 400
        End Set
    End Property

    Private _radians As Double
    Property Radians As Double
        Get
            Return _radians
        End Get
        Set(value As Double)
            _radians = value
            _decimalDegrees = _radians * 360 / 2 / System.Math.PI
        End Set
    End Property

    Private _turns As Double
    Property Turns As Double
        Get
            Return _turns
        End Get
        Set(value As Double)
            _turns = value
            _decimalDegrees = _turns * 360
        End Set
    End Property

    Private _decimalDegrees As Double = Double.NaN
    Property DecimalDegrees As Double
        Get
            Return _decimalDegrees
        End Get
        Set(value As Double)
            _decimalDegrees = value
        End Set
    End Property

End Class

'Class used for converting input distance values (easting or northing) from various units into the values in other units.
Public Class DistanceConvert
    'Example of usage:
    'InputUnit = "metre"
    'OutputUnit = "foot"
    'InputValue = 1
    'If ValidConversionFactor = True then values will be converted between Input and Output units.
    'OutputValue is automatically set to the value in Output units.
    'If ValidConversionFactor = False then InputUnit or OutputUnit has not been specified or a specified unit was not found in the dictDistanceUnits dictionary.

    'A distance value in units specified by _inputUnits
    Private _inputValue As Double = 0
    Property InputValue As Double
        Get
            Return _inputValue
        End Get
        Set(value As Double)
            _inputValue = value
            If _validConversionFactor = True Then
                _outputValue = _inputValue * _conversionFactor
            End If
        End Set
    End Property

    Private _inputUnit As String = "metre"
    Property InputUnit As String
        Get
            Return _inputUnit
        End Get
        Set(value As String)
            _inputUnit = value
            If Main.dictDistanceUnits.ContainsKey(_inputUnit) Then
                _validInputUnit = True
                If _validOutputUnit = True Then
                    _conversionFactor = Main.dictDistanceUnits(_inputUnit).FactorB / Main.dictDistanceUnits(_inputUnit).FactorC * Main.dictDistanceUnits(_outputUnit).FactorC / Main.dictDistanceUnits(_outputUnit).FactorB
                    _validConversionFactor = True
                    'To convert InputValue to value in metres: MetreValue = InputValue * InputFactorB / InputFactorC
                    'To convert value in metres to OutputValue: OutputValue = MetreValue / OutputFactorB * OutputFactorC
                    'To convert InputValue to OutputValue: OutputValue = InputValue * InputFactorB / InputFactorC /OutputFactorB * OutputFactorC
                    'ConversionFactor = InputFactorB / InputFactorC /OutputFactorB * OutputFactorC
                    'OutputValue = InputValue * ConversionFactor
                End If
            Else
                _validInputUnit = False
                _validConversionFactor = False
            End If
        End Set
    End Property

    'If _inputUnit is found in the dictionary of distance units then _validInputUnit = True
    Private _validInputUnit As Boolean = False
    ReadOnly Property ValidInputUnit As Boolean
        Get
            Return _validInputUnit
        End Get

    End Property

    'A distance value in units specified by _outputUnit
    Private _outputValue As Double = 0
    Property OutputValue As Double
        Get
            Return _outputValue
        End Get
        Set(value As Double)
            _outputValue = value
            If _validConversionFactor = True Then
                _inputValue = _outputValue / _conversionFactor
            End If
        End Set
    End Property

    Private _outputUnit As String = "metre"
    Property OutputUnit As String
        Get
            Return _outputUnit
        End Get
        Set(value As String)
            _outputUnit = value
            If Main.dictDistanceUnits.ContainsKey(_outputUnit) Then
                _validOutputUnit = True
                If _validInputUnit = True Then
                    _conversionFactor = Main.dictDistanceUnits(_inputUnit).FactorB / Main.dictDistanceUnits(_inputUnit).FactorC * Main.dictDistanceUnits(_outputUnit).FactorC / Main.dictDistanceUnits(_outputUnit).FactorB
                    _validConversionFactor = True
                    'To convert InputValue to value in metres: MetreValue = InputValue * InputFactorB / InputFactorC
                    'To convert value in metres to OutputValue: OutputValue = MetreValue / OutputFactorB * OutputFactorC
                    'To convert InputValue to OutputValue: OutputValue = InputValue * InputFactorB / InputFactorC /OutputFactorB * OutputFactorC
                    'ConversionFactor = InputFactorB / InputFactorC /OutputFactorB * OutputFactorC
                    'OutputValue = InputValue * ConversionFactor
                End If
            Else
                _validOutputUnit = False
                _validConversionFactor = False
            End If
        End Set
    End Property

    'If _inputUnit is found in the dictionary of distance units then _validInputUnit = True
    Private _validOutputUnit As Boolean = False
    ReadOnly Property ValidOutputUnit As Boolean
        Get
            Return _validOutputUnit
        End Get

    End Property

    'Conversion factor used to convert distance value in Input units to distance value in Output units:
    'OutputValue = InputValue * ConversionFactor
    'InputValue = OutputValue / ConversionFactor
    Private _conversionFactor As Double = 0
    ReadOnly Property ConversionFactor As Double
        Get
            Return _conversionFactor
        End Get
    End Property

    'If True, the conversion factor is valid.
    Private _validConversionFactor As Boolean
    ReadOnly Property ValidConversionFactor As Boolean
        Get
            Return _validConversionFactor
        End Get
    End Property

End Class

'Conversion factors: FactorB and FactorC. (Used to covert between values measured in different EPSG units.)
Public Class ConversionFactors
    'Conversion factors: FactorB and FactorC.
    'The factors are used to convert from a distance value in a unit into the corresponding value in standard (metre) units.
    'The standard distance unit is metre.
    'Value in metres is input value * FactorB / FactorC

    Private _factorB As Double
    Property FactorB As Double
        Get
            Return _factorB
        End Get
        Set(value As Double)
            _factorB = value
        End Set
    End Property

    Private _factorC As Double
    Property FactorC As Double
        Get
            Return _factorC
        End Get
        Set(value As Double)
            _factorC = value
        End Set
    End Property

End Class

'Stores information about a projection.
Public Class ProjectionInfo
    'Stores information about a projection.

    Public Enum ProjectionTypes
        Albers_Equal_Area                        'Albers Equal Area
        American_Polyconic                       'American Polyconic
        Bonne_South_Orientated                   'Bonne (South Oriented)
        Cassini_Soldner                          'Cassini-Soldner
        Colombia_Urban                           'Colombia Urban
        Equidistant_Cylindrical                  'Equidistant Cylindrical
        Equidistant_Cylindrical_Spherical        'Equidistant Cylindrical (Spherical)
        Guam_Projection                          'Guam Projection
        Hotine_Oblique_Mercator_Variant_A        'Hotine Oblique Mercator (variant A)
        Hotine_Oblique_Mercator_Variant_B        'Hotine Oblique Mercator (variant B)
        Hyperbolic_Cassini_Soldner               'Hyperbolic Cassini-Soldner
        Krovak                                   'Krovak
        Krovak_North_Orientated                  'Krovak (North Orientated)
        Krovak_Modified                          'Krovak Modified
        Krovak_Modified_North_Orientated         'Krovak Modified (North Orientated)
        Lambert_Azimuthal_Equal_Area             'Lambert Azimuthal Equal Area
        Lambert_Azimuthal_Equal_Area_Spherical   'Lambert Azimuthal Equal Area (Spherical)
        Lambert_Conic_Conformal_1SP              'Lambert Conic Conformal (1SP)
        Lambert_Conic_Conformal_2SP              'Lambert Conic Conformal (2SP)
        Lambert_Conic_Conformal_2SP_Belgium      'Lambert Conic Conformal (2SP Belgium)
        Lambert_Conic_Conformal_2SP_Michigan     'Lambert Conic Conformal (2SP Michigan)
        Lambert_Conic_Conformal_West_Orientated  'Lambert Conic Conformal (West Orientated)
        Lambert_Conic_Near_Conformal             'Lambert Conic Near-Conformal
        Lambert_Cylindrical_Equal_Area_Spherical 'Lambert Cylindrical Equal Area (Spherical)
        Mercator_Variant_A                       'Mercator (variant A)
        Mercator_Variant_B                       'Mercator (variant B)
        Modified_Azimuthal_Equidistant           'Modified Azimuthal Equidistant
        New_Zealand_Map_Grid                     'New Zealand Map Grid
        Oblique_Stereographic                    'Oblique Stereographic
        Polar_Stereographic_Variant_A            'Polar Stereographic (variant A)
        Polar_Stereographic_Variant_B            'Polar Stereographic (variant B)
        Polar_Stereographic_Variant_C            'Polar Stereographic (variant C)
        Popular_Visualization_Pseudo_Mercator    'Popular Visualisation Pseudo Mercator
        Transverse_Mercator                      'Transverse Mercator
        Transverse_Mercator_Zoned_Grid_System    'Transverse Mercator Zoned Grid System
        Tunisia_Mining_Grid                      'Tunisia Mining Grid
    End Enum 'List of 36 projection types

    Private _name As String
    Property Name As String 'The name of the projection.
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Private _type As ProjectionTypes = ProjectionTypes.Transverse_Mercator
    Property Type As ProjectionTypes 'The type of the projection.
        Get
            Return _type
        End Get
        Set(value As ProjectionTypes)
            _type = value
        End Set
    End Property

    Private _author As String = ""
    Property Author As String 'The author of the projection.
        Get
            Return _author
        End Get
        Set(value As String)
            _author = value
        End Set
    End Property 'The author of the projection.

    Private _code As Integer = 0
    Property Code As Integer 'The code assigned to the projection by the author.
        Get
            Return _code
        End Get
        Set(value As Integer)
            _code = value
        End Set
    End Property 'The code assigned to the projection by the author. 

End Class

'Class used for storing projected coordinate reference system information.
Public Class ProjectedCrsInfo
    'Class used for storing projection information.
    'Class used for storing projected coordinate reference system information.

    Public InputLatitude As New InputAngle 'Accepts longitude in several units. Automatically calculates longitude in decimal degrees.
    Public InputLongitude As New InputAngle 'Accepts latitude in several units. Automatically calculates latitude in decimal degrees.

    Public InputEasting As New DistanceConvert 'Accepts input easting value with specified units. Calculates value in default units for the selected projection.
    Public InputNorthing As New DistanceConvert 'Accepts input northing value with specified units. Calculates value in default units for the selected projection.

    Public OutputEasting As New DistanceConvert 'Accepts output easting value with specified units. Calculates the value in the units required for the output coordinates.
    Public OutputNorthing As New DistanceConvert 'Accepts output northing value with specified units. Calculates the value in the units required for the output coordinates.

    Public Projection As New ProjectionInfo 'Stores information about the projection associated with the projected CRS

    Private Sub Test()
        'The subroutine demonstrates the use of class clsDistanceConvert to convert a distance value in metres to a distance value in feet.
        InputEasting.InputUnit = "metre"
        InputEasting.OutputUnit = "foot"
        InputEasting.InputValue = 1
        Dim EastingInFeet As Double
        EastingInFeet = InputEasting.OutputValue
    End Sub

    Private _name As String = ""
    Property Name As String 'The name of the projection. (Not the same as the name of the projection method.)
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property 'The name of the projection. (Not the same as the name of the projection method.)

    Private _author As String = ""
    Property Author As String 'The author of the projection.
        Get
            Return _author
        End Get
        Set(value As String)
            _author = value
        End Set
    End Property 'The author of the projection. CORRECTION: The author of the projected CRS

    Private _code As Integer = 0
    Property Code As Integer 'The code assigned to the projection by the author.
        Get
            Return _code
        End Get
        Set(value As Integer)
            _code = value
        End Set
    End Property 'The code assigned to the projection by the author. CORRECTION: The code assigned to the projected CRS

    Private _sourceGeogCrsType As String = ""
    Property SourceGeogCrsType As String
        Get
            Return _sourceGeogCrsType
        End Get
        Set(value As String)
            _sourceGeogCrsType = value
        End Set
    End Property

    Private _sourceGeogCrsAuthor As String = ""
    Property SourceGeogCrsAuthor As String
        Get
            Return _sourceGeogCrsAuthor
        End Get
        Set(value As String)
            _sourceGeogCrsAuthor = value
        End Set
    End Property

    Private _sourceGeogCrsCode As Integer = 0
    Property SourceGeogCrsCode As Integer
        Get
            Return _sourceGeogCrsCode
        End Get
        Set(value As Integer)
            _sourceGeogCrsCode = value
        End Set
    End Property

    Private _parametersLoaded As Boolean = False
    Property ParametersLoaded As Boolean 'True if projection parameters have been loaded OK.
        Get
            Return _parametersLoaded
        End Get
        Set(value As Boolean)
            _parametersLoaded = value
        End Set
    End Property 'True if projection parameters have been loaded OK.

    Public Enum CoordsType
        Geographic
        Projected
    End Enum

    Private _inputCoordsType As CoordsType = CoordsType.Geographic
    Property InputCoordinatesType As CoordsType 'The type of input coordinates (Geographic or Projected).
        Get
            Return _inputCoordsType
        End Get
        Set(value As CoordsType)
            _inputCoordsType = value
        End Set
    End Property 'The type of input coordinates (Geographic or Projected).

    Private _outputCoordinatesType As CoordsType = CoordsType.Projected
    Property OutputCoordinatesType As CoordsType 'The type of output coordinates (Geographic or Projected).
        Get
            Return _outputCoordinatesType
        End Get
        Set(value As CoordsType)
            _outputCoordinatesType = value
        End Set
    End Property 'The type of output coordinates (Geographic or Projected).

End Class
