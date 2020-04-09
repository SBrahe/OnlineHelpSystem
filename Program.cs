using System;

namespace OnlineHelpSystem
{
    class Program
    {
        static void Main(string[] args)
        {
          Console.WriteLine("Hello World!");
          
      using (var context = new AppDbContext())
      {
        System.Console.WriteLine("Seed database?? Y/n");
        ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
        if (consoleKeyInfo.KeyChar == 'Y')
        {
          SeedDatabase(context);
        }

        System.Console.WriteLine("Show all products Y/n");
        consoleKeyInfo = Console.ReadKey();
        if (consoleKeyInfo.KeyChar == 'Y')
        {
          ShowAllProducts(context, 'a');
        }

        System.Console.WriteLine("List all Pcs(p), Laptops(l), Printers(m)");
        consoleKeyInfo = Console.ReadKey();
        if (consoleKeyInfo.KeyChar == 'p' || consoleKeyInfo.KeyChar == 'l' || consoleKeyInfo.KeyChar == 'm')
        {
          ShowAllProducts(context, consoleKeyInfo.KeyChar);
        }

        System.Console.WriteLine("Quiting...");
      }
    }

    private static void ShowAllProducts(AppDbContext context, char c)
    {
      switch (c)
      {
        case 'a':
          ListAllPcs(context);
          ListAllLaptops(context);
          ListAllPrinters(context);
          break;

        case 'p':
          ListAllPcs(context);
          break;

        case 'l':
          ListAllLaptops(context);
          break;

        case 'm':
          ListAllPrinters(context);
          break;
      }
    }

    private static void ListAllPrinters(AppDbContext context)
    {
      foreach (var pc in context.printers.Include(p => p.Product).ToList())
      {
        System.Console.WriteLine(pc);
      }
    }

    private static void ListAllLaptops(AppDbContext context)
    {
      foreach (var pc in context.laptops.Include(p => p.Product).ToList())
      {
        System.Console.WriteLine(pc);
      }
    }

    private static void ListAllPcs(AppDbContext context)
    {
      foreach (var pc in context.pcs.Include(p => p.Product).ToList())
      {
        System.Console.WriteLine(pc);
      }
    }

    private static void SeedDatabase(AppDbContext context)
    {
      Product DellLatitude = new Product()
      {
        Maker = "Dell",
        Model = "Latitude"
      };

      Product ThinkpadT560 = new Product()
      {
        Maker = "Thinkpad",
        Model = "T560"
      };

      Product Epson = new Product()
      {
        Maker = "Epson",
      };

      context.Add(DellLatitude);
      context.Add(ThinkpadT560);
      context.Add(Epson);

      Laptop laptop1 = new Laptop()
      {
        Product = ThinkpadT560,
        Hd = 23,
        Screen = 21,
        Price = 23,
        Speed = 34,
      };

      Laptop laptop2 = new Laptop()
      {
        Product = ThinkpadT560,
        Hd = 24,
        Screen = 21,
        Price = 23,
        Speed = 34,
      };

      Laptop laptop3 = new Laptop()
      {
        Product = DellLatitude,
        Hd = 242,
        Screen = 12,
        Price = 2323,
        Speed = 341,
      };

      context.Add(laptop1);
      context.Add(laptop2);
      context.Add(laptop3);

      Printer p = new Printer()
      {
        Product = Epson,
        Color = "64",
        Price = 234
      };

      context.Add(p);

      context.SaveChanges();
      System.Console.WriteLine("Data saved");
        }
    }
}
