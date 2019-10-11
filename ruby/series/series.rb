class Series

    def initialize(rawNums)
        @rawNums = rawNums
    end

    def slices(num)
        retVal = []
        if (num > @rawNums.length)
            raise ArgumentError
        end
        @rawNums.split("").each.with_index do | e, i | 
            if i + num-1 < @rawNums.length
                retVal.push(@rawNums[i..i+num-1])
            end
        end
        return retVal
    end

end