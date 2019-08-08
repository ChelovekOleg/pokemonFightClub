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
    [Activity(Label = "FightPage")]
    public class FightPage : Activity
    {
        TextView hpOne;
        TextView hpTwo;
        Button btnAttack1;
        Button btnAttack2;
        Button btnAttack3;
        Button btnAttack4;
        TextView nameOne;
        TextView nameTwo;
        ImageView imageOne;
        ImageView imageTwo;
        Pokemon pokemonFight;
        Pokemon pokemonBot;
        DBHelper myDbInstance;
        Random random = new Random();
        Android.App.AlertDialog.Builder myAlert;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.fightPage);
            imageOne = FindViewById<ImageView>(Resource.Id.versPic1);
            imageTwo = FindViewById<ImageView>(Resource.Id.versPic2);
            nameOne = FindViewById<TextView>(Resource.Id.versDescript1);
            nameTwo = FindViewById<TextView>(Resource.Id.versDescript2);
            btnAttack1 = FindViewById<Button>(Resource.Id.btnAttack1);
            btnAttack2 = FindViewById<Button>(Resource.Id.btnAttack2);
            btnAttack3 = FindViewById<Button>(Resource.Id.btnAttack3);
            btnAttack4 = FindViewById<Button>(Resource.Id.btnAttack4);
            hpOne = FindViewById<TextView>(Resource.Id.hpOne);
            hpTwo = FindViewById<TextView>(Resource.Id.hpTwo);
            pokemonFight = JsonConvert.DeserializeObject<Pokemon>(Intent.GetStringExtra("pokemonFight"));
            myDbInstance = new DBHelper(this);
            myAlert = new Android.App.AlertDialog.Builder(this);
            pokemonBot = myDbInstance.RandPokemonForFight();
            //Pokemon Player
            imageOne.SetImageResource(pokemonFight.image);
            nameOne.Text = pokemonFight.name;
            btnAttack1.Text = pokemonFight.abilityOne;
            btnAttack2.Text = pokemonFight.abilityTwo;
            btnAttack3.Text = pokemonFight.abilityThree;
            btnAttack4.Text = pokemonFight.abilityFour;
            hpOne.Text = pokemonFight.hp + " HP";

            //PokemonBot
            imageTwo.SetImageResource(pokemonBot.image);
            nameTwo.Text = pokemonBot.name;
            hpTwo.Text = pokemonBot.hp + " HP";

            btnAttack1.Click += delegate {
                pokemonBot.attack(pokemonFight.abilityOneAttack);
                hpTwo.Text = pokemonBot.checkHealthPoints().ToString() + " HP";
                pokemonFight.attack(randomAttack());
                hpOne.Text = pokemonFight.checkHealthPoints().ToString() + " HP";
                checkWinner();
            };
            btnAttack2.Click += delegate {
                pokemonBot.attack(pokemonFight.abilityTwoAttack);
                hpTwo.Text = pokemonBot.checkHealthPoints().ToString() + " HP";
                pokemonFight.attack(randomAttack());
                hpOne.Text = pokemonFight.checkHealthPoints().ToString() + " HP";
                checkWinner();
            };
            btnAttack3.Click += delegate {
                pokemonBot.attack(pokemonFight.abilityThreeAttack);
                hpTwo.Text = pokemonBot.checkHealthPoints().ToString() + " HP";
                pokemonFight.attack(randomAttack());
                hpOne.Text = pokemonFight.checkHealthPoints().ToString() + " HP";
                checkWinner();
            };
            btnAttack4.Click += delegate {
                pokemonBot.attack(pokemonFight.abilityFourAttack);
                hpTwo.Text = pokemonBot.checkHealthPoints().ToString() + " HP";
                pokemonFight.attack(randomAttack());
                hpOne.Text = pokemonFight.checkHealthPoints().ToString() + " HP";
                checkWinner();
            };

        }

        public int randomAttack() {
            
            int attackDamage;
            switch (random.Next(1, 5))
            {
                case 1:
                    attackDamage = pokemonBot.abilityOneAttack;
                    break;
                case 2:
                    attackDamage = pokemonBot.abilityTwoAttack;
                    break;
                case 3:
                    attackDamage = pokemonBot.abilityThreeAttack;
                    break;
                case 4:
                    attackDamage = pokemonBot.abilityFourAttack;
                    break;
                default:
                    attackDamage = pokemonBot.abilityOneAttack;
                    break;
            }
            return attackDamage;
        }

        public void checkWinner()
        {
            if (pokemonFight.checkHealthPoints() <= 0 && pokemonFight.checkHealthPoints() < pokemonBot.checkHealthPoints()) {
                
                myAlert.SetTitle("You lose!");
                myAlert.SetMessage(pokemonBot.name + " enemy won!!");
                myAlert.SetPositiveButton("OK", OkAction);
                Dialog myDialog = myAlert.Create();
                myDialog.Show();
                
                //PokemonBot Winner
            } else if (pokemonBot.checkHealthPoints() <= 0 && pokemonFight.checkHealthPoints() > pokemonBot.checkHealthPoints()) {
                
                myAlert.SetTitle("You won!");
                myAlert.SetMessage("Your " + pokemonFight.name + " won!!");
                myAlert.SetPositiveButton("OK", OkAction);
                Dialog myDialog = myAlert.Create();
                myDialog.Show();
            }
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            Intent pokeballPage = new Intent(this, typeof(PokeballPage));
            StartActivity(pokeballPage);
        }
        
    }
}