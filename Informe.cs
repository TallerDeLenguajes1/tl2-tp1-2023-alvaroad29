namespace EspacioInforme;

public class Informe
{
    string nombreCadete;
    float montoGanado;
    int entregadosCadete;

    public string NombreCadete { get => nombreCadete; set => nombreCadete = value; }
    public float MontoGanado { get => montoGanado; set => montoGanado = value; }
    public int EntregadosCadete { get => entregadosCadete; set => entregadosCadete = value; }
}