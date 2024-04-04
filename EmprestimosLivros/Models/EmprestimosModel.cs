using System.ComponentModel.DataAnnotations;

namespace EmprestimosLivros.Models
{
    public class EmprestimosModel 
        //Na model que vai referenciar a cada coluna no banco de dados
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome do recebedor!")] 
        public string Recebedor { get; set; }

        [Required(ErrorMessage = "Digite o nome do Fornecedor!")]
        public string Fornecedor { get; set;}

        [Required(ErrorMessage = "Digite o nome do Livro!")]
        public string LivroEmprestado { get; set;}  
        public DateTime DataEmprestimo { get; set; } = DateTime.Now;

    }
}
