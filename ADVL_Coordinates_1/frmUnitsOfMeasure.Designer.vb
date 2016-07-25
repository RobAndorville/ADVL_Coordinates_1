<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUnitsOfMeasure
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnGetEpsgList = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtUOMListFileName = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtDeprecated = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.txtUomCode = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btnAddAlias = New System.Windows.Forms.Button()
        Me.txtNewAliasName = New System.Windows.Forms.TextBox()
        Me.btnDelAlias = New System.Windows.Forms.Button()
        Me.cmbAliasNames = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFactorC = New System.Windows.Forms.TextBox()
        Me.txtFactorB = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtStandardUOM = New System.Windows.Forms.TextBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUnitName = New System.Windows.Forms.TextBox()
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
        Me.btnNameFindNext.TabIndex = 199
        Me.btnNameFindNext.Text = "Next"
        Me.btnNameFindNext.UseVisualStyleBackColor = True
        '
        'txtSearchText
        '
        Me.txtSearchText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchText.Location = New System.Drawing.Point(326, 13)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(412, 20)
        Me.txtSearchText.TabIndex = 198
        '
        'btnNameFind
        '
        Me.btnNameFind.Location = New System.Drawing.Point(170, 12)
        Me.btnNameFind.Name = "btnNameFind"
        Me.btnNameFind.Size = New System.Drawing.Size(58, 22)
        Me.btnNameFind.TabIndex = 197
        Me.btnNameFind.Text = "Find First"
        Me.btnNameFind.UseVisualStyleBackColor = True
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Location = New System.Drawing.Point(523, 66)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(74, 22)
        Me.btnMoveDown.TabIndex = 196
        Me.btnMoveDown.Text = "Move Dwn"
        Me.btnMoveDown.UseVisualStyleBackColor = True
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Location = New System.Drawing.Point(456, 66)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(61, 22)
        Me.btnMoveUp.TabIndex = 195
        Me.btnMoveUp.Text = "Move Up"
        Me.btnMoveUp.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Location = New System.Drawing.Point(411, 66)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(39, 22)
        Me.btnDel.TabIndex = 194
        Me.btnDel.Text = "Del"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(366, 66)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(39, 22)
        Me.btnAdd.TabIndex = 193
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtRecordNo
        '
        Me.txtRecordNo.Location = New System.Drawing.Point(60, 67)
        Me.txtRecordNo.Name = "txtRecordNo"
        Me.txtRecordNo.Size = New System.Drawing.Size(45, 20)
        Me.txtRecordNo.TabIndex = 192
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 191
        Me.Label2.Text = "Record"
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(321, 66)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(39, 22)
        Me.btnLast.TabIndex = 190
        Me.btnLast.Text = "Last"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(276, 66)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(39, 22)
        Me.btnNext.TabIndex = 189
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(231, 66)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(39, 22)
        Me.btnPrev.TabIndex = 188
        Me.btnPrev.Text = "Prev"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(186, 66)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(39, 22)
        Me.btnFirst.TabIndex = 187
        Me.btnFirst.Text = "First"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(111, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 186
        Me.Label1.Text = "of"
        '
        'txtNRecords
        '
        Me.txtNRecords.Location = New System.Drawing.Point(132, 67)
        Me.txtNRecords.Name = "txtNRecords"
        Me.txtNRecords.ReadOnly = True
        Me.txtNRecords.Size = New System.Drawing.Size(47, 20)
        Me.txtNRecords.TabIndex = 185
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 13)
        Me.Label11.TabIndex = 184
        Me.Label11.Text = "Unit of Measure list file:"
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
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(52, 22)
        Me.btnSave.TabIndex = 181
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFind.Location = New System.Drawing.Point(760, 40)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(48, 22)
        Me.btnFind.TabIndex = 180
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtUOMListFileName
        '
        Me.txtUOMListFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUOMListFileName.Location = New System.Drawing.Point(134, 41)
        Me.txtUOMListFileName.Name = "txtUOMListFileName"
        Me.txtUOMListFileName.Size = New System.Drawing.Size(620, 20)
        Me.txtUOMListFileName.TabIndex = 179
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(745, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 178
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
        Me.TabControl1.Location = New System.Drawing.Point(12, 94)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(796, 347)
        Me.TabControl1.TabIndex = 200
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtDeprecated)
        Me.TabPage1.Controls.Add(Me.Label29)
        Me.TabPage1.Controls.Add(Me.txtAuthor)
        Me.TabPage1.Controls.Add(Me.Label27)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.btnApply)
        Me.TabPage1.Controls.Add(Me.txtUomCode)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.btnAddAlias)
        Me.TabPage1.Controls.Add(Me.txtNewAliasName)
        Me.TabPage1.Controls.Add(Me.btnDelAlias)
        Me.TabPage1.Controls.Add(Me.cmbAliasNames)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtFactorC)
        Me.TabPage1.Controls.Add(Me.txtFactorB)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtStandardUOM)
        Me.TabPage1.Controls.Add(Me.txtComments)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.cmbType)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtUnitName)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(788, 321)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Units"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtDeprecated
        '
        Me.txtDeprecated.Location = New System.Drawing.Point(564, 49)
        Me.txtDeprecated.Name = "txtDeprecated"
        Me.txtDeprecated.Size = New System.Drawing.Size(60, 20)
        Me.txtDeprecated.TabIndex = 181
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(492, 52)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(66, 13)
        Me.Label29.TabIndex = 180
        Me.Label29.Text = "Deprecated:"
        '
        'txtAuthor
        '
        Me.txtAuthor.Location = New System.Drawing.Point(91, 49)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(253, 20)
        Me.txtAuthor.TabIndex = 179
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 52)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(41, 13)
        Me.Label27.TabIndex = 178
        Me.Label27.Text = "Author:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 263)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(290, 13)
        Me.Label10.TabIndex = 172
        Me.Label10.Text = "Value in standard units = Current value * Factor B / Factor C"
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Location = New System.Drawing.Point(729, 140)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(53, 22)
        Me.btnApply.TabIndex = 171
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'txtUomCode
        '
        Me.txtUomCode.Location = New System.Drawing.Point(406, 49)
        Me.txtUomCode.Name = "txtUomCode"
        Me.txtUomCode.Size = New System.Drawing.Size(68, 20)
        Me.txtUomCode.TabIndex = 170
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(365, 52)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(35, 13)
        Me.Label26.TabIndex = 169
        Me.Label26.Text = "Code:"
        '
        'btnAddAlias
        '
        Me.btnAddAlias.Location = New System.Drawing.Point(8, 110)
        Me.btnAddAlias.Name = "btnAddAlias"
        Me.btnAddAlias.Size = New System.Drawing.Size(77, 22)
        Me.btnAddAlias.TabIndex = 168
        Me.btnAddAlias.Text = "Add Alias"
        Me.btnAddAlias.UseVisualStyleBackColor = True
        '
        'txtNewAliasName
        '
        Me.txtNewAliasName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewAliasName.Location = New System.Drawing.Point(91, 111)
        Me.txtNewAliasName.Name = "txtNewAliasName"
        Me.txtNewAliasName.Size = New System.Drawing.Size(691, 20)
        Me.txtNewAliasName.TabIndex = 167
        '
        'btnDelAlias
        '
        Me.btnDelAlias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelAlias.Location = New System.Drawing.Point(743, 82)
        Me.btnDelAlias.Name = "btnDelAlias"
        Me.btnDelAlias.Size = New System.Drawing.Size(39, 22)
        Me.btnDelAlias.TabIndex = 166
        Me.btnDelAlias.Text = "Del"
        Me.btnDelAlias.UseVisualStyleBackColor = True
        '
        'cmbAliasNames
        '
        Me.cmbAliasNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAliasNames.FormattingEnabled = True
        Me.cmbAliasNames.Location = New System.Drawing.Point(91, 84)
        Me.cmbAliasNames.Name = "cmbAliasNames"
        Me.cmbAliasNames.Size = New System.Drawing.Size(646, 21)
        Me.cmbAliasNames.TabIndex = 165
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 164
        Me.Label9.Text = "Alias names:"
        '
        'txtFactorC
        '
        Me.txtFactorC.Location = New System.Drawing.Point(434, 235)
        Me.txtFactorC.Name = "txtFactorC"
        Me.txtFactorC.Size = New System.Drawing.Size(169, 20)
        Me.txtFactorC.TabIndex = 163
        '
        'txtFactorB
        '
        Me.txtFactorB.Location = New System.Drawing.Point(140, 235)
        Me.txtFactorB.Name = "txtFactorB"
        Me.txtFactorB.Size = New System.Drawing.Size(169, 20)
        Me.txtFactorB.TabIndex = 162
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(325, 238)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 13)
        Me.Label8.TabIndex = 161
        Me.Label8.Text = "Conversion factor C:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 238)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 13)
        Me.Label7.TabIndex = 160
        Me.Label7.Text = "Conversion factor B:"
        '
        'txtStandardUOM
        '
        Me.txtStandardUOM.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStandardUOM.Location = New System.Drawing.Point(140, 209)
        Me.txtStandardUOM.Name = "txtStandardUOM"
        Me.txtStandardUOM.Size = New System.Drawing.Size(642, 20)
        Me.txtStandardUOM.TabIndex = 159
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComments.Location = New System.Drawing.Point(91, 168)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(691, 35)
        Me.txtComments.TabIndex = 158
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 212)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 13)
        Me.Label6.TabIndex = 157
        Me.Label6.Text = "Standard unit of measure:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 156
        Me.Label5.Text = "Comments:"
        '
        'cmbType
        '
        Me.cmbType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(91, 141)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(632, 21)
        Me.cmbType.TabIndex = 155
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 154
        Me.Label4.Text = "Type:"
        '
        'txtUnitName
        '
        Me.txtUnitName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUnitName.Location = New System.Drawing.Point(91, 23)
        Me.txtUnitName.Name = "txtUnitName"
        Me.txtUnitName.Size = New System.Drawing.Size(691, 20)
        Me.txtUnitName.TabIndex = 149
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 148
        Me.Label3.Text = "Unit name:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(788, 321)
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
        Me.ListBox1.Location = New System.Drawing.Point(6, 9)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(776, 303)
        Me.ListBox1.TabIndex = 2
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
        Me.btnNameFindPrev.TabIndex = 266
        Me.btnNameFindPrev.Text = "Prev"
        Me.btnNameFindPrev.UseVisualStyleBackColor = True
        '
        'frmUnitsOfMeasure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 453)
        Me.Controls.Add(Me.btnNameFindPrev)
        Me.Controls.Add(Me.TabControl1)
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
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnGetEpsgList)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.txtUOMListFileName)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmUnitsOfMeasure"
        Me.Text = "Unit Of Measure"
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnGetEpsgList As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents txtUOMListFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtDeprecated As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtAuthor As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents txtUomCode As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btnAddAlias As System.Windows.Forms.Button
    Friend WithEvents txtNewAliasName As System.Windows.Forms.TextBox
    Friend WithEvents btnDelAlias As System.Windows.Forms.Button
    Friend WithEvents cmbAliasNames As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFactorC As System.Windows.Forms.TextBox
    Friend WithEvents txtFactorB As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtStandardUOM As System.Windows.Forms.TextBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUnitName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnNameFindPrev As System.Windows.Forms.Button
End Class
