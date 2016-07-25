<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrimeMeridians
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
        Me.btnNameFind = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnGetEpsgList = New System.Windows.Forms.Button()
        Me.btnMoveDown = New System.Windows.Forms.Button()
        Me.btnMoveUp = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtRecordNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNRecords = New System.Windows.Forms.TextBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtPmListFileName = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtPMAuthor = New System.Windows.Forms.TextBox()
        Me.txtPMDeprecated = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.txtSexagesimalDegrees = New System.Windows.Forms.TextBox()
        Me.txtDecimalDegrees = New System.Windows.Forms.TextBox()
        Me.txtPmCode = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbWE = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRadians = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbUnits = New System.Windows.Forms.ComboBox()
        Me.txtGrads = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSeconds = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMinutes = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDegrees = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNewAliasName = New System.Windows.Forms.TextBox()
        Me.btnDelAlias = New System.Windows.Forms.Button()
        Me.btnAddAlias = New System.Windows.Forms.Button()
        Me.cmbAliasNames = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPrimeMeridianName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnNameFindPrev = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNameFindNext
        '
        Me.btnNameFindNext.Location = New System.Drawing.Point(280, 12)
        Me.btnNameFindNext.Name = "btnNameFindNext"
        Me.btnNameFindNext.Size = New System.Drawing.Size(40, 22)
        Me.btnNameFindNext.TabIndex = 210
        Me.btnNameFindNext.Text = "Next"
        Me.btnNameFindNext.UseVisualStyleBackColor = True
        '
        'txtSearchText
        '
        Me.txtSearchText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchText.Location = New System.Drawing.Point(326, 13)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(272, 20)
        Me.txtSearchText.TabIndex = 209
        '
        'btnNameFind
        '
        Me.btnNameFind.Location = New System.Drawing.Point(170, 12)
        Me.btnNameFind.Name = "btnNameFind"
        Me.btnNameFind.Size = New System.Drawing.Size(58, 22)
        Me.btnNameFind.TabIndex = 208
        Me.btnNameFind.Text = "Find First"
        Me.btnNameFind.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 13)
        Me.Label13.TabIndex = 207
        Me.Label13.Text = "Prime Meridian List File:"
        '
        'btnGetEpsgList
        '
        Me.btnGetEpsgList.Location = New System.Drawing.Point(70, 12)
        Me.btnGetEpsgList.Name = "btnGetEpsgList"
        Me.btnGetEpsgList.Size = New System.Drawing.Size(94, 22)
        Me.btnGetEpsgList.TabIndex = 206
        Me.btnGetEpsgList.Text = "Get EPSG List"
        Me.btnGetEpsgList.UseVisualStyleBackColor = True
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Location = New System.Drawing.Point(520, 67)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(74, 22)
        Me.btnMoveDown.TabIndex = 205
        Me.btnMoveDown.Text = "Move Dwn"
        Me.btnMoveDown.UseVisualStyleBackColor = True
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Location = New System.Drawing.Point(453, 67)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(61, 22)
        Me.btnMoveUp.TabIndex = 204
        Me.btnMoveUp.Text = "Move Up"
        Me.btnMoveUp.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Location = New System.Drawing.Point(408, 67)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(39, 22)
        Me.btnDel.TabIndex = 203
        Me.btnDel.Text = "Del"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(363, 67)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(39, 22)
        Me.btnAdd.TabIndex = 202
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtRecordNo
        '
        Me.txtRecordNo.Location = New System.Drawing.Point(57, 68)
        Me.txtRecordNo.Name = "txtRecordNo"
        Me.txtRecordNo.Size = New System.Drawing.Size(45, 20)
        Me.txtRecordNo.TabIndex = 201
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 200
        Me.Label2.Text = "Record"
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(318, 67)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(39, 22)
        Me.btnLast.TabIndex = 199
        Me.btnLast.Text = "Last"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(273, 67)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(39, 22)
        Me.btnNext.TabIndex = 198
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(228, 67)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(39, 22)
        Me.btnPrev.TabIndex = 197
        Me.btnPrev.Text = "Prev"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(183, 67)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(39, 22)
        Me.btnFirst.TabIndex = 196
        Me.btnFirst.Text = "First"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(108, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 195
        Me.Label1.Text = "of"
        '
        'txtNRecords
        '
        Me.txtNRecords.Location = New System.Drawing.Point(129, 68)
        Me.txtNRecords.Name = "txtNRecords"
        Me.txtNRecords.ReadOnly = True
        Me.txtNRecords.Size = New System.Drawing.Size(47, 20)
        Me.txtNRecords.TabIndex = 194
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFind.Location = New System.Drawing.Point(620, 40)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(48, 22)
        Me.btnFind.TabIndex = 193
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtPmListFileName
        '
        Me.txtPmListFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPmListFileName.Location = New System.Drawing.Point(129, 41)
        Me.txtPmListFileName.Name = "txtPmListFileName"
        Me.txtPmListFileName.Size = New System.Drawing.Size(485, 20)
        Me.txtPmListFileName.TabIndex = 192
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(52, 22)
        Me.btnSave.TabIndex = 190
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(604, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 189
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 95)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(656, 356)
        Me.TabControl1.TabIndex = 211
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtPMAuthor)
        Me.TabPage1.Controls.Add(Me.txtPMDeprecated)
        Me.TabPage1.Controls.Add(Me.Label52)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label54)
        Me.TabPage1.Controls.Add(Me.Label53)
        Me.TabPage1.Controls.Add(Me.txtSexagesimalDegrees)
        Me.TabPage1.Controls.Add(Me.txtDecimalDegrees)
        Me.TabPage1.Controls.Add(Me.txtPmCode)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.cmbWE)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.txtRadians)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.cmbUnits)
        Me.TabPage1.Controls.Add(Me.txtGrads)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtSeconds)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtMinutes)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtDegrees)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtComments)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtNewAliasName)
        Me.TabPage1.Controls.Add(Me.btnDelAlias)
        Me.TabPage1.Controls.Add(Me.btnAddAlias)
        Me.TabPage1.Controls.Add(Me.cmbAliasNames)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtPrimeMeridianName)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(648, 330)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Prime Meridian"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtPMAuthor
        '
        Me.txtPMAuthor.Location = New System.Drawing.Point(91, 32)
        Me.txtPMAuthor.Name = "txtPMAuthor"
        Me.txtPMAuthor.Size = New System.Drawing.Size(119, 20)
        Me.txtPMAuthor.TabIndex = 198
        '
        'txtPMDeprecated
        '
        Me.txtPMDeprecated.Location = New System.Drawing.Point(464, 32)
        Me.txtPMDeprecated.Name = "txtPMDeprecated"
        Me.txtPMDeprecated.Size = New System.Drawing.Size(66, 20)
        Me.txtPMDeprecated.TabIndex = 197
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(392, 35)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(66, 13)
        Me.Label52.TabIndex = 196
        Me.Label52.Text = "Deprecated:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 195
        Me.Label14.Text = "Author:"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(372, 243)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(107, 13)
        Me.Label54.TabIndex = 194
        Me.Label54.Text = "Sexagesimal degrees"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(372, 217)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(86, 13)
        Me.Label53.TabIndex = 193
        Me.Label53.Text = "Decimal degrees"
        '
        'txtSexagesimalDegrees
        '
        Me.txtSexagesimalDegrees.Location = New System.Drawing.Point(179, 240)
        Me.txtSexagesimalDegrees.Name = "txtSexagesimalDegrees"
        Me.txtSexagesimalDegrees.Size = New System.Drawing.Size(186, 20)
        Me.txtSexagesimalDegrees.TabIndex = 192
        '
        'txtDecimalDegrees
        '
        Me.txtDecimalDegrees.Location = New System.Drawing.Point(179, 214)
        Me.txtDecimalDegrees.Name = "txtDecimalDegrees"
        Me.txtDecimalDegrees.Size = New System.Drawing.Size(186, 20)
        Me.txtDecimalDegrees.TabIndex = 191
        '
        'txtPmCode
        '
        Me.txtPmCode.Location = New System.Drawing.Point(288, 32)
        Me.txtPmCode.Name = "txtPmCode"
        Me.txtPmCode.Size = New System.Drawing.Size(68, 20)
        Me.txtPmCode.TabIndex = 190
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(247, 35)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(35, 13)
        Me.Label26.TabIndex = 189
        Me.Label26.Text = "Code:"
        '
        'cmbWE
        '
        Me.cmbWE.FormattingEnabled = True
        Me.cmbWE.Location = New System.Drawing.Point(394, 188)
        Me.cmbWE.Name = "cmbWE"
        Me.cmbWE.Size = New System.Drawing.Size(42, 21)
        Me.cmbWE.TabIndex = 188
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(372, 295)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 187
        Me.Label12.Text = "Radians"
        '
        'txtRadians
        '
        Me.txtRadians.Location = New System.Drawing.Point(179, 292)
        Me.txtRadians.Name = "txtRadians"
        Me.txtRadians.Size = New System.Drawing.Size(186, 20)
        Me.txtRadians.TabIndex = 186
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(371, 269)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 185
        Me.Label11.Text = "Gradians"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 217)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 184
        Me.Label10.Text = "Units:"
        '
        'cmbUnits
        '
        Me.cmbUnits.FormattingEnabled = True
        Me.cmbUnits.Location = New System.Drawing.Point(46, 214)
        Me.cmbUnits.Name = "cmbUnits"
        Me.cmbUnits.Size = New System.Drawing.Size(127, 21)
        Me.cmbUnits.TabIndex = 183
        '
        'txtGrads
        '
        Me.txtGrads.Location = New System.Drawing.Point(179, 266)
        Me.txtGrads.Name = "txtGrads"
        Me.txtGrads.Size = New System.Drawing.Size(186, 20)
        Me.txtGrads.TabIndex = 182
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(271, 172)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 181
        Me.Label9.Text = "Sec"
        '
        'txtSeconds
        '
        Me.txtSeconds.Location = New System.Drawing.Point(268, 189)
        Me.txtSeconds.Name = "txtSeconds"
        Me.txtSeconds.Size = New System.Drawing.Size(120, 20)
        Me.txtSeconds.TabIndex = 180
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(227, 172)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 179
        Me.Label7.Text = "Min"
        '
        'txtMinutes
        '
        Me.txtMinutes.Location = New System.Drawing.Point(224, 189)
        Me.txtMinutes.Name = "txtMinutes"
        Me.txtMinutes.Size = New System.Drawing.Size(38, 20)
        Me.txtMinutes.TabIndex = 178
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(183, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 177
        Me.Label6.Text = "Deg"
        '
        'txtDegrees
        '
        Me.txtDegrees.Location = New System.Drawing.Point(180, 189)
        Me.txtDegrees.Name = "txtDegrees"
        Me.txtDegrees.Size = New System.Drawing.Size(39, 20)
        Me.txtDegrees.TabIndex = 176
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 191)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 13)
        Me.Label5.TabIndex = 175
        Me.Label5.Text = "Longitude from Greenwich:"
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComments.Location = New System.Drawing.Point(91, 116)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(551, 53)
        Me.txtComments.TabIndex = 174
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 173
        Me.Label4.Text = "Comments:"
        '
        'txtNewAliasName
        '
        Me.txtNewAliasName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewAliasName.Location = New System.Drawing.Point(91, 90)
        Me.txtNewAliasName.Name = "txtNewAliasName"
        Me.txtNewAliasName.Size = New System.Drawing.Size(551, 20)
        Me.txtNewAliasName.TabIndex = 172
        '
        'btnDelAlias
        '
        Me.btnDelAlias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelAlias.Location = New System.Drawing.Point(603, 63)
        Me.btnDelAlias.Name = "btnDelAlias"
        Me.btnDelAlias.Size = New System.Drawing.Size(39, 22)
        Me.btnDelAlias.TabIndex = 171
        Me.btnDelAlias.Text = "Del"
        Me.btnDelAlias.UseVisualStyleBackColor = True
        '
        'btnAddAlias
        '
        Me.btnAddAlias.Location = New System.Drawing.Point(6, 88)
        Me.btnAddAlias.Name = "btnAddAlias"
        Me.btnAddAlias.Size = New System.Drawing.Size(77, 22)
        Me.btnAddAlias.TabIndex = 170
        Me.btnAddAlias.Text = "Add Alias"
        Me.btnAddAlias.UseVisualStyleBackColor = True
        '
        'cmbAliasNames
        '
        Me.cmbAliasNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAliasNames.FormattingEnabled = True
        Me.cmbAliasNames.Location = New System.Drawing.Point(91, 63)
        Me.cmbAliasNames.Name = "cmbAliasNames"
        Me.cmbAliasNames.Size = New System.Drawing.Size(506, 21)
        Me.cmbAliasNames.TabIndex = 169
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 168
        Me.Label8.Text = "Alias names:"
        '
        'txtPrimeMeridianName
        '
        Me.txtPrimeMeridianName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrimeMeridianName.Location = New System.Drawing.Point(119, 6)
        Me.txtPrimeMeridianName.Name = "txtPrimeMeridianName"
        Me.txtPrimeMeridianName.Size = New System.Drawing.Size(523, 20)
        Me.txtPrimeMeridianName.TabIndex = 167
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 166
        Me.Label3.Text = "Prime meridian name:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(648, 330)
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
        Me.ListBox1.Location = New System.Drawing.Point(6, 10)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(624, 303)
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
        Me.btnNameFindPrev.TabIndex = 262
        Me.btnNameFindPrev.Text = "Prev"
        Me.btnNameFindPrev.UseVisualStyleBackColor = True
        '
        'frmPrimeMeridians
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(680, 463)
        Me.Controls.Add(Me.btnNameFindPrev)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnNameFindNext)
        Me.Controls.Add(Me.txtSearchText)
        Me.Controls.Add(Me.btnNameFind)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnGetEpsgList)
        Me.Controls.Add(Me.btnMoveDown)
        Me.Controls.Add(Me.btnMoveUp)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtRecordNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNRecords)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.txtPmListFileName)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmPrimeMeridians"
        Me.Text = "Prime Meridian"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNameFindNext As System.Windows.Forms.Button
    Friend WithEvents txtSearchText As System.Windows.Forms.TextBox
    Friend WithEvents btnNameFind As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnGetEpsgList As System.Windows.Forms.Button
    Friend WithEvents btnMoveDown As System.Windows.Forms.Button
    Friend WithEvents btnMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtRecordNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNRecords As System.Windows.Forms.TextBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents txtPmListFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtPMAuthor As System.Windows.Forms.TextBox
    Friend WithEvents txtPMDeprecated As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents txtSexagesimalDegrees As System.Windows.Forms.TextBox
    Friend WithEvents txtDecimalDegrees As System.Windows.Forms.TextBox
    Friend WithEvents txtPmCode As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbWE As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtRadians As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbUnits As System.Windows.Forms.ComboBox
    Friend WithEvents txtGrads As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSeconds As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMinutes As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDegrees As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNewAliasName As System.Windows.Forms.TextBox
    Friend WithEvents btnDelAlias As System.Windows.Forms.Button
    Friend WithEvents btnAddAlias As System.Windows.Forms.Button
    Friend WithEvents cmbAliasNames As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPrimeMeridianName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnNameFindPrev As System.Windows.Forms.Button
End Class
