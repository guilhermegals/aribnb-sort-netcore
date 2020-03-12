using System;
using System.Diagnostics;
using System.IO;

namespace GA.AED.Sort {
    public class Program {

        #region [ Consts ]

        private const string FILE_READ_PATH_RANDOM = @"Files\dados_airbnb_random.csv";
        private const string FILE_READ_PATH_DESC = @"Files\dados_airbnb_desc.csv";
        private const string FILE_READ_PATH_ASC = @"Files\dados_airbnb_asc.csv";
        private const string FILE_WRITE_PATH = @"Files\Log.csv";

        private const string BUBBLE_SORT = "BubbleSort";
        private const string SELECT_SORT = "SelectSort";
        private const string INSERT_SORT = "InsertSort";
        private const string MERGE_SORT = "MergeSort";
        private const string QUICK_SORT = "QuickSort";
        
        private const string RANDOM = "Aleatorio";
        private const string DESC = "Decrescente";
        private const string ASC = "Crescente";

        private const int REPETITIONS_TIME = 5;
        private const int THOUSAND = 1000;

        #endregion

        public static void Main(string[] args) {
            File.Delete(FILE_WRITE_PATH);

            Airbnb[] airbnbsRandom = ReadAirbnbFile(FILE_READ_PATH_RANDOM);
            Airbnb[] airbnbsDesc = ReadAirbnbFile(FILE_READ_PATH_DESC);
            Airbnb[] airbnbsAsc = ReadAirbnbFile(FILE_READ_PATH_ASC);

            for (int i = 1; i <= 7; i++) {
                int quantity = Convert.ToInt32(Math.Pow(2, i) * THOUSAND);

                #region [ BubbleSort ]

                Bubble(airbnbsRandom, RANDOM, quantity);
                Bubble(airbnbsDesc, DESC, quantity);
                Bubble(airbnbsAsc, ASC, quantity);

                #endregion

                #region [ SelectSort ]

                Select(airbnbsRandom, RANDOM, quantity);
                Select(airbnbsDesc, DESC, quantity);
                Select(airbnbsAsc, ASC, quantity);

                #endregion

                #region [ InsertSort ]

                Insert(airbnbsRandom, RANDOM, quantity);
                Insert(airbnbsDesc, DESC, quantity);
                Insert(airbnbsAsc, ASC, quantity);

                #endregion

                #region [ MergeSort ]

                Merge(airbnbsRandom, RANDOM, quantity);
                Merge(airbnbsDesc, DESC, quantity);
                Merge(airbnbsAsc, ASC, quantity);

                #endregion

                #region [ QuickSort ]

                Quick(airbnbsRandom, RANDOM, quantity);
                Quick(airbnbsDesc, DESC, quantity);
                Quick(airbnbsAsc, ASC, quantity);

                #endregion

                #region [ CreateSort ]

                Create(airbnbsRandom, RANDOM, quantity);
                Create(airbnbsDesc, DESC, quantity);
                Create(airbnbsAsc, ASC, quantity);

                #endregion
            }

        }

        #region [ Sorts ]

        private static void Bubble(Airbnb[] airbnbs, string type, int quantity) {
            DateTime bubbleSortStart = DateTime.Now;

            double[] bubbleSortTimes = new double[REPETITIONS_TIME];
            for (int repetition = 0; repetition < REPETITIONS_TIME; repetition++) {
                Airbnb[] airbnbsBoubbleSort = Airbnb.GetCopy(airbnbs, quantity);

                Stopwatch watch = Stopwatch.StartNew();
                Airbnb.BubbleSort(airbnbsBoubbleSort);
                watch.Stop();

                bubbleSortTimes[repetition] = watch.ElapsedMilliseconds / 1000.0;
            }

            double bubbleAverageTime = AverageTime(bubbleSortTimes);
            DateTime bubbleSortEnd = DateTime.Now;

            Log(BUBBLE_SORT,
                type,
                quantity,
                bubbleAverageTime,
                Process.GetCurrentProcess().PeakWorkingSet64 / (1024 * 1024));

            Console.WriteLine($"{quantity,-10} {type, -15} {BUBBLE_SORT,-15} ({bubbleSortStart} - {bubbleSortEnd})");
        }

        private static void Select(Airbnb[] airbnbs, string type, int quantity) {

        }

        private static void Insert(Airbnb[] airbnbs, string type, int quantity) {

        }

        private static void Merge(Airbnb[] airbnbs, string type, int quantity) {

        }

        private static void Quick(Airbnb[] airbnbs, string type, int quantity) {

        }

        private static void Create(Airbnb[] airbnbs, string type, int quantity) {

        }

        #endregion

        #region [ Log ]

        private static double AverageTime(double[] times) {
            double max = times[0], min = times[0];
            double sum = times[0];

            for (int i = 1; i < times.Length; i++) {
                if (times[i] > max)
                    max = times[i];
                else if (times[i] < min)
                    min = times[i];
                sum += times[i];
            }

            return (sum - max - min) / ((times.Length - 2) * 1.0);
        }

        private static void Log(string description,
                                string tipo,
                                int quantity,
                                double time,
                                long memory) {

            string linha = string.Empty;

            if (!File.Exists(FILE_WRITE_PATH)) {
                File.Create(FILE_WRITE_PATH).Close();
                linha += "Algoritmo; Tipo; Quantidade; Tempo; Memoria\n";
            }

            linha += $"{description}; {tipo}; {quantity}; {time}; {memory}\n";
            File.AppendAllText(FILE_WRITE_PATH, linha);
        }

        #endregion

        #region [ Read File ]

        private static Airbnb[] ReadAirbnbFile(string path) {
            string[] lines = File.ReadAllLines(path);
            Airbnb[] airbnbs = new Airbnb[lines.Length - 1];

            for (int i = 1; i < lines.Length; i++) {
                string[] line = lines[i].Split(",");
                int roomId = Convert.ToInt32(line[0]);
                int hostId = Convert.ToInt32(line[1]);
                string roomType = line[2];
                string country = line[3];
                string city = line[4];
                string neighborhood = line[5];
                double review = Convert.ToDouble(line[6]);
                double overallSatisfaction = Convert.ToDouble(line[7]);
                double accommodates = Convert.ToDouble(line[8]);
                double bedrooms = Convert.ToDouble(line[9]);
                double price = Convert.ToDouble(line[10]);
                string propertyType = line[11];

                airbnbs[i - 1] = new Airbnb(roomId,
                                            hostId,
                                            roomType,
                                            city,
                                            country,
                                            neighborhood,
                                            review,
                                            overallSatisfaction,
                                            accommodates,
                                            bedrooms,
                                            price,
                                            propertyType);
            }

            return airbnbs;
        }

        #endregion
    }
}
