
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject turretToBuild;

   



    //Singelton Patteren
    //----------------------------------------------------------------------------------------
    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("more than one build manager");
            return;
        }
        //everytime we start the game, the game will say that THIS buildManager is put into instance variable.
        //But it can be accessed form anywhere
        instance = this;
    }
    //-----------------------------------------------------------------------------------------

    public GameObject gunTurretPrefab;
    public GameObject missileTurretPrefab;

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }


    public void PlaceTurret(GameObject turret)
    {

        turretToBuild = turret;
    }


}
