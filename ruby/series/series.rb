class Series

    def initialize(rawNums)
        @rawNums = rawNums
    end

    def slices(num)
        retVal = []
        i=0
        if (num > @rawNums.length)
            raise ArgumentError
        end
        until i == @rawNums.length-num+1
            retVal = retVal.push(@rawNums[i..i+num-1])
             i += 1
        end
        return retVal
    end

end