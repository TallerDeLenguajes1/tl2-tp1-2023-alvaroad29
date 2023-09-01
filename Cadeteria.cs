using EspacioCadete;
using EspacioPedido;
using EspacioCliente;

namespace EspacioCadeteria;
public class Cadeteria
{
    // Atributos
    private string nombre;
    private string telefono;
    private List<Cadete> cadetes;

    // Propiedades
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    // Metodos
    public Cadeteria(string nombre, string telefono) // constructor
    {
        cadetes = new List<Cadete>();
        Nombre = nombre;
        Telefono = telefono;
    }

    public void AgregarCadete(Cadete cadete)
    {
        cadetes.Add(cadete);
    }

    public void AgregarPedido(Pedido pedido, Cadete cadete)
    {
        cadete.AgregarPedido(pedido);
    }

    public void EliminarPedido(Pedido pedido, Cadete cadete)
    {
        cadete.EliminarPedido(pedido.Nro);
    }

    public void CambiarEstadoPedido(Pedido pedido, Cadete cadete)
    {
        cadete.CambiarEstadoPedido(pedido.Nro);
    }

    public void ReasignarPedido(Pedido pedido, Cadete cadeteEliminar, Cadete cadeteAgregar)
    {
        cadeteAgregar.AgregarPedido(pedido);
        cadeteEliminar.EliminarPedido(pedido.Nro);
    }
    public void ListarCadetes()
    {
        System.Console.WriteLine("======== INFORMACION CADETES DISPONIBLES =======");
        foreach (var item in cadetes)
        {
            item.mostrarCadete();
        }
        System.Console.WriteLine("\n");
    }

    public bool ComprobarCadete(int id) //comprueba si un cadete se encuentra en la lista a partir de su id
    {
        bool bandera = false;
        foreach (var item in cadetes)
        {
            if (item.Id == id)
            {
                bandera = true;
            }
        }
        return bandera;
    }

    public Pedido DevolverPedido(int id,Cadete cadete)
    {
        return cadete.DevolverPedido(id);
    }
    public Cadete DevolverCadete(int id)
    {
        return cadetes.SingleOrDefault(cadete => cadete.Id == id);
    }

    public void MostrarPedidos() // muestro los cadetes que tiene por lo menos un pedido
    {
        foreach (var item in cadetes)
        {
            if (item.CantPedidos() > 0)
            {
                item.MostrarPedidos();
            }
        }
        System.Console.WriteLine("=====================");
    }

    public void mostrarCadetes()
    {
        foreach (var item in cadetes)
        {
            item.mostrarCadete();
        }
    }

}