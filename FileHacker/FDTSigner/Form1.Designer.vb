<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderPath = New System.Windows.Forms.Label()
        Me.FileSelect = New System.Windows.Forms.Button()
        Me.FileSelecter = New System.Windows.Forms.OpenFileDialog()
        Me.StartSign = New System.Windows.Forms.Button()
        Me.Signer = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ファイル展開ツールのフォルダ"
        '
        'FolderPath
        '
        Me.FolderPath.AutoSize = True
        Me.FolderPath.Location = New System.Drawing.Point(13, 36)
        Me.FolderPath.Name = "FolderPath"
        Me.FolderPath.Size = New System.Drawing.Size(0, 12)
        Me.FolderPath.TabIndex = 1
        '
        'FileSelect
        '
        Me.FileSelect.Location = New System.Drawing.Point(197, 8)
        Me.FileSelect.Name = "FileSelect"
        Me.FileSelect.Size = New System.Drawing.Size(75, 23)
        Me.FileSelect.TabIndex = 2
        Me.FileSelect.Text = "選択"
        Me.FileSelect.UseVisualStyleBackColor = True
        '
        'FileSelecter
        '
        Me.FileSelecter.Filter = "EXEファイル|*.exe|ファイル展開ツール|FileDeploymentTool.exe"
        '
        'StartSign
        '
        Me.StartSign.Location = New System.Drawing.Point(13, 71)
        Me.StartSign.Name = "StartSign"
        Me.StartSign.Size = New System.Drawing.Size(75, 23)
        Me.StartSign.TabIndex = 3
        Me.StartSign.Text = "署名開始"
        Me.StartSign.UseVisualStyleBackColor = True
        '
        'Signer
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 99)
        Me.Controls.Add(Me.StartSign)
        Me.Controls.Add(Me.FileSelect)
        Me.Controls.Add(Me.FolderPath)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "署名ツール"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FolderPath As System.Windows.Forms.Label
    Friend WithEvents FileSelect As System.Windows.Forms.Button
    Friend WithEvents FileSelecter As System.Windows.Forms.OpenFileDialog
    Friend WithEvents StartSign As System.Windows.Forms.Button
    Friend WithEvents Signer As System.ComponentModel.BackgroundWorker

End Class
