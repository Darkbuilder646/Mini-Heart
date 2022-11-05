using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethod
{
    public static void MoveSwapValue<T>(this List<T> list, int value1, int value2) //where T : new() Le type a un constructeur sans argument
    {
        T t = list[value2];
        list[value2] = list[value1];
        list[value1] = t;
    }

    public static void ShiftAndPlace<T>(this List<T> list, T t, int value)
    {
        list.Add(t);
        for (int i = list.Count - 2; i >= value; i--)
        {
            list[i + 1] = list[i];
        }
        list[value] = t;
    }

    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static int RandomOneAndOneMinus()
    {
        if(Random.Range(0,2) == 1)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    public static bool Odd(this int i)
    {
        if (i % 2 != 0)
            return true;
        else
            return false;
    }

    //the methods bellow aren't mine, but I know how they work

    public static long Factoriel(long n) 
    {
        return n > 1 ? n * Factoriel(n - 1) : 1;
    }
    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    public static Vector3 BezierCurve(Vector3 A, Vector3 B, Vector3 C, Vector3 D, float t)
    {
        Vector3 E = Vector3.Lerp(A, B, t);
        Vector3 F = Vector3.Lerp(C, D, t);
        return Vector3.Lerp(E, F, t);
    }
    
}
