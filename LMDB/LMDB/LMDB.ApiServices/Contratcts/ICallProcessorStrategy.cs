﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Contratcts
{
    public interface ICallProcessorStrategy<in T>
    {
        void ExectuteStrategy(T parameter);
    }
}
