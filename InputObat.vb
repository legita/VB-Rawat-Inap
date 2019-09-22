Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class InputObat
    Dim suntik, infus, makanminum, obat, total As Integer
    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim reader As MySqlDataReader
    Sub Clear()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
    End Sub

    Sub opentable()
        Dim myadapter As New MySqlDataAdapter("select * from inputobat", Koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)

    End Sub

    Private Sub InputObat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        mycommand = New MySqlCommand("SELECT * FROM pasien WHERE status = 0", Koneksi)
        reader = mycommand.ExecuteReader()
        While reader.Read()
            ComboBox1.Items.Add(reader("id_pasien"))
        End While

        ComboBox2.Items.Add("Malam")
        ComboBox2.Items.Add("Pagi")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Poli Jantung
        If TextBox11.Text = "Poli Jantung" Then
            If CheckBox1.Checked = True Then
                If TextBox1.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
            Else
                TextBox1.Text = "0"
            End If
            If CheckBox2.Checked = True Then
                If TextBox2.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'infus = TextBox2.Text
            Else
                TextBox2.Text = "0"
            End If
            If CheckBox3.Checked = True Then
                If TextBox3.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'makanminum = TextBox1.Text
            Else
                TextBox3.Text = "0"
            End If
            If CheckBox4.Checked = True Then
                If TextBox4.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
            Else
                TextBox4.Text = "0"
            End If
        End If

        'Kandungan
        If TextBox11.Text = "Kandungan" Then
            If CheckBox1.Checked = True Then
                If TextBox1.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'suntik = TextBox1.Text
            Else
                TextBox1.Text = "0"
            End If
            If CheckBox2.Checked = True Then
                If TextBox2.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'infus = TextBox2.Text
            Else
                TextBox2.Text = "0"
            End If
            If CheckBox3.Checked = True Then
                If TextBox3.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'makanminum = TextBox1.Text
            Else
                TextBox3.Text = "0"
            End If
            If CheckBox4.Checked = True Then
                If TextBox4.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'obat = TextBox1.Text
            Else
                TextBox4.Text = "0"
            End If
        End If

        'Poli Anak
        If TextBox11.Text = "Poli Anak" Then
            If CheckBox1.Checked = True Then
                If TextBox1.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'suntik = TextBox1.Text
            Else
                TextBox1.Text = "0"
            End If
            If CheckBox2.Checked = True Then
                If TextBox2.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'infus = TextBox2.Text
            Else
                TextBox2.Text = "0"
            End If
            If CheckBox3.Checked = True Then
                If TextBox3.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'makanminum = TextBox1.Text
            Else
                TextBox3.Text = "0"
            End If
            If CheckBox4.Checked = True Then
                If TextBox4.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'obat = TextBox1.Text
            Else
                TextBox4.Text = "0"
            End If
        End If

        'Poli Saraf
        If TextBox11.Text = "Poli Saraf" Then
            If CheckBox1.Checked = True Then
                If TextBox1.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'suntik = TextBox1.Text
            Else
                TextBox1.Text = "0"
            End If
            If CheckBox2.Checked = True Then
                If TextBox2.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'infus = TextBox2.Text
            Else
                TextBox2.Text = "0"
            End If
            If CheckBox3.Checked = True Then
                If TextBox3.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'makanminum = TextBox1.Text
            Else
                TextBox3.Text = "0"
            End If
            If CheckBox4.Checked = True Then
                If TextBox4.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'obat = TextBox1.Text
            Else
                TextBox4.Text = "0"
            End If
        End If

        'Umum
        If TextBox11.Text = "Umum" Then
            If CheckBox1.Checked = True Then
                If TextBox1.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'suntik = TextBox1.Text
            Else
                TextBox1.Text = "0"
            End If
            If CheckBox2.Checked = True Then
                If TextBox2.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'infus = TextBox2.Text
            Else
                TextBox2.Text = "0"
            End If
            If CheckBox3.Checked = True Then
                If TextBox3.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'makanminum = TextBox1.Text
            Else
                TextBox3.Text = "0"
            End If
            If CheckBox4.Checked = True Then
                If TextBox4.Text = "" Then
                    MsgBox("Jumlah Harus Diisi")
                End If
                'obat = TextBox1.Text
            Else
                TextBox4.Text = "0"
            End If
        End If

        'TextBox1.Text = suntik
        'TextBox2.Text = infus
        'TextBox3.Text = makanminum
        'TextBox4.Text = obat

        'simpan
        Koneksi()
        Dim Sqltambah As String = "INSERT INTO inputobat(id_obat,id_pasien,nama_pasien,kondisi,spesialis,nama_dokter,shift,nama_dkr,nama_perawat,suntik,infus,mkn,bykobat,nama_obat)values('""','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox11.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & ComboBox2.Text & "','" & ComboBox4.Text & "','" & ComboBox3.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
        mycommand = New MySqlCommand(Sqltambah, Koneksi)
        mycommand.ExecuteNonQuery()
        Clear()
        MsgBox("Data berhasil di simpan", MsgBoxStyle.OkOnly, "Pemberitahuan")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Koneksi()
        mycommand = New MySqlCommand("SELECT * FROM pasien WHERE id_pasien = '" & ComboBox1.Text & "'", Koneksi)
        reader = mycommand.ExecuteReader()
        While reader.Read()
            TextBox6.Text = reader("nama_pasien")
        End While
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        Koneksi()
        mycommand = New MySqlCommand("SELECT * FROM pasien WHERE id_pasien = '" & ComboBox1.Text & "'", Koneksi)
        reader = mycommand.ExecuteReader()
        While reader.Read()
            TextBox11.Text = reader("kondisi")
            TextBox7.Text = reader("spesialis")
            TextBox8.Text = reader("nama_dokter")
        End While
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox3.Items.Clear()
        ComboBox4.Items.Clear()
        Koneksi()
        mycommand = New MySqlCommand("SELECT * FROM dokterjaga where shift = '" & ComboBox2.Text & "'", Koneksi)
        reader = mycommand.ExecuteReader()
        ComboBox1.Items.Clear()
        While reader.Read()
            ComboBox4.Items.Add(reader("nama_dkr"))
        End While

        mycommand = New MySqlCommand("SELECT * FROM perawat where shift = '" & ComboBox2.Text & "'", Koneksi)
        reader = mycommand.ExecuteReader()
        ComboBox1.Items.Clear()
        While reader.Read()
            ComboBox3.Items.Add(reader("nama_perawat"))
        End While

    End Sub
End Class
