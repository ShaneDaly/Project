﻿using UnityEngine;
using System.Collections;

public class PickUpItem : MonoBehaviour
{
    void OnTriggerEnter(Collider Scrap)
    {
        Destroy(GameObject.FindWithTag("scrap"));
        var ResourseNumber = +10;
    }
}
