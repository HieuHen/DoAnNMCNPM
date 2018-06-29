Imports System.Configuration
Imports System.Data.SqlClient
Imports QLDLDTO
Imports Utility

Public Class MatHangDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub

    Public Function buildMaMatHang(ByRef nextMaMatHang As Integer) As Result
        Dim MaMHonDB As Integer
        Dim query As String = String.Empty
        query &= " SELECT IDENT_CURRENT('MATHANG')"
        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        While reader.Read()
                            MaMHonDB = Convert.ToInt32(reader.GetValue(0))
                        End While
                    End If

                Catch ex As Exception
                    conn.Close() ' that bai!!!
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tự động Mã Mặt Hàng kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using




        query = String.Empty
        query &= "SELECT * FROM [MATHANG] where [MaMatHang] = @MaMatHang"
        'neu has row thi nextMshs = "SELECT IDENT_CURRENT('HOCSINH')" + 1
        'neu khong co row thì next Mshs = 1;
        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaMatHang", MaMHonDB)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        nextMaMatHang = 1 + MaMHonDB
                    Else
                        nextMaMatHang = MaMHonDB
                    End If
                Catch ex As Exception
                    conn.Close() ' that bai!!!
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tự động Mã Mặt Hàng kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function insert(MatHang As MatHangDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [MATHANG] (  [TenMatHang], [SoLuongTon])"
        query &= "VALUES (@TenMatHang,@SoLuongTon)"


        Dim nextMaMatHang = "1"
        buildMaMatHang(nextMaMatHang)
        MatHang.MaMatHang = nextMaMatHang

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@TenMatHang", MatHang.TenMatHang)
                    .Parameters.AddWithValue("@SoLuongTon", MatHang.SoLuongTon)

                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm Mặt Hàng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function update(mh As MatHangDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [MATHANG] SET"
        query &= " [TenMatHang] = @TenMatHang "
        query &= " ,[SoLuongTon] = @SoLuongTon "
        query &= " WHERE "
        query &= " [MaMatHang] = @MaMatHang "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaMatHang", mh.MaMatHang)
                    .Parameters.AddWithValue("@TenMatHang", mh.TenMatHang)
                    .Parameters.AddWithValue("@SoLuongTon", mh.SoLuongTon)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Mặt Hàng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL(ByRef listMatHang As List(Of MatHangDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [MaMatHang], [TenMatHang], [SoLuongTon]"
        query &= " FROM [MatHang]"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listMatHang.Clear()
                        While reader.Read()
                            listMatHang.Add(New MatHangDTO(reader("MaMatHang"), reader("TenMatHang"), reader("SoLuongTon")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Mặt Hàng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL_ByMaMatHang(iMaMatHang As Integer, ByRef listMatHang As List(Of MatHangDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [MaMattHang], [TenMatHang], [SoLuongTon]"
        query &= " FROM [MATHANG]"
        query &= " WHERE "
        query &= " [MaMatHang] = @MaMatHang"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaMatMang", iMaMatHang)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listMatHang.Clear()
                        While reader.Read()
                            listMatHang.Add(New MatHangDTO(reader("MaMatHang"), reader("TenMatHang"), reader("SoLuongTon")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Mặt Hàng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function delete(MaMatHang As Integer) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [MATHANG] "
        query &= " WHERE "
        query &= " [MaMatHang] = @MaMatHang "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaMatHang", MaMatHang)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Mặt Hàng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
