﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_StudentToFile
{
    class FileIO
    {
        public static void SaveToFile(List<Student> stud)
        {
            string jsonString;

            jsonString = JsonConvert.SerializeObject(stud, Formatting.Indented);
            File.WriteAllText(GetFile(), jsonString);
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
                return null;
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