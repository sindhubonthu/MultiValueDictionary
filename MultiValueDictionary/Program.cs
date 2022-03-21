using System;
using System.Linq;

namespace MultiValueDictionary
{
    internal class Program
    {
        private static void Main()
        {
            GetCommandLineInput();
        }

        // This method takes input from the command line and executes relative multi value dictionary operation
        private static void GetCommandLineInput()
        {
            MultiValueDictionary multiDictionary = new();

            while (true)
            {
                //Constants for input values and message
                const int command = 0;
                const int key = 1;
                const int value = 2;
                const string enterValidInput = "Please enter input in valid format";

                //Accepts input from CommandLine
                var userInput = Console.ReadLine();

                //Exists if user types Exit
                if (userInput == null || userInput.Equals("Exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                //Splits input and stores values in array
                var input = userInput.Split(" ");

                if (input != null && input.Length > 0)
                {
                    //Executes statements based on case
                    switch (input[command])
                    {
                        case "ADD":
                            if (input.Length != 3)
                            {
                                Console.WriteLine(enterValidInput);
                            }
                            else
                            {
                                try
                                {
                                    Console.WriteLine(multiDictionary.Add(input[key], input[value])
                                   ? "Added"
                                   : "ERROR, member already exists for key");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            break;

                        case "KEYS":
                            if (input.Length != 1)
                            {
                                Console.WriteLine(enterValidInput);
                            }
                            else
                            {
                                try
                                {
                                    if (multiDictionary.GetKeys().Count == 0)
                                    {
                                        Console.WriteLine("There are no Keys");
                                    }
                                    else
                                    {
                                        multiDictionary?.GetKeys().ForEach(Console.WriteLine);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            break;

                        case "MEMBERS":
                            try
                            {
                                if (input.Length != 2)
                                {
                                    Console.WriteLine(enterValidInput);
                                }
                                else
                                {
                                    if (!multiDictionary.IsKeyExists(input[key]))
                                    {
                                        Console.WriteLine("Given key does not exist");
                                    }
                                    else
                                    {
                                        foreach (var member in multiDictionary.GetMembers(input[key]))
                                        {
                                            Console.WriteLine(member);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case "REMOVE":
                            try
                            {
                                if (input.Length != 3)
                                {
                                    Console.WriteLine(enterValidInput);
                                }
                                else
                                {
                                    if (!multiDictionary.IsKeyExists(input[key]))
                                    {
                                        Console.WriteLine("Given Key does not exist");
                                    }
                                    else
                                    {
                                        Console.WriteLine(multiDictionary.Remove(input[key], input[value])
                                            ? "Removed"
                                            : "ERROR, Member does not exist for the key");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case "REMOVEALL":
                            try
                            {
                                if (input.Length != 2)
                                {
                                    Console.WriteLine(enterValidInput);
                                }
                                else
                                {
                                    Console.WriteLine(multiDictionary.RemoveAll(input[key]) ? "Removed" : "Error, Key does not exist");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case "CLEAR":
                            if (input.Length != 1)
                            {
                                Console.WriteLine(enterValidInput);
                            }
                            else
                            {
                                multiDictionary.Clear();
                                Console.WriteLine("Cleared");
                            }
                            break;

                        case "KEYEXISTS":
                            try
                            {
                                if (input.Length != 2)
                                {
                                    Console.WriteLine(enterValidInput);
                                }
                                else
                                {
                                    Console.WriteLine(multiDictionary.IsKeyExists(input[key]) ? "True" : "false");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case "MEMBEREXISTS":
                            try
                            {
                                if (input.Length != 3)
                                {
                                    Console.WriteLine(enterValidInput);
                                }
                                else
                                {
                                    Console.WriteLine(multiDictionary.IsMemberExists(input[key], input[value]) ? "True" : "False");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case "ALLMEMBERS":

                            if (input.Length != 1)
                            {
                                Console.WriteLine(enterValidInput);
                            }
                            else
                            {
                                var allMembers = multiDictionary.AllMembers();
                                if (allMembers is { Count: > 0 })
                                {
                                    multiDictionary.AllMembers().ForEach(Console.WriteLine);

                                }
                                else
                                {
                                    Console.WriteLine("(empty set)");
                                }

                            }
                            break;

                        case "ITEMS":
                            if (input.Length != 1)
                            {
                                Console.WriteLine(enterValidInput);
                            }
                            else
                            {
                                var itemsList = multiDictionary.GetItems();
                                if (itemsList is { Count: > 0 })
                                {
                                    multiDictionary.GetItems().Select(item => $"{item.Key}: {item.Value}").ToList().ForEach(Console.WriteLine);
                                }
                                else
                                {
                                    Console.WriteLine("(empty set)");
                                }
                            }
                            break;

                        case "UNION":
                            {
                                if (input.Length != 3)
                                {
                                    Console.WriteLine(enterValidInput);
                                }
                                else
                                {
                                    var unionItems = multiDictionary.Union(input[key], input[value]);
                                    foreach (var item in unionItems)
                                        Console.WriteLine(item);
                                }
                            }
                            break;

                        case "INTERSECT":
                            {
                                if (input.Length != 3)
                                {
                                    Console.WriteLine(enterValidInput);
                                }
                                else
                                {
                                    var unionItems = multiDictionary.Intersect(input[key], input[value]);
                                    foreach (var item in unionItems)
                                        Console.WriteLine(item);
                                }
                            }
                            break;

                        default:
                            Console.WriteLine(enterValidInput);
                            break;

                    }
                }
                else
                {
                    Console.WriteLine(enterValidInput);
                }
            }
        }
    }
}