<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnMessages = New System.Windows.Forms.Button()
        Me.btnOnline = New System.Windows.Forms.Button()
        Me.btnConversions = New System.Windows.Forms.Button()
        Me.btnProjectionCalcs = New System.Windows.Forms.Button()
        Me.btnAppInfo = New System.Windows.Forms.Button()
        Me.btnEpsgDatabase = New System.Windows.Forms.Button()
        Me.btnProject = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnAndorville = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtLastUsed = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCreationDate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDataLocationPath = New System.Windows.Forms.TextBox()
        Me.txtDataLocationType = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSettingsLocationPath = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSettingsLocationType = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtProjectType = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProjectDescription = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProjectName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnProjections = New System.Windows.Forms.Button()
        Me.btnTransformations = New System.Windows.Forms.Button()
        Me.btnCoordOpMethods = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnAreasOfUse = New System.Windows.Forms.Button()
        Me.btnUnitsOfMeasure = New System.Windows.Forms.Button()
        Me.btnCoordinateSystems = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnEllipsoids = New System.Windows.Forms.Button()
        Me.btnPrimeMeridians = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnEngineeringDatum = New System.Windows.Forms.Button()
        Me.btnVerticalDatum = New System.Windows.Forms.Button()
        Me.btnGeodeticDatums = New System.Windows.Forms.Button()
        Me.btnDatumList = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCompound = New System.Windows.Forms.Button()
        Me.btnEngineering = New System.Windows.Forms.Button()
        Me.btnGeocentric = New System.Windows.Forms.Button()
        Me.btnGeographic3D = New System.Windows.Forms.Button()
        Me.btnVerticalCRS = New System.Windows.Forms.Button()
        Me.btnProjected = New System.Windows.Forms.Button()
        Me.btnGeographic2D = New System.Windows.Forms.Button()
        Me.btnCRSList = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(568, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnMessages
        '
        Me.btnMessages.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMessages.Location = New System.Drawing.Point(428, 12)
        Me.btnMessages.Name = "btnMessages"
        Me.btnMessages.Size = New System.Drawing.Size(72, 22)
        Me.btnMessages.TabIndex = 30
        Me.btnMessages.Text = "Messages"
        Me.btnMessages.UseVisualStyleBackColor = True
        '
        'btnOnline
        '
        Me.btnOnline.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOnline.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOnline.ForeColor = System.Drawing.Color.Red
        Me.btnOnline.Location = New System.Drawing.Point(506, 12)
        Me.btnOnline.Name = "btnOnline"
        Me.btnOnline.Size = New System.Drawing.Size(56, 22)
        Me.btnOnline.TabIndex = 35
        Me.btnOnline.Text = "Offline"
        Me.btnOnline.UseVisualStyleBackColor = True
        '
        'btnConversions
        '
        Me.btnConversions.Location = New System.Drawing.Point(6, 6)
        Me.btnConversions.Name = "btnConversions"
        Me.btnConversions.Size = New System.Drawing.Size(138, 22)
        Me.btnConversions.TabIndex = 36
        Me.btnConversions.Text = "Conversions"
        Me.btnConversions.UseVisualStyleBackColor = True
        '
        'btnProjectionCalcs
        '
        Me.btnProjectionCalcs.Location = New System.Drawing.Point(6, 34)
        Me.btnProjectionCalcs.Name = "btnProjectionCalcs"
        Me.btnProjectionCalcs.Size = New System.Drawing.Size(138, 22)
        Me.btnProjectionCalcs.TabIndex = 37
        Me.btnProjectionCalcs.Text = "Projection Calculations"
        Me.btnProjectionCalcs.UseVisualStyleBackColor = True
        '
        'btnAppInfo
        '
        Me.btnAppInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAppInfo.Location = New System.Drawing.Point(327, 12)
        Me.btnAppInfo.Name = "btnAppInfo"
        Me.btnAppInfo.Size = New System.Drawing.Size(95, 22)
        Me.btnAppInfo.TabIndex = 44
        Me.btnAppInfo.Text = "Application Info"
        Me.btnAppInfo.UseVisualStyleBackColor = True
        '
        'btnEpsgDatabase
        '
        Me.btnEpsgDatabase.Location = New System.Drawing.Point(6, 6)
        Me.btnEpsgDatabase.Name = "btnEpsgDatabase"
        Me.btnEpsgDatabase.Size = New System.Drawing.Size(105, 22)
        Me.btnEpsgDatabase.TabIndex = 45
        Me.btnEpsgDatabase.Text = "EPSG Database"
        Me.btnEpsgDatabase.UseVisualStyleBackColor = True
        '
        'btnProject
        '
        Me.btnProject.Location = New System.Drawing.Point(6, 6)
        Me.btnProject.Name = "btnProject"
        Me.btnProject.Size = New System.Drawing.Size(69, 22)
        Me.btnProject.TabIndex = 46
        Me.btnProject.Text = "Project"
        Me.btnProject.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'btnAndorville
        '
        Me.btnAndorville.BackgroundImage = Global.ADVL_Coordinates.My.Resources.Resources.Andorville_16May16_TM_Crop_Grey
        Me.btnAndorville.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAndorville.Font = New System.Drawing.Font("Harlow Solid Italic", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAndorville.Location = New System.Drawing.Point(5, 5)
        Me.btnAndorville.Name = "btnAndorville"
        Me.btnAndorville.Size = New System.Drawing.Size(118, 29)
        Me.btnAndorville.TabIndex = 48
        Me.btnAndorville.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(620, 343)
        Me.TabControl1.TabIndex = 49
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.txtLastUsed)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.btnProject)
        Me.TabPage1.Controls.Add(Me.txtCreationDate)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtDataLocationPath)
        Me.TabPage1.Controls.Add(Me.txtDataLocationType)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtSettingsLocationPath)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtSettingsLocationType)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtProjectType)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtProjectDescription)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtProjectName)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(612, 317)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Project Information"
        '
        'txtLastUsed
        '
        Me.txtLastUsed.Location = New System.Drawing.Point(457, 116)
        Me.txtLastUsed.Name = "txtLastUsed"
        Me.txtLastUsed.Size = New System.Drawing.Size(150, 20)
        Me.txtLastUsed.TabIndex = 35
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(374, 119)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Date last used:"
        '
        'txtCreationDate
        '
        Me.txtCreationDate.Location = New System.Drawing.Point(217, 115)
        Me.txtCreationDate.Name = "txtCreationDate"
        Me.txtCreationDate.Size = New System.Drawing.Size(150, 20)
        Me.txtCreationDate.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(138, 119)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Creation date:"
        '
        'txtDataLocationPath
        '
        Me.txtDataLocationPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDataLocationPath.Location = New System.Drawing.Point(215, 193)
        Me.txtDataLocationPath.Multiline = True
        Me.txtDataLocationPath.Name = "txtDataLocationPath"
        Me.txtDataLocationPath.Size = New System.Drawing.Size(391, 46)
        Me.txtDataLocationPath.TabIndex = 31
        '
        'txtDataLocationType
        '
        Me.txtDataLocationType.Location = New System.Drawing.Point(124, 193)
        Me.txtDataLocationType.Name = "txtDataLocationType"
        Me.txtDataLocationType.Size = New System.Drawing.Size(85, 20)
        Me.txtDataLocationType.TabIndex = 30
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(112, 222)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Data location path:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Data location type:"
        '
        'txtSettingsLocationPath
        '
        Me.txtSettingsLocationPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSettingsLocationPath.Location = New System.Drawing.Point(215, 141)
        Me.txtSettingsLocationPath.Multiline = True
        Me.txtSettingsLocationPath.Name = "txtSettingsLocationPath"
        Me.txtSettingsLocationPath.Size = New System.Drawing.Size(391, 46)
        Me.txtSettingsLocationPath.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(97, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Settings location path:"
        '
        'txtSettingsLocationType
        '
        Me.txtSettingsLocationType.Location = New System.Drawing.Point(123, 141)
        Me.txtSettingsLocationType.Name = "txtSettingsLocationType"
        Me.txtSettingsLocationType.Size = New System.Drawing.Size(86, 20)
        Me.txtSettingsLocationType.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Settings location type:"
        '
        'txtProjectType
        '
        Me.txtProjectType.Location = New System.Drawing.Point(46, 116)
        Me.txtProjectType.Name = "txtProjectType"
        Me.txtProjectType.Size = New System.Drawing.Size(86, 20)
        Me.txtProjectType.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Type:"
        '
        'txtProjectDescription
        '
        Me.txtProjectDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjectDescription.Location = New System.Drawing.Point(123, 69)
        Me.txtProjectDescription.Multiline = True
        Me.txtProjectDescription.Name = "txtProjectDescription"
        Me.txtProjectDescription.Size = New System.Drawing.Size(483, 40)
        Me.txtProjectDescription.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Description:"
        '
        'txtProjectName
        '
        Me.txtProjectName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjectName.Location = New System.Drawing.Point(123, 43)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(483, 20)
        Me.txtProjectName.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Name:"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.btnEpsgDatabase)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(612, 317)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Geodetic Parameters"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnCRSList)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(600, 277)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Coordinate Reference Systems"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox6.Controls.Add(Me.btnProjections)
        Me.GroupBox6.Controls.Add(Me.btnTransformations)
        Me.GroupBox6.Controls.Add(Me.btnCoordOpMethods)
        Me.GroupBox6.Location = New System.Drawing.Point(369, 47)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(134, 125)
        Me.GroupBox6.TabIndex = 29
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Coordinate Processes"
        '
        'btnProjections
        '
        Me.btnProjections.Location = New System.Drawing.Point(6, 19)
        Me.btnProjections.Name = "btnProjections"
        Me.btnProjections.Size = New System.Drawing.Size(118, 22)
        Me.btnProjections.TabIndex = 5
        Me.btnProjections.Text = "Projections"
        Me.btnProjections.UseVisualStyleBackColor = True
        '
        'btnTransformations
        '
        Me.btnTransformations.Location = New System.Drawing.Point(6, 47)
        Me.btnTransformations.Name = "btnTransformations"
        Me.btnTransformations.Size = New System.Drawing.Size(118, 22)
        Me.btnTransformations.TabIndex = 1
        Me.btnTransformations.Text = "Transformations"
        Me.btnTransformations.UseVisualStyleBackColor = True
        '
        'btnCoordOpMethods
        '
        Me.btnCoordOpMethods.Location = New System.Drawing.Point(6, 75)
        Me.btnCoordOpMethods.Name = "btnCoordOpMethods"
        Me.btnCoordOpMethods.Size = New System.Drawing.Size(118, 39)
        Me.btnCoordOpMethods.TabIndex = 27
        Me.btnCoordOpMethods.Text = "Coordinate Operation Methods"
        Me.btnCoordOpMethods.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox3.Controls.Add(Me.btnAreasOfUse)
        Me.GroupBox3.Controls.Add(Me.btnUnitsOfMeasure)
        Me.GroupBox3.Controls.Add(Me.btnCoordinateSystems)
        Me.GroupBox3.Location = New System.Drawing.Point(243, 47)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(120, 125)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "General Parameters"
        '
        'btnAreasOfUse
        '
        Me.btnAreasOfUse.Location = New System.Drawing.Point(6, 19)
        Me.btnAreasOfUse.Name = "btnAreasOfUse"
        Me.btnAreasOfUse.Size = New System.Drawing.Size(107, 22)
        Me.btnAreasOfUse.TabIndex = 2
        Me.btnAreasOfUse.Text = "Areas of Use"
        Me.btnAreasOfUse.UseVisualStyleBackColor = True
        '
        'btnUnitsOfMeasure
        '
        Me.btnUnitsOfMeasure.Location = New System.Drawing.Point(6, 47)
        Me.btnUnitsOfMeasure.Name = "btnUnitsOfMeasure"
        Me.btnUnitsOfMeasure.Size = New System.Drawing.Size(107, 22)
        Me.btnUnitsOfMeasure.TabIndex = 2
        Me.btnUnitsOfMeasure.Text = "Units of Measure"
        Me.btnUnitsOfMeasure.UseVisualStyleBackColor = True
        '
        'btnCoordinateSystems
        '
        Me.btnCoordinateSystems.Location = New System.Drawing.Point(6, 75)
        Me.btnCoordinateSystems.Name = "btnCoordinateSystems"
        Me.btnCoordinateSystems.Size = New System.Drawing.Size(107, 39)
        Me.btnCoordinateSystems.TabIndex = 6
        Me.btnCoordinateSystems.Text = "Coordinate Systems"
        Me.btnCoordinateSystems.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox4.Controls.Add(Me.btnEllipsoids)
        Me.GroupBox4.Controls.Add(Me.btnPrimeMeridians)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.btnDatumList)
        Me.GroupBox4.Location = New System.Drawing.Point(119, 47)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(118, 220)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datums"
        '
        'btnEllipsoids
        '
        Me.btnEllipsoids.Location = New System.Drawing.Point(6, 183)
        Me.btnEllipsoids.Name = "btnEllipsoids"
        Me.btnEllipsoids.Size = New System.Drawing.Size(100, 22)
        Me.btnEllipsoids.TabIndex = 21
        Me.btnEllipsoids.Text = "Ellipsoids"
        Me.btnEllipsoids.UseVisualStyleBackColor = True
        '
        'btnPrimeMeridians
        '
        Me.btnPrimeMeridians.Location = New System.Drawing.Point(6, 155)
        Me.btnPrimeMeridians.Name = "btnPrimeMeridians"
        Me.btnPrimeMeridians.Size = New System.Drawing.Size(100, 22)
        Me.btnPrimeMeridians.TabIndex = 20
        Me.btnPrimeMeridians.Text = "Prime Meridians"
        Me.btnPrimeMeridians.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Silver
        Me.GroupBox5.Controls.Add(Me.btnEngineeringDatum)
        Me.GroupBox5.Controls.Add(Me.btnVerticalDatum)
        Me.GroupBox5.Controls.Add(Me.btnGeodeticDatums)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 47)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(100, 102)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Datum Types"
        '
        'btnEngineeringDatum
        '
        Me.btnEngineeringDatum.Location = New System.Drawing.Point(6, 75)
        Me.btnEngineeringDatum.Name = "btnEngineeringDatum"
        Me.btnEngineeringDatum.Size = New System.Drawing.Size(88, 22)
        Me.btnEngineeringDatum.TabIndex = 3
        Me.btnEngineeringDatum.Text = "Engineering"
        Me.btnEngineeringDatum.UseVisualStyleBackColor = True
        '
        'btnVerticalDatum
        '
        Me.btnVerticalDatum.Location = New System.Drawing.Point(6, 47)
        Me.btnVerticalDatum.Name = "btnVerticalDatum"
        Me.btnVerticalDatum.Size = New System.Drawing.Size(88, 22)
        Me.btnVerticalDatum.TabIndex = 2
        Me.btnVerticalDatum.Text = "Vertical"
        Me.btnVerticalDatum.UseVisualStyleBackColor = True
        '
        'btnGeodeticDatums
        '
        Me.btnGeodeticDatums.Location = New System.Drawing.Point(6, 19)
        Me.btnGeodeticDatums.Name = "btnGeodeticDatums"
        Me.btnGeodeticDatums.Size = New System.Drawing.Size(88, 22)
        Me.btnGeodeticDatums.TabIndex = 0
        Me.btnGeodeticDatums.Text = "Geodetic"
        Me.btnGeodeticDatums.UseVisualStyleBackColor = True
        '
        'btnDatumList
        '
        Me.btnDatumList.Location = New System.Drawing.Point(6, 19)
        Me.btnDatumList.Name = "btnDatumList"
        Me.btnDatumList.Size = New System.Drawing.Size(100, 22)
        Me.btnDatumList.TabIndex = 0
        Me.btnDatumList.Text = "Datum List"
        Me.btnDatumList.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Controls.Add(Me.btnCompound)
        Me.GroupBox2.Controls.Add(Me.btnEngineering)
        Me.GroupBox2.Controls.Add(Me.btnGeocentric)
        Me.GroupBox2.Controls.Add(Me.btnGeographic3D)
        Me.GroupBox2.Controls.Add(Me.btnVerticalCRS)
        Me.GroupBox2.Controls.Add(Me.btnProjected)
        Me.GroupBox2.Controls.Add(Me.btnGeographic2D)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(107, 220)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CRS Types"
        '
        'btnCompound
        '
        Me.btnCompound.Location = New System.Drawing.Point(6, 19)
        Me.btnCompound.Name = "btnCompound"
        Me.btnCompound.Size = New System.Drawing.Size(92, 22)
        Me.btnCompound.TabIndex = 6
        Me.btnCompound.Text = "Compound"
        Me.btnCompound.UseVisualStyleBackColor = True
        '
        'btnEngineering
        '
        Me.btnEngineering.Location = New System.Drawing.Point(6, 47)
        Me.btnEngineering.Name = "btnEngineering"
        Me.btnEngineering.Size = New System.Drawing.Size(92, 22)
        Me.btnEngineering.TabIndex = 5
        Me.btnEngineering.Text = "Engineering"
        Me.btnEngineering.UseVisualStyleBackColor = True
        '
        'btnGeocentric
        '
        Me.btnGeocentric.Location = New System.Drawing.Point(6, 75)
        Me.btnGeocentric.Name = "btnGeocentric"
        Me.btnGeocentric.Size = New System.Drawing.Size(92, 22)
        Me.btnGeocentric.TabIndex = 4
        Me.btnGeocentric.Text = "Geocentric"
        Me.btnGeocentric.UseVisualStyleBackColor = True
        '
        'btnGeographic3D
        '
        Me.btnGeographic3D.Location = New System.Drawing.Point(6, 131)
        Me.btnGeographic3D.Name = "btnGeographic3D"
        Me.btnGeographic3D.Size = New System.Drawing.Size(92, 22)
        Me.btnGeographic3D.TabIndex = 3
        Me.btnGeographic3D.Text = "Geographic 3D"
        Me.btnGeographic3D.UseVisualStyleBackColor = True
        '
        'btnVerticalCRS
        '
        Me.btnVerticalCRS.Location = New System.Drawing.Point(6, 187)
        Me.btnVerticalCRS.Name = "btnVerticalCRS"
        Me.btnVerticalCRS.Size = New System.Drawing.Size(92, 22)
        Me.btnVerticalCRS.TabIndex = 2
        Me.btnVerticalCRS.Text = "Vertical"
        Me.btnVerticalCRS.UseVisualStyleBackColor = True
        '
        'btnProjected
        '
        Me.btnProjected.Location = New System.Drawing.Point(6, 159)
        Me.btnProjected.Name = "btnProjected"
        Me.btnProjected.Size = New System.Drawing.Size(92, 22)
        Me.btnProjected.TabIndex = 1
        Me.btnProjected.Text = "Projected"
        Me.btnProjected.UseVisualStyleBackColor = True
        '
        'btnGeographic2D
        '
        Me.btnGeographic2D.Location = New System.Drawing.Point(6, 103)
        Me.btnGeographic2D.Name = "btnGeographic2D"
        Me.btnGeographic2D.Size = New System.Drawing.Size(92, 22)
        Me.btnGeographic2D.TabIndex = 0
        Me.btnGeographic2D.Text = "Geographic 2D"
        Me.btnGeographic2D.UseVisualStyleBackColor = True
        '
        'btnCRSList
        '
        Me.btnCRSList.Location = New System.Drawing.Point(6, 19)
        Me.btnCRSList.Name = "btnCRSList"
        Me.btnCRSList.Size = New System.Drawing.Size(107, 22)
        Me.btnCRSList.TabIndex = 0
        Me.btnCRSList.Text = "CRS List"
        Me.btnCRSList.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.White
        Me.TabPage3.Controls.Add(Me.btnConversions)
        Me.TabPage3.Controls.Add(Me.btnProjectionCalcs)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(612, 317)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Coordinate Conversions"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 395)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnAndorville)
        Me.Controls.Add(Me.btnAppInfo)
        Me.Controls.Add(Me.btnOnline)
        Me.Controls.Add(Me.btnMessages)
        Me.Controls.Add(Me.btnExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "Coordinates"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnMessages As System.Windows.Forms.Button
    Friend WithEvents btnOnline As System.Windows.Forms.Button
    Friend WithEvents btnConversions As System.Windows.Forms.Button
    Friend WithEvents btnProjectionCalcs As System.Windows.Forms.Button
    Friend WithEvents btnAppInfo As System.Windows.Forms.Button
    Friend WithEvents btnEpsgDatabase As System.Windows.Forms.Button
    Friend WithEvents btnProject As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnAndorville As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents txtLastUsed As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtCreationDate As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtDataLocationPath As TextBox
    Friend WithEvents txtDataLocationType As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSettingsLocationPath As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSettingsLocationType As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtProjectType As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtProjectDescription As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtProjectName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents btnProjections As Button
    Friend WithEvents btnTransformations As Button
    Friend WithEvents btnCoordOpMethods As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnAreasOfUse As Button
    Friend WithEvents btnUnitsOfMeasure As Button
    Friend WithEvents btnCoordinateSystems As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnEllipsoids As Button
    Friend WithEvents btnPrimeMeridians As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents btnEngineeringDatum As Button
    Friend WithEvents btnVerticalDatum As Button
    Friend WithEvents btnGeodeticDatums As Button
    Friend WithEvents btnDatumList As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnCompound As Button
    Friend WithEvents btnEngineering As Button
    Friend WithEvents btnGeocentric As Button
    Friend WithEvents btnGeographic3D As Button
    Friend WithEvents btnVerticalCRS As Button
    Friend WithEvents btnProjected As Button
    Friend WithEvents btnGeographic2D As Button
    Friend WithEvents btnCRSList As Button
End Class
