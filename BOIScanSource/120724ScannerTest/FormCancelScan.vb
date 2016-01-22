'****************************************************************************
'
'   Scanner Control SDK Test Program
'
'   Copyright PFU LIMITED 2011
'
'****************************************************************************
Public Class FormCancelScan
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ButtonCancelScan As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ButtonCancelScan = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ButtonCancelScan
        '
        Me.ButtonCancelScan.Location = New System.Drawing.Point(59, 35)
        Me.ButtonCancelScan.Name = "ButtonCancelScan"
        Me.ButtonCancelScan.TabIndex = 0
        Me.ButtonCancelScan.Text = "CancelScan"
        '
        'FormCancelScan
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(192, 93)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonCancelScan)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCancelScan"
        Me.Text = "CancelScan"
        Me.ResumeLayout(False)

    End Sub

#End Region


    '----------------------------------------------------------------------------
    '   Function    : CancelScan button processing
    '   Argument    : Nothing
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub ButtonCancelScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancelScan.Click
        bCancelScan = True
    End Sub
End Class
