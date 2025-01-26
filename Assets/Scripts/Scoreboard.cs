using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    //[System.Serializable]
    //public class Score
    //{
    //    public string nombre;
    //    public int scoreValue;
    //}

    //public List<Score> scoreList = new List<Score>();
    //public Transform contenedorPuntajes; // Contenedor para los elementos del scoreboard
    //public GameObject prefabPuntaje;    // Prefab para cada fila del scoreboard
    //public InputField inputNombre;      // Campo para que el jugador escriba su nombre
    //public Text puntajeJugadorActual;   // Puntaje del jugador actual

    //private int puntajeActual;

    //void Start()
    //{
    //    // Cargar puntajes al iniciar el juego
    //    CargarPuntajes();
    //    ActualizarScoreboard();
    //}

    //public void AñadirPuntaje()
    //{
    //    // Obtener el nombre del jugador y añadir un puntaje
    //    string nombre = string.IsNullOrEmpty(inputNombre.text) ? "Jugador" : inputNombre.text;
    //    scoreList.Add(new Score { nombre = nombre, scoreValue = puntajeActual });

    //    // Ordenar puntajes de mayor a menor
    //    scoreList.Sort((a, b) => b.puntaje.CompareTo(a.puntaje));

    //    // Limitar a los 10 mejores puntajes
    //    if (scoreList.Count > 10)
    //        scoreList.RemoveAt(scoreList.Count - 1);

    //    // Guardar y actualizar el scoreboard
    //    GuardarPuntajes();
    //    ActualizarScoreboard();
    //}

    //private void ActualizarScoreboard()
    //{
    //    // Limpiar el contenido previo
    //    foreach (Transform child in contenedorPuntajes)
    //    {
    //        Destroy(child.gameObject);
    //    }

    //    // Crear un nuevo elemento para cada puntaje
    //    foreach (var puntaje in scoreList)
    //    {
    //        GameObject nuevoElemento = Instantiate(prefabPuntaje, contenedorPuntajes);
    //        nuevoElemento.GetComponent<Text>().text = $"{puntaje.nombre} - {puntaje.puntaje}";
    //    }
    //}

    //private void GuardarPuntajes()
    //{
    //    for (int i = 0; i < scoreList.Count; i++)
    //    {
    //        PlayerPrefs.SetString($"PuntajeNombre{i}", scoreList[i].nombre);
    //        PlayerPrefs.SetInt($"PuntajeValor{i}", scoreList[i].puntaje);
    //    }
    //    PlayerPrefs.Save();
    //}

    //private void CargarPuntajes()
    //{
    //    scoreList.Clear();
    //    for (int i = 0; i < 10; i++)
    //    {
    //        if (PlayerPrefs.HasKey($"PuntajeNombre{i}"))
    //        {
    //            string nombre = PlayerPrefs.GetString($"PuntajeNombre{i}");
    //            int puntaje = PlayerPrefs.GetInt($"PuntajeValor{i}");
    //            scoreList.Add(new Score { nombre = nombre, scoreValue = puntaje });
    //        }
    //    }
    //}

    //// Método para establecer el puntaje actual del jugador
    //public void EstablecerPuntajeActual(int puntaje)
    //{
    //    puntajeActual = puntaje;
    //    puntajeJugadorActual.text = $"Puntaje: {puntajeActual}";
    //}
}
