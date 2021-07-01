using SuperVideos.Domain.Entities.ValueObject;

namespace SuperVideos.Domain.Entities
{
    public class Movie : EntityBase
    {
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public byte[] Sleeve { get; set; }
        public bool Available { get; set; }
        public MovieDetail MovieDetail { get; set; } = new MovieDetail();

        public Movie(){ }

        public Movie(string title, string synopsis, byte[] sleeve, MovieDetail movieDetail)
        {
            Title = title;
            Synopsis = synopsis;
            Sleeve = sleeve;
            MovieDetail = movieDetail;
        }
    }
}
