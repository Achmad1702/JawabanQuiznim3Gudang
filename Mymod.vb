Imports MySql.Data.MySqlClient
Imports DevComponents.DotNetBar
Module MyMod
    Public myCommand As New MySqlCommand
    Public myAdapter As New MySqlDataAdapter
    Public myData As New DataTable
    Public DR As MySqlDataReader
    Public SQL As String
    Public conn As New MySqlConnection

    Public cldbarang As New frmBarang
    Public cldbm As New frmbarangmasuk
    Public cldbk As New frmBarangkeluar
    Public cldsupplier As New frmsupplier

    Public barang_masuk As Boolean
    Public menu_barang As Boolean
    Public barang_keluar As Boolean
    Public supp As Boolean

    'Table1 User
    '--------------------------------
    Public user_baru As Boolean
    Public oUser As New User
    '--------------------------------
    'Tabel Login
    '--------------------------------
    Public login_valid As Boolean
    Public nobukti As Double
    '--------------------------------
    'Tabel Barang
    '--------------------------------
    Public Barang_baru As Boolean
    Public obarang As New Barang
    '--------------------------------
    'Tabel Barangkeluar
    '--------------------------------
    Public barangkeluar_baru As Boolean
    Public oBK As New Barangkeluar
    '--------------------------------
    'Tabel Barangmasuk
    '--------------------------------
    Public barangmasuk_baru As Boolean
    Public oBM As New Barangmasuk
    '--------------------------------
    'Tabel Supplier
    '--------------------------------
    Public supplier_baru As Boolean
    Public osupplier As New Supplier
    '--------------------------------
    'Tabel Detail
    '--------------------------------
    Public barangmasuk_detail_baru As Boolean
    Public barangkeluar_detail_baru As Boolean
    Public obmd As New Detail
    '--------------------------------
    Public R As Random = New Random
    Public TotalTab As Integer = 0
    Public x As Integer

    Public Sub BikinMenu(ByVal Child As Form, ByVal mytab As TabControl, ByVal sTitle As String)

        Dim newTab As DevComponents.DotNetBar.TabItem = mytab.CreateTab(sTitle)
        Dim panel As DevComponents.DotNetBar.TabControlPanel = DirectCast(newTab.AttachedControl, Panel)


        Child.TopLevel = False
        Child.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Child.Dock = DockStyle.Fill
        Child.Show()
        panel.Controls.Add(Child)

    End Sub
    Public Function getTabIndex(ByVal mytab As TabControl, ByVal sCari As String)
        Dim i As Integer
        For i = 0 To TotalTab - 1
            If (mytab.Tabs(i).Text = sCari) Then

                Exit For
            End If
        Next
        getTabIndex = i
    End Function
    Public Sub DBConnect()
        conn.ConnectionString = "server=localhost;" &
        "user id=root;" &
        "password=;" &
        "database=quiz2"
        Try
            conn.Open()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If (conn.State = ConnectionState.Open) Then
            Else
                MessageBox.Show("Sorry not connected.")
            End If
        End Try
    End Sub

    Public Sub DBDisconnect()

        If (conn.State = ConnectionState.Open) Then
            conn.Close()
            conn.Dispose()
        End If
    End Sub

    Public Function getMD5Hash(ByVal strToHash As String) As String

        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        Dim b As Byte
        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function


    Public Function getNomorBukti()
        Dim res As Double
        res = R.Next(0, 9999999)
        Return res
    End Function
End Module

