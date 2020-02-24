using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCScript : MonoBehaviour
{
    public string dialogue;
    public Sprite head;

    GameObject textBoxHolder;
    Text textBox;

    GameObject textBoxImageHolder;
    Image textBoxImage;

    GameObject imageHolder;
    Image face;

    GameObject faceBgHolder;
    Image faceBg;

    GameObject clickBoxHolder;
    Image clickBox;

    GameObject clickTextHolder;
    Text clickText;


    GameObject playerCapsule;
    FirstPersonController playerScript;

    public bool touching = false;

    // Start is called before the first frame update
    void Start()
    {
        playerCapsule = GameObject.Find("playerCapsule");
        playerScript = playerCapsule.GetComponent<FirstPersonController>();

        textBoxHolder = GameObject.Find("TextHolder");
        textBox = textBoxHolder.GetComponent<Text>();

        textBoxImageHolder = GameObject.Find("WhiteTextBox");
        textBoxImage = textBoxImageHolder.GetComponent<Image>();

        imageHolder = GameObject.Find("UIFace");
        face = imageHolder.GetComponent<Image>();

        faceBgHolder = GameObject.Find("FaceBg");
        faceBg = faceBgHolder.GetComponent<Image>();

        clickBoxHolder = GameObject.Find("ClickBox");
        clickBox = clickBoxHolder.GetComponent<Image>();

        clickTextHolder = GameObject.Find("ClickPrompt");
        clickText = clickTextHolder.GetComponent<Text>();



    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
        {
            Debug.Log("Touching");
            if (!playerScript.isTalking)
            {
                Debug.Log("UI Showing Waiting");
                clickText.enabled = true;
                clickBox.enabled = true;

                if (Input.GetMouseButtonDown(0))
                {

                    face.sprite = head;
                    textBox.text = dialogue;

                    textBox.enabled = true;
                    textBoxImage.enabled = true;
                    face.enabled = true;
                    faceBg.enabled = true;

                    clickText.enabled = false;
                    clickBox.enabled = false;

                    playerScript.isTalking = true;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    textBox.enabled = false;
                    textBoxImage.enabled = false;
                    face.enabled = false;
                    faceBg.enabled = false;

                    playerScript.isTalking = false;
                }
            }
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Colliding with Player" + collision.gameObject.name) ;
        if (collision.collider.tag == "Player")
        {
            touching = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Player Left NPC");
        touching = false;
        clickText.enabled = false;
        clickBox.enabled = false;
    }
}
