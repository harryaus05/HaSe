using HaSe.Domain;
using System.ComponentModel;

namespace HaSe.Facade {
    public abstract class EntityViewModel : IEntity {
        [DisplayName("Id")] public int Id { get; set; }
    }
}
