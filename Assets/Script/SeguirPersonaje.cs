using UnityEngine;

public class SeguirPersonaje : MonoBehaviour
{
    public Transform objetivo; // El personaje que la bomba seguirá
    public float velocidad = 5f; // Velocidad de seguimiento
    public GameObject efectoExplosion; // Prefab de explosión

    void Update()
    {
        if (objetivo != null)
        {
            // Mover la bomba hacia el objetivo
            Vector3 direccion = (objetivo.position - transform.position).normalized;
            transform.position += direccion * velocidad * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Instanciar el efecto de explosión en la posición de la bomba
            Instantiate(efectoExplosion, transform.position, transform.rotation);

            // Destruir la bomba
            Destroy(gameObject);

            // Llamar a GameOver en el GameManager
            GameManager.Instance.GameOver();
        }
    }
}
