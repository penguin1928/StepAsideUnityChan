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
        //�A�C�e�����z�u�������W���g�p�i�ŏ���80m���15m���݁j
        //���j�e�B�����ƃA�C�e�����W�̋�����50m�����ɂȂ����Ƃ�+�A�C�e�����W���S�[�������̂Ƃ����{
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
            //�A�C�e�����W�ɃA�C�e����u������Ɏ��̃A�C�e�����W�ֈړ�
            itemPos += 15;
        }
    }
}
