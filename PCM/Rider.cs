using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM
{
    public class Rider : GameObject
    {
        public Rider()
        {

            id = DatabaseConnection.Instance.id;
            name = DatabaseConnection.Instance.name;
            stamina = DatabaseConnection.Instance.stamina;
            speed = DatabaseConnection.Instance.speed;
            strength = DatabaseConnection.Instance.strength;
            weight = DatabaseConnection.Instance.weight;
            age = DatabaseConnection.Instance.age;
            experince = DatabaseConnection.Instance.experince;
            price = DatabaseConnection.Instance.price;
        }


    }
}
