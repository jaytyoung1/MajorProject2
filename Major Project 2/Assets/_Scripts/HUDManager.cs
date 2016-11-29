using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    //public Quaternion rotation = Quaternion.identity;
    public GameObject ship;
    public Text statsDisplay;
    float pitchValue;
    float yawValue;
    float rollValue;
    float zPos;
    string stats = "";


	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        //float dy = (Input.mousePosition.y - (Screen.height / 2)) / (Screen.height / 2);
        //float pitchAngle = dy * 180f;
        pitchValue = ship.gameObject.transform.eulerAngles.x;
        pitchValue = pitchValue - 360f;
        pitchValue = pitchValue * -1;
        //Debug.Log(pitchValue);
        yawValue = ship.gameObject.transform.eulerAngles.y;
        rollValue = ship.gameObject.transform.eulerAngles.z;
        rollValue = 360 - rollValue;
        zPos = ship.gameObject.transform.position.z;

        if (pitchValue > 180f)
        {
            pitchValue = pitchValue - 360;
        }
        if (yawValue > 180f)
        {
            yawValue = yawValue - 360;
        }
        if (rollValue > 180f)
        {
            rollValue = rollValue - 360;
        }
        //else
        //{
        //    pitchValue = 360 - pitchValue;
        //}

        pitchValue = Mathf.Round(pitchValue * 1000f) / 1000f;
        yawValue = Mathf.Round(yawValue * 1000f) / 1000f;
        rollValue = Mathf.Round(rollValue * 1000f) / 1000f;
        zPos = Mathf.Round(zPos * 1000f) / 1000f;

        stats = "Pitch: " + pitchValue + 
                "\nYaw: " + yawValue + 
                "\nRoll: " + rollValue +
                "\nZ-Pos: " + zPos + "\n";
        statsDisplay.text = stats;
	}
}
