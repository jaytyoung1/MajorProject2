using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    ShipHandler sHandler;
    public BulletShooter bShooter;
    public AudioSource thrustAudio;
    public AudioSource explosionAudio;

    [HideInInspector]
    public bool isExplosion = false;

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
        //if (isExplosion)
        //    Debug.Log("EXPLOSION\n\n");
        //else if (!isExplosion)
        //    Debug.Log("is not Explosion");

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
            //Debug.Log("left click");
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

    //public IEnumerator playExplosionAudioCO()
    //{
    //    explosionAudio.Play();
    //    yield return new WaitForSecondsRealtime(5);
    //}
    void FixedUpdate()
    {
        //send input
        sHandler.MoveInput(moveInput, rotInput);
    }
}
