using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace modul7_2211104027
{
    public class GlossaryItem2211104027
    {
        public class GlossaryRoot
        {
            [JsonPropertyName("glossary")]
            public Glossary Glossary { get; set; }
        }

        public class Glossary
        {
            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("GlossDiv")]
            public GlossDiv GlossDiv { get; set; }
        }

        public class GlossDiv
        {
            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("GlossList")]
            public GlossList GlossList { get; set; }
        }

        public class GlossList
        {
            [JsonPropertyName("GlossEntry")]
            public GlossEntry GlossEntry { get; set; }
        }

        public class GlossEntry
        {
            [JsonPropertyName("ID")]
            public string ID { get; set; }

            [JsonPropertyName("SortAs")]
            public string SortAs { get; set; }

            [JsonPropertyName("GlossTerm")]
            public string GlossTerm { get; set; }

            [JsonPropertyName("Acronym")]
            public string Acronym { get; set; }

            [JsonPropertyName("Abbrev")]
            public string Abbrev { get; set; }

            [JsonPropertyName("GlossDef")]
            public GlossDef GlossDef { get; set; }

            [JsonPropertyName("GlossSee")]
            public string GlossSee { get; set; }
        }

        public class GlossDef
        {
            [JsonPropertyName("para")]
            public string Para { get; set; }

            [JsonPropertyName("GlossSeeAlso")]
            public string[] GlossSeeAlso { get; set; }
        }

        public static void ReadJSON()
        {
            try
            {
                string filePath = "jurnal7_3_2211104027.json"; // Sesuaikan dengan NIM Anda
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File JSON tidak ditemukan!");
                    return;
                }

                string jsonContent = File.ReadAllText(filePath);
                GlossaryRoot glossaryData = JsonSerializer.Deserialize<GlossaryRoot>(jsonContent);

                if (glossaryData?.Glossary?.GlossDiv?.GlossList?.GlossEntry != null)
                {
                    GlossEntry entry = glossaryData.Glossary.GlossDiv.GlossList.GlossEntry;
                    Console.WriteLine("GlossEntry Data:");
                    Console.WriteLine($"ID       : {entry.ID}");
                    Console.WriteLine($"SortAs   : {entry.SortAs}");
                    Console.WriteLine($"GlossTerm: {entry.GlossTerm}");
                    Console.WriteLine($"Acronym  : {entry.Acronym}");
                    Console.WriteLine($"Abbrev   : {entry.Abbrev}");
                    Console.WriteLine($"GlossSee : {entry.GlossSee}");
                    Console.WriteLine($"Definition: {entry.GlossDef.Para}");
                    Console.WriteLine("GlossSeeAlso: " + string.Join(", ", entry.GlossDef.GlossSeeAlso));
                }
                else
                {
                    Console.WriteLine("Data GlossEntry tidak ditemukan!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saat membaca JSON: " + ex.Message);
            }
        }

        public static void Main()
        {
            ReadJSON();
        }
    }
}
