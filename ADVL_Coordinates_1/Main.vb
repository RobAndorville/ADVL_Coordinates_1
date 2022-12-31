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

Imports System.ComponentModel
Imports System.Security.Permissions
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
<System.Runtime.InteropServices.ComVisibleAttribute(True)>
Public Class Main
    'The ADVL_Coordinates_1 application is used to store geographic and projected coordinate parameters and convert between coordinate systems.


#Region " Coding Notes - Notes on the code used in this class." '==============================================================================================================================

    'ADD THE SYSTEM UTILITIES REFERENCE: ==========================================================================================
    'The following references are required by this software: 
    'ADVL_Utilities_Library_1.dll
    'To add the reference, press Project \ Add Reference... 
    '  Select the Browse option then press the Browse button
    '  Find the ADVL_Utilities_Library_1.dll file (it should be located in the directory ...\Projects\ADVL_Utilities_Library_1\ADVL_Utilities_Library_1\bin\Debug\)
    '  Press the Add button. Press the OK button.
    'The Utilities Library is used for Project Management, Archive file management, running XSequence files and running XMessage files.
    'If there are problems with a reference, try deleting it from the references list and adding it again.

    'ADD THE SERVICE REFERENCE: ===================================================================================================
    'A service reference to the Message Service must be added to the source code before this service can be used.
    'This is used to connect to the Application Network.

    'Adding the service reference to a project that includes the WcfMsgServiceLib project: -----------------------------------------
    'Project \ Add Service Reference
    'Press the Discover button.
    'Expand the items in the Services window and select IMsgService.
    'Press OK.
    '------------------------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------------------------
    'Adding the service reference to other projects that dont include the WcfMsgServiceLib project: -------------------------------
    'Run the ADVL_Application_Network_1 application to start the Application Network message service.
    'In Microsoft Visual Studio select: Project \ Add Service Reference
    'Enter the address: http://localhost:8734/ADVLService
    'Press the Go button.
    'MsgService is found.
    'Press OK to add ServiceReference1 to the project.
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'ADD THE MsgServiceCallback CODE: =============================================================================================
    'This is used to connect to the Application Network.
    'In Microsoft Visual Studio select: Project \ Add Class
    'MsgServiceCallback.vb
    'Add the following code to the class:
    'Imports System.ServiceModel
    'Public Class MsgServiceCallback
    '    Implements ServiceReference1.IMsgServiceCallback
    '    Public Sub OnSendMessage(message As String) Implements ServiceReference1.IMsgServiceCallback.OnSendMessage
    '        'A message has been received.
    '        'Set the InstrReceived property value to the message (usually in XMessage format). This will also apply the instructions in the XMessage.
    '        Main.InstrReceived = message
    '    End Sub
    'End Class
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'DEBUGGING TIPS:
    '1. If an application based on the Application Template does not initially run correctly,
    '    check that the copied methods, such as Main_Load, have the correct Handles statement.
    '    For example: the Main_Load method should have the following declaration: Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
    '      It will not run when the application loads, with this declaration:      Private Sub Main_Load(sender As Object, e As EventArgs)
    '    For example: the Main_FormClosing method should have the following declaration: Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '      It will not run when the application closes, with this declaration:     Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs)
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'ADD THE Timer1 Control to the Main Form: =====================================================================================
    'Select the Main.vb [Design] tab.
    'Press Toolbox \ Compnents \ Times and add Timer1 to the Main form.
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'EDIT THE DefaultAppProperties() CODE: ========================================================================================
    'This sets the Application properties that are stored in the Application_Info_ADVL_2.xml settings file.
    'The following properties need to be updated:
    '  ApplicationInfo.Name
    '  ApplicationInfo.Description
    '  ApplicationInfo.CreationDate
    '  ApplicationInfo.Author
    '  ApplicationInfo.Copyright
    '  ApplicationInfo.Trademarks
    '  ApplicationInfo.License
    '  ApplicationInfo.SourceCode          (Optional - Preliminary implemetation coded.)
    '  ApplicationInfo.ModificationSummary (Optional - Preliminary implemetation coded.)
    '  ApplicationInfo.Libraries           (Optional - Preliminary implemetation coded.)
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'ADD THE Application Icon: ====================================================================================================
    'Double-click My Project in the Solution Explorer window to open the project tab.
    'In the Application section press the Icon box and selct Browse.
    'Select an application icon.
    'This icon can also be selected for the Main form icon by editing the properties of this form.
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'EDIT THE Application Info Text: ==============================================================================================
    'The Application Info Text is used to label the appllication icon in the Application Network tree view.
    'This is edited in the SendApplicationInfo() method of the Main form.
    'Edit the line of code: Dim text As New XElement("Text", "Application Template").
    'Replace the default text "Application Template" with the required text.
    'Note that this text can be updated at any time and when the updated executable is run, it will update the Application Network tree view the next time it is connected.
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'Calling JavaScript from VB.NET:
    'The following Imports statement and permissions are required for the Main form:
    'Imports System.Security.Permissions
    '<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    '<System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    'NOTE: the line continuation characters (_) will disappear form the code view after they have been typed!
    '------------------------------------------------------------------------------------------------------------------------------
    'Calling VB.NET from JavaScript
    'Add the following line to the Main.Load method:
    '  Me.WebBrowser1.ObjectForScripting = Me
    '------------------------------------------------------------------------------------------------------------------------------


#End Region 'Coding Notes ---------------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Variable Declarations - All the variables and class objects used in this form and this application." '===============================================================================

    Public WithEvents ApplicationInfo As New ADVL_Utilities_Library_1.ApplicationInfo 'This object is used to store application information.
    Public WithEvents Project As New ADVL_Utilities_Library_1.Project 'This object is used to store Project information.
    Public WithEvents Message As New ADVL_Utilities_Library_1.Message 'This object is used to display messages in the Messages window.
    Public WithEvents ApplicationUsage As New ADVL_Utilities_Library_1.Usage 'This object stores application usage information.

    'Forms used by this application:
    Public WithEvents EpsgDatabaseForm As frmEpsgDatabase
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

    Public WithEvents WebPageList As frmWebPageList
    Public WithEvents ProjectArchive As frmArchive 'Form used to view the files in a Project archive
    Public WithEvents SettingsArchive As frmArchive 'Form used to view the files in a Settings archive
    Public WithEvents DataArchive As frmArchive 'Form used to view the files in a Data archive
    Public WithEvents SystemArchive As frmArchive 'Form used to view the files in a System archive

    Public WithEvents NewHtmlDisplay As frmHtmlDisplay
    Public HtmlDisplayFormList As New ArrayList 'Used for displaying multiple HtmlDisplay forms.

    Public WithEvents NewWebPage As frmWebPage
    Public WebPageFormList As New ArrayList 'Used for displaying multiple WebView forms.


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

    'Declare objects used to connect to the Message Service:
    Public client As ServiceReference1.MsgServiceClient
    Public WithEvents XMsg As New ADVL_Utilities_Library_1.XMessage
    Dim XDoc As New System.Xml.XmlDocument
    Public Status As New System.Collections.Specialized.StringCollection
    Dim ClientProNetName As String = "" 'The name of the client Project Network requesting service. 
    Dim ClientAppName As String = "" 'The name of the client requesting service
    Dim ClientConnName As String = "" 'The name of the client connection requesting service
    Dim MessageXDoc As System.Xml.Linq.XDocument
    Dim xmessage As XElement
    Dim xlocns As New List(Of XElement) 'A list of locations. Each location forms part of the reply message. The information in the reply message will be sent to the specified location in the client application.
    Dim MessageText As String 'The text of a message sent through the Application Network

    'Dim CompletionInstruction As String = "Stop" 'The last instruction returned on completion of the processing of an XMessage.
    Public OnCompletionInstruction As String = "Stop" 'The last instruction returned in <EndInstruction> on completion of the processing of an XMessage.
    Public EndInstruction As String = "Stop" 'Another method of specifying the last instruction. This is processed in the EndOfSequence section of XMsg.Instructions.


    Public ConnectionName As String = "" 'The name of the connection used to connect this application to the AppNet.

    Public ProNetName As String = "" 'The name of the Project Network
    Public ProNetPath As String = "" 'The path of the Project Network

    Public AdvlNetworkAppPath As String = "" 'The application path of the ADVL Network application (ComNet). This is where the "Application.Lock" file will be while ComNet is running
    Public AdvlNetworkExePath As String = "" 'The executable path of the ADVL Network.

    'Variable for local processing of an XMessage:
    Public WithEvents XMsgLocal As New ADVL_Utilities_Library_1.XMessage
    Dim XDocLocal As New System.Xml.XmlDocument
    Public StatusLocal As New System.Collections.Specialized.StringCollection

    'Variables used for angle conversions:
    Dim angleConvert As New ADVL_Coordinates_Library_1.AngleConvert 'TDS_Utilities.Coordinates.clsAngleConvert
    Dim angleDegMinSec As New ADVL_Coordinates_Library_1.AngleDegMinSec 'TDS_Utilities.Coordinates.clsAngleDegMinSec
    Dim ProjectedCrsInfo As New ProjectedCrsInfo 'Stores information about the selected projected CRS.
    Dim TransverseMercator As ADVL_Coordinates_Library_1.TransverseMercator

    Public dictDistanceUnits As New Dictionary(Of String, ConversionFactors)

    Dim GetCRSListInfo As New clsGetCRSListInfo 'Settings used to get a list of coordinate reference systems

    'Main.Load variables:
    Dim ProjectSelected As Boolean = False 'If True, a project has been selected using Command Arguments. Used in Main.Load.
    Dim StartupConnectionName As String = "" 'If not "" the application will be connected to the AppNet using this connection name in  Main.Load.

    'The following variables are used to run JavaScript in Web Pages loaded into the Document View: -------------------
    Public WithEvents XSeq As New ADVL_Utilities_Library_1.XSequence
    'To run an XSequence:
    '  XSeq.RunXSequence(xDoc, Status) 'ImportStatus in Import
    '    Handle events:
    '      XSeq.ErrorMsg
    '      XSeq.Instruction(Info, Locn)

    Private XStatus As New System.Collections.Specialized.StringCollection

    'Variables used to restore Item values on a web page.
    Private FormName As String
    Private ItemName As String
    Private SelectId As String

    'StartProject variables:
    Private StartProject_AppName As String  'The application name
    Private StartProject_ConnName As String 'The connection name
    Private StartProject_ProjID As String   'The project ID

    Private WithEvents bgwComCheck As New System.ComponentModel.BackgroundWorker 'Used to perform communication checks on a separate thread.

    Public WithEvents bgwSendMessage As New System.ComponentModel.BackgroundWorker 'Used to send a message through the Message Service.
    Dim SendMessageParams As New clsSendMessageParams 'This hold the Send Message parameters: .ProjectNetworkName, .ConnectionName & .Message

    'Alternative SendMessage background worker - needed to send a message while instructions are being processed.
    Public WithEvents bgwSendMessageAlt As New System.ComponentModel.BackgroundWorker 'Used to send a message through the Message Service - alternative backgound worker.
    Dim SendMessageParamsAlt As New clsSendMessageParams 'This hold the Send Message parameters: .ProjectNetworkName, .ConnectionName & .Message - for the alternative background worker.

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

    'True if the application is connected to the Application Network.
    Private _connectedToComNet As Boolean = False  'True if the application is connected to the Communication Network (Message Service).
    Property ConnectedToComNet As Boolean
        Get
            Return _connectedToComNet
        End Get
        Set(value As Boolean)
            _connectedToComNet = value
        End Set
    End Property

    Private _instrReceived As String = "" 'Contains Instructions received from the message service.

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Property InstrReceived As String
        Get
            Return _instrReceived
        End Get
        Set(value As String)
            If value = Nothing Then
                Message.Add("Empty message received!")
            Else
                _instrReceived = value
                ProcessInstructions(_instrReceived)
            End If
        End Set
    End Property

    Private Sub ProcessInstructions(ByVal Instructions As String)
        'Process the XMessage instructions.

        Dim MsgType As String
        If Instructions.StartsWith("<XMsg>") Then
            MsgType = "XMsg"
            If ShowXMessages Then
                'Add the message header to the XMessages window:
                Message.XAddText("Message received: " & vbCrLf, "XmlReceivedNotice")
            End If
        ElseIf Instructions.StartsWith("<XSys>") Then
            MsgType = "XSys"
            If ShowSysMessages Then
                'Add the message header to the XMessages window:
                Message.XAddText("System Message received: " & vbCrLf, "XmlReceivedNotice")
            End If
        Else
            MsgType = "Unknown"
        End If

        'If ShowXMessages Then
        '    'Add the message header to the XMessages window:
        '    Message.XAddText("Message received: " & vbCrLf, "XmlReceivedNotice")
        'End If

        'If Instructions.StartsWith("<XMsg>") Then 'This is an XMessage set of instructions.
        If MsgType = "XMsg" Or MsgType = "XSys" Then 'This is an XMessage or XSystem set of instructions.
            Try
                'Inititalise the reply message:
                ClientProNetName = ""
                ClientConnName = ""
                ClientAppName = ""
                xlocns.Clear() 'Clear the list of locations in the reply message. 
                Dim Decl As New XDeclaration("1.0", "utf-8", "yes")
                MessageXDoc = New XDocument(Decl, Nothing) 'Reply message - this will be sent to the Client App.
                'xmessage = New XElement("XMsg")
                xmessage = New XElement(MsgType)
                xlocns.Add(New XElement("Main")) 'Initially set the location in the Client App to Main.

                'Run the received message:
                Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
                XDoc.LoadXml(XmlHeader & vbCrLf & Instructions)
                'If ShowXMessages Then
                '    Message.XAddXml(XDoc)   'Add the message to the XMessages window.
                '    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                'End If
                If (MsgType = "XMsg") And ShowXMessages Then
                    Message.XAddXml(XDoc)  'Add the message to the XMessages window.
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                ElseIf (MsgType = "XSys") And ShowSysMessages Then
                    Message.XAddXml(XDoc)  'Add the message to the XMessages window.
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                End If
                XMsg.Run(XDoc, Status)
            Catch ex As Exception
                Message.Add("Error running XMsg: " & ex.Message & vbCrLf)
            End Try

            'XMessage has been run.
            'Reply to this message:
            'Add the message reply to the XMessages window:
            'Complete the MessageXDoc:
            xmessage.Add(xlocns(xlocns.Count - 1)) 'Add the last location reply instructions to the message.
            MessageXDoc.Add(xmessage)
            MessageText = MessageXDoc.ToString

            If ClientConnName = "" Then
                'No client to send a message to - process the message locally.
                'If ShowXMessages Then
                '    Message.XAddText("Message processed locally:" & vbCrLf, "XmlSentNotice")
                '    Message.XAddXml(MessageText)
                '    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                'End If
                If (MsgType = "XMsg") And ShowXMessages Then
                    Message.XAddText("Message processed locally:" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(MessageText)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                ElseIf (MsgType = "XSys") And ShowSysMessages Then
                    Message.XAddText("System Message processed locally:" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(MessageText)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                End If
                ProcessLocalInstructions(MessageText)
            Else
                'If ShowXMessages Then
                '    Message.XAddText("Message sent to [" & ClientProNetName & "]." & ClientConnName & ":" & vbCrLf, "XmlSentNotice")
                '    Message.XAddXml(MessageText)
                '    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                'End If
                If (MsgType = "XMsg") And ShowXMessages Then
                    Message.XAddText("Message sent to [" & ClientProNetName & "]." & ClientConnName & ":" & vbCrLf, "XmlSentNotice")   'NOTE: There is no SendMessage code in the Message Service application!
                    Message.XAddXml(MessageText)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                ElseIf (MsgType = "XSys") And ShowSysMessages Then
                    Message.XAddText("System Message sent to [" & ClientProNetName & "]." & ClientConnName & ":" & vbCrLf, "XmlSentNotice")   'NOTE: There is no SendMessage code in the Message Service application!
                    Message.XAddXml(MessageText)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                End If

                'Send Message on a new thread:
                SendMessageParams.ProjectNetworkName = ClientProNetName
                SendMessageParams.ConnectionName = ClientConnName
                SendMessageParams.Message = MessageText
                If bgwSendMessage.IsBusy Then
                    Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                Else
                    bgwSendMessage.RunWorkerAsync(SendMessageParams)
                End If
            End If
        Else 'This is not an XMessage!
            If Instructions.StartsWith("<XMsgBlk>") Then 'This is an XMessageBlock.
                'Process the received message:
                Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
                XDoc.LoadXml(XmlHeader & vbCrLf & Instructions.Replace("&", "&amp;")) 'Replace "&" with "&amp:" before loading the XML text.
                If ShowXMessages Then
                    Message.XAddXml(XDoc)   'Add the message to the XMessages window.
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                End If

                'Process the XMessageBlock:
                Dim XMsgBlkLocn As String
                XMsgBlkLocn = XDoc.GetElementsByTagName("ClientLocn")(0).InnerText
                Select Case XMsgBlkLocn
                    Case "TestLocn" 'Replace this with the required location name.
                        Dim XInfo As Xml.XmlNodeList = XDoc.GetElementsByTagName("XInfo") 'Get the XInfo node list
                        Dim InfoXDoc As New Xml.Linq.XDocument 'Create an XDocument to hold the information contained in XInfo 
                        InfoXDoc = XDocument.Parse("<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>" & vbCrLf & XInfo(0).InnerXml) 'Read the information into InfoXDoc
                        'Add processing instructions here - The information in the InfoXDoc is usually stored in an XDocument in the application or as an XML file in the project.

                    Case Else
                        Message.AddWarning("Unknown XInfo Message location: " & XMsgBlkLocn & vbCrLf)
                End Select
            Else
                Message.XAddText("The message is not an XMessage or XMessageBlock: " & vbCrLf & Instructions & vbCrLf & vbCrLf, "Normal")
            End If
            'Message.XAddText("The message is not an XMessage: " & _instrReceived & vbCrLf, "Normal")
        End If
    End Sub

    Private Sub ProcessLocalInstructions(ByVal Instructions As String)
        'Process the XMessage instructions locally.

        'If Instructions.StartsWith("<XMsg>") Then 'This is an XMessage set of instructions.
        If Instructions.StartsWith("<XMsg>") Or Instructions.StartsWith("<XSys>") Then 'This is an XMessage set of instructions.
            'Run the received message:
            Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
            XDocLocal.LoadXml(XmlHeader & vbCrLf & Instructions)
            XMsgLocal.Run(XDocLocal, StatusLocal)
        Else 'This is not an XMessage!
            Message.XAddText("The message is not an XMessage: " & Instructions & vbCrLf, "Normal")
        End If
    End Sub

    Private _showXMessages As Boolean = True 'If True, XMessages that are sent or received will be shown in the Messages window.
    Property ShowXMessages As Boolean
        Get
            Return _showXMessages
        End Get
        Set(value As Boolean)
            _showXMessages = value
        End Set
    End Property

    Private _showSysMessages As Boolean = True 'If True, System messages that are sent or received will be shown in the messages window.
    Property ShowSysMessages As Boolean
        Get
            Return _showSysMessages
        End Get
        Set(value As Boolean)
            _showSysMessages = value
        End Set
    End Property

    Private _closedFormNo As Integer 'Temporarily holds the number of the form that is being closed. 
    Property ClosedFormNo As Integer
        Get
            Return _closedFormNo
        End Get
        Set(value As Integer)
            _closedFormNo = value
        End Set
    End Property

    Private _workflowFileName As String = "" 'The file name of the html document displayed in the Workflow tab.
    Public Property WorkflowFileName As String
        Get
            Return _workflowFileName
        End Get
        Set(value As String)
            _workflowFileName = value
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
                               <AdvlNetworkAppPath><%= AdvlNetworkAppPath %></AdvlNetworkAppPath>
                               <AdvlNetworkExePath><%= AdvlNetworkExePath %></AdvlNetworkExePath>
                               <ShowXMessages><%= ShowXMessages %></ShowXMessages>
                               <ShowSysMessages><%= ShowSysMessages %></ShowSysMessages>
                               <WorkFlowFileName><%= WorkflowFileName %></WorkFlowFileName>
                               <!---->
                           </FormSettings>

        'Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & " - Main.xml"
        Project.SaveXmlSettings(SettingsFileName, settingsData)

    End Sub

    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        'Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & " - Main.xml"

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

            If Settings.<FormSettings>.<AdvlNetworkAppPath>.Value <> Nothing Then AdvlNetworkAppPath = Settings.<FormSettings>.<AdvlNetworkAppPath>.Value
            If Settings.<FormSettings>.<AdvlNetworkExePath>.Value <> Nothing Then AdvlNetworkExePath = Settings.<FormSettings>.<AdvlNetworkExePath>.Value
            If Settings.<FormSettings>.<ShowXMessages>.Value <> Nothing Then ShowXMessages = Settings.<FormSettings>.<ShowXMessages>.Value
            If Settings.<FormSettings>.<ShowSysMessages>.Value <> Nothing Then ShowSysMessages = Settings.<FormSettings>.<ShowSysMessages>.Value

            If Settings.<FormSettings>.<WorkFlowFileName>.Value <> Nothing Then WorkflowFileName = Settings.<FormSettings>.<WorkFlowFileName>.Value

            CheckFormPos()
        End If
    End Sub

    Private Sub CheckFormPos()
        'Check that the form can be seen on a screen.

        Dim MinWidthVisible As Integer = 192 'Minimum number of X pixels visible. The form will be moved if this many form pixels are not visible.
        Dim MinHeightVisible As Integer = 64 'Minimum number of Y pixels visible. The form will be moved if this many form pixels are not visible.

        Dim FormRect As New Rectangle(Me.Left, Me.Top, Me.Width, Me.Height)
        Dim WARect As Rectangle = Screen.GetWorkingArea(FormRect) 'The Working Area rectangle - the usable area of the screen containing the form.

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

        If ApplicationInfo.FileExists Then
            ApplicationInfo.ReadFile()
        Else
            'There is no Application_Info_ADVL_2.xml file.
            DefaultAppProperties() 'Create a new Application Info file with default application properties:
            ApplicationInfo.WriteFile() 'Write the file now. The file information may be used by other applications.
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
        'Edit My Project \ Application \ Assembly Information to edit the Version settings. (?)
        ApplicationInfo.Version.Major = My.Application.Info.Version.Major
        ApplicationInfo.Version.Minor = My.Application.Info.Version.Minor
        ApplicationInfo.Version.Build = My.Application.Info.Version.Build
        ApplicationInfo.Version.Revision = My.Application.Info.Version.Revision

        'ApplicationInfo.Version.Major = My.Application.Deployment.CurrentVersion.Major
        'ApplicationInfo.Version.Minor = My.Application.Deployment.CurrentVersion.Minor
        'ApplicationInfo.Version.Build = My.Application.Deployment.CurrentVersion.Build
        'ApplicationInfo.Version.Revision = My.Application.Deployment.CurrentVersion.Revision

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
        ApplicationInfo.License.Code = ADVL_Utilities_Library_1.License.Codes.Apache_License_2_0
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

        'Set the Application Directory path:
        Project.ApplicationDir = My.Application.Info.DirectoryPath.ToString

        'Read the Application Information file: ---------------------------------------------
        ApplicationInfo.ApplicationDir = My.Application.Info.DirectoryPath.ToString 'Set the Application Directory property

        ''Get the Application Version Information:
        'ApplicationInfo.Version.Major = My.Application.Info.Version.Major
        'ApplicationInfo.Version.Minor = My.Application.Info.Version.Minor
        'ApplicationInfo.Version.Build = My.Application.Info.Version.Build
        'ApplicationInfo.Version.Revision = My.Application.Info.Version.Revision

        If ApplicationInfo.ApplicationLocked Then
            MessageBox.Show("The application is locked. If the application is not already in use, remove the 'Application_Info.lock file from the application directory: " & ApplicationInfo.ApplicationDir, "Notice", MessageBoxButtons.OK)
            Dim dr As Windows.Forms.DialogResult
            dr = MessageBox.Show("Press 'Yes' to unlock the application", "Notice", MessageBoxButtons.YesNo)
            If dr = Windows.Forms.DialogResult.Yes Then
                ApplicationInfo.UnlockApplication()
            Else
                Application.Exit()
                Exit Sub
            End If
        End If

        ReadApplicationInfo()

        'Read the Application Usage information: --------------------------------------------
        ApplicationUsage.StartTime = Now
        ApplicationUsage.SaveLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
        ApplicationUsage.SaveLocn.Path = Project.ApplicationDir
        ApplicationUsage.RestoreUsageInfo()

        'Restore Project information: -------------------------------------------------------
        Project.Application.Name = ApplicationInfo.Name

        'Set up Message object:
        Message.ApplicationName = ApplicationInfo.Name

        'Set up a temporary initial settings location:
        Dim TempLocn As New ADVL_Utilities_Library_1.FileLocation
        TempLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
        TempLocn.Path = ApplicationInfo.ApplicationDir
        Message.SettingsLocn = TempLocn

        Me.Show() 'Show this form before showing the Message form - This will show the App icon on top in the TaskBar.

        'Start showing messages here - Message system is set up.
        Message.AddText("------------------- Starting Application: ADVL Coordinates ------------------------------ " & vbCrLf, "Heading")
        'Message.AddText("Application usage: Total duration = " & ApplicationUsage.TotalDuration.TotalHours & " hours" & vbCrLf, "Normal")
        Dim TotalDuration As String = ApplicationUsage.TotalDuration.Days.ToString.PadLeft(5, "0"c) & "d:" &
                           ApplicationUsage.TotalDuration.Hours.ToString.PadLeft(2, "0"c) & "h:" &
                           ApplicationUsage.TotalDuration.Minutes.ToString.PadLeft(2, "0"c) & "m:" &
                           ApplicationUsage.TotalDuration.Seconds.ToString.PadLeft(2, "0"c) & "s"
        Message.AddText("Application usage: Total duration = " & TotalDuration & vbCrLf, "Normal")

        'https://msdn.microsoft.com/en-us/library/z2d603cy(v=vs.80).aspx#Y550
        'Process any command line arguments:
        Try
            For Each s As String In My.Application.CommandLineArgs
                Message.Add("Command line argument: " & vbCrLf)
                Message.AddXml(s & vbCrLf & vbCrLf)
                InstrReceived = s
            Next
        Catch ex As Exception
            Message.AddWarning("Error processing command line arguments: " & ex.Message & vbCrLf)
        End Try

        If ProjectSelected = False Then
            'Read the Settings Location for the last project used:
            Project.ReadLastProjectInfo()
            'The Last_Project_Info.xml file contains:
            '  Project Name and Description. Settings Location Type and Settings Location Path.

            'Message.Add("Last project info has been read." & vbCrLf)
            'Message.Add("Project.Type.ToString  " & Project.Type.ToString & vbCrLf)
            'Message.Add("Project.Path  " & Project.Path & vbCrLf)
            Message.Add("Last project details:" & vbCrLf)
            Message.Add("Project Type:  " & Project.Type.ToString & vbCrLf)
            Message.Add("Project Path:  " & Project.Path & vbCrLf)

            'At this point read the application start arguments, if any.
            'The selected project may be changed here.

            'Check if the project is locked:
            If Project.ProjectLocked Then
                Message.AddWarning("The project is locked: " & Project.Name & vbCrLf)
                Dim dr As System.Windows.Forms.DialogResult
                dr = MessageBox.Show("Press 'Yes' to unlock the project", "Notice", MessageBoxButtons.YesNo)
                If dr = System.Windows.Forms.DialogResult.Yes Then
                    Project.UnlockProject()
                    Message.AddWarning("The project has been unlocked: " & Project.Name & vbCrLf)
                    'Read the Project Information file: -------------------------------------------------
                    Message.Add("Reading project info." & vbCrLf)
                    Project.ReadProjectInfoFile()    'Read the file in the SettingsLocation: ADVL_Project_Info.xml

                    Project.ReadParameters()
                    Project.ReadParentParameters()
                    If Project.ParentParameterExists("ProNetName") Then
                        Project.AddParameter("ProNetName", Project.ParentParameter("ProNetName").Value, Project.ParentParameter("ProNetName").Description) 'AddParameter will update the parameter if it already exists.
                        ProNetName = Project.Parameter("ProNetName").Value
                    Else
                        ProNetName = Project.GetParameter("ProNetName")
                    End If
                    If Project.ParentParameterExists("ProNetPath") Then 'Get the parent parameter value - it may have been updated.
                        Project.AddParameter("ProNetPath", Project.ParentParameter("ProNetPath").Value, Project.ParentParameter("ProNetPath").Description) 'AddParameter will update the parameter if it already exists.
                        ProNetPath = Project.Parameter("ProNetPath").Value
                    Else
                        ProNetPath = Project.GetParameter("ProNetPath") 'If the parameter does not exist, the value is set to ""
                    End If
                    Project.SaveParameters() 'These should be saved now - child projects look for parent parameters in the parameter file.

                    Project.LockProject() 'Lock the project while it is open in this application.
                    'Set the project start time. This is used to track project usage.
                    Project.Usage.StartTime = Now
                    ApplicationInfo.SettingsLocn = Project.SettingsLocn
                    'Set up the Message object:
                    Message.SettingsLocn = Project.SettingsLocn
                    Message.Show() 'Added 18May19
                Else
                    'Continue without any project selected.
                    Project.Name = ""
                    Project.Type = ADVL_Utilities_Library_1.Project.Types.None
                    Project.Description = ""
                    Project.SettingsLocn.Path = ""
                    Project.DataLocn.Path = ""
                End If

            Else
                'Read the Project Information file: -------------------------------------------------
                Message.Add("Reading project info." & vbCrLf)
                Project.ReadProjectInfoFile() 'Read the file in the SettingsLocation: ADVL_Project_Info.xml

                Project.ReadParameters()
                Project.ReadParentParameters()
                If Project.ParentParameterExists("ProNetName") Then
                    Project.AddParameter("ProNetName", Project.ParentParameter("ProNetName").Value, Project.ParentParameter("ProNetName").Description) 'AddParameter will update the parameter if it already exists.
                    ProNetName = Project.Parameter("ProNetName").Value
                Else
                    ProNetName = Project.GetParameter("ProNetName")
                End If
                If Project.ParentParameterExists("ProNetPath") Then 'Get the parent parameter value - it may have been updated.
                    Project.AddParameter("ProNetPath", Project.ParentParameter("ProNetPath").Value, Project.ParentParameter("ProNetPath").Description) 'AddParameter will update the parameter if it already exists.
                    ProNetPath = Project.Parameter("ProNetPath").Value
                Else
                    ProNetPath = Project.GetParameter("ProNetPath") 'If the parameter does not exist, the value is set to ""
                End If
                Project.SaveParameters() 'These should be saved now - child projects look for parent parameters in the parameter file.

                Project.LockProject() 'Lock the project while it is open in this application.
                'Set the project start time. This is used to track project usage.
                Project.Usage.StartTime = Now
                ApplicationInfo.SettingsLocn = Project.SettingsLocn
                'Set up the Message object:
                Message.SettingsLocn = Project.SettingsLocn
                Message.Show() 'Added 18May19
            End If
        Else 'Project has been opened using Command Line arguments.
            Project.ReadParameters()
            Project.ReadParentParameters()
            If Project.ParentParameterExists("ProNetName") Then
                Project.AddParameter("ProNetName", Project.ParentParameter("ProNetName").Value, Project.ParentParameter("ProNetName").Description) 'AddParameter will update the parameter if it already exists.
                ProNetName = Project.Parameter("ProNetName").Value
            Else
                ProNetName = Project.GetParameter("ProNetName")
            End If
            If Project.ParentParameterExists("ProNetPath") Then 'Get the parent parameter value - it may have been updated.
                Project.AddParameter("ProNetPath", Project.ParentParameter("ProNetPath").Value, Project.ParentParameter("ProNetPath").Description) 'AddParameter will update the parameter if it already exists.
                ProNetPath = Project.Parameter("ProNetPath").Value
            Else
                ProNetPath = Project.GetParameter("ProNetPath") 'If the parameter does not exist, the value is set to ""
            End If
            Project.SaveParameters() 'These should be saved now - child projects look for parent parameters in the parameter file.

            Project.LockProject() 'Lock the project while it is open in this application.
            ProjectSelected = False 'Reset the Project Selected flag.
        End If

        'START Initialise the form: ===============================================================

        Me.WebBrowser1.ObjectForScripting = Me

        bgwSendMessage.WorkerReportsProgress = True
        bgwSendMessage.WorkerSupportsCancellation = True

        InitialiseForm() 'Initialise the form for a new project.

        'END   Initialise the form: ---------------------------------------------------------------

        RestoreFormSettings()
        OpenStartPage()
        Message.ShowXMessages = ShowXMessages
        Message.ShowSysMessages = ShowSysMessages
        RestoreProjectSettings()

        ShowProjectInfo() 'Show the project information.

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

        Message.AddText("------------------- Started OK -------------------------------------------------------------------------- " & vbCrLf & vbCrLf, "Heading")

        ShowEPSGTermsOfUse()

        If StartupConnectionName = "" Then
            If Project.ConnectOnOpen Then
                ConnectToComNet() 'The Project is set to connect when it is opened.
            ElseIf ApplicationInfo.ConnectOnStartup Then
                ConnectToComNet() 'The Application is set to connect when it is started.
            Else
                'Don't connect to ComNet.
            End If
        Else
            'Connect to AppNet using the connection name StartupConnectionName.
            ConnectToComNet(StartupConnectionName)
        End If

        'Get the Application Version Information:
        If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            'Application is network deployed.
            ApplicationInfo.Version.Number = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
            ApplicationInfo.Version.Major = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Major
            ApplicationInfo.Version.Minor = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Minor
            ApplicationInfo.Version.Build = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Build
            ApplicationInfo.Version.Revision = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Revision
            ApplicationInfo.Version.Source = "Publish"
            Message.Add("Application version: " & System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString & vbCrLf)
        Else
            'Application is not network deployed.
            ApplicationInfo.Version.Number = My.Application.Info.Version.ToString
            ApplicationInfo.Version.Major = My.Application.Info.Version.Major
            ApplicationInfo.Version.Minor = My.Application.Info.Version.Minor
            ApplicationInfo.Version.Build = My.Application.Info.Version.Build
            ApplicationInfo.Version.Revision = My.Application.Info.Version.Revision
            ApplicationInfo.Version.Source = "Assembly"
            Message.Add("Application version: " & My.Application.Info.Version.ToString & vbCrLf)
        End If

    End Sub

    Private Sub InitialiseForm()
        'Initialise the form for a new project.
        'OpenStartPage()
    End Sub

    Private Sub ShowProjectInfo()
        'Show the project information:

        txtProjectName.Text = Project.Name
        txtProNetName.Text = Project.GetParameter("ProNetName")
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
        txtProjectPath.Text = Project.Path

        Select Case Project.SettingsLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtSettingsLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtSettingsLocationType.Text = "Archive"
        End Select
        txtSettingsPath.Text = Project.SettingsLocn.Path

        Select Case Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtDataLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtDataLocationType.Text = "Archive"
        End Select
        txtDataPath.Text = Project.DataLocn.Path

        Select Case Project.SystemLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtSystemLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtSystemLocationType.Text = "Archive"
        End Select
        txtSystemPath.Text = Project.SystemLocn.Path

        If Project.ConnectOnOpen Then
            chkConnect.Checked = True
        Else
            chkConnect.Checked = False
        End If

        'txtTotalDuration.Text = Project.Usage.TotalDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
        '                        Project.Usage.TotalDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
        '                        Project.Usage.TotalDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
        '                        Project.Usage.TotalDuration.Seconds.ToString.PadLeft(2, "0"c)

        'txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
        '                          Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
        '                          Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
        '                          Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)

        txtTotalDuration.Text = Project.Usage.TotalDuration.Days.ToString.PadLeft(5, "0"c) & "d:" &
                        Project.Usage.TotalDuration.Hours.ToString.PadLeft(2, "0"c) & "h:" &
                        Project.Usage.TotalDuration.Minutes.ToString.PadLeft(2, "0"c) & "m:" &
                        Project.Usage.TotalDuration.Seconds.ToString.PadLeft(2, "0"c) & "s"

        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & "d:" &
                                  Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & "h:" &
                                  Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & "m:" &
                                  Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c) & "s"
    End Sub



    Private Sub ShowEPSGTermsOfUse()

        Message.AddWarning("Important Notice" & vbCrLf)
        Message.SetNormalStyle()
        Message.Add("This software can import and use the EPSG Geodetic Parameter Dataset." & vbCrLf)
        Message.Add("EPSG specify Terms of Use for this dataset." & vbCrLf)
        Message.Add("These terms can be found at: http://www.epsg.org/Termsofuse.aspx" & vbCrLf & vbCrLf)
        Message.SetBoldStyle()
        Message.Add("The terms include:" & vbCrLf)
        Message.SetNormalStyle()
        Message.Add("    The EPSG Facilities are published by IOGP at no charge. Distribution for profit is forbidden." & vbCrLf)
        Message.Add("    The data may be included in any commercial package provided that any commerciality is based on value added by the provider and not on a value ascribed to the EPSG Dataset which is made available at no charge." & vbCrLf)
        Message.Add("    Ownership of the EPSG Dataset by IOGP must be acknowledged in any publication or transmission (by whatever means) thereof (including permitted modifications)." & vbCrLf)
        Message.Add("    Modification of parameter values is permitted as described in the table 1 to allow change to the content of the information provided that numeric equivalence is achieved." & vbCrLf)
        Message.Add("    No data that has been modified other than as permitted in these Terms of Use shall be attributed to the EPSG Dataset." & vbCrLf & vbCrLf)
        Message.Add("-------------------------------------------------------------------------------------------------------------------------------------------" & vbCrLf & vbCrLf)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Application

        DisconnectFromComNet() 'Disconnect from the Communication Network.

        SaveProjectSettings()  'Save the project settings.

        ApplicationInfo.WriteFile()  'Update the Application Information file.
        ApplicationInfo.UnlockApplication()

        Project.SaveLastProjectInfo() 'Save information about the last project used.
        Project.SaveParameters() 'ADDED 3Feb19

        'Project.SaveProjectInfoFile() 'Update the Project Information file. This is not required unless there is a change made to the project.

        Project.Usage.SaveUsageInfo() 'Save Project usage information.
        Project.UnlockProject() 'Unlock the project.

        ApplicationUsage.SaveUsageInfo() 'Save Application Usage information.

        Application.Exit()

    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Save the form settings if the form state is normal. (A minimised form will have the incorrect size and location.)
        If WindowState = FormWindowState.Normal Then
            SaveFormSettings()
        End If
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
        Message.ShowXMessages = ShowXMessages
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


    Private Sub btnWebPages_Click(sender As Object, e As EventArgs) Handles btnWebPages.Click
        'Open the Web Pages form.

        If IsNothing(WebPageList) Then
            WebPageList = New frmWebPageList
            WebPageList.Show()
        Else
            WebPageList.Show()
            WebPageList.BringToFront()
        End If
    End Sub

    Private Sub WebPageList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles WebPageList.FormClosed
        WebPageList = Nothing
    End Sub

    Public Function OpenNewWebPage() As Integer
        'Open a new HTML Web View window, or reuse an existing one if avaiable.
        'The new forms index number in WebViewFormList is returned.

        NewWebPage = New frmWebPage
        If WebPageFormList.Count = 0 Then
            WebPageFormList.Add(NewWebPage)
            WebPageFormList(0).FormNo = 0
            WebPageFormList(0).Show
            Return 0 'The new HTML Display is at position 0 in WebViewFormList()
        Else
            Dim I As Integer
            Dim FormAdded As Boolean = False
            For I = 0 To WebPageFormList.Count - 1 'Check if there are closed forms in WebViewFormList. They can be re-used.
                If IsNothing(WebPageFormList(I)) Then
                    WebPageFormList(I) = NewWebPage
                    WebPageFormList(I).FormNo = I
                    WebPageFormList(I).Show
                    FormAdded = True
                    Return I 'The new Html Display is at position I in WebViewFormList()
                    Exit For
                End If
            Next
            If FormAdded = False Then 'Add a new form to WebViewFormList
                Dim FormNo As Integer
                WebPageFormList.Add(NewWebPage)
                FormNo = WebPageFormList.Count - 1
                WebPageFormList(FormNo).FormNo = FormNo
                WebPageFormList(FormNo).Show
                Return FormNo 'The new WebPage is at position FormNo in WebPageFormList()
            End If
        End If
    End Function

    Public Sub WebPageFormClosed()
        'This subroutine is called when the Web Page form has been closed.
        'The subroutine is usually called from the FormClosed event of the WebPage form.
        'The WebPage form may have multiple instances.
        'The ClosedFormNumber property should contains the number of the instance of the WebPage form.
        'This property should be updated by the WebPage form when it is being closed.
        'The ClosedFormNumber property value is used to determine which element in WebPageList should be set to Nothing.

        If WebPageFormList.Count < ClosedFormNo + 1 Then
            'ClosedFormNo is too large to exist in WebPageFormList
            Exit Sub
        End If

        If IsNothing(WebPageFormList(ClosedFormNo)) Then
            'The form is already set to nothing
        Else
            WebPageFormList(ClosedFormNo) = Nothing
        End If
    End Sub

    Public Function OpenNewHtmlDisplayPage() As Integer
        'Open a new HTML display window, or reuse an existing one if avaiable.
        'The new forms index number in HtmlDisplayFormList is returned.

        NewHtmlDisplay = New frmHtmlDisplay
        If HtmlDisplayFormList.Count = 0 Then
            HtmlDisplayFormList.Add(NewHtmlDisplay)
            HtmlDisplayFormList(0).FormNo = 0
            HtmlDisplayFormList(0).Show
            Return 0 'The new HTML Display is at position 0 in HtmlDisplayFormList()
        Else
            Dim I As Integer
            Dim FormAdded As Boolean = False
            For I = 0 To HtmlDisplayFormList.Count - 1 'Check if there are closed forms in HtmlDisplayFormList. They can be re-used.
                If IsNothing(HtmlDisplayFormList(I)) Then
                    HtmlDisplayFormList(I) = NewHtmlDisplay
                    HtmlDisplayFormList(I).FormNo = I
                    HtmlDisplayFormList(I).Show
                    FormAdded = True
                    Return I 'The new Html Display is at position I in HtmlDisplayFormList()
                    Exit For
                End If
            Next
            If FormAdded = False Then 'Add a new form to HtmlDisplayFormList
                Dim FormNo As Integer
                HtmlDisplayFormList.Add(NewHtmlDisplay)
                FormNo = HtmlDisplayFormList.Count - 1
                HtmlDisplayFormList(FormNo).FormNo = FormNo
                HtmlDisplayFormList(FormNo).Show
                Return FormNo 'The new HtmlDisplay is at position FormNo in HtmlDisplayFormList()
            End If
        End If
    End Function

#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Public Sub UpdateWebPage(ByVal FileName As String)
        'Update the web page in WebPageFormList if the Web file name is FileName.

        Dim NPages As Integer = WebPageFormList.Count
        Dim I As Integer

        Try
            For I = 0 To NPages - 1
                If IsNothing(WebPageFormList(I)) Then
                    'Web page has been deleted!
                Else
                    If WebPageFormList(I).FileName = FileName Then
                        WebPageFormList(I).OpenDocument
                    End If
                End If
            Next
        Catch ex As Exception
            Message.AddWarning(ex.Message & vbCrLf)
        End Try
    End Sub

#Region " Start Page Code" '=========================================================================================================================================

    Public Sub OpenStartPage()
        'Open the workflow page:

        If Project.DataFileExists(WorkflowFileName) Then
            'Note: WorkflowFileName should have been restored when the application started.
            DisplayWorkflow()
        ElseIf Project.DataFileExists("StartPage.html") Then
            WorkflowFileName = "StartPage.html"
            DisplayWorkflow()
        Else
            CreateStartPage()
            WorkflowFileName = "StartPage.html"
            DisplayWorkflow()
        End If

        ''Open the StartPage.html file and display in the Workflow tab.
        'If Project.DataFileExists("StartPage.html") Then
        '    WorkflowFileName = "StartPage.html"
        '    DisplayWorkflow()
        'Else
        '    CreateStartPage()
        '    WorkflowFileName = "StartPage.html"
        '    DisplayWorkflow()
        'End If
    End Sub

    Public Sub DisplayWorkflow()
        'Display the StartPage.html file in the Start Page tab.

        If Project.DataFileExists(WorkflowFileName) Then
            Dim rtbData As New IO.MemoryStream
            Project.ReadData(WorkflowFileName, rtbData)
            rtbData.Position = 0
            Dim sr As New IO.StreamReader(rtbData)
            WebBrowser1.DocumentText = sr.ReadToEnd()
        Else
            Message.AddWarning("Web page file not found: " & WorkflowFileName & vbCrLf)
        End If
    End Sub

    Private Sub CreateStartPage()
        'Create a new default StartPage.html file.

        Dim htmData As New IO.MemoryStream
        Dim sw As New IO.StreamWriter(htmData)
        sw.Write(AppInfoHtmlString("Application Information")) 'Create a web page providing information about the application.
        sw.Flush()
        Project.SaveData("StartPage.html", htmData)
    End Sub

    Public Function AppInfoHtmlString(ByVal DocumentTitle As String) As String
        'Create an Application Information Web Page.

        'This function should be edited to provide a brief description of the Application.

        Dim sb As New System.Text.StringBuilder

        sb.Append("<!DOCTYPE html>" & vbCrLf)
        sb.Append("<html>" & vbCrLf)
        sb.Append("<head>" & vbCrLf)
        sb.Append("<title>" & DocumentTitle & "</title>" & vbCrLf)
        sb.Append("<meta name=""description"" content=""Application information."">" & vbCrLf)
        sb.Append("</head>" & vbCrLf)

        sb.Append("<body style=""font-family:arial;"">" & vbCrLf & vbCrLf)

        sb.Append("<h2>" & "Andorville&trade; Coordinates" & "</h2>" & vbCrLf & vbCrLf) 'Add the page title.
        sb.Append("<hr>" & vbCrLf) 'Add a horizontal divider line.
        sb.Append("<p>The Andorville&trade; Coordinates application stores coordinate reference system parameters. The application can display the parameters and convert coordinate locations between reference systems.</p>" & vbCrLf) 'Add an application description.
        sb.Append("<hr>" & vbCrLf & vbCrLf) 'Add a horizontal divider line.

        sb.Append(DefaultJavaScriptString)

        sb.Append("</body>" & vbCrLf)
        sb.Append("</html>" & vbCrLf)

        Return sb.ToString

    End Function

    Public Function DefaultJavaScriptString() As String
        'Generate the default JavaScript section of an Andorville(TM) Workflow Web Page.

        Dim sb As New System.Text.StringBuilder

        'Add JavaScript section:
        sb.Append("<script>" & vbCrLf & vbCrLf)

        'START: User defined JavaScript functions ==========================================================================
        'Add functions to implement the main actions performed by this web page.
        sb.Append("//START: User defined JavaScript functions ==========================================================================" & vbCrLf)
        sb.Append("//  Add functions to implement the main actions performed by this web page." & vbCrLf & vbCrLf)

        sb.Append("//END:   User defined JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf & vbCrLf)
        'END:   User defined JavaScript functions --------------------------------------------------------------------------


        'START: User modified JavaScript functions ==========================================================================
        'Modify these function to save all required web page settings and process all expected XMessage instructions.
        sb.Append("//START: User modified JavaScript functions ==========================================================================" & vbCrLf)
        sb.Append("//  Modify these function to save all required web page settings and process all expected XMessage instructions." & vbCrLf & vbCrLf)

        'Add the SaveSettings function - This is used to save web page settings between sessions.
        sb.Append("//Save the web page settings." & vbCrLf)
        sb.Append("function SaveSettings() {" & vbCrLf)
        sb.Append("  var xSettings = ""<Settings>"" + "" \n"" ; //String containing the web page settings in XML format." & vbCrLf)
        sb.Append("  //Add xml lines to save each setting." & vbCrLf & vbCrLf)
        sb.Append("  xSettings +=    ""</Settings>"" + ""\n"" ; //End of the Settings element." & vbCrLf)
        sb.Append(vbCrLf)
        sb.Append("  //Save the settings as an XML file in the project." & vbCrLf)
        sb.Append("  window.external.SaveHtmlSettings(xSettings) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Process a single XMsg instruction (Information:Location pair)
        sb.Append("//Process an XMessage instruction:" & vbCrLf)
        sb.Append("function XMsgInstruction(Info, Locn) {" & vbCrLf)
        sb.Append("  switch(Locn) {" & vbCrLf)
        sb.Append("  //Insert case statements here." & vbCrLf)
        sb.Append("  default:" & vbCrLf)
        sb.Append("    window.external.AddWarning(""Unknown location: "" + Locn + ""\r\n"") ;" & vbCrLf)
        sb.Append("  }" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        sb.Append("//END:   User modified JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf & vbCrLf)
        'END:   User modified JavaScript functions --------------------------------------------------------------------------

        'START: Required Document Library Web Page JavaScript functions ==========================================================================
        sb.Append("//START: Required Document Library Web Page JavaScript functions ==========================================================================" & vbCrLf & vbCrLf)

        'Add the AddText function - This sends a message to the message window using a named text type.
        sb.Append("//Add text to the Message window using a named txt type:" & vbCrLf)
        sb.Append("function AddText(Msg, TextType) {" & vbCrLf)
        sb.Append("  window.external.AddText(Msg, TextType) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the AddMessage function - This sends a message to the message window using default black text.
        sb.Append("//Add a message to the Message window using the default black text:" & vbCrLf)
        sb.Append("function AddMessage(Msg) {" & vbCrLf)
        sb.Append("  window.external.AddMessage(Msg) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the AddWarning function - This sends a red, bold warning message to the message window.
        sb.Append("//Add a warning message to the Message window using bold red text:" & vbCrLf)
        sb.Append("function AddWarning(Msg) {" & vbCrLf)
        sb.Append("  window.external.AddWarning(Msg) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the RestoreSettings function - This is used to restore web page settings.
        sb.Append("//Restore the web page settings." & vbCrLf)
        sb.Append("function RestoreSettings() {" & vbCrLf)
        sb.Append("  window.external.RestoreHtmlSettings() " & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'This line runs the RestoreSettings function when the web page is loaded.
        sb.Append("//Restore the web page settings when the page loads." & vbCrLf)
        sb.Append("window.onload = RestoreSettings; " & vbCrLf)
        sb.Append(vbCrLf)

        'Restores a single setting on the web page.
        sb.Append("//Restore a web page setting." & vbCrLf)
        sb.Append("  function RestoreSetting(FormName, ItemName, ItemValue) {" & vbCrLf)
        sb.Append("  document.forms[FormName][ItemName].value = ItemValue ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the RestoreOption function - This is used to add an option to a Select list.
        sb.Append("//Restore a Select control Option." & vbCrLf)
        sb.Append("function RestoreOption(SelectId, OptionText) {" & vbCrLf)
        sb.Append("  var x = document.getElementById(SelectId) ;" & vbCrLf)
        sb.Append("  var option = document.createElement(""Option"") ;" & vbCrLf)
        sb.Append("  option.text = OptionText ;" & vbCrLf)
        sb.Append("  x.add(option) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        sb.Append("//END:   Required Document Library Web Page JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf)
        'END:   Required Document Library Web Page JavaScript functions --------------------------------------------------------------------------

        sb.Append("</script>" & vbCrLf & vbCrLf)

        Return sb.ToString

    End Function


    Public Function DefaultHtmlString(ByVal DocumentTitle As String) As String
        'Create a blank HTML Web Page.

        Dim sb As New System.Text.StringBuilder

        sb.Append("<!DOCTYPE html>" & vbCrLf)
        sb.Append("<html>" & vbCrLf)
        sb.Append("<!-- Andorville(TM) Workflow File -->" & vbCrLf)
        sb.Append("<!-- Application Name:    " & ApplicationInfo.Name & " -->" & vbCrLf)
        sb.Append("<!-- Application Version: " & My.Application.Info.Version.ToString & " -->" & vbCrLf)
        sb.Append("<!-- Creation Date:          " & Format(Now, "dd MMMM yyyy") & " -->" & vbCrLf)
        sb.Append("<head>" & vbCrLf)
        sb.Append("<title>" & DocumentTitle & "</title>" & vbCrLf)
        sb.Append("<meta name=""description"" content=""Workflow description."">" & vbCrLf)
        sb.Append("</head>" & vbCrLf)

        sb.Append("<body style=""font-family:arial;"">" & vbCrLf & vbCrLf)

        sb.Append("<h1>" & DocumentTitle & "</h1>" & vbCrLf & vbCrLf)

        sb.Append(DefaultJavaScriptString)

        sb.Append("</body>" & vbCrLf)
        sb.Append("</html>" & vbCrLf)

        Return sb.ToString

    End Function

#End Region 'Start Page Code ------------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Methods Called by JavaScript - A collection of methods that can be called by JavaScript in a web page shown in WebBrowser1" '==================================
    'These methods are used to display HTML pages in the Document tab.
    'The same methods can be found in the WebView form, which displays web pages on seprate forms.


    'Display Messages ==============================================================================================

    Public Sub AddMessage(ByVal Msg As String)
        'Add a normal text message to the Message window.
        Message.Add(Msg)
    End Sub

    Public Sub AddWarning(ByVal Msg As String)
        'Add a warning text message to the Message window.
        Message.AddWarning(Msg)
    End Sub

    Public Sub AddTextTypeMessage(ByVal Msg As String, ByVal TextType As String)
        'Add a message with the specified Text Type to the Message window.
        Message.AddText(Msg, TextType)
    End Sub

    Public Sub AddXmlMessage(ByVal XmlText As String)
        'Add an Xml message to the Message window.
        Message.AddXml(XmlText)
    End Sub

    'END Display Messages ------------------------------------------------------------------------------------------


    'Run an XSequence ==============================================================================================

    Public Sub RunClipboardXSeq()
        'Run the XSequence instructions in the clipboard.

        Dim XDocSeq As System.Xml.Linq.XDocument
        Try
            XDocSeq = XDocument.Parse(My.Computer.Clipboard.GetText)
        Catch ex As Exception
            Message.AddWarning("Error reading Clipboard data. " & ex.Message & vbCrLf)
            Exit Sub
        End Try

        If IsNothing(XDocSeq) Then
            Message.Add("No XSequence instructions were found in the clipboard.")
        Else
            Dim XmlSeq As New System.Xml.XmlDocument
            Try
                XmlSeq.LoadXml(XDocSeq.ToString) 'Convert XDocSeq to an XmlDocument to process with XSeq.
                'Run the sequence:
                XSeq.RunXSequence(XmlSeq, Status)
            Catch ex As Exception
                Message.AddWarning("Error restoring HTML settings. " & ex.Message & vbCrLf)
            End Try
        End If
    End Sub

    Public Sub RunXSequence(ByVal XSequence As String)
        'Run the XMSequence
        Dim XmlSeq As New System.Xml.XmlDocument
        XmlSeq.LoadXml(XSequence)
        XSeq.RunXSequence(XmlSeq, Status)
    End Sub

    Private Sub XSeq_ErrorMsg(ErrMsg As String) Handles XSeq.ErrorMsg
        Message.AddWarning(ErrMsg & vbCrLf)
    End Sub

    Private Sub XSeq_Instruction(Data As String, Locn As String) Handles XSeq.Instruction
        'Execute each instruction produced by running the XSeq file.

        Select Case Locn
            Case "Settings:Form:Name"
                FormName = Data

            Case "Settings:Form:Item:Name"
                ItemName = Data

            Case "Settings:Form:Item:Value"
                RestoreSetting(FormName, ItemName, Data)

            Case "Settings:Form:SelectId"
                SelectId = Data

            Case "Settings:Form:OptionText"
                RestoreOption(SelectId, Data)

            Case "Settings"

            Case "EndOfSequence"
                'Main.Message.Add("End of processing sequence" & Data & vbCrLf)

            Case Else
                'Main.Message.AddWarning("Unknown location: " & Locn & "  Data: " & Data & vbCrLf)
                Message.AddWarning("Unknown location: " & Locn & "  Data: " & Data & vbCrLf)

        End Select
    End Sub

    'END Run an XSequence ------------------------------------------------------------------------------------------


    'Run an XMessage ===============================================================================================

    Public Sub RunXMessage(ByVal XMsg As String)
        'Run the XMessage by sending it to InstrReceived.
        InstrReceived = XMsg
    End Sub

    Public Sub SendXMessage(ByVal ConnName As String, ByVal XMsg As String)
        'Send the XMessage to the application with the connection name ConnName.
        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                If bgwSendMessage.IsBusy Then
                    Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                Else
                    Dim SendMessageParams As New clsSendMessageParams
                    SendMessageParams.ProjectNetworkName = ProNetName
                    SendMessageParams.ConnectionName = ConnName
                    SendMessageParams.Message = XMsg
                    bgwSendMessage.RunWorkerAsync(SendMessageParams)
                    If ShowXMessages Then
                        Message.XAddText("Message sent to " & "[" & ProNetName & "]." & ConnName & ":" & vbCrLf, "XmlSentNotice")
                        Message.XAddXml(XMsg)
                        Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub SendXMessageExt(ByVal ProNetName As String, ByVal ConnName As String, ByVal XMsg As String)
        'Send the XMsg to the application with the connection name ConnName and Project Network Name ProNetname.
        'This version can send the XMessage to a connection external to the current Project Network.
        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                If bgwSendMessage.IsBusy Then
                    Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                Else
                    Dim SendMessageParams As New clsSendMessageParams
                    SendMessageParams.ProjectNetworkName = ProNetName
                    SendMessageParams.ConnectionName = ConnName
                    SendMessageParams.Message = XMsg
                    bgwSendMessage.RunWorkerAsync(SendMessageParams)
                    If ShowXMessages Then
                        Message.XAddText("Message sent to " & "[" & ProNetName & "]." & ConnName & ":" & vbCrLf, "XmlSentNotice")
                        Message.XAddXml(XMsg)
                        Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub SendXMessageWait(ByVal ConnName As String, ByVal XMsg As String)
        'Send the XMsg to the application with the connection name ConnName.
        'Wait for the connection to be made.
        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            Try
                'Application.DoEvents() 'TRY THE METHOD WITHOUT THE DOEVENTS
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("client state is faulted. Message not sent!" & vbCrLf)
                Else
                    Dim StartTime As Date = Now
                    Dim Duration As TimeSpan
                    'Wait up to 16 seconds for the connection ConnName to be established
                    While client.ConnectionExists(ProNetName, ConnName) = False 'Wait until the required connection is made.
                        System.Threading.Thread.Sleep(1000) 'Pause for 1000ms
                        Duration = Now - StartTime
                        If Duration.Seconds > 16 Then Exit While
                    End While

                    If client.ConnectionExists(ProNetName, ConnName) = False Then
                        Message.AddWarning("Connection not available: " & ConnName & " in application network: " & ProNetName & vbCrLf)
                    Else
                        If bgwSendMessage.IsBusy Then
                            Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                        Else
                            Dim SendMessageParams As New clsSendMessageParams
                            SendMessageParams.ProjectNetworkName = ProNetName
                            SendMessageParams.ConnectionName = ConnName
                            SendMessageParams.Message = XMsg
                            bgwSendMessage.RunWorkerAsync(SendMessageParams)
                            If ShowXMessages Then
                                Message.XAddText("Message sent to " & "[" & ProNetName & "]." & ConnName & ":" & vbCrLf, "XmlSentNotice")
                                Message.XAddXml(XMsg)
                                Message.XAddText(vbCrLf, "Normal") 'Add extra line
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                Message.AddWarning(ex.Message & vbCrLf)
            End Try
        End If
    End Sub

    Public Sub SendXMessageExtWait(ByVal ProNetName As String, ByVal ConnName As String, ByVal XMsg As String)
        'Send the XMsg to the application with the connection name ConnName and Project Network Name ProNetName.
        'Wait for the connection to be made.
        'This version can send the XMessage to a connection external to the current Project Network.
        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                Dim StartTime As Date = Now
                Dim Duration As TimeSpan
                'Wait up to 16 seconds for the connection ConnName to be established
                While client.ConnectionExists(ProNetName, ConnName) = False
                    System.Threading.Thread.Sleep(1000) 'Pause for 1000ms
                    Duration = Now - StartTime
                    If Duration.Seconds > 16 Then Exit While
                End While

                If client.ConnectionExists(ProNetName, ConnName) = False Then
                    Message.AddWarning("Connection not available: " & ConnName & " in application network: " & ProNetName & vbCrLf)
                Else
                    If bgwSendMessage.IsBusy Then
                        Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                    Else
                        Dim SendMessageParams As New clsSendMessageParams
                        SendMessageParams.ProjectNetworkName = ProNetName
                        SendMessageParams.ConnectionName = ConnName
                        SendMessageParams.Message = XMsg
                        bgwSendMessage.RunWorkerAsync(SendMessageParams)
                        If ShowXMessages Then
                            Message.XAddText("Message sent to " & "[" & ProNetName & "]." & ConnName & ":" & vbCrLf, "XmlSentNotice")
                            Message.XAddXml(XMsg)
                            Message.XAddText(vbCrLf, "Normal") 'Add extra line
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub XMsgInstruction(ByVal Info As String, ByVal Locn As String)
        'Send the XMessage Instruction to the JavaScript function XMsgInstruction for processing.
        Me.WebBrowser1.Document.InvokeScript("XMsgInstruction", New String() {Info, Locn})
    End Sub

    'END Run an XMessage -------------------------------------------------------------------------------------------


    'Get Information ===============================================================================================

    Public Function GetFormNo() As String
        'Return the Form Number of the current instance of the WebPage form.
        'Return FormNo.ToString
        Return "-1" 'The Main Form is not a Web Page form.
    End Function

    Public Function GetParentFormNo() As String
        'Return the Form Number of the Parent Form (that called this form).
        'Return ParentWebPageFormNo.ToString
        Return "-1" 'The Main Form does not have a Parent Web Page.
    End Function

    Public Function GetConnectionName() As String
        'Return the Connection Name of the Project.
        Return ConnectionName
    End Function

    Public Function GetProNetName() As String
        'Return the Project Network Name of the Project.
        Return ProNetName
    End Function

    Public Sub ParentProjectName(ByVal FormName As String, ByVal ItemName As String)
        'Return the Parent Project name:
        RestoreSetting(FormName, ItemName, Project.ParentProjectName)
    End Sub

    Public Sub ParentProjectPath(ByVal FormName As String, ByVal ItemName As String)
        'Return the Parent Project path:
        RestoreSetting(FormName, ItemName, Project.ParentProjectPath)
    End Sub

    Public Sub ParentProjectParameterValue(ByVal FormName As String, ByVal ItemName As String, ByVal ParameterName As String)
        'Return the specified Parent Project parameter value:
        RestoreSetting(FormName, ItemName, Project.ParentParameter(ParameterName).Value)
    End Sub

    Public Sub ProjectParameterValue(ByVal FormName As String, ByVal ItemName As String, ByVal ParameterName As String)
        'Return the specified Project parameter value:
        RestoreSetting(FormName, ItemName, Project.Parameter(ParameterName).Value)
    End Sub

    Public Sub ProjectNetworkName(ByVal FormName As String, ByVal ItemName As String)
        'Return the name of the Project Network:
        RestoreSetting(FormName, ItemName, Project.Parameter("ProNetName").Value)
    End Sub

    'END Get Information -------------------------------------------------------------------------------------------


    'Open a Web Page ===============================================================================================

    Public Sub OpenWebPage(ByVal FileName As String)
        'Open the web page with the specified File Name.

        If FileName = "" Then

        Else
            'First check if the HTML file is already open:
            Dim FileFound As Boolean = False
            If WebPageFormList.Count = 0 Then

            Else
                Dim I As Integer
                For I = 0 To WebPageFormList.Count - 1
                    If WebPageFormList(I) Is Nothing Then

                    Else
                        If WebPageFormList(I).FileName = FileName Then
                            FileFound = True
                            WebPageFormList(I).BringToFront
                        End If
                    End If
                Next
            End If

            If FileFound = False Then
                Dim FormNo As Integer = OpenNewWebPage()
                WebPageFormList(FormNo).FileName = FileName
                WebPageFormList(FormNo).OpenDocument
                WebPageFormList(FormNo).BringToFront
            End If
        End If
    End Sub

    'END Open a Web Page -------------------------------------------------------------------------------------------


    'Open and Close Projects =======================================================================================

    Public Sub OpenProjectAtRelativePath(ByVal RelativePath As String, ByVal ConnectionName As String)
        'Open the Project at the specified Relative Path using the specified Connection Name.

        Dim ProjectPath As String
        If RelativePath.StartsWith("\") Then
            ProjectPath = Project.Path & RelativePath
            client.StartProjectAtPath(ProjectPath, ConnectionName)
        Else
            ProjectPath = Project.Path & "\" & RelativePath
            client.StartProjectAtPath(ProjectPath, ConnectionName)
        End If
    End Sub

    Public Sub CheckOpenProjectAtRelativePath(ByVal RelativePath As String, ByVal ConnectionName As String)
        'Check if the project at the specified Relative Path is open.
        'Open it if it is not already open.
        'Open the Project at the specified Relative Path using the specified Connection Name.

        Dim ProjectPath As String
        If RelativePath.StartsWith("\") Then
            ProjectPath = Project.Path & RelativePath
            If client.ProjectOpen(ProjectPath) Then
                'Project is already open.
            Else
                client.StartProjectAtPath(ProjectPath, ConnectionName)
            End If
        Else
            ProjectPath = Project.Path & "\" & RelativePath
            If client.ProjectOpen(ProjectPath) Then
                'Project is already open.
            Else
                client.StartProjectAtPath(ProjectPath, ConnectionName)
            End If
        End If
    End Sub

    Public Sub OpenProjectAtProNetPath(ByVal RelativePath As String, ByVal ConnectionName As String)
        'Open the Project at the specified Path (relative to the Project Network Path) using the specified Connection Name.

        Dim ProjectPath As String
        If RelativePath.StartsWith("\") Then
            If Project.ParameterExists("ProNetPath") Then
                ProjectPath = Project.GetParameter("ProNetPath") & RelativePath
                client.StartProjectAtPath(ProjectPath, ConnectionName)
            Else
                Message.AddWarning("The Project Network Path is not known." & vbCrLf)
            End If
        Else
            If Project.ParameterExists("ProNetPath") Then
                ProjectPath = Project.GetParameter("ProNetPath") & "\" & RelativePath
                client.StartProjectAtPath(ProjectPath, ConnectionName)
            Else
                Message.AddWarning("The Project Network Path is not known." & vbCrLf)
            End If
        End If
    End Sub

    Public Sub CheckOpenProjectAtProNetPath(ByVal RelativePath As String, ByVal ConnectionName As String)
        'Check if the project at the specified Path (relative to the Project Network Path) is open.
        'Open it if it is not already open.
        'Open the Project at the specified Path using the specified Connection Name.

        Dim ProjectPath As String
        If RelativePath.StartsWith("\") Then
            If Project.ParameterExists("ProNetPath") Then
                ProjectPath = Project.GetParameter("ProNetPath") & RelativePath
                'client.StartProjectAtPath(ProjectPath, ConnectionName)
                If client.ProjectOpen(ProjectPath) Then
                    'Project is already open.
                Else
                    client.StartProjectAtPath(ProjectPath, ConnectionName)
                End If
            Else
                Message.AddWarning("The Project Network Path is not known." & vbCrLf)
            End If
        Else
            If Project.ParameterExists("ProNetPath") Then
                ProjectPath = Project.GetParameter("ProNetPath") & "\" & RelativePath
                'client.StartProjectAtPath(ProjectPath, ConnectionName)
                If client.ProjectOpen(ProjectPath) Then
                    'Project is already open.
                Else
                    client.StartProjectAtPath(ProjectPath, ConnectionName)
                End If
            Else
                Message.AddWarning("The Project Network Path is not known." & vbCrLf)
            End If
        End If
    End Sub

    Public Sub CloseProjectAtConnection(ByVal ProNetName As String, ByVal ConnectionName As String)
        'Close the Project at the specified connection.

        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                'Create the XML instructions to close the application at the connection.
                Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class

                'NOTE: No reply expected. No need to provide the following client information(?)
                'Dim clientConnName As New XElement("ClientConnectionName", Me.ConnectionName)
                'xmessage.Add(clientConnName)

                Dim command As New XElement("Command", "Close")
                xmessage.Add(command)
                doc.Add(xmessage)

                'Show the message sent:
                Message.XAddText("Message sent to: [" & ProNetName & "]." & ConnectionName & ":" & vbCrLf, "XmlSentNotice")
                Message.XAddXml(doc.ToString)
                Message.XAddText(vbCrLf, "Normal") 'Add extra line

                client.SendMessage(ProNetName, ConnectionName, doc.ToString)
            End If
        End If
    End Sub

    'END Open and Close Projects -----------------------------------------------------------------------------------


    'System Methods ================================================================================================

    Public Sub SaveHtmlSettings(ByVal xSettings As String, ByVal FileName As String)
        'Save the Html settings for a web page.

        'Convert the XSettings to XML format:
        Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
        Dim XDocSettings As New System.Xml.Linq.XDocument

        Try
            XDocSettings = System.Xml.Linq.XDocument.Parse(XmlHeader & vbCrLf & xSettings)
        Catch ex As Exception
            Message.AddWarning("Error saving HTML settings file. " & ex.Message & vbCrLf)
        End Try

        Project.SaveXmlData(FileName, XDocSettings)
    End Sub

    Public Sub RestoreHtmlSettings()
        'Restore the Html settings for a web page.

        Dim SettingsFileName As String = WorkflowFileName & "Settings"
        Dim XDocSettings As New System.Xml.Linq.XDocument
        Project.ReadXmlData(SettingsFileName, XDocSettings)

        If XDocSettings Is Nothing Then
            'Message.Add("No HTML Settings file : " & SettingsFileName & vbCrLf)
        Else
            Dim XSettings As New System.Xml.XmlDocument
            Try
                XSettings.LoadXml(XDocSettings.ToString)
                'Run the Settings file:
                XSeq.RunXSequence(XSettings, Status)
            Catch ex As Exception
                Message.AddWarning("Error restoring HTML settings. " & ex.Message & vbCrLf)
            End Try
        End If
    End Sub

    Public Sub RestoreSetting(ByVal FormName As String, ByVal ItemName As String, ByVal ItemValue As String)
        'Restore the setting value with the specified Form Name and Item Name.
        Me.WebBrowser1.Document.InvokeScript("RestoreSetting", New String() {FormName, ItemName, ItemValue})
    End Sub

    Public Sub RestoreOption(ByVal SelectId As String, ByVal OptionText As String)
        'Restore the Option text in the Select control with the Id SelectId.
        Me.WebBrowser1.Document.InvokeScript("RestoreOption", New String() {SelectId, OptionText})
    End Sub

    Private Sub SaveWebPageSettings()
        'Call the SaveSettings JavaScript function:
        Try
            Me.WebBrowser1.Document.InvokeScript("SaveSettings")
        Catch ex As Exception
            Message.AddWarning("Web page settings not saved: " & ex.Message & vbCrLf)
        End Try
    End Sub

    'END System Methods --------------------------------------------------------------------------------------------


    'Legacy Code (These methods should no longer be used) ==========================================================

    Public Sub JSMethodTest1()
        'Test method that is called from JavaScript.
        Message.Add("JSMethodTest1 called OK." & vbCrLf)
    End Sub

    Public Sub JSMethodTest2(ByVal Var1 As String, ByVal Var2 As String)
        'Test method that is called from JavaScript.
        Message.Add("Var1 = " & Var1 & " Var2 = " & Var2 & vbCrLf)
    End Sub

    Public Sub JSDisplayXml(ByRef XDoc As XDocument)
        Message.Add(XDoc.ToString & vbCrLf & vbCrLf)
    End Sub

    Public Sub ShowMessage(ByVal Msg As String)
        Message.Add(Msg)
    End Sub

    Public Sub AddText(ByVal Msg As String, ByVal TextType As String)
        Message.AddText(Msg, TextType)
    End Sub

    'END Legacy Code -----------------------------------------------------------------------------------------------


#End Region 'Methods Called by JavaScript -------------------------------------------------------------------------------------------------------------------------------



    Private Sub ApplicationInfo_UpdateExePath() Handles ApplicationInfo.UpdateExePath
        'Update the Executable Path.
        ApplicationInfo.ExecutablePath = Application.ExecutablePath
    End Sub

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

    Private Sub txtDataLocationPath_LostFocus(sender As Object, e As EventArgs) Handles txtDataPath.LostFocus
        'The Data Location Path has been changed.
        Project.DataLocn.Path = txtDataPath.Text
    End Sub

#Region " Display Messages"

    Private Sub AreaOfUse_ErrorMessage(Message As String) Handles AreaOfUse.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub AreaOfUse_Message(Message As String) Handles AreaOfUse.Message
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub btnAppInfo_Click(sender As Object, e As EventArgs) Handles btnAppInfo.Click
        ApplicationInfo.ShowInfo()
    End Sub

    Private Sub CoordOpMethod_ErrorMessage(Message As String) Handles CoordOpMethod.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub CoordOpMethod_Message(Message As String) Handles CoordOpMethod.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub CoordinateSystem_ErrorMessage(Message As String) Handles CoordinateSystem.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub CoordinateSystem_Message(Message As String) Handles CoordinateSystem.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub Datum_ErrorMessage(Message As String) Handles Datum.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub Datum_Message(Message As String) Handles Datum.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub Transformation_ErrorMessage(Message As String) Handles Transformation.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub Transformation_Message(Message As String) Handles Transformation.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub GeodeticDatum_ErrorMessage(Message As String) Handles GeodeticDatum.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub GeodeticDatum_Message(Message As String) Handles GeodeticDatum.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub CoordRefSystem_ErrorMessage(Message As String) Handles CoordRefSystem.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub CoordRefSystem_Message(Message As String) Handles CoordRefSystem.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub Geographic2DCRS_ErrorMessage(Message As String) Handles Geographic2DCRS.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub Geographic2DCRS_Message(Message As String) Handles Geographic2DCRS.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub ProjectedCRS_ErrorMessage(Message As String) Handles ProjectedCRS.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub ProjectedCRS_Message(Message As String) Handles ProjectedCRS.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub Project_ErrorMessage(Message As String) Handles Project.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub Project_Message(Message As String) Handles Project.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub UnitOfMeasure_ErrorMessage(Message As String) Handles UnitOfMeasure.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub UnitOfMeasure_Message(Message As String) Handles UnitOfMeasure.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub PrimeMeridian_ErrorMessage(Message As String) Handles PrimeMeridian.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub PrimeMeridian_Message(Message As String) Handles PrimeMeridian.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub Ellipsoid_ErrorMessage(Message As String) Handles Ellipsoid.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub Ellipsoid_Message(Message As String) Handles Ellipsoid.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub Projection_ErrorMessage(Message As String) Handles Projection.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub Projection_Message(Message As String) Handles Projection.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub CompoundCRS_ErrorMessage(Message As String) Handles CompoundCRS.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub CompoundCRS_Message(Message As String) Handles CompoundCRS.Message
        Me.Message.Add(Message)
    End Sub

#End Region 'Display Messages

    Private Sub btnProject_Click(sender As Object, e As EventArgs) Handles btnProject.Click
        Project.SelectProject() 'This opens the Project Form - A list of projects is displayed - Any of these can be selected.
    End Sub

    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter
        'Update the current duration:

        'txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
        '                          Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
        '                          Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
        '                          Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)

        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & "d:" &
                                   Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & "h:" &
                                   Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & "m:" &
                                   Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c) & "s"

        Timer2.Interval = 5000 '5 seconds
        Timer2.Enabled = True
        Timer2.Start()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'Update the current duration:

        'txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
        '                          Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
        '                          Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
        '                          Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)

        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & "d:" &
                           Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & "h:" &
                           Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & "m:" &
                           Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c) & "s"
    End Sub

    Private Sub TabPage1_Leave(sender As Object, e As EventArgs) Handles TabPage1.Leave
        Timer2.Enabled = False
    End Sub

    Private Sub btnParameters_Click(sender As Object, e As EventArgs) Handles btnParameters.Click
        Project.ShowParameters()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Add the current project to the Message Service list.

        If Project.ParentProjectName <> "" Then
            Message.AddWarning("This project has a parent: " & Project.ParentProjectName & vbCrLf)
            Message.AddWarning("Child projects can not be added to the list." & vbCrLf)
            Exit Sub
        End If

        If ConnectedToComNet = False Then
            Message.AddWarning("The application is not connected to the Message Service." & vbCrLf)
        Else 'Connected to the Message Service (ComNet).
            If IsNothing(client) Then
                Message.Add("No client connection available!" & vbCrLf)
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("Client state is faulted. Message not sent!" & vbCrLf)
                Else
                    'Construct the XMessage to send to AppNet:
                    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    Dim projectInfo As New XElement("ProjectInfo")

                    'Dim Path As New XElement("Path", Me.Project.Path)
                    Dim Path As New XElement("Path", Project.Path)
                    projectInfo.Add(Path)
                    xmessage.Add(projectInfo)
                    doc.Add(xmessage)

                    'Show the message sent to AppNet:
                    Message.XAddText("Message sent to " & "Message Service" & ":" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(doc.ToString)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    client.SendMessage("", "MessageService", doc.ToString) 'UPDATED 2Feb19
                End If
            End If
        End If
    End Sub

    Private Sub btnOpenProject_Click(sender As Object, e As EventArgs) Handles btnOpenProject.Click
        If Project.Type = ADVL_Utilities_Library_1.Project.Types.Archive Then
            If IsNothing(ProjectArchive) Then
                ProjectArchive = New frmArchive
                ProjectArchive.Show()
                ProjectArchive.Title = "Project Archive"
                ProjectArchive.Path = Project.Path
            Else
                ProjectArchive.Show()
                ProjectArchive.BringToFront()
            End If
        Else
            Process.Start(Project.Path)
        End If
    End Sub

    Private Sub ProjectArchive_FormClosed(sender As Object, e As FormClosedEventArgs) Handles ProjectArchive.FormClosed
        ProjectArchive = Nothing
    End Sub

    Private Sub btnOpenSettings_Click(sender As Object, e As EventArgs) Handles btnOpenSettings.Click
        If Project.SettingsLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory Then
            Process.Start(Project.SettingsLocn.Path)
        ElseIf Project.SettingsLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive Then
            If IsNothing(SettingsArchive) Then
                SettingsArchive = New frmArchive
                SettingsArchive.Show()
                SettingsArchive.Title = "Settings Archive"
                SettingsArchive.Path = Project.SettingsLocn.Path
            Else
                SettingsArchive.Show()
                SettingsArchive.BringToFront()
            End If
        End If
    End Sub

    Private Sub SettingsArchive_FormClosed(sender As Object, e As FormClosedEventArgs) Handles SettingsArchive.FormClosed
        SettingsArchive = Nothing
    End Sub

    Private Sub btnOpenData_Click(sender As Object, e As EventArgs) Handles btnOpenData.Click
        If Project.DataLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory Then
            Process.Start(Project.DataLocn.Path)
        ElseIf Project.DataLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive Then
            If IsNothing(DataArchive) Then
                DataArchive = New frmArchive
                DataArchive.Show()
                DataArchive.Title = "Data Archive"
                DataArchive.Path = Project.DataLocn.Path
            Else
                DataArchive.Show()
                DataArchive.BringToFront()
            End If
        End If
    End Sub

    Private Sub DataArchive_FormClosed(sender As Object, e As FormClosedEventArgs) Handles DataArchive.FormClosed
        DataArchive = Nothing
    End Sub

    Private Sub btnOpenSystem_Click(sender As Object, e As EventArgs) Handles btnOpenSystem.Click
        If Project.SystemLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory Then
            Process.Start(Project.SystemLocn.Path)
        ElseIf Project.SystemLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive Then
            If IsNothing(SystemArchive) Then
                SystemArchive = New frmArchive
                SystemArchive.Show()
                SystemArchive.Title = "System Archive"
                SystemArchive.Path = Project.SystemLocn.Path
            Else
                SystemArchive.Show()
                SystemArchive.BringToFront()
            End If
        End If
    End Sub

    Private Sub SystemArchive_FormClosed(sender As Object, e As FormClosedEventArgs) Handles SystemArchive.FormClosed
        SystemArchive = Nothing
    End Sub

    Private Sub btnOpenAppDir_Click(sender As Object, e As EventArgs) Handles btnOpenAppDir.Click
        Process.Start(ApplicationInfo.ApplicationDir)
    End Sub

    Private Sub btnShowProjectInfo_Click(sender As Object, e As EventArgs) Handles btnShowProjectInfo.Click
        'Show the current Project information:
        Message.Add("--------------------------------------------------------------------------------------" & vbCrLf)
        Message.Add("Project ------------------------ " & vbCrLf)
        Message.Add("   Name: " & Project.Name & vbCrLf)
        Message.Add("   Type: " & Project.Type.ToString & vbCrLf)
        Message.Add("   Description: " & Project.Description & vbCrLf)
        Message.Add("   Creation Date: " & Project.CreationDate & vbCrLf)
        Message.Add("   ID: " & Project.ID & vbCrLf)
        Message.Add("   Relative Path: " & Project.RelativePath & vbCrLf)
        Message.Add("   Path: " & Project.Path & vbCrLf & vbCrLf)

        Message.Add("Parent Project ----------------- " & vbCrLf)
        Message.Add("   Name: " & Project.ParentProjectName & vbCrLf)
        Message.Add("   Path: " & Project.ParentProjectPath & vbCrLf)

        Message.Add("Application -------------------- " & vbCrLf)
        Message.Add("   Name: " & Project.Application.Name & vbCrLf)
        Message.Add("   Description: " & Project.Application.Description & vbCrLf)
        Message.Add("   Path: " & Project.ApplicationDir & vbCrLf)

        Message.Add("Settings ----------------------- " & vbCrLf)
        Message.Add("   Settings Relative Location Type: " & Project.SettingsRelLocn.Type.ToString & vbCrLf)
        Message.Add("   Settings Relative Location Path: " & Project.SettingsRelLocn.Path & vbCrLf)
        Message.Add("   Settings Location Type: " & Project.SettingsLocn.Type.ToString & vbCrLf)
        Message.Add("   Settings Location Path: " & Project.SettingsLocn.Path & vbCrLf)

        Message.Add("Data --------------------------- " & vbCrLf)
        Message.Add("   Data Relative Location Type: " & Project.DataRelLocn.Type.ToString & vbCrLf)
        Message.Add("   Data Relative Location Path: " & Project.DataRelLocn.Path & vbCrLf)
        Message.Add("   Data Location Type: " & Project.DataLocn.Type.ToString & vbCrLf)
        Message.Add("   Data Location Path: " & Project.DataLocn.Path & vbCrLf)

        Message.Add("System ------------------------- " & vbCrLf)
        Message.Add("   System Relative Location Type: " & Project.SystemRelLocn.Type.ToString & vbCrLf)
        Message.Add("   System Relative Location Path: " & Project.SystemRelLocn.Path & vbCrLf)
        Message.Add("   System Location Type: " & Project.SystemLocn.Type.ToString & vbCrLf)
        Message.Add("   System Location Path: " & Project.SystemLocn.Path & vbCrLf)
        Message.Add("======================================================================================" & vbCrLf)

    End Sub

    Private Sub btnOpenParentDir_Click(sender As Object, e As EventArgs) Handles btnOpenParentDir.Click
        'Open the Parent directory of the selected project.
        Dim ParentDir As String = System.IO.Directory.GetParent(Project.Path).FullName
        If System.IO.Directory.Exists(ParentDir) Then
            Process.Start(ParentDir)
        Else
            Message.AddWarning("The parent directory was not found: " & ParentDir & vbCrLf)
        End If
    End Sub

    Private Sub btnCreateArchive_Click(sender As Object, e As EventArgs) Handles btnCreateArchive.Click
        'Create a Project Archive file.
        If Project.Type = ADVL_Utilities_Library_1.Project.Types.Archive Then
            Message.Add("The Project is an Archive type. It is already in an archived format." & vbCrLf)

        Else
            'The project is contained in the directory Project.Path.
            'This directory and contents will be saved in a zip file in the parent directory with the same name but with extension .AdvlArchive.

            Dim ParentDir As String = System.IO.Directory.GetParent(Project.Path).FullName
            Dim ProjectArchiveName As String = System.IO.Path.GetFileName(Project.Path) & ".AdvlArchive"

            If My.Computer.FileSystem.FileExists(ParentDir & "\" & ProjectArchiveName) Then 'The Project Archive file already exists.
                Message.Add("The Project Archive file already exists: " & ParentDir & "\" & ProjectArchiveName & vbCrLf)
            Else 'The Project Archive file does not exist. OK to create the Archive.
                System.IO.Compression.ZipFile.CreateFromDirectory(Project.Path, ParentDir & "\" & ProjectArchiveName)

                'Remove all Lock files:
                Dim Zip As System.IO.Compression.ZipArchive
                Zip = System.IO.Compression.ZipFile.Open(ParentDir & "\" & ProjectArchiveName, IO.Compression.ZipArchiveMode.Update)
                Dim DeleteList As New List(Of String) 'List of entry names to delete
                Dim myEntry As System.IO.Compression.ZipArchiveEntry
                For Each entry As System.IO.Compression.ZipArchiveEntry In Zip.Entries
                    If entry.Name = "Project.Lock" Then
                        DeleteList.Add(entry.FullName)
                    End If
                Next
                For Each item In DeleteList
                    myEntry = Zip.GetEntry(item)
                    myEntry.Delete()
                Next
                Zip.Dispose()

                Message.Add("Project Archive file created: " & ParentDir & "\" & ProjectArchiveName & vbCrLf)
            End If
        End If
    End Sub

    Private Sub btnOpenArchive_Click(sender As Object, e As EventArgs) Handles btnOpenArchive.Click
        'Open a Project Archive file.

        'Use the OpenFileDialog to look for an .AdvlArchive file.      
        OpenFileDialog1.Title = "Select an Archived Project File"
        OpenFileDialog1.InitialDirectory = System.IO.Directory.GetParent(Project.Path).FullName 'Start looking in the ParentDir.
        OpenFileDialog1.Filter = "Archived Project|*.AdvlArchive"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim FileName As String = OpenFileDialog1.FileName
            OpenArchivedProject(FileName)
        End If
    End Sub

    Private Sub OpenArchivedProject(ByVal FilePath As String)
        'Open the archived project at the specified path.

        Dim Zip As System.IO.Compression.ZipArchive
        Try
            Zip = System.IO.Compression.ZipFile.OpenRead(FilePath)

            Dim Entry As System.IO.Compression.ZipArchiveEntry = Zip.GetEntry("Project_Info_ADVL_2.xml")
            If IsNothing(Entry) Then
                Message.AddWarning("The file is not an Archived Andorville Project." & vbCrLf)
                'Check if it is an Archive project type with a .AdvlProject extension.
                'NOTE: These are already zip files so no need to archive.

            Else
                Message.Add("The file is an Archived Andorville Project." & vbCrLf)
                Dim ParentDir As String = System.IO.Directory.GetParent(FilePath).FullName
                Dim ProjectName As String = System.IO.Path.GetFileNameWithoutExtension(FilePath)
                Message.Add("The Project will be expanded in the directory: " & ParentDir & vbCrLf)
                Message.Add("The Project name will be: " & ProjectName & vbCrLf)
                Zip.Dispose()
                If System.IO.Directory.Exists(ParentDir & "\" & ProjectName) Then
                    Message.AddWarning("The Project already exists: " & ParentDir & "\" & ProjectName & vbCrLf)
                Else
                    System.IO.Compression.ZipFile.ExtractToDirectory(FilePath, ParentDir & "\" & ProjectName) 'Extract the project from the archive                   
                    Project.AddProjectToList(ParentDir & "\" & ProjectName)
                    'Open the new project                 
                    CloseProject()  'Close the current project
                    Project.SelectProject(ParentDir & "\" & ProjectName) 'Select the project at the specifed path.
                    OpenProject() 'Open the selected project.
                End If
            End If
        Catch ex As Exception
            Message.AddWarning("Error opening Archived Andorville Project: " & ex.Message & vbCrLf)
        End Try
    End Sub


    Private Sub TabPage1_DragEnter(sender As Object, e As DragEventArgs) Handles TabPage1.DragEnter
        'DragEnter: An object has been dragged into TabPage2 - Project Information tab.
        'This code is required to get the link to the item(s) being dragged into Project Information:
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Link
        End If
    End Sub

    Private Sub TabPage1_DragDrop(sender As Object, e As DragEventArgs) Handles TabPage1.DragDrop
        'A file has been dropped into the Project Information tab.

        Dim Path As String()
        Path = e.Data.GetData(DataFormats.FileDrop)
        Dim I As Integer

        If Path.Count > 0 Then
            If Path.Count > 1 Then
                Message.AddWarning("More than one file has been dropped into the Project Information tab. Only the first one will be opened." & vbCrLf)
            End If

            Try
                Dim ArchivedProjectPath As String = Path(0)
                If ArchivedProjectPath.EndsWith(".AdvlArchive") Then
                    Message.Add("The archived project will be opened: " & vbCrLf & ArchivedProjectPath & vbCrLf)
                    OpenArchivedProject(ArchivedProjectPath)
                Else
                    Message.Add("The dropped file is not an archived project: " & vbCrLf & ArchivedProjectPath & vbCrLf)
                End If
            Catch ex As Exception
                Message.AddWarning("Error opening dropped archived project. " & ex.Message & vbCrLf)
            End Try
        End If
    End Sub
    Private Sub Project_Closing() Handles Project.Closing
        'The current project is closing.
        CloseProject()
        'SaveFormSettings() 'Save the form settings - they are saved in the Project before is closes.
        'SaveProjectSettings() 'Update this subroutine if project settings need to be saved.
        'Project.Usage.SaveUsageInfo() 'Save the current project usage information.
        'Project.UnlockProject() 'Unlock the current project before it Is closed.
        'If ConnectedToComNet Then DisconnectFromComNet()
    End Sub

    Private Sub CloseProject()
        'Close the Project:
        SaveFormSettings() 'Save the form settings - they are saved in the Project before is closes.
        SaveProjectSettings() 'Update this subroutine if project settings need to be saved.
        Project.Usage.SaveUsageInfo() 'Save the current project usage information.
        Project.UnlockProject() 'Unlock the current project before it Is closed.
        If ConnectedToComNet Then DisconnectFromComNet() 'ADDED 9Apr20
    End Sub

    'Private Sub Project_ProjectSelected() Handles Project.ProjectSelected
    Private Sub Project_Selected() Handles Project.Selected
        'A new project has been selected.
        OpenProject()

        ''Message.Add("------------------------- A project has been selected --------------------------------------------------------------" & vbCrLf)

        ''Clear the parameter lists:
        ''Message.Add("Clearing the old coordinate parameter lists." & vbCrLf)
        'AreaOfUse.Clear()
        'UnitOfMeasure.Clear()
        'PrimeMeridian.Clear()
        'Ellipsoid.Clear()
        'Projection.Clear()
        'CoordOpMethod.Clear()
        'CoordRefSystem.Clear()
        'CoordinateSystem.Clear()
        'Datum.Clear()
        'Transformation.Clear()
        'GeodeticDatum.Clear()
        'Geographic2DCRS.Clear()
        'ProjectedCRS.Clear()

        'When a project is selected, initially only the settings location is specified.
        'The project information is read from the settings location to get the remaining information including the data location.

        'Read the Project Information file: -------------------------------------------------
        'Project.ReadProjectInfoFile()

        'Project.ReadParameters()
        'Project.ReadParentParameters()
        'If Project.ParentParameterExists("AppNetName") Then
        '    Project.AddParameter("AppNetName", Project.ParentParameter("AppNetName").Value, Project.ParentParameter("AppNetName").Description) 'AddParameter will update the parameter if it already exists.
        '    AppNetName = Project.Parameter("AppNetName").Value
        'Else
        '    AppNetName = Project.GetParameter("AppNetName")
        'End If

        'Project.ReadParameters()
        'Project.ReadParentParameters()
        'If Project.ParentParameterExists("ProNetName") Then
        '    Project.AddParameter("ProNetName", Project.ParentParameter("ProNetName").Value, Project.ParentParameter("ProNetName").Description) 'AddParameter will update the parameter if it already exists.
        '    ProNetName = Project.Parameter("ProNetName").Value
        'Else
        '    ProNetName = Project.GetParameter("ProNetName")
        'End If
        'If Project.ParentParameterExists("ProNetPath") Then 'Get the parent parameter value - it may have been updated.
        '    Project.AddParameter("ProNetPath", Project.ParentParameter("ProNetPath").Value, Project.ParentParameter("ProNetPath").Description) 'AddParameter will update the parameter if it already exists.
        '    ProNetPath = Project.Parameter("ProNetPath").Value
        'Else
        '    ProNetPath = Project.GetParameter("ProNetPath") 'If the parameter does not exist, the value is set to ""
        'End If
        'Project.SaveParameters() 'These should be saved now - child projects look for parent parameters in the parameter file.

        'Project.LockProject() 'Lock the project while it is open in this application.

        ''Set the project start time. This is used to track project usage.
        'Project.Usage.StartTime = Now

        'ApplicationInfo.SettingsLocn = Project.SettingsLocn

        ''Set up Message object:
        'Message.ApplicationName = ApplicationInfo.Name
        'Message.SettingsLocn = Project.SettingsLocn
        'Message.Show() 'Added 18May19

        'RestoreProjectSettings()

        'ShowProjectInfo()

        ''Update the project display.

        '''Show the project information:
        ''txtProjectName.Text = Project.Name
        ''txtProjectDescription.Text = Project.Description
        ''Select Case Project.Type
        ''    Case ADVL_Utilities_Library_1.Project.Types.Directory
        ''        txtProjectType.Text = "Directory"
        ''    Case ADVL_Utilities_Library_1.Project.Types.Archive
        ''        txtProjectType.Text = "Archive"
        ''    Case ADVL_Utilities_Library_1.Project.Types.Hybrid
        ''        txtProjectType.Text = "Hybrid"
        ''    Case ADVL_Utilities_Library_1.Project.Types.None
        ''        txtProjectType.Text = "None"
        ''End Select
        ''txtCreationDate.Text = Format(Project.CreationDate, "d-MMM-yyyy H:mm:ss")
        ''txtLastUsed.Text = Format(Project.Usage.LastUsed, "d-MMM-yyyy H:mm:ss")
        ''Select Case Project.SettingsLocn.Type
        ''    Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
        ''        txtSettingsLocationType.Text = "Directory"
        ''    Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
        ''        txtSettingsLocationType.Text = "Archive"
        ''End Select
        ''txtSettingsPath.Text = Project.SettingsLocn.Path
        ''Select Case Project.DataLocn.Type
        ''    Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
        ''        txtDataLocationType.Text = "Directory"
        ''    Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
        ''        txtDataLocationType.Text = "Archive"
        ''End Select
        ''txtDataPath.Text = Project.DataLocn.Path

        ''Set up the location information for each list
        'AreaOfUse.FileLocation = Project.DataLocn
        'UnitOfMeasure.FileLocation = Project.DataLocn
        'PrimeMeridian.FileLocation = Project.DataLocn
        'Ellipsoid.FileLocation = Project.DataLocn
        'Projection.FileLocation = Project.DataLocn
        'CoordOpMethod.FileLocation = Project.DataLocn
        'CoordRefSystem.FileLocation = Project.DataLocn
        'CoordinateSystem.FileLocation = Project.DataLocn
        'Datum.FileLocation = Project.DataLocn
        'Transformation.FileLocation = Project.DataLocn
        'GeodeticDatum.FileLocation = Project.DataLocn
        'Geographic2DCRS.FileLocation = Project.DataLocn
        'ProjectedCRS.FileLocation = Project.DataLocn

        'If Project.ConnectOnOpen Then
        '    ConnectToComNet() 'The Project is set to connect when it is opened.
        'ElseIf ApplicationInfo.ConnectOnStartup Then
        '    ConnectToComNet() 'The Application is set to connect when it is started.
        'Else
        '    'Don't connect to ComNet.
        'End If

    End Sub

    Private Sub OpenProject()

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

        'Open the Project:
        RestoreFormSettings()
        Project.ReadProjectInfoFile()

        Project.ReadParameters()
        Project.ReadParentParameters()
        If Project.ParentParameterExists("ProNetName") Then
            Project.AddParameter("ProNetName", Project.ParentParameter("ProNetName").Value, Project.ParentParameter("ProNetName").Description) 'AddParameter will update the parameter if it already exists.
            ProNetName = Project.Parameter("ProNetName").Value
        Else
            ProNetName = Project.GetParameter("ProNetName")
        End If
        If Project.ParentParameterExists("ProNetPath") Then 'Get the parent parameter value - it may have been updated.
            Project.AddParameter("ProNetPath", Project.ParentParameter("ProNetPath").Value, Project.ParentParameter("ProNetPath").Description) 'AddParameter will update the parameter if it already exists.
            ProNetPath = Project.Parameter("ProNetPath").Value
        Else
            ProNetPath = Project.GetParameter("ProNetPath") 'If the parameter does not exist, the value is set to ""
        End If
        Project.SaveParameters() 'These should be saved now - child projects look for parent parameters in the parameter file.

        Project.LockProject() 'Lock the project while it is open in this application.

        Project.Usage.StartTime = Now

        ApplicationInfo.SettingsLocn = Project.SettingsLocn
        Message.SettingsLocn = Project.SettingsLocn
        Message.Show() 'Added 18May19

        'Restore the new project settings:
        RestoreProjectSettings() 'Update this subroutine if project settings need to be restored.

        ShowProjectInfo()

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
        Geographic2DCRS.FileLocation = Project.DataLocn
        ProjectedCRS.FileLocation = Project.DataLocn

        If Project.ConnectOnOpen Then
            ConnectToComNet() 'The Project is set to connect when it is opened.
        ElseIf ApplicationInfo.ConnectOnStartup Then
            ConnectToComNet() 'The Application is set to connect when it is started.
        Else
            'Don't connect to ComNet.
        End If
    End Sub

    Private Sub btnAndorville_Click(sender As Object, e As EventArgs) Handles btnAndorville.Click
        ApplicationInfo.ShowInfo()
    End Sub

#Region " Online/Offline code"

    Private Sub btnOnline_Click(sender As Object, e As EventArgs) Handles btnOnline.Click
        'Connect to or disconnect from the Message Exchange.
        If ConnectedToComNet = False Then
            ConnectToComNet()
        Else
            DisconnectFromComNet()
        End If
    End Sub

    Private Sub ConnectToComNet()
        'Connect to the Message Service. (ComNet)

        If IsNothing(client) Then
            client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
        End If

        'UPDATE 14 Feb 2021 - If the VS2019 version of the ADVL Network is running it may not detected by ComNetRunning()!
        'Check if the Message Service is running by trying to open a connection:
        Try
            client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 16) 'Temporarily set the send timeaout to 16 seconds (8 seconds is too short for a slow computer!)
            ConnectionName = ApplicationInfo.Name 'This name will be modified if it is already used in an existing connection.
            ConnectionName = client.Connect(ProNetName, ApplicationInfo.Name, ConnectionName, Project.Name, Project.Description, Project.Type, Project.Path, False, False)
            If ConnectionName <> "" Then
                Message.Add("Connected to the Andorville™ Network with Connection Name: [" & ProNetName & "]." & ConnectionName & vbCrLf)
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
                btnOnline.Text = "Online"
                btnOnline.ForeColor = Color.ForestGreen
                ConnectedToComNet = True
                SendApplicationInfo()
                SendProjectInfo()
                client.GetAdvlNetworkAppInfoAsync() 'Update the Exe Path in case it has changed. This path may be needed in the future to start the ComNet (Message Service).

                bgwComCheck.WorkerReportsProgress = True
                bgwComCheck.WorkerSupportsCancellation = True
                If bgwComCheck.IsBusy Then
                    'The ComCheck thread is already running.
                Else
                    bgwComCheck.RunWorkerAsync() 'Start the ComCheck thread.
                End If
                Exit Sub 'Connection made OK
            Else
                'Message.Add("Connection to the Andorville™ Network failed!" & vbCrLf)
                Message.Add("The Andorville™ Network was not found. Attempting to start it." & vbCrLf)
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
            End If
        Catch ex As System.TimeoutException
            Message.Add("Message Service Check Timeout error. Check if the Andorville™ Network (Message Service) is running." & vbCrLf)
            client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
            Message.Add("Attempting to start the Message Service." & vbCrLf)
        Catch ex As Exception
            Message.Add("Error message: " & ex.Message & vbCrLf)
            client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
            Message.Add("Attempting to start the Message Service." & vbCrLf)
        End Try
        'END UPDATE

        If ComNetRunning() Then
            'The Message Service is Running.
        Else 'The Message Service is NOT running'
            'Start the Andorville™ Network:
            If AdvlNetworkAppPath = "" Then
                Message.AddWarning("Andorville™ Network application path is unknown." & vbCrLf)
            Else
                If System.IO.File.Exists(AdvlNetworkExePath) Then 'OK to start the Message Service application:
                    Shell(Chr(34) & AdvlNetworkExePath & Chr(34), AppWinStyle.NormalFocus) 'Start Message Service application with no argument
                Else
                    'Incorrect Message Service Executable path.
                    Message.AddWarning("Andorville™ Network exe file not found. Service not started." & vbCrLf)
                End If
            End If
        End If

        'Try to fix a faulted client state:
        If client.State = ServiceModel.CommunicationState.Faulted Then
            client = Nothing
            client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
        End If

        If client.State = ServiceModel.CommunicationState.Faulted Then
            Message.AddWarning("Client state is faulted. Connection not made!" & vbCrLf)
        Else
            Try
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 16) 'Temporarily set the send timeaout to 16 seconds (8 seconds is too short for a slow computer!)

                ConnectionName = ApplicationInfo.Name 'This name will be modified if it is already used in an existing connection.
                ConnectionName = client.Connect(ProNetName, ApplicationInfo.Name, ConnectionName, Project.Name, Project.Description, Project.Type, Project.Path, False, False)

                If ConnectionName <> "" Then
                    Message.Add("Connected to the Andorville™ Network with Connection Name: [" & ProNetName & "]." & ConnectionName & vbCrLf)
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                    btnOnline.Text = "Online"
                    btnOnline.ForeColor = Color.ForestGreen
                    ConnectedToComNet = True
                    SendApplicationInfo()
                    SendProjectInfo()
                    client.GetAdvlNetworkAppInfoAsync() 'Update the Exe Path in case it has changed. This path may be needed in the future to start the ComNet (Message Service).

                    bgwComCheck.WorkerReportsProgress = True
                    bgwComCheck.WorkerSupportsCancellation = True
                    If bgwComCheck.IsBusy Then
                        'The ComCheck thread is already running.
                    Else
                        bgwComCheck.RunWorkerAsync() 'Start the ComCheck thread.
                    End If

                Else
                    Message.Add("Connection to the Andorville™ Network failed!" & vbCrLf)
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                End If
            Catch ex As System.TimeoutException
                Message.Add("Timeout error. Check if the Andorville™ Network (Message Service) is running." & vbCrLf)
            Catch ex As Exception
                Message.Add("Error message: " & ex.Message & vbCrLf)
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
            End Try
        End If
    End Sub

    Private Sub ConnectToComNet(ByVal ConnName As String)
        'Connect to the Application Network with the connection name ConnName.

        'UPDATE 14 Feb 2021 - If the VS2019 version of the ADVL Network is running it may not be detected by ComNetRunning()!
        'Check if the Message Service is running by trying to open a connection:

        If IsNothing(client) Then
            client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
        End If

        Try
            client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 16) 'Temporarily set the send timeaout to 16 seconds (8 seconds is too short for a slow computer!)
            ConnectionName = ConnName 'This name will be modified if it is already used in an existing connection.
            ConnectionName = client.Connect(ProNetName, ApplicationInfo.Name, ConnectionName, Project.Name, Project.Description, Project.Type, Project.Path, False, False)
            If ConnectionName <> "" Then
                Message.Add("Connected to the Andorville™ Network with Connection Name: [" & ProNetName & "]." & ConnectionName & vbCrLf)
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
                btnOnline.Text = "Online"
                btnOnline.ForeColor = Color.ForestGreen
                ConnectedToComNet = True
                SendApplicationInfo()
                SendProjectInfo()
                client.GetAdvlNetworkAppInfoAsync() 'Update the Exe Path in case it has changed. This path may be needed in the future to start the ComNet (Message Service).

                bgwComCheck.WorkerReportsProgress = True
                bgwComCheck.WorkerSupportsCancellation = True
                If bgwComCheck.IsBusy Then
                    'The ComCheck thread is already running.
                Else
                    bgwComCheck.RunWorkerAsync() 'Start the ComCheck thread.
                End If
                Exit Sub 'Connection made OK
            Else
                'Message.Add("Connection to the Andorville™ Network failed!" & vbCrLf)
                Message.Add("The Andorville™ Network was not found. Attempting to start it." & vbCrLf)
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
            End If
        Catch ex As System.TimeoutException
            Message.Add("Message Service Check Timeout error. Check if the Andorville™ Network (Message Service) is running." & vbCrLf)
            client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
            Message.Add("Attempting to start the Message Service." & vbCrLf)
        Catch ex As Exception
            Message.Add("Error message: " & ex.Message & vbCrLf)
            client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
            Message.Add("Attempting to start the Message Service." & vbCrLf)
        End Try
        'END UPDATE

        If ConnectedToComNet = False Then
            'Dim Result As Boolean

            If IsNothing(client) Then
                client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
            End If

            'Try to fix a faulted client state:
            If client.State = ServiceModel.CommunicationState.Faulted Then
                client = Nothing
                client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
            End If

            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.AddWarning("client state is faulted. Connection not made!" & vbCrLf)
            Else
                Try
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 16) 'Temporarily set the send timeaout to 16 seconds (8 seconds is too short for a slow computer!)
                    ConnectionName = ConnName 'This name will be modified if it is already used in an existing connection.
                    ConnectionName = client.Connect(ProNetName, ApplicationInfo.Name, ConnectionName, Project.Name, Project.Description, Project.Type, Project.Path, False, False)

                    If ConnectionName <> "" Then
                        Message.Add("Connected to the Andorville™ Network with Connection Name: [" & ProNetName & "]." & ConnectionName & vbCrLf)
                        client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                        btnOnline.Text = "Online"
                        btnOnline.ForeColor = Color.ForestGreen
                        ConnectedToComNet = True
                        SendApplicationInfo()
                        SendProjectInfo()
                        client.GetAdvlNetworkAppInfoAsync() 'Update the Exe Path in case it has changed. This path may be needed in the future to start the ComNet (Message Service).

                        bgwComCheck.WorkerReportsProgress = True
                        bgwComCheck.WorkerSupportsCancellation = True
                        If bgwComCheck.IsBusy Then
                            'The ComCheck thread is already running.
                        Else
                            bgwComCheck.RunWorkerAsync() 'Start the ComCheck thread.
                        End If

                    Else
                        Message.Add("Connection to the Andorville™ Network failed!" & vbCrLf)
                        client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                    End If
                Catch ex As System.TimeoutException
                    Message.Add("Timeout error. Check if the Andorville™ Network (Message Service) is running." & vbCrLf)
                Catch ex As Exception
                    Message.Add("Error message: " & ex.Message & vbCrLf)
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                End Try
            End If
        Else
            Message.AddWarning("Already connected to the Andorville™ Network (Message Service)." & vbCrLf)
        End If
    End Sub

    Private Sub DisconnectFromComNet()
        'Disconnect from the Message Exchange.

        If ConnectedToComNet = True Then
            If IsNothing(client) Then
                'Message.Add("Already disconnected from the Communication Network." & vbCrLf)
                Message.Add("Already disconnected from the Andorville™ Network (Message Service)." & vbCrLf)
                btnOnline.Text = "Offline"
                btnOnline.ForeColor = Color.Red
                ConnectedToComNet = False
                ConnectionName = ""
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("client state is faulted." & vbCrLf)
                Else
                    Try
                        'client.Disconnect(AppNetName, ConnectionName)
                        client.Disconnect(ProNetName, ConnectionName)
                        btnOnline.Text = "Offline"
                        btnOnline.ForeColor = Color.Red
                        ConnectedToComNet = False
                        ConnectionName = ""
                        'Message.Add("Disconnected from the Communication Network." & vbCrLf)
                        Message.Add("Disconnected from the Andorville™ Network (Message Service)." & vbCrLf)

                        If bgwComCheck.IsBusy Then
                            bgwComCheck.CancelAsync()
                        End If

                    Catch ex As Exception
                        'Message.AddWarning("Error disconnecting from Communication Network: " & ex.Message & vbCrLf)
                        Message.AddWarning("Error disconnecting from Andorville™ Network (Message Service): " & ex.Message & vbCrLf)
                    End Try
                End If
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

                'Create the XML instructions to send application information.
                Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                Dim applicationInfo As New XElement("ApplicationInfo")
                Dim name As New XElement("Name", Me.ApplicationInfo.Name)
                applicationInfo.Add(name)

                Dim text As New XElement("Text", "Coordinates")
                applicationInfo.Add(text)

                Dim exePath As New XElement("ExecutablePath", Me.ApplicationInfo.ExecutablePath)
                applicationInfo.Add(exePath)

                Dim directory As New XElement("Directory", Me.ApplicationInfo.ApplicationDir)
                applicationInfo.Add(directory)
                Dim description As New XElement("Description", Me.ApplicationInfo.Description)
                applicationInfo.Add(description)
                xmessage.Add(applicationInfo)
                doc.Add(xmessage)

                'Show the message sent to AppNet:
                Message.XAddText("Message sent to " & "Message Service" & ":" & vbCrLf, "XmlSentNotice")
                Message.XAddXml(doc.ToString)
                Message.XAddText(vbCrLf, "Normal") 'Add extra line

                client.SendMessage("", "MessageService", doc.ToString)
            End If
        End If
    End Sub

    Private Sub SendProjectInfo()
        'Send the project information to the Network application.

        If ConnectedToComNet = False Then
            Message.AddWarning("The application is not connected to the Message Service." & vbCrLf)
        Else 'Connected to the Message Service (ComNet).
            If IsNothing(client) Then
                Message.Add("No client connection available!" & vbCrLf)
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("Client state is faulted. Message not sent!" & vbCrLf)
                Else
                    'Construct the XMessage to send to AppNet:
                    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    Dim projectInfo As New XElement("ProjectInfo")

                    Dim Path As New XElement("Path", Project.Path)
                    projectInfo.Add(Path)
                    xmessage.Add(projectInfo)
                    doc.Add(xmessage)

                    'Show the message sent to the Message Service:
                    Message.XAddText("Message sent to " & "Message Service" & ":" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(doc.ToString)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    client.SendMessage("", "MessageService", doc.ToString)
                End If
            End If
        End If
    End Sub

    Public Sub SendProjectInfo(ByVal ProjectPath As String)
        'Send the project information to the Network application.
        'This version of SendProjectInfo uses the ProjectPath argument.

        If ConnectedToComNet = False Then
            Message.AddWarning("The application is not connected to the Message Service." & vbCrLf)
        Else 'Connected to the Message Service (ComNet).
            If IsNothing(client) Then
                Message.Add("No client connection available!" & vbCrLf)
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("Client state is faulted. Message not sent!" & vbCrLf)
                Else
                    'Construct the XMessage to send to AppNet:
                    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    Dim projectInfo As New XElement("ProjectInfo")

                    'Dim Path As New XElement("Path", Project.Path)
                    Dim Path As New XElement("Path", ProjectPath)
                    projectInfo.Add(Path)
                    xmessage.Add(projectInfo)
                    doc.Add(xmessage)

                    'Show the message sent to the Message Service:
                    Message.XAddText("Message sent to " & "Message Service" & ":" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(doc.ToString)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    client.SendMessage("", "MessageService", doc.ToString)
                End If
            End If
        End If
    End Sub
    Private Function ComNetRunning() As Boolean
        'Return True if ComNet (Message Service) is running.
        'If System.IO.File.Exists(MsgServiceAppPath & "\Application.Lock") Then
        '    Return True
        'Else
        '    Return False
        'End If
        If AdvlNetworkAppPath = "" Then
            'Message.Add("Message Service application path is not known." & vbCrLf)
            Message.Add("Andorville™ Network application path is not known." & vbCrLf)
            'Message.Add("Run the Message Service before connecting to update the path." & vbCrLf)
            Message.Add("Run the Andorville™ Network before connecting to update the path." & vbCrLf)
            Return False
        Else
            'If System.IO.File.Exists(MsgServiceAppPath & "\Application.Lock") Then
            If System.IO.File.Exists(AdvlNetworkAppPath & "\Application.Lock") Then
                'Message.Add("AppLock found - ComNet is running." & vbCrLf)
                Return True
            Else
                'Message.Add("AppLock not found - ComNet is running." & vbCrLf)
                Return False
            End If
        End If
    End Function



#End Region 'Online/Offline code


    'Process XMessages: ---------------------------------------------------------------------------------------------------
    Private Sub XMsg_Instruction(Data As String, Locn As String) Handles XMsg.Instruction
        'Process an XMessage instruction.
        'An XMessage is a simplified XSequence. It is used to exchange information between Andorville™ applications.
        '
        'An XSequence file is an AL-H7™ Information Sequence stored in an XML format.
        'AL-H7™ is the name of a programming system that uses sequences of data and location value pairs to store information or processing steps.
        'Any program, mathematical expression or data set can be expressed as an Information Sequence.

        'Add code here to process the XMessage instructions.
        'See other Andorville™ applications for examples.

        If IsDBNull(Data) Then
            Data = ""
        End If

        'Intercept instructions with the prefix "WebPage_"
        If Locn.StartsWith("WebPage_") Then 'Send the Data, Location data to the correct Web Page:
            'Message.Add("Web Page Location: " & Locn & vbCrLf)
            If Locn.Contains(":") Then
                Dim EndOfWebPageNoString As Integer = Locn.IndexOf(":")
                If Locn.Contains("-") Then
                    Dim HyphenLocn As Integer = Locn.IndexOf("-")
                    If HyphenLocn < EndOfWebPageNoString Then 'Web Page Location contains a sub-location in the web page - WebPage_1-SubLocn:Locn - SubLocn:Locn will be sent to Web page 1
                        EndOfWebPageNoString = HyphenLocn
                    End If
                End If
                Dim PageNoLen As Integer = EndOfWebPageNoString - 8
                Dim WebPageNoString As String = Locn.Substring(8, PageNoLen)
                Dim WebPageNo As Integer = CInt(WebPageNoString)
                Dim WebPageData As String = Data
                Dim WebPageLocn As String = Locn.Substring(EndOfWebPageNoString + 1)

                'Message.Add("WebPageData = " & WebPageData & "  WebPageLocn = " & WebPageLocn & vbCrLf)

                WebPageFormList(WebPageNo).XMsgInstruction(WebPageData, WebPageLocn)
            Else
                Message.AddWarning("XMessage instruction location is not complete: " & Locn & vbCrLf)
            End If
        Else

            Select Case Locn

            'Case "ClientAppNetName"
            '    ClientAppNetName = Data 'The name of the Client Application Network requesting service. ADDED 2Feb19.
                Case "ClientProNetName"
                    ClientProNetName = Data 'The name of the Client Application Network requesting service. 

                Case "ClientName"
                    ClientAppName = Data 'The name of the Client requesting service.

                Case "ClientConnectionName"
                    ClientConnName = Data 'The name of the client requesting service.

                Case "ClientLocn"
                    Dim statusOK As New XElement("Status", "OK") 'Add Status OK element when the Client Location is changed
                    xlocns(xlocns.Count - 1).Add(statusOK)

                    xmessage.Add(xlocns(xlocns.Count - 1)) 'Add the instructions for the last location to the reply xmessage
                    xlocns.Add(New XElement(Data)) 'Stert the new location instructions

                'Case "OnCompletion" 'Specify the last instruction to be returned on completion of the XMessage processing.
                '    CompletionInstruction = Data

                'UPDATE:
                Case "OnCompletion"
                    OnCompletionInstruction = Data

                Case "Main"
                 'Blank message - do nothing.

                'Case "Main:OnCompletion"
                '    Select Case "Stop"
                '        'Stop on completion of the instruction sequence.
                '    End Select

                Case "Main:EndInstruction"
                    Select Case Data
                        Case "Stop"
                            'Stop at the end of the instruction sequence.

                            'Add other cases here:
                    End Select

                Case "Main:Status"
                    Select Case Data
                        Case "OK"
                            'Main instructions completed OK
                    End Select

                Case "Command"
                    Select Case Data
                        Case "GetProjectedCrsList"    'Get the list of projected coordinate reference systems
                            GetProjectedCrsListForClient()

                        Case "ConnectToComNet" 'Startup Command
                            If ConnectedToComNet = False Then
                                ConnectToComNet()
                            End If

                        Case "AppComCheck"
                            'Add the Appplication Communication info to the reply message:
                            Dim clientProNetName As New XElement("ClientProNetName", ProNetName) 'The Project Network Name
                            xlocns(xlocns.Count - 1).Add(clientProNetName)
                            Dim clientName As New XElement("ClientName", "ADVL_Coordinates_1") 'The name of this application.
                            xlocns(xlocns.Count - 1).Add(clientName)
                            Dim clientConnectionName As New XElement("ClientConnectionName", ConnectionName)
                            xlocns(xlocns.Count - 1).Add(clientConnectionName)
                            '<Status>OK</Status> will be automatically appended to the XMessage before it is sent.
                    End Select


                Case "ConvertAngle:InputDmsSign"
                    If Data = "+" Then
                        angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Positive 'TDS_Utilities.Coordinates.clsAngleConvert.Sign.Positive
                    ElseIf Data = "-" Then
                        angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Negative 'TDS_Utilities.Coordinates.clsAngleConvert.Sign.Negative
                    Else
                        'Unknown sign
                    End If

                Case "ConvertAngle:InputDmsDegrees"
                    'The degrees value of the input DMS angle
                    angleConvert.DmsDegrees = Data

                Case "ConvertAngle:InputDmsMinutes"
                    'The minutes value of the input DMS angle
                    angleConvert.DmsMinutes = Data

                Case "ConvertAngle:InputDmsSeconds"
                    'The seconds value of the input DMS angle
                    angleConvert.DmsSeconds = Data

                Case "ConvertAngle:InputDecimalDegrees"
                    'The value of the input decimal degrees angle
                    angleConvert.DecimalDegrees = Data

                Case "ConvertAngle:InputSexagesimalDegrees"
                    'The value of the input sexagesimal degrees angle
                    angleConvert.SexagesimalDegrees = Data

                Case "ConvertAngle:InputRadians"
                    'The value of the input radians angle
                    angleConvert.Radians = Data

                Case "ConvertAngle:InputGradians"
                    'The value of the input gradians angle
                    angleConvert.Gradians = Data

                Case "ConvertAngle:InputTurns"
                    'The value of the input turns angle
                    angleConvert.Turns = Data

                Case "ConvertAngle:Command"
                    'A convert angle command
                    Dim operation As New XElement("ConvertedAngle")
                    Select Case Data
                        Case "ConvertDmsToDms"
                            If angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Negative Then
                                Dim outputDmsSign As New XElement("DmsSign", "-")
                                operation.Add(outputDmsSign)
                            Else
                                Dim outputDmsSign As New XElement("DmsSign", "+")
                                operation.Add(outputDmsSign)
                            End If
                            Dim OutputDmsDegrees As New XElement("DmsDegrees", angleConvert.DmsDegrees)
                            operation.Add(OutputDmsDegrees)
                            Dim OutputDmsMinutes As New XElement("DmsMinutes", angleConvert.DmsMinutes)
                            operation.Add(OutputDmsMinutes)
                            Dim OutputDmsSeconds As New XElement("DmsSeconds", angleConvert.DmsSeconds)
                            operation.Add(OutputDmsSeconds)

                        Case "ConvertDmsToDecimalDegrees"
                            angleConvert.ConvertDegMinSecToDecimalDegrees()
                            Dim outputDecimalDegrees As New XElement("DecimalDegrees", angleConvert.DecimalDegrees)
                            operation.Add(outputDecimalDegrees)

                        Case "ConvertDmsToSexagecimalDegrees"
                            angleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                            Dim outputSexagesimalDegrees As New XElement("SexagesimalDegrees", angleConvert.SexagesimalDegrees)
                            operation.Add(outputSexagesimalDegrees)

                        Case "ConvertDmsToRadians"
                            angleConvert.ConvertDegMinSecToRadians()
                            Dim outputRadians As New XElement("Radians", angleConvert.Radians)
                            operation.Add(outputRadians)

                        Case "ConvertDmsToGradians"
                            angleConvert.ConvertDegMinSecToGradians()
                            Dim outputGradians As New XElement("Gradians", angleConvert.Gradians)
                            operation.Add(outputGradians)

                        Case "ConvertDmsToTurns"
                            angleConvert.ConvertDegMinSecToTurns()
                            Dim outputTurns As New XElement("Turns", angleConvert.Turns)
                            operation.Add(outputTurns)

                        Case "ConvertDecimalDegreesToDms"
                            angleConvert.ConvertDecimalDegreeToDegMinSec()
                            If angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Negative Then
                                Dim outputDmsSign As New XElement("DmsSign", "-")
                                operation.Add(outputDmsSign)
                            Else
                                Dim outputDmsSign As New XElement("DmsSign", "+")
                                operation.Add(outputDmsSign)
                            End If
                            Dim OutputDmsDegrees As New XElement("DmsDegrees", angleConvert.DmsDegrees)
                            operation.Add(OutputDmsDegrees)
                            Dim OutputDmsMinutes As New XElement("DmsMinutes", angleConvert.DmsMinutes)
                            operation.Add(OutputDmsMinutes)
                            Dim OutputDmsSeconds As New XElement("DmsSeconds", angleConvert.DmsSeconds)
                            operation.Add(OutputDmsSeconds)

                        Case "ConvertDecimalDegreesToDecimalDegrees"
                            Dim outputDecimalDegrees As New XElement("DecimalDegrees", angleConvert.DecimalDegrees)
                            operation.Add(outputDecimalDegrees)

                        Case "ConvertDecimalDegreesToSexagesimalDegrees"
                            angleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                            Dim outputSexagesimalDegrees As New XElement("SexagesimalDegrees", angleConvert.SexagesimalDegrees)
                            operation.Add(outputSexagesimalDegrees)

                        Case "ConvertDecimalDegreesToRadians"
                            angleConvert.ConvertDecimalDegreeToRadian()
                            Dim outputRadians As New XElement("Radians", angleConvert.Radians)
                            operation.Add(outputRadians)

                        Case "ConvertDecimalDegreesToGradians"
                            angleConvert.ConvertDecimalDegreeToGradian()
                            Dim outputGradians As New XElement("Gradians", angleConvert.Gradians)
                            operation.Add(outputGradians)

                        Case "ConvertDecimalDegreesToTurns"
                            angleConvert.ConvertDecimalDegreeToTurn()
                            Dim outputTurns As New XElement("Turns", angleConvert.Turns)
                            operation.Add(outputTurns)

                        Case "ConvertSexagesimalDegreesToDms"
                            angleConvert.ConvertSexagesimalDegreeToDegMinSec()
                            If angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Negative Then
                                Dim outputDmsSign As New XElement("DmsSign", "-")
                                operation.Add(outputDmsSign)
                            Else
                                Dim outputDmsSign As New XElement("DmsSign", "+")
                                operation.Add(outputDmsSign)
                            End If
                            Dim OutputDmsDegrees As New XElement("DmsDegrees", angleConvert.DmsDegrees)
                            operation.Add(OutputDmsDegrees)
                            Dim OutputDmsMinutes As New XElement("DmsMinutes", angleConvert.DmsMinutes)
                            operation.Add(OutputDmsMinutes)
                            Dim OutputDmsSeconds As New XElement("DmsSeconds", angleConvert.DmsSeconds)
                            operation.Add(OutputDmsSeconds)

                        Case "ConvertSexagesimalDegreesToDecimalDegrees"
                            angleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                            Dim outputDecimalDegrees As New XElement("DecimalDegrees", angleConvert.DecimalDegrees)
                            operation.Add(outputDecimalDegrees)

                        Case "ConvertSexagesimalDegreesToSexagesimalDegrees"
                            Dim outputSexagesimalDegrees As New XElement("SexagesimalDegrees", angleConvert.SexagesimalDegrees)
                            operation.Add(outputSexagesimalDegrees)

                        Case "ConvertSexagesimalDegreesToRadians"
                            angleConvert.ConvertSexagesimalDegreeToRadian()
                            Dim outputRadians As New XElement("Radians", angleConvert.Radians)
                            operation.Add(outputRadians)

                        Case "ConvertSexagesimalDegreesToGradians"
                            angleConvert.ConvertSexagesimalDegreeToGradian()
                            Dim outputGradians As New XElement("Gradians", angleConvert.Gradians)
                            operation.Add(outputGradians)

                        Case "ConvertSexagesimalDegreesToTurns"
                            angleConvert.ConvertSexagesimalDegreeToTurn()
                            Dim outputTurns As New XElement("Turns", angleConvert.Turns)
                            operation.Add(outputTurns)

                        Case "ConvertRadiansToDms"
                            angleConvert.ConvertRadianToDegMinSec()
                            If angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Negative Then
                                Dim outputDmsSign As New XElement("DmsSign", "-")
                                operation.Add(outputDmsSign)
                            Else
                                Dim outputDmsSign As New XElement("DmsSign", "+")
                                operation.Add(outputDmsSign)
                            End If
                            Dim OutputDmsDegrees As New XElement("DmsDegrees", angleConvert.DmsDegrees)
                            operation.Add(OutputDmsDegrees)
                            Dim OutputDmsMinutes As New XElement("DmsMinutes", angleConvert.DmsMinutes)
                            operation.Add(OutputDmsMinutes)
                            Dim OutputDmsSeconds As New XElement("DmsSeconds", angleConvert.DmsSeconds)
                            operation.Add(OutputDmsSeconds)

                        Case "ConvertRadiansToDecimalDegrees"
                            angleConvert.ConvertRadianToDecimalDegree()
                            Dim outputDecimalDegrees As New XElement("DecimalDegrees", angleConvert.DecimalDegrees)
                            operation.Add(outputDecimalDegrees)

                        Case "ConvertRadiansToSexagesimalDegrees"
                            angleConvert.ConvertRadianToSexagesimalDegree()
                            Dim outputSexagesimalDegrees As New XElement("SexagesimalDegrees", angleConvert.SexagesimalDegrees)
                            operation.Add(outputSexagesimalDegrees)

                        Case "ConvertRadiansToRadians"
                            Dim outputRadians As New XElement("Radians", angleConvert.Radians)
                            operation.Add(outputRadians)

                        Case "ConvertRadiansToGradians"
                            angleConvert.ConvertRadianToGradian()
                            Dim outputRadians As New XElement("Gradians", angleConvert.Gradians)
                            operation.Add(outputRadians)

                        Case "ConvertRadiansToTurns"
                            angleConvert.ConvertRadianToTurn()
                            Dim outputTurns As New XElement("Turns", angleConvert.Turns)
                            operation.Add(outputTurns)

                        Case "ConvertGradiansToDms"
                            angleConvert.ConvertGradianToDegMinSec()
                            If angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Negative Then
                                Dim outputDmsSign As New XElement("DmsSign", "-")
                                operation.Add(outputDmsSign)
                            Else
                                Dim outputDmsSign As New XElement("DmsSign", "+")
                                operation.Add(outputDmsSign)
                            End If
                            Dim OutputDmsDegrees As New XElement("DmsDegrees", angleConvert.DmsDegrees)
                            operation.Add(OutputDmsDegrees)
                            Dim OutputDmsMinutes As New XElement("DmsMinutes", angleConvert.DmsMinutes)
                            operation.Add(OutputDmsMinutes)
                            Dim OutputDmsSeconds As New XElement("DmsSeconds", angleConvert.DmsSeconds)
                            operation.Add(OutputDmsSeconds)

                        Case "ConvertGradiansToDecimalDegrees"
                            angleConvert.ConvertGradianToDecimalDegree()
                            Dim outputDecimalDegrees As New XElement("DecimalDegrees", angleConvert.DecimalDegrees)
                            operation.Add(outputDecimalDegrees)

                        Case "ConvertGradiansToSexagesimalDegrees"
                            angleConvert.ConvertGradianToSexagesimalDegree()
                            Dim outputSexagesiamlDegrees As New XElement("SexagesimalDegrees", angleConvert.SexagesimalDegrees)
                            operation.Add(outputSexagesiamlDegrees)

                        Case "ConvertGradiansToRadians"
                            angleConvert.ConvertGradianToRadian()
                            Dim outputRadians As New XElement("Radians", angleConvert.Radians)
                            operation.Add(outputRadians)

                        Case "ConvertGradiansToGradians"
                            Dim outputGradians As New XElement("Gradians", angleConvert.Gradians)
                            operation.Add(outputGradians)

                        Case "ConvertGradiansToTurns"
                            angleConvert.ConvertGradianToTurn()
                            Dim outputTurns As New XElement("Turns", angleConvert.Turns)
                            operation.Add(outputTurns)

                        Case "ConvertTurnsToDms"
                            angleConvert.ConvertTurnToDegMinSec()
                            If angleConvert.DmsSign = ADVL_Coordinates_Library_1.AngleConvert.Sign.Negative Then
                                Dim outputDmsSign As New XElement("DmsSign", "-")
                                operation.Add(outputDmsSign)
                            Else
                                Dim outputDmsSign As New XElement("DmsSign", "+")
                                operation.Add(outputDmsSign)
                            End If
                            Dim OutputDmsDegrees As New XElement("DmsDegrees", angleConvert.DmsDegrees)
                            operation.Add(OutputDmsDegrees)
                            Dim OutputDmsMinutes As New XElement("DmsMinutes", angleConvert.DmsMinutes)
                            operation.Add(OutputDmsMinutes)
                            Dim OutputDmsSeconds As New XElement("DmsSeconds", angleConvert.DmsSeconds)
                            operation.Add(OutputDmsSeconds)

                        Case "ConvertTurnsToDecimalDegrees"
                            angleConvert.ConvertTurnToDecimalDegree()
                            Dim outputDecimalDegrees As New XElement("DecimalDegrees", angleConvert.DecimalDegrees)
                            operation.Add(outputDecimalDegrees)

                        Case "ConvertTurnsToSexagesimalDegrees"
                            angleConvert.ConvertTurnToSexagesimalDegree()
                            Dim outputSexagesiamlDegrees As New XElement("SexagesimalDegrees", angleConvert.SexagesimalDegrees)
                            operation.Add(outputSexagesiamlDegrees)

                        Case "ConvertTurnsToRadians"
                            angleConvert.ConvertTurnToRadian()
                            Dim outputRadians As New XElement("Radians", angleConvert.Radians)
                            operation.Add(outputRadians)

                        Case "ConvertTurnsToGradians"
                            angleConvert.ConvertTurnToGradian()
                            Dim outputRadians As New XElement("Radians", angleConvert.Radians)
                            operation.Add(outputRadians)

                        Case "ConvertTurnsToTurns"
                            Dim outputTurns As New XElement("Turns", angleConvert.Turns)
                            operation.Add(outputTurns)

                        Case Else

                    End Select 'ConvertAngle:Command Prop

                    xlocns(xlocns.Count - 1).Add(operation)

                'Convert Projected Coordinates ----------------------------------------------------------------------------------------------------------------------------------------
                Case "ConvertProjectedCoordinates:ProjectedCRS" 'Convert Projected Coordinates operation: set the Projected CRS.
                    ProjectedCrsInfo.Name = Data
                    GetProjectedCrsParameters() 'Get the projected CRS parameters corresponding to ProjectionInfo.Name

                Case "ConvertProjectedCoordinates:InputCoordinates:Type"
                    If Data = "Geographic" Then
                        ProjectedCrsInfo.InputCoordinatesType = ProjectedCrsInfo.CoordsType.Geographic
                    ElseIf Data = "Projected" Then
                        ProjectedCrsInfo.InputCoordinatesType = ProjectedCrsInfo.CoordsType.Projected
                    End If

                Case "ConvertProjectedCoordinates:InputCoordinates:Easting"
                    SetEasting(Data)

                Case "ConvertProjectedCoordinates:InputCoordinates:Northing"
                    SetNorthing(Data)

                Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeDmsSign"
                    If Data = "-" Then
                        ProjectedCrsInfo.InputLatitude.DmsSign = InputAngle.Sign.Negative
                    Else
                        ProjectedCrsInfo.InputLatitude.DmsSign = InputAngle.Sign.Positive
                    End If

                Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeDmsDegrees"

                    ProjectedCrsInfo.InputLatitude.DmsDegrees = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeDmsMinutes"
                    ProjectedCrsInfo.InputLatitude.DmsMinutes = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeDmsSeconds"
                    ProjectedCrsInfo.InputLatitude.DmsSeconds = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeDecimalDegrees"
                    ProjectedCrsInfo.InputLatitude.DecimalDegrees = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeSexagesimalDegrees"
                    ProjectedCrsInfo.InputLatitude.SexagesimalDegrees = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeRadians"
                    ProjectedCrsInfo.InputLatitude.Radians = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeGradians"
                    ProjectedCrsInfo.InputLatitude.Gradians = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LatitudeTurns"
                    ProjectedCrsInfo.InputLatitude.Turns = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeDmsSign"
                    If Data = "-" Then
                        ProjectedCrsInfo.InputLongitude.DmsSign = InputAngle.Sign.Negative
                    Else
                        ProjectedCrsInfo.InputLongitude.DmsSign = InputAngle.Sign.Positive
                    End If

                Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeDmsDegrees"
                    ProjectedCrsInfo.InputLongitude.DmsDegrees = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeDmsMinutes"
                    ProjectedCrsInfo.InputLongitude.DmsMinutes = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeDmsSeconds"
                    ProjectedCrsInfo.InputLongitude.DmsSeconds = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeDecimalDegrees"
                    ProjectedCrsInfo.InputLongitude.DecimalDegrees = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeSexagesimalDegrees"
                    ProjectedCrsInfo.InputLongitude.SexagesimalDegrees = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeRadians"
                    ProjectedCrsInfo.InputLongitude.Radians = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeGradians"
                    ProjectedCrsInfo.InputLongitude.Gradians = Data

                Case "ConvertProjectedCoordinates:InputCoordinates:LongitudeTurns"
                    ProjectedCrsInfo.InputLongitude.Turns = Data

                Case "ConvertProjectedCoordinates:OutputCoordinates:Type"
                    If Data = "Geographic" Then
                        ProjectedCrsInfo.OutputCoordinatesType = ProjectedCrsInfo.CoordsType.Geographic
                    ElseIf Data = "Projected" Then
                        ProjectedCrsInfo.OutputCoordinatesType = ProjectedCrsInfo.CoordsType.Projected
                    End If

                Case "ConvertProjectedCoordinates:OutputCoordinates:EastingUnits"
                    ProjectedCrsInfo.OutputEasting.OutputUnit = Data

                Case "ConvertProjectedCoordinates:OutputCoordinates:NorthingUnits"
                    ProjectedCrsInfo.OutputNorthing.OutputUnit = Data

                Case "ConvertProjectedCoordinates:Command"
                    Select Case Data
                        Case "ConvertCoordinates"
                            If ProjectedCrsInfo.InputCoordinatesType = ProjectedCrsInfo.CoordsType.Geographic Then
                                LatLongToEastingNorthing()
                            ElseIf ProjectedCrsInfo.InputCoordinatesType = ProjectedCrsInfo.CoordsType.Projected Then
                                EastingNorthingToLatLong()
                            End If
                    End Select
                'End Convert Projected Coordinates ---------------------------------------------------------------------------------------------------------------------------------

                Case "CommunicationNetworkClosing" 'NOT SURE IF THIS IS STILL USED!!!

                    btnOnline.Text = "Offline"
                    btnOnline.ForeColor = Color.Black
                    ConnectedToComNet = False
                    Try
                        client.Close()
                    Catch ex As Exception
                        client.Abort()
                    End Try
                    client = Nothing


           'Process instructions used to get a list of geographic coordinate reference systems: ------------------------------------------------------------
                Case "GetGeographicCRSList:SelectMethod"
                    Select Case Data
                        Case "All"
                            GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.All
                        Case "ExtendingInto"
                            GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.ExtendingInto
                        Case "Inside"
                            GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.Inside
                    End Select

                Case "GetGeographicCRSList:NorthLatitude"
                    GetCRSListInfo.NorthLat = Data
                Case "GetGeographicCRSList:SouthLatitude"
                    GetCRSListInfo.SouthLat = Data
                Case "GetGeographicCRSList:WestLongitude"
                    GetCRSListInfo.WestLong = Data
                Case "GetGeographicCRSList:EastLongitude"
                    GetCRSListInfo.EastLong = Data

                Case "GetGeographicCRSList:GetGeographic2D"
                    If Data = "true" Then
                        GetCRSListInfo.GetGeographic2D = True
                    Else
                        GetCRSListInfo.GetGeographic2D = False
                    End If

                Case "GetGeographicCRSList:GetGeographic3D"
                    If Data = "true" Then
                        GetCRSListInfo.GetGeographic3D = True
                    Else
                        GetCRSListInfo.GetGeographic3D = False
                    End If

                Case "GetGeographicCRSList:Command"
                    If Data = "OK" Then
                        GetGeographicCRSList()
                    End If


                'Process instructions used to get a list of geographic coordinate reference systems: ------------------------------------------------------------
                Case "GetProjectedCrsList:SelectMethod"
                    Select Case Data
                        Case "All"
                            GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.All
                        Case "ExtendingInto"
                            GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.ExtendingInto
                        Case "Inside"
                            GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.Inside
                    End Select

                Case "GetProjectedCrsList:NorthLatitude"
                    GetCRSListInfo.NorthLat = Data

                Case "GetProjectedCrsList:SouthLatitude"
                    GetCRSListInfo.SouthLat = Data

                Case "GetProjectedCrsList:WestLongitude"
                    GetCRSListInfo.WestLong = Data

                Case "GetProjectedCrsList:EastLongitude"
                    GetCRSListInfo.EastLong = Data

                Case "GetProjectedCrsList:Command"
                    If Data = "OK" Then
                        GetProjectedCrsList()
                    End If

            'Startup Command Arguments ================================================
                Case "ProjectName"
                    If Project.OpenProject(Data) = True Then
                        ProjectSelected = True 'Project has been opened OK.
                    Else
                        ProjectSelected = False 'Project could not be opened.
                    End If

                Case "ProjectID"
                    Message.AddWarning("Add code to handle ProjectID parameter at StartUp!" & vbCrLf)

                'Case "ProjectPath"
                '    If Project.OpenProjectPath(Data) = True Then
                '        ProjectSelected = True 'Project has been opened OK.
                '    Else
                '        ProjectSelected = False 'Project could not be opened.
                '    End If

                Case "ProjectPath"
                    If Project.OpenProjectPath(Data) = True Then
                        ProjectSelected = True 'Project has been opened OK.
                        'THE PROJECT IS LOCKED IN THE Form.Load EVENT:

                        ApplicationInfo.SettingsLocn = Project.SettingsLocn
                        Message.SettingsLocn = Project.SettingsLocn 'Set up the Message object
                        Message.Show() 'Added 18May19

                        'txtTotalDuration.Text = Project.Usage.TotalDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
                        '              Project.Usage.TotalDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
                        '              Project.Usage.TotalDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                        '              Project.Usage.TotalDuration.Seconds.ToString.PadLeft(2, "0"c)

                        'txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
                        '               Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
                        '               Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                        '               Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)

                        txtTotalDuration.Text = Project.Usage.TotalDuration.Days.ToString.PadLeft(5, "0"c) & "d:" &
                                        Project.Usage.TotalDuration.Hours.ToString.PadLeft(2, "0"c) & "h:" &
                                        Project.Usage.TotalDuration.Minutes.ToString.PadLeft(2, "0"c) & "m:" &
                                        Project.Usage.TotalDuration.Seconds.ToString.PadLeft(2, "0"c) & "s"

                        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & "d:" &
                                       Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & "h:" &
                                       Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & "m:" &
                                       Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c) & "s"

                    Else
                        ProjectSelected = False 'Project could not be opened.
                        Message.AddWarning("Project could not be opened at path: " & Data & vbCrLf)
                    End If

                Case "ConnectionName"
                    StartupConnectionName = Data
            '--------------------------------------------------------------------------

            'Application Information  =================================================
            'returned by client.GetAdvlNetworkAppInfoAsync()

            'Case "MessageServiceAppInfo:Name"
            '    'The name of the Message Service Application. (Not used.)
                Case "AdvlNetworkAppInfo:Name"
                'The name of the Andorville™ Network Application. (Not used.)

            'Case "MessageServiceAppInfo:ExePath"
            '    'The executable file path of the Message Service Application.
            '    MsgServiceExePath = Info
                Case "AdvlNetworkAppInfo:ExePath"
                    'The executable file path of the Andorville™ Network Application.
                    AdvlNetworkExePath = Data

            'Case "MessageServiceAppInfo:Path"
            '    'The path of the Message Service Application (ComNet). (This is where an Application.Lock file will be found while ComNet is running.)
            '    MsgServiceAppPath = Info
                Case "AdvlNetworkAppInfo:Path"
                    'The path of the Andorville™ Network Application (ComNet). (This is where an Application.Lock file will be found while ComNet is running.)
                    AdvlNetworkAppPath = Data

           '---------------------------------------------------------------------------

             'Message Window Instructions  ==============================================
                Case "MessageWindow:Left"
                    If IsNothing(Message.MessageForm) Then
                        Message.ApplicationName = ApplicationInfo.Name
                        Message.SettingsLocn = Project.SettingsLocn
                        Message.Show()
                    End If
                    Message.MessageForm.Left = Data
                Case "MessageWindow:Top"
                    If IsNothing(Message.MessageForm) Then
                        Message.ApplicationName = ApplicationInfo.Name
                        Message.SettingsLocn = Project.SettingsLocn
                        Message.Show()
                    End If
                    Message.MessageForm.Top = Data
                Case "MessageWindow:Width"
                    If IsNothing(Message.MessageForm) Then
                        Message.ApplicationName = ApplicationInfo.Name
                        Message.SettingsLocn = Project.SettingsLocn
                        Message.Show()
                    End If
                    Message.MessageForm.Width = Data
                Case "MessageWindow:Height"
                    If IsNothing(Message.MessageForm) Then
                        Message.ApplicationName = ApplicationInfo.Name
                        Message.SettingsLocn = Project.SettingsLocn
                        Message.Show()
                    End If
                    Message.MessageForm.Height = Data
                Case "MessageWindow:Command"
                    Select Case Data
                        Case "BringToFront"
                            If IsNothing(Message.MessageForm) Then
                                Message.ApplicationName = ApplicationInfo.Name
                                Message.SettingsLocn = Project.SettingsLocn
                                Message.Show()
                            End If
                            'Message.MessageForm.BringToFront()
                            Message.MessageForm.Activate()
                            Message.MessageForm.TopMost = True
                            Message.MessageForm.TopMost = False
                        Case "SaveSettings"
                            Message.MessageForm.SaveFormSettings()
                    End Select

            '---------------------------------------------------------------------------

           'Command to bring the Application window to the front:
                Case "ApplicationWindow:Command"
                    Select Case Data
                        Case "BringToFront"
                            Me.Activate()
                            Me.TopMost = True
                            Me.TopMost = False
                    End Select



                Case "EndOfSequence"
                    'End of Information Vector Sequence reached.
                    'Add Status OK element at the end of the sequence:
                    Dim statusOK As New XElement("Status", "OK")
                    xlocns(xlocns.Count - 1).Add(statusOK)

                    Select Case EndInstruction
                        Case "Stop"
                            'No instructions.

                            'Add any other Cases here:

                        Case Else
                            Message.AddWarning("Unknown End Instruction: " & EndInstruction & vbCrLf)
                    End Select
                    EndInstruction = "Stop"

                    ''Add the final OnCompletion instruction:
                    'Dim onCompletion As New XElement("OnCompletion", CompletionInstruction) '
                    'xlocns(xlocns.Count - 1).Add(onCompletion)
                    'CompletionInstruction = "Stop" 'Reset the Completion Instruction

                    ''Final Version:
                    ''Add the final EndInstruction:
                    'Dim xEndInstruction As New XElement("EndInstruction", OnCompletionInstruction)
                    'xlocns(xlocns.Count - 1).Add(xEndInstruction)
                    'OnCompletionInstruction = "Stop" 'Reset the OnCompletion Instruction

                    'Add the final EndInstruction:
                    If OnCompletionInstruction = "Stop" Then
                        'Final EndInstruction is not required.
                    Else
                        Dim xEndInstruction As New XElement("EndInstruction", OnCompletionInstruction)
                        xlocns(xlocns.Count - 1).Add(xEndInstruction)
                        OnCompletionInstruction = "Stop" 'Reset the OnCompletion Instruction
                    End If

                Case Else
                    Message.AddWarning("Unknown location: " & Locn & vbCrLf)
                    Message.AddWarning("            data: " & Data & vbCrLf)
            End Select
        End If
    End Sub

    Private Sub XMsg_ErrorMsg(ErrMsg As String) Handles XMsg.ErrorMsg
        'Process the error message:
        Message.AddWarning("Error message: " & ErrMsg & vbCrLf)
    End Sub

    'Private Sub SendMessage()
    '    'Code used to send a message after a timer delay.
    '    'The message destination is stored in MessageDest
    '    'The message text is stored in MessageText
    '    Timer1.Interval = 100 '100ms delay
    '    Timer1.Enabled = True 'Start the timer.
    'End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    '    If IsNothing(client) Then
    '        Message.AddWarning("No client connection available!" & vbCrLf)
    '    Else
    '        If client.State = ServiceModel.CommunicationState.Faulted Then
    '            Message.AddWarning("client state is faulted. Message not sent!" & vbCrLf)
    '        Else
    '            Try
    '                Message.Add("Sending a message. Number of characters: " & MessageText.Length & vbCrLf)
    '                'client.SendMessage(ClientAppNetName, ClientConnName, MessageText)
    '                client.SendMessage(ClientProNetName, ClientConnName, MessageText)

    '                MessageText = "" 'Clear the message after it has been sent.
    '                ClientConnName = "" 'Clear the Client Application Name after the message has been sent.
    '                xlocns.Clear()
    '            Catch ex As Exception
    '                Message.AddWarning("Error sending message: " & ex.Message & vbCrLf)
    '            End Try
    '        End If
    '    End If

    '    'Stop timer:
    '    Timer1.Enabled = False
    'End Sub

    Private Sub GetProjectedCrsParameters()
        'Get the projected CRS parameters corresponding to ProjectionInfo.ProjectedCrsName

        ProjectedCRS.AddUser()

        If ProjectedCRS.NRecords > 0 Then
            'Find the selected Projected CRS:
            Dim ProjCrsMatch = From ProjCrs In ProjectedCRS.List Where ProjCrs.Name = ProjectedCrsInfo.Name

            If ProjCrsMatch.Count > 0 Then
                Select Case ProjCrsMatch(0).ProjectionMethod.Name
                    Case "Transverse Mercator"
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

        Projection.AddUser()

        TransverseMercator = New ADVL_Coordinates_Library_1.TransverseMercator 'TDS_Utilities.Coordinates.clsTransverseMercator

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
            Geographic2DCRS.AddUser()

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

        GeodeticDatum.AddUser()
        Dim DatumMatch = From Datum In GeodeticDatum.List Where Datum.Author = Author And Datum.Code = Code

        If DatumMatch.Count > 0 Then
            TransverseMercator.GeographicCRS.DatumName = DatumMatch(0).Name
            TransverseMercator.GeographicCRS.EllipsoidName = DatumMatch(0).Ellipsoid.Name

            Dim EllipsoidMatch = From Ellipsoid In Ellipsoid.List Where Ellipsoid.Author = DatumMatch(0).Ellipsoid.Author And Ellipsoid.Code = DatumMatch(0).Ellipsoid.Code

            If EllipsoidMatch.Count > 0 Then
                If EllipsoidMatch(0).EllipsoidParameters = ADVL_Coordinates_Library_1.Ellipsoid.DefiningParameters.SemiMajorAxis_InverseFlattening Then
                    TransverseMercator.GeographicCRS.SemiMajorAxis = EllipsoidMatch(0).SemiMajorAxis
                    TransverseMercator.GeographicCRS.InverseFlattening = EllipsoidMatch(0).InverseFlattening
                    'Calculate SemiMinorAxis:
                    TransverseMercator.GeographicCRS.SemiMinorAxis = EllipsoidMatch(0).SemiMajorAxis - (EllipsoidMatch(0).SemiMajorAxis / EllipsoidMatch(0).InverseFlattening)
                    Message.Add("Calculated Semi Minor Axis: " & TransverseMercator.GeographicCRS.SemiMinorAxis & vbCrLf)
                ElseIf EllipsoidMatch(0).EllipsoidParameters = ADVL_Coordinates_Library_1.Ellipsoid.DefiningParameters.SemiMajorAxis_SemiMinorAxis Then
                    TransverseMercator.GeographicCRS.SemiMajorAxis = EllipsoidMatch(0).SemiMajorAxis
                    TransverseMercator.GeographicCRS.SemiMinorAxis = EllipsoidMatch(0).SemiMinorAxis
                    'Calculate InverseFlattening:
                    TransverseMercator.GeographicCRS.InverseFlattening = EllipsoidMatch(0).SemiMajorAxis / (EllipsoidMatch(0).SemiMajorAxis - EllipsoidMatch(0).SemiMinorAxis)
                    Message.Add("Calculated Inverse Flattening: " & TransverseMercator.GeographicCRS.InverseFlattening & vbCrLf)
                Else
                    Message.Add("Unknown ellipsoid specification: " & vbCrLf)
                    TransverseMercator.GeographicCRS.SemiMajorAxis = EllipsoidMatch(0).SemiMajorAxis
                    TransverseMercator.GeographicCRS.SemiMinorAxis = EllipsoidMatch(0).SemiMinorAxis
                    TransverseMercator.GeographicCRS.InverseFlattening = EllipsoidMatch(0).InverseFlattening
                End If
                Message.Add("Base datum found: " & DatumMatch(0).Name & vbCrLf)

                Message.Add("Ellipsoid name: " & DatumMatch(0).Ellipsoid.Name & vbCrLf)
                Message.Add("Inverse Flattening: " & EllipsoidMatch(0).InverseFlattening & vbCrLf)
                Message.Add("Semi Major Axis: " & EllipsoidMatch(0).SemiMajorAxis & vbCrLf)
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

        ProjectedCRS.AddUser()

        Dim list As New XElement("ProjectedCrsList")

        Dim I As Integer
        Dim NRecords As Integer
        NRecords = ProjectedCRS.List.Count
        Message.Add("Number of Projected CRS's: " & NRecords & vbCrLf)

        For I = 0 To NRecords - 1
            Dim crsName As New XElement("ProjectedCrsName", ProjectedCRS.List(I).Name)
            list.Add(crsName)
        Next

        xlocns(xlocns.Count - 1).Add(list)

    End Sub

    Private Sub EastingNorthingToLatLong()

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

        xlocns(xlocns.Count - 1).Add(operation)

    End Sub

    Private Sub LatLongToEastingNorthing()

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

        xlocns(xlocns.Count - 1).Add(operation)

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

    Private Sub GetGeographicCRSList()
        'Generate an XMessage containing a list of Geographic Coordinate Reference Systems.
        'The settings used to generate this list are stored in GetCRSListInfo.

        If GetCRSListInfo.GetGeographic2D = True Then
            Geographic2DCRS.AddUser()
            AreaOfUse.AddUser()
            Dim list As New XElement("Geographic2DCrsList")

            Dim I As Integer
            Dim NRecords As Integer

            NRecords = Geographic2DCRS.List.Count

            If GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.All Then
                For I = 0 To NRecords - 1
                    Dim crsName As New XElement("Geographic2DCrsName", Geographic2DCRS.List(I).Name)
                    list.Add(crsName)
                Next
                xmessage.Add(list)
            ElseIf GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.ExtendingInto Then
                Dim IncludeCRS As Boolean
                For I = 0 To NRecords - 1
                    Dim AreaMatch = From Area In AreaOfUse.List Where Area.Author = Geographic2DCRS.List(I).Area.Author And Area.Code = Geographic2DCRS.List(I).Area.Code

                    If AreaMatch.Count > 0 Then
                        IncludeCRS = True 'Initialise to True.
                        If AreaMatch(0).SouthLatitude > GetCRSListInfo.NorthLat Then IncludeCRS = False
                        If AreaMatch(0).NorthLatitude < GetCRSListInfo.SouthLat Then IncludeCRS = False
                        If AreaMatch(0).WestLongitude > GetCRSListInfo.EastLong Then IncludeCRS = False
                        If AreaMatch(0).EastLongitude < GetCRSListInfo.WestLong Then IncludeCRS = False
                        If IncludeCRS Then 'Area extends into the selection area
                            Dim crsName As New XElement("Geographic2DCrsName", Geographic2DCRS.List(I).Name)
                            list.Add(crsName)
                        End If
                    End If
                Next
            ElseIf GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.Inside Then
                For I = 0 To NRecords - 1
                    Dim AreaMatch = From Area In AreaOfUse.List Where Area.Author = Geographic2DCRS.List(I).Area.Author And Area.Code = Geographic2DCRS.List(I).Area.Code
                    If AreaMatch.Count > 0 Then
                        If AreaMatch(0).NorthLatitude <= GetCRSListInfo.NorthLat Then
                            If AreaMatch(0).SouthLatitude >= GetCRSListInfo.SouthLat Then
                                If AreaMatch(0).WestLongitude >= GetCRSListInfo.WestLong Then
                                    If AreaMatch(0).EastLongitude <= GetCRSListInfo.EastLong Then
                                        'Area is completely within the selection area.
                                        Dim crsName As New XElement("Geographic2DCrsName", Geographic2DCRS.List(I).Name)
                                        list.Add(crsName)
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
            End If
            xlocns(xlocns.Count - 1).Add(list)
            Geographic2DCRS.RemoveUser()
            AreaOfUse.RemoveUser()
        End If


        If GetCRSListInfo.GetGeographic3D = True Then
            Geographic3DCRS.AddUser()
            AreaOfUse.AddUser()
            Dim list As New XElement("Geographic3DCrsList")

            Dim I As Integer
            Dim NRecords As Integer

            NRecords = Geographic3DCRS.List.Count

            If GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.All Then
                For I = 0 To NRecords - 1
                    Dim crsName As New XElement("Geographic3DCrsName", Geographic3DCRS.List(I).Name)
                    list.Add(crsName)
                Next
                xlocns(xlocns.Count - 1).Add(list)
            ElseIf GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.ExtendingInto Then
                Dim IncludeCRS As Boolean
                For I = 0 To NRecords - 1
                    Dim AreaMatch = From Area In AreaOfUse.List Where Area.Author = Geographic3DCRS.List(I).Area.Author And Area.Code = Geographic3DCRS.List(I).Area.Code

                    If AreaMatch.Count > 0 Then
                        IncludeCRS = True 'Initialise to True.
                        If AreaMatch(0).SouthLatitude > GetCRSListInfo.NorthLat Then IncludeCRS = False
                        If AreaMatch(0).NorthLatitude < GetCRSListInfo.SouthLat Then IncludeCRS = False
                        If AreaMatch(0).WestLongitude > GetCRSListInfo.EastLong Then IncludeCRS = False
                        If AreaMatch(0).EastLongitude < GetCRSListInfo.WestLong Then IncludeCRS = False
                        If IncludeCRS Then 'Area extends into the selection area
                            Dim crsName As New XElement("Geographic3DCrsName", Geographic3DCRS.List(I).Name)
                            list.Add(crsName)
                        End If
                    End If
                Next
            ElseIf GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.Inside Then
                For I = 0 To NRecords - 1
                    Dim AreaMatch = From Area In AreaOfUse.List Where Area.Author = Geographic3DCRS.List(I).Area.Author And Area.Code = Geographic3DCRS.List(I).Area.Code
                    If AreaMatch.Count > 0 Then
                        If AreaMatch(0).NorthLatitude <= GetCRSListInfo.NorthLat Then
                            If AreaMatch(0).SouthLatitude >= GetCRSListInfo.SouthLat Then
                                If AreaMatch(0).WestLongitude >= GetCRSListInfo.WestLong Then
                                    If AreaMatch(0).EastLongitude <= GetCRSListInfo.EastLong Then
                                        'Area is completely within the selection area.
                                        Dim crsName As New XElement("Geographic3DCrsName", Geographic3DCRS.List(I).Name)
                                        list.Add(crsName)
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
            End If
            xlocns(xlocns.Count - 1).Add(list)
            Geographic3DCRS.RemoveUser()
            AreaOfUse.RemoveUser()
        End If

    End Sub

    Private Sub GetProjectedCrsList()
        'Generate an XMessage containing a list of Projected Coordinate Reference Systems.
        'The settings used to generate this list are stored in GetCRSListInfo.

        ProjectedCRS.AddUser()
        AreaOfUse.AddUser()
        Dim list As New XElement("ProjectedCrsList")

        Dim I As Integer
        Dim NRecords As Integer

        NRecords = ProjectedCRS.List.Count

        If GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.All Then
            For I = 0 To NRecords - 1
                Dim crsName As New XElement("ProjectedCrsName", ProjectedCRS.List(I).Name)
                list.Add(crsName)
            Next
            xlocns(xlocns.Count - 1).Add(list)
        ElseIf GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.ExtendingInto Then
            Dim IncludeCRS As Boolean
            For I = 0 To NRecords - 1
                Dim AreaMatch = From Area In AreaOfUse.List Where Area.Author = ProjectedCRS.List(I).Area.Author And Area.Code = ProjectedCRS.List(I).Area.Code

                If AreaMatch.Count > 0 Then
                    IncludeCRS = True 'Initialise to True.
                    If AreaMatch(0).SouthLatitude > GetCRSListInfo.NorthLat Then IncludeCRS = False
                    If AreaMatch(0).NorthLatitude < GetCRSListInfo.SouthLat Then IncludeCRS = False
                    If AreaMatch(0).WestLongitude > GetCRSListInfo.EastLong Then IncludeCRS = False
                    If AreaMatch(0).EastLongitude < GetCRSListInfo.WestLong Then IncludeCRS = False
                    If IncludeCRS Then 'Area extends into the selection area
                        Dim crsName As New XElement("ProjectedCrsName", ProjectedCRS.List(I).Name)
                        list.Add(crsName)
                    End If
                End If
            Next
        ElseIf GetCRSListInfo.SelectMethod = clsGetCRSListInfo.SelectMethods.Inside Then
            For I = 0 To NRecords - 1
                Dim AreaMatch = From Area In AreaOfUse.List Where Area.Author = ProjectedCRS.List(I).Area.Author And Area.Code = ProjectedCRS.List(I).Area.Code
                If AreaMatch.Count > 0 Then
                    If AreaMatch(0).NorthLatitude <= GetCRSListInfo.NorthLat Then
                        If AreaMatch(0).SouthLatitude >= GetCRSListInfo.SouthLat Then
                            If AreaMatch(0).WestLongitude >= GetCRSListInfo.WestLong Then
                                If AreaMatch(0).EastLongitude <= GetCRSListInfo.EastLong Then
                                    'Area is completely within the selection area.
                                    Dim crsName As New XElement("ProjectedCrsName", ProjectedCRS.List(I).Name)
                                    list.Add(crsName)
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End If
        xlocns(xlocns.Count - 1).Add(list)
        ProjectedCRS.RemoveUser()
        AreaOfUse.RemoveUser()

    End Sub


    'END Process XMessages ------------------------------------------------------------------------------------------------

    Private Sub Project_NewProjectCreated(ProjectPath As String) Handles Project.NewProjectCreated
        SendProjectInfo(ProjectPath) 'Send the path of the new project to the Network application. The new project will be added to the list of projects.
    End Sub

#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------


    Private Class clsGetCRSListInfo
        'Settings used to get a list of geographic coordinate reference systems.
        Property NorthLat As Single 'The northern latitude of the selection bounding area.
        Property SouthLat As Single 'The southern latitude of the selection bounding area.
        Property WestLong As Single 'The western longitude of the selection bounding area.
        Property EastLong As Single 'The eastern longitude of the selection bounding area.

        Enum SelectMethods
            All
            ExtendingInto
            Inside
        End Enum
        Property SelectMethod As SelectMethods 'The area selection method: All - select all CRSs, ExtendingInto - select CRSs extending into the area, Inside - select CRSs inside the area.

        Property GetGeographic2D As Boolean 'If true, Geographic 2D CRSs are selected.

        Property GetGeographic3D As Boolean 'If true, Geographic 3D CRSs are selected.

    End Class 'clsGetGeoCRSListInfo



    Private Sub chkConnect_LostFocus(sender As Object, e As EventArgs) Handles chkConnect.LostFocus
        If chkConnect.Checked Then
            Project.ConnectOnOpen = True
        Else
            Project.ConnectOnOpen = False
        End If
        Project.SaveProjectInfoFile()

    End Sub

    'Private Sub Timer3_Tick(sender As Object, e As EventArgs)
    '    'Keet the connection awake with each tick:

    '    If ConnectedToComNet = True Then
    '        Try
    '            If client.IsAlive() Then
    '                Message.Add(Format(Now, "HH:mm:ss") & " Connection OK." & vbCrLf)
    '                Timer3.Interval = TimeSpan.FromMinutes(55).TotalMilliseconds '55 minute interval
    '            Else
    '                Message.Add(Format(Now, "HH:mm:ss") & " Connection Fault." & vbCrLf)
    '                Timer3.Interval = TimeSpan.FromMinutes(55).TotalMilliseconds '55 minute interval
    '            End If
    '        Catch ex As Exception
    '            Message.AddWarning(ex.Message & vbCrLf)
    '            'Set interval to five minutes - try again in five minutes:
    '            Timer3.Interval = TimeSpan.FromMinutes(5).TotalMilliseconds '5 minute interval
    '        End Try
    '    Else
    '        Message.Add(Format(Now, "HH:mm:ss") & " Not connected." & vbCrLf)
    '    End If

    'End Sub

    Private Sub ToolStripMenuItem1_EditWorkflowTabPage_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1_EditWorkflowTabPage.Click
        'Edit the Workflow Web Page:

        If WorkflowFileName = "" Then
            Message.AddWarning("No page to edit." & vbCrLf)
        Else
            Dim FormNo As Integer = OpenNewHtmlDisplayPage()
            HtmlDisplayFormList(FormNo).FileName = WorkflowFileName
            HtmlDisplayFormList(FormNo).OpenDocument
        End If

    End Sub

    Private Sub ToolStripMenuItem1_ShowStartPageInWorkflowTab_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1_ShowStartPageInWorkflowTab.Click
        'Show the Start Page in the Workflow Tab:
        OpenStartPage()

    End Sub

    Private Sub bgwComCheck_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwComCheck.DoWork
        'The communications check thread.
        While ConnectedToComNet
            Try
                If client.IsAlive() Then
                    'Message.Add(Format(Now, "HH:mm:ss") & " Connection OK." & vbCrLf) 'This produces the error: Cross thread operation not valid.
                    bgwComCheck.ReportProgress(1, Format(Now, "HH:mm:ss") & " Connection OK." & vbCrLf)
                Else
                    'Message.Add(Format(Now, "HH:mm:ss") & " Connection Fault." & vbCrLf) 'This produces the error: Cross thread operation not valid.
                    bgwComCheck.ReportProgress(1, Format(Now, "HH:mm:ss") & " Connection Fault.")
                End If
            Catch ex As Exception
                bgwComCheck.ReportProgress(1, "Error in bgeComCheck_DoWork!" & vbCrLf)
                bgwComCheck.ReportProgress(1, ex.Message & vbCrLf)
            End Try

            'System.Threading.Thread.Sleep(60000) 'Sleep time in milliseconds (60 seconds) - For testing only.
            'System.Threading.Thread.Sleep(3600000) 'Sleep time in milliseconds (60 minutes)
            System.Threading.Thread.Sleep(1800000) 'Sleep time in milliseconds (30 minutes)
        End While
    End Sub

    Private Sub bgwComCheck_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwComCheck.ProgressChanged
        Message.Add(e.UserState.ToString) 'Show the ComCheck message 
    End Sub

    Private Sub bgwSendMessage_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSendMessage.DoWork
        'Send a message on a separate thread:
        Try
            If IsNothing(client) Then
                bgwSendMessage.ReportProgress(1, "No Connection available. Message not sent!")
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    bgwSendMessage.ReportProgress(1, "Connection state is faulted. Message not sent!")
                Else
                    Dim SendMessageParams As clsSendMessageParams = e.Argument
                    client.SendMessage(SendMessageParams.ProjectNetworkName, SendMessageParams.ConnectionName, SendMessageParams.Message)
                End If
            End If
        Catch ex As Exception
            bgwSendMessage.ReportProgress(1, ex.Message)
        End Try
    End Sub

    Private Sub bgwSendMessage_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSendMessage.ProgressChanged
        'Display an error message:
        Message.AddWarning("Send Message error: " & e.UserState.ToString & vbCrLf) 'Show the bgwSendMessage message 
    End Sub

    Private Sub bgwSendMessageAlt_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSendMessageAlt.DoWork
        'Alternative SendMessage background worker - used to send a message while instructions are being processed. 
        'Send a message on a separate thread
        Try
            If IsNothing(client) Then
                bgwSendMessageAlt.ReportProgress(1, "No Connection available. Message not sent!")
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    bgwSendMessageAlt.ReportProgress(1, "Connection state is faulted. Message not sent!")
                Else
                    Dim SendMessageParamsAlt As clsSendMessageParams = e.Argument
                    client.SendMessage(SendMessageParamsAlt.ProjectNetworkName, SendMessageParamsAlt.ConnectionName, SendMessageParamsAlt.Message)
                End If
            End If
        Catch ex As Exception
            bgwSendMessageAlt.ReportProgress(1, ex.Message)
        End Try
    End Sub

    Private Sub bgwSendMessageAlt_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSendMessageAlt.ProgressChanged
        'Display an error message:
        Message.AddWarning("Send Message error: " & e.UserState.ToString & vbCrLf) 'Show the bgwSendMessageAlt message 
    End Sub

    Private Sub Message_ShowXMessagesChanged(Show As Boolean) Handles Message.ShowXMessagesChanged
        ShowXMessages = Show
    End Sub

    Private Sub Message_ShowSysMessagesChanged(Show As Boolean) Handles Message.ShowSysMessagesChanged
        ShowSysMessages = Show
    End Sub

    Private Sub XMsgLocal_Instruction(Info As String, Locn As String) Handles XMsgLocal.Instruction

    End Sub


End Class 'Main


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

End Class 'InputAngle

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

End Class 'DistanceConvert

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

End Class 'ConversionFactors

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

End Class 'ProjectionInfo

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

End Class 'ProjectedCrsInfo

Public Class clsSendMessageParams
    'Parameters used when sending a message using the Message Service.
    Public ProjectNetworkName As String
    Public ConnectionName As String
    Public Message As String
End Class

