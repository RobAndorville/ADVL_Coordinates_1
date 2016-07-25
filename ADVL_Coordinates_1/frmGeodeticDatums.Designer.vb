<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeodeticDatums
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
        Me.btnNameFindNext = New System.Windows.Forms.Button()
        Me.txtSearchText = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNameFind = New System.Windows.Forms.Button()
        Me.txtDatumName = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnGetEpsgList = New System.Windows.Forms.Button()
        Me.btnMoveDown = New System.Windows.Forms.Button()
        Me.btnMoveUp = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtDatumListFileName = New System.Windows.Forms.TextBox()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.txtRecordNo = New System.Windows.Forms.TextBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.txtNRecords = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtDatumAuthor = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.txtDatumDeprecated = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtDatumScope = New System.Windows.Forms.TextBox()
        Me.txtDatumOrigin = New System.Windows.Forms.TextBox()
        Me.txtDatumCode = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtGeodeticDatumName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbDatumAliasNames = New System.Windows.Forms.ComboBox()
        Me.btnDelAlias = New System.Windows.Forms.Button()
        Me.btnAddAlias = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDatumComments = New System.Windows.Forms.TextBox()
        Me.txtNewAliasName = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtEllipsoidAuthor = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.txtAxisUnits = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.txtEllipsoidCode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbEllipsoidAliasNames = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSemiMinorAxis = New System.Windows.Forms.TextBox()
        Me.txtInverseFlattening = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSemiMajorAxis = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbSemiMajorAndSemiMinor = New System.Windows.Forms.RadioButton()
        Me.rbSemiMajorAndInverseFlat = New System.Windows.Forms.RadioButton()
        Me.txtEllipsoidComments = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtEllipsoidName = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtPmAuthor = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.txtPmSexagesimalDegrees = New System.Windows.Forms.TextBox()
        Me.txtPmDecimalDegrees = New System.Windows.Forms.TextBox()
        Me.txtPmCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPmWE = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtPmRadians = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbPmUnits = New System.Windows.Forms.ComboBox()
        Me.txtPmGrads = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtPmSeconds = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtPmMinutes = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtPmDegrees = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtPrimeMeridianComments = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cmbPrimeMeridianAliasNames = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtPrimeMeridianName = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtAreaAuthor = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.txtAouDescription = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNLatDegrees = New System.Windows.Forms.TextBox()
        Me.cmbWLongWE = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtNLatMinutes = New System.Windows.Forms.TextBox()
        Me.txtWLongSeconds = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtNLatSeconds = New System.Windows.Forms.TextBox()
        Me.txtWLongMinutes = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cmbNLatNS = New System.Windows.Forms.ComboBox()
        Me.txtWLongDegrees = New System.Windows.Forms.TextBox()
        Me.txtSLatDegrees = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.cmbELongWE = New System.Windows.Forms.ComboBox()
        Me.txtSLatMinutes = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtELongSeconds = New System.Windows.Forms.TextBox()
        Me.txtSLatSeconds = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtELongMinutes = New System.Windows.Forms.TextBox()
        Me.cmbSLatNS = New System.Windows.Forms.ComboBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtELongDegrees = New System.Windows.Forms.TextBox()
        Me.txtIsoNumericCode = New System.Windows.Forms.TextBox()
        Me.txtAreaOfUseName = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.txtIso3CharCode = New System.Windows.Forms.TextBox()
        Me.txtAouCode = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtIso2CharCode = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.txtAouComments = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.cmbAouAliasNames = New System.Windows.Forms.ComboBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnNameFindPrev = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNameFindNext
        '
        Me.btnNameFindNext.Location = New System.Drawing.Point(280, 12)
        Me.btnNameFindNext.Name = "btnNameFindNext"
        Me.btnNameFindNext.Size = New System.Drawing.Size(40, 22)
        Me.btnNameFindNext.TabIndex = 200
        Me.btnNameFindNext.Text = "Next"
        Me.btnNameFindNext.UseVisualStyleBackColor = True
        '
        'txtSearchText
        '
        Me.txtSearchText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchText.Location = New System.Drawing.Point(326, 13)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(344, 20)
        Me.txtSearchText.TabIndex = 199
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(52, 22)
        Me.btnSave.TabIndex = 196
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNameFind
        '
        Me.btnNameFind.Location = New System.Drawing.Point(170, 12)
        Me.btnNameFind.Name = "btnNameFind"
        Me.btnNameFind.Size = New System.Drawing.Size(58, 22)
        Me.btnNameFind.TabIndex = 198
        Me.btnNameFind.Text = "Find First"
        Me.btnNameFind.UseVisualStyleBackColor = True
        '
        'txtDatumName
        '
        Me.txtDatumName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatumName.Location = New System.Drawing.Point(603, 68)
        Me.txtDatumName.Name = "txtDatumName"
        Me.txtDatumName.Size = New System.Drawing.Size(137, 20)
        Me.txtDatumName.TabIndex = 195
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 13)
        Me.Label11.TabIndex = 194
        Me.Label11.Text = "Datum list file:"
        '
        'btnGetEpsgList
        '
        Me.btnGetEpsgList.Location = New System.Drawing.Point(70, 12)
        Me.btnGetEpsgList.Name = "btnGetEpsgList"
        Me.btnGetEpsgList.Size = New System.Drawing.Size(94, 22)
        Me.btnGetEpsgList.TabIndex = 183
        Me.btnGetEpsgList.Text = "Get EPSG List"
        Me.btnGetEpsgList.UseVisualStyleBackColor = True
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Location = New System.Drawing.Point(523, 68)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(74, 22)
        Me.btnMoveDown.TabIndex = 193
        Me.btnMoveDown.Text = "Move Dwn"
        Me.btnMoveDown.UseVisualStyleBackColor = True
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Location = New System.Drawing.Point(456, 68)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(61, 22)
        Me.btnMoveUp.TabIndex = 192
        Me.btnMoveUp.Text = "Move Up"
        Me.btnMoveUp.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(676, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 178
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Location = New System.Drawing.Point(411, 68)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(39, 22)
        Me.btnDel.TabIndex = 191
        Me.btnDel.Text = "Del"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFind.Location = New System.Drawing.Point(692, 40)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(48, 22)
        Me.btnFind.TabIndex = 180
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(366, 68)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(39, 22)
        Me.btnAdd.TabIndex = 190
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtDatumListFileName
        '
        Me.txtDatumListFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatumListFileName.Location = New System.Drawing.Point(90, 42)
        Me.txtDatumListFileName.Name = "txtDatumListFileName"
        Me.txtDatumListFileName.Size = New System.Drawing.Size(596, 20)
        Me.txtDatumListFileName.TabIndex = 179
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(321, 68)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(39, 22)
        Me.btnLast.TabIndex = 187
        Me.btnLast.Text = "Last"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'txtRecordNo
        '
        Me.txtRecordNo.Location = New System.Drawing.Point(60, 68)
        Me.txtRecordNo.Name = "txtRecordNo"
        Me.txtRecordNo.Size = New System.Drawing.Size(45, 20)
        Me.txtRecordNo.TabIndex = 189
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(276, 68)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(39, 22)
        Me.btnNext.TabIndex = 186
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 188
        Me.Label9.Text = "Record"
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(231, 68)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(39, 22)
        Me.btnPrev.TabIndex = 185
        Me.btnPrev.Text = "Prev"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(111, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(16, 13)
        Me.Label10.TabIndex = 182
        Me.Label10.Text = "of"
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(186, 68)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(39, 22)
        Me.btnFirst.TabIndex = 184
        Me.btnFirst.Text = "First"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'txtNRecords
        '
        Me.txtNRecords.Location = New System.Drawing.Point(133, 68)
        Me.txtNRecords.Name = "txtNRecords"
        Me.txtNRecords.ReadOnly = True
        Me.txtNRecords.Size = New System.Drawing.Size(47, 20)
        Me.txtNRecords.TabIndex = 181
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(12, 96)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(728, 468)
        Me.TabControl1.TabIndex = 201
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtDatumAuthor)
        Me.TabPage1.Controls.Add(Me.Label56)
        Me.TabPage1.Controls.Add(Me.txtDatumDeprecated)
        Me.TabPage1.Controls.Add(Me.Label52)
        Me.TabPage1.Controls.Add(Me.txtDatumScope)
        Me.TabPage1.Controls.Add(Me.txtDatumOrigin)
        Me.TabPage1.Controls.Add(Me.txtDatumCode)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtGeodeticDatumName)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.cmbDatumAliasNames)
        Me.TabPage1.Controls.Add(Me.btnDelAlias)
        Me.TabPage1.Controls.Add(Me.btnAddAlias)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtDatumComments)
        Me.TabPage1.Controls.Add(Me.txtNewAliasName)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(720, 442)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Geodetic Datum"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtDatumAuthor
        '
        Me.txtDatumAuthor.Location = New System.Drawing.Point(81, 54)
        Me.txtDatumAuthor.Name = "txtDatumAuthor"
        Me.txtDatumAuthor.Size = New System.Drawing.Size(131, 20)
        Me.txtDatumAuthor.TabIndex = 155
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(6, 57)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(41, 13)
        Me.Label56.TabIndex = 154
        Me.Label56.Text = "Author:"
        '
        'txtDatumDeprecated
        '
        Me.txtDatumDeprecated.Location = New System.Drawing.Point(509, 54)
        Me.txtDatumDeprecated.Name = "txtDatumDeprecated"
        Me.txtDatumDeprecated.Size = New System.Drawing.Size(66, 20)
        Me.txtDatumDeprecated.TabIndex = 153
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(437, 57)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(66, 13)
        Me.Label52.TabIndex = 152
        Me.Label52.Text = "Deprecated:"
        '
        'txtDatumScope
        '
        Me.txtDatumScope.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatumScope.Location = New System.Drawing.Point(81, 285)
        Me.txtDatumScope.Multiline = True
        Me.txtDatumScope.Name = "txtDatumScope"
        Me.txtDatumScope.Size = New System.Drawing.Size(633, 69)
        Me.txtDatumScope.TabIndex = 151
        '
        'txtDatumOrigin
        '
        Me.txtDatumOrigin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatumOrigin.Location = New System.Drawing.Point(81, 210)
        Me.txtDatumOrigin.Multiline = True
        Me.txtDatumOrigin.Name = "txtDatumOrigin"
        Me.txtDatumOrigin.Size = New System.Drawing.Size(633, 69)
        Me.txtDatumOrigin.TabIndex = 150
        '
        'txtDatumCode
        '
        Me.txtDatumCode.Location = New System.Drawing.Point(290, 54)
        Me.txtDatumCode.Name = "txtDatumCode"
        Me.txtDatumCode.Size = New System.Drawing.Size(107, 20)
        Me.txtDatumCode.TabIndex = 149
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(249, 57)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(35, 13)
        Me.Label26.TabIndex = 148
        Me.Label26.Text = "Code:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Geodetic datum name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 288)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Scope:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 212)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Datum Origin:"
        '
        'txtGeodeticDatumName
        '
        Me.txtGeodeticDatumName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGeodeticDatumName.Location = New System.Drawing.Point(126, 28)
        Me.txtGeodeticDatumName.Name = "txtGeodeticDatumName"
        Me.txtGeodeticDatumName.Size = New System.Drawing.Size(588, 20)
        Me.txtGeodeticDatumName.TabIndex = 56
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "Alias names:"
        '
        'cmbDatumAliasNames
        '
        Me.cmbDatumAliasNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDatumAliasNames.FormattingEnabled = True
        Me.cmbDatumAliasNames.Location = New System.Drawing.Point(81, 80)
        Me.cmbDatumAliasNames.Name = "cmbDatumAliasNames"
        Me.cmbDatumAliasNames.Size = New System.Drawing.Size(588, 21)
        Me.cmbDatumAliasNames.TabIndex = 61
        '
        'btnDelAlias
        '
        Me.btnDelAlias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelAlias.Location = New System.Drawing.Point(675, 80)
        Me.btnDelAlias.Name = "btnDelAlias"
        Me.btnDelAlias.Size = New System.Drawing.Size(39, 22)
        Me.btnDelAlias.TabIndex = 63
        Me.btnDelAlias.Text = "Del"
        Me.btnDelAlias.UseVisualStyleBackColor = True
        '
        'btnAddAlias
        '
        Me.btnAddAlias.Location = New System.Drawing.Point(9, 107)
        Me.btnAddAlias.Name = "btnAddAlias"
        Me.btnAddAlias.Size = New System.Drawing.Size(77, 22)
        Me.btnAddAlias.TabIndex = 62
        Me.btnAddAlias.Text = "Add Alias"
        Me.btnAddAlias.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Comments:"
        '
        'txtDatumComments
        '
        Me.txtDatumComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatumComments.Location = New System.Drawing.Point(81, 135)
        Me.txtDatumComments.Multiline = True
        Me.txtDatumComments.Name = "txtDatumComments"
        Me.txtDatumComments.Size = New System.Drawing.Size(633, 69)
        Me.txtDatumComments.TabIndex = 66
        '
        'txtNewAliasName
        '
        Me.txtNewAliasName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewAliasName.Location = New System.Drawing.Point(92, 108)
        Me.txtNewAliasName.Name = "txtNewAliasName"
        Me.txtNewAliasName.Size = New System.Drawing.Size(622, 20)
        Me.txtNewAliasName.TabIndex = 64
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtEllipsoidAuthor)
        Me.TabPage3.Controls.Add(Me.Label59)
        Me.TabPage3.Controls.Add(Me.txtAxisUnits)
        Me.TabPage3.Controls.Add(Me.Label57)
        Me.TabPage3.Controls.Add(Me.txtEllipsoidCode)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.cmbEllipsoidAliasNames)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.txtSemiMinorAxis)
        Me.TabPage3.Controls.Add(Me.txtInverseFlattening)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.txtSemiMajorAxis)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.txtEllipsoidComments)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.txtEllipsoidName)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(720, 442)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Ellipsoid"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtEllipsoidAuthor
        '
        Me.txtEllipsoidAuthor.Location = New System.Drawing.Point(88, 49)
        Me.txtEllipsoidAuthor.Name = "txtEllipsoidAuthor"
        Me.txtEllipsoidAuthor.Size = New System.Drawing.Size(219, 20)
        Me.txtEllipsoidAuthor.TabIndex = 164
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(39, 50)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(41, 13)
        Me.Label59.TabIndex = 163
        Me.Label59.Text = "Author:"
        '
        'txtAxisUnits
        '
        Me.txtAxisUnits.Location = New System.Drawing.Point(341, 249)
        Me.txtAxisUnits.Name = "txtAxisUnits"
        Me.txtAxisUnits.Size = New System.Drawing.Size(144, 20)
        Me.txtAxisUnits.TabIndex = 162
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(236, 252)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(54, 13)
        Me.Label57.TabIndex = 161
        Me.Label57.Text = "Axis units:"
        '
        'txtEllipsoidCode
        '
        Me.txtEllipsoidCode.Location = New System.Drawing.Point(357, 49)
        Me.txtEllipsoidCode.Name = "txtEllipsoidCode"
        Me.txtEllipsoidCode.Size = New System.Drawing.Size(83, 20)
        Me.txtEllipsoidCode.TabIndex = 150
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(316, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 149
        Me.Label6.Text = "Code:"
        '
        'cmbEllipsoidAliasNames
        '
        Me.cmbEllipsoidAliasNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEllipsoidAliasNames.FormattingEnabled = True
        Me.cmbEllipsoidAliasNames.Location = New System.Drawing.Point(88, 76)
        Me.cmbEllipsoidAliasNames.Name = "cmbEllipsoidAliasNames"
        Me.cmbEllipsoidAliasNames.Size = New System.Drawing.Size(616, 21)
        Me.cmbEllipsoidAliasNames.TabIndex = 148
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 79)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 147
        Me.Label12.Text = "Alias names:"
        '
        'txtSemiMinorAxis
        '
        Me.txtSemiMinorAxis.Location = New System.Drawing.Point(341, 223)
        Me.txtSemiMinorAxis.Name = "txtSemiMinorAxis"
        Me.txtSemiMinorAxis.Size = New System.Drawing.Size(255, 20)
        Me.txtSemiMinorAxis.TabIndex = 146
        '
        'txtInverseFlattening
        '
        Me.txtInverseFlattening.Location = New System.Drawing.Point(341, 197)
        Me.txtInverseFlattening.Name = "txtInverseFlattening"
        Me.txtInverseFlattening.Size = New System.Drawing.Size(255, 20)
        Me.txtInverseFlattening.TabIndex = 145
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(236, 226)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 13)
        Me.Label13.TabIndex = 144
        Me.Label13.Text = "Semi minor axis:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(236, 200)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 13)
        Me.Label14.TabIndex = 143
        Me.Label14.Text = "Inverse flattening:"
        '
        'txtSemiMajorAxis
        '
        Me.txtSemiMajorAxis.Location = New System.Drawing.Point(341, 171)
        Me.txtSemiMajorAxis.Name = "txtSemiMajorAxis"
        Me.txtSemiMajorAxis.Size = New System.Drawing.Size(255, 20)
        Me.txtSemiMajorAxis.TabIndex = 142
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(236, 174)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 13)
        Me.Label15.TabIndex = 141
        Me.Label15.Text = "Semi major axis:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSemiMajorAndSemiMinor)
        Me.GroupBox1.Controls.Add(Me.rbSemiMajorAndInverseFlat)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 171)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(213, 71)
        Me.GroupBox1.TabIndex = 140
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Defined by:"
        '
        'rbSemiMajorAndSemiMinor
        '
        Me.rbSemiMajorAndSemiMinor.AutoSize = True
        Me.rbSemiMajorAndSemiMinor.Location = New System.Drawing.Point(6, 42)
        Me.rbSemiMajorAndSemiMinor.Name = "rbSemiMajorAndSemiMinor"
        Me.rbSemiMajorAndSemiMinor.Size = New System.Drawing.Size(174, 17)
        Me.rbSemiMajorAndSemiMinor.TabIndex = 1
        Me.rbSemiMajorAndSemiMinor.TabStop = True
        Me.rbSemiMajorAndSemiMinor.Text = "Semi major and semi minor axes"
        Me.rbSemiMajorAndSemiMinor.UseVisualStyleBackColor = True
        '
        'rbSemiMajorAndInverseFlat
        '
        Me.rbSemiMajorAndInverseFlat.AutoSize = True
        Me.rbSemiMajorAndInverseFlat.Location = New System.Drawing.Point(6, 19)
        Me.rbSemiMajorAndInverseFlat.Name = "rbSemiMajorAndInverseFlat"
        Me.rbSemiMajorAndInverseFlat.Size = New System.Drawing.Size(201, 17)
        Me.rbSemiMajorAndInverseFlat.TabIndex = 0
        Me.rbSemiMajorAndInverseFlat.TabStop = True
        Me.rbSemiMajorAndInverseFlat.Text = "Semi major axis and inverse flattening"
        Me.rbSemiMajorAndInverseFlat.UseVisualStyleBackColor = True
        '
        'txtEllipsoidComments
        '
        Me.txtEllipsoidComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEllipsoidComments.Location = New System.Drawing.Point(88, 103)
        Me.txtEllipsoidComments.Multiline = True
        Me.txtEllipsoidComments.Name = "txtEllipsoidComments"
        Me.txtEllipsoidComments.Size = New System.Drawing.Size(616, 53)
        Me.txtEllipsoidComments.TabIndex = 139
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 106)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 138
        Me.Label16.Text = "Comments:"
        '
        'txtEllipsoidName
        '
        Me.txtEllipsoidName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEllipsoidName.Location = New System.Drawing.Point(88, 23)
        Me.txtEllipsoidName.Name = "txtEllipsoidName"
        Me.txtEllipsoidName.Size = New System.Drawing.Size(616, 20)
        Me.txtEllipsoidName.TabIndex = 137
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 13)
        Me.Label17.TabIndex = 136
        Me.Label17.Text = "Ellipsoid name:"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.txtPmAuthor)
        Me.TabPage4.Controls.Add(Me.Label58)
        Me.TabPage4.Controls.Add(Me.Label54)
        Me.TabPage4.Controls.Add(Me.Label53)
        Me.TabPage4.Controls.Add(Me.txtPmSexagesimalDegrees)
        Me.TabPage4.Controls.Add(Me.txtPmDecimalDegrees)
        Me.TabPage4.Controls.Add(Me.txtPmCode)
        Me.TabPage4.Controls.Add(Me.Label5)
        Me.TabPage4.Controls.Add(Me.cmbPmWE)
        Me.TabPage4.Controls.Add(Me.Label18)
        Me.TabPage4.Controls.Add(Me.txtPmRadians)
        Me.TabPage4.Controls.Add(Me.Label19)
        Me.TabPage4.Controls.Add(Me.Label20)
        Me.TabPage4.Controls.Add(Me.cmbPmUnits)
        Me.TabPage4.Controls.Add(Me.txtPmGrads)
        Me.TabPage4.Controls.Add(Me.Label21)
        Me.TabPage4.Controls.Add(Me.txtPmSeconds)
        Me.TabPage4.Controls.Add(Me.Label22)
        Me.TabPage4.Controls.Add(Me.txtPmMinutes)
        Me.TabPage4.Controls.Add(Me.Label23)
        Me.TabPage4.Controls.Add(Me.txtPmDegrees)
        Me.TabPage4.Controls.Add(Me.Label24)
        Me.TabPage4.Controls.Add(Me.txtPrimeMeridianComments)
        Me.TabPage4.Controls.Add(Me.Label25)
        Me.TabPage4.Controls.Add(Me.cmbPrimeMeridianAliasNames)
        Me.TabPage4.Controls.Add(Me.Label27)
        Me.TabPage4.Controls.Add(Me.txtPrimeMeridianName)
        Me.TabPage4.Controls.Add(Me.Label28)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(720, 442)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Prime Meridian"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtPmAuthor
        '
        Me.txtPmAuthor.Location = New System.Drawing.Point(126, 51)
        Me.txtPmAuthor.Name = "txtPmAuthor"
        Me.txtPmAuthor.Size = New System.Drawing.Size(191, 20)
        Me.txtPmAuthor.TabIndex = 163
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(79, 55)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(41, 13)
        Me.Label58.TabIndex = 162
        Me.Label58.Text = "Author:"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(380, 243)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(107, 13)
        Me.Label54.TabIndex = 161
        Me.Label54.Text = "Sexagesimal degrees"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(380, 217)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(86, 13)
        Me.Label53.TabIndex = 160
        Me.Label53.Text = "Decimal degrees"
        '
        'txtPmSexagesimalDegrees
        '
        Me.txtPmSexagesimalDegrees.Location = New System.Drawing.Point(188, 240)
        Me.txtPmSexagesimalDegrees.Name = "txtPmSexagesimalDegrees"
        Me.txtPmSexagesimalDegrees.Size = New System.Drawing.Size(186, 20)
        Me.txtPmSexagesimalDegrees.TabIndex = 159
        '
        'txtPmDecimalDegrees
        '
        Me.txtPmDecimalDegrees.Location = New System.Drawing.Point(188, 214)
        Me.txtPmDecimalDegrees.Name = "txtPmDecimalDegrees"
        Me.txtPmDecimalDegrees.Size = New System.Drawing.Size(186, 20)
        Me.txtPmDecimalDegrees.TabIndex = 158
        '
        'txtPmCode
        '
        Me.txtPmCode.Location = New System.Drawing.Point(377, 51)
        Me.txtPmCode.Name = "txtPmCode"
        Me.txtPmCode.Size = New System.Drawing.Size(87, 20)
        Me.txtPmCode.TabIndex = 157
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(336, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 156
        Me.Label5.Text = "Code:"
        '
        'cmbPmWE
        '
        Me.cmbPmWE.FormattingEnabled = True
        Me.cmbPmWE.Location = New System.Drawing.Point(402, 188)
        Me.cmbPmWE.Name = "cmbPmWE"
        Me.cmbPmWE.Size = New System.Drawing.Size(42, 21)
        Me.cmbPmWE.TabIndex = 155
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(380, 295)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 154
        Me.Label18.Text = "Radians"
        '
        'txtPmRadians
        '
        Me.txtPmRadians.Location = New System.Drawing.Point(188, 292)
        Me.txtPmRadians.Name = "txtPmRadians"
        Me.txtPmRadians.Size = New System.Drawing.Size(186, 20)
        Me.txtPmRadians.TabIndex = 153
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(380, 269)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 13)
        Me.Label19.TabIndex = 152
        Me.Label19.Text = "Gradians"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(14, 217)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(34, 13)
        Me.Label20.TabIndex = 151
        Me.Label20.Text = "Units:"
        '
        'cmbPmUnits
        '
        Me.cmbPmUnits.FormattingEnabled = True
        Me.cmbPmUnits.Location = New System.Drawing.Point(54, 214)
        Me.cmbPmUnits.Name = "cmbPmUnits"
        Me.cmbPmUnits.Size = New System.Drawing.Size(127, 21)
        Me.cmbPmUnits.TabIndex = 150
        '
        'txtPmGrads
        '
        Me.txtPmGrads.Location = New System.Drawing.Point(188, 266)
        Me.txtPmGrads.Name = "txtPmGrads"
        Me.txtPmGrads.Size = New System.Drawing.Size(186, 20)
        Me.txtPmGrads.TabIndex = 149
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(279, 172)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(26, 13)
        Me.Label21.TabIndex = 148
        Me.Label21.Text = "Sec"
        '
        'txtPmSeconds
        '
        Me.txtPmSeconds.Location = New System.Drawing.Point(276, 189)
        Me.txtPmSeconds.Name = "txtPmSeconds"
        Me.txtPmSeconds.Size = New System.Drawing.Size(120, 20)
        Me.txtPmSeconds.TabIndex = 147
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(235, 172)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(24, 13)
        Me.Label22.TabIndex = 146
        Me.Label22.Text = "Min"
        '
        'txtPmMinutes
        '
        Me.txtPmMinutes.Location = New System.Drawing.Point(232, 189)
        Me.txtPmMinutes.Name = "txtPmMinutes"
        Me.txtPmMinutes.Size = New System.Drawing.Size(38, 20)
        Me.txtPmMinutes.TabIndex = 145
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(191, 172)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(27, 13)
        Me.Label23.TabIndex = 144
        Me.Label23.Text = "Deg"
        '
        'txtPmDegrees
        '
        Me.txtPmDegrees.Location = New System.Drawing.Point(188, 189)
        Me.txtPmDegrees.Name = "txtPmDegrees"
        Me.txtPmDegrees.Size = New System.Drawing.Size(39, 20)
        Me.txtPmDegrees.TabIndex = 143
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(11, 191)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(134, 13)
        Me.Label24.TabIndex = 142
        Me.Label24.Text = "Longitude from Greenwich:"
        '
        'txtPrimeMeridianComments
        '
        Me.txtPrimeMeridianComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrimeMeridianComments.Location = New System.Drawing.Point(98, 107)
        Me.txtPrimeMeridianComments.Multiline = True
        Me.txtPrimeMeridianComments.Name = "txtPrimeMeridianComments"
        Me.txtPrimeMeridianComments.Size = New System.Drawing.Size(619, 53)
        Me.txtPrimeMeridianComments.TabIndex = 141
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(13, 110)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(59, 13)
        Me.Label25.TabIndex = 140
        Me.Label25.Text = "Comments:"
        '
        'cmbPrimeMeridianAliasNames
        '
        Me.cmbPrimeMeridianAliasNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPrimeMeridianAliasNames.FormattingEnabled = True
        Me.cmbPrimeMeridianAliasNames.Location = New System.Drawing.Point(98, 80)
        Me.cmbPrimeMeridianAliasNames.Name = "cmbPrimeMeridianAliasNames"
        Me.cmbPrimeMeridianAliasNames.Size = New System.Drawing.Size(619, 21)
        Me.cmbPrimeMeridianAliasNames.TabIndex = 139
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(13, 83)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(66, 13)
        Me.Label27.TabIndex = 138
        Me.Label27.Text = "Alias names:"
        '
        'txtPrimeMeridianName
        '
        Me.txtPrimeMeridianName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrimeMeridianName.Location = New System.Drawing.Point(126, 25)
        Me.txtPrimeMeridianName.Name = "txtPrimeMeridianName"
        Me.txtPrimeMeridianName.Size = New System.Drawing.Size(591, 20)
        Me.txtPrimeMeridianName.TabIndex = 137
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(13, 28)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(107, 13)
        Me.Label28.TabIndex = 136
        Me.Label28.Text = "Prime meridian name:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtAreaAuthor)
        Me.TabPage2.Controls.Add(Me.Label60)
        Me.TabPage2.Controls.Add(Me.txtAouDescription)
        Me.TabPage2.Controls.Add(Me.Label30)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.txtIsoNumericCode)
        Me.TabPage2.Controls.Add(Me.txtAreaOfUseName)
        Me.TabPage2.Controls.Add(Me.Label45)
        Me.TabPage2.Controls.Add(Me.txtIso3CharCode)
        Me.TabPage2.Controls.Add(Me.txtAouCode)
        Me.TabPage2.Controls.Add(Me.Label46)
        Me.TabPage2.Controls.Add(Me.txtIso2CharCode)
        Me.TabPage2.Controls.Add(Me.Label47)
        Me.TabPage2.Controls.Add(Me.Label48)
        Me.TabPage2.Controls.Add(Me.Label49)
        Me.TabPage2.Controls.Add(Me.txtAouComments)
        Me.TabPage2.Controls.Add(Me.Label50)
        Me.TabPage2.Controls.Add(Me.cmbAouAliasNames)
        Me.TabPage2.Controls.Add(Me.Label51)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(720, 442)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Area of Use"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtAreaAuthor
        '
        Me.txtAreaAuthor.Location = New System.Drawing.Point(92, 45)
        Me.txtAreaAuthor.Name = "txtAreaAuthor"
        Me.txtAreaAuthor.Size = New System.Drawing.Size(216, 20)
        Me.txtAreaAuthor.TabIndex = 152
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(32, 49)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(41, 13)
        Me.Label60.TabIndex = 151
        Me.Label60.Text = "Author:"
        '
        'txtAouDescription
        '
        Me.txtAouDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAouDescription.Location = New System.Drawing.Point(79, 371)
        Me.txtAouDescription.Multiline = True
        Me.txtAouDescription.Name = "txtAouDescription"
        Me.txtAouDescription.Size = New System.Drawing.Size(659, 65)
        Me.txtAouDescription.TabIndex = 148
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 374)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 13)
        Me.Label30.TabIndex = 147
        Me.Label30.Text = "Description"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label55)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtNLatDegrees)
        Me.GroupBox2.Controls.Add(Me.cmbWLongWE)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.txtNLatMinutes)
        Me.GroupBox2.Controls.Add(Me.txtWLongSeconds)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.txtNLatSeconds)
        Me.GroupBox2.Controls.Add(Me.txtWLongMinutes)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.Label36)
        Me.GroupBox2.Controls.Add(Me.cmbNLatNS)
        Me.GroupBox2.Controls.Add(Me.txtWLongDegrees)
        Me.GroupBox2.Controls.Add(Me.txtSLatDegrees)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.Label38)
        Me.GroupBox2.Controls.Add(Me.cmbELongWE)
        Me.GroupBox2.Controls.Add(Me.txtSLatMinutes)
        Me.GroupBox2.Controls.Add(Me.Label39)
        Me.GroupBox2.Controls.Add(Me.Label40)
        Me.GroupBox2.Controls.Add(Me.txtELongSeconds)
        Me.GroupBox2.Controls.Add(Me.txtSLatSeconds)
        Me.GroupBox2.Controls.Add(Me.Label41)
        Me.GroupBox2.Controls.Add(Me.Label42)
        Me.GroupBox2.Controls.Add(Me.txtELongMinutes)
        Me.GroupBox2.Controls.Add(Me.cmbSLatNS)
        Me.GroupBox2.Controls.Add(Me.Label43)
        Me.GroupBox2.Controls.Add(Me.Label44)
        Me.GroupBox2.Controls.Add(Me.txtELongDegrees)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 197)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(624, 167)
        Me.GroupBox2.TabIndex = 146
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Geographic Bounding Box"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(6, 16)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(172, 13)
        Me.Label55.TabIndex = 151
        Me.Label55.Text = "Referenced to the WGS 84 datum."
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(121, 35)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(89, 13)
        Me.Label31.TabIndex = 104
        Me.Label31.Text = "Northern Latitude"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "Western Longitude"
        '
        'txtNLatDegrees
        '
        Me.txtNLatDegrees.Location = New System.Drawing.Point(216, 32)
        Me.txtNLatDegrees.Name = "txtNLatDegrees"
        Me.txtNLatDegrees.Size = New System.Drawing.Size(39, 20)
        Me.txtNLatDegrees.TabIndex = 97
        '
        'cmbWLongWE
        '
        Me.cmbWLongWE.FormattingEnabled = True
        Me.cmbWLongWE.Location = New System.Drawing.Point(227, 74)
        Me.cmbWLongWE.Name = "cmbWLongWE"
        Me.cmbWLongWE.Size = New System.Drawing.Size(42, 21)
        Me.cmbWLongWE.TabIndex = 127
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(213, 16)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(27, 13)
        Me.Label32.TabIndex = 98
        Me.Label32.Text = "Deg"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(107, 58)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(26, 13)
        Me.Label29.TabIndex = 126
        Me.Label29.Text = "Sec"
        '
        'txtNLatMinutes
        '
        Me.txtNLatMinutes.Location = New System.Drawing.Point(260, 32)
        Me.txtNLatMinutes.Name = "txtNLatMinutes"
        Me.txtNLatMinutes.Size = New System.Drawing.Size(38, 20)
        Me.txtNLatMinutes.TabIndex = 99
        '
        'txtWLongSeconds
        '
        Me.txtWLongSeconds.Location = New System.Drawing.Point(101, 74)
        Me.txtWLongSeconds.Name = "txtWLongSeconds"
        Me.txtWLongSeconds.Size = New System.Drawing.Size(120, 20)
        Me.txtWLongSeconds.TabIndex = 125
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(265, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(24, 13)
        Me.Label33.TabIndex = 100
        Me.Label33.Text = "Min"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(66, 58)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(24, 13)
        Me.Label34.TabIndex = 124
        Me.Label34.Text = "Min"
        '
        'txtNLatSeconds
        '
        Me.txtNLatSeconds.Location = New System.Drawing.Point(304, 32)
        Me.txtNLatSeconds.Name = "txtNLatSeconds"
        Me.txtNLatSeconds.Size = New System.Drawing.Size(120, 20)
        Me.txtNLatSeconds.TabIndex = 101
        '
        'txtWLongMinutes
        '
        Me.txtWLongMinutes.Location = New System.Drawing.Point(58, 74)
        Me.txtWLongMinutes.Name = "txtWLongMinutes"
        Me.txtWLongMinutes.Size = New System.Drawing.Size(38, 20)
        Me.txtWLongMinutes.TabIndex = 123
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(308, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(26, 13)
        Me.Label35.TabIndex = 102
        Me.Label35.Text = "Sec"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(17, 58)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(27, 13)
        Me.Label36.TabIndex = 122
        Me.Label36.Text = "Deg"
        '
        'cmbNLatNS
        '
        Me.cmbNLatNS.FormattingEnabled = True
        Me.cmbNLatNS.Location = New System.Drawing.Point(430, 32)
        Me.cmbNLatNS.Name = "cmbNLatNS"
        Me.cmbNLatNS.Size = New System.Drawing.Size(42, 21)
        Me.cmbNLatNS.TabIndex = 103
        '
        'txtWLongDegrees
        '
        Me.txtWLongDegrees.Location = New System.Drawing.Point(13, 74)
        Me.txtWLongDegrees.Name = "txtWLongDegrees"
        Me.txtWLongDegrees.Size = New System.Drawing.Size(39, 20)
        Me.txtWLongDegrees.TabIndex = 121
        '
        'txtSLatDegrees
        '
        Me.txtSLatDegrees.Location = New System.Drawing.Point(215, 134)
        Me.txtSLatDegrees.Name = "txtSLatDegrees"
        Me.txtSLatDegrees.Size = New System.Drawing.Size(39, 20)
        Me.txtSLatDegrees.TabIndex = 105
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(348, 97)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(93, 13)
        Me.Label37.TabIndex = 120
        Me.Label37.Text = "Eastern Longitude"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(217, 118)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(27, 13)
        Me.Label38.TabIndex = 106
        Me.Label38.Text = "Deg"
        '
        'cmbELongWE
        '
        Me.cmbELongWE.FormattingEnabled = True
        Me.cmbELongWE.Location = New System.Drawing.Point(566, 74)
        Me.cmbELongWE.Name = "cmbELongWE"
        Me.cmbELongWE.Size = New System.Drawing.Size(42, 21)
        Me.cmbELongWE.TabIndex = 119
        '
        'txtSLatMinutes
        '
        Me.txtSLatMinutes.Location = New System.Drawing.Point(260, 134)
        Me.txtSLatMinutes.Name = "txtSLatMinutes"
        Me.txtSLatMinutes.Size = New System.Drawing.Size(38, 20)
        Me.txtSLatMinutes.TabIndex = 107
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(447, 58)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(26, 13)
        Me.Label39.TabIndex = 118
        Me.Label39.Text = "Sec"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(265, 118)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(24, 13)
        Me.Label40.TabIndex = 108
        Me.Label40.Text = "Min"
        '
        'txtELongSeconds
        '
        Me.txtELongSeconds.Location = New System.Drawing.Point(440, 74)
        Me.txtELongSeconds.Name = "txtELongSeconds"
        Me.txtELongSeconds.Size = New System.Drawing.Size(120, 20)
        Me.txtELongSeconds.TabIndex = 117
        '
        'txtSLatSeconds
        '
        Me.txtSLatSeconds.Location = New System.Drawing.Point(304, 134)
        Me.txtSLatSeconds.Name = "txtSLatSeconds"
        Me.txtSLatSeconds.Size = New System.Drawing.Size(120, 20)
        Me.txtSLatSeconds.TabIndex = 109
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(398, 58)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(24, 13)
        Me.Label41.TabIndex = 116
        Me.Label41.Text = "Min"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(308, 118)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(26, 13)
        Me.Label42.TabIndex = 110
        Me.Label42.Text = "Sec"
        '
        'txtELongMinutes
        '
        Me.txtELongMinutes.Location = New System.Drawing.Point(396, 74)
        Me.txtELongMinutes.Name = "txtELongMinutes"
        Me.txtELongMinutes.Size = New System.Drawing.Size(38, 20)
        Me.txtELongMinutes.TabIndex = 115
        '
        'cmbSLatNS
        '
        Me.cmbSLatNS.FormattingEnabled = True
        Me.cmbSLatNS.Location = New System.Drawing.Point(429, 134)
        Me.cmbSLatNS.Name = "cmbSLatNS"
        Me.cmbSLatNS.Size = New System.Drawing.Size(42, 21)
        Me.cmbSLatNS.TabIndex = 111
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(348, 58)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(27, 13)
        Me.Label43.TabIndex = 114
        Me.Label43.Text = "Deg"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(118, 137)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(91, 13)
        Me.Label44.TabIndex = 112
        Me.Label44.Text = "Southern Latitude"
        '
        'txtELongDegrees
        '
        Me.txtELongDegrees.Location = New System.Drawing.Point(351, 74)
        Me.txtELongDegrees.Name = "txtELongDegrees"
        Me.txtELongDegrees.Size = New System.Drawing.Size(39, 20)
        Me.txtELongDegrees.TabIndex = 113
        '
        'txtIsoNumericCode
        '
        Me.txtIsoNumericCode.Location = New System.Drawing.Point(470, 162)
        Me.txtIsoNumericCode.Name = "txtIsoNumericCode"
        Me.txtIsoNumericCode.Size = New System.Drawing.Size(48, 20)
        Me.txtIsoNumericCode.TabIndex = 145
        '
        'txtAreaOfUseName
        '
        Me.txtAreaOfUseName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAreaOfUseName.Location = New System.Drawing.Point(92, 19)
        Me.txtAreaOfUseName.Name = "txtAreaOfUseName"
        Me.txtAreaOfUseName.Size = New System.Drawing.Size(622, 20)
        Me.txtAreaOfUseName.TabIndex = 135
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(6, 22)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(61, 13)
        Me.Label45.TabIndex = 134
        Me.Label45.Text = "Area name:"
        '
        'txtIso3CharCode
        '
        Me.txtIso3CharCode.Location = New System.Drawing.Point(302, 162)
        Me.txtIso3CharCode.Name = "txtIso3CharCode"
        Me.txtIso3CharCode.Size = New System.Drawing.Size(48, 20)
        Me.txtIso3CharCode.TabIndex = 144
        '
        'txtAouCode
        '
        Me.txtAouCode.Location = New System.Drawing.Point(393, 45)
        Me.txtAouCode.Name = "txtAouCode"
        Me.txtAouCode.Size = New System.Drawing.Size(86, 20)
        Me.txtAouCode.TabIndex = 150
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(352, 48)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(35, 13)
        Me.Label46.TabIndex = 149
        Me.Label46.Text = "Code:"
        '
        'txtIso2CharCode
        '
        Me.txtIso2CharCode.Location = New System.Drawing.Point(126, 162)
        Me.txtIso2CharCode.Name = "txtIso2CharCode"
        Me.txtIso2CharCode.Size = New System.Drawing.Size(48, 20)
        Me.txtIso2CharCode.TabIndex = 143
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(186, 165)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(110, 13)
        Me.Label47.TabIndex = 141
        Me.Label47.Text = "ISO 3-character Code"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(10, 165)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(110, 13)
        Me.Label48.TabIndex = 140
        Me.Label48.Text = "ISO 2-character Code"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(369, 165)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(95, 13)
        Me.Label49.TabIndex = 142
        Me.Label49.Text = "ISO Numeric Code"
        '
        'txtAouComments
        '
        Me.txtAouComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAouComments.Location = New System.Drawing.Point(92, 100)
        Me.txtAouComments.Multiline = True
        Me.txtAouComments.Name = "txtAouComments"
        Me.txtAouComments.Size = New System.Drawing.Size(622, 53)
        Me.txtAouComments.TabIndex = 139
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(9, 103)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(59, 13)
        Me.Label50.TabIndex = 138
        Me.Label50.Text = "Comments:"
        '
        'cmbAouAliasNames
        '
        Me.cmbAouAliasNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAouAliasNames.FormattingEnabled = True
        Me.cmbAouAliasNames.Location = New System.Drawing.Point(92, 73)
        Me.cmbAouAliasNames.Name = "cmbAouAliasNames"
        Me.cmbAouAliasNames.Size = New System.Drawing.Size(622, 21)
        Me.cmbAouAliasNames.TabIndex = 137
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(7, 76)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(66, 13)
        Me.Label51.TabIndex = 136
        Me.Label51.Text = "Alias names:"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.ListBox1)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(720, 442)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "List"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(3, 9)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(714, 433)
        Me.ListBox1.TabIndex = 3
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnNameFindPrev
        '
        Me.btnNameFindPrev.Location = New System.Drawing.Point(234, 12)
        Me.btnNameFindPrev.Name = "btnNameFindPrev"
        Me.btnNameFindPrev.Size = New System.Drawing.Size(40, 22)
        Me.btnNameFindPrev.TabIndex = 260
        Me.btnNameFindPrev.Text = "Prev"
        Me.btnNameFindPrev.UseVisualStyleBackColor = True
        '
        'frmGeodeticDatums
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 576)
        Me.Controls.Add(Me.btnNameFindPrev)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnNameFindNext)
        Me.Controls.Add(Me.txtSearchText)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnNameFind)
        Me.Controls.Add(Me.txtDatumName)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnGetEpsgList)
        Me.Controls.Add(Me.btnMoveDown)
        Me.Controls.Add(Me.btnMoveUp)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtDatumListFileName)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.txtRecordNo)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.txtNRecords)
        Me.Name = "frmGeodeticDatums"
        Me.Text = "Geodetic Datums"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNameFindNext As System.Windows.Forms.Button
    Friend WithEvents txtSearchText As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnNameFind As System.Windows.Forms.Button
    Friend WithEvents txtDatumName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnGetEpsgList As System.Windows.Forms.Button
    Friend WithEvents btnMoveDown As System.Windows.Forms.Button
    Friend WithEvents btnMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtDatumListFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents txtRecordNo As System.Windows.Forms.TextBox
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents txtNRecords As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtDatumAuthor As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents txtDatumDeprecated As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtDatumScope As System.Windows.Forms.TextBox
    Friend WithEvents txtDatumOrigin As System.Windows.Forms.TextBox
    Friend WithEvents txtDatumCode As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtGeodeticDatumName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbDatumAliasNames As System.Windows.Forms.ComboBox
    Friend WithEvents btnDelAlias As System.Windows.Forms.Button
    Friend WithEvents btnAddAlias As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDatumComments As System.Windows.Forms.TextBox
    Friend WithEvents txtNewAliasName As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtEllipsoidCode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbEllipsoidAliasNames As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSemiMinorAxis As System.Windows.Forms.TextBox
    Friend WithEvents txtInverseFlattening As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtSemiMajorAxis As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSemiMajorAndSemiMinor As System.Windows.Forms.RadioButton
    Friend WithEvents rbSemiMajorAndInverseFlat As System.Windows.Forms.RadioButton
    Friend WithEvents txtEllipsoidComments As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtEllipsoidName As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents txtPmSexagesimalDegrees As System.Windows.Forms.TextBox
    Friend WithEvents txtPmDecimalDegrees As System.Windows.Forms.TextBox
    Friend WithEvents txtPmCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbPmWE As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtPmRadians As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbPmUnits As System.Windows.Forms.ComboBox
    Friend WithEvents txtPmGrads As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtPmSeconds As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtPmMinutes As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtPmDegrees As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtPrimeMeridianComments As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmbPrimeMeridianAliasNames As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtPrimeMeridianName As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtAouDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNLatDegrees As System.Windows.Forms.TextBox
    Friend WithEvents cmbWLongWE As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtNLatMinutes As System.Windows.Forms.TextBox
    Friend WithEvents txtWLongSeconds As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtNLatSeconds As System.Windows.Forms.TextBox
    Friend WithEvents txtWLongMinutes As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cmbNLatNS As System.Windows.Forms.ComboBox
    Friend WithEvents txtWLongDegrees As System.Windows.Forms.TextBox
    Friend WithEvents txtSLatDegrees As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cmbELongWE As System.Windows.Forms.ComboBox
    Friend WithEvents txtSLatMinutes As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtELongSeconds As System.Windows.Forms.TextBox
    Friend WithEvents txtSLatSeconds As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtELongMinutes As System.Windows.Forms.TextBox
    Friend WithEvents cmbSLatNS As System.Windows.Forms.ComboBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtELongDegrees As System.Windows.Forms.TextBox
    Friend WithEvents txtIsoNumericCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAreaOfUseName As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txtIso3CharCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAouCode As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtIso2CharCode As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txtAouComments As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents cmbAouAliasNames As System.Windows.Forms.ComboBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnNameFindPrev As System.Windows.Forms.Button
    Friend WithEvents txtAxisUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents txtEllipsoidAuthor As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents txtPmAuthor As System.Windows.Forms.TextBox
    Friend WithEvents txtAreaAuthor As System.Windows.Forms.TextBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
End Class
