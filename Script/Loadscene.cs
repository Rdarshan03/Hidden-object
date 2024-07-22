using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadscene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void btnplay()
    {
        SceneManager.LoadScene("Levels");
    }
    public void btnBack()
    {
        SceneManager.LoadScene("Home");
    }


}
