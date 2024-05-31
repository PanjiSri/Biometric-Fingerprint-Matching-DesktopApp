namespace Tubes3_let_me_seedik;

using MySql.Data.MySqlClient;
using System;

public class DatabaseManager
{
    private MySqlConnection connection;

    public DatabaseManager(string connectionString)
    {
        connection = new MySqlConnection(connectionString);
    }

    public void OpenConnection()
    {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
                throw;
            }
    }

    public void CloseConnection()
    {
        if (connection.State == System.Data.ConnectionState.Open)
            connection.Close();
    }

    public void InsertFingerprintRecord(string imagePath)
    {
        try
        {
            OpenConnection();
            string query = "INSERT INTO sidik_jari (berkas_citra, nama) VALUES (@imagePath, NULL)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@imagePath", imagePath);
            cmd.ExecuteNonQuery();
        }
        finally
        {
            CloseConnection();
        }
    } 

    public void RetrieveFingerprints()
    {
        try
        {
            OpenConnection();
            string query = "SELECT * FROM sidik_jari LIMIT 20";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["berkas_citra"].ToString());
            }
            reader.Close();
        }
        finally
        {
            CloseConnection();
        }
    }

    public void ClearFingerprintTable()
    {
        try
        {
            OpenConnection();
            string query = "TRUNCATE TABLE sidik_jari";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Isi tabel sidik_jari berhasil dihapus");
        }
        finally
        {
            CloseConnection();
        }
    }
}
