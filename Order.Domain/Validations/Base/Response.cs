namespace Order.Domain.Validations.Base
{
    public class Response
    {
        public List<Report> Report { get; }
        public Response()
        {
            Report = new List<Report>();
        }
        public Response(List<Report> reports)
        {
            Report = reports;
        }
        public Response(Report report) : this(new List<Report>() { report })
        {

        }
    }

    public class Reponse<T> : Response
    {
        public T Data { get; set; }
        public Reponse()
        {

        }
        public Reponse(T data, List<Report> reports = null) : base(reports)
        {
            data = data;
        }
    }
}
