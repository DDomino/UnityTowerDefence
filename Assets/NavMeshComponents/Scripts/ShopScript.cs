
using UnityEngine;

public class ShopScript : MonoBehaviour
{

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void GunTurret()
    {
        Debug.Log("Gun Turret Purchased");
        buildManager.PlaceTurret(buildManager.gunTurretPrefab);

    }
    public void MissileTurret()
    {
        Debug.Log("Missile Turret Purchased");
        buildManager.PlaceTurret(buildManager.missileTurretPrefab);


    }
}
