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

namespace PokemonFightClub
{
    [Activity(Label = "Register")]
    public class Register : Activity
    {

        EditText firstName;
        EditText username;
        EditText email;
        EditText password;
        Android.App.AlertDialog.Builder myAlert;
        DBHelper myDbInstance;
        Random random = new Random();
        TextView goBack;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.registration);
            myDbInstance = new DBHelper(this);

            firstName = FindViewById<EditText>(Resource.Id.full_name);
            email = FindViewById<EditText>(Resource.Id.email_id);
            username = FindViewById<EditText>(Resource.Id.user);
            password = FindViewById<EditText>(Resource.Id.new_password);
            goBack = FindViewById<TextView>(Resource.Id.goBack);

            Button complete = FindViewById<Button>(Resource.Id.btnSignin);

            goBack.Click += delegate
            {
                Intent loginPage = new Intent(this, typeof(MainActivity));
                StartActivity(loginPage);
            };

            complete.Click += myButtonClick;

            myAlert = new Android.App.AlertDialog.Builder(this);
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            System.Console.WriteLine("Ok button have been clicked!");

        }

        private void OkActionDone(object sender, DialogClickEventArgs e)
        {
            Intent login = new Intent(this, typeof(MainActivity));
            StartActivity(login);

        }

        private void CancelAction(object sender, DialogClickEventArgs e)
        {
            System.Console.WriteLine("Cancel button have been clicked!");
        }

        void myButtonClick(object sender, System.EventArgs e)
        {
            myAlert.SetTitle("Validation Error");
            myAlert.SetMessage("Please Fill All Fields!");
            myAlert.SetPositiveButton("OK", OkAction);


            bool validation = (firstName.Text == "" || email.Text == "" || password.Text == "" || firstName.Equals("") || email.Equals("") || password.Equals("")) ? true : false;

            
            if (validation)
            {
                myAlert.SetNegativeButton("Cancel", CancelAction);
                Dialog myDialog = myAlert.Create();
                myDialog.Show();
            }
            else
            {
                myDbInstance.insertNewUser(random.Next() ,firstName.Text, email.Text, username.Text, password.Text);
                myAlert.SetTitle("You have created new account successfully!!");
                myAlert.SetMessage("Proceed to login page");
                myAlert.SetPositiveButton("OK", OkActionDone);
                
                Dialog myDialog = myAlert.Create();
                myDialog.Show();
                
            }
        }
    }
}