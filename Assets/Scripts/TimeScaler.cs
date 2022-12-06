using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    int multiplier;
    
    
    void Start()
    {
        multiplier = 0;
        StartCoroutine(TimeScaleIncrement());
    }

    
    void Update()
    {
        
    }

    IEnumerator TimeScaleIncrement()
    {

        yield return new WaitForSeconds(15f);
        if (multiplier <= 5)
        {
            multiplier++;
            Debug.Log("Multiplier Value is " + multiplier);
            Debug.Log("Timescale value is " + Time.timeScale);
            Time.timeScale += 0.2f;
            StartCoroutine(TimeScaleIncrement());
        }
        
    }
}
