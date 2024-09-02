using UnityEngine;
using TMPro;

public class ContadorEsferas : MonoBehaviour
{
    public TextMeshProUGUI textoContadorEsferas; // Asigna el TextMeshProUGUI del contador de esferas en el Inspector
    public int esferasNecesariasParaGanar = 3; // Número de esferas necesarias para ganar

    private int contadorEsferasDestruidas = 0;

    void Start()
    {
        ActualizarTextoContador();
    }

    public void AumentarContador()
    {
        contadorEsferasDestruidas++;
        ActualizarTextoContador();

        if (contadorEsferasDestruidas >= esferasNecesariasParaGanar)
        {
            GameManager.Instance.Ganaste(); // Muestra el mensaje de victoria
        }
    }

    private void ActualizarTextoContador()
    {
        textoContadorEsferas.text = "Esferas Destruidas: " + contadorEsferasDestruidas;
    }
    public int GetEsferasDestruidas()
    {
        return contadorEsferasDestruidas;
    }

}
