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

    public void SeedDatabase(string[] names, string[] imagePaths, string[] dummy_names){  

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
                cmdFingerprint.Parameters.AddWithValue("@imagePath", imagePaths[i]); 
                cmdFingerprint.Parameters.AddWithValue("@name", names[i]);
                cmdFingerprint.ExecuteNonQuery();

                string queryBiodata = "INSERT INTO biodata (NIK, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, golongan_darah, " +
                "alamat, agama, status_perkawinan, pekerjaan, kewarganegaraan) VALUES (@NIK, @name, 'Ngawi', '1990-01-01', 'Laki-Laki', " +
                "'O', 'Jl. Merdeka No.10', 'Islam', 'Belum Menikah', 'Mahasiswa', 'Indonesia')";
                MySqlCommand cmdBiodata = new MySqlCommand(queryBiodata, connection);
                cmdBiodata.Parameters.AddWithValue("@NIK", $"3201{i}000{i}000{i}");
                cmdBiodata.Parameters.AddWithValue("@name", dummy_names[i]);
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

    public string[] GetAllName()
    {
        List<string> names = new List<string>();  

        try
        {
            OpenConnection();
            string query = "SELECT nama FROM biodata";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())  
            {
                string name = reader["nama"].ToString();
                names.Add(name); 
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

        return names.ToArray(); 
    }

    private class BiodataRecord
    {
        public string NIK { get; set; }
        public string Nama { get; set; }
        public string TempatLahir { get; set; }
        public string GolonganDarah { get; set; }
        public string Alamat { get; set; }
        public string Agama { get; set; }
        public string Pekerjaan { get; set; }
        public string Kewarganegaraan { get; set; }
    }

    public void EncryptAndUpdateBiodata(int key)
    {
        try
        {
            OpenConnection();

            CaesarCipher caesar = new CaesarCipher();

            string selectQuery = "SELECT NIK, nama, tempat_lahir, golongan_darah, alamat, agama, pekerjaan, kewarganegaraan FROM biodata";

            using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection))

            using (MySqlDataReader reader = selectCmd.ExecuteReader())
            {
                List<BiodataRecord> records = new List<BiodataRecord>();

                while (reader.Read())
                {
                    records.Add(new BiodataRecord
                    {
                        NIK = reader["NIK"].ToString(),
                        Nama = reader["nama"].ToString(),
                        TempatLahir = reader["tempat_lahir"].ToString(),
                        GolonganDarah = reader["golongan_darah"].ToString(),
                        Alamat = reader["alamat"].ToString(),
                        Agama = reader["agama"].ToString(),
                        Pekerjaan = reader["pekerjaan"].ToString(),
                        Kewarganegaraan = reader["kewarganegaraan"].ToString()
                    });
                }
                reader.Close();


                foreach (var record in records)
                {
                    string encryptedNIK = caesar.Encrypt(record.NIK, key);
                    string encryptedNama = caesar.Encrypt(record.Nama, key);
                    string encryptedTempatLahir = caesar.Encrypt(record.TempatLahir, key);
                    string encryptedGolonganDarah = caesar.Encrypt(record.GolonganDarah, key);
                    string encryptedAlamat = caesar.Encrypt(record.Alamat, key);
                    string encryptedAgama = caesar.Encrypt(record.Agama, key);
                    string encryptedPekerjaan = caesar.Encrypt(record.Pekerjaan, key);
                    string encryptedKewarganegaraan = caesar.Encrypt(record.Kewarganegaraan, key);

                    string updateQuery = "UPDATE biodata SET " +
                                        "NIK = @encryptedNIK, " +
                                        "nama = @encryptedNama, " +
                                        "tempat_lahir = @encryptedTempatLahir, " +
                                        "golongan_darah = @encryptedGolonganDarah, " +
                                        "alamat = @encryptedAlamat, " +
                                        "agama = @encryptedAgama, " +
                                        "pekerjaan = @encryptedPekerjaan, " +
                                        "kewarganegaraan = @encryptedKewarganegaraan " +
                                        "WHERE NIK = @originalNIK";

                    Console.WriteLine($"Original NIK: {record.NIK}, Encrypted NIK: {encryptedNIK}");

                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@originalNIK", record.NIK);
                        updateCmd.Parameters.AddWithValue("@encryptedNIK", encryptedNIK);
                        updateCmd.Parameters.AddWithValue("@encryptedNama", encryptedNama);
                        updateCmd.Parameters.AddWithValue("@encryptedTempatLahir", encryptedTempatLahir);
                        updateCmd.Parameters.AddWithValue("@encryptedGolonganDarah", encryptedGolonganDarah);
                        updateCmd.Parameters.AddWithValue("@encryptedAlamat", encryptedAlamat);
                        updateCmd.Parameters.AddWithValue("@encryptedAgama", encryptedAgama);
                        updateCmd.Parameters.AddWithValue("@encryptedPekerjaan", encryptedPekerjaan);
                        updateCmd.Parameters.AddWithValue("@encryptedKewarganegaraan", encryptedKewarganegaraan);

                        updateCmd.ExecuteNonQuery();
                    }
                }
            }
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
    }


    public void DecryptAndUpdateBiodata(int key)
    {
        try
        {
            OpenConnection();

            CaesarCipher caesar = new CaesarCipher();

            string selectQuery = "SELECT NIK, nama, tempat_lahir, golongan_darah, alamat, agama, pekerjaan, kewarganegaraan FROM biodata";
            using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection))
            using (MySqlDataReader reader = selectCmd.ExecuteReader())
            {
                List<BiodataRecord> records = new List<BiodataRecord>();

                while (reader.Read())
                {
                    records.Add(new BiodataRecord
                    {
                        NIK = reader["NIK"].ToString(),
                        Nama = reader["nama"].ToString(),
                        TempatLahir = reader["tempat_lahir"].ToString(),
                        GolonganDarah = reader["golongan_darah"].ToString(),
                        Alamat = reader["alamat"].ToString(),
                        Agama = reader["agama"].ToString(),
                        Pekerjaan = reader["pekerjaan"].ToString(),
                        Kewarganegaraan = reader["kewarganegaraan"].ToString()
                    });
                }
                reader.Close();

                foreach (var record in records)
                {
                    string decryptedNIK = caesar.Decrypt(record.NIK, key);
                    string decryptedNama = caesar.Decrypt(record.Nama, key);
                    string decryptedTempatLahir = caesar.Decrypt(record.TempatLahir, key);
                    string decryptedGolonganDarah = caesar.Decrypt(record.GolonganDarah, key);
                    string decryptedAlamat = caesar.Decrypt(record.Alamat, key);
                    string decryptedAgama = caesar.Decrypt(record.Agama, key);
                    string decryptedPekerjaan = caesar.Decrypt(record.Pekerjaan, key);
                    string decryptedKewarganegaraan = caesar.Decrypt(record.Kewarganegaraan, key);

                    string updateQuery = "UPDATE biodata SET " +
                                        "NIK = @decryptedNIK, " +
                                        "nama = @decryptedNama, " +
                                        "tempat_lahir = @decryptedTempatLahir, " +
                                        "golongan_darah = @decryptedGolonganDarah, " +
                                        "alamat = @decryptedAlamat, " +
                                        "agama = @decryptedAgama, " +
                                        "pekerjaan = @decryptedPekerjaan, " +
                                        "kewarganegaraan = @decryptedKewarganegaraan " +
                                        "WHERE NIK = @originalNIK";

                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@originalNIK", record.NIK);
                        updateCmd.Parameters.AddWithValue("@decryptedNIK", decryptedNIK);
                        updateCmd.Parameters.AddWithValue("@decryptedNama", decryptedNama);
                        updateCmd.Parameters.AddWithValue("@decryptedTempatLahir", decryptedTempatLahir);
                        updateCmd.Parameters.AddWithValue("@decryptedGolonganDarah", decryptedGolonganDarah);
                        updateCmd.Parameters.AddWithValue("@decryptedAlamat", decryptedAlamat);
                        updateCmd.Parameters.AddWithValue("@decryptedAgama", decryptedAgama);
                        updateCmd.Parameters.AddWithValue("@decryptedPekerjaan", decryptedPekerjaan);
                        updateCmd.Parameters.AddWithValue("@decryptedKewarganegaraan", decryptedKewarganegaraan);

                        updateCmd.ExecuteNonQuery();
                    }
                }
            }
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
    }

    public void SeedManySidik_Jari(string[] imagePaths)
    {
        if (imagePaths.Length < 600)
        {
            throw new ArgumentException("Jumlah minimal 600.");
        }

        try
        {
            OpenConnection();
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            Random random = new Random();
            HashSet<string> uniqueNames = new HashSet<string>();
            int nameLength = 5;

            for (int i = 0; i < 600; i++)
            {
                string name;
                do
                {
                    name = new string(Enumerable.Repeat(alphabet, nameLength).Select(s => s[random.Next(s.Length)]).ToArray());
                } while (!uniqueNames.Add(name));

                string querySidikJari = "INSERT INTO sidik_jari (berkas_citra, nama) VALUES (@imagePath, @name)";
                MySqlCommand cmdSidikJari = new MySqlCommand(querySidikJari, connection);
                cmdSidikJari.Parameters.AddWithValue("@imagePath", imagePaths[i]);
                cmdSidikJari.Parameters.AddWithValue("@name", name);
                cmdSidikJari.ExecuteNonQuery();
            }
        }
        finally
        {
            CloseConnection();
        }
    }

    public void SeedManyBiodata(string[] names)
    {
        if (names.Length < 600)
        {
            throw new ArgumentException("Nama minimal 600.");
        }

        try
        {
            OpenConnection();
            
            for (int i = 0; i < 600; i++)
            {
                string name = names[i];
                string NIK = (3201000000000 + i).ToString();
                string queryBiodata = "INSERT INTO biodata (NIK, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, golongan_darah, " +
                                    "alamat, agama, status_perkawinan, pekerjaan, kewarganegaraan) VALUES (@NIK, @name, 'Ngawi', '1990-01-01', 'Laki-Laki', " +
                                    "'O', 'Jl. Merdeka No.10', 'Islam', 'Belum Menikah', 'Mahasiswa', 'Indonesia')";
                MySqlCommand cmdBiodata = new MySqlCommand(queryBiodata, connection);
                cmdBiodata.Parameters.AddWithValue("@NIK", NIK);
                cmdBiodata.Parameters.AddWithValue("@name", name);
                cmdBiodata.ExecuteNonQuery();
            }
        }
        finally
        {
            CloseConnection();
        }
    }

    public string[] GetAllNamesFromSidikJari()
    {
        try
        {
            OpenConnection();
            
            string query = "SELECT nama FROM sidik_jari";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            List<string> names = new List<string>();
            
            while (reader.Read())
            {
                names.Add(reader["nama"].ToString());
            }
            
            reader.Close();
            return names.ToArray();
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
    }

    public void SeedManySidik_JariTXT(string[] imagePaths, string[] names)
    {
        if (imagePaths.Length < 600 || names.Length < 600)
        {
            throw new ArgumentException("Jumlah minimal 600 untuk path dan nama.");
        }

        try
        {
            OpenConnection();
            
            for (int i = 0; i < 600; i++)
            {
                string querySidikJari = "INSERT INTO sidik_jari (berkas_citra, nama) VALUES (@imagePath, @name)";
                MySqlCommand cmdSidikJari = new MySqlCommand(querySidikJari, connection);
                cmdSidikJari.Parameters.AddWithValue("@imagePath", imagePaths[i]);
                cmdSidikJari.Parameters.AddWithValue("@name", names[i]);
                cmdSidikJari.ExecuteNonQuery();
            }
        }
        finally
        {
            CloseConnection();
        }
    }

    public void SeedTest(string tempat_lahir){
        OpenConnection();
            
                string NIK = (3201000000000).ToString();
                string queryBiodata = "INSERT INTO biodata (NIK, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, golongan_darah, " +
                                    "alamat, agama, status_perkawinan, pekerjaan, kewarganegaraan) VALUES (@NIK, 'sigit' , @tempat_lahir, '1990-01-01', 'Laki-Laki', " +
                                    "'O', 'Jl. Merdeka No.10', 'Islam', 'Belum Menikah', 'Mahasiswa', 'Indonesia')";
                MySqlCommand cmdBiodata = new MySqlCommand(queryBiodata, connection);
                cmdBiodata.Parameters.AddWithValue("@NIK", NIK);
                cmdBiodata.Parameters.AddWithValue("@tempat_lahir", tempat_lahir);
                cmdBiodata.ExecuteNonQuery();
        
        CloseConnection();
        
    }
}
