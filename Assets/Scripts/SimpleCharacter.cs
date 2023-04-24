using OpenAI_API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleCharacter : MonoBehaviour
{
    public TextBubble ResponseTextPrefab;
    private Animator anim;
    [SerializeField] TextMeshProUGUI chat;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Think (string text)
    {
        anim.SetTrigger("Think");
    }

    public void Talk(List<Choice> choices)
    {
        Instantiate(ResponseTextPrefab).Init(this.gameObject, choices[0].Text);
        chat.text = chat.text + "\nChad:" + choices[0].Text;
        anim.SetTrigger("Talk");
    }
}
