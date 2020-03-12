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

        public static void BubbleSort(Airbnb[] airbnbs) {
            int length = airbnbs.Length;
            for (int i = 0; i < length; i++) {
                for (int j = 0; j < length - i - 1; j++) {
                    if(airbnbs[j].RoomId > airbnbs[i].RoomId) {
                        Airbnb aux = airbnbs[j];
                        airbnbs[j] = airbnbs[j + 1];
                        airbnbs[j + 1] = aux;
                    }
                }
            }
        }

        public static void SelectSort(Airbnb[] airbnbs) {
            //TODO: Implementar o SelectSort
        }

        public static void InsertSort(Airbnb[] airbnbs) {
            //TODO: Implementar o InsertSort
        }

        public static void MergeSort(Airbnb[] airbnbs) {
            //TODO: Implementar o MergeSort
        }

        public static void QuickSort(Airbnb[] airbnbs) {
            //TODO: Implementar o QuickSort
        }

        public static void CreateSort(Airbnb[] airbnbs) {
            //TODO: Implementar o CreateSort
        }

        #endregion
    }
}
