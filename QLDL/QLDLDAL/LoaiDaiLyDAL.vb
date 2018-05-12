Imports System.Configuration
Imports System.Data.SqlClient
Imports QLDLDTO
Imports Utility


Public Class LoaiDaiLyDAL
    Private connectionString As String
    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")

    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub
    Public Function selectALL(ByRef listLoaiDaiLy As List(Of LoaiDaiLyDTO)) As Result
        Dim query As String = String.Empty
        query &= "SELECT [MaLoaiDaiLy], [TenLoaiDaiLy]"
        query &= "FROM [LOAIDAILY]"
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
                        listLoaiDaiLy.Clear()
                        While reader.Read()
                            listLoaiDaiLy.Add(New LoaiDaiLyDTO(reader("MaLoaiDaiLy"), reader("TenLoaiDaiLy")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tất cả loại đại lý không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
