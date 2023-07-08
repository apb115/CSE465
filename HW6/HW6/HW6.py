import sys

# Begin by opening up the first arg file
f = open(sys.argv[1], "r")

# Next open the second arg file
g = open(sys.argv[2], "r")

# Object for g lines
gPos = []
for lines in g:
    gPos.append(lines)

for lines in f:
    lines = lines.strip().split("\t")
    if "ID" in lines and "<<" not in lines:
        index = lines.index("ID")
        elements = []
        for element in lines:
            elements.append(element)
        continue
    else:
        name = str(lines[index]) + ".txt"
        h = open(name, "w")
        # copy all args from g into this file
        for lines2 in gPos:
            if "ID" in lines2 and "NAME" in lines2: continue
            copy = lines2
            for x in elements:
                replacer = "<<" + str(x) + ">>"
                if replacer in lines2:
                    copy = copy.replace(replacer, str(lines[elements.index(x)]))
            h.write(copy)
        h.close()
f.close()

