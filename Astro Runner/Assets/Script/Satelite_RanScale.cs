using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To randomly spawn the satelite with different heights

public class Satelite_RanScale : MonoBehaviour
{
    void Start()
    {
        float ranScaleY = Random.Range(0.5f, 1.1f);
        this.transform.localScale = new Vector3(this.transform.localScale.x, ranScaleY, this.transform.localScale.z);
    }
}
