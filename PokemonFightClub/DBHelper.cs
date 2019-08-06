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
            db.ExecSQL("CREATE TABLE pokemons (id INTEGER, name TEXT, description TEXT, type TEXT, generation INTEGER, userIdOwe INTEGER, ability1 TEXT, ability2 TEXT, ability3 TEXT, ability4 TEXT, ability1Attack INTEGER, ability2Attack INTEGER, ability3Attack INTEGER, ability4Attack INTEGER)");
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
    }
}