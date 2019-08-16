import java.util.ArrayList;
import java.util.List;

class KindergartenGarden {

    String[] _garden;
    KindergartenGarden(String garden) {
        _garden = garden.split("\n");
    }

    List<Plant> getPlantsOfStudent(String student) {
        int studentIndex = (student.charAt(0) - 'A')*2;
        ArrayList<Plant> retVal = new ArrayList<Plant>();
        retVal.add(Plant.getPlant(_garden[0].charAt(studentIndex)));
        retVal.add(Plant.getPlant(_garden[0].charAt(studentIndex+1)));
        retVal.add(Plant.getPlant(_garden[1].charAt(studentIndex)));
        retVal.add(Plant.getPlant(_garden[1].charAt(studentIndex+1)));
        return retVal;
    }

}
