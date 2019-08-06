using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;

namespace PokemonFightClub
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText login;
        EditText password;
        Android.App.AlertDialog.Builder myAlert;

        DBHelper myDbInstance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            myDbInstance = new DBHelper(this);
            login = FindViewById<EditText>(Resource.Id.user_name);
            password = FindViewById<EditText>(Resource.Id.password);
            Button loginButton = FindViewById<Button>(Resource.Id.btnLog);
            Button register = FindViewById<Button>(Resource.Id.btnSign);

            loginButton.Click += myButtonClick;

            myAlert = new Android.App.AlertDialog.Builder(this);

            register.Click += delegate
            {
                Intent registerPage = new Intent(this, typeof(Register));
                StartActivity(registerPage);
            };
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            System.Console.WriteLine("Ok button have been clicked!");

        }

        private void CancelAction(object sender, DialogClickEventArgs e)
        {
            System.Console.WriteLine("OCancel button have been clicked!");
        }

        void myButtonClick(object sender, System.EventArgs e)
        {

            Dialog myDialog = myAlert.Create();
            if (login.Text == "" || password.Text == "" || login.Equals("") || password.Equals(""))
            {
                myAlert.SetTitle("Validation Error");
                myAlert.SetMessage("Please Enter Your User Name or Password");
                myAlert.SetPositiveButton("OK", OkAction);
                myAlert.SetNegativeButton("Cancel", CancelAction);
                myDialog.Show();
            }
            else
            {
                
                bool dbValidation = myDbInstance.checkUser(login.Text, password.Text);
                if (dbValidation)
                {
                    Intent welcome = new Intent(this, typeof(PokeballPage));
                    welcome.PutExtra("username", login.Text);
                    welcome.PutExtra("password", password.Text);

                    StartActivity(welcome);
                }
                else
                {
                    myAlert.SetTitle("User or Password is incorrect");
                    myAlert.SetMessage("Try again!");
                    myAlert.SetPositiveButton("OK", OkAction);
                    myDialog.Show();

                }

            }
        }
    }
}