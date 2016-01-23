using UnityEngine;

namespace Problem1
{
    /// <summary>
    /// Mock up vehicle class
    /// </summary>
    internal sealed class Racer:ScriptableObject
    {
        public void update(float deltaTime)
        {
            //random calculation
            int value = 100;
            while (value > 0)
            {
                value--;
            }
        }
        public bool IsCollidable()
        {
            return Random.value > .5f;
        }
        public bool IsAlive()
        {
            return Random.value > .5f;
        }
        public bool CollidesWith(Racer other)
        {
            return Random.value > .5f;
        }
        public void Destroy()
        {
            //random calculation
            int value = 100;
            while (value > 0)
            {
                value--;
            }
        }
    }
}
