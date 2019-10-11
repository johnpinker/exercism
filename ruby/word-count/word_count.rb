
class Phrase

    def initialize(inString)
        @inString = inString
    end
    def word_count
        st = @inString.downcase.scan(/\b([\w']+)\b/).map { |w| w[0]}
        h = Hash.new()
        st.uniq.each { |e| h[e] =st.count(e) }
        return h
    end

end