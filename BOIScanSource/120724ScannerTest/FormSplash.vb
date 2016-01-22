'****************************************************************************
'
'   Scanner Control SDK Test Program
'
'   Copyright PFU LIMITED 2005-2011
'
'****************************************************************************
Public Class FormSplash
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        InitializeComponent()

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblProductName2 As System.Windows.Forms.Label
    Friend WithEvents lblProductName1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblCopyright = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.lblProductName2 = New System.Windows.Forms.Label
        Me.lblProductName1 = New System.Windows.Forms.Label
        Me.GroupBox = New System.Windows.Forms.GroupBox
        Me.GroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCopyright
        '
        Me.lblCopyright.Location = New System.Drawing.Point(32, 104)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(304, 16)
        Me.lblCopyright.TabIndex = 4
        Me.lblCopyright.Text = "Copyright PFU LIMITED 2005-2011"
        Me.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(184, 80)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(112, 16)
        Me.lblVersion.TabIndex = 3
        Me.lblVersion.Text = "Version: 2.1"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(72, 80)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(88, 16)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "fiScanTest"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProductName2
        '
        Me.lblProductName2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductName2.Location = New System.Drawing.Point(16, 48)
        Me.lblProductName2.Name = "lblProductName2"
        Me.lblProductName2.Size = New System.Drawing.Size(336, 24)
        Me.lblProductName2.TabIndex = 1
        Me.lblProductName2.Text = "Visual Basic Sample Program"
        Me.lblProductName2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProductName1
        '
        Me.lblProductName1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductName1.Location = New System.Drawing.Point(16, 24)
        Me.lblProductName1.Name = "lblProductName1"
        Me.lblProductName1.Size = New System.Drawing.Size(336, 24)
        Me.lblProductName1.TabIndex = 0
        Me.lblProductName1.Text = "Fujitsu Scanner Control SDK"
        Me.lblProductName1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox
        '
        Me.GroupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblVersion, Me.lblCopyright, Me.lblTitle, Me.lblProductName2, Me.lblProductName1})
        Me.GroupBox.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(368, 136)
        Me.GroupBox.TabIndex = 5
        Me.GroupBox.TabStop = False
        '
        'FormSplash
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(384, 160)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox})
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSplash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
