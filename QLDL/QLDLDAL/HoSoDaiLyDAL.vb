Imports System.Configuration
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
        query &= "INSERT INTO [HOSODAILY] ( [Ten], [MaLoaiDaiLy], [DienThoai], [DiaChi],[MaQuan],[NgayTiepNhan],[Email])"
        query &= "VALUES (@Ten,@MaLoaiDaiLy,@DienThoai,@DiaChi,@MaQuan,@NgayTiepNhan,@Email)"


        Dim nextMaDaiLy = "1"
        buildMaDaiLy(nextMaDaiLy)
        daiLy.MaDaiLy = nextMaDaiLy

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query

                    .Parameters.AddWithValue("@Ten", daiLy.Ten)
                    .Parameters.AddWithValue("@MaLoaiDaiLy", daiLy.MaLoaiDaiLy)
                    .Parameters.AddWithValue("@DienThoai", daiLy.DienThoai)
                    .Parameters.AddWithValue("@DiaChi", daiLy.DiaChi)
                    .Parameters.AddWithValue("@MaQuan", daiLy.MaQuan)
                    .Parameters.AddWithValue("@NgayTiepNhan", daiLy.NgayTiepNhan)
                    .Parameters.AddWithValue("@Email", daiLy.Email)
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


End Class
