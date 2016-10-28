using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicoWeb.Models
{
    class HoraireModel
    {
        public int IdHoraire { get; set; }

        public string Jour { get; set; }

        public DateTime DebMat { get; set; }

        public DateTime FinMat { get; set; }

        public DateTime DebAprem { get; set; }

        public DateTime FinAprem { get; set; }

        public DateTime DebDate { get; set; }

        public DateTime FinDate { get; set; }

        internal List<HoraireModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
