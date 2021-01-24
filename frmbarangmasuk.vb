Public Class frmbarangmasuk

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SimpanBarangMasuk()
        GetData()
        frmMasukDetail.ShowDialog()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearEntry()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        GetData()
    End Sub

    Private Sub txtkodesupplier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtkodesupplier.KeyDown
        If (e.KeyCode = Keys.Enter And txtidm.Text <> "") Then
            oBM.Caribarangmasuk(txtkodesupplier.Text)
            txtnomorfaktur.Text = oBM.nomor_faktur
            txtnamapenerima.Text = oBM.nama_penerima
            TampilData()
        Else
            MessageBox.Show("Data Tidak Di temukan")
        End If
    End Sub
    Private Sub ClearEntry()
        txtidm.Clear()
        txtkodesupplier.Clear()
        txtnomorfaktur.Clear()
        txtnamapenerima.Clear()
        txtkodesupplier.Focus()
    End Sub
    Private Sub TampilData()
        txtidm.Text = oBM.idamasuk
        txtkodesupplier.Text = oBM.kode_supplier
        txtnomorfaktur.Text = oBM.nomor_faktur
        txtnamapenerima.Text = oBM.nama_penerima
    End Sub
    Private Sub SimpanBarangMasuk()
        Barang_baru = True
        oBM.idamasuk = txtidm.Text
        oBM.kode_supplier = txtkodesupplier.Text
        oBM.nomor_faktur = txtnomorfaktur.Text
        oBM.nama_penerima = txtnamapenerima.Text
    End Sub
    Private Sub GetData()
        oBM.getAllData(DataGridView1)
    End Sub

    Private Sub frmbarangmasuk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtidm_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidm.KeyDown
        If (e.KeyCode = Keys.Enter And txtidm.Text <> "") Then
            oBM.Caribarangmasuk(txtidm.Text)
            If (barangmasuk_baru = True) Then
                txtkodesupplier.Focus()
            Else
                TampilData()
            End If
        End If
    End Sub
End Class
