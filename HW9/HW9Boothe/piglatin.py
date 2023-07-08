"""
Transforms a string represented as a list of characters into its Pig Latin 
version.

Args:
	l: a list of characters representing one of the input strings
	   e.q., l = ['a', 'p', 'p', 'l', 'e'] represents the string "apple"
	
Returns:
	A list of characters representing the pig latin version of the string 
	represented by argument l. The function is also supposed to change the
	list l in place to its pig latin version.
	   e.g., for argument l = ['a', 'p', 'p', 'l', 'e'], the return should be
	   ['a', 'p', 'p', 'l', 'e', 'w', 'a', 'y'] and also the argument l should
	   be changed to value ['a', 'p', 'p', 'l', 'e', 'w', 'a', 'y'].
"""
def ToPigLatin(l):
	# print(l)
	vowels = ['a', 'e', 'i', 'o', 'u']
	vowels2 = ['a', 'e', 'i', 'o', 'u', 'y', 'w']
	i = 0
	list1 = l.copy()
	for cha in list1:
		if i == 0 and cha.lower() in vowels:
			l.append("way")
			return l
		else:
			if cha.lower() not in vowels2:
				l.remove(cha)
				l.append(cha)
			elif cha.lower() in vowels2 and i == 0:
				l.remove(cha)
				l.append(cha)
			else:
				l.append("ay")
				break
		i+=1
	if list1[0].isupper():
		l[0] = l[0].capitalize()
		j = 0
		for cha2 in l:
			if j != 0 and cha2.isupper():
				l[j] = l[j].lower()
			j+=1
	return l
	
		
# Main -- do not change the code below
s = input('Enter 5 strings separated by one blank space: ')
myList = s.strip().split(' ')

resList = []
for i in range(3):
	l = list(myList[i])
	ToPigLatin(l)
	resList.append(''.join(l))
for i in range(3,5):
	l = list(myList[i])
	resList.append(''.join(ToPigLatin(l)))
print(' '.join(resList))
	

