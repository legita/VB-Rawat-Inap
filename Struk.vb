Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class Struk
    Dim cd As New MySqlCommand
    Dim cmd As MySqlCommand
    Dim rdr As MySqlDataReader
    Dim jk As String
    Dim mycommand, mycommand2 As MySqlCommand
    Dim reader As MySqlDataReader

    Sub opentable()
        Koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from transaksi", Koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
    End Sub

    Private Sub Struk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MsgBox("Struk di Proses ... ")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
        Transaksi.Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Koneksi()
        Dim Sqltambah As String = "INSERT INTO transaksi(id_transaksi,nama_pasien,administrasi,biaya_kamar,lama_menginap,biaya_dokter,biaya_obat,keperawatan,tgl_klr,tgl_msk,total_bayar) values('','" & TextBox5.Text & "','" & TextBox10.Text & "','" & TextBox7.Text & "','" & TextBox6.Text & "','" & TextBox11.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox2.Text & "')"
        mycommand = New MySqlCommand(Sqltambah, Koneksi)
        mycommand.ExecuteNonQuery()
        opentable()
        MsgBox("Data Berhasil di Simpan", MsgBoxStyle.OkOnly, "Pemberitahuan")

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Home.Show()
    End Sub
End Class