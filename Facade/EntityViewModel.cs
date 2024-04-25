using HaSe.Domain;

namespace HaSe.Facade {
    public abstract class EntityViewModel : IEntity {
        public int Id { get; set; }
    }
}
