//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorldSkillsYachts.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contract()
        {
            this.Invoices = new HashSet<Invoice>();
        }
    
        public int Contract_ID { get; set; }
        public System.DateTime Date { get; set; }
        public decimal DepositPayed { get; set; }
        public Nullable<int> Order_ID { get; set; }
        public decimal ContractTotalPrice { get; set; }
        public decimal ContracTotalPrice_inclVAT { get; set; }
        public string ProductionProcess { get; set; }
    
        public virtual Order Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
