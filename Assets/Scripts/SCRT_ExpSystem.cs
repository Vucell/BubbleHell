using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SCRT_ExpSystem : MonoBehaviour
{
    [Header("Experience Bar Settings")]
    public Slider expBar; // Barra de experiencia como Slider
    public Text expText; // Texto opcional para mostrar el progreso (por ejemplo: "30/100")
    public float maxExp = 100f; // Experiencia m�xima necesaria para llenar la barra
    public float currentExp = 0f; // Experiencia actual

    [Header("Level Settings")]
    public int currentLevel = 1; // Nivel actual del jugador
    public float expIncreasePerRound = 50f; // Incremento de la experiencia m�xima por cada ronda

    //SCORE SYSTEM
    public int INT_TOTAL_Score;

    public GameObject canvasScore;
    public GameObject FinalScore;


    public List<SCRT_Habilidad> habilidades;  // Lista de habilidades (ScriptableObjects)

    //public SCRT_HabilidadParametro parametroToModify;

    [Header("Pause Canvas Settings")]
    public Canvas pauseCanvas; // Canvas con los botones de pausa
    public UnityEngine.UI.Button optionButton1;
    public UnityEngine.UI.Button optionButton2;
    public Text countdownText; // Texto del temporizador de cuenta atr�s
    private float countdownTime = 25f; // Tiempo de cuenta atr�s en segundos
    private bool isPaused = false; // Bandera para pausar el juego

    private Coroutine countdownRoutine; // Rutina del temporizador
    private float remainingTime;



    private void Start()
    {
        canvasScore = GameObject.FindGameObjectWithTag("CanvasScore");
        FinalScore = GameObject.FindGameObjectWithTag("FinalScore");
        canvasScore.SetActive(false);


        expBar.maxValue = maxExp; // Configurar el valor m�ximo del Slider
        expBar.value = currentExp; // Inicializar el valor actual

        pauseCanvas.enabled = false; // Ocultar el canvas de pausa al inicio

        optionButton1.onClick.AddListener(() => OnButtonPressed(1));
        optionButton2.onClick.AddListener(() => OnButtonPressed(2));

        
    }

    public void AddExperience(float amount)
    {
        currentExp += amount; // A�adir experiencia
        expBar.value = currentExp; // Actualizar el Slider

        if (expText != null)
            expText.text = $"{currentExp}/{maxExp}"; // Actualizar texto de experiencia

        if (currentExp >= maxExp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentExp = 0f; // Reiniciar experiencia actual
        currentLevel++; // Incrementar el nivel del jugador
        maxExp += expIncreasePerRound; // Incrementar la experiencia m�xima necesaria

        expBar.maxValue = maxExp; // Actualizar el valor m�ximo del Slider
        expBar.value = currentExp; // Reiniciar el Slider

        PauseGame(); // Pausar el juego y mostrar opciones
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pausar el tiempo del juego
        pauseCanvas.enabled = true; // Mostrar el canvas de pausa

        IDHabilidades();

        countdownRoutine = StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        float remainingTime = countdownTime;

        while (remainingTime > 0)
        {
            Debug.Log($"Time left: {remainingTime:F1} seconds");
            countdownText.text = $"Time left: {remainingTime:F1} seconds";
            remainingTime -= Time.unscaledDeltaTime;
            yield return null;
        }

        // Si se acaba el tiempo sin interacci�n, seleccionar un bot�n aleatorio
        int randomChoice = Random.Range(1, 3);
        OnButtonPressed(randomChoice);
    }




    private void OnButtonPressed(int buttonIndex)
    {
        if (countdownRoutine != null)
            StopCoroutine(countdownRoutine);

        //IDHabilidades(); //El boton sprite.
        // Acciones al pulsar un bot�n
        if (buttonIndex == 1)
        {
            Debug.Log("Bot�n 1 presionado: Opci�n 1 seleccionada.");

            boton_01();
        }
        else if (buttonIndex == 2)
        {
            Debug.Log("Bot�n 2 presionado: Opci�n 2 seleccionada.");

            boton_02();
        }

        ResumeGame(); // Reanudar el juego despu�s de presionar un bot�n
    }

    public int ID1;
    public int ID2;
    public NuevaHabilidad[] CambioNuebaHabilidad;
    //playerobject.GetComponent<SCRT_Atack_Player>().projectilePrefab.GetComponent<SCRT_proyectile_Player>().damage;
    public void boton_01()
    {
        //habilidades[ID1].playerObject = GameObject.FindGameObjectWithTag("player");

        //habilidades[ID1].cambioStats(habilidades[ID1].IDHabilidad);
        CambioNuebaHabilidad[0].cambioStats(ID1);
    }
    public void boton_02()
    {
        //habilidades[ID2].playerObject = GameObject.FindGameObjectWithTag("player");
        //habilidades[ID2].cambioStats(habilidades[ID2].IDHabilidad);
        CambioNuebaHabilidad[1].cambioStats(ID2);
    }

    public void IDHabilidades()
    {
        ID1 = Random.Range(0, 3);
        ID2 = Random.Range(0, 3);

        optionButton1.GetComponent<Image>().sprite = CambioNuebaHabilidad[0].HabilidadSprite[ID1];
        optionButton2.GetComponent<Image>().sprite = CambioNuebaHabilidad[1].HabilidadSprite[ID2];
        //optionButton1.GetComponent<Image>().sprite = habilidades[ID1].HabilidadSprite[ID1];
        //optionButton2.GetComponent<Image>().sprite = habilidades[ID2].HabilidadSprite[ID2];

    }


    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Reanudar el tiempo del juego
        pauseCanvas.enabled = false; // Ocultar el canvas de pausa
    }

    public void FinalGame()
    {
        canvasScore.SetActive(true);
        FinalScore.GetComponent<Text>().text = "SCORE: " + INT_TOTAL_Score.ToString();
    }
}
