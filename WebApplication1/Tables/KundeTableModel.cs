using WebApplication1.Repositories;


namespace WebApplication1.Tables
{
    public class KundeData
    {
        public int KundeID { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Bedrift { get; set; }
        public string TelefonNR { get; set; }
        public string Adresse { get; set; }

        public int DeleteID { get; set; }

    }


}