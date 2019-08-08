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

using Android.Database.Sqlite;
using Android.Database;

namespace PokemonFightClub
{
    public class DBHelper : SQLiteOpenHelper
    {
        Random random = new Random();

        private static string _DatabaseName = "pokemonFightClub.db";
        private const string TableName = "users";
        private const string ColumnId = "id";
        private const string ColumnName = "name";
        private const string ColumnEmail = "email";
        private const string ColumnUserName = "username";
        private const string ColumnPass = "password";

        private const string TablePokemonName = "pokemons";

        public const string createUserTableQuery = "CREATE TABLE " + TableName + "(" + ColumnId + " INTEGER," + ColumnName + " TEXT,"
            + ColumnEmail + " TEXT," + ColumnUserName + " TEXT," + ColumnPass + " TEXT)";
        

        SQLiteDatabase myObj;
        Context myContext;

        public DBHelper(Context context) : base(context, name: _DatabaseName, factory: null, version: 1)
        {
            myContext = context;
            myObj = WritableDatabase;
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(createUserTableQuery);
            db.ExecSQL("CREATE TABLE pokemons (id INTEGER, name TEXT, description TEXT, type TEXT, generation INTEGER, userIdOwe INTEGER, ability1 TEXT, ability2 TEXT, ability3 TEXT, ability4 TEXT, ability1Attack INTEGER, ability2Attack INTEGER, ability3Attack INTEGER, ability4Attack INTEGER, hp INTEGER, image INTEGER)");
            //First Generation
            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'Pikachu', 'Pikachu is a short, chubby rodent Pokémon. It is covered in yellow fur with two horizontal brown stripes on its back. It has a small mouth, long, pointed ears with black tips, and brown eyes. Each cheek is a red circle that contains a pouch for electricity storage. It has short forearms with five fingers on each paw, and its feet each have three toes. At the base of its lightning bolt-shaped tail is a patch of brown fur. A female will have a V-shaped notch at the end of its tail, which looks like the top of a heart. It is classified as a quadruped, but it has been known to stand and walk on its hind legs.', 'Electric', 1, 0, 'Static', 'Scratch', 'Thunder', 'Dodge', 30, 15, 50, 0, 100, " + Resource.Drawable.Pikachu + ")");
            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'Charmander', 'Charmander is a bipedal, reptilian Pokémon with a primarily orange body and blue eyes. Its underside from the chest down and the soles of its feet are cream-colored. It has two small fangs visible in its upper jaw and two smaller fangs in its lower jaw. A fire burns at the tip of this Pokémon s slender tail and has blazed there since Charmander s birth. The flame can be used as an indication of Charmander s health and mood, burning brightly when the Pokémon is strong, weakly when it is exhausted, wavering when it is happy, and blazing when it is enraged. It is said that Charmander dies if its flame goes out. However, if the Pokémon is healthy, the flame will continue to burn even if it gets a bit wet and is said to steam in the rain.', 'Fire', 1, 0, 'Flamethrower', 'Flame Burst', 'Slash', 'Dodge', 30, 17, 45, 0, 100, " + Resource.Drawable.Charmander + ")");
            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'Bulbasaur', 'Bulbasaur is a small, quadruped Pokémon that has blue-green skin with darker patches. It has red eyes with white pupils, pointed, ear-like structures on top of its head, and a short, blunt snout with a wide mouth. A pair of small, pointed teeth are visible in the upper jaw when its mouth is open. Each of its thick legs ends with three sharp claws. On its back is a green plant bulb, which is grown from a seed planted there at birth. The bulb provides it with energy through photosynthesis as well as from the nutrient-rich seeds contained within.', 'Grass,Poison', 1, 0, 'Leech Seed', 'Vine Whip', 'Poison Powder', 'Dodge', 30, 17, 45, 0, 100, " + Resource.Drawable.bulbasaur + ")");
            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'Igglybuff', 'Igglybuff is a small, bipedal balloon-like animal that is completely pink. It has a rounded tuft of hair on top of its head, a small swirl-like pattern on its forehead, and red eyes. Igglybuff has small, stubby limbs. This small Pokémon is extremely elastic and can bounce like a ball, although it may not be able to stop if it does this.', 'Normal,Fairy', 1, 0, 'Sing', 'Pound', 'Sweet Kiss', 'Dodge', 15, 11, 28, 0, 200, " + Resource.Drawable.Igglybuff + ")");
            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'Mew', 'Mew is a pink, bipedal Pokémon with mammalian features. It has a rounded, wide snout, triangular ears, and large, blue eyes. It has short arms with three-fingered paws and large hind paws with oval markings on the soles. Its tail is long and thin with an ovoid tip. Its fur is so fine and thin, it can only be seen under a microscope. Mew is said to have the DNA of every single Pokémon contained within its body, and as such is able to learn any attack.', 'Psychic', 1, 0, 'Amnesia', 'Psywave', 'Barrier', 'Dodge', 40, 8, 50, 0, 200, " + Resource.Drawable.Mew + ")");
            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'Squirtle', 'Squirtle is a small Pokémon that resembles a light blue turtle. While it typically walks on its two short legs, it has been shown to run on all fours in Super Smash Bros. Brawl. It has large, purplish or reddish eyes and a slightly hooked upper lip. Each of its hands and feet have three pointed digits. The end of its long tail curls inward. Its body is encased by a tough shell that forms and hardens after birth. This shell is brown on the top, pale yellow on the bottom, and has a thick white ridge between the two halves.', 'Water', 1, 0, 'Bubble', 'Tackle', 'Water Gun', 'Dodge', 30, 17, 45, 0, 100, " + Resource.Drawable.Squirtle + ")");
            //Second Generation
            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'Raichu', 'Raichu is a bipedal, rodent-like Pokémon. Raichu is covered in dark orange fur with a white belly. Its bifurcated ears are brown on the outside, yellow on the insides, and end in a distinctive curl. There is a circular yellow marking on each cheek where its electric sacs are, and it has a triangular, dark brown nose. Its arms and feet have patches of brown fur at the end, and the soles of its long feet are tan with a circular orange pad in the center. On its back are two horizontal brown stripes. Its long, thin tail has a lightning bolt-shaped end. This lightning bolt is smaller on females. Raichu exudes a weak electrical charge from all its body and glows slightly in the dark.', 'Electric', 2, 0, 'Static', 'Scratch', 'Thunder', 'Dodge', 40, 20, 60, 0, 150, " + Resource.Drawable.Raichu + ")");
            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'Charizard', 'Charizard is a draconic, bipedal Pokémon. It is primarily orange with a cream underside from the chest to the tip of its tail. It has a long neck, small blue eyes, slightly raised nostrils, and two horn-like structures protruding from the back of its rectangular head. There are two fangs visible in the upper jaw when its mouth is closed. Two large wings with blue-green undersides sprout from its back, and a horn-like appendage juts out from the third joint of each wing. A single wing-finger is visible through the center of each wing membrane. Charizard s arms are short and skinny compared to its robust belly, and each limb has three white claws. It has stocky legs with cream-colored soles on each of its plantigrade feet. The tip of its long, tapering tail burns with a sizable flame.', 'Fire', 2, 0, 'Flamethrower', 'Flame Burst', 'Slash', 'Dodge', 40, 23, 55, 0, 150, " + Resource.Drawable.Charizard + ")");
            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'Venusaur', 'Venusaur is a squat, quadruped Pokémon with bumpy, blue-green skin. It has small, circular red eyes, a short, blunt snout, and a wide mouth with two pointed teeth in the upper jaw and four in the lower jaw. On top of its head are small, pointed ears with reddish pink insides. It has three clawed toes on each foot. The bud on its back has bloomed in a large pink, white-spotted flower. The flower is supported by a thick, brown trunk surrounded by green fronds. A female Venusaur will have a seed in the center of its flower.', 'Grass,Poison', 2, 0, 'Leech Seed', 'Vine Whip', 'Poison Powder', 'Dodge', 40, 23, 55, 0, 150, " + Resource.Drawable.Venusaur + ")");
            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'Wigglytuff', 'Wigglytuff is a Pokémon with a bean-shaped body and stubby arms and legs. There is a fluffy, curled tuft of fur on its head. It has long, rabbit-like ears with black insides and slightly lighter color at the tips. Its large, blue eyes are covered in layer of tears that quickly washes away any debris. It is covered in pink fur with a white belly. This fine layer of fur is so soft that those who touch it, including other Wigglytuff, will not want to stop.', 'Normal,Fairy', 2, 0, 'Sing', 'Pound', 'Sweet Kiss', 'Dodge', 25, 21, 38, 0, 250, " + Resource.Drawable.Wigglytuff + ")");
            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'Mewtwo', 'Mewtwo is a Pokémon created by science. It is a bipedal, humanoid creature with some feline features. It is primarily gray with a long, purple tail. On top of its head are two short, blunt horns, and it has purple eyes. A tube extends from the back of its skull to the top of its spine, bypassing its neck. It has a defined chest and shoulders, which resemble a breastplate. The three digits on each hand and foot have spherical tips. Its tail is thick at the base, but thins before ending in a small bulb.', 'Psychic', 2, 0, 'Amnesia', 'Psywave', 'Barrier', 'Dodge', 50, 18, 60, 0, 250, " + Resource.Drawable.mewtwo + ")");
            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'Blastoise', 'Blastoise is a large, bipedal turtle-like Pokémon. Its body is blue and is mostly hidden by its tough, brown shell. This shell has a cream-colored underside and a white ridge encircling its arms and separating the upper and lower halves. Two powerful water cannons reside in the top of shell over its shoulders. These cannons can be extended or withdrawn. Blastoise s head has triangular ears that are black on the inside, small brown eyes, and a cream-colored lower jaw. Its arms are thick, and it has three claws on each hand. Its feet have three claws on the front and one on the back. Poking out of the bottom of its shell is a stubby tail.', 'Water', 2, 0, 'Bubble', 'Tackle', 'Water Gun', 'Dodge', 40, 27, 55, 0, 150, " + Resource.Drawable.Blastoise + ")");
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            throw new NotImplementedException();
        }

        public void insertNewUser(int id, string name, string email,string username, string pass)
        {
            String insertQuery = "Insert into " + TableName + " values(" + id + "," + "'" + name + "'" + "," + "'" + email + "'" + "," + "'" + username + "'" + "," + "'" + pass + "'" + ");";

            myObj.ExecSQL(insertQuery);
        }

        public int getUserId(string login)
        {
            ICursor cursor = myObj.RawQuery("select id from users where username = '" + login + "';", null);
            cursor.MoveToFirst();
            
            return cursor.GetInt(cursor.GetColumnIndex("id"));
            
                
        }

        public bool addToPokeball(int idPlayer, int pokemonId) {
            ICursor cursor = myObj.RawQuery("select userIdOwe from pokemons where id = " + pokemonId + ";", null);
            if (cursor.MoveToFirst())
            {
                int idDb = cursor.GetInt(cursor.GetColumnIndex("userIdOwe"));
                if (idDb != 0 && idDb != idPlayer) { return false; }
                myObj.ExecSQL("UPDATE pokemons set userIdOwe = " + idPlayer + " where id = " + pokemonId + ";");
            }
                return true;
        }

        public bool checkUser(string name, string pass)
        {
            String selectQuery = "Select " + ColumnUserName + ", " + ColumnPass + " from " + TableName + " where " + ColumnUserName + " = " + "'" + name + "'" + " and " + ColumnPass + " = " + "'" + pass + "'" + ";";
            ICursor result = myObj.RawQuery(selectQuery, null);

            if (result.Count > 0)
            {
                Console.WriteLine("Inserted");
                return true;
            }
            else
            {
                return false;
            }
        }

        public Pokemon RandPokemonForFight() {
            ICursor cursor = myObj.RawQuery("select * from pokemons ORDER BY random() LIMIT 1", null);
            cursor.MoveToFirst();
            int id = cursor.GetInt(cursor.GetColumnIndex("id"));
            String name = cursor.GetString(cursor.GetColumnIndex("name"));
            String description = cursor.GetString(cursor.GetColumnIndex("description"));
            String type = cursor.GetString(cursor.GetColumnIndex("type"));
            int generation = cursor.GetInt(cursor.GetColumnIndex("generation"));
            int userIdOwe = cursor.GetInt(cursor.GetColumnIndex("userIdOwe"));
            String ab1 = cursor.GetString(cursor.GetColumnIndex("ability1"));
            String ab2 = cursor.GetString(cursor.GetColumnIndex("ability2"));
            String ab3 = cursor.GetString(cursor.GetColumnIndex("ability3"));
            String ab4 = cursor.GetString(cursor.GetColumnIndex("ability4"));
            int ab1Attack = cursor.GetInt(cursor.GetColumnIndex("ability1Attack"));
            int ab2Attack = cursor.GetInt(cursor.GetColumnIndex("ability2Attack"));
            int ab3Attack = cursor.GetInt(cursor.GetColumnIndex("ability3Attack"));
            int ab4Attack = cursor.GetInt(cursor.GetColumnIndex("ability4Attack"));
            int hp = cursor.GetInt(cursor.GetColumnIndex("hp"));
            int image = cursor.GetInt(cursor.GetColumnIndex("image"));
            return new Pokemon(id, name, type, "" + userIdOwe + "", description, generation, ab1, ab2, ab3, ab4, ab1Attack, ab2Attack, ab3Attack, ab4Attack, hp, image);
        }

        public List<Pokemon> GetLiblaryPokemons(int generationLib, string userIdParse) {
            int userId = Int32.Parse(userIdParse);
            List<Pokemon> listPokemons = new List<Pokemon>();
            String whereCondition = "";
            if (userId > 0)
            {
                whereCondition = "userIdOwe = " + userId + ";";
            }
            else
            {
                whereCondition = "generation = '" + generationLib + "';";
            }

                ICursor cursor = myObj.RawQuery("select * from pokemons where " + whereCondition + "", null);
            
            
            if (cursor.MoveToFirst()) {
                while (!cursor.IsAfterLast) {
                    int id = cursor.GetInt(cursor.GetColumnIndex("id"));
                    String name = cursor.GetString(cursor.GetColumnIndex("name"));
                    String description = cursor.GetString(cursor.GetColumnIndex("description"));
                    String type = cursor.GetString(cursor.GetColumnIndex("type"));
                    int generation = cursor.GetInt(cursor.GetColumnIndex("generation"));
                    int userIdOwe = cursor.GetInt(cursor.GetColumnIndex("userIdOwe"));
                    String ab1 = cursor.GetString(cursor.GetColumnIndex("ability1"));
                    String ab2 = cursor.GetString(cursor.GetColumnIndex("ability2"));
                    String ab3 = cursor.GetString(cursor.GetColumnIndex("ability3"));
                    String ab4 = cursor.GetString(cursor.GetColumnIndex("ability4"));
                    int ab1Attack = cursor.GetInt(cursor.GetColumnIndex("ability1Attack"));
                    int ab2Attack = cursor.GetInt(cursor.GetColumnIndex("ability2Attack"));
                    int ab3Attack = cursor.GetInt(cursor.GetColumnIndex("ability3Attack"));
                    int ab4Attack = cursor.GetInt(cursor.GetColumnIndex("ability4Attack"));
                    int hp = cursor.GetInt(cursor.GetColumnIndex("hp"));
                    int image = cursor.GetInt(cursor.GetColumnIndex("image"));

                    listPokemons.Add(new Pokemon(id, name, type, ""+userIdOwe+"", description, generation, ab1, ab2, ab3, ab4, ab1Attack, ab2Attack, ab3Attack, ab4Attack, hp, image));
                    cursor.MoveToNext();
                }
            }

            return listPokemons;
        }
    }
}