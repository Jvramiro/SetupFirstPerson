using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ListUtils
{
    public static T GetRandom<T>(this List<T> list){
        if(list.Count <= 0) throw new System.Exception("Is not possible to return a Random Value from a empty list");
        return list[Random.Range(0, list.Count)];
    }
}
