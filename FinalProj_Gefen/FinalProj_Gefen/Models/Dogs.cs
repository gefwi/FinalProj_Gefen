using FinalProj_Gefen.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProj_Gefen.Models
{
    public class Dogs
    {
        string breed;
        string name;
        double price;
        int id;

    
        public Dogs() { }

        public Dogs(string breed, string name, double price, int id)
        {
            Breed = breed;
            Name = name;
            Price = price;
            Id = id;
        }

        public string Breed { get => breed; set => breed = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Id { get => id; set => id = value; }

        public void Insert()
        {
            DBServices dbs = new DBServices();
            dbs.Insert(this);
        }

        // TODO: Add a Delete Method
        public int Delete(int id)
        {
            DBServices dbs = new DBServices();
            return dbs.Delete(id);
        }

        public List<Dogs> getByMaxPrice(double maxPrice)
        {

            DBServices dbs = new DBServices();
            List<Dogs> fList = dbs.getByMaxPrice(maxPrice);
            return fList;

        }

    }
}



