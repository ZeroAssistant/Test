using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dianji : MonoBehaviour
{
    public GameObject player;
    Vector3 Pos = new Vector3(0,0,0);
    int point = 0;
    public GameObject floor;
    int Select = 0;
    List<GameObject> floor1 = new List<GameObject>();

    void Update()
    {
        aa();
    }

    void aa()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            if(Select == 1)
            {
                if(hit.transform.tag == "floor")
                {
                    Pos = new Vector3(hit.transform.position.x, hit.transform.position.y, 0);
                    player.transform.DOLocalMove(Pos, 0.5f);
                    point = 0;
                }
                for (int i = 0; i < floor1.Count; i++)
                {
                    Destroy(floor1[i].gameObject);
                }
                Select = 0;
            }
            else
            {
                if(hit.transform.tag == "Player")
                {
                    Crefloor();
                    Select = 1;
                }
            }
        }
    }

    void Crefloor()
    {
        int k = 1;
        int z = 0;
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < k; j++)
            {
                GameObject floor0 = (GameObject)Instantiate(floor, new Vector3((i - 3) + player.transform.position.x, (j - z) + player.transform.position.y, 1), Quaternion.identity);
                floor1.Add(floor0);
            }
            if(i<3)
            {
                z++;
                k = k + 2;
            }
            else
            {
                z--;
                k = k - 2;
            }
        }
    }


}
