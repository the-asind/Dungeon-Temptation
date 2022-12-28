namespace DungeonCreature
{
    public class HealingPotion : Item
    {
       private int healValue;

       public int ProvideHeal()
       {
           return healValue;
       }
    }
}