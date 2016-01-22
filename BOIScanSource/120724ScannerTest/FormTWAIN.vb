'****************************************************************************
'
'   Scanner Control SDK Test Program
'
'   Copyright(C) PFU LIMITED 2005-2009
'
'****************************************************************************
Public Class FormTWAIN
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
        Me.ButtonOK = New System.Windows.Forms.Button
        Me.ButtonCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lstTemplate = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(288, 16)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(72, 24)
        Me.ButtonOK.TabIndex = 0
        Me.ButtonOK.Text = "OK"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
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
        Me.lstTemplate.ItemHeight = 12
        Me.lstTemplate.Location = New System.Drawing.Point(16, 40)
        Me.lstTemplate.Name = "lstTemplate"
        Me.lstTemplate.Size = New System.Drawing.Size(224, 112)
        Me.lstTemplate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Template List:"
        '
        'FormTWAIN
        '
        Me.AcceptButton = Me.ButtonOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(368, 190)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.ButtonCancel, Me.ButtonOK})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormTWAIN"
        Me.Text = "TWAIN Template"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '----------------------------------------------------------------------------
    '   Function    : The form was loaded
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub FormTWAIN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim count As Short
        Dim Index As Short
        Dim strName As String

        '1) When a template exists
        '    A template list is created.
        '    The current template is chosen.
        '2) When a template does not exist
        '    The OK button and tempalte list are disabled.
        count = FormScan.CurrentInstance.AxFiScn1.GetTWAINTemplateCount
        If count < 1 Then
            ButtonOK.Enabled = False
            lstTemplate.Enabled = False
            Exit Sub
        End If
        For Index = 0 To count - 1
            strName = FormScan.CurrentInstance.AxFiScn1.GetTWAINTemplateName(Index)
            lstTemplate.Items.Add((strName))
        Next Index
        Index = FormScan.CurrentInstance.AxFiScn1.GetTWAINTemplateSelect
        lstTemplate.SelectedIndex = Index
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "OK" button was pushed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        FormScan.CurrentInstance.AxFiScn1.SourceCurrentScan = FormScan.CurrentInstance.MenuItemSourceCurrentScan.Checked
        'The selected template is set up
        FormScan.CurrentInstance.AxFiScn1.SetTWAINTemplateSelect(lstTemplate.SelectedIndex)
        Me.Close()
    End Sub
End Class
