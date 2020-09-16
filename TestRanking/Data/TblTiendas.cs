using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestRanking.Data
{
    public partial class TblTiendas
    {
        public TblTiendas()
        {
            TblHorarios = new HashSet<TblHorarios>();
            TblPuntos = new HashSet<TblPuntos>();
        }
        [Key]
        public int IdTienda { get; set; }
        public string NombreTienda { get; set; }
        public string Descripcion { get; set; }
        public string Logo { get; set; }
        public string Imagen { get; set; }

        public virtual ICollection<TblHorarios> TblHorarios { get; set; }
        public virtual ICollection<TblPuntos> TblPuntos { get; set; }
    }
}
