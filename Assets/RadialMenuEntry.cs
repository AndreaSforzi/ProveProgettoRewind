using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class RadialMenuEntry : MonoBehaviour , IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] TextMeshProUGUI _label;
    [SerializeField] Image icon;

    RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    public void SetLabel(string pText)
    {
        _label.text = pText;
    }

    public void SetIcon(Image pIcon)
    {
        icon = pIcon;
    }

    public Image GetIcon()
    {
        return icon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rect.localScale= new Vector3(transform.localScale.x * 1.1f, transform.localScale.y * 1.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rect.localScale = new Vector3(transform.localScale.x * 0.9f, transform.localScale.y * 0.9f);
    }
}
