using System.ComponentModel.DataAnnotations;

namespace PokemonCollectorMVC.Models
{
    public class TCG
    {
        [Key]
        public string CardId { get; set; }
        public string CardSeries { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
    }
}
