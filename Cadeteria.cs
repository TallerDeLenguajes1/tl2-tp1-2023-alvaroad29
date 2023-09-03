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
    private List<Pedido> pedidos;

    // Propiedades
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }

    // Metodos
    public Cadeteria(string nombre, string telefono) // constructor
    {
        pedidos = new List<Pedido>();
        Cadetes = new List<Cadete>();
        Nombre = nombre;
        Telefono = telefono;
    }

    public void AgregarCadete(Cadete cadete)
    {
        Cadetes.Add(cadete);
    }

    public bool AgregarPedido(Pedido pedido)
    {
        bool bandera = false;
        if (pedido != null)
        {
            pedidos.Add(pedido);
            bandera = true;
        }
        return bandera;
    }

    public bool AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        bool bandera = false;
        var pedido = DevolverPedido(idPedido);
        if (pedido != null)
        {
            pedido.IdCadete = idCadete;
            bandera = true;
        }
        return bandera;
    }

    public void EliminarPedido(int idPedido, Cadete cadete)
    {
        pedidos.RemoveAll(pedido => pedido.Nro == idPedido);
    }

    public bool CambiarEstadoPedido(int idPedido)
    {
        bool bandera = false; 
        var pedido = pedidos.FirstOrDefault(pedido => pedido.Nro == idPedido);
        if (pedido != null && pedido.Estado == enumEstado.pendiente) //solo cambia pedido que este y 
        {
            pedido.CambiarEstado();
            bandera = true;
        }
        return bandera;
    }

    public void ReasignarPedido(Pedido pedido, int idCadeteAgregar)
    {
        pedido.IdCadete = idCadeteAgregar;
    }
    public void ListarCadetes()
    {
        System.Console.WriteLine("======== INFORMACION CADETES DISPONIBLES =======");
        foreach (var item in Cadetes)
        {
            item.mostrarCadete();
        }
        System.Console.WriteLine("\n");
    }

    public Cadete DevolverCadetePedido(int idPedido) //devuelve el cadete a partir del id del pedido
    {
        var pedido = DevolverPedido(idPedido);
        return DevolverCadete(pedido.IdCadete);
    }
    public Cadete DevolverCadete(int id) // devuelve cadete a parter de su id
    {
        return Cadetes.SingleOrDefault(cadete => cadete.Id == id);
    }

    public Pedido DevolverPedido(int idPedido) // devuelve pedido a partir de un id
    {
        return pedidos.SingleOrDefault(pedido => pedido.Nro == idPedido);;
    }

    public int CantPedidos()
    {
        return pedidos.Count();
    }

    public void MostrarPedidos() // muestro los cadetes que tiene por lo menos un pedido y que esten pendiente
    {
        foreach (var item in pedidos)
        {
            item.MostrarPedido();
        }
        System.Console.WriteLine("\n");
    }

    public List<Informe> GenerarInforme()
    {
        List<Informe> info = new List<Informe>();
        Informe infoCadete;
        foreach (var item in Cadetes)
        {
            infoCadete = new Informe();
            infoCadete.NombreCadete = item.Nombre;
            infoCadete.MontoGanado = JornalACobrar(item.Id);
            infoCadete.EntregadosCadete = CantidadPedidosEntregados(item.Id);
            info.Add(infoCadete);
        }
        return info;
    }

    public int CantidadPedidosEntregados(int idCadete)
    {
        return pedidos.Count(item => item.Estado == enumEstado.entregado && item.IdCadete == idCadete);
    }
    public int JornalACobrar(int idCadete)
    {
        return CantidadPedidosEntregados(idCadete) * 500;
    }

    public void MostrarPedidosSinAsignar()
    {   
        foreach (var item in pedidos)
        {
            if (item.IdCadete == 0)
            {
                item.MostrarPedido();
            }
        }
        System.Console.WriteLine("\n");
    }
}