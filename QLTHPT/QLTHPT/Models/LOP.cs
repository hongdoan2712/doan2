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
    
    public partial class LOP
    {
        public LOP()
        {
            this.HOCSINHs = new HashSet<HOCSINH>();
            this.THOIKHOABIEUx = new HashSet<THOIKHOABIEU>();
        }
    
        public string LOP_MA { get; set; }
        public string LOP_TEN { get; set; }
    
        public virtual ICollection<HOCSINH> HOCSINHs { get; set; }
        public virtual ICollection<THOIKHOABIEU> THOIKHOABIEUx { get; set; }
    }
}
