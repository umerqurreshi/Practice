using System.ComponentModel.DataAnnotations;

namespace DbOps.DtoModels
{
    public class AddedBonus
    {
        [Key]
        public int AddedBonusId { get; set; }
        public string GiftVouchers { get; set; }
        public string ChildVouchers { get; set; }
        public string ElderlyVouchers { get; set; }
        public string CleaningVouchers { get; set; }
        
    }
}
