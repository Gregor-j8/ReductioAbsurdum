public class Product {
    private static int nextId = 1;
    public int Id {get; private set; }
    string Name {get; set; }
    public decimal Price {get; set; }
    public Boolean IsAvailable {get; set; }
    public int TypeId {get; set; }
    public int DaysOnShelf {get; set; }
    Product (string ProductName) 
    {
        Id = nextId;
        nextId++;
        Name = ProductName;
    }
}

public class ProductType {
    public string Id {get; set;}
    public string Name {get; set;}
}