namespace ApiProjeKamp.WebUI.Dtos.AISuggestionDtos
{
    public class ResultAIDailyMenuSuggestionItemDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Reason { get; set; } //ai'ın neden seçtiği bilgisini tutacak
    }
}
