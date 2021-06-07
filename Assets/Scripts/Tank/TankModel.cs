using UnityEngine;

namespace Tank
{
    public class TankModel
    {
        public TankTypes tankTypes { get; private set; }
        public string tankName { get; private set; }
        public float movementSpeed { get; private set; }
        public float rotationSpeed { get; private set; }
        public float health { get; private set; }
        public float damage { get; private set; }
        public Material material { get; private set; }

        public TankScriptableObject tankScriptableObject;
        public TankModel(TankScriptableObject tankScriptableObject)
        {
            tankTypes = tankScriptableObject.tankTypes;
            tankName = tankScriptableObject.tankName;
            movementSpeed = tankScriptableObject.movementSpeed;
            rotationSpeed = tankScriptableObject.rotationSpeed;
            health = tankScriptableObject.health;
            damage = tankScriptableObject.damage;
            material = tankScriptableObject.material;
        }
    }
}