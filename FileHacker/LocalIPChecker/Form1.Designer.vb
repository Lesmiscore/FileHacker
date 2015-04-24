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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.IPCheckStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.IPList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PortNum = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StartCheck = New System.Windows.Forms.Button()
        Me.Checker = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PortNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IPCheckStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 239)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(284, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'IPCheckStatus
        '
        Me.IPCheckStatus.Name = "IPCheckStatus"
        Me.IPCheckStatus.Size = New System.Drawing.Size(0, 17)
        '
        'IPList
        '
        Me.IPList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IPList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.IPList.Location = New System.Drawing.Point(13, 39)
        Me.IPList.Name = "IPList"
        Me.IPList.Size = New System.Drawing.Size(259, 197)
        Me.IPList.TabIndex = 1
        Me.IPList.UseCompatibleStateImageBehavior = False
        Me.IPList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IPアドレス"
        Me.ColumnHeader1.Width = 300
        '
        'PortNum
        '
        Me.PortNum.Location = New System.Drawing.Point(52, 11)
        Me.PortNum.Maximum = New Decimal(New Integer() {65536, 0, 0, 0})
        Me.PortNum.Name = "PortNum"
        Me.PortNum.Size = New System.Drawing.Size(70, 19)
        Me.PortNum.TabIndex = 2
        Me.PortNum.Value = New Decimal(New Integer() {80, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ポート"
        '
        'StartCheck
        '
        Me.StartCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StartCheck.Location = New System.Drawing.Point(197, 8)
        Me.StartCheck.Name = "StartCheck"
        Me.StartCheck.Size = New System.Drawing.Size(75, 23)
        Me.StartCheck.TabIndex = 4
        Me.StartCheck.Text = "開始"
        Me.StartCheck.UseVisualStyleBackColor = True
        '
        'Checker
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.StartCheck)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PortNum)
        Me.Controls.Add(Me.IPList)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.Text = "ローカルIPチェッカー"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PortNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents IPCheckStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents IPList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PortNum As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StartCheck As System.Windows.Forms.Button
    Friend WithEvents Checker As System.ComponentModel.BackgroundWorker

End Class
