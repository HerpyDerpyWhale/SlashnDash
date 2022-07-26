using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    public string nextScene = string.Empty;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(nextScene);
    }
}
