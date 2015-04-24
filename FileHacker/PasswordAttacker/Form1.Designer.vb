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
        Me.AttackingPassword = New System.Windows.Forms.Label()
        Me.StartAttack = New System.Windows.Forms.Button()
        Me.Attacker = New System.ComponentModel.BackgroundWorker()
        Me.AttackResult = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "検証中:"
        '
        'AttackingPassword
        '
        Me.AttackingPassword.AutoSize = True
        Me.AttackingPassword.Location = New System.Drawing.Point(72, 9)
        Me.AttackingPassword.Name = "AttackingPassword"
        Me.AttackingPassword.Size = New System.Drawing.Size(0, 12)
        Me.AttackingPassword.TabIndex = 2
        '
        'StartAttack
        '
        Me.StartAttack.Location = New System.Drawing.Point(12, 24)
        Me.StartAttack.Name = "StartAttack"
        Me.StartAttack.Size = New System.Drawing.Size(75, 23)
        Me.StartAttack.TabIndex = 3
        Me.StartAttack.Text = "開始"
        Me.StartAttack.UseVisualStyleBackColor = True
        '
        'Attacker
        '
        Me.Attacker.WorkerReportsProgress = True
        Me.Attacker.WorkerSupportsCancellation = True
        '
        'AttackResult
        '
        Me.AttackResult.AutoSize = True
        Me.AttackResult.Location = New System.Drawing.Point(72, 50)
        Me.AttackResult.Name = "AttackResult"
        Me.AttackResult.Size = New System.Drawing.Size(0, 12)
        Me.AttackResult.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "結果:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 76)
        Me.Controls.Add(Me.AttackResult)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.StartAttack)
        Me.Controls.Add(Me.AttackingPassword)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "パスワードアタックツール"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AttackingPassword As System.Windows.Forms.Label
    Friend WithEvents StartAttack As System.Windows.Forms.Button
    Friend WithEvents Attacker As System.ComponentModel.BackgroundWorker
    Friend WithEvents AttackResult As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
