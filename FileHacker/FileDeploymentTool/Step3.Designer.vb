<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Step3
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
        Me.SelectFile = New System.Windows.Forms.Button()
        Me.FileName = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.StartGet = New System.Windows.Forms.Button()
        Me.FileSaver = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(420, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ファイルを取得できます。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ただし、暗号化されたファイルを書き出してから復号するため、時間がかかることがあります。"
        '
        'SelectFile
        '
        Me.SelectFile.Location = New System.Drawing.Point(15, 41)
        Me.SelectFile.Name = "SelectFile"
        Me.SelectFile.Size = New System.Drawing.Size(75, 23)
        Me.SelectFile.TabIndex = 1
        Me.SelectFile.Text = "選択"
        Me.SelectFile.UseVisualStyleBackColor = True
        '
        'FileName
        '
        Me.FileName.AutoSize = True
        Me.FileName.Location = New System.Drawing.Point(96, 46)
        Me.FileName.Name = "FileName"
        Me.FileName.Size = New System.Drawing.Size(0, 12)
        Me.FileName.TabIndex = 2
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "MP4動画ファイル|*.mp4"
        Me.SaveFileDialog1.Title = "保存先を選択"
        '
        'StartGet
        '
        Me.StartGet.Location = New System.Drawing.Point(15, 71)
        Me.StartGet.Name = "StartGet"
        Me.StartGet.Size = New System.Drawing.Size(75, 23)
        Me.StartGet.TabIndex = 3
        Me.StartGet.Text = "取得実行"
        Me.StartGet.UseVisualStyleBackColor = True
        '
        'FileSaver
        '
        '
        'Step3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 108)
        Me.Controls.Add(Me.StartGet)
        Me.Controls.Add(Me.FileName)
        Me.Controls.Add(Me.SelectFile)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Step3"
        Me.Text = "Step3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SelectFile As System.Windows.Forms.Button
    Friend WithEvents FileName As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents StartGet As System.Windows.Forms.Button
    Friend WithEvents FileSaver As System.ComponentModel.BackgroundWorker
End Class
