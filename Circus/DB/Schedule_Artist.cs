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
    
    public partial class Schedule_Artist
    {
        public int ID_ScheduleArtist { get; set; }
        public Nullable<int> ID_Artist { get; set; }
        public Nullable<int> ID_Event { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Hour { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual Workers Workers { get; set; }
    }
}