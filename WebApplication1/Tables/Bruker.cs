using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Tables
{
    [Table("brukere")]
    public class BrukerBord
    {
        public string Navn { get; set; }
        public int TelefonNummer { get; set; }

    }
}