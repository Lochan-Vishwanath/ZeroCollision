using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragwithMouse : MonoBehaviour {

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
