using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public LogicaPersonaje1 logicaPersonaje1;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        logicaPersonaje1.puedoSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        logicaPersonaje1.puedoSaltar = false;
    }
}
