﻿// See https://aka.ms/new-console-template for more information

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
    try {
        int response = int.Parse(Console.ReadLine().Trim());
        if (response > 5 | response < 1) {
            Console.WriteLine(@"Please enter a valid menu option");
        } else {
            HandleChoice(response);
        }
    } catch (FormatException) {
        Console.WriteLine("Invalid input. Please enter a number.");
    } catch (Exception ex) {
        Console.WriteLine($"An error occurred: {ex.Message}");
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
            try {
                int chosenType = int.Parse(Console.ReadLine().Trim());
                if (chosenType > 1 || chosenType < 4)
                {
                    List<Product> ChosenTypes = Database.products.Where(type => type.TypeId == chosenType).ToList();
                    foreach (Product type in ChosenTypes)
                    {
                        Console.WriteLine($"{type.Id}. {type.Name}");
                    }
                } else {
                    Console.WriteLine($"Invalid input");
                }
            } catch (FormatException) {
                Console.WriteLine("Invalid input. Please enter a number for the type.");
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
    }
    else if (choice == 3) {
        Console.WriteLine(@"
        **Adding a product**

        What is your product name?
        ");

        string name = Console.ReadLine();

        Console.WriteLine($"What is the price of your {name}?");

        decimal price = 0; 
        try {
            price = decimal.Parse(Console.ReadLine().Trim());
        } catch (FormatException) {
            Console.WriteLine("Invalid price format. Please enter a valid number.");
        } catch (Exception ex) {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        Console.WriteLine($@"What is the type of your {name}?

        These are all the types
        ");

        foreach (ProductType types in Database.productTypes)
        {  
            Console.WriteLine($"{types.Id}. {types.Name}");
        }

        Console.WriteLine($"Please enter the number of the type of your {name}");

        int typeId = 0; 
        try {
            typeId = int.Parse(Console.ReadLine().Trim());
        } catch (FormatException) {
            Console.WriteLine("Invalid input. Please enter a number for the type.");
        } catch (Exception ex) {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
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

        Product productToRemove = null;
        try {
            productToRemove = Database.products.FirstOrDefault(product => product.Name == itemToDelete);
            if (productToRemove != null) {
                Console.WriteLine(productToRemove.Name);
            }
        } catch (Exception ex) {
            Console.WriteLine($"An error occurred while finding the product: {ex.Message}");
        }

        if (productToRemove != null) {
            Database.products.Remove(productToRemove);
            Console.WriteLine("Product Removed");
        }
        else {
            Console.WriteLine("Product not found");
        }
    }
    else if (choice == 5) {
        Console.WriteLine(@"***Update a product***
        
        Please enter the Name of the product you want to update");

         Console.WriteLine($"These are all of the products");
        foreach (Product product in Database.products)
        {
            Console.WriteLine($"{product.Name}");
        }

        string itemToUpdate = Console.ReadLine().Trim();

        Product productToUpdate = null;
        try {
            productToUpdate = Database.products.FirstOrDefault(product => product.Name == itemToUpdate);
            if (productToUpdate != null) { 
                Console.WriteLine(productToUpdate.Name);
            }
        } catch (Exception ex) {
            Console.WriteLine($"An error occurred while finding the product: {ex.Message}");
        }

        if (productToUpdate != null) {
            Console.WriteLine("");
            Console.WriteLine(@"Update product name");
            productToUpdate.Name = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine(@"Update product price");
            try {
                productToUpdate.Price = decimal.Parse(Console.ReadLine()); 
            } catch (FormatException) {
                Console.WriteLine("Invalid price format. Price not updated.");
            } catch (NullReferenceException) {
                Console.WriteLine("Error: Product reference was null unexpectedly.");
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred updating price: {ex.Message}");
            }
            Console.WriteLine("Product update");
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

    try {
        on = int.Parse(Console.ReadLine().Trim());
    } catch (FormatException) {
        Console.WriteLine("Invalid input. Please enter 0 or 1.");
        on = 1; // Default to returning to menu on invalid input
    } catch (Exception ex) {
        Console.WriteLine($"An error occurred: {ex.Message}");
        on = 1; // Default to returning to menu on other errors
    }

}