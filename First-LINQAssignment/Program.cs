using System;
using System.Linq;
using LINQ.DataSources;

class Program
{
    static void Main()
    {
        // Q01
        var res = Source.ProductList.Where(p => p.Category == "Seafood")
            .Select(p => new { p.ProductName, p.UnitPrice });
        foreach (var item in res)
        {
            Console.WriteLine(item);
        }
        //Q02
        var res2 = Source.ProductList.Select(p => p.ProductName);
        foreach (var item in res2)
        {
            Console.WriteLine(item);
        }
        //Q03
        var res3 = Source.ProductList.OrderBy(p => p.UnitPrice)
                           .Select(p => new { p.ProductName, p.UnitPrice });
        foreach (var item in res3)
        {
            Console.WriteLine(item);
        }
        //Q04
        var res4 = Source.ProductList.Where((p) => p.UnitPrice >= 10 && p.UnitPrice <= 30)
                                       .Select(p => new { p.ProductName, p.UnitPrice });
        foreach (var item in res4)
        {
            Console.WriteLine(item);
        }


        //Q05
        var res5 = Source.ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Spices & Condiments")// fe el assignment Conditions bs fe Profucts heya Spices & Condiments
                .Select(p => new { p.ProductName, p.UnitsInStock });
        foreach (var item in res5)
        {
            Console.WriteLine(item);
        }

        //Q06
        var res6 = Source.ProductList.Select(p => new
        {
            Name = p.ProductName,
            Price = p.UnitPrice,
            StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
        });
        foreach (var item in res6)
        {
            Console.WriteLine(item);
        }
        //Q07
        var res7 = Source.ProductList.Select((p, index) => new
        {
            Position = index + 1,
            p.ProductName
        });
        foreach (var p in res7)
            Console.WriteLine($"{p.Position}. {p.ProductName}");

        //Q08 
        var res8 = Source.ProductList.OrderBy(p => p.Category)
            .ThenByDescending(p => p.UnitPrice);
        foreach (var p in res8)
            Console.WriteLine($"{p.Category} - {p.ProductName} - {p.UnitPrice}");
        //Q09
        var res9 = Source.ProductList.Where(p => p.Category == "Beverages")
            .OrderByDescending(p => p.UnitsInStock);
        foreach (var p in res9)
            Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");

        //Q10
        var res10 = from customer in Source.CustomerList
                    from order in customer.Orders
                    where order.OrderDate >= new DateTime(1997, 1, 1)
                    select new
                    {
                        customer.CustomerID,
                        order.OrderDate
                    };
        foreach (var order in res10)
            Console.WriteLine($"{order.CustomerID} - {order.OrderDate:d}");

        //Q11 
        var res11 = Source.ProductList.Select((p, i) => new {
            index = i,
            p.ProductName
        });
        foreach (var p in res11)
            Console.WriteLine($"{p.index + 1}. {p.ProductName}");

        //Q12
        String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

        var res12 = Arr.OrderBy(p => p.Length)
            .ThenBy(p => p, StringComparer.OrdinalIgnoreCase);
        foreach (var p in res12)
        {
            Console.WriteLine(p);
        }
        //Q13
        var res13 = Arr.Where(s => s.Length > 1 && char.ToLower(s[1]) == 'i')
            .Reverse();
        foreach (var item in res13)
        {
            Console.WriteLine(item);
        }

    }
}