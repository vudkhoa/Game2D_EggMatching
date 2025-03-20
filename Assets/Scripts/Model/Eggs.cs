using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Eggs
{
    public List<Egg> lst;

    public Eggs()
    {
        lst = new List<Egg>();
    }

    public void AddEgg(Egg egg)
    {
        this.lst.Add(egg);
    }

    public void PrintEggs()
    {
        foreach (Egg egg in lst)
        {
            Debug.Log(egg.yPos);
        }
    }
}
