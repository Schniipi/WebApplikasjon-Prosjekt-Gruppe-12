using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.FormDataMappe
{
    public class FormData
    {
        public int id { get; set; }
        public string Navn { get; set; }
        public int TelefonNummer { get; set; }
        public string Kommentar { get; set; }

        public int DeleteID { get; set; }

    }


}