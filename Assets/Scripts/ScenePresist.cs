using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePresist : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake()
    {
        int numScenePresists = FindObjectsOfType<ScenePresist>().Length;

        if (numScenePresists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void DestroyScenePersist(){
        Destroy(gameObject);
    }
}
