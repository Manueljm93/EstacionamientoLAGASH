using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLagash
{
    class Program
    {
        private static int index = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a ParkingLot! Aprete cualquier teclada para ver el menu.");
            Console.ReadKey();
            Console.Clear();

            Estacionamiento estacionamiento = new Estacionamiento(10);

            List<string> menuItems = new List<string>()
            {
                "Ingresar auto",
                "Egresar auto",
                "Salir",
            };

            Console.CursorVisible = false;

            while (true)
            {
                string selectMenuItem = dibujarMenu(menuItems);
                if (selectMenuItem == "Egresar auto")
                {                    
                    estacionamiento.EgresoDetectado();
                    Console.ReadKey();                    
                }
                else if (selectMenuItem == "Ingresar auto")
                {
                    estacionamiento.IngresoDetectado();
                    Console.ReadKey();
                }
                else if (selectMenuItem == "Salir")
                {
                    Environment.Exit(0);                    
                }
            }
        }

        private static void EnviarFacturacion(Estacionamiento estacionamiento)
        {
            DateTime Tiempo = DateTime.Now;

            if (Tiempo.ToString("HH") == "00")
            {
                estacionamiento.FacturarEstadia();
                Console.WriteLine("Correo Enviado");
                Console.ReadKey();
            }
        }

        private static string dibujarMenu(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i == index)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine(items[i]);                    
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo ckey = Console.ReadKey();

            if (ckey.Key == ConsoleKey.DownArrow)
            {                
                if (index == items.Count - 1)
                {
                    index = 0; 
                }
                else { index++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0)
                {
                    index = items.Count - 1; 
                }
                else { index--; }
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                
                return items[index];
            }
            else
            {                
                return "";
            }            
            return "";
        }
    }
}