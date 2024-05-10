using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedContracts;
public class ProductsDatabase
{
    public static List<Product> Products = new List<Product>
    {
        new Product(1, "MacBook Pro", 2999.99M, 5),
        new Product(2, "Harry Potter and The Order of The Phoenix", 19.99M, 3),
        new Product(3, "Leather Jacket", 699.99M, 1),
    };  
}
