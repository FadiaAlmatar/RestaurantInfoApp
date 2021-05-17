using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantInfo.Domain.Models
{
    public class Restaurant:BaseEntity
    {
        private Restaurant(string name, string address)
        {
            Name = name;
            Address = address;
        }
        public static Restaurant Create(string name, string address)
        {
            if (String.IsNullOrWhiteSpace(name)) throw new NullReferenceException("name is Null");//validation
            return new Restaurant(name,address);
        }
        public void Update(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
