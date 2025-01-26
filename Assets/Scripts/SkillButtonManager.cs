using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonManager : MonoBehaviour
{
    public Button button1;  // Primer bot�n para una habilidad
    public Button button2;  // Segundo bot�n para otra habilidad

    public List<SCRT_Habilidad> habilidades;  // Lista de habilidades (ScriptableObjects)

    public SCRT_HabilidadParametro parametroToModify;  // El parametro a modificar por las habilidades

    private void Start()
    {
        //// Asignamos las funciones a los botones
        //button1.onClick.AddListener(() => OnSkillButtonPressed(0));  // 0 ser� el �ndice de la habilidad
        //button2.onClick.AddListener(() => OnSkillButtonPressed(1));  // 1 ser� el �ndice de la habilidad
    }

    // Esta funci�n se llama cuando se presiona un bot�n de habilidad
    private void OnSkillButtonPressed(int skillIndex)
    {
        // Asegurarnos de que el �ndice est� dentro de los l�mites
        if (skillIndex >= 0 && skillIndex < habilidades.Count)
        {
            SCRT_Habilidad habilidadSeleccionada = habilidades[skillIndex];

            // Modificamos el parametroToModify usando la habilidad seleccionada
            //parametroToModify.valor += habilidadSeleccionada.habilidadParametro.valor;

            // Actualizamos el sprite o realizamos otras acciones, seg�n se necesite
            // Este paso es opcional, dependiendo de c�mo quieras gestionar la UI y efectos visuales
            //Debug.Log($"Habilidad {habilidadSeleccionada.habilidadNombre} aplicada. Nuevo valor: {parametroToModify.valor}");
        }
        else
        {
            Debug.LogWarning("�ndice de habilidad fuera de rango.");
        }
    }
}

