using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomScheduler
    {
    class TrainingOrganizer1
        {
        static Random random = new Random(DateTimeOffset.Now.GetHashCode());
        static List<int> TrainingIndexes = new List<int>();
        
        static void Main(string[] args)
            {

            Hashtable ht = new Hashtable();
            Hashtable ht1 = new Hashtable();
            Hashtable LeftOverSessions = new Hashtable();
            int AvailableSession1Hours = 120;
            int AvailableSession2Hours = 120;


            //Initialize the training names
            ht.Add(1, "T1");
            ht.Add(2, "T2");
            ht.Add(3, "T3");
            ht.Add(4, "T4");
            ht.Add(5, "T5");
            ht.Add(6, "T6");
            ht.Add(7, "T7");
            ht.Add(8, "T8");
            ht.Add(9, "T9");

            //Initialize the training names
            ht1.Add(1, 45);
            ht1.Add(2, 30);
            ht1.Add(3, 20);
            ht1.Add(4, 10);
            ht1.Add(5, 60);
            ht1.Add(6, 30);
            ht1.Add(7, 50);
            ht1.Add(8, 30);
            ht1.Add(9, 15);

            // Get a collection of the keys.
            Console.WriteLine("GetRandomNumber");
            List<int> TrainingIDs = new List<int>();
            TrainingIDs = TrainingOrganizer.GetRandomNumber(ht.Count);
            //ICollection key = ht.Keys;
            
            foreach (int k in TrainingIDs)
                {

                if ((int)ht1[k] <= AvailableSession1Hours)
                    {
                    AvailableSession1Hours = AvailableSession1Hours - (int)ht1[k];
                    Console.WriteLine(k + ": " + ht[k] + ": " + ht1[k]);
                    }
                else
                    {
                    LeftOverSessions.Add(k, ht1[k]);

                    }
                }
            if (AvailableSession1Hours > 0)
                {
                Console.WriteLine("Abracadabra" + ": " + AvailableSession1Hours);
                }

            // Print Break
            Console.WriteLine("Lunch Break :" + "1HR");

            ICollection trainings = LeftOverSessions.Keys;
            foreach (int k in trainings)
                {

                if ((int)LeftOverSessions[k] <= AvailableSession2Hours)
                    {
                    AvailableSession2Hours = AvailableSession2Hours - (int)LeftOverSessions[k];
                    Console.WriteLine(k + ": " + LeftOverSessions[k] + ": " + LeftOverSessions[k]);
                    }

                }
            if (AvailableSession2Hours > 0)
                {
                Console.WriteLine("Abracadabra" + ": " + AvailableSession2Hours);
                }


            Console.ReadKey();
            }

        public static List<int> GetRandomNumber(int max)
            {
            int[] indexes = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Random ran = new Random();
            int count = 0;
            int mynum = indexes[ran.Next(0, max)];

            while (count < max)
                {
                mynum = indexes[ran.Next(0, max)];
                if (!TrainingIndexes.Contains(mynum))
                    {
                    TrainingIndexes.Add(mynum);
                    count++;
                    }

                }

            return TrainingIndexes;
            }
        static int findleastTrainingTime(Hashtable TrainingWithTime)
            {
            int leastTrainingTime = 999;

            ICollection trainingIDs = TrainingWithTime.Keys;

            foreach (int trainingId in trainingIDs)
                {
                if ((int)TrainingWithTime[trainingId] < leastTrainingTime)
                    {
                    leastTrainingTime = (int)TrainingWithTime[trainingId];
                    }
                }

            return leastTrainingTime;

            }

        }
    }


