using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;

namespace PrimeApp
{
    [Activity(Label = "PrimeCalculator", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
            Button calculateButton = FindViewById<Button>(Resource.Id.CalculateButton);
            TextView errorText = FindViewById<TextView>(Resource.Id.errorText);
            Button methodSelectBtn = FindViewById<Button>(Resource.Id.MethodSelectBtn);
            EditText nbOfPrimeNumbers = FindViewById<EditText>(Resource.Id.NbOfPrimeNumbers);

            string methodRec = Intent.GetStringExtra("Method");
            string method = "Straight";
            if (!(methodRec is null))
            {
                method = methodRec;
            }

            calculateButton.Click += (s, e) =>
            {
                try { 
                int givenNbPrimes = PrimeCalculation.ToNumber(nbOfPrimeNumbers.Text);
                Intent resultScreenIntent = new Intent(this, typeof(ToResultScreen));
                resultScreenIntent.PutExtra("nbPrimes", givenNbPrimes);
                resultScreenIntent.PutExtra("Method", method);

                    StartActivity(resultScreenIntent);
                }
                catch (Exception ex)
                {
                    errorText.Text = "Please enter an integer";
                }
            };

            methodSelectBtn.Click += (s, e) =>
            {
                {
                    Intent MethodScreenIntent = new Intent(this, typeof(ToMethodScreen));
                    StartActivity(MethodScreenIntent);
                }
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }


}