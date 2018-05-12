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
                    Return New Result(False, "Lấy tất cả quận không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
