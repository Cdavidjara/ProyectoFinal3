using UnityEngine;

public class Bala : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObjetoQueHuye"))
        {
            // Destruir el objeto que huye
            Destroy(collision.gameObject);

            // Actualizar el contador de esferas destruidas
            ContadorEsferas contador = FindObjectOfType<ContadorEsferas>();
            if (contador != null)
            {
                contador.AumentarContador();
            }

            // Destruir la bala
            Destroy(gameObject);
        }
    }
}
