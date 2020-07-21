using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringProcessor
{
    class Program
    {

        static List<int> layer1 = new List<int>();
        static List<int> layer2 = new List<int>();
        static List<int> layer3 = new List<int>();

        static string getInput()
        {
            var rez = Console.ReadLine();
            while (rez == null || rez.Trim().Length == 0)
            {
                rez = Console.ReadLine();
            }
            return rez;
        }

        static void showIntro()
        {
            Console.WriteLine("Welcome to my string processing application.");
        }

        static void showUsage()
        {
            Console.WriteLine("Usage: \nA -> Add an operation to a layer. \nR -> Remove an operation from a layer \nP -> Process strings \nS -> Show layers");
        }

        static void showOperationTable()
        {
            Console.WriteLine("Please choose an opperation by typing the coresponding number (Lowercase(1), Uppercase(2), Sort(3), Invert(4) or Remove Spaces(5))");
        }

        static void showLayerSelect()
        {
            Console.WriteLine("Please choose a layer (1, 2 or 3)");
        }

        static void showInvalidPath()
        {
            Console.WriteLine("Invalid path");
        }

        static void showLayerAdd()
        {
            Console.WriteLine("Operation successfully added to layer");
        }

        static void showLayerRemove()
        {
            Console.WriteLine("Operation successfully removed from layer");
        }
        static void showProcessText()
        {
            Console.WriteLine("Please type the path to the folder containing the strings that need to be processed");
        }

        static void showOutput()
        {
            Console.WriteLine("Unknown Operation");
        }

        static void showEmptyLayer(int layer)
        {
            Console.WriteLine("Layer " + layer + " is empty");
        }

        static void showFinisedProcessing(int count)
        {
            Console.WriteLine("Finished processing " + count + " strings");
        }

        static void showOperationName(int op)
        {
            switch (op)
            {
                case 1:
                    Console.Write("Lowercase ");
                    break;
                case 2:
                    Console.Write("Uppercase ");
                    break;
                case 3:
                    Console.Write("Sort ");
                    break;
                case 4:
                    Console.Write("Invert ");
                    break;
                case 5:
                    Console.Write("Remove Spaces");
                    break;
                default:
                    showOutput();
                    break;
            }
        }

        static bool checkLayerSize(int layer)
        {
            switch (layer)
            {
                case 1: 
                    if (layer1.Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        showEmptyLayer(layer);
                        return false;
                    }
                case 2:
                    if (layer2.Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        showEmptyLayer(layer);
                        return false;
                    }
                case 3:
                    if (layer3.Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        showEmptyLayer(layer);
                        return false;
                    }
            }
            return false;
        }

        static void showLayers()
        {
            Console.WriteLine("The layers have the following structure:");
            Console.Write("Layer 1: ");
            foreach (int op in layer1)
            {
                showOperationName(op);
            }
            Console.Write("\nLayer 2: ");
            foreach (int op in layer2)
            {
                showOperationName(op);
            }
            Console.Write("\nLayer 3: ");
            foreach (int op in layer3)
            {
                showOperationName(op);
            }
            Console.Write('\n');

        }

        static void showLayerRemoveSelect(int layer)
        {
            int i = 1;
            Console.WriteLine("Please select an operation to remove by typing the corresponding number\nThe current contains of the layer are:");
            switch (layer)
            {
                case 1:
                    foreach (int op in layer1)
                    {
                        showOperationName(op);
                        Console.Write("(" + i + ") ");
                        i++;
                    };
                    break;
                case 2:
                    foreach (int op in layer2)
                    {
                        showOperationName(op);
                        Console.Write("(" + i + ") ");
                        i++;
                    };
                    break;
                case 3:
                    foreach (int op in layer3)
                    {
                        showOperationName(op);
                        Console.Write("(" + i + ") ");
                        i++;
                    };
                    break;
                default:
                    showOutput();
                    break;
            }
            Console.Write('\n');
        }

        static void removeOperation(string rez, int layer)
        {
            int numberToRemove;
            int.TryParse(rez[0].ToString(), out numberToRemove);

            switch (layer)
            {
                case 1:
                    if (numberToRemove == 0 || numberToRemove > layer1.Count())
                    {
                        showOutput();
                        showUsage();
                    }
                    else
                    {
                        layer1.RemoveAt(numberToRemove - 1);
                        showLayerRemove();
                    }
                    break;
                case 2:
                    if (numberToRemove == 0 || numberToRemove > layer2.Count())
                    {
                        showOutput();
                        showUsage();
                    }
                    else
                    {
                        layer2.RemoveAt(numberToRemove - 1);
                        showLayerRemove();
                    }
                    break;
                case 3:
                    if (numberToRemove == 0 || numberToRemove > layer3.Count())
                    {
                        showOutput();
                        showUsage();
                    }
                    else
                    {
                        layer3.RemoveAt(numberToRemove - 1);
                        showLayerRemove();
                    }
                    break;
                default:
                    showOutput();
                    break;
            }
            
        }

        static void addToLayer(int layer, int number)
        {
            switch (layer)
            {
                case 1:
                    layer1.Add(number);
                    showLayerAdd();
                    break;
                case 2:
                    layer2.Add(number);
                    showLayerAdd();
                    break;
                case 3:
                    layer3.Add(number);
                    showLayerAdd();
                    break;
                default:
                    showOutput();
                    break;
            }
        }

        static void addOperation(string rez, int layer)
        {
            switch (rez[0])
            {
                case '1':
                    addToLayer(layer, 1);
                    break;
                case '2':
                    addToLayer(layer, 2);
                    break;
                case '3':
                    addToLayer(layer, 3);
                    break;
                case '4':
                    addToLayer(layer, 4);
                    break;
                case '5':
                    addToLayer(layer, 5);
                    break;
                default:
                    showOutput();
                    break;
            }
        }


        static string processString(string input)
        {

            foreach (var op in layer1)
            {
                switch (op)
                {
                    case 1:
                        input = input.ToLower();
                        break;
                    case 2:
                        input = input.ToUpper();
                        break;
                    case 3:
                        input = new string(input.OrderBy(c => c).ToArray());
                        break;
                    case 4:
                        char[] array = input.ToCharArray();
                        Array.Reverse(array);
                        input =  new String(array);
                        break;
                    case 5:
                        input = Regex.Replace(input, @"\s+", "");
                        break;
                }
            }

            foreach (var op in layer2)
            {
                switch (op)
                {
                    case 1:
                        input = input.ToLower();
                        break;
                    case 2:
                        input = input.ToUpper();
                        break;
                    case 3:
                        input = new string(input.OrderBy(c => c).ToArray());
                        break;
                    case 4:
                        char[] array = input.ToCharArray();
                        Array.Reverse(array);
                        input = new String(array);
                        break;
                    case 5:
                        input = Regex.Replace(input, @"\s+", "");
                        break;
                }
            }

            foreach (var op in layer3)
            {
                switch (op)
                {
                    case 1:
                        input = input.ToLower();
                        break;
                    case 2:
                        input = input.ToUpper();
                        break;
                    case 3:
                        input = new string(input.OrderBy(c => c).ToArray());
                        break;
                    case 4:
                        char[] array = input.ToCharArray();
                        Array.Reverse(array);
                        input = new String(array);
                        break;
                    case 5:
                        input = Regex.Replace(input, @"\s+", "");
                        break;
                }
            }

            return input;
        }


        static void Main(string[] args)
        {
            showIntro();
            showUsage();
            var rez = getInput();

            while (rez[0] != 'q')
            {

                if (rez[0] == 'a' || rez[0] == 'A')
                {
                    showLayerSelect();
                    rez = getInput();
                   
                    if (rez[0] == '1' || rez[0] == '2' || rez[0] == '3')
                    {
                        showOperationTable();
                        int layer = int.Parse(rez[0].ToString());
                        
                            rez = getInput();
                            addOperation(rez, layer);
                    
                    }
                    else
                    {
                        showOutput();
                        showUsage();
                    }

                }
                else if (rez[0] == 'r' || rez[0] == 'R')
                {
                    showLayerSelect();
                    rez = getInput();

                    if (rez[0] == '1' || rez[0] == '2' || rez[0] == '3')
                    {
                        int layer = int.Parse(rez[0].ToString());
                        if (checkLayerSize(layer))
                        {
                            showLayerRemoveSelect(layer);
                            rez = getInput();
                            removeOperation(rez, layer);
                        }
                    }
                    else
                    {
                        showOutput();
                        showUsage();
                    }

                    
                }
                else if (rez[0] == 'p' || rez[0] == 'P')
                {
                    showProcessText();
                    rez = getInput();


                    int counter = 0;
                    string line;

                    try
                    {
                    // Read the file and display it line by line. 
                        System.IO.StreamReader file =
                        new System.IO.StreamReader(rez);
                        while ((line = file.ReadLine()) != null)
                        {
                            Console.WriteLine(processString(line));
                            counter++;
                        }

                        file.Close();
                        showFinisedProcessing(counter);

                    } catch
                    {
                        showInvalidPath();
                    }
                    

                }
                else if (rez[0] == 's' || rez[0] == 'S')
                {
                    showLayers();
                }
                else
                {
                    showOutput();
                    showUsage();
                }

                rez = getInput();
            }

        }
    }
}


