/*
	CSVReader by Dock. (24/8/11)
	http://starfruitgames.com
 
	usage: 
	CSVReader.SplitCsvGrid(textString)
 
	returns a 2D string array. 
 
	Drag onto a gameobject for a demo of CSV parsing.
*/

using UnityEngine;
using System.Collections.Generic;
using System.Linq; 

public class ReadCSV : MonoBehaviour 
{
	public TextAsset csvFile; 

	// splits a CSV file into a 2D string array
	static public Dictionary<string, List<string>> GetDicFromCsv(string csvText)
	{
		string[] lines = csvText.Split("\n"[0]); 

		// finds the max width of row
		int width = 0; 
		for (int i = 0; i < lines.Length; i++)
		{
			string[] row = SplitCsvLine( lines[i] ); 
			width = Mathf.Max(width, row.Length); 
		}

		// creates new 2D string grid to output to
		string[,] outputGrid = new string[width + 1, lines.Length + 1]; 
		for (int y = 0; y < lines.Length; y++)
		{
			string[] row = SplitCsvLine( lines[y] ); 
			for (int x = 0; x < row.Length; x++) 
			{
				outputGrid[x,y] = row[x]; 

				// This line was to replace "" with " in my output. 
				// Include or edit it as you wish.
				outputGrid[x,y] = outputGrid[x,y].Replace("\"\"", "\"");
			}
		}
		return ConvertGridToDic(outputGrid);
	}

	static Dictionary<string, List<string>> ConvertGridToDic (string[,] grid) {
		Dictionary<string, List<string>> dic = new Dictionary<string, List<string>> ();
		for (int y = 0; y < grid.GetUpperBound(1); y++) {
			List<string> phrase = new List<string> ();
			for(int x = 1; x < grid.GetUpperBound(0); x++) {
				if(grid[x,y] != "" && grid[x,y] != null) phrase.Add (grid[x,y]);
			}
			dic.Add (grid[0,y].ToString(), phrase);
		}
		return dic;
	}

	// splits a CSV row 
	static string[] SplitCsvLine(string line)
	{
		return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
			@"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)", 
			System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
			select m.Groups[1].Value).ToArray();
	}
}