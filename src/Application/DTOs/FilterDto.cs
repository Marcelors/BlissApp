namespace Application.DTOs
{
    public class FilterDto
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string Filter { get; set; }
    }
}
