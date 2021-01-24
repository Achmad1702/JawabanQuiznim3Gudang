Public Class frmKeluardetail
    Private Sub ClearEntry()
        txtKodeBarang.Text = ""
        txtNamaBarang.Text = ""
        txtKodeBarang.Text = ""
        txtQTY.Text = ""
    End Sub
    Private Sub Reload()
        obmd.getAllData(DataGridView1)
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        SimpanDetail()
    End Sub

    Private Sub SimpanDetail()
        obmd.nomor_bukti = txtNomorbukti.Text
        obmd.kode_barang = txtKodeBarang.Text
        obmd.kode_barang = txtKodeBarang.Text
        obmd.qty = txtQTY.Text

        barangkeluar_detail_baru = True
        obmd.SimpanKeluarDetail()
        ClearEntry()
        Reload()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    

    Private Sub frmKeluardetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtNomorbukti.Text = nobukti
        Reload()
    End Sub
End Class
