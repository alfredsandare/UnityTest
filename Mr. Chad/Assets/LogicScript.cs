using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public GameObject[] groundObjects;


    void Start()
    {
        groundObjects = GameObject.FindGameObjectsWithTag("ground");
    }

    void Update()
    {
        
    }
}
