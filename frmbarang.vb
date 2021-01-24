Public Class frmBarang


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SimpanBarang()
        GetData()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearEntry()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        GetData()
    End Sub

    Private Sub txtkodebarang_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtkodebarang.KeyDown
        If (e.KeyCode = Keys.Enter And txtkodebarang.Text <> "") Then
            obarang.Caribarang(txtkodebarang.Text)
            txtnamabarang.Text = obarang.nama_barang
            txtstok.Text = obarang.stok
            cbosatuan.Text = obarang.satuan
        End If
    End Sub
    Private Sub ClearEntry()
        txtidbarang.Clear()
        txtkodebarang.Clear()
        txtnamabarang.Clear()
        txtstok.Clear()
        txtkodebarang.Focus()
    End Sub
    Private Sub TampilData()
        txtidbarang.Text = obarang.idbarang
        txtkodebarang.Text = obarang.kode_barang
        txtnamabarang.Text = obarang.nama_barang
        cbosatuan.Text = obarang.satuan
        txtstok.Text = obarang.stok
    End Sub
    Private Sub SimpanBarang()
        Barang_baru = True
        obarang.idbarang = txtidbarang.Text
        obarang.kode_barang = txtkodebarang.Text
        obarang.nama_barang = txtnamabarang.Text
        obarang.satuan = cbosatuan.Text
        obarang.stok = txtstok.Text
    End Sub
    Private Sub GetData()
        obarang.getAllData(DataGridView1, txtkodebarang.Text)
    End Sub

    Private Sub frmBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
