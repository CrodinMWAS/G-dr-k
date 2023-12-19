namespace Godrocskek
{
    internal class Program
    {
        static List<int> depth = new();
        static List<string> holesList = new();
        static void Main(string[] args)
        {
            LoadData();
            int searchedPlace = Convert.ToInt32(Console.ReadLine());
            query(searchedPlace);
            untouched();
            writePits();
        }
        public static void LoadData()
        {
            StreamReader sr = new StreamReader("melyseg.txt");
            while (!sr.EndOfStream)
            {
                depth.Add(Convert.ToInt32(sr.ReadLine()));
            }

            Console.WriteLine(depth.Count());

            sr.Close();
        }

        public static void query(int searchedPlace)
        {
            for (int i = 0; i != depth.Count; i++)
            {
                if (i == searchedPlace)
                {
                    Console.WriteLine(depth[i]);
                }
            }
        }

        public static void untouched()
        {
            List<int> notTouched = new();
            for (int i = 0; i != depth.Count; i++)
            {
                if (depth[i] == 0)
                {
                    notTouched.Add(depth[i]);
                }
            }

            Console.WriteLine(Math.Round(Convert.ToDouble(notTouched.Count) / Convert.ToDouble(depth.Count) *100, 2));
        }
        public static void writePits()
        {
            StreamWriter sw = new StreamWriter("godrok.txt");
            string currentHole = "";
            int holes = 0;
            for (int i = 0; i != depth.Count; i++)
            {
                if (depth[i] != 0)
                {
                    currentHole += depth[i];
                }
                if(currentHole != "" && depth[i] == 0)
                {
                    holes++;
                    sw.WriteLine(currentHole);
                    currentHole = "";
                }
            }
            sw.Close();


            Console.WriteLine(holes);
        }
    }
}
