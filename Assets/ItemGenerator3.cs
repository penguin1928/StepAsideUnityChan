using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator3 : MonoBehaviour
{
    public GameObject unitychan;
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    private int itemPos = 80;
    private int goalPos = 360;
    private float posRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //アイテムが配置される座標を使用（最初の80mより15m刻み）
        //ユニティちゃんとアイテム座標の距離が50m未満になったとき+アイテム座標がゴール未満のとき実施
        if (itemPos - this.unitychan.transform.position.z < 50 && itemPos < goalPos)
        {
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, itemPos);
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
                            coin.transform.position.y, itemPos + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j,
                            car.transform.position.y, itemPos + offsetZ);
                    }
                }
            }
            //アイテム座標にアイテムを置いた後に次のアイテム座標へ移動
            itemPos += 15;
        }
    }
}
