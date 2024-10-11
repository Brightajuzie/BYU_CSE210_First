using System;
using System.Collections.Generic;

namespace OrderSystem
{
    public class Product
    {
        private string name;
        private string productId;
        private decimal pricePerUnit;
        private int quantity;

        public Product(string name, string productId, decimal pricePerUnit, int quantity)
        {
            this.name = name;
            this.productId = productId;
            this.pricePerUnit = pricePerUnit;
            this.quantity = quantity;
        }

        public string Name { get => name; set => name = value; }
        public string ProductId { get => productId; set => productId = value; }
        public decimal PricePerUnit { get => pricePerUnit; set => pricePerUnit = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public decimal CalculateTotalCost()
        {
            return pricePerUnit * quantity;
        }
    }

    public class Address
    {
        private string streetAddress;
        private string city;
        private string stateProvince;
        private string country;

        public Address(string streetAddress, string city, string stateProvince, string country)
        {
            this.streetAddress = streetAddress;
            this.city = city;
            this.stateProvince = stateProvince;
            this.country = country;
        }

        public string StreetAddress { get => streetAddress; set => streetAddress = value; }
        public string City { get => city; set => city = value; }
        public string StateProvince { get => stateProvince; set => stateProvince = value; }
        public string Country { get => country; set => country = value; }

        public bool IsInUSA()
        {
            return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"{streetAddress}\n{city}, {stateProvince}\n{country}";
        }
    }

    public class Customer
    {
        private string name;
        private Address address;

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        public string Name { get => name; set => name = value; }
        public Address Address { get => address; set => address = value; }

        public bool IsInUSA()
        {
            return address.IsInUSA();
        }
    }

    public class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
            this.products = new List<Product>();
        }

        public List<Product> Products { get => products; set => products = value; }
        public Customer Customer { get => customer; set => customer = value; }

        public decimal CalculateTotalCost()
        {
            decimal productTotal = products.Sum(p => p.CalculateTotalCost());
            decimal shippingCost = customer.IsInUSA() ? 5 : 35;
            return productTotal + shippingCost;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label\n";
            foreach (Product product in products)
            {
                label += $"{product.Name} ({product.ProductId})\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            string label = "Shipping Label\n";
            label += $"{customer.Name}\n";
            label += customer.Address.ToString();
            return label;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creation of products
            Product product1 = new Product("Akara", "P1", 10.0m, 2);
            Product product2 = new Product("Custard", "P2", 5.0m, 3);
            Product product3 = new Product("Garri ", "P3", 5.0m, 3);


            // Create customers
            Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
            Address address2 = new Address("45 Uzo Ulo St", "Aba", "Abia", "Nigeria");
            Customer customer1 = new Customer("Mazi Kachi", address1);
            Customer customer2 = new Customer("Chibiara Dozie", address2);

            // Create orders
            Order order1 = new Order(customer1);
            order1.Products.Add(product1);
            order1.Products.Add(product2);

            Order order2 = new Order(customer2);
            order2.Products.Add(product1);

            // Display order information
            Console.WriteLine("Order 1:");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine("Total cost: $" + order1.CalculateTotalCost());

            Console.WriteLine("\nOrder 2:");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine("Total cost: $" + order2.CalculateTotalCost());
        }
    }
}
