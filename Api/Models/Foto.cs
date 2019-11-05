namespace Api.Models
{
    public class Foto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public Usuario Usuario { get; set; }
    }
}