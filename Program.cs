// See https://aka.ms/new-console-template for more information

void menu()
{
    Console.WriteLine(@"
    1. view all products
    2. view products for category 
    3. add product to inventory
    4. delete product from inventory 
    5. update product details
    ");
}

void HandleChoice(int choice)
{
    if (choice == 1)
    {

        foreach (Product product in Database.products)
        {
            Console.WriteLine($"{product.Id}. {product.Name}");
        }
    }
}
