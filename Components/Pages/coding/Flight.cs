using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace app.Components.Pages.coding
{
    internal partial class Flight
    {
        // Constants
        public const int RECORD_SIZE = 72;

        // Fields
        private string code;
        private string airline;
        private string from;
        private string to;
        private string weekday;
        private string time;
        private int seats;
        private double costPerSeat;

        // Constructors
        // Constructor with code parameter
        public Flight(string code)
        {
            this.code = code;
        }

        // Constructor with all parameters
        public Flight(string code, string airline, string from, string to, string weekday, string time, int seats, double costPerSeat)
        {
            this.code = code;
            this.airline = airline;
            this.from = from;
            this.to = to;
            this.weekday = weekday;
            this.time = time;
            this.seats = seats;
            this.costPerSeat = costPerSeat;
        }

        // Properties
        // Properties for accessing fields
        public string Code { get => code; set => code = value; }
        public string Airline { get => airline; set => airline = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public string Weekday { get => weekday; set => weekday = value; }
        public string Time { get => time; set => time = value; }
        public int Seats { get => seats; set => seats = value; }
        public double CostPerSeat { get => costPerSeat; set => costPerSeat = value; }

        // Methods

        // Overridden Equals method
        // Compares two Flight objects for equality
        public override bool Equals(object obj)
        {
            return obj is Flight flight &&
                   code == flight.code &&
                   airline == flight.airline &&
                   from == flight.from &&
                   to == flight.to &&
                   weekday == flight.weekday &&
                   time == flight.time &&
                   seats == flight.seats &&
                   costPerSeat == flight.costPerSeat &&
                   Code == flight.Code &&
                   Airline == flight.Airline &&
                   From == flight.From &&
                   To == flight.To &&
                   Weekday == flight.Weekday &&
                   Time == flight.Time &&
                   Seats == flight.Seats &&
                   CostPerSeat == flight.CostPerSeat;
        }

        // Check if flight is domestic
        // Checks if both departure and destination airports are domestic
        public bool isDomestic()
        {
            return From[0] == 'Y' && To[0] == 'Y';
        }

        // Override ToString method
        // Returns the flight code as a string representation
        public string toString()
        {
            return Code;
        }

        // Parse flight code
        // Parses the flight code to extract airline information
        private void ParseCode(string code)
        {
            // Validate the format of the flight code using a regular expression
            if (!Regex.Match(code, "^[A-Z]{2}-\\d{4}$").Success)
            {
                // Throw an exception if the code doesn't match the expected format
                throw new Exception("Invalid flight code format.");
            }

            // Extract the airline abbreviation from the flight code
            string abbreviation = code.Substring(0, 2);

            // Map airline abbreviations to full airline names
            switch (abbreviation)
            {
                case "OA":
                    airline = "Otto Airlines";
                    break;

                case "CA":
                    airline = "Conned Air";
                    break;

                case "TB":
                    airline = "Try a Bus Airways";
                    break;

                case "VA":
                    airline = "Vertical Airways";
                    break;

                default:
                    // Throw an exception if the abbreviation is not recognized
                    throw new Exception("Unknown airline abbreviation.");
            }
        }

        // Override GetHashCode method
        // Not implemented yet
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
