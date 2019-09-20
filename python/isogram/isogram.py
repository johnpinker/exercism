def is_isogram(string):
    tmpStr = "".join(list(filter(lambda s: s.isalpha(), string.lower())))
    isoset = set(tmpStr)
    if (len(isoset) == len(tmpStr)):
        return True
    else:
        return False
