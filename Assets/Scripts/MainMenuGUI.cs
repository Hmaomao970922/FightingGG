 using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class MainMenuGUI : MonoBehaviour
{

    public AudioClip beep;
    public GUISkin menuSkin;
    public Rect menuArea;
    public Rect playButton;
    public Rect SettingsButton;
    public Rect quitButton;
    public Rect instructions;
    Rect menuAreaNormalized;
    string menuPage = "main";
    // Use this for initialization
    void Start()
    {

        menuAreaNormalized =
            new Rect(menuArea.x * Screen.width - (menuArea.width * 0.5f), menuArea.y * Screen.height - (menuArea.height * 0.5f), menuArea.width, menuArea.height);
    }
    void OnGUI()
    {
        GUI.skin = menuSkin;
        GUI.BeginGroup(menuAreaNormalized);
        if (menuPage == "main")
        {
            if (GUI.Button(new Rect(playButton), "play"))
            {
                StartCoroutine("ButtonAction", "Main");
                //Application.LoadLevel("second");
            }
            if (GUI.Button(new Rect(SettingsButton), "Settings"))
            {
                GetComponent<AudioSource>().PlayOneShot(beep);
                menuPage = "Settings";

            }
            if (GUI.Button(new Rect(quitButton), "Quit"))
            {
                StartCoroutine("ButtonAction", "quit");
                Application.Quit();
            }
        }
       if (menuPage == "Settings")
        {
            GUI.Label(new Rect(0,100,200,40), "nothing here,LOL");
            if (GUI.Button(new Rect(quitButton), "Back"))
            {
                GetComponent<AudioSource>().PlayOneShot(beep);
                menuPage = "main";
            }
        }
        GUI.EndGroup();
    }
    IEnumerator ButtonAction(string levelName)
    {
        GetComponent<AudioSource>().PlayOneShot(beep);
        yield return new WaitForSeconds(0.35f);

        if (levelName != "quit")
        {
            Application.LoadLevel(levelName);
        }
        else
        {
            Application.Quit();
            Debug.Log("Have Quit");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}