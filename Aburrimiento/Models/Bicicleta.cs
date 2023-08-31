using System;
using System.Collections.Generic;

namespace Aburrimiento.Models;

public partial class Bicicleta
{
    public int? Id { get; set; }

    public string? MarcaBici { get; set; }

    public string? Estado { get; set; }

    public string? Dueño { get; set; }

    public string? Numero { get; set; }
}
