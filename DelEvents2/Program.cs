using System;
using System.Collections.Generic;

//N1
public static class StringExtensions
{
    public static bool IsValidParentheses(this string str)
    {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> brackets = new Dictionary<char, char>
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

        foreach (char ch in str)
        {
            if (brackets.ContainsValue(ch))
            {
                stack.Push(ch);
            }
            else if (brackets.ContainsKey(ch))
            {
                if (stack.Count == 0 || stack.Pop() != brackets[ch])
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
}
//N2
static class ExtArray
{
    public static int[] FiltrParn(int[] arr)
    {
        int[] filteredArr = arr.Where(x => x % 2 == 0).ToArray();
        return filteredArr;
    }
}

//N3

delegate void UpBalance(string message);
delegate void SpendBalance(string message);
delegate void StartSpending(string message);
delegate void Limit(string message);
delegate void ChangePin(string message);

class CreditCard
{
    public event UpBalance Up;
    public event SpendBalance Spend;
    public event StartSpending StartSpend;
    public event Limit Lim;
    public event ChangePin Change;
    public int Balance { get; set; }
    public string Name { get; set; }
    public int PIN { get; set; }

    public CreditCard(int balance, string name, int pIN)
    {
        Balance = balance;
        Name = name;
        PIN = pIN;
    }   
    public void UpBalance(int number)
    {
        Console.WriteLine(Name);
        Console.WriteLine("Balance up: " + (Balance += number));
        Up?.Invoke("Balance has been increased! ");

    }
    public void SpendBalance(int number)
    {
        Console.WriteLine(Name);
        Console.WriteLine("Spend Balance: " + (Balance -= number));
        Spend?.Invoke("Balance has been spent! ");
    }
    public void StartSpending() {
        Console.WriteLine(Name);
        Console.WriteLine("Balance Spending...");
        StartSpend?.Invoke("Spent! ");
    
    }
    public void Limit(int number) {
        Console.WriteLine(Name);
        if (Balance > number)
        {
            Console.WriteLine($"You're reaching all limits!");

        }
        Console.WriteLine("You've reached limit!");
    
    }
    public void pIN(int number)
    {
        Console.WriteLine(Name);
        PIN += number;
        Console.WriteLine("Changing Pin...");
        Console.WriteLine("Pin has been changed");
    }
}


class DayTemp
{
    public double maxForDay { get; set; }
    public double minForDay { get; set; }

    public DayTemp(double max, double min)
    {
        maxForDay = max;
        minForDay = min;
    }
    public double Max(double[] arr)
    {
        return arr.Max();
    }

    public double Min(double[] arr)
    {
        return arr.Min();
    }

    public double MaxDifference(double[] arr)
    {
        return Max(arr) - Min(arr);
    }
}

class Program
{
    static void Main(string[] args)
    {
        //N1
        string[] testStrings = { "{}", "[]", "(())", "[{}]", "[}", "[[{]}]" };

        foreach (var test in testStrings)
        {
            bool isValid = test.IsValidParentheses();
            Console.WriteLine($"{test} - {(isValid ? "валидная строка" : "невалидная строка")}");
        }
        //N2
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] filteredArray = ExtArray.FiltrParn(array);
        //N3
        Console.WriteLine("Четные числа:");
        foreach (int num in filteredArray)
        {
            Console.WriteLine(num);
        }
        CreditCard obj = new CreditCard(100, "privat", 902390);

       
        obj.Up += HandleUpBalance;
        obj.Spend += HandleSpendBalance;
        obj.StartSpend += HandleStartSpending;
        obj.Lim += HandleLimit;
        obj.Change += HandleChangePin;

        obj.UpBalance(50);
        obj.SpendBalance(30);
        obj.StartSpending();
        obj.Limit(50);
        obj.pIN(123456);
        //N4 
        double[] ar = { 15.0, 25.0, 10.0, 17.0 };
        DayTemp temp = new DayTemp(0, 0);

        double maxTemp = temp.Max(ar);
        double minTemp = temp.Min(ar);
        double maxDifference = temp.MaxDifference(ar);

        Console.WriteLine("Максимальная температура: " + maxTemp);
        Console.WriteLine("Минимальная температура: " + minTemp);
        Console.WriteLine("Самая большая разница между max и min:  " + maxDifference);

    }
    static void HandleUpBalance(string message)
    {
        Console.WriteLine( message);
    }

    static void HandleSpendBalance(string message)
    {
        Console.WriteLine( message);
    }

    static void HandleStartSpending(string message)
    {
        Console.WriteLine( message);
    }

    static void HandleLimit(string message)
    {
        Console.WriteLine( message);
    }

    static void HandleChangePin(string message)
    {
        Console.WriteLine( message);
    }
    

}

