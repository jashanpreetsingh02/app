using System;
using System.Collections.Generic;
using System.IO;

namespace app.Components.Pages.coding
{
    internal class FlightManager
    {
        
        public static string WEEKDAY_ANY = "Any";
        public static string WEEKDAY_SUNDAY = "Sunday";
        public static string WEEKDAY_MONDAY = "Monday";
        public static string WEEKDAY_TUESDAY = "Tuesday";
        public static string WEEKDAY_WEDNESDAY = "Wednesday";
        public static string WEEKDAY_THURSDAY = "Thursday";
        public static string WEEKDAY_FRIDAY = "Friday";
        public static string WEEKDAY_SATURDAY = "Saturday";

        // File paths for data
        public static string FLIGHTS_TEXT = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\sidhu\source\repos\app\Components\Pages\files\flights.csv");
        public static string AIRPORTS_TEXT = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\sidhu\source\repos\app\Components\Pages\files\airports.csv");

        // Lists to store flights and airports
        public static List<Flight> flights = new List<Flight>();
        public static List<string> airports = new List<string>();

        // Default constructor to populate data
        public FlightManager()
        {
            // Populate airports and flights data
            PopulateAirports();
            PopulateFlights();
        }

        // Method to get all airports
        public List<string> getAirports()
        {
            return airports;
        }

        // Method to get all flights
        public static List<Flight> getFlights()
        {
            return flights;
        }

        // Method to find airport by code
        public string findAirportByCode(string code)
        {
            // Iterate through airports list to find matching airport code
            foreach (string airport in airports)
            {
                if (airport.Equals(code))
                    return airport;
            }
            return null; // Return null if airport code is not found
        }

        // Method to find flight by code
        public static Flight findFlightByCode(string code)
        {
            // Iterate through flights list to find matching flight code
            foreach (Flight flight in flights)
            {
                if (flight.Code.Equals(code))
                    return flight;
            }
            return null; // Return null if flight code is not found
        }

        // Method to find flights based on criteria
        public static List<Flight> findFlights(string from, string to, string weekday)
        {
            List<Flight> found = new List<Flight>();

            // Iterate through flights list to find flights matching criteria
            foreach (Flight flight in flights)
            {
                // Check if flight matches criteria (or criteria is 'Any')
                if ((weekday.Equals(WEEKDAY_ANY) || flight.Weekday.Equals(weekday)) &&
                    (to.Equals(WEEKDAY_ANY) || flight.To.Equals(to)) &&
                    (from.Equals(WEEKDAY_ANY) || flight.From.Equals(from)))
                {
                    found.Add(flight); // Add matching flight to the list
                }
            }
            return found; // Return list of matching flights
        }

        // Method to populate flights from CSV file
        private void PopulateFlights()
        {
            flights.Clear(); // Clear existing flights data

            try
            {
                // Read all lines from the flights text file
                string[] lines = File.ReadAllLines(FLIGHTS_TEXT);

                foreach (string line in lines)
                {
                    // Split the CSV line into parts
                    string[] parts = line.Split(",");

                    // If the number of parts is less than expected, skip this line
                    if (parts.Length < 8)
                    {
                        // Log or handle the invalid line
                        continue;
                    }

                    // Extract flight details from parts
                    string code = parts[0];
                    string airline = parts[1];
                    string from = parts[2];
                    string to = parts[3];
                    string weekday = parts[4];
                    string time = parts[5];
                    int seatsAvailable;
                    double pricePerSeat;

                    // Try parsing seatsAvailable and pricePerSeat
                    if (!int.TryParse(parts[6], out seatsAvailable) || !double.TryParse(parts[7], out pricePerSeat))
                    {
                        // Log or handle parsing errors
                        continue;
                    }

                    string fromAirport = findAirportByCode(from);
                    string toAirport = findAirportByCode(to);

                    try
                    {
                        // Create new Flight object and add to flights list
                        Flight flight = new Flight(code, airline, fromAirport, toAirport, weekday, time, seatsAvailable, pricePerSeat);
                        flights.Add(flight);
                    }
                    catch (Exception e) //InvalidFlightCodeException
                    {
                        // Handle exception
                    }
                }
            }
            catch (Exception e)
            {
                // Handle file reading or other exceptions
            }
        }


        // Method to populate airports from CSV file
        private void PopulateAirports()
        {
            try
            {
                // Clear existing airport data
                airports.Clear();

                // Read lines from the airports text file and populate airports list
                foreach (string line in File.ReadLines(AIRPORTS_TEXT))
                {
                    // Split the line by comma to extract airport details
                    string[] parts = line.Split(",");

                    // Extract airport code from the CSV line
                    string code = parts[0];

                    // Add airport code to the airports list
                    airports.Add(code);
                }
            }
            catch (Exception e)
            {
                // Handle exception
            }
        }

    }
}
