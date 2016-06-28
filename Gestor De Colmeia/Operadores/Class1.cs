using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operadores
{
    public class Class1
    {
        public static bool operator ==(Empresa.Empresa p1, Empresa.Empresa p2)
        {
            return (p1.Nif == p2.Nif);
        }

        public static bool operator !=(Empresa.Empresa p1, Empresa.Empresa p2)
        {
            return !(p1.Nif == p2.Nif);
        }

        public static bool operator ==(Empresa.Colmeia p1, Empresa.Colmeia p2)
        {
            return (p1.NumeroComeia == p2.NumeroComeia && p1.NumeroApiario == p2.NumeroApiario);
        }

        public static bool operator !=(Empresa.Colmeia p1, Empresa.Colmeia p2)
        {
            return !(p1.NumeroComeia == p2.NumeroComeia && p1.NumeroApiario == p2.NumeroApiario);
        }

        

        
    }
}
