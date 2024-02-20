public class Reservasi
{
    public int id { get; set; }
    public int id_karyawan { get; set; }
    public int id_pengunjung { get; set; }
    public int id_kamar { get; set; }
    public DateTime tanggal_checkin { get; set; }
    public DateTime tanggal_checkout { get; set; }
    public int lama_hari { get; set; }
    public decimal total_harga { get; set; }
    public int status_pembayaran { get; set; }
    public string nama { get; set; }
    public string nomor_kamar { get; set; }
    public string nama_lengkap { get; set; }
}