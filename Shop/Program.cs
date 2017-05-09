using System;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram=true;//Controling the Main loop
            while(runProgram)
            {
                Console.Clear();
               
                Console.WriteLine("Welcome to the Magic Store\nPlease navigate in the menu by using numbers");

                Console.WriteLine("(1)Enter the shop\n(0)Exit");
                //Main Menu
                switch(Console.ReadLine())
                {
                    case "1"://Entering the Shop
                        
                        bool questioning = true;
                        string answer = "-1";
                        while(questioning)
                        {
                            Console.Clear();
                            Console.WriteLine("Dangers ahead!!!\nAre you really sure that you want to enter the shop?(y/n)");

                            answer = Console.ReadLine().ToLower();
                            switch(answer)
                            {
                                case "y":
                                    questioning = false;
                                    break;
                                case "n":
                                    questioning = false;
                                    break;
                                default:
                                    Console.WriteLine("Error Message: input isn't 'y' or 'n'\nPlease enter a key to continue");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        if (answer == "y")//Enter the shop
                        {
                            bool inShop = true;
                            while (inShop)
                            {
                                Console.Clear();
                                Console.WriteLine("(1)Shopping cart\n(2)Search\n(0)Exit");
                                switch(Console.ReadLine())
                                {
                                    case "1":
                                        break;
                                    case "2":
                                        break;
                                    case "0":
                                        inShop = false;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You will return back to main menu!");
                            Console.ReadKey();
                        }
                        break;
                    case "0": //Exit the program
                        runProgram = false;
                        break;
                }
                
            }
        }
        static void WriteToConsole(string inputString)//Skriver ut en sträng
        {
            Console.WriteLine(inputString);
        }
        static void ClearTheConsoleWindow()//Rensar fönstret
        {
            Console.Clear();
        }
    }
}
