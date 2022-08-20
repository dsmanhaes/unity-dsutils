using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    void Start()
    {
        foreach (Display display in Display.displays)
        { display.Activate(); }
    }
}
