<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Step1
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
        Me.VerifyText = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.ReadDifficult = New System.Windows.Forms.Button()
        Me.Quiz = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(267, 48)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "下に表示された文字列を入力して下さい。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "大文字と小文字を区別します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "簡単な事なので、一回間違えると、シャットダウンします。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ただし、閉じた場合は、何も起き" & _
    "ません。"
        '
        'VerifyText
        '
        Me.VerifyText.AutoSize = True
        Me.VerifyText.Location = New System.Drawing.Point(20, 67)
        Me.VerifyText.Name = "VerifyText"
        Me.VerifyText.Size = New System.Drawing.Size(0, 12)
        Me.VerifyText.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(15, 97)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(265, 19)
        Me.TextBox1.TabIndex = 2
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(15, 122)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 3
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'ReadDifficult
        '
        Me.ReadDifficult.Location = New System.Drawing.Point(96, 122)
        Me.ReadDifficult.Name = "ReadDifficult"
        Me.ReadDifficult.Size = New System.Drawing.Size(75, 23)
        Me.ReadDifficult.TabIndex = 4
        Me.ReadDifficult.Text = "よく読めない"
        Me.ReadDifficult.UseVisualStyleBackColor = True
        '
        'Quiz
        '
        Me.Quiz.Location = New System.Drawing.Point(205, 122)
        Me.Quiz.Name = "Quiz"
        Me.Quiz.Size = New System.Drawing.Size(75, 23)
        Me.Quiz.TabIndex = 5
        Me.Quiz.Text = "問題を解く"
        Me.Quiz.UseVisualStyleBackColor = True
        '
        'Step1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 155)
        Me.Controls.Add(Me.Quiz)
        Me.Controls.Add(Me.ReadDifficult)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.VerifyText)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Step1"
        Me.Text = "Step1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents VerifyText As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents ReadDifficult As System.Windows.Forms.Button
    Friend WithEvents Quiz As System.Windows.Forms.Button

End Class
