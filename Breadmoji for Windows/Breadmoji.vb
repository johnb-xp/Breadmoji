'PROJECT Breadmoji for Windows
'ENTITY: Breadmoji
'AUTHOR: johnbilkey@protonmail.com
'DATE : May 29, 2020
'PROVIDES: Main window for Breadmoji program. This program copies a selected bread image to the clipboard.


Public Class Breadmoji

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Notify Icon is displayed when program loads
        NotifyIcon1.Visible = True

        'Don't show program in taskbar
        ShowInTaskbar = False

        ' Get Active Screen cursor is on, then go to bottom right corner
        Dim scr As Screen = Screen.FromPoint(Cursor.Position)
        Me.Location = New Point(scr.WorkingArea.Right - Me.Width, scr.WorkingArea.Bottom - Me.Height)

        'Hide window - useful when running on startup
        Me.WindowState = FormWindowState.Minimized
        Me.Hide()

        'Restrict application to a single instance
        Dim mut As System.Threading.Mutex =
        New System.Threading.Mutex(False, Application.ProductName)
        Dim running As Boolean = Not mut.WaitOne(0, False)
        If running Then
            Application.ExitThread()
            Return
        End If

        CheckUpdate()

    End Sub

    Private Sub ListView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDown
        ' This code segment chooses the selected bread icon from the imageList
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
                ' Copy image to clipboard
            End If
        End If
    End Sub

    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        If Me.WindowState = FormWindowState.Normal Then
            'Minimizes window
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
        Else
            'Restores window
            Me.Show()
            Me.WindowState = FormWindowState.Normal
        End If
        NotifyIcon1.Visible = True
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        UpdateWindow.show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.show
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CheckUpdate()
    End Sub

    Private Sub CheckUpdate()
        If UpdateWindow.UpdateCheck() Then
            UpdateToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub UpdateToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
        UpdateWindow.Show()
    End Sub
End Class
