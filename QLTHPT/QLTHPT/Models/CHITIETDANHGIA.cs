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
    
    public partial class CHITIETDANHGIA
    {
        public CHITIETDANHGIA()
        {
            this.MONHOCs = new HashSet<MONHOC>();
        }
    
        public string CTDG_MA { get; set; }
        public Nullable<System.DateTime> CTDG_NGAYDG { get; set; }
        public string SODANHGIA_SDG_MA { get; set; }
        public string HOCSINH_HS_MA { get; set; }
    
        public virtual ICollection<MONHOC> MONHOCs { get; set; }
        public virtual HOCSINH HOCSINH { get; set; }
        public virtual SODANHGIA SODANHGIA { get; set; }
    }
}
