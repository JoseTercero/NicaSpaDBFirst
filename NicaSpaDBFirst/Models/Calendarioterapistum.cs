using System;
using System.Collections.Generic;

namespace NicaSpaDBFirst.Models;

public partial class Calendarioterapistum
{
    public int Id { get; set; }

    public int Idmasajista { get; set; }

    public DateTime Fecha { get; set; }

    public int Idhorario { get; set; }

    public virtual Horariostratamiento IdhorarioNavigation { get; set; } = null!;

    public virtual Masajistum IdmasajistaNavigation { get; set; } = null!;
}
