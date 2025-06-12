namespace CatalogService.API.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    //public Guid Id { get; private set; } = Guid.NewGuid();
    //public string Name { get; private set; }
    //public string Description { get; private set; }
    //public decimal Price { get; private set; }

    //public Product(string name, string description, decimal price)
    //{
    //    Name = name;
    //    Description = description;
    //    Price = price;
    //}

    //public void Update(string name, string description, decimal price)
    //{
    //    Name = name;
    //    Description = description;
    //    Price = price;
    //}

    //public Guid Id { get; private set; }
    //public string Name { get; private set; } = default!;
    //public decimal Price { get; private set; }

    //private Product() { }

    //public Product(Guid id, string name, decimal price)
    //{
    //    Id = id;
    //    SetName(name);
    //    SetPrice(price);
    //}

    //public void SetName(string name)
    //{
    //    if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid Name");
    //    Name = name;
    //}

    //public void SetPrice(decimal price)
    //{
    //    if (price < 0) throw new ArgumentException("Price Must Be >= 0");
    //    Price = price;
    //}
}
