using System;
using System.Collections.Generic;

namespace NicaSpaDBFirst.Models;

public partial class Usuario
{
    public int Codigousuario { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int Codigotipousuario { get; set; }

    public string Imagenusuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual Tipousuario CodigotipousuarioNavigation { get; set; } = null!;

    public virtual ICollection<Reservacion> Reservacions { get; } = new List<Reservacion>();
}
