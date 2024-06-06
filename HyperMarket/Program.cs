using HyperMarket.Entities;
using HyperMarket.Management;
using SuperMarketEntities.Entities;
using System.Diagnostics;
namespace HyperMarket;

internal class Program
{
 
    public static void Main(string[] args)
    {
        //Polymorphism
        // 1. If similar objects (physiscally) with possibly different implementation of the same behevior - abstract classes
        // 2. If object can have diiferent physiscal structure but the similar behaviour with different implementation -  interfaces 
        // 3. What to do if absolutely different items has absolutely same behavoiur? (generics "static polymorphism")

        // 1. Be more carefully with the task formulation
        // 2. Please test your application yourself more carefully in boundary conditions
        // 3. Unit tests
        // 4. Be more carefull with float and double comparison for equality
        // (sqty(2)-1.534567893) < Double.Epsilon
        // 5. Pay more attension to interfaces 

        // main code 
        // Exception
        // IEnumerable -> let us to iterate via collection (object)
        // Events

        // We need to organize the 24/7 support of orders (requests)

        // Pattern Command
        // 1. Need to perform some activity as a result of other activity (like delegate)
        // 2. Create queue of activity (with possible undo)
        // 3. Log activity and control changes

        // Join receiver (object wich will perform activity) with activity


        // One application start- one process -> do nothing, manage memory, not more -> box to wrap threads
        // -> operation system bit number 64-bit -> adress 2 in rank 64 bits-> logical addresses (RAM)

        //logical address is set to variable
        //1. int[] array = new int[100000000];-> 0xA1234DCF -> physical > ask operation system -> unit 4 cell start from 1024 up to 
        //2. int[] array1 = new int[100000000];-> 0xA1234DCF -> physical > ask operation system -> unit 3 cell start from 20045 up to 

        // 0xA1234DCF -> ask OS -> map logical address to phisical addres
        // THread entity to execute code instructions one process-one (main) thread
        // one CPU with one kernel
        // 2 single thread applications + 1 two-threads application, 4 threads  do some activity ->simulate switch between threads -> ASBOLUTE DEMOCRACY 1/4 part of CPU time

        // one CPU- 8 kernels -> 8 threads-> 

        // Main idea of multithreading is that different operations consume different recources and different CPU time
        // copy file -> time consuming -> CPU consuming thery low -> HDD adapter (physics ) very high()
        ManagementCompany managementCompany = new();

        HyperMarketItem carefour = managementCompany.CreateHyperMarket("Carefure", "Small");
        HyperMarketItem carefourBig = managementCompany.CreateHyperMarket("CarefureBig1", "Big");
        
        ProductDescription milkDescription1 = new()
        {
            Details = new() {
              { new DescriptionEntity("Еat content", "1.5%") },
              {new DescriptionEntity("Producer", "Milk company") },
              {new DescriptionEntity("Expirity date", "05-11-2024") },
            }
        };

        ProductDescription milkDescription2 = new()
        {
            Details = new() {
              { new DescriptionEntity("Еat content", "15%") },
              {new DescriptionEntity("Producer", "Milk company") },
              {new DescriptionEntity("Expirity date", "05-11-2024") },
            }
        };

        carefour.AddProduct(new Product("Milk", "Food", 0.9f, milkDescription1)); 
        carefour.AddProduct(new Product("Milk", "Food", 0.9f, milkDescription2));

        carefourBig.AddProduct(new Product("Milk", "Food", 0.9f, milkDescription1));
        carefourBig.AddProduct(new Product("Milk", "Food", 0.9f, milkDescription2));

        Buyer buyer1 = new Buyer("Mike", 16);
        Buyer buyer2 = new Buyer("Nike", 19);
        Buyer buyer3 = new Buyer("Addidas", 20);

        //Night (24/7 service)

        carefour.SetPreOrder(buyer1, "Want to Barber");
        carefour.SetPreOrder(buyer2, "Repair  IPhone");
        carefour.SetPreOrder(buyer3, "Want to Barber");

        Stopwatch watch = new Stopwatch();
        watch.Start();
        var results = carefour.DoPreorders();
        watch.Stop();
        var elapsedTime = watch.ElapsedMilliseconds;
        
    }
}
