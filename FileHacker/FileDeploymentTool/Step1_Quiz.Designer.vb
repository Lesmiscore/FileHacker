<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Step1_Quiz
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
        Me.MoreQuiz = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.QuizData = New System.Windows.Forms.Label()
        Me.TextReading = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'MoreQuiz
        '
        Me.MoreQuiz.Location = New System.Drawing.Point(88, 118)
        Me.MoreQuiz.Name = "MoreQuiz"
        Me.MoreQuiz.Size = New System.Drawing.Size(75, 23)
        Me.MoreQuiz.TabIndex = 9
        Me.MoreQuiz.Text = "他の問題"
        Me.MoreQuiz.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(7, 118)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 8
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(7, 93)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(265, 19)
        Me.TextBox1.TabIndex = 7
        '
        'QuizData
        '
        Me.QuizData.AutoSize = True
        Me.QuizData.Location = New System.Drawing.Point(5, 9)
        Me.QuizData.Name = "QuizData"
        Me.QuizData.Size = New System.Drawing.Size(0, 12)
        Me.QuizData.TabIndex = 5
        '
        'TextReading
        '
        Me.TextReading.Location = New System.Drawing.Point(197, 118)
        Me.TextReading.Name = "TextReading"
        Me.TextReading.Size = New System.Drawing.Size(75, 23)
        Me.TextReading.TabIndex = 10
        Me.TextReading.Text = "文字読み"
        Me.TextReading.UseVisualStyleBackColor = True
        '
        'Step1_Quiz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 150)
        Me.Controls.Add(Me.TextReading)
        Me.Controls.Add(Me.MoreQuiz)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.QuizData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Step1_Quiz"
        Me.Text = "Step1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MoreQuiz As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents QuizData As System.Windows.Forms.Label
    Friend WithEvents TextReading As System.Windows.Forms.Button
End Class
