using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public Transform objective; // El objetivo que la c�mara debe seguir

    void Update()
    {
        // La c�mara siempre mira al objetivo
        this.transform.LookAt(objective);
    }
}
