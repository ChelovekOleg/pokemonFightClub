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

            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'pikachu', 'Whenever Pikachu comes across something new, it blasts it with a jolt of electricity. If you come across a blackened berry, its evidence that this Pokémon mistook the intensity of its charge.', 'electric', 1, 0, 'Static', 'Scratch', 'Thunder', 'Dodge', 50, 25, 100, 0, 270, " + Resource.Drawable.pikachu + ")");
            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'charmeleon ', 'Charmeleon mercilessly destroys its foes using its sharp claws. If it encounters a strong foe, it turns aggressive. In this excited state, the flame at the tip of its tail flares with a bluish white color.', 'fire', 1, 0, 'Blaze', 'Scratch', 'Solar Power', 'Dodge', 45, 35, 105, 0, 250, " + Resource.Drawable.charmeleon + ")");

            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'pikachu', 'Whenever Pikachu comes across something new, it blasts it with a jolt of electricity. If you come across a blackened berry, its evidence that this Pokémon mistook the intensity of its charge.', 'electric', 2, 0, 'Static', 'Scratch', 'Thunder', 'Dodge', 50, 25, 100, 0, 270, " + Resource.Drawable.pikachu + ")");
            db.ExecSQL("Insert into pokemons values (" + random.Next() + ", 'charmeleon ', 'Charmeleon mercilessly destroys its foes using its sharp claws. If it encounters a strong foe, it turns aggressive. In this excited state, the flame at the tip of its tail flares with a bluish white color.', 'fire', 2, 0, 'Blaze', 'Scratch', 'Solar Power', 'Dodge', 45, 35, 105, 0, 250, " + Resource.Drawable.charmeleon + ")");
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
                if (idDb != 0) { return false; }
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