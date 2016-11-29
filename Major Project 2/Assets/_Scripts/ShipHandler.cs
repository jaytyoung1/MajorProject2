using UnityEngine;
using System.Collections;

public class ShipHandler : MonoBehaviour
{
    Vector3 posInput;
    Vector3 rotInput;
    Rigidbody rbody;

    //bool powered = true;
    float shipSpeed = 150.0f;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    public void MoveInput(Vector3 move, Vector3 rote)
    {
        posInput = move;
        rotInput = rote;
        //powered = power;

        ActuallyMove();
    }

    void ActuallyMove()
    {
        if (posInput.z != 0)
        {
            shipSpeed = 150.0f;
            //rbody.drag = 10;
        }
        else
        {
            shipSpeed = 0;
            //rbody.drag = 10;
        }

        rbody.AddRelativeForce(posInput * shipSpeed);
        rbody.AddRelativeTorque(rotInput);
        //transform.Rotate(rotInput);
    }
}
