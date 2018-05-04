using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BuildingManager
{
    public HUD hud;
    public List<Building> buildings = new List<Building>();
    private static BuildingManager instance;

    private BuildingManager() { }

    public static BuildingManager Instance
    {
        get
        {
            if (instance == null)
                instance = new BuildingManager();
            return instance;
        }
    }

    public void addBuilding(Building b)
    {
        buildings.Add(b);
        b.registerObserver(hud);
    }
}
