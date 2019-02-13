using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task7
{

    public class Coords
    {
        public int Latitude;
        public int Longitude;

        public Coords(int la, int lo)
        {
            this.Latitude = la;
            this.Longitude = lo;
        }
    }

    class Helicopter
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
        public Coords Position { get; set; }
        public bool Armed { get; set; }


        public Helicopter()                                                         // Default Constructor
        {
            Name = "Some name";
            Model = "Some model";
            Position = new Coords(0, 0);
            Weight = 10000;
            Armed = false;
        }

        public Helicopter(string n, string m, Coords p, int w, bool a)             // Syntax Constructor 
        {
            Name = n;
            Model = m;
            Position = p;
            Weight = w;
            Armed = a;
        }

        public Helicopter(Helicopter helicopter)                                   // Copy Constructor 
        {
            this.Name = helicopter.Name;
            this.Model = helicopter.Model;
            this.Position = helicopter.Position;
            this.Weight = helicopter.Weight;
            this.Armed = helicopter.Armed;

        }

        public override string ToString()
        {
            return $"\"{Name}\",  {Model},  {Weight} kg, armed:  {Armed},  on position {Position.Latitude}x{Position.Longitude}";
        }



    }
}
