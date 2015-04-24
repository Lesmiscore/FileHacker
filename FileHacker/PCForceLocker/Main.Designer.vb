<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.SystemLock = New System.Windows.Forms.CheckBox()
        Me.ApplicationLock = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MaskedTextBox2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DoWithFileHacker = New System.Windows.Forms.CheckBox()
        Me.LockFromFileHacker = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SystemLock
        '
        Me.SystemLock.AutoSize = True
        Me.SystemLock.Location = New System.Drawing.Point(12, 13)
        Me.SystemLock.Name = "SystemLock"
        Me.SystemLock.Size = New System.Drawing.Size(95, 16)
        Me.SystemLock.TabIndex = 0
        Me.SystemLock.Text = "システムをロック"
        Me.SystemLock.UseVisualStyleBackColor = True
        '
        'ApplicationLock
        '
        Me.ApplicationLock.AutoSize = True
        Me.ApplicationLock.Location = New System.Drawing.Point(12, 35)
        Me.ApplicationLock.Name = "ApplicationLock"
        Me.ApplicationLock.Size = New System.Drawing.Size(139, 16)
        Me.ApplicationLock.TabIndex = 1
        Me.ApplicationLock.Text = "アプリケーション側でロック"
        Me.ApplicationLock.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.MaskedTextBox2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.MaskedTextBox1)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(12, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 72)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "アプリケーション側でロック"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "確認"
        '
        'MaskedTextBox2
        '
        Me.MaskedTextBox2.Location = New System.Drawing.Point(70, 44)
        Me.MaskedTextBox2.Name = "MaskedTextBox2"
        Me.MaskedTextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(29577)
        Me.MaskedTextBox2.Size = New System.Drawing.Size(184, 19)
        Me.MaskedTextBox2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "パスワード"
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Location = New System.Drawing.Point(70, 19)
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(37329)
        Me.MaskedTextBox1.Size = New System.Drawing.Size(184, 19)
        Me.MaskedTextBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 136)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "開始"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DoWithFileHacker
        '
        Me.DoWithFileHacker.AutoSize = True
        Me.DoWithFileHacker.Location = New System.Drawing.Point(113, 12)
        Me.DoWithFileHacker.Name = "DoWithFileHacker"
        Me.DoWithFileHacker.Size = New System.Drawing.Size(153, 16)
        Me.DoWithFileHacker.TabIndex = 4
        Me.DoWithFileHacker.Text = "FileHackerに手伝ってもらう"
        Me.DoWithFileHacker.UseVisualStyleBackColor = True
        '
        'LockFromFileHacker
        '
        Me.LockFromFileHacker.AutoSize = True
        Me.LockFromFileHacker.Location = New System.Drawing.Point(148, 35)
        Me.LockFromFileHacker.Name = "LockFromFileHacker"
        Me.LockFromFileHacker.Size = New System.Drawing.Size(137, 16)
        Me.LockFromFileHacker.TabIndex = 5
        Me.LockFromFileHacker.Text = "FileHackerのせいにする"
        Me.LockFromFileHacker.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 162)
        Me.Controls.Add(Me.LockFromFileHacker)
        Me.Controls.Add(Me.DoWithFileHacker)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ApplicationLock)
        Me.Controls.Add(Me.SystemLock)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Form1"
        Me.Text = "システム強制ロックツール"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SystemLock As System.Windows.Forms.CheckBox
    Friend WithEvents ApplicationLock As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MaskedTextBox2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DoWithFileHacker As System.Windows.Forms.CheckBox
    Friend WithEvents LockFromFileHacker As System.Windows.Forms.CheckBox

End Class
