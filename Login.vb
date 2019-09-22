Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class Login
    Dim koneksi As MySqlConnection
    Dim sql, username, password As String
    Dim cmd As New MySqlCommand
    Dim rd As MySqlDataReader

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("Login Dahulu")
        Else
            username = TextBox1.Text
            password = TextBox2.Text
            sql = "Select * from login where username='" & username & "' and Password='" & password & "'"
            cmd = New MySqlCommand(sql, koneksi)
            rd = cmd.ExecuteReader
            rd.Read()

            If rd.HasRows Then
                MsgBox("Anda Berhasil Login")
                Me.Hide()
                Home.Show()
                Home.Label3.Text = rd.Item("level")

                If Home.Label3.Text = "admin" Then

                ElseIf Home.Label3.Text = "dokter" Then
                    Home.AdministrasiToolStripMenuItem.Enabled = False
                    Home.PendaftaranToolStripMenuItem.Enabled = False
                    Home.TransaksiToolStripMenuItem.Enabled = False
                    Home.KamarInapToolStripMenuItem.Enabled = False


                ElseIf Home.Label3.Text = "perawat" Then
                    Home.AdministrasiToolStripMenuItem.Enabled = False
                    Home.InputObatToolStripMenuItem.Enabled = False
                    Home.KamarInapToolStripMenuItem.Enabled = False
                    Home.TransaksiToolStripMenuItem.Enabled = False

                ElseIf Home.Label3.Text = "dokterjaga" Then
                    Home.AdministrasiToolStripMenuItem.Enabled = False
                    Home.InputObatToolStripMenuItem.Enabled = False
                    Home.KamarInapToolStripMenuItem.Enabled = False
                    Home.PendaftaranToolStripMenuItem.Enabled = False
                    Home.TransaksiToolStripMenuItem.Enabled = False

                End If

                TextBox1.Text = ""
                TextBox2.Text = ""
                rd.Close()
            Else
                MsgBox("Silahkan Coba Lagi")
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox1.Focus()
                rd.Close()
            End If
            End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strKoneksi As String
        strKoneksi = "server='localhost';user id='root';password='';database='hospital'"
        koneksi = New MySqlConnection(strKoneksi)
        Try
            koneksi.Open()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

End Class