using System.ComponentModel.DataAnnotations;

namespace DbOps.DtoModels
{
   
    public class Perks
    {
        [Key]
        public int PerkId { get; set; }
        public string PerkType { get; set; }
        public int PerkDuration { get; set; }
        public int EmployeeId { get; set; }
        public virtual AddedBonus AddedBonus { get; set; }
    }
}
