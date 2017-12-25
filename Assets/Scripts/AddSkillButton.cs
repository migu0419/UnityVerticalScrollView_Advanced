using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSkillButton : MonoBehaviour {

	private GameObject content;
	private GameObject textPrefab;
	private Button getSkillButton;
	private List<string> skillList = new List<string>();
	private Text informationText;
	private int learnedSkillCount = 0;
	private int maxSkillCount = 0;
	private Vector3 informationTextOffsetPosition = new Vector3(380,0,0);

	void Awake(){
		// skillListリストに要素を追加
		skillList.Add ("料理");
		skillList.Add ("栽培");
		skillList.Add ("鑑定");
		skillList.Add ("園芸");
		skillList.Add ("裁縫");
		skillList.Add ("調合");
		skillList.Add ("整頓");
		skillList.Add ("彫金");
		skillList.Add ("木工");
		skillList.Add ("鍛治");
		skillList.Add ("採掘");
		skillList.Add ("精製");
		skillList.Add ("水泳");
		skillList.Add ("錬金");
		skillList.Add ("合成");
		skillList.Add ("分解");
		skillList.Add ("演奏");
		skillList.Add ("作曲");
		skillList.Add ("歌唱");
		skillList.Add ("休憩");
		Debug.Log (skillList.Count);
		content = GameObject.Find ("Content");
		textPrefab = (GameObject)Resources.Load("Prefabs/Text");
		getSkillButton = transform.GetComponent<Button> ();
		informationText = GameObject.Find ("InformationText").GetComponent<Text>();
		maxSkillCount = skillList.Count;
	}

	public void OnClickAddSkillButton(){
		// skillListリストに要素が残っている場合
		if (skillList.Count > 0) {
			GameObject _text = Instantiate (textPrefab, content.transform);
			int index = Random.Range (0, skillList.Count);
			_text.GetComponent<Text> ().text = skillList [index];
			skillList.RemoveAt (index);
			learnedSkillCount++;
			informationText.text = learnedSkillCount+"/"+maxSkillCount;
			informationText.transform.SetAsLastSibling ();
			StartCoroutine (Wait ());
			Debug.Log (_text.transform.localPosition);
			informationText.transform.localPosition = _text.transform.localPosition + informationTextOffsetPosition;
			Debug.Log (skillList.Count);
			// 要素が無くなったらボタンを押せないようにし、文言を変更する
			if (skillList.Count <= 0) {				
				getSkillButton.interactable = false;
				getSkillButton.GetComponentInChildren<Text> ().text = "GetAllSkill!";
				Debug.Log ("GetALLSkill!");
			}
		}
	}

	private IEnumerator Wait(){
		yield return new WaitForEndOfFrame ();
	}
}
