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
    
    public partial class Exercise
    {
        public int ID_Exercise { get; set; }
        public Nullable<int> ID_Worker { get; set; }
        public string Description { get; set; }
        public string Name_Status { get; set; }
        public string Comment { get; set; }
    
        public virtual Workers Workers { get; set; }
    }
}
