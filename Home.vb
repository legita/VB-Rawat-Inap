Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class Home
    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter, myadapter1, myadapter3 As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim reader As MySqlDataReader

    'Sub opentable()
    '    Dim myadapter As New MySqlDataAdapter("select nama_dokter,nomor_kamar,nama_pasien,kondisi from pasien", Koneksi)
    '    Dim mydata As New DataTable
    '    myadapter.Fill(mydata)
    '    DataGridView1.DataSource = mydata
    'End Sub

    'Sub db()
    '    Dim myadapter3 As New MySqlDataAdapter("select * nama_perawat from perawat", Koneksi)
    '    Dim mydata3 As New DataTable
    '    myadapter3.Fill(mydata3)
    '    DataGridView2.DataSource = mydata

    '    Dim myadapter1 As New MySqlDataAdapter("select * nomor_kamar,kondisi,nama_dokter,shift from pasien", Koneksi)
    '    Dim mydata1 As New DataTable
    '    myadapter.Fill(mydata1)
    '    DataGridView2.DataSource = mydata
    'End Sub

    Private Sub KamarInapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KamarInapToolStripMenuItem.Click
        Kamar.Show()
    End Sub

    Private Sub DokterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DokterToolStripMenuItem.Click
        Dokter.Show()
    End Sub

    Private Sub InfoKamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoKamarToolStripMenuItem.Click
        InfoKamar.Show()
    End Sub

    Private Sub PendaftaranToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendaftaranToolStripMenuItem.Click
        Pasien.Show()
    End Sub

    Private Sub InfoPasienToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoPasienToolStripMenuItem.Click
        InfoPasien.Show()
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeluarToolStripMenuItem.Click
        Dim Q As String
        Q = MsgBox("Anda yakin akan keluar", vbQuestion + vbOKCancel, "Informasi")
        If Q = vbOK Then
            Me.Close()
        End If
        Login.Show()
    End Sub

    Private Sub Home_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
    End Sub

    Private Sub PerawatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PerawatToolStripMenuItem.Click
        Perawat.Show()
    End Sub

    Private Sub ObatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim sql2 As String
    '    sql2 = "select * from pasien where nama_dokter like '%" & TextBox1.Text & "%'"
    '    myadapter = New MySqlDataAdapter(sql2, Koneksi)
    '    Dim SRT As New DataTable
    '    SRT.Clear()
    '    myadapter.Fill(SRT)
    '    DataGridView1.DataSource = SRT
    'End Sub

    'Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim sql3 As String
    '    sql3 = "select * from pasien where shift like '%" & TextBox2.Text & "And select * from perawat where nama_perawat '%'"
    '    myadapter1 = New MySqlDataAdapter(sql3, Koneksi)
    '    Dim SRT As New DataTable
    '    SRT.Clear()
    '    myadapter.Fill(SRT)
    '    DataGridView2.DataSource = SRT
    'End Sub

    Private Sub TransaksiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransaksiToolStripMenuItem.Click
        BiayaPengeluaran.Show()
    End Sub

    Private Sub InfoTransaksiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoTransaksiToolStripMenuItem.Click
        InfoTransaksi.Show()
    End Sub

    Private Sub DokterJagaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DokterJagaToolStripMenuItem.Click
        DokterJaga.Show()
    End Sub

    Private Sub JadwalObatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JadwalObatToolStripMenuItem.Click
        JadwalObat.Show()
    End Sub

    Private Sub InputObatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputObatToolStripMenuItem.Click
        InputObat.Show()
    End Sub

    Private Sub DokterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DokterToolStripMenuItem1.Click
        JadwalDokter.Show()
    End Sub

    Private Sub PerawatToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PerawatToolStripMenuItem1.Click
        JadwalPerawatdanDokterJaga.Show()
    End Sub
End Class