using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionAnswearManager : MonoBehaviour {
    public string[] variants;
    public GameObject questionPattern;
    public GameObject answearPattern;
    GameObject[] messages;
    Vector3 startQuestionPosition;
    Vector3 startAnswearPosition;
    int i = 1;
    int index_answer = 1;
	// Use this for initialization
	void Start () {
        messages = new GameObject[20];
        startQuestionPosition = questionPattern.transform.position;
        startAnswearPosition = answearPattern.transform.position;
        messages[0] = Instantiate(answearPattern, startQuestionPosition, Quaternion.identity);
        messages[0].transform.parent = GameObject.Find("Canvas").transform;
        messages[0].transform.localScale = new Vector3(1, 1, 1);
        //Hardcode((
        messages[0].transform.position = new Vector3(startQuestionPosition.x/76.8f, startQuestionPosition.y/76.8f, startQuestionPosition.z/76.8f);
        messages[0].GetComponentInChildren<Text>().text = variants[0];

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void NextQuestion()
    {

        foreach (var message in messages)
        {
            if (message != null)
                message.transform.position += new Vector3(0, 1.3f, 0);
        }
        GameObject newMessage = Instantiate(questionPattern, startQuestionPosition, Quaternion.identity);
        newMessage.transform.parent = GameObject.Find("Canvas").transform;
        newMessage.GetComponentInChildren<Text>().text = variants[index_answer++];
        newMessage.transform.localScale = new Vector2(1, 1);
        newMessage.transform.position = new Vector3(startQuestionPosition.x / 76.8f, startQuestionPosition.y / 76.8f, startQuestionPosition.z / 76.8f);
        messages[i++] = newMessage;
        foreach (var item in gameObject.GetComponentsInChildren<ChooseVariant>())
        {
            item.Next();
        }
    }
    void NextAnswear()
    {
        GameObject newMessage = Instantiate(answearPattern, startAnswearPosition, Quaternion.identity);
        newMessage.transform.parent = GameObject.Find("Canvas").transform;
        newMessage.transform.localScale = new Vector2(1, 1);
        newMessage.transform.position = new Vector3(startAnswearPosition.x / 76.8f, startAnswearPosition.y / 76.8f, startAnswearPosition.z / 76.8f);
        newMessage.GetComponentInChildren<Text>().text = GameObject.Find("InputField").GetComponent<UnityEngine.UI.InputField>().text;
        messages[i++] = newMessage;
    }
    public void GiveNextMessege()
    {
        foreach (var item in gameObject.GetComponentsInChildren<Button>())
        {
            item.enabled = false;
        }
        foreach (var message in messages)
        {
            if (message != null)
                message.transform.position += new Vector3(0, 1.3f, 0);
        }
        NextAnswear();
        GameObject.Find("InputField").GetComponent<UnityEngine.UI.InputField>().text = "";
        GameObject.Find("Submit").GetComponent<Button>().enabled = false;
        Invoke("NextQuestion",1);
        
    }
}
