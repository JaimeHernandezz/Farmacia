using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPoyectoMiQueridoEnfermito.Repositorio
{
    public class RepositorioDeEmpleado
    {
        ManejadorDeArchivos archivo;
        List<Nempleados> cat;
        public RepositorioDeEmpleado()
        {
            archivo = new ManejadorDeArchivos("empleados.txt");
            cat = new List<Nempleados>();
        }
        public bool AgregarEmpleado(Nempleados ca)
        {
            cat.Add(ca);
            bool resultado = ActualizarArchivo();
            cat = LeerEmpleado();
            return resultado;
        }
        public bool EliminarEmpleado(Nempleados ca)
        {
            Nempleados temporal = new Nempleados();
            foreach (var item in cat)
            {
                if (item.Nombre == ca.Nombre)
                {
                    temporal = item;
                }
            }
            cat.Remove(temporal);
            bool resultado = ActualizarArchivo();
            cat = LeerEmpleado();
            return resultado;
        }
        public bool ModificarEmpleado(Nempleados original, Nempleados modificado)
        {
            Nempleados temporal = new Nempleados();
            foreach (var item in cat)
            {
                if (original.Nombre == item.Nombre)
                {
                    temporal = item;
                }
            }

            temporal.Nombre = modificado.Nombre;
            temporal.Direccion = modificado.Direccion;
            temporal.RFC = modificado.RFC;
            temporal.Telefono = modificado.Telefono;
            temporal.Email = modificado.Email;
            temporal.Matricula = modificado.Matricula;
            bool resultado = ActualizarArchivo();
            cat = LeerEmpleado();
            return resultado;
        }
        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (Nempleados item in cat)
            {
                datos += string.Format("{0}|{1}|{2}|{3}|{4}\n", item.Nombre, item.Direccion, item.RFC, item.Telefono, item.Email, item.Matricula);
            }
            return archivo.Guardar(datos);
        }
        public List<Nempleados> LeerEmpleado()
        {
            string datos = archivo.Leer();
            if (datos != null)
            {
                List<Nempleados> cate = new List<Nempleados>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    Nempleados a = new Nempleados()
                    {
                        Nombre = campos[0],
                        Direccion = campos[1],
                        RFC = campos[2],
                        Telefono = campos[3],
                        Email = campos[4],
                        Matricula = campos[4]

                    };
                    cate.Add(a);
                }
                cat = cate;
                return cate;
            }
            else
            {
                return null;
            }
        }



    }
}
