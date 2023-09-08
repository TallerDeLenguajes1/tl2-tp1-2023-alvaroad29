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

    private int idCadete;

    // Propiedades
    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public enumEstado Estado { get => estado; set => estado = value; }
    public int IdCadete { get => idCadete; set => idCadete = value; }

    // Metodos

    private static int numPedido = 1;
    public Pedido(string obs, string nombre, string direccion, string telefono, string datosReferenciaDireccion) // constructor
    {
        IdCadete = 0; // valor por defecto (sin cadete asignado)
        Estado = enumEstado.pendiente;
        Nro = numPedido++;
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

    public string MostrarPedido()
    {
        string devolver = $"Numero de pedido: {Nro} -- Observaciones: {Obs} -- Estado: {Estado}";
        return devolver;
    }
}