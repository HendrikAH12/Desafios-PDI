using BasicInventoryManagement.ConsoleApplication.Entities;

namespace basicInventoryManagement.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int optionFirstMenu = 0;
            Dictionary<string, User> users = new Dictionary<string, User>();
            User admin = new User("admin@invmanagement.com", "admin123", true);
            users.Add("admin@invmanagement.com", admin);

            List<Product> products = new List<Product>();
            Product banana = new Product("banana", "fruta", 2, 10);
            Product abacaxi = new Product("abacaxi", "fruta", 4, 8);
            products.Add(banana);
            products.Add(abacaxi);

            List<Cart> carts = new List<Cart>();

            List<Order> orders = new List<Order>();

            do
            {
                try
                {
                    Console.WriteLine("1 - Register\n2 - Login\n3 - Exit");
                    optionFirstMenu = Convert.ToInt32(Console.ReadLine());

                    int optionSecondMenu = 0;
                    string userName, email, password;
                    User user;
                    Cart userCart;

                    switch (optionFirstMenu)
                    {
                        case 1:
                            Console.Write("\nEmail: ");
                            email = Console.ReadLine();

                            Console.Write("Password: ");
                            password = Console.ReadLine();

                            if (!users.ContainsKey(email))
                            {
                                user = new User(email, password);
                                users.Add(email, user);

                                userCart = new Cart(email);
                                carts.Add(userCart);

                                Console.WriteLine("\nCreated user\n");
                            } else
                            {
                                Console.WriteLine("\nUser already registered\n");
                            }
                            break;

                        case 2:
                            Console.Write("\nEmail: ");
                            email = Console.ReadLine();

                            Console.Write("Password: ");
                            password = Console.ReadLine();

                            if(users.ContainsKey(email))
                            {
                                user = users[email];

                                if (user.Password == password)
                                {
                                    Console.WriteLine("\nLogged in\n");

                                    Product product;
                                    int optionThirdMenu = 0;

                                    if (user.IsAdmin)
                                    {
                                        do
                                        {
                                            try
                                            {
                                                Console.WriteLine("1 - View orders\n2 - Add product\n3 - View products\n4 - Update product\n5 - Delete product\n6 - Exit");
                                                optionSecondMenu = Convert.ToInt32(Console.ReadLine());

                                                string title, description, productId;
                                                double price;
                                                int inStock;
                                                Order order;

                                                switch (optionSecondMenu)
                                                {
                                                    case 1:
                                                        Console.WriteLine("");

                                                        if (orders.Count != 0)
                                                        {
                                                            for (int i = 0; i < orders.Count; i++)
                                                            {
                                                                order = orders[i];
                                                                Console.WriteLine(order.ToString(products));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("No order has been registered\n");
                                                        }
                                                        break;

                                                    case 2:
                                                        Console.Write("\nTitle: ");
                                                        title = Console.ReadLine();

                                                        Console.Write("Description: ");
                                                        description = Console.ReadLine();

                                                        Console.Write("Price: ");
                                                        price = Convert.ToDouble(Console.ReadLine());

                                                        Console.Write("In stock: ");
                                                        inStock = Convert.ToInt32(Console.ReadLine());

                                                        product = new Product(title, description, price, inStock);
                                                        products.Add(product);

                                                        Console.WriteLine("\nCreated product\n");
                                                        break;

                                                    case 3:
                                                        Console.WriteLine("");

                                                        if (products.Count != 0)
                                                        {
                                                            for (int i = 0; i < products.Count; i++)
                                                            {
                                                                product = products[i];
                                                                Console.WriteLine(product.ToString(user.IsAdmin));
                                                            }
                                                        } else
                                                        {
                                                            Console.WriteLine("No product has been registered\n");
                                                        }
                                                        break;

                                                    case 4:
                                                        Console.Write("\nProduct id: ");
                                                        productId = Console.ReadLine();

                                                        product = products.Find(p => p.Id.ToString().Equals(productId));

                                                        if (product != null)
                                                        {
                                                            Console.Write("\nTitle: ");
                                                            title = Console.ReadLine();

                                                            Console.Write("Description: ");
                                                            description = Console.ReadLine();

                                                            Console.Write("Price: ");
                                                            price = Convert.ToDouble(Console.ReadLine());

                                                            Console.Write("In stock: ");
                                                            inStock = Convert.ToInt32(Console.ReadLine());

                                                            product.Title = title;
                                                            product.Description = description;
                                                            product.Price = price;
                                                            product.InStock = inStock;

                                                            Console.WriteLine("\nUpdated product\n");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("\nProduct not found\n");
                                                        }
                                                        break;

                                                    case 5:
                                                        Console.Write("\nProduct id: ");
                                                        productId = Console.ReadLine();

                                                        product = products.Find(p => p.Id.ToString().Equals(productId));

                                                        if (product != null)
                                                        {
                                                            Cart cart;
                                                            for (int i = 0; i < carts.Count; i++)
                                                            {
                                                                cart = carts[i];

                                                                cart.Products.RemoveAll(p => p.ProductId.Equals(product.Id));
                                                            }
                                                            products.Remove(product);

                                                            Console.WriteLine("\nDeleted product\n");
                                                        } else
                                                        {
                                                            Console.WriteLine("\nProduct not found\n");
                                                        }
                                                        break;

                                                    case 6:
                                                        Console.WriteLine("");
                                                        break;

                                                    default:
                                                        Console.WriteLine("\nWe don't have that option\n");
                                                        break;
                                                }
                                            }
                                            catch (FormatException ex) { Console.WriteLine(ex.Message); }
                                        } while (optionSecondMenu != 6);
                                    } else
                                    {
                                        do
                                        {
                                            try
                                            {
                                                Console.WriteLine("1 - View products\n2 - Cart\n3 - Exit");
                                                optionSecondMenu = Convert.ToInt32(Console.ReadLine());

                                                switch (optionSecondMenu)
                                                {
                                                    case 1:
                                                        Console.WriteLine("");

                                                        for (int i = 0; i < products.Count; i++)
                                                        {
                                                            product = products[i];
                                                            Console.WriteLine("Product " + i + ":\n" + product.ToString(user.IsAdmin));
                                                        }
                                                        break;

                                                    case 2:
                                                        Console.WriteLine("");

                                                        do
                                                        {
                                                            try
                                                            {
                                                                Console.WriteLine("1 - View Cart\n2 - Add product\n3 - Remove product\n4 - Checkout\n5 - Exit");
                                                                optionThirdMenu = Convert.ToInt32(Console.ReadLine());

                                                                userCart = carts.Find(c => c.UserEmail == user.Email);
                                                                int productIndex;

                                                                int optionFourthMenu = 0;

                                                                switch (optionThirdMenu)
                                                                {
                                                                    case 1:
                                                                        Console.WriteLine(userCart.ToString(products).Item1);
                                                                        break;

                                                                    case 2:
                                                                        int quantity;

                                                                        Console.Write("\nProduct index: ");
                                                                        productIndex = Convert.ToInt32(Console.ReadLine());

                                                                        Console.Write("Quantity: ");
                                                                        quantity = Convert.ToInt32(Console.ReadLine());

                                                                        if (products.Count - 1 >= productIndex && productIndex >= 0)
                                                                        {
                                                                            product = products[productIndex];

                                                                            if (product.InStock >= quantity)
                                                                            {
                                                                                var result = userCart.Products.FirstOrDefault(p => p.ProductId.Equals(product.Id));

                                                                                if (result.Equals(default(ValueTuple<Guid, int>)))
                                                                                {
                                                                                    userCart.Products.Add((product.Id, quantity));
                                                                                    Console.WriteLine("\nProduct added to cart\n");
                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.WriteLine("\nProduct is already in your cart\n");
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("\nUnavailable quantity\n");
                                                                            }
                                                                        } else
                                                                        {
                                                                            Console.WriteLine("\nProduct not found\n");
                                                                        }
                                                                        break;

                                                                    case 3:
                                                                        Console.Write("\nProduct index: ");
                                                                        productIndex = Convert.ToInt32(Console.ReadLine());

                                                                        if (userCart.Products.Count - 1 >= productIndex && productIndex >= 0)
                                                                        {
                                                                            userCart.Products.RemoveAt(productIndex);
                                                                            Console.WriteLine("\nProduct removed\n");
                                                                        } else
                                                                        {
                                                                            Console.WriteLine("\nProduct not found\n");
                                                                        }
                                                                        break;

                                                                    case 4:
                                                                        var response = userCart.ToString(products);

                                                                        if (response.Item2 > 0)
                                                                        {
                                                                            Console.WriteLine(response.Item1);
                                                                            Console.WriteLine("Total: " + response.Item2 + "\n");

                                                                            do
                                                                            {
                                                                                try
                                                                                {
                                                                                    Console.WriteLine("1 - Finalize order\n2 - Exit");
                                                                                    optionFourthMenu = Convert.ToInt32(Console.ReadLine());
                                                                                    double amount;

                                                                                    switch (optionFourthMenu)
                                                                                    {
                                                                                        case 1:
                                                                                            Console.Write("\nAmount you will pay: ");
                                                                                            amount = Convert.ToInt32(Console.ReadLine());

                                                                                            if (amount >= response.Item2)
                                                                                            {
                                                                                                Order order = new Order(user.Email, userCart.Products.ToList(), response.Item2);
                                                                                                orders.Add(order);

                                                                                                userCart.Products.Clear();

                                                                                                Console.WriteLine("\nFinished order\n");

                                                                                                optionFourthMenu = 2;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                Console.WriteLine("\nThe purchase amount is greater than entered\n");
                                                                                            }
                                                                                            break;

                                                                                        case 2:
                                                                                            Console.WriteLine("");
                                                                                            break;

                                                                                        default:
                                                                                            Console.WriteLine("\nWe don't have that option\n");
                                                                                            break;
                                                                                    }
                                                                                }
                                                                                catch (FormatException ex) { Console.WriteLine(ex.Message); }
                                                                            } while (optionFourthMenu != 2);
                                                                        } else
                                                                        {
                                                                            Console.WriteLine("\nYour shopping cart is empty\n");
                                                                        }
                                                                        break;

                                                                    case 5:
                                                                        Console.WriteLine("");
                                                                        break;

                                                                    default:
                                                                        Console.WriteLine("\nWe don't have that option\n");
                                                                        break;
                                                                }
                                                            }
                                                            catch (FormatException ex) { Console.WriteLine(ex.Message); }
                                                        } while (optionThirdMenu != 5);
                                                        break;

                                                    case 3:
                                                        Console.WriteLine("");
                                                        break;

                                                    default:
                                                        Console.WriteLine("\nWe don't have that option\n");
                                                        break;
                                                }
                                            }
                                            catch (FormatException ex) { Console.WriteLine(ex.Message); }
                                        } while (optionSecondMenu != 3);
                                    }
                                } else
                                {
                                    Console.WriteLine("\nPassword do not match\n");
                                }
                            } else
                            {
                                Console.WriteLine("\nUser not found\n");
                            }
                            break;

                        case 3:
                            break;

                        default:
                            Console.WriteLine("\nWe don't have that option\n");
                            break;
                    }
                } catch (FormatException ex) { Console.WriteLine(ex.Message); }
            } while (optionFirstMenu != 3);
        }
    }
}