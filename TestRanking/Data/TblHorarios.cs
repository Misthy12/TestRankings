using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestRanking.Data
{
    public partial class TblHorarios
    {
        [Key]
        public int IdHorario { get; set; }
        public string HoraApertura { get; set; }
        public string HoraCierre { get; set; }
        public string Dias { get; set; }
        public int IdTienda { get; set; }

        public virtual TblTiendas IdTiendaNavigation { get; set; }
    }
}
