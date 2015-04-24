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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.EditExceptionMode = New System.Windows.Forms.Button()
        Me.UnPakRes = New System.ComponentModel.BackgroundWorker()
        Me.ChangeSpecialModeMusic = New System.Windows.Forms.Button()
        Me.InitAll = New System.Windows.Forms.Button()
        Me.SaveChanges = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 288)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(461, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Status
        '
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(0, 17)
        '
        'EditExceptionMode
        '
        Me.EditExceptionMode.Enabled = False
        Me.EditExceptionMode.Location = New System.Drawing.Point(13, 13)
        Me.EditExceptionMode.Name = "EditExceptionMode"
        Me.EditExceptionMode.Size = New System.Drawing.Size(436, 35)
        Me.EditExceptionMode.TabIndex = 1
        Me.EditExceptionMode.Text = "例外設定の編集"
        Me.EditExceptionMode.UseVisualStyleBackColor = True
        '
        'UnPakRes
        '
        '
        'ChangeSpecialModeMusic
        '
        Me.ChangeSpecialModeMusic.Enabled = False
        Me.ChangeSpecialModeMusic.Location = New System.Drawing.Point(13, 54)
        Me.ChangeSpecialModeMusic.Name = "ChangeSpecialModeMusic"
        Me.ChangeSpecialModeMusic.Size = New System.Drawing.Size(436, 35)
        Me.ChangeSpecialModeMusic.TabIndex = 2
        Me.ChangeSpecialModeMusic.Text = "specialモードの音声の変更"
        Me.ChangeSpecialModeMusic.UseVisualStyleBackColor = True
        '
        'InitAll
        '
        Me.InitAll.Enabled = False
        Me.InitAll.Location = New System.Drawing.Point(13, 95)
        Me.InitAll.Name = "InitAll"
        Me.InitAll.Size = New System.Drawing.Size(436, 35)
        Me.InitAll.TabIndex = 3
        Me.InitAll.Text = "設定と音声の初期化"
        Me.InitAll.UseVisualStyleBackColor = True
        '
        'SaveChanges
        '
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 310)
        Me.Controls.Add(Me.InitAll)
        Me.Controls.Add(Me.ChangeSpecialModeMusic)
        Me.Controls.Add(Me.EditExceptionMode)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Main"
        Me.Text = "FileHacker リソースマネージャー"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents EditExceptionMode As System.Windows.Forms.Button
    Friend WithEvents UnPakRes As System.ComponentModel.BackgroundWorker
    Friend WithEvents ChangeSpecialModeMusic As System.Windows.Forms.Button
    Friend WithEvents InitAll As System.Windows.Forms.Button
    Friend WithEvents SaveChanges As System.ComponentModel.BackgroundWorker

End Class
