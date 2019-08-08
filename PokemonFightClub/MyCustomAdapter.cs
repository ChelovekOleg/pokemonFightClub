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
using Newtonsoft.Json;

namespace PokemonFightClub
{
    class MyCustomAdapter : BaseAdapter<Pokemon>
    {

        Context myContext;
        List<Pokemon> myListArray;
        Button takeToFight;
        DBHelper myDbInstance;
        Android.App.AlertDialog.Builder myAlert;

        public MyCustomAdapter(Context context, List<Pokemon> mySubjectList)
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
                myView = LayoutInflater.From(myContext).Inflate(Resource.Layout.listViewPokeBall, null);

                myView.FindViewById<ImageView>(Resource.Id.myPokePicID).SetImageResource(pokemon.image);
                myView.FindViewById<TextView>(Resource.Id.myPokeDescriptID).Text = pokemon.name + ": " + pokemon.description;

                takeToFight = myView.FindViewById<Button>(Resource.Id.btnFight);

                takeToFight.Click += delegate {
                    
                    Intent fightPage = new Intent(myContext, typeof(FightPage));
                    fightPage.PutExtra("pokemonFight", JsonConvert.SerializeObject(pokemon));
                    myContext.StartActivity(fightPage);
                };
            }

            return myView;
        }
    }
}