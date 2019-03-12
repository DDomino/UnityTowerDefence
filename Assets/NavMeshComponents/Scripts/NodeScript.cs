using UnityEngine;
using UnityEngine.EventSystems;
public class NodeScript : MonoBehaviour
{
    public Color hoverColor;

    private Renderer rend;
    private Color startColor;
    public Vector3 postionoffset;
   

    private GameObject turret;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }


    private void OnMouseDown()
    {
        

        if(buildManager.getTurretToBuild() == null)
           return;
        

        if (turret != null && Input.GetMouseButton(0))
        {
            Debug.Log("Cant build there! -- TODO:");
            return;
        }
        //Requires Scripts to be in the same folder.
        GameObject turretToBuild = buildManager.getTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + postionoffset, transform.rotation);

       
    }
    

    private void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.getTurretToBuild() == null)
        return;
        rend.material.color = hoverColor;
    }


    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }




}
