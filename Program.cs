namespace ConsoleMenu
{
    class Program
    {
        static List<Merchandise> merchandiseList = new List<Merchandise>();
        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Main Menu");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1. Delivery of goods");
                Console.WriteLine("2. Sale of goods");
                Console.WriteLine("3. Availability");
                Console.WriteLine("4. Customer statistics");
                Console.WriteLine("5. General shop statistics");
                Console.WriteLine("6. Create a client");
                Console.WriteLine("8. Exit");
                Console.WriteLine();
                Console.Write("Enter your choice (1-8): ");

                string choiceStr = Console.ReadLine() ?? string.Empty;
                if (!int.TryParse(choiceStr, out choice))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        DeliveryOfGoods();
                        break;
                    case 2:
                        SaleOfGoods();
                        break;
                    case 6:
                        CreateClient();
                        break;
                }

            } while (choice != 8);
        }

        class Merchandise
        {
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public string Category { get; set; }

            public Merchandise(decimal price, int quantity, string category)
            {
                Price = price;
                Quantity = quantity;
                Category = category;
            }
        }


        static void DeliveryOfGoods()
        {
            int deliveryChoice;
            do
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Delivery of goods");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1. Add merchandise");
                Console.WriteLine("2. View merchandise list");
                Console.WriteLine("3. Back to Main Menu");
                Console.WriteLine();
                Console.Write("Enter your choice (1-3): ");
                string deliveryChoiceStr = Console.ReadLine() ?? string.Empty;
                if (!int.TryParse(deliveryChoiceStr, out deliveryChoice))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }
                switch (deliveryChoice)
                {
                    case 1:
                        AddMerchandise();
                        break;
                    case 2:
                        ViewMerchandiseList();
                        break;
                }
            } while (deliveryChoice != 3);
        }

        static void AddMerchandise()
        {
            Console.WriteLine("Enter price: ");
            string priceStr = Console.ReadLine() ?? string.Empty;
            if (!decimal.TryParse(priceStr, out decimal price))
            {
                Console.WriteLine("Invalid input. Please try again.");
                return;
            }
            Console.WriteLine("Enter quantity: ");
            string quantityStr = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(quantityStr, out int quantity))
            {
                Console.WriteLine("Invalid input. Please try again.");
                return;
            }
            Console.WriteLine("Enter category: ");
            string category = Console.ReadLine() ?? string.Empty;

            Program.merchandiseList.Add(new Merchandise(price, quantity, category));
        }

        static void ViewMerchandiseList()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Merchandise list");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Price\tQuantity\tCategory");
            foreach (var merchandise in merchandiseList)
            {
                Console.WriteLine("{0}\t{1}\t{2}", merchandise.Price, merchandise.Quantity, merchandise.Category);
            }
        }

        static void SaleOfGoods()
        {
            int saleChoice;

            do
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Sale of goods");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1. View merchandise list");
                Console.WriteLine("2. Sell merchandise");
                Console.WriteLine("3. Back to Main Menu");
                Console.WriteLine();
                Console.Write("Enter your choice (1-3): ");
                string saleChoiceStr = Console.ReadLine() ?? string.Empty;
                if (!int.TryParse(saleChoiceStr, out saleChoice))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                switch (saleChoice)
                {
                    case 2:
                        SellMerchandise();
                        break;
                }

            } while (saleChoice != 3);
        }

        static void SellMerchandise()
        {
            Console.WriteLine("Enter merchandise ID: ");
            string merchandiseIDStr = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(merchandiseIDStr, out int merchandiseID))
            {
                Console.WriteLine("Invalid input. Please try again.");
                return;
            }

            Console.WriteLine("Enter quantity: ");
            string quantityStr = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(quantityStr, out int quantity))
            {
                Console.WriteLine("Invalid input. Please try again.");
                return;
            }

            Console.WriteLine("Merchandise with ID " + merchandiseID + " sold in quantity of " + quantity);
        }

        static List<Client> clients = new List<Client>();

        static void CreateClient()
        {
            Console.WriteLine("Enter client name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter client number: ");
            string numberStr = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(numberStr, out int number))
            {
                Console.WriteLine("Invalid input. Please try again.");
                return;
            }

            Client newClient = new Client { Name = name, Number = number };
            clients.Add(newClient);

            Console.WriteLine("Client with name " + name + " and number " + number + " has been created and added to the collection.");
        }

        public class Client
        {
            public string? Name { get; set; }
            public int Number { get; set; }
        }
    }
}