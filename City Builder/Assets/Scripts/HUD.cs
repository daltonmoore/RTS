using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Button houseButton;
    public GameObject housePrefab, temp;

    private void Start()
    {
        houseButton.onClick.AddListener(constructHouse);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

        }
        if(temp!=null)
        {
            Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            temp.transform.position = new Vector3 (Mathf.Round(v.x), Mathf.Round(v.y));
            
            if(Input.GetMouseButtonDown(0))
            {
                temp = null;
            }
            if(Input.GetMouseButtonDown(1))
            {
                Destroy(temp);
            }
        }
    }

    void constructHouse()
    {
        temp = Instantiate(housePrefab);
    }
}
