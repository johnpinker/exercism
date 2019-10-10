
class Matrix

    def initialize(matString)
        @matrix = Array(matString.split("\n").map { |s|
            Array(s.split(" ").map(&:to_i))
        })
    end

    def rows
        return @matrix
    end

    def columns
        @columns = []
        for i in 0..@matrix[0].length-1
            @columns = @columns.push([])
            for j in 0..@matrix.length-1
                @columns[i] = @columns[i].push(@matrix[j][i])
            end
        end
        return @columns
    end
end
