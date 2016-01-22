'****************************************************************************
'
'   Scanner Control SDK Test Program
'
'   Copyright(C) PFU LIMITED 2005-2006
'
'****************************************************************************
Public Class FormSoftIPC
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
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstTemplate As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstTemplate = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonOK
        '
        Me.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButtonOK.Location = New System.Drawing.Point(288, 16)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(72, 24)
        Me.ButtonOK.TabIndex = 0
        Me.ButtonOK.Text = "OK"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButtonCancel.Location = New System.Drawing.Point(288, 48)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(72, 24)
        Me.ButtonCancel.TabIndex = 1
        Me.ButtonCancel.Text = "Cancel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstTemplate, Me.Label1})
        Me.GroupBox1.Location = New System.Drawing.Point(16, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 168)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'lstTemplate
        '
        Me.lstTemplate.ItemHeight = 15
        Me.lstTemplate.Location = New System.Drawing.Point(16, 32)
        Me.lstTemplate.Name = "lstTemplate"
        Me.lstTemplate.Size = New System.Drawing.Size(224, 124)
        Me.lstTemplate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Template List:"
        '
        'FormSoftIPC
        '
        Me.AcceptButton = Me.ButtonOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(368, 190)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.ButtonCancel, Me.ButtonOK})
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSoftIPC"
        Me.Text = "SoftIPC Template"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '----------------------------------------------------------------------------
    '   Function    : The form was loaded
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub FormSoftIPC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim count As Short
        Dim Index As Short
        Dim strName As String

        '1) When a template exists
        '    A template list is created.
        '    The current template is chosen.
        '2) When a template does not exist
        '    The OK button and tempalte list are disabled.
        count = FormScan.CurrentInstance.AxFiScn1.GetSIpcTemplateCount
        If count < 1 Then
            ButtonOK.Enabled = False
            lstTemplate.Enabled = False
            Exit Sub
        End If
        For Index = 0 To count - 1
            strName = FormScan.CurrentInstance.AxFiScn1.GetSIpcTemplateName(Index)
            lstTemplate.Items.Add((strName))
        Next Index
        Index = FormScan.CurrentInstance.AxFiScn1.GetSIpcTemplateSelect
        lstTemplate.SelectedIndex = Index
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "OK" button was pushed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        'The selected template is set up
        FormScan.CurrentInstance.AxFiScn1.SetSIpcTemplateSelect(lstTemplate.SelectedIndex)
        Me.Close()
    End Sub
End Class
