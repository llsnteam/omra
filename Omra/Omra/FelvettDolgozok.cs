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
    
    public partial class FelvettDolgozok
    {
        public decimal bunesetID { get; set; }
        public decimal dolgozoID { get; set; }
        public System.DateTime felvetel_idopontja { get; set; }
    
        public virtual Bunesetek Bunesetek { get; set; }
        public virtual Dolgozok Dolgozok { get; set; }
    }
}