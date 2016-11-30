using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShipHandler : MonoBehaviour
{
    Vector3 posInput;
    Vector3 rotInput;
    Rigidbody rbody;
    public AudioSource restartAudio;
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

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("collision");
            restartAudio.Play();
            StartCoroutine(restartGame());
            //SceneManager.LoadScene("GameScene");
        }
    }

    IEnumerator restartGame()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("GameScene");
    }

    //public void playExplosionAudio()
    //{

    //}
}
