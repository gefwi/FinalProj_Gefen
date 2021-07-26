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
        int age;
        string image;
        string city;
        int id;

        public string Breed { get => breed; set => breed = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public int Id { get => id; set => id = value; }
        public string Image { get => image; set => image = value; }
        public string City { get => city; set => city = value; }

        //double price;

        public Dogs() { }

        public Dogs(string breed, string name, int age, int id, string image, string city)
        {
            Breed = breed;
            Name = name;
            Age = age;            
            Image = image;
            City = city;
            Id = id;
        }

     
        public void Insert()
        {
            DBServices dbs = new DBServices();
            dbs.Insert(this);
        }

        //public List<Dogs> Read()
        //{
        //    DBServices dbs = new DBServices();

        //    return dbs.Read();
        //}

        public List<Dogs> getByCity(string city)
        {
            DBServices dbs = new DBServices();
            List<Dogs> fList = dbs.getByCity(city);
            return fList;

        }
       
    }
}



