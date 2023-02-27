namespace BasicInventoryManagement.ConsoleApplication.Entities
{
    public class Cart
    {
        public string UserEmail { get; set; }
        public List<(Guid ProductId, int Quantity)> Products { get; set; }

        public Cart(string userEmail) 
        {
            UserEmail = userEmail;
            Products = new List<(Guid ProductId, int Quantity)>();
        }

        public (string, double) ToString(List<Product> products)
        {
            if (Products.Count != 0) {
                string aux = "";
                Product product;
                double total = 0;

                for (int i = 0; i < Products.Count; i++)
                {
                    product = products.Find(p => p.Id.Equals(Products[i].ProductId));
                    total += Products[i].Quantity * product.Price;

                    aux += "Product " + i + ":\n" + "Title: " + product.Title + "\nQuantity: " + Products[i].Quantity + "\nPrice: " + Products[i].Quantity * product.Price + "\n";

                    if (Products.Count - 1 > i)
                    {
                        aux += "\n";
                    }
                }

                return ("\n" + aux, total);
            } else
            {
                return ("\nYour shopping cart is empty\n", 0);
            }
        }
    }
}
