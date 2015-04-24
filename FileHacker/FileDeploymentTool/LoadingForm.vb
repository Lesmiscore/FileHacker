Imports FileDeploymentTool.Tools
Imports System.Threading
Imports System.IO

Public Class LoadingForm
    Dim closeAllow As Boolean = False
    Private Sub LoadingForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If closeAllow Then Return
        If MessageBox.Show("閉じて終了しますか？", "質問", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub LoadingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lx, ly As Integer
        lx = My.Computer.Screen.Bounds.Width / 2
        ly = My.Computer.Screen.Bounds.Height / 2
        lx -= Me.Size.Width / 2
        ly -= Me.Size.Height / 2
        Me.Location = New Point(lx, ly)
        Validator.RunWorkerAsync()
    End Sub

    Private Sub Validator_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Validator.DoWork
        Dim d = SignEntry.GetResourcesSign
        If d Is Nothing Then
            MessageBox.Show("署名ファイルが見つからないか、壊れています。" & vbCrLf & "署名ツールで修復または署名して下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ForceStop()
        End If
        If Not d.CheckBrokenOrMissingFiles Then
            MessageBox.Show("リソースフォルダにある分割されたファイル群が壊れています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ForceStop()
        End If
        Dim tfn = Path.ChangeExtension(Path.GetTempFileName, "exe")
        File.WriteAllBytes(tfn, My.Resources.FileHacker)
        Process.Start(tfn)
    End Sub

    Private Sub Validator_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Validator.RunWorkerCompleted
        Step1.Show()
        closeAllow = True
        Me.Close()
    End Sub
End Class