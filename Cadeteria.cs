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

    public bool AgregarPedido(string obs,string nombre,string direccion,string telefono,string datosReferencia)
    {
        bool bandera = false;
        Pedido pedido = new Pedido(obs,nombre,direccion,telefono,datosReferencia);
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

    public void EliminarPedido(int idPedido)
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
    public string ListarCadetes()
    {
        
        string devolver = "";
        foreach (var item in Cadetes)
        {
            devolver = devolver + "\n" + item.mostrarCadete();
        }
        return devolver;
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

    public int CantPedidos(enumEstado tipo)
    {
        int cant = 0;
        switch (tipo)
        {
            case enumEstado.pendiente:
                cant =  pedidos.Count(item => item.Estado == enumEstado.pendiente);
                break;

            case enumEstado.entregado:
                cant =  pedidos.Count(item => item.Estado == enumEstado.entregado);
                break;

            case enumEstado.cancelado:
                cant =  pedidos.Count(item => item.Estado == enumEstado.cancelado);
                break;
        }
        return cant;
    }

    public int CantPedidosEntregados(int idCadete)
    {
        return pedidos.Count(item => item.Estado == enumEstado.entregado && item.IdCadete == idCadete);
    }

    public int CantPedidosCancelados(int idCadete)
    {
        return pedidos.Count(item => item.Estado == enumEstado.cancelado && item.IdCadete == idCadete);
    }

    

    public string MostrarPedidos() // muestro los cadetes que tiene por lo menos un pedido y que esten pendiente
    {
        string devolver = "";
        foreach (var item in pedidos)
        {
            devolver = devolver + "\n" + item.MostrarPedido();
        }
        return devolver;
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
            infoCadete.EntregadosCadete = CantPedidosEntregados(item.Id);
            info.Add(infoCadete);
        }
        return info;
    }

    
    public int JornalACobrar(int idCadete)
    {
        return CantPedidosEntregados(idCadete) * 500;
    }

    public string MostrarPedidosSinAsignar()
    {   
        string devolver = "";
        foreach (var item in pedidos)
        {
            if (item.IdCadete == 0)
            {
                devolver = devolver + "\n" + item.MostrarPedido();
            }
        }
        return devolver;
    }
}