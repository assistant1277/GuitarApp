using GuitarApp.Model;
using GuitarApp.Type;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Service
{
    public class InventoryService
    {
        //private list to store instruments in inventory
        private readonly List<Instrument> instruments;

        //constructor initializes instrument list
        public InventoryService()
        {
            instruments = new List<Instrument>(); //create new list of instruments
        }

        //method to add new instrument to inventory
        public void AddInstrument(Instrument instrument)
        {
            instruments.Add(instrument); //add instrument to list
        }

        public List<Instrument> SearchInstruments(InstrumentSpec spec)
        {
            //create list to store matched instruments
            var matchedInstruments = new List<Instrument>();

            //loop through all instruments in inventory
            foreach (var instrument in instruments) 
            {
                //check if current instrument matches specified criteria
                if (Matches(instrument.Spec, spec))
                {
                    matchedInstruments.Add(instrument); //add matched instrument to list
                }
            }
            return matchedInstruments; //return list of matched instruments
        }

        public Instrument GetInstrumentBySerialNumber(string serialNumber)
        {
            //find and return instrument with specified serial number
            return instruments.Find(instr => instr.SerialNumber == serialNumber);
        }

        public bool Matches(InstrumentSpec instrumentSpec, InstrumentSpec otherSpec)
        {
            if (otherSpec == null) return false; //return false if other specification is null

            //check if two instrument specifications match based on various criteria
            //how it works like Compare builders for equality then check if instrumentSpec.Model is not null
            //if it is not null compare the lowercase version of both Models
            //if instrumentSpec.Model is null check if otherSpec.Model is also null
            //then compare types for equality then compare backwoods for equality then compare topwoods for equality then compare number of strings for equality
            return instrumentSpec.Builder == otherSpec.Builder && 
                (instrumentSpec.Model != null ? instrumentSpec.Model.ToLower() == otherSpec.Model?.ToLower() : otherSpec.Model == null) && 
                instrumentSpec.Type == otherSpec.Type && 
                instrumentSpec.BackWood == otherSpec.BackWood && 
                instrumentSpec.TopWood == otherSpec.TopWood && 
                instrumentSpec.NumStrings == otherSpec.NumStrings;
        }
    }
}
