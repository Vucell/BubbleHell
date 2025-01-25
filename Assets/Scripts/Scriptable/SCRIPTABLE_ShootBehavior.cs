using UnityEngine;

public abstract class SCRIPTABLE_ShootBehavior : ScriptableObject
{
    public abstract void ExecuteBehavior(SCRT_Atack_Player player, Transform target);
}
