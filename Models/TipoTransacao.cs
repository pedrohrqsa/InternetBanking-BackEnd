using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("TipoTransacao")]
    public class TipoTransacao
    {
        [Key]
        public int idTipoTransacao { get; set; }
        public int cdTipoTransacao { get; set; }
    }
}