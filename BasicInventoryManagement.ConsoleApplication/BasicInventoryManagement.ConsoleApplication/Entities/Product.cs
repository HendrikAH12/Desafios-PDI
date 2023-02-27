namespace BasicInventoryManagement.ConsoleApplication.Entities
{
    public class Product
    {
        public Guid Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }

        public Product(string title, string description, double price, int inStock)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Price = price;
            InStock = inStock;
        }

        public string ToString(bool IsAdmin)
        {
            if (IsAdmin)
            {
                return "Id: " + Id.ToString() + "\nTitle: " + Title + "\nDescription: " + Description + "\nPrice: " + Price.ToString() + "\nIn stock: " + InStock.ToString() + "\n";
            } else
            {
                return "Title: " + Title + "\nDescription: " + Description + "\nPrice: " + Price.ToString() + "\nIn stock: " + InStock.ToString() + "\n";
            }
        }
    }
}
