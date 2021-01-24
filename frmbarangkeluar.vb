Public Class frmBarangkeluar

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SimpanBarangKeluar()
        GetData()
        frmKeluardetail.ShowDialog()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ClearEntry()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GetData()
    End Sub

    Private Sub txtk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNStoko.KeyDown
        If (e.KeyCode = Keys.Enter And txtidkeluar.Text <> "") Then
            oBK.Caribarangkeluar(txtnomorbukti.Text)
            txtNStoko.Text = oBK.namastaff_toko
            txtNSgudang.Text = oBK.namastaff_gudang
        End If
    End Sub
    Private Sub ClearEntry()
        txtidkeluar.Clear()
        txtNStoko.Clear()
        txtnomorbukti.Clear()
        txtNSgudang.Clear()
        txtNStoko.Focus()
    End Sub
    Private Sub TampilData()
        txtidkeluar.Text = oBK.idkeluar
        txtNStoko.Text = oBK.nomor_bukti
        txtnomorbukti.Text = oBK.namastaff_toko
        txtNSgudang.Text = oBK.namastaff_gudang
    End Sub
    Private Sub SimpanBarangKeluar()
        Barang_baru = True
        oBK.idkeluar = txtidkeluar.Text
        oBK.nomor_bukti = txtnomorbukti.Text
        oBM.nomor_faktur = txtnomorbukti.Text
        oBM.nama_penerima = txtNSgudang.Text
    End Sub
    Private Sub GetData()
        oBK.getAllData(DataGridView1)
    End Sub

   
    Private Sub txtnomorbukti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnomorbukti.KeyDown
        If (e.KeyCode = Keys.Enter And txtidkeluar.Text <> "") Then
            oBK.Caribarangkeluar(txtnomorbukti.Text)
            txtNStoko.Text = oBK.namastaff_toko
            txtNSgudang.Text = oBK.namastaff_gudang
        Else
            MessageBox.Show("Data Tidak Di temukan")
        End If
    End Sub

    Private Sub frmBarangkeluar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
