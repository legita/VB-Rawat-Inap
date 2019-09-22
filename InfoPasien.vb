Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class InfoPasien
    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim reader As MySqlDataReader

    Sub opentable()
        Dim myadapter As New MySqlDataAdapter("select * from pasien", Koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DGV.DataSource = mydata

    End Sub
    Private Sub InfoPasien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        opentable()
        Dim sql2 As String
        sql2 = "select * from pasien where id_pasien like '%" & TextBox1.Text & "%' or nama_pasien like '%" & TextBox1.Text & "%'"
        myadapter = New MySqlDataAdapter(sql2, Koneksi)
        Dim SRT As New DataTable
        SRT.Clear()
        myadapter.Fill(SRT)
        DGV.DataSource = SRT
    End Sub
End Class