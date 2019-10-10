class Acronym
    def self.abbreviate(fullString)
        fullString.scan(/\b\w/).join.upcase
    end
end