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
using Plugin.SecureStorage;


namespace PokemonFightClub
{
    class CustomAdapterLib : BaseAdapter<Pokemon>
    {

        Context myContext;
        List<Pokemon> myListArray;
        Button takeToPokeball;
        DBHelper myDbInstance;
        Android.App.AlertDialog.Builder myAlert;

        public CustomAdapterLib(Context context, List<Pokemon> mySubjectList)
        {

            myContext = context;
            myListArray = mySubjectList;
            myDbInstance = new DBHelper(context);
            myAlert = new Android.App.AlertDialog.Builder(context);

        }

        //Step: 2
        public override Pokemon this[int position]
        {

            get { return myListArray[position]; }

        }
        public override int Count
        {

            get { return myListArray.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            View myView = convertView;

            Pokemon pokemon = myListArray[position];

            if (myView == null)
            {
                myView = LayoutInflater.From(myContext).Inflate(Resource.Layout.libPokemon, null);

                myView.FindViewById<ImageView>(Resource.Id.mySubjectImageId).SetImageResource(pokemon.image);
                myView.FindViewById<TextView>(Resource.Id.subjectDescriptID).Text = pokemon.name + System.Environment.NewLine +"Pokemon Type " + pokemon.type;
                takeToPokeball = myView.FindViewById<Button>(Resource.Id.btnPick);
                if (int.Parse(CrossSecureStorage.Current.GetValue("userIdAuth")) == int.Parse(pokemon.userIdOwe)) {
                    takeToPokeball.Text = "Your pokemon";
                }
                
                takeToPokeball.Click += delegate {
                    Console.WriteLine("Button was clicked!!!" + position);
                    if (myDbInstance.addToPokeball(int.Parse(CrossSecureStorage.Current.GetValue("userIdAuth")), pokemon.id))
                    {
                        Intent pokeballPage = new Intent(myContext, typeof(PokeballPage));//PokeballPage will be
                        myContext.StartActivity(pokeballPage);
                    }
                    else {
                        myAlert.SetTitle("Pokemon has been taken by another player!!");
                        myAlert.SetMessage("Please choose another one");
                        Dialog myDialog = myAlert.Create();
                        myDialog.Show();
                    }
                    
                };
            }

            return myView;
        }

        private void TakeToPokeball_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button was clicked!!!");
        }
    }
}