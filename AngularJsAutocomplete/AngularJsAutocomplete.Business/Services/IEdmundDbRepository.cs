﻿using AngularJsAutocomplete.Business.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsAutocomplete.Business.Services
{
    public interface IEdmundDbRepository
    {
        int SaveMakes(IEnumerable<Make> makes);

        IEnumerable<Make> GetAllMakes();

        IEnumerable<Model> GetAllModels();
    }
}
