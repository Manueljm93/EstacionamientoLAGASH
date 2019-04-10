using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLagash
{
    public interface IParkingLot
    {
        int CantidadEstacionados
        {
            get;
        }

        int EspaciosDisponibles
        {
            get;
        }
        int PrecioPorDia
        {
            get;
            set;
        }

        void IngresoDetectado();

        void EgresoDetectado();

        void FacturarEstadia();

    }
}

