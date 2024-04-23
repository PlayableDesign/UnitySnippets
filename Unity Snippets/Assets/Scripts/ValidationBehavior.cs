using System;
using System.Collections.Generic;
using UnityEngine;

public class ValidationBehavior : MonoBehaviour
{
    private List<bool> validations;

    private void Awake()
    {
        validations = new List<bool>();
    }

    public bool IsCondition(Func<bool> condition)
    {
        var result = condition();
        validations.Add(result);
        return result;
    }

    public bool FailedOneOrMore()
    {
        return validations.Contains(false);
    }

    public int Failed()
    {
        var count = 0;

        foreach (var result in validations)
        {
            if (result == false) count++;
        }

        return count;
    }

    public void Reset()
    {
        validations.Clear();
    }

}

