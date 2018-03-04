using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinaison  {

    public ColorSheepEnum[,] combinaisons;

    public Combinaison(ColorManager colorManager)
    {
        combinaisons = new  ColorSheepEnum[colorManager.GetColorCount(), colorManager.GetColorCount()];

        for (int i = 0; i < colorManager.GetColorCount(); i++)
        {
            for (int j = 0; j < colorManager.GetColorCount(); j++)
            {
                combinaisons[i,j] = ColorSheepEnum.Trash;
            }
        }   
        for (int i = 0; i < colorManager.GetColorCount(); i++)
        {
            combinaisons[i, i] = (ColorSheepEnum)i;
        }

        // line 1 (Red)
        AddCombinaison(ColorSheepEnum.Red, ColorSheepEnum.Yellow, ColorSheepEnum.Orange);
        AddCombinaison(ColorSheepEnum.Red, ColorSheepEnum.Green, ColorSheepEnum.Yellow);
        AddCombinaison(ColorSheepEnum.Red, ColorSheepEnum.Cyan, ColorSheepEnum.White);
        AddCombinaison(ColorSheepEnum.Red, ColorSheepEnum.Blue, ColorSheepEnum.Magenta);
        AddCombinaison(ColorSheepEnum.Red, ColorSheepEnum.Magenta, ColorSheepEnum.Pink);

        // line 2 (Orange)
        AddCombinaison(ColorSheepEnum.Orange, ColorSheepEnum.Apple, ColorSheepEnum.Yellow);
        AddCombinaison(ColorSheepEnum.Orange, ColorSheepEnum.Sky, ColorSheepEnum.White);
        AddCombinaison(ColorSheepEnum.Orange, ColorSheepEnum.Pink, ColorSheepEnum.Red);
        AddCombinaison(ColorSheepEnum.Orange, ColorSheepEnum.White, ColorSheepEnum.Yellow);
        AddCombinaison(ColorSheepEnum.Orange, ColorSheepEnum.Black, ColorSheepEnum.Red);

        // line 3 (Yellow)
        AddCombinaison(ColorSheepEnum.Yellow, ColorSheepEnum.Green, ColorSheepEnum.Apple);
        AddCombinaison(ColorSheepEnum.Yellow, ColorSheepEnum.Cyan, ColorSheepEnum.Green);
        AddCombinaison(ColorSheepEnum.Yellow, ColorSheepEnum.Blue, ColorSheepEnum.White);
        AddCombinaison(ColorSheepEnum.Yellow, ColorSheepEnum.Magenta, ColorSheepEnum.Red);

        // line 4 (Apple)
        AddCombinaison(ColorSheepEnum.Apple, ColorSheepEnum.Turqoise, ColorSheepEnum.Green);
        AddCombinaison(ColorSheepEnum.Apple, ColorSheepEnum.Purple, ColorSheepEnum.White);
        AddCombinaison(ColorSheepEnum.Apple, ColorSheepEnum.White, ColorSheepEnum.Yellow);
        AddCombinaison(ColorSheepEnum.Apple, ColorSheepEnum.Black, ColorSheepEnum.Green);

        // line 5 (Green)
        AddCombinaison(ColorSheepEnum.Green, ColorSheepEnum.Cyan, ColorSheepEnum.Turqoise);
        AddCombinaison(ColorSheepEnum.Green, ColorSheepEnum.Blue, ColorSheepEnum.Cyan);
        AddCombinaison(ColorSheepEnum.Green, ColorSheepEnum.Magenta, ColorSheepEnum.White);

        // line 6 (Turqoise)
        AddCombinaison(ColorSheepEnum.Turqoise, ColorSheepEnum.Sky, ColorSheepEnum.Cyan);
        AddCombinaison(ColorSheepEnum.Turqoise, ColorSheepEnum.Pink, ColorSheepEnum.White);
        AddCombinaison(ColorSheepEnum.Turqoise, ColorSheepEnum.White, ColorSheepEnum.Cyan);
        AddCombinaison(ColorSheepEnum.Turqoise, ColorSheepEnum.Black, ColorSheepEnum.Green);

        // line 7 (Cyan)
        AddCombinaison(ColorSheepEnum.Cyan, ColorSheepEnum.Blue, ColorSheepEnum.Sky);
        AddCombinaison(ColorSheepEnum.Cyan, ColorSheepEnum.Magenta, ColorSheepEnum.Blue);

        // line 8 (Sky)
        AddCombinaison(ColorSheepEnum.Sky, ColorSheepEnum.Purple, ColorSheepEnum.Blue);
        AddCombinaison(ColorSheepEnum.Sky, ColorSheepEnum.White, ColorSheepEnum.Cyan);
        AddCombinaison(ColorSheepEnum.Sky, ColorSheepEnum.Black, ColorSheepEnum.Blue);

        // line 9 (Blue)
        AddCombinaison(ColorSheepEnum.Blue, ColorSheepEnum.Magenta, ColorSheepEnum.Purple);

        // line 10 (Purple)
        AddCombinaison(ColorSheepEnum.Purple, ColorSheepEnum.Pink, ColorSheepEnum.Magenta);
        AddCombinaison(ColorSheepEnum.Purple, ColorSheepEnum.White, ColorSheepEnum.Magenta);
        AddCombinaison(ColorSheepEnum.Purple, ColorSheepEnum.Black, ColorSheepEnum.Blue);

        // line 11 (Magenta)

        // line 12 (Pink)
        AddCombinaison(ColorSheepEnum.Pink, ColorSheepEnum.White, ColorSheepEnum.Magenta);
        AddCombinaison(ColorSheepEnum.Pink, ColorSheepEnum.Black, ColorSheepEnum.Red);

        // line 13 (White)
        AddCombinaison(ColorSheepEnum.White, ColorSheepEnum.Black, ColorSheepEnum.Grey);
    }

    private void AddCombinaison(ColorSheepEnum colorA, ColorSheepEnum colorB, ColorSheepEnum colorC)
    {
        combinaisons[(int)colorA,(int)colorB] = colorC;
        combinaisons[(int)colorB,(int)colorA] = colorC;
    }

    public ColorSheepEnum Combine(ColorSheepEnum colorA, ColorSheepEnum colorB)
    {
        return (ColorSheepEnum)(combinaisons[(int)colorA,(int)colorB]);
    }
}
