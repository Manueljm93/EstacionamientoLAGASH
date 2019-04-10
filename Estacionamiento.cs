using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLagash
{
    class Estacionamiento : IParkingLot
    {
        private int cantidadDeAutos;
        private int maximaCantidadAutos = 100;
        private int totalDeAutosIngresados;



        public Estacionamiento(int precioPorDia)
        {
            this.PrecioPorDia = precioPorDia;

        }
        // guarde el valor (actual) de los autos ingresados.
        public int CantidadEstacionados
        {
            get { return cantidadDeAutos; }
        }

        //reste el valor actual con el 100 y determine el numero disponible.
        public int EspaciosDisponibles
        {
            get { return maximaCantidadAutos - cantidadDeAutos; }
        }

        // devuelva valor por dia
        public int PrecioPorDia
        {
            get;

            set;
        }

        public void EgresoDetectado()
        {
            //cuando aprete en egreso reste -1.

            if (cantidadDeAutos == 0)
            {
                Console.WriteLine("No hay autos estacionados.");
            }
            else
            {
                --cantidadDeAutos;
                Console.WriteLine("Egreso un vehiculo." + " " + "Autos estacionados:" + " " + cantidadDeAutos);
            }

        }

        public void IngresoDetectado()
        {
            // Cuando aprete en ingresar sume +1.

            if (cantidadDeAutos == 100)
            {
                Console.WriteLine("Limite de capacidad.");
            }
            else
            {
                ++cantidadDeAutos;
                Console.WriteLine("Ingreso un vehiculo." + " " + "Autos estacionados:" + " " + cantidadDeAutos);
            }

            // Cuente la cantidad total de autos que ingresaron durante el dia.
            ++totalDeAutosIngresados;
        }
        // ingresa el valor por dia multiplicado por la cantidad de autos que hubo en el dia.
        public void FacturarEstadia()
        {
            int input = PrecioPorDia * totalDeAutosIngresados;

            Console.WriteLine("Factura de estadia" + input);
            Console.ReadKey();
        }
    }
}
