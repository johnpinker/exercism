import re

def count_words(sentence):
    r = re.compile("[a-zA-Z0-9']+")
    d = dict()
    s = ""
    for w in r.findall(sentence):
        if (w[0] == "'"):
            s = w[1: len(w)-1].lower()
        else:
            s = w.lower()
        if (s in d.keys()):
            d[s.lower()] += 1
        else:
            d[s] = 1
    return d

