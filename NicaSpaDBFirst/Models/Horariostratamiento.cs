using System;
using System.Collections.Generic;

namespace NicaSpaDBFirst.Models;

public partial class Horariostratamiento
{
    public int Id { get; set; }

    public string Horario { get; set; } = null!;

    public virtual ICollection<Calendarioterapistum> Calendarioterapista { get; } = new List<Calendarioterapistum>();
}
