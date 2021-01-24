Public Class Barangmasuk
    Dim strsql As String
    Dim info As String
    Private _idamasuk As Integer
    Private _nomor_faktur As String
    Private _kode_supplier As String
    Private _tanggal As String
    Private _nama_penerima As String
    Private _idmd As Integer
    Private _kode_barang As Integer
    Private _nama_barang As String
    Private _qty As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property idmd()
        Get
            Return _idmd
        End Get
        Set(ByVal value)
            _idmd = value
        End Set
    End Property
    Public Property nomor_faktur()
        Get
            Return _nomor_faktur
        End Get
        Set(ByVal value)
            _nomor_faktur = value
        End Set
    End Property

    Public Property qty()
        Get
            Return _qty
        End Get
        Set(ByVal value)
            _qty = value
        End Set
    End Property
    Public Property idamasuk()
        Get
            Return _idamasuk
        End Get
        Set(ByVal value)
            _idamasuk = value
        End Set
    End Property
 
    Public Property kode_supplier()
        Get
            Return _kode_supplier
        End Get
        Set(ByVal value)
            _kode_supplier = value
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
    Public Property nama_penerima()
        Get
            Return _nama_penerima
        End Get
        Set(ByVal value)
            _nama_penerima = value
        End Set
    End Property
   
    Public Property kode_barang()
        Get
            Return _kode_barang
        End Get
        Set(ByVal value)
            _kode_barang = value
        End Set
    End Property
    Public Property nama_barang()
        Get
            Return _nama_barang
        End Get
        Set(ByVal value)
            _nama_barang = value
        End Set
    End Property
    
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (barangmasuk_baru = True) Then
            strsql = "Insert into barangmasuk(idamasuk,nomor_faktur,kode_supplier,tanggal,nama_penerima) values ('" & _idamasuk & "','" & _nomor_faktur & "','" & _kode_supplier & "','" & _tanggal & "','" & _nama_penerima & "')"
            info = "INSERT"
        Else
            strsql = "update barangmasuk set idamasuk='" & _idamasuk & "', nomor_faktur='" & _nomor_faktur & "', kode_supplier='" & _kode_supplier & "', tanggal='" & _tanggal & "', nama_penerima='" & _nama_penerima & "' where idmmasuk='" & _idamasuk & "'"
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
    Public Sub Caribarangmasuk(ByVal sidmdetail As String)
        DBConnect()
        strsql = "SELECT * FROM barangmasuk WHERE idmdetail='" & sidmdetail & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            barangmasuk_baru = False
            DR.Read()
            idamasuk = Convert.ToString((DR("idamasuk")))
            nomor_faktur = Convert.ToString((DR("nomor_faktur")))
            kode_supplier = Convert.ToString((DR("kode_supplier")))
            tanggal = Convert.ToString((DR("tanggal")))
            nama_penerima = Convert.ToString((DR("nama_penerima")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            barangmasuk_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sidmdetail As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM barangmasuk WHERE idmdetail='" & sidmdetail & "'"
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
            strsql = "SELECT * FROM barangmasuk"
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
    Public Sub SimpanDetail()
        DBConnect()
        If (bmdetail_baru = True) Then
            strsql = "Insert into bmdetail(idmd,nomor_faktur,kode_barang,nama_barang,qty) values ('" & _idmd & "','" & _nomor_faktur & "','" & _kode_barang & "','" & _nama_barang & "','" & _qty & "')"
            info = "INSERT"
        Else
            strsql = "update bmdetail set idmd='" & _idmd & "', nomor_faktur='" & _nomor_faktur & "', kode_barang='" & _kode_barang & "', nama_barang='" & _nama_barang & "', qty='" & _qty & "' where nomor_faktur='" & _nomor_faktur & "'"
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
    Public Sub Caribmdetail(ByVal sidmd As String)
        DBConnect()
        strsql = "SELECT * FROM bmdetail WHERE idmd='" & sidmd & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            bmdetail_baru = False
            DR.Read()
            idmd = Convert.ToString((DR("idmd")))
            nomor_faktur = Convert.ToString((DR("nomor_faktur")))
            kode_barang = Convert.ToString((DR("kode_barang")))
            nama_barang = Convert.ToString((DR("nama_barang")))
            qty = Convert.ToString((DR("qty")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            bmdetail_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub HapusDetail(ByVal sidmd As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM bmdetail WHERE idmd='" & sidmd & "'"
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
    Public Sub getAllDataDetail(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM bmdetail"
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


