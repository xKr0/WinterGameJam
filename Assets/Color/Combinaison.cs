using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinaison  {

    public ColorManager.ColorList[][] combinaisons = ColorManager.ColorList.Trash;

    private static Combinaison instance;

    private Combinaison()
    {
        /*for (int i = 0; i < ColorManager.getColorCount(); i++)
        {
            for (int j = 0; j < ColorManager.getColorCount(); j++)
            {
                combinaisons[i][j] = ColorManager.ColorList.Trash;
            } 
        }*/
    }

    public static Combinaison Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Combinaison();
            }
            return instance;
        }
    }

}
