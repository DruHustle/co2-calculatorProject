namespace Calculator.Units
{
    using System.ComponentModel;

    struct Units
    {  
        // Mass constants.
        [Description("kg")]
        public const double kg = 0.001;
        [Description("g")]
        public const double g = 1;

        //Length constants.
        [Description("km")]
        public const double km = 1;
        [Description("m")]
        public const double m = 0.001;
    }

}