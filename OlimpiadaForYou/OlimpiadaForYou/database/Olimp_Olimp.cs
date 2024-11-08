//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OlimpiadaForYou.database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Olimp_Olimp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Olimp_Olimp()
        {
            this.Olimp_Registration = new HashSet<Olimp_Registration>();
        }
    
        public int ID { get; set; }
        public int ID_Creator { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ID_Class { get; set; }
        public int ID_Difficulty { get; set; }
        public int ID_Subject { get; set; }
        public System.DateTime DateOfEnd { get; set; }
        public System.DateTime DateOfEvent { get; set; }
        public int MaxGoal { get; set; }
        public string Duration { get; set; }
        public bool IsEventPassed => DateOfEvent < DateTime.Now;
        public string ResultText
        {
            get
            {
                if (IsEventPassed)
                {
                    var registration = App.Context.Olimp_Registration.FirstOrDefault(r => r.ID_Olimp == this.ID && r.ID_User == App._Olimp_Users.ID);

                    if (registration != null)
                    {
                        if (registration.Result == null )
                        {
                            return "Скоро узнаешь!";
                        }
                        return $"{registration.Result}/{MaxGoal}";
                    }
                }
                return string.Empty;
            }
        }

        public virtual Olimp_Class Olimp_Class { get; set; }
        public virtual Olimp_Difficulty Olimp_Difficulty { get; set; }
        public virtual Olimp_Subject Olimp_Subject { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Olimp_Registration> Olimp_Registration { get; set; }
    }
}
