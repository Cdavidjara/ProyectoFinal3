using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huir : MonoBehaviour
{
    public float velocidad = 5f;
    public Transform objetivo; // El personaje al que deben huir las esferas
    public Vector3 limitesMinimos; // Coordenadas mínimas del plano
    public Vector3 limitesMaximos; // Coordenadas máximas del plano

    private float y;

    void Start()
    {
        y = transform.position.y;
    }

    void Update()
    {
        if (objetivo != null)
        {
            // Calcular la dirección opuesta al objetivo
            Vector3 direccion = (transform.position - objetivo.position).normalized;

            // Mover en la dirección opuesta
            Vector3 nuevaPosicion = transform.position + direccion * velocidad * Time.deltaTime;

            // Limitar el movimiento dentro de los límites del plano
            nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, limitesMinimos.x, limitesMaximos.x);
            nuevaPosicion.z = Mathf.Clamp(nuevaPosicion.z, limitesMinimos.z, limitesMaximos.z);
            nuevaPosicion.y = y; // Mantener la altura original

            transform.position = nuevaPosicion;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bala"))
        {
            Destroy(gameObject); // Destruir la esfera si colisiona con una bala
            Destroy(other.gameObject); // Destruir la bala al colisionar
        }
    }
}
