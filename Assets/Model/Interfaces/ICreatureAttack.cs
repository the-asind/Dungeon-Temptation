namespace DungeonCreature.Interfaces
{
    public interface ICreatureAttack
    {
        void Attack(ICreatureTakeDamage creature);
    }
}