namespace BasicInventoryManagement.ConsoleApplication.Entities
{
    public class Order
    {
        public string UserEmail { get; set; }
        public List<(Guid ProductId, int Quantity)> Products { get; set; }
        public double Amount { get; set; }

        public Order(string userEmail, List<(Guid ProductId, int Quantity)> products, double amount) { 
            UserEmail = userEmail;
            Products = products;
            Amount = amount;
        }

        public string ToString(List<Product> products)
        {
            return "User email: " + UserEmail + "\n" + ProductsToString(products) + "\nAmount: " + Amount + "\n";
        }

        public string ProductsToString(List<Product> products)
        {
            string aux = "";
            Product product;
            double total = 0;

            for (int i = 0; i < this.Products.Count; i++)
            {
                product = products.Find(p => p.Id.Equals(this.Products[i].ProductId));
                total += this.Products[i].Quantity * product.Price;

                aux += "Product " + i + ":\n" + "Title: " + product.Title + "\nQuantity: " + this.Products[i].Quantity + "\nPrice: " + this.Products[i].Quantity * product.Price + "\n";

                if (this.Products.Count - 1 > i)
                {
                    aux += "\n";
                }
            }

            return "\n" + aux;
        }
    }
}
