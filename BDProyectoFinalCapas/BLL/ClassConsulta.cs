using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Collections;

namespace BLL
{
   public class ClassConsulta
    {
      public IEnumerable sp_xmlM(string xml_muestra)
        {
            ClassTSQL Lg = new ClassTSQL();
            return Lg.sp_xmlmuestra(xml_muestra);
        }

        public IEnumerable sp_xmlD(int id, int cantidad)
        {
            ClassTSQL Lg = new ClassTSQL();
            return Lg.sp_xmldescontar(id, cantidad);
        }

        public IEnumerable sp_xmlF(string cadenaF, string cadenaD,string cadenaP)
        {
            ClassTSQL Lg = new ClassTSQL();
            return Lg.sp_xmlfacturacion(cadenaF,cadenaD,cadenaP);
        }
    }
}
