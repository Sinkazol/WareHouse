using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Keyless]
    public class ViewModelKeszlet
    {
        public required string TermekNev { get; set; }
        public string? TermekLeiras { get; set; }
        public int TermekAra { get; set; }
        public int TermekMennyisege { get; set; }
        public required string TelephelyCime { get; set; }
    }
}
