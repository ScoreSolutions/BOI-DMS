<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompany
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
        Me.btnCompany = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnCompany
        '
        Me.btnCompany.Location = New System.Drawing.Point(12, 39)
        Me.btnCompany.Name = "btnCompany"
        Me.btnCompany.Size = New System.Drawing.Size(90, 23)
        Me.btnCompany.TabIndex = 0
        Me.btnCompany.Text = "Add Company"
        Me.btnCompany.UseVisualStyleBackColor = True
        '
        'frmCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 152)
        Me.Controls.Add(Me.btnCompany)
        Me.Name = "frmCompany"
        Me.Text = "frmCompany"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCompany As System.Windows.Forms.Button
End Class
