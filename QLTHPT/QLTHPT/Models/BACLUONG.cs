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
    
    public partial class BACLUONG
    {
        public BACLUONG()
        {
            this.THONGTINLUONGs = new HashSet<THONGTINLUONG>();
        }
    
        public string BL_MA { get; set; }
        public string BL_TEN { get; set; }
    
        public virtual ICollection<THONGTINLUONG> THONGTINLUONGs { get; set; }
    }
}
