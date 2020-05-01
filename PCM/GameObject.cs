using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM
{
    public enum GameState { StartScreen, Transfer, Racing }

    public enum CRUD { Read, Create, Update, Delete }
    public abstract class GameObject
    {
        //public GameState gamestate = new GameState();
        //public CRUD crud = new CRUD();

        public static int gameS;

        public SQLiteDataReader result;
        public SQLiteConnection connection;
        public SQLiteCommand command;
        public int id;
        public string name;
        public float stamina;
        public float speed;
        public float strength;
        public float weight;
        public float age;
        public float experince;
        public float price;
    }
}
