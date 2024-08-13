using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour, IDropHandler
{
    public Image normalImage;
    public Image hooverImage;
    public List<Sprite> normalImages;

    public bool selected { get; set; }
    public int squareIndex { get; set; }
    public bool squareOccupied { get; set; }

    void Start()
    {
        selected = false;
        squareOccupied = false;
    }

    public bool CanUseThisSquare()//temp function
    {
        return hooverImage.gameObject.activeSelf;
    }

    public void ActivateSquare()
    {
        Debug.Log("o dang duoc su dung");
        selected = true;
        squareOccupied = true;
    }

    public void SetImage()
    { 
        normalImage.GetComponent<Image>().sprite = normalImages[0];
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        selected = true;
        if (!squareOccupied)
        {
            hooverImage.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!squareOccupied)
        {
            selected = false;
            hooverImage.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!squareOccupied)
        {
            selected = true;
            hooverImage.gameObject.SetActive(true);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        { 
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
