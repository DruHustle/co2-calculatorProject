using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using Calculator.Methods;

namespace Co2calculator
{
    class Program
    {
        static int Main(string[] args)
        {
            // Creating a CLI root command with some options.
            var rootCommand = new RootCommand
            {               
                new Option<string>(
                    "--transportation-method",
                    getDefaultValue: () => "",
                    description: "Different tansport methods in the database. They have a prescribed average emmision values"),
                new Option<string>(
                    "--unit-of-distance",
                    getDefaultValue: () => "km",
                    description: "The unit of distance is either m or km. The default unit is km."),
                new Option<double>(
                    "--distance",
                    getDefaultValue: () => 0,
                    description: "The distance covered during the travel."),
                new Option<string>(
                "--output",
                   getDefaultValue: () => "",
                   description: "The unit of mass in the output. It is either in kg or grams."),
            };

            //Description for the root command.
            rootCommand.Description = "The program returns the amount of CO2-equivalent caused when traveling a given distance using a given transportation method.";

            try
            {                
                rootCommand.Handler = CommandHandler.Create<string, string, double, string>((transportationMethod, unitOfDistance, distance, output) =>
                {
                    //Get the emission values from the CO2 data provided.
                    Methods.GetEmissionValue(transportationMethod, out int emissionValue);

                    //Check to see if the user has entered a positive distance value.
                    Methods.GetDistanceValidity(distance, out bool distaceValidTrip);

                    //Get the mass output unit to use. 
                    Methods.GetMassOutputUnit(transportationMethod, output, out bool unitOfDistanceValidTrip, out string massOutputUnits);

                    //Get multiplication factor to use for the mass calculations.
                    Methods.GetEmissionValue(massOutputUnits, out int massMultiplicationFactor);

                    //Get multiplication factor to use for the distance calculations.
                    Methods.GetDistanceMultiplicationFactor(unitOfDistance, out bool unitOfMassValidTrip, out double distanceMultiplicationFactor);

                    Methods.CheckTripValidity(distaceValidTrip, unitOfDistanceValidTrip, unitOfMassValidTrip, out bool validTrip);

                    //Calculate the CO2 emission.
                    Methods.CalculateEmission(emissionValue, distanceMultiplicationFactor, massMultiplicationFactor, distance, massOutputUnits, out double massEmission, validTrip);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }           

            // Parse the incoming args and invoke the handler
            return rootCommand.InvokeAsync(args).Result;
        }
    }
}
