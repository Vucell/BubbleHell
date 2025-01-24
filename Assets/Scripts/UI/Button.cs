using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Button : MonoBehaviour, IPointerClickHandler, ISelectHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{

    //Opcion de mutear el sonido del boton
    [SerializeField] private bool muteSound;
    //Clip de audio de pulsar el boton
    [SerializeField] private AudioClip pressedSound;
    //Clip de audio del highlight del boton
    [SerializeField] private AudioClip highlightSound;
    //Clip de audio de seleccionar el boton
    [SerializeField] private AudioClip selectSound;
    //
    [SerializeField] private float hoverEffectScale = 0.06f;

    private Vector3 originalScale;
    private bool isPointerDown = false;
    private bool isPointerInside = false;
    public Button buttonComponent;


    void Awake()
    {
        buttonComponent = GetComponent<Button>();
    }

    void Start()
    {
        originalScale = transform.localScale;
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("pointer click");
        //if (buttonComponent.IsInteractable() && !muteSound) PlayButtonPressedSound();
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("on select");
        //if (buttonComponent.IsInteractable() && !muteSound) PlayButtonSelectedSound();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        {
            isPointerInside = true;
            if(!isPointerDown)
            {
                transform.localScale = originalScale * (1f + hoverEffectScale);
                if (!muteSound)
                {
                    AudioSource audio = GetComponent<AudioSource>();
                    audio.clip = highlightSound;
                    audio.Play();
                }
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        {
            isPointerInside = false;
            if (!isPointerDown)
            {
                transform.localScale = originalScale;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        {
            isPointerDown = false;
            transform.localScale = originalScale * (isPointerInside ? (1f + hoverEffectScale) : 1f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        {
            isPointerDown = true;
            if (!muteSound)
            {

                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = pressedSound;
                audio.Play();
            }
            transform.localScale = originalScale * (1f - hoverEffectScale / 2f);
        }
    }

}
