namespace Survival
{
    public abstract class Character
    {
        protected int ID { get; set; }
        public float Health { get; set; }
        public float MaxHealth { get; set; }
        public float Damage { get; set; }
        public float Armor { get; set; }
        public float Speed { get; set; }
        public float Experience { get; set; }
    }
}