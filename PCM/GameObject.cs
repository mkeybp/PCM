using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM
{
    public class GameObject
    {
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
