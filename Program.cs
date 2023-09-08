using EspacioCadeteria;
using EspacioCadete;
using EspacioPedido;
using EspacioInforme;
using EspacioAccesoDatos;

internal class Program
{
    private static void Main(string[] args)
    {
        // cargo los datos
        AccesoADatos cargarDatos; 
        Cadeteria cadeteria = null; 
        int op2;
        do
        {
            System.Console.WriteLine("Cargar datos desde: [1] CSV / [2] JSON");
        } while (!int.TryParse(Console.ReadLine(),out op2) || op2 < 1 || op2 > 2);

        switch (op2)
        {
            case 1:
                cargarDatos = new AccesoCSV(); // para cargar los datos
                cadeteria = cargarDatos.cargarCadeteria("infoCadeteria.csv"); // cargo datos sobre cadeteria
                cadeteria = cargarDatos.cargarCadetes("infoCadetes.csv",cadeteria); // cargo los datos de cadetes
                break;
            case 2:
                cargarDatos = new AccesoJSON(); 
                cadeteria = cargarDatos.cargarCadeteria("infoCadeteria.json"); 
                cadeteria = cargarDatos.cargarCadetes("infoCadetes.json",cadeteria); 
                break;
        }



        Cadete cadete;
        string nombre,direccion,telefono,datosReferencia,obs;

        int op = 0,  idCadete = 0, idCadete2 = 0, idPedido = 0;
        do
        {
            do
            {
                Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><>");
                Console.WriteLine("<>   Ingrese la operacion a realizar:       <>");
                Console.WriteLine("<>   0-Salir                                <>");
                Console.WriteLine("<>   1-Agregar pedido                       <>");
                Console.WriteLine("<>   2-Asignar pedido                       <>");
                Console.WriteLine("<>   3-Cambiar estado pedido                <>");
                Console.WriteLine("<>   4-Reasignar pedido                     <>");
                Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><>");
            } while (!int.TryParse(Console.ReadLine(),out op) || op < 0 || op > 4);

            switch (op)
            {
                case 1:
                    Console.WriteLine("### Info cliente ###");
                    System.Console.Write("Nombre: ");
                    nombre = Console.ReadLine();
                    System.Console.Write("Direccion: ");
                    direccion = Console.ReadLine();
                    System.Console.Write("Referencias direccion: ");
                    datosReferencia = Console.ReadLine();
                    System.Console.Write("Telefono: ");
                    telefono = Console.ReadLine();
                    System.Console.WriteLine("### Info pedido ###");
                    System.Console.Write("Observaciones pedido: ");
                    obs = Console.ReadLine();

                    cadeteria.AgregarPedido(obs,nombre,direccion,telefono,datosReferencia);
                    System.Console.WriteLine(">>> PEDIDO AGREGADO <<<");
                    break;

                case 2:

                    if (cadeteria.CantPedidos() > 0)
                    {
                        System.Console.WriteLine("Seleccione el pedido: ");

                        System.Console.WriteLine(cadeteria.MostrarPedidosSinAsignar());

                        do
                        {
                            Console.WriteLine("# Id del pedido: ");
                        } while (!int.TryParse(Console.ReadLine(),out idPedido) || cadeteria.DevolverPedido(idPedido) == null); // control de pedido


                        System.Console.WriteLine("\n### Seleccione un cadete ###");
                        System.Console.WriteLine(cadeteria.ListarCadetes());

                        do
                        {
                            Console.WriteLine("# Id del cadete: ");
                        } while (!int.TryParse(Console.ReadLine(),out idCadete) || cadeteria.DevolverCadete(idCadete) == null);

                        cadeteria.AsignarCadeteAPedido(idPedido,idCadete);
                    }
                    else
                    {
                        System.Console.WriteLine("No hay pedidos cargados");
                    }
                    break;

                case 3:
                    System.Console.WriteLine("== Pedidos pendientes ==");
                    System.Console.WriteLine(cadeteria.MostrarPedidos());

                    do
                    {
                        Console.WriteLine("# Id del pedido pendiente: ");
                    } while (!int.TryParse(Console.ReadLine(),out idPedido) || !cadeteria.CambiarEstadoPedido(idPedido)); // control de pedido

                    System.Console.WriteLine(">> Pedido actualizado <<");
                    break;

                case 4:
                    System.Console.WriteLine("== Lista de cadetes y sus pedidos pendientes ==");
                    cadeteria.MostrarPedidos();
                    do
                    {
                        Console.WriteLine("# Id del pedido a reasignar: ");
                    } while (!int.TryParse(Console.ReadLine(),out idPedido) || cadeteria.DevolverPedido(idPedido) == null); // control de pedido

                    System.Console.WriteLine("Seleccione el cadete");
                    cadeteria.ListarCadetes();

                    do
                    {
                        Console.WriteLine("# Id del cadete a asignar el pedido: ");
                    } while (!int.TryParse(Console.ReadLine(),out idCadete) || cadeteria.DevolverCadete(idCadete) == null);

                    cadeteria.ReasignarPedido(cadeteria.DevolverPedido(idPedido), idCadete);
                    break;
            }
    
        } while (op != 0);

        List<Informe> info = cadeteria.GenerarInforme();

        MostrarInforme(info);
    }

    private static void MostrarInforme(List<Informe> info){
        System.Console.WriteLine("############ INFORME #########");
        foreach (var item in info)
        {
            System.Console.WriteLine($"Nombre cadete: {item.NombreCadete} \t Total envios: {item.EntregadosCadete} \t Monto ganado: {item.MontoGanado}");
        }
        System.Console.WriteLine($"\t Total de envios realizados: {info.Sum(x => x.EntregadosCadete)}");
        System.Console.WriteLine($"\t Total monto ganado : {info.Sum(x => x.MontoGanado)}");
        System.Console.WriteLine($"\t Promedio de entragados por cadete : {info.Average(x => x.EntregadosCadete)}");
    }
}

// ObjetoVisual obj1 = new ObjetoVisual(); // me deja xq estoy aplicando solo herencia, si fuera abstraccion no podria
        // ObjetoVisual obj2 = new Texto();

        // List<Vehiculo> listVehiculo = new List<Vehiculo>();

        // Vehiculo auto = new Auto();
        // System.Console.WriteLine(auto.acelerar());

        // Vehiculo autof1 = new AutoFormula1();
        // System.Console.WriteLine(autof1.acelerar());

        // listVehiculo.Add(auto);
        // listVehiculo.Add(autof1);

        // foreach (Vehiculo item in listVehiculo)
        // {
        //     System.Console.WriteLine(item.GetType()); // para saber que tipo de objeto es
        //     item.acelerar(); 
        // }

