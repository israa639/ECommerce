﻿

using Domain.Models;

namespace Domain
{
    public static class DataStore
    {
        public static List<User> Users { get; } = new()
        {
            new User(){UserID=Guid.NewGuid().ToString(),UserName="israa",
                Password="123456789",Email="israa123@gmail.com" ,
                Address=new Address(){country="egypt",city="cairo",street="roxi"} },

            new User(){UserID=Guid.NewGuid().ToString(),UserName="salah",
                Password="123456789",Email="salah@gmail.com",
                Address=new Address(){country="egypt",city="cairo",street="roxi"} }
        };
        public static HashSet<string> Emails { get; } = new HashSet<string> { "israa123@gmail.com", "salah@gmail.com" };
        public static HashSet<string> UserNames { get; } = new HashSet<string> { "israa", "salah" };

        public static List<Product> products = new()
        {
              new Product(){ProductID =1 ,Description="for men",Name="Rolex watch",StockQuantity=10,Price=700.0m},
              new Product(){ProductID =2 ,Description="for women",Name="Apple smart watch",StockQuantity=8,Price=200.0m},
              new Product(){ProductID =3 ,Description="for women",Name="Rolex watch",StockQuantity=10,Price=300.0m},
              new Product(){ProductID =4 ,Description="for women",Name="fossil watch",StockQuantity=200,Price=1000.0m},
              new Product(){ProductID =5 ,Description="for women",Name="Rolex",StockQuantity=70,Price=400.0m},

        };





    }




}