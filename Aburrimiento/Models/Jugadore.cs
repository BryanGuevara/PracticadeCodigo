using System;
using System.Collections.Generic;

namespace Aburrimiento.Models;

public partial class Jugadore
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Equipo { get; set; }

    public string? Activo { get; set; }
}
