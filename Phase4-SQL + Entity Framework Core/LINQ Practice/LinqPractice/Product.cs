//Step 1: Setup Sample Data 
var products = GetSampleProducts();

static List<Product> GetSampleProducts()
{
    return new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m, Stock = 5, Category = "Electronics" },
        new Product { Id = 2, Name = "Smartphone", Price = 699.99m, Stock = 10, Category = "Electronics" },
        new Product { Id = 3, Name = "Desk Chair", Price = 89.99m, Stock = 15, Category = "Furniture" },
        new Product { Id = 4, Name = "Book: C# Programming", Price = 39.99m, Stock = 20, Category = "Books" },
        new Product { Id = 5, Name = "Wireless Mouse", Price = 29.99m, Stock = 25, Category = "Electronics" },
        new Product { Id = 6, Name = "Office Desk", Price = 199.99m, Stock = 8, Category = "Furniture" },
        new Product { Id = 7, Name = "Headphones", Price = 149.99m, Stock = 12, Category = "Electronics" },
        new Product { Id = 8, Name = "Coffee Maker", Price = 79.99m, Stock = 7, Category = "Appliances" },
        new Product { Id = 9, Name = "Notebook", Price = 4.99m, Stock = 50, Category = "Stationery" },
        new Product { Id = 10, Name = "Pen Set", Price = 9.99m, Stock = 40, Category = "Stationery" }
    };
}

//Step 2:  Filtering with .Where()

Console.WriteLine("PRODUCTS WITH PRICES MORE THAN 50............");
Console.WriteLine(System.Environment.NewLine);

var result = products.Where(p => p.Price > 50).ToList();
foreach (var r in result)
{
    Console.WriteLine($"Produts: {r.Name} and Price: {r.Price}");
}
Console.WriteLine("==================================================================");

Console.WriteLine("ELECTRONICS PRODUCTS............");
Console.WriteLine(System.Environment.NewLine);

var result1 = products.Where(p => p.Category == "Electronics").ToList();
foreach (var r in result1)
{
    Console.WriteLine($"Produts: {r.Name}");
}
Console.WriteLine("==================================================================");

Console.WriteLine(" OUT OF STOCK PRODUCTS............");
Console.WriteLine(System.Environment.NewLine);

var result2 = products.Where(p => p.Stock == 0).ToList();
if (result2.Any())
{
    foreach (var r in result2)
    {
        Console.WriteLine($"Produts: {r.Name}");
    }
}
else
{
    Console.WriteLine("No item out of stock");
}
Console.WriteLine("==================================================================");

Console.WriteLine("PRODUCTS WITH PRICES LESS THAN 20 AND STOCK MORE THAN 50............");
Console.WriteLine(System.Environment.NewLine);

var result3 = products.Where(p => p.Price < 20 && p.Stock > 10).ToList();
if (result2.Any())
{
    foreach (var r in result3)
    {
        Console.WriteLine($"Product available: {r.Name}");
    }
}
else
{
    Console.WriteLine("No such item in stock");
}

//Step 3: Sorting with .OrderBy()

Console.WriteLine(System.Environment.NewLine);
Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=");
Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=");
Console.WriteLine(System.Environment.NewLine);

Console.WriteLine();
Console.WriteLine("PRODUCTS BY PRICE (ascending)");
Console.WriteLine(System.Environment.NewLine);

var order = products.OrderBy(p => p.Price).ToList();
foreach (var o in order)
{
    Console.WriteLine($"Products: {o.Name} and Price: {o.Price}");
}

Console.WriteLine(System.Environment.NewLine);
Console.WriteLine("==================================================================");
Console.WriteLine(System.Environment.NewLine);

Console.WriteLine("PRODUCTS BY PRICE (descending)");
Console.WriteLine(System.Environment.NewLine);

var order1 = products.OrderByDescending(p => p.Price).ToList();
foreach (var o in order1)
{
    Console.WriteLine($"Products: {o.Name} and Price: {o.Price}");
}

Console.WriteLine(System.Environment.NewLine);
Console.WriteLine("==================================================================");
Console.WriteLine(System.Environment.NewLine);

Console.WriteLine("SORT BY CATEGORY & PRICE");
Console.WriteLine(System.Environment.NewLine);

var sort = products.OrderBy(p => p.Category).ThenBy(p => p.Price).ToList();
string currentCategory = null;

foreach (var s in sort)
{
    // Print category only if it's different from the previous one
    if (s.Category != currentCategory)
    {
        if (currentCategory != null)
        {
            Console.WriteLine();
        }
        currentCategory = s.Category;
        Console.WriteLine($"Category: {currentCategory}");
    }

    // Print product details
    Console.WriteLine($"Product: {s.Name} - Price: {s.Price}");
}

Console.WriteLine(System.Environment.NewLine);
Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=");
Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=");
Console.WriteLine(System.Environment.NewLine);

//Step 4: Aggregation

var inventory = products.Sum(p => p.Price * p.Stock);
Console.WriteLine($"Total inventory value: {inventory}");

Console.WriteLine(System.Environment.NewLine);

var avg = products.Average(p => p.Price);
Console.WriteLine($"Average price of all products: {avg}");

Console.WriteLine(System.Environment.NewLine);

var maxexpense = products.Max(p => p.Price);
Console.WriteLine($"Most expensive product price: {maxexpense}");

Console.WriteLine(System.Environment.NewLine);

var inStock = products.Count(p => p.Stock > 0);
Console.WriteLine($"Total products in stock: {inStock}");

Console.WriteLine(System.Environment.NewLine);

var pro = products.Count(p => p.Price > 100);
Console.WriteLine($"Number of products more expensive than 100: {pro}");

Console.WriteLine(System.Environment.NewLine);
Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=");
Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=");
Console.WriteLine(System.Environment.NewLine);

//Step 5: Grouping

var grouped = products.GroupBy(p => p.Category);
decimal highestAvg = 0;
string highestCategory = "";

foreach (var g in grouped)
{
    Console.WriteLine($"Category: {g.Key}");
    Console.WriteLine($"Count: {g.Count()}");
    Console.WriteLine($"Total inventory value: {g.Sum(p => p.Price * p.Stock)}");
    Console.WriteLine($"Average: {g.Average(p => p.Price)}");
    var currentAvg = g.Average(p => p.Price);

    if (currentAvg > highestAvg)
    {
        highestAvg = currentAvg;
        highestCategory = g.Key;
    }
    Console.WriteLine();
}
Console.WriteLine("==================================================================");
Console.WriteLine($"Highest Average Price Category: {highestCategory}");
Console.WriteLine($"Highest Avg Price: {highestAvg}");

Console.WriteLine(System.Environment.NewLine);
Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=");
Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=");
Console.WriteLine(System.Environment.NewLine);

//Step: Projection with .Select(); 

var names = products.Select(p => p.Name).ToList();
foreach (var name in names)
{
    Console.WriteLine(name);
}

Console.WriteLine();
Console.WriteLine("==================================================================");
Console.WriteLine();

var tax = products.Select(p => new
{
    p.Name,
    PriceWithTax = p.Price * 1.15m
});
foreach (var item in tax)
{
    Console.WriteLine($"{item.Name} -> Price with Tax: {item.PriceWithTax}");
}

Console.WriteLine();
Console.WriteLine("==================================================================");
Console.WriteLine();

var check = products.Select(p => new
{
    p.Name,
    p.Category,
    isExpensive = p.Price > 100
});

foreach (var ch in check)
{
    Console.WriteLine($"{ch.Name}, {ch.Category}, Expensive: {ch.isExpensive}");
}

Console.WriteLine(System.Environment.NewLine);
Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=");
Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=");
Console.WriteLine(System.Environment.NewLine);

//Step 7: Chaining

var chaining = products.Where(p => p.Stock > 0).OrderBy(p => p.Category).ThenByDescending(p => p.Price).GroupBy(p => p.Category).Select(g => new { Category = g.Key, Names = g.Select(p => p.Name).ToList() });

foreach (var group in chaining)
{
    Console.WriteLine($"Category: {group.Category}");
    foreach (var name in group.Names)
    {
        Console.WriteLine($"{name}");
    }
    Console.WriteLine();
}

Console.WriteLine(System.Environment.NewLine);
Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=");
Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=");
Console.WriteLine(System.Environment.NewLine);

//Step 8: Final Challenge

// 1️. Total products
int totalProducts = products.Count();
Console.WriteLine($"Total products: {totalProducts}");

//2. Total inventory value
var totalInventoryValue = products.Sum(p => p.Price * p.Stock);
Console.WriteLine($"Total inventory value: {totalInventoryValue}");

//3. Category breakdown
var catBeakdown = products.GroupBy(p => p.Category).Select(g => new { Category = g.Key, Count = g.Count(), avgP = g.Average(p => p.Price) }).ToList();
catBeakdown.ForEach(c =>
{
    Console.WriteLine($"Category: {c.Category}");
    Console.WriteLine($"  Count: {c.Count}");
    Console.WriteLine($"  Average Price: {c.avgP}");
    Console.WriteLine();  
});

//4. Top 3 most expensive products
var top3Expensive = products.OrderByDescending(p => p.Price).Take(3).Select(p => new { p.Name, p.Price }).ToList();
Console.WriteLine("\nTop 3 Most Expensive Products:");
top3Expensive.ForEach(c =>
{
    Console.WriteLine($"{c.Name} -> {c.Price}");
});

//5. Restock
var restock = products.Where(p => p.Stock < 5).Select(p => new { p.Name, p.Stock }).ToList();
Console.WriteLine("\nProducts that need restocking:");
if (restock.Any())   
{
    restock.ForEach(p =>
    {
        Console.WriteLine($"  {p.Name} -> Stock: {p.Stock}");
    });
}
else
{
    Console.WriteLine("None! All products have sufficient stock.");
}