using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class UserFamilyDiet
    {
        public int UserFamilyMemberId { get; set; }
        public int DietId { get; set; }

        public virtual Diet Diet { get; set; }
        public virtual UserFamily UserFamilyMember { get; set; }
    }
}
