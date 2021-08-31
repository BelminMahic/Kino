namespace Kino.Model.Requests
{
    public class AuditoriumSearchRequest
    {
        public string AuditoriumName { get; set; }
        public int? CinemaId { get; set; }
        public string[] IncludeList { get; set; }

    }
}
