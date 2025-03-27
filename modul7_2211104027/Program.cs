using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul7_2211104027
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Nim { get; set; }
    }

    public class TeamData
    {
        public List<Member> Members { get; set; }
    }

    public class TeamMembers2211104027
    {
        public static void ReadJSON()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "jurnal7_2_2211104027.json");

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File JSON tidak ditemukan!");
                Console.WriteLine($"Mencari di: {filePath}");
                return;
            }

            string jsonContent = File.ReadAllText(filePath);

            TeamData teamData = JsonSerializer.Deserialize<TeamData>(jsonContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (teamData?.Members == null || teamData.Members.Count == 0)
            {
                Console.WriteLine("Data anggota tim tidak ditemukan atau kosong.");
                return;
            }

            Console.WriteLine("Team member list:");
            foreach (var member in teamData.Members)
            {
                Console.WriteLine($"{member.Nim} {member.FirstName} {member.LastName} ({member.Age} {member.Gender})");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            TeamMembers2211104027.ReadJSON();
        }
    }
}
