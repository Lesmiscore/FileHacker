<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DecryptFiles
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ConfiscatedFiles = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FoundFiles = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FileSearcher = New System.ComponentModel.BackgroundWorker()
        Me.FileConfiscater = New System.ComponentModel.BackgroundWorker()
        Me.FormUpdater = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'ConfiscatedFiles
        '
        Me.ConfiscatedFiles.AutoSize = True
        Me.ConfiscatedFiles.Location = New System.Drawing.Point(113, 21)
        Me.ConfiscatedFiles.Name = "ConfiscatedFiles"
        Me.ConfiscatedFiles.Size = New System.Drawing.Size(11, 12)
        Me.ConfiscatedFiles.TabIndex = 7
        Me.ConfiscatedFiles.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "処理したファイル数:"
        '
        'FoundFiles
        '
        Me.FoundFiles.AutoSize = True
        Me.FoundFiles.Location = New System.Drawing.Point(113, 9)
        Me.FoundFiles.Name = "FoundFiles"
        Me.FoundFiles.Size = New System.Drawing.Size(11, 12)
        Me.FoundFiles.TabIndex = 5
        Me.FoundFiles.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "未処理のファイル数:"
        '
        'DecryptFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 45)
        Me.Controls.Add(Me.ConfiscatedFiles)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.FoundFiles)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DecryptFiles"
        Me.Text = "復元"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ConfiscatedFiles As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FoundFiles As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FileSearcher As System.ComponentModel.BackgroundWorker
    Friend WithEvents FileConfiscater As System.ComponentModel.BackgroundWorker
    Friend WithEvents FormUpdater As System.ComponentModel.BackgroundWorker
End Class
