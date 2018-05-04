using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : Observer
{
    public Button houseButton, barracksButton, trainMarineButton;
    public GameObject barracksGroup, buildGroup, housePrefab, barracksPrefab, marinePrefab, temp;
    BuildingManager bmanager = BuildingManager.Instance;
    public UnitSelectionComponent usc;

    private void Start()
    {
        houseButton.onClick.AddListener(constructHouse);
        barracksButton.onClick.AddListener(constructBarracks);
        trainMarineButton.onClick.AddListener(trainMarine);

        bmanager.hud = this;
    }

    private void Update()
    {   
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

    void constructBarracks()
    {
        temp = Instantiate(barracksPrefab);
    }

    void trainMarine()
    {
        GameObject t = Instantiate(marinePrefab);
        usc.army.Add(t.GetComponent<Unit>());
    }

    public override void OnNotify(GameObject g)
    {
        print("building " + g + " selected");
        showBarracksUI();
    }

    void showBarracksUI()
    {
        buildGroup.SetActive(false);
        barracksGroup.SetActive(true);
    }
}
