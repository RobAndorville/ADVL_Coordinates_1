<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjectionCalcs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProjectionCalcs))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnShowDataSettings = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbDirection6 = New System.Windows.Forms.ComboBox()
        Me.cmbDirection5 = New System.Windows.Forms.ComboBox()
        Me.cmbDirection4 = New System.Windows.Forms.ComboBox()
        Me.cmbDirection3 = New System.Windows.Forms.ComboBox()
        Me.cmbDirection2 = New System.Windows.Forms.ComboBox()
        Me.cmbDirection1 = New System.Windows.Forms.ComboBox()
        Me.txtDescr6 = New System.Windows.Forms.TextBox()
        Me.txtDescr5 = New System.Windows.Forms.TextBox()
        Me.txtDescr4 = New System.Windows.Forms.TextBox()
        Me.txtDescr3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtGeographicCRS2 = New System.Windows.Forms.TextBox()
        Me.cmbUnits6 = New System.Windows.Forms.ComboBox()
        Me.cmbUnits5 = New System.Windows.Forms.ComboBox()
        Me.cmbUnits4 = New System.Windows.Forms.ComboBox()
        Me.cmbUnits3 = New System.Windows.Forms.ComboBox()
        Me.cmbUnits2 = New System.Windows.Forms.ComboBox()
        Me.cmbUnits1 = New System.Windows.Forms.ComboBox()
        Me.cmbDataType6 = New System.Windows.Forms.ComboBox()
        Me.cmbDataType5 = New System.Windows.Forms.ComboBox()
        Me.cmbDataType4 = New System.Windows.Forms.ComboBox()
        Me.cmbDataType3 = New System.Windows.Forms.ComboBox()
        Me.cmbDataType2 = New System.Windows.Forms.ComboBox()
        Me.cmbDataType1 = New System.Windows.Forms.ComboBox()
        Me.txtDescr2 = New System.Windows.Forms.TextBox()
        Me.txtDescr1 = New System.Windows.Forms.TextBox()
        Me.txtProjectionMethod = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbProjectedCRS = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(892, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnShowDataSettings
        '
        Me.btnShowDataSettings.Location = New System.Drawing.Point(176, 12)
        Me.btnShowDataSettings.Name = "btnShowDataSettings"
        Me.btnShowDataSettings.Size = New System.Drawing.Size(128, 22)
        Me.btnShowDataSettings.TabIndex = 78
        Me.btnShowDataSettings.Text = "Show Data Settings"
        Me.btnShowDataSettings.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Direction:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 76
        Me.Label5.Text = "Units:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Data Type:"
        '
        'cmbDirection6
        '
        Me.cmbDirection6.FormattingEnabled = True
        Me.cmbDirection6.Location = New System.Drawing.Point(770, 133)
        Me.cmbDirection6.Name = "cmbDirection6"
        Me.cmbDirection6.Size = New System.Drawing.Size(133, 21)
        Me.cmbDirection6.TabIndex = 74
        '
        'cmbDirection5
        '
        Me.cmbDirection5.FormattingEnabled = True
        Me.cmbDirection5.Location = New System.Drawing.Point(631, 133)
        Me.cmbDirection5.Name = "cmbDirection5"
        Me.cmbDirection5.Size = New System.Drawing.Size(133, 21)
        Me.cmbDirection5.TabIndex = 73
        '
        'cmbDirection4
        '
        Me.cmbDirection4.FormattingEnabled = True
        Me.cmbDirection4.Location = New System.Drawing.Point(492, 133)
        Me.cmbDirection4.Name = "cmbDirection4"
        Me.cmbDirection4.Size = New System.Drawing.Size(133, 21)
        Me.cmbDirection4.TabIndex = 72
        '
        'cmbDirection3
        '
        Me.cmbDirection3.FormattingEnabled = True
        Me.cmbDirection3.Location = New System.Drawing.Point(353, 133)
        Me.cmbDirection3.Name = "cmbDirection3"
        Me.cmbDirection3.Size = New System.Drawing.Size(133, 21)
        Me.cmbDirection3.TabIndex = 71
        '
        'cmbDirection2
        '
        Me.cmbDirection2.FormattingEnabled = True
        Me.cmbDirection2.Location = New System.Drawing.Point(214, 133)
        Me.cmbDirection2.Name = "cmbDirection2"
        Me.cmbDirection2.Size = New System.Drawing.Size(133, 21)
        Me.cmbDirection2.TabIndex = 70
        '
        'cmbDirection1
        '
        Me.cmbDirection1.FormattingEnabled = True
        Me.cmbDirection1.Location = New System.Drawing.Point(75, 133)
        Me.cmbDirection1.Name = "cmbDirection1"
        Me.cmbDirection1.Size = New System.Drawing.Size(133, 21)
        Me.cmbDirection1.TabIndex = 69
        '
        'txtDescr6
        '
        Me.txtDescr6.Location = New System.Drawing.Point(770, 153)
        Me.txtDescr6.Name = "txtDescr6"
        Me.txtDescr6.Size = New System.Drawing.Size(133, 20)
        Me.txtDescr6.TabIndex = 68
        '
        'txtDescr5
        '
        Me.txtDescr5.Location = New System.Drawing.Point(631, 153)
        Me.txtDescr5.Name = "txtDescr5"
        Me.txtDescr5.Size = New System.Drawing.Size(133, 20)
        Me.txtDescr5.TabIndex = 67
        '
        'txtDescr4
        '
        Me.txtDescr4.Location = New System.Drawing.Point(492, 153)
        Me.txtDescr4.Name = "txtDescr4"
        Me.txtDescr4.Size = New System.Drawing.Size(133, 20)
        Me.txtDescr4.TabIndex = 66
        '
        'txtDescr3
        '
        Me.txtDescr3.Location = New System.Drawing.Point(353, 153)
        Me.txtDescr3.Name = "txtDescr3"
        Me.txtDescr3.Size = New System.Drawing.Size(133, 20)
        Me.txtDescr3.TabIndex = 65
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(510, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Geographic CRS:"
        '
        'txtGeographicCRS2
        '
        Me.txtGeographicCRS2.Location = New System.Drawing.Point(606, 68)
        Me.txtGeographicCRS2.Name = "txtGeographicCRS2"
        Me.txtGeographicCRS2.Size = New System.Drawing.Size(297, 20)
        Me.txtGeographicCRS2.TabIndex = 62
        '
        'cmbUnits6
        '
        Me.cmbUnits6.FormattingEnabled = True
        Me.cmbUnits6.Location = New System.Drawing.Point(770, 113)
        Me.cmbUnits6.Name = "cmbUnits6"
        Me.cmbUnits6.Size = New System.Drawing.Size(133, 21)
        Me.cmbUnits6.TabIndex = 61
        '
        'cmbUnits5
        '
        Me.cmbUnits5.FormattingEnabled = True
        Me.cmbUnits5.Location = New System.Drawing.Point(631, 113)
        Me.cmbUnits5.Name = "cmbUnits5"
        Me.cmbUnits5.Size = New System.Drawing.Size(133, 21)
        Me.cmbUnits5.TabIndex = 60
        '
        'cmbUnits4
        '
        Me.cmbUnits4.FormattingEnabled = True
        Me.cmbUnits4.Location = New System.Drawing.Point(492, 113)
        Me.cmbUnits4.Name = "cmbUnits4"
        Me.cmbUnits4.Size = New System.Drawing.Size(133, 21)
        Me.cmbUnits4.TabIndex = 59
        '
        'cmbUnits3
        '
        Me.cmbUnits3.FormattingEnabled = True
        Me.cmbUnits3.Location = New System.Drawing.Point(353, 113)
        Me.cmbUnits3.Name = "cmbUnits3"
        Me.cmbUnits3.Size = New System.Drawing.Size(133, 21)
        Me.cmbUnits3.TabIndex = 58
        '
        'cmbUnits2
        '
        Me.cmbUnits2.FormattingEnabled = True
        Me.cmbUnits2.Location = New System.Drawing.Point(214, 113)
        Me.cmbUnits2.Name = "cmbUnits2"
        Me.cmbUnits2.Size = New System.Drawing.Size(133, 21)
        Me.cmbUnits2.TabIndex = 57
        '
        'cmbUnits1
        '
        Me.cmbUnits1.FormattingEnabled = True
        Me.cmbUnits1.Location = New System.Drawing.Point(75, 113)
        Me.cmbUnits1.Name = "cmbUnits1"
        Me.cmbUnits1.Size = New System.Drawing.Size(133, 21)
        Me.cmbUnits1.TabIndex = 56
        '
        'cmbDataType6
        '
        Me.cmbDataType6.FormattingEnabled = True
        Me.cmbDataType6.Location = New System.Drawing.Point(770, 93)
        Me.cmbDataType6.Name = "cmbDataType6"
        Me.cmbDataType6.Size = New System.Drawing.Size(133, 21)
        Me.cmbDataType6.TabIndex = 55
        '
        'cmbDataType5
        '
        Me.cmbDataType5.FormattingEnabled = True
        Me.cmbDataType5.Location = New System.Drawing.Point(631, 93)
        Me.cmbDataType5.Name = "cmbDataType5"
        Me.cmbDataType5.Size = New System.Drawing.Size(133, 21)
        Me.cmbDataType5.TabIndex = 54
        '
        'cmbDataType4
        '
        Me.cmbDataType4.FormattingEnabled = True
        Me.cmbDataType4.Location = New System.Drawing.Point(492, 93)
        Me.cmbDataType4.Name = "cmbDataType4"
        Me.cmbDataType4.Size = New System.Drawing.Size(133, 21)
        Me.cmbDataType4.TabIndex = 53
        '
        'cmbDataType3
        '
        Me.cmbDataType3.FormattingEnabled = True
        Me.cmbDataType3.Location = New System.Drawing.Point(353, 93)
        Me.cmbDataType3.Name = "cmbDataType3"
        Me.cmbDataType3.Size = New System.Drawing.Size(133, 21)
        Me.cmbDataType3.TabIndex = 52
        '
        'cmbDataType2
        '
        Me.cmbDataType2.FormattingEnabled = True
        Me.cmbDataType2.Location = New System.Drawing.Point(214, 93)
        Me.cmbDataType2.Name = "cmbDataType2"
        Me.cmbDataType2.Size = New System.Drawing.Size(133, 21)
        Me.cmbDataType2.TabIndex = 51
        '
        'cmbDataType1
        '
        Me.cmbDataType1.FormattingEnabled = True
        Me.cmbDataType1.Location = New System.Drawing.Point(75, 93)
        Me.cmbDataType1.Name = "cmbDataType1"
        Me.cmbDataType1.Size = New System.Drawing.Size(133, 21)
        Me.cmbDataType1.TabIndex = 50
        '
        'txtDescr2
        '
        Me.txtDescr2.Location = New System.Drawing.Point(214, 153)
        Me.txtDescr2.Name = "txtDescr2"
        Me.txtDescr2.Size = New System.Drawing.Size(133, 20)
        Me.txtDescr2.TabIndex = 49
        '
        'txtDescr1
        '
        Me.txtDescr1.Location = New System.Drawing.Point(75, 153)
        Me.txtDescr1.Name = "txtDescr1"
        Me.txtDescr1.Size = New System.Drawing.Size(133, 20)
        Me.txtDescr1.TabIndex = 48
        '
        'txtProjectionMethod
        '
        Me.txtProjectionMethod.Location = New System.Drawing.Point(217, 68)
        Me.txtProjectionMethod.Name = "txtProjectionMethod"
        Me.txtProjectionMethod.Size = New System.Drawing.Size(277, 20)
        Me.txtProjectionMethod.TabIndex = 47
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(115, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Projection Method:"
        '
        'cmbProjectedCRS
        '
        Me.cmbProjectedCRS.FormattingEnabled = True
        Me.cmbProjectedCRS.Location = New System.Drawing.Point(217, 40)
        Me.cmbProjectedCRS.Name = "cmbProjectedCRS"
        Me.cmbProjectedCRS.Size = New System.Drawing.Size(686, 21)
        Me.cmbProjectedCRS.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Projected Coordinate Reference System:"
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 179)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(944, 428)
        Me.DataGridView1.TabIndex = 79
        '
        'frmProjectionCalcs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 619)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnShowDataSettings)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbDirection6)
        Me.Controls.Add(Me.cmbDirection5)
        Me.Controls.Add(Me.cmbDirection4)
        Me.Controls.Add(Me.cmbDirection3)
        Me.Controls.Add(Me.cmbDirection2)
        Me.Controls.Add(Me.cmbDirection1)
        Me.Controls.Add(Me.txtDescr6)
        Me.Controls.Add(Me.txtDescr5)
        Me.Controls.Add(Me.txtDescr4)
        Me.Controls.Add(Me.txtDescr3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtGeographicCRS2)
        Me.Controls.Add(Me.cmbUnits6)
        Me.Controls.Add(Me.cmbUnits5)
        Me.Controls.Add(Me.cmbUnits4)
        Me.Controls.Add(Me.cmbUnits3)
        Me.Controls.Add(Me.cmbUnits2)
        Me.Controls.Add(Me.cmbUnits1)
        Me.Controls.Add(Me.cmbDataType6)
        Me.Controls.Add(Me.cmbDataType5)
        Me.Controls.Add(Me.cmbDataType4)
        Me.Controls.Add(Me.cmbDataType3)
        Me.Controls.Add(Me.cmbDataType2)
        Me.Controls.Add(Me.cmbDataType1)
        Me.Controls.Add(Me.txtDescr2)
        Me.Controls.Add(Me.txtDescr1)
        Me.Controls.Add(Me.txtProjectionMethod)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbProjectedCRS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProjectionCalcs"
        Me.Text = "Projection Calculations"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnShowDataSettings As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbDirection6 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDirection5 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDirection4 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDirection3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDirection2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDirection1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescr6 As System.Windows.Forms.TextBox
    Friend WithEvents txtDescr5 As System.Windows.Forms.TextBox
    Friend WithEvents txtDescr4 As System.Windows.Forms.TextBox
    Friend WithEvents txtDescr3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtGeographicCRS2 As System.Windows.Forms.TextBox
    Friend WithEvents cmbUnits6 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUnits5 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUnits4 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUnits3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUnits2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUnits1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDataType6 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDataType5 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDataType4 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDataType3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDataType2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDataType1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescr2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDescr1 As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectionMethod As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbProjectedCRS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
