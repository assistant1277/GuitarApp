using GuitarApp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Model
{
    public class InstrumentSpecBuilder
    {
        //private variables to hold specifications for instrument
        private InstrumentSpecBuilderEnum builder; //holds the builder brand like fender,gibson,etc
        private string model; //holds model name of instrument
        private InstrumentSpecType type; //holds type of instrument like electric,acoustic,etc
        private InstrumentSpecWood backWood; //holds type of wood used for back
        private InstrumentSpecWood topWood;
        private int numStrings;

        //method to set builder and return builder instance for method chaining
        public InstrumentSpecBuilder Builder(InstrumentSpecBuilderEnum builder)
        {
            this.builder = builder; //assigns builder value
            return this; //returns current builder instance for chaining
        }

        public InstrumentSpecBuilder Model(string model)
        {
            this.model = model;
            return this;
        }

        public InstrumentSpecBuilder Type(InstrumentSpecType type)
        {
            this.type = type;
            return this;
        }

        //method to set back wood type and return builder instance for method chaining
        public InstrumentSpecBuilder BackWood(InstrumentSpecWood backWood)
        {
            this.backWood = backWood; //assigns back wood value
            return this; //returns current builder instance for chaining
        }

        public InstrumentSpecBuilder TopWood(InstrumentSpecWood topWood)
        {
            this.topWood = topWood;
            return this;
        }

        //method to set number of strings and return builder instance for method chaining
        public InstrumentSpecBuilder NumStrings(int numStrings)
        {
            this.numStrings = numStrings; //assigns number of strings
            return this; //returns current builder instance for chaining
        }

        //method to create InstrumentSpec object using the collected specifications
        public InstrumentSpec Build()
        {
            //creates and returns new InstrumentSpec instance with specified parameters
            return new InstrumentSpec(builder, model, type, backWood, topWood, numStrings);
        }
    }
}
