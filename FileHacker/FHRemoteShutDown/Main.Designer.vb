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
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.一斉操作ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendShutDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendReboot = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendSignout = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendCursorLock = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendCursorUnlock = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendMusicPlay = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendMusicStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendChengeWallpaper = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrangeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MusicSelector = New System.Windows.Forms.OpenFileDialog()
        Me.PictureSelector = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ViewMenu, Me.ToolsMenu, Me.WindowsMenu, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ToolStripSeparator5, Me.ExitToolStripMenuItem})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(70, 20)
        Me.FileMenu.Text = "ファイル(&F)"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.OpenToolStripMenuItem.Text = "新しい接続(&N)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(192, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.ExitToolStripMenuItem.Text = "アプリケーションの終了(&X)"
        '
        'ViewMenu
        '
        Me.ViewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolBarToolStripMenuItem, Me.StatusBarToolStripMenuItem})
        Me.ViewMenu.Name = "ViewMenu"
        Me.ViewMenu.Size = New System.Drawing.Size(61, 20)
        Me.ViewMenu.Text = "表示(&V)"
        '
        'ToolBarToolStripMenuItem
        '
        Me.ToolBarToolStripMenuItem.Checked = True
        Me.ToolBarToolStripMenuItem.CheckOnClick = True
        Me.ToolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolBarToolStripMenuItem.Name = "ToolBarToolStripMenuItem"
        Me.ToolBarToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ToolBarToolStripMenuItem.Text = "ツール バー(&T)"
        '
        'StatusBarToolStripMenuItem
        '
        Me.StatusBarToolStripMenuItem.Checked = True
        Me.StatusBarToolStripMenuItem.CheckOnClick = True
        Me.StatusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.StatusBarToolStripMenuItem.Name = "StatusBarToolStripMenuItem"
        Me.StatusBarToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.StatusBarToolStripMenuItem.Text = "ステータス バー(&S)"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.ToolStripSeparator1, Me.一斉操作ToolStripMenuItem})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(66, 20)
        Me.ToolsMenu.Text = "ツール(&T)"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.OptionsToolStripMenuItem.Text = "オプション(&O)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(133, 6)
        '
        '一斉操作ToolStripMenuItem
        '
        Me.一斉操作ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SendShutDown, Me.SendReboot, Me.SendSignout, Me.SendCursorLock, Me.SendCursorUnlock, Me.SendMusicPlay, Me.SendMusicStop, Me.SendChengeWallpaper})
        Me.一斉操作ToolStripMenuItem.Name = "一斉操作ToolStripMenuItem"
        Me.一斉操作ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.一斉操作ToolStripMenuItem.Text = "一斉操作"
        '
        'SendShutDown
        '
        Me.SendShutDown.Name = "SendShutDown"
        Me.SendShutDown.Size = New System.Drawing.Size(163, 22)
        Me.SendShutDown.Text = "シャットダウン"
        '
        'SendReboot
        '
        Me.SendReboot.Name = "SendReboot"
        Me.SendReboot.Size = New System.Drawing.Size(163, 22)
        Me.SendReboot.Text = "再起動"
        '
        'SendSignout
        '
        Me.SendSignout.Name = "SendSignout"
        Me.SendSignout.Size = New System.Drawing.Size(163, 22)
        Me.SendSignout.Text = "サインアウト"
        '
        'SendCursorLock
        '
        Me.SendCursorLock.Name = "SendCursorLock"
        Me.SendCursorLock.Size = New System.Drawing.Size(163, 22)
        Me.SendCursorLock.Text = "カーソルをロック"
        '
        'SendCursorUnlock
        '
        Me.SendCursorUnlock.Name = "SendCursorUnlock"
        Me.SendCursorUnlock.Size = New System.Drawing.Size(163, 22)
        Me.SendCursorUnlock.Text = "カーソルをアンロック"
        '
        'SendMusicPlay
        '
        Me.SendMusicPlay.Name = "SendMusicPlay"
        Me.SendMusicPlay.Size = New System.Drawing.Size(163, 22)
        Me.SendMusicPlay.Text = "音楽を再生"
        '
        'SendMusicStop
        '
        Me.SendMusicStop.Name = "SendMusicStop"
        Me.SendMusicStop.Size = New System.Drawing.Size(163, 22)
        Me.SendMusicStop.Text = "音楽を停止"
        '
        'SendChengeWallpaper
        '
        Me.SendChengeWallpaper.Name = "SendChengeWallpaper"
        Me.SendChengeWallpaper.Size = New System.Drawing.Size(163, 22)
        Me.SendChengeWallpaper.Text = "壁紙を変更"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CascadeToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(61, 20)
        Me.WindowsMenu.Text = "ウィンドウ"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CascadeToolStripMenuItem.Text = "重ねて表示(&C)"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CloseAllToolStripMenuItem.Text = "すべて閉じる(&L)"
        '
        'ArrangeIconsToolStripMenuItem
        '
        Me.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem"
        Me.ArrangeIconsToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ArrangeIconsToolStripMenuItem.Text = "アイコンの整列(&A)"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(67, 20)
        Me.HelpMenu.Text = "ヘルプ(&H)"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.AboutToolStripMenuItem.Text = "バージョン情報(&A)..."
        '
        'MusicSelector
        '
        Me.MusicSelector.Filter = "Music|*.wav"
        '
        'PictureSelector
        '
        Me.PictureSelector.Filter = "画像|*.jpg,*.jpeg,*.gif,*.png,*.bmp"
        Me.PictureSelector.Title = "画像を選択して下さい。"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 418)
        Me.Controls.Add(Me.MenuStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "Main"
        Me.ShowIcon = False
        Me.Text = "FileHackerRemoteController"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ViewMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 一斉操作ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendShutDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendReboot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendSignout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendCursorLock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendCursorUnlock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendMusicStop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendMusicPlay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MusicSelector As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureSelector As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SendChengeWallpaper As System.Windows.Forms.ToolStripMenuItem

End Class
