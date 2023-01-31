using System;
using System.Collections.Generic;

namespace NicaSpaDBFirst.Models;

public partial class Tipousuario
{
    public int Codigotipousuario { get; set; }

    public string Tipousuario1 { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
