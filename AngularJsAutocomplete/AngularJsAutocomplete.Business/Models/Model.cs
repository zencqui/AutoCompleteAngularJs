//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AngularJsAutocomplete.Business.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Model
    {
        public Model()
        {
            this.Years = new HashSet<Year>();
        }
    
        public string Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string NiceName { get; set; }
    
        public virtual Make Make { get; set; }
        public virtual ICollection<Year> Years { get; set; }
    }
}