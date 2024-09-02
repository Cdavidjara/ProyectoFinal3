using UnityEngine;

public class RecogerPistola : MonoBehaviour
{
    public Transform posicionMano; // Aqu� asignar�s el transform de la mano del personaje
    private GameObject pistola; // Referencia a la pistola que el personaje recoger�

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pistol"))
        {
            pistola = other.gameObject;
            pistola.transform.SetParent(posicionMano); // Asignar como hijo de la mano
            pistola.transform.localPosition = Vector3.zero; // Ajustar posici�n local
            pistola.transform.localRotation = Quaternion.identity; // Ajustar rotaci�n local

            // Desactivar el collider y el Rigidbody de la pistola
            pistola.GetComponent<Collider>().enabled = false;
            pistola.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
