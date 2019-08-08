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
using Newtonsoft.Json;

namespace PokemonFightClub
{
    [Activity(Label = "Description")]
    public class Description : Activity
    {
        ImageView image;
        TextView description;
        TextView descriptionAbilities;
        Pokemon clickedPok;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.descriptPokeLayout);
            image = FindViewById<ImageView>(Resource.Id.descriptPictrID);
            descriptionAbilities = FindViewById<TextView>(Resource.Id.descriptAbilitiesID);
            description = FindViewById<TextView>(Resource.Id.descriptListID);
            //clickedPok = (Pokemon)this.Intent.Extras.Get("pokemonClicked");
            clickedPok = JsonConvert.DeserializeObject<Pokemon>(Intent.GetStringExtra("pokemonClicked"));
            image.SetImageResource(clickedPok.image);
            descriptionAbilities.Text = "Abilities" + System.Environment.NewLine + clickedPok.abilityOne + ": " + clickedPok.abilityOneAttack + " hp" + System.Environment.NewLine + "" + clickedPok.abilityTwo + ": " + clickedPok.abilityTwoAttack + " hp" + System.Environment.NewLine + clickedPok.abilityThree + ": " + clickedPok.abilityThreeAttack + System.Environment.NewLine + clickedPok.abilityFour + ": " + clickedPok.abilityFourAttack;
            description.Text = clickedPok.description;
        }
    }
}