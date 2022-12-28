namespace DungeonCreature
{
    public struct Position
    {
        public float x { get; set; }
        public float y { get; set; }
        
        
        public void ChangePosition(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
    }
}