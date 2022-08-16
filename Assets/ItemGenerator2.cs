using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator2 : MonoBehaviour
{
    public GameObject unitychan;
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;

    private float posRange = 3.4f;
    private bool flag = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //15mの倍数を基準として判定
        //ユニティちゃんが基準よりも1m超えた場合にflagをtrueに変更
        if (unitychan.transform.position.z % 15 > 1 && flag == false)
        {
            flag = true;
        }

        //ユニティちゃんが基準よりも1m以内に入った場合に実行
        //flagはfalseに変更
        //アイテムをユニティちゃんから見て45m先辺りに生成
        else if (this.unitychan.transform.position.z % 15 < 1 && flag == true)
        {
            flag = false;

            int num = Random.Range(1,11);
            if (num <= 2)
            {
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, 
                        unitychan.transform.position.z + 45);
                }
            }
            else
            {
                for (int j = -1; j <= 1; j++)
                {
                    int item = Random.Range(1, 11);
                    int offsetZ = Random.Range(-5, 6);

                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j,
                            coin.transform.position.y, unitychan.transform.position.z + 45 + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j,
                            car.transform.position.y, unitychan.transform.position.z + 45 + offsetZ);
                    }

                }
            }
        }
    }
}
