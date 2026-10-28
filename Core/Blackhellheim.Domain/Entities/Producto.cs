namespace Blackhellheim.Domain.Entities;

public class Producto
{
    public Guid Id {get; private set;} = Guid.CreateVersion7();
    public string Titulo {get; private set;} = string.Empty;
    public string Slug {get; private set;} = string.Empty;
    public string Descripcion {get; private set;} = string.Empty;
    public DateTime Fecha_Creacion {get; private set;}
    public int Categoria_Id {get; private set;}

    public static Producto Crear(
        string titulo, string slug, string descripcion, int categoria_id)
    {
        //Validaciones finales del flujo
        return new Producto
        {
            Titulo=titulo,
            Slug=slug,
            Descripcion=descripcion,
            Categoria_Id=categoria_id,
            Fecha_Creacion=DateTime.UtcNow
        };
    }
}