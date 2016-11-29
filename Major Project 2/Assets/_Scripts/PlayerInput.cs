using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    ShipHandler sHandler;
    public BulletShooter bShooter;

    Vector3 moveInput;
    Vector3 rotInput;

    //bool powered = true;

	// Use this for initialization
	void Start ()
    {
        sHandler = GetComponent<ShipHandler>();
        //bShooter = GetComponent<BulletShooter>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //receive movement input
        float thrust = Input.GetAxisRaw("Thrust");

        float roll = Input.GetAxisRaw("Roll");
        float yaw = Input.GetAxisRaw("Mouse X");
        float pitch = Input.GetAxisRaw("Mouse Y");
        //if (thrust > 0 || thrust < 0)
        //{
        //    powered = true;
        //}

        //receive shooting input
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("left click");
            bShooter.shoot();
        }

        moveInput = new Vector3(0, 0, thrust);
        rotInput = new Vector3(pitch, yaw, roll);
	}

    void FixedUpdate()
    {
        //send input
        sHandler.MoveInput(moveInput, rotInput);
    }
}
