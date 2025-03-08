﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Common.Entities
{
    class BaseEntity<TKey> where TKey:IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
