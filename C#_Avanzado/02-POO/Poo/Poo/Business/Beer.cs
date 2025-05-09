using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo.Business
{
    public class Beer : ISalable
    {
        private const string Category = "Cerveza";
        private decimal _alcohol;
        public string Name { get; set; }
        protected decimal Price { get; set; }
        public decimal Alcohol
        {
            get { return _alcohol; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _alcohol = value;
            }
        }


        public Beer(string name, decimal price, decimal alcohol)
        {
            Name = name;
            Price = price;
            Alcohol = alcohol;
        }


        public virtual string GetInfo()
        {
            return $"Nombre: {Name}, Precio: {Price}, Alcohol: {Alcohol}, Categoria: {Category}";
        }

        public string GetCategory()
        {
            return Category;
        }

        public decimal GetPrice()
        {
            return Price;
        }

    }
}