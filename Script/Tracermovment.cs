using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tracermovment : MonoBehaviour
{
    public float baseVelocity = 5F;
    public Rigidbody rigi = null;
    public float rotationv = 10F;
    private bool loose = false;
    public string wallname = null;
    public GameObject loooser = null;
    public string winin = null;
    public float numberofwin = 0F;
    public GameObject winobjectText=null;
    private bool winner = false;
    public GameObject WinToText = null;
    private Text towinscore;
    public AudioSource collectedServiceWhen;
    void Start()
    {
        rigi.velocity = transform.right * baseVelocity;
        loooser.SetActive(false);
        winobjectText.SetActive(false);
        WinToText.SetActive(true);
        towinscore =WinToText.GetComponent<UnityEngine.UI.Text>();
        towinscore.text = "You have to collect " + numberofwin.ToString()+" Objects";/*https://answers.unity.com/questions/848230/how-to-edit-ui-text-from-script.html
    */}

    void Update()
    {
        if (numberofwin <= 0&&!loose) {
            winobjectText.SetActive(true);
            winner = true;
            WinToText.SetActive(false);
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (!loose&&!winner)
        {
            float rotation = 0F;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rotation = 0F - rotationv;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                rotation = rotationv;
            }
            if (rotation != 0F)
            {
                transform.Rotate(0F, rotation, 0F);
                rigi.velocity = transform.right * baseVelocity;
            }
            rigi.velocity = transform.right * baseVelocity;
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == wallname&&!winner)
        {
            loose = true;
            loooser.SetActive(true);
            WinToText.SetActive(false);
        }
        else if(coll.gameObject.name == winin){
            coll.gameObject.SetActive(false);
            collectedServiceWhen.Play();
            numberofwin--;
            towinscore.text = "You have to collect " + numberofwin.ToString() + " Objects";
        }
    }
    public void reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
