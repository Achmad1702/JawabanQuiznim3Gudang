Public Class Form1

    Private Sub btnBarang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBarang.Click
        If (menu_barang = False) Then
            BikinMenu(cldbarang, TabControl1, "Barang")
            menu_barang = True
        Else
            x = getTabIndex(TabControl1, "Barang")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub
    Private Sub btnBM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBM.Click
        If (barang_masuk = False) Then
            BikinMenu(cldbm, TabControl1, "Barang Masuk")
            barang_masuk = True
        Else
            x = getTabIndex(TabControl1, "Barang Masuk")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub
    Private Sub TabControl1_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles TabControl1.ControlAdded
        TabControl1.SelectedTabIndex = TotalTab - 1
    End Sub

    Private Sub TabControl1_TabItemClose(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripActionEventArgs) Handles TabControl1.TabItemClose
        Dim itemToRemove As DevComponents.DotNetBar.TabItem = TabControl1.SelectedTab
        If (TotalTab > 3) Then
            TotalTab = TotalTab - 1
        Else
            TotalTab = 0
        End If
        TabControl1.Tabs.Remove(itemToRemove)
        TabControl1.Controls.Remove(itemToRemove.AttachedControl)
        TabControl1.RecalcLayout()


        If (itemToRemove.ToString = "Barang") Then
            menu_barang = False
        ElseIf (itemToRemove.ToString = "Barang Keluar") Then
            barang_keluar = False
        ElseIf (itemToRemove.ToString = "Barang Masuk") Then
            barang_masuk = False
        Else

        End If
    End Sub

    Private Sub TabControl1_TabItemOpen(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.TabItemOpen
        If (TotalTab = 0) Then
            TotalTab = TotalTab + 3
        Else
            TotalTab = TotalTab + 1
        End If
    End Sub


    Private Sub btnSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplier.Click
        If (supp = False) Then
            BikinMenu(cldsupplier, TabControl1, "Supplier")
            supp = True
        Else
            x = getTabIndex(TabControl1, "Supplier")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub btnBK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBK.Click
        If (barang_keluar = False) Then
            BikinMenu(cldbk, TabControl1, "Barang Keluar")
            barang_keluar = True
        Else
            x = getTabIndex(TabControl1, "Barang Keluar")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub RibbonPanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonPanel1.Click

    End Sub

    Private Sub DahsboardBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RibbonControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonControl1.Click

    End Sub
End Class
