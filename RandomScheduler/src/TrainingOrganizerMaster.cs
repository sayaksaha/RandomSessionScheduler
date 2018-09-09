using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace RandomScheduler.src
    {
    class TrainingOrganizer
        {
        static Random RandomIndex = new Random(DateTimeOffset.Now.GetHashCode());
        List<int> TrainingIndexes = new List<int>();
        static Hashtable TrainingNames = new Hashtable();
        static Hashtable TrainingWithDuration = new Hashtable();

        public static XName Duration { get; private set; }

        static void Main(string[] args)
            {

            Hashtable LeftOverSessions = new Hashtable();
            ICollection Session2TrainingIDComplete;
            List<int> TrainingIDs = new List<int>();
            ExtractSessionDetailsToXML DS = new ExtractSessionDetailsToXML();
            TrainingOrganizer organizer = new TrainingOrganizer();
            String path = null;

            const int Session1Slot = 120;
            const int Session2Slot = 120;

            int AvailableSession1Hours = Session1Slot;
            int AvailableSession2Hours = Session2Slot;


            //Read data from command line and convert to xml
            try
                {
                if (args.Any())
                    {
                    path = args[0];
                     }
                DS.convertRawDataToXML(path);
                }
            catch (CustomException CE)
                {
                CE.DumpException();
                }
            //Read from xml and convert to hashtable ds
            try
                {
                organizer.ConvertXMLToDataStructure();
                }
            catch (CustomException CE)
                {
                CE.DumpException();
                }

            // Get a random collection of the training id keys.
            organizer.GetRandomTrainingIDList(TrainingNames);
            foreach (int LocalTID in organizer.TrainingIndexes.ToArray())
                if ((int)TrainingWithDuration[LocalTID] <= AvailableSession1Hours)
                    {
                    AvailableSession1Hours = AvailableSession1Hours - (int)TrainingWithDuration[LocalTID];
                    Console.WriteLine(TrainingNames[LocalTID] + ": " + TrainingWithDuration[LocalTID] + " min");
                    }
                else
                    {
                    LeftOverSessions.Add(LocalTID, TrainingWithDuration[LocalTID]);

                    }

            if (AvailableSession1Hours > 0)
                {
                Console.WriteLine("Adhoc Break" + ": " + AvailableSession1Hours + " min");
                }

            // Print Lunch Break
            Console.WriteLine("Lunch Break :" + "1HR");
            Session2TrainingIDComplete = LeftOverSessions.Keys;

            foreach (int LocalTID in Session2TrainingIDComplete)
                {

                if ((int)LeftOverSessions[LocalTID] <= AvailableSession2Hours)
                    {
                    AvailableSession2Hours = AvailableSession2Hours - (int)LeftOverSessions[LocalTID];
                    Console.WriteLine(TrainingNames[LocalTID] + ": " + LeftOverSessions[LocalTID] + " min");
                    }

                }
            if (AvailableSession2Hours > 0)
                {
                Console.WriteLine("MISC/BREAKS" + ": " + AvailableSession2Hours);
                }
            Console.ReadKey();
            }

        public void GetRandomTrainingIDList(Hashtable TrainingNames)
            {
            //Initialize the training indices
            List<int> tempIndexes = TrainingNames.Keys.OfType<int>().ToList(); ;
            int RandomIndexCount = 0;
            int tempIndex;

            while (RandomIndexCount < TrainingNames.Count)
                {
                tempIndex = tempIndexes[RandomIndex.Next(0, TrainingNames.Count)];
                if (!this.TrainingIndexes.Contains(tempIndex))
                    {
                    RandomIndexCount++;
                    this.TrainingIndexes.Add(tempIndex);

                    }
                }
            }

        public void ConvertXMLToDataStructure()
            {
            XElement xmlRoot = null;

            // Read data from XML and convert a Hashtable
            try
                {
                xmlRoot = XElement.Load(@"C:\temp\SessionData.xml");
                }
            catch (CustomException CE)
                {
                CE.DumpException();
                }
            // Get a sequence of trainings
            IEnumerable<XElement> trainings = xmlRoot.Elements();

            foreach (var training in trainings)
                {

                //Temp variables before data structure push
                int id = int.Parse(training.Attribute("ID").Value);
                string trainingName = training.Element("Name").Value;
                int duration = int.Parse(training.Element("TrainingDuration").Value);

                TrainingNames.Add(id, trainingName);
                TrainingWithDuration.Add(id, duration);
                }
            }

        }
    }



