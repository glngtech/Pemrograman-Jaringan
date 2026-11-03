using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace PraktikumStream
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Inisialisasi Objek Mahasiswa di Memori (Sisi Pengirim)
            // Tambahkan casting (int) pada NIM untuk menghindari error konversi long ke int
            Mahasiswa mhsOriginal = new Mahasiswa(
                (int)24131310,
                "Gilang",
                "Teknologi Informasi",
                new List<string> { "Pemrograman Jaringan", "Sistem Operasi", "Keamanan Siber" }
            );

            Console.WriteLine("=== DATA OBJEK ASLI DI MEMORI ===");
            mhsOriginal.TampilkanInfo();

            // ==========================================
            // BAGIAN A: SERIALISASI, SIMPAN FILE, & DESERIALISASI JSON
            // ==========================================
            
            // Proses Serialisasi Objek ke JSON String
            string jsonString = JsonSerializer.Serialize(mhsOriginal, new JsonSerializerOptions { WriteIndented = true });
            
            // Simpan ke berkas fisik .json
            string jsonFilePath = "mahasiswa.json";
            File.WriteAllText(jsonFilePath, jsonString);
            Console.WriteLine($"[INFO] Berkas JSON berhasil disimpan ke: {Path.GetFullPath(jsonFilePath)}");

            // Baca kembali berkas fisik menggunakan File.ReadAllText
            string jsonFromFile = File.ReadAllText(jsonFilePath);
            Console.WriteLine("--- ISI BERKAS JSON YANG DIBACA KEMBALI ---");
            Console.WriteLine(jsonFromFile);

            // Proses Deserialisasi dari teks file JSON menjadi Objek Mahasiswa
            Mahasiswa? mhsFromJson = JsonSerializer.Deserialize<Mahasiswa>(jsonFromFile);
            Console.WriteLine("--- HASIL DESERIALISASI DARI BERKAS JSON ---");
            mhsFromJson?.TampilkanInfo();


            // ==========================================
            // BAGIAN B: SERIALISASI, SIMPAN FILE, & DESERIALISASI XML
            // ==========================================
            
            // Proses Serialisasi Objek ke XML String
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Mahasiswa));
            string xmlString = "";
            
            using (StringWriter sw = new StringWriter())
            {
                xmlSerializer.Serialize(sw, mhsOriginal);
                xmlString = sw.ToString();
            }

            // Simpan ke berkas fisik .xml
            string xmlFilePath = "mahasiswa.xml";
            File.WriteAllText(xmlFilePath, xmlString);
            Console.WriteLine($"[INFO] Berkas XML berhasil disimpan ke: {Path.GetFullPath(xmlFilePath)}");

            // Baca kembali berkas fisik menggunakan File.ReadAllText
            string xmlFromFile = File.ReadAllText(xmlFilePath);
            Console.WriteLine("--- ISI BERKAS XML YANG DIBACA KEMBALI ---");
            Console.WriteLine(xmlFromFile);

            // Proses Deserialisasi dari teks file XML menjadi Objek Mahasiswa
            Mahasiswa? mhsFromXml;
            using (StringReader sr = new StringReader(xmlFromFile))
            {
                mhsFromXml = (Mahasiswa?)xmlSerializer.Deserialize(sr);
            }
            
            Console.WriteLine("--- HASIL DESERIALISASI DARI BERKAS XML ---");
            mhsFromXml?.TampilkanInfo();
        }
    }
}