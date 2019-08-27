using System;
using System.Linq;
using System.Collections.Generic;
public class BowlingGame
{

    List<int> rolls = new List<int>();
    int[] frames = new int[10];
    int frame = 0;
    int numStrikes = 0;
    bool openFrame = false;
    bool isSpare = false;
    int lastFrameRolls = 0;
    public void Roll(int pins) 
    {
        if (pins < 0 || pins > 10) throw new ArgumentException();
        if (frame == 9)
        {
            rolls.Add(pins);
            //if (rolls.Where(s => s != 10).Sum() > 10) throw new ArgumentException();
            if (pins == 10 && rolls.Sum()%10 != 0) throw new ArgumentException();
            if (rolls.Count() > 2 && rolls.Sum() < 10) throw new ArgumentException();
            if (rolls.Count() > 2 && rolls.Take(2).Sum() < 10) throw new ArgumentException();
            if (rolls.Count() > 3) throw new ArgumentException();
            if (rolls.ElementAt(0) == 10 && rolls.Skip(1).Where(s => s != 10).Sum() > 10) throw new ArgumentException();
            return;
        }

        if (pins == 10 && numStrikes != 2)
        {
            frame++;
            numStrikes++;
            openFrame = false;
            return;
        }
        else if (pins == 10 && numStrikes == 2)
        {
            frames[frame-2] = 30;
            openFrame = false;
            frame++;
            //numStrikes--;
            return;
        }
        if (numStrikes == 2)
        {
            frames[frame-2] = 20 + pins;
            numStrikes--;
            openFrame = true;
            frames[frame] = pins;
            return;
        } 
        else if (numStrikes == 1 && openFrame == true)
        {
            frames[frame] += pins;
            frames[frame-1] = 10 + frames[frame];
            frame++;
            numStrikes = 0;
            openFrame = false;
            return;
        }
        if (isSpare)
        {
            if (frame != 9) frames[frame-1] += pins;
            isSpare = false;
            openFrame = true;
            frames[frame] += pins;
            return;
        }

        frames[frame] += pins;
        if (frames[frame] > 10) throw new ArgumentException();
        isSpare  = frames[frame] == 10;
        frame = openFrame  && frame != 9 ? frame + 1 : frame;
        openFrame = openFrame ? false : true;
        
    }


    public int? Score()
    {
        if (rolls.Count() < 2) throw new ArgumentException();
        if (rolls.Count() == 2 && rolls.Sum() == 20) throw new ArgumentException();
        if (rolls.Count() == 2 && rolls.Sum() == 10) throw new ArgumentException();
        ProcessFrame10();
        return frames.Sum();
    }

    private void ProcessFrame10()
    {
        if (numStrikes == 2)
        {
            frames[frame-1] = 10 + rolls.ElementAt(0) + rolls.ElementAt(1);
            frames[frame-2] = frames[frame-1];
            frames[frame] = rolls.Sum();
        }
        else if (numStrikes == 1)
        {
            frames[frame-2] = 10 + frames[frame-1];
            frames[frame] = rolls.Sum();
        }
        else
        {
            frames[frame] = rolls.Sum();
        }
        int strikes = rolls.Where(s => s == 10).Count();

    }
}