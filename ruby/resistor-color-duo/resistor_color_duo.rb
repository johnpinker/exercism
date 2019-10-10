class ResistorColorDuo

    def self.value(colorArray)
        colors = [ "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" ]
        return colorArray.first(2)
            .map {|x| colors.index(x)} 
            .join()
            .to_i
    end
end
