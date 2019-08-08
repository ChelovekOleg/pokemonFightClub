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
    public class Pokemon
    {
        public int id = 0;
        public string name = "";
        public string type = "";
        public string userIdOwe = "";
        public string description = "";
        public int generation = 0;
        public string abilityOne = "";
        public string abilityTwo = "";
        public string abilityThree = "";
        public string abilityFour = "";
        public int abilityOneAttack = 0;
        public int abilityTwoAttack = 0;
        public int abilityThreeAttack = 0;
        public int abilityFourAttack = 0;
        public int hp = 0;
        public int image = 0;

        // 3. CONSTRUCRTOR
        public Pokemon(int id, string name, string type, string userIdOwe, string description, int generation, string abilityOne, string abilityTwo, string abilityThree, string abilityFour, int abilityOneAttack, int abilityTwoAttack, int abilityThreeAttack, int abilityFourAttack, int hp, int image)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.hp = hp;
            this.userIdOwe = userIdOwe;
            this.description = description;
            this.generation = generation;
            this.abilityOne = abilityOne;
            this.abilityTwo = abilityTwo;
            this.abilityThree = abilityThree;
            this.abilityFour = abilityFour;
            this.abilityOneAttack = abilityOneAttack;
            this.abilityTwoAttack = abilityTwoAttack;
            this.abilityThreeAttack = abilityThreeAttack;
            this.abilityFourAttack = abilityFourAttack;
            this.image = image;
        }

        // 4. METHODS
       
        public int checkHealthPoints()
        {
            return this.hp;
        }

        public void attack(int damage) {
            this.hp -= damage;
        }
    }
}