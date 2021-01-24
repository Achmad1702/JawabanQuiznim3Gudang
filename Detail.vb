Public Class Detail
        Dim strsql As String
        Dim info As String
        Private _idmdetail As Integer
        Private _nomor_faktur As String
        Private _kode_barang As Integer
        Private _nama_barang As String
    Private _qty As String
    Private _idkdetail As Integer
    Private _nomor_bukti As String
        Public InsertState As Boolean = False
        Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property idkdetail()
        Get
            Return _idkdetail
        End Get
        Set(ByVal value)
            _idkdetail = value
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
        Public Property idmdetail()
            Get
                Return _idmdetail
            End Get
            Set(ByVal value)
                _idmdetail = value
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
        Public Property qty()
            Get
                Return _qty
            End Get
            Set(ByVal value)
                _qty = value
            End Set
    End Property
    Public Sub SimpanMasukDetail()
        Dim info As String
        DBConnect()
        If (barangmasuk_detail_baru = True) Then
            strsql = "Insert into barangmasuk_detail(idmdetail,nomor_faktur,kode_barang,nama_barang,qty) values ('" & _idmdetail & "','" & _nomor_faktur & "','" & _kode_barang & "','" & _nama_barang & "','" & _qty & "')"
            info = "INSERT"
        Else
            strsql = "update barangmasuk_detail set idmdetail='" & _idmdetail & "', nomor_faktur='" & _nomor_faktur & "', kode_barang='" & _kode_barang & "', nama_barang='" & _nama_barang & "', qty='" & _qty & "' where nomor_faktur='" & _nomor_faktur & "'"
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
        Public Sub Caribarangmasuk_detail(ByVal sidmdetail As String)
            DBConnect()
            strsql = "SELECT * FROM barangmasuk_detail WHERE idmdetail='" & sidmdetail & "'"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            DR = myCommand.ExecuteReader
            If (DR.HasRows = True) Then
                barangmasuk_detail_baru = False
                DR.Read()
                idmdetail = Convert.ToString((DR("idmdetail")))
                nomor_faktur = Convert.ToString((DR("nomor_faktur")))
                kode_barang = Convert.ToString((DR("kode_barang")))
                nama_barang = Convert.ToString((DR("nama_barang")))
                qty = Convert.ToString((DR("qty")))
            Else
                MessageBox.Show("Data Tidak Ditemukan.")
                barangmasuk_detail_baru = True
            End If
            DBDisconnect()
        End Sub
        Public Sub Hapus(ByVal sidmdetail As String)
            Dim info As String
            DBConnect()
            strsql = "DELETE FROM barangmasuk_detail WHERE idmdetail='" & sidmdetail & "'"
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
                strsql = "SELECT * FROM barangmasuk_detail"
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
Public Sub SimpanKeluarDetail()
    Dim info As String
    DBConnect()
    If (barangkeluar_detail_baru = True) Then
        strsql = "Insert into barangkeluar_detail(idkdetail,nomor_bukti,kode_barang,nama_barang,qty) values ('" & _idkdetail & "','" & _nomor_bukti & "','" & _kode_barang & "','" & _nama_barang & "','" & _qty & "')"
        info = "INSERT"
    Else
        strsql = "update barangkeluar_detail set idkdetail='" & _idkdetail & "', nomor_bukti='" & _nomor_bukti & "', kode_barang='" & _kode_barang & "', nama_barang='" & _nama_barang & "', qty='" & _qty & "' where idmdetail='" & _idmdetail & "'"
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
Public Sub Caribarangkeluar_detail(ByVal sidmdetail As String)
    DBConnect()
    strsql = "SELECT * FROM barangkeluar_detail WHERE idmdetail='" & sidmdetail & "'"
    myCommand.Connection = conn
    myCommand.CommandText = strsql
    DR = myCommand.ExecuteReader
    If (DR.HasRows = True) Then
        barangkeluar_detail_baru = False
        DR.Read()
        idkdetail = Convert.ToString((DR("idkdetail")))
        nomor_bukti = Convert.ToString((DR("nomor_bukti")))
        kode_barang = Convert.ToString((DR("kode_barang")))
        nama_barang = Convert.ToString((DR("nama_barang")))
        qty = Convert.ToString((DR("qty")))
    Else
        MessageBox.Show("Data Tidak Ditemukan.")
        barangkeluar_detail_baru = True
    End If
    DBDisconnect()
End Sub
Public Sub HapusKeluarDetail(ByVal sidmdetail As String)
    Dim info As String
    DBConnect()
    strsql = "DELETE FROM barangkeluar_detail WHERE idmdetail='" & sidmdetail & "'"
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
        strsql = "SELECT * FROM barangkeluar_detail"
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
