using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class UnitSelectionComponent : MonoBehaviour
{
    public List<Unit> army = new List<Unit>();
    List<Unit> selected = new List<Unit>();
    bool isSelecting = false;
    Vector3 mousePosition1;

    private void Update()
    { 
        if(Input.GetMouseButtonDown(1))
        {
            foreach (var item in selected)
            {
                item.moving = true;
                item.endpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        // If we press the left mouse button, save mouse location and begin selection
        if (Input.GetMouseButtonDown(0))
        {
            //first deselect all the ones you had previously
            iterateThroughArmy();
            isSelecting = true;
            mousePosition1 = Input.mousePosition;
        }
        // If we let go of the left mouse button, end selection
        if (Input.GetMouseButtonUp(0))
        {
            iterateThroughArmy();
            isSelecting = false;
                
        }
    }

    IEnumerator moveToLocation(Vector3 loc)
    {
        yield return new WaitForSeconds(1);
    }

    void OnGUI()
    {
        if (isSelecting)
        {
            // Create a rect from both mouse positions
            var rect = Utils.GetScreenRect(mousePosition1, Input.mousePosition);
            Utils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            Utils.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }

    void iterateThroughArmy()
    {
        if (army.Count > 0)
        {
            foreach (var item in army)
            {
                if (IsWithinSelectionBounds(item.gameObject))
                {
                    selected.Add(item);
                    foreach (Transform child in item.transform)
                    {
                        if (child.gameObject.name == "SelectionCircle")
                        {
                            child.gameObject.SetActive(true);

                        }
                    }
                }
                else
                {
                    selected.Remove(item);
                    foreach (Transform child in item.transform)
                    {
                        if (child.gameObject.name == "SelectionCircle")
                        {
                            child.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }

        //print selected list
        foreach (var item in selected)
        {
            print(item);
        }
    }

    public bool IsWithinSelectionBounds(GameObject gameObject)
    {
        if (!isSelecting)
            return false;

        var camera = Camera.main;
        var viewportBounds =
            Utils.GetViewportBounds(camera, mousePosition1, Input.mousePosition);

        return viewportBounds.Contains(
            camera.WorldToViewportPoint(gameObject.transform.position));
    }
}

