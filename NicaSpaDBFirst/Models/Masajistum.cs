using System;
using System.Collections.Generic;

namespace NicaSpaDBFirst.Models;

public partial class Masajistum
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public virtual ICollection<Calendarioterapistum> Calendarioterapista { get; } = new List<Calendarioterapistum>();

    public virtual ICollection<Reservacion> Reservacions { get; } = new List<Reservacion>();
}
