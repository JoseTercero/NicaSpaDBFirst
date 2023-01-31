using System;
using System.Collections.Generic;

namespace NicaSpaDBFirst.Models;

public partial class Reservacion
{
    public int Idreservacion { get; set; }

    public string Tratamiento { get; set; } = null!;

    public int Total { get; set; }

    public string? Usuario { get; set; }

    public DateTime Fecha { get; set; }

    public string Masajista { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public int? Idusuario { get; set; }

    public int? Idtratamiento { get; set; }

    public int? Idmasajista { get; set; }

    public virtual Masajistum? IdmasajistaNavigation { get; set; }

    public virtual Tratamiento? IdtratamientoNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
