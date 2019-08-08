using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace PokemonFightClub
{
    public class SecondGeneration : Fragment
    {
        CustomAdapterLib myAdapter;
        ListView myListView;
        SearchView barFilter;
        Context context;
        DBHelper myDbInstance;
        List<Pokemon> myPokemonList = new List<Pokemon>();
        List<Pokemon> myPokemonListFillter = new List<Pokemon>();

        public SecondGeneration(Context context, DBHelper myDbInstance)
        {
            this.context = context;
            this.myDbInstance = myDbInstance;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View myView = inflater.Inflate(Resource.Layout.sndFragLayout, container, false);


            myListView = myView.FindViewById<ListView>(Resource.Id.listView2);
            barFilter = myView.FindViewById<SearchView>(Resource.Id.barSearch);
            myPokemonList = myDbInstance.GetLiblaryPokemons(2, "0");
            myPokemonListFillter = myDbInstance.GetLiblaryPokemons(2, "0");
            myAdapter = new CustomAdapterLib(this.context, myPokemonList);
            myListView.Adapter = myAdapter;
            barFilter.QueryTextChange += barSearch_QueryTextChange;

            return myView;
        }

        private void barSearch_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            //Console.WriteLine(e.NewText);
            myPokemonList.Clear();
            foreach (Pokemon item in myPokemonListFillter)
            {

                if (item.name.Contains(e.NewText))
                {
                    Console.WriteLine(item.name);
                    myPokemonList.Add(item);
                }

            }
            myAdapter = new CustomAdapterLib(this.context, myPokemonList);
            myListView.Adapter = myAdapter;
            myAdapter.NotifyDataSetChanged();

        }

        public override void OnResume()
        {
            base.OnResume();

        }
    }
}