<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHtmlDisplay
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
        Dim XmlHtmDisplaySettings2 As ADVL_Utilities_Library_1.XmlHtmDisplaySettings = New ADVL_Utilities_Library_1.XmlHtmDisplaySettings()
        Dim TextSettings16 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings17 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings18 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings19 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings20 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings21 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings22 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings23 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings24 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings25 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings26 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings27 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings28 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings29 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings30 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.btnUpdateFormatting = New System.Windows.Forms.Button()
        Me.XmlHtmDisplay1 = New ADVL_Utilities_Library_1.XmlHtmDisplay(Me.components)
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtInfo
        '
        Me.txtInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInfo.Location = New System.Drawing.Point(565, 13)
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ReadOnly = True
        Me.txtInfo.Size = New System.Drawing.Size(164, 20)
        Me.txtInfo.TabIndex = 278
        '
        'btnUpdateFormatting
        '
        Me.btnUpdateFormatting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateFormatting.Location = New System.Drawing.Point(735, 12)
        Me.btnUpdateFormatting.Name = "btnUpdateFormatting"
        Me.btnUpdateFormatting.Size = New System.Drawing.Size(51, 22)
        Me.btnUpdateFormatting.TabIndex = 277
        Me.btnUpdateFormatting.Text = "Format"
        Me.btnUpdateFormatting.UseVisualStyleBackColor = True
        '
        'XmlHtmDisplay1
        '
        Me.XmlHtmDisplay1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XmlHtmDisplay1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.XmlHtmDisplay1.Location = New System.Drawing.Point(12, 40)
        Me.XmlHtmDisplay1.Name = "XmlHtmDisplay1"
        TextSettings16.Bold = False
        TextSettings16.Color = System.Drawing.Color.Black
        TextSettings16.ColorIndex = 7
        TextSettings16.FontIndex = 7
        TextSettings16.FontName = "Arial"
        TextSettings16.HalfPointSize = 20
        TextSettings16.Italic = False
        TextSettings16.PointSize = 10.0!
        XmlHtmDisplaySettings2.DefaultText = TextSettings16
        TextSettings17.Bold = False
        TextSettings17.Color = System.Drawing.Color.Blue
        TextSettings17.ColorIndex = 4
        TextSettings17.FontIndex = 1
        TextSettings17.FontName = "Arial"
        TextSettings17.HalfPointSize = 20
        TextSettings17.Italic = False
        TextSettings17.PointSize = 10.0!
        XmlHtmDisplaySettings2.HAttribute = TextSettings17
        TextSettings18.Bold = False
        TextSettings18.Color = System.Drawing.Color.Gray
        TextSettings18.ColorIndex = 6
        TextSettings18.FontIndex = 1
        TextSettings18.FontName = "Arial"
        TextSettings18.HalfPointSize = 20
        TextSettings18.Italic = False
        TextSettings18.PointSize = 10.0!
        XmlHtmDisplaySettings2.HChar = TextSettings18
        TextSettings19.Bold = False
        TextSettings19.Color = System.Drawing.Color.Gray
        TextSettings19.ColorIndex = 6
        TextSettings19.FontIndex = 1
        TextSettings19.FontName = "Arial"
        TextSettings19.HalfPointSize = 20
        TextSettings19.Italic = False
        TextSettings19.PointSize = 10.0!
        XmlHtmDisplaySettings2.HComment = TextSettings19
        TextSettings20.Bold = False
        TextSettings20.Color = System.Drawing.Color.DarkRed
        TextSettings20.ColorIndex = 2
        TextSettings20.FontIndex = 1
        TextSettings20.FontName = "Arial"
        TextSettings20.HalfPointSize = 20
        TextSettings20.Italic = False
        TextSettings20.PointSize = 10.0!
        XmlHtmDisplaySettings2.HElement = TextSettings20
        TextSettings21.Bold = False
        TextSettings21.Color = System.Drawing.Color.Black
        TextSettings21.ColorIndex = 5
        TextSettings21.FontIndex = 1
        TextSettings21.FontName = "Arial"
        TextSettings21.HalfPointSize = 20
        TextSettings21.Italic = False
        TextSettings21.PointSize = 10.0!
        XmlHtmDisplaySettings2.HStyle = TextSettings21
        TextSettings22.Bold = False
        TextSettings22.Color = System.Drawing.Color.Black
        TextSettings22.ColorIndex = 7
        TextSettings22.FontIndex = 7
        TextSettings22.FontName = "Arial"
        TextSettings22.HalfPointSize = 20
        TextSettings22.Italic = False
        TextSettings22.PointSize = 10.0!
        XmlHtmDisplaySettings2.HText = TextSettings22
        TextSettings23.Bold = False
        TextSettings23.Color = System.Drawing.Color.Black
        TextSettings23.ColorIndex = 5
        TextSettings23.FontIndex = 1
        TextSettings23.FontName = "Arial"
        TextSettings23.HalfPointSize = 20
        TextSettings23.Italic = False
        TextSettings23.PointSize = 10.0!
        XmlHtmDisplaySettings2.HValue = TextSettings23
        TextSettings24.Bold = False
        TextSettings24.Color = System.Drawing.Color.Black
        TextSettings24.ColorIndex = 7
        TextSettings24.FontIndex = 7
        TextSettings24.FontName = "Arial"
        TextSettings24.HalfPointSize = 20
        TextSettings24.Italic = False
        TextSettings24.PointSize = 10.0!
        XmlHtmDisplaySettings2.PlainText = TextSettings24
        TextSettings25.Bold = False
        TextSettings25.Color = System.Drawing.Color.Red
        TextSettings25.ColorIndex = 3
        TextSettings25.FontIndex = 1
        TextSettings25.FontName = "Arial"
        TextSettings25.HalfPointSize = 20
        TextSettings25.Italic = False
        TextSettings25.PointSize = 10.0!
        XmlHtmDisplaySettings2.XAttributeKey = TextSettings25
        TextSettings26.Bold = False
        TextSettings26.Color = System.Drawing.Color.Blue
        TextSettings26.ColorIndex = 4
        TextSettings26.FontIndex = 1
        TextSettings26.FontName = "Arial"
        TextSettings26.HalfPointSize = 20
        TextSettings26.Italic = False
        TextSettings26.PointSize = 10.0!
        XmlHtmDisplaySettings2.XAttributeValue = TextSettings26
        TextSettings27.Bold = False
        TextSettings27.Color = System.Drawing.Color.Gray
        TextSettings27.ColorIndex = 6
        TextSettings27.FontIndex = 1
        TextSettings27.FontName = "Arial"
        TextSettings27.HalfPointSize = 20
        TextSettings27.Italic = False
        TextSettings27.PointSize = 10.0!
        XmlHtmDisplaySettings2.XComment = TextSettings27
        TextSettings28.Bold = False
        TextSettings28.Color = System.Drawing.Color.DarkRed
        TextSettings28.ColorIndex = 2
        TextSettings28.FontIndex = 1
        TextSettings28.FontName = "Arial"
        TextSettings28.HalfPointSize = 20
        TextSettings28.Italic = False
        TextSettings28.PointSize = 10.0!
        XmlHtmDisplaySettings2.XElement = TextSettings28
        XmlHtmDisplaySettings2.XIndentSpaces = 4
        XmlHtmDisplaySettings2.XmlLargeFileSizeLimit = 1000000
        TextSettings29.Bold = False
        TextSettings29.Color = System.Drawing.Color.Blue
        TextSettings29.ColorIndex = 1
        TextSettings29.FontIndex = 1
        TextSettings29.FontName = "Arial"
        TextSettings29.HalfPointSize = 20
        TextSettings29.Italic = False
        TextSettings29.PointSize = 10.0!
        XmlHtmDisplaySettings2.XTag = TextSettings29
        TextSettings30.Bold = False
        TextSettings30.Color = System.Drawing.Color.Black
        TextSettings30.ColorIndex = 5
        TextSettings30.FontIndex = 1
        TextSettings30.FontName = "Arial"
        TextSettings30.HalfPointSize = 20
        TextSettings30.Italic = False
        TextSettings30.PointSize = 10.0!
        XmlHtmDisplaySettings2.XValue = TextSettings30
        Me.XmlHtmDisplay1.Settings = XmlHtmDisplaySettings2
        Me.XmlHtmDisplay1.Size = New System.Drawing.Size(828, 478)
        Me.XmlHtmDisplay1.TabIndex = 276
        Me.XmlHtmDisplay1.Text = ""
        '
        'txtFileName
        '
        Me.txtFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileName.Location = New System.Drawing.Point(166, 13)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(393, 20)
        Me.txtFileName.TabIndex = 275
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(104, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 13)
        Me.Label14.TabIndex = 274
        Me.Label14.Text = "FIle name:"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(12, 12)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(86, 22)
        Me.btnUpdate.TabIndex = 273
        Me.btnUpdate.Text = "Update Page"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(792, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(48, 22)
        Me.btnExit.TabIndex = 272
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmHtmlDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 530)
        Me.Controls.Add(Me.txtInfo)
        Me.Controls.Add(Me.btnUpdateFormatting)
        Me.Controls.Add(Me.XmlHtmDisplay1)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmHtmlDisplay"
        Me.Text = "HTML Display"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtInfo As TextBox
    Friend WithEvents btnUpdateFormatting As Button
    Friend WithEvents XmlHtmDisplay1 As ADVL_Utilities_Library_1.XmlHtmDisplay
    Friend WithEvents txtFileName As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnExit As Button
End Class
