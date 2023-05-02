using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DeleteEggs : MonoBehaviour
{
    private void Start()
    {
        GameObject[] eggs = GameObject.FindGameObjectsWithTag("BlockToDelete");

        foreach (GameObject egg in eggs)
        {
            egg.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}