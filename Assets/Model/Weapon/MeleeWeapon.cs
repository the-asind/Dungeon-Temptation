namespace DungeonCreature
{
    public class MeleeWeapon : Weapon
    {
       public int AttackRadius { get; set; }

       public MeleeWeapon(int damage, int attackRadius, WeaponType type) : base(damage, type) 
       {
           AttackRadius = attackRadius;
       }
    }
}