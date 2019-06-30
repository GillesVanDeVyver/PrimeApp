using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PrimeApp
{
    [Activity(Label = "Activity1")]
    public class ToInfoScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.infoScreen);
            TextView info = FindViewById<TextView>(Resource.Id.Info);
            TextView title = FindViewById<TextView>(Resource.Id.Title);

            string methodRec = Intent.GetStringExtra("Method");
            string method = "Straight";
            if (!(methodRec is null))
            {
                method = methodRec;
            }

            string text;
            string titletxt;
            if (method == "Sieve")
            {
                text = "This method uses the property that all multiples of numbers are non-prime numbers: " +
                    "'In mathematics, the Sieve of Eratosthenes is a simple, ancient algorithm for finding all prime numbers up to any given limit. " +
                    "It does so by iteratively marking as composite (i.e., not prime) the multiples of each prime, starting with the first prime number, 2. " +
                    "The multiples of a given prime are generated as a sequence of numbers starting from that prime, with constant difference between them that is equal to that prime. " +
                    "This is the sieve's key distinction from using trial division to sequentially test each candidate number for divisibility by each prime'. " +
                    "(https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes)";

                titletxt = "Sieve of eratosthenes";
            }
            else
            {
                text = " Each number is checked if it is a prime number with the defenition of a prime number:" +
                    " 'A prime number (or a prime) is a natural number greater than 1 that cannot be formed by multiplying two smaller natural numbers'. " +
                    "(https://en.wikipedia.org/wiki/Prime_number)";

                titletxt = "Prime numbers";

            }
            info.Text = text;
            title.Text = titletxt;
        }
    }
}