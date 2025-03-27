using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul7_2211104027
{
    public class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    public class Course
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class DataMahasiswa2211104027
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public List<Course> Courses { get; set; }

        public static void ReadJSON()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jurnal7_1_2211104027.json");
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                DataMahasiswa2211104027 mahasiswa = JsonSerializer.Deserialize<DataMahasiswa2211104027>(jsonContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                Console.WriteLine("=== Data Mahasiswa ===");
                Console.WriteLine($"Nama: {mahasiswa.FirstName} {mahasiswa.LastName}");
                Console.WriteLine($"Gender: {mahasiswa.Gender}");
                Console.WriteLine($"Usia: {mahasiswa.Age}");
                Console.WriteLine($"Alamat: {mahasiswa.Address.StreetAddress}, {mahasiswa.Address.City}, {mahasiswa.Address.State}");
                Console.WriteLine("Mata Kuliah:");
                foreach (var course in mahasiswa.Courses)
                {
                    Console.WriteLine($"- {course.Code}: {course.Name}");
                }
            }
            else
            {
                Console.WriteLine("File JSON tidak ditemukan!");
                Console.WriteLine($"Mencari di: {filePath}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            DataMahasiswa2211104027.ReadJSON();
        }
    }
}
