namespace Calculator.Methods
{
    using System;
    using Calculator.Units;
    using System.Collections.Generic;
    

    public class Methods
    {
        public static void GetDistanceValidity(double distance, out bool distaceValidTrip)
        {
            //If no or negative distance value is added, prompt user to enter distance.
            if (distance <= 0)
            {
                distaceValidTrip = false;
                Console.WriteLine("Enter a distance value.");
            }
            else
            {
                distaceValidTrip = true;
            }
        }

        public static void GetMassMultiplicationFactor(string massOutputUnits, out double massMultiplicationFactor)
        {
            massMultiplicationFactor = 0;

            //Set the units of mass for calculations
            if (massOutputUnits == "kg")
            {
                massMultiplicationFactor = (double)Units.kg;
            }
            if (massOutputUnits == "g")
            {
                massMultiplicationFactor = (double)Units.g;
            }
        }

        public static void GetEmissionValue(string transportationMethod, out int emissionValue)
        {
            emissionValue = 0;

            // A dictionary to store the vehicle emmission data.
            IDictionary<string, int> vehicleEmissions = new Dictionary<string, int>
            {
                //Small sized car emissions in grams:
                { "small-diesel-car", 142 },
                { "small-petrol-car", 154 },
                { "small-plugin-hybrid-car", 73 },
                { "small-electric-car", 50 },

                //Medium sized car emissions in grams:
                { "medium-diesel-car", 171 },
                { "medium-petrol-car", 192 },
                { "medium-plugin-hybrid-car", 110 },
                { "medium-electric-car", 58 },

                //Large car emissions in grams:
                { "large-diesel-car", 209 },
                { "large-petrol-car", 282 },
                { "large-plugin-hybrid-car", 126 },
                { "large-electric-car", 73 },

                //Bus emissions in grams:
                { "bus", 27 },

                //Train emissions in grams:
                { "train", 6 }

            };

            if (transportationMethod == "")
            {
                Console.Write("Enter a transport method.");
            }
            else if (transportationMethod is string)
            {
                try
                {
                    vehicleEmissions.TryGetValue(transportationMethod, out emissionValue);
                }
                catch (KeyNotFoundException)
                {
                    Console.Write($"The {transportationMethod} is not a valid input.");
                }
            }
        }

        public static void GetDistanceMultiplicationFactor(string unitOfDistance, out bool unitOfDistanceValidTrip, out double distanceMultiplicationFactor)
        {
            distanceMultiplicationFactor = 0;
            unitOfDistanceValidTrip = true;

            //Check the unit of distance
            if (unitOfDistance == "km")
            {
                distanceMultiplicationFactor = (double)Units.km;
            }
            else if (unitOfDistance == "m")
            {
                distanceMultiplicationFactor = (double)Units.m;
            }
            else
            {
                unitOfDistanceValidTrip = false;
                Console.Write($"{unitOfDistance} is not a valid input for unit of distance.");
            }
        }

        public static void GetMassOutputUnit(string transportationMethod, string output, out bool unitOfMassValidTrip, out string massOutputUnits)
        {
            massOutputUnits = "";

            //Default unit for mass is kg, except for train transportation method.
            //If the method is train, default units are grams but should be overriden if the output is set by user to kg.
            if ((output == "kg") || (output == "g") || (output == ""))
            {
                unitOfMassValidTrip = true;
                if (transportationMethod == "train")
                {
                    massOutputUnits = "g";

                    if (output == "kg")
                    {
                        massOutputUnits = "kg";
                    }
                }
                else
                {
                    massOutputUnits = "kg";
                }
            }
            else
            {
                unitOfMassValidTrip = false;
                Console.Write($"{output} is not a valid input.");
            }

        }

        public static void CheckTripValidity(bool distaceValidTrip, bool unitOfDistanceValidTrip, bool unitOfMassValidTrip, out bool validTrip)
        {
            validTrip = distaceValidTrip && unitOfDistanceValidTrip && unitOfMassValidTrip;
        }

        public static void CalculateEmission(double emissionValue, double distanceMultiplicationFactor, double massMultiplicationFactor, double distance, string massOutputUnits, out double massEmission, bool validTrip)
        {
            //Calculate the CO2-equivalent
            massEmission = emissionValue * distanceMultiplicationFactor * massMultiplicationFactor * distance;
            massEmission = Math.Round(massEmission, 1);

            if (validTrip == true)
            {
                Console.WriteLine($"Your trip caused {massEmission}{massOutputUnits} of CO2 - equivalent.");
            }
        }

    }
}
