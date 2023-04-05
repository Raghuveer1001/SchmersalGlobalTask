namespace SchmersalGlobalTask.Domain
{
    public abstract class BaseEntity
    {
        public int CreatedBy { get; set; }
        public int CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int ModifiedOn { get; set; }
    }
}