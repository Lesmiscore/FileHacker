<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditExceptionMode_Form
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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.UserName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Mode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Delete = New System.Windows.Forms.Button()
        Me.MakeNew = New System.Windows.Forms.Button()
        Me.Change = New System.Windows.Forms.Button()
        Me.Apply = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.UserName, Me.Mode})
        Me.ListView1.Location = New System.Drawing.Point(13, 13)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(525, 305)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'UserName
        '
        Me.UserName.Text = "ユーザー名"
        Me.UserName.Width = 159
        '
        'Mode
        '
        Me.Mode.Text = "モード"
        Me.Mode.Width = 165
        '
        'Delete
        '
        Me.Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Delete.Location = New System.Drawing.Point(463, 324)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(75, 23)
        Me.Delete.TabIndex = 1
        Me.Delete.Text = "削除"
        Me.Delete.UseVisualStyleBackColor = True
        '
        'MakeNew
        '
        Me.MakeNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MakeNew.Location = New System.Drawing.Point(301, 324)
        Me.MakeNew.Name = "MakeNew"
        Me.MakeNew.Size = New System.Drawing.Size(75, 23)
        Me.MakeNew.TabIndex = 2
        Me.MakeNew.Text = "新規作成"
        Me.MakeNew.UseVisualStyleBackColor = True
        '
        'Change
        '
        Me.Change.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Change.Location = New System.Drawing.Point(382, 324)
        Me.Change.Name = "Change"
        Me.Change.Size = New System.Drawing.Size(75, 23)
        Me.Change.TabIndex = 3
        Me.Change.Text = "変更"
        Me.Change.UseVisualStyleBackColor = True
        '
        'Apply
        '
        Me.Apply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Apply.Location = New System.Drawing.Point(94, 324)
        Me.Apply.Name = "Apply"
        Me.Apply.Size = New System.Drawing.Size(75, 23)
        Me.Apply.TabIndex = 5
        Me.Apply.Text = "OK"
        Me.Apply.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cancel.Location = New System.Drawing.Point(13, 324)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Cancel.TabIndex = 4
        Me.Cancel.Text = "キャンセル"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'EditExceptionMode_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 359)
        Me.Controls.Add(Me.Apply)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Change)
        Me.Controls.Add(Me.MakeNew)
        Me.Controls.Add(Me.Delete)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "EditExceptionMode_Form"
        Me.Text = "例外設定の編集"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents UserName As System.Windows.Forms.ColumnHeader
    Friend WithEvents Mode As System.Windows.Forms.ColumnHeader
    Friend WithEvents Delete As System.Windows.Forms.Button
    Friend WithEvents MakeNew As System.Windows.Forms.Button
    Friend WithEvents Change As System.Windows.Forms.Button
    Friend WithEvents Apply As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
End Class
