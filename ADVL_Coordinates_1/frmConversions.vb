Public Class frmConversions
    'The Conversions form is used to convert angles and locations.


#Region " Variable Declarations - All the variables used in this form and this application." '-------------------------------------------------------------------------------------------------
#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Properties - All the properties used in this form and this application" '------------------------------------------------------------------------------------------------------------

#End Region 'Properties -----------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Process XML files - Read and write XML files." '-------------------------------------------------------------------------------------------------------------------------------------

    Private Sub SaveFormSettings()
        'Save the form settings in an XML document.
        Dim settingsData = <?xml version="1.0" encoding="utf-8"?>
                           <!---->
                           <!--Form settings for Main form.-->
                           <FormSettings>
                               <Left><%= Me.Left %></Left>
                               <Top><%= Me.Top %></Top>
                               <Width><%= Me.Width %></Width>
                               <Height><%= Me.Height %></Height>
                               <!---->
                           </FormSettings>

        'Add code to include other settings to save after the comment line <!---->

        Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Main.Project.SaveXmlSettings(SettingsFileName, settingsData)
    End Sub

    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"

        If Main.Project.SettingsFileExists(SettingsFileName) Then
            Dim Settings As System.Xml.Linq.XDocument
            Main.Project.ReadXmlSettings(SettingsFileName, Settings)

            If IsNothing(Settings) Then 'There is no Settings XML data.
                Exit Sub
            End If

            'Restore form position and size:
            If Settings.<FormSettings>.<Left>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Left = Settings.<FormSettings>.<Left>.Value
            End If

            If Settings.<FormSettings>.<Top>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Top = Settings.<FormSettings>.<Top>.Value
            End If

            If Settings.<FormSettings>.<Height>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Height = Settings.<FormSettings>.<Height>.Value
            End If

            If Settings.<FormSettings>.<Width>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Width = Settings.<FormSettings>.<Width>.Value
            End If

            'Add code to read other saved setting here:

            CheckFormPos()
        End If
    End Sub

    Private Sub CheckFormPos()
        'Check that the form can be seen on a screen.

        Dim MinWidthVisible As Integer = 192 'Minimum number of X pixels visible. The form will be moved if this many form pixels are not visible.
        Dim MinHeightVisible As Integer = 64 'Minimum number of Y pixels visible. The form will be moved if this many form pixels are not visible.

        Dim FormRect As New Rectangle(Me.Left, Me.Top, Me.Width, Me.Height)
        Dim WARect As Rectangle = Screen.GetWorkingArea(FormRect) 'The Working Area rectangle - the usable area of the screen containing the form.

        ''Check if the top of the form is less than zero:
        'If Me.Top < 0 Then Me.Top = 0

        'Check if the top of the form is above the top of the Working Area:
        If Me.Top < WARect.Top Then
            Me.Top = WARect.Top
        End If

        'Check if the top of the form is too close to the bottom of the Working Area:
        If (Me.Top + MinHeightVisible) > (WARect.Top + WARect.Height) Then
            Me.Top = WARect.Top + WARect.Height - MinHeightVisible
        End If

        'Check if the left edge of the form is too close to the right edge of the Working Area:
        If (Me.Left + MinWidthVisible) > (WARect.Left + WARect.Width) Then
            Me.Left = WARect.Left + WARect.Width - MinWidthVisible
        End If

        'Check if the right edge of the form is too close to the left edge of the Working Area:
        If (Me.Left + Me.Width - MinWidthVisible) < WARect.Left Then
            Me.Left = WARect.Left - Me.Width + MinWidthVisible
        End If
    End Sub

    'Save the form settings if the form is being minimised:
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = &H112 Then 'SysCommand
            If m.WParam.ToInt32 = &HF020 Then 'Form is being minimised
                SaveFormSettings()
            End If
        End If
        MyBase.WndProc(m)
    End Sub

#End Region 'Process XML Files ----------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Display Methods - Code used to display this form." '----------------------------------------------------------------------------------------------------------------------------

    Private Sub frmConversions_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Restore the form settings: ---------------------------------------------------------
        RestoreFormSettings()

        cmbInput.Items.Add("Degrees, Minutes, Seconds")
        cmbInput.Items.Add("Decimal Degrees")
        cmbInput.Items.Add("Sexagesimal Degrees")
        cmbInput.Items.Add("Radians")
        cmbInput.Items.Add("Gradians")
        cmbInput.Items.Add("Turns")
        cmbInput.SelectedIndex = 0

        cmbOutput.Items.Add("Degrees, Minutes, Seconds")
        cmbOutput.Items.Add("Decimal Degrees")
        cmbOutput.Items.Add("Sexagesimal Degrees")
        cmbOutput.Items.Add("Radians")
        cmbOutput.Items.Add("Gradians")
        cmbOutput.Items.Add("Turns")
        cmbOutput.SelectedIndex = 1

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Form
        Me.Close()  'Close the form
    End Sub

    Private Sub frmConversions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If WindowState = FormWindowState.Normal Then
            SaveFormSettings()
        End If



    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub cmbInput_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbInput.SelectedIndexChanged
        Select Case cmbInput.Text
            Case "Degrees, Minutes, Seconds"
                txtInputAngle.Hide()
                txtInputSign.Show()
                txtInputDegrees.Show()
                txtInputMinutes.Show()
                txtInputSeconds.Show()
                txtInputSign.Location = New Point(6, 60)
                txtInputSign.Width = 16
                txtInputDegrees.Location = New Point(27, 60)
                txtInputDegrees.Width = 38
                txtInputMinutes.Location = New Point(71, 60)
                txtInputMinutes.Width = 38
                txtInputSeconds.Location = New Point(115, 60)
                txtInputSeconds.Width = 120

                Label6.Show() 'Deg label
                Label7.Show() 'Min label
                Label9.Show() 'Sec label

            Case "Decimal Degrees"
                txtInputAngle.Show()
                txtInputSign.Hide()
                txtInputDegrees.Hide()
                txtInputMinutes.Hide()
                txtInputSeconds.Hide()
                txtInputAngle.Location = New Point(7, 60)
                txtInputAngle.Width = 120

                Label6.Hide() 'Deg label
                Label7.Hide() 'Min label
                Label9.Hide() 'Sec label

            Case "Sexagesimal Degrees"
                txtInputAngle.Show()
                txtInputSign.Hide()
                txtInputDegrees.Hide()
                txtInputMinutes.Hide()
                txtInputSeconds.Hide()
                txtInputAngle.Location = New Point(7, 60)
                txtInputAngle.Width = 120

                Label6.Hide() 'Deg label
                Label7.Hide() 'Min label
                Label9.Hide() 'Sec label

            Case "Radians"
                txtInputAngle.Show()
                txtInputSign.Hide()
                txtInputDegrees.Hide()
                txtInputMinutes.Hide()
                txtInputSeconds.Hide()
                txtInputDegrees.Location = New Point(7, 60)
                txtInputDegrees.Width = 120

                Label6.Hide() 'Deg label
                Label7.Hide() 'Min label
                Label9.Hide() 'Sec label

            Case "Gradians"
                txtInputAngle.Show()
                txtInputSign.Hide()
                txtInputDegrees.Hide()
                txtInputMinutes.Hide()
                txtInputSeconds.Hide()
                txtInputAngle.Location = New Point(7, 60)
                txtInputAngle.Width = 120

                Label6.Hide() 'Deg label
                Label7.Hide() 'Min label
                Label9.Hide() 'Sec label

            Case "Turns"
                txtInputAngle.Show()
                txtInputSign.Hide()
                txtInputDegrees.Hide()
                txtInputMinutes.Hide()
                txtInputSeconds.Hide()
                txtInputAngle.Location = New Point(7, 60)
                txtInputAngle.Width = 120

                Label6.Hide() 'Deg label
                Label7.Hide() 'Min label
                Label9.Hide() 'Sec label

        End Select
    End Sub

    Private Sub cmbOutput_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOutput.SelectedIndexChanged
        Select Case cmbOutput.Text
            Case "Degrees, Minutes, Seconds"
                txtOutputAngle.Hide()
                txtOutputSign.Show()
                txtOutputDegrees.Show()
                txtOutputMinutes.Show()
                txtOutputSeconds.Show()
                txtOutputSign.Location = New Point(263, 60)
                txtOutputSign.Width = 16
                txtOutputDegrees.Location = New Point(285, 60)
                txtOutputDegrees.Width = 38
                txtOutputMinutes.Location = New Point(329, 60)
                txtOutputMinutes.Width = 38
                txtOutputSeconds.Location = New Point(373, 60)
                txtOutputSeconds.Width = 120

                Label5.Show() 'Deg label
                Label4.Show() 'Min label
                Label3.Show() 'Sec label

            Case "Decimal Degrees"
                txtOutputAngle.Show()
                txtOutputSign.Hide()
                txtOutputDegrees.Hide()
                txtOutputMinutes.Hide()
                txtOutputSeconds.Hide()
                txtOutputAngle.Location = New Point(245, 60)
                txtOutputAngle.Width = 120

                Label5.Hide() 'Deg label
                Label4.Hide() 'Min label
                Label3.Hide() 'Sec label

            Case "Sexagesimal Degrees"
                txtOutputAngle.Show()
                txtOutputSign.Hide()
                txtOutputDegrees.Hide()
                txtOutputMinutes.Hide()
                txtOutputSeconds.Hide()
                txtOutputAngle.Location = New Point(245, 60)
                txtOutputAngle.Width = 120

                Label5.Hide() 'Deg label
                Label4.Hide() 'Min label
                Label3.Hide() 'Sec label

            Case "Radians"
                txtOutputAngle.Show()
                txtOutputSign.Hide()
                txtOutputDegrees.Hide()
                txtOutputMinutes.Hide()
                txtOutputSeconds.Hide()
                txtOutputDegrees.Location = New Point(245, 60)
                txtOutputDegrees.Width = 120

                Label5.Hide() 'Deg label
                Label4.Hide() 'Min label
                Label3.Hide() 'Sec label

            Case "Gradians"
                txtOutputAngle.Show()
                txtOutputSign.Hide()
                txtOutputDegrees.Hide()
                txtOutputMinutes.Hide()
                txtOutputSeconds.Hide()
                txtOutputAngle.Location = New Point(245, 60)
                txtOutputAngle.Width = 120

                Label5.Hide() 'Deg label
                Label4.Hide() 'Min label
                Label3.Hide() 'Sec label

            Case "Turns"
                txtOutputAngle.Show()
                txtOutputSign.Hide()
                txtOutputDegrees.Hide()
                txtOutputMinutes.Hide()
                txtOutputSeconds.Hide()
                txtOutputAngle.Location = New Point(245, 60)
                txtOutputAngle.Width = 120

                Label5.Hide() 'Deg label
                Label4.Hide() 'Min label
                Label3.Hide() 'Sec label

        End Select
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        'Convert Input angle to Output angle

        Dim angleConvert As New ADVL_Coordinates_Library_1.AngleConvert
        Dim angleDegMinSec As New ADVL_Coordinates_Library_1.AngleDegMinSec

        If txtInputSign.Text = "" Then txtInputSign.Text = "+"
        If txtInputAngle.Text = "" Then txtInputAngle.Text = "0"
        If txtInputDegrees.Text = "" Then txtInputDegrees.Text = "0"
        If txtInputMinutes.Text = "" Then txtInputMinutes.Text = "0"
        If txtInputSeconds.Text = "" Then txtInputSeconds.Text = "0"

        Select Case cmbInput.Text
            Case "Degrees, Minutes, Seconds" 'Input angle is | Sign | Degrees | Minutes | Seconds |
                If txtInputSign.Text = "+" Then
                    angleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Positive
                ElseIf txtInputSign.Text = "-" Then
                    angleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Negative
                End If
                angleDegMinSec.Degrees = txtInputDegrees.Text
                angleDegMinSec.Minutes = txtInputMinutes.Text
                angleDegMinSec.Seconds = txtInputSeconds.Text
                angleConvert.DecimalDegrees = angleDegMinSec.DegMinSecToDecimalDegrees
                Select Case cmbOutput.Text
                    Case "Degrees, Minutes, Seconds"
                        txtOutputSign.Text = txtInputSign.Text
                        txtOutputDegrees.Text = txtInputDegrees.Text
                        txtOutputMinutes.Text = txtInputMinutes.Text
                        txtOutputSeconds.Text = txtInputSeconds.Text
                    Case "Decimal Degrees"
                        txtOutputAngle.Text = angleConvert.DecimalDegrees
                    Case "Sexagesimal Degrees"
                        angleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                        txtOutputAngle.Text = angleConvert.SexagesimalDegrees
                    Case "Radians"
                        angleConvert.ConvertDecimalDegreeToRadian()
                        txtOutputAngle.Text = angleConvert.Radians
                    Case "Gradians"
                        angleConvert.ConvertDecimalDegreeToGradian()
                        txtOutputAngle.Text = angleConvert.Gradians
                    Case "Turns"
                        angleConvert.ConvertDecimalDegreeToTurn()
                        txtOutputAngle.Text = angleConvert.Turns
                End Select

            Case "Decimal Degrees" 'Input angle is | Decimal Degrees |
                angleConvert.DecimalDegrees = txtInputAngle.Text
                Select Case cmbOutput.Text
                    Case "Degrees, Minutes, Seconds" 'Output angle is | Sign | Degrees | Minutes | Seconds |
                        angleDegMinSec.DecimalDegreesToDegMinSec(angleConvert.DecimalDegrees)
                        If angleDegMinSec.DegMinSecSign = ADVL_Coordinates_Library_1.AngleDegMinSec.Sign.Positive Then
                            txtOutputSign.Text = "+"
                        Else
                            txtOutputSign.Text = "-"
                        End If
                        txtOutputDegrees.Text = angleDegMinSec.Degrees
                        txtOutputMinutes.Text = angleDegMinSec.Minutes
                        txtOutputSeconds.Text = angleDegMinSec.Seconds
                    Case "Decimal Degrees"
                        txtOutputAngle.Text = txtInputAngle.Text
                    Case "Sexagesimal Degrees"
                        angleConvert.ConvertDecimalDegreeToSexagesimalDegree()
                        txtOutputAngle.Text = angleConvert.SexagesimalDegrees
                    Case "Radians"
                        angleConvert.ConvertDecimalDegreeToRadian()
                        txtOutputAngle.Text = angleConvert.Radians
                    Case "Gradians"
                        angleConvert.ConvertDecimalDegreeToGradian()
                        txtOutputAngle.Text = angleConvert.Gradians
                    Case "Turns"
                        angleConvert.ConvertDecimalDegreeToTurn()
                        txtOutputAngle.Text = angleConvert.Turns
                End Select
            Case "Sexagesimal Degrees"
                angleConvert.SexagesimalDegrees = txtInputAngle.Text
                Select Case cmbOutput.Text
                    Case "Degrees, Minutes, Seconds"
                        angleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                        angleDegMinSec.DecimalDegreesToDegMinSec(angleConvert.DecimalDegrees)
                        txtOutputDegrees.Text = angleDegMinSec.Degrees
                        txtOutputMinutes.Text = angleDegMinSec.Minutes
                        txtOutputSeconds.Text = angleDegMinSec.Seconds
                    Case "Decimal Degrees"
                        angleConvert.ConvertSexagesimalDegreeToDecimalDegree()
                        txtOutputAngle.Text = angleConvert.DecimalDegrees
                    Case "Sexagesimal Degrees"
                        txtOutputAngle.Text = txtInputAngle.Text
                    Case "Radians"
                        angleConvert.ConvertSexagesimalDegreeToRadian()
                        txtOutputAngle.Text = angleConvert.Radians
                    Case "Gradians"
                        angleConvert.ConvertSexagesimalDegreeToGradian()
                        txtOutputAngle.Text = angleConvert.Gradians
                    Case "Turns"
                        angleConvert.ConvertSexagesimalDegreeToTurn()
                        txtOutputAngle.Text = angleConvert.Turns
                End Select
            Case "Radians"
                angleConvert.Radians = txtInputAngle.Text
                Select Case cmbOutput.Text
                    Case "Degrees, Minutes, Seconds"
                        angleConvert.ConvertRadianToDecimalDegree()
                        angleDegMinSec.DecimalDegreesToDegMinSec(angleConvert.DecimalDegrees)
                        txtOutputDegrees.Text = angleDegMinSec.Degrees
                        txtOutputMinutes.Text = angleDegMinSec.Minutes
                        txtOutputSeconds.Text = angleDegMinSec.Seconds
                    Case "Decimal Degrees"
                        angleConvert.ConvertRadianToDecimalDegree()
                        txtOutputAngle.Text = angleConvert.DecimalDegrees
                    Case "Sexagesimal Degrees"
                        angleConvert.ConvertRadianToSexagesimalDegree()
                        txtOutputAngle.Text = angleConvert.SexagesimalDegrees
                    Case "Radians"
                        txtOutputAngle.Text = txtInputAngle.Text
                    Case "Gradians"
                        angleConvert.ConvertRadianToGradian()
                        txtOutputAngle.Text = angleConvert.Gradians
                    Case "Turns"
                        angleConvert.ConvertRadianToTurn()
                        txtOutputAngle.Text = angleConvert.Turns
                End Select
            Case "Gradians"
                angleConvert.Gradians = txtInputAngle.Text
                Select Case cmbOutput.Text
                    Case "Degrees, Minutes, Seconds"
                        angleConvert.ConvertGradianToDecimalDegree()
                        angleDegMinSec.DecimalDegreesToDegMinSec(angleConvert.DecimalDegrees)
                        txtOutputDegrees.Text = angleDegMinSec.Degrees
                        txtOutputMinutes.Text = angleDegMinSec.Minutes
                        txtOutputSeconds.Text = angleDegMinSec.Seconds
                    Case "Decimal Degrees"
                        angleConvert.ConvertGradianToDecimalDegree()
                        txtOutputAngle.Text = angleConvert.DecimalDegrees
                    Case "Sexagesimal Degrees"
                        angleConvert.ConvertGradianToSexagesimalDegree()
                        txtOutputAngle.Text = angleConvert.SexagesimalDegrees
                    Case "Radians"
                        angleConvert.ConvertGradianToRadian()
                        txtOutputAngle.Text = angleConvert.Radians
                    Case "Gradians"
                        txtOutputAngle.Text = txtInputAngle.Text
                    Case "Turns"
                        angleConvert.ConvertGradianToTurn()
                        txtOutputAngle.Text = angleConvert.Turns
                End Select
            Case "Turns"
                angleConvert.Turns = txtInputAngle.Text
                Select Case cmbOutput.Text
                    Case "Degrees, Minutes, Seconds"
                        angleConvert.ConvertTurnToDecimalDegree()
                        angleDegMinSec.DecimalDegreesToDegMinSec(angleConvert.DecimalDegrees)
                        txtOutputDegrees.Text = angleDegMinSec.Degrees
                        txtOutputMinutes.Text = angleDegMinSec.Minutes
                        txtOutputSeconds.Text = angleDegMinSec.Seconds
                    Case "Decimal Degrees"
                        angleConvert.ConvertTurnToDecimalDegree()
                        txtOutputAngle.Text = angleConvert.DecimalDegrees
                    Case "Sexagesimal Degrees"
                        angleConvert.ConvertTurnToSexagesimalDegree()
                        txtOutputAngle.Text = angleConvert.SexagesimalDegrees
                    Case "Radians"
                        angleConvert.ConvertTurnToRadian()
                        txtOutputAngle.Text = angleConvert.Radians
                    Case "Gradians"
                        angleConvert.ConvertTurnToGradian()
                        txtOutputAngle.Text = angleConvert.Gradians
                    Case "Turns"
                        txtOutputAngle.Text = txtInputAngle.Text
                End Select
        End Select
    End Sub

    Private Sub txtInputDegrees_LostFocus(sender As Object, e As EventArgs) Handles txtInputDegrees.LostFocus
        txtInputDegrees.Text = Str(Val(txtInputDegrees.Text))
        If Val(txtInputDegrees.Text) < 0 Then
            'Check that Minutes and Seconds are also negative
            If Val(txtInputMinutes.Text) > 0 Then
                txtInputMinutes.Text = Str(Val(txtInputMinutes.Text) * -1)
            End If
            If Val(txtInputSeconds.Text) > 0 Then
                txtInputSeconds.Text = Str(Val(txtInputSeconds.Text) * -1)
            End If
        ElseIf Val(txtInputDegrees.Text) > 0 Then
            'Check that Minutes and Seconds are also positive
            If Val(txtInputMinutes.Text) < 0 Then
                txtInputMinutes.Text = Str(Val(txtInputMinutes.Text) * -1)
            End If
            If Val(txtInputSeconds.Text) < 0 Then
                txtInputSeconds.Text = Str(Val(txtInputSeconds.Text) * -1)
            End If
        End If
    End Sub

    Private Sub txtInputMinutes_LostFocus(sender As Object, e As EventArgs) Handles txtInputMinutes.LostFocus
        txtInputMinutes.Text = Str(Val(txtInputMinutes.Text))
        If Val(txtInputMinutes.Text) < 0 Then
            'Check that Degrees and Seconds are also negative
            If Val(txtInputDegrees.Text) > 0 Then
                txtInputDegrees.Text = Str(Val(txtInputDegrees.Text) * -1)
            End If
            If Val(txtInputSeconds.Text) > 0 Then
                txtInputSeconds.Text = Str(Val(txtInputSeconds.Text) * -1)
            End If
        ElseIf Val(txtInputMinutes.Text) > 0 Then
            'Check that Degrees and Seconds are also positive
            If Val(txtInputDegrees.Text) < 0 Then
                txtInputDegrees.Text = Str(Val(txtInputDegrees.Text) * -1)
            End If
            If Val(txtInputSeconds.Text) < 0 Then
                txtInputSeconds.Text = Str(Val(txtInputSeconds.Text) * -1)
            End If
        End If
    End Sub

    Private Sub txtInputSeconds_LostFocus(sender As Object, e As EventArgs) Handles txtInputSeconds.LostFocus
        txtInputSeconds.Text = Str(Val(txtInputSeconds.Text))
        If Val(txtInputSeconds.Text) < 0 Then
            'Check that Degrees and Minutes are also negative
            If Val(txtInputDegrees.Text) > 0 Then
                txtInputDegrees.Text = Str(Val(txtInputDegrees.Text) * -1)
            End If
            If Val(txtInputMinutes.Text) > 0 Then
                txtInputMinutes.Text = Str(Val(txtInputMinutes.Text) * -1)
            End If
        ElseIf Val(txtInputSeconds.Text) > 0 Then
            'Check that Degrees and Minutes are also positive
            If Val(txtInputDegrees.Text) < 0 Then
                txtInputDegrees.Text = Str(Val(txtInputDegrees.Text) * -1)
            End If
            If Val(txtInputMinutes.Text) < 0 Then
                txtInputMinutes.Text = Str(Val(txtInputMinutes.Text) * -1)
            End If
        End If
    End Sub

    Private Sub txtInputAngle_LostFocus(sender As Object, e As EventArgs) Handles txtInputAngle.LostFocus
        txtInputAngle.Text = Str(Val(txtInputAngle.Text))
    End Sub

    Private Sub txtOutputDegrees_LostFocus(sender As Object, e As EventArgs) Handles txtOutputDegrees.LostFocus
        txtOutputDegrees.Text = Str(Val(txtOutputDegrees.Text))
    End Sub

    Private Sub txtOutputMinutes_LostFocus(sender As Object, e As EventArgs) Handles txtOutputMinutes.LostFocus
        txtOutputMinutes.Text = Str(Val(txtOutputMinutes.Text))
    End Sub

    Private Sub txtOutputSeconds_LostFocus(sender As Object, e As EventArgs) Handles txtOutputSeconds.LostFocus
        txtOutputSeconds.Text = Str(Val(txtOutputSeconds.Text))
    End Sub

    Private Sub txtOutputAngle_LostFocus(sender As Object, e As EventArgs) Handles txtOutputAngle.LostFocus
        txtOutputAngle.Text = Str(Val(txtOutputAngle.Text))
    End Sub


#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Events - Events that can be triggered by this form." '--------------------------------------------------------------------------------------------------------------------------
#End Region 'Form Events ----------------------------------------------------------------------------------------------------------------------------------------------------------------------



End Class