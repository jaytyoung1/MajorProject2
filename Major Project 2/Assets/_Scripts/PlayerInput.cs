using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    ShipHandler sHandler;

    Vector3 moveInput;
    Vector3 rotInput;

    //bool powered = true;

	// Use this for initialization
	void Start ()
    {
        sHandler = GetComponent<ShipHandler>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //receive input
        float thrust = Input.GetAxisRaw("Thrust");
        //if (thrust > 0 || thrust < 0)
        //{
        //    powered = true;
        //}

        moveInput = new Vector3(0, 0, thrust);
        rotInput = new Vector3(0, 0, 0);
	}

    void FixedUpdate()
    {
        //send input
        sHandler.MoveInput(moveInput, rotInput);
    }
}
