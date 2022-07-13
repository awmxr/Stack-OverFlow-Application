import datetime as dt
import time
import socket	
import queue
from types import coroutine

# q2 = queue.Queue()
# q3 = queue.Queue()
# from myServer import clientConected
# clientConected = {}

def check_Fin(a):
    if "<SSFINSS>" in a:
        return True
    return False



def check_client_connection(clientConected):
    # iii = 0
    # while(True):
    # time.sleep(2)
    # print(iii)
    # iii += 1
    try:
        # print("client2",clientConected)
        for i in list(clientConected):
            if ( dt.datetime.now() - clientConected[i][1] > dt.timedelta(seconds=100)):
                clientConected[i][0].close()
                del clientConected[i]

        # print("client",clientConected)
        # if q3.empty():
        #     q3.put(clientConected)
        # else:
        #     while(q3.empty() == False):
        #         xxx = q3.get()
    except Exception as  es:
        # print("z4  " , es)
        pass
        # time.sleep(3)
        # try:
        #     if q2.empty():
        #         continue
        #     z = q2.get()
        #     print("z" , z)
        #     clientConected[z[2][0]] = (z[0] , z[1])
        #     print("z2" , clientConected)
        # except Exception as es:
        #     print("z3  " , es)
        #     pass

        
            
    
        
            






