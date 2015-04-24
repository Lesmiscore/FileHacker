<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Step2
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
        Me.Password = New System.Windows.Forms.MaskedTextBox()
        Me.ValidateAndContinue = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(306, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "このユーザーのパスワードを入力して下さい。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "デタラメなパスワードはダメです。USBのパスワードではありません。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ここにパスワードを入力しないと、次に100%進" & _
    "めません。"
        '
        'Password
        '
        Me.Password.Location = New System.Drawing.Point(15, 53)
        Me.Password.Name = "Password"
        Me.Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.Password.Size = New System.Drawing.Size(304, 19)
        Me.Password.TabIndex = 1
        '
        'ValidateAndContinue
        '
        Me.ValidateAndContinue.Location = New System.Drawing.Point(15, 79)
        Me.ValidateAndContinue.Name = "ValidateAndContinue"
        Me.ValidateAndContinue.Size = New System.Drawing.Size(83, 23)
        Me.ValidateAndContinue.TabIndex = 2
        Me.ValidateAndContinue.Text = "検証して続行"
        Me.ValidateAndContinue.UseVisualStyleBackColor = True
        '
        'Step2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 113)
        Me.Controls.Add(Me.ValidateAndContinue)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Step2"
        Me.Text = "Step2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Password As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ValidateAndContinue As System.Windows.Forms.Button
End Class
