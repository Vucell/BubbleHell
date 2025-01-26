using UnityEngine;

public class NuevaHabilidad : MonoBehaviour
{
    //public string habilidadNombre;  // Nombre de la habilidad
    //public Sprite habilidadSprite;  // Sprite de la habilidad
    public Sprite[] HabilidadSprite;

    //public SCRT_HabilidadParametro habilidadParametro;  // El parametro que modifica otro ScriptableObject
    public SCRIPTABLE_BurstShootBehavior burstShootBehavior;
    //public SCRT_Atack_Player playerobject;
    //public SCRT_movement_Player playermovement;
    public GameObject playerObject;
    public GameObject Bullet;

    public float damage;
    public int balines;
    public float speedShoot;
    public float speedplayer;

    public int IDHabilidad;

    public void Start()
    {
        burstShootBehavior.burstCount = 1;
        burstShootBehavior.SpeedShot = 2;
    }

    public void cambioStats(int indexID)
    {
        if (indexID == 0)
        {
            //playerobject.projectilePrefab.GetComponent<SCRT_proyectile_Player>().damage = damage + playerobject.projectilePrefab.GetComponent<SCRT_proyectile_Player>().damage;

            //playerObject.GetComponent<SCRT_proyectile_Player>().damage = playerObject.GetComponent<SCRT_proyectile_Player>().damage + damage;
            //playerObject.GetComponent<SCRT_Atack_Player>().GetComponent<SCRT_proyectile_Player>().damage = playerObject.GetComponent<SCRT_Atack_Player>().GetComponent<SCRT_proyectile_Player>().damage + damage;
            Bullet.GetComponent<SCRT_proyectile_Player>().damage = Bullet.GetComponent<SCRT_proyectile_Player>().damage + damage;
        }
        else if (indexID == 1)
        {
            burstShootBehavior.burstCount = burstShootBehavior.burstCount + balines;

        }
        else if (indexID == 2)
        {
            burstShootBehavior.SpeedShot = burstShootBehavior.SpeedShot + speedShoot;

        }
        else if (indexID == 3)
        {
            //playermovement.moveSpeed = playermovement.moveSpeed + speedplayer;
            playerObject.GetComponent<SCRT_movement_Player>().moveSpeed = playerObject.GetComponent<SCRT_movement_Player>().moveSpeed + speedplayer;
        }




    }
}
