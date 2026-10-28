namespace Blackhellheim.Domain.Entities;

public class Categorias
{
    public Guid Id {get; private set;} = Guid.CreateVersion7();
    public int Categoria_Padre_Id {get; private set;}
    public string Nombre {get; private set;} = string.Empty;
    public string Slug {get; private set;} = string.Empty;
    public bool Activa {get; private set;}
}