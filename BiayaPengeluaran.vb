Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data
Public Class BiayaPengeluaran
    Dim suntik, infus, makanminum, obat, total As Integer
    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim reader As MySqlDataReader
    Sub Clear()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'TextBox7.Text = suntik
        'TextBox8.Text = infus
        'TextBox9.Text = makanminum
        'TextBox10.Text = obat

        'Poli Jantung
        If TextBox12.Text = "Poli Jantung" Then
            If TextBox1.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox7.Text = 20000 * Val(TextBox1.Text)
                suntik = TextBox7.Text
            End If

            If TextBox2.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox8.Text = 10000 * TextBox2.Text
                infus = TextBox8.Text
            End If

            If TextBox3.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox9.Text = 30000 * TextBox3.Text
                makanminum = TextBox9.Text
            End If

            If TextBox4.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox10.Text = 30000 * TextBox4.Text
                obat = TextBox10.Text
            End If
        End If

        'Kandungan
        If TextBox12.Text = "Kandungan" Then
            If TextBox1.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox7.Text = 20000 * TextBox1.Text
                suntik = TextBox7.Text
            End If

            If TextBox2.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox8.Text = 10000 * TextBox2.Text
                infus = TextBox8.Text
            End If

            If TextBox3.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox9.Text = 30000 * TextBox3.Text
                makanminum = TextBox9.Text
            End If

            If TextBox4.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox10.Text = 30000 * TextBox4.Text
                obat = TextBox10.Text
            End If
        End If

        'Poli Anak
        If TextBox12.Text = "Poli Anak" Then
            If TextBox1.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox7.Text = 20000 * TextBox1.Text
                suntik = TextBox7.Text
            End If

            If TextBox2.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox8.Text = 10000 * TextBox2.Text
                infus = TextBox8.Text
            End If

            If TextBox3.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                makanminum = 30000 * TextBox3.Text
                TextBox9.Text = makanminum
            End If

            If TextBox4.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox10.Text = 30000 * TextBox4.Text
                obat = TextBox10.Text
            End If
        End If

        'Poli Saraf
        If TextBox12.Text = "Poli Saraf" Then
            If TextBox1.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox7.Text = 20000 * TextBox1.Text
                suntik = TextBox7.Text
            End If

            If TextBox2.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox8.Text = 10000 * TextBox2.Text
                infus = TextBox8.Text
            End If

            If TextBox3.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox9.Text = 30000 * TextBox3.Text
                makanminum = TextBox9.Text
            End If

            If TextBox4.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox10.Text = 30000 * TextBox4.Text
                obat = TextBox10.Text
            End If
        End If

        'Umum
        If TextBox12.Text = "Umum" Then
            If TextBox1.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox7.Text = 20000 * TextBox1.Text
                suntik = TextBox7.Text
            End If

            If TextBox2.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox8.Text = 10000 * TextBox2.Text
                infus = TextBox8.Text
            End If

            If TextBox3.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox9.Text = 30000 * TextBox3.Text
                makanminum = TextBox9.Text
            End If

            If TextBox4.Text = "" Then
                MsgBox("Jumlah Harus Diisi")
            Else
                TextBox10.Text = 30000 * TextBox4.Text
                obat = TextBox10.Text
            End If
        End If

        TextBox5.Text = suntik + infus + makanminum + obat
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Koneksi()
        Dim Sqltambah As String = "INSERT INTO obat(id_pasien,suntikan,infusan,obat,makan,total)values('" & ComboBox1.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox5.Text & "')"
        mycommand = New MySqlCommand(Sqltambah, Koneksi)
        mycommand.ExecuteNonQuery()
        Clear()
        MsgBox("Data berhasil di simpan", MsgBoxStyle.OkOnly, "Pemberitahuan")
    End Sub

    Private Sub BiayaPengeluaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        mycommand = New MySqlCommand("SELECT * FROM pasien WHERE status = 0", Koneksi)
        reader = mycommand.ExecuteReader()
        While reader.Read()
            ComboBox1.Items.Add(reader("id_pasien"))
        End While
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Koneksi()
        mycommand = New MySqlCommand("SELECT * FROM inputobat WHERE id_pasien = '" & ComboBox1.Text & "'", Koneksi)
        reader = mycommand.ExecuteReader()
        While reader.Read()
            TextBox6.Text = reader("nama_pasien")
            TextBox11.Text = reader("kondisi")
            TextBox12.Text = reader("spesialis")
            TextBox1.Text = reader("suntik")
            TextBox2.Text = reader("infus")
            TextBox3.Text = reader("mkn")
            TextBox4.Text = reader("bykobat")
        End While
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        Transaksi.Show()
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub
End Class