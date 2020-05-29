Public Class Breadmoji
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ' Add Notify Icon
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.Visible = True
            Me.Hide()
            NotifyIcon1.BalloonTipText = "Breadmoji is minimized."
            NotifyIcon1.ShowBalloonTip(500)
        End If
    End Sub

    Private Sub ListView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDown
        Dim objDrawingPoint As Drawing.Point
        Dim objListViewItem As ListViewItem

        If e.Button = Windows.Forms.MouseButtons.Right Then Return

        objDrawingPoint = ListView1.PointToClient(Cursor.Position)

        If Not IsNothing(objDrawingPoint) Then
            With objDrawingPoint
                objListViewItem = ListView1.GetItemAt(.X, .Y)
            End With

            If Not IsNothing(objListViewItem) Then
                Clipboard.SetImage(ImageList1.Images(objListViewItem.ImageIndex))
            End If
        End If
    End Sub



    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub

    Private Sub NotifyIcon1_RightClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        NotifyIcon1.BalloonTipText = "Breadmoji will close."
        NotifyIcon1.ShowBalloonTip(500)
        Me.Close()
    End Sub
End Class
