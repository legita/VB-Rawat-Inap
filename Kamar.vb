Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class Kamar
    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim reader As MySqlDataReader

    Sub opentable()
        Koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from kamar", Koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata

    End Sub
    Sub hapus()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        TextBox5.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        opentable()
        ComboBox1.Items.Add("VIP")
        ComboBox1.Items.Add("Kelas 1")
        ComboBox1.Items.Add("Kelas 2")
        ComboBox1.Items.Add("Kelas 3")
        ComboBox1.Items.Add("Kelas 4")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call koneksi()
        mycommand = New MySqlCommand("INSERT INTO kamar(id_kamar,nomor_kamar,nama_kamar,type_kamar,kapasitas,tarif_kamar,status) values('','" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & TextBox5.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')", Koneksi)
        mycommand.ExecuteNonQuery()
        opentable()
        hapus()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        mycommand = New MySqlCommand("update kamar set nama_kamar = '" & TextBox2.Text & "', type_kamar = '" & ComboBox1.Text & "', kapasitas = '" & TextBox5.Text & "',tarif_kamar = '" & TextBox3.Text & "',status = '" & TextBox4.Text & "' where nomor_kamar = '" & TextBox1.Text & "'", Koneksi)
        mycommand.ExecuteNonQuery()
        opentable()
        hapus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        koneksi()
        mycommand = New MySqlCommand("delete from kamar where nomor_kamar ='" & TextBox1.Text & "'", Koneksi)
        mycommand.ExecuteNonQuery()
        opentable()
        hapus()
        MsgBox("Data berhasil di hapus", MsgBoxStyle.OkOnly, "Pemberitahuan")

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "VIP" Then
            TextBox5.Text = "1 orang"
        ElseIf ComboBox1.Text = "Kelas 1" Then
            TextBox5.Text = "2 orang"
        ElseIf ComboBox1.Text = "Kelas 2" Then
            TextBox5.Text = "3 orang"
        ElseIf ComboBox1.Text = "Kelas 3" Then
            TextBox5.Text = "4 orang"
        ElseIf ComboBox1.Text = "Kelas 4" Then
            TextBox5.Text = "5 orang"
        End If
    End Sub


    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
        Home.Show()
    End Sub
End Class