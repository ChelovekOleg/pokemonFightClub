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
using Plugin.SecureStorage;

namespace PokemonFightClub
{
    public class FirstGeneration : Fragment
    {
        CustomAdapterLib myAdapter;
        ListView myListView;
        SearchView barFilter;
        Context context;
        DBHelper myDbInstance;
        Button toPokeball;
        List<Pokemon> myPokemonList = new List<Pokemon>();
        List<Pokemon> myPokemonListFillter = new List<Pokemon>();


        public FirstGeneration(Context context, DBHelper myDbInstance)
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
            View myView = inflater.Inflate(Resource.Layout.FstFragLayout, container, false);

            
            myListView = myView.FindViewById<ListView>(Resource.Id.listView2);
            
            barFilter = myView.FindViewById<SearchView>(Resource.Id.barSearch);
            toPokeball = myView.FindViewById<Button>(Resource.Id.btnSign);

            myPokemonList = myDbInstance.GetLiblaryPokemons(1, "0");
            myPokemonListFillter = myDbInstance.GetLiblaryPokemons(1, "0");
            myAdapter = new CustomAdapterLib(this.context, myPokemonList);
            myListView.Adapter = myAdapter;
            myListView.ChoiceMode = ChoiceMode.Single;

            barFilter.QueryTextChange += barSearch_QueryTextChange;

            this.myListView.ItemClick += myListView_ItemClick;
            //toPokeball.Click += btnToPokeball_Click;

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
                else if (e.NewText == "") {
                    myPokemonList.Add(item);
                }

            }
            
            myAdapter = new CustomAdapterLib(this.context, myPokemonList);
            myListView.Adapter = myAdapter;
            myAdapter.NotifyDataSetChanged();

        }

        void myListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e) {
            System.Console.WriteLine(myPokemonList[e.Position].id);
            myDbInstance.addToPokeball(int.Parse(CrossSecureStorage.Current.GetValue("userIdAuth")), myPokemonList[e.Position].id);
        }

        public override void OnResume()
        {
            base.OnResume();

        }
    }
}