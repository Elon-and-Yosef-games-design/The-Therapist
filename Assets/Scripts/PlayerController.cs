using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenAI_Unity;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public InputField questionInput;
    public float speakRange = 10;

    [SerializeField] TextMeshProUGUI chat;

    private Rigidbody rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    
        questionInput.onEndEdit.AddListener((string data) =>
        {
            if (!string.IsNullOrEmpty(data))
            {
                Collider[] surroundingColliders = Physics.OverlapSphere(this.transform.position, this.speakRange);
                foreach (Collider c in surroundingColliders)
                {
                    var ai = c.GetComponent<OAICharacter>();
                    if (ai)
                    {
                        chat.text = chat.text +"\nYou:"+ data;
                        ai.AddToStory(data);
                    }
                }
            }
            questionInput.text = "";
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            questionInput.Select();
            questionInput.ActivateInputField();
        }

    }



}
