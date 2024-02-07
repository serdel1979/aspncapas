﻿using System;
using System.Collections.Generic;

namespace ProjectCrud.Models;

public partial class Contacto
{
    public int IdContacto { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
