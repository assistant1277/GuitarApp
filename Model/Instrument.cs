using GuitarApp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Model
{
    public class Instrument
    {
        //read only property for serial number of instrument
        public string SerialNumber { get; }
        public double Price { get; }

        //read only property for instruments specifications like builder,type,wood_types,etc
        public InstrumentSpec Spec { get; }

        //constructor that initializes serial number,price and specifications for instrument
        public Instrument(string serialNumber, double price, InstrumentSpec spec)
        {
            //assigns serial number to property
            SerialNumber = serialNumber;

            //assigns price to property
            Price = price;

            //assigns instruments specifications to property
            Spec = spec; //Spec full form is Specification
        }
    }
}
