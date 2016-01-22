<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateDocumentStatus
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
        Me.components = New System.ComponentModel.Container
        Me.btnStart = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.lblTotal = New System.Windows.Forms.Label
        Me.lblCurrent = New System.Windows.Forms.Label
        Me.lblTime = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtBookNo = New System.Windows.Forms.TextBox
        Me.lblMonth = New System.Windows.Forms.Label
        Me.cmbOrgID = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtMonthFrom = New System.Windows.Forms.TextBox
        Me.txtMonthTo = New System.Windows.Forms.TextBox
        Me.txtYearTo = New System.Windows.Forms.TextBox
        Me.txtYear = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(309, 38)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(60, 20)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "เริ่ม"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 130)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(360, 23)
        Me.ProgressBar1.TabIndex = 3
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(123, 114)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(37, 13)
        Me.lblTotal.TabIndex = 4
        Me.lblTotal.Text = "Total :"
        '
        'lblCurrent
        '
        Me.lblCurrent.AutoSize = True
        Me.lblCurrent.Location = New System.Drawing.Point(220, 114)
        Me.lblCurrent.Name = "lblCurrent"
        Me.lblCurrent.Size = New System.Drawing.Size(47, 13)
        Me.lblCurrent.TabIndex = 5
        Me.lblCurrent.Text = "Current :"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(320, 114)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(49, 13)
        Me.lblTime.TabIndex = 6
        Me.lblTime.Text = "00:00:00"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(232, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "เลขที่หนังสือ"
        '
        'txtBookNo
        '
        Me.txtBookNo.Location = New System.Drawing.Point(291, 12)
        Me.txtBookNo.Name = "txtBookNo"
        Me.txtBookNo.Size = New System.Drawing.Size(82, 20)
        Me.txtBookNo.TabIndex = 14
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(14, 114)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(37, 13)
        Me.lblMonth.TabIndex = 9
        Me.lblMonth.Text = "Month"
        '
        'cmbOrgID
        '
        Me.cmbOrgID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrgID.FormattingEnabled = True
        Me.cmbOrgID.Location = New System.Drawing.Point(58, 64)
        Me.cmbOrgID.Name = "cmbOrgID"
        Me.cmbOrgID.Size = New System.Drawing.Size(311, 21)
        Me.cmbOrgID.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "เดือนที่"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(127, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(127, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "-"
        '
        'txtMonthFrom
        '
        Me.txtMonthFrom.Location = New System.Drawing.Point(58, 38)
        Me.txtMonthFrom.Name = "txtMonthFrom"
        Me.txtMonthFrom.Size = New System.Drawing.Size(58, 20)
        Me.txtMonthFrom.TabIndex = 10
        Me.txtMonthFrom.Text = "1"
        '
        'txtMonthTo
        '
        Me.txtMonthTo.Location = New System.Drawing.Point(152, 38)
        Me.txtMonthTo.Name = "txtMonthTo"
        Me.txtMonthTo.Size = New System.Drawing.Size(58, 20)
        Me.txtMonthTo.TabIndex = 12
        Me.txtMonthTo.Text = "12"
        '
        'txtYearTo
        '
        Me.txtYearTo.Location = New System.Drawing.Point(152, 12)
        Me.txtYearTo.Name = "txtYearTo"
        Me.txtYearTo.Size = New System.Drawing.Size(58, 20)
        Me.txtYearTo.TabIndex = 7
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(58, 12)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(58, 20)
        Me.txtYear.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ปี ค.ศ."
        '
        'frmUpdateDocumentNoMovement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 165)
        Me.Controls.Add(Me.cmbOrgID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtBookNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMonthTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMonthFrom)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtYearTo)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblCurrent)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtYear)
        Me.Name = "frmUpdateDocumentNoMovement"
        Me.Text = "Update Document No Movement"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblCurrent As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBookNo As System.Windows.Forms.TextBox
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents cmbOrgID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMonthFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtMonthTo As System.Windows.Forms.TextBox
    Friend WithEvents txtYearTo As System.Windows.Forms.TextBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
