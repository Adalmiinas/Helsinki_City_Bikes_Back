using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelsinkiBikes.Model
{
    public class StationDTO
    {
        public int FID { get; set; }
        public int ID { get; set; }

        public string Nimi { get; set; }

        public string Namn { get; set; }

        public string Name { get; set; }

        public string Osoite { get; set; }

        public string Adress { get; set; }

        public string Kaupunki { get; set; }

        public string Stad { get; set; }

        public string Operaattor { get; set; }

        public int Kapasiteet { get; set; }

        public string x { get; set; }

        public string y { get; set; }
    }
}

