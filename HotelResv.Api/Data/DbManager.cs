using System.Data;
using MySql.Data.MySqlClient;

public class DbManager
{
    public readonly string connectionString;
    private readonly MySqlConnection _connection;
    public DbManager(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
        _connection = new MySqlConnection(connectionString);
    }

    public List<Kamar> GetAllKamars()
    {
        List<Kamar> kamarList = new List<Kamar>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM kamar";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Kamar kamar = new Kamar
                        {
                            id = Convert.ToInt32(reader["id"]),
                            nomor_kamar = reader["nomor_kamar"].ToString(),
                            tipe_kamar = reader["tipe_kamar"].ToString(),
                            harga = Convert.ToInt32(reader["harga"]),
                            ketersediaan = Convert.ToInt32(reader["ketersediaan"]),
                        };
                        kamarList.Add(kamar);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return kamarList;
    }

    public Kamar GetKamarById(int id)
    {   
        Kamar kamar = null;
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM kamar WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        kamar = new Kamar
                        {
                            id = Convert.ToInt32(reader["id"]),
                            nomor_kamar = reader["nomor_kamar"].ToString(),
                            tipe_kamar = reader["tipe_kamar"].ToString(),
                            harga = Convert.ToInt32(reader["harga"]),
                            ketersediaan = Convert.ToInt32(reader["ketersediaan"]),
                        };
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return kamar;
    }

    public int CreateKamar(Kamar kamar)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "INSERT INTO kamar (nomor_kamar, tipe_kamar, harga, ketersediaan) VALUES (@nomor_kamar, @tipe_kamar, @harga, 1)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nomor_kamar", kamar.nomor_kamar);
                command.Parameters.AddWithValue("@tipe_kamar", kamar.tipe_kamar);
                command.Parameters.AddWithValue("@harga", kamar.harga);
                command.Parameters.AddWithValue("@ketersediaan", kamar.ketersediaan);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public int UpdateKamar(int id, Kamar kamar)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "UPDATE kamar SET nomor_kamar = @nomor_kamar, tipe_kamar = @tipe_kamar, harga = @harga, ketersediaan = @ketersediaan WHERE id = @id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nomor_kamar", kamar.nomor_kamar);
                command.Parameters.AddWithValue("@tipe_kamar", kamar.tipe_kamar);
                command.Parameters.AddWithValue("@harga", kamar.harga);
                command.Parameters.AddWithValue("@ketersediaan", kamar.ketersediaan);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public int DeleteKamar(int id)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "DELETE FROM kamar WHERE id = @id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    // Pengunjung
    public List<Pengunjung> GetAllPengunjungs()
    {
        List<Pengunjung> pengunjungList = new List<Pengunjung>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM pengunjung";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pengunjung pengunjung = new Pengunjung
                        {
                            id = Convert.ToInt32(reader["id"]),
                            nama = reader["nama"].ToString(),
                            alamat = reader["alamat"].ToString(),
                            email = reader["email"].ToString(),
                            telepon = reader["telepon"].ToString(),
                        };
                        pengunjungList.Add(pengunjung);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return pengunjungList;
    }

    public Pengunjung GetPengunjungById(int id)
    {   
        Pengunjung pengunjung = null;
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM pengunjung WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pengunjung = new Pengunjung
                        {
                            nama = reader["nama"].ToString(),
                            alamat = reader["alamat"].ToString(),
                            email = reader["email"].ToString(),
                            telepon = reader["telepon"].ToString(),
                        };
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return pengunjung;
    }

    public int CreatePengunjung(Pengunjung pengunjung)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "INSERT INTO pengunjung (nama, alamat, email, telepon) VALUES (@nama, @alamat, @email, @telepon)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nama", pengunjung.nama);
                command.Parameters.AddWithValue("@alamat", pengunjung.alamat);
                command.Parameters.AddWithValue("@email", pengunjung.email);
                command.Parameters.AddWithValue("@telepon", pengunjung.telepon);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public int UpdatePengunjung(int id, Pengunjung pengunjung)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "UPDATE pengunjung SET nama = @nama, alamat = @alamat, email = @email, telepon = @telepon WHERE id = @id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nama", pengunjung.nama);
                command.Parameters.AddWithValue("@alamat", pengunjung.alamat);
                command.Parameters.AddWithValue("@email", pengunjung.email);
                command.Parameters.AddWithValue("@telepon", pengunjung.telepon);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public int DeletePengunjung(int id)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "DELETE FROM pengunjung WHERE id = @id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    // reservasi
    public List<Reservasi> GetAllReservasis()
    {
        List<Reservasi> reservasiList = new List<Reservasi>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT `reservasi`.*, `pengunjung`.`nama`, `kamar`.`nomor_kamar`, `karyawan`.`nama_lengkap` FROM `reservasi` LEFT JOIN `pengunjung` ON `pengunjung`.`id` = `reservasi`.`id_pengunjung` LEFT JOIN `kamar` ON `kamar`.`id` = `reservasi`.`id_kamar` LEFT JOIN `karyawan` ON `karyawan`.`id` = `reservasi`.`id_karyawan`";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Reservasi reservasi = new Reservasi
                        {
                            id = Convert.ToInt32(reader["id"]),
                            id_karyawan = reader.IsDBNull(reader.GetOrdinal("id_karyawan")) ? 0 : Convert.ToInt32(reader["id_karyawan"]),
                            id_pengunjung = reader.IsDBNull(reader.GetOrdinal("id_pengunjung")) ? 0 : Convert.ToInt32(reader["id_pengunjung"]),
                            id_kamar = reader.IsDBNull(reader.GetOrdinal("id_kamar")) ? 0 : Convert.ToInt32(reader["id_kamar"]),
                            tanggal_checkin = Convert.ToDateTime(reader["tanggal_checkin"]),
                            tanggal_checkout = Convert.ToDateTime(reader["tanggal_checkout"]),
                            lama_hari = Convert.ToInt32(reader["lama_hari"]),
                            total_harga = Convert.ToInt32(reader["total_harga"]),
                            status_pembayaran = Convert.ToInt32(reader["status_pembayaran"]),
                            nama = reader["nama"].ToString(),
                            nomor_kamar = reader["nomor_kamar"].ToString(),
                            nama_lengkap = reader["nama_lengkap"].ToString()
                        };
                        reservasiList.Add(reservasi);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return reservasiList;
    }

    public Reservasi GetReservasiById(int id)
    {
        Reservasi reservasi = null;
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM reservasi WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reservasi = new Reservasi
                        {
                            id = Convert.ToInt32(reader["id"]),
                            id_karyawan = Convert.ToInt32(reader["id_karyawan"]),
                            id_pengunjung = Convert.ToInt32(reader["id_pengunjung"]),
                            id_kamar = Convert.ToInt32(reader["id_kamar"]),
                            tanggal_checkin = Convert.ToDateTime(reader["tanggal_checkin"]),
                            tanggal_checkout = Convert.ToDateTime(reader["tanggal_checkout"]),
                            lama_hari = Convert.ToInt32(reader["lama_hari"]),
                            total_harga = Convert.ToDecimal(reader["total_harga"]),
                            status_pembayaran = Convert.ToInt32(reader["status_pembayaran"]),
                        };
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return reservasi;
    }

}
