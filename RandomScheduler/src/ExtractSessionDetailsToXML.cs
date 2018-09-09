using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RandomScheduler.src
    {
    public class ExtractSessionDetailsToXML
        {
        string[] lines;
        FileStream fs;

        [System.Xml.Serialization.XmlArray]
        static List<Training> TrainingList = new List<Training>();

        XmlSerializer serialization = new XmlSerializer(TrainingList.GetType());
        XmlDocument xmlDoc;
        string FilePath = @"C:\temp\SessionData.xml";

        public void convertRawDataToXML(String path)
            {

            try
                {
                //lines = File.ReadAllLines("c:\\users\\sayak_saha\\documents\\visual studio 2015\\Projects\\RandomScheduler\\RandomScheduler\\config\\SessionDataRaw.txt");
                lines = File.ReadAllLines(path);
                }
            catch (IOException)
                {
                Console.WriteLine(" string[] lines = File.ReadAllLines");
                }

            try
                {

                if (File.Exists(FilePath))
                    {
                    File.Delete(FilePath);
                    }

                fs = new System.IO.FileStream(FilePath, FileMode.CreateNew, FileAccess.ReadWrite);
                xmlDoc = new XmlDocument();

                }
            catch
                {
                Console.WriteLine("FileStream fs = new FileStream");
                }

            int TrainingID = 1;

            //Skip the first 2 headers from the input file
            lines = lines.Skip(2).ToArray();

            foreach (string line in lines)
                {
                string[] contents = line.Split(new char[] { '|' });
                int ID = TrainingID;
                string Name = contents[0];
                string TrainingDuration = contents[1].Replace("min", "");
                Training training = new Training(ID, Name, TrainingDuration);
                TrainingList.Add(training);
                TrainingID++;

                }

            try
                {
                serialization.Serialize(fs, TrainingList);
                fs.Close();
                serialization = null;
                }
            catch (CustomException CE)
                {
                CE.DumpException();
                }
            }
        
        }
    }
