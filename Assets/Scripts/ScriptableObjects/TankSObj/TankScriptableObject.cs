using UnityEngine;
using Tank;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/Tank/NewTankScriptableObjects")]
public class TankScriptableObject : ScriptableObject
{
    public TankTypes tankTypes;
    public string tankName;
    public float speed;
    public float health;
    public float damage;
    public TankView tankView;
}

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/Tank/NewTankListScriptableObjects")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tanks;
}