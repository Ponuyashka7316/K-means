using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means
{
    public class Pair
    {
        double object1 { get; set; }
        double object2 { get; set; }

        public Pair(double one, double two)
        {
            object1 = one;
            object2 = two;
        }

        public double getOne()
        {
            return object1;
        }

        public double getTwo()
        {
            return object2;
        }

        internal void setOne(double sumOne)
        {
            object1 = sumOne;
        }

        internal void setTwo(double sumTwo)
        {
            object2 = sumTwo;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Pair[] pairs = { new Pair(0,2), new Pair(4,6), new Pair(5,7), new Pair(2,3), new Pair(3,5),
                new Pair(1.5,3), new Pair(7,3), new Pair(7,3) };

            Pair m1 = new Pair(1, 1);
            Pair m2 = new Pair(3, 5);

            ArrayList oldmm1 = new ArrayList();
            ArrayList oldmm2 = new ArrayList();

            ArrayList mm1 = new ArrayList();
            ArrayList mm2 = new ArrayList();

            int k = 0;

            do
            {

                oldmm1 = mm1;
                oldmm2 = mm2;

                mm1 = new ArrayList();
                mm2 = new ArrayList();

                foreach (var p in pairs)
                {
                    double sum1 = Math.Sqrt(Math.Pow(m1.getOne() - p.getOne(), 2) + Math.Pow(m1.getTwo() - p.getTwo(), 2));
                    double sum2 = Math.Sqrt(Math.Pow(m2.getOne() - p.getOne(), 2) + Math.Pow(m2.getTwo() - p.getTwo(), 2));
                    if (sum1 > sum2)
                    {
                        mm2.Add(p);
                    }
                    else
                    {
                        mm1.Add(p);
                    }
                }

                double sumOne = 0;
                foreach (Pair pair in mm1)
                {
                    sumOne += pair.getOne();
                }
                sumOne /= mm1.Count;
                m1.setOne(sumOne);

                double sumTwo = 0;
                foreach (Pair pair in mm1)
                {
                    sumTwo += pair.getTwo();
                }
                sumTwo /= mm1.Count;
                m1.setTwo(sumTwo);

                sumOne = 0;
                foreach (Pair pair in mm2)
                {
                    sumOne += pair.getOne();
                }
                sumOne /= mm2.Count;
                m2.setOne(sumOne);

                sumTwo = 0;
                foreach (Pair pair in mm2)
                {
                    sumTwo += pair.getTwo();
                }
                sumTwo /= mm2.Count;
                m2.setTwo(sumTwo);

                k++;

            } while (oldmm1.Count == 0 || isChange(mm1, oldmm1) || isChange(mm2, oldmm2));

            Console.WriteLine("m1(" + m1.getOne() + "; " + m1.getTwo() + ")\nm2(" + m2.getOne() + "; " + m2.getTwo() + ")");

        }

        private static bool isChange(ArrayList mm, ArrayList oldmm)
        {
            for (int i = 0; i < mm.Count; i++)
            {
                if (!mm[i].Equals(oldmm[i]))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
