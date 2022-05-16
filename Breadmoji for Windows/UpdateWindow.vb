Imports System.Net
Imports System.IO

Public Class UpdateWindow

    Public latest As String
    '' Holds version # of latest version from Breadmoji Server

    Public Function UpdateCheck()
        Try
            Dim client As WebClient = New WebClient()
            Dim reader As StreamReader = New StreamReader(client.OpenRead("http://johnbilkey.com/breadmoji/latest.txt"))
            latest = reader.ReadLine()
            ''Checks for Updates based on the version stated in the "About" program
            If latest.Equals(About.GetVersion()) Then
                ' Up to date
                Return False
            Else
                ' Update 
                Return True
            End If
        Catch
            ''Could not connect To server
            Return False
        End Try
    End Function


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim webAddress As String = "https://github.com/johnb-xp/Breadmoji/releases"
        Process.Start(webAddress)
    End Sub

    Private Sub UpdateWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class