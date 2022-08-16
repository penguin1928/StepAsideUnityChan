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
        //15m�̔{������Ƃ��Ĕ���
        //���j�e�B����񂪊����1m�������ꍇ��flag��true�ɕύX
        if (unitychan.transform.position.z % 15 > 1 && flag == false)
        {
            flag = true;
        }

        //���j�e�B����񂪊����1m�ȓ��ɓ������ꍇ�Ɏ��s
        //flag��false�ɕύX
        //�A�C�e�������j�e�B����񂩂猩��45m��ӂ�ɐ���
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
