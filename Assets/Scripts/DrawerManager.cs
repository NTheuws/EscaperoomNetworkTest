using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerManager : MonoBehaviour
{
    GameObject UpperCross;
    GameObject LowerCross;

    public static bool LowerDrawerClicked = false;
    public static bool UpperDrawerClicked = false;

    void Start()
    {
        UpperCross = this.transform.GetChild(0).gameObject;
        LowerCross = this.transform.GetChild(1).gameObject;
    }

    void Update()
    {
        
    }

    public void IsClicked(int val)
    {
        if (val == 1)
        {
            UpperCross.SetActive(true);
            UpperDrawerClicked = true;
        }
        else if (val == 2)
        {
            LowerCross.SetActive(true);
            LowerDrawerClicked = true;
        }
    }

    public void UpdateDrawers(bool upper, bool lower)
    {
        // Upper Drawer.
        if (upper)
        {
            UpperCross.SetActive(true);
        }
        else
        {
            UpperCross.SetActive(false);
        }
        // Lower Drawer.
        if (lower)
        {
            LowerCross.SetActive(true);
        }
        else
        {
            LowerCross.SetActive(false);
        }
    }
}
