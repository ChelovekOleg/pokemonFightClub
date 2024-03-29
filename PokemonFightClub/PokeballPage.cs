﻿using System;
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
    [Activity(Label = "PokeballPage")]
    public class PokeballPage : Activity
    {
        ListView myListView;
        MyCustomAdapter myAdapter;
        List<Pokemon> myPokemonList = new List<Pokemon>();
        DBHelper myDbInstance;
        TextView noItem;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.myPokeBall);
            myDbInstance = new DBHelper(this);
            //Change to id user
            string userIdLog = CrossSecureStorage.Current.GetValue("userIdAuth");
            myPokemonList = myDbInstance.GetLiblaryPokemons(1, userIdLog);
            if (myPokemonList.Count == 0) {
                noItem = FindViewById<TextView>(Resource.Id.noItemsInList);
                noItem.Text = "You have not got pokemons yet!";
                noItem.SetHeight(100);
            }
            myListView = FindViewById<ListView>(Resource.Id.listView1);
            myAdapter = new MyCustomAdapter(this, myPokemonList);

            myListView.Adapter = myAdapter;
        }
    }
}