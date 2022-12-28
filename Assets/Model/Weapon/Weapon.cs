namespace DungeonCreature
{
    public class Weapon : Item
    {
        public int Damage { get; }
        public WeaponType Type { get; protected set; }
        
        public Weapon() 
        {
            Damage = 0;
        } 
        public Weapon(int damage, WeaponType type)
        {
            Damage = damage;
            Type = type;
        }
    }
}