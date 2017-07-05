using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace DivisasNative.Droid
{
    [Activity(Label = "Divisas Native", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
		#region Controls
		EditText editTextPesos;
		EditText editTextDollars;
		EditText editTextEuros;
		EditText editTextPounds;
        Button buttonConvert;
        #endregion

        #region Methods
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

			editTextPesos = FindViewById<EditText>(Resource.Id.editTextPesos);
			editTextDollars = FindViewById<EditText>(Resource.Id.editTextDollars);
			editTextEuros = FindViewById<EditText>(Resource.Id.editTextEuros);
			editTextPounds = FindViewById<EditText>(Resource.Id.editTextPounds);
			buttonConvert = FindViewById<Button>(Resource.Id.buttonConvert);

            buttonConvert.Click += ButtonConvert_Click;
		}

        void ButtonConvert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(editTextPesos.Text))
            {
                ShowMessage(Resources.GetString(Resource.String.Error), 
                    Resources.GetString(Resource.String.ErrorPesos));
                return;
            }
            var pesos = decimal.Parse(editTextPesos.Text);
            var exchange = Converter.Convert(pesos);
            editTextDollars.Text = string.Format("${0:N2}", exchange.Dollars);
            editTextEuros.Text = string.Format("€{0:N2}", exchange.Euros);
            editTextPounds.Text = string.Format("£{0:N2}", exchange.Pounds);
        }

        void ShowMessage(string title, string message)
        {
            var builder = new AlertDialog.Builder(this);
            var alert = builder.Create();
            alert.SetTitle(title);
            alert.SetIcon(Resource.Mipmap.Icon);
            alert.SetMessage(message);
            alert.SetButton(
                Resources.GetString(Resource.String.Accept),
                (s, ev) => { });
            alert.Show();
        }
        #endregion
    }
}

