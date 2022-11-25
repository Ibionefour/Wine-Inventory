using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineInventory
{
    class Wine
    {
        static void Main(string[] args)
        {
            new WineProgram();

        }
    }
}
class WineProgram
{

    public static List<Wine> wines; 
    static bool chk = false;
    public WineProgram()
    {

        wines = new List<Wine>();
        Console.Clear();
        MenuList(); 
        Console.WriteLine("\nPlease Select a option from menu list!");
        string input;

      
        while (true)
        {
            input = TakeInput();

            switch (input)
            {
                case "1":
                    LoadWineData();
                    break;

                case "2":
                    AddWine(); 
                    break;

                case "3":
                    ShowWine(); 
                    break;

                case "4":
                    SearchWine(); 
                    break;

                case "5":
                    WriteDataToTextFile(); 
                    break;

                case "0":
                    Environment.Exit(0); 
                    break;


            }
            Console.WriteLine("\n");
            MenuList(); // displaying menu again 
            Console.WriteLine("\n Select other option from Menu list");
        }

    }

    private void AddWine()
    {
        Console.Clear();
        Console.Write("\nEnter Wine Id: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("\nEnter Wine Name: ");
        string name = Console.ReadLine();
        Console.Write("\nEnter Wine Stock: ");
        int stock = int.Parse(Console.ReadLine());
        Console.Write("\nEnter Wine Price: ");
        double price = double.Parse(Console.ReadLine());
        wines.Add(new Wine(id, name, stock, price));
        Console.Clear();
        Console.WriteLine("Wine Added Successfully");
    }

    public static string TakeInput()
    {
        string input = Console.ReadLine(); 
        return input; 
    }
    private static void MenuList()
    {
         
        Console.WriteLine("WELCOME TO IBBIE'S WINE INVENTORY");
        Console.WriteLine("1. Load Data ");
        Console.WriteLine("2. Add Wine");
        Console.WriteLine("3. Sort and display the wine records");
        Console.WriteLine("4. Search for a Wine");
        Console.WriteLine("5. Save Info into text file");
        Console.WriteLine("0. Exit");


    }

    public static void LoadWineData()
    { 

        string fileName = @"wine_record.text"; // load wine Record From Text File
        if (File.Exists(fileName)) 
        {
            string[] lines = File.ReadAllLines(fileName); // reading all line and storing them in array of string
            int totalWines = lines.Length; // counting total wines in the list 
            foreach (var line in lines) // looping through each line assigning the data to wine list 
            {
                string[] wi = line.Split(','); // spilting the column on space if in your data there is tab seperater you can use it
                wines.Add(new Wine(int.Parse(wi[0]), wi[1], int.Parse(wi[2].ToString()), double.Parse(wi[3]))); // adding wine to the list
            }
            chk = true;
        }
        else
        {
            Console.WriteLine("File Does Not Exist.");
        }

    }
    public static void ShowWine()
    {
        
        wines = wines.OrderBy(e => e.WineId).ToList();
        Console.WriteLine("Wine List");
        Console.WriteLine("\n");
        Console.WriteLine(" Wine ID\t Wine Name\t Stock Available\t Price\t ");
        foreach (Wine w in wines)
        {
           Console.WriteLine(w.toString());
        }
        Console.WriteLine("\n");
    }


     
    public static void SearchWine()
    {
        Console.Write("\nPlease enter the id of Wine : ");
        int key=(int.Parse(Console.ReadLine()));
        int loop=0;
        for (loop = 0; loop < wines.Count; loop++)
        {
            if (wines[loop].WineId == key)
            {
                break;
            }
        }
        Console.Clear();
        if (loop<wines.Count)
        {
            Console.WriteLine(" Wine ID\t Wine Name\t Available Stock\t Price\t ");
            Console.WriteLine(wines[loop].toString());

        }
        else
            Console.WriteLine("Wine Does not Exists!");
    }

   
    
    public static void WriteDataToTextFile()
    {

        string OutputfileName = @"wine_records.txt"; 
        if (chk)
        {
            File.WriteAllText(OutputfileName, "");
        }
        foreach (Wine w in wines)
        {
            File.AppendAllText(OutputfileName,w.WineId+","+w.WineName+","+w.Stock+","+w.Price+ "\n");
        }
        Console.Clear();
        Console.WriteLine("All Data is Saved Successfully in wine_records.txt Thank you!");
    }


    public class Wine 
    {

        public int WineId; 
        public string WineName;
        public int Stock;
        public double Price;


        public Wine(int id, string name, int stock, double price)
        {
            this.WineId = id;
            this.WineName = name;
            this.Stock = stock;
            this.Price = price;
        }

        public string toString() 
        {
            return String.Format(" {0,-11}\t {1,-19}\t {2,-11}\t {3,-13} ", WineId, WineName, Stock, Price);
        }

        public string print()
        {
            return

                "Wine Details" + "\n" +
                "Wine ID : " + this.WineId + "\n" +
                "Wine Name : " + this.WineName + "\n" +
                "Stock Available : " + this.Stock + "\n" +
                "Price : " + this.Price + "\n";
        }
    }
}