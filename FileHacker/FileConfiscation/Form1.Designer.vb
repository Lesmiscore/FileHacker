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
        Me.FolderName = New System.Windows.Forms.TextBox()
        Me.StartWipe = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "フォルダパス:"
        '
        'FolderName
        '
        Me.FolderName.Location = New System.Drawing.Point(78, 10)
        Me.FolderName.Name = "FolderName"
        Me.FolderName.Size = New System.Drawing.Size(194, 19)
        Me.FolderName.TabIndex = 1
        '
        'StartWipe
        '
        Me.StartWipe.Location = New System.Drawing.Point(15, 38)
        Me.StartWipe.Name = "StartWipe"
        Me.StartWipe.Size = New System.Drawing.Size(75, 23)
        Me.StartWipe.TabIndex = 2
        Me.StartWipe.Text = "没収実行"
        Me.StartWipe.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 71)
        Me.Controls.Add(Me.StartWipe)
        Me.Controls.Add(Me.FolderName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Form1"
        Me.Text = "ファイル没収"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FolderName As System.Windows.Forms.TextBox
    Friend WithEvents StartWipe As System.Windows.Forms.Button

End Class
