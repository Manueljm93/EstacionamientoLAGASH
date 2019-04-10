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
                "Exit",
            };


            Console.CursorVisible = false;
            while (true)
            {
                
                string selectMenuItem = drawnMenu(menuItems);
                if (selectMenuItem == "Ingresa auto")
                {
                    Console.Clear();
                    estacionamiento.IngresoDetectado(); Console.Read();
                }
                else if (selectMenuItem == "Egresar auto")
                {
                    estacionamiento.EgresoDetectado(); Console.Read();
                }
                else if (selectMenuItem == "Exit")
                {
                    Environment.Exit(0);
                }
            }
        }

        private static void Tiempo(Estacionamiento estacionamiento)
        {
            DateTime Tiempo = DateTime.Now;

            if (Tiempo.ToString("HH:mm") == "00:00")
            {
                estacionamiento.FacturarEstadia();
                ServicioExterno.EnviarMail("Asunto Ejemplo", "Cuerpo Ejemplo", "email@ejemplo.com");
                Console.WriteLine("Correo enviado.");
                Console.ReadKey();
            }
        }

        private static string drawnMenu(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i == index)
                {
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

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo ckey = Console.ReadKey();
                if (ckey.Key == ConsoleKey.DownArrow)
                {
                    if (index == items.Count - 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
                else if (ckey.Key == ConsoleKey.UpArrow)
                {
                    if (index <= 0)
                    {
                        index = items.Count - 1;
                    }
                    else
                    {
                        index--;
                    }

                }
                else if (ckey.Key == ConsoleKey.Enter)
                {
                    return items[index];              
                }
                else
                {
                    return "";
                }
                

            }
            Console.ReadKey();
            Console.Clear();
            return "";
        }
    }
}