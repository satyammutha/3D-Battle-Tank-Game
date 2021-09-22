using UnityEngine;
using BulletSObj;
using Tank;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/Tank/NewTankScriptableObjects")]
public class TankScriptableObject : ScriptableObject
{
    public TankTypes tankTypes;
    public string tankName;
    public float movementSpeed;
    public float rotationSpeed;
    public float health;
    public Material material;
    public TankView tankView;
    public float fireRate;
    public BulletScriptableObject bulletType;
}
[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/Tank/NewTankScriptableObjectsList")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tankList;
}