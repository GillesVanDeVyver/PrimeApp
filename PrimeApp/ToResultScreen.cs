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
    public class ToResultScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            int givenNbPrimes = Intent.GetIntExtra("nbPrimes", 0);
            string methodRec = Intent.GetStringExtra("Method");

            string method = "Straight";
            if (!(methodRec is null))
            {
                method = methodRec;
            }

            SetContentView(Resource.Layout.resultScreen);
            TextView methodTxt = FindViewById<TextView>(Resource.Id.MethodTxt);
            TextView result = FindViewById<TextView>(Resource.Id.result);
            TextView calculationTimeText = FindViewById<TextView>(Resource.Id.calculationTimeText);

            string text;
            if (method == "Sieve")
            {
                text = "Sieve of Eratosthenes";
            }
            else
            {
                text = "Straightforward";
            }
            methodTxt.Text = text;

            PrimeCalculation currentCalculation = new PrimeCalculation(givenNbPrimes, method);
            string primeNumbers = currentCalculation.result;
            double calculationTime = currentCalculation.calculationTime;

            result.Text = primeNumbers;
            calculationTimeText.Text = calculationTime.ToString() + " miliseconds";
        }
    }
}