//https://github.com/kimt74/assign.git
using System;

namespace Lab1
{
    class Program
    {
        static Database database;
        static void Main( string[] args )
        {
            database = new Database();

            database.Load( "database.db" );

            int menu;
            // loop until choose exit menu
            while((menu = Menu()) != 5)
            {
                switch(menu)
                {
                    case 1:
                        Create();
                        break;

                    case 2:
                        Update();
                        break;

                    case 3:
                        Delete();
                        break;

                    case 4:
                        List();
                        break;
                }
            }

            // save info to file
            database.Save( "database.db" );
        }

        static void Create()
        {
            Console.WriteLine( "\n===Create Menu===" );

            string identifier;
            while (true)
            {
                Console.Write( "Identifier : " );
                identifier = Console.ReadLine();
                //it should be 6 length with first 3 is letter and last 3 is number 
                if(identifier.Length != 6 || !char.IsLetter(identifier[0])
                                          || !char.IsLetter(identifier[1])
                                          || !char.IsLetter(identifier[2])
                                          || !char.IsDigit(identifier[3])
                                          || !char.IsDigit(identifier[4])
                                          || !char.IsDigit(identifier[5]))
                {
                    Console.WriteLine( "Error! Identifier must be 3 letters about airline code + 3 digits." );
                    continue;
                }
                
                if(database.IndexOf(identifier.ToUpper()) != -1)
                {
                    Console.WriteLine( "Error! This identifier is already used." );
                    continue;
                }

                break;
            }

            string origin;
            while(true)
            {
                Console.Write( "Origin : " );
                origin = Console.ReadLine();
                if (origin.Length != 4)
                {
                    Console.WriteLine( "Error! Origin must be 4 letters." );
                    continue;
                }
                break;
            }

            string destination;
            while (true)
            {
                Console.Write( "Destination : " );
                destination = Console.ReadLine();
                if (destination.Length != 4)
                {
                    Console.WriteLine( "Error! Destination must be 4 letters." );
                    continue;
                }
                break;
            }

            int passangers;
            while (true)
            {
                Console.Write( "Passangers : " );
                if (!int.TryParse( Console.ReadLine(), out passangers ))
                {
                    Console.WriteLine( "Error! Passangers must be integer." );
                    continue;
                }
                break;
            }

            // add to db
            database.Add( new Data( origin, destination, identifier.ToUpper(), passangers ) );
            // db sort
            database.Sort();
            Console.WriteLine( $"{identifier.ToUpper()} flight added to Database!" );
            Console.WriteLine( "Press any key to continue..." );
            Console.ReadKey( true );
            Console.Clear();
        }
        static void Update()
        {
            Console.Clear();
            Console.WriteLine( "\n===Update Menu===" );
            Console.Write( "Enter the identifier : " );
            string identifier = Console.ReadLine();
            // search from db
            var index = database.IndexOf( identifier.ToUpper() );
            if (index == -1)
            {
                Console.WriteLine( "Error! Identifier not found." );
                return;
            }

            while (true)
            {
                Console.Write( $"Select the field to change.\n" +
                               $"1. Origin      ({database[index].Origin})\n" +
                               $"2. Destination ({database[index].Destination})\n" +
                               $"3. Passangers  ({database[index].Passengers})\n" +
                               $"4. Cancel\n" +
                               $"=> " );
                // change the info that found
                if (int.TryParse( Console.ReadLine(), out int menu ))
                {
                    if(menu >= 1 && menu <= 3)
                    {
                        switch (menu)
                        {
                            case 1:
                                string origin;
                                while (true)
                                {
                                    Console.Write( "Enter a new value for origin : " );
                                    origin = Console.ReadLine();
                                    if(origin.Length == 4)
                                    {
                                        database[index].SetOrigin( origin );
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine( "Origin must be 4 letters." );
                                        continue;
                                    }
                                }
                                break;

                            case 2:
                                string destination;
                                while (true)
                                {
                                    Console.Write( "Enter a new value for destination : " );
                                    destination = Console.ReadLine();
                                    if (destination.Length == 4)
                                    {
                                        database[index].SetDestination( destination );
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine( "Destination must be 4 letters." );
                                        continue;
                                    }
                                }
                                break;

                            case 3:
                                while (true)
                                {
                                    Console.Write( "Enter a new value for passangers : " );
                                    if (int.TryParse(Console.ReadLine(), out int passangers))
                                    {
                                        database[index].SetPassangers( passangers );
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine( "Passangers must be integer." );
                                        continue;
                                    }
                                }
                                break;
                        }
                    }
                    else if (menu == 4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine( "Wrong menu. Select again." );
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine( "Wrong menu. Select again." );
                    continue;
                }

                Console.WriteLine( "Value has updated. Keep to update? [Y/N] : " );
                switch (Console.ReadKey( true ).Key)
                {
                    case ConsoleKey.Y:
                        Console.Clear();
                        continue;

                    case ConsoleKey.N:
                        break;
                }
            }
            
            Console.Clear();
        }
        static void Delete()
        {
            Console.Clear();
            Console.WriteLine( "\n===Update Menu===" );
            Console.Write( "Enter the identifier : " );
            string identifier = Console.ReadLine();
            // search from db
            var index = database.IndexOf( identifier.ToUpper() );
            if (index == -1)
            {
                Console.WriteLine( "Error! Identifier not found." );
                return;
            }

            Console.WriteLine( "Really want to remove flight? [Y/N] : " );
            switch (Console.ReadKey( true ).Key)
            {
                case ConsoleKey.Y:
                    //delted searched item
                    database.RemoveAt( index );
                    break;

                case ConsoleKey.N:
                    break;
            }

            Console.WriteLine( $"{identifier.ToUpper()} flight was removed." );
            Console.WriteLine( "Press any key to continue..." );
            Console.ReadKey( true );
            Console.Clear();
        }
        static void List()
        {
            Console.WriteLine( "\n===Flight List===" );
            Console.WriteLine( "Identifier\tOrigin\tDestination\tPassengers" );
            foreach(Data d in database)
            {
                Console.WriteLine( $"{d.Identifier}\t\t{d.Origin}\t{d.Destination}\t\t{d.Passengers}" );
            }
            Console.WriteLine( "Press any key to continue..." );
            Console.ReadKey( true );
            Console.Clear();
        }
        static int Menu()
        {
            while(true)
            {
                Console.Write( "\n===Select Menu===\n" +
                               "1. Create Flight\n" +
                               "2. Update Flight\n" +
                               "3. Delete Flight\n" +
                               "4. Flight List\n" +
                               "5. Exit\n" +
                               "=> " );

                if(int.TryParse(Console.ReadLine(), out int menu) )
                {
                    if(menu >= 1 && menu <= 5)
                    {
                        return menu;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine( "Wrong number. Select again.\n" );
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine( "Wrong charactor. You must input only number.\n" );
                }
            }
        }
    }
}
