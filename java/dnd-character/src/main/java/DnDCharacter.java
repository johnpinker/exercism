import java.util.*;

class DnDCharacter {

    private int _ability = -1;
    int ability() {
        if (_ability == -1)
            _ability = getRandomThrows();
        return _ability;

    }


    int modifier(int input) {
        return (int)Math.floor(((input-10.0)/2));
        //return (int)Math.floor(((this.getConstitution()-10.0)/2));
    }

    int _strength = -1;
    int getStrength() {
        if (_ability == -1)
            _ability = getRandomThrows();
        return _ability;
    }

    int _dexterity = -1;
    int getDexterity() {
        if (_dexterity == -1)
            _dexterity = getRandomThrows();
        return _dexterity;
    }

    int _constitution = -1;
    int getConstitution() {
        if (_constitution == -1)
            _constitution = getRandomThrows();
        return _constitution;
    }

    int _intelligence = -1;
    int getIntelligence() {
        if (_intelligence == -1)
            _intelligence = getRandomThrows();
        return _intelligence;
    }

    int _wisdom = -1;
    int getWisdom() {
        if (_wisdom == -1)
            _wisdom = getRandomThrows();
        return _wisdom;
    }

    int _charisma = -1;
    int getCharisma() {
        if (_charisma == -1)
            _charisma = getRandomThrows();
        return _charisma;
    }

    int _hitpoints = -1;
    int getHitpoints() {
        if (_hitpoints == -1)
            _hitpoints = modifier(getConstitution())+10;
        return _hitpoints;
    }

    int getRandomThrows()
    {
        int lowestIndex= 0;
        ArrayList<Integer> rollList = new ArrayList<Integer>();
        for (int i=0; i < 4; i++)
            rollList.add((int)Math.ceil((Math.random()*6)));
        for (int i=0; i<rollList.size(); i++)
            if (rollList.get(lowestIndex) > rollList.get(i))
                lowestIndex = i;
        rollList.remove(lowestIndex);
        int newTotal = 0;
        for (Integer data: rollList)
            newTotal += data;
        return newTotal;
    }
}
