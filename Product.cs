public class Product {
    private static int nextId = 1;
    public int Id {get; private set; }
    public string Name {get; set; }
    public decimal Price {get; set; }
    public Boolean IsAvailable {get; set; }
    public int TypeId {get; set; }
    public DateTime DaysOnShelf {get; set; }
    public Product (string ProductName) 
    {
        Id = nextId;
        nextId++;
        Name = ProductName;
    }
}

public class ProductType {
    public int Id {get; set;}
    public string Name {get; set;}
}