using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SelectionAndRotate : MonoBehaviour
{
    public Button rotate;

    private Transform selection;
    private RaycastHit raycastHit;

    private void Start()
    {
        rotate.onClick.AddListener(RotateItems);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (selection != null)
            {
                selection = null;
            }

            if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
            {
                selection = raycastHit.transform;
                if (selection.CompareTag("Shape"))
                {
                    Debug.Log("xoay");
                }
                else 
                {
                    selection = null;
                }
            }
        }
    }

    public void RotateItems()
    {
        if (selection == null)
        {
            Debug.Log("selection null");
            return;
        }
        if (true)
        {
            var rotation = this.GetComponent<RectTransform>().localRotation;
            rotation.z += 90f;
            selection.GetComponent<RectTransform>().localRotation = rotation;
        }
    }
}
