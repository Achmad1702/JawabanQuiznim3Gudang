Public Class Supplier
    Dim strsql As String
    Dim info As String
    Private _idsupplier As Integer
    Private _kode_supplier As String
    Private _nama_supplier As String
    Private _kontak_person As String
    Private _email As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property idsupplier()
        Get
            Return _idsupplier
        End Get
        Set(ByVal value)
            _idsupplier = value
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
    Public Property nama_supplier()
        Get
            Return _nama_supplier
        End Get
        Set(ByVal value)
            _nama_supplier = value
        End Set
    End Property
    Public Property kontak_person()
        Get
            Return _kontak_person
        End Get
        Set(ByVal value)
            _kontak_person = value
        End Set
    End Property
    Public Property email()
        Get
            Return _email
        End Get
        Set(ByVal value)
            _email = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (supplier_baru = True) Then
            strsql = "Insert into supplier(idsupplier,kode_supplier,nama_supplier,kontak_person,email) values ('" & _idsupplier & "','" & _kode_supplier & "','" & _nama_supplier & "','" & _kontak_person & "','" & _email & "')"
            info = "INSERT"
        Else
            strsql = "update supplier set idsupplier='" & _idsupplier & "', kode_supplier='" & _kode_supplier & "', nama_supplier='" & _nama_supplier & "', kontak_person='" & _kontak_person & "', email='" & _email & "' where idsupplier='" & _idsupplier & "'"
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
    Public Sub Carisupplier(ByVal sidbarang As String)
        DBConnect()
        strsql = "SELECT * FROM supplier WHERE idbarang='" & sidbarang & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            supplier_baru = False
            DR.Read()
            idsupplier = Convert.ToString((DR("idsupplier")))
            kode_supplier = Convert.ToString((DR("kode_supplier")))
            nama_supplier = Convert.ToString((DR("nama_supplier")))
            kontak_person = Convert.ToString((DR("kontak_person")))
            email = Convert.ToString((DR("email")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            supplier_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sidbarang As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM supplier WHERE idbarang='" & sidbarang & "'"
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
            strsql = "SELECT * FROM supplier"
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

    Sub getAllData(ByVal dataGridView As DataGridView, ByVal p2 As String)
        Try
            DBConnect()
            strsql = "SELECT * FROM supplier"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dataGridView
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
