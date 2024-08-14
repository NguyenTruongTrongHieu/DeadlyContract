using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shape shape = collision.GetComponent<Shape>();
        if (shape != null)
        {
            shape.ReturnStartPosition();
        }
    }

}
