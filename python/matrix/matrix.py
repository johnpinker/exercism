class Matrix(object):
    def __init__(self, matrix_string):
        self.m = [[int(s2) for s2 in s.split(" ")] for s in matrix_string.split("\n")]


    def row(self, index):        
        return self.m[index-1]

    def column(self, index):
        c = []
        for i in range(len(self.m)):
            c.append(self.m[i][index-1])
        return c
