//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OtoparkYonetimi.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Araclar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Araclar()
        {
            this.Tbl_ParkYeri = new HashSet<Tbl_ParkYeri>();
        }
    
        public int AracId { get; set; }
        public string AracPlaka { get; set; }
        public string AracMarka { get; set; }
        public string AracRenk { get; set; }
        public int KisiId { get; set; }
    
        public virtual Tbl_Kisiler Tbl_Kisiler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_ParkYeri> Tbl_ParkYeri { get; set; }
    }
}
