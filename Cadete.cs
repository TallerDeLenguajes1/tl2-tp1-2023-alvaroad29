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

    public float JornalACobrar()
    {
        int entregados = 0;

        foreach (var item in pedidos)
        {
            if (item.Estado == enumEstado.entregado)
            {
                entregados++;
            }
        }
        return entregados * 500;
    }

    public void mostrarCadete()
    {
        
        System.Console.WriteLine("Nombre: " + Nombre);
        System.Console.WriteLine("Id cadete " + Id);
        System.Console.WriteLine("Direccion: " + Direccion);
        System.Console.WriteLine("Telefono: " + Telefono);
    }

    public void MostrarPedidos()
    {
        System.Console.WriteLine("Info cadete");
        mostrarCadete();
        System.Console.WriteLine("Info pedidos");
        foreach (var item in pedidos)
        {
            item.MostrarPedido();
        }
    }

    public Pedido DevolverPedido(int id)
    {
        return pedidos.SingleOrDefault(pedido => pedido.Nro == id);
    }

    //metodos publicos o privados con mayuscula
    //todo los atributos publicos con mayuscula
}