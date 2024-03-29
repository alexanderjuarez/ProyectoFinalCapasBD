﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODELS
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProyectoBDEntities : DbContext
    {
        public ProyectoBDEntities()
            : base("name=ProyectoBDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }
        public virtual DbSet<DetallePago> DetallePago { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<IngresoUsuarios> IngresoUsuarios { get; set; }
        public virtual DbSet<Presentacion> Presentacion { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<tipoLogin> tipoLogin { get; set; }
        public virtual DbSet<TipoP> TipoP { get; set; }
    
        public virtual ObjectResult<productos_Result> productos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<productos_Result>("productos");
        }
    
        public virtual ObjectResult<Nullable<int>> descontar(Nullable<int> id, Nullable<int> cantidad)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("descontar", idParameter, cantidadParameter);
        }
    
        public virtual ObjectResult<Facturacionxml_Result> Facturacionxml(string facturaxml, string detallexml, string pagoxml)
        {
            var facturaxmlParameter = facturaxml != null ?
                new ObjectParameter("facturaxml", facturaxml) :
                new ObjectParameter("facturaxml", typeof(string));
    
            var detallexmlParameter = detallexml != null ?
                new ObjectParameter("detallexml", detallexml) :
                new ObjectParameter("detallexml", typeof(string));
    
            var pagoxmlParameter = pagoxml != null ?
                new ObjectParameter("pagoxml", pagoxml) :
                new ObjectParameter("pagoxml", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Facturacionxml_Result>("Facturacionxml", facturaxmlParameter, detallexmlParameter, pagoxmlParameter);
        }
    
        public virtual ObjectResult<muestra_Result> muestra(string xml_estructura)
        {
            var xml_estructuraParameter = xml_estructura != null ?
                new ObjectParameter("xml_estructura", xml_estructura) :
                new ObjectParameter("xml_estructura", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<muestra_Result>("muestra", xml_estructuraParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> descontar1(Nullable<int> id, Nullable<int> cantidad)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("descontar1", idParameter, cantidadParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Descontar2(Nullable<int> id, Nullable<int> cantidad)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Descontar2", idParameter, cantidadParameter);
        }
    }
}
