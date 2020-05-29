'PROJECT Breadmoji for Windows
'ENTITY: Breadmoji
'AUTHOR: johnbilkey@protonmail.com
'DATE : May 29, 2020
'PROVIDES: Main window for Breadmoji program. This program copies a selected bread image to the clipboard.


Public Class Breadmoji

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Notify Icon is displayed when program loads
        NotifyIcon1.Visible = True
        Me.Show()

        'Restrict application to a single instance
        Dim mut As System.Threading.Mutex =
        New System.Threading.Mutex(False, Application.ProductName)
        Dim running As Boolean = Not mut.WaitOne(0, False)
        If running Then
            Application.ExitThread()
            Return
        End If
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
        'Restores window on left click
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        'Minimizes window on a double click
        Me.WindowState = FormWindowState.Minimized
    End Sub

End Class
