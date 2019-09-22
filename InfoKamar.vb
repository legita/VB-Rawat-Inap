Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class InfoKamar
    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim reader As MySqlDataReader

    Sub opentable()
        Dim myadapter As New MySqlDataAdapter("select * from kamar", Koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata

    End Sub
 
    Private Sub InfoKamar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        opentable()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        koneksi()
        Dim sql2 As String
        sql2 = "select * from kamar where nomor_kamar like '%" & TextBox1.Text & "%' or nama_kamar like '%" & TextBox1.Text & "%'"
        myadapter = New MySqlDataAdapter(sql2, Koneksi)
        Dim SRT As New DataTable
        SRT.Clear()
        myadapter.Fill(SRT)
        DataGridView1.DataSource = SRT
    End Sub

End Class