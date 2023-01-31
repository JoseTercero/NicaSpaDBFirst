using System;
using System.Collections.Generic;

namespace NicaSpaDBFirst.Models;

public partial class Tratamiento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public int Precio { get; set; }

    public virtual ICollection<Reservacion> Reservacions { get; } = new List<Reservacion>();
}
