using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonManager : MonoBehaviour
{
    public Button button1;  // Primer botón para una habilidad
    public Button button2;  // Segundo botón para otra habilidad

    public List<SCRT_Habilidad> habilidades;  // Lista de habilidades (ScriptableObjects)

    public SCRT_HabilidadParametro parametroToModify;  // El parametro a modificar por las habilidades

    private void Start()
    {
        //// Asignamos las funciones a los botones
        //button1.onClick.AddListener(() => OnSkillButtonPressed(0));  // 0 será el índice de la habilidad
        //button2.onClick.AddListener(() => OnSkillButtonPressed(1));  // 1 será el índice de la habilidad
    }

    // Esta función se llama cuando se presiona un botón de habilidad
    private void OnSkillButtonPressed(int skillIndex)
    {
        // Asegurarnos de que el índice está dentro de los límites
        if (skillIndex >= 0 && skillIndex < habilidades.Count)
        {
            SCRT_Habilidad habilidadSeleccionada = habilidades[skillIndex];

            // Modificamos el parametroToModify usando la habilidad seleccionada
            //parametroToModify.valor += habilidadSeleccionada.habilidadParametro.valor;

            // Actualizamos el sprite o realizamos otras acciones, según se necesite
            // Este paso es opcional, dependiendo de cómo quieras gestionar la UI y efectos visuales
            //Debug.Log($"Habilidad {habilidadSeleccionada.habilidadNombre} aplicada. Nuevo valor: {parametroToModify.valor}");
        }
        else
        {
            Debug.LogWarning("Índice de habilidad fuera de rango.");
        }
    }
}

