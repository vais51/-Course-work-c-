//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.Document = new HashSet<Document>();
            this.Document1 = new HashSet<Document>();
        }
    
        public int idEmployee { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Nullable<int> idRole { get; set; }
    
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<Document> Document1 { get; set; }
        public virtual Role Role { get; set; }
    }
}