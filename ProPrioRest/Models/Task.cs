//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProPrioRest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public System.Data.Entity.Spatial.DbGeography Location { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
        public bool Category_Urgent { get; set; }
        public bool Category_Important { get; set; }
        public byte[] Photo { get; set; }
        public int Task_Id { get; set; }
        public Nullable<int> User_Id { get; set; }
    
        public virtual User User { get; set; }
    }
}
