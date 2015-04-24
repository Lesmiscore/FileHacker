<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileHackerAdditionalTools
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
        Me.Wtimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PCID = New System.Windows.Forms.NumericUpDown()
        Me.SSPanel = New System.Windows.Forms.PictureBox()
        Me.ShowSS = New System.Windows.Forms.Button()
        CType(Me.PCID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SSPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Wtimer
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PC番号"
        '
        'PCID
        '
        Me.PCID.Location = New System.Drawing.Point(63, 11)
        Me.PCID.Maximum = New Decimal(New Integer() {36, 0, 0, 0})
        Me.PCID.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.PCID.Name = "PCID"
        Me.PCID.Size = New System.Drawing.Size(87, 19)
        Me.PCID.TabIndex = 1
        Me.PCID.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'SSPanel
        '
        Me.SSPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SSPanel.Location = New System.Drawing.Point(15, 36)
        Me.SSPanel.Name = "SSPanel"
        Me.SSPanel.Size = New System.Drawing.Size(442, 275)
        Me.SSPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SSPanel.TabIndex = 2
        Me.SSPanel.TabStop = False
        '
        'ShowSS
        '
        Me.ShowSS.Location = New System.Drawing.Point(156, 8)
        Me.ShowSS.Name = "ShowSS"
        Me.ShowSS.Size = New System.Drawing.Size(75, 23)
        Me.ShowSS.TabIndex = 3
        Me.ShowSS.Text = "表示"
        Me.ShowSS.UseVisualStyleBackColor = True
        '
        'FileHackerAdditionalTools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 323)
        Me.Controls.Add(Me.ShowSS)
        Me.Controls.Add(Me.SSPanel)
        Me.Controls.Add(Me.PCID)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(485, 362)
        Me.Name = "FileHackerAdditionalTools"
        Me.ShowIcon = False
        Me.Text = "スクリーンショット覗き見"
        CType(Me.PCID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SSPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Wtimer As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PCID As System.Windows.Forms.NumericUpDown
    Friend WithEvents SSPanel As System.Windows.Forms.PictureBox
    Friend WithEvents ShowSS As System.Windows.Forms.Button

End Class
