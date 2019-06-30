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
    public class ToMethodScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.methodScreen);
            Button straightBtn = FindViewById<Button>(Resource.Id.StraightBtn);
            Button sieveBtn = FindViewById<Button>(Resource.Id.SieveBtn);
            Button infoStraightBtn = FindViewById<Button>(Resource.Id.InfoStraightBtn);
            Button infoSieveBtn = FindViewById<Button>(Resource.Id.InfoSieveBtn);

            straightBtn.Click += (s, e) =>
            {
                 Intent MainScreenIntent = new Intent(this, typeof(MainActivity));
                 StartActivity(MainScreenIntent);
            };

            sieveBtn.Click += (s, e) =>
            {
                Intent MainScreenIntent = new Intent(this, typeof(MainActivity));
                MainScreenIntent.PutExtra("Method", "Sieve");
                StartActivity(MainScreenIntent);
            };

            infoStraightBtn.Click += (s, e) =>
            {
                Intent InfoScreenIntent = new Intent(this, typeof(ToInfoScreen));
                StartActivity(InfoScreenIntent);
            };

            infoSieveBtn.Click += (s, e) =>
            {
                Intent InfoScreenIntent = new Intent(this, typeof(ToInfoScreen));
                InfoScreenIntent.PutExtra("Method", "Sieve");
                StartActivity(InfoScreenIntent);
            };
        }
    }
}