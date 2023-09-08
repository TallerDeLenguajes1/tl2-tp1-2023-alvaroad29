using EspacioPedido;
namespace EspacioCadete;
public class Cadete
{

    // Atributos
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;

    // Propiedades
    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    // Metodos
    public Cadete(int id, string nombre, string direccion, string telefono) //constructor
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }
    public string mostrarCadete()
    {
        string devolver = $"ID: {Id} -- Nombre: {Nombre} --  ";
        return devolver;
    }

}