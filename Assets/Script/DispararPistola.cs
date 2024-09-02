using UnityEngine;

public class DispararPistola : MonoBehaviour
{
    public GameObject balaPrefab; // Prefab de la bala
    public Transform puntoDisparo; // Punto desde donde se dispara la bala
    public float velocidadBala = 20f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Cambia "F" por la tecla que prefieras
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = puntoDisparo.forward * velocidadBala; // Aplicar velocidad a la bala
    }
}
