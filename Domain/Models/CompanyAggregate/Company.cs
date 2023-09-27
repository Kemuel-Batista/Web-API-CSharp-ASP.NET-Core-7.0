using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiYoutube.Domain.Models.CompanyAggregate
{
    [Table("company")]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
