using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Pessoa
    {
        [Key]
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Cidade {set; get;}
        public int Idade {get; set;}
    }
}