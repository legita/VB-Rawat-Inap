Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class JadwalDokter

    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim reader As MySqlDataReader

    Sub opentable()
        Koneksi()
        Dim myadapter As New MySqlDataAdapter("select dokter.id_dokter, inputobat.nama_dokter, pasien.nama_pasien, pasien.jenis_kelamin, pasien.umur, pasien.kondisi, pasien.nomor_kamar, inputobat.nama_dkr, inputobat.nama_perawat, inputobat.shift, pasien.status from dokter, inputobat, pasien where pasien.status AND dokter.nama_dokter = inputobat.nama_dokter", Koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata

    End Sub
    Sub opentable1()
        Koneksi()
        Dim myadapter As New MySqlDataAdapter("select dokter.id_dokter, inputobat.nama_dokter, pasien.nama_pasien, pasien.jenis_kelamin, pasien.umur, pasien.kondisi, pasien.nomor_kamar, pasien.nama_dokter, inputobat.nama_dkr, inputobat.nama_perawat, inputobat.shift, pasien.status from dokter, inputobat, pasien, dokterjaga where dokter.id_dokter = '" & TextBox1.Text & "' AND pasien.status AND dokter.nama_dokter = inputobat.nama_perawat AND inputobat.shift = dokterjaga.shift", Koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata

    End Sub

    Private Sub JadwalDokter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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