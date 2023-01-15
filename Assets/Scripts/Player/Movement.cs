using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public VariableJoystick joystick;
    public Animator animCtrl;
    public EnterCar CarScript;
    public EnterPlane PlaneScript;

    public float Speed = 5f;
    public float RotationSpeed = 10f;
    public float CarTireRotationSpeed;
    public float PlanePropellerRotationSpeed;

   
    void Update()
    {
        if (joystick == null)
            return;

        if (animCtrl == null)
            return;


        Vector2 direction = joystick.Direction;

        Vector3 movementVector = new Vector3(direction.x, 0, direction.y);

        movementVector = movementVector * Time.deltaTime * Speed;

        transform.position += movementVector;
        //movementCache += movementVector;

        if (movementVector.magnitude != 0)
        {
            //transform.forward = movementVector;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVector, Vector3.up), Time.deltaTime * RotationSpeed);
        }


        //bool isWalking = direction != Vector2.zero;
        bool isWalking = direction.magnitude > 0;

        animCtrl.SetBool("IsWalking", isWalking);

        animCtrl.SetFloat("SpeedValue", direction.magnitude);
        
        if (CarScript.InCar == true)
        {            
            if (isWalking)
            {
                CarScript.CarTire.transform.Rotate(CarTireRotationSpeed * Time.deltaTime, 0, 0);
                CarScript.CarTire2.transform.Rotate(CarTireRotationSpeed * Time.deltaTime, 0, 0);
                CarScript.CarTire3.transform.Rotate(CarTireRotationSpeed * Time.deltaTime, 0, 0);
                CarScript.CarTire4.transform.Rotate(CarTireRotationSpeed * Time.deltaTime, 0, 0);
            }
            else if(isWalking == false)
            {
                CarScript.CarTire.transform.Rotate(0, 0, 0);
                CarScript.CarTire2.transform.Rotate(0, 0, 0);
                CarScript.CarTire3.transform.Rotate(0, 0, 0);
                CarScript.CarTire4.transform.Rotate(0, 0, 0);
            }
        }
        if (PlaneScript.InPlane == true)
        {
            PlaneScript.PlanePropeller.transform.Rotate(0, 0, PlanePropellerRotationSpeed * Time.deltaTime);
            if (isWalking)
            {
                StartCoroutine(FlyPlane());
            }
            else
            {
                LandPlane();
                PlaneScript.transform.Rotate(45, 0, 0);
                
            }
        }
        

        
        

    }
    void LandPlane()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0, 50f), transform.position.z);
        transform.Translate(0, -5f * Time.deltaTime, 0);

    }
    IEnumerator FlyPlane()
    {
        yield return new WaitForSeconds(2f);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0, 50f), transform.position.z);
        transform.Translate(0, 3f * Time.deltaTime, 0);
    }
}
