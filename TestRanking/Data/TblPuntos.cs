using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestRanking.Data
{
    public partial class TblPuntos
    {
        [Key]
        public int IdPuntos { get; set; }
        public int Puntos { get; set; }
        public int Total { get; set; }
        public int IdTienda { get; set; }

        public virtual TblTiendas IdTiendaNavigation { get; set; }
    }
}
