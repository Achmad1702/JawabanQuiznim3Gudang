Public Class frmSupplier

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Simpansupplier()
        GetData()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearEntry()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        GetData()
    End Sub
    Private Sub txtkodesupplier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtkodesupplier.KeyDown
        If (e.KeyCode = Keys.Enter And txtkodesupplier.Text <> "") Then
            osupplier.Carisupplier(txtkodesupplier.Text)
            txtnamasupplier.Text = osupplier.nama_supplier
            txtkontakperson.Text = osupplier.kontak_person
            txtemail.Text = osupplier.email
        End If
    End Sub
    Private Sub ClearEntry()
        txtidsupplier.Clear()
        txtkodesupplier.Clear()
        txtnamasupplier.Clear()
        txtkontakperson.Clear()
        txtemail.Clear()
        txtidsupplier.Focus()
    End Sub
    Private Sub TampilData()
        txtidsupplier.Text = osupplier.idsupplier
        txtkodesupplier.Text = osupplier.kode_supplier
        txtnamasupplier.Text = osupplier.nama_supplier
        txtkontakperson.Text = osupplier.kontak_person
        txtemail.Text = osupplier.email
    End Sub
    Private Sub Simpansupplier()
        Barang_baru = True
        osupplier.idsupplier = txtidsupplier.Text
        osupplier.kode_supplier = txtkodesupplier.Text
        osupplier.nama_supplier = txtnamasupplier.Text
        osupplier.kontak_person = txtkontakperson.Text
        osupplier.email = txtemail.Text
    End Sub
    Private Sub GetData()
        osupplier.getAllData(DataGridView1, txtkodesupplier.Text)
    End Sub

    Private Sub frmSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
