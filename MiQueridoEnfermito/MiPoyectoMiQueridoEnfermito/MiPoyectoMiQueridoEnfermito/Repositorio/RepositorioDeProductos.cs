using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPoyectoMiQueridoEnfermito.Repositorio
{
    public class RepositorioDeProductos
    {
        ManejadorDeArchivos archivo;
        List<Nproductos> cat;
        public RepositorioDeProductos()
        {
            archivo = new ManejadorDeArchivos("productos.txt");
            cat = new List<Nproductos>();
        }
        public bool AgregarProducto(Nproductos ca)
        {
            cat.Add(ca);
            bool resultado = ActualizarArchivo();
            cat = LeerProducto();
            return resultado;
        }

        

        public bool EliminarProducto(Nproductos ca)
        {
            Nproductos temporal = new Nproductos();
            foreach (var item in cat)
            {
                if (item.Nombre == ca.Nombre)
                {
                    temporal = item;
                }
            }
            cat.Remove(temporal);
            bool resultado = ActualizarArchivo();
            cat = LeerProducto();
            return resultado;
        }
        public bool ModificarProducto(Nproductos original, Nproductos modificado)
        {
            Nproductos temporal = new Nproductos();
            foreach (var item in cat)
            {
                if (original.Nombre == item.Nombre)
                {
                    temporal = item;
                }
            }

            temporal.Nombre = modificado.Nombre;
            temporal.Categoria = modificado.Categoria;
            temporal.Descripcion = modificado.Descripcion;
            temporal.PrecioCompra = modificado.PrecioCompra;
            temporal.PrecioVenta = modificado.PrecioVenta;
            bool resultado = ActualizarArchivo();
            cat = LeerProducto();
            return resultado;
        }
        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (Nproductos item in cat)
            {
                datos += string.Format("{0}|{1}|{2}|{3}|{4}\n", item.Nombre, item.Categoria, item.Descripcion, item.PrecioCompra, item.PrecioVenta);
            }
            return archivo.Guardar(datos);
        }
        public List<Nproductos> LeerProducto()
        {
            string datos = archivo.Leer();
            if (datos != null)
            {
                List<Nproductos> cate = new List<Nproductos>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    Nproductos a = new Nproductos()
                    {
                        Nombre = campos[0],
                        Categoria = campos[1],
                        Descripcion = campos[2],
                        PrecioCompra = campos[3],
                        PrecioVenta = campos[4]

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
