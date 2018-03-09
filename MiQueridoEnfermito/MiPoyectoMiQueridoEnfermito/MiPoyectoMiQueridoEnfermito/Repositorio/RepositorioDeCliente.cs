using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPoyectoMiQueridoEnfermito.Repositorio
{
   public  class RepositorioDeCliente
    {
        ManejadorDeArchivos archivo;
        List<Nclientes> cat;
        public RepositorioDeCliente()
        {
            archivo = new ManejadorDeArchivos("clientes.txt");
            cat = new List<Nclientes>();
        }
        public bool AgregarCliente(Nclientes ca)
        {
            cat.Add(ca);
            bool resultado = ActualizarArchivo();
            cat = LeerCliente();
            return resultado;
        }
        public bool EliminarCliente(Nclientes ca)
        {
            Nclientes temporal = new Nclientes();
            foreach (var item in cat)
            {
                if (item.Nombre == ca.Nombre)
                {
                    temporal = item;
                }
            }
            cat.Remove(temporal);
            bool resultado = ActualizarArchivo();
            cat = LeerCliente();
            return resultado;
        }
        public bool ModificarCliente(Nclientes original, Nclientes modificado)
        {
            Nclientes temporal = new Nclientes();
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
            temporal.Estacionamiento = modificado.Estacionamiento;
            bool resultado = ActualizarArchivo();
            cat = LeerCliente();
            return resultado;
        }
        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (Nclientes item in cat)
            {
                datos += string.Format("{0}|{1}|{2}|{3}|{4}\n", item.Nombre, item.Direccion, item.RFC, item.Telefono, item.Estacionamiento);
            }
            return archivo.Guardar(datos);
        }
        public List<Nclientes> LeerCliente()
        {
            string datos = archivo.Leer();
            if (datos != null)
            {
                List<Nclientes> cate = new List<Nclientes>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    Nclientes a = new Nclientes()
                    {
                        Nombre = campos[0],
                        Direccion = campos[1],
                        RFC = campos[2],
                        Telefono = campos[3],
                        Estacionamiento = campos[4]

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
