using UnityEngine;
using System.Collections;

public class ShipHandler : MonoBehaviour
{
    Vector3 posInput;
    Vector3 rotInput;
    public Rigidbody rbody;

    //bool powered = true;
    float speed = 150.0f;

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
            speed = 150.0f;
            rbody.drag = 10;
        }
        else
        {
            speed = 0;
            rbody.drag = 0;
        }

        rbody.AddRelativeForce(posInput * speed);
        rbody.AddRelativeTorque(rotInput);
    }
}
