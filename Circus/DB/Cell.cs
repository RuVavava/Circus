//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Circus.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cell
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cell()
        {
            this.Schedule_Trainer = new HashSet<Schedule_Trainer>();
        }
    
        public int ID_Cell { get; set; }
        public string Name_Animal { get; set; }
        public Nullable<int> Age_Animal { get; set; }
        public Nullable<int> ID_Gender { get; set; }
        public string View_Animal { get; set; }
        public string Food { get; set; }
        public string Care { get; set; }
    
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule_Trainer> Schedule_Trainer { get; set; }
    }
}
