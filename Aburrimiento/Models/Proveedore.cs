using System;
using System.Collections.Generic;

namespace Aburrimiento.Models;

public partial class Proveedore
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Empresa { get; set; }

    public int? Telefono { get; set; }
}
