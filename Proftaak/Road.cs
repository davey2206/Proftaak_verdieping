using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proftaak
{
    class Road
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
        Random rng = new Random();
        private int answer;
        private int count = -1;
        private int answerCount = -1;
        private int[] number = { 1, 2, 3, 4, 5, 6, 7, 8 };
        private int[] rngPosition = { 10, 10, 10, 10, 10 };
        private int[] position = { 0, 0, 0, 0, 0 };
        private int[] answerNumber = { 0, 0, 0, 0, 0 };

        public void Make_vehicles()
        {
            vehicles.Add(new Vehicle(0, Properties.Resources.auto));
            vehicles.Add(new Vehicle(1, Properties.Resources.brandweerauto));
            vehicles.Add(new Vehicle(2, Properties.Resources.bus));
            vehicles.Add(new Vehicle(3, Properties.Resources.busje));
            vehicles.Add(new Vehicle(4, Properties.Resources.politieauto));
            vehicles.Add(new Vehicle(5, Properties.Resources.tractor));
            vehicles.Add(new Vehicle(6, Properties.Resources.vrachtwagen));
            vehicles.Add(new Vehicle(7, Properties.Resources.ziekenwagen));
        }

        public void reset()
        {
            answer = 0;
            count = -1;
            answerCount = -1;
            for (int i = 0; i < 8; i++)
            {
                number[i] = i;
            }
            for (int i = 0; i < 5; i++)
            {
                rngPosition[i] = 10;
            }
            for (int i = 0; i < 5; i++)
            {
                position[i] = 0;
                answerNumber[i] = 0;
            }
        }

        public Vehicle getVehicle()
        {
            int n = rng.Next(0, 8);
            while (number[n] == 0)
            {
                n = rng.Next(0, 8);
            }

            number[n] = 0;

            foreach (var vehicle in vehicles)
            {
                if (vehicle.Id == n)
                {
                    count++;
                    rngPosition[count] = vehicle.Id;
                    answerNumber[count] = vehicle.Id;

                    return vehicle;
                }
            }
            return null;
        }

        public Image setPosition()
        {
            int r = rng.Next(0, 4);

            while (rngPosition[r] == 10)
            {
                r = rng.Next(0, 4);
            }
            answerCount++;
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Id == rngPosition[r])
                {
                    position[answerCount] = vehicle.Id;
                    rngPosition[r] = 10;
                    return vehicle.Picture;
                }
            }

            return null;
        }

        public string setAnswer()
        {
            int r = rng.Next(1, 5);

            answer = r;

            if (position[r - 1] == answerNumber[0])
            {
                return "welke kwam als 1e";
            }
            else if (position[r - 1] == answerNumber[1])
            {
                return "welke kwam als 2e";
            }
            else if (position[r - 1] == answerNumber[2])
            {
                return "welke kwam als 3e";
            }
            else if (position[r - 1] == answerNumber[3])
            {
                return "welke kwam als 4e";
            }

            return null;
        }

        public bool check(int a)
        {
            if (answer == a)
            {
                reset();
                return true;
            }
            reset();
            return false;
        }
    }
}
