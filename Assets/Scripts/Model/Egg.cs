using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class Egg
{
    public int col;
    public EggView eggView;
    public float yPos;
    public int row;

    public bool UpdateYPos(float distance, float speedFall)
    {
        if (yPos - distance >= -545)
        {
            float xPos = this.GetXPos(this.col);
            this.eggView.MoveEgg(this.row, xPos, yPos, distance);
            this.row = (int)((this.yPos + 30) / 120) + 5;
            this.yPos -= distance;
            return true;
        }
        return false;   
    }

    public void InitEggModel()
    {
        this.col = -1;
        this.eggView = null;
        this.yPos = -1;
        this.row = -1;
    }

    public void InitEgg(int col, EggView eggView, float speedFall)
    {
        this.row = 0;
        this.yPos = 600;
        this.col = col;
        SetEggView(eggView, speedFall);
    }

    private void SetEggView(EggView eggView, float speedFall)
    {
        this.eggView = eggView;    
        eggView.SetSpeedFall(speedFall);
    }

    private float GetXPos(int col)
    {
        return -300 + col * 150;
    }
}
