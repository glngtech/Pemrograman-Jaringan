using System;
using System.Collections.Generic;

namespace PraktikumStream
{
    [Serializable]
    public class Mahasiswa
    {
        // Ubah tipe data dari int ke long agar bisa menampung angka NIM yang panjang
        public long NIM { get; set; }
        public string Nama { get; set; } = string.Empty;
        public string Jurusan { get; set; } = string.Empty;
        public List<string> Matakuliah { get; set; } = new();

        // Constructor kosong wajib ada untuk proses Deserialisasi XML
        public Mahasiswa() { }

        // Parameter nim diubah tipe datanya menjadi long
        public Mahasiswa(long nim, string nama, string jurusan, List<string> matkul)
        {
            NIM = nim;
            Nama = nama;
            Jurusan = jurusan;
            Matakuliah = matkul;
        }

        public void TampilkanInfo()
        {
            Console.WriteLine($"NIM     : {NIM}");
            Console.WriteLine($"Nama    : {Nama}");
            Console.WriteLine($"Jurusan : {Jurusan}");
            Console.WriteLine($"Matkul  : {string.Join(", ", Matakuliah)}");
            Console.WriteLine("----");
        }
    }
}