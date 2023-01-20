using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrainCollector : MonoBehaviour
{
    public GameObject collectablePrefab;
    public GameObject dropZone;
    public GameObject carriage;
    public TextMeshPro collectedMetalTxt;

    public int CollectedMetal = 0;

    private void Update()
    {
        collectedMetalTxt.text = CollectedMetal.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectable"))
        {
            Destroy(other);
            CollectedMetal++;
            Instantiate(collectablePrefab, carriage.transform);
        }

        if (other.gameObject.tag == "Station")
        {
            for (int i = 0; i < CollectedMetal; i++)
            {
                Instantiate(collectablePrefab, dropZone.transform);
            }
        }
    }
}
