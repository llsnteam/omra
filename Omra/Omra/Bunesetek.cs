//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Omra
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bunesetek
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bunesetek()
        {
            this.FelvettBizonyitekok = new HashSet<FelvettBizonyitekok>();
            this.FelvettDolgozok = new HashSet<FelvettDolgozok>();
            this.FelvettGyanusitottak = new HashSet<FelvettGyanusitottak>();
        }
    
        public decimal bunesetID { get; set; }
        public System.DateTime felvetel { get; set; }
        public Nullable<System.DateTime> lezaras { get; set; }
        public decimal felelos_ornagy { get; set; }
        public string leiras { get; set; }
        public string allapot { get; set; }
    
        public virtual Dolgozok Dolgozok { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FelvettBizonyitekok> FelvettBizonyitekok { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FelvettDolgozok> FelvettDolgozok { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FelvettGyanusitottak> FelvettGyanusitottak { get; set; }
    }
}
