using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadManager : MonoBehaviour
{

    private List<GameObject> HintList = new List<GameObject>();
    public GameObject Hint;
    public Slider load;

    private const int LOAD_TIME= 3;

    float second;
    

    void Start()
    {
        for(int i=0;i<Hint.transform.childCount;i++)
        {
            HintList.Add(Hint.transform.GetChild(i).gameObject);
            Hint.transform.GetChild(i).gameObject.SetActive(false);//Hint�I�u�W�F�N�g�����ׂĔ�\����
        }

       HintList[Random.Range(0, HintList.Count)].SetActive(true);//�����_���őI�΂ꂽ�q���g��\������
    }

    // Update is called once per frame
    void Update()
    {
        if(second<=LOAD_TIME)
        {
            load.value += (1/(float)LOAD_TIME)*Time.deltaTime;
        }

        //�Q�[�W�����܂�����
        if(load.value>=1)
        {
            SceneManager.LoadScene("stage" + stageSelector.stage);
        }
    }
}
