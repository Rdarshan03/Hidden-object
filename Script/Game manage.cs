using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanagers : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public static Gamemanagers instance;
    [SerializeField]
    private List<hiddenobjectdata> hiddenobjectlist;
    private List<hiddenobjectdata> activehiddenobjectlist;
    [SerializeField]
    private int maxactivehiddenobjcount = 5;
    private int totalhiddenobjectsfoun = 0;
    public GameObject gameover;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) Destroy(gameObject);
    }
    private void Start()
    {
        gameover.SetActive(false);
        activehiddenobjectlist = new List<hiddenobjectdata>();
        hiddenobj();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);
            if (hit && hit.collider != null)
            {

                //  print("object name" + hit.collider.gameObject.name);

                hit.collider.gameObject.SetActive(false);
                uimanager.instance.checkconditions(hit.collider.gameObject.name);

                for (int i = 0; i < activehiddenobjectlist.Count; i++)
                {
                    if (activehiddenobjectlist[i].hiddenobject.name == hit.collider.gameObject.name)
                    {
                        activehiddenobjectlist.RemoveAt(i);
                        break;
                    }

                }
                totalhiddenobjectsfoun++;

                if (totalhiddenobjectsfoun >= maxactivehiddenobjcount)
                {
                    print("level completed");
                    gameover.SetActive(true);
                }
            }
        }
    }
    void hiddenobj()
    {
        totalhiddenobjectsfoun = 0;
        activehiddenobjectlist.Clear();
        for (int i = 0; i < hiddenobjectlist.Count; i++)
        {
            hiddenobjectlist[i].hiddenobject.GetComponent<Collider2D>().enabled = false;
        }
        int k = 0;
        while (k < maxactivehiddenobjcount)
        {
            int randomvalue = Random.Range(0, hiddenobjectlist.Count);

            if (!hiddenobjectlist[randomvalue].makehidden)
            {
                //  hiddenobjectlist[randomvalue].hiddenobject.name = "" + k;
                hiddenobjectlist[randomvalue].makehidden = true;
                hiddenobjectlist[randomvalue].hiddenobject.GetComponent<Collider2D>().enabled = true;

                activehiddenobjectlist.Add(hiddenobjectlist[randomvalue]);
                k++;
            }
        }

        uimanager.instance.hiddenicons(activehiddenobjectlist);

    }
}

[System.Serializable]
public class hiddenobjectdata
{
    public string name;
    public GameObject hiddenobject;
    public bool makehidden = false;
}