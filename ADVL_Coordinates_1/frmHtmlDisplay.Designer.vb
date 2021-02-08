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
        Dim XmlHtmDisplaySettings1 As ADVL_Utilities_Library_1.XmlHtmDisplaySettings = New ADVL_Utilities_Library_1.XmlHtmDisplaySettings()
        Dim TextSettings1 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings2 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings3 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings4 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings5 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings6 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings7 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings8 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings9 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings10 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings11 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings12 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings13 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings14 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Dim TextSettings15 As ADVL_Utilities_Library_1.TextSettings = New ADVL_Utilities_Library_1.TextSettings()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.btnUpdateFormatting = New System.Windows.Forms.Button()
        Me.XmlHtmDisplay1 = New ADVL_Utilities_Library_1.XmlHtmDisplay(Me.components)
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSaveAs = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtInfo
        '
        Me.txtInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInfo.Location = New System.Drawing.Point(622, 12)
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ReadOnly = True
        Me.txtInfo.Size = New System.Drawing.Size(164, 20)
        Me.txtInfo.TabIndex = 278
        '
        'btnUpdateFormatting
        '
        Me.btnUpdateFormatting.Location = New System.Drawing.Point(104, 12)
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
        TextSettings1.Bold = False
        TextSettings1.Color = System.Drawing.Color.Black
        TextSettings1.ColorIndex = 7
        TextSettings1.FontIndex = 7
        TextSettings1.FontName = "Arial"
        TextSettings1.HalfPointSize = 20
        TextSettings1.Italic = False
        TextSettings1.PointSize = 10.0!
        XmlHtmDisplaySettings1.DefaultText = TextSettings1
        TextSettings2.Bold = False
        TextSettings2.Color = System.Drawing.Color.Blue
        TextSettings2.ColorIndex = 4
        TextSettings2.FontIndex = 1
        TextSettings2.FontName = "Arial"
        TextSettings2.HalfPointSize = 20
        TextSettings2.Italic = False
        TextSettings2.PointSize = 10.0!
        XmlHtmDisplaySettings1.HAttribute = TextSettings2
        TextSettings3.Bold = False
        TextSettings3.Color = System.Drawing.Color.Gray
        TextSettings3.ColorIndex = 6
        TextSettings3.FontIndex = 1
        TextSettings3.FontName = "Arial"
        TextSettings3.HalfPointSize = 20
        TextSettings3.Italic = False
        TextSettings3.PointSize = 10.0!
        XmlHtmDisplaySettings1.HChar = TextSettings3
        TextSettings4.Bold = False
        TextSettings4.Color = System.Drawing.Color.Gray
        TextSettings4.ColorIndex = 6
        TextSettings4.FontIndex = 1
        TextSettings4.FontName = "Arial"
        TextSettings4.HalfPointSize = 20
        TextSettings4.Italic = False
        TextSettings4.PointSize = 10.0!
        XmlHtmDisplaySettings1.HComment = TextSettings4
        TextSettings5.Bold = False
        TextSettings5.Color = System.Drawing.Color.DarkRed
        TextSettings5.ColorIndex = 2
        TextSettings5.FontIndex = 1
        TextSettings5.FontName = "Arial"
        TextSettings5.HalfPointSize = 20
        TextSettings5.Italic = False
        TextSettings5.PointSize = 10.0!
        XmlHtmDisplaySettings1.HElement = TextSettings5
        TextSettings6.Bold = False
        TextSettings6.Color = System.Drawing.Color.Black
        TextSettings6.ColorIndex = 5
        TextSettings6.FontIndex = 1
        TextSettings6.FontName = "Arial"
        TextSettings6.HalfPointSize = 20
        TextSettings6.Italic = False
        TextSettings6.PointSize = 10.0!
        XmlHtmDisplaySettings1.HStyle = TextSettings6
        TextSettings7.Bold = False
        TextSettings7.Color = System.Drawing.Color.Black
        TextSettings7.ColorIndex = 7
        TextSettings7.FontIndex = 7
        TextSettings7.FontName = "Arial"
        TextSettings7.HalfPointSize = 20
        TextSettings7.Italic = False
        TextSettings7.PointSize = 10.0!
        XmlHtmDisplaySettings1.HText = TextSettings7
        TextSettings8.Bold = False
        TextSettings8.Color = System.Drawing.Color.Black
        TextSettings8.ColorIndex = 5
        TextSettings8.FontIndex = 1
        TextSettings8.FontName = "Arial"
        TextSettings8.HalfPointSize = 20
        TextSettings8.Italic = False
        TextSettings8.PointSize = 10.0!
        XmlHtmDisplaySettings1.HValue = TextSettings8
        TextSettings9.Bold = False
        TextSettings9.Color = System.Drawing.Color.Black
        TextSettings9.ColorIndex = 7
        TextSettings9.FontIndex = 7
        TextSettings9.FontName = "Arial"
        TextSettings9.HalfPointSize = 20
        TextSettings9.Italic = False
        TextSettings9.PointSize = 10.0!
        XmlHtmDisplaySettings1.PlainText = TextSettings9
        TextSettings10.Bold = False
        TextSettings10.Color = System.Drawing.Color.Red
        TextSettings10.ColorIndex = 3
        TextSettings10.FontIndex = 1
        TextSettings10.FontName = "Arial"
        TextSettings10.HalfPointSize = 20
        TextSettings10.Italic = False
        TextSettings10.PointSize = 10.0!
        XmlHtmDisplaySettings1.XAttributeKey = TextSettings10
        TextSettings11.Bold = False
        TextSettings11.Color = System.Drawing.Color.Blue
        TextSettings11.ColorIndex = 4
        TextSettings11.FontIndex = 1
        TextSettings11.FontName = "Arial"
        TextSettings11.HalfPointSize = 20
        TextSettings11.Italic = False
        TextSettings11.PointSize = 10.0!
        XmlHtmDisplaySettings1.XAttributeValue = TextSettings11
        TextSettings12.Bold = False
        TextSettings12.Color = System.Drawing.Color.Gray
        TextSettings12.ColorIndex = 6
        TextSettings12.FontIndex = 1
        TextSettings12.FontName = "Arial"
        TextSettings12.HalfPointSize = 20
        TextSettings12.Italic = False
        TextSettings12.PointSize = 10.0!
        XmlHtmDisplaySettings1.XComment = TextSettings12
        TextSettings13.Bold = False
        TextSettings13.Color = System.Drawing.Color.DarkRed
        TextSettings13.ColorIndex = 2
        TextSettings13.FontIndex = 1
        TextSettings13.FontName = "Arial"
        TextSettings13.HalfPointSize = 20
        TextSettings13.Italic = False
        TextSettings13.PointSize = 10.0!
        XmlHtmDisplaySettings1.XElement = TextSettings13
        XmlHtmDisplaySettings1.XIndentSpaces = 4
        XmlHtmDisplaySettings1.XmlLargeFileSizeLimit = 1000000
        TextSettings14.Bold = False
        TextSettings14.Color = System.Drawing.Color.Blue
        TextSettings14.ColorIndex = 1
        TextSettings14.FontIndex = 1
        TextSettings14.FontName = "Arial"
        TextSettings14.HalfPointSize = 20
        TextSettings14.Italic = False
        TextSettings14.PointSize = 10.0!
        XmlHtmDisplaySettings1.XTag = TextSettings14
        TextSettings15.Bold = False
        TextSettings15.Color = System.Drawing.Color.Black
        TextSettings15.ColorIndex = 5
        TextSettings15.FontIndex = 1
        TextSettings15.FontName = "Arial"
        TextSettings15.HalfPointSize = 20
        TextSettings15.Italic = False
        TextSettings15.PointSize = 10.0!
        XmlHtmDisplaySettings1.XValue = TextSettings15
        Me.XmlHtmDisplay1.Settings = XmlHtmDisplaySettings1
        Me.XmlHtmDisplay1.Size = New System.Drawing.Size(828, 478)
        Me.XmlHtmDisplay1.TabIndex = 276
        Me.XmlHtmDisplay1.Text = ""
        '
        'txtFileName
        '
        Me.txtFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileName.Location = New System.Drawing.Point(290, 12)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(326, 20)
        Me.txtFileName.TabIndex = 275
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(228, 15)
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
        'btnSaveAs
        '
        Me.btnSaveAs.Location = New System.Drawing.Point(161, 12)
        Me.btnSaveAs.Name = "btnSaveAs"
        Me.btnSaveAs.Size = New System.Drawing.Size(61, 22)
        Me.btnSaveAs.TabIndex = 279
        Me.btnSaveAs.Text = "Save As"
        Me.btnSaveAs.UseVisualStyleBackColor = True
        '
        'frmHtmlDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 530)
        Me.Controls.Add(Me.btnSaveAs)
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
    Friend WithEvents btnSaveAs As Button
End Class
