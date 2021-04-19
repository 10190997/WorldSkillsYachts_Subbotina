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
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Contracts = new HashSet<Contract>();
            this.Details = new HashSet<Detail>();
        }
    
        public int Order_ID { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> Salesperson_ID { get; set; }
        public Nullable<int> Customer_ID { get; set; }
        public Nullable<int> Boat_ID { get; set; }
        public string DeliveryAddress { get; set; }
        public string City { get; set; }
    
        public virtual Boat Boat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detail> Details { get; set; }
        public virtual Salesperson Salesperson { get; set; }
    }
}
