using EspacioCadete;
using EspacioCadeteria;

namespace EspacioAccesoDatos;

public class AccesoDatos
{
    public Cadeteria cargarCadeteria(string nombreArchivo)
    {
        if (File.Exists(nombreArchivo))
        {
            using (StreamReader reader = new StreamReader(nombreArchivo))
            {
                string linea = reader.ReadLine(); //lee una linea
                Cadeteria cadeteria = new Cadeteria(linea.Split(",")[0],linea.Split(",")[1]);
                return cadeteria;
            }
            
        }
        else
        {
            System.Console.WriteLine($"El archivo {nombreArchivo} NO EXISTE");
            return null;
        }
    }

    public Cadeteria cargarCadetes(string nombreArchivo, Cadeteria cadeteria)
    {
        if (File.Exists(nombreArchivo))
        {
            using (StreamReader reader = new StreamReader(nombreArchivo))
            {
                Cadete cadete;
                string linea = "";
                string [] lineaSeparada;
                while ((linea = reader.ReadLine()) != null)
                {
                    lineaSeparada = linea.Split(",");
                    cadete = new Cadete(int.Parse(lineaSeparada[0]),lineaSeparada[1],lineaSeparada[2],lineaSeparada[3]);
                    cadeteria.AgregarCadete(cadete);
                }
                return cadeteria;
            }
        }
        else
        {
            System.Console.WriteLine($"El archivo {nombreArchivo} NO EXISTE");
            return null;
        }
    }
}