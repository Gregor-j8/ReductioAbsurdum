public class Database
{
    public static List<Product> products = new List<Product>() {

    new Product("Laptop")
    {
        Price = 999.99m,
        IsAvailable = true,
        TypeId = 2,
        DaysOnShelf = new DateTime(2022, 10, 1)
    },
    new Product("Smartphone")
    {
        Price = 699.50m,
        IsAvailable = true,
        TypeId = 1,
        DaysOnShelf = new DateTime(2023, 3, 15)
    },

    new Product("Headphones")
    {
        Price = 149.99m,
        IsAvailable = false,
        TypeId = 3,
        DaysOnShelf = new DateTime(2023, 8, 5)
    },

    new Product("Monitor")
    {
        Price = 279.00m,
        IsAvailable = true,
        TypeId = 4,
        DaysOnShelf = new DateTime(2023, 11, 20)
    },

    new Product("Keyboard")
    {
        Price = 89.99m,
        IsAvailable = false,
        TypeId = 5,
        DaysOnShelf = new DateTime(2024, 1, 10)
    },

    };

}

