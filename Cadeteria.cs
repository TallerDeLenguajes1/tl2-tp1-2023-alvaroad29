using EspacioCadete;
using EspacioPedido;
using EspacioInforme;

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

    public void EliminarPedido(int idPedido, Cadete cadete)
    {
        cadete.EliminarPedido(idPedido);
    }

    public void CambiarEstadoPedido(int idPedido, Cadete cadete)
    {
        cadete.CambiarEstadoPedido(idPedido);
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

    public Cadete DevolverCadetePedido(int idPedido) //devuelve el cadete a partir del id del pedido
    {
        foreach (var cadete in cadetes)
        {
            var pedidoEncontrado = cadete.DevolverPedido(idPedido);
            if (pedidoEncontrado != null)
            {
                return cadete;
            }
        }
        return null;
    }
    public Cadete DevolverCadete(int id) // devuelve cadete a parter de su id
    {
        return cadetes.SingleOrDefault(cadete => cadete.Id == id);
    }

    public Pedido DevolverPedido(int idPedido) // devuelve pedido a partir de un id
    {
        foreach (var cadete in cadetes)
        {
            var pedidoEncontrado = cadete.DevolverPedido(idPedido);
            if (pedidoEncontrado != null)
            {
                return pedidoEncontrado;
            }
        }
        return null;
    }

    public void MostrarPedidos() // muestro los cadetes que tiene por lo menos un pedido y que esten pendiente
    {
        foreach (var item in cadetes)
        {
            if (item.CantPedidos() > 0) // cadetes con pedidos cargados
            {
                item.MostrarPedidos();
            }
        }
        System.Console.WriteLine("\n");
    }

    public List<Informe> GenerarInforme()
    {
        List<Informe> info = new List<Informe>();
        Informe infoCadete;
        foreach (var item in cadetes)
        {
            infoCadete = new Informe();
            infoCadete.NombreCadete = item.Nombre;
            infoCadete.MontoGanado = item.JornalACobrar();
            infoCadete.EntregadosCadete = item.CantPedidosEntregados();
            info.Add(infoCadete);
        }
        return info;
    }
}