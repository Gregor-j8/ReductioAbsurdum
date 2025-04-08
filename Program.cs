// See https://aka.ms/new-console-template for more information

void menu()
{
    Console.WriteLine(@"
    Please enter number to choose option

    1. view all products
    2. view products for category 
    3. add product to inventory
    4. delete product from inventory 
    5. update product details
    ");
    int response = int.Parse(Console.ReadLine().Trim());
    if (response > 5 | response < 1) {
        Console.WriteLine(@"Please enter value in the menu");
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
        Console.WriteLine($"These are all the types");
        foreach (ProductType types in Database.productTypes)
        {  
            Console.WriteLine($"{types.Id}. {types.Name}");
        }
            int choosenType = int.Parse(Console.ReadLine().Trim());
            if (choosenType > 1 || choosenType < 4) 
            {
                List<Product> ChosenTypes = Database.products.Where(type => type.TypeId == choosenType).ToList();
                    foreach (Product type in ChosenTypes)
                    {  
                         Console.WriteLine($"{type.Id}. {type.Name}");
                    }
            }
    }
}

menu();