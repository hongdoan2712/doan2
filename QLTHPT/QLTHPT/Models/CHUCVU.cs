//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLTHPT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHUCVU
    {
        public CHUCVU()
        {
            this.CHITIET_CHUCVU = new HashSet<CHITIET_CHUCVU>();
        }
    
        public string CV_MA { get; set; }
        public string CV_TEN { get; set; }
    
        public virtual ICollection<CHITIET_CHUCVU> CHITIET_CHUCVU { get; set; }
    }
}