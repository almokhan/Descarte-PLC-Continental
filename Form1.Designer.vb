<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        MonitorTimer = New Timer(components)
        qrtextbox = New TextBox()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' MonitorTimer
        ' 
        MonitorTimer.Enabled = True
        MonitorTimer.Interval = 1
        ' 
        ' qrtextbox
        ' 
        qrtextbox.Location = New Point(40, 29)
        qrtextbox.Name = "qrtextbox"
        qrtextbox.Size = New Size(374, 23)
        qrtextbox.TabIndex = 6
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(40, 83)
        Label2.Name = "Label2"
        Label2.Size = New Size(132, 20)
        Label2.TabIndex = 7
        Label2.Text = "Escaneie o código"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(518, 156)
        Controls.Add(Label2)
        Controls.Add(qrtextbox)
        Name = "Form1"
        Text = "Descarte de peças"
        TopMost = True
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MonitorTimer As Timer
    Friend WithEvents qrtextbox As TextBox
    Friend WithEvents Label2 As Label
End Class
