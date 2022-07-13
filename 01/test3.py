import datetime as dt

list01 = []

date01 = dt.datetime.now()

# sleep 5 s

list01.append(date01 + dt.timedelta(seconds=11))


if(list01[0]-dt.datetime.now() <= dt.timedelta(seconds=10)):
    print("1")
else:
    print("0")







