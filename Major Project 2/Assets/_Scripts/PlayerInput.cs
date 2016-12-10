using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    ShipHandler sHandler;
    public BulletShooter bShooter;
    public AudioSource thrustAudio;
    public AudioSource explosionAudio;
    Vector3 moveInput;
    Vector3 rotInput;

	// Use this for initialization
	void Start ()
    {
        sHandler = GetComponent<ShipHandler>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //receive movement input
        float thrust = Input.GetAxisRaw("Thrust");

        float roll = Input.GetAxisRaw("Roll");
        float yaw = Input.GetAxisRaw("Mouse X");
        float pitch = Input.GetAxisRaw("Mouse Y");
        if (thrust > 0 || thrust < 0)
        {
            //powered = true;
            if (!thrustAudio.isPlaying)
                thrustAudio.Play();
        }
        else
        {
            if (thrustAudio.isPlaying)
                thrustAudio.Stop();
        }

        //receive shooting input
        if (Input.GetMouseButtonDown(0))
        {
            bShooter.shoot();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("WelcomeScene");
        }

        moveInput = new Vector3(0, 0, thrust);
        rotInput = new Vector3(pitch, yaw, roll);
	}

    public void playExplosionAudio()
    {
        explosionAudio.Play();
    }

    void FixedUpdate()
    {
        //send input
        sHandler.MoveInput(moveInput, rotInput);
    }
}
