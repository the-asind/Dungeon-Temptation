using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Creature : MonoBehaviour
    {
        public double Health { get; private set; }
        public double Defence { get; private set; }
        public double MovesDelay { get; private set; }
        public int Agility { get; private set; }
        public int Strength { get; private set; }
        public int Intelligence { get; private set; }
    }
}