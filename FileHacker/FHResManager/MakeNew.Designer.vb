<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MakeNew
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.debug = New System.Windows.Forms.RadioButton()
        Me.spnc = New System.Windows.Forms.RadioButton()
        Me.nocopy = New System.Windows.Forms.RadioButton()
        Me.special = New System.Windows.Forms.RadioButton()
        Me.allow = New System.Windows.Forms.RadioButton()
        Me.normal = New System.Windows.Forms.RadioButton()
        Me.strict = New System.Windows.Forms.RadioButton()
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.debug)
        Me.Panel1.Controls.Add(Me.spnc)
        Me.Panel1.Controls.Add(Me.nocopy)
        Me.Panel1.Controls.Add(Me.special)
        Me.Panel1.Controls.Add(Me.allow)
        Me.Panel1.Controls.Add(Me.normal)
        Me.Panel1.Controls.Add(Me.strict)
        Me.Panel1.Location = New System.Drawing.Point(12, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(259, 86)
        Me.Panel1.TabIndex = 0
        '
        'debug
        '
        Me.debug.AutoSize = True
        Me.debug.Location = New System.Drawing.Point(135, 14)
        Me.debug.Name = "debug"
        Me.debug.Size = New System.Drawing.Size(53, 16)
        Me.debug.TabIndex = 6
        Me.debug.Text = "debug"
        Me.debug.UseVisualStyleBackColor = True
        '
        'spnc
        '
        Me.spnc.AutoSize = True
        Me.spnc.Location = New System.Drawing.Point(70, 58)
        Me.spnc.Name = "spnc"
        Me.spnc.Size = New System.Drawing.Size(47, 16)
        Me.spnc.TabIndex = 5
        Me.spnc.Text = "spnc"
        Me.spnc.UseVisualStyleBackColor = True
        '
        'nocopy
        '
        Me.nocopy.AutoSize = True
        Me.nocopy.Location = New System.Drawing.Point(70, 36)
        Me.nocopy.Name = "nocopy"
        Me.nocopy.Size = New System.Drawing.Size(59, 16)
        Me.nocopy.TabIndex = 4
        Me.nocopy.Text = "nocopy"
        Me.nocopy.UseVisualStyleBackColor = True
        '
        'special
        '
        Me.special.AutoSize = True
        Me.special.Location = New System.Drawing.Point(70, 14)
        Me.special.Name = "special"
        Me.special.Size = New System.Drawing.Size(59, 16)
        Me.special.TabIndex = 3
        Me.special.Text = "special"
        Me.special.UseVisualStyleBackColor = True
        '
        'allow
        '
        Me.allow.AutoSize = True
        Me.allow.Checked = True
        Me.allow.Location = New System.Drawing.Point(14, 58)
        Me.allow.Name = "allow"
        Me.allow.Size = New System.Drawing.Size(49, 16)
        Me.allow.TabIndex = 2
        Me.allow.TabStop = True
        Me.allow.Text = "allow"
        Me.allow.UseVisualStyleBackColor = True
        '
        'normal
        '
        Me.normal.AutoSize = True
        Me.normal.Location = New System.Drawing.Point(14, 36)
        Me.normal.Name = "normal"
        Me.normal.Size = New System.Drawing.Size(57, 16)
        Me.normal.TabIndex = 1
        Me.normal.Text = "normal"
        Me.normal.UseVisualStyleBackColor = True
        '
        'strict
        '
        Me.strict.AutoSize = True
        Me.strict.Location = New System.Drawing.Point(14, 14)
        Me.strict.Name = "strict"
        Me.strict.Size = New System.Drawing.Size(50, 16)
        Me.strict.TabIndex = 0
        Me.strict.Text = "strict"
        Me.strict.UseVisualStyleBackColor = True
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(12, 127)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(75, 23)
        Me.OK.TabIndex = 1
        Me.OK.Text = "OK"
        Me.OK.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(197, 127)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Cancel.TabIndex = 2
        Me.Cancel.Text = "キャンセル"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ユーザー名:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(68, 10)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(204, 19)
        Me.TextBox1.TabIndex = 4
        '
        'MakeNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 157)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MakeNew"
        Me.Text = "モード変更"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents debug As System.Windows.Forms.RadioButton
    Friend WithEvents spnc As System.Windows.Forms.RadioButton
    Friend WithEvents nocopy As System.Windows.Forms.RadioButton
    Friend WithEvents special As System.Windows.Forms.RadioButton
    Friend WithEvents allow As System.Windows.Forms.RadioButton
    Friend WithEvents normal As System.Windows.Forms.RadioButton
    Friend WithEvents strict As System.Windows.Forms.RadioButton
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
