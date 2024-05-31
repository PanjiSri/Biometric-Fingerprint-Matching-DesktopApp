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

    public void ClearBiodataTable()
    {
        try
        {
            OpenConnection();
            string query = "TRUNCATE TABLE biodata";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Isi tabel biodata berhasil dihapus");
        }
        finally
        {
            CloseConnection();
        }
    }

    public void SeedDatabase(string[] names, string[] imagePaths){  

        if(names.Length != imagePaths.Length){
            Console.WriteLine("Panjang nama dummy dan path gambar dummy tidak sama");
            return;
        }

        try
        {
            OpenConnection();
            for(int i = 0; i < names.Length; i++){
                string queryFingerprint = "INSERT INTO sidik_jari (berkas_citra, nama) VALUES (@imagePath, @name)";
                MySqlCommand cmdFingerprint = new MySqlCommand(queryFingerprint, connection);
                cmdFingerprint.Parameters.AddWithValue("@imagePath", imagePaths[i]);  // Konsisten dengan nama parameter
                cmdFingerprint.Parameters.AddWithValue("@name", names[i]);
                cmdFingerprint.ExecuteNonQuery();

                string queryBiodata = "INSERT INTO biodata (NIK, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, golongan_darah, " +
                "alamat, agama, status_perkawinan, pekerjaan, kewarganegaraan) VALUES (@NIK, @name, 'Ngawi', '1990-01-01', 'Laki-Laki', " +
                "'O', 'Jl. Merdeka No.10', 'Islam', 'Belum Menikah', 'Mahasiswa', 'Indonesia')";
                MySqlCommand cmdBiodata = new MySqlCommand(queryBiodata, connection);
                cmdBiodata.Parameters.AddWithValue("@NIK", $"3201{i}000{i}000{i}");
                cmdBiodata.Parameters.AddWithValue("@name", names[i]);
                cmdBiodata.ExecuteNonQuery();
            }
        }
        finally{
            CloseConnection();
        }
    }

    public string GetName(string path){
        string name = null;  
        try
        {
            OpenConnection();
            string query = "SELECT nama FROM sidik_jari WHERE berkas_citra = @path";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@path", path);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())  
            {
                name = reader["nama"] as string; 
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
        finally
        {
            CloseConnection();
        }
        return name;
    }

    public string[] GetBiodata(string nama)
    {
        string[] biodata = null;
        try
        {
            OpenConnection();
            string query = "SELECT NIK, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, golongan_darah, " +
                        "alamat, agama, status_perkawinan, pekerjaan, kewarganegaraan FROM biodata WHERE nama = @nama";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nama", nama);
            MySqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            biodata = new string[] {
                reader["NIK"].ToString(),
                reader["nama"].ToString(),
                reader["tempat_lahir"].ToString(),
                Convert.ToDateTime(reader["tanggal_lahir"]).ToString("yyyy-MM-dd"),
                reader["jenis_kelamin"].ToString(),
                reader["golongan_darah"].ToString(),
                reader["alamat"].ToString(),
                reader["agama"].ToString(),
                reader["status_perkawinan"].ToString(),
                reader["pekerjaan"].ToString(),
                reader["kewarganegaraan"].ToString()
            };
        }
        reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
        finally
        {
            CloseConnection();
        }

        return biodata;
    }

    public string[] GetAllPath()
    {
        List<string> paths = new List<string>();  

        try
        {
            OpenConnection();
            string query = "SELECT berkas_citra FROM sidik_jari";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())  
            {
                string path = reader["berkas_citra"].ToString();
                paths.Add(path); 
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
        finally
        {
            CloseConnection();
        }

        return paths.ToArray(); 
    }

}
