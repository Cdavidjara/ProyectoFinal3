using UnityEngine;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public TextMeshProUGUI textoTemporizador; // Asigna el TextMeshProUGUI del temporizador en el Inspector
    public float tiempoLimite = 30f; // Tiempo límite en segundos

    private float tiempoRestante;
    private bool juegoTerminado = false;

    void Start()
    {
        tiempoRestante = tiempoLimite;
        ActualizarTextoTemporizador();
    }

    void Update()
    {
        if (!juegoTerminado)
        {
            tiempoRestante -= Time.deltaTime;
            ActualizarTextoTemporizador();

            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                FinDelJuego();
            }
        }
    }

    private void ActualizarTextoTemporizador()
    {
        textoTemporizador.text = "Tiempo: " + Mathf.Max(0, Mathf.Round(tiempoRestante)).ToString("00");
    }

    private void FinDelJuego()
    {
        juegoTerminado = true;
        GameManager.Instance.GameOver(); // Muestra el mensaje de Game Over
    }

    public void ReiniciarTemporizador()
    {
        tiempoRestante = tiempoLimite;
        juegoTerminado = false;
    }
    public float GetTiempoRestante()
    {
        return tiempoRestante;
    }

}
