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
        private static bool interruptor = true;

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
                string selectMenuItem = "";
                selectMenuItem = dibujarMenu(menuItems);

                if (selectMenuItem == "Egresar auto")
                {
                    estacionamiento.EgresoDetectado();
                }
                else if (selectMenuItem == "Ingresar auto")
                {
                    estacionamiento.IngresoDetectado();

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
            if (interruptor == true)
            {
                Console.Clear();
                for (int i = 0; i < items.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(items[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(items[i]);
                    }
                }

                interruptor = false;
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
                    interruptor = true;
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
                    interruptor = true;
                }
                else if (ckey.Key == ConsoleKey.Enter)
                {
                    interruptor = true;
                    return items[index];
                }
            }
            return "";
        }
    }
}