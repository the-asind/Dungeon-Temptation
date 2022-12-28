namespace DungeonCreature
{
    public class RangedWeapon : Weapon
    {
        public int Range { get; }
        
        public RangedWeapon(int damage, WeaponType type, int range) : base(damage, type) 
        {
            Range = range;
        } 
    }
}