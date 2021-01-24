Public Class Barangkeluar
    Dim strsql As String
    Dim info As String
    Private _idkeluar As Integer
    Private _nomor_bukti As String
    Private _tanggal As String
    Private _namastaff_toko As String
    Private _namastaff_gudang As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property idkeluar()
        Get
            Return _idkeluar
        End Get
        Set(ByVal value)
            _idkeluar = value
        End Set
    End Property
    Public Property nomor_bukti()
        Get
            Return _nomor_bukti
        End Get
        Set(ByVal value)
            _nomor_bukti = value
        End Set
    End Property
    Public Property tanggal()
        Get
            Return _tanggal
        End Get
        Set(ByVal value)
            _tanggal = value
        End Set
    End Property
    Public Property namastaff_toko()
        Get
            Return _namastaff_toko
        End Get
        Set(ByVal value)
            _namastaff_toko = value
        End Set
    End Property
    Public Property namastaff_gudang()
        Get
            Return _namastaff_gudang
        End Get
        Set(ByVal value)
            _namastaff_gudang = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (barangkeluar_baru = True) Then
            strsql = "Insert into barangkeluar(idkeluar,nomor_bukti,tanggal,namastaff_toko,namastaff_gudang) values ('" & _idkeluar & "','" & _nomor_bukti & "','" & _tanggal & "','" & _namastaff_toko & "','" & _namastaff_gudang & "')"
            info = "INSERT"
        Else
            strsql = "update barangkeluar set idkeluar='" & _idkeluar & "', nomor_bukti='" & _nomor_bukti & "', tanggal='" & _tanggal & "', namastaff_toko='" & _namastaff_toko & "', namastaff_gudang='" & _namastaff_gudang & "' where idbarang='" & _idkeluar & "'"
            info = "UPDATE"
        End If
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            If (info = "INSERT") Then
                InsertState = False
            ElseIf (info = "UPDATE") Then
                UpdateState = False
            Else
            End If
        Finally
            If (info = "INSERT") Then
                InsertState = True
            ElseIf (info = "UPDATE") Then
                UpdateState = True
            Else
            End If
        End Try
        DBDisconnect()
    End Sub
    
    Public Sub Caribarangkeluar(ByVal sidbarang As String)
        DBConnect()
        strsql = "SELECT * FROM barangkeluar WHERE idbarang='" & sidbarang & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            barangkeluar_baru = False
            DR.Read()
            idkeluar = Convert.ToString((DR("idkeluar")))
            nomor_bukti = Convert.ToString((DR("nomor_bukti")))
            tanggal = Convert.ToString((DR("tanggal")))
            namastaff_toko = Convert.ToString((DR("namastaff_toko")))
            namastaff_gudang = Convert.ToString((DR("namastaff_gudang")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            barangkeluar_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sidbarang As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM barangkeluar WHERE idbarang='" & sidbarang & "'"
        info = "DELETE"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        DBDisconnect()
    End Sub
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM barangkeluar"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dg
                .DataSource = myData
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub





End Class
