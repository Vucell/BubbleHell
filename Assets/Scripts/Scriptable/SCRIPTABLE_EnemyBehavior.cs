using UnityEngine;

public abstract class SCRIPTABLE_EnemyBehavior : ScriptableObject
{
    [Tooltip("Velocidad de movimiento que usará este comportamiento.")]
    public float behaviorSpeed = 2f;

    public abstract void ExecuteBehavior(SCRT_Enemy_DMGRecived_02 enemy);

}
