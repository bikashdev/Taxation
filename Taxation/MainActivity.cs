using Android.App;
using Android.Widget;
using Android.OS;
using Android.Text;
using System;
using Android.Views;

namespace Taxation
{
    [Activity(Label = "Taxation", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Get our UI controls from the loaded layout
            EditText monthlySalary = FindViewById<EditText>(Resource.Id.Monthly);
            TextView Result = FindViewById<TextView>(Resource.Id.Result);
            Button Calculate = FindViewById<Button>(Resource.Id.btn_calc);
            CheckBox isMarried = FindViewById<CheckBox>(Resource.Id.isMarried);
            CheckBox isBonus = FindViewById<CheckBox>(Resource.Id.isYearlyBonus);
            
            
            var layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;

            EditText BonusAmount = new EditText(this);
            BonusAmount.Text = "Enter Value";
            BonusAmount.Visibility = ViewStates.Invisible;


            isBonus.Click += (sender, e) =>
            {
                if (isBonus.Checked)
                {
                    BonusAmount.Text = "Enter Value";
                    layout.AddView(BonusAmount);
                }
                else
                {
                    BonusAmount.Visibility = ViewStates.Gone;
                }
            };


            Calculate.Click += (sender, e) =>
              {
                  if (string.IsNullOrWhiteSpace(monthlySalary.Text))
                  {
                      Result.Text = "Enter Valid data. For E.g. 10000";
                  }

                  else
                  {
                      // decimal monthly = converter.ToDecimal(monthlySalary.Text);
                      Result.Text = core.Calculator.Calculate(monthlySalary.Text, isMarried.Checked);
                  }
              };
        }
    }
}

