using GuitarApp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Model
{
    public class InstrumentSpec
    {
        //read only property for builder of instrument like fender,gibson,ryan
        public InstrumentSpecBuilderEnum Builder { get; }
        public string Model { get; }

        //read only property for type of instrument like electric,acoustic
        public InstrumentSpecType Type { get; }

        //read only property for type of wood used on back of instrument
        public InstrumentSpecWood BackWood { get; }

        //read only property for type of wood used on top of instrument
        public InstrumentSpecWood TopWood { get; }
        public int NumStrings { get; }

        //constructor that initializes all properties of instrument specification
        public InstrumentSpec(
            InstrumentSpecBuilderEnum builder,
            string model,
            InstrumentSpecType type,
            InstrumentSpecWood backWood,
            InstrumentSpecWood topWood,
            int numStrings)
        {
            //assigns builder to property
            Builder = builder;

            //assigns model name to property
            Model = model;

            Type = type;

            // assigns back wood type to property
            BackWood = backWood;

            //assigns top wood type to property
            TopWood = topWood;

            //assigns number of strings to property
            NumStrings = numStrings;
        }
    }
}
