using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetDialog : MonoBehaviour
{
	public TextAsset csvQuete;
	public TextAsset csvDialog;

	private Dictionary<string, List<string>> dicQuete;
	private Dictionary<string, List<string>> dicDialog;

    private void Start()
    {
        dicDialog = ReadCSV.GetDicFromCsv(csvDialog.text);
        dicQuete = ReadCSV.GetDicFromCsv(csvQuete.text);
    }
    public string getTextQuete(string color) {
		int rdm = Random.Range (0, dicQuete[color].Count);
		return dicQuete [color][rdm];
	}

	public string getTextDialog(string expression) {
		int rdm = Random.Range (0, dicDialog[expression].Count);
		return dicDialog [expression][rdm];
	}

    public List<string> getColor()
    {
        List<string> colors = new List<string>(this.dicQuete.Keys);
        return colors;
    }
}