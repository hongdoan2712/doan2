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
    
    public partial class HINHTHUC
    {
        public HINHTHUC()
        {
            this.THONGTINDAOTAOs = new HashSet<THONGTINDAOTAO>();
        }
    
        public string HT_MA { get; set; }
        public string HT_TEN { get; set; }
    
        public virtual ICollection<THONGTINDAOTAO> THONGTINDAOTAOs { get; set; }
    }
}
