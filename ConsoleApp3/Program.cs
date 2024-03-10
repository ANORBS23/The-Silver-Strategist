using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Inversity_Challange
{
    internal class Program
    {
        struct Track
        {
            //structure to allow for both track name and laptime to be added into array


            public int laptime;
            public string trackname;
        }
        static void Customisation()
        {
            bool valid = false;
            while (valid == false)
            {
                Console.WriteLine("1.Change colour of font");
                Console.WriteLine("2.Change colour of background");
                Console.WriteLine("3.Exit");
                int usrchoice = int.Parse(Console.ReadLine());
                switch (usrchoice)
                {
                    case 1:
                        Console.WriteLine("Which colour would you like your font");
                        Console.WriteLine("1.Green");
                        Console.WriteLine("2.Yellow");
                        Console.WriteLine("3.Red");
                        Console.WriteLine("4.Blue");
                        
                        
                        int fontchoice = int.Parse(Console.ReadLine());
                        switch (fontchoice)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;

                        }
                        break;
                    case 2:
                        Console.WriteLine("Which colour would you like your font");
                        Console.WriteLine("1.Green");
                        Console.WriteLine("2.Yellow");
                        Console.WriteLine("3.Red");
                        Console.WriteLine("4.Blue");

                        int backchoice = int.Parse(Console.ReadLine());
                        switch (backchoice)
                        {
                            case 1:
                                Console.BackgroundColor = ConsoleColor.Green;
                                break;
                            case 2:
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                break;
                            case 3:
                                Console.BackgroundColor = ConsoleColor.Red;
                                break;
                            case 4:
                                Console.BackgroundColor = ConsoleColor.Blue;
                                break;

                        }
                        break;
                    case 3:
                        valid = true;
                        break;

                }
            }
            

        }
        static void Main(string[] args)
        {
            Customisation();
            Secuirity();
            bool randominfo = false;
            Track[] track = new Track[24];//creating an array for structure
            track[0].trackname = "bahrain";//adding track name to array
            track[0].laptime = 96;//adding laptime into the array
            track[1].trackname = "silverstone";
            track[1].laptime = 92;
            track[2].trackname = "monaco";
            track[2].laptime = 74;
            bool testtrack = false;//condition to repeat the loop until the condition has been met
            while (testtrack == false)
            {
                Console.WriteLine("Log in successful");
                Console.WriteLine("Select track");//system to select track
                string usrtrack = Console.ReadLine().ToLower();
                char trackconfirm = ' ';
                char quit = ' ';
                for (int i = 0; i < 24; i++)//goes through all tracks if they all added
                {
                    if (usrtrack == track[i].trackname)
                    {
                        testtrack = true;
                        Console.WriteLine($"Is {track[i].trackname} the track that you selected?PRESS Y/N ");//makes sure user has entered the correct track they wanted
                        try
                        {
                            trackconfirm = char.Parse(Console.ReadLine().ToLower());
                        }
                        catch
                        {
                            Console.WriteLine("INVALID INPUT PLEASE TRY AGAIN");//catch to make sure that any invalid inputs doesn't
                        }
                        if (usrtrack != track[i].trackname || trackconfirm != 'y')//doesnt accept invalid inputs means that it won't allow for the user to contiune if they haven't entered correct inputs
                        {
                            Console.WriteLine("Your track has not been accepted, please try again ");
                            testtrack = false;



                        }
                        else
                        {
                            Console.WriteLine(track[i].trackname + " has been selected");//output to the user to show which track they have choosen
                        }
                        Console.WriteLine("Would you like to exit/log off y/n");//gives option for the user to log off if they want to
                        quit = char.Parse(Console.ReadLine().ToLower());
                        if (quit == 'y')
                        {
                            Console.WriteLine("You will now be logged off");//if they choose to log out it will move to the quit menu
                            QuitMenu();
                        }
                        Console.Clear();//clears so that information isn't overwhelming
                    }
                }

            }

            menu(track, ref randominfo);//calls menu
            GetMenuChoice(track, ref randominfo);//calls menu choice
        }
        static void menu(Track[] track, ref bool randominfo)
        {
            //menu method

            Console.WriteLine("              ");
            Console.WriteLine("--------------");
            Console.WriteLine("Main Menu");
            Console.WriteLine("1.Tyre degradation");
            Console.WriteLine("2.Safety car chances");
            Console.WriteLine("3.Competitor information");
            Console.WriteLine("4.Best race strategy");
            Console.WriteLine("5.Lap chart");
            Console.WriteLine("6.Quit/Log out");
            Console.WriteLine("--------------");
            Console.WriteLine("              ");
            GetMenuChoice(track, ref randominfo);//calls for the choice

        }
        static void GetMenuChoice(Track[] track, ref bool randominfo)
        {
            bool valid = false;
            while (valid == false)
            {
                Console.WriteLine("Please enter your choice");
                try//option for choice
                {
                    int usrchoice = int.Parse(Console.ReadLine());
                    if (usrchoice > 0 && usrchoice <= 6)//validates that the user has entered correct input
                    {
                        valid = true;
                        switch (usrchoice)//casing the inputs
                        {
                            case 1:
                                TyreDeg(ref track, ref randominfo);//different options depending on the user choice 
                                break;
                            case 2:
                                SafetyCarChances(track, randominfo);
                                break;
                            case 3:
                                DataBase(track, ref randominfo);
                                break;

                            case 4:
                                BestStragery(track, ref randominfo);
                                break;
                            case 5:
                                RunProgram(track, ref randominfo);
                                break;
                            case 6:
                                QuitMenu();
                                break;

                        }
                    }
                    else
                    {
                        Console.WriteLine("INVALID INPUT,PLEASE TRY AGAIN");//if it isnt accepted it will ask the user of they want to log out
                        Console.WriteLine("Would you like to log out?");
                        char usrquit = char.Parse(Console.ReadLine().ToLower());
                        if (usrquit == 'y')//if yes quit menu will be loaded.
                        {
                            QuitMenu();
                        }
                    }

                }
                catch (Exception e)//catches any invalid data so that the program doesnt crash
                {
                    Console.WriteLine("Invalid");
                }
            }


        }
        static void BestStragery(Track[] track, ref bool randominfo)
        {
            Console.Clear();
            string compoundused = "";
            Console.WriteLine("Enter number of laps left");
            int numpoflapsleft = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter the compound used");
            compoundused = Console.ReadLine().ToLower();
            //asks the user which compound that they have used as atleast 2 compounds have to be used within a race 

            if (compoundused == "soft" || compoundused == "meduim" || compoundused == "hard" && numpoflapsleft > 0)//makes sure that the compound is either s/m/h
            {//validates that number of laps is greater than 0 as you cannot have a negative number of laps
                if (compoundused == "soft")//options if the tyre is soft,medium or hard
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;//shows it in a different colour therefore stands out
                    //different colours for different compounds
                    Console.WriteLine("Pit window in around laps 15-23");//shows the pit window
                    Console.ForegroundColor = ConsoleColor.White;
                    if (numpoflapsleft < 50)//decision of which tyre should be used depends on the number of laps left
                    {
                        Console.WriteLine("All right we'll need to come into the pits for the hard tyre as it is faster");
                        Console.WriteLine("Data used from 2024 bahrain GP");
                    }
                    else if (numpoflapsleft < 57 && numpoflapsleft > 50)//max possible laps is 57 therefore cannot be greater than 57.
                    {
                        Console.WriteLine("You may want to pit twice onto the medium then hard, or pit onto the hard twice");
                    }
                }
                else if (compoundused == "meduim")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Pit window laps 24-33");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (numpoflapsleft < 20)
                    {
                        Console.WriteLine("All right we'll need to come into the pits for the soft tyre as it is faster, mind tyre deg");

                        Console.WriteLine("Data used from 2024 bahrain GP");
                    }
                    else if (numpoflapsleft < 57 && numpoflapsleft > 50)
                    {
                        Console.WriteLine("You may want to pit twice onto the soft then hard, or pit onto the medium twice");

                    }
                }
                else if (compoundused == "hard")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Pit window laps 30-46");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (numpoflapsleft < 20)
                    {
                        Console.WriteLine("All right we'll need to come into the pits for the soft tyre as it is faster, mind tyre deg");

                        Console.WriteLine("Used from 2024 bahrain GP");
                    }
                    else if (numpoflapsleft < 57 && numpoflapsleft > 50)
                    {
                        Console.WriteLine("You may want to pit twice onto the soft then medium, or pit onto the medium twice");

                    }
                }
            }
            else
            {
                Console.WriteLine("Number of laps cannot be negative, please try again");

            }


            menu(track, ref randominfo);//calls the menu
        }
        static void SafetyCarChances(Track[] track, bool randominfo)
        {
            Console.Clear();
            Console.WriteLine("Enter the number of collisions this race");
            int collisons = int.Parse(Console.ReadLine());//user inputs
            Console.WriteLine("Enter the number of cars on track");
            int numofcars = int.Parse(Console.ReadLine());
            Random random = new Random();//random numbers as the chances of a safety car are so unpredictable
            int probcond = random.Next(1, 100);//here i wanted to implement a way of having random unpredictable chances of a safety car, much like in a proper race scenario.
            int probweath = random.Next(1, 100);
            const double pastsafetycars = 1.592;//historial risks at said track
            double probsc = ((collisons + pastsafetycars / numofcars) * probcond * probweath) / 1000;//equation of probability of safety car,depending on random factors
            if (probsc > 1.5)//if greater than 1.5 then deemed high likelyhood.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("High likelihood of a safety car");
                Console.WriteLine("Consider staying out a few more laps");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Low likelihood of a safety car");
                Console.ForegroundColor = ConsoleColor.White;
            }
            menu(track, ref randominfo);
        }

        static void QuitMenu()
        {

            Console.Clear();
            Console.WriteLine("You will now be logged off ,safe driving");
            Environment.Exit(0);
        }







        static void Secuirity()
        {//chat gpt adapted by myself lines(275-342)
            bool loggedin = false;
            while (loggedin == false)
            {
                string username = "M-2327A"; // Predefined username
                string storedPasswordHash = HashPassword("pass456"); // Predefined password hashed
                Console.Clear();
                Console.WriteLine("Welcome to the Secure Login System");

                // Ask for username
                Console.Write("Enter username: ");
                string enteredUsername = Console.ReadLine();

                // Mask password entry
                Console.Write("Enter password: ");
                string enteredPassword = MaskInput();

                // Hash entered password
                string enteredPasswordHash = HashPassword(enteredPassword);

                // Check if username and hashed password are correct
                if (enteredUsername == username && enteredPasswordHash == storedPasswordHash)
                {
                    Console.WriteLine("Login successful!");
                    Console.Clear();
                    loggedin = true;

                }
                else
                {
                    Console.WriteLine("Incorrect username or password. Access denied.");//doesnt allow the user to contuine of they have inputted incorrect username or password.
                    loggedin = false;
                    Console.WriteLine("Would you like to exit");
                    try
                    {
                        char usrexitchoice = char.Parse(Console.ReadLine().ToLower());
                        if (usrexitchoice == 'y')//choice for the user to quit
                        {
                            Environment.Exit(0);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("INVALID");
                    }
                }
            }

        }

        static string MaskInput()
        {
            string input = "";
            ConsoleKeyInfo keyInfo;

            // Capture key presses until Enter key is pressed
            do
            {
                keyInfo = Console.ReadKey(true);

                // Replace typed characters with '*'
                if (keyInfo.Key != ConsoleKey.Enter)
                {
                    Console.Write("*");
                    input += keyInfo.KeyChar;
                }
            } while (keyInfo.Key != ConsoleKey.Enter);

            Console.WriteLine(); // Move to the next line after masking input
            return input;
        }

        static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        static void TyreDeg(ref Track[] track, ref bool randominfo)
        {
            Console.Clear();
            int tracktemperature = 0;
            int humidilty = 0;
            int rainchance = 0;
            if (randominfo == false)
            {
                Random rnd = new Random();
                tracktemperature = rnd.Next(30, 37);
                humidilty = rnd.Next(40, 60);
                rainchance = rnd.Next(1, 36);
                randominfo = true;
            }
            const double softbasedeg = 0.5;//as on average tyre degration is 0.5% slower
            const double meduimbasedeg = 0.3;//as medium degrades slower than soft
            const double hardbasedeg = 0.2;//hard is the longest lasting tyre therefore has the least amount of tyre deg,it is also the slowest tyre.
            const double WeatherMultiplier = 0.05; // Weather impact multiplier
            const double TemperatureMultiplier = 0.03; // Temperature impact multiplier
            const double TireCompoundMultiplier = 0.08; // Tire compound impact multiplier
            const double TireAgeMultiplier = 0.02; // Tire age impact multiplier
            double tyreage = 0;
            double weatherimpact = 0;
            double temperature = 0;
            double totaldeg = 0;
            double percentagetyrewear = 0;
            Console.WriteLine($"Track temperature is {tracktemperature} degrees ");
            Console.WriteLine($"The humidity of the track is {humidilty} %");
            Console.WriteLine($"The chances of rain are {rainchance} %");


            Console.WriteLine("Please choose the tyre compound S/M/H");
            try
            {

                char usrtyrechoice = char.Parse(Console.ReadLine().ToLower());
                if (usrtyrechoice == 's')
                {
                    Console.WriteLine("Soft tyre has been selected");
                    Console.WriteLine("Enter the age of the tyre");
                    tyreage = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the weather impact 1.0, for no impact ,< 1.0 more degradation,> 1.0 less degradation");
                    weatherimpact = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the temperature impact 1.0, for no impact ,< 1.0 more degradation,> 1.0 less degradation");
                    temperature = double.Parse(Console.ReadLine());
                    totaldeg = softbasedeg + (softbasedeg * tyreage * TireAgeMultiplier + softbasedeg * TemperatureMultiplier * temperature + TireCompoundMultiplier * softbasedeg + softbasedeg * WeatherMultiplier * weatherimpact);
                    if (totaldeg > 1)
                    {
                        totaldeg = 1;
                    }
                }
                else if (usrtyrechoice == 'm')
                {
                    Console.WriteLine("Medium tyre has been selected");
                    Console.WriteLine("Enter the age of the tyre");
                    tyreage = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the weather impact 1.0, for no impact ,< 1.0 more degradation,> 1.0 less degradation");
                    weatherimpact = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the temperature impact 1.0, for no impact ,< 1.0 more degradation,> 1.0 less degradation");
                    temperature = double.Parse(Console.ReadLine());
                    totaldeg = meduimbasedeg + (meduimbasedeg * tyreage * TireAgeMultiplier + meduimbasedeg * TemperatureMultiplier * temperature + TireCompoundMultiplier * meduimbasedeg + meduimbasedeg * WeatherMultiplier * weatherimpact);
                    if (totaldeg > 1)
                    {
                        totaldeg = 1;
                    }
                }
                else if (usrtyrechoice == 'h')
                {
                    Console.WriteLine("hard tyre has been selected");
                    Console.WriteLine("Enter the age of the tyre");
                    tyreage = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the weather impact 1.0, for no impact ,< 1.0 more degradation,> 1.0 less degradation");
                    weatherimpact = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the temperature impact 1.0, for no impact ,< 1.0 more degradation,> 1.0 less degradation");
                    temperature = double.Parse(Console.ReadLine());
                    totaldeg = hardbasedeg + (hardbasedeg * tyreage * TireAgeMultiplier + hardbasedeg * TemperatureMultiplier * temperature + TireCompoundMultiplier * hardbasedeg + hardbasedeg * WeatherMultiplier * weatherimpact);
                    if (totaldeg > 1)
                    {
                        totaldeg = 1;
                    }
                }

                else
                {
                    Console.WriteLine("You have unsuccessfully selected a tyre");
                    Console.WriteLine("You will now be redirected to the main menu");
                    menu(track, ref randominfo);
                    GetMenuChoice(track, ref randominfo);
                }

                Console.WriteLine($"The total tyre degradation for the current tyre is approximately {totaldeg} %");
                percentagetyrewear = (1 - totaldeg) * 100;
                
                Console.WriteLine($"Front left degradation is {percentagetyrewear+1} %");
                Console.WriteLine($"Front right degradation is {percentagetyrewear-1} %");
                Console.WriteLine($"Back left degradation is {percentagetyrewear+2} %");
                Console.WriteLine($"Back right degradation is {percentagetyrewear-2}  %");
                double maxlapsleft = 0;
                if (usrtyrechoice == 's')
                {
                    maxlapsleft = 20 - (20 * totaldeg);
                }
                if (usrtyrechoice == 'm')
                {
                    maxlapsleft = 30 - (30 * totaldeg);
                }
                if (usrtyrechoice == 'h')
                {
                    maxlapsleft = 40 - (40 * totaldeg);
                }

                Console.WriteLine($"Maximum possible laps left is {maxlapsleft}");
                if (percentagetyrewear < 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("We would recommend that you pit ASAP as there is a high likelihood that you may get a puncture");
                    Console.ForegroundColor = ConsoleColor.White;
                    menu(track, ref randominfo);



                }
                if (percentagetyrewear < 30 && percentagetyrewear > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("With this data we would advise you to come into the pits soon");
                    Console.ForegroundColor = ConsoleColor.White;
                    menu(track, ref randominfo);

                }
                else if (percentagetyrewear > 50 && percentagetyrewear > 30)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your tyres seem to be good therefore no need to pit");
                    Console.ForegroundColor = ConsoleColor.White;
                }




            }
            catch (Exception ex)
            {
                Console.WriteLine("INVALID, please try again");
            }

        }
        static List<int[]> coordinates = new List<int[]>();//chat gpt(488-583)
        static void RunProgram(Track[] track, ref bool randominfo)
        {
            bool done = false;

            while (!done)
            {
               
                Console.WriteLine("1. Enter coordinates for line graph");
                Console.WriteLine("2. View line graph");
                Console.WriteLine("3. Exit");
                Console.WriteLine("4. Menu");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EnterCoordinates();
                        break;
                    case "2":
                        ViewGraph();
                        break;
                    case "3":
                        done = true;
                        break;
                    case "4":
                        menu(track, ref randominfo);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }

        static void EnterCoordinates()
        {
            Console.WriteLine("Enter the coordinates as (x1,y1) space (x2,y2) etc. X coordinate being the lap and Y coordinate being laptime Press Enter when done:");

            string input = Console.ReadLine();
            string[] points = input.Split(' ');

            foreach (string point in points)
            {
                string[] values = point.Trim('(', ')').Split(',');
                if (values.Length != 2 || !int.TryParse(values[0], out int x) || !int.TryParse(values[1], out int y))
                {
                    Console.WriteLine("Invalid input format. Please enter coordinates in the format (x,y).");
                    coordinates.Clear();
                    return;
                }
                coordinates.Add(new int[] { x, y });
            }
        }

        static void ViewGraph()
        {
            if (coordinates.Count == 0)
            {
                Console.WriteLine("No coordinates entered yet. Please enter coordinates first.");
                return;
            }

            int maxX = coordinates.Max(c => c[0]);
            int maxY = coordinates.Max(c => c[1]);
            int startY = 80;

            Console.WriteLine("Lap Chart X coordinate being the lap, Y coordinate being the lap time:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Green being quicker than average target laptime");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Red being slower than average target laptime ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Average target laptime:96s (1min 36s)");
            Console.ForegroundColor = ConsoleColor.White;

            for (int y = maxY; y >= startY; y--)
            {
                Console.Write($"{y} | ");
                for (int x = 1; x <= maxX; x++)
                {
                    bool pointExists = coordinates.Any(c => c[0] == x && c[1] == y);
                    if (pointExists)
                    {
                        // Check y-value to determine color
                        Console.ForegroundColor = (y < 96) ? ConsoleColor.Green : ConsoleColor.Red;
                        Console.Write("* ");
                        Console.ResetColor(); // Reset color to default
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }

            // Print X-axis labels
            Console.Write("    ");
            for (int x = 1; x <= maxX; x++)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();
            Console.WriteLine("    X-axis");
        }







        //chat gpt lines(592-679)
        class F1Driver
        {//makes a class 
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Nationality { get; set; }
            public DateTime DateOfBirth { get; set; }
            public int TotalWins { get; set; }
            public int TotalPodiums { get; set; }
            public Dictionary<string, string> AdditionalInfo { get; set; }//makes a string to add any information that the user wants to add. 

            public F1Driver()
            {
                AdditionalInfo = new Dictionary<string, string>();
            }

            public void PrintDriverInfo()
            {//outputs the drivers information that has been saved
                Console.WriteLine($"Name: {FirstName} {LastName}");
                Console.WriteLine($"Nationality: {Nationality}");
                Console.WriteLine($"Date of Birth: {DateOfBirth.ToShortDateString()}");
                Console.WriteLine($"Total Wins: {TotalWins}");
                Console.WriteLine($"Total Podiums: {TotalPodiums}");

                if (AdditionalInfo.Count > 0)
                {
                    Console.WriteLine("Additional Information:");
                    foreach (var info in AdditionalInfo)
                    {
                        Console.WriteLine($"- {info.Key}: {info.Value}");
                    }
                }
            }
        }



        static List<F1Driver> drivers = new List<F1Driver>();

        static void DataBase(Track[] track, ref bool randominfo)
        {
            bool valid= false;
            // Add default driver (Max Verstappen)
            AddDefaultDriver();

            while (valid==false)
            {//case statement for that allows to view competitor information
                
                Console.WriteLine("1. Add new driver");
                Console.WriteLine("2. Add information about existing drivers");
                Console.WriteLine("3. View existing drivers");
                Console.WriteLine("4. Menu");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                int usrchoice=int.Parse(Console.ReadLine());
                Console.WriteLine(usrchoice);
                if (usrchoice > 0 && usrchoice < 6)
                {
                    switch (usrchoice)
                    {
                        case 1:
                            {
                                AddNewDriver();
                                break;
                            }

                        case 2:
                            {
                                AddInfoToExistingDriver();
                                break;
                            }
                        case 3:
                            {
                                ViewExistingDrivers();
                                break;
                            }

                        case 4:
                            menu(track, ref randominfo);
                            break;
                            case 5:
                            QuitMenu();
                            break;
                            default:
                            Console.WriteLine("INVALID");
                            break;

                            

                    }
                }
               
            }
        }

        static void AddDefaultDriver()
        {
            F1Driver defaultDriver = new F1Driver
            {//defualt driver is max verstappen as greatest competitor
                FirstName = "Max",
                LastName = "Verstappen",
                Nationality = "Dutch",
                DateOfBirth = new DateTime(1997, 9, 30),
                TotalWins = 15,
                TotalPodiums = 35
            };
            drivers.Add(defaultDriver);
        }

        static void AddNewDriver()
        {//adding data about a new driver
            F1Driver newDriver = new F1Driver();

            Console.WriteLine("Enter driver information:");

            Console.Write("First Name: ");
            newDriver.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            newDriver.LastName = Console.ReadLine();

            Console.Write("Nationality: ");
            newDriver.Nationality = Console.ReadLine();

            Console.Write("Date of Birth (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
            {
                newDriver.DateOfBirth = dob;
            }
            else
            {
                Console.WriteLine("Invalid date format. Skipping Date of Birth.");
            }

            Console.Write("Total Wins: ");
            if (int.TryParse(Console.ReadLine(), out int wins))
            {
                newDriver.TotalWins = wins;
            }
            else
            {
                Console.WriteLine("Invalid input for total wins. Skipping Total Wins.");
            }

            Console.Write("Total Podiums: ");
            if (int.TryParse(Console.ReadLine(), out int podiums))
            {
                newDriver.TotalPodiums = podiums;
            }
            else
            {
                Console.WriteLine("Invalid input for total podiums. Skipping Total Podiums.");
            }

            // Additional Information
            //chat gpt lines(726-811)

            Console.WriteLine("Enter additional information about the driver (press Enter to skip):");
            while (true)
            {
                Console.Write("Key: ");
                string key = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(key))
                    break;

                Console.Write("Value: ");
                string value = Console.ReadLine();

                newDriver.AdditionalInfo.Add(key, value);

                Console.Write("Add more? (y/n): ");
                string more = Console.ReadLine();
                if (more.ToLower() != "y")
                    break;
            }

            drivers.Add(newDriver);

            Console.WriteLine("Driver added successfully!\n");
        }

        static void AddInfoToExistingDriver()
        {//information can bev added on existing drivers
            Console.WriteLine("Select a driver to add information:");
            for (int i = 0; i < drivers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {drivers[i].FirstName} {drivers[i].LastName}");
            }

            Console.Write("Enter the number corresponding to the driver: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= drivers.Count)//asssigns the drivers a number and lets the user pick a number
                                                                                                        //more reliable than entering names as the user may input the drivers name incorrectly,
            {
                F1Driver selectedDriver = drivers[index - 1];

                Console.WriteLine($"Adding information for {selectedDriver.FirstName} {selectedDriver.LastName}:");

                // Additional Information
                Console.WriteLine("Enter additional information about the driver (press Enter to skip):");
                while (true)
                {
                    Console.Write("Key: ");
                    string key = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(key))
                        break;

                    Console.Write("Value: ");
                    string value = Console.ReadLine();

                    selectedDriver.AdditionalInfo.Add(key, value);

                    Console.Write("Add more? (y/n): ");
                    string more = Console.ReadLine();
                    if (more.ToLower() != "y")
                        break;
                }

                Console.WriteLine("Information added successfully!\n");//tells user if they have added the information correctly
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.\n");//tells the user if they have incorrectly inputted their data
            }
        }

        static void ViewExistingDrivers()
        {//can view the data as many times as possible
         
            if (drivers.Count == 0)
            {
                Console.WriteLine("No drivers added yet.\n");//if no drivers have been added then it won't output anything
                return;
            }
            else
            {
                Console.WriteLine("Existing Drivers:");
                foreach (var driver in drivers)
                {
                    driver.PrintDriverInfo();
                    Console.WriteLine();
                }
            }


        }



    }

}









