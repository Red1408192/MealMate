using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class UserFamilyDesease
    {
        public int UserFamilyMemberId { get; set; }
        public int DeseaseId { get; set; }

        public virtual Desease Desease { get; set; }
        public virtual UserFamily UserFamilyMember { get; set; }
    }
}
