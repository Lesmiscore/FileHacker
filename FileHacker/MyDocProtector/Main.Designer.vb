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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.FileLocker = New System.ComponentModel.BackgroundWorker()
        Me.FileSystemChangesWatcher = New System.IO.FileSystemWatcher()
        Me.TaskNotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderPath = New System.Windows.Forms.Label()
        Me.FolderChange = New System.Windows.Forms.Button()
        Me.LockButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PasswordVerify = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PasswordMain = New System.Windows.Forms.MaskedTextBox()
        Me.FolderSelector = New System.Windows.Forms.FolderBrowserDialog()
        Me.FileUnLocker = New System.ComponentModel.BackgroundWorker()
        Me.FailedFileLocker = New System.ComponentModel.BackgroundWorker()
        Me.CreatedDataDeleter = New System.ComponentModel.BackgroundWorker()
        Me.tmstop = New System.ComponentModel.BackgroundWorker()
        Me.TaskManagerStopping = New System.Windows.Forms.CheckBox()
        Me.LockIf10TimeChange = New System.Windows.Forms.CheckBox()
        CType(Me.FileSystemChangesWatcher, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FileLocker
        '
        '
        'FileSystemChangesWatcher
        '
        Me.FileSystemChangesWatcher.EnableRaisingEvents = True
        Me.FileSystemChangesWatcher.NotifyFilter = CType((((((((System.IO.NotifyFilters.FileName Or System.IO.NotifyFilters.DirectoryName) _
            Or System.IO.NotifyFilters.Attributes) _
            Or System.IO.NotifyFilters.Size) _
            Or System.IO.NotifyFilters.LastWrite) _
            Or System.IO.NotifyFilters.LastAccess) _
            Or System.IO.NotifyFilters.CreationTime) _
            Or System.IO.NotifyFilters.Security), System.IO.NotifyFilters)
        Me.FileSystemChangesWatcher.SynchronizingObject = Me
        '
        'TaskNotifyIcon
        '
        Me.TaskNotifyIcon.Icon = CType(resources.GetObject("TaskNotifyIcon.Icon"), System.Drawing.Icon)
        Me.TaskNotifyIcon.Text = "NotifyIcon1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "保護するディレクトリ"
        '
        'FolderPath
        '
        Me.FolderPath.AutoSize = True
        Me.FolderPath.Location = New System.Drawing.Point(13, 37)
        Me.FolderPath.Name = "FolderPath"
        Me.FolderPath.Size = New System.Drawing.Size(0, 12)
        Me.FolderPath.TabIndex = 1
        '
        'FolderChange
        '
        Me.FolderChange.Location = New System.Drawing.Point(232, 32)
        Me.FolderChange.Name = "FolderChange"
        Me.FolderChange.Size = New System.Drawing.Size(40, 23)
        Me.FolderChange.TabIndex = 2
        Me.FolderChange.Text = "変更"
        Me.FolderChange.UseVisualStyleBackColor = True
        '
        'LockButton
        '
        Me.LockButton.Location = New System.Drawing.Point(12, 183)
        Me.LockButton.Name = "LockButton"
        Me.LockButton.Size = New System.Drawing.Size(75, 23)
        Me.LockButton.TabIndex = 3
        Me.LockButton.Text = "ロック"
        Me.LockButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PasswordVerify)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.PasswordMain)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 72)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "パスワード"
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
        'PasswordVerify
        '
        Me.PasswordVerify.Location = New System.Drawing.Point(70, 44)
        Me.PasswordVerify.Name = "PasswordVerify"
        Me.PasswordVerify.PasswordChar = Global.Microsoft.VisualBasic.ChrW(29577)
        Me.PasswordVerify.Size = New System.Drawing.Size(184, 19)
        Me.PasswordVerify.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "パスワード"
        '
        'PasswordMain
        '
        Me.PasswordMain.Location = New System.Drawing.Point(70, 19)
        Me.PasswordMain.Name = "PasswordMain"
        Me.PasswordMain.PasswordChar = Global.Microsoft.VisualBasic.ChrW(37329)
        Me.PasswordMain.Size = New System.Drawing.Size(184, 19)
        Me.PasswordMain.TabIndex = 0
        '
        'FileUnLocker
        '
        '
        'FailedFileLocker
        '
        '
        'CreatedDataDeleter
        '
        '
        'tmstop
        '
        '
        'TaskManagerStopping
        '
        Me.TaskManagerStopping.AutoSize = True
        Me.TaskManagerStopping.Location = New System.Drawing.Point(15, 139)
        Me.TaskManagerStopping.Name = "TaskManagerStopping"
        Me.TaskManagerStopping.Size = New System.Drawing.Size(190, 16)
        Me.TaskManagerStopping.TabIndex = 5
        Me.TaskManagerStopping.Text = "タスクマネージャーを強制終了させる"
        Me.TaskManagerStopping.UseVisualStyleBackColor = True
        '
        'LockIf10TimeChange
        '
        Me.LockIf10TimeChange.AutoSize = True
        Me.LockIf10TimeChange.Location = New System.Drawing.Point(15, 161)
        Me.LockIf10TimeChange.Name = "LockIf10TimeChange"
        Me.LockIf10TimeChange.Size = New System.Drawing.Size(186, 16)
        Me.LockIf10TimeChange.TabIndex = 6
        Me.LockIf10TimeChange.Text = "10回ファイル操作したら1分間ロック"
        Me.LockIf10TimeChange.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 214)
        Me.Controls.Add(Me.LockIf10TimeChange)
        Me.Controls.Add(Me.TaskManagerStopping)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LockButton)
        Me.Controls.Add(Me.FolderChange)
        Me.Controls.Add(Me.FolderPath)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.Text = "マイドキュメント保護プログラム"
        CType(Me.FileSystemChangesWatcher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FileLocker As System.ComponentModel.BackgroundWorker
    Friend WithEvents FileSystemChangesWatcher As System.IO.FileSystemWatcher
    Friend WithEvents TaskNotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents FolderChange As System.Windows.Forms.Button
    Friend WithEvents FolderPath As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LockButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PasswordVerify As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PasswordMain As System.Windows.Forms.MaskedTextBox
    Friend WithEvents FolderSelector As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents FileUnLocker As System.ComponentModel.BackgroundWorker
    Friend WithEvents FailedFileLocker As System.ComponentModel.BackgroundWorker
    Friend WithEvents CreatedDataDeleter As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmstop As System.ComponentModel.BackgroundWorker
    Friend WithEvents TaskManagerStopping As System.Windows.Forms.CheckBox
    Friend WithEvents LockIf10TimeChange As System.Windows.Forms.CheckBox

End Class
