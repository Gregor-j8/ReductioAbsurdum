// See https://aka.ms/new-console-template for more information

void menu()
{
    Console.WriteLine(@"
    *** Welcome to Reductio Absurdum ***

    Please enter a number to choose an option

    1. view all products
    2. view products for category 
    3. add product to inventory
    4. delete product from inventory 
    5. update product details
    ");
    int response = int.Parse(Console.ReadLine().Trim());
    if (response > 5 | response < 1) {
        Console.WriteLine(@"Please enter a valid menu option");
    } else {
        HandleChoice(response);
    }
}

void HandleChoice(int choice)
{
    if (choice == 1)
    {
        Console.WriteLine($"These are all of the products");
        foreach (Product product in Database.products)
        {
            Console.WriteLine($"{product.Id}. {product.Name}");
        }
    }
    else if (choice == 2)
    { 
        Console.WriteLine("These are all the types");
        foreach (ProductType types in Database.productTypes)
        {  
            Console.WriteLine($"{types.Id}. {types.Name}");
        }
            int chosenType = int.Parse(Console.ReadLine().Trim());
            if (chosenType > 1 || chosenType < 4) 
            {
                List<Product> ChosenTypes = Database.products.Where(type => type.TypeId == chosenType).ToList();
                    foreach (Product type in ChosenTypes)
                    {  
                         Console.WriteLine($"{type.Id}. {type.Name}");
                    }
            }
    }
    else if (choice == 3) {
        Console.WriteLine(@"
        **Adding a product**

        What is your product name?
        ");

        string name = Console.ReadLine();

        Console.WriteLine($"What is the price of your {name}?");

        decimal price = decimal.Parse(Console.ReadLine().Trim());

        Console.WriteLine($@"What is the type of your {name}?

        These are all the types
        ");

        foreach (ProductType types in Database.productTypes)
        {  
            Console.WriteLine($"{types.Id}. {types.Name}");
        }

        Console.WriteLine($"Please enter the number of the type of your {name}");

        int typeId = int.Parse(Console.ReadLine().Trim());

        Product newProduct = new Product(name)
    {
        Price = price,
        IsAvailable = true,
        TypeId = typeId,
        DaysOnShelf = DateTime.Now
    };
    Database.products.Add(newProduct);

    Console.WriteLine($"Product '{newProduct.Name}' added successfully!");

    }
    else if (choice == 4) {
        Console.WriteLine(@"***Delete An product***
        
        Please enter the Name of the product you want to delete");

         Console.WriteLine($"These are all of the products");
        foreach (Product product in Database.products)
        {
            Console.WriteLine($"{product.Name}");
        }

        string itemToDelete = Console.ReadLine().Trim();

        Product productToRemove = Database.products.FirstOrDefault(product => product.Name == itemToDelete);
        Console.WriteLine(productToRemove.Name);

        if (productToRemove != null) {
            Database.products.Remove(productToRemove);
            Console.WriteLine("Product Removed");
        }
        else {
            Console.WriteLine("Product not found");
        }
    }
}

int on = 1;

while(on > 0) {
menu();

Console.WriteLine(@"
0. exit
1. return to menu
");

on = int.Parse(Console.ReadLine().Trim());

}