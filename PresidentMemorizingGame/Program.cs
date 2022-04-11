// See https://aka.ms/new-console-template for more information
static void SetUp()
{
    //Get our input from user
    Console.WriteLine("Select presidents to do. Ex 1-10");
    var input = Console.ReadLine().Split('-'); //Parse input into array seperated by the - to get a range
    if (input.Length <= 1)
    {
        Console.WriteLine("Ben stop trying to break my program. You have to enter a range. Ex: 1-10, 11-20, ect");
        SetUp();
    }
    
    //Parse to ints
    var minSuccess  = int.TryParse(input[0], out int min);
    var maxSuccess = int.TryParse(input[1], out int max);

    if (!minSuccess || !maxSuccess)
    {
        Console.WriteLine("Ben stop trying to break my program. You have to enter a range. Ex: 1-10, 11-20, ect");
        SetUp();
    }
    
    //TODO: set up random order
    // Console.WriteLine("Do you want it to be a random order?, (y or n)");
    // var randinput = Console.ReadLine();
    // bool isRand = randinput == "y";

    RunGame(false, min, max);
}

static void RunGame(bool random, int min, int max)
{
    string[] presidents = new string[]
    {
        "George Washington", 
        "John Adams", 
        "Thomas Jefferson", 
        "James Madison", 
        "James Monroe", 
        "John Quincy Adams", 
        "Andrew Jackson", 
        "Martin Van Buren", 
        "William Henry Harrison", 
        "John Tyler",
        "James Polk",
        "Zachary Taylor",
        "Millard Fillmore",
        "Franklin Pierce",
        "James Buchanan",
        "Abraham Lincoln",
        "Andrew Johnson",
        "Ulysses S. Grant",
        "Rutherford B. Hayes",
        "James A. Garfield",
        "Chester A. Author",
        "Grover Cleveland",
        "Benjamin Harrison",
        "Grover Cleveland",
        "William McKinley",
        "Theodore Roosevelt",
        "William Howard Taft",
        "Woodrow Wilson",
        "Warren G. Harding",
        "Calvin Coolidge",
        "Herbert Hoover",
        "Franklin D. Roosevelt",
        "Harry S. Truman",
        "Dwight D. Eisenhower",
        "John F. Kennedy",
        "Lyndon B. Johnson",
        "Richard M. Nixon",
        "Gerald Ford",
        "Jimmy Carter",
        "Ronald Regan",
        "George H.W. Bush",
        "Bill Clinton",
        "George W. Bush",
        "Barack Obama",
        "Donald Trump",
        "Joe Biden"
        
    };
    
    //If max is greater than our array length we just set the max to the array length
    if (max > presidents.Length)
    {
        max = presidents.Length;
    }
    
    Console.WriteLine("Here is some review:");
    
    for (int i = min - 1; i < max; i++)
    {
        Console.WriteLine($"{i+1}: {presidents[i]}");
    }
    Console.WriteLine("Press any key to continue...");

    Console.ReadKey();
    Console.Clear();
    
    List<string> right = new List<string>();
    List<string> wrong = new List<string>();

    int[] taken = new int[max];
    for (int x = min - 1; x < max ; x++)
    {
        // var temp = x;
        // if (random)
        // {
        //     Random rnd = new Random();
        //     int num = 0;
        //     do
        //     {
        //         num = min + rnd.Next(max - min);
        //     } while (taken.Contains(num));
        //     taken[x] = num;
        //     x = num;
        //
        // }
        Console.WriteLine($"Please input the {x+1}{GetPrefix(x+1)} president:");
        var answer = Console.ReadLine();
        //Check to see if answer is right then add it to a list
        //TODO: Make a percentage system to see if answer is right
        if(answer == presidents[x])
        {
            right.Add($"{x+1}: {presidents[x]}");
        } else {
            wrong.Add($"{x+1}: {presidents[x]}");
        }
        
        Console.Clear();
        //x = temp;
    }

    
    //Calculate data
    float percent = (float) right.Count / (max - (min - 1));

    var presidentStringRight = "";
    for (int i = 0; i < right.Count; i++)
    {
        presidentStringRight += $"{right[i]} ";
    }

    var presidentStringWrong = "";
    for (int i = 0; i < wrong.Count; i++)
    {
        presidentStringWrong += $"{wrong[i]} ";
    }
    
    Console.WriteLine("Here's how you did\n" +
                      $"Range: {min}-{max}\n" +
                      $"Total right: {right.Count}\n" +
                      $"Total Wrong: {wrong.Count}\n" +
                      $"Presidents you got right: {presidentStringRight}\n" +
                      $"Presidents you got wrong: {presidentStringWrong}\n" +
                      $"Percentage: {Math.Round(percent * 100)}%");
    
    SetUp();
}

static string GetPrefix(int num)
{
    if (num == 1)
        return "st";
    else if (num == 2)
        return "nd";
    else if (num == 3)
        return "rd";
    else
        return "th";
}


static bool IsCorrect(string guess, string answer)
{
    double correct = 0.00;
    for (int i = 0; i < guess.Length; i++)
    {
        if (guess[i] == answer[i])
        {
            correct += 1.00;
        } else if (guess[i] == Char.ToLower(answer[i]))
        {
            correct += 0.50;
        }
    }

    return (correct / answer.Length) * 100 > 80;
}
SetUp();