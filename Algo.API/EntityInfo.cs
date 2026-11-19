namespace Algo.API
{
    public struct EntityInfo
    {
        public float X { get; }
        public float Y { get; }
        public float Mass { get; }

        public EntityInfo(float x, float y, float mass)
        {
            X = x;
            Y = y;
            Mass = mass;
        }
    }
}
