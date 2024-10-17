using GuitarApp.Controller;
using GuitarApp.Exceptions;
using GuitarApp.Model;
using GuitarApp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Presentation
{
    public class ConsolePresentation
    {
        //created instance of InventoryController to handle instrument logic
        private static readonly InventoryController inventoryController = new InventoryController();

        public static void Start()
        {
            Console.WriteLine("***** Welcome to Guitar App *****\n");
            while (true)
            {
                Console.WriteLine("Select option ->");
                Console.WriteLine("1) Search for instrument");
                Console.WriteLine("2) Add new instrument");
                Console.WriteLine("3) Get instrument by serial number");
                Console.WriteLine("4) Exit");
                Console.Write("\nChoose option(1,2,3,4) -> ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        SearchAndDisplayInstruments();
                        break;

                    case "2":
                        AddNewInstrument();
                        break;

                    case "3":
                        GetInstrumentBySerialNumber();
                        break;

                    case "4":
                        return; 

                    default:
                        Console.WriteLine("\nInvalid option try again\n");
                        break;
                }
            }
        }

        //method to search for instruments based on user input
        private static void SearchAndDisplayInstruments()
        {
            try
            {
                Console.WriteLine("\nYou can write builder,type,back_wood,top_wood values in lowercase or uppercase also\n");
                Console.Write("Enter builder means (fender,gibson,etc) -> ");
                string builderInput = Console.ReadLine().ToUpper();

                Console.Write("Enter model -> ");
                string modelInput = Console.ReadLine();

                Console.Write("Enter type (electric,acoustic,mandolin,etc) -> ");
                string typeInput = Console.ReadLine().ToUpper();

                Console.Write("Enter back wood (alder,mahogany,maple,etc) -> ");
                string backWoodInput = Console.ReadLine().ToUpper();

                Console.Write("Enter top wood (alder,mahogany,maple,etc) -> ");
                string topWoodInput = Console.ReadLine().ToUpper();

                Console.Write("Enter number of strings -> ");
                int numStrings = Convert.ToInt32(Console.ReadLine());

                var matchedInstruments = inventoryController.SearchInstruments(builderInput, modelInput, typeInput, backWoodInput, topWoodInput, numStrings);

                if (matchedInstruments.Count == 0)
                {
                    Console.WriteLine("\nSorry we have nothing for you\n");
                }
                else
                {
                    foreach (var instrument in matchedInstruments)
                    {
                        var instrumentSpec = instrument.Spec;
                        Console.WriteLine($"\nYou might like this {instrumentSpec.Builder} {instrumentSpec.Model} \n" + 
                            $"{instrumentSpec.Type} guitar with {instrumentSpec.NumStrings} strings and \n" +
                            $"{instrumentSpec.BackWood} back and {instrumentSpec.TopWood} top and \n" +
                            $"you can have it for only {instrument.Price}\n");
                    }
                }
            }
            catch (InvalidBuilderException ex)
            {
                Console.WriteLine($"Error -> {ex.Message}");
            }
            catch (InvalidModelException ex)
            {
                Console.WriteLine($"Error -> {ex.Message}");
            }
            catch (InvalidTypeException ex)
            {
                Console.WriteLine($"Error -> {ex.Message}");
            }
            catch (InvalidWoodTypeException ex)
            {
                Console.WriteLine($"Error -> {ex.Message}");
            }
            catch (InvalidNumberOfStringsException ex)
            {
                Console.WriteLine($"Error -> {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error -> {ex.Message}");
            }
        }

        //method to add new instrument to the inventory
        private static void AddNewInstrument()
        {
            try
            {
                Console.WriteLine("\nYou can write builder,type,back_wood,top_wood values in lowercase or uppercase also\n");
                Console.Write("Enter serial number -> ");
                string serialNumber = Console.ReadLine();

                Console.Write("Enter price -> ");
                double price = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter builder (fender,gibson,etc) -> ");
                string builderInput = Console.ReadLine().ToUpper();

                Console.Write("Enter model -> ");
                string modelInput = Console.ReadLine();

                Console.Write("Enter type (electric,acoustic,mandolin,etc) -> ");
                string typeInput = Console.ReadLine().ToUpper();

                Console.Write("Enter back wood (alder,mahogany,maple,etc) -> ");
                string backWoodInput = Console.ReadLine().ToUpper();

                Console.Write("Enter top wood (alder,mahogany,maple,etc) -> ");
                string topWoodInput = Console.ReadLine().ToUpper();

                Console.Write("Enter number of strings -> ");
                int numStrings = Convert.ToInt32(Console.ReadLine());

                inventoryController.AddInstrument(typeInput, serialNumber, price, builderInput, modelInput, backWoodInput, topWoodInput, numStrings);
                Console.WriteLine("\nInstrument added successfully\n");
            }
            catch (InvalidBuilderException ex)
            {
                Console.WriteLine($"Error -> {ex.Message}");
            }
            catch (InvalidModelException ex)
            {
                Console.WriteLine($"Error -> {ex.Message}");
            }
            catch (InvalidTypeException ex)
            {
                Console.WriteLine($"Error -> {ex.Message}");
            }
            catch (InvalidWoodTypeException ex)
            {
                Console.WriteLine($"Error -> {ex.Message}");
            }
            catch (InvalidNumberOfStringsException ex)
            {
                Console.WriteLine($"Error -> {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error -> {ex.Message}");
            }
        }

        //method to get instrument by its serial number
        private static void GetInstrumentBySerialNumber()
        {
            try
            {
                Console.Write("Enter serial number -> ");
                string serialNumber = Console.ReadLine();

                var instrument = inventoryController.GetInstrumentBySerialNumber(serialNumber);

                if (instrument == null)
                {
                    Console.WriteLine($"\nInstrument with serial number {serialNumber} not found\n");
                }
                else
                {
                    var spec = instrument.Spec;
                    Console.WriteLine($"\nFound instrument -> {spec.Builder} {spec.Model} and \n" + 
                        $"{spec.Type} guitar with {spec.NumStrings} strings and \n" +
                        $"{spec.BackWood} back and {spec.TopWood} top and \n" +
                        $"price -> {instrument.Price}\n");
                }
            }
            catch (InvalidModelException ex)
            {
                Console.WriteLine($"Error -> {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error -> {ex.Message}");
            }
        }

    }
}
