using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Contacts
{
    public interface IDbInitializer
    {
        void initialize();
        void Seed();
    }
}
