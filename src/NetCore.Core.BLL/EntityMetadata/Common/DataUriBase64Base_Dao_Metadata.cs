﻿using Dna.NetCore.Core.BLL.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public abstract partial class DataUriBase64Base_Dao_Metadata : BaseMetadata
    {
        [Required(ErrorMessageResourceName = "PictureIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DisplayFormat(NullDisplayText = "[Image]")]
        [Display(Name = "Picture", ResourceType = typeof(Labels))]
        [Column(TypeName = "varbinary")]  // add-migration generates c.Binary(nullable: false, maxLength: 8000),
        public virtual Byte[] Data { get; set; } //add-migration treats byte[] & Byte[] the same

        //[Required(ErrorMessageResourceName = "ContentTypeIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        //[Display(Name = "ContentType", ResourceType = typeof(Labels))]
        //public virtual string ContentType { get; set; }  // defaults to text/plain

    }
}