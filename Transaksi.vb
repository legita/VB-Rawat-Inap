Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class Transaksi
    Dim cd As New MySqlCommand
    Dim cmd As MySqlCommand
    Dim rdr As MySqlDataReader
    Dim jk As String
    Dim mycommand, mycommand2 As MySqlCommand
    Dim reader As MySqlDataReader
    Dim selisih, perawatan, obat, keperawatan, inap, Dokter As String

    Sub opentable()
        Koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from pasien where status = 0", Koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
    End Sub

    Sub opentable2()
        Koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from kamar", Koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView2.DataSource = mydata
    End Sub

    Sub tgl()
        cmd = New MySqlCommand("select * FROM pasien where id_pasien = '" & TextBox1.Text & "'", Koneksi)
        rdr = cmd.ExecuteReader
        Do While rdr.Read
            DateTimePicker2.Value = rdr.Item(7)
        Loop
    End Sub

    Sub kapasitas()
        cmd = New MySqlCommand("select * FROM kamar where nomor_kamar = '" & TextBox3.Text & "'", Koneksi)
        rdr = cmd.ExecuteReader
        Do While rdr.Read
            TextBox4.Text = rdr.Item(4)
        Loop
    End Sub

    Sub htg_mlm()
        Dim a As Date = DateTimePicker1.Value
        Dim b As Date = DateTimePicker2.Value
        Dim c As Long = DateDiff(DateInterval.Day, b, a)
        TextBox6.Text = c
    End Sub

    Sub hapus()
        TextBox12.Text = ""
        TextBox5.Text = ""
        TextBox10.Text = ""
        TextBox7.Text = ""
        TextBox13.Text = ""
        TextBox11.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        DateTimePicker1.Text = ""
        DateTimePicker2.Text = ""
        TextBox2.Text = ""
    End Sub

    Sub st()
        Struk.TextBox5.Text = TextBox5.Text
        Struk.TextBox10.Text = TextBox10.Text
        Struk.TextBox7.Text = TextBox13.Text
        Struk.TextBox6.Text = TextBox13.Text
        Struk.TextBox11.Text = TextBox11.Text
        Struk.TextBox8.Text = TextBox8.Text
        Struk.TextBox9.Text = TextBox9.Text
        Struk.TextBox1.Text = DateTimePicker1.Value
        Struk.TextBox3.Text = DateTimePicker2.Value
        Struk.TextBox2.Text = TextBox2.Text
    End Sub


    Private Sub Kasir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        opentable()
        opentable2()
        tgl()
        htg_mlm()
        kapasitas()
        hapus()
        TextBox10.Text = "20000"
        TextBox14.Text = "45000"

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Home.Show()
    End Sub

    Sub cari()
        If TextBox1.Text = "" Then
            TextBox1.Focus()
            opentable()
        Else
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter("Select * from pasien where id_pasien like '%" & TextBox1.Text & "%' or nama_pasien like '%" & TextBox1.Text & "%' ", Koneksi)
            da.Fill(ds, "pasien")
            DataGridView1.DataSource = ds.Tables("pasien")
            DataGridView1.ReadOnly = True
            Try
                Koneksi.Open()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        cari()
        Koneksi()
        mycommand = New MySqlCommand("SELECT * FROM obat WHERE id_pasien='" & TextBox1.Text & "'", Koneksi)
        reader = mycommand.ExecuteReader()
        While reader.Read()
            TextBox8.Text = reader("total")
        End While

        mycommand = New MySqlCommand("SELECT * FROM pasien WHERE id_pasien='" & TextBox1.Text & "'", Koneksi)
        reader = mycommand.ExecuteReader()
        While reader.Read()
            TextBox7.Text = reader("type_kamar")
            TextBox12.Text = reader("nama_dokter")
            TextBox3.Text = reader("nomor_kamar")
            DateTimePicker2.Value = reader(10)
            TextBox5.Text = reader(1)
        End While

        mycommand = New MySqlCommand("SELECT * FROM kamar WHERE type_kamar='" & TextBox7.Text & "'", Koneksi)
        reader = mycommand.ExecuteReader()
        While reader.Read()
            Label9.Text = reader("tarif_kamar")
            TextBox13.Text = Label9.Text * selisih
        End While

        mycommand = New MySqlCommand("SELECT * FROM dokter WHERE nama_dokter='" & TextBox12.Text & "'", Koneksi)
        reader = mycommand.ExecuteReader()
        While reader.Read()
            Label10.Text = reader("tarif_dokter")
            TextBox11.Text = Label10.Text * selisih
            TextBox9.Text = TextBox14.Text * selisih
        End While

    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        selisih = DateDiff(DateInterval.Day, DateTimePicker2.Value, DateTimePicker1.Value)
        Refresh()
        TextBox6.Text = "Lama menginap selama " & selisih & " hari"

    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        kapasitas()
        Dim kr As String
        kr = 1
        TextBox15.Text = Val(TextBox4.Text) + kr
        TextBox2.Text = Val(TextBox11.Text) + Val(TextBox8.Text) + Val(TextBox9.Text) + Val(TextBox13.Text)
        MsgBox("Total Transaksi = Rp. " & TextBox2.Text, MsgBoxStyle.OkOnly, "Pemberitahuan")

        Dim Kps As String = "UPDATE kamar, pasien SET pasien.status='1', kamar.kapasitas = '" & TextBox15.Text & "' WHERE kamar.nomor_kamar = '" & TextBox3.Text & "'"
        mycommand2 = New MySqlCommand(Kps, Koneksi)
        mycommand2.ExecuteNonQuery()
        
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Koneksi()
        st()
        Struk.Show()
        Me.Hide()
        hapus()
    End Sub

End Class