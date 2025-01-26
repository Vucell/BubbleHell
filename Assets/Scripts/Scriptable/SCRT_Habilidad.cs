using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skills/Skill")]
public class SCRT_Habilidad : ScriptableObject
{
    //public string habilidadNombre;  // Nombre de la habilidad
    //public Sprite habilidadSprite;  // Sprite de la habilidad
    public Sprite[] HabilidadSprite;
    
    //public SCRT_HabilidadParametro habilidadParametro;  // El parametro que modifica otro ScriptableObject
    public SCRIPTABLE_BurstShootBehavior burstShootBehavior;
    //public SCRT_Atack_Player playerobject;
    //public SCRT_movement_Player playermovement;
    public GameObject playerObject;

    public float damage;
    public int balines;
    public float speedShoot;
    public float speedplayer;

    public int IDHabilidad;

    
    public void cambioStats(int indexID)
    {
        if (IDHabilidad == 0)
        {
            //playerobject.projectilePrefab.GetComponent<SCRT_proyectile_Player>().damage = damage + playerobject.projectilePrefab.GetComponent<SCRT_proyectile_Player>().damage;

            playerObject.GetComponent<SCRT_proyectile_Player>().damage = playerObject.GetComponent<SCRT_proyectile_Player>().damage + damage;

        }
        else if (IDHabilidad == 1)
        {
            burstShootBehavior.burstCount = burstShootBehavior.burstCount + balines;

        }
        else if (IDHabilidad == 2)
        {
            burstShootBehavior.SpeedShot = burstShootBehavior.SpeedShot + speedShoot;

        }
        else if (IDHabilidad == 3)
        {
            //playermovement.moveSpeed = playermovement.moveSpeed + speedplayer;
            playerObject.GetComponent<SCRT_movement_Player>().moveSpeed = playerObject.GetComponent<SCRT_movement_Player>().moveSpeed + speedplayer;
        }




    }
}

