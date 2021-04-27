namespace GitTracker.Domain.Models
{
    public class EndPointModel
    {
        public string Username { get; set; }
        public string Owner { get; set; }
        public string Repo { get; set; }
        public string Sha { get; set; }
    }
}