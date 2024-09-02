using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public Transform objective; // El objetivo que la cámara debe seguir

    void Update()
    {
        // La cámara siempre mira al objetivo
        this.transform.LookAt(objective);
    }
}
