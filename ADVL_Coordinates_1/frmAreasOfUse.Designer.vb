<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAreasOfUse
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtDeprecated = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtAouCode = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
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
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtNLatSeconds = New System.Windows.Forms.TextBox()
        Me.txtWLongMinutes = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNewAliasName = New System.Windows.Forms.TextBox()
        Me.btnDelAlias = New System.Windows.Forms.Button()
        Me.btnAddAlias = New System.Windows.Forms.Button()
        Me.cmbAliasNames = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAreaOfUseName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnGetEpsgList = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtAouListFileName = New System.Windows.Forms.TextBox()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnNameFindPrev = New System.Windows.Forms.Button()
        Me.btnCopyToClipboard = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNameFindNext
        '
        Me.btnNameFindNext.Location = New System.Drawing.Point(338, 12)
        Me.btnNameFindNext.Name = "btnNameFindNext"
        Me.btnNameFindNext.Size = New System.Drawing.Size(40, 22)
        Me.btnNameFindNext.TabIndex = 198
        Me.btnNameFindNext.Text = "Next"
        Me.btnNameFindNext.UseVisualStyleBackColor = True
        '
        'txtSearchText
        '
        Me.txtSearchText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchText.Location = New System.Drawing.Point(387, 13)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(324, 20)
        Me.txtSearchText.TabIndex = 197
        '
        'btnNameFind
        '
        Me.btnNameFind.Location = New System.Drawing.Point(228, 12)
        Me.btnNameFind.Name = "btnNameFind"
        Me.btnNameFind.Size = New System.Drawing.Size(58, 22)
        Me.btnNameFind.TabIndex = 196
        Me.btnNameFind.Text = "Find First"
        Me.btnNameFind.UseVisualStyleBackColor = True
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Location = New System.Drawing.Point(522, 67)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(74, 22)
        Me.btnMoveDown.TabIndex = 195
        Me.btnMoveDown.Text = "Move Dwn"
        Me.btnMoveDown.UseVisualStyleBackColor = True
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Location = New System.Drawing.Point(455, 67)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(61, 22)
        Me.btnMoveUp.TabIndex = 194
        Me.btnMoveUp.Text = "Move Up"
        Me.btnMoveUp.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Location = New System.Drawing.Point(410, 67)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(39, 22)
        Me.btnDel.TabIndex = 193
        Me.btnDel.Text = "Del"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(365, 67)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(39, 22)
        Me.btnAdd.TabIndex = 192
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtRecordNo
        '
        Me.txtRecordNo.Location = New System.Drawing.Point(59, 68)
        Me.txtRecordNo.Name = "txtRecordNo"
        Me.txtRecordNo.Size = New System.Drawing.Size(45, 20)
        Me.txtRecordNo.TabIndex = 191
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 190
        Me.Label2.Text = "Record"
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(320, 67)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(39, 22)
        Me.btnLast.TabIndex = 189
        Me.btnLast.Text = "Last"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(275, 67)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(39, 22)
        Me.btnNext.TabIndex = 188
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(230, 67)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(39, 22)
        Me.btnPrev.TabIndex = 187
        Me.btnPrev.Text = "Prev"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(185, 67)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(39, 22)
        Me.btnFirst.TabIndex = 186
        Me.btnFirst.Text = "First"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(110, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 185
        Me.Label1.Text = "of"
        '
        'txtNRecords
        '
        Me.txtNRecords.Location = New System.Drawing.Point(131, 68)
        Me.txtNRecords.Name = "txtNRecords"
        Me.txtNRecords.ReadOnly = True
        Me.txtNRecords.Size = New System.Drawing.Size(47, 20)
        Me.txtNRecords.TabIndex = 184
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.ItemSize = New System.Drawing.Size(52, 18)
        Me.TabControl1.Location = New System.Drawing.Point(15, 95)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(766, 532)
        Me.TabControl1.TabIndex = 183
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtDeprecated)
        Me.TabPage1.Controls.Add(Me.Label29)
        Me.TabPage1.Controls.Add(Me.txtAuthor)
        Me.TabPage1.Controls.Add(Me.Label27)
        Me.TabPage1.Controls.Add(Me.txtAouCode)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.txtAreaOfUse)
        Me.TabPage1.Controls.Add(Me.Label25)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.txtIsoNumericCode)
        Me.TabPage1.Controls.Add(Me.txtIso3CharCode)
        Me.TabPage1.Controls.Add(Me.txtIso2CharCode)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtComments)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtNewAliasName)
        Me.TabPage1.Controls.Add(Me.btnDelAlias)
        Me.TabPage1.Controls.Add(Me.btnAddAlias)
        Me.TabPage1.Controls.Add(Me.cmbAliasNames)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtAreaOfUseName)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(758, 506)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Area of Use"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtDeprecated
        '
        Me.txtDeprecated.Location = New System.Drawing.Point(560, 32)
        Me.txtDeprecated.Name = "txtDeprecated"
        Me.txtDeprecated.Size = New System.Drawing.Size(60, 20)
        Me.txtDeprecated.TabIndex = 177
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(488, 35)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(66, 13)
        Me.Label29.TabIndex = 176
        Me.Label29.Text = "Deprecated:"
        '
        'txtAuthor
        '
        Me.txtAuthor.Location = New System.Drawing.Point(78, 32)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(262, 20)
        Me.txtAuthor.TabIndex = 175
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(9, 35)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(41, 13)
        Me.Label27.TabIndex = 174
        Me.Label27.Text = "Author:"
        '
        'txtAouCode
        '
        Me.txtAouCode.Location = New System.Drawing.Point(401, 32)
        Me.txtAouCode.Name = "txtAouCode"
        Me.txtAouCode.Size = New System.Drawing.Size(68, 20)
        Me.txtAouCode.TabIndex = 173
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(360, 35)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(35, 13)
        Me.Label26.TabIndex = 172
        Me.Label26.Text = "Code:"
        '
        'txtAreaOfUse
        '
        Me.txtAreaOfUse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAreaOfUse.Location = New System.Drawing.Point(78, 371)
        Me.txtAreaOfUse.Multiline = True
        Me.txtAreaOfUse.Name = "txtAreaOfUse"
        Me.txtAreaOfUse.Size = New System.Drawing.Size(674, 129)
        Me.txtAreaOfUse.TabIndex = 171
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(9, 374)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(63, 13)
        Me.Label25.TabIndex = 170
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
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtNLatSeconds)
        Me.GroupBox1.Controls.Add(Me.txtWLongMinutes)
        Me.GroupBox1.Controls.Add(Me.Label9)
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 198)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(624, 167)
        Me.GroupBox1.TabIndex = 169
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
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(265, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 13)
        Me.Label10.TabIndex = 100
        Me.Label10.Text = "Min"
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(308, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 102
        Me.Label9.Text = "Sec"
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
        Me.txtIsoNumericCode.Location = New System.Drawing.Point(475, 172)
        Me.txtIsoNumericCode.Name = "txtIsoNumericCode"
        Me.txtIsoNumericCode.Size = New System.Drawing.Size(48, 20)
        Me.txtIsoNumericCode.TabIndex = 168
        '
        'txtIso3CharCode
        '
        Me.txtIso3CharCode.Location = New System.Drawing.Point(310, 172)
        Me.txtIso3CharCode.Name = "txtIso3CharCode"
        Me.txtIso3CharCode.Size = New System.Drawing.Size(48, 20)
        Me.txtIso3CharCode.TabIndex = 167
        '
        'txtIso2CharCode
        '
        Me.txtIso2CharCode.Location = New System.Drawing.Point(125, 172)
        Me.txtIso2CharCode.Name = "txtIso2CharCode"
        Me.txtIso2CharCode.Size = New System.Drawing.Size(48, 20)
        Me.txtIso2CharCode.TabIndex = 166
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(374, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 13)
        Me.Label7.TabIndex = 165
        Me.Label7.Text = "ISO Numeric Code"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(194, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 164
        Me.Label6.Text = "ISO 3-character Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 13)
        Me.Label5.TabIndex = 163
        Me.Label5.Text = "ISO 2-character Code"
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComments.Location = New System.Drawing.Point(97, 113)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(655, 53)
        Me.txtComments.TabIndex = 162
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 161
        Me.Label4.Text = "Comments:"
        '
        'txtNewAliasName
        '
        Me.txtNewAliasName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewAliasName.Location = New System.Drawing.Point(97, 87)
        Me.txtNewAliasName.Name = "txtNewAliasName"
        Me.txtNewAliasName.Size = New System.Drawing.Size(655, 20)
        Me.txtNewAliasName.TabIndex = 160
        '
        'btnDelAlias
        '
        Me.btnDelAlias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelAlias.Location = New System.Drawing.Point(713, 58)
        Me.btnDelAlias.Name = "btnDelAlias"
        Me.btnDelAlias.Size = New System.Drawing.Size(39, 22)
        Me.btnDelAlias.TabIndex = 159
        Me.btnDelAlias.Text = "Del"
        Me.btnDelAlias.UseVisualStyleBackColor = True
        '
        'btnAddAlias
        '
        Me.btnAddAlias.Location = New System.Drawing.Point(8, 85)
        Me.btnAddAlias.Name = "btnAddAlias"
        Me.btnAddAlias.Size = New System.Drawing.Size(77, 22)
        Me.btnAddAlias.TabIndex = 158
        Me.btnAddAlias.Text = "Add Alias"
        Me.btnAddAlias.UseVisualStyleBackColor = True
        '
        'cmbAliasNames
        '
        Me.cmbAliasNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAliasNames.FormattingEnabled = True
        Me.cmbAliasNames.Location = New System.Drawing.Point(78, 58)
        Me.cmbAliasNames.Name = "cmbAliasNames"
        Me.cmbAliasNames.Size = New System.Drawing.Size(629, 21)
        Me.cmbAliasNames.TabIndex = 157
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 156
        Me.Label8.Text = "Alias names:"
        '
        'txtAreaOfUseName
        '
        Me.txtAreaOfUseName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAreaOfUseName.Location = New System.Drawing.Point(78, 6)
        Me.txtAreaOfUseName.Name = "txtAreaOfUseName"
        Me.txtAreaOfUseName.Size = New System.Drawing.Size(674, 20)
        Me.txtAreaOfUseName.TabIndex = 155
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "Area name:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(786, 506)
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
        Me.ListBox1.Location = New System.Drawing.Point(6, 14)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(776, 485)
        Me.ListBox1.TabIndex = 1
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(12, 44)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(124, 13)
        Me.Label28.TabIndex = 182
        Me.Label28.Text = "Area of use list file name:"
        '
        'btnGetEpsgList
        '
        Me.btnGetEpsgList.Location = New System.Drawing.Point(128, 12)
        Me.btnGetEpsgList.Name = "btnGetEpsgList"
        Me.btnGetEpsgList.Size = New System.Drawing.Size(94, 22)
        Me.btnGetEpsgList.TabIndex = 181
        Me.btnGetEpsgList.Text = "Get EPSG List"
        Me.btnGetEpsgList.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFind.Location = New System.Drawing.Point(733, 40)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(48, 22)
        Me.btnFind.TabIndex = 180
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtAouListFileName
        '
        Me.txtAouListFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAouListFileName.Location = New System.Drawing.Point(141, 41)
        Me.txtAouListFileName.Name = "txtAouListFileName"
        Me.txtAouListFileName.Size = New System.Drawing.Size(586, 20)
        Me.txtAouListFileName.TabIndex = 179
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(70, 12)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(52, 22)
        Me.btnNew.TabIndex = 177
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(52, 22)
        Me.btnSave.TabIndex = 176
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(717, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 175
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnNameFindPrev
        '
        Me.btnNameFindPrev.Location = New System.Drawing.Point(292, 12)
        Me.btnNameFindPrev.Name = "btnNameFindPrev"
        Me.btnNameFindPrev.Size = New System.Drawing.Size(40, 22)
        Me.btnNameFindPrev.TabIndex = 199
        Me.btnNameFindPrev.Text = "Prev"
        Me.btnNameFindPrev.UseVisualStyleBackColor = True
        '
        'btnCopyToClipboard
        '
        Me.btnCopyToClipboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyToClipboard.Location = New System.Drawing.Point(670, 67)
        Me.btnCopyToClipboard.Name = "btnCopyToClipboard"
        Me.btnCopyToClipboard.Size = New System.Drawing.Size(111, 22)
        Me.btnCopyToClipboard.TabIndex = 200
        Me.btnCopyToClipboard.Text = "Copy to Clipboard"
        Me.btnCopyToClipboard.UseVisualStyleBackColor = True
        '
        'frmAreasOfUse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 639)
        Me.Controls.Add(Me.btnCopyToClipboard)
        Me.Controls.Add(Me.btnNameFindPrev)
        Me.Controls.Add(Me.btnNameFindNext)
        Me.Controls.Add(Me.txtSearchText)
        Me.Controls.Add(Me.btnNameFind)
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
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.btnGetEpsgList)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.txtAouListFileName)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmAreasOfUse"
        Me.Text = "Area Of Use"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNameFindNext As System.Windows.Forms.Button
    Friend WithEvents txtSearchText As System.Windows.Forms.TextBox
    Friend WithEvents btnNameFind As System.Windows.Forms.Button
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtDeprecated As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtAuthor As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtAouCode As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
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
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtNLatSeconds As System.Windows.Forms.TextBox
    Friend WithEvents txtWLongMinutes As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
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
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNewAliasName As System.Windows.Forms.TextBox
    Friend WithEvents btnDelAlias As System.Windows.Forms.Button
    Friend WithEvents btnAddAlias As System.Windows.Forms.Button
    Friend WithEvents cmbAliasNames As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAreaOfUseName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents btnGetEpsgList As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents txtAouListFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnNameFindPrev As System.Windows.Forms.Button
    Friend WithEvents btnCopyToClipboard As Button
End Class
