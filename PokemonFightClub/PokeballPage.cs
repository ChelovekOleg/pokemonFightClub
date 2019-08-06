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
    [Activity(Label = "PokeballPage")]
    public class PokeballPage : Activity
    {
        ListView myListView;
        MyCustomAdapter myAdapter;
        List<Pokemon> myPokemonList = new List<Pokemon>();
        DBHelper myDbInstance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.myPokeBall);
            myDbInstance = new DBHelper(this);
            //myPokemonList.Add(myDbInstance.getMyPokeball());
            myPokemonList.Add(new Pokemon(1,"Fafa", "fire", "1", "description for fafa", 1, "Attack 1", "Attack 2", "Attack 3", "Attack 4", 50,60,55,65,475,Resource.Drawable.pikachu));
            myPokemonList.Add(new Pokemon(2, "Fafa", "fire", "1", "description for fafa", 1, "Attack 1", "Attack 2", "Attack 3", "Attack 4", 50, 60, 55, 65, 475, Resource.Drawable.pikachu));
            myListView = FindViewById<ListView>(Resource.Id.listView1);
            myAdapter = new MyCustomAdapter(this, myPokemonList);

            myListView.Adapter = myAdapter;
        }
    }
}