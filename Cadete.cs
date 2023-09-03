using EspacioPedido;
namespace EspacioCadete;
public class Cadete
{

    // Atributos
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> pedidos;

    // Propiedades
    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    // Metodos
    public Cadete(int id, string nombre, string direccion, string telefono) //constructor
    {
        pedidos = new List<Pedido>();
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }

    public void AgregarPedido(Pedido pedido)
    {
        pedidos.Add(pedido);
    }

    public int CantPedidos()
    {
        return pedidos.Count;
    }

    public int CantPedidosEntregados()
    {
        return pedidos.Count(pedido => pedido.Estado == enumEstado.entregado);
    }
    public void EliminarPedido(int nro)
    {
        for (int i = 0; i < pedidos.Count; i++)
        {
            if (pedidos[i].Nro == nro)
            {
                pedidos.RemoveAt(i);
                break;
            }
        }
    }
    public void CambiarEstadoPedido(int nro)
    {
        for (int i = 0; i < pedidos.Count; i++)
        {
            if (pedidos[i].Nro == nro)
            {
                pedidos[i].CambiarEstado();
                break;
            }
        }
    }

    public Pedido DevolverPedido(int idPedido)
    {
        return pedidos.SingleOrDefault(pedido => pedido.Nro == idPedido);
    }

    public float JornalACobrar()
    {
        return pedidos.Count(pedido => pedido.Estado == enumEstado.entregado) * 500;
    }

    public void mostrarCadete()
    {
        
        System.Console.WriteLine($"ID: {Id} -- Nombre: {Nombre} --  ");
        // System.Console.WriteLine("Direccion: " + Direccion);
        // System.Console.WriteLine("Telefono: " + Telefono);
    }

    public void MostrarPedidos()
    {
        System.Console.WriteLine("Info cadete");
        mostrarCadete();
        System.Console.WriteLine("Info pedidos");
        foreach (var item in pedidos) // solo muestro pedidos en estado pendiente
        {
            if (item.Estado == enumEstado.pendiente)
            {
                item.MostrarPedido();
            }
        }
    }

    public void MostrarPedidosPendientes()
    {
        System.Console.WriteLine("Info cadete");
        mostrarCadete();
        System.Console.WriteLine("Info pedidos");
        foreach (var item in pedidos)
        {
            if (item.Estado == enumEstado.pendiente)
            {
                item.MostrarPedido();
            }
        }
    }
    //metodos publicos o privados con mayuscula
    //todo los atributos publicos con mayuscula
}