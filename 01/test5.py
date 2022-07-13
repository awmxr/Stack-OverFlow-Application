def add_more(list):
    list[0]["1212"] = 1111
    print("Inside Function", list)
 
# Driver's code
mylist = [{"qw" : 12}]
 
add_more(mylist)
print("Outside Function:", mylist)