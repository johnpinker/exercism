class HighScores

    def initialize(scoreList)
        @scoreList=scoreList
    end

    def scores()
        return @scoreList
    end

    def personal_best()
        return @scoreList.max()
    end

    def latest()
        return @scoreList.last()
    end

    def personal_top_three()
        return @scoreList.sort { |x,y| y <=> x }.take(3)
    end

    def latest_is_personal_best?
        return self.latest() == self.personal_best()
    end
end