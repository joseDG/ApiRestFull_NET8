using CleanArchitecture.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Vehiculos
{
    //sealed - esta propiedad no permite que se herede
    public sealed class Vehiculo: Entity
    {
        //creacion del constructor
        public Vehiculo(
            Guid id,
            Modelo modelo,
            Vin vin,
            Moneda precio,
            Moneda mantenimiento,
            DateTime? fechaUltimaAlquiler,
            List<Accesorio> accesorios,
            Direccion? direccion
            ) : base(id) 
        {
            Modelo = modelo;
            Vin = vin;
            Precio = precio;
            Mantenimiento = mantenimiento;
            FechaUltimaAlquiler = fechaUltimaAlquiler;
            Accesorios = accesorios;
            Direccion = direccion;
        }

        public Modelo? Modelo { get; private set; }
        public Vin? Vin { get; private set; }
        public Direccion? Direccion { get;  private set; }
        public Moneda? Precio {  get; private set; }
        public Moneda? Mantenimiento { get; private set; }
        public DateTime? FechaUltimaAlquiler { get; private set; }
        public List<Accesorio> Accesorios {get; private set; } = new ();

    }
}
