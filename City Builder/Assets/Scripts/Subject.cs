using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Subject
{
    List<Observer> observers = new List<Observer>();

    public void Notify()
    {
        for (int i = 0; i < observers.Count; i++)
        {
            observers[i].OnNotify();
        }
    }

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(Observer ob)
    {
        observers.Remove(ob);
    }
}

