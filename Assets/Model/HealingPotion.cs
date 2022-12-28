namespace DungeonCreature
{
    public class HealingPotion : Item
    {
        private int healValue = 100;

       public int ProvideHeal()
       {
           return healValue;
       }

        public HealingPotion(int _healValue = 10)
        {
            healValue = _healValue;
            Type = "";
        }
    }
}