using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathSceneManager : MonoBehaviour
{
    public Image redScreen;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine("fadeRedScreen");
	}

    IEnumerator fadeRedScreen()
    {
        for (float f = 3f; f >= 0; f -= 0.02f)
        {
            Color c = redScreen.color;
            //Color c = renderer.material.color;
            c.a = f;
            redScreen.color = c;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
