﻿Imports System.Configuration
Imports System.Data.SqlClient
Imports QLDLDTO
Imports Utility

Public Class HoSoDaiLyDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub

    Public Function buildMaDaiLy(ByRef nextMaDaiLy As Integer) As Result
        Dim MaOnDB As Integer
        Dim query As String = String.Empty
        query &= " SELECT IDENT_CURRENT('HOSODAILY')"
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
                            MaOnDB = Convert.ToInt32(reader.GetValue(0))
                        End While
                    End If

                Catch ex As Exception
                    conn.Close() ' that bai!!!
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tự động Mã Đại Lý kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using




        query = String.Empty
        query &= "SELECT * FROM [HOSODAILY] where [MaDaiLy] = @MaDaiLy"
        'neu has row thi nextMshs = "SELECT IDENT_CURRENT('HOCSINH')" + 1
        'neu khong co row thì next Mshs = 1;
        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaDaiLy", MaOnDB)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        nextMaDaiLy = 1 + MaOnDB
                    Else
                        nextMaDaiLy = MaOnDB
                    End If
                Catch ex As Exception
                    conn.Close() ' that bai!!!
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tự động Mã Đại Lý kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function


    Public Function insert(daiLy As HoSoDaiLyDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [HOSODAILY] ( [TenDaiLy], [MaLoaiDaiLy], [DienThoai], [DiaChi],[MaQuan],[NgayTiepNhan],[Email],[NoCuaDaiLy])"
        query &= "VALUES (@TenDaiLy,@MaLoaiDaiLy,@DienThoai,@DiaChi,@MaQuan,@NgayTiepNhan,@Email,@NoCuaDaiLy)"


        Dim nextMaDaiLy = "1"
        buildMaDaiLy(nextMaDaiLy)
        daiLy.MaDaiLy = nextMaDaiLy

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query

                    .Parameters.AddWithValue("@TenDaiLy", daiLy.TenDaiLy)
                    .Parameters.AddWithValue("@MaLoaiDaiLy", daiLy.MaLoaiDaiLy)
                    .Parameters.AddWithValue("@DienThoai", daiLy.DienThoai)
                    .Parameters.AddWithValue("@DiaChi", daiLy.DiaChi)
                    .Parameters.AddWithValue("@MaQuan", daiLy.MaQuan)
                    .Parameters.AddWithValue("@NgayTiepNhan", daiLy.NgayTiepNhan)
                    .Parameters.AddWithValue("@Email", daiLy.Email)
                    .Parameters.AddWithValue("@NoCuaDaiLy", daiLy.NoCuaDaiLy)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm thẻ Đại lý không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function update(dl As HoSoDaiLyDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [HOSODAILY] SET"
        query &= " [TenDaiLy] = @TenDaiLy "
        query &= " ,[MaLoaiDaiLy] = @MaLoaiDaiLy "
        query &= " ,[DienThoai] = @DienThoai "
        query &= " ,[DiaChi] = @DiaChi "
        query &= " ,[MaQuan] = @MaQuan "
        query &= " ,[NgayTiepNhan] = @NgayTiepNhan "
        query &= " ,[Email] = @Email "
        query &= " WHERE "
        query &= " [MaDaiLy] = @MaDaiLy "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaDaiLy", dl.MaDaiLy)
                    .Parameters.AddWithValue("@MaLoaiDaiLy", dl.MaLoaiDaiLy)
                    .Parameters.AddWithValue("@MaQuan", dl.MaQuan)
                    .Parameters.AddWithValue("@NgayTiepNhan", dl.NgayTiepNhan)
                    .Parameters.AddWithValue("@NoCuaDaiLy", dl.NoCuaDaiLy)
                    .Parameters.AddWithValue("@TenDaiLy", dl.TenDaiLy)
                    .Parameters.AddWithValue("@DienThoai", dl.DienThoai)
                    .Parameters.AddWithValue("@Email", dl.Email)
                    .Parameters.AddWithValue("@DiaChi", dl.DiaChi)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Đại Lý không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function delete(MaDaiLy As String) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [HoSoDaiLy] "
        query &= " WHERE "
        query &= " [MaDaiLy] = @MaDaiLy "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaDaiLy", MaDaiLy)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Xóa Đại Lý không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)  ' thanh cong
    End Function
    Public Function selectALL(ByRef listDaiLy As List(Of HoSoDaiLyDTO)) As Result

        Dim query As String = String.Empty
        query &= "SELECT [MaDaiLy], [MaLoaiDaiLy], [TenDaiLy], [DienThoai],[DiaChi],[MaQuan],[NgayTiepNhan],[Email], [NoCuaDaiLy] "
        query &= "FROM [HoSoDaiLy] "



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
                        listDaiLy.Clear()
                        While reader.Read()
                            listDaiLy.Add(New HoSoDaiLyDTO(reader("MaDaiLy"), reader("MaLoaiDaiLy"), reader("TenDaiLy"), reader("DienThoai"), reader("DiaChi"), reader("MaQuan"), reader("NgayTiepNhan"), reader("Email"), reader("NoCuaDaiLy")))
                        End While
                    End If

                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tất cả Đại Lý không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL_ByType(MaLoaiDaiLy As Integer, ByRef ListDaiLy As List(Of HoSoDaiLyDTO)) As Result

        Dim query As String = String.Empty
        query &= "SELECT [MaDaiLy], [MaLoaiDaiLy], [TenDaiLy], [DienThoai],[DiaChi],[MaQuan],[NgayTiepNhan],[Email], [NoCuaDaiLy] "
        query &= "FROM [HoSoDaiLy] "
        query &= "WHERE [MaLoaiDaiLy] = @MaLoaiDaiLy "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaLoaiDaiLy", MaLoaiDaiLy)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        ListDaiLy.Clear()
                        While reader.Read()
                            ListDaiLy.Add(New HoSoDaiLyDTO(reader("MaDaiLy"), reader("TenDaiLy"), reader("MaLoaiDaiLy"), reader("DienThoai"), reader("DiaChi"), reader("MaQuan"), reader("NgayTiepNhan"), reader("Email"), reader("NoCuaDaiLy")))
                        End While
                    End If

                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tất cả Đại Lý theo Loại không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

End Class
