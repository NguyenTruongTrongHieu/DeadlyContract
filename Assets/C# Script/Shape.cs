using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shape : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IBeginDragHandler, 
    IDragHandler, IEndDragHandler, IPointerDownHandler
{
    public Image ShapeImage;
    public Vector3 shapeSelectedScale;
    public Vector2 offset = new Vector2 (0f, 700f);
    public bool isInTheBox;
    public bool isChoosen = false;

    private Vector3 shapeStartScale;
    [SerializeField] private RectTransform rectTransform;
    private bool shapeDraggable = true;
    [SerializeField]private Canvas canvas;
    private Vector3 startPosition;
    private Quaternion rotate;

    private BoxCollider2D boxCollider;
    private CanvasGroup canvasGroup;
    private bool trungNhau;

    public void Awake()
    {
        shapeStartScale = this.GetComponent<RectTransform>().localScale;
        rectTransform = this.GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>().GetComponentInParent<Canvas>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        shapeDraggable = true;
        startPosition = rectTransform.localPosition;
        rotate = this.GetComponent<RectTransform>().localRotation;

        canvasGroup = this.GetComponent<CanvasGroup>();
    }

    /*public bool isOnStartPosition()
    { 
        return rectTransform.localPosition == startPosition;
    }*/

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    { 
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = shapeSelectedScale;
        this.GetComponent<BoxCollider2D>().offset = boxCollider.offset;

        //canvasGroup.alpha = .6f;
        //canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchorMin = new Vector2(0,0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.pivot = new Vector2(0, 0);

        //transform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, 
           eventData.position, Camera.main, out pos);
        rectTransform.localPosition = pos + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = shapeStartScale;

        if (trungNhau)
        {
            this.transform.position = startPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("xoay");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GridSquare gridSquare = collision.GetComponent<GridSquare>();
        if (gridSquare != null)
        {
            this.GetComponent<RectTransform>().localScale = shapeSelectedScale;
            isInTheBox = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shape shape = collision.GetComponent<Shape>();
        if (shape != null)
        {
            trungNhau = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GridSquare gridSquare = collision.GetComponent<GridSquare>();
        if (gridSquare != null)
        {
            isInTheBox = false;
        }

        Shape shape = collision.GetComponent<Shape>();
        if (shape != null)
        {
            trungNhau = false;
        }
    }
}
