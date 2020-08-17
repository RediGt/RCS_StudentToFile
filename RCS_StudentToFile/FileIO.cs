using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCS_StudentContactsJson
{
    class FileIO
    {
        public static void SaveToFile(List<Student> stud)
        {
            string jsonString;

            jsonString = JsonConvert.SerializeObject(stud, Formatting.Indented);
            File.WriteAllText(GetFile(), jsonString);
            MessageBox.Show("Saved successfully");
        }

        public static List<Student> LoadFromFile()
        {
            try
            {
                StreamReader reader = new StreamReader(GetFile());
                String line = reader.ReadLine();
                String json = "";

                while (line != null)
                {
                    json += line;
                    line = reader.ReadLine();
                }
                reader.Close();

                return JsonConvert.DeserializeObject<List<Student>>(json);
            }
            catch
            {
                List<Student> a = new List<Student>();
                a.Add(new Student("Janis", "Jansons", 20));
                return a;
            }
        }

        public static string GetFile()
        {
            string filename = Directory.GetCurrentDirectory();
            filename += @"\StudList.json";

            return filename;
        }
    }
}
