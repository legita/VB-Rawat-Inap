Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class Dokter
    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim reader As MySqlDataReader
    Dim shift As String
    Sub opentable()

        Dim myadapter As New MySqlDataAdapter("select * from dokter", Koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata '

    End Sub
    Sub hapus()
        TextBox1.Text = ""
        TextBox2.Text = ""
        shift = ""
        ComboBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call koneksi()
        If RadioButton1.Checked = True Then
            shift = "Malam"
        ElseIf RadioButton2.Checked = True Then
            shift = "Pagi"
        End If

        Dim Sqltambah As String = "INSERT INTO dokter(id_dokter,nama_dokter,spesialis,tlp_hp,tarif_dokter,shift) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & shift & "')"
        mycommand = New MySqlCommand(Sqltambah, Koneksi)
        mycommand.ExecuteNonQuery()
        opentable()
        hapus()
        MsgBox("Data berhasil di tambah", MsgBoxStyle.OkOnly, "Pemberitahuan")

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Koneksi()
        If RadioButton1.Checked = True Then
            shift = "Malam"
        ElseIf RadioButton2.Checked = True Then
            shift = "Pagi"
        End If
        mycommand = New MySqlCommand("update dokter set nama_dokter = '" & TextBox2.Text & "', spesialis = '" & ComboBox1.Text & "', tlp_hp = '" & TextBox3.Text & "',tarif_dokter = '" & TextBox4.Text & "',shift = '" & shift & "' where id_dokter = '" & TextBox1.Text & "'", Koneksi)
        mycommand.ExecuteNonQuery()
        opentable()
        hapus()
        MsgBox("Data berhasil di ubah", MsgBoxStyle.OkOnly, "Pemberitahuan")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        koneksi()
        mycommand = New MySqlCommand("delete from dokter where id_dokter='" & TextBox1.Text & "'", Koneksi)
        mycommand.ExecuteNonQuery()
        opentable()
        hapus()
        MsgBox("Data berhasil di hapus", MsgBoxStyle.OkOnly, "Pemberitahuan")

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
        Home.Show()
    End Sub

    Private Sub Dokter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        opentable()
        ComboBox1.Items.Add("Poli Saraf")
        ComboBox1.Items.Add("Poli Kandungan")
        ComboBox1.Items.Add("Poli Anak")
        ComboBox1.Items.Add("Poli Jantung")
        ComboBox1.Items.Add("Umum")
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        shift = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        If DataGridView1.Rows(e.RowIndex).Cells(5).Value = "Malam" Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If
    End Sub
End Class