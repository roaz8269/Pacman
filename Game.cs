using System;
using System.Threading.Tasks;

public class Game
{
    ICharacter[] characters = new ICharacter[5];
    Mode mode = Mode.NotScared;

    public void SwitchMode()
    {
        Switch();//i 30 sekunder switch
        //Sen Switch i
    }
    void Switch()
    {
        mode = mode switch
        {
            Mode.NotScared => Mode.Scared,
            _ => Mode.NotScared
        };
    }

    void Update()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].NextMove(); //uppdaterar deras koordinater
        }
    }
}