using System;
using System.Diagnostics;

namespace PrimeApp
{
    public class PrimeCalculation {

        public string result;
        public double calculationTime;

        public PrimeCalculation(int n, string method)
        {
            if (method == "Sieve")
            {
                this.calculateFirstPrimesSieve(n);
            }
            else
            {
                this.calculateFirstPrimesStraight(n);
            }
        }

        public void calculateFirstPrimesSieve(int n)
        {
            DateTime startTime = DateTime.Now;
            int count = 0;
            int k = 10 * n;
            while (count < n)
            {
                count = 0;
                string results = "";

                bool[] e = new bool[k];//by default they're all false
                for (int i = 2; i < k; i++)
                {
                    e[i] = true;//set all numbers to true
                }
                //weed out the non primes by finding mutiples 
                for (int j = 2; j < n; j++)
                {
                    if (e[j])
                    {
                        for (long p = 2; (p * j) < k; p++)
                        {
                            e[p * j] = false;
                        }
                    }
                }
                for (int i = 2; i < k; i++)
                {
                    if (e[i])
                    {
                        results += " " + i.ToString();
                        count++;
                        if (count == n)
                        {
                            this.result = results;
                            DateTime endTime = DateTime.Now;
                            double elapsedTime = (endTime - startTime).TotalMilliseconds;
                            this.calculationTime = elapsedTime;
                            return;
                        }
                    }

                }

                k = k * 2; //more numbers need to be checked
            }
        }

        public static int ToNumber(string givenString)
        {
            int integer;
            if (int.TryParse(givenString, out integer))
            {
                return integer;
            }
            throw new System.ArgumentException();
        }

        public void calculateFirstPrimesStraight(int n)
        {
            DateTime startTime = DateTime.Now;
            int count = 0;
            int currentNumber = 1;
            string results = "";
            while (count < n)
            {
                if (isPrime(currentNumber))
                {
                    results += " " + currentNumber.ToString();
                    count += 1;
                }
                currentNumber++;
 
            }
            this.result = results;
            DateTime endTime = DateTime.Now;
            double elapsedTime = (endTime - startTime).TotalMilliseconds;
            this.calculationTime = elapsedTime;
        }


        public static Boolean isPrime(int n)
        {
            if (n == 1)
                return false;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}