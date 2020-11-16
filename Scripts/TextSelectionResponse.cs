using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSelectionResponse : MonoBehaviour, ISelectionResponse
{
    public Canvas canvas;

    public void OnDeselect(Transform selection)
    {
        canvas.gameObject.SetActive(false);
    }

    public void OnSelect(Transform selection)
    {
        var height = selection.transform.localScale.y;
        canvas.transform.position = new Vector3(selection.transform.position.x, height * 1.75f, selection.transform.position.z);
        canvas.gameObject.SetActive(true);
    }
}
