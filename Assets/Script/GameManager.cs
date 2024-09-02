using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking; // Necesario para UnityWebRequest
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject gameOverText;
    public GameObject ganasteText;
    public TextMeshProUGUI textoTemporizador;

    private ContadorEsferas contadorEsferas;
    private Temporizador temporizador;

    private bool juegoTerminado = false; // Añadir esta variable

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        contadorEsferas = FindObjectOfType<ContadorEsferas>();
        temporizador = FindObjectOfType<Temporizador>();
    }

    public void GameOver()
    {
        if (juegoTerminado) return; // Evitar duplicación si el juego ya está terminado

        juegoTerminado = true; // Marcar el juego como terminado
        gameOverText.SetActive(true);
        Time.timeScale = 0;

        // Enviar datos a la base de datos
        StartCoroutine(EnviarDatos("Game Over"));
    }

    public void Ganaste()
    {
        if (juegoTerminado) return; // Evitar duplicación si el juego ya está terminado

        juegoTerminado = true; // Marcar el juego como terminado
        ganasteText.SetActive(true);
        Time.timeScale = 0;

        // Enviar datos a la base de datos
        StartCoroutine(EnviarDatos("Ganaste"));
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator EnviarDatos(string resultado)
    {
        WWWForm form = new WWWForm();
        form.AddField("esferas_destruidas", contadorEsferas.GetEsferasDestruidas());
        form.AddField("tiempo_restante", temporizador.GetTiempoRestante().ToString("F2")); // Convertir float a string con dos decimales
        form.AddField("fecha", System.DateTime.Now.ToString("yyyy-MM-dd"));
        form.AddField("resultado", resultado);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Proyecto/proyecto.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error al enviar datos: " + www.error);
            }
            else
            {
                Debug.Log("Datos enviados correctamente.");
            }
        }
    }
}
