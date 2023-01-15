using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterYacht : MonoBehaviour
{
    public GameObject EnterText;
    public GameObject ExitText;
    public Movement PlayerScript;
    public GameObject PlayerModel;
    public GameObject Yacht;

    public bool InYacht;

    private void OnTriggerEnter(Collider other)
    {
        if (InYacht == false)
        {
            if (other.gameObject.name == "Player")
            {
                EnterText.gameObject.SetActive(true);          
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player" && InYacht == false)
        {
            EnterText.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (InYacht == true)
        {
            EnterText.gameObject.SetActive(false);
            ExitText.gameObject.SetActive(true);
        }
    }
    public void GetInYacht()
    {
        if (InYacht == false)
        {
            PlayerScript.transform.position = this.transform.position;
            PlayerScript.transform.rotation = this.transform.rotation;
            this.gameObject.SetActive(false);
            EnterText.gameObject.SetActive(false);
            ExitText.gameObject.SetActive(true);
            PlayerModel.gameObject.SetActive(false);
            Yacht.gameObject.SetActive(true);
            PlayerScript.Speed = 60f;
            InYacht = true;
        }
    }

    public void GetOutOfYacht()
    {
        if (InYacht)
        {
            this.transform.position = PlayerScript.transform.position;
            this.transform.rotation = PlayerScript.transform.rotation;
            this.gameObject.SetActive(true);
            PlayerModel.gameObject.SetActive(true);
            Yacht.gameObject.SetActive(false);
            PlayerScript.Speed = 20f;
            InYacht = false;
            ExitText.gameObject.SetActive(false);
        }
    }
}
