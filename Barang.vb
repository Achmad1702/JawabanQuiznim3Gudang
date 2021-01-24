Public Class Barang
    Dim strsql As String
    Dim info As String
    Private _idbarang As Integer
    Private _kode_barang As Integer
    Private _nama_barang As String
    Private _satuan As String
    Private _stok As Integer
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property idbarang()
        Get
            Return _idbarang
        End Get
        Set(ByVal value)
            _idbarang = value
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
    Public Property satuan()
        Get
            Return _satuan
        End Get
        Set(ByVal value)
            _satuan = value
        End Set
    End Property
    Public Property stok()
        Get
            Return _stok
        End Get
        Set(ByVal value)
            _stok = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (barang_baru = True) Then
            strsql = "Insert into barang(idbarang,kode_barang,nama_barang,satuan,stok) values ('" & _idbarang & "','" & _kode_barang & "','" & _nama_barang & "','" & _satuan & "','" & _stok & "')"
            info = "INSERT"
        Else
            strsql = "update barang set idbarang='" & _idbarang & "', kode_barang='" & _kode_barang & "', nama_barang='" & _nama_barang & "', satuan='" & _satuan & "', stok='" & _stok & "' where kode_barang='" & _kode_barang & "'"
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
    Public Sub Caribarang(ByVal sidbarang As String)
        DBConnect()
        strsql = "SELECT * FROM barang WHERE idbarang='" & sidbarang & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            barang_baru = False
            DR.Read()
            idbarang = Convert.ToString((DR("idbarang")))
            kode_barang = Convert.ToString((DR("kode_barang")))
            nama_barang = Convert.ToString((DR("nama_barang")))
            satuan = Convert.ToString((DR("satuan")))
            stok = Convert.ToString((DR("stok")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            barang_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sidbarang As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM barang WHERE idbarang='" & sidbarang & "'"
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
            strsql = "SELECT * FROM barang"
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

    Sub getAllData(ByVal datagridview As DataGridView, ByVal p2 As String)
        Try
            DBConnect()
            strsql = "SELECT * FROM barang"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With datagridview
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
