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
        //���j�e�B����񂪃S�[���ɓ��B��������̕ǂ��X�^�[�g�ʒu�Ɉړ�
        if (unitychan.transform.position.z > goal.transform.position.z)
        {
            this.transform.position = new Vector3(0, this.transform.position.y, 0);
        }
        //���j�e�B�����̈ړ��ɉ����Č��̕ǂ��ǐ�
        else
        {
            this.transform.position = new Vector3(0, this.transform.position.y,
            this.unitychan.transform.position.z - difference);
        }
    }

    //���̕ǂɏՓ˂���I�u�W�F�N�g���폜
    void OnTriggerEnter(Collider other)
    {
            Destroy(other.gameObject);
    }
}
