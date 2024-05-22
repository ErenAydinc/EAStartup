namespace EARepository.Abstractions
{
    public abstract class EAEntity:IEAEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
    }
}
