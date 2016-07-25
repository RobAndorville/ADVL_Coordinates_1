<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeocentricCRS
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnNameFindPrev = New System.Windows.Forms.Button()
        Me.btnNameFindNext = New System.Windows.Forms.Button()
        Me.txtSearchText = New System.Windows.Forms.TextBox()
        Me.btnNameFind = New System.Windows.Forms.Button()
        Me.btnGetEpsgList = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtGeocentricCRSListFileName = New System.Windows.Forms.TextBox()
        Me.txtCRSName2 = New System.Windows.Forms.TextBox()
        Me.btnMoveDown = New System.Windows.Forms.Button()
        Me.btnMoveUp = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.txtRecordNo = New System.Windows.Forms.TextBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.txtNRecords = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtDatumType = New System.Windows.Forms.TextBox()
        Me.txtCSType = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.txtDatumName = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.txtCSName = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txtAOUName = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtCrsScope = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCrsComments = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbCRSAliasNames = New System.Windows.Forms.ComboBox()
        Me.btnDelAlias = New System.Windows.Forms.Button()
        Me.btnAddAlias = New System.Windows.Forms.Button()
        Me.txtNewAliasName = New System.Windows.Forms.TextBox()
        Me.txtCrsAuthor = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.txtCrsDeprecated = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtCrsCode = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtCRSName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtAreaOfUseDeprecated = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtAreaOfUseAuthor = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtAreaOfUseCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAreaOfUse = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtNLatDegrees = New System.Windows.Forms.TextBox()
        Me.cmbWLongWE = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtNLatMinutes = New System.Windows.Forms.TextBox()
        Me.txtWLongSeconds = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtNLatSeconds = New System.Windows.Forms.TextBox()
        Me.txtWLongMinutes = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbNLatNS = New System.Windows.Forms.ComboBox()
        Me.txtWLongDegrees = New System.Windows.Forms.TextBox()
        Me.txtSLatDegrees = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbELongWE = New System.Windows.Forms.ComboBox()
        Me.txtSLatMinutes = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtELongSeconds = New System.Windows.Forms.TextBox()
        Me.txtSLatSeconds = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtELongMinutes = New System.Windows.Forms.TextBox()
        Me.cmbSLatNS = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtELongDegrees = New System.Windows.Forms.TextBox()
        Me.txtIsoNumericCode = New System.Windows.Forms.TextBox()
        Me.txtIso3CharCode = New System.Windows.Forms.TextBox()
        Me.txtIso2CharCode = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtAreaComments = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtAddAreaOfUseAlias = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmbAreaAliasNames = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtAreaOfUseName = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtCoordSysComments = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtAxisOrientation3 = New System.Windows.Forms.TextBox()
        Me.txtAxisUnit3 = New System.Windows.Forms.TextBox()
        Me.txtAxisAbbr3 = New System.Windows.Forms.TextBox()
        Me.txtAxisName3 = New System.Windows.Forms.TextBox()
        Me.txtAxisOrder3 = New System.Windows.Forms.TextBox()
        Me.txtAxisOrientation2 = New System.Windows.Forms.TextBox()
        Me.txtAxisUnit2 = New System.Windows.Forms.TextBox()
        Me.txtAxisAbbr2 = New System.Windows.Forms.TextBox()
        Me.txtAxisName2 = New System.Windows.Forms.TextBox()
        Me.txtAxisOrder2 = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtAxisOrientation1 = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtAxisUnit1 = New System.Windows.Forms.TextBox()
        Me.txtAxisAbbr1 = New System.Windows.Forms.TextBox()
        Me.txtAxisName1 = New System.Windows.Forms.TextBox()
        Me.txtAxisOrder1 = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtCoordSysDimension = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtCoordSysType = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtCoordSysAuthor = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtCoordSysDeprecated = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtCoordSysCode = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.txtCoordSysName = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.txtDatumType2 = New System.Windows.Forms.TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.txtDatumAuthor2 = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.txtDatumDeprecated = New System.Windows.Forms.TextBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.txtDatumScope = New System.Windows.Forms.TextBox()
        Me.txtDatumOrigin = New System.Windows.Forms.TextBox()
        Me.txtDatumCode2 = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.txtDatumName2 = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.cmbDatumAliasNames = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.txtDatumComments = New System.Windows.Forms.TextBox()
        Me.txtAddDatumAlias = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(815, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnNameFindPrev
        '
        Me.btnNameFindPrev.Location = New System.Drawing.Point(234, 12)
        Me.btnNameFindPrev.Name = "btnNameFindPrev"
        Me.btnNameFindPrev.Size = New System.Drawing.Size(40, 22)
        Me.btnNameFindPrev.TabIndex = 267
        Me.btnNameFindPrev.Text = "Prev"
        Me.btnNameFindPrev.UseVisualStyleBackColor = True
        '
        'btnNameFindNext
        '
        Me.btnNameFindNext.Location = New System.Drawing.Point(280, 12)
        Me.btnNameFindNext.Name = "btnNameFindNext"
        Me.btnNameFindNext.Size = New System.Drawing.Size(40, 22)
        Me.btnNameFindNext.TabIndex = 266
        Me.btnNameFindNext.Text = "Next"
        Me.btnNameFindNext.UseVisualStyleBackColor = True
        '
        'txtSearchText
        '
        Me.txtSearchText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchText.Location = New System.Drawing.Point(326, 13)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(483, 20)
        Me.txtSearchText.TabIndex = 265
        '
        'btnNameFind
        '
        Me.btnNameFind.Location = New System.Drawing.Point(170, 12)
        Me.btnNameFind.Name = "btnNameFind"
        Me.btnNameFind.Size = New System.Drawing.Size(58, 22)
        Me.btnNameFind.TabIndex = 264
        Me.btnNameFind.Text = "Find First"
        Me.btnNameFind.UseVisualStyleBackColor = True
        '
        'btnGetEpsgList
        '
        Me.btnGetEpsgList.Location = New System.Drawing.Point(70, 12)
        Me.btnGetEpsgList.Name = "btnGetEpsgList"
        Me.btnGetEpsgList.Size = New System.Drawing.Size(94, 22)
        Me.btnGetEpsgList.TabIndex = 263
        Me.btnGetEpsgList.Text = "Get EPSG List"
        Me.btnGetEpsgList.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(52, 22)
        Me.btnSave.TabIndex = 262
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(182, 13)
        Me.Label9.TabIndex = 270
        Me.Label9.Text = "Coordinate Reference System list file:"
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFind.Location = New System.Drawing.Point(831, 40)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(48, 22)
        Me.btnFind.TabIndex = 269
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtGeocentricCRSListFileName
        '
        Me.txtGeocentricCRSListFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGeocentricCRSListFileName.Location = New System.Drawing.Point(200, 41)
        Me.txtGeocentricCRSListFileName.Name = "txtGeocentricCRSListFileName"
        Me.txtGeocentricCRSListFileName.Size = New System.Drawing.Size(625, 20)
        Me.txtGeocentricCRSListFileName.TabIndex = 268
        '
        'txtCRSName2
        '
        Me.txtCRSName2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCRSName2.Location = New System.Drawing.Point(604, 68)
        Me.txtCRSName2.Name = "txtCRSName2"
        Me.txtCRSName2.Size = New System.Drawing.Size(275, 20)
        Me.txtCRSName2.TabIndex = 283
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Location = New System.Drawing.Point(524, 67)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(74, 22)
        Me.btnMoveDown.TabIndex = 282
        Me.btnMoveDown.Text = "Move Dwn"
        Me.btnMoveDown.UseVisualStyleBackColor = True
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Location = New System.Drawing.Point(457, 67)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(61, 22)
        Me.btnMoveUp.TabIndex = 281
        Me.btnMoveUp.Text = "Move Up"
        Me.btnMoveUp.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Location = New System.Drawing.Point(412, 67)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(39, 22)
        Me.btnDel.TabIndex = 280
        Me.btnDel.Text = "Del"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(367, 67)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(39, 22)
        Me.btnAdd.TabIndex = 279
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(322, 67)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(39, 22)
        Me.btnLast.TabIndex = 276
        Me.btnLast.Text = "Last"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'txtRecordNo
        '
        Me.txtRecordNo.Location = New System.Drawing.Point(57, 68)
        Me.txtRecordNo.Name = "txtRecordNo"
        Me.txtRecordNo.Size = New System.Drawing.Size(45, 20)
        Me.txtRecordNo.TabIndex = 278
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(277, 67)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(39, 22)
        Me.btnNext.TabIndex = 275
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 277
        Me.Label1.Text = "Record"
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(232, 67)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(39, 22)
        Me.btnPrev.TabIndex = 274
        Me.btnPrev.Text = "Prev"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(108, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(16, 13)
        Me.Label10.TabIndex = 272
        Me.Label10.Text = "of"
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(187, 67)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(39, 22)
        Me.btnFirst.TabIndex = 273
        Me.btnFirst.Text = "First"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'txtNRecords
        '
        Me.txtNRecords.Location = New System.Drawing.Point(129, 68)
        Me.txtNRecords.Name = "txtNRecords"
        Me.txtNRecords.ReadOnly = True
        Me.txtNRecords.Size = New System.Drawing.Size(47, 20)
        Me.txtNRecords.TabIndex = 271
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 95)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(867, 499)
        Me.TabControl1.TabIndex = 284
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtDatumType)
        Me.TabPage1.Controls.Add(Me.txtCSType)
        Me.TabPage1.Controls.Add(Me.Label66)
        Me.TabPage1.Controls.Add(Me.Label65)
        Me.TabPage1.Controls.Add(Me.txtDatumName)
        Me.TabPage1.Controls.Add(Me.Label60)
        Me.TabPage1.Controls.Add(Me.txtCSName)
        Me.TabPage1.Controls.Add(Me.Label51)
        Me.TabPage1.Controls.Add(Me.txtAOUName)
        Me.TabPage1.Controls.Add(Me.Label47)
        Me.TabPage1.Controls.Add(Me.txtCrsScope)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtCrsComments)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.cmbCRSAliasNames)
        Me.TabPage1.Controls.Add(Me.btnDelAlias)
        Me.TabPage1.Controls.Add(Me.btnAddAlias)
        Me.TabPage1.Controls.Add(Me.txtNewAliasName)
        Me.TabPage1.Controls.Add(Me.txtCrsAuthor)
        Me.TabPage1.Controls.Add(Me.Label56)
        Me.TabPage1.Controls.Add(Me.txtCrsDeprecated)
        Me.TabPage1.Controls.Add(Me.Label52)
        Me.TabPage1.Controls.Add(Me.txtCrsCode)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.txtCRSName)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(859, 473)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Coordinate Reference System"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtDatumType
        '
        Me.txtDatumType.Location = New System.Drawing.Point(110, 364)
        Me.txtDatumType.Name = "txtDatumType"
        Me.txtDatumType.Size = New System.Drawing.Size(241, 20)
        Me.txtDatumType.TabIndex = 211
        '
        'txtCSType
        '
        Me.txtCSType.Location = New System.Drawing.Point(110, 301)
        Me.txtCSType.Name = "txtCSType"
        Me.txtCSType.Size = New System.Drawing.Size(241, 20)
        Me.txtCSType.TabIndex = 210
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(70, 367)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(34, 13)
        Me.Label66.TabIndex = 208
        Me.Label66.Text = "Type:"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(70, 304)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(34, 13)
        Me.Label65.TabIndex = 207
        Me.Label65.Text = "Type:"
        '
        'txtDatumName
        '
        Me.txtDatumName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatumName.Location = New System.Drawing.Point(110, 338)
        Me.txtDatumName.Name = "txtDatumName"
        Me.txtDatumName.Size = New System.Drawing.Size(743, 20)
        Me.txtDatumName.TabIndex = 196
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(63, 341)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(41, 13)
        Me.Label60.TabIndex = 193
        Me.Label60.Text = "Datum:"
        '
        'txtCSName
        '
        Me.txtCSName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCSName.Location = New System.Drawing.Point(110, 275)
        Me.txtCSName.Name = "txtCSName"
        Me.txtCSName.Size = New System.Drawing.Size(743, 20)
        Me.txtCSName.TabIndex = 189
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(6, 278)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(98, 13)
        Me.Label51.TabIndex = 186
        Me.Label51.Text = "Coordinate System:"
        '
        'txtAOUName
        '
        Me.txtAOUName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAOUName.Location = New System.Drawing.Point(110, 238)
        Me.txtAOUName.Name = "txtAOUName"
        Me.txtAOUName.Size = New System.Drawing.Size(743, 20)
        Me.txtAOUName.TabIndex = 180
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(38, 241)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(66, 13)
        Me.Label47.TabIndex = 179
        Me.Label47.Text = "Area of Use:"
        '
        'txtCrsScope
        '
        Me.txtCrsScope.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCrsScope.Location = New System.Drawing.Point(92, 111)
        Me.txtCrsScope.Multiline = True
        Me.txtCrsScope.Name = "txtCrsScope"
        Me.txtCrsScope.Size = New System.Drawing.Size(761, 48)
        Me.txtCrsScope.TabIndex = 178
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(45, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 177
        Me.Label7.Text = "Scope:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "Comments:"
        '
        'txtCrsComments
        '
        Me.txtCrsComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCrsComments.Location = New System.Drawing.Point(92, 165)
        Me.txtCrsComments.Multiline = True
        Me.txtCrsComments.Name = "txtCrsComments"
        Me.txtCrsComments.Size = New System.Drawing.Size(761, 54)
        Me.txtCrsComments.TabIndex = 176
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 170
        Me.Label8.Text = "Alias names:"
        '
        'cmbCRSAliasNames
        '
        Me.cmbCRSAliasNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCRSAliasNames.FormattingEnabled = True
        Me.cmbCRSAliasNames.Location = New System.Drawing.Point(92, 58)
        Me.cmbCRSAliasNames.Name = "cmbCRSAliasNames"
        Me.cmbCRSAliasNames.Size = New System.Drawing.Size(716, 21)
        Me.cmbCRSAliasNames.TabIndex = 171
        '
        'btnDelAlias
        '
        Me.btnDelAlias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelAlias.Location = New System.Drawing.Point(814, 57)
        Me.btnDelAlias.Name = "btnDelAlias"
        Me.btnDelAlias.Size = New System.Drawing.Size(39, 22)
        Me.btnDelAlias.TabIndex = 173
        Me.btnDelAlias.Text = "Del"
        Me.btnDelAlias.UseVisualStyleBackColor = True
        '
        'btnAddAlias
        '
        Me.btnAddAlias.Location = New System.Drawing.Point(9, 84)
        Me.btnAddAlias.Name = "btnAddAlias"
        Me.btnAddAlias.Size = New System.Drawing.Size(77, 22)
        Me.btnAddAlias.TabIndex = 172
        Me.btnAddAlias.Text = "Add Alias"
        Me.btnAddAlias.UseVisualStyleBackColor = True
        '
        'txtNewAliasName
        '
        Me.txtNewAliasName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewAliasName.Location = New System.Drawing.Point(92, 85)
        Me.txtNewAliasName.Name = "txtNewAliasName"
        Me.txtNewAliasName.Size = New System.Drawing.Size(761, 20)
        Me.txtNewAliasName.TabIndex = 174
        '
        'txtCrsAuthor
        '
        Me.txtCrsAuthor.Location = New System.Drawing.Point(92, 32)
        Me.txtCrsAuthor.Name = "txtCrsAuthor"
        Me.txtCrsAuthor.Size = New System.Drawing.Size(131, 20)
        Me.txtCrsAuthor.TabIndex = 169
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(45, 35)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(41, 13)
        Me.Label56.TabIndex = 168
        Me.Label56.Text = "Author:"
        '
        'txtCrsDeprecated
        '
        Me.txtCrsDeprecated.Location = New System.Drawing.Point(455, 32)
        Me.txtCrsDeprecated.Name = "txtCrsDeprecated"
        Me.txtCrsDeprecated.Size = New System.Drawing.Size(66, 20)
        Me.txtCrsDeprecated.TabIndex = 167
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(383, 35)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(66, 13)
        Me.Label52.TabIndex = 166
        Me.Label52.Text = "Deprecated:"
        '
        'txtCrsCode
        '
        Me.txtCrsCode.Location = New System.Drawing.Point(270, 32)
        Me.txtCrsCode.Name = "txtCrsCode"
        Me.txtCrsCode.Size = New System.Drawing.Size(107, 20)
        Me.txtCrsCode.TabIndex = 165
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(229, 35)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(35, 13)
        Me.Label26.TabIndex = 164
        Me.Label26.Text = "Code:"
        '
        'txtCRSName
        '
        Me.txtCRSName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCRSName.Location = New System.Drawing.Point(145, 6)
        Me.txtCRSName.Name = "txtCRSName"
        Me.txtCRSName.Size = New System.Drawing.Size(708, 20)
        Me.txtCRSName.TabIndex = 163
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 13)
        Me.Label2.TabIndex = 162
        Me.Label2.Text = "Geocentric CRS Name:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtAreaOfUseDeprecated)
        Me.TabPage3.Controls.Add(Me.Label29)
        Me.TabPage3.Controls.Add(Me.txtAreaOfUseAuthor)
        Me.TabPage3.Controls.Add(Me.Label27)
        Me.TabPage3.Controls.Add(Me.txtAreaOfUseCode)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.txtAreaOfUse)
        Me.TabPage3.Controls.Add(Me.Label25)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.txtIsoNumericCode)
        Me.TabPage3.Controls.Add(Me.txtIso3CharCode)
        Me.TabPage3.Controls.Add(Me.txtIso2CharCode)
        Me.TabPage3.Controls.Add(Me.Label28)
        Me.TabPage3.Controls.Add(Me.Label30)
        Me.TabPage3.Controls.Add(Me.Label31)
        Me.TabPage3.Controls.Add(Me.txtAreaComments)
        Me.TabPage3.Controls.Add(Me.Label32)
        Me.TabPage3.Controls.Add(Me.txtAddAreaOfUseAlias)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Controls.Add(Me.cmbAreaAliasNames)
        Me.TabPage3.Controls.Add(Me.Label33)
        Me.TabPage3.Controls.Add(Me.txtAreaOfUseName)
        Me.TabPage3.Controls.Add(Me.Label34)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(859, 473)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Area of Use"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtAreaOfUseDeprecated
        '
        Me.txtAreaOfUseDeprecated.Location = New System.Drawing.Point(560, 34)
        Me.txtAreaOfUseDeprecated.Name = "txtAreaOfUseDeprecated"
        Me.txtAreaOfUseDeprecated.Size = New System.Drawing.Size(60, 20)
        Me.txtAreaOfUseDeprecated.TabIndex = 201
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(488, 37)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(66, 13)
        Me.Label29.TabIndex = 200
        Me.Label29.Text = "Deprecated:"
        '
        'txtAreaOfUseAuthor
        '
        Me.txtAreaOfUseAuthor.Location = New System.Drawing.Point(78, 34)
        Me.txtAreaOfUseAuthor.Name = "txtAreaOfUseAuthor"
        Me.txtAreaOfUseAuthor.Size = New System.Drawing.Size(262, 20)
        Me.txtAreaOfUseAuthor.TabIndex = 199
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(9, 37)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(41, 13)
        Me.Label27.TabIndex = 198
        Me.Label27.Text = "Author:"
        '
        'txtAreaOfUseCode
        '
        Me.txtAreaOfUseCode.Location = New System.Drawing.Point(401, 34)
        Me.txtAreaOfUseCode.Name = "txtAreaOfUseCode"
        Me.txtAreaOfUseCode.Size = New System.Drawing.Size(68, 20)
        Me.txtAreaOfUseCode.TabIndex = 197
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(360, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 196
        Me.Label3.Text = "Code:"
        '
        'txtAreaOfUse
        '
        Me.txtAreaOfUse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAreaOfUse.Location = New System.Drawing.Point(78, 373)
        Me.txtAreaOfUse.Multiline = True
        Me.txtAreaOfUse.Name = "txtAreaOfUse"
        Me.txtAreaOfUse.Size = New System.Drawing.Size(763, 95)
        Me.txtAreaOfUse.TabIndex = 195
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(9, 376)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(63, 13)
        Me.Label25.TabIndex = 194
        Me.Label25.Text = "Area of Use"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtNLatDegrees)
        Me.GroupBox1.Controls.Add(Me.cmbWLongWE)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtNLatMinutes)
        Me.GroupBox1.Controls.Add(Me.txtWLongSeconds)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtNLatSeconds)
        Me.GroupBox1.Controls.Add(Me.txtWLongMinutes)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.cmbNLatNS)
        Me.GroupBox1.Controls.Add(Me.txtWLongDegrees)
        Me.GroupBox1.Controls.Add(Me.txtSLatDegrees)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cmbELongWE)
        Me.GroupBox1.Controls.Add(Me.txtSLatMinutes)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtELongSeconds)
        Me.GroupBox1.Controls.Add(Me.txtSLatSeconds)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtELongMinutes)
        Me.GroupBox1.Controls.Add(Me.cmbSLatNS)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtELongDegrees)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 200)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(624, 167)
        Me.GroupBox1.TabIndex = 193
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Geographic Bounding Box"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(121, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 104
        Me.Label12.Text = "Northern Latitude"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(13, 97)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(97, 13)
        Me.Label21.TabIndex = 128
        Me.Label21.Text = "Western Longitude"
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(213, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 13)
        Me.Label11.TabIndex = 98
        Me.Label11.Text = "Deg"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(107, 58)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(26, 13)
        Me.Label22.TabIndex = 126
        Me.Label22.Text = "Sec"
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(265, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 13)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Min"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(66, 58)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(24, 13)
        Me.Label23.TabIndex = 124
        Me.Label23.Text = "Min"
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(308, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "Sec"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(17, 58)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(27, 13)
        Me.Label24.TabIndex = 122
        Me.Label24.Text = "Deg"
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
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(348, 97)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(93, 13)
        Me.Label17.TabIndex = 120
        Me.Label17.Text = "Eastern Longitude"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(217, 118)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(27, 13)
        Me.Label16.TabIndex = 106
        Me.Label16.Text = "Deg"
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
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(447, 58)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(26, 13)
        Me.Label18.TabIndex = 118
        Me.Label18.Text = "Sec"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(265, 118)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 13)
        Me.Label15.TabIndex = 108
        Me.Label15.Text = "Min"
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
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(398, 58)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(24, 13)
        Me.Label19.TabIndex = 116
        Me.Label19.Text = "Min"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(308, 118)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(26, 13)
        Me.Label14.TabIndex = 110
        Me.Label14.Text = "Sec"
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
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(348, 58)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(27, 13)
        Me.Label20.TabIndex = 114
        Me.Label20.Text = "Deg"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(118, 137)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 13)
        Me.Label13.TabIndex = 112
        Me.Label13.Text = "Southern Latitude"
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
        Me.txtIsoNumericCode.Location = New System.Drawing.Point(475, 174)
        Me.txtIsoNumericCode.Name = "txtIsoNumericCode"
        Me.txtIsoNumericCode.Size = New System.Drawing.Size(48, 20)
        Me.txtIsoNumericCode.TabIndex = 192
        '
        'txtIso3CharCode
        '
        Me.txtIso3CharCode.Location = New System.Drawing.Point(310, 174)
        Me.txtIso3CharCode.Name = "txtIso3CharCode"
        Me.txtIso3CharCode.Size = New System.Drawing.Size(48, 20)
        Me.txtIso3CharCode.TabIndex = 191
        '
        'txtIso2CharCode
        '
        Me.txtIso2CharCode.Location = New System.Drawing.Point(125, 174)
        Me.txtIso2CharCode.Name = "txtIso2CharCode"
        Me.txtIso2CharCode.Size = New System.Drawing.Size(48, 20)
        Me.txtIso2CharCode.TabIndex = 190
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(374, 177)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(95, 13)
        Me.Label28.TabIndex = 189
        Me.Label28.Text = "ISO Numeric Code"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(194, 177)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(110, 13)
        Me.Label30.TabIndex = 188
        Me.Label30.Text = "ISO 3-character Code"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(9, 177)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(110, 13)
        Me.Label31.TabIndex = 187
        Me.Label31.Text = "ISO 2-character Code"
        '
        'txtAreaComments
        '
        Me.txtAreaComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAreaComments.Location = New System.Drawing.Point(97, 115)
        Me.txtAreaComments.Multiline = True
        Me.txtAreaComments.Name = "txtAreaComments"
        Me.txtAreaComments.Size = New System.Drawing.Size(744, 53)
        Me.txtAreaComments.TabIndex = 186
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(9, 118)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(59, 13)
        Me.Label32.TabIndex = 185
        Me.Label32.Text = "Comments:"
        '
        'txtAddAreaOfUseAlias
        '
        Me.txtAddAreaOfUseAlias.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddAreaOfUseAlias.Location = New System.Drawing.Point(97, 89)
        Me.txtAddAreaOfUseAlias.Name = "txtAddAreaOfUseAlias"
        Me.txtAddAreaOfUseAlias.Size = New System.Drawing.Size(744, 20)
        Me.txtAddAreaOfUseAlias.TabIndex = 184
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(802, 60)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(39, 22)
        Me.Button1.TabIndex = 183
        Me.Button1.Text = "Del"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(8, 87)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(77, 22)
        Me.Button2.TabIndex = 182
        Me.Button2.Text = "Add Alias"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmbAreaAliasNames
        '
        Me.cmbAreaAliasNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAreaAliasNames.FormattingEnabled = True
        Me.cmbAreaAliasNames.Location = New System.Drawing.Point(78, 60)
        Me.cmbAreaAliasNames.Name = "cmbAreaAliasNames"
        Me.cmbAreaAliasNames.Size = New System.Drawing.Size(718, 21)
        Me.cmbAreaAliasNames.TabIndex = 181
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(6, 65)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(66, 13)
        Me.Label33.TabIndex = 180
        Me.Label33.Text = "Alias names:"
        '
        'txtAreaOfUseName
        '
        Me.txtAreaOfUseName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAreaOfUseName.Location = New System.Drawing.Point(78, 8)
        Me.txtAreaOfUseName.Name = "txtAreaOfUseName"
        Me.txtAreaOfUseName.Size = New System.Drawing.Size(763, 20)
        Me.txtAreaOfUseName.TabIndex = 179
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(9, 11)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(61, 13)
        Me.Label34.TabIndex = 178
        Me.Label34.Text = "Area name:"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.txtCoordSysComments)
        Me.TabPage4.Controls.Add(Me.Label35)
        Me.TabPage4.Controls.Add(Me.txtAxisOrientation3)
        Me.TabPage4.Controls.Add(Me.txtAxisUnit3)
        Me.TabPage4.Controls.Add(Me.txtAxisAbbr3)
        Me.TabPage4.Controls.Add(Me.txtAxisName3)
        Me.TabPage4.Controls.Add(Me.txtAxisOrder3)
        Me.TabPage4.Controls.Add(Me.txtAxisOrientation2)
        Me.TabPage4.Controls.Add(Me.txtAxisUnit2)
        Me.TabPage4.Controls.Add(Me.txtAxisAbbr2)
        Me.TabPage4.Controls.Add(Me.txtAxisName2)
        Me.TabPage4.Controls.Add(Me.txtAxisOrder2)
        Me.TabPage4.Controls.Add(Me.Label36)
        Me.TabPage4.Controls.Add(Me.txtAxisOrientation1)
        Me.TabPage4.Controls.Add(Me.Label37)
        Me.TabPage4.Controls.Add(Me.Label38)
        Me.TabPage4.Controls.Add(Me.Label39)
        Me.TabPage4.Controls.Add(Me.txtAxisUnit1)
        Me.TabPage4.Controls.Add(Me.txtAxisAbbr1)
        Me.TabPage4.Controls.Add(Me.txtAxisName1)
        Me.TabPage4.Controls.Add(Me.txtAxisOrder1)
        Me.TabPage4.Controls.Add(Me.Label40)
        Me.TabPage4.Controls.Add(Me.txtCoordSysDimension)
        Me.TabPage4.Controls.Add(Me.Label41)
        Me.TabPage4.Controls.Add(Me.txtCoordSysType)
        Me.TabPage4.Controls.Add(Me.Label42)
        Me.TabPage4.Controls.Add(Me.txtCoordSysAuthor)
        Me.TabPage4.Controls.Add(Me.Label43)
        Me.TabPage4.Controls.Add(Me.txtCoordSysDeprecated)
        Me.TabPage4.Controls.Add(Me.Label44)
        Me.TabPage4.Controls.Add(Me.txtCoordSysCode)
        Me.TabPage4.Controls.Add(Me.Label45)
        Me.TabPage4.Controls.Add(Me.txtCoordSysName)
        Me.TabPage4.Controls.Add(Me.Label46)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(859, 473)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Coordinate System"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtCoordSysComments
        '
        Me.txtCoordSysComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCoordSysComments.Location = New System.Drawing.Point(67, 232)
        Me.txtCoordSysComments.Multiline = True
        Me.txtCoordSysComments.Name = "txtCoordSysComments"
        Me.txtCoordSysComments.Size = New System.Drawing.Size(774, 233)
        Me.txtCoordSysComments.TabIndex = 276
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(9, 235)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(59, 13)
        Me.Label35.TabIndex = 275
        Me.Label35.Text = "Comments:"
        '
        'txtAxisOrientation3
        '
        Me.txtAxisOrientation3.Location = New System.Drawing.Point(526, 202)
        Me.txtAxisOrientation3.Name = "txtAxisOrientation3"
        Me.txtAxisOrientation3.Size = New System.Drawing.Size(184, 20)
        Me.txtAxisOrientation3.TabIndex = 274
        '
        'txtAxisUnit3
        '
        Me.txtAxisUnit3.Location = New System.Drawing.Point(234, 202)
        Me.txtAxisUnit3.Name = "txtAxisUnit3"
        Me.txtAxisUnit3.Size = New System.Drawing.Size(286, 20)
        Me.txtAxisUnit3.TabIndex = 273
        '
        'txtAxisAbbr3
        '
        Me.txtAxisAbbr3.Location = New System.Drawing.Point(191, 202)
        Me.txtAxisAbbr3.Name = "txtAxisAbbr3"
        Me.txtAxisAbbr3.Size = New System.Drawing.Size(37, 20)
        Me.txtAxisAbbr3.TabIndex = 272
        '
        'txtAxisName3
        '
        Me.txtAxisName3.Location = New System.Drawing.Point(48, 202)
        Me.txtAxisName3.Name = "txtAxisName3"
        Me.txtAxisName3.Size = New System.Drawing.Size(137, 20)
        Me.txtAxisName3.TabIndex = 271
        '
        'txtAxisOrder3
        '
        Me.txtAxisOrder3.Location = New System.Drawing.Point(9, 202)
        Me.txtAxisOrder3.Name = "txtAxisOrder3"
        Me.txtAxisOrder3.Size = New System.Drawing.Size(34, 20)
        Me.txtAxisOrder3.TabIndex = 270
        '
        'txtAxisOrientation2
        '
        Me.txtAxisOrientation2.Location = New System.Drawing.Point(526, 176)
        Me.txtAxisOrientation2.Name = "txtAxisOrientation2"
        Me.txtAxisOrientation2.Size = New System.Drawing.Size(184, 20)
        Me.txtAxisOrientation2.TabIndex = 269
        '
        'txtAxisUnit2
        '
        Me.txtAxisUnit2.Location = New System.Drawing.Point(234, 176)
        Me.txtAxisUnit2.Name = "txtAxisUnit2"
        Me.txtAxisUnit2.Size = New System.Drawing.Size(286, 20)
        Me.txtAxisUnit2.TabIndex = 268
        '
        'txtAxisAbbr2
        '
        Me.txtAxisAbbr2.Location = New System.Drawing.Point(191, 176)
        Me.txtAxisAbbr2.Name = "txtAxisAbbr2"
        Me.txtAxisAbbr2.Size = New System.Drawing.Size(37, 20)
        Me.txtAxisAbbr2.TabIndex = 267
        '
        'txtAxisName2
        '
        Me.txtAxisName2.Location = New System.Drawing.Point(48, 176)
        Me.txtAxisName2.Name = "txtAxisName2"
        Me.txtAxisName2.Size = New System.Drawing.Size(137, 20)
        Me.txtAxisName2.TabIndex = 266
        '
        'txtAxisOrder2
        '
        Me.txtAxisOrder2.Location = New System.Drawing.Point(9, 176)
        Me.txtAxisOrder2.Name = "txtAxisOrder2"
        Me.txtAxisOrder2.Size = New System.Drawing.Size(34, 20)
        Me.txtAxisOrder2.TabIndex = 265
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(523, 134)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(58, 13)
        Me.Label36.TabIndex = 264
        Me.Label36.Text = "Orientation"
        '
        'txtAxisOrientation1
        '
        Me.txtAxisOrientation1.Location = New System.Drawing.Point(526, 150)
        Me.txtAxisOrientation1.Name = "txtAxisOrientation1"
        Me.txtAxisOrientation1.Size = New System.Drawing.Size(184, 20)
        Me.txtAxisOrientation1.TabIndex = 263
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(233, 134)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(48, 13)
        Me.Label37.TabIndex = 262
        Me.Label37.Text = "Axis Unit"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(188, 134)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(29, 13)
        Me.Label38.TabIndex = 261
        Me.Label38.Text = "Abbr"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(45, 134)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(57, 13)
        Me.Label39.TabIndex = 260
        Me.Label39.Text = "Axis Name"
        '
        'txtAxisUnit1
        '
        Me.txtAxisUnit1.Location = New System.Drawing.Point(234, 150)
        Me.txtAxisUnit1.Name = "txtAxisUnit1"
        Me.txtAxisUnit1.Size = New System.Drawing.Size(286, 20)
        Me.txtAxisUnit1.TabIndex = 259
        '
        'txtAxisAbbr1
        '
        Me.txtAxisAbbr1.Location = New System.Drawing.Point(191, 150)
        Me.txtAxisAbbr1.Name = "txtAxisAbbr1"
        Me.txtAxisAbbr1.Size = New System.Drawing.Size(37, 20)
        Me.txtAxisAbbr1.TabIndex = 258
        '
        'txtAxisName1
        '
        Me.txtAxisName1.Location = New System.Drawing.Point(48, 150)
        Me.txtAxisName1.Name = "txtAxisName1"
        Me.txtAxisName1.Size = New System.Drawing.Size(137, 20)
        Me.txtAxisName1.TabIndex = 257
        '
        'txtAxisOrder1
        '
        Me.txtAxisOrder1.Location = New System.Drawing.Point(9, 150)
        Me.txtAxisOrder1.Name = "txtAxisOrder1"
        Me.txtAxisOrder1.Size = New System.Drawing.Size(33, 20)
        Me.txtAxisOrder1.TabIndex = 256
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(9, 134)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(33, 13)
        Me.Label40.TabIndex = 255
        Me.Label40.Text = "Order"
        '
        'txtCoordSysDimension
        '
        Me.txtCoordSysDimension.Location = New System.Drawing.Point(292, 86)
        Me.txtCoordSysDimension.Name = "txtCoordSysDimension"
        Me.txtCoordSysDimension.Size = New System.Drawing.Size(40, 20)
        Me.txtCoordSysDimension.TabIndex = 254
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(227, 89)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(59, 13)
        Me.Label41.TabIndex = 253
        Me.Label41.Text = "Dimension:"
        '
        'txtCoordSysType
        '
        Me.txtCoordSysType.Location = New System.Drawing.Point(55, 86)
        Me.txtCoordSysType.Name = "txtCoordSysType"
        Me.txtCoordSysType.Size = New System.Drawing.Size(159, 20)
        Me.txtCoordSysType.TabIndex = 252
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(9, 89)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(34, 13)
        Me.Label42.TabIndex = 251
        Me.Label42.Text = "Type:"
        '
        'txtCoordSysAuthor
        '
        Me.txtCoordSysAuthor.Location = New System.Drawing.Point(55, 58)
        Me.txtCoordSysAuthor.Name = "txtCoordSysAuthor"
        Me.txtCoordSysAuthor.Size = New System.Drawing.Size(159, 20)
        Me.txtCoordSysAuthor.TabIndex = 250
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(8, 61)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(41, 13)
        Me.Label43.TabIndex = 249
        Me.Label43.Text = "Author:"
        '
        'txtCoordSysDeprecated
        '
        Me.txtCoordSysDeprecated.Location = New System.Drawing.Point(511, 58)
        Me.txtCoordSysDeprecated.Name = "txtCoordSysDeprecated"
        Me.txtCoordSysDeprecated.Size = New System.Drawing.Size(66, 20)
        Me.txtCoordSysDeprecated.TabIndex = 248
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(439, 61)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(66, 13)
        Me.Label44.TabIndex = 247
        Me.Label44.Text = "Deprecated:"
        '
        'txtCoordSysCode
        '
        Me.txtCoordSysCode.Location = New System.Drawing.Point(292, 58)
        Me.txtCoordSysCode.Name = "txtCoordSysCode"
        Me.txtCoordSysCode.Size = New System.Drawing.Size(107, 20)
        Me.txtCoordSysCode.TabIndex = 246
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(251, 61)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(35, 13)
        Me.Label45.TabIndex = 245
        Me.Label45.Text = "Code:"
        '
        'txtCoordSysName
        '
        Me.txtCoordSysName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCoordSysName.Location = New System.Drawing.Point(117, 10)
        Me.txtCoordSysName.Multiline = True
        Me.txtCoordSysName.Name = "txtCoordSysName"
        Me.txtCoordSysName.Size = New System.Drawing.Size(724, 42)
        Me.txtCoordSysName.TabIndex = 244
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(9, 13)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(102, 13)
        Me.Label46.TabIndex = 243
        Me.Label46.Text = "Name / Description:"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.txtDatumType2)
        Me.TabPage5.Controls.Add(Me.Label68)
        Me.TabPage5.Controls.Add(Me.txtDatumAuthor2)
        Me.TabPage5.Controls.Add(Me.Label69)
        Me.TabPage5.Controls.Add(Me.txtDatumDeprecated)
        Me.TabPage5.Controls.Add(Me.Label70)
        Me.TabPage5.Controls.Add(Me.txtDatumScope)
        Me.TabPage5.Controls.Add(Me.txtDatumOrigin)
        Me.TabPage5.Controls.Add(Me.txtDatumCode2)
        Me.TabPage5.Controls.Add(Me.Label71)
        Me.TabPage5.Controls.Add(Me.Label72)
        Me.TabPage5.Controls.Add(Me.Label73)
        Me.TabPage5.Controls.Add(Me.Label74)
        Me.TabPage5.Controls.Add(Me.txtDatumName2)
        Me.TabPage5.Controls.Add(Me.Label75)
        Me.TabPage5.Controls.Add(Me.cmbDatumAliasNames)
        Me.TabPage5.Controls.Add(Me.Button3)
        Me.TabPage5.Controls.Add(Me.Button4)
        Me.TabPage5.Controls.Add(Me.Label76)
        Me.TabPage5.Controls.Add(Me.txtDatumComments)
        Me.TabPage5.Controls.Add(Me.txtAddDatumAlias)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(859, 473)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Datum"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'txtDatumType2
        '
        Me.txtDatumType2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatumType2.Location = New System.Drawing.Point(82, 32)
        Me.txtDatumType2.Name = "txtDatumType2"
        Me.txtDatumType2.Size = New System.Drawing.Size(288, 20)
        Me.txtDatumType2.TabIndex = 178
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(6, 35)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(64, 13)
        Me.Label68.TabIndex = 177
        Me.Label68.Text = "Datum type:"
        '
        'txtDatumAuthor2
        '
        Me.txtDatumAuthor2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatumAuthor2.Location = New System.Drawing.Point(423, 32)
        Me.txtDatumAuthor2.Name = "txtDatumAuthor2"
        Me.txtDatumAuthor2.Size = New System.Drawing.Size(131, 20)
        Me.txtDatumAuthor2.TabIndex = 176
        '
        'Label69
        '
        Me.Label69.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(376, 35)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(41, 13)
        Me.Label69.TabIndex = 175
        Me.Label69.Text = "Author:"
        '
        'txtDatumDeprecated
        '
        Me.txtDatumDeprecated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatumDeprecated.Location = New System.Drawing.Point(786, 32)
        Me.txtDatumDeprecated.Name = "txtDatumDeprecated"
        Me.txtDatumDeprecated.Size = New System.Drawing.Size(67, 20)
        Me.txtDatumDeprecated.TabIndex = 174
        '
        'Label70
        '
        Me.Label70.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(714, 35)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(66, 13)
        Me.Label70.TabIndex = 173
        Me.Label70.Text = "Deprecated:"
        '
        'txtDatumScope
        '
        Me.txtDatumScope.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatumScope.Location = New System.Drawing.Point(81, 263)
        Me.txtDatumScope.Multiline = True
        Me.txtDatumScope.Name = "txtDatumScope"
        Me.txtDatumScope.Size = New System.Drawing.Size(772, 69)
        Me.txtDatumScope.TabIndex = 172
        '
        'txtDatumOrigin
        '
        Me.txtDatumOrigin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatumOrigin.Location = New System.Drawing.Point(81, 188)
        Me.txtDatumOrigin.Multiline = True
        Me.txtDatumOrigin.Name = "txtDatumOrigin"
        Me.txtDatumOrigin.Size = New System.Drawing.Size(772, 69)
        Me.txtDatumOrigin.TabIndex = 171
        '
        'txtDatumCode2
        '
        Me.txtDatumCode2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatumCode2.Location = New System.Drawing.Point(601, 32)
        Me.txtDatumCode2.Name = "txtDatumCode2"
        Me.txtDatumCode2.Size = New System.Drawing.Size(107, 20)
        Me.txtDatumCode2.TabIndex = 170
        '
        'Label71
        '
        Me.Label71.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(560, 35)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(35, 13)
        Me.Label71.TabIndex = 169
        Me.Label71.Text = "Code:"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(6, 9)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(70, 13)
        Me.Label72.TabIndex = 158
        Me.Label72.Text = "Datum name:"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(9, 266)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(41, 13)
        Me.Label73.TabIndex = 167
        Me.Label73.Text = "Scope:"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(6, 190)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(71, 13)
        Me.Label74.TabIndex = 168
        Me.Label74.Text = "Datum Origin:"
        '
        'txtDatumName2
        '
        Me.txtDatumName2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatumName2.Location = New System.Drawing.Point(82, 6)
        Me.txtDatumName2.Name = "txtDatumName2"
        Me.txtDatumName2.Size = New System.Drawing.Size(771, 20)
        Me.txtDatumName2.TabIndex = 159
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(6, 61)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(66, 13)
        Me.Label75.TabIndex = 160
        Me.Label75.Text = "Alias names:"
        '
        'cmbDatumAliasNames
        '
        Me.cmbDatumAliasNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDatumAliasNames.FormattingEnabled = True
        Me.cmbDatumAliasNames.Location = New System.Drawing.Point(82, 58)
        Me.cmbDatumAliasNames.Name = "cmbDatumAliasNames"
        Me.cmbDatumAliasNames.Size = New System.Drawing.Size(726, 21)
        Me.cmbDatumAliasNames.TabIndex = 161
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(814, 57)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(39, 22)
        Me.Button3.TabIndex = 163
        Me.Button3.Text = "Del"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(9, 85)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(77, 22)
        Me.Button4.TabIndex = 162
        Me.Button4.Text = "Add Alias"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(9, 116)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(59, 13)
        Me.Label76.TabIndex = 165
        Me.Label76.Text = "Comments:"
        '
        'txtDatumComments
        '
        Me.txtDatumComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatumComments.Location = New System.Drawing.Point(81, 113)
        Me.txtDatumComments.Multiline = True
        Me.txtDatumComments.Name = "txtDatumComments"
        Me.txtDatumComments.Size = New System.Drawing.Size(772, 69)
        Me.txtDatumComments.TabIndex = 166
        '
        'txtAddDatumAlias
        '
        Me.txtAddDatumAlias.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddDatumAlias.Location = New System.Drawing.Point(92, 86)
        Me.txtAddDatumAlias.Name = "txtAddDatumAlias"
        Me.txtAddDatumAlias.Size = New System.Drawing.Size(761, 20)
        Me.txtAddDatumAlias.TabIndex = 164
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(859, 473)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "List"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(3, 8)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(850, 446)
        Me.ListBox1.TabIndex = 4
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmGeocentricCRS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 606)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtCRSName2)
        Me.Controls.Add(Me.btnMoveDown)
        Me.Controls.Add(Me.btnMoveUp)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.txtRecordNo)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.txtNRecords)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.txtGeocentricCRSListFileName)
        Me.Controls.Add(Me.btnNameFindPrev)
        Me.Controls.Add(Me.btnNameFindNext)
        Me.Controls.Add(Me.txtSearchText)
        Me.Controls.Add(Me.btnNameFind)
        Me.Controls.Add(Me.btnGetEpsgList)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmGeocentricCRS"
        Me.Text = "Geocentric Coordinate Reference System"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnNameFindPrev As System.Windows.Forms.Button
    Friend WithEvents btnNameFindNext As System.Windows.Forms.Button
    Friend WithEvents txtSearchText As System.Windows.Forms.TextBox
    Friend WithEvents btnNameFind As System.Windows.Forms.Button
    Friend WithEvents btnGetEpsgList As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents txtGeocentricCRSListFileName As System.Windows.Forms.TextBox
    Friend WithEvents txtCRSName2 As System.Windows.Forms.TextBox
    Friend WithEvents btnMoveDown As System.Windows.Forms.Button
    Friend WithEvents btnMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents txtRecordNo As System.Windows.Forms.TextBox
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents txtNRecords As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtDatumType As System.Windows.Forms.TextBox
    Friend WithEvents txtCSType As System.Windows.Forms.TextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents txtDatumName As System.Windows.Forms.TextBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents txtCSName As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents txtAOUName As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtCrsScope As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCrsComments As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbCRSAliasNames As System.Windows.Forms.ComboBox
    Friend WithEvents btnDelAlias As System.Windows.Forms.Button
    Friend WithEvents btnAddAlias As System.Windows.Forms.Button
    Friend WithEvents txtNewAliasName As System.Windows.Forms.TextBox
    Friend WithEvents txtCrsAuthor As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents txtCrsDeprecated As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtCrsCode As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtCRSName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtAreaOfUseDeprecated As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtAreaOfUseAuthor As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtAreaOfUseCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAreaOfUse As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtNLatDegrees As System.Windows.Forms.TextBox
    Friend WithEvents cmbWLongWE As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtNLatMinutes As System.Windows.Forms.TextBox
    Friend WithEvents txtWLongSeconds As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtNLatSeconds As System.Windows.Forms.TextBox
    Friend WithEvents txtWLongMinutes As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmbNLatNS As System.Windows.Forms.ComboBox
    Friend WithEvents txtWLongDegrees As System.Windows.Forms.TextBox
    Friend WithEvents txtSLatDegrees As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbELongWE As System.Windows.Forms.ComboBox
    Friend WithEvents txtSLatMinutes As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtELongSeconds As System.Windows.Forms.TextBox
    Friend WithEvents txtSLatSeconds As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtELongMinutes As System.Windows.Forms.TextBox
    Friend WithEvents cmbSLatNS As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtELongDegrees As System.Windows.Forms.TextBox
    Friend WithEvents txtIsoNumericCode As System.Windows.Forms.TextBox
    Friend WithEvents txtIso3CharCode As System.Windows.Forms.TextBox
    Friend WithEvents txtIso2CharCode As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtAreaComments As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtAddAreaOfUseAlias As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmbAreaAliasNames As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtAreaOfUseName As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents txtCoordSysComments As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtAxisOrientation3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAxisUnit3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAxisAbbr3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAxisName3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAxisOrder3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAxisOrientation2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAxisUnit2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAxisAbbr2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAxisName2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAxisOrder2 As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtAxisOrientation1 As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtAxisUnit1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAxisAbbr1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAxisName1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAxisOrder1 As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtCoordSysDimension As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtCoordSysType As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtCoordSysAuthor As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtCoordSysDeprecated As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtCoordSysCode As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txtCoordSysName As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents txtDatumType2 As System.Windows.Forms.TextBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents txtDatumAuthor2 As System.Windows.Forms.TextBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents txtDatumDeprecated As System.Windows.Forms.TextBox
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents txtDatumScope As System.Windows.Forms.TextBox
    Friend WithEvents txtDatumOrigin As System.Windows.Forms.TextBox
    Friend WithEvents txtDatumCode2 As System.Windows.Forms.TextBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents txtDatumName2 As System.Windows.Forms.TextBox
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents cmbDatumAliasNames As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents txtDatumComments As System.Windows.Forms.TextBox
    Friend WithEvents txtAddDatumAlias As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
