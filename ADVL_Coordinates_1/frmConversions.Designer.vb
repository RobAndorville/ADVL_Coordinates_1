<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConversions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConversions))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtOutputSign = New System.Windows.Forms.TextBox()
        Me.txtInputSign = New System.Windows.Forms.TextBox()
        Me.txtOutputAngle = New System.Windows.Forms.TextBox()
        Me.txtInputAngle = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOutputSeconds = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOutputMinutes = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOutputDegrees = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtInputSeconds = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtInputMinutes = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtInputDegrees = New System.Windows.Forms.TextBox()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.cmbOutput = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbInput = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(528, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 18
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
        Me.TabControl1.Location = New System.Drawing.Point(12, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(580, 367)
        Me.TabControl1.TabIndex = 19
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtOutputSign)
        Me.TabPage1.Controls.Add(Me.txtInputSign)
        Me.TabPage1.Controls.Add(Me.txtOutputAngle)
        Me.TabPage1.Controls.Add(Me.txtInputAngle)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtOutputSeconds)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtOutputMinutes)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtOutputDegrees)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtInputSeconds)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtInputMinutes)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtInputDegrees)
        Me.TabPage1.Controls.Add(Me.btnConvert)
        Me.TabPage1.Controls.Add(Me.cmbOutput)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.cmbInput)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(572, 341)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Angles"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtOutputSign
        '
        Me.txtOutputSign.Location = New System.Drawing.Point(263, 60)
        Me.txtOutputSign.Name = "txtOutputSign"
        Me.txtOutputSign.Size = New System.Drawing.Size(16, 20)
        Me.txtOutputSign.TabIndex = 92
        '
        'txtInputSign
        '
        Me.txtInputSign.Location = New System.Drawing.Point(6, 60)
        Me.txtInputSign.Name = "txtInputSign"
        Me.txtInputSign.Size = New System.Drawing.Size(16, 20)
        Me.txtInputSign.TabIndex = 91
        '
        'txtOutputAngle
        '
        Me.txtOutputAngle.Location = New System.Drawing.Point(263, 86)
        Me.txtOutputAngle.Name = "txtOutputAngle"
        Me.txtOutputAngle.Size = New System.Drawing.Size(120, 20)
        Me.txtOutputAngle.TabIndex = 90
        '
        'txtInputAngle
        '
        Me.txtInputAngle.Location = New System.Drawing.Point(6, 86)
        Me.txtInputAngle.Name = "txtInputAngle"
        Me.txtInputAngle.Size = New System.Drawing.Size(120, 20)
        Me.txtInputAngle.TabIndex = 89
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(376, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "Sec"
        '
        'txtOutputSeconds
        '
        Me.txtOutputSeconds.Location = New System.Drawing.Point(373, 60)
        Me.txtOutputSeconds.Name = "txtOutputSeconds"
        Me.txtOutputSeconds.Size = New System.Drawing.Size(120, 20)
        Me.txtOutputSeconds.TabIndex = 87
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(332, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Min"
        '
        'txtOutputMinutes
        '
        Me.txtOutputMinutes.Location = New System.Drawing.Point(329, 60)
        Me.txtOutputMinutes.Name = "txtOutputMinutes"
        Me.txtOutputMinutes.Size = New System.Drawing.Size(38, 20)
        Me.txtOutputMinutes.TabIndex = 85
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(288, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Deg"
        '
        'txtOutputDegrees
        '
        Me.txtOutputDegrees.Location = New System.Drawing.Point(285, 60)
        Me.txtOutputDegrees.Name = "txtOutputDegrees"
        Me.txtOutputDegrees.Size = New System.Drawing.Size(39, 20)
        Me.txtOutputDegrees.TabIndex = 83
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(118, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 81
        Me.Label9.Text = "Sec"
        '
        'txtInputSeconds
        '
        Me.txtInputSeconds.Location = New System.Drawing.Point(115, 60)
        Me.txtInputSeconds.Name = "txtInputSeconds"
        Me.txtInputSeconds.Size = New System.Drawing.Size(120, 20)
        Me.txtInputSeconds.TabIndex = 80
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(74, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Min"
        '
        'txtInputMinutes
        '
        Me.txtInputMinutes.Location = New System.Drawing.Point(71, 60)
        Me.txtInputMinutes.Name = "txtInputMinutes"
        Me.txtInputMinutes.Size = New System.Drawing.Size(38, 20)
        Me.txtInputMinutes.TabIndex = 78
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Deg"
        '
        'txtInputDegrees
        '
        Me.txtInputDegrees.Location = New System.Drawing.Point(27, 60)
        Me.txtInputDegrees.Name = "txtInputDegrees"
        Me.txtInputDegrees.Size = New System.Drawing.Size(39, 20)
        Me.txtInputDegrees.TabIndex = 76
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(174, 19)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(68, 22)
        Me.btnConvert.TabIndex = 4
        Me.btnConvert.Text = "Convert"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'cmbOutput
        '
        Me.cmbOutput.FormattingEnabled = True
        Me.cmbOutput.Location = New System.Drawing.Point(263, 19)
        Me.cmbOutput.Name = "cmbOutput"
        Me.cmbOutput.Size = New System.Drawing.Size(159, 21)
        Me.cmbOutput.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(260, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Output"
        '
        'cmbInput
        '
        Me.cmbInput.FormattingEnabled = True
        Me.cmbInput.Location = New System.Drawing.Point(9, 19)
        Me.cmbInput.Name = "cmbInput"
        Me.cmbInput.Size = New System.Drawing.Size(159, 21)
        Me.cmbInput.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Input"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(572, 341)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Projections"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'frmConversions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 419)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConversions"
        Me.Text = "Conversions"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtOutputSign As System.Windows.Forms.TextBox
    Friend WithEvents txtInputSign As System.Windows.Forms.TextBox
    Friend WithEvents txtOutputAngle As System.Windows.Forms.TextBox
    Friend WithEvents txtInputAngle As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOutputSeconds As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOutputMinutes As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtOutputDegrees As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtInputSeconds As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtInputMinutes As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtInputDegrees As System.Windows.Forms.TextBox
    Friend WithEvents btnConvert As System.Windows.Forms.Button
    Friend WithEvents cmbOutput As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbInput As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
End Class
