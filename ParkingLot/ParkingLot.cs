using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1;

public class ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            int totalSlots = 0;
            bool exit = false;
            
            while (!exit)
            {
                Console.Write("$ ");
                string[] input = Console.ReadLine().Split();

                switch (input[0])
                {
                    case "create_parking_lot":
                        totalSlots = int.Parse(input[1]);
                        Console.WriteLine("Create a parking lot with "+totalSlots+" slots");
                        break;
                    
                    case "park":
                        if (cars.Count() < totalSlots)
                        {
                            var newCar = new Car();
                            newCar.Number = input[1];
                            newCar.Color = input[2];
                            newCar.Type = input[3];
                            newCar.Slot = cars.Count() + 1;
                            cars.Add(newCar);
                            Console.WriteLine("Allocated slot number : "+newCar.Slot);
                        }
                        else
                        {
                            Console.WriteLine("Sorry, parking lot is full");
                        }
                        
                        break;
                    
                    case "leave":
                        int slot = int.Parse(input[1]);
                        Car leaveCar = cars.Find(x => x.Slot== slot);
                        if (leaveCar != null)
                        {
                            cars.Remove(leaveCar);
                            Console.WriteLine("Slot number "+slot+" is free");
                        }
                        else
                        {
                            Console.WriteLine("The slot is empty");
                        }
                        break;
                    
                    case "status":
                        Console.WriteLine("Slot\t Registration No.\t Type\t Color\t");
                        foreach (var car in cars)
                        {
                            Console.WriteLine("{0}\t {1}\t\t {2}\t {3}", car.Slot, car.Number, car.Type, car.Color);
                        }
                        break;
                    
                    case "type_of_vehicles":
                        string type = input[1];
                        int count = cars.Count(car => car.Type.ToLower() == type.ToLower());
                        Console.WriteLine(count);
                        break;
                    
                    case "registration_numbers_for_vehicles_with_ood_plate":
                        var listCarNumber = cars.Where( Car => int.Parse(Car.Number.Split("-")[1])%2 == 0).Select(car => car.Number);
                        Console.WriteLine(string.Join(",", listCarNumber));
                        break;
                    
                    case "registration_numbers_for_vehicles_with_event_plate":
                        var listCarNumberEvent = cars.Where( Car => int.Parse(Car.Number.Split("-")[1])%2 == 1).Select(car => car.Number);
                        Console.WriteLine(string.Join(",", listCarNumberEvent));
                        break;
                    
                    case "registration_numbers_for_vehicles_with_colour":
                        string carColor = input[1];
                        var colorReg = cars.Where(car => car.Color == carColor).Select(car => car.Number);
                        Console.WriteLine(string.Join(", ", colorReg));
                        break;
                    
                    case "slot_numbers_for_vehicles_with_colour":
                        string color = input[1];
                        var colorSlot = cars.Where(car => car.Color == color).Select(car => car.Slot);
                        Console.WriteLine(string.Join(", ", colorSlot));
                        break;
                    
                    case "slot_numbers_for_registration_number":
                        string number = input[1];
                        var numberSlot = cars.Where(car => car.Number == number).Select(car => car.Slot);
                        Console.WriteLine(string.Join(", ", numberSlot));
                        break;
                    
                    case "exit":
                        exit = true;
                        break;
                }
            }
        }
        
    }
    
    class Car
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        
        public int Slot { get; set; }
        
        public override string ToString()
        {
            return this.Slot+ " " + this.Number+ " " + this.Type + " " + this.Color;
        }
    }
    
}
