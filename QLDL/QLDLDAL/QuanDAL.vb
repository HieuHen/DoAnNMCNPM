Imports System.Configuration
Imports System.Data.SqlClient
Imports QLDLDTO
Imports Utility


Public Class QuanDAL
    Private connectionString As String
    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")

    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub
    Public Function buildMaQuan(ByRef nextMaQuan As Integer) As Result
        Dim MaQonDB As Integer
        Dim query As String = String.Empty
        query &= " SELECT IDENT_CURRENT('QUAN')"
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
                            MaQonDB = Convert.ToInt32(reader.GetValue(0))
                        End While
                    End If

                Catch ex As Exception
                    conn.Close() ' that bai!!!
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tự động Mã Quận kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using




        query = String.Empty
        query &= "SELECT * FROM [QUAN] where [MaQuan] = @MaQuan"
        'neu has row thi nextMshs = "SELECT IDENT_CURRENT('HOCSINH')" + 1
        'neu khong co row thì next Mshs = 1;
        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaQuan", MaQonDB)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        nextMaQuan = 1 + MaQonDB
                    Else
                        nextMaQuan = MaQonDB
                    End If
                Catch ex As Exception
                    conn.Close() ' that bai!!!
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tự động Mã Quận kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function insert(Quan As QuanDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [QUAN] (  [TenQuan], [SoLuongDaiLyToiDa])"
        query &= "VALUES (@TenQuan,@SoLuongDaiLyToiDa)"


        Dim nextMaQuan = "1"
        buildMaQuan(nextMaQuan)
        Quan.MaQuan = nextMaQuan

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@TenQuan", Quan.TenQuan)
                    .Parameters.AddWithValue("@SoLuongDaiLyToiDa", Quan.SoLuongDaiLyToida)

                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm Quận không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function update(qu As QuanDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [QUAN] SET"
        query &= " [TenQuan] = @TenQuan "
        query &= " ,[SoLuongDaiLyToiDa] = @SoLuongDaiLyToiDA "
        query &= " WHERE "
        query &= " [MaQuan] = @MaQuan "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaQuan", qu.MaQuan)
                    .Parameters.AddWithValue("@TenQuan", qu.TenQuan)
                    .Parameters.AddWithValue("@SoLuongDaiLyToiDa", qu.SoLuongDaiLyToiDa)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Quận không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function delete(MaQuan As Integer) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [QUAN] "
        query &= " WHERE "
        query &= " [MaQuan] = @MaQuan "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaQuan", MaQuan)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Quận không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL(ByRef listQuan As List(Of QuanDTO)) As Result
        Dim query As String = String.Empty
        query &= "SELECT [MaQuan], [TenQuan],[SoLuongDaiLyToiDa]"
        query &= "FROM [QUAN]"
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
                        listQuan.Clear()
                        While reader.Read()
                            listQuan.Add(New QuanDTO(reader("MaQuan"), reader("TenQuan"), reader("SoLuongDaiLyToida")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tất cả quận không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectAvailableQuan(ByRef listQuan As List(Of QuanDTO)) As Result
        Dim query As String = String.Empty
        query &= "SELECT [MaQuan], [TenQuan], [SoLuongDaiLyToida]"
        query &= "FROM [QUAN] AS [Q]"
        query &= "WHERE [SoLuongDaiLyToida] > (SELECT COUNT([MaDaiLy]) FROM [HOSODAILY] AS [HSDL] WHERE [Q].[MaQuan] = [HSDL].[MaQuan] )"
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
                        listQuan.Clear()
                        While reader.Read()
                            listQuan.Add(New QuanDTO(reader("MaQuan"), reader("TenQuan"), reader("SoLuongDaiLyToida")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tất cả Quận không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL_ByMaQuan(iMaQuan As Integer, ByRef listQuan As List(Of QuanDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [MaQuan], [TenQuan], [SoLuongDaiLyToiDa]"
        query &= " FROM [QUAN]"
        query &= " WHERE "
        query &= " [MaQuan] = @MaQuan"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaQuan", iMaQuan)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listQuan.Clear()
                        While reader.Read()
                            listQuan.Add(New QuanDTO(reader("MaQuan"), reader("TenQuan"), reader("SoLuongDaiLyToiDa")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Quận không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
