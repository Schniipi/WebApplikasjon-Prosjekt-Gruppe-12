﻿using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models.FormDataMappe.ServiceModel
{
    public class FormData
    {
        [Required]
        public string Navn { get; set; }
        public int TelefonNummer { get; set; }
        public string Kommentar { get; set; }

    }


}