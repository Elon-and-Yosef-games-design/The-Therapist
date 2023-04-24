using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_handler : MonoBehaviour
{

    public void load_scene()
    {
        SceneManager.LoadScene("OAIDemo");
    }
}
