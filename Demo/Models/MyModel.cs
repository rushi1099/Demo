using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class MyModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }

        // Static method to simulate data fetching
        public static List<MyModel> GetData()
        {
            return new List<MyModel>
            {
                //new MyModel { ID = 1, Name = "Book 1", Pages = 300, Author = "Author 1", ImageUrl = "url1.jpg", Price = 29.99, InStock = 10 },
                //new MyModel { ID = 2, Name = "Book 2", Pages = 250, Author = "Author 2", ImageUrl = "url2.jpg", Price = 19.99, InStock = 5 },
                //new MyModel { ID = 3, Name = "Book 3", Pages = 400, Author = "Author 3", ImageUrl = "url3.jpg", Price = 39.99, InStock = 2 }

               new MyModel {Name="Rama II", Author="Arthur C. Clark", Pages=281,ImageUrl="rama.jpg", InStock=54, Price=44.23 },
               new MyModel {Name="Exhalation", Author="Ted Chiang", Pages=556,ImageUrl="exhalation.jpg", InStock=13, Price=50.99 },
               new MyModel {Name="Traffic Secrets", Author="Russell Brunson", Pages=306,ImageUrl="traffic.jpg", InStock=65, Price=18.97 },
               new MyModel {Name="Clean Code", Author="Robert Martin", Pages=464,ImageUrl="clean.jpg", InStock=15, Price=87.00 }
            };
        }
    }
}