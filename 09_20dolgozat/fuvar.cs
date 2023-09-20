using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_20dolgozat
{
    internal class fuvar
    {
        int azonosito;
        DateTime indulas_idopontja;
        int utazas_idotartama;
        double megtett_tavolsag;
        double dij;
        double borravalo;
        string fizetes_modja;

        public fuvar(int azonosito, DateTime indulas_idopontja, int utazas_idotartama, double megtett_tavolsag, double dij, double borravalo, string fizetes_modja)
        {
            this.azonosito = azonosito;
            this.indulas_idopontja = indulas_idopontja;
            this.utazas_idotartama = utazas_idotartama;
            this.megtett_tavolsag = megtett_tavolsag;
            this.dij = dij;
            this.borravalo = borravalo;
            this.fizetes_modja = fizetes_modja;
        }

        public int Azonosito { get => azonosito;  }
        public DateTime Indulas_idopontja { get => indulas_idopontja;  }
        public int Utazas_idotartama { get => utazas_idotartama;  }
        public double Megtett_tavolsag { get => megtett_tavolsag;  }
        public double Dij { get => dij;  }
        public double Borravalo { get => borravalo;  }
        public string Fizetes_modja { get => fizetes_modja;  }
    }

}
