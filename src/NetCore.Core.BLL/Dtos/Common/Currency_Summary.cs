﻿using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
#if NET462
    [MetadataType(typeof(Currency_Summary_Metadata))]
#endif
    public partial class Currency_Summary : BaseDataTransferObjectSummary
    {
        public virtual int Id { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Code { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
