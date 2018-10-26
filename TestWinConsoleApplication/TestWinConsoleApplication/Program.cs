namespace TestWinConsoleApplication
{
    using System;
    using System.Linq;

    class Program
    {
        const long dimension = 365;

        static void Main(string[] args)
        {
            var newMess = new int[dimension];
            //var random = new Random();
            var resultString = "";
            for(int i = 0; i< dimension; i++)
            {
                newMess[i] = (int)Math.Round(Gaussian.gaussianInRange(1.0, 5.0, 8.0)); //;//Gaussian.Next(1, 9); /*random.Next(1, 9);*/
                resultString += " " + newMess[i].ToString();
            }

            Console.WriteLine($"Набор чисел - {resultString}");
            Console.WriteLine();

            var groupMass = newMess.GroupBy(x => x);
            foreach(var grop in groupMass.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"Цифра '{grop.Key}' встречается {grop.Count()}");
            }

            Console.WriteLine();
            var minNumber = groupMass.OrderBy(x => x.Count()).First();
            Console.WriteLine($"Минимально встречаемая цифра - {minNumber.Key}");
            Console.WriteLine();

            var resString = "Дом нужно строить c ";
            switch (minNumber.Key)
            {
                case 1:
                    resString += "севера";
                    break;
                case 2:
                    resString += "северо-востока";
                    break;
                case 3:
                    resString += "востока";
                    break;
                case 4:
                    resString += "юго-востока";
                    break;
                case 5:
                    resString += "юга";
                    break;
                case 6:
                    resString += "юго-запада";
                    break;
                case 7:
                    resString += "запада";
                    break;
                case 8:
                    resString += "северо-запада";
                    break;
            }

            Console.WriteLine(resString);
            Console.ReadLine();
        }
    }
}
