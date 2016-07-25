Public Class frmEpsgDatabase
    'The EPSG Database form is used to view tables in the EPSG database.

#Region " Variable Declarations - All the variables used in this form." '----------------------------------------------------------------------------------------------------------------------

    'Variables used to connect to a database and open a table:
    Dim connString As String
    Dim myConnection As OleDb.OleDbConnection = New OleDb.OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDb.OleDbDataAdapter
    Dim tables As DataTableCollection = ds.Tables

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Properties - All the properties used in this form." '--------------------------------------------------------------------------------------------------------------------------------

    'The TableName property stores the name of the table selected for viewing.
    Private mTableName As String
    Public Property TableName As String
        Get
            Return mTableName
        End Get
        Set(value As String)
            mTableName = value
        End Set
    End Property

    'The Query property stores the text of the query used to display table values in the GridDataView on this form.
    Private mQuery As String
    Public Property Query() As String
        Get
            Return mQuery
        End Get
        Set(ByVal value As String)
            mQuery = value
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
                               <TableName><%= TableName %></TableName>
                               <Query><%= Query %></Query>
                           </FormSettings>

        'Dim SettingsName As String = "FormSettings_" & Me.Text & ".xml"
        'Dim SettingsName As String = "Formsettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Dim SettingsName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Main.Project.SaveXmlSettings(SettingsName, settingsData)

    End Sub

    'Private Sub RestoreFormSettings(ByRef Settings As System.Xml.Linq.XDocument)
    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        'Dim SettingsName As String = "FormSettings_" & Me.Text & ".xml"
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

            If Settings.<FormSettings>.<TableName>.Value = Nothing Then
                'Form setting not saved.
            Else
                TableName = Settings.<FormSettings>.<TableName>.Value
            End If

            If Settings.<FormSettings>.<Query>.Value = Nothing Then
                'Form setting not saved.
            Else
                Query = Settings.<FormSettings>.<Query>.Value
            End If

        End If

    End Sub

#End Region 'Process XML Files ----------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Display Methods - Code used to display this form." '----------------------------------------------------------------------------------------------------------------------------

    Private Sub frmEpsgDatabase_Load(sender As Object, e As EventArgs) Handles Me.Load
        RestoreFormSettings()

        txtDatabase.Text = Main.EpsgDatabasePath
        FillCmbSelectTable()

        If TableName <> "" Then
            'Select the table iame in the combobox

            'cmbSelectTable.FindStringExact(TableName)
            cmbSelectTable.SelectedIndex = cmbSelectTable.FindStringExact(TableName)
        End If

        txtImportFileNames.Text = "EPSG_" & Format(Now, "ddMMMyyyy")

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        SaveFormSettings()
        Me.Close()
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------

#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub btnFindDatabase_Click(sender As Object, e As EventArgs) Handles btnFindDatabase.Click
        'Find a database file:

        If txtDatabase.Text <> "" Then
            Dim fInfo As New System.IO.FileInfo(txtDatabase.Text)
            OpenFileDialog1.InitialDirectory = fInfo.DirectoryName
            OpenFileDialog1.Filter = "Database |*.accdb; *.mdb"
            OpenFileDialog1.FileName = fInfo.Name
        Else
            OpenFileDialog1.InitialDirectory = System.Environment.SpecialFolder.MyDocuments
            OpenFileDialog1.Filter = "Database |*.accdb; *.mdb"
            OpenFileDialog1.FileName = ""
        End If

        If OpenFileDialog1.ShowDialog() = vbOK Then
            Main.EpsgDatabasePath = OpenFileDialog1.FileName
            txtDatabase.Text = Main.EpsgDatabasePath
            FillCmbSelectTable()
        End If
    End Sub

    Private Sub FillCmbSelectTable()
        'Fill the cmbSelectTable listbox with the availalble tables in the selected database.

        If Main.EpsgDatabasePath = "" Then
            'Main.MessageStyleWarningSet()
            'Main.MessageAdd("No EPSG database has been selected." & vbCrLf)
            Main.Message.SetWarningStyle()
            Main.Message.Add("No EPSG database has been selected." & vbCrLf)
            Exit Sub
        End If

        If Not System.IO.File.Exists(Main.EpsgDatabasePath) Then
            'Main.MessageStyleWarningSet()
            'Main.MessageAdd("Selected EPSG database can not be found." & vbCrLf)
            Main.Message.SetWarningStyle()
            Main.Message.Add("Selected EPSG database can not be found." & vbCrLf)
            Exit Sub
        End If

        'Database access for MS Access:
        Dim connectionString As String 'Declare a connection string for MS Access - defines the database or server to be used.
        Dim conn As System.Data.OleDb.OleDbConnection 'Declare a connection for MS Access - used by the Data Adapter to connect to and disconnect from the database.
        Dim dt As DataTable

        cmbSelectTable.Items.Clear()

        'Specify the connection string:
        'Access 2003
        'connectionString = "provider=Microsoft.Jet.OLEDB.4.0;" + _
        '"data source = " + txtDatabase.Text

        'Access 2007:
        connectionString = "provider=Microsoft.ACE.OLEDB.12.0;" + _
        "data source = " + Main.EpsgDatabasePath

        'Connect to the Access database:
        conn = New System.Data.OleDb.OleDbConnection(connectionString)
        conn.Open()

        'This error occurs on the above line (conn.Open()):
        'Additional information: The 'Microsoft.ACE.OLEDB.12.0' provider is not registered on the local machine.
        'Fix attempt: 
        'http://www.microsoft.com/en-us/download/confirmation.aspx?id=23734
        'Download AccessDatabaseEngine.exe
        'Run the file to install the 2007 Office System Driver: Data Connectivity Components.


        Dim restrictions As String() = New String() {Nothing, Nothing, Nothing, "TABLE"} 'This restriction removes system tables
        dt = conn.GetSchema("Tables", restrictions)

        'Fill lstSelectTable
        Dim dr As DataRow
        Dim I As Integer 'Loop index
        Dim MaxI As Integer

        MaxI = dt.Rows.Count
        For I = 0 To MaxI - 1
            dr = dt.Rows(0)
            cmbSelectTable.Items.Add(dt.Rows(I).Item(2).ToString)
        Next I

        conn.Close()

    End Sub

    Private Sub cmbSelectTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSelectTable.SelectedIndexChanged
        'Update DataGridView1:

        If IsNothing(cmbSelectTable.SelectedItem) Then
            Exit Sub
        End If

        'TableName = "[" + cmbSelectTable.SelectedItem.ToString + "]"
        TableName = cmbSelectTable.SelectedItem.ToString

        Query = "Select Top 500 * From [" & TableName & "]"
        txtQuery.Text = Query

        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" & Main.EpsgDatabasePath
        myConnection.ConnectionString = connString
        myConnection.Open()

        da = New OleDb.OleDbDataAdapter(Query, myConnection)

        da.MissingSchemaAction = MissingSchemaAction.AddWithKey 'This statement is required to obtain the correct result from the statement: ds.Tables(0).Columns(0).MaxLength (This fixes a Microsoft bug: http://support.microsoft.com/kb/317175 )

        ds.Clear()
        ds.Reset()

        da.FillSchema(ds, SchemaType.Source, TableName)

        da.Fill(ds, TableName)

        DataGridView1.AutoGenerateColumns = True

        DataGridView1.EditMode = DataGridViewEditMode.EditOnKeystroke

        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.AutoResizeColumns()

        DataGridView1.Update()
        DataGridView1.Refresh()
        myConnection.Close()
    End Sub

    Private Sub btnApplyQuery_Click(sender As Object, e As EventArgs) Handles btnApplyQuery.Click
        'Applu the SQL Query in txtQuary:

        Query = txtQuery.Text

        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" & Main.EpsgDatabasePath
        myConnection.ConnectionString = connString
        myConnection.Open()

        da = New OleDb.OleDbDataAdapter(Query, myConnection)

        da.MissingSchemaAction = MissingSchemaAction.AddWithKey 'This statement is required to obtain the correct result from the statement: ds.Tables(0).Columns(0).MaxLength (This fixes a Microsoft bug: http://support.microsoft.com/kb/317175 )

        ds.Clear()
        ds.Reset()

        da.FillSchema(ds, SchemaType.Source, TableName)

        Try
            da.Fill(ds, TableName)

            DataGridView1.AutoGenerateColumns = True

            DataGridView1.EditMode = DataGridViewEditMode.EditOnKeystroke

            DataGridView1.DataSource = ds.Tables(0)
            DataGridView1.AutoResizeColumns()

            DataGridView1.Update()
            DataGridView1.Refresh()
        Catch ex As Exception
            Main.Message.SetWarningStyle()
            Main.Message.Add("Error: " & ex.Message & vbCrLf)
        End Try
        myConnection.Close()
    End Sub

    Private Sub Import_Click(sender As Object, e As EventArgs) Handles Import.Click
        'Import each Coordinate parameter list from the EPSG database.

        Dim ImportFileNames As String = Trim(txtImportFileNames.Text)
        If ImportFileNames = "" Then
            Main.Message.SetWarningStyle()
            Main.Message.Add("Please enter a name for the imported files. The correct extension will be added to each file type." & vbCrLf)
            Exit Sub
        End If

        If System.IO.File.Exists(Main.EpsgDatabasePath) Then
            Dim FileName As String
            Main.Message.SetNormalStyle()
            Main.Message.Add("Importing data from EPSG Access database." & vbCrLf)

            'Import Area Of Use data: -----------------------------------------------------------------
            Main.AreaOfUse.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".AouList"
            Main.Project.SaveXmlData(FileName, Main.AreaOfUse.ToXDoc)
            Main.AreaOfUse.ListFileName = FileName
            Main.Message.Add("Area of Use data imported." & vbCrLf)

            'Import Unit Of Measure data: -------------------------------------------------------------
            Main.UnitOfMeasure.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".UomList"
            Main.Project.SaveXmlData(FileName, Main.UnitOfMeasure.ToXDoc)
            Main.UnitOfMeasure.ListFileName = FileName
            Main.Message.Add("Unit of Measure data imported." & vbCrLf)

            'Import Prime Meridian data: --------------------------------------------------------------
            Main.PrimeMeridian.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".PmList"
            Main.Project.SaveXmlData(FileName, Main.PrimeMeridian.ToXDoc)
            Main.PrimeMeridian.ListFileName = FileName
            Main.Message.Add("Prime Meridian data imported." & vbCrLf)

            'Import Ellipsoid data: -------------------------------------------------------------------
            Main.Ellipsoid.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".EllipsoidList"
            Main.Project.SaveXmlData(FileName, Main.Ellipsoid.ToXDoc)
            Main.Ellipsoid.ListFileName = FileName
            Main.Message.Add("Ellipsoid data imported." & vbCrLf)

            'Import Projection data: ------------------------------------------------------------------
            Main.Projection.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".ProjectionList"
            Main.Project.SaveXmlData(FileName, Main.Projection.ToXDoc)
            Main.Projection.ListFileName = FileName
            Main.Message.Add("Projection data imported." & vbCrLf)

            'Import Coordinate Operation Method data: -------------------------------------------------
            Main.CoordOpMethod.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".CoordOpMethodList"
            Main.Project.SaveXmlData(FileName, Main.CoordOpMethod.ToXDoc)
            Main.CoordOpMethod.ListFileName = FileName
            Main.Message.Add("Coordinate Operation Method data imported." & vbCrLf)

            'Import Coordinate Reference System data: -------------------------------------------------
            Main.CoordRefSystem.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".CrsList"
            Main.Project.SaveXmlData(FileName, Main.CoordRefSystem.ToXDoc)
            Main.CoordRefSystem.ListFileName = FileName
            Main.Message.Add("Coordinate Reference System data imported." & vbCrLf)

            'Import Coordinate System data: -----------------------------------------------------------
            Main.CoordinateSystem.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".CoordSysList"
            Main.Project.SaveXmlData(FileName, Main.CoordinateSystem.ToXDoc)
            Main.CoordinateSystem.ListFileName = FileName
            Main.Message.Add("Coordinate System data imported." & vbCrLf)

            'Import Datum data: -----------------------------------------------------------------------
            Main.Datum.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".DatumList"
            Main.Project.SaveXmlData(FileName, Main.Datum.ToXDoc)
            Main.Datum.ListFileName = FileName
            Main.Message.Add("Datum data imported." & vbCrLf)

            'Import Transformation data: --------------------------------------------------------------
            Main.Transformation.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".TransformationList"
            Main.Project.SaveXmlData(FileName, Main.Transformation.ToXDoc)
            Main.Transformation.ListFileName = FileName
            Main.Message.Add("Transformation data imported." & vbCrLf)

            'Import Geodetic Datum data: --------------------------------------------------------------
            Main.GeodeticDatum.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".GeoDatumList"
            Main.Project.SaveXmlData(FileName, Main.GeodeticDatum.ToXDoc)
            Main.GeodeticDatum.ListFileName = FileName
            Main.Message.Add("Geodetic Datum data imported." & vbCrLf)

            'Import Vertical Datum data: --------------------------------------------------------------
            Main.VerticalDatum.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".VertDatumList"
            Main.Project.SaveXmlData(FileName, Main.VerticalDatum.ToXDoc)
            Main.VerticalDatum.ListFileName = FileName
            Main.Message.Add("Vertical Datum data imported." & vbCrLf)

            'Import Engineering Datum data: --------------------------------------------------------------
            Main.EngineeringDatum.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".EngDatumList"
            Main.Project.SaveXmlData(FileName, Main.EngineeringDatum.ToXDoc)
            Main.EngineeringDatum.ListFileName = FileName
            Main.Message.Add("Engineering Datum data imported." & vbCrLf)


            'Import Compound Coordinate reference System data: ---------------------------------------
            Main.CompoundCRS.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".CompoundCRSList"
            Main.Project.SaveXmlData(FileName, Main.CompoundCRS.ToXDoc)
            Main.CompoundCRS.ListFileName = FileName

            'Import Engineering Coordinate reference System data: ---------------------------------------
            Main.EngineeringCRS.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".EngineeringCRSList"
            Main.Project.SaveXmlData(FileName, Main.EngineeringCRS.ToXDoc)
            Main.EngineeringCRS.ListFileName = FileName

            'Import Geocentric Coordinate reference System data: ---------------------------------------
            Main.GeocentricCRS.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".GeocentricCRSList"
            Main.Project.SaveXmlData(FileName, Main.GeocentricCRS.ToXDoc)
            Main.GeocentricCRS.ListFileName = FileName
            Main.Message.Add("Geocentric Coordinate reference System data imported." & vbCrLf)

            'Import Geographic 2D Coordinate Reference System data: -----------------------------------
            Main.Geographic2DCRS.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".Geogr2DCRSList"
            Main.Project.SaveXmlData(FileName, Main.Geographic2DCRS.ToXDoc)
            Main.Geographic2DCRS.ListFileName = FileName
            Main.Message.Add("Geographic 2D Coordinate reference System data imported." & vbCrLf)

            'Import Geographic 3D Coordinate Reference System data: -----------------------------------
            Main.Geographic3DCRS.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".Geogr3DCRSList"
            Main.Project.SaveXmlData(FileName, Main.Geographic3DCRS.ToXDoc)
            Main.Geographic3DCRS.ListFileName = FileName
            Main.Message.Add("Geographic 3D Coordinate reference System data imported." & vbCrLf)

            'Import Projected Coordinate reference System data: ---------------------------------------
            Main.ProjectedCRS.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".ProjectedCRSList"
            Main.Project.SaveXmlData(FileName, Main.ProjectedCRS.ToXDoc)
            Main.ProjectedCRS.ListFileName = FileName
            Main.Message.Add("Projected Coordinate reference System data imported." & vbCrLf)

            'Import Vertical Coordinate reference System data: ---------------------------------------
            Main.VerticalCRS.LoadEpsgDbList(Main.EpsgDatabasePath)
            FileName = ImportFileNames & ".VerticalCRSList"
            Main.Project.SaveXmlData(FileName, Main.VerticalCRS.ToXDoc)
            Main.VerticalCRS.ListFileName = FileName
            Main.Message.Add("Vertical Coordinate reference System data imported." & vbCrLf)

            '------------------------------------------------------------------------------------------
            Main.Message.Add("All data imported." & vbCrLf & vbCrLf)
        Else
            Main.Message.SetWarningStyle()
            Main.Message.Add("Please select an EPSG Access database." & vbCrLf)
        End If

    End Sub

#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------




  
  
  
   
   
End Class