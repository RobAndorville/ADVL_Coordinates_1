<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCoordOpMethods
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
        Me.txtMethodName = New System.Windows.Forms.TextBox()
        Me.btnMoveDown = New System.Windows.Forms.Button()
        Me.btnMoveUp = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.txtRecordNo = New System.Windows.Forms.TextBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.txtNRecords = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtCoordOpMethodListFileName = New System.Windows.Forms.TextBox()
        Me.btnGetEpsgList = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.txtReversable = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbAliasNames = New System.Windows.Forms.ComboBox()
        Me.btnAddAlias = New System.Windows.Forms.Button()
        Me.txtNewAliasName = New System.Windows.Forms.TextBox()
        Me.txtDeprecated = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMethodName2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.rtbFormula = New System.Windows.Forms.RichTextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.rtbExample = New System.Windows.Forms.RichTextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnNameFindPrev = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNameFindNext
        '
        Me.btnNameFindNext.Location = New System.Drawing.Point(280, 12)
        Me.btnNameFindNext.Name = "btnNameFindNext"
        Me.btnNameFindNext.Size = New System.Drawing.Size(40, 22)
        Me.btnNameFindNext.TabIndex = 252
        Me.btnNameFindNext.Text = "Next"
        Me.btnNameFindNext.UseVisualStyleBackColor = True
        '
        'txtSearchText
        '
        Me.txtSearchText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchText.Location = New System.Drawing.Point(326, 13)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(473, 20)
        Me.txtSearchText.TabIndex = 251
        '
        'btnNameFind
        '
        Me.btnNameFind.Location = New System.Drawing.Point(170, 12)
        Me.btnNameFind.Name = "btnNameFind"
        Me.btnNameFind.Size = New System.Drawing.Size(58, 22)
        Me.btnNameFind.TabIndex = 250
        Me.btnNameFind.Text = "Find First"
        Me.btnNameFind.UseVisualStyleBackColor = True
        '
        'txtMethodName
        '
        Me.txtMethodName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMethodName.Location = New System.Drawing.Point(598, 68)
        Me.txtMethodName.Name = "txtMethodName"
        Me.txtMethodName.Size = New System.Drawing.Size(271, 20)
        Me.txtMethodName.TabIndex = 249
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Location = New System.Drawing.Point(518, 68)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(74, 22)
        Me.btnMoveDown.TabIndex = 248
        Me.btnMoveDown.Text = "Move Dwn"
        Me.btnMoveDown.UseVisualStyleBackColor = True
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Location = New System.Drawing.Point(451, 68)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(61, 22)
        Me.btnMoveUp.TabIndex = 247
        Me.btnMoveUp.Text = "Move Up"
        Me.btnMoveUp.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Location = New System.Drawing.Point(406, 68)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(39, 22)
        Me.btnDel.TabIndex = 246
        Me.btnDel.Text = "Del"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(361, 68)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(39, 22)
        Me.btnAdd.TabIndex = 245
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(316, 68)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(39, 22)
        Me.btnLast.TabIndex = 242
        Me.btnLast.Text = "Last"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'txtRecordNo
        '
        Me.txtRecordNo.Location = New System.Drawing.Point(55, 68)
        Me.txtRecordNo.Name = "txtRecordNo"
        Me.txtRecordNo.Size = New System.Drawing.Size(45, 20)
        Me.txtRecordNo.TabIndex = 244
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(271, 68)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(39, 22)
        Me.btnNext.TabIndex = 241
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 243
        Me.Label9.Text = "Record"
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(226, 68)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(39, 22)
        Me.btnPrev.TabIndex = 240
        Me.btnPrev.Text = "Prev"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(106, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(16, 13)
        Me.Label10.TabIndex = 238
        Me.Label10.Text = "of"
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(181, 68)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(39, 22)
        Me.btnFirst.TabIndex = 239
        Me.btnFirst.Text = "First"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'txtNRecords
        '
        Me.txtNRecords.Location = New System.Drawing.Point(128, 68)
        Me.txtNRecords.Name = "txtNRecords"
        Me.txtNRecords.ReadOnly = True
        Me.txtNRecords.Size = New System.Drawing.Size(47, 20)
        Me.txtNRecords.TabIndex = 237
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 43)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(126, 13)
        Me.Label11.TabIndex = 236
        Me.Label11.Text = "Operation Method list file:"
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFind.Location = New System.Drawing.Point(821, 40)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(48, 22)
        Me.btnFind.TabIndex = 235
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtCoordOpMethodListFileName
        '
        Me.txtCoordOpMethodListFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCoordOpMethodListFileName.Location = New System.Drawing.Point(144, 41)
        Me.txtCoordOpMethodListFileName.Name = "txtCoordOpMethodListFileName"
        Me.txtCoordOpMethodListFileName.Size = New System.Drawing.Size(671, 20)
        Me.txtCoordOpMethodListFileName.TabIndex = 234
        '
        'btnGetEpsgList
        '
        Me.btnGetEpsgList.Location = New System.Drawing.Point(70, 12)
        Me.btnGetEpsgList.Name = "btnGetEpsgList"
        Me.btnGetEpsgList.Size = New System.Drawing.Size(94, 22)
        Me.btnGetEpsgList.TabIndex = 233
        Me.btnGetEpsgList.Text = "Get EPSG List"
        Me.btnGetEpsgList.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(805, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 232
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
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(12, 96)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(857, 538)
        Me.TabControl1.TabIndex = 253
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtComments)
        Me.TabPage1.Controls.Add(Me.txtReversable)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.cmbAliasNames)
        Me.TabPage1.Controls.Add(Me.btnAddAlias)
        Me.TabPage1.Controls.Add(Me.txtNewAliasName)
        Me.TabPage1.Controls.Add(Me.txtDeprecated)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtCode)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtAuthor)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtMethodName2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(849, 512)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Coordinate Operation Method"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 196)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(834, 310)
        Me.GroupBox2.TabIndex = 88
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Method Parameters"
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 19)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(822, 285)
        Me.DataGridView1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Comments:"
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComments.Location = New System.Drawing.Point(78, 121)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(765, 69)
        Me.txtComments.TabIndex = 87
        '
        'txtReversable
        '
        Me.txtReversable.Location = New System.Drawing.Point(669, 36)
        Me.txtReversable.Name = "txtReversable"
        Me.txtReversable.Size = New System.Drawing.Size(60, 20)
        Me.txtReversable.TabIndex = 85
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(553, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 13)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Reversible Operation"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "Alias names:"
        '
        'cmbAliasNames
        '
        Me.cmbAliasNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAliasNames.FormattingEnabled = True
        Me.cmbAliasNames.Location = New System.Drawing.Point(78, 67)
        Me.cmbAliasNames.Name = "cmbAliasNames"
        Me.cmbAliasNames.Size = New System.Drawing.Size(765, 21)
        Me.cmbAliasNames.TabIndex = 81
        '
        'btnAddAlias
        '
        Me.btnAddAlias.Location = New System.Drawing.Point(9, 94)
        Me.btnAddAlias.Name = "btnAddAlias"
        Me.btnAddAlias.Size = New System.Drawing.Size(63, 22)
        Me.btnAddAlias.TabIndex = 82
        Me.btnAddAlias.Text = "Add Alias"
        Me.btnAddAlias.UseVisualStyleBackColor = True
        '
        'txtNewAliasName
        '
        Me.txtNewAliasName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewAliasName.Location = New System.Drawing.Point(78, 95)
        Me.txtNewAliasName.Name = "txtNewAliasName"
        Me.txtNewAliasName.Size = New System.Drawing.Size(765, 20)
        Me.txtNewAliasName.TabIndex = 83
        '
        'txtDeprecated
        '
        Me.txtDeprecated.Location = New System.Drawing.Point(467, 36)
        Me.txtDeprecated.Name = "txtDeprecated"
        Me.txtDeprecated.Size = New System.Drawing.Size(60, 20)
        Me.txtDeprecated.TabIndex = 79
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(395, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Deprecated:"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(271, 36)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(105, 20)
        Me.txtCode.TabIndex = 77
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(215, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Code:"
        '
        'txtAuthor
        '
        Me.txtAuthor.Location = New System.Drawing.Point(78, 36)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(131, 20)
        Me.txtAuthor.TabIndex = 75
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Author:"
        '
        'txtMethodName2
        '
        Me.txtMethodName2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMethodName2.Location = New System.Drawing.Point(78, 10)
        Me.txtMethodName2.Name = "txtMethodName2"
        Me.txtMethodName2.Size = New System.Drawing.Size(765, 20)
        Me.txtMethodName2.TabIndex = 73
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Name:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.rtbFormula)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(849, 512)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Formula"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'rtbFormula
        '
        Me.rtbFormula.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbFormula.Location = New System.Drawing.Point(6, 6)
        Me.rtbFormula.Name = "rtbFormula"
        Me.rtbFormula.Size = New System.Drawing.Size(812, 500)
        Me.rtbFormula.TabIndex = 1
        Me.rtbFormula.Text = ""
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.rtbExample)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(849, 512)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Example"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'rtbExample
        '
        Me.rtbExample.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbExample.Location = New System.Drawing.Point(3, 3)
        Me.rtbExample.Name = "rtbExample"
        Me.rtbExample.Size = New System.Drawing.Size(818, 506)
        Me.rtbExample.TabIndex = 3
        Me.rtbExample.Text = ""
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.ListBox1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(849, 512)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "List"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(3, 1)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(818, 498)
        Me.ListBox1.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(52, 22)
        Me.btnSave.TabIndex = 254
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
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
        Me.btnNameFindPrev.TabIndex = 256
        Me.btnNameFindPrev.Text = "Prev"
        Me.btnNameFindPrev.UseVisualStyleBackColor = True
        '
        'frmCoordOpMethods
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(881, 646)
        Me.Controls.Add(Me.btnNameFindPrev)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnNameFindNext)
        Me.Controls.Add(Me.txtSearchText)
        Me.Controls.Add(Me.btnNameFind)
        Me.Controls.Add(Me.txtMethodName)
        Me.Controls.Add(Me.btnMoveDown)
        Me.Controls.Add(Me.btnMoveUp)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.txtRecordNo)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.txtNRecords)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.txtCoordOpMethodListFileName)
        Me.Controls.Add(Me.btnGetEpsgList)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmCoordOpMethods"
        Me.Text = "Coordinate Operation Methods"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNameFindNext As System.Windows.Forms.Button
    Friend WithEvents txtSearchText As System.Windows.Forms.TextBox
    Friend WithEvents btnNameFind As System.Windows.Forms.Button
    Friend WithEvents txtMethodName As System.Windows.Forms.TextBox
    Friend WithEvents btnMoveDown As System.Windows.Forms.Button
    Friend WithEvents btnMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents txtRecordNo As System.Windows.Forms.TextBox
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents txtNRecords As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents txtCoordOpMethodListFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnGetEpsgList As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents txtReversable As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbAliasNames As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddAlias As System.Windows.Forms.Button
    Friend WithEvents txtNewAliasName As System.Windows.Forms.TextBox
    Friend WithEvents txtDeprecated As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAuthor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMethodName2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents rtbFormula As System.Windows.Forms.RichTextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents rtbExample As System.Windows.Forms.RichTextBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnNameFindPrev As System.Windows.Forms.Button
End Class
