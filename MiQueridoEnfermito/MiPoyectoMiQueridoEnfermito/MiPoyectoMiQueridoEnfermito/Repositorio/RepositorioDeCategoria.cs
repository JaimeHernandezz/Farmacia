using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPoyectoMiQueridoEnfermito.Repositorio
{

    public class RepositorioDeCategoria
    {
        ManejadorDeArchivos archivo;
        List<Ncategoria> cat;
        public RepositorioDeCategoria()
        {
            archivo = new ManejadorDeArchivos("categoria.txt");
            cat = new List<Ncategoria>();
        }

        public bool AgregarCategoria(Ncategoria ca)
        {
            cat.Add(ca);
            bool resultado = ActualizarArchivo();
            cat = LeerCategoria();
            return resultado;
        }

        public bool EliminarCategoria(Ncategoria ca)
        {
            Ncategoria temporal = new Ncategoria();
            foreach (var item in cat)
            {
                if (item.TipoDecategoria == ca.TipoDecategoria)
                {
                    temporal = item;
                }
            }
            cat.Remove(temporal);
            bool resultado = ActualizarArchivo();
            cat = LeerCategoria();
            return resultado;
        }

        public bool ModificarCategoria(Ncategoria original, Ncategoria modificado)
        {
            Ncategoria temporal = new Ncategoria();
            foreach (var item in cat)
            {
                if (original.TipoDecategoria == item.TipoDecategoria)
                {
                    temporal = item;
                }
            }
            
            temporal.TipoDecategoria = modificado.TipoDecategoria;
            bool resultado = ActualizarArchivo();
            cat = LeerCategoria();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (Ncategoria item in cat)
            {
                datos += string.Format("{0}\n", item.TipoDecategoria);
            }
            return archivo.Guardar(datos);
        }
        public List<Ncategoria> LeerCategoria()
        {
            string datos = archivo.Leer();
            if (datos != null)
            {
                List<Ncategoria> cate = new List<Ncategoria>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    Ncategoria a = new Ncategoria()
                    {
                        TipoDecategoria = campos[0]
                        
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
