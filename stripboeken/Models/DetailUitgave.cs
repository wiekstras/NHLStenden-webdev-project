namespace stripboeken.Models
{
    public class DetailUitgave
    {
        public int UitgaveId { get; set; }
        public int ReeksId { get; set; }
        public string ReeksTitel { get; set; }
        public string BoekTitel { get; set; }
        public int boekId { get; set; }
        public string Weblink { get; set; }
        public string ISBN { get; set; }
        public int Jaar { get; set; }
        public string AfbeeldingsPad { get; set; }
        public string Uitgever { get; set; }
        public string Druk { get; set; }
        public string Cover { get; set; }
        public string Taal { get; set; }
        public int AantalBladzijden { get; set; }
        public decimal Breedte { get; set; }
        public decimal Hoogte { get; set; }
        public string Beschrijving { get; set; }
        public string Weetjes { get; set; }
    }
}
