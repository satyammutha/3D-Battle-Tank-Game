using UnityEngine;
using Tank;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/Tank/NewTankScriptableObjects")]
public class TankScriptableObject : ScriptableObject
{
    public TankTypes tankTypes;
    public string tankName;
    public float movementSpeed;
    public float rotationSpeed;
    public float health;
    public float damage;
    public Material material;
    public TankView tankView;
}