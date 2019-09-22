Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class Pasien
    Dim cd As New MySqlCommand
    Dim cmd As MySqlCommand
    Dim rdr As MySqlDataReader
    Dim jk As String
    Dim jdl As String
    Dim gender As String

    Sub opentable()
        Koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from pasien", Koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
    End Sub
    Sub spesialis()
        ComboBox4.Items.Clear()
        cmd = New MySqlCommand("SELECT distinct spesialis FROM dokter ", Koneksi)
        rdr = cmd.ExecuteReader()
        ComboBox1.Items.Clear()
        While rdr.Read()
            ComboBox4.Items.Add(rdr("spesialis"))
        End While
    End Sub
    Sub hapus()
        DateTimePicker2.Text = ""
        TextBox1.Text = ""
        jk = ""
        TextBox5.Text = ""
        TextBox4.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""

    End Sub

    Sub kamar()
        cmd = New MySqlCommand("SELECT DISTINCT type_kamar FROM kamar", Koneksi)
        rdr = cmd.ExecuteReader()
        While rdr.Read()
            ComboBox2.Items.Add(rdr("type_kamar"))
        End While
    End Sub
    Sub kmr()
        Dim kmar As String
        Dim sisa As Integer
        cmd = New MySqlCommand("SELECT * FROM kamar where nomor_kamar='" & ComboBox3.Text & "'", Koneksi)
        rdr = cmd.ExecuteReader()
        While rdr.Read()
            kmar = rdr("kapasitas")
            sisa = kmar - 1
        End While

        Dim kurangistok As String = "Update kamar set " & _
            "kapasitas='" & sisa & "' where nomor_kamar = '" & ComboBox3.Text & "'"
        cmd = New MySqlCommand(kurangistok, Koneksi)
        cmd.ExecuteReader()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
       
        If RadioButton1.Checked = True Then
            jk = RadioButton1.Text
        ElseIf RadioButton2.Checked = True Then
            jk = RadioButton2.Text
        End If

        Dim Sqltambah As String = "INSERT INTO pasien(nama_pasien,jenis_kelamin,alamat,umur,kondisi,spesialis,jadwal,tlp_hp,nama_dokter,tanggal_masuk,type_kamar,nomor_kamar,status) values('" & TextBox1.Text & "','" & jk & "','" & TextBox5.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox4.Text & "','" & ComboBox5.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "','" & Format(DateTimePicker2.Value, "yy-MM-dd") & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','0')"
        cd = New MySqlCommand(Sqltambah, Koneksi)
        cd.ExecuteNonQuery()
        MsgBox("Data berhasil di Tambah", MsgBoxStyle.OkOnly, "Pemberitahuan")
        kmr()
        opentable()
        hapus()

    End Sub

    Sub test()

    End Sub

    Private Sub Pasien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        opentable()
        kamar()
        spesialis()

        ComboBox5.Items.Add("Malam")
        ComboBox5.Items.Add("Pagi")
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox3.Items.Clear()
        cmd = New MySqlCommand("SELECT * FROM kamar where type_kamar ='" & ComboBox2.Text & "' and kapasitas > 0 ", Koneksi)
        rdr = cmd.ExecuteReader()
        While rdr.Read()
            ComboBox3.Items.Add(rdr("nomor_kamar"))
        End While
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        jk = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        ComboBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        ComboBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value
        ComboBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(11).Value '2
        ComboBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(12).Value
        DateTimePicker2.Value = DataGridView1.Rows(e.RowIndex).Cells(10).Value
        If DataGridView1.Rows(e.RowIndex).Cells(2).Value = "L" Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        Home.Show()
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        ComboBox1.Items.Clear()
        cmd = New MySqlCommand("SELECT * FROM dokter where spesialis='" & ComboBox4.Text & "' and shift ='" & ComboBox5.Text & "'", Koneksi)
        rdr = cmd.ExecuteReader()
        ComboBox1.Items.Clear()
        While rdr.Read()
            ComboBox1.Items.Add(rdr("nama_dokter"))
        End While
    End Sub
End Class