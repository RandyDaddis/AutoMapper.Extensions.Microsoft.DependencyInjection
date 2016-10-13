using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    [Table("Core_SystemSetting", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(SystemSetting_Dao_Metadata))]
#endif
    public partial class SystemSetting : BaseEntity
    {
        #region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public virtual string SystemName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Description { get; set; }

        public virtual bool BooleanValue { get; set; }
        public virtual decimal DecimalValue { get; set; }
        public virtual int IntegerValue { get; set; }
        public virtual string StringValue { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual int PluginId { get; set; }

        // TODO: add SystemSettingValueTypeId & change UI to only show <input> for that valueType (E.G. string, boolean, etc)

        #endregion

        #region Helper Methods

        //public virtual SystemSetting Set(string systemName, string displayName, string description,
        //                            bool booleanValue, decimal decimalValue, 
        //                            int integerValue, string stringValue,
        //                            bool isActive = true)
        //{
        //    this.SystemName = systemName;
        //    this.DisplayName = displayName;
        //    this.Description = description;
        //    this.BooleanValue = booleanValue;
        //    this.DecimalValue = decimalValue;
        //    this.IntegerValue = integerValue;
        //    this.StringValue = stringValue;
        //    this.IsActive = isActive;
        //    this.PluginId = pluginId;

        //    return this;
        //}

        #endregion
    }
}
