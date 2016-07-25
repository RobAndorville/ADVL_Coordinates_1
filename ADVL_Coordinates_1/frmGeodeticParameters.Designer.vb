<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeodeticParameters
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnTransformations = New System.Windows.Forms.Button()
        Me.btnProjections = New System.Windows.Forms.Button()
        Me.btnCoordOpMethods = New System.Windows.Forms.Button()
        Me.btnCoordinateSystems = New System.Windows.Forms.Button()
        Me.btnUnitsOfMeasure = New System.Windows.Forms.Button()
        Me.btnAreasOfUse = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnEllipsoids = New System.Windows.Forms.Button()
        Me.btnPrimeMeridians = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnEngineeringDatum = New System.Windows.Forms.Button()
        Me.btnVerticalDatum = New System.Windows.Forms.Button()
        Me.btnGeodeticDatums = New System.Windows.Forms.Button()
        Me.btnDatumList = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCompound = New System.Windows.Forms.Button()
        Me.btnEngineering = New System.Windows.Forms.Button()
        Me.btnGeocentric = New System.Windows.Forms.Button()
        Me.btnGeographic3D = New System.Windows.Forms.Button()
        Me.btnVerticalCRS = New System.Windows.Forms.Button()
        Me.btnProjected = New System.Windows.Forms.Button()
        Me.btnGeographic2D = New System.Windows.Forms.Button()
        Me.btnCRSList = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.btnTransformations)
        Me.GroupBox1.Controls.Add(Me.btnProjections)
        Me.GroupBox1.Controls.Add(Me.btnCoordOpMethods)
        Me.GroupBox1.Controls.Add(Me.btnCoordinateSystems)
        Me.GroupBox1.Controls.Add(Me.btnUnitsOfMeasure)
        Me.GroupBox1.Controls.Add(Me.btnAreasOfUse)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnCRSList)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 383)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Coordinate Reference Systems"
        '
        'btnTransformations
        '
        Me.btnTransformations.Location = New System.Drawing.Point(119, 301)
        Me.btnTransformations.Name = "btnTransformations"
        Me.btnTransformations.Size = New System.Drawing.Size(118, 22)
        Me.btnTransformations.TabIndex = 1
        Me.btnTransformations.Text = "Transformations"
        Me.btnTransformations.UseVisualStyleBackColor = True
        '
        'btnProjections
        '
        Me.btnProjections.Location = New System.Drawing.Point(119, 275)
        Me.btnProjections.Name = "btnProjections"
        Me.btnProjections.Size = New System.Drawing.Size(118, 22)
        Me.btnProjections.TabIndex = 5
        Me.btnProjections.Text = "Projections"
        Me.btnProjections.UseVisualStyleBackColor = True
        '
        'btnCoordOpMethods
        '
        Me.btnCoordOpMethods.Location = New System.Drawing.Point(119, 329)
        Me.btnCoordOpMethods.Name = "btnCoordOpMethods"
        Me.btnCoordOpMethods.Size = New System.Drawing.Size(118, 39)
        Me.btnCoordOpMethods.TabIndex = 27
        Me.btnCoordOpMethods.Text = "Coordinate Operation Methods"
        Me.btnCoordOpMethods.UseVisualStyleBackColor = True
        '
        'btnCoordinateSystems
        '
        Me.btnCoordinateSystems.Location = New System.Drawing.Point(6, 329)
        Me.btnCoordinateSystems.Name = "btnCoordinateSystems"
        Me.btnCoordinateSystems.Size = New System.Drawing.Size(107, 39)
        Me.btnCoordinateSystems.TabIndex = 6
        Me.btnCoordinateSystems.Text = "Coordinate Systems"
        Me.btnCoordinateSystems.UseVisualStyleBackColor = True
        '
        'btnUnitsOfMeasure
        '
        Me.btnUnitsOfMeasure.Location = New System.Drawing.Point(6, 301)
        Me.btnUnitsOfMeasure.Name = "btnUnitsOfMeasure"
        Me.btnUnitsOfMeasure.Size = New System.Drawing.Size(107, 22)
        Me.btnUnitsOfMeasure.TabIndex = 2
        Me.btnUnitsOfMeasure.Text = "Units of Measure"
        Me.btnUnitsOfMeasure.UseVisualStyleBackColor = True
        '
        'btnAreasOfUse
        '
        Me.btnAreasOfUse.Location = New System.Drawing.Point(6, 275)
        Me.btnAreasOfUse.Name = "btnAreasOfUse"
        Me.btnAreasOfUse.Size = New System.Drawing.Size(107, 22)
        Me.btnAreasOfUse.TabIndex = 2
        Me.btnAreasOfUse.Text = "Areas of Use"
        Me.btnAreasOfUse.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox4.Controls.Add(Me.btnEllipsoids)
        Me.GroupBox4.Controls.Add(Me.btnPrimeMeridians)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.btnDatumList)
        Me.GroupBox4.Location = New System.Drawing.Point(119, 47)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(118, 220)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datums"
        '
        'btnEllipsoids
        '
        Me.btnEllipsoids.Location = New System.Drawing.Point(6, 183)
        Me.btnEllipsoids.Name = "btnEllipsoids"
        Me.btnEllipsoids.Size = New System.Drawing.Size(100, 22)
        Me.btnEllipsoids.TabIndex = 21
        Me.btnEllipsoids.Text = "Ellipsoids"
        Me.btnEllipsoids.UseVisualStyleBackColor = True
        '
        'btnPrimeMeridians
        '
        Me.btnPrimeMeridians.Location = New System.Drawing.Point(6, 155)
        Me.btnPrimeMeridians.Name = "btnPrimeMeridians"
        Me.btnPrimeMeridians.Size = New System.Drawing.Size(100, 22)
        Me.btnPrimeMeridians.TabIndex = 20
        Me.btnPrimeMeridians.Text = "Prime Meridians"
        Me.btnPrimeMeridians.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Silver
        Me.GroupBox5.Controls.Add(Me.btnEngineeringDatum)
        Me.GroupBox5.Controls.Add(Me.btnVerticalDatum)
        Me.GroupBox5.Controls.Add(Me.btnGeodeticDatums)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 47)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(100, 102)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Datum Types"
        '
        'btnEngineeringDatum
        '
        Me.btnEngineeringDatum.Location = New System.Drawing.Point(6, 75)
        Me.btnEngineeringDatum.Name = "btnEngineeringDatum"
        Me.btnEngineeringDatum.Size = New System.Drawing.Size(88, 22)
        Me.btnEngineeringDatum.TabIndex = 3
        Me.btnEngineeringDatum.Text = "Engineering"
        Me.btnEngineeringDatum.UseVisualStyleBackColor = True
        '
        'btnVerticalDatum
        '
        Me.btnVerticalDatum.Location = New System.Drawing.Point(6, 47)
        Me.btnVerticalDatum.Name = "btnVerticalDatum"
        Me.btnVerticalDatum.Size = New System.Drawing.Size(88, 22)
        Me.btnVerticalDatum.TabIndex = 2
        Me.btnVerticalDatum.Text = "Vertical"
        Me.btnVerticalDatum.UseVisualStyleBackColor = True
        '
        'btnGeodeticDatums
        '
        Me.btnGeodeticDatums.Location = New System.Drawing.Point(6, 19)
        Me.btnGeodeticDatums.Name = "btnGeodeticDatums"
        Me.btnGeodeticDatums.Size = New System.Drawing.Size(88, 22)
        Me.btnGeodeticDatums.TabIndex = 0
        Me.btnGeodeticDatums.Text = "Geodetic"
        Me.btnGeodeticDatums.UseVisualStyleBackColor = True
        '
        'btnDatumList
        '
        Me.btnDatumList.Location = New System.Drawing.Point(6, 19)
        Me.btnDatumList.Name = "btnDatumList"
        Me.btnDatumList.Size = New System.Drawing.Size(100, 22)
        Me.btnDatumList.TabIndex = 0
        Me.btnDatumList.Text = "Datum List"
        Me.btnDatumList.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Controls.Add(Me.btnCompound)
        Me.GroupBox2.Controls.Add(Me.btnEngineering)
        Me.GroupBox2.Controls.Add(Me.btnGeocentric)
        Me.GroupBox2.Controls.Add(Me.btnGeographic3D)
        Me.GroupBox2.Controls.Add(Me.btnVerticalCRS)
        Me.GroupBox2.Controls.Add(Me.btnProjected)
        Me.GroupBox2.Controls.Add(Me.btnGeographic2D)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(107, 220)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CRS Types"
        '
        'btnCompound
        '
        Me.btnCompound.Location = New System.Drawing.Point(6, 19)
        Me.btnCompound.Name = "btnCompound"
        Me.btnCompound.Size = New System.Drawing.Size(92, 22)
        Me.btnCompound.TabIndex = 6
        Me.btnCompound.Text = "Compound"
        Me.btnCompound.UseVisualStyleBackColor = True
        '
        'btnEngineering
        '
        Me.btnEngineering.Location = New System.Drawing.Point(6, 47)
        Me.btnEngineering.Name = "btnEngineering"
        Me.btnEngineering.Size = New System.Drawing.Size(92, 22)
        Me.btnEngineering.TabIndex = 5
        Me.btnEngineering.Text = "Engineering"
        Me.btnEngineering.UseVisualStyleBackColor = True
        '
        'btnGeocentric
        '
        Me.btnGeocentric.Location = New System.Drawing.Point(6, 75)
        Me.btnGeocentric.Name = "btnGeocentric"
        Me.btnGeocentric.Size = New System.Drawing.Size(92, 22)
        Me.btnGeocentric.TabIndex = 4
        Me.btnGeocentric.Text = "Geocentric"
        Me.btnGeocentric.UseVisualStyleBackColor = True
        '
        'btnGeographic3D
        '
        Me.btnGeographic3D.Location = New System.Drawing.Point(6, 131)
        Me.btnGeographic3D.Name = "btnGeographic3D"
        Me.btnGeographic3D.Size = New System.Drawing.Size(92, 22)
        Me.btnGeographic3D.TabIndex = 3
        Me.btnGeographic3D.Text = "Geographic 3D"
        Me.btnGeographic3D.UseVisualStyleBackColor = True
        '
        'btnVerticalCRS
        '
        Me.btnVerticalCRS.Location = New System.Drawing.Point(6, 187)
        Me.btnVerticalCRS.Name = "btnVerticalCRS"
        Me.btnVerticalCRS.Size = New System.Drawing.Size(92, 22)
        Me.btnVerticalCRS.TabIndex = 2
        Me.btnVerticalCRS.Text = "Vertical"
        Me.btnVerticalCRS.UseVisualStyleBackColor = True
        '
        'btnProjected
        '
        Me.btnProjected.Location = New System.Drawing.Point(6, 159)
        Me.btnProjected.Name = "btnProjected"
        Me.btnProjected.Size = New System.Drawing.Size(92, 22)
        Me.btnProjected.TabIndex = 1
        Me.btnProjected.Text = "Projected"
        Me.btnProjected.UseVisualStyleBackColor = True
        '
        'btnGeographic2D
        '
        Me.btnGeographic2D.Location = New System.Drawing.Point(6, 103)
        Me.btnGeographic2D.Name = "btnGeographic2D"
        Me.btnGeographic2D.Size = New System.Drawing.Size(92, 22)
        Me.btnGeographic2D.TabIndex = 0
        Me.btnGeographic2D.Text = "Geographic 2D"
        Me.btnGeographic2D.UseVisualStyleBackColor = True
        '
        'btnCRSList
        '
        Me.btnCRSList.Location = New System.Drawing.Point(6, 19)
        Me.btnCRSList.Name = "btnCRSList"
        Me.btnCRSList.Size = New System.Drawing.Size(107, 22)
        Me.btnCRSList.TabIndex = 0
        Me.btnCRSList.Text = "CRS List"
        Me.btnCRSList.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(198, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 25
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmGeodeticParameters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(274, 440)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmGeodeticParameters"
        Me.Text = "Geodetic Parameters"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnTransformations As System.Windows.Forms.Button
    Friend WithEvents btnProjections As System.Windows.Forms.Button
    Friend WithEvents btnCoordOpMethods As System.Windows.Forms.Button
    Friend WithEvents btnCoordinateSystems As System.Windows.Forms.Button
    Friend WithEvents btnUnitsOfMeasure As System.Windows.Forms.Button
    Friend WithEvents btnAreasOfUse As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEllipsoids As System.Windows.Forms.Button
    Friend WithEvents btnPrimeMeridians As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEngineeringDatum As System.Windows.Forms.Button
    Friend WithEvents btnVerticalDatum As System.Windows.Forms.Button
    Friend WithEvents btnGeodeticDatums As System.Windows.Forms.Button
    Friend WithEvents btnDatumList As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCompound As System.Windows.Forms.Button
    Friend WithEvents btnEngineering As System.Windows.Forms.Button
    Friend WithEvents btnGeocentric As System.Windows.Forms.Button
    Friend WithEvents btnGeographic3D As System.Windows.Forms.Button
    Friend WithEvents btnVerticalCRS As System.Windows.Forms.Button
    Friend WithEvents btnProjected As System.Windows.Forms.Button
    Friend WithEvents btnGeographic2D As System.Windows.Forms.Button
    Friend WithEvents btnCRSList As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
End Class
