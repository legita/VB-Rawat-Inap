Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class JadwalPerawatdanDokterJaga

    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim reader As MySqlDataReader

    Sub opentable()
        Koneksi()
        Dim myadapter As New MySqlDataAdapter("select perawat.id_perawat, inputobat.nama_perawat, pasien.nama_pasien, pasien.jenis_kelamin, pasien.umur, pasien.kondisi, pasien.nomor_kamar, pasien.nama_dokter, inputobat.nama_dkr, inputobat.shift, pasien.status from perawat, inputobat, pasien where pasien.status AND perawat.nama_perawat = inputobat.nama_perawat", Koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata

    End Sub
    Sub opentable1()
        Koneksi()
        Dim myadapter As New MySqlDataAdapter("select perawat.id_perawat, inputobat.nama_perawat, pasien.nama_pasien, pasien.jenis_kelamin, pasien.umur, pasien.kondisi, pasien.nomor_kamar, pasien.nama_dokter, inputobat.nama_dkr, inputobat.shift, pasien.status from perawat, inputobat, pasien, dokterjaga where perawat.id_perawat = '" & TextBox1.Text & "' AND pasien.status AND perawat.nama_perawat = inputobat.nama_perawat AND inputobat.shift = dokterjaga.shift", Koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata

    End Sub

    Private Sub JadwalPerawatdanDokterJaga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        opentable()

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Koneksi()
        'opentable1()
        If TextBox1.Text = "" Then
            opentable()
        Else
            opentable1()
        End If
    End Sub
End Class