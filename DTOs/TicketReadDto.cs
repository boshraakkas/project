namespace Assignment2.DTOs
{
    public class TicketReadDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
