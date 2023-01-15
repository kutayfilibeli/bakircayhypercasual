using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterPlane : MonoBehaviour
{
    public GameObject EnterText;
    public GameObject ExitText;
    public Movement PlayerScript;
    public GameObject PlayerModel;
    public GameObject Plane;
    public GameObject PlanePropeller;

    public bool InPlane;

    private void OnTriggerEnter(Collider other)
    {
        if (InPlane == false)
        {
            if (other.gameObject.name == "Player")
            {
                EnterText.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player" && InPlane == false)
        {
            EnterText.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (InPlane == true)
        {
            EnterText.gameObject.SetActive(false);
            ExitText.gameObject.SetActive(true);
        }
    }
    public void GetInPlane()
    {
        if (InPlane == false)
        {
            PlanePropeller.transform.Rotate(0, 0, 50);
            PlayerScript.transform.position = this.transform.position;
            PlayerScript.transform.rotation = this.transform.rotation;
            this.gameObject.SetActive(false);
            EnterText.gameObject.SetActive(false);
            ExitText.gameObject.SetActive(true);
            PlayerModel.gameObject.SetActive(false);
            Plane.gameObject.SetActive(true);
            PlayerScript.Speed = 60f;
            InPlane = true;
        }
    }

    public void GetOutOfPlane()
    {
        if (InPlane && PlayerScript.transform.position.y <=0)
        {   
            this.transform.position = new Vector3(PlayerScript.transform.position.x, 3.05f, PlayerScript.transform.position.z);
            this.transform.rotation = PlayerScript.transform.rotation;
            this.gameObject.SetActive(true);
            PlayerModel.gameObject.SetActive(true);
            Plane.gameObject.SetActive(false);
            PlayerScript.Speed = 20f;
            InPlane = false;
            ExitText.gameObject.SetActive(false);
        }
    }
}
