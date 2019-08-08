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
    class CustomAdapterLib : BaseAdapter<Pokemon>
    {

        Context myContext;
        List<Pokemon> myListArray;

        public CustomAdapterLib(Context context, List<Pokemon> mySubjectList)
        {

            myContext = context;
            myListArray = mySubjectList;

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
                myView.FindViewById<TextView>(Resource.Id.subjectDescriptID).Text = pokemon.name + ": " + pokemon.description;
                
            }

            return myView;
        }

    }
}