//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoExam.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event_type_event
    {
        public int ID_event { get; set; }
        public int ID_type_event { get; set; }
        public Nullable<int> ID_direction { get; set; }
    
        public virtual Direction Direction { get; set; }
        public virtual Event Event { get; set; }
        public virtual Type_event Type_event { get; set; }
    }
}
