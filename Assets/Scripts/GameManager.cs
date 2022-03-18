using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefabTower1;
    public GameObject prefabTower2;
    public GameObject prefabTower3;
    public GameObject prefabDome;
    public GameObject selectedObj;
    private bool move;
    private bool build;

    public int turnNumber;
    public bool blueTurn;
    public bool redTurn;
    // Start is called before the first frame update
    void Start()
    {
        turnNumber = 0;
        blueTurn = true;
        redTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
            BlueTurn();
    }

    Vector3 GetTarget()
    {
        //Vector3 targetPos = new Vector3 (0, 0, 0);

        if(Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast (ray, out hit))
            {
                Vector3 targetPos = new Vector3(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y, hit.collider.gameObject.transform.position.z);
                return (targetPos);
            }
        }
        return (new Vector3(0, -1, 0));
    }

    void BlueTurn()
    {
    //    Moving();
        Building();
    }

   /* void Moving()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast (ray, out hit))
            {
                selectedObj = hit.collider.gameObject;
            }
        }
        Vector3 builder = GetTarget();
        if (selectedObj.CompareTag("Player"))
        {
            selectedObj.transform.position = destination + new Vector3(0, 6, 0);
        }
        
    }*/

    void Building()
    {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 target = GetTarget();
                if (target.y == 0)
                {
                    BuildTower1(target);
                }
                if (target.y == 3)
                {
                    BuildTower2(target);
                }
                if (target.y == 9)
                {
                        BuildTower3(target);
                }
                if (target.y == 15)
                {
                        BuildDome(target);
                }
            }
    }
    void BuildTower1(Vector3 targetPos)
    {
        Instantiate(prefabTower1, (targetPos + new Vector3(0, 3, 0)), Quaternion.identity);
    }
    void BuildTower2(Vector3 targetPos)
    {
        Instantiate(prefabTower2, (targetPos + new Vector3(0, 6, 0)), Quaternion.identity);
    }
    void BuildTower3(Vector3 targetPos)
    {
        Instantiate(prefabTower3, (targetPos + new Vector3(0, 6, 0)), Quaternion.identity);
    }
    void BuildDome(Vector3 targetPos)
    {
        Instantiate(prefabDome, (targetPos + new Vector3(0, 3, 0)), Quaternion.identity);
    }
}
