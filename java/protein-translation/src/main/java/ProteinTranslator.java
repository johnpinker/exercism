import java.io.Console;
import java.util.*;

class ProteinTranslator {

    private HashMap<String, String> proteinDict= new HashMap<String, String>();

    ProteinTranslator() {
        proteinDict.put("AUG", "Methionine");
        proteinDict.put("UUU, UUC", "Phenylalanine");
        proteinDict.put("UUA, UUG", "Leucine");
        proteinDict.put("UCU, UCC, UCA, UCG", "Serine");
        proteinDict.put("UAU, UAC", "Tyrosine");
        proteinDict.put("UGU, UGC", "Cysteine");
        proteinDict.put("UGG", "Tryptophan");
        proteinDict.put("UAA, UAG, UGA", "");

    }
    List<String> translate(String rnaSequence) {
        ArrayList<String> retList = new ArrayList<String>();
        for (int i=0; i< rnaSequence.length(); i=i+3) {
            String tmpStr = rnaSequence.substring(i, i+3);
            String tmpStr2 = translateProtein(tmpStr);
            if (tmpStr2.isBlank() || tmpStr2.isEmpty())
                break;
            else
                retList.add((tmpStr2));

        }
        return retList;
    }

    private String translateProtein(String s) {
       for (Map.Entry<String, String> e: proteinDict.entrySet()) {
           if (e.getKey().contains(s))
               return e.getValue();
       }
       return "";
    }
}
