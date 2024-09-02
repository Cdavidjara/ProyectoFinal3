using UnityEngine;

public class SeguirPersonaje : MonoBehaviour
{
    public Transform objetivo; // El personaje que la bomba seguir�
    public float velocidad = 5f; // Velocidad de seguimiento
    public GameObject efectoExplosion; // Prefab de explosi�n

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
            // Instanciar el efecto de explosi�n en la posici�n de la bomba
            Instantiate(efectoExplosion, transform.position, transform.rotation);

            // Destruir la bomba
            Destroy(gameObject);

            // Llamar a GameOver en el GameManager
            GameManager.Instance.GameOver();
        }
    }
}
