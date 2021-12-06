using System.Collections;
using UnityEngine;

public class TransitionsLoading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SceneManager>().LoadScene();
    }

}
