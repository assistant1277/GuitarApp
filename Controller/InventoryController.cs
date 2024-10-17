using GuitarApp.Exceptions;
using GuitarApp.Model;
using GuitarApp.Service;
using GuitarApp.Type;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Controller
{
    public class InventoryController
    {
        //create instance of InventoryService to manage instruments
        private readonly InventoryService inventoryService = new InventoryService();

        //method to search for instruments based on various specifications
        public List<Instrument> SearchInstruments(string builderInput, string modelInput, string typeInput, string backWoodInput, string topWoodInput, int numStrings)
        {
            ValidateBuilder(builderInput);
            ValidateModel(modelInput);
            ValidateType(typeInput);
            ValidateWoodType(backWoodInput);
            ValidateWoodType(topWoodInput);
            ValidateNumberOfStrings(numStrings);

            //build new instrument specification based on validated inputs
            var spec = new InstrumentSpecBuilder()
                .Builder(Enum.Parse<InstrumentSpecBuilderEnum>(builderInput))
                .Model(modelInput)
                .Type(Enum.Parse<InstrumentSpecType>(typeInput))
                .BackWood(Enum.Parse<InstrumentSpecWood>(backWoodInput))
                .TopWood(Enum.Parse<InstrumentSpecWood>(topWoodInput))
                .NumStrings(numStrings)
                .Build();

            //use inventory service to search for instruments matching the specification
            return inventoryService.SearchInstruments(spec);
        }

        //method to add new instrument to inventory
        public void AddInstrument(string typeInput, string serialNumber, double price, string builderInput, string modelInput, string backWoodInput, string topWoodInput, int numStrings)
        {
            ValidateBuilder(builderInput);
            ValidateModel(modelInput);
            ValidateType(typeInput);
            ValidateWoodType(backWoodInput);
            ValidateWoodType(topWoodInput);
            ValidateNumberOfStrings(numStrings);

            //build new instrument specification based on validated inputs
            var instrumentSpec = new InstrumentSpecBuilder()
                .Builder(Enum.Parse<InstrumentSpecBuilderEnum>(builderInput))
                .Model(modelInput)
                .Type(Enum.Parse<InstrumentSpecType>(typeInput))
                .BackWood(Enum.Parse<InstrumentSpecWood>(backWoodInput))
                .TopWood(Enum.Parse<InstrumentSpecWood>(topWoodInput))
                .NumStrings(numStrings)
                .Build();

            //create a new instrument using serial number,price and specification
            var instrument = new Instrument(serialNumber, price, instrumentSpec);
            //add new instrument to inventory
            inventoryService.AddInstrument(instrument);
        }

        //method to get instrument by it serial number
        public Instrument GetInstrumentBySerialNumber(string serialNumber)
        {
            //check if serial number is null or empty
            if (string.IsNullOrEmpty(serialNumber))
            {
                //if so throw an exception indicating that serial number is required
                throw new InvalidModelException("\nSerial number cannot be null or empty\n");
            }

            //use the inventory service to retrieve instrument by its serial number
            return inventoryService.GetInstrumentBySerialNumber(serialNumber);
        }

        //method to validate builder input
        private void ValidateBuilder(string builderInput)
        {
            //what below if statement does like it check if input is null or empty or if it cannot be parsed to a valid enum value
            //!Enum.TryParse<InstrumentSpecBuilderEnum>(builderInput, true, out _) what it does like ->
            //tries to convert builderInput string to corresponding value of InstrumentSpecBuilderEnum enumeration and 
            //builderInput -> means string to convert into enum
            //true -> this parameter indicates that parse operation should ignore case means making it case insensitive
            //out _ -> out parameter is used to store result of parse operation and we use _ as a discard means we dont care about actual enum value produced by parse operation
            // returns true if parsing was successful means builderInput matched one of the enum names and
            //false if the parsing failed means builderInput does not match any enum name
            if (string.IsNullOrEmpty(builderInput) || !Enum.TryParse<InstrumentSpecBuilderEnum>(builderInput, true, out _))
            {
                //throw an exception if validation fails
                throw new InvalidBuilderException("\nInvalid builder specified use FENDER/fender or GIBSON/gibson,etc\n");
            }
        }

        //method to validate the model input
        private void ValidateModel(string modelInput)
        {
            //check if input is null or empty
            if (string.IsNullOrEmpty(modelInput))
            {
                //throw an exception if validation fails
                throw new InvalidModelException("\nModel cannot be null or empty\n");
            }
        }

        //method to validate the instrument type input
        private void ValidateType(string typeInput)
        {
            //check if the typeInput string is null or empty then
            // try to convert typeInput into a valid InstrumentSpecType enum value
            // Enum.TryParse returns true if conversion is successful
            // true as the second argument means the parsing should ignore case means case-insensitive
            // out _ means the result of the parsing is ignored means we dont need to store the parsed value
            if (string.IsNullOrEmpty(typeInput) || !Enum.TryParse<InstrumentSpecType>(typeInput, true, out _))
            {
                //if either the input is empty or invalid throw an exception with specific message
                throw new InvalidTypeException("\nInvalid type specified use ELECTRIC/electric,ACOUSTIC/acoustic or MANDOLIN/mandolin, etc\n");
            }
        }

        //method to validate the wood type input
        private void ValidateWoodType(string woodTypeInput)
        {
            //check if the input is null or empty or if it cannot be parsed to a valid enum value
            // first step is -> Check if the woodTypeInput string is either null or empty
            // string.IsNullOrEmpty(woodTypeInput) returns true if woodTypeInput is null or an empty string
            // checks whether the user has provided any input for the wood type

            // second step is -> try to convert the woodTypeInput string into a valid enum value of type InstrumentSpecWood
            // Enum.TryParse attempts to match the input string [woodTypeInput] to a valid enum value.
            // 'true' argument makes the matching case-insensitive so it does not matter if the input is in uppercase or lowercase
            // out _ is used to ignore the parsed value means we don’t need to store it we just want to know if parsing is successful
            // ! checks if the parsing failed and if parsing fails the entire condition becomes true
            if (string.IsNullOrEmpty(woodTypeInput) || !Enum.TryParse<InstrumentSpecWood>(woodTypeInput, true, out _))
            {
                //throw an exception if the validation fails
                throw new InvalidWoodTypeException("\nInvalid wood type specified use ALDER/alder,MAHOGANY/mahogany or MAPLE/maple,etc\n");
            }
        }

        private void ValidateNumberOfStrings(int numStrings)
        {
            if (numStrings < 0)
            {
                throw new InvalidNumberOfStringsException("\nNumber of strings cannot be negative\n");
            }
        }
    }
}
