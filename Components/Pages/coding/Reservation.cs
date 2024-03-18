﻿using System;

namespace app.Components.Pages.coding

{
    internal partial class Reservation
    {
        
        public const int RECORD_SIZE = 201;

       
        private string code;            
        private string flightCode;      
        private string airline;         
        private string name;            
        private string citizenship;     
        private double cost;            
        private string active;          
        private string reservationCode; 
        private Flight flight;         

        
        public Reservation()
        {
        }
        public Reservation(string code, string flightCode, string airline, double cost, string name, string citizenship, string active)
        {
            this.code = code;
            this.flightCode = flightCode;
            this.airline = airline;
            this.name = name;
            this.citizenship = citizenship;
            this.cost = cost;
            this.active = active;
        }

        // Constructor with parameters
        public Reservation(string reservationCode, Flight flight, string name, string citizenship)
        {
            this.reservationCode = reservationCode;
            this.flight = flight;
            this.name = name;
            this.citizenship = citizenship;
        }

   
        public string Code { get => code; set => code = value; }
        public string FlightCode { get => flightCode; set => flightCode = value; }
        public string Airline { get => airline; set => airline = value; }
        public string Name { get => name; set => name = value; }
        public string Citizenship { get => citizenship; set => citizenship = value; }
        public double Cost { get => cost; set => cost = value; }
        public string Active { get => active; set => active = value; }

        
        public void SetName(string name)
        {
            
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            this.name = name;
        }

        
        public void SetCitizenship(string citizenship)
        {
          
            if (string.IsNullOrEmpty(citizenship))
            {
                throw new Exception(); 
            }

            this.citizenship = citizenship;
        }

        
        public string ToString()
        {
            return $"{Code}, {FlightCode}, {Airline}, {Cost}, {Name}, {Citizenship}, {Active}";
        }
    }
}
