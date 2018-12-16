using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshDisplay : MonoBehaviour {

    public string sortingLayerName = "UI";

    public int sortingOrder = 0;

    private void Awake()
    {
        GetComponent<MeshRenderer>().sortingLayerName = sortingLayerName;
        GetComponent<MeshRenderer>().sortingOrder = 0;
    }
}
