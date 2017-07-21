using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class Note_Item {
	public string color;
	public float time; 
}

public class XmlParsing : MonoBehaviour {
	public List<Note_Item> itemList = new List<Note_Item>();
	private int noteNum=128;
	private AudioSource audio;
	private float timer;
	public GameObject SpawnObj;

	// Use this for initialization
	void Start () {
		itemList = Read("note");
		audio = GetComponent<AudioSource>();
	}

	public static List<Note_Item> Read(string filePath) {
		TextAsset textxml = (TextAsset)Resources.Load(filePath);
		XmlDocument Document = new XmlDocument();
		Document.LoadXml(textxml.text);

		XmlElement ItemListElement = Document["note"];

		List<Note_Item> ItemList = new List<Note_Item>();

		foreach (XmlElement ItemElement in ItemListElement.ChildNodes) {
			Note_Item Item = new Note_Item();
			Item.color = ItemElement.GetAttribute("color");
			Item.time = System.Convert.ToSingle(ItemElement.GetAttribute("time"));
			ItemList.Add(Item);
		}
		return ItemList;
	}
	
	// Update is called once per frame
	void Update () {
		timer = Time.time + 2.2f;
		timer = Mathf.Round(timer/.01f)*.01f;
		noteRead();
	}

	private void noteRead() {
		for(int i=0;i<=noteNum; i++) {
			if(itemList[i].time == timer) {
				if(itemList[i].color == "red") {
					SpawnObj.SendMessage("RedCreate");
				}
				if(itemList[i].color == "blue") {
					SpawnObj.SendMessage("BlueCreate");
				}
				if(itemList[i].color == "green") {
					SpawnObj.SendMessage("GreenCreate");
				}
				if(itemList[i].color == "yellow") {
					SpawnObj.SendMessage("YellowCreate");
				}
			}
		}
	}
}
