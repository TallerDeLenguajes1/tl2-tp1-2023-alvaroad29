using EspacioCliente;
namespace EspacioPedido;

public enum enumEstado{pendiente,entregado,cancelado};

public class Pedido
{
    // Atributos
    private int nro;
    private string obs;
    private Cliente cliente;
    private enumEstado estado;

    // Propiedades
    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public enumEstado Estado { get => estado; set => estado = value; }

    // Metodos

    public Pedido(string obs, string nombre, string direccion, string telefono, string datosReferenciaDireccion) // constructor
    {
        Estado = enumEstado.pendiente;
        Nro += 1;
        Obs = obs;
        cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
    }
    public void VerDireccionCliente()
    {
        System.Console.WriteLine(cliente.Direccion);
    }

    public void VerDatosCliente()
    {
        System.Console.WriteLine(cliente.Nombre);
        System.Console.WriteLine(cliente.Telefono);
        System.Console.WriteLine(cliente.Telefono);
    }

    public void CambiarEstado()
    {
        if (Estado != enumEstado.cancelado) //uso Estado o estado?
        {
            Estado = enumEstado.entregado;
        }
    }

    public void MostrarPedido()
    {
        System.Console.WriteLine("Numero de pedido: " + Nro);
        System.Console.WriteLine("Observaciones: " + Obs);
        System.Console.WriteLine("Estado pedido: " + Estado);
    }
}