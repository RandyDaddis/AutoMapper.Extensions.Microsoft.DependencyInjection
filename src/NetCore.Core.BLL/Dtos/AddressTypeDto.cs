namespace NetCore.Core.BLL.DataTransferObjects
{
    public partial class AddressTypeDto
    {
        public virtual int Id { get; set; }
        public virtual string SystemName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
