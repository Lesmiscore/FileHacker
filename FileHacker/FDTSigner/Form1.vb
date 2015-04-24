Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class Form1
    Dim ok As Boolean = False
    Private Sub FileSelect_Click(sender As Object, e As EventArgs) Handles FileSelect.Click
        FileSelecter.ShowDialog()
    End Sub

    Private Function B(by As Byte()) As String
        Return Convert.ToBase64String(by)
    End Function

    Private Function GetHash(data As Byte(), ha As HashAlgorithm) As Byte()
        'ハッシュ値を計算する
        Dim bs As Byte() = ha.ComputeHash(data)
        'リソースを解放する
        ha.Clear()
        'ここの部分は次のようにもできる
        Return bs
    End Function

    Private Sub FileSelecter_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles FileSelecter.FileOk
        ok = True
        FolderPath.Text = Path.GetDirectoryName(FileSelecter.FileName)
    End Sub

    Private Sub StartSign_Click(sender As Object, e As EventArgs) Handles StartSign.Click
        If Not ok Then
            MessageBox.Show("ファイル(フォルダ)を選択して下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Signer.RunWorkerAsync()
        StartSign.Enabled = False
        FileSelect.Enabled = False
    End Sub

    Private Sub Signer_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Signer.DoWork
        Dim rp = Path.Combine(Path.GetDirectoryName(FileSelecter.FileName), "Resources")
        If Not Directory.Exists(rp) Then
            Return
        End If
        Dim sfp = Path.Combine(rp, "Sign.xml")
        If File.Exists(sfp) Then
            File.Delete(sfp)
        End If
        Dim xd = <Sign></Sign>
        Dim files = Directory.GetFiles(rp)
        xd.@count = files.Count
        For Each i In files
            Dim parent = <Entry></Entry>
            Dim filepath = <FilePath></FilePath>
            filepath.Value = Path.GetFileName(i)
            parent.Add(filepath)
            Dim data = File.ReadAllBytes(i)
            Dim md5h = <MD5Hash></MD5Hash>
            md5h.Value = B(GetHash(data, New MD5Cng))
            parent.Add(md5h)
            Dim sha256h = <SHA256Hash></SHA256Hash>
            sha256h.Value = B(GetHash(data, New SHA256Managed))
            parent.Add(sha256h)
            Dim sha384h = <SHA384Hash></SHA384Hash>
            sha384h.Value = B(GetHash(data, New SHA384Managed))
            parent.Add(sha384h)
            Dim sha512h = <SHA512Hash></SHA512Hash>
            sha512h.Value = B(GetHash(data, New SHA512Managed))
            parent.Add(sha512h)
            xd.Add(parent)
        Next
        Dim tw As TextWriter = New StreamWriter(sfp, False, New UTF8Encoding)
        xd.Save(tw)
    End Sub

    Private Sub Signer_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Signer.RunWorkerCompleted
        Me.Close()
    End Sub
End Class
