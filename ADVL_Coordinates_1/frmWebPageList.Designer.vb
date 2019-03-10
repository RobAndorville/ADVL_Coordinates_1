<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWebPageList
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
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNewHtmlFileTitle = New System.Windows.Forms.TextBox()
        Me.txtNewHtmlFileName = New System.Windows.Forms.TextBox()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.lstWebPages = New System.Windows.Forms.ListBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(120, 14)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(48, 22)
        Me.btnDelete.TabIndex = 43
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Title:"
        '
        'txtNewHtmlFileTitle
        '
        Me.txtNewHtmlFileTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewHtmlFileTitle.Location = New System.Drawing.Point(66, 69)
        Me.txtNewHtmlFileTitle.Name = "txtNewHtmlFileTitle"
        Me.txtNewHtmlFileTitle.Size = New System.Drawing.Size(294, 20)
        Me.txtNewHtmlFileTitle.TabIndex = 41
        '
        'txtNewHtmlFileName
        '
        Me.txtNewHtmlFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewHtmlFileName.Location = New System.Drawing.Point(66, 43)
        Me.txtNewHtmlFileName.Name = "txtNewHtmlFileName"
        Me.txtNewHtmlFileName.Size = New System.Drawing.Size(294, 20)
        Me.txtNewHtmlFileName.TabIndex = 40
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(12, 42)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(48, 22)
        Me.btnNew.TabIndex = 39
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(66, 14)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(48, 22)
        Me.btnEdit.TabIndex = 38
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(12, 14)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(48, 22)
        Me.btnOpen.TabIndex = 37
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'lstWebPages
        '
        Me.lstWebPages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstWebPages.FormattingEnabled = True
        Me.lstWebPages.Location = New System.Drawing.Point(12, 94)
        Me.lstWebPages.Name = "lstWebPages"
        Me.lstWebPages.Size = New System.Drawing.Size(348, 238)
        Me.lstWebPages.TabIndex = 36
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(312, 14)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(48, 22)
        Me.btnExit.TabIndex = 35
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmWebPageList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 346)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNewHtmlFileTitle)
        Me.Controls.Add(Me.txtNewHtmlFileName)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.lstWebPages)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmWebPageList"
        Me.Text = "Web Pages"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDelete As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNewHtmlFileTitle As TextBox
    Friend WithEvents txtNewHtmlFileName As TextBox
    Friend WithEvents btnNew As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnOpen As Button
    Friend WithEvents lstWebPages As ListBox
    Friend WithEvents btnExit As Button
End Class
