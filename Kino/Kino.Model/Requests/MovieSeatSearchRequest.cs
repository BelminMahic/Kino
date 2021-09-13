namespace Kino.Model.Requests
{
    public class MovieSeatSearchRequest
    {
        public int? AuditoriumId { get; set; }
        public string[] IncludeList { get; set; }

    }
}
