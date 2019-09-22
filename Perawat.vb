Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class Perawat
    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim reader As MySqlDataReader
    Dim shift As String

    Sub opentable()

        Dim myadapter As New MySqlDataAdapter("select * from perawat", Koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata '

    End Sub
    Sub hapus()
        TextBox1.Text = ""
        TextBox2.Text = ""
        shift = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox3.Text = ""

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call koneksi()
        If RadioButton1.Checked = True Then
            shift = "Malam"
        ElseIf RadioButton2.Checked = True Then
            shift = "Pagi"
        End If

        Dim Sqltambah As String = "INSERT INTO perawat(id_perawat,nama_perawat,shift,tlp_hp) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & shift & "','" & TextBox3.Text & "')"
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
        mycommand = New MySqlCommand("update perawat set nama_perawat = '" & TextBox2.Text & "', shift = '" & shift & "', tlp_hp = '" & TextBox3.Text & "' where id_perawat = '" & TextBox1.Text & "'", Koneksi)
        mycommand.ExecuteNonQuery()
        opentable()
        hapus()
        MsgBox("Data berhasil di ubah", MsgBoxStyle.OkOnly, "Pemberitahuan")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        koneksi()
        mycommand = New MySqlCommand("delete from perawat where id_perawat='" & TextBox1.Text & "'", Koneksi)
        mycommand.ExecuteNonQuery()
        opentable()
        hapus()
        MsgBox("Data berhasil di hapus", MsgBoxStyle.OkOnly, "Pemberitahuan")

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
        Home.Show()
    End Sub

    Private Sub Perawat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        opentable()
    End Sub


    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        shift = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        If DataGridView1.Rows(e.RowIndex).Cells(3).Value = "Malam" Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If
    End Sub
End Class