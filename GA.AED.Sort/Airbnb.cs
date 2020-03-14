namespace GA.AED.Sort {
    public class Airbnb {

        #region [ Properties ]

        public int RoomId { get; set; }
        public int HostId { get; set; }
        public string RoomType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public double Reviews { get; set; }
        public double OverallSatisfaction { get; set; }
        public double Accommodates { get; set; }
        public double Bedrooms { get; set; }
        public double Price { get; set; }
        public string PropertyType { get; set; }

        #endregion

        #region [ Constructor ]

        public Airbnb(int roomId,
                      int hostId,
                      string roomType,
                      string city,
                      string country,
                      string neighborhood,
                      double review,
                      double overallSatisfaction,
                      double accommodates,
                      double bedrooms,
                      double price,
                      string propertyType) {

            this.RoomId = roomId;
            this.HostId = hostId;
            this.RoomType = roomType;
            this.City = city;
            this.Country = country;
            this.Neighborhood = neighborhood;
            this.Reviews = review;
            this.OverallSatisfaction = overallSatisfaction;
            this.Accommodates = accommodates;
            this.Bedrooms = bedrooms;
            this.Price = price;
            this.PropertyType = propertyType;
        }

        #endregion

        #region [ Copy ]

        public static Airbnb[] GetCopy(Airbnb[] airbnbs, int lenght) {
            Airbnb[] airbnbCopy = new Airbnb[lenght];

            for (int i = 0; i < lenght; i++) {
                airbnbCopy[i] = airbnbs[i];
            }

            return airbnbCopy;
        }

        #endregion

        #region [ Sort ]

        #region [ Bubble Sort ]

        public static void BubbleSort(Airbnb[] airbnbs) {
            int length = airbnbs.Length;
            for (int i = 0; i <= length - 1; i++) {
                for (int j = 0; j < length - 1; j++) {
                    if (airbnbs[j + 1].RoomId < airbnbs[j].RoomId) {
                        Airbnb aux = airbnbs[j];
                        airbnbs[j] = airbnbs[j + 1];
                        airbnbs[j + 1] = aux;
                    }
                }
            }
        }

        #endregion

        #region [ Select Sort ]

        public static void SelectSort(Airbnb[] airbnbs) {
            //TODO: Implementar o SelectSort
        }

        #endregion

        #region [ Insert Sort ]

        public static void InsertSort(Airbnb[] airbnbs) {
            int n = airbnbs.Length;

            for (int i = 1; i < n; ++i) {

                Airbnb key = airbnbs[i];
                int j = i - 1;

                while (j >= 0 && airbnbs[j].RoomId > key.RoomId) {
                    airbnbs[j + 1] = airbnbs[j];
                    j = j - 1;
                }

                airbnbs[j + 1] = key;
            }
        }

        #endregion

        #region [ Merge Sort ]

        public static void MergeSort(Airbnb[] airbnbs) {
            //TODO: Implementar o MergeSort
        }

        #endregion

        #region [ Quick Sort ]

        public static void QuickSort(Airbnb[] airbnbs, int start, int end) {

            if (start < end) {
                int pivot = QuickSortPartition(airbnbs, start, end);

                QuickSort(airbnbs, start, pivot - 1);
                QuickSort(airbnbs, pivot + 1, end);
            }
        }

        private static int QuickSortPartition(Airbnb[] airbnbs, int start, int end) {
            Airbnb airbnbEnd = airbnbs[end], temp;
            int pivot = start - 1;

            for (int i = start; i <= end - 1; i++) {
                if (airbnbs[i].RoomId <= airbnbEnd.RoomId) {
                    pivot++;
                    temp = airbnbs[pivot];
                    airbnbs[pivot] = airbnbs[i];
                    airbnbs[i] = temp;
                }
            }

            temp = airbnbs[pivot + 1];
            airbnbs[pivot + 1] = airbnbs[end];
            airbnbs[end] = temp;
            return pivot + 1;
        }

        #endregion

        #region [ Create Sort ]

        public static void CreateSort(Airbnb[] airbnbs) {
            //TODO: Implementar o CreateSort
        }

        #endregion

        #endregion
    }
}
