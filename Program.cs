using EspacioCadeteria;
using EspacioCadete;
using EspacioPedido;
using EspacioCliente;
using EspacioAccesoDatos;

internal class Program
{
    private static void Main(string[] args)
    {
        // cargo los datos
        AccesoDatos cargarDatos = new AccesoDatos(); // para cargar los datos

        Cadeteria cadeteria = cargarDatos.cargarCadeteria("infoCadeteria.csv"); // cargo datos sobre cadeteria
        cadeteria = cargarDatos.cargarCadetes("infoCadetes.csv",cadeteria); // cargo los datos de cadetes

        //List<Pedido> pedidosTomados = new List<Pedido>();
        Pedido pedido = null;
        Cadete cadete;
        string nombre,direccion,telefono,datosReferencia,obs;
        // interfaz

        int op = 0,  idCadete = 0, idPedido = 0;
        do
        {
            do
            {
                Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><>");
                Console.WriteLine("<>   Ingrese la operacion a realizar:       <>");
                Console.WriteLine("<>   0-Salir                                <>");
                Console.WriteLine("<>   1-Dar alta pedido                      <>");
                Console.WriteLine("<>   2-Asigna pedido a cadete               <>");
                Console.WriteLine("<>   3-Cambiar estado pedido                <>");
                Console.WriteLine("<>   4-Reasignar pedido                     <>");
                Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><>");
            } while (!int.TryParse(Console.ReadLine(),out op) || op < 0 || op > 4);

            switch (op)
            {
                case 1:
                    System.Console.WriteLine("Info Pedido:");
                    System.Console.Write("Nombre: ");
                    nombre = Console.ReadLine();
                    System.Console.Write("Direccion: ");
                    direccion = Console.ReadLine();
                    System.Console.Write("Referencias direccion: ");
                    datosReferencia = Console.ReadLine();
                    System.Console.Write("Telefono: ");
                    telefono = Console.ReadLine();
                    System.Console.Write("Observaciones pedido: ");
                    obs = Console.ReadLine();
                    pedido = new Pedido(obs,nombre,direccion,telefono,datosReferencia);
                    break;

                case 2:
                    if (pedido != null)
                    {
                        cadeteria.ListarCadetes();
                        do
                        {
                            Console.WriteLine("# Id del cadete: ");
                        } while (!int.TryParse(Console.ReadLine(),out idCadete) || cadeteria.DevolverCadete(idCadete) == null);
                        cadeteria.AgregarPedido(pedido, cadeteria.DevolverCadete(idCadete));
                    }
                    else
                    {
                        System.Console.WriteLine("NO HAY UN PEDIDO CARGADOS");
                    }
                    break;
                case 3:
                    cadeteria.ListarCadetes(); // listo cadetes
                    do
                    {
                        Console.WriteLine("# Id del cadete con el pedido a cambiar: ");
                    } while (!int.TryParse(Console.ReadLine(),out idCadete) || cadeteria.DevolverCadete(idCadete) == null);

                    cadeteria.DevolverCadete(idCadete).MostrarPedidos(); //muestro pedidos de ese cadete
                    do
                    {
                        Console.WriteLine("# Id del pedido: ");
                    } while (!int.TryParse(Console.ReadLine(),out idPedido) || cadeteria.DevolverPedido(idPedido,cadeteria.DevolverCadete(idCadete)) == null); // control de pedido
                    cadeteria.CambiarEstadoPedido(cadeteria.DevolverPedido(idPedido,cadeteria.DevolverCadete(idCadete)),cadeteria.DevolverCadete(idCadete));
                    break;

                case 4:
                    break;
            }
    
        } while (op != 0);
    }
}

//las cosas que son calculos, calcularlas en el momentos en q se pise, Mientras se pueda

