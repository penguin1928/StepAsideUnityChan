using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWallController : MonoBehaviour
{
    public GameObject unitychan;
    public GameObject goal;
    private float difference;

    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
        this.goal = GameObject.Find("Goal");

        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //ユニティちゃんがゴールに到達したら後ろの壁をスタート位置に移動
        if (unitychan.transform.position.z > goal.transform.position.z)
        {
            this.transform.position = new Vector3(0, this.transform.position.y, 0);
        }
        //ユニティちゃんの移動に応じて後ろの壁が追随
        else
        {
            this.transform.position = new Vector3(0, this.transform.position.y,
            this.unitychan.transform.position.z - difference);
        }
    }

    //後ろの壁に衝突するオブジェクトを削除
    void OnTriggerEnter(Collider other)
    {
            Destroy(other.gameObject);
    }
}
