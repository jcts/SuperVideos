namespace SuperVideos.Domain.Entities.ValueObject
{
    public class MovieDetail : ValueObject<MovieDetail>
    {
        public long BarCode { get; set; }
        public int Duration { get; set; }
        public long Isbn { get; set; }

        public MovieDetail()
        {   }

        public MovieDetail(long barcode, int duration, long isbn)
        {
            BarCode = barcode;
            Duration = duration;
            Isbn = isbn;
        }
    }
}
