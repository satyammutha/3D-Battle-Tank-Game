namespace Tank
{
    public class TankModel
    {
        private TankController tankController;

        public TankTypes tankTypes { get; private set; }
        public float speed { get; private set; }
        public float health { get; private set; }
        public float damage { get; private set; }

        public TankScriptableObject tankScriptableObject;
        public TankModel(TankScriptableObject tankScriptableObject)
        {
            tankTypes = tankScriptableObject.tankTypes;
            speed = tankScriptableObject.speed;
            health = tankScriptableObject.health;
            damage = tankScriptableObject.damage;
        }
        public int SpeedLive { get { return (int)tankScriptableObject.speed; } }
    }
}