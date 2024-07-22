using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class uimanager : MonoBehaviour
{
    public static uimanager instance;

    [SerializeField] private GameObject hiddengameobjecticonholder;
    [SerializeField] private GameObject hiddenobjectprefab;
    [SerializeField] private GameObject gamepanel;

    private List<GameObject> hiddeniconobjectlist;



    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) Destroy(gameObject);

        hiddeniconobjectlist = new List<GameObject>();
    }
    public void hiddenicons(List<hiddenobjectdata> activehiddenobjectlist)
    {
        hiddeniconobjectlist.Clear();

        for (int i = 0; i < activehiddenobjectlist.Count; i++)
        {
            GameObject icons = Instantiate(hiddenobjectprefab, hiddengameobjecticonholder.transform);
            icons.name = activehiddenobjectlist[i].hiddenobject.name;
            Image childimage = icons.transform.GetChild(0).GetComponent<Image>();
            Text childtext = icons.transform.GetChild(1).GetComponent<Text>();

            childimage.sprite = activehiddenobjectlist[i].hiddenobject.GetComponent<SpriteRenderer>().sprite;
            childtext.text = activehiddenobjectlist[i].name;

            hiddeniconobjectlist.Add(icons);
        }
    }
    public void checkconditions(string objectname)
    {
        for (int i = 0; i < hiddeniconobjectlist.Count; i++)
        {
            if (hiddeniconobjectlist[i].name == objectname)
            {
                hiddeniconobjectlist[i].SetActive(false);
                break;

            }
        }
    }




}