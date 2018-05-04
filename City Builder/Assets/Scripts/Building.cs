using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Building : MonoBehaviour, Subject
{
    List<Observer> observers = new List<Observer>();

    private void Start()
    {
        BuildingManager.Instance.addBuilding(this);
    }

    public void notifyObservers()
    {
        foreach (var item in observers)
        {
            item.OnNotify(gameObject);
        }
    }

    public void registerObserver(Observer o)
    {
        observers.Add(o);
    }

    public void removeObserver(Observer o)
    {
        observers.Remove(o);
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            notifyObservers();
        }
    }
}

