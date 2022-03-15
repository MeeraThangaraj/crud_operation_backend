using Carousal.BOs;
using Npgsql;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Carousal.Helpers.DataStore
{
    public struct CarousalSchema
    {
        public enum CarousalDataTable
        {
            [Description("sample.content_table")]
            content_table,
        }
        public enum CarousalFunctions
        {
            [Description("SELECT sample.add_content_table(@_content_id,@_image, @_description)")]
            add_content_table,
            [Description("SELECT (sample.fetch_all_content_table()).*")]
            fetch_all_content_table,
            [Description("SELECT sample.delete_content_table(@_content_id)")]
            delete_content_table,
            [Description("SELECT sample.update_content_table(@_content_id,@_image, @_description)")]
            update_content_table,
            [Description("SELECT (sample.fetch_one_content(@_content_id)).*")]
            fetch_one_content

        }
        public static ObservableCollection<CarousalBO> FetchAllCarousalData()
        {
            ObservableCollection<CarousalBO> DataList = new ObservableCollection<CarousalBO>();
            using (NpgsqlConnection sqlConnection = new NpgsqlConnection("User ID=postgres;Password=Ramy@2307$;Host=localhost;Port=5432;Database=postgres;"))
            {
                sqlConnection.Open();
                using (NpgsqlCommand sqlCommand = new NpgsqlCommand("SELECT (sample.fetch_all_content_table()).*", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;

                    var reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        DataList.Add(new CarousalBO()
                        {
                            Id = reader.IsDBNull(reader.GetOrdinal("content_id")) ? -1 : reader.GetInt32(reader.GetOrdinal("content_id")),
                            Image = reader.IsDBNull(reader.GetOrdinal("image")) ? null : reader.GetString(reader.GetOrdinal("image")),
                            Description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal("description")),

                        });
                    }
                    sqlConnection.Close();
                }
            }

            return DataList;
        }
        public static int AddCarousalData(int content_id,string image, string description)
        {
            using (NpgsqlConnection sqlConnection = new NpgsqlConnection("User ID=postgres;Password=Ramy@2307$;Host=localhost;Port=5432;Database=postgres;"))
            {
                sqlConnection.Open();

                using (NpgsqlCommand sqlCommand = new NpgsqlCommand("SELECT sample.add_content_table(@_content_id,@_image, @_description)", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@_content_id", content_id);
                    sqlCommand.Parameters.AddWithValue("@_image", image);
                    sqlCommand.Parameters.AddWithValue("@_description", description);
                    var reader = sqlCommand.ExecuteReader();
                    return DBOperation.CheckNonQueryStatus(reader, sqlConnection);
                }
            }
        }
        public static int DeleteCarousalData(int content_id)
        {
            using (NpgsqlConnection sqlConnection = new NpgsqlConnection("User ID=postgres;Password=Ramy@2307$;Host=localhost;Port=5432;Database=postgres;"))
            {
                sqlConnection.Open();

                using (NpgsqlCommand sqlCommand = new NpgsqlCommand("SELECT sample.delete_content_table(@_content_id)", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@_content_id", content_id);

                    var reader = sqlCommand.ExecuteReader();
                    return DBOperation.CheckNonQueryStatus(reader, sqlConnection);
                }
            }
        }
        public static int UpdateCarousalData(int content_id, string image, string description)
        {
            using (NpgsqlConnection sqlConnection = new NpgsqlConnection("User ID=postgres;Password=Ramy@2307$;Host=localhost;Port=5432;Database=postgres;"))
            {
                sqlConnection.Open();

                using (NpgsqlCommand sqlCommand = new NpgsqlCommand("SELECT sample.update_content_table(@_content_id,@_image, @_description)", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@_content_id", content_id);
                    sqlCommand.Parameters.AddWithValue("@_image", image);
                    sqlCommand.Parameters.AddWithValue("@_description", description);
                    var reader = sqlCommand.ExecuteReader();
                    return DBOperation.CheckNonQueryStatus(reader, sqlConnection);
                }
            }
        }
        public static ObservableCollection<CarousalBO> FetchOneCarousalContent(int content_id)
        {
            ObservableCollection<CarousalBO> DataList = new ObservableCollection<CarousalBO>();
            using (NpgsqlConnection sqlConnection = new NpgsqlConnection("User ID=postgres;Password=Ramy@2307$;Host=localhost;Port=5432;Database=postgres;"))
            {
                sqlConnection.Open();
                using (NpgsqlCommand sqlCommand = new NpgsqlCommand("SELECT (sample.fetch_one_content(@_content_id)).*", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                   
                    sqlCommand.Parameters.AddWithValue("@_content_id", content_id);
                    var reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        DataList.Add(new CarousalBO()
                        {
                            Id = reader.IsDBNull(reader.GetOrdinal("content_id")) ? -1 : reader.GetInt32(reader.GetOrdinal("content_id")),
                            Image = reader.IsDBNull(reader.GetOrdinal("image")) ? null : reader.GetString(reader.GetOrdinal("image")),
                            Description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal("description")),

                        });
                    }
                    sqlConnection.Close();
                }
            }

            return DataList;
        }
    }
}
