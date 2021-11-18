using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEditor;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    
    
    
    public struct Screenlayout
    {
        public float x;
        public float y;
    }

    public static Screenlayout scr;
    public static bool isPaused;
    public GameObject music;
    public float volumeMaster;
    public AudioMixer audi;
    
    // Start is called before the first frame update

    private void Awake()
    {
        if (!GameObject.FindGameObjectWithTag("Music"))
        {
            Instantiate(music);
            audi.SetFloat("MasterVol", volumeMaster);
        }
    }
    void Start()
    {
        audi.SetFloat("MasterVol", -30);
        UnPaused();
        Debug.Log("its running okay");
        


    }
    

    // Update is called once per frame

    public void Paused()//When oaysed us triggered
    {
        //stop out time
        Time.timeScale = 0;
        // free out coursor
        Cursor.lockState = CursorLockMode.Confined;
        //see out coursor
        Cursor.visible = true;
    }
    public void UnPaused()
    {
        //unoayse out game 

        //start time
        Time.timeScale = 1;
        //lock out corsor
        Cursor.lockState = CursorLockMode.Confined;
        //hide our cursor 
        Cursor.visible = true;
    }
    void Update()
    {
        //GetKeyDown        On Press
        //GetKey            While Held
        //GetKeyUp          On Realse
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Paused();
                isPaused = true;

            }
            else
            {

                isPaused = false;
                UnPaused();
            }
        }
    }
    private void OnGUI()
    {
        scr.x = Screen.width / 16;
        scr.y = Screen.height / 9;
        if (isPaused)
        {
            MenuLayout();
        }
    }
    void MenuLayout()
    {
        //Background
        GUI.Box(new Rect(6.5f * Screen.width, 3 * Screen.height, 3.25f * Screen.width, 3 * Screen.height), "");
        //Title
        GUI.Box(new Rect(6.5f * scr.x, 3.15f *  scr.y, 3 *  scr.x, 3 *  scr.y), "Time to Go?");
        //Return //if GUI Button on the Screen is pressed
        if (GUI.Button(new Rect(6.5f *  scr.x, 4 *  scr.y, 3 *  scr.x, .35f *  scr.y), "Return"))
        {
            UnPaused();
            isPaused = false;
        }
        GUI.Box(new Rect(6.5f * scr.x, 4.5f * scr.y, 3 * scr.x, .7f * scr.y), "Volume");

        audi.SetFloat("MasterVol", volumeMaster = GUI.HorizontalSlider(new Rect(6.5f * scr.x, 4.9f * scr.y, 3 * scr.x, .35f * scr.y), volumeMaster, -80, 20));
       

        if (GUI.Button(new Rect(6.5f *  scr.x, 5.35f *  scr.y, 3 *  scr.x, .55f *  scr.y), "exit"))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
