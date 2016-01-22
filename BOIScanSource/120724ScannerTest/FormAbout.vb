'****************************************************************************
'
'   Scanner Control SDK Test Program
'
'   Copyright PFU LIMITED 2005-2011
'
'****************************************************************************
Public Class FormAbout
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

    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonOCXVer As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblInformation As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ButtonOK = New System.Windows.Forms.Button
        Me.ButtonOCXVer = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblInformation = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ButtonOK
        '
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButtonOK.Location = New System.Drawing.Point(320, 16)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(88, 24)
        Me.ButtonOK.TabIndex = 0
        Me.ButtonOK.Text = "OK"
        '
        'ButtonOCXVer
        '
        Me.ButtonOCXVer.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButtonOCXVer.Location = New System.Drawing.Point(320, 48)
        Me.ButtonOCXVer.Name = "ButtonOCXVer"
        Me.ButtonOCXVer.Size = New System.Drawing.Size(88, 24)
        Me.ButtonOCXVer.TabIndex = 1
        Me.ButtonOCXVer.Text = "OCX Version"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fujitsu Scanner Control SDK"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(72, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Visual Basic Sample Program"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "fiScanTest"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(160, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Version : 2.1"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(360, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Copyright PFU LIMITED 2005-2011"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblInformation
        '
        Me.lblInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInformation.Location = New System.Drawing.Point(24, 120)
        Me.lblInformation.Name = "lblInformation"
        Me.lblInformation.Size = New System.Drawing.Size(360, 16)
        Me.lblInformation.TabIndex = 7
        Me.lblInformation.Text = "Information :"
        '
        'FormAbout
        '
        Me.AcceptButton = Me.ButtonOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.ButtonOK
        Me.ClientSize = New System.Drawing.Size(416, 150)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInformation, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.ButtonOCXVer, Me.ButtonOK})
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAbout"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "About"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '----------------------------------------------------------------------------
    '   Function    : The form was loaded
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub FormAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'An image scanner name and flatbed existence are displayed.
        'When the scanner is not yet opened, it is displayed as "Not OpenScanner".
        If blnOpenScanner = False Then
            lblInformation.Text = "Information : Not OpenScanner"
            Exit Sub
        End If

        If FormScan.CurrentInstance.AxFiScn1.IsExistsFB = False Then
            If blnFjtwn = True Then
                lblInformation.Text = "Information : " & FormScan.CurrentInstance.AxFiScn1.ImageScanner & " Not Flatbed"
            Else
                lblInformation.Text = "Information : " & "  Not FUJITSU TWAIN32 Driver  " & " : (Not Flatbed)"
            End If
        Else
            If blnFjtwn = True Then
                lblInformation.Text = "Information : " & FormScan.CurrentInstance.AxFiScn1.ImageScanner & " With Flatbed"
            Else
                lblInformation.Text = "Information : " & "  Not FUJITSU TWAIN32 Driver  " & " : (With Flatbed)"
            End If
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "OCX Version" button was pushed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub ButtonOCXVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOCXVer.Click
        FormScan.CurrentInstance.AxFiScn1.AboutBox()
    End Sub

End Class
